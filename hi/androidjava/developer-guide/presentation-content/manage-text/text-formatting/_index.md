---
title: Android पर प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/androidjava/text-formatting/
keywords:
- हाइलाइट टेक्स्ट
- रेगुलर एक्सप्रेशन
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट बैकग्राउंड
- टेक्स्ट पारदर्शिता
- कैरेक्टर स्पेसिंग
- फ़ॉन्ट प्रॉपर्टीज़
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटॉफ़िट प्रॉपर्टी
- टेक्स्ट फ्रेम एँकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **परिचय**

यह लेख Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने के तरीकों को दर्शाता है। इसमें हाइलाइटिंग, बैकग्राउंड रंग, ट्रांसपेरेंसी, कैरेक्टर स्पेसिंग, फ़ॉन्ट प्रॉपर्टीज़, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एँकरिंग, टैब स्टॉप्स और भाषा सेटिंग्स शामिल हैं।

नीचे के उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का प्रयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है और वह निम्नलिखित टेक्स्ट रखता है:

![उदाहरण टेक्स्ट](sample_text.png)

## **हाइलाइट टेक्स्ट**

जब आपको टेक्स्ट फ्रेम के भीतर किसी विशिष्ट नमूने से मेल खाने वाले टेक्स्ट को हाइलाइट करना हो, तो [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) मेथड का उपयोग करें। यह मेथड मिलते हुए टेक्स्ट फ्रैगमेंट्स पर हाइलाइट रंग लागू करता है और इसे [ITextSearchOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextSearchOptions) के साथ उपयोग करके खोज के तरीके को नियंत्रित किया जा सकता है, उदाहरण के लिए केवल पूरे शब्दों को मिलाना।

निचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // पहले स्लाइड से पहला आकार प्राप्त करें।
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // आकार में शब्द "try" को हाइलाइट करें।
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // आकार में शब्द "to" को हाइलाइट करें।
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![हाइलाइट किया हुआ टेक्स्ट](highlighted_text.png)

## **रेगुलर एक्सप्रेशन का उपयोग करके हाइलाइट टेक्स्ट**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) मेथड रेगुलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मैच को हाइलाइट करता है।

निचे दिया गया कोड उदाहरण उन सभी शब्दों को हाइलाइट करता है जिनमें **सात या अधिक अक्षर** होते हैं:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // सात या अधिक अक्षरों वाले सभी शब्दों को हाइलाइट करें।
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![रेगुलर एक्सप्रेशन से हाइलाइट किया हुआ टेक्स्ट](highlighted_text_using_regex.png)

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट पोर्शन के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) का उपयोग करें।

निचे दिया गया कोड उदाहरण **पूरा पैराग्राफ** के बैकग्राउंड रंग को सेट करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

निचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट पोर्शन** के बैकग्राउंड रंग को सेट करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट पोर्शन के लिए हाइलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे टेक्स्ट पोर्शन](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) का उपयोग करें। मान मध्य (center), बायाँ (left), दायाँ (right), न्यायसंगत (justify) आदि हो सकते हैं।

निचे दिया गया कोड उदाहरण पैराग्राफ को **केंद्रीय** रूप में संरेखित करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट के लिए ट्रांसपेरेंसी सेट करें**

