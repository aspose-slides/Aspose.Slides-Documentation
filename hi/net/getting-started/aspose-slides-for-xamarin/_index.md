---
title: Aspose.Slides for Xamarin (ऐतिहासिक)
linktitle: Xamarin (ऐतिहासिक)
type: docs
weight: 200
url: /hi/net/aspose-slides-for-xamarin/
keywords:
  - Xamarin
  - मोबाइल विकास
  - Android
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "ऐतिहासिक: Aspose.Slides for .NET संस्करण 20.2 से 22.10 ने कैसे एक अलग लाइब्रेरी के माध्यम से Xamarin.Android को समर्थन दिया। वर्तमान संस्करण इसमें शामिल नहीं हैं।"
---
{{% alert color="info" title="नोट" %}}
यह एक ऐतिहासिक पृष्ठ है। Aspose.Slides.NET पैकेज के संस्करण 20.2 से 22.10 ने एक अलग Xamarin.Android लाइब्रेरी, *Aspose.Slides.Droid.dll*, शामिल की थी, जिसका कोड इस पृष्ठ पर उपयोग किया गया है। बाद के संस्करणों में यह नहीं शामिल है: वर्तमान पैकेज में केवल .NET Framework 4.6.2, .NET 6, और .NET Standard 2.0 के लिए बिल्ड्स हैं। माइक्रोसॉफ्ट ने सभी Xamarin SDKs के लिए समर्थन 1 मई 2024 को समाप्त कर दिया; देखें[Xamarin समर्थन नीति](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin)।
{{% /alert %}}

## **परिचय**

Xamarin .NET C# में मोबाइल विकास के लिए उपयोग किया जाने वाला एक फ्रेमवर्क है। Xamarin के पास ऐसे टूल और लाइब्रेरी हैं जो .NET प्लेटफ़ॉर्म की क्षमताओं का विस्तार करते हैं। यह डेवलपर्स को **Android** ऑपरेटिंग सिस्टम के लिए एप्लिकेशन बनाने की अनुमति देता है।

