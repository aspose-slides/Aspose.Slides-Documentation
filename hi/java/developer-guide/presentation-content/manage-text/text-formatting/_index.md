---
title: जावा में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट स्वरूपण
type: docs
weight: 50
url: /hi/java/text-formatting/
keywords:
- पैराग्राफ संरेखित
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ़्रेम
- लाइन अंतराल
- ऑटॉफिट गुण
- टेक्स्ट फ़्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख दर्शाता है कि Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे स्वरूपित किया जाए। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा न कहा गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया जाता है। पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाया गया टेक्स्ट रखता है। स्लाइड और आकार दोनों के सूचक शून्य-आधारित हैं। बोल्ड भाग चुनने वाले उदाहरण प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिली बोल्ड स्वरूपण भी शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

अक्षर या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/java/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाइलाइट को डिफ़ॉल्ट रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्रधानता रखते हैं:

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

![स्लेटी पैराग्राफ](gray_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** के लिए पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

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

![स्लेटी टेक्स्ट भाग](gray_text_portions.png)

## **पैराग्राफ टेक्स्ट संरेखित करें**

टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बाएँ-अनुरूप, दाएँ-अनुरूप, समायोजित आदि हो सकता है।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करता है:

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

## **पंक्ति में फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार के टेक्स्ट भागों को एक पंक्ति में लंबवत संरेखित करने के लिए [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक स्लाइड में चार लेबल्ड टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट आकार के समान टेक्स्ट होते हैं, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटॉफिट और रैपिंग को अक्षम करता है, और टेक्स्ट फ़्रेम को एक पंक्ति के लिये पर्याप्त बड़ा रखता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![बेसलाइन, टॉप, सेंटर और बॉटम फ़ॉन्ट संरेखण मिश्रित फ़ॉन्ट आकारों के साथ तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर निर्भर करता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे आवश्यकतः बिल्कुल मेल नहीं खा सकते। उदाहरण में एक बड़े अक्षर और एक नीचे‑गिरता अक्षर शामिल है ताकि बेसलाइन और बॉटम संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, प्रयुक्त अक्षर और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ़्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटॉफिट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) से अलग है, जो क्षैतिज पैराग्राफ संरेखण नियंत्रित करता है, तथा [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) से भी अलग है, जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष स्थानांतरित करता है, न कि पैराग्राफ लाइनों के लिए फ़ॉन्ट संरेखण सेट करता है।

## **टेक्स्ट के लिये पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) द्वारा सौंपे गए रंग के अल्फा घटक से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` एक ARGB अल्फा‑चैनल मान है 0–255 पैमाने पर, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // टेक्स्ट का फ़िल रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** पर पारदर्शिता लागू करता है:

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

## **टेक्स्ट के लिये अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाने या घटाने के लिये [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें। उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकीर्ण बनाते हैं।

निम्न जावा कोड **पूरे पैराग्राफ** में अक्षर अंतराल बढ़ाने का प्रदर्शन करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिये नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भाग** में अक्षर अंतराल बढ़ाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिये नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट भाग में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिये कर्निंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा कसा हुआ लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिये कर्निंग डेटा को नज़रअंदाज़ कर देता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में आउटपुट को PowerPoint के करीब लाने के लिये, उन टेक्स्ट भागों के लिये कर्निंग को अक्षम किया जा सकता है जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण पहले स्लाइड के पहले आकार में एक टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, और Roboto का उपयोग करने वाले भागों के लिये 100‑पॉइंट थ्रेशोल्ड सेट करता है। यह 100 पॉइंट से छोटे फ़ॉन्ट आकार वाले मिलते भागों की कर्निंग को अक्षम करता है:

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

थ्रेशोल्ड से नीचे वाले मिलते टेक्स्ट के लिये, यह सेटिंग कर्निंग को रोकती है और उस फ़ॉन्ट के लिये PowerPoint‑विशिष्ट व्यवहार से प्रभावित रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ अधिक मिलान करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) के द्वारा सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और बिंदीदार अंडरलाइन स्वरूपण के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट पर प्रधानता रखता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ के लिये फ़ॉन्ट गुण सेट करें।
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

