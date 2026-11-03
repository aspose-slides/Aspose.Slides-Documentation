---
title: C++ में प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/cpp/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- चित्र प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- कंटेंट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ टेक्स्ट, चित्र, चार्ट और कंटेंट प्लेसहोल्डर को निरीक्षण और संपादन करना तथा प्लेसहोल्डर विरासत को समझना सीखें।"
---
## **परिचय**

एक प्लेसहोल्डर एक आकार (shape) है जो प्रस्तुति टेम्पलेट में किसी विशेष प्रकार की सामग्री के लिए एक स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट और सामान्य प्रयोजन की सामग्री प्लेसहोल्डर शामिल हैं। सामान्य आकार के विपरीत, एक प्लेसहोल्डर अपनी स्थिति, आकार, स्वरूपण और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में प्राप्त कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) मेथड के माध्यम से प्रस्तुत करता है। यह मेथड एक [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) ऑब्जेक्ट या सामान्य आकार के लिए `nullptr` लौटाता है। प्लेसहोल्डर में क्या होना चाहिए, यह निर्धारित करने के लिए [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) उपयोग करें।

शेप इंटरफ़ेस अभी भी मायने रखता है जब आप प्लेसहोल्डर प्रकार जानते हैं:

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट प्लेसहोल्डर सामान्यतः एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) द्वारा प्रदर्शित किया जाता है।
- एक भरा हुआ चित्र प्लेसहोल्डर एक [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) द्वारा प्रदर्शित किया जा सकता है।
- एक भरा हुआ चार्ट प्लेसहोल्डर एक [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) द्वारा प्रदर्शित किया जा सकता है।
- एक कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। हर प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) माना जाने के बजाय [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) और रनटाइम आकार इंटरफ़ेस दोनों की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकार के रनटाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों तक पहुंचने से पहले हमेशा प्रकार जाँच का उपयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियों को परिभाषित करती है और कुछ मामलों में मास्टर‑लेवल प्लेसहोल्डर भी रखती है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था को परिभाषित करती है और मास्टर से विरासत प्राप्त कर सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर रखती है और अपनी लेआउट से विरासत प्राप्त कर सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) को कॉल करें। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार का कोई बेस प्लेसहोल्डर न हो तो मेथड `nullptr` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर सूचीबद्ध करता है और उनके बेस प्लेसहोल्डर रिपोर्ट करता है:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

एक सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए एक स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से सभी स्लाइडें प्रभावित हो सकती हैं जो अभी भी वह सेटिंग विरासत में लेती हैं। एक सामान्य आकार जिसका कोई बेस प्लेसहोल्डर नहीं है, केवल इसलिए विरासत नहीं शुरू करता क्योंकि वह समान समन्वय रखता है।

## **प्लेसहोल्डर स्थिति हटाएँ**

टेम्पलेट को अनुकूलित करते समय, मौजूदा ऑब्जेक्ट को सामान्य आकार के रूप में रखने के लिए [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) का उपयोग करें। इसका [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) मेथड `nullptr` लौटाता है, लेकिन आकार स्लाइड की कलेक्शन में बना रहता है। इसके विपरीत, [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) आकार को उस कलेक्शन से हटा देता है।

निम्न उदाहरण के लिए आवश्यक है कि `template.pptx` में कम से कम एक स्लाइड और पहली स्लाइड पर एक अधूरा टेक्स्ट प्लेसहोल्डर हो। लेआउट या मास्टर से विरासत में मिली स्वरूपण वाले प्लेसहोल्डर का उपयोग करके संबंध को हटाने के प्रभाव को देखें। उदाहरण जाँचता है कि वही आकार बना रहता है, फिर उसी सामान्य आकार पर फिर से मेथड को कॉल करता है और परिणाम सहेजता है।

