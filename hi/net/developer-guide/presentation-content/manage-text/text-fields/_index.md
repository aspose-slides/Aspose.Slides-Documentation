---
title: PowerPoint प्रस्तुतियों में .NET में टेक्स्ट फ़ील्ड प्रबंधित करें
linktitle: टेक्स्ट फ़ील्ड
type: docs
weight: 52
url: /hi/net/text-fields/
keywords:
- टेक्स्ट फ़ील्ड
- स्वचालित टेक्स्ट
- स्लाइड नंबर
- तारीख और समय
- हेडर
- फ़ूटर
- टेक्स्ट भाग
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड बनाएं, जाँचें, संशोधित करें और हटाएँ। फ़ॉर्मेटिंग बनाए रखें और सहेजे गए PPTX और PPT फ़ाइलों की पुष्टि करें।"
---
## **अवलोकन**

एक टेक्स्ट पैराग्राफ भागों (portions) से बना होता है। एक सामान्य [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) में शाब्दिक पाठ होता है; एक फ़ील्ड भाग में एक अतिरिक्त [IField](https://reference.aspose.com/slides/hi/net/aspose.slides/ifield/) भी होता है जिसका प्रकार स्वचालित रूप से अपडेट होने वाला मान पहचानता है, जैसे स्लाइड नंबर या तारीख। दो भाग समान अक्षर दर्शा सकते हैं जबकि केवल एक में फ़ील्ड हो।

उन्हें पहचानने के लिए [IPortion.Field](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/field/) का उपयोग करें: यह सामान्य पाठ के लिए `null` होता है। [IPortion.AddField](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/addfield/) मौजूदा भाग को फ़ील्ड में परिवर्तित करता है। लेबल और उसकी डायनैमिक वैल्यू को अलग-अलग भागों में रखें ताकि वैल्यू को बदलने से लेबल भी बदल न जाये।

यह गाइड पाठ के भीतर फ़ील्ड, उनके फ़ॉर्मेटिंग, और उन्हें PPTX एवं PPT में सहेजने को कवर करता है। टेक्स्ट फ्रेम्स और पैराग्राफ के लिए देखें [Manage Text](/slides/hi/net/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाएं**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल होता है जिसके बाद स्वचालित रूप से अपडेट होने वाला नंबर जुड़ा होता है। यह फ़ील्ड जोड़ने से पहले नंबर का आकार, वजन और रंग सेट करता है, फिर सहेजे गए प्रेजेंटेशन को पुनः खोलता है और फ़ील्ड प्रकार, टेक्स्ट और फ़ॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

नया प्रेजेंटेशन स्लाइड नंबर 1 से शुरू होता है, इसलिए टेक्स्ट `Slide 1` है, और दोनों जाँचें `True` प्रिंट करती हैं। पुनः खोलने के बाद भी नंबर फ़ील्ड बना रहता है; यह शाब्दिक `1` नहीं है। सत्यापन में प्रयुक्त कास्ट और इंडेक्स उस शेप और भागों को संदर्भित करते हैं जो इस उदाहरण द्वारा बनाए गए हैं।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifieldtype/) को लागू करता है और निम्न पूर्वपरिभाषित मान प्रदान करता है। उपयुक्त मान को [AddField](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/addfield/) को पास करें।

| मान | उद्देश्य |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/slidenumber/) | वर्तमान स्लाइड नंबर। |
| [DateTime](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/datetime/) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फॉर्मेट में दिनांक/समय। |
| [DateTime1](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/datetime1/)-[DateTime9](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/datetime9/) | पूर्वपरिभाषित तिथि या संयुक्त तिथि/समय फॉर्मेट। |
| [DateTime10](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/datetime10/)-[DateTime13](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/datetime13/) | पूर्वपरिभाषित समय फॉर्मेट, जिसमें सेकंड और 12‑घंटे घड़ी विकल्प शामिल हैं। |
| [Header](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/header/) | एक हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फॉर्मेट सीमाओं को देखें। |
| [Footer](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/footer/) | एक फ़ूटर फ़ील्ड। |

