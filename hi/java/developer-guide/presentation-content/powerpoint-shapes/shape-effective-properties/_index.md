---
title: जावा में प्रस्तुतियों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/java/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- प्रकाश व्यवस्था
- बिवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट शैली
- फ़ॉन्ट ऊँचाई
- भराव स्वरूप
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में स्थानीय, विरासत और प्रभावी आकार फ़ॉर्मेटिंग को कैसे अलग करें, सीखें।"
---
## **स्थानीय, विरासत और प्रभावी गुण समझें**

PowerPoint फ़ॉर्मेटिंग कई स्थानों से आ सकती है। किसी ऑब्जेक्ट पर सीधे संग्रहीत मान उसका **स्थानीय मान** है। यदि वह मान सेट नहीं है, तो PowerPoint पैराग्राफ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रेजेंटेशन‑स्तर डिफ़ॉल्ट जैसे पैरेंट फ़ॉर्मेटिंग स्रोतों को देखता है। इन मानों को **विरासत मान** कहा जाता है। पूरी पदानुक्रम को हल करने के बाद जो मान बचता है वह **प्रभावी मान** है—ऑब्जेक्ट को रेंडर करने के लिए उपयोग किया जाने वाला मान।

उदाहरण के लिए, किसी टेक्स्ट पोर्शन में फ़ॉन्ट ऊँचाई परिभाषित नहीं हो सकती। उसका स्थानीय [getFontHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) मान `Float.NaN` होता है, जिसका अर्थ है “यहाँ सेट नहीं है।” पोर्शन अपनी पैराग्राफ, प्रेजेंटेशन के डिफ़ॉल्ट टेक्स्ट स्टाइल, या अन्य उपयुक्त स्रोत से ऊँचाई विरासत में ले सकता है। पोर्शन फ़ॉर्मेट पर [getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/#getEffective--) को कॉल करने से अंतिम हल की गई ऊँचाई मिलती है।

दो प्रकार के फ़ॉर्मेटिंग डेटा का विभिन्न उद्देश्यों के लिए उपयोग करें:

- स्थानीय फ़ॉर्मेट ऑब्जेक्ट, जैसे [IPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/), पढ़ें या बदलें, जब आपको यह नियंत्रित करना हो कि मान कहाँ परिभाषित है।
- प्रभावी डेटा ऑब्जेक्ट, जैसे [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformateffectivedata/), पढ़ें, जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए। प्रभावी डेटा केवल पढ़ने‑के‑लिए है।

## **स्थानीय, विरासत और प्रभावी मानों की तुलना करें**

निम्न पूर्ण उदाहरण एक शAPE बनाता है और प्रेजेंटेशन, पैराग्राफ और पोर्शन स्तर पर फ़ॉन्ट ऊँचाइयाँ लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों और उसी टेक्स्ट पोर्शन के परिणामस्वरूप प्रभावी मान को प्रिंट करता है। यह यह भी दर्शाता है कि फ़ॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // दो विभिन्न स्तरों पर विरासत मान निर्धारित करें।
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // पोर्शन पर स्थानीय मान दोनों विरासत मानों को अधिच्छादित करता है।
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // विरासत मान को बदलने से मौजूदा स्थानीय मान नहीं बदलता।
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // स्थानीय मान को साफ़ करें। पोर्शन अब फिर से पैराग्राफ से विरासत में लेता है।
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // पैराग्राफ मान को साफ़ करें। प्रस्तुति का डिफ़ॉल्ट अब परिणाम प्रदान करता है।
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // पिछले परिवर्तनों के बाद प्रभावी डेटा पढ़ें।
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

इस उदाहरण में प्राथमिकता पोर्शन स्थानीय फ़ॉर्मेटिंग, फिर पैराग्राफ फ़ॉर्मेटिंग, फिर प्रेजेंटेशन डिफ़ॉल्ट है। अन्य ऑब्जेक्ट्स की विरासत श्रृंखलाएँ अलग हो सकती हैं, लेकिन सिद्धांत समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/#getEffective--) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फ़ॉर्मेटिंग कई ऑब्जेक्ट्स में विभाजित होती है:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#getEffective--) मार्जिन, एंकरिंग, ऑटॉफिट और वर्टिकल टेक्स्ट दिशा जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextstyle/#getEffective--) प्रत्येक टेक्स्ट स्टाइल स्तर के लिए पैराग्राफ फ़ॉर्मेटिंग को हल करता है।
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getEffective--) संरेखण, इंडेंटेशन और बुलेट जैसे पैराग्राफ गुणों को हल करता है।
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/#getEffective--) फ़ॉन्ट ऊँचाई, टाइपफेस, रंग, बोल्ड और इटैलिक जैसे कैरेक्टर गुणों को हल करता है।

