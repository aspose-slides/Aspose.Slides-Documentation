---
title: जावा में प्रस्तुति पाठ फ़ॉर्मेट करें
linktitle: पाठ फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/java/text-formatting/
keywords:
- पैराग्राफ संरेखित करना
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ़्रेम
- पंक्ति अंतराल
- ऑटोफ़िट गुण
- पाठ फ़्रेम एंकर
- पाठ टैब्यूलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण, और अधिक को अनुकूलित करें।"
---
## **सारांश**

यह लेख Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट करने का तरीका दिखाता है। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

नीचे दिए गए उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

पाठ खोजें और बदलें के लिए देखें [पाठ खोजें और बदलें](/slides/hi/java/search-and-replace-text/)।

## **पाठ की पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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

![धूसर पैराग्राफ](gray_paragraph.png)

नीचे का कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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
        // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
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

## **पाठ पैराग्राफ संरेखित करें**

एक टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बायाँ, दायाँ, जस्टीफ़ाइड आदि हो सकता है।

निम्नलिखित कोड उदाहरण दर्शाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

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

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) को असाइन की गई रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, प्रतिशत नहीं।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पाठ के फ़िल रंग को पारदर्शी रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता कैसे लागू की जाए:

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
            // टेक्स्ट भाग की पारदर्शिता सेट करें।
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

टेक्स्ट बॉक्स में अक्षरों के बीच अंतर को विस्तारित या घटाने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें।

निम्न Java कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे विस्तारित किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे का कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल कैसे विस्तारित किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाई देने वाले पाठ से थोड़ी अधिक कसकर दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को उपेक्षित करता है, भले ही फ़ॉन्ट में मान्य केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में आउटपुट को PowerPoint के करीब लाने के लिए आप प्रभावित फ़ॉन्ट वाले टेक्स्ट भागों के लिए केरनिंग अक्षम कर सकते हैं। [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

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

यह सेटिंग मेल खाते टेक्स्ट भागों पर केरनिंग को लागू होने से रोकती है और फ़ॉन्ट्स के लिए PowerPoint‑विशिष्ट व्यवहार के कारण उत्पन्न दृश्य अंतर को कम करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को सभी भागों पर लागू करता है।

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

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर समान गुण लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घूर्णन सेट करें**

एक आकार के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करने के लिए [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण आकार में पाठ अभिविन्यास को `Vertical270` पर सेट करता है, जिससे पाठ **90 डिग्री प्रतिक्लॉकवाइज़** घुमता है:

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

![पाठ घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

नीचे का कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमा देता है:

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

## **पैराग्राफ की पंक्ति अंतराल सेट करें**

Aspose.Slides उपलब्ध कराता है [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) ताकि पैराग्राफ अंतराल नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* पंक्ति अंतराल को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* पंक्ति अंतराल को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्नलिखित कोड उदाहरण पैराग्राफ के भीतर पंक्ति अंतराल कैसे निर्दिष्ट किया जाए, दिखाता है:

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

![पैराग्राफ के भीतर पंक्ति अंतराल](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से बाहर जाने पर कैसे व्यवहार करता है। इसका उपयोग करके आप टेक्स्ट को सिकुड़ना, ओवरफ़्लो होना या आकार को स्वचालित रूप से बदलना नियंत्रित कर सकते हैं।

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

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) निर्धारित करता है कि टेक्स्ट आकार के भीतर ऊर्ध्वाधर रूप से कहाँ स्थित होगा, जैसे शीर्ष, मध्य या नीचे।

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

## **टेक्स्ट टैब्यूलेशन सेट करें**

एक पैराग्राफ में टैब स्टॉप को कॉन्फ़िगर करने के लिए [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें।

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

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides उपलब्ध कराता है [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), जिससे आप टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न कोड उदाहरण एक टेक्स्ट भाग के लिए प्रूफिंग भाषा कैसे सेट की जाए, दर्शाता है:

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

लोड या प्रस्तुति बनाते समय निर्मित टेक्स्ट के लिए डिफ़ॉल्ट भाषा निर्धारित करने के लिए [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करें।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // नया आयताकार आकार टैक्स्ट के साथ जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले भाग की भाषा जाँचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न कोड उदाहरण एक नई प्रस्तुति में सभी स्लाइड्स के लिए 14 pt आकार का डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर का पैराग्राफ फ़ॉर्मेट प्राप्त करें।
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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर स्वरूपित टेक्स्ट बड़े अक्षरों में दिखता है, भले ही मूल रूप से यह छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी वही स्ट्रिंग वापस देती है जो दर्ज की गई थी। प्रदर्शित टेक्स्ट के साथ मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textcaptype/) की जाँच करें और यदि मान `All` है तो स्ट्रिंग को अपर केस में परिवर्तित करें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्न टेक्स्ट बॉक्स है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण दर्शाता है कि **All Caps** प्रभाव लागू किए हुए टेक्स्ट को कैसे निकाला जाए:

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

## **सामान्य प्रश्न**

**स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करें?**

तालिका में टेक्स्ट को संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/#getTextFrame--) के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेट को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।