{{% alert color="warning" title="Warning" %}}
प्लेसहोल्डर स्थिति को हटाने से विरासत में मिली उपस्थिति सेटिंग्स स्वचालित रूप से संरक्षित नहीं रहतीं। नीचे दिया गया उदाहरण जानबूझकर उन सेटिंग्स को अपरिवर्तित छोड़ता है, इसलिए आउटपुट अलग दिख सकता है। पूरी तरह विरासत में मिली स्थिति और आकार वाले आकार कॉल के बाद शून्य समन्वय और आयाम रख सकता है और वह कलेक्शन में बना रहने पर भी अदृश्य हो सकता है।
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // साधारण आकार पर मेथड को कॉल करने से कोई प्रभाव नहीं पड़ता।
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

मिलते‑जुलते प्लेसहोल्डर के लिए, सभी तीन जाँचें `True` प्रिंट करती हैं। टेक्स्ट बना रहता है, लेकिन विरासत में मिला स्थान, आकार, घुमाव, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट‑फ़्रेम मार्जिन, वर्टिकल एंकरिंग, फ़िल, और लाइन सेटिंग्स प्लेसहोल्डर संबंध हटाए जाने पर बदल सकते हैं। उदाहरण के लिए, विरासत में मिला शीर्षक स्वरूपण साधारण टेक्स्ट स्वरूपण में गिर सकता है। लेआउट के बारे में अधिक जानकारी के लिए देखें: [Slide Layout](/slides/hi/cpp/slide-layout/)।

इच्छित उपस्थिति को बनाए रखने के लिए, कॉल से पहले हल किए गए स्थान, आकार और घुमाव को कैप्चर करें, और आवश्यक प्रभावी स्वरूपण मानों को अलग वेरिएबल्स में कॉपी करें। इन मानों को [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), और [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) के माध्यम से प्राप्त करें। केवल प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट को रखें पर भरोसा न करें, क्योंकि संबंध हटाए जाने के बाद उनके टेक्स्ट‑फ़ॉर्मेटिंग मान बदल सकते हैं। कैप्चर किए गए मानों को सामान्य आकार पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट फ़ैमिली, आकार, शैली, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट‑फ़्रेम सेटिंग्स, फ़िल और लाइन शामिल हों।

विरासत में मिले आकार ज्यामिति को भी [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) के द्वारा स्पष्ट रूप से असाइन करने की आवश्यकता हो सकती है। आयताकार टेक्स्ट प्लेसहोल्डर के लिए इसका अर्थ है [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) असाइन करना; केवल फ़िल और लाइन को पुनर्स्थापित करने से दिखाई देने वाला आयत नहीं बन सकता। अतिरिक्त इफ़ेक्ट्स या अधिक जटिल स्वरूपण वाले टेम्पलेट को भी इन सेटिंग्स को संभालना पड़ेगा।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। उपयोग करने से पहले [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) की जाँच करें और उसके [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) मेथड को कॉल करें।

यह उदाहरण पहली स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) में कास्ट करने से बचाता है। यह प्लेसहोल्डर को उसके उद्देश्य से पहचानता है न कि अस्थिर आकार इंडेक्स पर निर्भर होने से।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिजाइन‑टाइम निर्देश है जो एक खाली प्लेसहोल्डर में दिखाया जाता है, जैसे *Click to add title*। प्रॉम्प्ट टेक्स्ट को सामान्य स्लाइड के आकार कलेक्शन से प्राप्त करने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर सेट करें। लेआउट तक पहुँचने के लिए [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) का उपयोग करें और [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/) पर इटरेट करें।

निम्न उदाहरण पहली स्लाइड द्वारा उपयोग किये गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट को बदलता है:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए निर्देशित है। जब उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान करता है, तो प्रॉम्प्ट अब नहीं दिखाया जाता। प्रॉम्प्ट बदलने से उस लेआउट को उपयोग करने वाली स्लाइडों पर मौजूदा टेक्स्ट प्रतिस्थापित नहीं होता।

## **चित्र प्लेसहोल्डर अपडेट करें**

