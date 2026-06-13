---
title: ".NET में स्लाइड लेआउट लागू या बदलें"
linktitle: "स्लाइड लेआउट"
type: docs
weight: 60
url: /hi/net/slide-layout/
keywords:
- "स्लाइड लेआउट"
- "सामग्री लेआउट"
- "प्लेसहोल्डर"
- "प्रस्तुति डिज़ाइन"
- "स्लाइड डिज़ाइन"
- "अप्रयुक्त लेआउट"
- "फ़ूटर दृश्यता"
- "शीर्षक स्लाइड"
- "शीर्षक और सामग्री"
- "सेक्शन हेडर"
- "दो सामग्री"
- "तुलना"
- "केवल शीर्षक"
- "ब्लैंक लेआउट"
- "कैप्शन सहित सामग्री"
- "कैप्शन सहित चित्र"
- "शीर्षक और ऊर्ध्वाधर टेक्स्ट"
- "ऊर्ध्वाधर शीर्षक और टेक्स्ट"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में स्लाइड लेआउट को प्रबंधित और अनुकूलित करें। लेआउट प्रकार, प्लेसहोल्डर नियंत्रण, और C# कोड उदाहरणों के माध्यम से फ़ूटर दृश्यता का अन्वेषण करें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड पर सामग्री के लिए प्लेसहोल्डर बॉक्सों की व्यवस्था और फ़ॉर्मेटिंग को परिभाषित करता है। यह नियंत्रित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ दिखाई देते हैं। स्लाइड लेआउट आपको प्रस्तुतियों को तेज़ी से और सुसंगत रूप से डिजाइन करने में मदद करता है—चाहे आप कुछ सरल बना रहे हों या अधिक जटिल। PowerPoint में सबसे सामान्य स्लाइड लेआउट्स में शामिल हैं:

**Title Slide layout** – दो टेक्स्ट प्लेसहोल्डर शामिल हैं: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content layout** – शीर्ष भाग में एक छोटा शीर्षक प्लेसहोल्डर और नीचे मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट्स, चार्ट, छवियाँ, आदि) के लिए बड़ी जगह प्रदान करता है।

**Blank layout** – कोई प्लेसहोल्डर नहीं होता, जिससे आपको स्लाइड को शून्य से डिजाइन करने पर पूर्ण नियंत्रण मिलता है।

स्लाइड लेआउट्स स्लाइड मास्टर का हिस्सा होते हैं, जो प्रस्तुति के लिए लेआउट शैलियों को परिभाषित करने वाली शीर्ष-स्तर की स्लाइड है। आप स्लाइड मास्टर के माध्यम से लेआउट स्लाइड्स तक पहुँच और संशोधन कर सकते हैं—चाहे उनके प्रकार, नाम या अनोखे ID द्वारा। वैकल्पिक रूप से, आप प्रस्तुति के भीतर सीधे किसी विशिष्ट लेआउट स्लाइड को संपादित भी कर सकते हैं।

