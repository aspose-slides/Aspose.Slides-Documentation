---
title: जावा में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/java/text-formatting/
keywords:
- अनुच्छेद संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- पंक्ति अंतराल
- ऑटॉफिट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित करने का तरीका दिखाता है। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, अनुच्छेद अंतराल, ऑटॉफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

नीचे के उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

शाब्दिक पाठ या रेगुलर‑एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए देखें [पाठ खोजें और बदलें](/slides/hi/java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाईलाइट रंग सेट करने के लिए [IParagraphFormat.getDefaultPortionFormat] का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat.getHighlightColor] का उपयोग करें।

नीचे दिया गया कोड उदाहरण **पूरा अनुच्छेद** के लिए पृष्ठभूमि रंग सेट करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे अनुच्छेद के लिए हाईलाइट रंग सेट करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर अनुच्छेद](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** के लिए पृष्ठभूमि रंग सेट करने का तरीका दिखाता है:

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
            // टेक्स्ट भाग के लिए हाईलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर टेक्स्ट भाग](gray_text_portions.png)

## **पाठ अनुच्छेद संरेखित करें**

[IParagraphFormat.setAlignment] का उपयोग करके टेक्स्ट फ्रेम के भीतर अनुच्छेद संरेखण सेट करें। मान केंद्रित, बाएँ संरेखित, दाएँ संरेखित, बराबर, आदि हो सकते हैं।

नीचे दिया गया कोड उदाहरण अनुच्छेद को **केंद्र** में संरेखित करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ का संरेखण केंद्र में सेट करें.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

टेक्स्ट पारदर्शिता को [IBasePortionFormat.getFillFormat] को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरा अनुच्छेद** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पाठ का भरने का रंग पारदर्शी रंग में सेट करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** पर पारदर्शिता लागू करने का तरीका दिखाता है:

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
            // टेक्स्ट भाग की पारदर्शिता सेट करें.
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

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

[IBasePortionFormat.setSpacing] का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाया या घटाया जा सकता है।

नीचे दिया गया जावा कोड **पूरा अनुच्छेद** में अक्षर अंतराल को विस्तारित करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** में अक्षर अंतराल को विस्तारित करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए टेक्स्ट से थोड़ा अधिक संकीर्ण दिख सकता है। यह इसलिए होता है क्योंकि PowerPoint कुछ फ़ॉन्ट के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी मौजूद हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडरिंग को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट भागों के लिए केरनिंग को निष्क्रिय कर सकते हैं। [IBasePortionFormat.setKerningMinimalSize] को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat] के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat] के माध्यम से सेट किया जा सकता है।

नीचे दिया गया कोड पूरे अनुच्छेद के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को सभी भागों पर लागू करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें.
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

![अनुच्छेद के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** पर समान गुण लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें.
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

![टेक्स्ट भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

[ITextFrameFormat.setTextVerticalType] का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जो टेक्स्ट को **90 डिग्री विपरीत दिशा में** घुमाता है:

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

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.setRotationAngle] का उपयोग करके किसी [ITextFrame] के लिए कस्टम घूर्णन कोण सेट किया जा सकता है।

नीचे दिया गया कोड आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **अनुच्छेदों की पंक्ति अंतराल सेट करें**

Aspose.Slides [IParagraphFormat.setSpaceAfter], [IParagraphFormat.setSpaceBefore] और [IParagraphFormat.setSpaceWithin] प्रदान करता है ताकि अनुच्छेद अंतराल को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन की ऊँचाई के प्रतिशत के रूप में पंक्ति अंतराल निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* पॉइंट्स में पंक्ति अंतराल निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

नीचे दिया गया कोड उदाहरण अनुच्छेद के भीतर पंक्ति अंतराल निर्दिष्ट करने का तरीका दिखाता है:

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

![अनुच्छेद के भीतर पंक्ति अंतराल](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटॉफिट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType] निर्धारित करता है कि टेक्स्ट तभी कैसे व्यवहार करता है जब वह अपने कंटेनर की सीमाओं से अधिक हो जाता है। इसका उपयोग करके आप निर्धारित कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो हो, या आकार स्वचालित रूप से री‑साइज़ हो।

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

स्वचालित रैपिंग के बाद पंक्तियों की गिनती करने और यह देखने के लिए कि पाठ या आकार की चौड़ाई कैसे बदलती है, देखें [रेंडर की गई पंक्तियों की गणना](/slides/hi/java/manage-paragraph/). केवल पंक्ति गिनती यह नहीं बताती कि पाठ उसके कंटेनर से बाहर निकलता है या नहीं।

## **टेक्स्ट फ्रेमों के एंकर को सेट करें**

[ITextFrameFormat.setAnchoringType] निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत रूप से कैसे स्थित होता है, जैसे शीर्ष, मध्य या नीचे।

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

[IParagraphFormat.setDefaultTabSize] और [IParagraphFormat.getTabs] का उपयोग करके अनुच्छेद में टैब स्टॉप को कॉन्फ़िगर किया जा सकता है।

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

![अनुच्छेद टैब](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.setLanguageId] प्रदान करता है, जिससे आप टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा निर्धारित करती है कि PowerPoint में वर्तनी और व्याकरण जाँच किस भाषा में की जाएगी।

नीचे दिया गया कोड उदाहरण टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट करने का तरीका दिखाता है:

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

    // प्रूफ़िंग भाषा का Id सेट करें.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage] का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें।

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

    // पहले भाग की भाषा जाँचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रेज़ेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [IPresentation.getDefaultTextStyle] का उपयोग करें।

नीचे दिया गया कोड उदाहरण नई प्रस्तुति में सभी स्लाइड्स के टेक्स्ट के लिए 14 pt आकार के साथ डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करने का तरीका दिखाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर के पैराग्राफ फ़ॉर्मेट प्राप्त करें.
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

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालेँ**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर टेक्स्ट बड़े अक्षरों में दिखता है, भले ही मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी वही टेक्स्ट लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType] जांचें और जब मान `All` हो तो लौटाई गई स्ट्रिंग को बड़े अक्षरों में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **ऑल कैप्स** इफ़ेक्ट लागू हुए टेक्स्ट को निकालने का तरीका दिखाता है:

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

**स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करें?**

स्लाइड पर तालिका में टेक्स्ट को संशोधित करने के लिए [ITable] का उपयोग करें। सेल्स के माध्यम से इटररेट करें और प्रत्येक सेल को [ICell.getTextFrame] के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.getParagraphFormat] के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.getFillFormat] का उपयोग करें। [IFillFormat.setFillType] को [FillType.Gradient] पर सेट करें और ग्रेडिएंट स्टॉप, दिशा तथा पारदर्शिता को कॉन्फ़िगर करें।