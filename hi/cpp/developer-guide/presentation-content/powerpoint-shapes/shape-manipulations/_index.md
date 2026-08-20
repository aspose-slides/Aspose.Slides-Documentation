---
title: C++ में प्रस्तुति आकृतियों का प्रबंधन
linktitle: आकृति हेरफेर
type: docs
weight: 40
url: /hi/cpp/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन
- आकृति हटाएँ
- आकृति छिपाएँ
- आकृति क्रम बदलें
- इंटरॉप आकृति ID प्राप्त करें
- आकृति वैकल्पिक टेक्स्ट
- आकृति लेआउट फ़ॉर्मैट
- SVG के रूप में आकृति
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति आकृतियों की पहचान, क्लोन, हटाना, छिपाना, क्रम बदलना, निर्यात, संरेखण और फ़्लिप करने के तरीके सीखें।"
---
## **परिचय**

Aspose.Slides for C++ स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) के रूप में प्रस्तुत करता है। यह संग्रह वह स्थान है जहाँ आप आकृतियों को खोज और संशोधित करते हैं तथा उनका स्टैक क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे की आकृति को दर्शाता है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति को।

यह लेख उसी मॉडल का पालन करता है। यह पहले यह बताता है कि आकृति को विश्वसनीय रूप से कैसे पहचानें, फिर क्लोन, हटाना, छुपाना और क्रम बदलना कैसे किया जाता है। अंतिम भागों में लेआउट‑स्तर का फॉर्मेटिंग, SVG निर्यात, संरेखण और फ्लिप सेटिंग्स को कवर किया गया है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही संचालन उपयोग कर सकते हैं जो आपके कार्यप्रवाह के लिए आवश्यक हैं।

## **आकृतियों की पहचान और खोज**

संग्रह इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। आकृति को जोड़ने, हटाने या क्रम बदलने से उसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रखरखाव के अनुसार एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_name/) डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और उनकी अद्वितीयता गारंटी नहीं है, इसलिए यदि कोड उन पर निर्भर करता है तो नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_alternativetext/) तब उपयोगी होता है जब कोई पहुँच‑विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, इसे स्थानीयकृत या पहुँच के लिए पुनः लिखी जा सकती है, और इसकी अद्वितीयता गारंटी नहीं है। अर्थपूर्ण पहुँच पाठ को चुपचाप डेटाबेस कुंजी के रूप में न प्रयोग करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय होता है और PowerPoint इंटरॉप द्वारा उपयोग किए जाने वाले शेप ID से मेल खाता है। PowerPoint के साथ एकीकरण या आकृति के जीवनकाल के दौरान स्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः निर्मित आकृति एक अलग आकृति होती है और उसका अपना ID प्राप्त करता है।

संबंधित [UniqueId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_uniqueid/) प्रॉपर्टी का प्रस्तुति स्तर पर दायरा है, लेकिन यह ऐड‑इन्स के लिये है और इसे पुनः असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और यह सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण `Name` द्वारा खोज करता है और स्लाइड‑स्तर का इंटरॉप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं होती, तो कोड उस परिणाम को रिपोर्ट करता है बजाय गलत वस्तु के साथ जारी रखने के।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

जब कोई संचालन विशेष रूप से किसी आकृति प्रकार के लिये हो, तो टाइप‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण केवल तभी टेक्स्ट और वैकल्पिक टेक्स्ट अपडेट करता है जब नामित वस्तु एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) हो।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **आकृति संग्रह का संशोधन**

ऐड, क्लोन, रिमूव और रीऑर्डर मेथड्स तुरंत संग्रह पर कार्य करते हैं। यदि कोई संचालन आकृतियों की संख्या या क्रम बदलता है, तो उस संचालन से पहले लिए गए इंडेक्स पर निर्भरता जारी न रखें।

### **आकृति को क्लोन करें**

[AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addclone/) एक स्वतंत्र प्रति बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/insertclone/) भी एक प्रति बनाता है लेकिन उसे निर्दिष्ट ज़‑ऑर्डर इंडेक्स पर रखता है। जो ओवरलोड्स कोऑर्डिनेट्स स्वीकार करते हैं, वे क्लोन को आकार बदले बिना स्थानांतरित करते हैं; चौड़ाई और ऊँचाई वाले ओवरलोड्स इसे पुनः आकार दे सकते हैं।

उदाहरण एक लक्ष्य स्लाइड बनाता है, लेबल वाले आयत को आगे की ओर क्लोन करता है, और दूसरा क्लोन पीछे की ओर सम्मिलित करता है। किसी भी क्लोन में परिवर्तन स्रोत आकृति को नहीं बदलते।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

क्लोनिंग आकृति की सामग्री और फ़ॉर्मेटिंग, नाम और वैकल्पिक टेक्स्ट सहित, कॉपी करता है। जब इन मानों को अद्वितीय होना आवश्यक हो तो क्लोन को नए तार्किक पहचानकर्ता सौंपें। जटिल आकृतियों के संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसका अपना शेप पहचान होता है।

### **आकृतियों को हटाएँ**

[Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/remove/) संग्रह से एक विशिष्ट आकृति वस्तु को हटा देता है। इंडेक्स्ड इटरेशन के दौरान कई मिलान हटाते समय अंत से यात्रा करें ताकि प्रत्येक शेष इंडेक्स वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाली प्रत्येक आकृति को हटाता है। यह वर्तमान इंडेक्स वाली आकृति पढ़ता है, न कि कोई स्थिर संग्रह वस्तु, और अनावश्यक रूप से आकृति को कास्ट नहीं करता।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

