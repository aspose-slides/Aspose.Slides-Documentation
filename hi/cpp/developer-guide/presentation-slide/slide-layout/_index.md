---
title: C++ में स्लाइड लेआउट लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/cpp/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रेज़ेंटेशन डिज़ाइन
- स्लाइड डिज़ाइन
- अनुपयोगी लेआउट
- फ़ूटर दिखावट
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और ऊर्ध्वाधर पाठ
- ऊर्ध्वाधर शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड लेआउट प्रबंधित और अनुकूलित करें। लेआउट प्रकार, प्लेसहोल्डर नियंत्रण, और C++ कोड उदाहरणों के माध्यम से फ़ूटर दिखावट का अन्वेषण करें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड की सामग्री के लिए प्लेसहोल्डर बॉक्सों की व्यवस्था और फ़ॉर्मेटिंग को परिभाषित करता है। यह नियंत्रित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ दिखते हैं। स्लाइड लेआउट्स आपको प्रस्तुतीकरण जल्दी और स्थिर रूप से डिजाइन करने में मदद करते हैं—चाहे आप कुछ सरल बना रहे हों या अधिक जटिल। PowerPoint में सबसे सामान्य स्लाइड लेआउट्स में शामिल हैं:

**Title Slide layout** – दो टेक्स्ट प्लेसहोल्डर शामिल करता है: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content layout** – ऊपर एक छोटा शीर्षक प्लेसहोल्डर और नीचे मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट, चार्ट, चित्र, आदि) के लिए बड़ा प्लेसहोल्डर प्रदान करता है।

**Blank layout** – कोई प्लेसहोल्डर नहीं होता, इसलिए आप स्लाइड को शून्य से डिजाइन कर सकते हैं।

स्लाइड लेआउट्स एक स्लाइड मास्टर का हिस्सा होते हैं, जो प्रस्तुतीकरण के लिए लेआउट शैलियों को परिभाषित करने वाला शीर्ष‑स्तरीय स्लाइड है। आप स्लाइड मास्टर के माध्यम से लेआउट स्लाइड्स तक पहुँच और संशोधन कर सकते हैं—उन्हें उनके प्रकार, नाम या अनोखी ID द्वारा। वैकल्पिक रूप से, आप प्रस्तुतीकरण के भीतर सीधे किसी विशिष्ट लेआउट स्लाइड को भी संपादित कर सकते हैं।

Aspose.Slides for Android में स्लाइड लेआउट्स के साथ काम करने के लिए आप उपयोग कर सकते हैं:

