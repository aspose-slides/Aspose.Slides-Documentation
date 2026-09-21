---
title: C++ में PowerPoint प्रस्तुतियों में पाठ फ़ील्ड प्रबंधित करें
linktitle: पाठ फ़ील्ड
type: docs
weight: 52
url: /hi/cpp/text-fields/
keywords:
- पाठ फ़ील्ड
- स्वचालित पाठ
- स्लाइड संख्या
- तारीख और समय
- हैडर
- फुटर
- पाठ भाग
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में पाठ फ़ील्ड बनाएं, जांचें, संशोधित करें और हटाएं। स्वरूपण को संरक्षित रखें और सहेजे गए PPTX और PPT फ़ाइलों की जाँच करें।"
---
## **अवलोकन**

एक पाठ अनुच्छेद भागों (portions) से बना होता है। एक सामान्य [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) में शाब्दिक पाठ होता है; एक फ़ील्ड भाग में additionally एक [IField](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifield/) होता है जिसका प्रकार स्वचालित रूप से अपडेट होने वाले मान को दर्शाता है, जैसे स्लाइड संख्या या तिथि। दो भाग समान अक्षरों को प्रदर्शित कर सकते हैं जबकि केवल एक में फ़ील्ड होता है।

[IPortion::get_Field](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_field/) का उपयोग करके आप उन्हें अलग कर सकते हैं: यह सामान्य पाठ के लिए `nullptr` लौटाता है। [IPortion::AddField](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/addfield/) मौजूदा भाग को फ़ील्ड में बदल देता है। लेबल और उसका गतिशील मान अलग-अलग भागों में रखें ताकि मान को बदलने पर लेबल भी न बदले।

यह गाइड फ़ील्ड्स को पाठ में, उनके स्वरूपण और PPTX तथा PPT में सहेजने के बारे में बताता है। पाठ फ्रेम और अनुच्छेदों के लिए, देखें [Manage Text](/slides/hi/cpp/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाएं**

निम्न उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल के बाद स्वचालित रूप से अपडेट होने वाली संख्या आती है। यह संख्या का आकार, वजन और रंग निर्धारित करता है, फिर फ़ील्ड जोड़ता है, उसके बाद सहेजे गए प्रेज़ेंटेशन को फिर से खोलकर फ़ील्ड प्रकार, पाठ और स्वरूपण की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

नया प्रेज़ेंटेशन स्लाइड संख्या 1 से शुरू होता है, इसलिए प्रत्याशित पाठ `Slide 1` है, और दोनों जाँचें `True` प्रिंट करनी चाहिए। संख्या फिर से खोलने के बाद भी फ़ील्ड बनी रहती है; यह शाब्दिक `1` नहीं है। सत्यापन में कास्ट और इंडेक्स उस आकार (shape) और भागों (portions) को संदर्भित करते हैं जो इस उदाहरण द्वारा बनाए गए हैं।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifieldtype/) को लागू करता है और निम्न पूर्वनिर्धारित मान प्रदान करता है। उपयुक्त मान को [AddField](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/addfield/) को पास करें।

| Accessor | उद्देश्य |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_slidenumber/) | वर्तमान स्लाइड संख्या। |
| [get_DateTime](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_datetime/) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट स्वरूप में तिथि/समय। |
| [get_DateTime1](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_datetime9/) | पूर्वनिर्धारित तिथि या सम्मिलित तिथि/समय स्वरूप। |
| [get_DateTime10](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_datetime13/) | पूर्वनिर्धारित समय स्वरूप, जिसमें सेकेंड और 12‑घंटे घड़ी के विकल्प शामिल हैं। |
| [get_Header](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_header/) | हेडर फ़ील्ड; नीचे दिए गये प्लेसहोल्डर और स्वरूप सीमाओं को देखें। |
| [get_Footer](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_footer/) | फुटर फ़ील्ड। |

उदाहरण के लिए, [get_DateTime3](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/get_datetime3/) एक दिन, पूर्ण माह का नाम और वर्ष को अंग्रेज़ी में देता है। ये पूर्वनिर्धारित फ़ील्ड स्वरूप हैं, मनचाहे तिथि‑स्वरूप स्ट्रिंग नहीं। भाग की भाषा, जिसे आप [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_languageid/) से सेट कर सकते हैं, और प्रस्तुतिकरण को प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकता है।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएं**

[AddField](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/addfield/) का स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड पहचानकर्ता (identifier) स्वीकार करता है। इसे तब उपयोग करें जब आप किसी अन्य एप्लिकेशन द्वारा प्रदान किए गए पहचानकर्ता को संरक्षित रखना चाहते हैं जिसका कोई पूर्वनिर्धारित मान नहीं है। आप पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fieldtype/fieldtype/) भी बना सकते हैं। [IFieldType::get_InternalString](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifieldtype/get_internalstring/) उस पहचानकर्ता को निरीक्षण के लिए उजागर करता है।