ट्रांसपेरेंसी को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) पर सेट किए गए रंग के अल्फ़ा घटक द्वारा नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` ARGB अल्फ़ा‑चैनल मान है जो 0‑255 स्केल में है, प्रतिशत नहीं।

निचे दिया गया कोड उदाहरण **पूरे पैराग्राफ** पर ट्रांसपेरेंसी लागू करता है:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // टेक्स्ट के फ़िल रंग को पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ट्रांसपेरेंट पैराग्राफ](transparent_paragraph.png)

निचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट पोर्शन** पर ट्रांसपेरेंसी लागू करता है:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट पोर्शन की पारदर्शिता सेट करें।
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ट्रांसपेरेंट टेक्स्ट पोर्शन](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को विस्तारित या घटाने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) का उपयोग करें।

निचे दिया गया जावा कोड **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग को विस्तारित करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // कैरेक्टर स्पेसिंग बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

निचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट पोर्शन** में कैरेक्टर स्पेसिंग को विस्तारित करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // कैरेक्टर स्पेसिंग बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट पोर्शन में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint के मुकाबले थोड़ा टाइट दिख सकता है। यह इसलिए होता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में आप प्रभावित फ़ॉन्ट वाले टेक्स्ट पोर्शन के लिए केरनिंग अक्षम कर सकते हैं। [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह सेटिंग मिलते हुए टेक्स्ट पोर्शन पर केरनिंग को लागू होने से रोकती है और Aspose.Slides के रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में सहायक होती है।

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ को प्रबंधित करें**

फ़ॉन्ट प्रॉपर्टीज़ को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) या व्यक्तिगत पोर्शन पर [IPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortionFormat) के माध्यम से सेट किया जा सकता है।

निचे दिया गया कोड पूरी पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट स्टाइल सेट करता है: यह फ़ॉन्ट साइज, बोल्ड, इटैलिक, डॉटेड अंडरलाइन और Times New Roman फ़ॉन्ट को सभी पोर्शन पर लागू करता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ के लिए फ़ॉन्ट प्रॉपर्टीज़ सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_paragraph.png)

निचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट पोर्शन** के लिए समान प्रॉपर्टीज़ लागू करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट पोर्शन के लिए फ़ॉन्ट प्रॉपर्टीज़ सेट करें।
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट पोर्शन के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

शेप के भीतर निर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) का उपयोग करें।

निचे दिया गया कोड उदाहरण टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जिससे टेक्स्ट **90 डिग्री एंटी‑क्लॉकवाइज़** घुम जाता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम्स के लिए कस्टम रोटेशन सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame) के लिए कस्टम रोटेशन कोण सेट किया जा सकता है।

निचे दिया गया कोड उदाहरण शेम के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमाता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) द्वारा पैराग्राफ स्पेसिंग को नियंत्रित करता है। इन प्रॉपर्टीज़ का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* पॉइंट में लाइन स्पेसिंग निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निचे दिया गया कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग निर्दिष्ट करता है:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम्स के लिए ऑटॉफ़िट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) निर्धारित करता है कि जब टेक्स्ट कंटेनर की सीमा से बाहर हो तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप तय कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो करे, या आकार में स्वचालित रूप से सम्मिलित हो।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ्रेम्स का एँकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) परिभाषित करता है कि टेक्स्ट को शेप के भीतर ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, उदाहरण के लिए शीर्ष, मध्य या तल पर।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ में टैब स्टॉप्स को कॉन्फ़िगर करने के लिए [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) का उपयोग करें।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप टेक्स्ट पोर्शन के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निचे दिया गया कोड उदाहरण टेक्स्ट पोर्शन के लिए प्रूफ़िंग भाषा सेट करता है:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // प्रूफ़िंग भाषा का ID सेट करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है।

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले पोर्शन की भाषा जाँचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--) का उपयोग करें।

निचे दिया गया कोड उदाहरण नई प्रस्तुति में सभी स्लाइड्स के लिए डिफ़ॉल्ट बोल्ड फ़ॉन्ट, 14 pt आकार लागू करता है।

```java
Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर के पैराग्राफ फ़ॉर्मेट प्राप्त करें।
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides से ऐसा टेक्स्ट पोर्शन निकालते हैं, तो लाइब्रेरी टेक्स्ट को बिल्कुल वैसे ही वापस देती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextCapType) की जाँच करें और यदि मान `All` हो तो प्राप्त स्ट्रिंग को अपरकेस में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल‑कैप्स इफ़ेक्ट](all_caps_effect.png)

निचे दिया गया कोड उदाहरण **ऑल‑कैप्स** इफ़ेक्ट लागू किए हुए टेक्स्ट को निकालता है:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड पर टेबल में टेक्स्ट कैसे संशोधित करें?**

स्लाइड पर टेबल में टेक्स्ट संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) का उपयोग करें। सेल्स में इटररेट करके प्रत्येक सेल को [ICell.getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICell#getTextFrame--) और पैराग्राफ फॉर्मेट को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--) द्वारा अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FillType) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा ट्रांसपेरेंसी को कॉन्फ़िगर करें।