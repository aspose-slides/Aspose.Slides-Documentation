---
title: Python में PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड प्रबंधित करें
linktitle: टेक्स्ट फ़ील्ड
type: docs
weight: 52
url: /hi/python-net/text-fields/
keywords:
- टेक्स्ट फ़ील्ड
- स्वचालित टेक्स्ट
- स्लाइड नंबर
- तिथि और समय
- हेडर
- फुटर
- टेक्स्ट भाग
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड बनाएं, निरीक्षण करें, संशोधित करें और हटाएं। फ़ॉर्मेटिंग को बनाए रखें और सहेजे गए PPTX और PPT फ़ाइलों की पुष्टि करें।"
---
## **परिचय**

एक टेक्स्ट पैराग्राफ में भाग होते हैं। एक सामान्य [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) में शाब्दिक टेक्स्ट होता है; एक फ़ील्ड भाग में additionally एक [Field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/field/) होता है जिसका प्रकार एक स्वतः अद्यतन मान पहचानता है, जैसे स्लाइड नंबर या तिथि। दो भाग समान अक्षर दिखा सकते हैं जबकि केवल एक में फ़ील्ड होता है।

उनको अलग करने के लिए [Portion.field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/field/) का उपयोग करें: यह सामान्य टेक्स्ट के लिए `None` होता है। [Portion.add_field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/add_field/) मौजूदा भाग को फ़ील्ड में बदलता है। लेबल और उसके गतिशील मान को अलग-अलग भागों में रखें ताकि मान को बदलने से लेबल भी बदल न जाए।

यह गाइड टेक्स्ट के भीतर फ़ील्ड, उनके फ़ॉर्मेटिंग, और उन्हें PPTX तथा PPT में सहेजने को कवर करता है। टेक्स्ट फ्रेम और पैराग्राफ़ के लिए, देखें [Manage Text](/slides/hi/python-net/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाएं**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल के बाद एक स्वतः अद्यतन संख्या होती है। यह फ़ील्ड जोड़ने से पहले संख्या का आकार, वजन और रंग सेट करता है, फिर सहेजे गए प्रेजेंटेशन को फिर से खोलता है और फ़ील्ड प्रकार, टेक्स्ट और फ़ॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

नया प्रेजेंटेशन स्लाइड नंबर 1 से शुरू होता है, इसलिए टेक्स्ट `Slide 1` है, और दोनों जाँचें `True` प्रिंट करती हैं। पुनः खोलने के बाद भी संख्या फ़ील्ड बनी रहती है; यह शाब्दिक `1` नहीं है। सत्यापन में सूचकांक उस आकार (shape) और भागों (portions) को दर्शाते हैं जो इस उदाहरण द्वारा बनाए गए थे।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/) निम्नलिखित पूर्वपरिभाषित मान प्रदान करता है। उपयुक्त मान को [add_field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/add_field/) में पास करें।

| मान | उद्देश्य |
|---|---|
| [slide_number](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/slide_number/) | वर्तमान स्लाइड नंबर। |
| [date_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/date_time/) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फ़ॉर्मेट में तिथि/समय। |
| [date_time1](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/date_time9/) | पूर्वपरिभाषित तिथि या संयुक्त तिथि/समय फ़ॉर्मेट। |
| [date_time10](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/date_time13/) | पूर्वपरिभाषित समय फ़ॉर्मेट, जिसमें सेकंड्स और 12-घंटे वाली घड़ी के विकल्प शामिल हैं। |
| [header](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/header/) | एक हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फ़ॉर्मेट सीमाएँ देखें। |
| [footer](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/footer/) | एक फुटर फ़ील्ड। |

उदाहरण के लिए, [date_time3](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/date_time3/) इंग्लिश में दिन, पूर्ण महीना नाम, और वर्ष को दर्शाता है। ये पूर्वपरिभाषित फ़ील्ड फ़ॉर्मेट हैं, 任意 Python तिथि-फ़ॉर्मेट स्ट्रिंग नहीं। भाग का [language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/language_id/) और प्रेजेंटेशन को प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएं**

[add_field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/add_field/) की स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड पहचानकर्ता को स्वीकार करती है। इसे तब उपयोग करें जब आप कोई पहचानकर्ता रख रहे हों जो अन्य एप्लिकेशन द्वारा दिया गया हो लेकिन जिसका कोई पूर्वपरिभाषित मान न हो। आप उस पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/__init__/) भी बना सकते हैं। [FieldType.internal_string](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fieldtype/internal_string/) उस पहचानकर्ता को निरीक्षण के लिए उजागर करता है।

यह उदाहरण एक एप्लिकेशन-विशिष्ट `custom-report-id` फ़ील्ड को फ़ॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। पहचानकर्ता कोई गणना रजिस्टर नहीं करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट ID नहीं बनाता। जो एप्लिकेशन इस पहचानकर्ता को समझता है, उसे उसका अर्थ प्रदान करना और उसका मान अद्यतन करना होगा।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

