---
title: JavaScript में PowerPoint प्रस्तुतियों के लिए टेक्स्ट फ़ील्ड प्रबंधित करें
linktitle: टेक्स्ट फ़ील्ड
type: docs
weight: 52
url: /hi/nodejs-java/text-fields/
keywords:
- टेक्स्ट फ़ील्ड
- स्वचालित टेक्स्ट
- स्लाइड संख्या
- तिथि और समय
- हैडर
- फ़ूटर
- टेक्स्ट भाग
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड बनाएं, जांचें, संशोधित करें और हटाएँ। फ़ॉर्मेटिंग को बनाए रखें और सहेजे गए PPTX और PPT फ़ाइलों की जाँच करें।"
---
## **सारांश**

एक टेक्स्ट पैराग्राफ में कई भाग होते हैं। एक सामान्य [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) में शाब्दिक टेक्स्ट होता है; एक फ़ील्ड भाग में additionally एक [Field](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/field/) होता है जिसका प्रकार स्वचालित रूप से अपडेट होने वाले मान को दर्शाता है, जैसे स्लाइड नंबर या तिथि। दो भाग समान अक्षर दिखा सकते हैं जबकि केवल एक में फ़ील्ड हो सकता है।

इनके बीच अंतर करने के लिए [Portion.getField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#getField) का उपयोग करें: साधारण टेक्स्ट के लिए यह `null` होता है। [Portion.addField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#addField) मौजूदा भाग को फ़ील्ड में परिवर्तित करता है। लेबल और उसकी गतिशील मान को अलग‑अलग भागों में रखें ताकि मान को फ़ील्ड में बदलने से लेबल भी बदल न जाए।

यह गाइड टेक्स्ट के भीतर फ़ील्ड, उनका फ़ॉर्मेटिंग, और PPTX तथा PPT में सहेजने को कवर करता है। टेक्स्ट फ्रेम और पैराग्राफ के लिए देखें [Manage Text](/slides/hi/nodejs-java/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाएं**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल और उसके बाद स्वचालित रूप से अपडेट होने वाला नंबर होता है। यह फ़ील्ड जोड़ने से पहले नंबर का आकार, वजन, और रंग सेट करता है, फिर सहेजे गए प्रेजेंटेशन को पुनः खोलता है और फ़ील्ड प्रकार, टेक्स्ट, तथा फ़ॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

नई प्रेजेंटेशन स्लाइड नंबर 1 से शुरू होती है, इसलिए टेक्स्ट `Slide 1` है, और दोनों जाँचें `true` प्रिंट करती हैं। पुनः खोलने के बाद भी नंबर फ़ील्ड बना रहता है; यह शाब्दिक `1` नहीं है। सत्यापन में उपयोग किए गए इंडेक्स उस शेप और उन भागों को संदर्भित करते हैं जो इस उदाहरण द्वारा बनाए गए हैं।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/) पूर्वनिर्धारित मान प्राप्त करने के लिए निम्नलिखित विधियां प्रदान करता है। उपयुक्त मान को [addField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#addField) में पास करें।

| विधि | उद्देश्य |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | वर्तमान स्लाइड नंबर। |
| [getDateTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getDateTime) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फ़ॉर्मेट में तिथि/समय। |
| [getDateTime1](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | पूर्वनिर्धारित तिथि या संयोजन तिथि/समय फ़ॉर्मेट। |
| [getDateTime10](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | पूर्वनिर्धारित समय फ़ॉर्मेट, जिसमें सेकंड और 12‑घंटे घड़ी के विकल्प शामिल हैं। |
| [getHeader](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getHeader) | हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फ़ॉर्मेट सीमाओं को देखें। |
| [getFooter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getFooter) | फ़ूटर फ़ील्ड। |

उदाहरण के लिए, [getDateTime3](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getDateTime3) अंग्रेज़ी में दिन, पूर्ण महीना नाम, और वर्ष दर्शाता है। ये पूर्वनिर्धारित फ़ील्ड फ़ॉर्मेट हैं, नकली तारीख‑फ़ॉर्मेट स्ट्रिंग नहीं। [setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) के साथ सेट की गई भाषा और प्रेजेंटेशन प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएं**

[addField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#addField) का स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड पहचानकर्ता को स्वीकार करता है। इसे तब उपयोग करें जब कोई अन्य एप्लिकेशन द्वारा प्रदान किया गया पहचानकर्ता बिना पूर्वनिर्धारित मान के संरक्षित रहना हो। आप उसी पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/) भी बना सकते हैं। [FieldType.getInternalString](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fieldtype/#getInternalString) उस पहचानकर्ता को निरीक्षण के लिए उजागर करता है।

यह उदाहरण एप्लिकेशन‑विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। पहचानकर्ता कोई गणना नहीं पंजीकृत करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट ID उत्पन्न नहीं करता। जो एप्लिकेशन इस पहचानकर्ता को समझता है, उसे उसका अर्थ प्रदान करना और मान को अपडेट करना पड़ेगा।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

इस PPTX राउंड‑ट्रिप के बाद प्रकार `custom-report-id` रहता है और टेक्स्ट `Report-042` रहता है। `yyyy-MM-dd` जैसी स्ट्रिंग पास करने पर एक फ़ील्ड प्रकार का नाम बनेगा; यह कस्टम तारीख फ़ॉर्मेट को कॉन्फ़िगर नहीं करेगा। वैकल्पिक फ़ॉर्मेट में स्थिर तिथि के लिए साधारण टेक्स्ट उपयोग करें।

## **तारीख/समय फ़ील्ड की जाँच, संशोधन और हटाना**

[Field.setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/field/#setType) के द्वारा मौजूदा फ़ील्ड को बदलें। फ़ील्ड की जाँच करने से पहले सुनिश्चित करें कि वह मौजूद है। स्वचालित अपडेट रोकने के लिए [Portion.removeField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#removeField) को कॉल करें। यह फ़ील्ड एसोसिएशन को हटाते हुए भाग और उसका वर्तमान टेक्स्ट रखता है। यदि आपको कोई विशेष स्थिर मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

तारीख/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#setCurrentDateTime)। नीचे दिया गया उदाहरण फ़ील्ड को साधारण टेक्स्ट में बदलते समय स्पष्ट अनुमोदन तिथि का उपयोग करता है।

[sample.pptx](sample.pptx) को डाउनलोड करें और कार्य निर्देशिका में रखें। इसमें दो नामित टेक्स्ट शेप हैं, `UpdatedAt` और `ApprovedDate`, प्रत्येक में एक तारीख/समय फ़ील्ड है, साथ ही साधारण टेक्स्ट लेबल हैं। नीचे का उदाहरण नियमित स्लाइड्स पर शीर्ष‑स्तर के टेक्स्ट शेप्स को पार करता है। यह तारीख/समय फ़ील्ड को लंबी‑तारीख फ़ॉर्मेट में बदलता है और इटैलिक बनाता है, जबकि उनके अन्य फ़ॉर्मेटिंग को संरक्षित रखता है। केवल `ApprovedDate` के फ़ील्ड स्थिर टेक्स्ट बनते हैं।

अनुमोदन तिथि 5 अप्रैल 2030 है; JavaScript माह सूचकांक शून्य से शुरू होता है, इसलिए अप्रैल `3` है। UTC का उपयोग निर्माण और फ़ॉर्मेटिंग दोनों में किया गया है ताकि तारीख स्थानीय समय‑क्षेत्र से स्वतंत्र रहे।

उदाहरण निर्मित पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक को पहचानता है। समूह, तालिकाएँ, नोट्स, लेआउट और मास्टर को अपने स्वयं के टेक्स्ट कंटेनर की यात्रा करनी पड़ती है और यह उदाहरण की सीमा से बाहर हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

पुनः खोलने के बाद, `UpdatedAt` का प्रकार `datetime3` है और यह गतिशील बना रहता है। `ApprovedDate` में कोई फ़ील्ड नहीं है और टेक्स्ट `05 April 2030` है। दोनों तारीख भाग इटैलिक हैं, और उनका मूल फ़ॉन्ट आकार, बोल्ड सेटिंग, तथा रंग बरकरार रहता है। साधारण टेक्स्ट लेबल अपरिवर्तित हैं। सत्यापन आपूर्ति किए गए नमूने में दो ज्ञात शेप्स के पहले भाग को पढ़ता है।

## **टेक्स्ट फ़ॉर्मेटिंग को संरक्षित रखें**

फ़ील्ड जोड़ते समय, उसका प्रकार बदलते समय, या हटाते समय मौजूदा भाग के साथ काम करें। ये ऑपरेशन उस भाग की फ़ॉर्मेटिंग को बनाए रखते हैं। आवश्यक प्रॉपर्टीज़ ही बदलने के लिए [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#getPortionFormat) का उपयोग करें, जैसा कि उदाहरण रंग या इटैलिक के लिए करते हैं।

एक फ़ील्ड को अपडेट करने के लिए पूरी टेक्स्ट फ़्रेम को पुनः बनाना टालें: ऐसा करने से मूल भाग सीमाएँ और उनकी व्यक्तिगत फ़ॉर्मेटिंग खो सकती है। पैराग्राफ, लेआउट, या थीम से विरासत में मिली फ़ॉर्मेटिंग और स्पष्ट‑सेट फ़ॉर्मेटिंग के बीच अंतर करें। विस्तृत फ़ॉर्मेटिंग विकल्पों के लिए देखें [Text Formatting](/slides/hi/nodejs-java/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ूटर प्लेसहोल्डर**

फ़ील्ड टेक्स्ट भाग का हिस्सा है। प्लेसहोल्डर वह शेप है जिसका प्रस्तुति में विशेष रोल होता है, जैसे फ़ूटर या स्लाइड नंबर। सामान्य टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह शेप प्लेसहोल्डर नहीं बन जाता।

हेडर/फ़ूटर मैनेजर्स स्लाइड्स, लेआउट्स, और मास्टर्स पर प्लेसहोल्डर टेक्स्ट और दृश्यता को नियंत्रित करते हैं, जिसमें निर्भर स्लाइड्स तक प्रसार शामिल है। कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड तब भी उपयोगी हो सकता है जब आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग नहीं कर रहे हों। इसके विपरीत, प्लेसहोल्डर विज़िबिलिटी बदलने से अनसंबंधित टेक्स्ट बॉक्स से फ़ील्ड नहीं हटेगा।

पूर्वनिर्धारित हेडर और फ़ूटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते और उनका कंटेंट नहीं देते। विशेष रूप से, सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट्स पेज और हैंडआउट्स में होते हैं। यह न मानें कि किसी आकस्मिक शेप में हेडर या फ़ूटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर मैनेजर द्वारा कॉन्फ़िगर किया गया टेक्स्ट प्राप्त कर लेगा। उस कार्यप्रवाह के लिए देखें [Presentation Headers and Footers](/slides/hi/nodejs-java/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसके परिणामी टेक्स्ट दोनों की जाँच करें। एक पहचानकर्ता को संरक्षित करना यह सिद्ध नहीं करता कि एप्लिकेशन उसका मान गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | फ़ील्ड टेक्स्ट के साथ आंतरिक पहचानकर्ता संग्रहीत करता है। राउंड‑ट्रिप जाँचों में, ऊपर उपयोग किए गए पूर्वनिर्धारित प्रकार और कस्टम पहचानकर्ता दोनों सहेजने और पुनः खोलने के बाद बने रहे। अज्ञात कस्टम प्रकार ने अपना फॉलबैक टेक्स्ट बरकरार रखा; इसे स्वचालित गणना लॉजिक नहीं मिला। अन्य एप्लिकेशन असमर्थित पहचानकर्ताओं को अलग‑अलग तरीके से संभाल सकते हैं। |
| PPT | लेगेसी फ़ील्ड प्रतिनिधित्व का उपयोग करता है और संगतता अधिक सीमित है। राउंड‑ट्रिप जाँचों में, स्लाइड‑नंबर और पूर्वनिर्धारित तारीख/समय फ़ील्ड सहेजने और पुनः खोलने के बाद बने रहे। सामान्य स्लाइड टेक्स्ट बॉक्स में एक कस्टम फ़ील्ड अपने पहचानकर्ता के साथ खुला, लेकिन उसका टेक्स्ट `*` था; समान संदर्भ में हेडर फ़ील्ड भी `*` उत्पन्न करता था। कस्टम फ़ील्ड या असमर्थित फ़ील्ड संदर्भों को उनके दृश्यमान टेक्स्ट को बनाए रखने के लिए भरोसा न करें। |

पोर्टेबल, स्थिर आउटपुट के लिए, असमर्थित फ़ील्ड को सामान्य टेक्स्ट में बदलें और सहेजने से पहले स्पष्ट रूप से वह मान असाइन करें जिसे आप चाहते हैं। यह चयनित टेक्स्ट को संरक्षित रखता है लेकिन स्वचालित अपडेट को जानबूझकर रोकता है। जब लक्ष्य एप्लिकेशन अपना स्वयं का फ़ील्ड पुनर्गणना आपके कार्यप्रवाह का हिस्सा हो, तो उसे भी परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि प्रदर्शित नंबर या तिथि फ़ील्ड है या नहीं?**  
[Portion.getField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#getField) को देखें। नॉन‑null मान फ़ील्ड की पहचान करता है; केवल प्रदर्शित टेक्स्ट से यह पता नहीं चल सकता।

**क्या फ़ील्ड हटाने से उसका टेक्स्ट या फ़ॉर्मेटिंग भी हट जाती है?**  
नहीं। [removeField](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#removeField) मौजूदा भाग को साधारण टेक्स्ट में बदल देता है। यदि आपको विशेष रूप से जमे हुए दिनांक या फॉलबैक मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

**क्या आंतरिक स्ट्रिंग नई तिथि फ़ॉर्मेट या फ़ॉर्मूला निर्धारित कर सकती है?**  
नहीं। यह फ़ील्ड प्रकार को पहचानती है। अज्ञात पहचानकर्ता कोई इवैल्यूएटर या तिथि‑फ़ॉर्मेट पैटर्न प्रदान नहीं करता। समर्थित पूर्वनिर्धारित प्रकार का उपयोग करें या मान को स्वयं साधारण टेक्स्ट के रूप में फ़ॉर्मेट करें।

**सहेजने के बाद प्रेजेंटेशन को फिर से क्यों जाँचूँ?**  
फ़ील्ड पहचानकर्ता, गणितीय टेक्स्ट, और फ़ॉर्मेटिंग अलग‑अलग चीजें हैं जिन्हें सत्यापित करना आवश्यक है। फ़ॉर्मेट परिवर्तन दिखाई देने वाले परिणाम को बदल सकता है, भले ही फ़ील्ड पहचानकर्ता अभी भी मौजूद हो।