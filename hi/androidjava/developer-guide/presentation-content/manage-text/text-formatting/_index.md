---
title: Android पर प्रस्तुति टेक्स्ट का फ़ॉर्मेट
linktitle: टेक्स्ट फॉर्मेटिंग
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
- ऑटॉफिट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और शैली दें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने का तरीका दिखाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स और भाषा सेटिंग्स को कवर करता है।

नीचे के उदाहरणों में, हम "sample.pptx" नाम की फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

लिटरल टेक्स्ट या रेगुलर-एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/androidjava/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** का पृष्ठभूमि रंग कैसे सेट करें:

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

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट करें:

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
            // टेक्स्ट हिस्से के लिए हाइलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करके टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करें। मान को मध्य, बाएँ-संरेखित, दाएँ-संरेखित, जस्टिफाइड आदि हो सकता है।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित करें:

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

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू करें:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // टेक्स्ट का फ़िल रंग पारदर्शी रंग में सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर पारदर्शिता कैसे लागू करें:

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
            // टेक्स्ट हिस्से की पारदर्शिता सेट करें।
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

![पारदर्शी टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ा या घटा सकते हैं।

निम्नलिखित जावा कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में अक्षर अंतराल कैसे बढ़ाया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट हिस्सों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट से थोड़ा अधिक तंग लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में मान्य केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट हिस्सों के लिए केरनिंग को निष्क्रिय कर सकते हैं। [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

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

यह सेटिंग मिलते-जुलते टेक्स्ट हिस्सों पर केरनिंग लागू होने से रोकती है और इस PowerPoint-विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के विज़ुअल आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्नलिखित कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को पैराग्राफ के सभी हिस्सों पर लागू करता है।

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

नीचे दिया गया कोड उदाहरण समान गुणों को **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट हिस्से के लिए फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करके एक आकार के भीतर पूर्वपरिभाषित टेक्स्ट अभिविन्यास सेट करें।

निम्नलिखित कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री विरुद्ध घड़ी दिशा में** घुमा देता है:

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

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके एक [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी दिशा में घुमा देता है:

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

Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) प्रदान करता है ताकि पैराग्राफ अंतराल को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन अंतराल को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन अंतराल को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ के भीतर लाइन अंतराल कैसे निर्दिष्ट किया जाए:

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

![पैराग्राफ के भीतर लाइन अंतराल](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटॉफिट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि कंटेनर की सीमाओं से टेक्स्ट अधिक होने पर कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट सिकुड़ता है, ओवरफ्लो करता है, या आकार को स्वतः पुनः आकार देता है।

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

स्वचालित रैपिंग के बाद लाइनों की गणना करने और देखेंगे कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/androidjava/manage-paragraph/)। केवल लाइनों की संख्या यह नहीं बताती कि टेक्स्ट कंटेनर से अधिक हो रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) यह निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित है, जैसे शीर्ष, मध्य, या नीचे।

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

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करें।

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

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जो आपको टेक्स्ट हिस्से के लिए प्रूफिंग भाषा सेट करने की अनुमति देता है। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिये उपयोग की जाने वाली भाषा को निर्धारित करती है।

निम्नलिखित कोड उदाहरण दिखाता है कि टेक्स्ट हिस्से के लिए प्रूफिंग भाषा कैसे सेट की जाए:

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति को लोड या बनाते समय निर्मित टेक्स्ट के लिए डिफ़ॉल्ट भाषा निर्धारित करें।

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

    // पहले हिस्से की भाषा जाँचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि नई प्रस्तुति में सभी स्लाइडों के टेक्स्ट के लिए 14 pt आकार के साथ डिफ़ॉल्ट बोल्ड फ़ॉन्ट कैसे सेट किया जाए।

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

## **ऑल-केप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसी टेक्स्ट हिस्से को प्राप्त करने पर, लाइब्रेरी टेक्स्ट को बिल्कुल वही रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, जब मान [TextCapType.All](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textcaptype/) हो, तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल-केप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू किए हुए टेक्स्ट को कैसे निकालें:

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

## **प्रश्नोत्तर**

**स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करें?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए, [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटरिएट करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/#getTextFrame--) के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।