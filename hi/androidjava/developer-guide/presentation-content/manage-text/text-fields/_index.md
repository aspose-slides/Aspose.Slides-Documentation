---
title: Android पर PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड प्रबंधित करें
linktitle: टेक्स्ट फ़ील्ड्स
type: docs
weight: 52
url: /hi/androidjava/text-fields/
keywords:
- टेक्स्ट फ़ील्ड
- स्वचालित टेक्स्ट
- स्लाइड संख्या
- तारीख और समय
- हेडर
- फ़ूटर
- टेक्स्ट भाग
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java के माध्यम से PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड बनाएं, निरीक्षण करें, संशोधित करें और हटाएं। फ़ॉर्मेटिंग को संरक्षित रखें और सहेजे गए PPTX और PPT फाइलों की सत्यापित करें।"
---
## **अवलोकन**

एक पाठ अनुच्छेद कई भागों (portions) से बना होता है। एक साधारण [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) में शाब्दिक पाठ होता है; एक फ़ील्ड भाग में additionally एक [IField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifield/) भी होता है जिसका प्रकार स्वचालित रूप से अद्यतित मान को पहचानता है, जैसे स्लाइड संख्या या तिथि। दो भाग समान अक्षर प्रदर्शित कर सकते हैं जबकि केवल एक में फ़ील्ड होता है।

उन्हें अलग करने के लिए [IPortion.getField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getField--) का उपयोग करें: साधारण पाठ के लिए यह `null` होता है। [IPortion.addField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) मौजूदा भाग को फ़ील्ड में बदलता है। लेबल और उसकी गतिशील मान को अलग-अलग भागों में रखें ताकि मान को बदलने से लेबल भी न बदल जाए।

यह गाइड टेक्स्ट के भीतर फ़ील्ड, उनके फॉर्मेटिंग, और उन्हें PPTX व PPT में सेव करने को कवर करता है। टेक्स्ट फ्रेम और अनुच्छेदों के लिए, देखें [Manage Text](/slides/hi/androidjava/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाना**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल के साथ स्वचालित रूप से अपडेट होने वाली संख्या होती है। यह फ़ील्ड जोड़ने से पहले संख्या का आकार, वजन और रंग सेट करता है, फिर सहेजित प्रस्तुति को पुनः खोलता है और फ़ील्ड प्रकार, टेक्स्ट एवं फॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

नई प्रस्तुति स्लाइड संख्या 1 से शुरू होती है, इसलिए टेक्स्ट `Slide 1` है, और दोनों जाँच `true` प्रिंट करती हैं। पुनः खोलने के बाद संख्या फ़ील्ड बनी रहती है; यह शाब्दिक `1` नहीं है। सत्यापन में उपयोग किए गए कास्ट और इंडेक्स इस उदाहरण द्वारा बनाए गए आकार और भागों को संदर्भित करते हैं।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifieldtype/) को लागू करता है और पूर्वनिर्धारित मान प्राप्त करने के लिए निम्नलिखित मेथड प्रदान करता है। उपयुक्त मान को [addField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) में पास करें।