यह उदाहरण एप्लिकेशन‑विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक पाठ `Report-042` के साथ संग्रहीत करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। पहचानकर्ता कोई गणना पंजीकृत नहीं करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट IDs उत्पन्न नहीं करता। वह एप्लिकेशन जो इस पहचानकर्ता को समझता है, उसे इसका अर्थ प्रदान करना और मान अपडेट करना होगा।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

इस PPTX राउंड‑ट्रिप के बाद, अपेक्षित प्रकार `custom-report-id` और अपेक्षित पाठ `Report-042` होगा। `yyyy-MM-dd` जैसी स्ट्रिंग पास करने से एक फ़ील्ड प्रकार का नाम बनता है; वह कस्टम तिथि स्वरूप को कॉन्फ़िगर नहीं करता। किसी मनचाहे स्वरूप में निश्चित तिथि के लिए, सामान्य पाठ का उपयोग करें।

## **तिथि/समय फ़ील्ड देखना, संशोधित करना और हटाना**

मौजूदा फ़ील्ड प्रकार को [IField::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifield/get_type/) से पढ़ें और इसे [IField::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifield/set_type/) से बदलें। फ़ील्ड प्रकार तक पहुँचने से पहले यह जाँचें कि फ़ील्ड मौजूद है या नहीं। स्वचालित अपडेट को बंद करने के लिए, [IPortion::RemoveField](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/removefield/) को कॉल करें। यह भाग और उसका वर्तमान पाठ बनाए रखता है जबकि फ़ील्ड संबद्धता को हटा देता है। यदि आपको कोई निश्चित मान चाहिए, तो फ़ील्ड हटाने के बाद वह पाठ असाइन कर दें।

तिथि/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/set_currentdatetime/). नीचे का उदाहरण फ़ील्ड को साधारण पाठ में बदलते समय एक स्पष्ट अनुमोदन तिथि का उपयोग करता है।

[sample.pptx](sample.pptx) को डाउनलोड करके कार्य निर्देशिका में रखें। इसमें दो नामित पाठ आकार (`UpdatedAt` और `ApprovedDate`) हैं, प्रत्येक में तिथि/समय फ़ील्ड और सामान्य पाठ लेबल होते हैं। निम्न उदाहरण नियमित स्लाइडों की शीर्ष‑स्तरीय पाठ आकारों (top‑level text shapes) को पार करता है। यह तिथि/समय फ़ील्ड को लंबी‑तिथि स्वरूप में बदलता है और इटैलिक करता है, जबकि उनका अन्य स्वरूपण बरकरार रहता है। केवल `ApprovedDate` में फ़ील्ड हटाने पर पाठ स्थिर हो जाता है।

निर्मित नमूना अंतर्निहित पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक को पहचानता है। समूह, तालिका, नोट, लेआउट और मास्टर के अपने पाठ कंटेनर होते हैं और इनका ट्रैवर्सल इस उदाहरण के दायरे में नहीं है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

पुनः खोलने पर, `UpdatedAt` का प्रकार `datetime3` होना चाहिए और वह गतिशील बना रहना चाहिए। `ApprovedDate` में कोई फ़ील्ड नहीं होना चाहिए और उसमें `05 April 2030` होना चाहिए। दोनों तिथि भाग इटैलिक हैं, और उनका मूल फ़ॉन्ट आकार, बोल्ड सेटिंग और रंग अपरिवर्तित रहता है। सामान्य पाठ लेबल अपरिवर्तित रहते हैं। सत्यापन द्वारा प्रदान किए गए नमूने में दो ज्ञात आकारों के पहले भाग को पढ़ा जाता है।

## **पाठ स्वरूपण संरक्षित रखें**

फ़ील्ड जोड़ते, प्रकार बदलते या हटाते समय मौजूदा भाग के साथ काम करें। ये ऑपरेशन उस भाग का स्वरूपण बरकरार रखते हैं। केवल आवश्यक गुण बदलने के लिए [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_portionformat/) का उपयोग करें, जैसे उदाहरण में रंग या इटैलिक का परिवर्तन।

सिर्फ एक फ़ील्ड को अपडेट करने के लिए पूरे पाठ फ्रेम को पुनः बनाना टालें: इससे मूल भाग सीमाएँ और उनका व्यक्तिगत स्वरूपण खो सकता है। पैराग्राफ, लेआउट या थीम से विरासत में मिले स्वरूपण और स्पष्ट रूप से सेट किए गए स्वरूपण को अलग‑अलग पहचानें। विस्तृत स्वरूपण विकल्पों के लिए देखें [Text Formatting](/slides/hi/cpp/text-formatting/)।

## **फ़ील्ड और हेडर/फुटर प्लेसहोल्डर**