उदाहरण के तौर पर, [DateTime3](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/datetime3/) एक दिन, पूर्ण महीने का नाम, और अंग्रेज़ी में वर्ष दर्शाता है। ये पूर्वपरिभाषित फ़ील्ड फॉर्मेट हैं, मनमाने .NET तिथि‑फ़ॉर्मेट स्ट्रिंग नहीं। भाग का [LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) और प्रेजेंटेशन प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएं**

[AddField](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/addfield/) का स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड आइडेंटिफायर स्वीकार करता है। इसका उपयोग तब करें जब आपको किसी अन्य एप्लिकेशन द्वारा प्रदान किया गया आइडेंटिफ़ायर संरक्षित रखना हो जिसका कोई पूर्वपरिभाषित मान न हो। आप इस आइडेंटिफ़ायर से एक [FieldType](https://reference.aspose.com/slides/hi/net/aspose.slides/fieldtype/fieldtype/) भी बना सकते हैं। [IFieldType.InternalString](https://reference.aspose.com/slides/hi/net/aspose.slides/ifieldtype/internalstring/) इस आइडेंटिफ़ायर को निरीक्षण के लिए उजागर करता है।

यह उदाहरण एक एप्लिकेशन‑विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। यह आइडेंटिफ़ायर कोई गणना रजिस्टर नहीं करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट आईडी उत्पन्न नहीं करता। वह एप्लिकेशन जो इस आइडेंटिफ़ायर को समझता है, उसे उसका अर्थ प्रदान करना होगा और उसका मान अपडेट करना होगा।

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

इस PPTX राउंड‑ट्रिप के बाद, प्रकार `custom-report-id` रहेगा और टेक्स्ट `Report-042` होगा। `yyyy-MM-dd` जैसा स्ट्रिंग पास करने से एक फ़ील्ड प्रकार नामित होगा; यह कस्टम तिथि फ़ॉर्मेट कॉन्फ़िगर नहीं करेगा। मनमाने फ़ॉर्मेट में स्थिर तिथि के लिए सामान्य टेक्स्ट का प्रयोग करें।

## **तारीख/समय फ़ील्ड को निरीक्षण, संशोधित और हटाना**

[IField.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ifield/type/) के माध्यम से मौजूदा फ़ील्ड को पढ़ें और बदलें। फ़ील्ड के प्रकार तक पहुंचने से पहले यह सुनिश्चित करें कि फ़ील्ड मौजूद है। स्वचालित अपडेट रोकने के लिए [IPortion.RemoveField](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/removefield/) को कॉल करें। यह फ़ील्ड संबद्धता को हटाते हुए भाग और उसका वर्तमान टेक्स्ट बरकरार रखता है। यदि आपको कोई निश्चित मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

तारीख/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation.CurrentDateTime](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/currentdatetime/)। नीचे का उदाहरण फ़ील्ड को सामान्य टेक्स्ट में बदलते समय एक स्पष्ट अनुमोदन तिथि का उपयोग करता है।

[sample.pptx](sample.pptx) डाउनलोड करें और कार्यस्थल डायरेक्टरी में रखें। इसमें दो नामित टेक्स्ट शेप्स `UpdatedAt` और `ApprovedDate` हैं, प्रत्येक में एक तारीख/समय फ़ील्ड है, साथ ही सामान्य टेक्स्ट लेबल। नीचे का उदाहरण सामान्य स्लाइड्स में शीर्ष‑स्तर टेक्स्ट शेप्स को पार करता है। यह तारीख/समय फ़ील्ड को लंबी‑तारीख फ़ॉर्मेट में बदलता है और इटैलिक करता है, जबकि अन्य फ़ॉर्मेटिंग बनाए रखता है। केवल `ApprovedDate` के फ़ील्ड स्थायी टेक्स्ट बनाते हैं।

