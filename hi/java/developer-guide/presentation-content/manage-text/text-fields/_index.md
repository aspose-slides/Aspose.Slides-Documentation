---
title: Java में PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड्स का प्रबंधन
linktitle: टेक्स्ट फ़ील्ड्स
type: docs
weight: 52
url: /hi/java/text-fields/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड्स बनाएं, जांचें, संशोधित करें और हटाएं। फ़ॉर्मेटिंग को संरक्षित रखें और सहेजे गए PPTX और PPT फ़ाइलों की जाँच करें।"
---
## **सारांश**

एक टेक्स्ट पैराग्राफ़ भागों (portions) से बना होता है। एक सामान्य [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) में शाब्दिक टेक्स्ट होता है; एक फील्ड भाग में additionally एक [IField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifield/) भी होता है जिसकी प्रकार एक स्वचालित रूप से अपडेट होने वाले मान की पहचान करता है, जैसे कि स्लाइड नंबर या तिथि। दो भाग समान अक्षर प्रदर्शित कर सकते हैं जबकि केवल एक में फील्ड होता है।

इन दोनों को अलग करने के लिए [IPortion.getField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getField--) का उपयोग करें: साधारण टेक्स्ट के लिए यह `null` होता है। [IPortion.addField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) मौजूदा भाग को फील्ड में बदल देता है। लेबल और उसका गतिशील मान अलग-अलग भागों में रखें ताकि मान को बदलने से लेबल भी बदल न जाए।

यह गाइड टेक्स्ट के भीतर फील्ड, उनके फॉर्मेटिंग और उन्हें PPTX तथा PPT में सहेजने को कवर करता है। टेक्स्ट फ्रेम और पैराग्राफ़ के लिए देखें [Manage Text](/slides/hi/java/manage-text/)।

## **स्लाइड नंबर फील्ड बनाएं**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल के बाद स्वचालित रूप से अपडेट होने वाला नंबर होता है। यह फील्ड जोड़ने से पहले नंबर का आकार, वजन और रंग सेट करता है, फिर सहेजे गए प्रेजेंटेशन को पुनः खोलता है और फील्ड प्रकार, टेक्स्ट और फॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

नया प्रेजेंटेशन स्लाइड नंबर 1 से शुरू होता है, इसलिए टेक्स्ट `Slide 1` है, और दोनों जाँचें `true` प्रिंट करती हैं। पुनः खोलने के बाद भी नंबर फील्ड बना रहता है; यह शाब्दिक `1` नहीं है। सत्यापन में कास्ट और इंडेक्स उस शेप और भागों की ओर इशारा करते हैं जो इस उदाहरण द्वारा बनाए गए थे।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifieldtype/) को इम्प्लीमेंट करता है और पूर्वनिर्धारित मान प्राप्त करने के लिए निम्नलिखित विधियां प्रदान करता है। उपयुक्त मान को [addField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) में पास करें।

| विधि | उद्देश्य |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getSlideNumber--) | वर्तमान स्लाइड संख्या। |
| [getDateTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getDateTime--) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फ़ॉर्मेट में तिथि/समय। |
| [getDateTime1](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getDateTime9--) | पूर्वनिर्धारित तिथि या संयोजित तिथि/समय फ़ॉर्मेट। |
| [getDateTime10](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getDateTime13--) | पूर्वनिर्धारित समय फ़ॉर्मेट, सेकंड और 12-घंटे घड़ी विकल्प सहित। |
| [getHeader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getHeader--) | हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फ़ॉर्मेट सीमाएँ देखें। |
| [getFooter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getFooter--) | फ़ूटर फ़ील्ड। |

