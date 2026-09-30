---
title: जावा में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मानों को पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है जिससे आप प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरुआत से तालिका बनाएं**

एक तालिका बनाएं और उसकी स्थिति, स्तंभ चौड़ाइयाँ, और पंक्ति ऊँचाइयाँ निर्दिष्ट करें। स्लाइड में जोड़ने के बाद, आप सेल बॉर्डर फ़ॉर्मेट कर सकते हैं, सेल को मर्ज कर सकते हैं, और टेक्स्ट सम्मिलित कर सकते हैं।

1. एक नया [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. बिंदुओं में कॉलम चौड़ाइयों की एक एरे निर्धारित करें।
4. बिंदुओं में पंक्ति ऊँचाइयों की एक एरे निर्धारित करें।
5. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) मेथड के माध्यम से स्लाइड में एक [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) के लिए शीर्ष, नीचे, दाएँ, और बाएँ बॉर्डर पर फ़ॉर्मेट लागू करने के लिए इटररेट करें।
7. तालिका की पहली पंक्ति के पहले दो सेल को मर्ज करें।
8. मर्ज किए गए सेल को उसके [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) मेथड से एक्सेस करें।
9. मर्ज किए गए सेल में टेक्स्ट सेट करें।
10. संशोधित प्रस्तुति सहेजें।

नीचे दिया गया उदाहरण (100, 50) बिंदु पर तीन कॉलम और पाँच पंक्तियों वाली तालिका बनाता है। यह 5 बिंदु चौड़ाई वाली लाल बॉर्डर लागू करता है, पहली पंक्ति के पहले दो सेल को मर्ज करता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, सेल इंडेक्स शून्य‑आधारित होते हैं और क्रम (स्तंभ, पंक्ति) का उपयोग करता है। पहला सेल (0, 0) के रूप में क्रमांकित होता है।

उदाहरण के लिए, 4 कॉलम और 4 पंक्तियों वाली तालिका के सेल इस प्रकार क्रमांकित हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण ऊपर दर्शायी गई 4 × 4 तालिका बनाता है, जिसमें कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ 70 बिंदु हैं और लाल सेल बॉर्डर 5 बिंदु चौड़ी है। निर्देशांक सेल इंडेक्स को दर्शाते हैं; उदाहरण सेल को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मौजूदा तालिका तक पहुंच**

तालिकाएँ स्लाइड की शेप कलेक्शन में संग्रहीत रहती हैं। शेप्स के माध्यम से इटररेट करके तालिका खोजें, फिर [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) इंटरफ़ेस का उपयोग करके उसके सेल पढ़ें या अपडेट करें।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा तालिका वाली स्लाइड का संदर्भ प्राप्त करें।
3. [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ऑब्जेक्ट्स के माध्यम से इटररेट करें और जब तालिका मिले तो रुकें। यदि स्लाइड में कई तालिकाएँ हैं, तो आवश्यक तालिका पहचानने के लिए [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) का उपयोग करें।
4. लक्षित सेल में टेक्स्ट अपडेट करें।
5. संशोधित प्रस्तुति सहेजें।

नीचे दिया गया उदाहरण `UpdateExistingTable.pptx` खोलता है और पहले स्लाइड पर पहली तालिका खोजता है। यह कॉलम 0, पंक्ति 1 के सेल को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होना चाहिए, और उस स्लाइड पर पहली तालिका में कम से कम एक कॉलम और दो पंक्तियाँ होनी चाहिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

[पंक्ति की ऊँचाई नियंत्रित करें](/slides/hi/java/manage-rows-and-columns/#control-row-height)

## **टेक्स्ट फ्रेम वाला सेल खोजें**

जब सामान्य टेक्स्ट‑प्रोसेसिंग कोड को तालिका से [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) प्राप्त होता है, तो [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) मेथड का उपयोग करके मालिक [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) प्राप्त करें। तालिका‑सेल टेक्स्ट फ्रेम के लिए, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) स्वामी लौटाता है और [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) `null` लौटाता है, भले ही तालिका स्वयं एक शेप हो।

सेल निर्देशांक रीड‑ओनली [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) और [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) मेथड्स के माध्यम से उपलब्ध हैं। [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) भी रीड‑ओनली नेविगेशन प्रदान करता है: यह स्वामी लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग से पहले हमेशा `null` की जाँच करें।

तालिका‑सेल और शेप स्वामियों की पहचान करने वाला पूर्ण उदाहरण, जिसमें स्मार्टआर्ट नोड्स से संबंधित शेप्स शामिल हैं, देखें [Search and Replace Text](/slides/hi/java/search-and-replace-text/)।

## **तालिका में टेक्स्ट संरेखित करें**

आप व्यक्तिगत तालिका सेल के वर्टिकल एंकरिंग और टेक्स्ट दिशा को नियंत्रित कर सकते हैं। इस सेक्शन का उदाहरण पहली सेल के भीतर टेक्स्ट को केंद्रित करता है और उसे 270 डिग्री घुमाता है।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) ऑब्जेक्ट एक्सेस करें।
5. पहले [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) को एक्सेस करें और उसका टेक्स्ट व रंग सेट करें।
6. सेल की वर्टिकल एंकरिंग और टेक्स्ट दिशा को [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) और [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) से सेट करें।
7. संशोधित प्रस्तुति सहेजें।