Aspose.Slides for .NET में स्लाइड लेआउट्स के साथ काम करने के लिए आप उपयोग कर सकते हैं:
- प्रॉपर्टीज़ जैसे [LayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/layoutslides/) और [Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास के तहत उपलब्ध हैं
- प्रकार जैसे [ILayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutplaceholdermanager/), और [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
मास्टर स्लाइड्स के साथ काम करने के बारे में अधिक जानने के लिए, [Slide Master](/slides/hi/net/slide-master/) लेख देखें।
{{% /alert %}}

## **प्रस्तुतियों में स्लाइड लेआउट्स जोड़ें**

अपने स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए, आपको प्रस्तुति में नई लेआउट स्लाइड्स जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for .NET आपको यह जांचने की सुविधा देता है कि कोई विशिष्ट लेआउट पहले से मौजूद है या नहीं, आवश्यक होने पर नया जोड़ें, और उस लेआउट के आधार पर स्लाइड्स सम्मिलित करने के लिए उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterlayoutslidecollection/) तक पहुँचें।
3. जाँचें कि वांछित लेआउट स्लाइड संग्रह में पहले से मौजूद है या नहीं। यदि नहीं, तो आवश्यक लेआउट स्लाइड जोड़ें।
4. नए लेआउट स्लाइड के आधार पर एक खाली स्लाइड जोड़ें।
5. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड लेआउट कैसे जोड़ें:

```cs
// PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // लेआउट स्लाइड प्रकारों के माध्यम से जाकर एक लेआउट स्लाइड चुनें।
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // एक स्थिति जहाँ प्रस्तुति सभी लेआउट प्रकारों को शामिल नहीं करती है।
        // प्रस्तुति फ़ाइल में केवल Blank और Custom लेआउट प्रकार होते हैं।
        // हालांकि, कस्टम प्रकार वाले लेआउट स्लाइड्स के पहचान योग्य नाम हो सकते हैं,
        // जैसे "Title", "Title and Content" आदि, जिन्हें लेआउट स्लाइड चयन के लिए उपयोग किया जा सकता है।
        // आप प्लेसहोल्डर आकार प्रकारों के सेट पर भी भरोसा कर सकते हैं।
        // उदाहरण के तौर पर, एक Title स्लाइड में केवल Title प्लेसहोल्डर प्रकार होना चाहिए, आदि।
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // जोड़े गए लेआउट स्लाइड का उपयोग करके एक खाली स्लाइड जोड़ें।
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // प्रस्तुति को डिस्क पर सहेजें।  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) क्लास से [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड प्रदान करता है, जिससे आप अनावश्यक और अप्रयुक्त लेआउट स्लाइड्स को हटाने में सक्षम होते हैं।

निम्नलिखित C# कोड दिखाता है कि PowerPoint प्रस्तुति से लेआउट स्लाइड को कैसे हटाया जाए:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड लेआउट्स में प्लेसहोल्डर जोड़ें**

Aspose.Slides [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/placeholdermanager/) प्रॉपर्टी प्रदान करता है, जो आपको लेआउट स्लाइड में नए प्लेसहोल्डर जोड़ने की अनुमति देती है।

यह मैनेजर निम्नलिखित प्लेसहोल्डर प्रकारों के लिये मेथड्स प्रदान करता है:

| PowerPoint प्लेसहोल्डर | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutplaceholdermanager/) मेथड |
| ----------------------- | ------------------------------------------------------------ |
| ![सामग्री](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![टेक्स्ट](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![टेक्स्ट (ऊर्ध्वाधर)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![चित्र](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![चार्ट](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![टेबल](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![स्मार्टआर्ट](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![मीडिया](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![ऑनलाइन इमेज](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

निम्नलिखित C# कोड दिखाता है कि Blank लेआउट स्लाइड में नए प्लेसहोल्डर आकार कैसे जोड़ें:

```cs
using (var presentation = new Presentation())
{
    // Blank लेआउट स्लाइड प्राप्त करें।
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // लेआउट स्लाइड का प्लेसहोल्डर मैनेजर प्राप्त करें।
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // विभिन्न प्लेसहोल्डर को Blank लेआउट स्लाइड में जोड़ें।
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Blank लेआउट के साथ एक नई स्लाइड जोड़ें।
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The placeholders on the layout slide](add_placeholders.png)

## **लेआउट स्लाइड के लिए फ़ूटर दृश्यता सेट करें**

PowerPoint प्रस्तुतियों में फुटर तत्व जैसे तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट स्लाइड लेआउट के आधार पर दिखाए या छिपाए जा सकते हैं। Aspose.Slides for .NET आपको इन फुटर प्लेसहोल्डर की दृश्यता को नियंत्रित करने की सुविधा देता है। यह तब उपयोगी होता है जब आप चाहते हैं कि कुछ लेआउट्स फुटर जानकारी दिखाएँ जबकि अन्य साफ़ और न्यूनतम रहें।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स द्वारा एक लेआउट स्लाइड रेफ़रेंस प्राप्त करें।
3. स्लाइड फुटर प्लेसहोल्डर को दिखाने योग्य सेट करें।
4. स्लाइड नंबर प्लेसहोल्डर को दिखाने योग्य सेट करें।
5. तिथि-समय प्लेसहोल्डर को दिखाने योग्य सेट करें।
6. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड दिखाता है कि स्लाइड फुटर की दृश्यता कैसे सेट करें और संबंधित कार्य कैसे करें:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **स्लाइड के लिए चाइल्ड फुटर दृश्यता सेट करें**

PowerPoint प्रस्तुतियों में, तिथि, स्लाइड नंबर और कस्टम टेक्स्ट जैसे फुटर तत्वों को सभी लेआउट स्लाइड्स में स्थिरता बनाए रखने के लिए मास्टर स्लाइड स्तर पर नियंत्रित किया जा सकता है। Aspose.Slides for .NET आपको मास्टर स्लाइड पर इन फुटर प्लेसहोल्डर की दृश्यता और सामग्री सेट करने और ये सेटिंग्स सभी चाइल्ड लेआउट स्लाइड्स तक पहुँचाने की सुविधा देता है। यह तरीका आपकी प्रस्तुति में समान फुटर जानकारी सुनिश्चित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स द्वारा मास्टर स्लाइड का रेफ़रेंस प्राप्त करें।
3. मास्टर और सभी चाइल्ड फुटर प्लेसहोल्डर को दिखाने योग्य सेट करें।
4. मास्टर और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर को दिखाने योग्य सेट करें।
5. मास्टर और सभी चाइल्ड तिथि-समय प्लेसहोल्डर को दिखाने योग्य सेट करें।
6. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड इस ऑपरेशन को दर्शाता है:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड समग्र थीम और डिफ़ॉल्ट फ़ॉर्मेटिंग को परिभाषित करती है, जबकि लेआउट स्लाइड विभिन्न प्रकार की सामग्री के लिये प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरे में कॉपी कर सकता हूँ?**

हां, आप एक प्रस्तुति के [LayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/layoutslides/) संग्रह से लेआउट स्लाइड को क्लोन करके `AddClone` मेथड का उपयोग करके इसे किसी अन्य प्रस्तुति में सम्मिलित कर सकते हैं।

**यदि मैं एक लेआउट स्लाइड को हटाता हूँ जो अभी भी किसी स्लाइड द्वारा इस्तेमाल किया जा रहा है तो क्या होगा?**

यदि आप कोई लेआउट स्लाइड हटाने का प्रयास करते हैं जो प्रस्तुति में कम से कम एक स्लाइड द्वारा अभी भी संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) थ्रो करेगा। इसे टालने के लिए, [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) का उपयोग करें जो केवल उन लेआउट स्लाइड्स को सुरक्षित रूप से हटाता है जो उपयोग में नहीं हैं।

{{% /alert %}}