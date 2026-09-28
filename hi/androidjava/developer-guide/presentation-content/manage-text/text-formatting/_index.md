---
title: Android पर प्रस्तुति टेक्स्ट फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/androidjava/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- पंक्ति अंतराल
- ऑटोफिट प्रॉपर्टी
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **Overview**

यह लेख दिखाता है कि Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट का फॉर्मेट कैसे किया जाए। इसमें बैकग्राउंड रंग, ट्रांसपरेंसी, कैरेक्टर स्पेसिंग, फ़ॉन्ट प्रॉपर्टीज़, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स, और भाषा सेटिंग्स शामिल हैं।

यदि अन्यथा उल्लेख न किया गया हो, तो उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। पहले स्लाइड पर पहला शेप टेक्स्ट बॉक्स है, और उसकी पहली पैराग्राफ में नीचे दिखाया गया टेक्स्ट है। स्लाइड और शेप दोनों के इंडेक्स शून्य-आधारित हैं। बोल्ड भागों को चुनने वाले उदाहरण प्रभावी फॉर्मेटिंग, जिसमें विरासत में मिले बोल्ड फॉर्मेटिंग शामिल है, का उपयोग करते हैं:

![Sample text](sample_text.png)

लिटरल टेक्स्ट या रेगुलर एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए, देखें [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/)।

## **Set Text Background Color**

डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए पैराग्राफ के लिए [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट पोर्शन के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण प्रथम पैराग्राफ के लिए डिफ़ॉल्ट रूप में हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत पोर्शन पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The gray paragraph](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट पोर्शन** के लिए बैकग्राउंड रंग सेट करने को दिखाता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![The gray text portions](gray_text_portions.png)

## **Align Text Paragraphs**

टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparaphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बाएँ-संरेखित, दाएँ-संरेखित, जस्टिफ़ाइड आदि हो सकते हैं।

निम्न कोड उदाहरण **केंद्र** में पैराग्राफ को संरेखित करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ की संरेखण को केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The aligned paragraph](aligned_paragraph.png)

## **Set Transparency for Text**

टेक्स्ट ट्रांसपरेंसी को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) को असाइन किए गए रंग के अल्फा कॉम्पोनेंट के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मूल्य है, प्रतिशत नहीं।

निम्न कोड उदाहरण पूरे **पैराग्राफ** पर ट्रांसपरेंसी लागू करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // टेक्स्ट का भरने वाला रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The transparent paragraph](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट पोर्शन** पर ट्रांसपरेंसी लागू करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![The transparent text portions](transparent_text_portions.png)

## **Set Character Spacing for Text**

टेक्स्ट बॉक्स में कैरेक्टर्स के बीच स्पेसिंग को बढ़ाने या घटाने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें। उदाहरण 3 पॉइंट की स्पेसिंग जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकरी करते हैं।

निम्न Java कोड **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग को विस्तारित करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ध्यान दें: चरित्र अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट पोर्शन** में कैरेक्टर स्पेसिंग को विस्तारित करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: चरित्र अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक कसकर दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी मौजूद हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट पोर्शन के लिए केरनिंग को निष्क्रिय कर सकते हैं। [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण "presentation.pptx" को आवश्यक मानता है जिसमें पहली स्लाइड पर पहला शेप टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) की जाँच करता है और Roboto फ़ॉन्ट वाले पोर्शन के लिए 100‑पॉइंट थ्रेशहोल्ड सेट करता है। इससे 100 पॉइंट से छोटे फ़ॉन्ट आकार वाले मिलते-जुलते पोर्शन के लिए केरनिंग निष्क्रिय हो जाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

थ्रेशहोल्ड से नीचे वाले टेक्स्ट के लिए, यह सेटिंग केरनिंग को रोकती है और Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ अधिक मेल खाने में मदद कर सकती है।

## **Manage Text Font Properties**

फ़ॉन्ट प्रॉपर्टीज़ को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत पोर्शन पर [IPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन फॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत पोर्शन पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक फॉर्मेटिंग और डॉटेड अंडरलाइन को उन पोर्शन पर लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट पोर्शन के लिए फ़ॉन्ट गुण सेट करें।
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Set Text Rotation**

शेप के भीतर एक पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री घड़ी की विपरीत दिशा** में घुमाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The text rotation](text_rotation.png)

## **Set Custom Rotation for Text Frames**

एक [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) के लिए कस्टम रोटेशन एंगल सेट करने के लिए [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करें।

निम्न कोड उदाहरण शेप के भीतर टेक्स्ट फ्रेम को 3 डिग्री clockwise घुमाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The custom text rotation](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) का उपयोग करके पैराग्राफ स्पेसिंग को नियंत्रित करता है। इन प्रॉपर्टीज़ का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ की भीतर की स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The line spacing within the paragraph](line_spacing.png)

