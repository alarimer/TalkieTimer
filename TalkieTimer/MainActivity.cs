using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TalkieTimer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            long elapsed1 = 0;
            long elapsed2 = 0;

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainActivity);

            // controls
            Switch s1 = FindViewById<Switch>(Resource.Id.Person1Switch);
            Chronometer c1 = FindViewById<Chronometer>(Resource.Id.Person1Chronometer);

            s1.CheckedChange += (sender, e) =>
            {
                if (e.IsChecked)
                {
                    c1.Base = SystemClock.ElapsedRealtime() - elapsed1;
                    c1.Start();
                }
                else
                {
                    c1.Stop();
                    elapsed1 = SystemClock.ElapsedRealtime() - c1.Base;
                }
            };

            Switch s2 = FindViewById<Switch>(Resource.Id.Person2Switch);
            Chronometer c2 = FindViewById<Chronometer>(Resource.Id.Person2Chronometer);

            s2.CheckedChange += (sender, e) =>
            {
                if (e.IsChecked)
                {
                    c2.Base = SystemClock.ElapsedRealtime() - elapsed2;
                    c2.Start();
                }
                else
                {
                    c2.Stop();
                    elapsed2 = SystemClock.ElapsedRealtime() - c2.Base;
                }
            };

            Button reset = FindViewById<Button>(Resource.Id.ResetButton);

            reset.Click += (sender, e) =>
            {
                s1.Checked = s2.Checked = false;
                c1.Base = c2.Base = SystemClock.ElapsedRealtime();
                c1.Stop();
                c2.Stop();
                elapsed1 = elapsed2 = 0;
            };
        }
    }
}