यह उदाहरण 120 बिंदु कॉलम चौड़ाइयों और 100 बिंदु पंक्ति ऊँचाइयों वाली 4 × 4 तालिका बनाता है। यह सेल (0, 0) में टेक्स्ट फ़ॉर्मेट करता है, पहली पंक्ति के शेष सेल में मान जोड़ता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

सभी सेल पर टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) का उपयोग करें। इसके ओवरलोड भाग, पैराग्राफ और टेक्स्ट फ्रेम फ़ॉर्मेटिंग को स्वीकार करते हैं, इसलिए आप व्यक्तिगत सेल पर इटररेट किए बिना इन गुणों को सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ऑब्जेक्ट एक्सेस करें।
4. टेक्स्ट के फ़ॉन्ट आकार को [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) से 25 बिंदु सेट करें।
5. पैराग्राफ एलाइनमेंट और दाएँ मार्जिन को [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) से क्रमशः सेट करें।
6. टेक्स्ट दिशा को [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) से सेट करें।
7. संशोधित प्रस्तुति सहेजें।

नीचे दिया गया उदाहरण `table.pptx` खोलता है, जिसमें कम से कम एक स्लाइड पर पहला शेप एक तालिका होना आवश्यक है। यह फ़ॉन्ट आकार को 25 बिंदु, पैराग्राफ को दाएँ-एलाइन 20 बिंदु मार्जिन के साथ सेट करता है, और टेक्स्ट को वर्टिकल बनाता है। फ़ॉर्मेट की गई प्रस्तुति को `result.pptx` के रूप में सहेजा जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

एक तालिका की प्रीसेट शैली को पढ़ने के लिए [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) का उपयोग करें और उसे असाइन करने के लिए [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) का उपयोग करें। यह उदाहरण [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) को एक तालिका पर लागू करता है, प्रीसेट वैल्यू प्रिंट करता है, और उसी प्रीसेट को दूसरी तालिका पर असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी जाती हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका का अनुपात लॉक करें**

एक तालिका का अनुपात उसकी चौड़ाई और ऊँचाई का अनुपात होता है। इस अनुपात को तालिका के लिए लॉक करने हेतु [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) का उपयोग करें।

निचे दिया गया उदाहरण `pres.pptx` खोलता है, जिसमें कम से कम एक स्लाइड पर पहला शेप एक तालिका होना आवश्यक है। यह वर्तमान लॉक स्थिति प्रिंट करता है, अनुपात लॉक को सक्षम करता है, अपडेटेड स्थिति (`true`) प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसके सेल्स के टेक्स्ट के लिए दाएं से बाएं (RTL) पढ़ने की दिशा सक्रिय कर सकता/सकती हूँ?**

हाँ। तालिका [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) मेथड प्रदान करती है, और पैराग्राफ़ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) है। दोनों का उपयोग करने से सेल्स के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

[आकार लॉक](/slides/hi/java/applying-protection-to-presentation/) का उपयोग करके मूविंग, रिसाइज़िंग, सेलेक्शन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के अंदर छवि को बैकग्राउंड के रूप में सम्मिलित करना समर्थित है?**

हाँ। आप सेल के लिए [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्टेच या टाइल) के अनुसार सेल क्षेत्र को कवर करेगी।