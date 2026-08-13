---
title: Aspose.Slides สำหรับ Xamarin
type: docs
weight: 150
url: /th/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- การพัฒนาโมบาย
- Android
- PowerPoint
- OpenDocument
- งานพรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "สร้างแอปมือถือ Xamarin ด้วย C# เพื่อดู, แก้ไขและแปลงงานพรีเซนเทชันด้วย Aspose.Slides รองรับคุณลักษณะหลากหลายสำหรับ PPT, PPTX และ ODP บน Android."
---
## **บทนำ**

Xamarin เป็นกรอบงานที่ใช้สำหรับการพัฒนาแอปมือถือใน .NET C#. Xamarin มีเครื่องมือและไลบรารีที่ขยายความสามารถของแพลตฟอร์ม .NET ทำให้ผู้พัฒนาสามารถสร้างแอปพลิเคชันสำหรับระบบปฏิบัติการ **Android** ได้

{{% alert color="info" %}} 
สำหรับการพัฒนาใน Xamarin นักพัฒนาสามารถใช้สภาพแวดล้อมการพัฒนาปกติของตน (C#, Visual Studio และไลบรารีของบุคคลที่สาม)
{{% /alert %}}

Aspose.Slides API ทำงานบนแพลตฟอร์ม Xamarin เพื่อให้บรรลุเป้าหมายนี้ แพ็คเกจ Aspose.Slides .NET จะเพิ่ม DLL แยกสำหรับ Xamarin Aspose.Slides สำหรับ Xamarin รองรับคุณสมบัติจำนวนมากที่มีในเวอร์ชัน .NET:

- การแปลงและดูงานพรีเซนเทชัน
- การแก้ไขเนื้อหาในงานพรีเซนเทชัน: ข้อความ, รูปร่าง, แผนภูมิ, SmartArt, สื่อเสียง/วิดีโอ, ฟอนต์ ฯลฯ
- การจัดการ/จัดการกับแอนิเมชัน, เอฟเฟกต์ 2D, WordArt ฯลฯ
- การจัดการ/จัดการกับข้อมูลเมตาและคุณสมบัติเบื้องต้นของเอกสาร
- การพิมพ์, คัดลอก, รวม, เปรียบเทียบ, แบ่ง, ฯลฯ

เรามีการเปรียบเทียบคุณสมบัติทั้งหมดในส่วนอื่นที่อยู่ใกล้ส่วนล่างของหน้านี้

ใน Aspose.Slides สำหรับ Xamarin API คลาส, เนมสเปซ, ตรรกะและพฤติกรรมจะเหมือนกับเวอร์ชัน .NET ให้คุณย้ายแอปพลิเคชัน Aspose.Slides .NET ไปสู่ Xamarin ได้ด้วยต้นทุนที่ต่ำที่สุด


## **ตัวอย่างอย่างเร็ว**
คุณสามารถใช้ Aspose.Slides สำหรับ Xamarin เพื่อสร้างและใช้แอปพลิเคชัน C# ของคุณผ่าน Slides for Android

เราจัดเตรียมตัวอย่างแอป Android ผ่าน Xamarin ที่ใช้ Aspose.Slides เพื่อแสดงสไลด์พรีเซนเทชันและเพิ่มรูปทรงใหม่บนสไลด์เมื่อสัมผัส คุณสามารถค้นหาโค้ดต้นฉบับเต็มของตัวอย่างได้ที่ [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin)

เริ่มต้นโดยการสร้างแอป Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

ขั้นแรกเราจะสร้างเค้าโครงเนื้อหาที่จะมี ImageView, ปุ่ม Prev และ Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - สร้างเค้าโครงเนื้อหา**
``` 
 <LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:orientation=    "vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:showIn="@layout/activity_main">
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="1"
        android:id="@+id/linearLayout1">
        <ImageView
            android:src="@android:drawable/ic_menu_gallery"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            android:id="@+id/imageView"
            android:scaleType="fitCenter" />
    </LinearLayout>

    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="10"
        android:id="@+id/linearLayout2">
        <Button
            android:text="Prev"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonPrev" />
        <Button
            android:text="Next"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonNext"/>
    </LinearLayout>
</LinearLayout>
```

ที่นี่เราจะอ้างอิงไลบรารี "Aspose.Slides.Droid.dll" ที่รวมตัวอย่างพรีเซนเทชัน ("HelloWorld.pptx") ไว้ใน Assets ของแอป Xamarin และเพิ่มการเริ่มต้นใน MainActivity:

**C# - MainActivity.cs - การเริ่มต้น**
``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Aspose.Slides.Presentation presentation;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        if (presentation == null)
        {
            using (Stream input = Assets.Open("HelloWorld.pptx"))
            {
                presentation = new Aspose.Slides.Presentation(input);
            }
        }
    }

    protected override void OnPause()
    {
        if (presentation != null)
        {
            presentation.Dispose();
            presentation = null;
        }
    }
}
```

เพิ่มฟังก์ชันเพื่อแสดงสไลด์ Prev และ Next เมื่อตัวเลือกกดปุ่ม:

**C# - MainActivity.cs - แสดงสไลด์เมื่อคลิกปุ่ม Prev และ Next**
``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Button buttonNext;
    private Button buttonPrev;
    ImageView imageView;

    private Aspose.Slides.Presentation presentation;

    private int currentSlideNumber;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        base.OnResume();
        LoadPresentation();
        currentSlideNumber = 0;
        if (buttonNext == null)
        {
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
        }

        if (buttonPrev == null)
        {
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
        }

        if(imageView == null)
        {
            imageView= FindViewById<ImageView>(Resource.Id.imageView);
        }

        buttonNext.Click += ButtonNext_Click;
        buttonPrev.Click += ButtonPrev_Click;
        RefreshButtonsStatus();
        ShowSlide(currentSlideNumber);
    }

    private void ButtonNext_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber > (presentation.Slides.Count - 1))
        {
            return;
        }

        ShowSlide(++currentSlideNumber);
        RefreshButtonsStatus();
    }

    private void ButtonPrev_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber == 0)
        {
            return;
        }

        ShowSlide(--currentSlideNumber);
        RefreshButtonsStatus();
    }

    protected override void OnPause()
    {
        base.OnPause();
        if (buttonNext != null)
        {
            buttonNext.Dispose();
            buttonNext = null;
        }

        if (buttonPrev != null)
        {
            buttonPrev.Dispose();
            buttonPrev = null;
        }

        if(imageView != null)
        {
            imageView.Dispose();
            imageView = null;
        }

        DisposePresentation();
    }

    private void RefreshButtonsStatus()
    {
        buttonNext.Enabled = currentSlideNumber < (presentation.Slides.Count - 1);
        buttonPrev.Enabled = currentSlideNumber > 0;
    }

    private void ShowSlide(int slideNumber)
    {
        Aspose.Slides.Drawing.Xamarin.Size size = presentation.SlideSize.Size.ToSize();
        Aspose.Slides.Drawing.Xamarin.Bitmap bitmap = presentation.Slides[slideNumber].GetThumbnail(size);
        imageView.SetImageBitmap(bitmap.ToNativeBitmap());
    }

    private void LoadPresentation()
    {
        if(presentation != null)
        {
            return;
        }

        using (Stream input = Assets.Open("HelloWorld.pptx"))
        {
            presentation = new Aspose.Slides.Presentation(input);
        }
    }

    private void DisposePresentation()
    {
        if(presentation == null)
        {
            return;
        }
        
        presentation.Dispose();
        presentation = null;
    }

}
```

