---
title: Python के माध्यम से Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड प्रबंधन
linktitle: टेक्स्ट फ़ील्ड्स
type: docs
weight: 52
url: /hi/python-java/text-fields/
keywords:
- टेक्स्ट फ़ील्ड
- स्वचालित टेक्स्ट
- स्लाइड नंबर
- तिथि और समय
- हेडर
- फ़ूटर
- टेक्स्ट भाग
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड बनाएं, निरीक्षण करें, संशोधित करें और हटाएं। फ़ॉर्मेटिंग को संरक्षित रखें और सहेजे गए PPTX और PPT फ़ाइलों को सत्यापित करें।"
---
## **सारांश**

एक पाठ अनुच्छेद भागों से बना होता है। एक सामान्य [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) शाब्दिक पाठ रखता है; एक फ़ील्ड भाग में additionally एक [Field](https://reference.aspose.com/slides/hi/python-java/aspose.slides/field/) शामिल होता है जिसका प्रकार स्वचालित रूप से अपडेट हुए मान की पहचान करता है, जैसे स्लाइड नंबर या तिथि। दो भाग समान अक्षरों को प्रदर्शित कर सकते हैं जबकि केवल एक में फ़ील्ड होता है।

इन्हें अलग करने के लिए [Portion.getField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getField) का उपयोग करें: साधारण पाठ के लिए यह `None` होता है। [Portion.addField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#addField) मौजूदा भाग को फ़ील्ड में बदल देता है। लेबल और उसके गतिशील मान को अलग-अलग भागों में रखें ताकि मान को बदलने से लेबल भी बदल न जाए।

यह गाइड पाठ के भीतर फ़ील्ड, उनके फ़ॉर्मेटिंग, और उन्हें PPTX एवं PPT में सहेजने को कवर करता है। पाठ फ़्रेम और अनुच्छेदों के लिए देखें [Manage Text](/slides/hi/python-java/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाएँ**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल के बाद स्वचालित रूप से अपडेट होने वाला नंबर होता है। यह फ़ील्ड जोड़ने से पहले नंबर का आकार, वजन और रंग सेट करता है, फिर सहेजी गई प्रस्तुति को पुनः खोलता है और फ़ील्ड प्रकार, पाठ और फ़ॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

नई प्रस्तुति स्लाइड नंबर 1 से शुरू होती है, इसलिए पाठ `Slide 1` होता है, और दोनों जाँचें `True` प्रिंट करती हैं। पुनः खोलने के बाद भी नंबर फ़ील्ड बना रहता है; यह शाब्दिक `1` नहीं है। सत्यापन में उपयोग किए गए इंडेक्स उस उदाहरण द्वारा निर्मित शेप और भागों को दर्शाते हैं।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/) पूर्वनिर्धारित मान प्राप्त करने के लिए निम्नलिखित मेथड प्रदान करता है। उपयुक्त मान को [addField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#addField) में पास करें।

| मेथड | उद्देश्य |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getSlideNumber) | वर्तमान स्लाइड नंबर। |
| [getDateTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getDateTime) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फ़ॉर्मेट में तिथि/समय। |
| [getDateTime1](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getDateTime9) | पूर्वनिर्धारित तिथि या सम्मिलित तिथि/समय फ़ॉर्मेट। |
| [getDateTime10](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getDateTime13) | पूर्वनिर्धारित समय फ़ॉर्मेट, सेकंड और 12‑घंटे घड़ी विकल्पों सहित। |
| [getHeader](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getHeader) | एक हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फ़ॉर्मेट सीमाएँ देखें। |
| [getFooter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getFooter) | एक फ़ूटर फ़ील्ड। |

उदाहरण के लिए, [getDateTime3](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getDateTime3) एक दिन, पूर्ण महीने का नाम, और अंग्रेजी में वर्ष दर्शाता है। ये पूर्वनिर्धारित फ़ील्ड फ़ॉर्मेट हैं, किसी भी मनमाने Python तिथि‑फ़ॉर्मेट स्ट्रिंग नहीं। [setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) द्वारा सेट की गई भाषा और प्रस्तुति को प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएँ**

[addField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#addField) का स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड पहचानकर्ता स्वीकार करता है। इसे तब उपयोग करें जब किसी अन्य एप्लिकेशन द्वारा प्रदान किया गया पहचानकर्ता रखा जाना हो जिसका कोई पूर्वनिर्धारित मान न हो। आप इस पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#FieldType) भी बना सकते हैं। [FieldType.getInternalString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fieldtype/#getInternalString) उस पहचानकर्ता को निरीक्षण के लिए उजागर करता है।

यह उदाहरण एक एप्लिकेशन‑विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। पहचानकर्ता कोई गणना रजिस्टर नहीं करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट ID उत्पन्न नहीं करता। इस पहचानकर्ता को समझने वाला एप्लिकेशन इसका अर्थ प्रदान करे और मान अपडेट करे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

इस PPTX राउंड‑ट्रिप के बाद प्रकार `custom-report-id` रहता है और टेक्स्ट `Report-042` होता है। `yyyy-MM-dd` जैसी स्ट्रिंग पास करने से फ़ील्ड प्रकार का नाम मिलेगा; यह कस्टम तिथि फ़ॉर्मेट कॉन्फ़िगर नहीं करेगा। मनमाने फ़ॉर्मेट में स्थायी तिथि के लिए साधारण टेक्स्ट का उपयोग करें।

## **डेट/समय फ़ील्ड का निरीक्षण, संशोधन और हटाना**

एक मौजूदा फ़ील्ड को [Field.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/field/#setType) के माध्यम से बदलें। प्रकार तक पहुँचने से पहले जांचें कि फ़ील्ड मौजूद है। स्वचालित अपडेट रोकने के लिए [Portion.removeField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#removeField) को कॉल करें। यह फ़ील्ड संबंध को हटाते हुए भाग और उसका वर्तमान टेक्स्ट बरकरार रखता है। यदि आपको कोई निश्चित मान चाहिए तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

डेट/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#setCurrentDateTime)। नीचे दिया गया उदाहरण फ़ील्ड को साधारण टेक्स्ट में बदलते समय एक स्पष्ट स्वीकृति तिथि का उपयोग करता है।

[sample.pptx](sample.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसमें दो नामांकित टेक्स्ट शेप `UpdatedAt` और `ApprovedDate` हैं, प्रत्येक में डेट/टाइम फ़ील्ड और साधारण टेक्स्ट लेबल हैं। अगला उदाहरण नियमित स्लाइडों पर टॉप‑लेवल टेक्स्ट शेप्स को पार करता है। यह डेट/टाइम फ़ील्ड को लंबी‑तारीख फ़ॉर्मेट में बदलता है और इटैलिक बनाता है, जबकि अन्य फ़ॉर्मेटिंग बरकरार रखता है। केवल `ApprovedDate` में फ़ील्ड स्थिर टेक्स्ट बन जाता है।

नमूना निर्मित आंतरिक पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक पहचानता है। समूह, तालिकाएँ, नोट्स, लेआउट और मास्टर अपने स्वयं के टेक्स्ट कंटेनरों की यात्रा की आवश्यकता रखते हैं और इस उदाहरण के दायरे से बाहर हैं।

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # सिस्टम लोकेल से स्वतंत्र रूप से अंग्रेजी महीने के नाम उपयोग करें।
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

पुनः खोलने के बाद `UpdatedAt` का प्रकार `datetime3` है और यह गतिशील बना रहता है। `ApprovedDate` में कोई फ़ील्ड नहीं है और इसमें `05 April 2030` है। दोनों डेट भाग इटैलिक हैं, और उनके मूल फ़ॉन्ट साइज, बोल्ड सेटिंग, तथा रंग अपरिवर्तित हैं। साधारण टेक्स्ट लेबल बिना बदले हैं। सत्यापन प्रदत्त नमूने में दो ज्ञात शेप्स के पहले भाग को पढ़ता है।

## **पाठ फ़ॉर्मेटिंग को संरक्षित करें**

फ़ील्ड जोड़ते, उसका प्रकार बदलते या हटाते समय मौजूदा भाग के साथ काम करें। ये ऑपरेशन उस भाग की फ़ॉर्मेटिंग को बरकरार रखते हैं। आवश्यक गुणों को बदलने के लिये [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getPortionFormat) का उपयोग करें, जैसे उदाहरणों में रंग या इटैलिक के लिये किया गया है।

सिर्फ एक फ़ील्ड को अपडेट करने के लिये पूरे टेक्स्ट फ्रेम को पुनः बनाने से बचें: ऐसा करने से मूल भाग सीमाएँ और उनकी व्यक्तिगत फ़ॉर्मेटिंग खो सकती है। पैराग्राफ, लेआउट या थीम से विरासत में मिली फ़ॉर्मेटिंग और स्पष्ट रूप से सेट की गई फ़ॉर्मेटिंग में अंतर करें। विस्तृत फ़ॉर्मेटिंग विकल्पों के लिये देखें [Text Formatting](/slides/hi/python-java/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ूटर प्लेसहोल्डर**

फ़ील्ड एक टेक्स्ट भाग का हिस्सा है। प्लेसहोल्डर वह शेप है जिसके पास प्रस्तुति भूमिका होती है, जैसे फ़ूटर या स्लाइड नंबर। साधारण टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह शेप प्लेसहोल्डर नहीं बन जाता।

हेडर/फ़ूटर प्रबंधक स्लाइड, लेआउट और मास्टर पर प्लेसहोल्डर टेक्स्ट और दृश्यता को नियंत्रित करते हैं, जिसमें आश्रित स्लाइडों को प्रसार भी शामिल है। कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड तब भी उपयोगी हो सकता है जब आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग नहीं कर रहे हों। इसके विपरीत, प्लेसहोल्डर दृश्यता बदलने से असंबंधित टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वनिर्धारित हेडर और फ़ूटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते या उनका सामग्री प्रदान नहीं करते। विशेष रूप से, एक सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट्स पेज और हैंडआउट्स से संबंधित होते हैं। यह मान न लें कि मनमाने शेप में हेडर या फ़ूटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर प्रबंधक द्वारा कॉन्फ़िगर किया गया टेक्स्ट प्राप्त कर लेगा। उस वर्कफ़्लो के लिये देखें [Presentation Headers and Footers](/slides/hi/python-java/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसके परिणामी टेक्स्ट दोनों की जाँच करें। पहचानकर्ता को संरक्षित करने से यह सिद्ध नहीं होता कि एप्लिकेशन उसका मान गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | फ़ील्ड पहचानकर्ता को फ़ील्ड टेक्स्ट के साथ संग्रहीत किया जाता है। राउंड‑ट्रिप जाँच में, ऊपर उपयोग किए गए पूर्वनिर्धारित प्रकार और कस्टम पहचानकर्ता दोनों सहेजने और पुनः खोलने के बाद जीवित रहे। अज्ञात कस्टम प्रकार ने अपना फॉलबैक टेक्स्ट बरकरार रखा; इसे स्वचालित गणना लॉजिक नहीं मिला। अन्य एप्लिकेशन असमर्थित पहचानकर्ताओं को अलग तरह से संभाल सकते हैं। |
| PPT | लेगेसी फ़ील्ड प्रतिनिधित्व का उपयोग करता है और संगतता अधिक सीमित है। राउंड‑ट्रिप जाँच में, स्लाइड‑नंबर और पूर्वनिर्धारित डेट/टाइम फ़ील्ड सहेजने और पुनः खोलने के बाद जीवित रहे। सामान्य स्लाइड टेक्स्ट बॉक्स में एक कस्टम फ़ील्ड अपने पहचानकर्ता के साथ reopened हुआ लेकिन टेक्स्ट `*` था; समान संदर्भ में एक हेडर फ़ील्ड भी `*` उत्पन्न करता था। कस्टम फ़ील्ड या असमर्थित फ़ील्ड संदर्भों के दृश्यमान टेक्स्ट को बरकरार रखने पर भरोसा न करें। |

स्थिर, पोर्टेबल आउटपुट के लिये, असमर्थित फ़ील्ड को साधारण टेक्स्ट में बदलें और सहेजने से पहले वांछित मान स्पष्ट रूप से असाइन करें। यह चयनित टेक्स्ट को संरक्षित करता है लेकिन जानबूझकर स्वचालित अपडेट को रोकता है। जब आपका वर्कफ़्लो लक्ष्य एप्लिकेशन की अपनी फ़ील्ड पुनर्गणना शामिल करता है, तो उसे भी परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि दिखाया गया नंबर या तिथि फ़ील्ड है?**  
[Portion.getField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getField) देखें। `None` के अलावा कोई मान फ़ील्ड को दर्शाता है; केवल दिखाया गया टेक्स्ट यह बताता नहीं है।

**क्या फ़ील्ड हटाने से उसका पाठ या फ़ॉर्मेटिंग हट जाता है?**  
नहीं। [removeField](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#removeField) मौजूदा भाग को साधारण टेक्स्ट में परिवर्तित करता है। यदि आपको कोई निश्चित तिथि या फॉलबैक मान चाहिए तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

**क्या एक आंतरिक स्ट्रिंग नया तिथि फ़ॉर्मेट या सूत्र परिभाषित कर सकती है?**  
नहीं। यह केवल फ़ील्ड प्रकार की पहचान करती है। अज्ञात पहचानकर्ता मूल्यांकनकर्ता या Python तिथि‑फ़ॉर्मेट पैटर्न नहीं देता। समर्थनित पूर्वनिर्धारित प्रकार का उपयोग करें या मान को स्वयं साधारण टेक्स्ट के रूप में फ़ॉर्मेट करें।

**सहेजने के बाद प्रस्तुति को फिर से क्यों जांचना चाहिए?**  
फ़ील्ड पहचानकर्ता, गणना किया गया टेक्स्ट, और फ़ॉर्मेटिंग अलग‑अलग चीज़ें हैं जिन्हें सत्यापित करना आवश्यक है। फ़ॉर्मेट परिवर्तन दृश्य परिणाम को बदल सकता है भले ही फ़ील्ड पहचानकर्ता अभी भी मौजूद हो।