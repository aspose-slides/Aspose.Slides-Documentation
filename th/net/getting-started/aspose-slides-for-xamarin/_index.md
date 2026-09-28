---
title: Aspose.Slides สำหรับ Xamarin (Historical)
linktitle: Xamarin (Historical)
type: docs
weight: 200
url: /th/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- การพัฒนาแอปมือถือ
- Android
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ประวัติศาสตร์: วิธีที่ Aspose.Slides สำหรับ .NET เวอร์ชัน 20.2 ถึง 22.10 รองรับ Xamarin.Android ผ่านไลบรารีแยกต่างหาก เวอร์ชันปัจจุบันไม่ได้รวมไลบรารีนี้."
---
{{% alert color="info" title="Note" %}}

นี่เป็นหน้าประวัติศาสตร์ เวอร์ชัน 20.2 ถึง 22.10 ของแพคเกจ Aspose.Slides.NET รวมไลบรารี Xamarin.Android แยกต่างหาก, *Aspose.Slides.Droid.dll*, ซึ่งโค้ดในหน้านี้ใช้ เวอร์ชันหลังไม่ได้รวมไลบรารีนี้: แพคเกจปัจจุบันมีบิลด์สำหรับ .NET Framework 4.6.2, .NET 6, และ .NET Standard 2.0 เท่านั้น Microsoft ยุติการสนับสนุนสำหรับ SDK ของ Xamarin ทั้งหมดเมื่อวันที่ 1 พฤษภาคม 2024; ดูที่ [Xamarin support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **บทนำ**

Xamarin คือเฟรมเวิร์กที่ใช้สำหรับการพัฒนาแอปมือถือใน .NET C#. Xamarin มีเครื่องมือและไลบรารีที่ขยายความสามารถของแพลตฟอร์ม .NET. มันอนุญาตให้ผู้พัฒนาสร้างแอปพลิเคชันสำหรับระบบปฏิบัติการ **Android**.

{{% alert color="info" title="Note" %}}

สำหรับการพัฒนาใน Xamarin โปรแกรมเมอร์สามารถใช้สภาพแวดล้อมการพัฒนาปกติของตน (C#, Visual Studio, และไลบรารีของบุคคลที่สาม) ได้.

{{% /alert %}}

Aspose.Slides API ทำงานบนแพลตฟอร์ม Xamarin เพื่อให้บรรลุเป้าหมายนี้ แพคเกจ Aspose.Slides.NET ในเวอร์ชัน 20.2 ถึง 22.10 ได้เพิ่ม DLL แยกสำหรับ Xamarin Aspose.Slides for Xamarin รองรับส่วนใหญ่ของฟีเจอร์ที่มีในเวอร์ชัน .NET:

- การแปลงและการดูงานนำเสนอ.
- การแก้ไขเนื้อหาในงานนำเสนอ: ข้อความ, รูปร่าง, แผนภูมิ, SmartArt, เสียง/วิดีโอ, ฟอนต์ เป็นต้น.
- การจัดการหรือทำงานกับแอนิเมชัน, เอฟเฟกต์ 2D, WordArt เป็นต้น.
- การจัดการเมทาดาต้าและคุณสมบัติเขียนไฟล์.
- การทำสำเนา, การผสาน, การเปรียบเทียบ, การแยกส่วน เป็นต้น.

เรามีการเปรียบเทียบคุณสมบัติทั้งหมดในส่วนอื่นใกล้ด้านล่างของหน้านี้

ใน API ของ Aspose.Slides for Xamarin คลาส, เนมสเปซ, โลจิกและพฤติกรรมถูกทำให้คล้ายกับเวอร์ชัน .NET มากที่สุด คุณสามารถย้ายแอปพลิเคชัน Aspose.Slides .NET ของคุณไปยัง Xamarin ได้ด้วยต้นทุนที่ต่ำสุด

## **ตัวอย่างอย่างรวดเร็ว**

คุณสามารถใช้ Aspose.Slides for Xamarin เพื่อสร้างและใช้งานแอป C# ของคุณผ่าน Slides for Android

เรานำเสนอ ตัวอย่างแอป Android ผ่าน Xamarin ที่ใช้ Aspose.Slides เพื่อแสดงสไลด์งานนำเสนอและเพิ่มรูปร่างใหม่บนสไลด์เมื่อสัมผัส คุณสามารถค้นหาโค้ดเต็มของตัวอย่างได้บน [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

เริ่มต้นโดยสร้าง Xamarin Android App:

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

แรก เราจะสร้างเลย์เอาต์เนื้อหาซึ่งจะประกอบด้วย ImageView, ปุ่ม Prev และ Next:

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - สร้างเลย์เอาต์เนื้อหา**
```xml
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

ที่นี่ เราอ้างอิงไลบรารี "Aspose.Slides.Droid.dll" ที่รวมตัวอย่างงานนำเสนอ ("HelloWorld.pptx") เข้าไปใน Assets ของแอป Xamarin และเพิ่มการเริ่มต้นใน MainActivity:

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

ให้เพิ่มฟังก์ชันเพื่อแสดงสไลด์ Prev และ Next เมื่อกดปุ่ม:

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

สุดท้าย ให้ทำฟังก์ชันเพิ่มวงรีบนสไลด์เมื่อสัมผัส:

**C# - MainActivity.cs - เพิ่มวงรีโดยคลิกสไลด์**
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

แต่ละการคลิกบนสไลด์งานนำเสนอจะทำให้เพิ่มวงรีสีสุ่ม:
![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **ฟีเจอร์ที่รองรับ**

|**คุณลักษณะ**|**Aspose.Slides สำหรับ .NET**|**Aspose.Slides สำหรับ Xamarin**|
| :- | :- | :- |
|**Presentation features**:| | |
|Create new presentations|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 formats open/save|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 formats open/save|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 extensions support|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 extensions support|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 features support|restricted|restricted|
|PowerPoint 2019 features support|restricted|restricted|
|PPT 2 PPTX conversion|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 2 PPT conversion|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT|restricted|restricted|
|Themes processing|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Macros processing|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Document properties processing|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Password protection|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Fast text extraction|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Embedding fonts|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Comments rendering|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Interrupting of long-running tasks|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Export formats:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Import formats:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Master slides features:**| | |
|Accessing all existing master slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/removing master slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning master slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layout slides features:**| | |
|Accessing all existing layout slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/removing layout slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning layout slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Slide features:**| | |
|Accessing all existing slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/removing slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exporting slides to images|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/editing/removing slide sections|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notes slides features**:| | |
|Accessing all existing notes slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Shape features:**| | |
|Accessing all slide shapes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Adding new shapes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning shapes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exporting separate shapes to images|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Supported shape types:**| | |
|All predefined shape types|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Picture frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tables|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Charts|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objects|restricted|restricted|
|Video frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connectors|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Group shape features:**| | |
|Accessing group shapes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating group shapes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ungrouping existing group shapes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Shape effects features:**| | |
|2D effects|restricted|restricted|
|3D effects|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Text features:**| | |
|Paragraphs formatting|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Portions formatting|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animation Features:**| | |
|Export animation to SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Export animation to HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|