इस PPTX राउंड ट्रिप के बाद, प्रकार `custom-report-id` है और टेक्स्ट `Report-042` है। `%Y-%m-%d` जैसी स्ट्रिंग पास करने से एक फ़ील्ड प्रकार का नाम होगा; यह एक कस्टम तिथि फ़ॉर्मेट नहीं बनाता। 任意 फ़ॉर्मेट में निश्चित तिथि के लिए, सामान्य टेक्स्ट का उपयोग करें।

## **तिथि/समय फ़ील्ड का निरीक्षण, संशोधन और हटाना**

[Field.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/field/type/) के माध्यम से मौजूदा फ़ील्ड पढ़ें और बदलें। प्रकार तक पहुँचने से पहले सुनिश्चित करें कि फ़ील्ड मौजूद है। स्वचालित अद्यतन रोकने के लिए, [Portion.remove_field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/remove_field/) कॉल करें। यह फ़ील्ड संबंध को हटाते ہوئے भाग और उसके वर्तमान टेक्स्ट को रखता है। यदि आपको कोई विशिष्ट स्थिर मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

तिथि/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation.current_date_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/current_date_time/)। नीचे दिया गया उदाहरण फ़ील्ड को सामान्य टेक्स्ट में बदलते समय एक स्पष्ट अनुमोदन तिथि का उपयोग करता है। अंग्रेज़ी महीने-नाम का ट्यूपल प्रणाली के लोकैल से स्वतंत्र स्थिर तिथि रखता है।