![पैराग्राफ के लिये फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक स्वरूपण और बिंदीदार अंडरलाइन को उन भागों पर लागू करता है जिनका प्रभावी स्वरूपण बोल्ड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट भाग के लिये फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट भागों के लिये फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

टेक्स्ट को आकार के भीतर पूर्वनिर्धारित अभिविन्यास पर सेट करने के लिये [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री उल्टा** घुमा देता है:

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

## **टेक्स्ट फ़्रेम के लिये कस्टम घूर्णन सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) के लिये कस्टम घूर्णन कोण सेट करें।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ़्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides निम्नलिखित प्रॉपर्टीज़ प्रदान करता है: [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) पैराग्राफ अंतराल को नियंत्रित करने के लिये। इनका उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिये एक सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिये एक नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ की भीतर स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियन टेक्स्ट के मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे के मेथड्स [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) से संबंधित हैं, अतः वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से ईस्ट एशियन टेक्स्ट एवं विराम चिह्न की रैपिंग भी बदल सकती है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें पंक्ति की शुरुआत व अंत में वर्णों के प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम में स्वतः रैपिंग को सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक वर्ण नहीं सम्मिलित करते। एक स्पष्ट लाइन‑ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ के भीतर नई पंक्ति बनाता है।

निम्न स्वतंत्र उदाहरण चीनी व लैटिन टेक्स्ट वाले संकुचित टेक्स्ट ब्लॉक को बनाता है। यह दोनों लाइन‑ब्रेकिंग विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" को सहेजता है। किसी भी नियम को बदलने के लिये, दूसरे सेटिंग को अपरिवर्तित रखें। यह उदाहरण 24‑पॉइंट Arial व SimSun का उपयोग 160‑पॉइंट फ़्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ करता है। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) के साथ बुलाया गया है ताकि टेक्स्ट आकार व फ़्रेम आयाम स्थिर रहें:

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

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) योग्य विराम चिह्न को टेक्स्ट लाइन के दाएँ किनारे से बाहर तक विस्तारित करने की अनुमति देता है, बजाय अगले पंक्ति में स्थान लेने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑चौड़े टेक्स्ट फ़्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" को सहेजता है। 24‑पॉइंट Arial व शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक बढ़ता है। तुलना के लिये प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) पर सेट करें: इस सेटिंग के साथ बिंदु अलग पंक्ति में दिखेगा। रैपिंग सक्षम है व ऑटॉफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफिट सेटिंग बदलने से दृश्यमान अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिये ऑटॉफिट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से अधिक होने पर कैसे व्यवहार करे। इसका उपयोग करके टेक्स्ट को संकुचित, बाहर निकलने या आकार को स्वतः पुनः आकार देने को नियंत्रित किया जा सकता है। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार पुनः आकारित करता है और परिणाम को "autofit_type.pptx" में सहेजता है:

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

स्वचालित रैपिंग के बाद लाइनों की गिनती और टेक्स्ट या आकार की चौड़ाई परिवर्तन के परिणाम देखने के लिये, देखें [Count Rendered Lines](/slides/hi/java/manage-paragraph/). लाइनों की गिनती अकेले यह नहीं दर्शाती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ़्रेम का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) आकार के भीतर टेक्स्ट को ऊर्ध्वाधर रूप से कैसे स्थित किया जाता है, निर्धारित करता है, उदाहरण स्वरूप शीर्ष, मध्य या तल पर। निम्न उदाहरण टेक्स्ट को पहले आकार के तल पर एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है:

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

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिये [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑अनुरूप टैब स्टॉप जोड़ता है। यह सेटिंग टैब वर्ण वाले टेक्स्ट को प्रभावित करती है:

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

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जो टेक्स्ट भाग की प्रूफ़िंग भाषा को निर्धारित करता है। प्रूफ़िंग भाषा PowerPoint में वर्तनी व व्याकरण जांच के लिये उपयोग की जाती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है जिसमें पहले स्लाइड पर एक टेक्स्ट बॉक्स और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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

    // प्रूफ़िंग भाषा की Id सेट करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या निर्माण के दौरान निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिये `en-US` प्रिंट करता है:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक नया आयत आकार टेक्स्ट के साथ जोड़ें।
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

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट स्वरूपण लागू करने के लिये [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ़ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट स्वरूपण इन्हें अधिलेखित न करे।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर पैराग्राफ स्वरूप प्राप्त करें।
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

## **All‑Caps प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर सभी बड़े अक्षर में दिखता है, भले ही वह छोटे अक्षर में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, लाइब्रेरी टेक्स्ट को ठीक उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहले स्लाइड पर एक टेक्स्ट बॉक्स हो। उसके पहले पैराग्राफ़ का पहला भाग "Hello, Aspose!" को All Caps प्रभाव के साथ रखता है, जैसा नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

नीचे का कोड उदाहरण **All Caps** प्रभाव लागू हुए टेक्स्ट को निकालने का प्रदर्शन करता है:

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

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करूँ?**

एक स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिये, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) तथा पैराग्राफ स्वरूपण को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) के द्वारा अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिये, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा तथा पारदर्शिता को कॉन्फ़िगर करें।