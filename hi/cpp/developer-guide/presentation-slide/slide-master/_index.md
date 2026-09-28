---
title: C++ में प्रेजेंटेशन स्लाइड मास्टर्स का प्रबंधन
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
- मास्टर स्लाइड को क्लोन करें
- मास्टर स्लाइड की कॉपी बनाएं
- मास्टर स्लाइड को डुप्लिकेट करें
- अनुपयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides में स्लाइड मास्टर्स का प्रबंधन: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **अवलोकन**

एक **slide master** स्लाइड समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट स्टाइल, थीम सेटिंग्स और फ़ुटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, slide master को संपादित करना वह सामान्य तरीका है जिससे प्रस्तुति को सुसंगत रखा जाता है बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for C++ भी उसी मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक master slides हो सकते हैं, और प्रत्येक master slide में कई layout slides हो सकते हैं। सामान्य स्लाइड्स सीधे किसी master slide को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक layout slide का उपयोग करती है, और वह layout slide किसी master slide से जुड़ी होती है।

क्रमांकन इस प्रकार है:

1. **Slide master** – साझा डिज़ाइन और थीम को परिभाषित करता है।  
2. **Layout slide** – प्लेसहोल्डर्स और लेआउट‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
3. **Normal slide** – वास्तविक प्रस्तुति सामग्री रखती है और एक layout slide का उपयोग करती है।

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Aspose.Slides में, slide master को [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया जाता है। किसी प्रस्तुति के सभी master slides को [Presentation::get_Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) संग्रह के माध्यम से उपलब्ध कराया जाता है, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) को लागू करता है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर की प्रॉपर्टी लागू होती है। उदाहरण के तौर पर, यदि एक master slide और एक layout slide दोनों पृष्ठभूमि को परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/slides/hi/cpp/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंचना**

PowerPoint में, आप **View** > **Slide Master** से Slide Master दृश्य खोल सकते हैं।

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Aspose.Slides में, master slides तक पहुंचने के लिए `get_Masters()` संग्रह का उपयोग करें:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

आप एक सामान्य स्लाइड के लेआउट के माध्यम से उपयोग किए गए master slide को भी प्राप्त कर सकते हैं:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Slide Master में क्या शामिल होता है**

एक master slide एक स्लाइड‑समान ऑब्जेक्ट है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और layout स्लाइड्स द्वारा उपयोग की जाने वाली कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है। master‑विशिष्ट सदस्य [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) API पेज पर सूचीबद्ध हैं।

आम तौर पर उपयोग किए जाने वाले master slide सदस्य इस प्रकार हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `get_Background()` | master‑स्तर स्लाइड पृष्ठभूमि सेट करता है। |
| `get_Shapes()` | master पर रखे गए आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `get_LayoutSlides()` | master के अंतर्गत आने वाले layout slides को संग्रहीत करता है। |
| `get_ThemeManager()` | master थीम API तक पहुंच प्रदान करता है। |
| `get_HeaderFooterManager()` | master और उसके चाइल्ड लेआउट्स के हेडर, फुटर, तिथि और स्लाइड नंबर को नियंत्रित करता है। |
| `GetDependingSlides()` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट के माध्यम से master पर निर्भर करती हैं। |

## **Slide Master में चित्र जोड़ना**

जब आप एक master slide में चित्र जोड़ते हैं, तो वह उन स्लाइड्स में दिखता है जो उस master के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराव वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले master slide में एक लोगो जोड़ता है:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

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

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/cpp/picture-frame/)।

## **Master ग्राफ़िक्स की दृश्यता नियंत्रित करना**

[IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/set_showmastershapes/) का उपयोग करके आप विरासत में मिले master ग्राफ़िक्स (जैसे लोगो या सजावटी आकार) को हटाए बिना छिपा सकते हैं। उस स्लाइड पर `false` पास करें जहाँ आप ग्राफ़िक्स को छोड़ना चाहते हैं, और उन स्लाइड्स पर `true` पास करें जहाँ आप उन्हें दिखाना चाहते हैं:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यह उदाहरण एक नई प्रस्तुति के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने प्लेसहोल्डर्स को हटाता है।

### **सेटिंग का दायरा चुनें**

एक सामान्य स्लाइड अपने master को [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/get_layoutslide/) और [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_masterslide/) के माध्यम से उपयोग करती है। किसी व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल वही स्लाइड प्रभावित होती है। `false` को [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/layoutslide/set_showmastershapes/) को पास करने से उन स्लाइड्स के लिए master ग्राफ़िक्स छिप जाते हैं जो उस साझा लेआउट का उपयोग करती हैं, भले ही उनकी अपनी सेटिंग `true` हो। केवल एक स्लाइड पर ग्राफ़िक्स छिपाने के लिए, स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को अपरिवर्तित रखें।

यह सेटिंग master slide स्वयं पर दृश्यता नियंत्रण के रूप में समर्थित नहीं है। master पर यह हमेशा `false` लौटाता है, और `true` असाइन करने पर `System::NotSupportedException` उत्पन्न होता है। इसे सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करें**

