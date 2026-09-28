---
title: Aspose.Slides لـ Xamarin (تاريخية)
linktitle: Xamarin (تاريخية)
type: docs
weight: 200
url: /ar/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- تطوير التطبيقات المحمولة
- Android
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تاريخية: كيف دعمت Aspose.Slides لإصدار .NET من 20.2 إلى 22.10 منصة Xamarin.Android عبر مكتبة منفصلة. الإصدارات الحالية لا تتضمنها."
---
{{% alert color="info" title="ملاحظة" %}}

هذه صفحة تاريخية. إصدارات 20.2 إلى 22.10 من حزمة Aspose.Slides.NET شملت مكتبة Xamarin.Android منفصلة، *Aspose.Slides.Droid.dll*، التي يستخدمها الكود في هذه الصفحة. الإصدارات اللاحقة لا تشملها: الحزمة الحالية تحتوي على بنى لـ .NET Framework 4.6.2، .NET 6، و .NET Standard 2.0 فقط. أنهت مايكروسوفت دعم جميع SDKs لـ Xamarin في 1 مايو 2024؛ راجع [سياسة دعم Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **المقدمة**

Xamarin هو إطار يستخدم لتطوير التطبيقات المحمولة في .NET C#. يمتلك Xamarin أدوات ومكتبات توسّع قدرات منصة .NET. يتيح للمطورين بناء تطبيقات لنظام التشغيل **Android**.

{{% alert color="info" title="ملاحظة" %}}

للتطوير في Xamarin، يمكن للبرمجة استخدام بيئات التطوير المعتادة لديهم (C#، Visual Studio، ومكتبات الجهات الخارجية).

{{% /alert %}}

عملت واجهة برمجة تطبيقات Aspose.Slides على منصة Xamarin. لتحقيق ذلك، أضافت حزمة Aspose.Slides.NET، في الإصدارات 20.2 إلى 22.10، مكتبة DLL منفصلة لـ Xamarin. دعمت Aspose.Slides لـ Xamarin معظم الميزات المتوفرة في نسخة .NET:

- تحويل وعرض العروض التقديمية.
- تحرير محتويات العروض التقديمية: النص، الأشكال، المخططات، SmartArt، الصوت/الفيديو، الخطوط، إلخ.
- معالجة/التعامل مع الرسوم المتحركة، تأثيرات 2D، WordArt، إلخ.
- معالجة/التعامل مع البيانات الوصفية وخصائص المستند.
- استنساخ، دمج، مقارنة، تقسيم، إلخ.

لقد قدمنا مقارنة للميزات الكاملة في قسم آخر قرب أسفل هذه الصفحة.

في واجهة برمجة تطبيقات Aspose.Slides لـ Xamarin، كانت الفئات والمساحات الاسمية والمنطق والسلوك مشابهة قدر الإمكان لنسخة .NET. يمكنك ترحيل تطبيقات Aspose.Slides .NET الخاصة بك إلى Xamarin بأقل تكلفة.

## **مثال سريع**
يمكنك استخدام Aspose.Slides لـ Xamarin لإنشاء واستخدام تطبيق C# الخاص بك عبر Slides for Android.

نقدم مثالًا لتطبيق Android عبر Xamarin يستخدم Aspose.Slides لعرض شرائح العرض ويضيف شكلًا جديدًا على الشريحة عند اللمس. يمكنك العثور على الشيفرة الكاملة للأمثلة على [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

لنبدأ بإنشاء تطبيق Xamarin Android:

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

أولاً، نقوم بإنشاء تخطيط محتوى سيحتوي على عرض صورة، وزر Prev، وزر Next:

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - إنشاء تخطيط المحتوى**
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

هنا، نشير إلى مكتبة "Aspose.Slides.Droid.dll" التي تتضمن عرضًا تقديميًا تجريبيًا ("HelloWorld.pptx") في أصول تطبيق Xamarin وتضيف تهيئتها إلى MainActivity:

**C# - MainActivity.cs - التهيئة**
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

لنضيف الدالة لعرض شرائح Prev و Next عند النقر على الأزرار:
**C# - MainActivity.cs - عرض الشرائح عند النقر على أزرار Prev و Next**
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

أخيرًا، لننفذ دالة لإضافة شكل إهليلجي عند اللمس على الشريحة:
**C# - MainActivity.cs - إضافة إهليلج بواسطة النقر على الشريحة**
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

كل نقرة على شريحة العرض تؤدي إلى إضافة إهليلج عشوائي اللون:
![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **الميزات المدعومة**

|**الميزات**|**Aspose.Slides لـ .NET**|**Aspose.Slides لـ Xamarin**|
| :- | :- | :- |
|**ميزات العروض التقديمية**:| | |
|إنشاء عروض تقديمية جديدة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|صيغ PowerPoint 97 - 2003 (فتح/حفظ)|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|صيغ PowerPoint 2007 (فتح/حفظ)|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|دعم ملحقات PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|دعم ملحقات PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|دعم ميزات PowerPoint 2016|restricted|restricted|
|دعم ميزات PowerPoint 2019|restricted|restricted|
|تحويل PPT إلى PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|تحويل PPTX إلى PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX داخل PPT|restricted|restricted|
|معالجة السمات|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|معالجة الماكرو|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|معالجة خصائص المستند|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|حماية كلمة المرور|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|استخراج النص بسرعة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|تضمين الخطوط|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|عرض التعليقات|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|إيقاف مهام طويلة الأمد|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**صيغ التصدير:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**صيغ الاستيراد:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات الشرائح الرئيسية:**| | |
|الوصول إلى جميع الشرائح الرئيسية الموجودة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إنشاء/إزالة الشرائح الرئيسية|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|استنساخ الشرائح الرئيسية|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات شرائح التخطيط:**| | |
|الوصول إلى جميع شرائح التخطيط الموجودة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إنشاء/إزالة شرائح التخطيط|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|استنساخ شرائح التخطيط|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات الشريحة:**| | |
|الوصول إلى جميع الشرائح الموجودة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إنشاء/إزالة الشرائح|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|استنساخ الشرائح|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|تصدير الشرائح إلى صور|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إنشاء/تحرير/إزالة أقسام الشرائح|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات شرائح الملاحظات**:| | |
|الوصول إلى جميع شرائح الملاحظات الموجودة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات الشكل:**| | |
|الوصول إلى جميع أشكال الشرائح|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إضافة أشكال جديدة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|استنساخ الأشكال|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|تصدير الأشكال المنفصلة إلى صور|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**أنواع الأشكال المدعومة:**| | |
|جميع أنواع الأشكال المعرفة مسبقًا|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إطارات الصور|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|الجداول|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|المخططات|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|مخطط قديم|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|كائنات OLE, ActiveX|restricted|restricted|
|إطارات الفيديو|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إطارات الصوت|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|موصلات|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات مجموعة الأشكال:**| | |
|الوصول إلى مجموعات الأشكال|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إنشاء مجموعات الأشكال|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|إلغاء تجميع مجموعات الأشكال الموجودة|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات تأثيرات الشكل:**| | |
|تأثيرات 2D|restricted|restricted|
|تأثيرات 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**ميزات النص:**| | |
|تنسيق الفقرات|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|تنسيق الأجزاء|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ميزات الرسوم المتحركة:**| | |
|تصدير الرسوم المتحركة إلى SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|تصدير الرسوم المتحركة إلى HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|