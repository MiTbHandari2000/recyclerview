using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;

namespace recyclerview
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<string> employeenames;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView recycler;
        recycleradapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);
           
            employeenames = new List<string> { "sagar", "meet", "manish", "jay", "Aires", "Akash", "Raju", "meet", "manish", "jay", "Aires", "Akash", "Raju", "meet", "manish", "jay", "Aires", "Akash", "Raju" };
            mLayoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(mLayoutManager);
            mAdapter = new recycleradapter(employeenames, ApplicationContext);
            recycler.SetAdapter(mAdapter);
          

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}