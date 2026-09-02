---
title: C++ में प्रस्तुति प्लेसहोल्डर्स को प्रबंधित करें
linktitle: प्लेसहोल्डर्स प्रबंधित करें
type: docs
weight: 10
url: /hi/cpp/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- चित्र प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर्स की जाँच और संपादन करना सीखें और प्लेसहोल्डर विरासत को समझें।"
---
## **समीक्षा**

एक प्लेसहोल्डर वह आकार है जो प्रस्तुति टेम्प्लेट में किसी विशिष्ट प्रकार की सामग्री के लिए स्थिति आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। एक सामान्य आकार के विपरीत, प्लेसहोल्डर अपनी स्थिति, आकार, फॉर्मेटिंग और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में ले सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [IShape::get_Placeholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_placeholder/) मेथड के माध्यम से उजागर करता है। यह मेथड एक [IPlaceholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iplaceholder/) ऑब्जेक्ट या सामान्य आकार के लिए `nullptr` लौटाता है। प्लेसहोल्डर में क्या रखना है, यह निर्धारित करने के लिए [IPlaceholder::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iplaceholder/get_type/) का उपयोग करें।

आकार इंटरफ़ेस अभी भी महत्वपूर्ण है जब आप प्लेसहोल्डर प्रकार जान लेते हैं:

- खाली टेक्स्ट, चित्र, चार्ट या कंटेंट प्लेसहोल्डर आमतौर पर एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) द्वारा दर्शाया जाता है।
- भरपूर चित्र प्लेसहोल्डर को एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) द्वारा दर्शाया जा सकता है।
- भरपूर चार्ट प्लेसहोल्डर को एक [IChart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है।
- कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। हर प्लेसहोल्डर को एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) माना जाने से बचने के लिए दोनों [IPlaceholder::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iplaceholder/get_type/) और रन‑टाइम आकार इंटरफ़ेस की जांच करें।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iplaceholder/get_type/) प्लेसहोल्डर की भूमिका को बताता है; यह आकार के रन‑टाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा प्रकार जाँचें।
{{% /alert %}}

## **प्लेसहोल्डर उत्तराधिकार को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियाँ और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर परिभाषित करता है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था को परिभाषित करता है और मास्टर से विरासत ले सकता है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर रखती है और अपने लेआउट से विरासत ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/getbaseplaceholder/) को कॉल करें। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार का कोई बेस प्लेसहोल्डर नहीं होता तो यह मेथड `nullptr` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर की सूची देता है और उनके बेस प्लेसहोल्डर रिपोर्ट करता है:

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

एक सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से सभी स्लाइडों पर प्रभाव पड़ सकता है जो अभी भी वह सेटिंग विरासत में लेते हैं। एक स्थानीय सामान्य आकार का कोई बेस प्लेसहोल्डर नहीं होता और केवल उसी निर्देशांकों को occupy करने के कारण वह विरासत शुरू नहीं करता।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। इसका [get_TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/get_textframe/) मेथड उपयोग करने से पहले [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) की जाँच करें।

यह उदाहरण पहले स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) में कास्ट करने से बचाता है। यह कमजोर आकार इंडेक्स पर निर्भर रहने के बजाय उद्देश्य के आधार पर प्लेसहोल्डर की पहचान करता है।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिजाइन‑टाइम निर्देश है जो एक खाली प्लेसहोल्डर में दिखता है, जैसे *Click to add title*। सामान्य स्लाइड की आकार संग्रह के माध्यम से पहुँचने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर कस्टम प्रॉम्प्ट टेक्स्ट सेट करें। लेआउट तक पहुँचने के लिए [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/get_layoutslide/) उपयोग करें और [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_shapes/) पर इटरेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट बदलता है:

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

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसी संपादन एप्लिकेशन में खाली प्लेसहोल्डर के लिए अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर देता है, तो प्रॉम्प्ट अब नहीं दिखता। प्रॉम्प्ट बदलने से लेआउट उपयोग करने वाली स्लाइडों पर मौजूदा टेक्स्ट नहीं बदलता।