बिल्ट‑इन आंतरिक आइडेंटिफ़ायर `datetime` और `datetime1` से `datetime13` तक इस नमूने में पहचाने जाते हैं। ग्रुप्स, टेबल्स, नोट्स, लेआउट्स और मास्टर्स को अपने स्वयं के टेक्स्ट कंटेनर्स का ट्रैवर्सल करना पड़ता है और वह इस उदाहरण के दायरे से बाहर है।

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

पुनः खोलने के बाद, `UpdatedAt` का प्रकार `datetime3` है और यह डायनेमिक बना रहता है। `ApprovedDate` में कोई फ़ील्ड नहीं है और इसमें `05 April 2030` है। दोनों तारीख भाग इटैलिक हैं, और उनका मूल फ़ॉन्ट साइज, बोल्ड सेटिंग तथा रंग अपरिवर्तित रहता है। सामान्य टेक्स्ट लेबल अपरिवर्तित रहते हैं। सत्यापन प्रदान किए गए नमूने में दो ज्ञात शेप्स के पहले भाग को पढ़ता है।

## **पाठ फ़ॉर्मेटिंग बनाए रखें**

फ़ील्ड जोड़ते समय, उसका प्रकार बदलते समय या हटाते समय मौजूदा भाग के साथ काम करें। ये ऑपरेशन उस भाग की फ़ॉर्मेटिंग को बरकरार रखते हैं। केवल आवश्यक प्रॉपर्टीज़ बदलने के लिए [IPortion.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/portionformat/) का उपयोग करें, जैसा कि रंग या इटैलिक के उदाहरण में किया गया है।

