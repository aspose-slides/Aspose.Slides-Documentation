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
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างแอปโมบาย Xamarin ด้วย C# เพื่อดู, แก้ไขและแปลงการนำเสนอด้วย Aspose.Slides รองรับคุณลักษณะที่ครบครันสำหรับ PPT, PPTX และ ODP บน Android."
---
## **บทนำ**

Xamarin เป็นเฟรมเวิร์กที่ใช้สำหรับการพัฒนาแอปพลิเคชันบนมือถือใน .NET C#. Xamarin มีเครื่องมือและไลบรารีที่ขยายความสามารถของแพลตฟอร์ม .NET. มันอนุญาตให้นักพัฒนาสร้างแอปพลิเคชันสำหรับระบบปฏิบัติการ **Android**.

{{% alert color="info" %}} 

สำหรับการพัฒนาใน Xamarin โปรแกรมเมอร์สามารถใช้สภาพแวดล้อมการพัฒนาปกติของพวกเขา (C#, Visual Studioและไลบรารีของบุคคลที่สาม). 

{{% /alert %}}

Aspose.Slides API ทำงานบนแพลตฟอร์ม Xamarin. เพื่อให้บรรลุสิ่งนี้ แพ็กเกจ Aspose.Slides .NET เพิ่ม DLL แยกสำหรับ Xamarin. Aspose.Slides for Xamarin รองรับส่วนใหญ่ของคุณลักษณะที่มีในรุ่น .NET:

- แปลงและดูพรีเซนเทชัน
- แก้ไขเนื้อหาในพรีเซนเทชัน: ข้อความ, รูปร่าง, แผนภูมิ, SmartArt, สื่อ audio/video, ฟอนต์ ฯลฯ
- จัดการ/ทำงานกับแอนิเมชัน, เอฟเฟ็กต์ 2D, WordArt ฯลฯ
- จัดการ/ทำงานกับเมตาเดต้าและคุณสมบัติเขเอกสาร
- โคลน, ผสาน, เปรียบเทียบ, แยก, ฯลฯ

เราได้จัดทำการเปรียบเทียบคุณลักษณะทั้งหมดในส่วนอื่นใกล้ด้านล่างของหน้านี้

ใน Aspose.Slides for Xamarin API คลาส, เนมสเปซ, โลจิกและพฤติกรรมจะเหมือนกับรุ่น .NET มากที่สุดเท่าที่จะทำได้ คุณสามารถย้ายแอปพลิเคชัน Aspose.Slides .NET ของคุณไปยัง Xamarin ได้ด้วยค่าใช้จ่ายที่ต่ำที่สุด

## **ตัวอย่างอย่างรวดเร็ว**

คุณสามารถใช้ Aspose.Slides for Xamarin เพื่อสร้างและใช้งานแอปพลิเคชัน C# ของคุณผ่าน Slides for Android

เราจัดให้มีตัวอย่างแอปพลิเคชัน Android ผ่าน Xamarin ที่ใช้ Aspose.Slides เพื่อแสดงสไลด์พรีเซนเทชันและเพิ่มรูปร่างใหม่บนสไลด์เมื่อสัมผัส คุณสามารถค้นหาโค้ดเต็มของตัวอย่างได้บน [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

เริ่มต้นโดยการสร้าง Xamarin Android App:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

แรกเราจะสร้างเลเอาต์เนื้อหาซึ่งจะประกอบด้วย ImageView, ปุ่ม Prev และ Next:

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

ที่นี่ เราอ้างอิงไลบรารี "Aspose.Slides.Droid.dll" ที่รวมพรีเซนเทชันตัวอย่าง ("HelloWorld.pptx") เข้าไปใน Assets ของแอปพลิเคชัน Xamarin และเพิ่มการเริ่มต้นใน MainActivity:

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

เพิ่มฟังก์ชันเพื่อแสดงสไลด์ Prev และ Next เมื่อกดปุ่ม:

**C# - MainActivity.cs - Display slides on Prev and Next button click**
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

สุดท้าย เราจะทำฟังก์ชันเพื่อเพิ่มรูปร่างวงรีบนสไลด์เมื่อสัมผัส:

**C# - MainActivity.cs - Add ellipse by slide click**
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

แต่ละคลิกบนสไลด์พรีเซนเทชันจะทำให้เพิ่มวงรีสีสุ่ม:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **คุณลักษณะที่รองรับ**

|**คุณสมบัติ**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**คุณลักษณะการพรีเซนเทชัน:**| | |
|สร้างพรีเซนเทชันใหม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เปิด/บันทึกรูปแบบ PowerPoint 97 - 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เปิด/บันทึกรูปแบบ PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับส่วนขยาย PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับส่วนขยาย PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับคุณลักษณะ PowerPoint 2016|restricted|restricted|
|รองรับคุณลักษณะ PowerPoint 2019|restricted|restricted|
|การแปลง PPT เป็น PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การแปลง PPTX เป็น PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX ใน PPT|restricted|restricted|
|การประมวลผลธีม|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การประมวลผลมาโคร|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การประมวลผลคุณสมบัติเขเอกสาร|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การป้องกันด้วยรหัสผ่าน|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การสกัดข้อความอย่างรวดเร็ว|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ฝังฟอนต์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การแสดงคอมเมนต์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การขัดจังหวะงานที่ทำงานนาน|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**รูปแบบการส่งออก:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**รูปแบบการนำเข้า:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์มาสเตอร์:**| | |
|เข้าถึงสไลด์มาสเตอร์ที่มีอยู่ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์มาสเตอร์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนสไลด์มาสเตอร์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์เลย์เอาต์:**| | |
|เข้าถึงสไลด์เลย์เอาต์ที่มีอยู่ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์เลย์เอาต์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนสไลด์เลย์เอาต์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์:**| | |
|เข้าถึงสไลด์ที่มีอยู่ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ส่งออกสไลด์เป็นภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/แก้ไข/ลบส่วนของสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์โน้ต**| | |
|เข้าถึงสไลด์โน้ตที่มีอยู่ทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะรูปร่าง:**| | |
|เข้าถึงรูปร่างทั้งหมดของสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เพิ่มรูปร่างใหม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนรูปร่าง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ส่งออกรูปร่างแยกเป็นภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ประเภทรูปร่างที่รองรับ:**| | |
|ประเภทรูปร่างที่กำหนดล่วงหน้าทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|กรอบรูปภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ตาราง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|แผนภูมิ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|แผนภาพเก่า|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|วัตถุ OLE, ActiveX|restricted|restricted|
|เฟรมวิดีโอ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เฟรมเสียง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|คอนเนคเตอร์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะกลุ่มรูปร่าง:**| | |
|เข้าถึงกลุ่มรูปร่าง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้างกลุ่มรูปร่าง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ยกเลิกการจัดกลุ่มรูปร่างที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะเอฟเฟกต์ของรูปร่าง:**| | |
|เอฟเฟกต์ 2D|restricted|restricted|
|เอฟเฟกต์ 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**คุณลักษณะข้อความ:**| | |
|การจัดรูปแบบย่อหน้า|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การจัดรูปแบบส่วนย่อย|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะแอนิเมชัน:**| | |
|ส่งออกแอนิเมชันเป็น SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|ส่งออกแอนิเมชันเป็น HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|