## **चित्र प्लेसहोल्डर को अपडेट करें**

दो मामलों को संभालना होता है:

- यदि चित्र प्लेसहोल्डर पहले से भरपूर है और एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) द्वारा दर्शाया गया है, तो [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/get_picture/) और [ISlidesPicture::set_Image](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/set_image/) के माध्यम से छवि बदलें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addpictureframe/) से प्लेसहोल्डर के निर्देशांकों पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर हटाएँ।

अगला उदाहरण दोनों मामलों का समर्थन करता है और प्रस्तुति सहेजता है:

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

खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [IShape::get_Placeholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_placeholder/) केवल‑पढ़ने योग्य है। यह आरक्षित स्थिति रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार विरासत में नहीं लेता। यदि प्लेसहोल्डर संबंध बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides के साथ resulting [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिए देखें [Manage Picture Frames](/slides/hi/cpp/picture-frame/)। ये संचालन चित्र फ्रेम या चित्र फILL से संबंधित हैं, प्लेसहोल्डर मेटाडेटा से नहीं।

## **चार्ट और कंटेंट प्लेसहोल्डर्स के साथ काम करें**

भरा हुआ चार्ट प्लेसहोल्डर एक [IChart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रन‑टाइम इंटरफ़ेस दोनों से ऐसे चार्ट को खोजता है, उसका शीर्षक बदलता है और फ़ाइल सहेजता है:

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

एक सामान्य कंटेंट प्लेसहोल्डर आमतौर पर [PlaceholderType::Object](https://reference.aspose.com/slides/hi/cpp/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों — चार्ट, टेबल, डायग्राम, चित्र और मीडिया — के लिए एक लॉन्चर के रूप में कार्य करता है। एक बार भर जाने के बाद, वास्तविक आकार इंटरफ़ेस की जांच करें कि यह क्या रखता है। विशेष लेआउट भी [PlaceholderType::Chart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/hi/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/hi/cpp/aspose.slides/placeholdertype/), या [PlaceholderType::Diagram](https://reference.aspose.com/slides/hi/cpp/aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides खाली [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) प्लेसहोल्डर को केवल [IPlaceholder::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iplaceholder/get_type/) बदल कर [IChart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/) में नहीं बदलता; प्रकार केवल‑पढ़ने योग्य है। खाली चार्ट या कंटेंट एरिया को प्रोग्रामेटिक रूप से भरने के लिए, प्लेसहोल्डर के निर्देशांकों पर आवश्यक ऑब्जेक्ट जोड़ें और फिर खाली प्लेसहोल्डर हटाएँ। निम्न उदाहरण चार्ट के लिए यही करता है:

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

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को occupy करता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। उसके श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलने के लिए [chart management articles](/slides/hi/cpp/powerpoint-charts/) देखें।

## **पूर्ण उदाहरण: टेक्स्ट या इमेज कंटेंट अपडेट करें**

निम्न एंड‑टू‑एंड उदाहरण एक टेम्प्लेट खोलता है, पहले स्लाइड में शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकार जांचता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण जान‑बूझकर आकार इंडेक्स मानने या हर प्लेसहोल्डर को एक ही इंटरफ़ेस में कास्ट करने से बचता है।

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

**एक बेस प्लेसहोल्डर क्या है?**

एक बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर स्थित है, जिससे दूसरा प्लेसहोल्डर विरासत लेता है। इसे प्राप्त करने के लिए [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/getbaseplaceholder/) का उपयोग करें। एक सामान्य स्थानीय आकार `nullptr` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासतित फॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत होती है। पूरे प्रेजेंटेशन में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइडों पर इटरेट करें और प्रत्येक शीर्षक प्लेसहोल्डर अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर प्लेसहोल्डर्स को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप में हेडर और फुटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/cpp/presentation-header-and-footer/)।