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
description: "สร้างแอปโมบาย Xamarin ด้วย C# เพื่อดู แก้ไขและแปลงงานพรีเซนเทชันด้วย Aspose.Slides รองรับคุณลักษณะหลากหลายสำหรับ PPT, PPTX และ ODP บน Android."
---
## **บทนำ**

Xamarin เป็นเฟรมเวิร์กที่ใช้สำหรับการพัฒนาโมบายใน .NET C#. Xamarin มีเครื่องมือและไลบรารีที่ขยายความสามารถของแพลตฟอร์ม .NET มันช่วยให้นักพัฒนาสร้างแอปพลิเคชันสำหรับระบบปฏิบัติการ **Android** 

{{% alert color="primary" %}} 

สำหรับการพัฒนาใน Xamarin นักโปรแกรมเมอร์สามารถใช้สภาพแวดล้อมการพัฒนาปกติของตน (C#, Visual Studio, และไลบรารีของบุคคลที่สาม).

{{% /alert %}}

Aspose.Slides API ทำงานบนแพลตฟอร์ม Xamarin เพื่อให้บรรลุสิ่งนี้ แพ็กเกจ Aspose.Slides .NET เพิ่ม DLL แยกสำหรับ Xamarin Aspose.Slides สำหรับ Xamarin รองรับคุณลักษณะส่วนใหญ่ที่มีในเวอร์ชัน .NET:

- แปลงและดูงานพรีเซนเทชัน
- แก้ไขเนื้อหาในงานพรีเซนเทชัน: ข้อความ, รูปร่าง, แผนภูมิ, SmartArt, เสียง/วิดีโอ, ฟอนท์ ฯลฯ
- จัดการ/ทำงานกับแอนิเมชัน, เอฟเฟ็กต์ 2D, WordArt ฯลฯ
- จัดการเมทาดาต้าและคุณสมบัติของเอกสาร
- พิมพ์, โคลน, ผสาน, เปรียบเทียบ, แบ่ง, ฯลฯ

เราได้ให้การเปรียบเทียบคุณลักษณะทั้งหมดในส่วนอื่นใกล้ส่วนท้ายของหน้านี้

ใน Aspose.Slides for Xamarin API คลาส, เนมสเปซ, ลอจิกและพฤติกรรมจะใกล้เคียงกับเวอร์ชัน .NET ให้มากที่สุด คุณสามารถย้ายแอปพลิเคชัน Aspose.Slides .NET ของคุณไปยัง Xamarin ได้ด้วยค่าใช้จ่ายขั้นต่ำ


## **ตัวอย่างอย่างเร็ว**
คุณสามารถใช้ Aspose.Slides for Xamarin เพื่อสร้างและใช้งานแอปพลิเคชัน C# ของคุณผ่าน Slides for Android

เรานำเสนอ ตัวอย่างของแอป Android ผ่าน Xamarin ที่ใช้ Aspose.Slides เพื่อแสดงสไลด์พรีเซนเทชันและเพิ่มรูปร่างใหม่บนสไลด์เมื่อสัมผัส คุณสามารถค้นหาโค้ดเต็มของตัวอย่างได้บน[GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

มาทำการสร้างแอป Xamarin Android กัน:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

แรก เราจะสร้างเค้าโครงเนื้อหาที่จะประกอบด้วย ImageView, ปุ่ม Prev และ Next:

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

ที่นี่ เราอ้างอิงไลบรารี "Aspose.Slides.Droid.dll" ที่รวมตัวอย่างพรีเซนเทชัน ("HelloWorld.pptx") เข้าไปในโฟลเดอร์ Assets ของแอป Xamarin และเพิ่มการเริ่มต้นใน MainActivity:

**C# - MainActivity.cs - การเริ่มต้น**
``` csharp
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

ให้เพิ่มฟังก์ชันเพื่อแสดงสไลด์ Prev และ Next เมื่อกดปุ่ม:

**C# - MainActivity.cs - แสดงสไลด์เมื่อคลิกปุ่ม Prev และ Next**
``` csharp
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

สุดท้าย ให้ implement ฟังก์ชันเพื่อเพิ่มรูปร่างวงรีเมื่อสัมผัสสไลด์:

**C# - MainActivity.cs - เพิ่มวงรีเมื่อคลิกสไลด์**
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

แต่ละการคลิกบนสไลด์พรีเซนเทชันจะทำให้เพิ่มวงรีสีสุ่ม:
![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **คุณสมบัติที่สนับสนุน**

|**คุณสมบัติ**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**คุณสมบัติงานพรีเซนเทชัน:**| | |
|สร้างงานพรีเซนเทชันใหม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เปิด/บันทึกรูปแบบ PowerPoint 97 - 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เปิด/บันทึกรูปแบบ PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับส่วนขยาย PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับส่วนขยาย PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|รองรับคุณลักษณะ PowerPoint 2016|restricted|restricted|
|รองรับคุณลักษณะ PowerPoint 2019|restricted |restricted|
|แปลง PPT เป็น PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|แปลง PPTX เป็น PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX ใน PPT|restricted|restricted|
|ประมวลผลธีม|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ประมวลผลมาโคร|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ประมวลผลคุณสมบัติเอกสาร|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การป้องกันด้วยรหัสผ่าน|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การสกัดข้อความอย่างรวดเร็ว|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ฝังฟอนท์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การแสดงความเห็น|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|การขัดจังหวะงานที่ใช้เวลานาน|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**รูปแบบการส่งออก:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted |restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**รูปแบบการนำเข้า:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์แม่:**| | |
|เข้าถึงสไลด์แม่ทั้งหมดที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์แม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนนสไลด์แม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์เค้าโครง:**| | |
|เข้าถึงสไลด์เค้าโครงทั้งหมดที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์เค้าโครง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนนสไลด์เค้าโครง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์:**| | |
|เข้าถึงสไลด์ทั้งหมดที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/ลบสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนนสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ส่งออกสไลด์เป็นรูปภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้าง/แก้ไข/ลบส่วนของสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะสไลด์บันทึกย่อ**| | |
|เข้าถึงสไลด์บันทึกย่อทั้งหมดที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะรูปร่าง:**| | |
|เข้าถึงรูปร่างทั้งหมดของสไลด์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เพิ่มรูปร่างใหม่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|โคลนนรูปร่าง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ส่งออกรูปร่างแยกเป็นรูปภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ประเภทรูปร่างที่สนับสนุน:**| | |
|รูปทรงที่กำหนดล่วงหน้าทั้งหมด|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|กรอบรูปภาพ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ตาราง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|แผนภูมิ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ไดอะแกรมเก่า|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|วัตถุ OLE, ActiveX|restricted|restricted|
|เฟรมวิดีโอ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|เฟรมน้ำเสียง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|คอนเนคเตอร์|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะกลุ่มรูปร่าง:**| | |
|เข้าถึงกลุ่มรูปร่าง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|สร้างกลุ่มรูปร่าง|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ยกเลิกการจัดกลุ่มรูปร่างที่มีอยู่|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะเอฟเฟ็กต์รูปร่าง:**| | |
|เอฟเฟ็กต์ 2D|restricted|restricted|
|เอฟเฟ็กต์ 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**คุณลักษณะข้อความ:**| | |
|การจัดรูปแบบย่อหน้า|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|การจัดรูปแบบส่วนย่อย|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**คุณลักษณะแอนิเมชัน:**| | |
|ส่งออกรูปแบบแอนิเมชันเป็น SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|ส่งออกรูปแบบแอนิเมชันเป็น HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|