एक फ़ील्ड को अपडेट करने के लिये पूरे टेक्स्ट फ्रेम को पुनः निर्मित करने से बचें: ऐसा करने से मूल भाग सीमाएँ और उनकी व्यक्तिगत फ़ॉर्मेटिंग खो सकती है। पैराग्राफ, लेआउट या थीम से विरासत में मिली फ़ॉर्मेटिंग को स्पष्ट रूप से सेट की गई फ़ॉर्मेटिंग से अलग पहचानें। विस्तृत फ़ॉर्मेटिंग विकल्पों के लिये देखें [Text Formatting](/slides/hi/net/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ूटर प्लेसहोल्डर**

फ़ील्ड टेक्स्ट भाग का हिस्सा होता है। प्लेसहोल्डर वह शेप होता है जिसका प्रेजेंटेशन में कोई भूमिका होती है, जैसे फ़ूटर या स्लाइड नंबर। सामान्य टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह शेप प्लेसहोल्डर नहीं बन जाता।

हेडर/फ़ूटर मैनेजर्स स्लाइड्स, लेआउट्स और मास्टर्स पर प्लेसहोल्डर टेक्स्ट और दृश्यता को नियंत्रित करते हैं, जिसमें निर्भर स्लाइड्स में प्रसारण शामिल है। एक कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड उपयोगी हो सकता है भले ही आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग न कर रहे हों। इसके विपरीत, प्लेसहोल्डर दृश्यता बदलने से अनरिलेटेड टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वपरिभाषित हेडर और फ़ूटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते और न ही उनका कंटेंट सप्लाई करते हैं। विशेष रूप से, एक सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट्स पेज और हैंडआउट्स से संबंधित होते हैं। यह न मानें कि कोई हेडर या फ़ूटर फ़ील्ड किसी भी शेप में स्वतः प्लेसहोल्डर मैनेजर द्वारा कॉन्फ़िगर किया गया टेक्स्ट ले लेगा। इस कार्यप्रवाह के लिये देखें [Presentation Headers and Footers](/slides/hi/net/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसके परिणामस्वरूप टेक्स्ट दोनों को जाँचें। एक आइडेंटिफ़ायर को संरक्षित करना यह सिद्ध नहीं करता कि एप्लिकेशन उसके मान की गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | फ़ील्ड टेक्स्ट के साथ आंतरिक फ़ील्ड आइडेंटिफ़ायर संग्रहीत करता है। राउंड‑ट्रिप जाँच में, ऊपर उपयोग किए गए पूर्वपरिभाषित प्रकार और कस्टम आइडेंटिफ़ायर दोनों सहेजने और पुनः खोलने के बाद जीवित रहे। अज्ञात कस्टम प्रकार ने अपना फॉलबैक टेक्स्ट बरकरार रखा; उसने स्वचालित गणना लॉजिक नहीं प्राप्त किया। अन्य एप्लिकेशन असमर्थित आइडेंटिफ़ायर को अलग तरह से संभाल सकते हैं। |
| PPT | लेगसी फ़ील्ड रिप्रेजेंटेशन का उपयोग करता है और संगतता अधिक सीमित है। राउंड‑ट्रिप जाँच में, स्लाइड‑नंबर और पूर्वपरिभाषित तारीख/समय फ़ील्ड सहेजने और पुनः खोलने के बाद जीवित रहे। एक सामान्य स्लाइड टेक्स्ट बॉक्स में कस्टम फ़ील्ड अपने आइडेंटिफ़ायर के साथ पुनः खुला लेकिन उसका टेक्स्ट `*` था; उसी संदर्भ में हेडर फ़ील्ड भी `*` उत्पन्न करता था। कस्टम फ़ील्ड या असमर्थित फ़ील्ड कॉन्टेक्स्ट से दृश्यमान टेक्स्ट बनाये रखने पर भरोसा न करें। |

पोर्टेबल, स्थिर आउटपुट के लिये, असमर्थित फ़ील्ड को सामान्य टेक्स्ट में बदलें और सहेजने से पहले वह मूल्य स्पष्ट रूप से असाइन करें जिसे आप चाहते हैं। यह चुना हुआ टेक्स्ट संरक्षित करता है लेकिन जानबूझकर स्वचालित अपडेट रोकता है। आपके वर्कफ़्लो में यदि लक्ष्य एप्लिकेशन स्वयं फ़ील्ड पुनः‑गणना करता है तो उसे भी परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि दिखाया गया नंबर या तारीख फ़ील्ड है?**

[IPortion.Field](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/field/) देखें। गैर‑शून्य मान एक फ़ील्ड की पहचान करता है; केवल दिखाए गए टेक्स्ट से यह नहीं पता चलता।

**क्या फ़ील्ड हटाने से उसका टेक्स्ट या फ़ॉर्मेटिंग हटता है?**

नहीं। [RemoveField](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/removefield/) मौजूदा भाग को सामान्य टेक्स्ट में बदल देता है। यदि आपको कोई निश्चित फ़्रोज़न तिथि या फॉलबैक वैल्यू चाहिए तो फ़ील्ड हटाने के बाद वह मान असाइन करें।

**क्या आंतरिक स्ट्रिंग नई तारीख फ़ॉर्मेट या फ़ॉर्मूला निर्धारित कर सकती है?**

नहीं। यह केवल एक फ़ील्ड प्रकार की पहचान करती है। अज्ञात आइडेंटिफ़ायर कोई इवैल्युएटर या .NET तारीख‑फ़ॉर्मेट पैटर्न प्रदान नहीं करता। समर्थित पूर्वपरिभाषित प्रकार का प्रयोग करें या मूल्य को स्वयं सामान्य टेक्स्ट के रूप में फॉर्मेट करें।

**सहेजने के बाद प्रेज़ेंटेशन को फिर से क्यों जाँचें?**

फ़ील्ड आइडेंटिफ़ायर, गणना किया गया टेक्स्ट, और फ़ॉर्मेटिंग अलग‑अलग चीजें हैं जिन्हें सत्यापित करने की आवश्यकता होती है। फ़ॉर्मेट बदलने से दृश्यमान परिणाम बदल सकता है भले ही फ़ील्ड आइडेंटिफ़ायर अभी भी मौजूद हो।