สุดท้ายให้เราติดตั้งฟังก์ชันเพื่อเพิ่มรูปทรงวงรีเมื่อสัมผัสสไลด์:

**C# - MainActivity.cs - เพิ่มวงรีด้วยการคลิกสไลด์**
``` csharp
 private void ImageView_Touch(object sender, Android.Views.View.TouchEventArgs e)
{
    int[] location = new int[2];
    imageView.GetLocationOnScreen(location);
    int x = (int)e.Event.GetX();
    int y = (int)e.Event.GetY();
    int posX = x - location[0];
    int posY = y - location[0];
    
    Aspose.Slides.Drawing.Xamarin.Size presSize = presentation.SlideSize.Size.ToSize();

    float coeffX = (float)presSize.Width / imageView.Width;
    float coeffY = (float)presSize.Height / imageView.Height;
    int presPosX = (int)(posX * coeffX);
    int presPosY = (int)(posY * coeffY);
    int width = presSize.Width / 50;

    int height = width;
    Aspose.Slides.IAutoShape ellipse = presentation.Slides[currentSlideNumber].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, presPosX, presPosY, width, height);
    ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;

    Random random = new Random();
    Aspose.Slides.Drawing.Xamarin.Color slidesColor = Aspose.Slides.Drawing.Xamarin.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
    ellipse.FillFormat.SolidFillColor.Color = slidesColor;
    ShowSlide(currentSlideNumber);
}
```