अगले उदाहरण के लिए, `text-formatting.pptx` में कम से कम एक स्लाइड और एक [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जिसमें गैर‑खाली टेक्स्ट फ़्रेम हो, होना चाहिए। AutoShape शAPE संग्रह में किसी भी स्थान पर हो सकता है; कोड उपयुक्त ऑब्जेक्ट खोजता है और उपयोग से पहले उसकी पुष्टि करता है।

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **प्रभावी 3D गुण प्राप्त करें**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getEffective--) एक [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformateffectivedata/) ऑब्जेक्ट लौटाता है जो सभी हल की गई 3D सेटिंग्स को समूहित करता है। इसके [getCamera](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), और [getBevelBottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) मेथड्स संबंधित प्रभावी डेटा को उजागर करते हैं। इन संबंधित सेटिंग्स को साथ में पढ़ने से शAPE के अंतिम 3D रूप को समझना आसान हो जाता है।

इस उदाहरण के लिए, `shape-3d.pptx` में पहली स्लाइड पर कम से कम एक शAPE होना चाहिए। यदि आप डिफ़ॉल्ट के अलावा किसी मान को देखना चाहते हैं तो उस शAPE पर 3D कैमरा, लाइटिंग या बेवल सेटिंग लागू करें।

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **प्रभावी तालिका फ़ॉर्मेटिंग प्राप्त करें**

तालिका फ़ॉर्मेटिंग तालिका शैली और पूरी तालिका, कॉलम, पंक्ति या व्यक्तिगत सेल पर लागू फ़ॉर्मेट्स से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स के बीच संघर्ष में प्राथमिकता सेल, पंक्ति, कॉलम, और फिर पूरी तालिका की होती है। किसी सेल का प्रभावी फ़ॉर्मेट वह अंतिम फ़ॉर्मेट है जो सेल को ड्रॉ करने के लिए उपयोग किया जाता है।

इस उदाहरण के लिए, `table-formatting.pptx` में पहली स्लाइड पर कम से कम एक तालिका होनी चाहिए। तालिका में कम से कम एक पंक्ति और एक कॉलम होना चाहिए। कोड एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itable/) को खोजता है, यह मानते हुए कि `getShapes().get_Item(0)` तालिका है, यह न मानकर।

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

यदि आपको केवल फ़िल टाइप नहीं बल्कि रंग चाहिए, तो पहले प्रभावी [getFillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) की जांच करें, और फिर उस टाइप के अनुरूप मेथड पढ़ें—उदाहरण के लिए, सॉलिड फ़िल के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--)।

## **परिवर्तनों के बाद प्रभावी डेटा को पुनः पढ़ें**

प्रभावी डेटा वह फ़ॉर्मेटिंग पदानुक्रम दर्शाता है जो उस समय हल किया गया था। किसी भी चीज़ को बदलने के बाद `getEffective` को फिर से कॉल करें जो उस पदानुक्रम में भाग लेती है, जिसमें शामिल हैं:

- ऑब्जेक्ट का स्थानीय फ़ॉर्मेट;
- पैराग्राफ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट;
- तालिका शैली, तालिका, कॉलम, पंक्ति या सेल फ़ॉर्मेट;
- लेआउट या मास्टर स्लाइड फ़ॉर्मेट;
- थीम डेटा या प्रेजेंटेशन‑स्तर डिफ़ॉल्ट;
- स्लाइड को असाइन किया गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद का `getEffective` कॉल वह डेटा रीफ़्रेश कर सकता है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो आवश्यक स्केलर मानों—जैसे फ़ॉन्ट ऊँचाई, रंग, संरेखण या बेवल चौड़ाई—को बदलाव करने से पहले अपनी स्वयं की वेरिएबल्स में कॉपी कर लें।

किसी मान को बदलने के लिए, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर `getEffective` को कॉल करके परिणाम सत्यापित करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने‑के‑लिए होते हैं।

## **FAQ**

**मैं कैसे पता करूँ कि कौन सा स्तर प्रभावी मान प्रदान करता है?**

प्रभावी डेटा अंतिम मान रखता है, उसके स्रोत को नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स का निरीक्षण करें। टेक्स्ट के लिए यह पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम, लेआउट, मास्टर, थीम और प्रेजेंटेशन डिफ़ॉल्ट शामिल कर सकता है। अपरिभाषित मान जैसे `Float.NaN` या `null` संकेत देते हैं कि खोज अगले स्तर पर जारी रहती है।

**जब कोई स्तर किसी प्रॉपर्टी को परिभाषित नहीं करता तो क्या होता है?**

Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखाई देता है, भले ही किसी स्थानीय ऑब्जेक्ट ने इसे स्पष्ट रूप से परिभाषित न किया हो।

**कभी कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**

स्थानीय मान ने विरासत गणना में जीत हासिल की हो। यह तब अपेक्षित है जब प्रॉपर्टी ऑब्जेक्ट पर स्पष्ट रूप से सेट की गई हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड न करता हो।

**कब मुझे प्रभावी डेटा के बजाय स्थानीय डेटा उपयोग करना चाहिए?**

स्थानीय डेटा का उपयोग किसी विशिष्ट फ़ॉर्मेटिंग स्तर को निरीक्षण या संपादित करने के लिए करें। प्रभावी डेटा का उपयोग तब करें जब आपको विरासत, थीम नियम और लागू स्टाइल्स के बाद अंतिम रूप चाहिए। [पूर्ण तुलना उदाहरण](#compare-local-inherited-and-effective-values) दोनों को एक ही वर्कफ़्लो में प्रदर्शित करता है।