---
title: C++ में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 80
url: /hi/cpp/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन
- मास्टर स्लाइड कॉपी
- डुप्लिकेट मास्टर स्लाइड
- अप्रयुक्त मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **परिचय**

एक **स्लाइड मास्टर** कई स्लाइडों के समूह के लिये साझा डिजाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फुटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना प्रस्तुति को संगत रखने का सामान्य तरीका है, बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for C++ समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड हो सकते हैं। सामान्य स्लाइडें आमतौर पर सीधे किसी मास्टर स्लाइड का संदर्भ नहीं देतीं। इसके बजाय, एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है।

क्रमशः पदानुक्रम इस प्रकार है:

1. **स्लाइड मास्टर** - साझा डिजाइन और थीम को परिभाषित करता है।
2. **लेआउट स्लाइड** - प्लेसहोल्डर और लेआउट‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
3. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड, लेआउट स्लाइड, और सामान्य स्लाइड का पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया जाता है। प्रस्तुति में सभी मास्टर स्लाइडें [Presentation::get_Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) संग्रह के माध्यम से उपलब्ध होती हैं, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) को लागू करता है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइडें लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइडों के बारे में अधिक जानकारी के लिए देखें [लेआउट स्लाइड लागू या बदलें](/slides/hi/cpp/slide-layout/).
{{% /alert %}}

## **स्लाइड मास्टर तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर व्यू खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुँचने के लिए `get_Masters()` संग्रह का उपयोग करें:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

आप एक सामान्य स्लाइड द्वारा उपयोग की गई मास्टर स्लाइड को उसके लेआउट के माध्यम से भी प्राप्त कर सकते हैं:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **स्लाइड मास्टर में क्या होता है**

एक मास्टर स्लाइड एक स्लाइड जैसा ऑब्जेक्ट है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टी को उजागर करता है। मास्टर‑विशिष्ट सदस्यों की सूची [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) API पेज पर दी गई है।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्य शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `get_Background()` | मास्टर‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `get_Shapes()` | मास्टर पर रखे गए आकार, जैसे लोगो, चित्र फ़्रेम, और साझा टेक्स्ट संग्रहीत करता है। |
| `get_LayoutSlides()` | मास्टर से संबंधित लेआउट स्लाइड्स को संग्रहीत करता है। |
| `get_ThemeManager()` | मास्टर थीम API तक पहुँच प्रदान करता है। |
| `get_HeaderFooterManager()` | मास्टर और उसकी बाल लेआउट्स के लिए हेडर, फुटर, तिथियां, और स्लाइड नंबर नियंत्रित करता है। |
| `GetDependingSlides()` | उन सामान्य स्लाइड्स को लौटाता है जो लेआउट के माध्यम से मास्टर पर निर्भर हैं। |

## **स्लाइड मास्टर में एक छवि जोड़ें**

जब आप एक मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड, और अन्य पुनरावृत्त दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

चित्र फ़्रेम के बारे में अधिक जानकारी के लिए देखें [चित्र फ़्रेम](/slides/hi/cpp/picture-frame/).

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर्स आमतौर पर लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड उस साझा शैली और थीम को प्रदान करता है जिसे ये लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, प्लेसहोल्डर कमांड स्लाइड मास्टर व्यू में उपलब्ध होते हैं।

![PowerPoint स्लाइड मास्टर व्यू में प्लेसहोल्डर सम्मिलित कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर्स जोड़ने के लिए, मास्टर से संबंधित लेआउट स्लाइड के साथ काम करें:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकार को भी स्वरूपित कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और रैखिक ग्रेडियेंट फिल लागू करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![सामान्य स्लाइड्स द्वारा विरासत में मिले स्वरूपित शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें](/slides/hi/cpp/manage-placeholder/) और [टेक्स्ट फ़ॉर्मेटिंग](/slides/hi/cpp/text-formatting/).

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि को लेआउट और उन स्लाइड्स द्वारा विरासत में मिलता है जो इसे अधिलेखित नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

संबंधित विषयों के लिए देखें [प्रेज़ेंटेशन पृष्ठभूमि](/slides/hi/cpp/presentation-background/) और [प्रेज़ेंटेशन थीम](/slides/hi/cpp/presentation-theme/).

## **एक स्लाइड मास्टर को अन्य प्रस्तुति में क्लोन करें**

[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) का उपयोग करके एक मास्टर स्लाइड को दूसरी प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर फिर गंतव्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

यदि आपको अपने मास्टर के साथ सामान्य स्लाइड्स को क्लोन करने की आवश्यकता है, तो देखें [स्लाइड्स क्लोन करें](/slides/hi/cpp/clone-slides/).

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह उपयोगी है जब विभिन्न अनुभागों को विभिन्न ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स सम्मिलित करने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड को [IBaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/) से विरासत में मिले `Equals` मेथड से तुलना किया जा सकता है। तुलना संरचना और स्थिर सामग्री जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स की जांच करती है। यह अनूठे पहचानकर्ताओं जैसे स्लाइड IDs, या गतिशील प्लेसहोल्डर मान जैसे वर्तमान तिथि की तुलना नहीं करती।

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

अधिक जानकारी के लिए देखें [प्रेज़ेंटेशन स्लाइड्स की तुलना करें](/slides/hi/cpp/compare-slides/).

## **स्लाइड मास्टर व्यू को डिफ़ॉल्ट व्यू सेट करें**

[ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) पर `set_LastView` मेथड का उपयोग करके PowerPoint द्वारा पहली बार खुलने वाले व्यू को नियंत्रित करें। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

अधिक व्यू सेटिंग्स के लिए देखें [प्रेज़ेंटेशन सहेजें](/slides/hi/cpp/save-presentation/).

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कभी-कभी प्रस्तुतियों में ऐसे मास्टर स्लाइड्स होते हैं जो अब किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं किए जाते। अनुपयोगी मास्टरों को हटाने से फ़ाइल आकार कम हो सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

अनुपयोगी मास्टरों को `get_Masters()` संग्रह से हटाने के लिए [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/hi/cpp/aspose.slides/masterslidecollection/removeunused/) का उपयोग करें:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आप कम-कोड [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) मेथड का भी उपयोग कर सकते हैं:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

एक स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकार और टेक्स्ट शैलियों जैसी साझा डिजाइन सेटिंग्स को परिभाषित करता है। एक लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है। एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में लेती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हाँ। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। विभिन्न अनुभागों को अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होने पर कई मास्टर का उपयोग करें।

**मुझे प्लेसहोल्डर मास्टर स्लाइड में जोड़ना चाहिए या लेआउट स्लाइड में?**

अधिकांश मामलों में, प्लेसहोल्डर लेआउट स्लाइड्स में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर को उन लेआउट्स पर रखें जिन्हें सामान्य स्लाइड्स उपयोग करेगी।

**क्या मैं एक मास्टर स्लाइड को हटा सकता हूँ जो अभी भी उपयोग में है?**

नहीं। जो मास्टर स्लाइड निर्भर स्लाइड्स रखती है, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या एक ऐसी क्लीन‑अप विधि उपयोग करें जो केवल उन मास्टरों को हटाती है जो उपयोग में नहीं हैं।