[sample.pptx](sample.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसमें दो नामित टेक्स्ट शैप्स हैं, `UpdatedAt` और `ApprovedDate`, प्रत्येक में तिथि/समय फ़ील्ड है, साथ ही सामान्य टेक्स्ट लेबल भी। निम्नलिखित उदाहरण नियमित स्लाइड्स पर टॉप-लेवल टेक्स्ट शैप्स को पार करता है। यह तिथि/समय फ़ील्ड को लंबी तिथि फ़ॉर्मेट में बदलता है और उन्हें इटैलिक बनाता है, जबकि अन्य फ़ॉर्मेटिंग को बरकरार रखता है। केवल `ApprovedDate` के फ़ील्ड स्थिर टेक्स्ट बनते हैं।

नमूना अंतर्निहित आंतरिक पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक पहचानता है। समूह, टेबल, नोट्स, लेआउट, और मास्टर को उनके स्वयं के टेक्स्ट कंटेनर की ट्रैवर्सल की आवश्यकता होती है और यह इस उदाहरण के दायरे से बाहर हैं।

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

पुनः खोलने के बाद, `UpdatedAt` का प्रकार `datetime3` है और यह गतिशील रहता है। `ApprovedDate` में कोई फ़ील्ड नहीं है और इसमें `05 April 2030` है। दोनों तिथि भाग इटैलिक हैं, और उनका मूल फ़ॉन्ट आकार, बोल्ड सेटिंग, और रंग बना रहता है। सामान्य टेक्स्ट लेबल अपरिवर्तित हैं। सत्यापन प्रदान किए गए नमूने में दो ज्ञात शैप्स के पहले भाग को पढ़ता है।

## **टेक्स्ट फ़ॉर्मेटिंग बरकरार रखें**

फ़ील्ड जोड़ते समय, उसका प्रकार बदलते समय, या उसे हटाते समय मौजूदा भाग के साथ काम करें। ये ऑपरेशन्स भाग की फ़ॉर्मेटिंग को बरकरार रखती हैं। केवल आवश्यक गुण बदलने के लिए [Portion.portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/portion_format/) का उपयोग करें, जैसा कि उदाहरण रंग या इटैलिक के लिए करते हैं।

एक फ़ील्ड को अपडेट करने के लिए पूरे टेक्स्ट फ्रेम को पुन: निर्माण करने से बचें: ऐसा करने से मूल भाग सीमाओं और उनके व्यक्तिगत फ़ॉर्मेटिंग खो सकते हैं। साथ ही स्पष्ट रूप से सेट की गई फ़ॉर्मेटिंग को पैराग्राफ, लेआउट, या थीम से विरासत में मिली फ़ॉर्मेटिंग से अलग करें। व्यापक फ़ॉर्मेटिंग विकल्पों के लिए देखें [Text Formatting](/slides/hi/python-net/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ुटर प्लेसहोल्डर्स**

फ़ील्ड टेक्स्ट भाग का हिस्सा है। प्लेसहोल्डर वह शैप है जिसका प्रेजेंटेशन में भूमिका होती है, जैसे फ़ुटर या स्लाइड नंबर। एक सामान्य टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह शैप प्लेसहोल्डर नहीं बनता।

हेडर/फ़ुटर मैनेजर्स स्लाइड्स, लेआउट्स और मास्टर्स पर प्लेसहोल्डर टेक्स्ट और दृश्यता को नियंत्रित करते हैं, जिसमें निर्भर स्लाइड्स तक प्रसारण शामिल है। एक कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड तब भी उपयोगी हो सकता है जब आप स्लाइड-नंबर प्लेसहोल्डर का उपयोग नहीं कर रहे हों। इसके विपरीत, प्लेसहोल्डर दृश्यता बदलने से असंबंधित टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वपरिभाषित हेडर और फ़ुटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते या उनका कंटेंट नहीं प्रदान करते। विशेष रूप से, एक सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट्स पेज और हैंडआउट्स में होते हैं। यह न मानें कि किसी 任意 शैप में हेडर या फ़ुटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर मैनेजर द्वारा कॉन्फ़िगर किया गया टेक्स्ट प्राप्त करेगा। उस कार्यप्रवाह के लिए, देखें [Presentation Headers and Footers](/slides/hi/python-net/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसके परिणामस्वरूप टेक्स्ट दोनों की जाँच करें। पहचानकर्ता को संरक्षित करने से यह सिद्ध नहीं होता कि एप्लिकेशन उसका मान गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | फ़ील्ड टेक्स्ट के साथ आंतरिक फ़ील्ड पहचानकर्ता संग्रहीत करता है। राउंड‑ट्रिप जाँच में, उपरोक्त पूर्वपरिभाषित प्रकार और कस्टम पहचानकर्ता सहेजने और पुनः खोलने के बाद भी मौजूद रहे। अज्ञात कस्टम प्रकार ने अपना फ़ॉलबैक टेक्स्ट बरकरार रखा; इसे स्वचालित गणना तर्क नहीं मिला। अन्य एप्लिकेशन असमर्थित पहचानकर्ताओं को अलग तरह से संभाल सकते हैं। |
| PPT | लेगेसी फ़ील्ड प्रतिनिधित्व का उपयोग करता है और अधिक सीमित संगतता रखता है। राउंड‑ट्रिप जाँच में, स्लाइड‑नंबर और पूर्वपरिभाषित तिथि/समय फ़ील्ड सहेजने और पुनः खोलने के बाद भी बरकरार रहे। एक सामान्य स्लाइड टेक्स्ट बॉक्स में कस्टम फ़ील्ड अपने पहचानकर्ता के साथ पुनः खोला गया, लेकिन उसका टेक्स्ट `*` था; उसी संदर्भ में एक हेडर फ़ील्ड भी `*` उत्पन्न करता था। कस्टम फ़ील्ड या असमर्थित फ़ील्ड संदर्भों पर भरोसा न करें कि उनका दृश्य टेक्स्ट बना रहेगा। |

पोर्टेबल, स्थिर आउटपुट के लिए, असमर्थित फ़ील्ड को सामान्य टेक्स्ट में बदलें और सहेजने से पहले स्पष्ट रूप से वांछित मान असाइन करें। यह चुने हुए टेक्स्ट को बरकरार रखता है लेकिन स्वचालित अद्यतनों को जानबूझकर रोकता है। जब लक्ष्य एप्लिकेशन का अपना फ़ील्ड पुन: गणना आपके कार्यप्रवाह का हिस्सा हो, तो उसे भी टेस्ट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि प्रदर्शित संख्या या तिथि फ़ील्ड है या नहीं?**

[Portion.field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/field/) देखें। `None` के अलावा कोई भी मान फ़ील्ड को पहचाता है; केवल प्रदर्शित टेक्स्ट से आप नहीं बता सकते।

**क्या फ़ील्ड हटाने से उसका टेक्स्ट या फ़ॉर्मेटिंग हट जाता है?**

नहीं। [remove_field](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/remove_field/) मौजूदा भाग को सामान्य टेक्स्ट में बदल देता है। यदि आपको विशिष्ट जमी हुई तिथि या फ़ॉलबैक मान चाहिए तो बाद में स्पष्ट मान असाइन करें।

**क्या आंतरिक स्ट्रिंग नया तिथि फ़ॉर्मेट या फ़ॉर्मूला परिभाषित कर सकती है?**

नहीं। यह फ़ील्ड प्रकार को पहचानता है। अज्ञात पहचानकर्ता कोई इवैल्युएटर या Python तिथि-फ़ॉर्मेट पैटर्न नहीं देता। समर्थित पूर्वपरिभाषित प्रकार का उपयोग करें या मान को स्वयं सामान्य टेक्स्ट के रूप में फ़ॉर्मेट करें।

**सहेजने के बाद प्रस्तुति को फिर से क्यों जाँचें?**

फ़ील्ड पहचानकर्ता, गणना किया गया टेक्स्ट, और फ़ॉर्मेटिंग अलग-अलग चीजें हैं जिन्हें सत्यापित करना आवश्यक है। फ़ॉर्मेट परिवर्तन दृश्यमान परिणाम को बदल सकता है भले ही फ़ील्ड पहचानकर्ता मौजूद हो।