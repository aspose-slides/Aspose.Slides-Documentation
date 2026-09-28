---
title: जावा में प्रस्तुति पाठ को फॉर्मेट करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट करने का तरीका दिखाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतर, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतर, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा उल्लेख न किया गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। इसकी पहली स्लाइड में पहला आकार एक टेक्स्ट बॉक्स है, और उसके पहले पैराग्राफ में नीचे दिखाए गए पाठ होते हैं। स्लाइड और आकार दोनों के सूचक शून्य-आधारित हैं। बोल्ड भागों को चुनने वाले उदाहरण प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला हुआ बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![Sample text](sample_text.png)

शाब्दिक पाठ या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने के लिए देखें [Search and Replace Text](/slides/hi/java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने के लिए [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए डिफ़ॉल्ट रूप में हल्का धूसर हाईलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The gray paragraph](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** के लिए पृष्ठभूमि रंग कैसे सेट करें, दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
                // पाठ भाग के लिए हाइलाइट रंग सेट करें।
                portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The gray text portions](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान को केंद्रित, बाएँ‑सुविधा, दाएँ‑सुविधा, वैध आदि हो सकता है।

निम्न कोड उदाहरण **केंद्र** में पैराग्राफ संरेखित करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The aligned paragraph](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 पैमाने पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण **पूरा पैराग्राफ** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पाठ का भरने का रंग पारदर्शी रंग में सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The transparent paragraph](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // पाठ भाग की पारदर्शिता सेट करें।
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The transparent text portions](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतर सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतर को विस्तारित या संकुचित करने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का प्रयोग करें। नीचे के उदाहरण 3 पॉइंट अंतर जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करते हैं।

निम्न Java कोड **पूरा पैराग्राफ** में अक्षर अंतर को विस्तारित करने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर अंतर को संकुचित करने के लिए नकारात्मक मान इस्तेमाल करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतर को विस्तारित करें।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** में अक्षर अंतर को विस्तारित करने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: अक्षर अंतर को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतर को विस्तारित करें।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक सघन लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में PowerPoint के निकट रेंडरिंग प्राप्त करने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिए केरनिंग अक्षम कर सकते हैं। इसे करने के लिए [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण पहले स्लाइड के पहले आकार में टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता होती है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) को जांचता है और Roboto फ़ॉन्ट का उपयोग करने वाले भागों के लिए 100‑पॉइंट सीमा निर्धारित करता है। इससे 100 पॉइंट से कम आकार वाले मिलते‑जुलते भागों के लिए केरनिंग अक्षम हो जाती है:

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

सीमा से नीचे के मिलते‑जुलते पाठ के लिए यह सेटिंग केरनिंग को रोकती है और उन फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

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

निम्न उदाहरण प्रभावी फ़ॉर्मेटिंग जो बोल्ड है, वाले भागों पर 13‑पॉइंट Times New Roman, इटैलिक और डॉटेड अंडरलाइन लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
                // पाठ भाग के लिए फ़ॉन्ट गुण सेट करें।
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

## **पाठ घूर्णन सेट करें**

शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textverticaltype/) में सेट करता है, जिससे पाठ **90 डिग्री प्रतिक्लॉकवाइज़** घुम जाता है:

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

## **टेक्स्ट फ़्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

निचे दिया गया कोड उदाहरण शैप के भीतर टेक्स्ट फ़्रेम को 3 डिग्री क्लॉकवाइज़ घुमाता है:

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

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides पैराग्राफ स्पेसिंग को नियंत्रित करने के लिए [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) प्रदान करता है। ये गुण इस प्रकार उपयोग किए जाते हैं:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* पॉइंट में लाइन स्पेसिंग निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ के भीतर स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

## **लाइन ब्रेकिंग को नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियाई पाठ मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे के मेथड्स [IParagraphFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से ईस्ट एशियाई पाठ व विराम चिह्नों की रैपिंग भी बदल सकती है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियाई लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत व अंत में अक्षरों पर प्रतिबंध शामिल हैं।

इन नियमों से [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) का स्थान नहीं बदलता, जो टेक्स्ट फ्रेम के भीतर स्वतः रैपिंग को सक्षम करता है। ये नियम रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर नहीं डालते। स्पष्ट लाइन‑ब्रेक पैराग्राफ के भीतर नई लाइन बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्वयं‑समाहित उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन पाठ दोनों होते हैं। यह दोनों लाइन‑ब्रेक विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम का प्रयोग करने के लिए, संबंधित मान बदलें जबकि अन्य सेटिंग्स अपरिवर्तित रखें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन का उपयोग करता है। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार व फ्रेम आयाम स्थिर रहें:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **हैन्गिंग पंक्चुएशन नियंत्रित करें**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) पात्रता वाले विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे से आगे बढ़ने की अनुमति देता है, बजाय अगली लाइन में स्थान लेने के। यह पूरे पैराग्राफ पर लागू होता है और हैन्गिंग इंडेंट से अलग है।

