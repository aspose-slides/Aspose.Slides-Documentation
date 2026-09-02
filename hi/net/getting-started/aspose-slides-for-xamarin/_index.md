---
title: Xamarin के लिए Aspose.Slides
type: docs
weight: 150
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
description: "Aspose.Slides के साथ C# में Xamarin मोबाइल एप्लीकेशन बनाएं ताकि प्रेजेंटेशन को देख, संपादित और रूपांतरित किया जा सके, जो Android पर PPT, PPTX और ODP के लिए समृद्ध सुविधाएँ प्रदान करता है।"
---
## **परिचय**

Xamarin .NET C# में मोबाइल विकास के लिए उपयोग किया जाने वाला एक फ्रेमवर्क है। Xamarin के पास टूल्स और लाइब्रेरीज़ हैं जो .NET प्लेटफ़ॉर्म की क्षमताओं का विस्तार करती हैं। यह डेवलपर्स को **Android** ऑपरेटिंग सिस्टम के लिए एप्लिकेशन बनाने की अनुमति देता है।

{{% alert color="info" %}} 
Xamarin में विकास के लिए, प्रोग्रामर अपने सामान्य विकास वातावरण (C#, Visual Studio, और थर्ड पार्टी लाइब्रेरीज़) का उपयोग कर सकते हैं।
{{% /alert %}}

Aspose.Slides API Xamarin प्लेटफ़ॉर्म पर काम करता है। इसे प्राप्त करने के लिए, Aspose.Slides .NET पैकेज Xamarin के लिए एक अलग DLL जोड़ता है। Aspose.Slides for Xamarin .NET संस्करण में उपलब्ध अधिकांश फीचर्स को सपोर्ट करता है:

- प्रेजेंटेशन को कन्वर्ट करना और देखना।
- प्रेजेंटेशन की सामग्री को संपादित करना: टेक्स्ट, शॅप्स, चार्ट, SmartArt, ऑडियो/वीडियो, फॉन्ट्स आदि।
- एनीमेशन, 2D इफ़ेक्ट्स, WordArt आदि को संभालना।
- मेटाडेटा और दस्तावेज़ प्रॉपर्टीज़ को संभालना।
- क्लोनिंग, मर्जिंग, तुलना, स्प्लिटिंग आदि।

हमने इस पृष्ठ के नीचे के पास एक अन्य सेक्शन में सभी फीचर की तुलना प्रदान की है।

Aspose.Slides for Xamarin API में, क्लासेस, नेमस्पेसेस, लॉजिक और बिहेवियर .NET संस्करण के जितना संभव हो उतना समान हैं। आप अपने Aspose.Slides .NET एप्लिकेशन को न्यूनतम लागत के साथ Xamarin में माइग्रेट कर सकते हैं।

## **त्वरित उदाहरण**

आप Slides for Android के माध्यम से अपने C# एप्लिकेशन को बनाने और उपयोग करने के लिए Aspose.Slides for Xamarin का उपयोग कर सकते हैं।

हम Android के लिए Xamarin एप्लिकेशन का एक उदाहरण प्रदान कर रहे हैं जो Aspose.Slides का उपयोग करके प्रेजेंटेशन स्लाइड्स दिखाता है और टैच करने पर स्लाइड पर एक नया शॅप जोड़ता है। आप उदाहरणों का पूरा स्रोत [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) पर पा सकते हैं।

चलिए एक Xamarin Android ऐप बनाकर शुरू करते हैं:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

पहले, हम एक कंटेंट लेआउट बनाते हैं जिसमें एक इमेज व्यू, Prev और Next बटन होंगे:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - कंटेंट लेआउट बनाएं**
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

यहां, हम "Aspose.Slides.Droid.dll" लाइब्रेरी को संदर्भित करते हैं जिसमें एक सैंपल प्रेजेंटेशन ("HelloWorld.pptx") शामिल है, इसे Xamarin एप्लिकेशन के Assets में जोड़ते हैं और इसका इनिशियलाइज़ेशन MainActivity में जोड़ते हैं:

**C# - MainActivity.cs - इनिशियलाइज़ेशन**
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

चलिए बटन टैप करने पर Prev और Next स्लाइड्स दिखाने के लिए फ़ंक्शन जोड़ते हैं:
**C# - MainActivity.cs - Prev और Next बटन क्लिक पर स्लाइड्स दिखाएँ**
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

अंत में, चलिए स्लाइड पर टैच करने पर एक एलिप्स शॅप जोड़ने के लिए फ़ंक्शन लागू करते हैं:
**C# - MainActivity.cs - स्लाइड क्लिक द्वारा एलिप्स जोड़ें**
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

प्रेजेंटेशन स्लाइड पर प्रत्येक क्लिक एक रैंडम रंग का एलिप्स जोड़ता है:
![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **समर्थित सुविधाएँ**

|**विशेषताएँ**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**प्रेजेंटेशन विशेषताएँ:**| | |
|नई प्रेजेंटेशन बनाएं|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 फ़ॉर्मेट्स खोलें/सहेजें|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 फ़ॉर्मेट्स खोलें/सहेजें|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 एक्सटेंशन समर्थन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 एक्सटेंशन समर्थन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 सुविधाओं का समर्थन|restricted|restricted|
|PowerPoint 2019 सुविधाओं का समर्थन|restricted|restricted|
|PPT से PPTX रूपांतरण|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX से PPT रूपांतरण|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPT में PPTX|restricted|restricted|
|थीम प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मैक्रो प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|दस्तावेज़ प्रॉपर्टी प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पासवर्ड सुरक्षा|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|तेज़ टेक्स्ट निष्कर्षण|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|फ़ॉन्ट एम्बेडिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|टिप्पणियाँ रेंडरिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|दीर्घकालिक कार्यों का इंटरप्शन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**निर्यात फ़ॉर्मेट:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**आयात फ़ॉर्मेट:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**मास्टर स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा मास्टर स्लाइड तक पहुँच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मास्टर स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मास्टर स्लाइड क्लोनिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**लेआउट स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा लेआउट स्लाइड तक पहुँच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेआउट स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेआउट स्लाइड क्लोनिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा स्लाइड तक पहुँच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड क्लोनिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड को इमेज में निर्यात|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड सेक्शन बनाना/संपादित करना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**नोट्स स्लाइड सुविधाएँ**| | |
|सभी मौजूदा नोट्स स्लाइड तक पहुँच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**शॅप सुविधाएँ:**| | |
|सभी स्लाइड शॅप्स तक पहुँच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|नए शॅप जोड़ना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|शॅप क्लोनिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|अलग शॅप को इमेज में निर्यात|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**समर्थित शॅप प्रकार:**| | |
|सभी पूर्वनिर्धारित शॅप प्रकार|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|चित्र फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|टेबल|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|चार्ट|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पुरानी डायग्राम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX ऑब्जेक्ट्स|restricted|restricted|
|वीडियो फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ऑडियो फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|कनेक्टर|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ग्रुप शॅप सुविधाएँ:**| | |
|ग्रुप शॅप्स तक पहुँच|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ग्रुप शॅप्स बनाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मौजूदा ग्रुप शॅप्स को अनग्रुप करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**शॅप इफ़ेक्ट्स सुविधाएँ:**| | |
|2D इफ़ेक्ट्स|restricted|restricted|
|3D इफ़ेक्ट्स|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**टेक्स्ट सुविधाएँ:**| | |
|पैरा फ़ॉर्मेटिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पॉर्शन फ़ॉर्मेटिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**एनिमेशन सुविधाएँ:**| | |
|एनिमेशन को SWF में निर्यात|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|एनिमेशन को HTML में निर्यात|{{< emoticons/cross >}}|{{< emoticons/cross >}}|