फ़ील्ड एक पाठ भाग का हिस्सा है। प्लेसहोल्डर एक आकार (shape) है जिसका प्रस्तुति (presentation) में भूमिका होती है, जैसे फुटर या स्लाइड नंबर। सामान्य टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह आकार प्लेसहोल्डर नहीं बनता।

हेडर/फुटर प्रबंधक स्लाइड, लेआउट और मास्टर में प्लेसहोल्डर पाठ और दृश्यता को नियंत्रित करते हैं, साथ ही निर्भर स्लाइडों में प्रसार भी करते हैं। कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड इसलिए उपयोगी हो सकता है भले ही आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग न कर रहे हों। इसके विपरीत, प्लेसहोल्डर दृश्यता बदलने से किसी असंबंधित टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वनिर्धारित हेडर और फुटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते और न ही उनका सामग्री आपूर्ति करते हैं। विशेष रूप से, सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट पेज और हैंडआउट्स से संबंधित होते हैं। यह मान लेना कि किसी मनमाने आकार में हेडर या फुटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर प्रबंधक द्वारा कॉन्फ़िगर किया गया पाठ प्राप्त करेगा, गलत है। इस कार्य‑प्रवाह के लिए देखें [Presentation Headers and Footers](/slides/hi/cpp/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसका उत्पन्न पाठ दोनों को जाँचें। एक पहचानकर्ता को संरक्षित करना यह सिद्ध नहीं करता कि कोई एप्लिकेशन उसकी गणना या प्रदर्शन कर सकता है।

| स्वरूप | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | फ़ील्ड टेक्स्ट के साथ आंतरिक फ़ील्ड पहचानकर्ता संग्रहीत करता है। ऊपर दिए गए उदाहरणों का उपयोग करके सहेजने और पुनः खोलने के बाद पूर्वनिर्धारित प्रकार और कस्टम पहचानकर्ताओं की जाँच करें। अज्ञात कस्टम प्रकार स्वचालित गणना तर्क नहीं प्राप्त करता। अन्य एप्लिकेशन असमर्थित पहचानकर्ताओं को अलग तरीके से संभाल सकते हैं। |
| PPT | पुरानी फ़ील्ड प्रतिनिधित्व का उपयोग करता है और कम संगतता रखता है। स्लाइड‑नंबर और पूर्वनिर्धारित तिथि/समय फ़ील्ड में पुरानी प्रतिनिधित्व होते हैं। असमर्थित कस्टम फ़ील्ड या सामान्य स्लाइड टेक्स्ट बॉक्स में हेडर फ़ील्ड का पाठ `*` हो सकता है। कस्टम फ़ील्ड या असमर्थित फ़ील्ड संदर्भों के दृश्यमान पाठ को बनाए रखने पर भरोसा न करें। |

पोर्टेबल, निश्चित आउटपुट के लिए, असमर्थित फ़ील्ड को सामान्य पाठ में बदलें और सहेजने से पहले वह मान स्पष्ट रूप से असाइन करें। यह इच्छित पाठ को सुरक्षित रखता है लेकिन स्वचालित अपडेट को जानबूझकर रोकता है। जब लक्ष्य एप्लिकेशन का अपना फ़ील्ड पुनर्गणना आपके वर्कफ़्लो का हिस्सा हो, तो उसे भी परीक्षण में शामिल करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि प्रदर्शित संख्या या तिथि फ़ील्ड है या नहीं?**

[IPortion::get_Field](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_field/) को देखें। गैर‑नल मान फ़ील्ड को पहचानता है; केवल प्रदर्शित पाठ से यह पता नहीं चलता।

**क्या फ़ील्ड हटाने से उसका पाठ या स्वरूपण हट जाता है?**

नहीं। [RemoveField](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/removefield/) मौजूदा भाग को सामान्य पाठ में बदल देता है। यदि आपको कोई विशेष जमी हुई तिथि या फ़ॉलबैक मान चाहिए तो फ़ील्ड हटाने के बाद वह मान असाइन करें।

**क्या आंतरिक स्ट्रिंग नई तिथि स्वरूप या सूत्र को परिभाषित कर सकती है?**

नहीं। यह केवल एक फ़ील्ड प्रकार को पहचानती है। अज्ञात पहचानकर्ता कोई मूल्यांकनकर्ता या तिथि‑स्वरूप पैटर्न प्रदान नहीं करता। समर्थित पूर्वनिर्धारित प्रकार का उपयोग करें या स्वयं मूल्य को सामान्य पाठ के रूप में स्वरूपित करें।

**सहेजने के बाद प्रस्तुति को फिर से क्यों जांचें?**

फ़ील्ड पहचानकर्ता, गणना किया गया पाठ और स्वरूपण अलग‑अलग चीजें हैं जिन्हें सत्यापित करना आवश्यक है। स्वरूप रूपांतरण दृश्य परिणाम बदल सकता है, भले ही फ़ील्ड पहचानकर्ता अभी भी मौजूद हो।