निम्न स्वयं‑समाहित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैन्गिंग पंक्चुएशन को सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक जाता है। इस संपत्ति को [NullableBool.False](https://reference.aspose.com/slides/hi/java/com.aspose.slides/nullablebool/) पर सेट करने से आप तुलना कर सकते हैं: इस स्थिति में बिंदु अलग लाइन में दिखाई देगा। रैपिंग सक्षम है और उपलब्ध चौड़ाई को स्थिर रखने के लिये ऑटोफ़िट अक्षम है।

```java
import com.aspose.slides.*;
import java.awt.Color;

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

सभी विराम चिह्न हैंग नहीं सकते। दृश्य परिणाम फ़ॉन्ट उपलब्धता व लेआउट पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दिखाई देने वाला अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि जब टेक्स्ट अपने कंटेनर की सीमाओं से बाहर हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिये करें कि टेक्स्ट सिकुड़ता है, ओवरफ़्लो करता है या शैप को स्वचालित रूप से री‑साइज़ करता है। नीचे दिया गया उदाहरण शैप को उसके टेक्स्ट के अनुसार आकार बदलने हेतु कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है:

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

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या शैप की चौड़ाई परिवर्तन परिणाम को कैसे बदलते हैं, देखें [Count Rendered Lines](/slides/hi/java/manage-paragraph/)। केवल लाइनों की संख्या यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) शैप के भीतर टेक्स्ट को लंबवत रूप से कैसे स्थित किया जाता है, इसे परिभाषित करता है, उदाहरण के लिये शीर्ष, मध्य या नीचे। नीचे दिया गया उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है:

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

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। नीचे दिया गया उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑सुविधा टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं:

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

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप किसी पाठ भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा निर्धारित करती है जो PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाती है।

निम्न उदाहरण के लिये "presentation.pptx" में पहली स्लाइड के पहले आकार में एक टेक्स्ट बॉक्स होना आवश्यक है, और कम से कम एक पैराग्राफ होना चाहिए। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफ़िंग भाषा को सरल चीनी (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या निर्माण के दौरान बनाये गये टेक्स्ट के लिये डिफ़ॉल्ट भाषा निर्धारित करें। नीचे दिया गया उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिये `en-US` प्रिंट करता है:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले भाग की भाषा जांचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैराग्राफ़ों के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट तौर पर सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर के पैराग्राफ फ़ॉर्मेट को प्राप्त करें।
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

## **ऑल‑कैप्स प्रभाव के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही उसे छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides से ऐसे पाठ भाग को प्राप्त करते हैं, तो लाइब्रेरी ठीक वैसा ही पाठ लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मिलाने के लिये, [TextCapType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textcaptype/) की जाँच करें और यदि मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड के पहले आकार में टेक्स्ट बॉक्स हो। उसके पहले पैराग्राफ़ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा नीचे दिखाया गया है:

![The All Caps effect](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** प्रभाव लागू हुए पाठ को निकालने का तरीका दर्शाता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर तालिका में पाठ कैसे संशोधित करूँ?**

तालिका में पाठ संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटरेट करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/#getTextFrame--) के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getParagraphFormat--) के माध्यम से संचालित करें।

**PowerPoint स्लाइड पर पाठ में ग्रेडिएंट रंग कैसे लागू करूँ?**

ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा तथा पारदर्शिता को कॉन्फ़िगर करें।