उदाहरण के तौर पर, [getDateTime3](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#getDateTime3--) एक दिन, पूरा महीने का नाम और वर्ष को अंग्रेज़ी में दर्शाता है। ये पूर्वनिर्धारित फ़ील्ड फ़ॉर्मेट हैं, 任意 Java तिथि-फ़ॉर्मेट स्ट्रिंग नहीं। [setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) के साथ सेट की गई भाषा और प्रेजेंटेशन को प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएं**

[addField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#addField-java.lang.String-) का स्ट्रिंग ओवरलोड आंतरिक फील्ड पहचानकर्ता को स्वीकार करता है। इसे तब उपयोग करें जब आप किसी अन्य एप्लिकेशन द्वारा प्रदान किए गए पहचानकर्ता को संरक्षित रखना चाहते हैं जिसका कोई पूर्वनिर्धारित मान नहीं है। आप इस पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) भी बना सकते हैं। [IFieldType.getInternalString](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifieldtype/#getInternalString--) इस पहचानकर्ता को निरीक्षण के लिए उजागर करता है।

यह उदाहरण एक एप्लिकेशन-विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। पहचानकर्ता कोई गणना रजिस्टर नहीं करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट आईडी नहीं बनाता। वह एप्लिकेशन जो इस पहचानकर्ता को समझता है, उसे उसका अर्थ प्रदान करना और उसका मान अपडेट करना पड़ता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

इस PPTX राउंड‑ट्रिप के बाद, प्रकार `custom-report-id` रहता है और टेक्स्ट `Report-042` रहता है। `yyyy-MM-dd` जैसी स्ट्रिंग पास करने से फ़ील्ड प्रकार का नाम रहेगा; यह कस्टम तिथि फ़ॉर्मेट को कॉन्फ़िगर नहीं करेगा। 任意 फ़ॉर्मेट की स्थिर तिथि के लिए सामान्य टेक्स्ट उपयोग करें।

## **तिथि/समय फ़ील्ड की जाँच, संशोधन और हटाना**

मौजूदा फ़ील्ड को [IField.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) द्वारा बदलें। प्रकार तक पहुँचने से पहले यह सुनिश्चित करें कि फ़ील्ड मौजूद है। स्वचालित अपडेट रोकने के लिए [IPortion.removeField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#removeField--) को कॉल करें। यह भाग और उसकी वर्तमान टेक्स्ट को रखता है जबकि फ़ील्ड संबंध को हटा देता है। यदि आपको निश्चित मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

तिथि/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)। नीचे दिया गया उदाहरण फ़ील्ड को सामान्य टेक्स्ट में बदलते समय एक स्पष्ट स्वीकृति तिथि का उपयोग करता है।

[sample.pptx](sample.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसमें दो नामांकित टेक्स्ट शेप `UpdatedAt` और `ApprovedDate` हैं, प्रत्येक में तिथि/समय फ़ील्ड है, साथ ही सामान्य टेक्स्ट लेबल भी हैं। निम्न उदाहरण नियमित स्लाइडों पर शीर्ष‑स्तर के टेक्स्ट शेप को पार करता है। यह तिथि/समय फ़ील्ड को लंबी तिथि फ़ॉर्मेट में बदलता है और इटैलिक बनाता है, जबकि अन्य फ़ॉर्मेटिंग बरकरार रखता है। केवल `ApprovedDate` के फ़ील्ड स्थिर टेक्स्ट बनते हैं।

सैंपल अंतर्निहित पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक को पहचानता है। समूह, तालिकाएँ, नोट्स, लेआउट और मास्टर को उनके अपने टेक्स्ट कंटेनर की यात्रा करनी पड़ेगी और यह उदाहरण इनके दायरे से बाहर है।

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

पुनः खोलने के बाद, `UpdatedAt` का प्रकार `datetime3` है और यह गतिशील रहता है। `ApprovedDate` में कोई फ़ील्ड नहीं है और इसमें `05 April 2030` है। दोनों तिथि भाग इटैलिक हैं, और उनका मूल फ़ॉन्ट आकार, बोल्ड सेटिंग और रंग अपरिवर्तित रहता है। सामान्य टेक्स्ट लेबल अपरिवर्तित हैं। सत्यापन प्रदान किए गए सैंपल में दो ज्ञात शेप के पहले भाग को पढ़ता है।

## **टेक्स्ट फ़ॉर्मेटिंग को संरक्षित रखें**

फ़ील्ड जोड़ते, प्रकार बदलते या हटाते समय मौजूदा भाग के साथ काम करें। ये ऑपरेशन उस भाग की फ़ॉर्मेटिंग को बरकरार रखते हैं। आवश्यक प्रॉपर्टीज़ को ही बदलने के लिए [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getPortionFormat--) का उपयोग करें, जैसा कि उदाहरण में रंग या इटैलिक के लिए किया गया है।

केवल एक फ़ील्ड को अपडेट करने के लिए पूरे टेक्स्ट फ्रेम को पुनः बनाना avoided करें: इससे मूल भाग की सीमाएँ और उनकी व्यक्तिगत फ़ॉर्मेटिंग खो सकती हैं। पैराग्राफ, लेआउट या थीम से विरासत में मिली फ़ॉर्मेटिंग और स्पष्ट रूप से सेट की गई फ़ॉर्मेटिंग में अंतर करें। विस्तृत फ़ॉर्मेटिंग विकल्पों के लिए देखें [Text Formatting](/slides/hi/java/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ूटर प्लेसहोल्डर**

फ़ील्ड टेक्स्ट भाग का हिस्सा होता है। प्लेसहोल्डर एक शेप होता है जिसका प्रेजेंटेशन में कोई भूमिका होती है, जैसे कि फ़ूटर या स्लाइड नंबर। सामान्य टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह शेप प्लेसहोल्डर नहीं बन जाता।

हेडर/फ़ूटर मैनेजर्स स्लाइड, लेआउट और मास्टर पर प्लेसहोल्डर टेक्स्ट और दृश्यता को नियंत्रित करते हैं, जिसमें निर्भर स्लाइडों तक प्रसारण शामिल है। कस्टम टेक्स्ट बॉक्स में एक नंबर फ़ील्ड तब भी उपयोगी हो सकता है जब आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग नहीं कर रहे हों। इसके विपरीत, प्लेसहोल्डर की दृश्यता बदलने से असंबंधित टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वनिर्धारित हेडर और फ़ूटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते और न ही उनका कंटेंट सप्लाई करते हैं। विशेष रूप से, एक सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट्स पेज और हैंडआउट्स से संबंधित होते हैं। यह न मानें कि किसी 任意 शेप में हेडर या फ़ूटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर मैनेजर द्वारा कॉन्फ़िगर किया गया टेक्स्ट प्राप्त कर लेगा। इस वर्कफ़्लो के लिए देखें [Presentation Headers and Footers](/slides/hi/java/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसका परिणामस्वरूप टेक्स्ट दोनों की जाँच करें। पहचानकर्ता को संरक्षित करने से यह सिद्ध नहीं होता कि एप्लिकेशन उसका मान गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | आंतरिक फ़ील्ड पहचानकर्ता को फ़ील्ड टेक्स्ट के साथ संग्रहीत करता है। राउंड‑ट्रिप जाँचों में, ऊपर उपयोग किए गए पूर्वनिर्धारित प्रकार और कस्टम पहचानकर्ता सहेजने और पुनः खोलने के बाद भी बना रहे। अज्ञात कस्टम प्रकार ने अपना फॉलबैक टेक्स्ट बरकरार रखा; इसमें स्वचालित गणना लॉजिक नहीं आया। अन्य एप्लिकेशन असहाय पहचानकर्ताओं को अलग तरीके से संभाल सकते हैं। |
| PPT | पुरानी फ़ील्ड प्रस्तुतियों का उपयोग करता है और संगतता अधिक सीमित है। राउंड‑ट्रिप जाँचों में, स्लाइड‑नंबर और पूर्वनिर्धारित तिथि/समय फ़ील्ड सहेजने और पुनः खोलने के बाद भी बने रहे। सामान्य स्लाइड टेक्स्ट बॉक्स में एक कस्टम फ़ील्ड अपनी पहचानकर्ता के साथ खुला लेकिन टेक्स्ट `*` रहा; उसी संदर्भ में हेडर फ़ील्ड भी `*` उत्पन्न किया। कस्टम फ़ील्ड या असहाय फ़ील्ड संदर्भों पर भरोसा न करें कि उनका दृश्यमान टेक्स्ट बना रहे। |

पोर्टेबल, स्थिर आउटपुट के लिए, असहाय फ़ील्ड को सामान्य टेक्स्ट में बदलें और सहेजने से पहले वह मान स्पष्ट रूप से असाइन करें जो आप चाहते हैं। इससे चुना हुआ टेक्स्ट बरकरार रहता है लेकिन स्वचालित अपडेट जानबूझकर बंद हो जाते हैं। यदि आपका वर्कफ़्लो लक्षित एप्लिकेशन की फ़ील्ड पुनः‑गणना पर निर्भर करता है, तो उसे भी परीक्षण करें।

## **FAQ**

**मैं कैसे जानूँ कि प्रदर्शित नंबर या तिथि फ़ील्ड है या नहीं?**  
[IPortion.getField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getField--) देखें। शून्य‑नॉन null मान फ़ील्ड को पहचानता है; सिर्फ प्रदर्शित टेक्स्ट से यह नहीं पता चलता।

**क्या फ़ील्ड हटाने से उसका टेक्स्ट या फ़ॉर्मेटिंग हट जाता है?**  
नहीं। [removeField](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#removeField--) मौजूदा भाग को सामान्य टेक्स्ट में बदल देता है। यदि आपको कोई निश्चित तिथि या फॉलबैक मान चाहिए तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

**क्या आंतरिक स्ट्रिंग नई तिथि फ़ॉर्मेट या फ़ॉर्मूला परिभाषित कर सकती है?**  
नहीं। यह फ़ील्ड प्रकार को पहचानती है। अज्ञात पहचानकर्ता कोई मूल्यांकनकर्ता या Java तिथि‑फ़ॉर्मेट पैटर्न नहीं देता। समर्थित पूर्वनिर्धारित प्रकार उपयोग करें या मान को स्वयं सामान्य टेक्स्ट के रूप में फ़ॉर्मेट करें।

**सहेजने के बाद प्रेज़ेंटेशन को फिर से क्यों जांचें?**  
फ़ील्ड पहचानकर्ता, गणना किया गया टेक्स्ट और फ़ॉर्मेटिंग अलग‑अलग चीज़ें हैं जिन्हें सत्यापित करना आवश्यक है। फ़ॉर्मेट परिवर्तन दृश्यमान परिणाम को बदल सकता है जबकि फ़ील्ड पहचानकर्ता अभी भी मौजूद हो।