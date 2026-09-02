---
title: Android पर प्रस्तुतियों से आकृति के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/androidjava/shape-effective-properties/
keywords:
- आकृति गुण
- कैमरा गुण
- लाइट रिग
- बिवेल आकृति
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "जानेँ कैसे Aspose.Slides for Android को Java के माध्यम से उपयोग करके PowerPoint प्रस्तुतियों में स्थानीय, विरासत में प्राप्त, और प्रभावी आकृति फ़ॉर्मेटिंग को अलग किया जा सकता है।"
---
## **स्थानीय, विरासत में प्राप्त, और प्रभावी गुणों को समझें**

PowerPoint फ़ॉर्मेटिंग कई स्रोतों से आ सकती है। किसी ऑब्जेक्ट पर सीधे संग्रहीत मान उसका **स्थानीय मान** है। यदि वह मान सेट नहीं है, तो PowerPoint पैरेंट फ़ॉर्मेटिंग स्रोतों को देखता है, जैसे कि पैराग्राफ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रेज़ेंटेशन‑स्तर के डिफॉल्ट। उन मानों को **विरासत में प्राप्त मान** कहा जाता है। पूरी पदानुक्रम को हल करने के बाद जो मान बचता है वह **प्रभावी मान** है—ऑब्जेक्ट को रेंडर करने के लिए उपयोग किया जाने वाला मान।

उदाहरण के लिए, किसी टेक्स्ट पोर्शन में अपना फ़ॉन्ट ऊँचाई परिभाषित नहीं हो सकती। उसका स्थानीय [getFontHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) मान फिर `Float.NaN` होता है, जिसका अर्थ है "यहाँ सेट नहीं है"। पोर्शन अपनी पैराग्राफ, प्रेज़ेंटेशन की डिफ़ॉल्ट टेक्स्ट शैली, या किसी अन्य लागू स्रोत से ऊँचाई विरासत में ले सकता है। पोर्शन फ़ॉर्मेट पर [getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/#getEffective--) को कॉल करने से अंतिम हल की गई ऊँचाई प्राप्त होती है।

विभिन्न उद्देश्यों के लिए दो प्रकार के फ़ॉर्मेटिंग डेटा का उपयोग करें:

- स्थानीय फ़ॉर्मेट ऑब्जेक्ट को पढ़ें या बदलें, जैसे कि [IPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/), जब आपको यह नियंत्रित करना हो कि मान कहाँ परिभाषित है।
- एक प्रभावी डेटा ऑब्जेक्ट को पढ़ें, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformateffectivedata/), जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए। प्रभावी डेटा केवल‑पढ़ने योग्य है।

## **स्थानीय, विरासत में प्राप्त, और प्रभावी मानों की तुलना**

निम्नलिखित पूर्ण उदाहरण एक शेप बनाता है और प्रेज़ेंटेशन, पैराग्राफ, और पोर्शन स्तर पर फ़ॉन्ट ऊँचाइयों को लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों को प्रिंट करता है और उसी टेक्स्ट पोर्शन के लिए प्राप्त प्रभावी मान को दिखाता है। यह यह भी दर्शाता है कि फ़ॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को पुनः पढ़ना क्यों आवश्यक है।

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

            // दो विभिन्न स्तरों पर विरासत में प्राप्त मानों को परिभाषित करें।
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // पोर्शन पर स्थानीय मान दोनों विरासत में प्राप्त मानों को ओवरराइड करता है।
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // विरासत में प्राप्त मान को बदलने से मौजूदा स्थानीय मान ओवरराइड नहीं होता।
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // स्थानीय मान को साफ़ करें। पोर्शन अब पैराग्राफ से फिर से विरासत में प्राप्त करता है।
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // पैराग्राफ मान को साफ़ करें। प्रेज़ेंटेशन का डिफ़ॉल्ट अब परिणाम प्रदान करता है।
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

इस उदाहरण में प्राथमिकता पोर्शन स्थानीय फ़ॉर्मेटिंग, फिर पैराग्राफ फ़ॉर्मेटिंग, फिर प्रेज़ेंटेशन डिफ़ॉल्ट है। अन्य ऑब्जेक्ट्स की विरासत श्रृंखलाएँ अलग हो सकती हैं, पर सिद्धांत समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/#getEffective--) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फ़ॉर्मेटिंग कई ऑब्जेक्ट्स में विभाजित है:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#getEffective--) टेक्स्ट‑फ़्रेम गुणों को हल करता है जैसे मार्जिन, एंकरिंग, ऑटोफ़िट, और वर्टिकल टेक्स्ट डायरेक्शन।
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextstyle/#getEffective--) प्रत्येक टेक्स्ट स्टाइल स्तर के लिए पैराग्राफ फ़ॉर्मेटिंग को हल करता है।
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) पैराग्राफ गुणों को हल करता है जैसे अलाइन्मेंट, इंडेंटेशन, और बुलेट्स।
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/#getEffective--) कैरेक्टर गुणों को हल करता है जैसे फ़ॉन्ट ऊँचाई, टाइपफ़ेस, रंग, बोल्ड, और इटैलिक।