## **Control Line Breaking**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉक्स और लैटिन व ईस्ट एशियन टेक्स्ट के मिश्रण वाले प्रस्तुतियों में उपयोगी होते हैं। निम्न मेथड्स [IParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से आस-पास के ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैप भी बदल सकते हैं।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में कैरेक्टर्स पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर नहीं डालते। एक स्पष्ट लाइन ब्रेक पैराग्राफ के भीतर उपलब्ध चौड़ाई की परवाह किए बिना नई लाइन बनाता है।

निम्न स्वायत्त उदाहरण चाइनीज़ और लैटिन टेक्स्ट वाला संकरी टेक्स्ट ब्लॉक बनाता है। दोनों लाइन‑ब्रेकिंग विकल्प स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को प्रयोग करने के लिए, अन्य सेटिंग को स्थिर रखते हुए संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग 160‑पॉइंट फ्रेम चौड़ाई और शून्य-horizontal टेक्स्ट‑फ़्रेम मार्जिन के साथ करता है। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textautofittype/) के साथ बुलाया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Control Hanging Punctuation**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) योग्य विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे से बाहर तक विस्तारित होने की अनुमति देता है, बजाय अगले लाइन में ले जाने के। यह पूरे पैराग्राफ पर लागू होता है और हेंगिंग इंडेंट से अलग है।

निम्न स्वायत्त उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हेंगिंग पंक्चरशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य-horizontal टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग लाइन में आता है। रैपिंग सक्षम है और ऑटोफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सभी विराम चिह्न हेंग नहीं सकते। दृश्य परिणाम फ़ॉन्ट उपलब्धता और लेआउट पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफिट सेटिंग बदलने से दिखाई देने वाला अंतर हट सकता है।

## **Set Autofit Type for Text Frames**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि कंटेनर की सीमाओं से टेक्स्ट बाहर जाने पर उसका व्यवहार कैसे रहेगा। इसका उपयोग टेक्स्ट को सिकुड़ने, ओवरफ़्लो होने, या शेप को स्वतः आकार बदलने के लिए नियंत्रित करने के लिए किया जाता है। निम्न उदाहरण शेप को उसके टेक्स्ट के अनुसार रिसाइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्वचालित रैपिंग के बाद लाइनों की संख्या गिनने और देखना कि टेक्स्ट या शेप की चौड़ाई परिणाम को कैसे बदलती है, के लिए देखें [Count Rendered Lines](/slides/hi/androidjava/manage-paragraph/)。 केवल लाइन काउंट यह दर्शाता नहीं कि टेक्स्ट कंटेनर से बाहर तो नहीं जा रहा।

## **Set Anchor of Text Frames**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) यह निर्धारित करता है कि टेक्स्ट शेप के भीतर लंबवत कैसे स्थित हो, उदाहरण के लिए शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले शेप के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Tabulation**

पैराग्राफ में टैब स्टॉप्स कॉन्फ़िगर करने के लिए [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The paragraph tabs](paragraph_tabs.png)

## **Set Proofing Language**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप टेक्स्ट पोर्शन के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण "presentation.pptx" (पहले स्लाइड पर पहला शेप टेक्स्ट बॉक्स) की आवश्यकता रखता है और कम से कम एक पैराग्राफ होना चाहिए। यह प्रथम पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफ़िंग भाषा को Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // प्रूफ़िंग भाषा का Id सेट करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Default Language**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके प्रथम टेक्स्ट पोर्शन के लिए `en-US` प्रिंट करता है:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक नया आयताकार शेप टेक्स्ट के साथ जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले पोर्शन की भाषा जांचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Set Default Text Style**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ़ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें ओवरराइड न करे।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें।
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

## **Extract Text with the All-Caps Effect**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट पोर्शन प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textcaptype/) को देखें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में परिवर्तित करें।

यह उदाहरण "sample2.pptx" (पहले स्लाइड पर पहला शेप टेक्स्ट बॉक्स) की आवश्यकता रखता है। इसकी पहली पैराग्राफ़ के पहले पोर्शन में "Hello, Aspose!" है, जिस पर All Caps इफ़ेक्ट लागू किया गया है, जैसा कि नीचे दिखाया गया है।

![The All Caps effect](all_caps_effect.png)

निम्न कोड उदाहरण **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को निकालने को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **FAQ**

**मैं स्लाइड पर टेबल में टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर टेबल में टेक्स्ट संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itable/) का उपयोग करें। सेल्स के माध्यम से इटरेट करें और प्रत्येक सेल को [ICell.getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/#getTextFrame--) तथा पैराग्राफ फॉर्मेटिंग को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा ट्रांसपरेंसी को कॉन्फ़िगर करें।