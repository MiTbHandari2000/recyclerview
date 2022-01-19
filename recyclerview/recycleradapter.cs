using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace recyclerview
{
    class recycleradapter : RecyclerView.Adapter
    {
         
        Context con;
        
        public List<string> employeenames;

        public recycleradapter(List<string> employeenames,Context context)
        {
            this.employeenames = employeenames;
            con = context;
        }

        //public override int ItemCount => throw new NotImplementedException();
        public override int ItemCount
        {
            get { return employeenames.Count; }
        }
    

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder vh = holder as MyViewHolder;

            vh.textView.Text = employeenames[position].ToString();
            vh.textView.Click += delegate {
                Toast.MakeText(con, ""+employeenames[position], ToastLength.Long).Show();
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.rowitem, parent, false);
            MyViewHolder vh = new MyViewHolder(itemView);
            return vh;
        }
        public class MyViewHolder : RecyclerView.ViewHolder 
        {
            private readonly Action<int> listener;
            public TextView textView;
            public MyViewHolder(View itemView , Action<int> listener ) : base(itemView)
            {
                   
                textView = itemView.FindViewById<TextView>(Resource.Id.textitem);
                this.listener = listener;
                itemView.Click += ItemView_Click;
            }

            private void ItemView_Click(object sender, EventArgs e)
            {
                listener(LayoutPosition);
            }
        }

    }
}