हटाने के बाद, आकृति संख्या और पश्च के आकृतियों के इंडेक्स बदल जाते हैं। अप्रभावित आकृतियों के संदर्भ बचाए गए इंडेक्स की तुलना में अधिक विश्वसनीय होते हैं। कनेक्टर्स, एनीमेशन और अन्य प्रस्तुति सुविधाओं को भी विचार करें जो हटाई गई वस्तु को संदर्भित कर सकते हैं; दृश्यमान आकृति हटाने से स्लाइड की उपस्थिति से अधिक परिवर्तन हो सकते हैं।

### **आकृति को छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_hidden/) को `true` सेट करने से आकृति संग्रह में रहती है लेकिन सामान्य स्लाइड शो में प्रदर्शित नहीं होती। इसका इंडेक्स, फॉर्मेटिंग और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए छुपाना वैकल्पिक तत्वों के लिये उपयुक्त है जिन्हें बाद में पुनर्स्थापित किया जा सकता है।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

छुपाना हटाना या सुरक्षा नहीं है। वस्तु को अभी भी उपयोगकर्ता या कोड द्वारा पाया और अनहाइड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बनी रहती है।

### **Z‑ऑर्डर बदलें**

ऑवरलैपिंग आकृतियों को संग्रह क्रम में पेंट किया जाता है। [Reorder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/reorder/) मौजूदा आकृति को क्लोन किए बिना लक्ष्य इंडेक्स पर ले जाता है। इंडेक्स `0` पीछे है; `Count - 1` सामने है।

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आयत को पहले बनाया जाता है और प्रारंभिक रूप से अंडाकार के पीछे स्थित होता है। इसे अंतिम इंडेक्स पर ले जाने से यह आगे आ जाता है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद Z‑ऑर्डर को अंतिम रूप दें, क्योंकि ये कार्य नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड पर आकृतियों का निरीक्षण**

सामान्य स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के पास अलग-अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति सामान्य स्लाइड पर समान स्थिति वाली आकृति नहीं होती। जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझने या बदलने की आवश्यकता हो, तो लेआउट आकृतियों का निरीक्षण करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_fillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_lineformat/) को पढ़ता है, यह मानते हुए नहीं कि सभी आकृतियाँ `AutoShape` हैं।

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

लेआउट को संपादित करने से उससे जुड़ी कई स्लाइडों पर असर पड़ सकता है। लेआउट आकृति बदलने से पहले यह निर्धारित करें कि सामान्य स्लाइड ऑब्जेक्ट को विरासत में लेती है या स्थानीय ओवरराइड रखती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[WriteAsSvg](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/writeassvg/) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल वह आकृति होती है, न कि पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकृतियाँ।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकृति के फ़ॉर्मेटिंग तथा फ़ॉन्ट और चित्र जैसी संसाधनों पर निर्भर करता है। यदि आपको पूरी संरचना चाहिए, तो व्यक्तिगत आकृति के बजाय स्लाइड निर्यात करें। कॉलर स्ट्रीम का मालिक होता है और उसे बंद या डिस्पोज़ करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/alignshapes/) के ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेक्स को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड को निर्दिष्ट करता है। स्लाइड किनारों का उपयोग करने के लिये `alignToSlide` को `true` सेट करें; चयनित आकृतियों को परस्पर सापेक्ष संरेखित करने के लिये इसे `false` सेट करें।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गए आकृति संदर्भों को संरेखण से पहले तुरंत उनके वर्तमान इंडेक्स में परिवर्तित किया जाता है।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

संरेखण स्थितियों को बदलता है, न कि Z‑ऑर्डर को। सापेक्ष संरेखण के लिये सामान्यतः कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या लंबवत वितरण के लिये स्पेसिंग निर्धारित करने हेतु पर्याप्त आकृतियों की जरूरत होती है। मेथड कॉल करने से पहले यदि आप संग्रह में परिवर्तन करते हैं तो इंडेक्स पुनः गणना करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स, और घूर्णन को संग्रहीत करता है। इसके `FlipH` और `FlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/cpp/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्षम करता है, `False` उसे अक्षम करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को संरक्षित रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकृति रखता है।

![फ़्लिप करने से पहले का आकार](shape_to_be_flipped.png)

उदाहरण बाकी सभी फ्रेम मानों को संरक्षित रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_frame/) असाइन करने से पूरी फ्रेम बदल जाती है।

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

सहेजी गई आकृति क्षैतिज और लंबवत रूप से परावर्तित होती है जबकि उसकी स्थिति, आकार और घूर्णन बनाए रहता है।

![फ़्लिप करने के बाद का आकार](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे संग्रह इंडेक्स को आकृति पहचानकर्ता के रूप में उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिये जब संग्रह इंडेक्स उपयोग से पहले नहीं बदलेगा। निर्मित टेम्पलेट्स के लिये मान्य `Name` या `AlternativeText` नियम को प्राथमिकता दें, या स्लाइड‑स्तर के इंटरॉप कार्य के लिये `OfficeInteropShapeId` प्रयोग करें।

**क्या आकृति को छुपाने से वह Z‑ऑर्डर से हट जाती है?**

नहीं। छुपी हुई आकृति वही इंडेक्स पर संग्रह में बनी रहती है। इसे खोजा, पुनः क्रमित, संपादित या फिर से दृश्यमान किया जा सकता है।

**एक क्लोन्ड आकृति दूसरे के सामने क्यों दिखाई दी?**

`AddClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z‑ऑर्डर के सामने है। शुरूआती इंडेक्स चुनने के लिये `InsertClone` उपयोग करें या सभी आकृतियों को जोड़ने के बाद `Reorder` करें।