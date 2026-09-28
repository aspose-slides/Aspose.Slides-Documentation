---
title: Aspose.Slides برای Xamarin (تاریخی)
linktitle: Xamarin (تاریخی)
type: docs
weight: 200
url: /fa/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- توسعه موبایل
- Android
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تاریخی: چگونگی پشتیبانی Aspose.Slides برای .NET نسخه‌های 20.2 تا 22.10 از Xamarin.Android از طریق یک کتابخانهٔ جداگانه. نسخه‌های فعلی آن را شامل نمی‌شوند."
---
{{% alert color="info" title="توجه" %}}

این یک صفحه تاریخی است. نسخه‌های 20.2 تا 22.10 بسته Aspose.Slides.NET یک کتابخانه جداگانه Xamarin.Android به نام *Aspose.Slides.Droid.dll* را شامل می‌شد که کد این صفحه از آن استفاده می‌کند. نسخه‌های بعدی دیگر این کتابخانه را ندارند: بستهٔ فعلی فقط بناهای .NET Framework 4.6.2، .NET 6 و .NET Standard 2.0 را شامل می‌شود. مایکروسافت پشتیبانی از تمام SDKهای Xamarin را در تاریخ 1 می 2024 خاتمه داد؛ به [سیاست پشتیبانی Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin) مراجعه کنید.

{{% /alert %}}

## **مقدمه**

Xamarin چارچوبی برای توسعهٔ موبایل در .NET C# است. Xamarin ابزارها و کتابخانه‌هایی دارد که توانمندی‌های پلتفرم .NET را گسترش می‌دهند. این چارچوب به توسعه‌دهندگان امکان می‌دهد برنامه‌هایی برای سیستم‌عامل **Android** بسازند.

{{% alert color="info" title="توجه" %}}