{{% alert color="info" title="नोट" %}}
Xamarin में विकास के लिए, प्रोग्रामर अपने नियमित विकास परिवेश (C#, Visual Studio, और तीसरे पक्ष की लाइब्रेरी) का उपयोग कर सकते हैं।
{{% /alert %}}

Aspose.Slides API Xamarin प्लेटफ़ॉर्म पर काम करता था। इसे प्राप्त करने के लिए, Aspose.Slides.NET पैकेज ने, संस्करण 20.2 से 22.10 तक, Xamarin के लिए एक अलग DLL जोड़ी। Xamarin के लिए Aspose.Slides ने .NET संस्करण में उपलब्ध अधिकांश विशेषताएं समर्थित कीं:

- प्रेजेंटेशन को बदलना और देखना।
- प्रेजेंटेशन की सामग्री को संपादित करना: टेक्स्ट, शकलें, चार्ट, SmartArt, ऑडियो/वीडियो, फ़ॉन्ट आदि।
- एनिमेशन, 2D इफ़ेक्ट्स, WordArt आदि को संभालना/निपटाना।
- मेटाडेटा और दस्तावेज़ गुणों को संभालना/निपटाना.
- क्लोनिंग, मर्जिंग, तुलना, विभाजन आदि.

हमने इस पृष्ठ के निचले हिस्से के पास एक अन्य अनुभाग में पूरी विशेषताओं की तुलना प्रदान की है।

Aspose.Slides for Xamarin API में, क्लासेज़, नेमस्पेसेस, लॉजिक और व्यवहार .NET संस्करण के यथासंभव समान थे। आप अपने Aspose.Slides .NET अनुप्रयोगों को न्यूनतम लागत के साथ Xamarin में माइग्रेट कर सकते थे।

## **त्वरित उदाहरण**

आप Aspose.Slides for Xamarin का उपयोग करके Slides for Android के माध्यम से अपना C# एप्लिकेशन बना और उपयोग कर सकते हैं।

हम Xamarin एप्लिकेशन के माध्यम से Android का एक उदाहरण प्रदान कर रहे हैं जो Aspose.Slides का उपयोग करके प्रेजेंटेशन स्लाइड दिखाता है और टच पर स्लाइड में नया आकार जोड़ता है। आप उदाहरणों के पूर्ण स्रोत कोड को[GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) पर पा सकते हैं।

आइए एक Xamarin Android ऐप बनाकर शुरू करते हैं:

![Xamarin Android ऐप बनाना](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

पहले, हम एक सामग्री लेआउट बनाते हैं जिसमें छवि दृश्य, Prev, और Next बटन होते हैं:

![छवि दृश्य और Prev एवं Next बटनों के साथ सामग्री लेआउट](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - सामग्री लेआउट बनाएं**
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

यहाँ हम Aspose.Slides.Droid.dll लाइब्रेरी को संदर्भित करते हैं जो एक सैंपल प्रेजेंटेशन ("HelloWorld.pptx") को Xamarin एप्लिकेशन एसेट्स में शामिल करती है और इसकी प्रारम्भिककरण MainActivity में जोड़ती है:

**C# - MainActivity.cs - प्रारम्भिककरण**
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

बटनों को टैप करने पर Prev और Next स्लाइड दिखाने के लिए फ़ंक्शन जोड़ें:
**C# - MainActivity.cs - Prev और Next बटन क्लिक पर स्लाइड दिखाएँ**
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
        imageView.SetImageBitmap(bitmap ToNativeBitmap());
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

अंत में, स्लाइड पर टच करने पर एक अंडाकार आकार जोड़ने के लिए फ़ंक्शन लागू करें:
**C# - MainActivity.cs - स्लाइड क्लिक से अंडाकार जोड़ें**
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

प्रेजेंटेशन स्लाइड पर प्रत्येक क्लिक पर एक यादृच्छिक रंग का अंडाकार जोड़ा जाता है:
![टच द्वारा जोड़े गए अंडाकारों के साथ स्लाइड](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **समर्थित सुविधाएँ**

|**फ़ीचर्स**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**प्रेजेंटेशन सुविधाएँ**:| | |
|नई प्रेजेंटेशन बनाएं|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 फ़ॉर्मेट खोलें/सहेजें|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 फ़ॉर्मेट खोलें/सहेजें|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 एक्सटेंशन समर्थन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 एक्सटेंशन समर्थन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 फीचर समर्थन|restricted|restricted|
|PowerPoint 2019 फीचर समर्थन|restricted|restricted|
|PPT से PPTX परिवर्तन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX से PPT परिवर्तन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPT में PPTX|restricted|restricted|
|थीम प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मैक्रो प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|दस्तावेज़ गुण प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पासवर्ड सुरक्षा|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|तेज़ टेक्स्ट निष्कर्षण|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|फ़ॉन्ट एम्बेडिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|टिप्पणियों का रेंडरिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लंबे समय चलने वाले कार्यों का व्यवधान|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**निर्यात स्वरूप:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**आयात स्वरूप:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**मास्टर स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा मास्टर स्लाइड तक पहुंच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मास्टर स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मास्टर स्लाइड क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**लेआउट स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा लेआउट स्लाइड तक पहुंच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेआउट स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेआउट स्लाइड क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा स्लाइड तक पहुंच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड को छवियों में निर्यात करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड सेक्शन बनाना/संपादित करना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**नोट्स स्लाइड सुविधाएँ**:| | |
|सभी मौजूदा नोट्स स्लाइड तक पहुंच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**आकार सुविधाएँ:**| | |
|सभी स्लाइड आकारों तक पहुंच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|नए आकार जोड़ना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|आकार क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|अलग-अलग आकारों को छवियों में निर्यात करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**समर्थित आकार प्रकार:**| | |
|सभी पूर्वनिर्धारित आकार प्रकार|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|चित्र फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|टेबल्स|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|चार्ट|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेगसी डायग्राम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX ऑब्जेक्ट्स|restricted|restricted|
|वीडियो फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ऑडियो फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|कनेक्टर|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ग्रुप आकार सुविधाएँ:**| | |
|ग्रुप आकार तक पहुंच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ग्रुप आकार बनाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मौजूदा ग्रुप आकार को अनग्रुप करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**आकार प्रभाव सुविधाएँ:**| | |
|2D प्रभाव|restricted|restricted|
|3D प्रभाव|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**टेक्स्ट सुविधाएँ:**| | |
|पैराग्राफ़ फ़ॉर्मेटिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|भाग फ़ॉर्मेटिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**एनिमेशन सुविधाएँ:**| | |
|एनिमेशन को SWF में निर्यात|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|एनिमेशन को HTML में निर्यात|{{< emoticons/cross >}}|{{< emoticons/cross >}}|