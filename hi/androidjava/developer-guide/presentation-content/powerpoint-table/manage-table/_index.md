---
title: Android पर प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/androidjava/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुँचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपनी तालिका कार्यप्रवाह को सरल बनाने के लिए सरल Java कोड उदाहरणों की खोज करें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मान पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides प्रदान करता है [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार ताकि आप प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकें।

## **शुरुआत से एक तालिका बनाएं**

स्थिति, स्तंभ चौड़ाई और पंक्ति ऊँचाई निर्दिष्ट करके एक तालिका बनाएं। स्लाइड में जोड़ने के बाद, आप कोशिका सीमाओं को स्वरूपित कर सकते हैं, कोशिकाओं को मिलाने और पाठ सम्मिलित करने का काम कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. पॉइंट में स्तंभ चौड़ाई की एक एरे परिभाषित करें।
4. पॉइंट में पंक्ति ऊँचाई की एक एरे परिभाषित करें।
5. स्लाइड में [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ऑब्जेक्ट को [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) मेथड के माध्यम से जोड़ें।
6. प्रत्येक [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) पर इटरेंट करके शीर्ष, नीचे, दाएँ और बाएँ सीमाओं के लिए स्वरूपण लागू करें।
7. तालिका की पहली पंक्ति की पहली दो कोशिकाओं को मिलाएं।
8. मर्ज की गई कोशिका को उसके [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) मेथड के द्वारा एक्सेस करें।
9. मर्ज की गई कोशिका में टेक्स्ट सेट करें।
10. संशोधित प्रस्तुति को सहेजें।

निम्न उदाहरण तीन स्तंभ और पाँच पंक्तियों वाली तालिका (100, 50) पॉइंट पर बनाता है। यह 5 पॉइंट की चौड़ाई वाले लाल सीमाएं लागू करता है, पहली पंक्ति की पहली दो कोशिकाओं को मिलाता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

एक मानक तालिका में, कोशिका सूचकांक शून्य-आधारित होते हैं और क्रम (स्तंभ, पंक्ति) का उपयोग करते हैं। पहली कोशिका का सूचकांक (0, 0) है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका में कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण ऊपर दिखाए गए 4 × 4 तालिका को बनाता है, जिसमें स्तंभ चौड़ाई और पंक्ति ऊँचाई 70 पॉइंट है तथा लाल कोशिका सीमाएँ 5 पॉइंट की चौड़ाई वाली हैं। निर्देशांक कोशिका सूचकांक दर्शाते हैं; उदाहरण कोशिकाओं को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **मौजूदा तालिका तक पहुँचें**

तालिकाएँ स्लाइड के shape संग्रह में संग्रहीत होती हैं। shape में इटरेट करके तालिका खोजें, फिर [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) इंटरफ़ेस का उपयोग करके उसकी कोशिकाओं को पढ़ें या अपडेट करें।

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा उस स्लाइड का संदर्भ प्राप्त करें जिसमें तालिका है।
3. [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ऑब्जेक्ट्स पर इटरेट करें और तालिका मिलने पर रोकें। यदि स्लाइड में कई तालिकाएँ हैं, तो आवश्यक तालिका पहचानने के लिए [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) का उपयोग करें।
4. लक्ष्य कोशिका में टेक्स्ट अपडेट करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्न उदाहरण `UpdateExistingTable.pptx` खोलता है और पहले स्लाइड पर पहली तालिका खोजता है। यह स्तंभ 0, पंक्ति 1 की कोशिका को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होनी चाहिए, और उस स्लाइड की पहली तालिका में कम से कम एक स्तंभ और दो पंक्तियाँ होनी चाहिए।

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

वर्तमान फ़ाइल में तालिका की पंक्ति को पुन: आकार देने और समझने के लिए कि वास्तविक ऊँचाई अनुरोधित न्यूनतम से अधिक क्यों हो सकती है, देखें [पंक्ति ऊँचाई नियंत्रित करें](/slides/hi/androidjava/manage-rows-and-columns/#control-row-height)।

## **टेक्स्ट फ्रेम वाले सेल को खोजें**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से एक [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) प्राप्त होता है, तो स्वामी [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) को प्राप्त करने के लिए [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) मेथड का उपयोग करें। तालिका-सेल टेक्स्ट फ्रेम के लिए, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) स्वामी लौटाता है और [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` लौटाता है, भले ही तालिका स्वयं एक shape हो।

कोशिका निर्देशांक [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) और [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) पढ़ने-केवल मेथड्स द्वारा उपलब्ध हैं। [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) भी पढ़ने-केवल नेविगेशन प्रदान करता है: यह स्वामी को लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा लौटाई गई कोशिका को `null` के लिए जाँचें।

एक पूर्ण उदाहरण के लिए जो तालिका-सेल और shape स्वामियों की पहचान करता है, जिसमें SmartArt नोड्स से जुड़े shape शामिल हैं, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/androidjava/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

आप व्यक्तिगत तालिका कोशिकाओं के वर्टिकल एंकरिंग और टेक्स्ट दिशा को नियंत्रित कर सकते हैं। इस अनुभाग का उदाहरण पहली कोशिका के भीतर टेक्स्ट को केंद्रित करता है और उसे 270 डिग्री घुमाता है।

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) ऑब्जेक्ट प्राप्त करें।
5. पहले [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) को एक्सेस करें और उसका टेक्स्ट तथा रंग सेट करें।
6. [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) और [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) का उपयोग करके कोशिका की वर्टिकल एंकरिंग और टेक्स्ट दिशा सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण 120 पॉइंट स्तंभ चौड़ाई और 100 पॉइंट पंक्ति ऊँचाई वाली 4 × 4 तालिका बनाता है। यह कोशिका (0, 0) में टेक्स्ट को स्वरूपित करता है, पहली पंक्ति की शेष कोशिकाओं में मान जोड़ता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मैट सेट करें**

[setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) का उपयोग करके आप तालिका की सभी कोशिकाओं पर टेक्स्ट फ़ॉर्मैट लागू कर सकते हैं। इसके ओवरलोड्स भाग, पैराग्राफ और टेक्स्ट फ्रेम फ़ॉर्मैटिंग स्वीकार करते हैं, इसलिए आप व्यक्तिगत कोशिकाओं पर इटरेट किए बिना इन गुणों को सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ऑब्जेक्ट एक्सेस करें।
4. टेक्स्ट के लिए [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करके फ़ॉन्ट आकार सेट करें।
5. [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) का उपयोग करके पैराग्राफ संरेखण और दाएँ मार्जिन सेट करें।
6. [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करके टेक्स्ट दिशा सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

निम्न उदाहरण `table.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहली shape तालिका हो। यह फ़ॉन्ट आकार को 25 पॉइंट, पैराग्राफ को दाएँ संरेखित 20 पॉइंट दाएँ मार्जिन के साथ सेट करता है, और टेक्स्ट को वर्टिकल बनाता है। स्वरूपित प्रस्तुति `result.pptx` के रूप में सहेजी जाती है।

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

[getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) का उपयोग करके आप तालिका की प्रीसेट शैली पढ़ सकते हैं और [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) से उसे असाइन कर सकते हैं। यह उदाहरण एक तालिका पर [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) लागू करता है, प्रीसेट मान को प्रिंट करता है, और वही प्रीसेट दूसरी तालिका पर असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी जाती हैं।

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

एक तालिका का अनुपात उसकी चौड़ाई और ऊँचाई का अनुपात होता है। इस अनुपात को तालिका के लिए लॉक करने हेतु [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) का उपयोग करें।

निम्न उदाहरण `pres.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहली shape तालिका हो। यह वर्तमान लॉक स्थिति को प्रिंट करता है, अनुपात लॉक सक्षम करता है, अपडेटेड स्थिति (`true`) को प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

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

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ-से-बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) होता है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

[shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) का उपयोग करके स्थानांतरित, आकार बदलने, चयन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या कोशिका के अंदर पृष्ठभूमि के रूप में छवि डालना समर्थित है?**

हां। आप एक कोशिका के लिए [पिक्चर फिल](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रैच या टाइल) के अनुसार कोशिका क्षेत्र को कवर कर देगी।