| मेथड | उद्देश्य |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | वर्तमान स्लाइड संख्या। |
| [getDateTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फ़ॉर्मेट में तिथि/समय। |
| [getDateTime1](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | पूर्वनिर्धारित तिथि या संयुक्त तिथि/समय फ़ॉर्मेट। |
| [getDateTime10](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | पूर्वनिर्धारित समय फ़ॉर्मेट, जिसमें सेकंड और 12‑घंटे घड़ी विकल्प शामिल हैं। |
| [getHeader](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getHeader--) | हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फ़ॉर्मेट प्रतिबंध देखें। |
| [getFooter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getFooter--) | फ़ूटर फ़ील्ड। |

उदाहरण के लिए, [getDateTime3](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) एक दिन, पूर्ण महीने का नाम, और वर्ष को अंग्रेज़ी में दर्शाता है। ये पूर्वनिर्धारित फ़ील्ड फ़ॉर्मेट हैं, न कि मनमाने Java तिथि‑फ़ॉर्मेट स्ट्रिंग्स। [setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) के साथ सेट की गई भाषा और प्रस्तुति को प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाएँ**

[addField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) का स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड पहचानकर्ता स्वीकार करता है। इसका उपयोग तब करें जब किसी अन्य एप्लिकेशन द्वारा प्रदान किया गया पहचानकर्ता कोई पूर्वनिर्धारित मान नहीं रखता हो। आप इस पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) भी बना सकते हैं। [IFieldType.getInternalString](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) उस पहचानकर्ता को निरीक्षण हेतु उजागर करता है।

यह उदाहरण एक एप्लिकेशन‑विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। पहचानकर्ता कोई गणना नहीं पंजीकृत करता: Aspose.Slides अज्ञात प्रकार के लिए रिपोर्ट ID उत्पन्न नहीं करता। वह एप्लिकेशन जो इस पहचानकर्ता को समझता है, उसे इसका अर्थ प्रदान करना और मान को अपडेट करना होगा।

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

इस PPTX राउंड‑ट्रिप के बाद प्रकार `custom-report-id` है और टेक्स्ट `Report-042` है। `yyyy-MM-dd` जैसे स्ट्रिंग को पास करने से फ़ील्ड प्रकार का नाम मिलेगा; यह एक कस्टम तिथि फ़ॉर्मेट को कॉन्फ़िगर नहीं करेगा। मनमाने फ़ॉर्मेट में स्थिर तिथि के लिए साधारण टेक्स्ट का उपयोग करें।

## **डेट/टाइम फ़ील्ड की जाँच, संशोधन और हटाना**

[IField.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) के माध्यम से मौजूदा फ़ील्ड को बदलें। फ़ील्ड का प्रकार प्राप्त करने से पहले यह सुनिश्चित करें कि फ़ील्ड मौजूद है। स्वचालित अपडेट को रोकने के लिए [IPortion.removeField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#removeField--) को कॉल करें। यह फ़ील्ड संबद्धता को हटाते हुए भाग और उसका वर्तमान टेक्स्ट रखता है। यदि आपको कोई विशेष स्थिर मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

डेट/टाइम फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिए देखें [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)। नीचे का उदाहरण फ़ील्ड को साधारण टेक्स्ट में बदलते समय एक स्पष्ट अनुमोदन तिथि का उपयोग करता है।

[ sample.pptx ](sample.pptx) को डाउनलोड करके कार्य निर्देशिका में रखें। इसमें दो नामित टेक्स्ट शैप्स `UpdatedAt` और `ApprovedDate` हैं, प्रत्येक में एक डेट/टाइम फ़ील्ड तथा साधारण टेक्स्ट लेबल हैं। निम्न उदाहरण नियमित स्लाइड्स पर शीर्ष‑स्तर के टेक्स्ट शैप्स को क्रमबद्ध करता है। यह डेट/टाइम फ़ील्ड को लंबी‑तारीख फ़ॉर्मेट में बदलता है और इटैलिक करता है, जबकि अन्य फ़ॉर्मेटिंग को संरक्षित रखता है। केवल `ApprovedDate` में फ़ील्ड स्थिर टेक्स्ट बन जाती है।

नमूना अंतर्निहित पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक को पहचानता है। समूह, तालिकाएँ, नोट्स, लेआउट और मास्टर अपने‑अपने टेक्स्ट कंटेनर की यात्रा की आवश्यकता रखते हैं और इस उदाहरण के दायरे से बाहर हैं।

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

पुनः खोलने के बाद, `UpdatedAt` का प्रकार `datetime3` है और यह गतिशील रहता है। `ApprovedDate` का कोई फ़ील्ड नहीं है और इसमें `05 April 2030` टेक्स्ट है। दोनों डेट भाग इटैलिक हैं, और उनका मूल फ़ॉन्ट आकार, बोल्ड सेटिंग और रंग अपरिवर्तित रहता है। साधारण टेक्स्ट लेबल बदलाव के बिना रहता है। वैरिफ़िकेशन प्रदान किए गए नमूने में दो ज्ञात शैप्स के पहले भाग को पढ़ता है।

## **टेक्स्ट फ़ॉर्मेटिंग संरक्षित रखें**

फ़ील्ड जोड़ते समय, उसका प्रकार बदलते समय या हटाते समय मौजूदा भाग का उपयोग करें। ये ऑपरेशन उस भाग की फ़ॉर्मेटिंग को बनाए रखते हैं। आवश्यक प्रॉपर्टीज़ ही बदलने के लिए [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) का प्रयोग करें, जैसा कि रंग या इटैलिक के उदाहरण में दिखाया गया है।

एक फ़ील्ड को अद्यतन करने के लिए पूरे टेक्स्ट फ्रेम को पुनर्निर्मित करने से बचें: ऐसा करने से मूल भाग सीमाएँ और उनकी व्यक्तिगत फ़ॉर्मेटिंग खो सकती है। पैराग्राफ, लेआउट या थीम से विरासत में मिली फ़ॉर्मेटिंग को स्पष्ट सेट फ़ॉर्मेटिंग से अलग पहचानें। व्यापक फ़ॉर्मेटिंग विकल्पों के लिए देखें [Text Formatting](/slides/hi/androidjava/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ूटर प्लेसहोल्डर**

फ़ील्ड टेक्स्ट भाग का हिस्सा होता है। प्लेसहोल्डर वह आकार है जिसका प्रस्तुति में कोई भूमिका होती है, जैसे फ़ूटर या स्लाइड नंबर। साधारण टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह आकार प्लेसहोल्डर नहीं बनता।

हेडर/फ़ूटर प्रबंधक स्लाइड्स, लेआउट्स और मास्टर्स पर प्लेसहोल्डर टेक्स्ट और दृश्यमानता को नियंत्रित करते हैं, जिसमें निर्भर स्लाइड्स तक प्रसारण शामिल है। कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड तब भी उपयोगी हो सकता है जब आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग नहीं कर रहे हों। इसके विपरीत, प्लेसहोल्डर की दृश्यमानता बदलने से असंबद्ध टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वनिर्धारित हेडर और फ़ूटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते और न ही उनका कंटेंट प्रदान करते हैं। विशेष रूप से, नियमित PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट्स पेज और हैंडआउट्स में होते हैं। यह न मानें कि मनमाने आकार में हेडर या फ़ूटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर प्रबंधक द्वारा कॉन्फ़िगर टेक्स्ट प्राप्त करेगा। इस वर्कफ़्लो के लिए देखें [Presentation Headers and Footers](/slides/hi/androidjava/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उसके परिणामस्वरूप टेक्स्ट दोनों की जाँच करें। पहचानकर्ता को सुरक्षित रखना यह साबित नहीं करता कि एप्लिकेशन उसका मान गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | आंतरिक फ़ील्ड पहचानकर्ताओं को फ़ील्ड टेक्स्ट के साथ संग्रहीत करता है। राउंड‑ट्रिप जाँच में पूर्वनिर्धारित प्रकार और ऊपर उपयोग किया गया कस्टम पहचानकर्ता दोनों सहेजे जाने और पुनः खोलने के बाद बचे। अज्ञात कस्टम प्रकार ने अपना फॉलबैक टेक्स्ट बरकरार रखा; उसे स्वचालित गणना तर्क नहीं मिला। अन्य एप्लिकेशन असमर्थित पहचानकर्ताओं को अलग तरीके से संभाल सकते हैं। |
| PPT | पुरानी फ़ील्ड प्रतिनिधित्वों का उपयोग करता है और अधिक सीमित संगतता रखता है। राउंड‑ट्रिप जाँच में स्लाइड‑नंबर और पूर्वनिर्धारित डेट/टाइम फ़ील्ड सहेजे और पुनः खुले। साधारण स्लाइड टेक्स्ट बॉक्स में कस्टम फ़ील्ड अपने पहचानकर्ता के साथ खुला, लेकिन टेक्स्ट `*` था; समान संदर्भ में हेडर फ़ील्ड भी `*` उत्पन्न किया। कस्टम फ़ील्ड या असमर्थित फ़ील्ड संदर्भों को उनके दृश्यमान टेक्स्ट को बरकरार रखने पर भरोसा न करें। |

पोर्टेबल, स्थिर आउटपुट के लिए असमर्थित फ़ील्ड को साधारण टेक्स्ट में बदलें और सहेजने से पहले इच्छित मान स्पष्ट रूप से असाइन करें। इससे चुना हुआ टेक्स्ट बना रहता है लेकिन स्वचालित अपडेट जानबूझकर बंद हो जाता है। यदि लक्ष्य एप्लिकेशन का अपना फ़ील्ड पुनर्गणना आपके वर्कफ़्लो का हिस्सा है, तो उसे भी परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि प्रदर्शित संख्या या तिथि फ़ील्ड है या नहीं?**  
[IPortion.getField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getField--) को निरीक्षण करें। गैर‑null मान फ़ील्ड की पहचान करता है; केवल प्रदर्शित टेक्स्ट से पता नहीं चलता।

**क्या फ़ील्ड हटाने से उसका टेक्स्ट या फ़ॉर्मेटिंग हट जाता है?**  
नहीं। [removeField](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#removeField--) मौजूदा भाग को साधारण टेक्स्ट में बदल देता है। यदि आपको कोई विशेष स्थिर तिथि या फॉलबैक मान चाहिए तो फ़ील्ड हटाने के बाद वह मान असाइन करें।

**क्या आंतरिक स्ट्रिंग नया डेट फ़ॉर्मेट या फ़ॉर्मूला परिभाषित कर सकती है?**  
नहीं। यह फ़ील्ड प्रकार की पहचान करता है। अज्ञात पहचानकर्ता कोई इवैल्यूएटर या Java डेट‑फ़ॉर्मेट पैटर्न प्रदान नहीं करता। समर्थित पूर्वनिर्धारित प्रकार का उपयोग करें या मान को स्वयं साधारण टेक्स्ट के रूप में फॉर्मेट करें।

**सहेजने के बाद प्रस्तुति को फिर से जाँचने की आवश्यकता क्यों है?**  
फ़ील्ड पहचानकर्ता, गणना किया गया टेक्स्ट, और फ़ॉर्मेटिंग अलग‑अलग चीज़ें हैं जिन्हें सत्यापित करना आवश्यक है। फ़ॉर्मेट रूपांतरण दृश्यमान परिणाम को बदल सकता है, भले ही फ़ील्ड पहचानकर्ता अभी भी मौजूद हो।