अगले उदाहरण के लिए, `text-formatting.pptx` में कम से कम एक स्लाइड और एक [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) होना चाहिए जिसमें गैर‑खाली टेक्स्ट फ्रेम हो। AutoShape शैप कलेक्शन में किसी भी स्थिति में हो सकता है; कोड एक उपयुक्त ऑब्जेक्ट खोजता है और उपयोग से पहले उसकी पुष्टि करता है।

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

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getEffective--) एक [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसके [getCamera](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), और [getBevelBottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) मेथड्स संबंधित प्रभावी डेटा को उजागर करते हैं। इन संबंधित सेटिंग्स को एक साथ पढ़ने से किसी शेप की अंतिम 3D उपस्थिति को समझना आसान हो जाता है।

इस उदाहरण के लिए, `shape-3d.pptx` की पहली स्लाइड पर कम से कम एक शेप होना चाहिए। यदि आप आउटपुट में डिफ़ॉल्ट के अलावा अन्य मान चाहते हैं, तो उस शेप पर 3D कैमरा, लाइटिंग, या बिवेल सेटिंग्स लागू करें।

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

## **प्रभावी टेबल फ़ॉर्मेटिंग प्राप्त करें**

टेबल फ़ॉर्मेटिंग टेबल स्टाइल से और पूरे टेबल, कॉलम, रो, या व्यक्तिगत सेल पर लागू फ़ॉर्मेट से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स के बीच संघर्षों में प्राथमिकता सेल, रो, कॉलम, और फिर पूरी टेबल होती है। किसी सेल का प्रभावी फ़ॉर्मेट वह अंतिम फ़ॉर्मेट है जो उस सेल को ड्रॉ करने के लिए उपयोग किया जाता है।

इस उदाहरण के लिए, `table-formatting.pptx` की पहली स्लाइड पर कम से कम एक टेबल होना चाहिए। टेबल में कम से कम एक रो और एक कॉलम होना चाहिए। कोड यह मानने के बजाय कि `getShapes().get_Item(0)` टेबल है, एक [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itable/) खोजता है।

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

यदि आपको केवल फ़िल टाइप के बजाय रंग चाहिए, तो पहले प्रभावी [getFillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) जांचें, और फिर उस टाइप के लिए लागू मेथड पढ़ें—उदाहरण के लिए, सॉलिड फ़िल के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--)।

## **परिवर्तनों के बाद प्रभावी डेटा को पुनः पढ़ें**

प्रभावी डेटा उस समय के फ़ॉर्मेटिंग पदानुक्रम को वर्णित करता है जब इसे हल किया जाता है। किसी भी ऐसी चीज़ को बदलने के बाद `getEffective` को फिर से कॉल करें जो उस पदानुक्रम में भाग ले सकती है, जिसमें शामिल हैं:
- ऑब्जेक्ट का स्थानीय फ़ॉर्मेटिंग;
- पैराग्राफ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट;
- एक टेबल स्टाइल, टेबल, कॉलम, रो, या सेल फ़ॉर्मेट;
- लेआउट या मास्टर स्लाइड फ़ॉर्मेटिंग;
- थीम डेटा या प्रेज़ेंटेशन‑स्तर के डिफ़ॉल्ट;
- स्लाइड को असाइन किया गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद का `getEffective` कॉल उस डेटा को रीफ़्रेश कर सकता है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो परिवर्तन करने से पहले आवश्यक स्कैलर मानों—जैसे फ़ॉन्ट ऊँचाई, रंग, अलाइन्मेंट, या बिवेल चौड़ाई—को अपनी वेरिएबल्स में कॉपी कर लें।

किसी मान को बदलने के लिए, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर परिणाम सत्यापित करने के लिए `getEffective` कॉल करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने योग्य होते हैं।

## **FAQ**

**मैं कैसे पता करूँ कि किस स्तर ने प्रभावी मान प्रदान किया?**

प्रभावी डेटा अंतिम मान को रखता है, उसका स्रोत नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स की जाँच करें। टेक्स्ट के लिए यह पोर्शन, पैराग्राफ, टेक्स्ट‑फ़्रेम, लेआउट, मास्टर, थीम, और प्रेज़ेंटेशन डिफ़ॉल्ट शामिल हो सकते हैं। `Float.NaN` या `null` जैसे अनिर्धारित मान दर्शाते हैं कि खोज आगे किसी अन्य स्तर पर जारी रहती है।

**यदि कोई स्तर प्रॉपर्टी परिभाषित नहीं करता तो क्या होता है?**

Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखाई देता है यद्यपि कोई स्थानीय ऑब्जेक्ट स्पष्ट रूप से इसे परिभाषित नहीं करता।

**कभी-कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**

स्थानीय मान विरासत गणना में जीत गया। यह तब अपेक्षित है जब प्रॉपर्टी ऑब्जेक्ट पर स्पष्ट रूप से सेट की गई हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड नहीं करता।

**मुझे प्रभावी डेटा के बजाय स्थानीय डेटा कब उपयोग करना चाहिए?**

स्थानीय डेटा का उपयोग किसी विशिष्ट फ़ॉर्मेटिंग स्तर को देखना या संपादित करना हो तो करें। प्रभावी डेटा का उपयोग तब करें जब आपको विरासत, थीम नियम, और लागू स्टाइल्स को हल करने के बाद का अंतिम रूप चाहिए। [पूर्ण तुलना उदाहरण](#compare-local-inherited-and-effective-values) दोनों को एक ही वर्कफ़्लो में दर्शाता है।