- Methods such as [get_LayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_layoutslides/) and [get_Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) under the [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class
- Types like [ILayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/), and [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
अधिक जानकारी के लिए, मास्टर स्लाइड्स के साथ काम करने को देखें: [स्लाइड मास्टर](/slides/hi/cpp/slide-master/) लेख।
{{% /alert %}}

## **प्रेजेंटेशन में स्लाइड लेआउट्स जोड़ें**

अपनी स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए आपको नई लेआउट स्लाइड्स जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for Android आपको यह जाँचने देता है कि कोई विशेष लेआउट पहले से मौजूद है या नहीं, आवश्यक होने पर नया लेआउट जोड़ता है, और उस लेआउट के आधार पर स्लाइड्स सम्मिलित करता है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class.
2. Access the [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterlayoutslidecollection/).
3. Check whether the desired layout slide already exists in the collection. If not, add the layout slide you need.
4. Add an empty slide based on the new layout slide.
5. Save the presentation.

The following C++ code demonstrates how to add a slide layout to a PowerPoint presentation:

```cpp
// PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // ऐसी स्थिति जहाँ प्रस्तुति में सभी लेआउट प्रकार नहीं होते हैं।
    // प्रस्तुति फ़ाइल में केवल Blank और Custom लेआउट प्रकार होते हैं।
    // हालाँकि, कस्टम प्रकार वाली लेआउट स्लाइड्स में पहचाने जाने योग्य नाम हो सकते हैं,
    // जैसे "Title", "Title and Content" आदि, जिन्हें लेआउट स्लाइड चयन के लिए उपयोग किया जा सकता है।
    // आप प्लेसहोल्डर आकार प्रकारों के सेट पर भी निर्भर कर सकते हैं।
    // उदाहरण के लिए, एक Title स्लाइड में केवल Title प्लेसहोल्डर प्रकार होना चाहिए, आदि।
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Add an empty slide using the added layout slide.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Save the presentation to disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अनुपयोगी लेआउट स्लाइड्स हटाएँ**

Aspose.Slides provides the [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method from the [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) class to allow you to delete unwanted and unused layout slides.

The following C++ code shows how to remove a layout slide from a PowerPoint presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **लेआउट स्लाइड्स में प्लेसहोल्डर जोड़ें**

Aspose.Slides provides the [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) method, which allows you to add new placeholders to a layout slide.

This manager contains methods for the following placeholder types:

| PowerPoint प्लेसहोल्डर | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/) विधि |
| ---------------------- | ------------------------------------------------------------ |
| ![सामग्री](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![पाठ](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![पाठ (ऊर्ध्वाधर)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![चित्र](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![चार्ट](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![तालिका](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![स्मार्टआर्ट](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![मीडिया](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![ऑनलाइन छवि](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

The following C++ code demonstrates how to add new placeholder shapes to the Blank layout slide:

```cpp
auto presentation = MakeObject<Presentation>();

// खाली लेआउट स्लाइड प्राप्त करें।
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// लेआउट स्लाइड का प्लेसहोल्डर मैनेजर प्राप्त करें।
auto placeholderManager = layout->get_PlaceholderManager();

// विभिन्न प्लेसहोल्डर को खाली लेआउट स्लाइड में जोड़ें।
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// खाली लेआउट के साथ एक नई स्लाइड जोड़ें।
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

## **लेआउट स्लाइड के लिए फ़ूटर दृश्यता सेट करें**

PowerPoint प्रस्तुतियों में, फ़ूटर तत्व जैसे तिथि, स्लाइड संख्या, और कस्टम टेक्स्ट लेआउट के आधार पर दिखाए या छुपाए जा सकते हैं। Aspose.Slides for Android आपको इन फ़ूटर प्लेसहोल्डर की दृश्यता को नियंत्रित करने की सुविधा देता है। यह तब उपयोगी होता है जब आप चाहते हैं कि कुछ लेआउट्स फ़ूटर जानकारी दिखाएँ जबकि अन्य साफ़ और न्यूनतम रहें।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class.
2. Get a layout slide reference by its index.
3. Set the slide footer placeholder to visible.
4. Set the slide number placeholder to visible.
5. Set the date-time placeholder to visible.
6. Save the presentation.

The following C++ code shows how to set the visibility of a slide footer and perform related tasks:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड के लिए चाइल्ड फ़ूटर दृश्यता सेट करें**

PowerPoint प्रस्तुतियों में, फ़ूटर तत्व जैसे तिथि, स्लाइड संख्या, और कस्टम टेक्स्ट को मास्टर स्लाइड स्तर पर नियंत्रित किया जा सकता है ताकि सभी लेआउट स्लाइड्स में समानता बनी रहे। Aspose.Slides for Android आपको मास्टर स्लाइड पर इन फ़ूटर प्लेसहोल्डर की दृश्यता और सामग्री सेट करने और इन सेटिंग्स को सभी चाइल्ड लेआउट स्लाइड्स में लागू करने की अनुमति देता है। यह विधि आपके पूरे प्रस्तुतिकरण में समान फ़ूटर जानकारी सुनिश्चित करती है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class.
2. Get a reference to the master slide by its index.
3. Set the master’s and all child footer placeholders to visible.
4. Set the master’s and all child slide number placeholders to visible.
5. Set the master’s and all child date-time placeholders to visible.
6. Save the presentation.

The following C++ code demonstrates this operation:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड कुल थीम और डिफ़ॉल्ट फ़ॉर्मेटिंग को परिभाषित करती है, जबकि लेआउट स्लाइड विशिष्ट प्रकार की सामग्री के लिए प्लेसहोल्डर की व्यवस्था को निर्धारित करती है।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुतीकरण से दूसरे में कॉपी कर सकता हूँ?**

हाँ, आप किसी प्रस्तुतीकरण के लेआउट स्लाइड संग्रह से [get_LayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_layoutslides/) मेथड का उपयोग करके लेआउट स्लाइड को क्लोन कर सकते हैं, और `AddClone` मेथड से इसे दूसरे प्रस्तुतीकरण में डाल सकते हैं।

**यदि मैं किसी लेआउट स्लाइड को हटाता हूँ जो अभी भी किसी स्लाइड द्वारा उपयोग में है तो क्या होता है?**

यदि आप ऐसी लेआउट स्लाइड को हटाने की कोशिश करते हैं जो कम से कम एक स्लाइड द्वारा अभी भी संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxeditexception/) उठाएगा। इसे रोकने के लिए, आप [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) का उपयोग कर सकते हैं, जो सुरक्षित रूप से केवल अनउपयोगी लेआउट स्लाइड्स को हटाता है।