| ऑपरेशन | प्रभाव |
| --- | --- |
| Master ग्राफ़िक्स छिपाएँ | विरासत में मिले master आकारों की दृश्यता को बिना हटाए या स्लाइड के स्वयं के आकारों को बदले नियंत्रित करता है। |
| स्लाइड पृष्ठभूमि भराव बदलें | पृष्ठभूमि का रंग, ग्रेडिएंट या चित्र बदलता है। Master ग्राफ़िक्स अलग आकार होते हैं और उस पृष्ठभूमि के ऊपर दिखते रह सकते हैं। देखें [Presentation Background](/slides/hi/cpp/presentation-background/)। |
| master से आकार हटाएँ | साझा स्रोत आकार को हटा देता है, जिससे वह किसी भी स्लाइड के लिए उपलब्ध नहीं रहता जो उस master का उपयोग करती है। |

## **प्लेसहोल्डर्स के साथ काम करना**

प्लेसहोल्डर्स सामान्यतः layout slides पर परिभाषित होते हैं। master slide साझा शैली और थीम प्रदान करता है जिसे लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, प्लेसहोल्डर कमांड्स Slide Master दृश्य में उपलब्ध होते हैं।

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Aspose.Slides में नए प्लेसहोल्डर्स जोड़ने के लिए, उस layout slide के साथ काम करें जो master से संबंधित है:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

आप master slide पर पहले से मौजूद प्लेसहोल्डर आकारों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और रैखिक ग्रेडिएंट भराव लागू करता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/cpp/manage-placeholder/) और [Text Formatting](/slides/hi/cpp/text-formatting/)।

## **Slide Master पृष्ठभूमि बदलना**

एक master पृष्ठभूमि को लेआउट और स्लाइड्स द्वारा विरासत में मिला जाता है जब तक वह ओवरराइड न हो। निम्न उदाहरण पहले master slide के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/cpp/presentation-background/) और [Presentation Theme](/slides/hi/cpp/presentation-theme/)।

## **Slide Master को दूसरे प्रस्तुति में क्लोन करना**

[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) का उपयोग करके आप एक master slide को दूसरे प्रस्तुति में कॉपी कर सकते हैं। कॉपी किया गया master फिर गंतव्य प्रस्तुति के लेआउट और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

यदि आप सामान्य स्लाइड्स को उनके master के साथ क्लोन करना चाहते हैं, तो देखें [Clone Slides](/slides/hi/cpp/clone-slides/)।

## **एकाधिक Slide Masters जोड़ना**

एक प्रस्तुति में कई master slides हो सकते हैं। यह तब उपयोगी है जब विभिन्न सेक्शन को अलग‑अलग ब्रांडिंग, पेज संरचना या थीम सेटिंग्स की आवश्यकता हो।

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट master को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन्ड master के तहत एक लेआउट बनाता है, और उस लेआउट पर आधारित नई स्लाइड जोड़ता है:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

## **Slide Masters की तुलना करना**

Master slides की तुलना `Equals` मेथड से की जा सकती है, जिसे [IBaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/) से विरासत में मिला है। तुलना संरचना और स्थैतिक सामग्री (जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन और अन्य स्लाइड सेटिंग्स) को देखती है। यह अद्वितीय पहचानकर्ता (जैसे slide IDs) या गतिशील प्लेसहोल्डर मान (जैसे वर्तमान तिथि) की तुलना नहीं करती।

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

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

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/cpp/compare-slides/)।

## **Slide Master दृश्य को डिफ़ॉल्ट दृश्य बनाना**

[ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) पर `set_LastView` मेथड का उपयोग करके आप वह दृश्य नियंत्रित कर सकते हैं जो PowerPoint पहले खोलता है। निम्न उदाहरण प्रस्तुति को Slide Master दृश्य में खोलता है:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/cpp/save-presentation/)।

## **अप्रयुक्त Master Slides हटाना**

कभी‑कभी प्रस्तुति में ऐसे master slides होते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं किए जाते। अप्रयुक्त master को हटाने से फ़ाइल आकार घट सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

`get_Masters()` संग्रह से अप्रयुक्त masters हटाने के लिए उपयोग करें [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/hi/cpp/aspose.slides/masterslidecollection/removeunused/) :

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आप कम‑कोड विधि [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) भी उपयोग कर सकते हैं:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Slide master और layout slide में क्या अंतर है?**

एक slide master साझा डिज़ाइन सेटिंग्स जैसे थीम, पृष्ठभूमि, सामान्य आकार और टेक्स्ट स्टाइल को परिभाषित करता है। एक layout slide master का भाग होता है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करता है। एक सामान्य स्लाइड एक layout slide का उपयोग करती है, इसलिए वह दोनों layout और master से विरासत में प्राप्त करती है।

**क्या एक प्रस्तुति में कई slide masters हो सकते हैं?**

हां। एक प्रस्तुति में कई slide masters हो सकते हैं। जब विभिन्न सेक्शन को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता हो, तो कई masters का उपयोग करें।

**क्या मुझे प्लेसहोल्डर्स master slide में जोड़ने चाहिए या layout slide में?**

अधिकांश मामलों में प्लेसहोल्डर्स को layout slides में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग master slide पर रखें, और सामग्री प्लेसहोल्डर्स को उन लेआउट्स पर रखें जिन्हें सामान्य स्लाइड्स उपयोग करती हैं।

**क्या मैं अभी भी उपयोग में आए master slide को हटा सकता हूं?**

नहीं। किसी master slide को जिसे निर्भर स्लाइड्स हैं, सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइड्स को किसी अन्य master के तहत लेआउट में स्थानांतरित करें, या केवल अप्रयुक्त masters को हटाने की सफ़ाई विधि का उपयोग करें।