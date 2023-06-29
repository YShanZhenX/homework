package com.example.myapplication;
import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
public class LoginActivity extends AppCompatActivity {
    private EditText etUserId,etPasswd;
    private Button btnLogin;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        etUserId=findViewById(R.id.et_login_userid);
        etPasswd=findViewById(R.id.et_login_passwd);
        btnLogin=findViewById(R.id.btn_login);
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String userId=etUserId.getText().toString();
                String passwd=etPasswd.getText().toString();
                Intent intent=new Intent();
                if(userId.equals("xiaoming")&&passwd.equals("12345")){

                    Toast.makeText(LoginActivity.this,"登陆成功!",Toast.LENGTH_SHORT).show();
                    intent.setClass(LoginActivity.this,Main1Activity.class);
                    intent.putExtra("userId",userId);
                    intent.putExtra("userName","小明");
                    startActivity(intent);
                }else{


                    setResult(20,intent);
                }

                finish();
            }
        });
    }



}
