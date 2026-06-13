---
title: Xamarin के लिए Aspose.Slides
type: docs
weight: 150
url: /hi/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- मोबाइल विकास
- एंड्रॉइड
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides के साथ प्रस्तुतियों को देखने, संपादित करने और परिवर्तित करने के लिए C# में Xamarin मोबाइल ऐप्स बनाएं, जो Android पर PPT, PPTX और ODP के लिए समृद्ध सुविधाओं का समर्थन करता है।"
---
## **परिचय**

Xamarin .NET C# में मोबाइल विकास के लिए उपयोग किया जाने वाला एक फ्रेमवर्क है। Xamarin में टूल्स और लाइब्रेरीज़ हैं जो .NET प्लेटफ़ॉर्म की क्षमताओं को विस्तारित करती हैं। यह डेवलपर्स को **Android** ऑपरेटिंग सिस्टम के लिए एप्लिकेशन बनाने की अनुमति देता है। 

{{% alert color="primary" %}} 
Xamarin में विकास के लिए, प्रोग्रामर अपने सामान्य विकास वातावरण (C#, Visual Studio, और तृतीय पक्ष लाइब्रेरीज़) का उपयोग कर सकते हैं। 
{{% /alert %}}

Aspose.Slides API Xamarin प्लेटफ़ॉर्म पर काम करता है। इसे हासिल करने के लिए, Aspose.Slides .NET पैकेज Xamarin के लिए एक अलग DLL जोड़ता है। Xamarin के लिए Aspose.Slides .NET संस्करण में उपलब्ध अधिकांश सुविधाओं को समर्थन देता है:

- प्रेज़ेंटेशन को कन्वर्ट करना और देखना।
- प्रेज़ेंटेशन में सामग्री को संपादित करना: टेक्स्ट, शेप्स, चार्ट, SmartArt, ऑडियो/वीडियो, फ़ॉन्ट आदि।
- एनिमेशन, 2D इफ़ेक्ट्स, WordArt आदि को संभालना/संपादित करना।
- मेटाडेटा और दस्तावेज़ प्रॉपर्टीज़ को संभालना।
- प्रिंटिंग, क्लोनिंग, मर्जिंग, तुलना, स्प्लिटिंग आदि।

हमने पृष्ठ के निचले हिस्से के निकट एक अलग सेक्शन में सभी सुविधाओं की तुलना प्रदान की है।

Aspose.Slides for Xamarin API में, क्लासेज़, नेमस्पेसेज़, लॉजिक और व्यवहार .NET संस्करण के जितना संभव हो समान हैं। आप अपने Aspose.Slides .NET एप्लिकेशन्स को न्यूनतम लागत के साथ Xamarin में माइग्रेट कर सकते हैं।

## **त्वरित उदाहरण**
आप Slides for Android के माध्यम से अपने C# एप्लिकेशन को निर्माण और उपयोग करने के लिए Aspose.Slides for Xamarin का उपयोग कर सकते हैं।

हम एक Android Xamarin एप्लिकेशन का उदाहरण प्रदान कर रहे हैं जो Aspose.Slides का उपयोग करके प्रेज़ेंटेशन स्लाइड्स दिखाता है और स्पर्श पर स्लाइड पर एक नया शेप जोड़ता है। आप उदाहरणों का पूरा स्रोत [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) पर पा सकते हैं।

आइए एक Xamarin Android एप्लिकेशन बनाकर शुरू करते हैं:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

सबसे पहले, हम एक कंटेंट लेआउट बनाते हैं जिसमें एक इमेज व्यू, Prev, और Next बटन होंगे:

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

यहाँ, हम "Aspose.Slides.Droid.dll" लाइब्रेरी का संदर्भ देते हैं जिसमें एक सैंपल प्रेज़ेंटेशन ("HelloWorld.pptx") शामिल है, इसे Xamarin एप्लिकेशन के Assets में जोड़ते हैं और इसकी इनिशियलाइज़ेशन MainActivity में जोड़ते हैं:

**C# - MainActivity.cs - इनिशियलाइज़ेशन**

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

आइए बटन टैप करने पर Prev और Next स्लाइड्स दिखाने के लिए फ़ंक्शन जोड़ते हैं:

**C# - MainActivity.cs - Prev और Next बटन क्लिक पर स्लाइड्स दिखाएं**

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

अंत में, हम स्लाइड पर टैच करने पर एक एलिप्स शेप जोड़ने के लिए फ़ंक्शन लागू करते हैं:

**C# - MainActivity.cs - स्लाइड क्लिक से एलिप्स जोड़ें**

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

प्रेज़ेंटेशन स्लाइड पर प्रत्येक क्लिक पर एक रैंडम रंग का एलिप्स जोड़ा जाता है:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **समर्थित सुविधाएँ**

|**विशेषताएँ**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**प्रेज़ेंटेशन सुविधाएँ**:| | |
|नई प्रेज़ेंटेशन बनाएं|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 फ़ॉर्मेट खोलना/सेव करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 फ़ॉर्मेट खोलना/सेव करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 एक्सटेंशन सपोर्ट|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 एक्सटेंशन सपोर्ट|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 सुविधाओं का समर्थन|restricted|restricted|
|PowerPoint 2019 सुविधाओं का समर्थन|restricted |restricted|
|PPT से PPTX रूपांतरण|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX से PPT रूपांतरण|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPT में PPTX|restricted|restricted|
|थीम प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मैक्रो प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|डॉक्यूमेंट प्रॉपर्टीज़ प्रोसेसिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पासवर्ड सुरक्षा|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|तेज़ टेक्स्ट एक्सट्रैक्शन|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|फ़ॉन्ट एम्बेडिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|कॉमेंट्स रेंडरिंग|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|लंबे चलने वाले कार्यों को बाधित करना|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**एक्सपोर्ट फ़ॉर्मेट:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted |restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**इम्पोर्ट फ़ॉर्मेट:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**मुख्य स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा मुख्य स्लाइड तक पहुंचना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मुख्य स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मुख्य स्लाइड क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**लेआउट स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा लेआउट स्लाइड्स तक पहुंचना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेआउट स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेआउट स्लाइड क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा स्लाइड्स तक पहुंचना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड बनाना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड्स को इमेज में एक्सपोर्ट करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|स्लाइड सेक्शन बनाना/संपादित करना/हटाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**नोट्स स्लाइड सुविधाएँ:**| | |
|सभी मौजूदा नोट्स स्लाइड्स तक पहुंचना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**शेप सुविधाएँ:**| | |
|सभी स्लाइड शैप्स तक पहुंचना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|नए शैप्स जोड़ना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|शैप्स क्लोन करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|अलग-अलग शैप्स को इमेज में एक्सपोर्ट करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**समर्थित शेप प्रकार:**| | |
|सभी प्री-डिफाइन्ड शेप प्रकार|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पिक्चर फ्रेम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|टेबल्स|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|चार्ट्स|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|लेगेसी डायग्राम|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX ऑब्जेक्ट्स|restricted|restricted|
|वीडियो फ्रेम्स|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ऑडियो फ्रेम्स|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|कनेक्टर्स|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ग्रुप शेप सुविधाएँ:**| | |
|ग्रुप शैप्स तक पहुंचना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ग्रुप शैप्स बनाना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|मौजूदा ग्रुप शैप्स को अनग्रुप करना|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**शेप इफ़ेक्ट्स सुविधाएँ:**| | |
|2D इफ़ेक्ट्स|restricted|restricted|
|3D इफ़ेक्ट्स|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**टेक्स्ट सुविधाएँ:**| | |
|पैराग्राफ फॉर्मेटिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|पॉर्शन फॉर्मेटिंग|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**एनिमेशन सुविधाएँ:**| | |
|एनिमेशन को SWF में एक्सपोर्ट करना|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|एनिमेशन को HTML में एक्सपोर्ट करना|{{< emoticons/cross >}}|{{< emoticons/cross >}}|