برای توسعه در Xamarin، برنامه‌نویسان می‌توانند از محیط‌های توسعهٔ معمول خود (C#، Visual Studio و کتابخانه‌های شخص ثالث) استفاده کنند.

{{% /alert %}}

API Aspose.Slides بر روی پلتفرم Xamarin کار می‌کرد. برای دستیابی به این هدف، بسته Aspose.Slides.NET در نسخه‌های 20.2 تا 22.10 یک DLL جداگانه برای Xamarin اضافه کرد. Aspose.Slides برای Xamarin اکثر ویژگی‌های موجود در نسخهٔ .NET را پشتیبانی می‌کرد:

- تبدیل و نمایش ارائه‌ها.
- ویرایش محتویات ارائه‌ها: متن، اشکال، نمودارها، SmartArt، صدا/ویدیو، قلم‌ها و غیره.
- پردازش انیمیشن‌ها، افکت‌های 2D، WordArt و غیره.
- مدیریت متاداده و ویژگی‌های سند.
- کلون، ادغام، مقایسه، تقسیم و غیره.

مقایسهٔ کامل ویژگی‌ها در بخش دیگری در پایین این صفحه ارائه شده است.

در API Aspose.Slides برای Xamarin، کلاس‌ها، فضای‌نام‌ها، منطق و رفتارها تا حد امکان مشابه نسخهٔ .NET بودند. می‌توانستید برنامه‌های Aspose.Slides .NET خود را با هزینهٔ کم به Xamarin منتقل کنید.


## **مثال سریع**
می‌توانید از Aspose.Slides برای Xamarin استفاده کنید تا برنامهٔ C# خود را از طریق Slides for Android بسازید و استفاده کنید.

ما یک مثال از برنامهٔ Android با Xamarin ارائه می‌دهیم که از Aspose.Slides برای نمایش اسلایدهای ارائه استفاده می‌کند و با لمس، یک شکل جدید به اسلاید اضافه می‌کند. می‌توانید کد منبع کامل مثال‌ها را در [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) پیدا کنید.

بیایید با ایجاد یک برنامهٔ Xamarin Android شروع کنیم:

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

در ابتدا، یک طرح محتوا می‌سازیم که شامل یک ImageView، دکمه‌های Prev و Next می‌شود:

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Create content layout**
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



در اینجا کتابخانهٔ "Aspose.Slides.Droid.dll" را که شامل یک ارائهٔ نمونه ("HelloWorld.pptx") است به دارایی‌های برنامهٔ Xamarin ارجاع می‌دهیم و مقداردهی اولیهٔ آن را به MainActivity اضافه می‌کنیم:

**C# - MainActivity.cs - Initialization**

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

بیایید تابعی برای نمایش اسلایدهای Prev و Next هنگام فشار دکمه‌ها اضافه کنیم:

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



در نهایت، تابعی برای اضافه کردن یک شکل بیضی در هنگام لمس اسلاید پیاده‌سازی می‌کنیم:

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

هر کلیک بر روی اسلاید ارائه یک بیضی رنگی تصادفی اضافه می‌کند:

![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **ویژگی‌های پشتیبانی شده**

|**ویژگی‌ها**|**Aspose.Slides برای .NET**|**Aspose.Slides برای Xamarin**|
| :- | :- | :- |
|**ویژگی‌های ارائه**:| | |
|ایجاد ارائه‌های جدید|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|باز/ذخیره فرمت‌های PowerPoint 97 – 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|باز/ذخیره فرمت‌های PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|پشتیبانی از افزونه‌های PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|پشتیبانی از افزونه‌های PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|پشتیبانی از ویژگی‌های PowerPoint 2016|محدود|محدود|
|پشتیبانی از ویژگی‌های PowerPoint 2019|محدود|محدود|
|تبدیل PPT به PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|تبدیل PPTX به PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX در PPT|محدود|محدود|
|پردازش تم‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|پردازش ماکروها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|پردازش ویژگی‌های سند|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|حمایت از رمز عبور|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|استخراج سریع متن|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|جاسازی قلم‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|نمایش نظرات|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|قطع تسک‌های طولانی‌مدت|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**فرمت‌های خروجی:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|محدود|محدود|
|SWF|محدود|محدود|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**فرمت‌های ورودی:**| | |
|HTML|محدود|محدود|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های اسلایدهای مادر:**| | |
|دسترسی به تمام اسلایدهای مادر موجود|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ایجاد/حذف اسلایدهای مادر|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|کلون کردن اسلایدهای مادر|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های اسلایدهای چیدمان:**| | |
|دسترسی به تمام اسلایدهای چیدمان موجود|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ایجاد/حذف اسلایدهای چیدمان|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|کلون کردن اسلایدهای چیدمان|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های اسلاید:**| | |
|دسترسی به تمام اسلایدهای موجود|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ایجاد/حذف اسلایدها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|کلون کردن اسلایدها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|خروجی اسلایدها به تصویر|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ایجاد/ویرایش/حذف بخش‌های اسلاید|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های اسلایدهای یادداشت**:| | |
|دسترسی به تمام اسلایدهای یادداشت موجود|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های شکل:**| | |
|دسترسی به تمام شکل‌های اسلاید|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|اضافه کردن شکل‌های جدید|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|کلون کردن شکل‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|صدور شکل‌های جداگانه به تصویر|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**نوع‌های شکل پشتیبانی شده:**| | |
|تمام نوع‌های پیش‌تعریف شدهٔ شکل|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|قاب‌های تصویر|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|جداول|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|نمودارها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|نقشه‌کشی‌های قدیمی|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE، اشیای ActiveX|محدود|محدود|
|قاب‌های ویدئو|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|قاب‌های صدا|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|متصل‌کننده‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های گروه شکل:**| | |
|دستیابی به گروه شکل‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ایجاد گروه شکل‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|عدم گروه‌بندی گروه شکل‌های موجود|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های افکت‌های شکل:**| | |
|افکت‌های 2D|محدود|محدود|
|افکت‌های 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**ویژگی‌های متن:**| | |
|قالب‌بندی پاراگراف‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|قالب‌بندی بخش‌ها|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ویژگی‌های انیمیشن:**| | |
|خروجی انیمیشن به SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|خروجی انیمیشن به HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|