दो मामलों को संभालना है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) द्वारा दर्शाया गया है, तो चित्र को [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) और [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) के माध्यम से बदलें।
- यदि वह अभी भी खाली प्लेसहोल्डर है, तो प्लेसहोल्डर के समन्वय पर एक चित्र फ्रेम जोड़ें [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) से और खाली प्लेसहोल्डर को हटा दें।

अगला उदाहरण दोनों मामलों को सपोर्ट करता है और प्रस्तुति को सहेजता है:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

खाली प्लेसहोल्डर के लिए बनाई गई रिप्लेसमेंट एक स्थानीय चित्र फ्रेम है, न कि नया प्लेसहोल्डर, क्योंकि [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) केवल‑पढ़ने योग्य है। यह रिज़र्व किया गया स्थान रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार विरासत में नहीं लेता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर को तैयार और भरें, फिर Aspose.Slides के साथ परिणत [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) को अपडेट करें।

इमेज ट्रांसपरेंसी, क्रॉपिंग और अन्य चित्र‑विशिष्ट इफ़ेक्ट्स के लिए देखें: [Manage Picture Frames](/slides/hi/cpp/picture-frame/)। ये ऑपरेशन चित्र फ्रेम या चित्र फ़िल से संबंधित हैं, न कि प्लेसहोल्डर मेटाडाटा से।

## **चार्ट और कंटेंट प्लेसहोल्डर के साथ काम करें**

एक भरा हुआ चार्ट प्लेसहोल्डर एक [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रनटाइम इंटरफ़ेस दोनों से ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

एक सामान्य कंटेंट प्लेसहोल्डर आमतौर पर [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों (चार्ट, टेबल, डायग्राम, चित्र, मीडिया) को लॉन्च करने वाला बन जाता है। एक बार भर जाने के बाद, वास्तविक आकार इंटरफ़ेस की जाँच करें कि उसमें क्या है। विशेष लेआउट [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), या [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) को भी उजागर कर सकते हैं।

Aspose.Slides खाली [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) प्लेसहोल्डर को केवल [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) को बदलकर [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) में नहीं बदलता; प्रकार केवल‑पढ़ने योग्य है। खाली चार्ट या कंटेंट एरिया को प्रोग्रामेटिक रूप से भरने के लिए, प्लेसहोल्डर के समन्वय पर आवश्यक ऑब्जेक्ट जोड़ें और फिर खाली प्लेसहोल्डर को हटाएँ। निम्न उदाहरण एक चार्ट के लिए यही करता है:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। जब आपको उसकी श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलने की आवश्यकता हो, तो समर्पित [चार्ट प्रबंधन लेख](/slides/hi/cpp/powerpoint-charts/) देखें।

## **पूरा उदाहरण: टेक्स्ट या इमेज कंटेंट अपडेट करें**

निम्न अंतिम‑से‑अंत उदाहरण एक टेम्पलेट खोलता है, पहली स्लाइड में शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकार की जाँच करता है, उपयुक्त कंटेंट अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण जानबूझकर आकार इंडेक्स मानने या हर प्लेसहोल्डर को एक ही इंटरफ़ेस में कास्ट करने से बचता है।

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है?**

बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर स्थित होता है, जिससे दूसरा प्लेसहोल्डर विरासत प्राप्त करता है। इसे प्राप्त करने के लिए [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) उपयोग करें। एक सामान्य स्थानीय आकार `nullptr` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं सभी स्लाइड शीर्षकों को लेआउट प्लेसहोल्डर को संपादित करके बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली स्वरूपण या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों में संग्रहीत होती है। प्रस्तुति में सभी शीर्षक टेक्स्ट को बदलने के लिए, स्लाइडों पर इटरेट करें और प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हैडर और फुटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्तर पर हेडर और फुटर प्रबंधकों का उपयोग करें। पूर्ण उदाहरणों के लिए देखें: [Manage Presentation Header and Footer](/slides/hi/cpp/presentation-header-and-footer/)