ทุกครั้งที่คลิกบนสไลด์พรีเซนเทชันจะทำให้วงรีที่มีสีสุ่มถูกเพิ่มเข้าไป:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **คุณสมบัติที่รองรับ**

|**คุณสมบัติ**|**Aspose.Slides สำหรับ .NET**|**Aspose.Slides สำหรับ Xamarin**|
| :- | :- | :- |
|**คุณสมบัติของงานพรีเซนเทชัน**| | |
|สร้างงานพรีเซนเทชันใหม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เปิด/บันทึกรูปแบบ PowerPoint 97 - 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เปิด/บันทึกรูปแบบ PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับส่วนขยาย PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับส่วนขยาย PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับคุณสมบัติ PowerPoint 2016|จำกัด|จำกัด|
|รองรับคุณสมบัติ PowerPoint 2019|จำกัด|จำกัด|
|การแปลง PPT เป็น PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การแปลง PPTX เป็น PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX อยู่ใน PPT|จำกัด|จำกัด|
|ประมวลผลธีม|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ประมวลผลแมโคร|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ประมวลผลคุณสมบัติเบื้องต้นของเอกสาร|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การป้องกันด้วยรหัสผ่าน|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การสกัดข้อความเร็ว|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ฝังฟอนต์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การแสดงคอมเมนต์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การขัดจังหวะงานที่ใช้เวลานาน|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**รูปแบบการส่งออก**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|จำกัด|จำกัด|
|SWF|จำกัด|จำกัด|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**รูปแบบการนำเข้า**| | |
|HTML|จำกัด|จำกัด|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของมาสเตอร์สไลด์**| | |
|เข้าถึงมาสเตอร์สไลด์ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบมาสเตอร์สไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|คัดลอกมาสเตอร์สไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของเลย์เอาต์สไลด์**| | |
|เข้าถึงเลย์เอาต์สไลด์ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบเลย์เอาต์สไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|คัดลอกเลย์เอาต์สไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของสไลด์**| | |
|เข้าถึงสไลด์ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|คัดลอกสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ส่งออกสไลด์เป็นภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/แก้ไข/ลบส่วนของสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของสไลด์โน้ต**| | |
|เข้าถึงโน้ตสไลด์ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของรูปทรง**| | |
|เข้าถึงรูปทรงทั้งหมดในสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เพิ่มรูปทรงใหม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|คัดลอกรูปทรง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ส่งออกรูปทรงเป็นภาพแยก|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ประเภทรูปทรงที่สนับสนุน**| | |
|รูปทรงที่กำหนดไว้ล่วงหน้าทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|กรอบรูปภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ตาราง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|แผนภูมิ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|แผนภาพเก่า|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, วัตถุ ActiveX|จำกัด|จำกัด|
|กรอบวิดีโอ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|กรอบเสียง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ตัวเชื่อม|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของกลุ่มรูปทรง**| | |
|เข้าถึงกลุ่มรูปทรง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้างกลุ่มรูปทรง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ยกเลิกการจัดกลุ่มรูปทรงที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของเอฟเฟกต์รูปทรง**| | |
|เอฟเฟกต์ 2D|จำกัด|จำกัด|
|เอฟเฟกต์ 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**คุณสมบัติของข้อความ**| | |
|การจัดรูปแบบย่อหน้า|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การจัดรูปแบบช่วงข้อความ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณสมบัติของแอนิเมชัน**| | |
|ส่งออกแอนิเมชันเป็น SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|ส่งออกแอนิเมชันเป็น HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|