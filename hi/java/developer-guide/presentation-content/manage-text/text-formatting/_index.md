---
title: जावा में प्रस्तुति पाठ का स्वरूपण
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/java/text-formatting/
keywords:
- पैराग्राफ संरेखण
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- पाठ फ्रेम
- पंक्ति अंतराल
- ऑटोफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि कैसे PowerPoint और OpenDocument प्रस्तुतियों में पाठ को Aspose.Slides for Java का उपयोग करके स्वरूपित किया जाए। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, पैराग्राफ अंतराल, ऑटोफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा नहीं कहा गया है, उदाहरण के लिए [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड में पहली शेप एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और शेप दोनों के सूचक शून्य-आधारित हैं। बाद्द को मोटा (बोल्ड) भाग चुनने वाले उदाहरण प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड स्वरूपण शामिल है:

![नमूना पाठ](sample_text.png)

लिटरल टेक्स्ट या नियमित अभिव्यक्ति मैच ढूँढ़ने और हाइलाइट करने के लिए देखें [Search and Replace Text](/slides/hi/java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

किसी पैराग्राफ के लिये डिफ़ॉल्ट हाईलाइट रंग निर्धारित करने हेतु [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत पाठ हिस्सों के लिये [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिये हल्का धूसर हाईलाइट डिफ़ॉल्ट रूप से सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट को ओवरराइड करता है:

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

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ हिस्सों** के लिये पृष्ठभूमि रंग सेट करने को प्रदर्शित करता है:

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
            // पाठ हिस्से के लिए हाइलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर पाठ हिस्से](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

पाठ फ़्रेम के भीतर पैराग्राफ संरेखण निर्धारित करने के लिये [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बाएँ‑संतुलित, दाएँ‑संतुलित, औचित्यपूर्ण आदि हो सकते हैं।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने को दर्शाता है:

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

![संतुलित पैराग्राफ](aligned_paragraph.png)

## **पंक्ति में फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार वाले पाठ हिस्सों को एक ही पंक्ति में लंबवत संरेखित करने के लिये [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और उसके प्रत्येक पंक्ति में संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट का समान पाठ है, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटोफिट और रैपिंग को अक्षम करता है, तथा टेक्स्ट फ़्रेम को एकल पंक्ति के लिये पर्याप्त बड़ा रखता है।

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

![Baseline, Top, Center, और Bottom फ़ॉन्ट संरेखण का मिश्रित फ़ॉन्ट आकारों के साथ तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे बिल्कुल समान नहीं हो सकते। उदाहरण में एक बड़े अक्षर और एक नीचे की ओर गिरने वाला अक्षर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता एवं प्रतिस्थापन, प्रयुक्त अक्षर, एवं फ़ॉन्ट आकार का अंतर परिणाम को प्रभावित करता है। फ्रेम आकार, मार्जिन, पंक्ति अंतराल, रैपिंग और ऑटोफिट भी लेआउट को बदलते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) से अलग है, जो क्षैतिज पैराग्राफ संरेखण नियंत्रित करता है, तथा [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) से भी, जो शेप के भीतर पाठ ब्लॉक को लंबवत स्थित करता है। [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) द्वारा सुपर‑स्क्रिप्ट व सब‑स्क्रिप्ट स्वरूपण व्यक्तिगत हिस्सों को बेसलाइन के सापेक्ष स्थानांतरित करता है, न कि पैराग्राफ पंक्तियों के लिये फ़ॉन्ट संरेखण सेट करता है।

## **पाठ के लिये पारदर्शिता सेट करें**

पाठ पारदर्शिता [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक द्वारा नियंत्रित होती है। नीचे के उदाहरणों में `alpha = 50` 0–255 पैमाने पर ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करने को दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पाठ का भरने का रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ हिस्सों** पर पारदर्शिता लागू करने को दर्शाता है:

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
            // पाठ हिस्से की पारदर्शिता सेट करें।
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

![पारदर्शी पाठ हिस्से](transparent_text_portions.png)

## **पाठ के लिये अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करने हेतु [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें। निम्न उदाहरण 3 पॉइंट का अंतराल जोड़ता है; नकारात्मक मान पाठ को संकुचित करेंगे।

निम्न Java कोड **पूरे पैराग्राफ** में अक्षर अंतराल बढ़ाने को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: नकारात्मक मानों का उपयोग करके अक्षर अंतराल को संकुचित करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल को विस्तारित करें।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ हिस्सों** में अक्षर अंतराल बढ़ाने को प्रदर्शित करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: नकारात्मक मानों का उपयोग करके अक्षर अंतराल को संकुचित करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल को विस्तारित करें।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पाठ हिस्सों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग अक्षम करें**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखने वाले पाठ से थोड़ा सघन लग सकता है। ऐसा इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट के लिये केरनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में आप उन पाठ हिस्सों के लिये केरनिंग अक्षम कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण पहले स्लाइड के पहले शेप पर एक टेक्स्ट बॉक्स वाले "presentation.pptx" को आवश्यक मानता है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) को जाँचता है और Roboto का उपयोग करने वाले हिस्सों के लिये 100‑पॉइंट सीमा सेट करता है। यह 100 पॉइंट से कम आकार के मेल खाते हिस्सों के लिये केरनिंग को अक्षम करता है:

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

सीमा से नीचे के मेल खाते पाठ में यह सेटिंग केरनिंग को रोकती है और Aspose.Slides की रेंडरिंग को PowerPoint के दृश्य आउटपुट के अधिक निकट लाने में मदद कर सकती है, विशेष रूप से उन फ़ॉन्ट के लिये जो इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित होते हैं।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और बिंदीदार अंडरलाइन के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट को ओवरराइड करता है।

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

![पैराग्राफ के लिये फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन हिस्सों पर 13‑पॉइंट Times New Roman, इटैलिक स्वरूपण और बिंदीदार अंडरलाइन लागू करता है जिनकी प्रभावी स्वरूपण बोल्ड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // पाठ हिस्से के लिये फ़ॉन्ट गुण सेट करें।
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

![पाठ हिस्सों के लिये फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को पुन: उत्पन्न करने या अक्षर ऊँचाई में अंतर का अध्ययन करने के लिये [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) का उपयोग करें। PowerPoint में सामान्यीकरण सक्षम करने से व्यक्तिगत अक्षर ऊर्ध्वाधर रूप से खिंचे या संकुचित होते हैं ताकि वे पाठ हिस्से के भीतर समान दृश्यमान ऊँचाई रखें। यह विभिन्न फ़ॉन्ट के बीच समान पाठ ऊँचाई की गारंटी नहीं देता।

इस गुण को [NullableBool.True या False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) सेट करके स्पष्ट रूप से सक्षम या अक्षम किया जा सकता है। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट रखता है जिससे हिस्सा पैराग्राफ के [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) से मान विरासत में लेता है। यह `False` के बराबर नहीं है। [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) का उपयोग करके [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) से हल किया गया बूलियन मान पढ़ें।

निम्न स्वतंत्र उदाहरण **Arial** स्थापित होने की आवश्यकता रखता है। यह दो पाठ ब्लॉकों को बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, नीचे गिरने वाले अक्षर और उच्चारण वाले अक्षर 54 पॉइंट में होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम रखते हैं। ऊपर का हिस्सा स्पष्ट रूप से इसे अक्षम करता है; नीचे का हिस्सा इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटोफिट अक्षम हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: false` और `NotDefined: true` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे का तुलना सहेजे गए प्रस्तुतिकरण से निर्यात किया गया है। शीर्ष पंक्ति में सामान्यीकरण अक्षम (`False`) है; नीचे की पंक्ति में विरासत में मिला सेटिंग (`NotDefined` → `True`) सक्रिय है। इस दृश्य को पुन: उत्पन्न करने के लिये Arial स्थापित रखें।

![Arial 54‑पॉइंट पाठ, ऊपर सामान्यीकरण अक्षम और नीचे विरासत में मिला सामान्यीकरण सक्षम](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदलता है जबकि निर्धारित [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) मान अपरिवर्तित रहता है, जो फ़ॉन्ट आकार को पॉइंट में बताता है। पैराग्राफ [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) पंक्ति अंतराल नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) यह निर्धारित करता है कि पाठ या उसका कंटेनर कैसे फ़िट करता है। ये सेटिंग अलग‑अलग उद्देश्यों के लिये हैं और लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ स्वरूपण और वारिसे के बारे में अधिक जानकारी के लिए देखें [Manage Paragraph](/slides/hi/java/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू व हटाएँ**

पाठ हिस्से पर [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) का उपयोग करके सुधार, रद्द किए गए शब्द या पूर्व मूल्य को मूल पाठ को हटाए बिना दिखाया जा सकता है। इसे [TextStrikethroughType.Single या Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) सेट करके एक या दो रेखाएँ जोड़ें।

स्ट्राइकथ्रू हटाने के लिये [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) पास करें। यह प्रभाव को स्पष्ट रूप से अक्षम करता है, भले ही आसपास का स्वरूपण स्ट्राइकथ्रू निर्दिष्ट करता हो। इसके विपरीत, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अनिर्धारित छोड़ देता है, जिससे हिस्सा पैराग्राफ जैसे अन्य स्रोत से स्वरूपण विरासत में लेता है। यह स्ट्राइकथ्रू हटाने की गारंटी नहीं देता। परिणामी स्वरूपण, जिसमें विरासत मान भी शामिल हैं, पढ़ने के लिये [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) का उपयोग करें।

निम्न स्वतंत्र उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व मूल्य और वर्तमान मूल्य के लिये अलग‑अलग हिस्से होते हैं, इसलिए केवल पूर्व मूल्य प्रभावित होता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है फिर हटाती है; अन्य पंक्तियों में क्रमशः एकल और दुगुना स्ट्राइकथ्रू रहता है। यह सेटिंग पाठ और उसकी अन्य स्वरूपण, जैसे बोल्ड पूर्व मूल्य, को संरक्षित रखती है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // स्ट्राइकथ्रू लागू करें, फिर पहली पिछली कीमत से इसे स्पष्ट रूप से हटाएँ।
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, और दुगुना स्ट्राइकथ्रू।

![बिना स्ट्राइकथ्रू के पूर्व मूल्य, एकल स्ट्राइकथ्रू वाला और दोहरी स्ट्राइकथ्रू वाला](strikethrough.png)

## **पाठ घुमाव सेट करें**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करके शेप के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) पर सेट करता है, जो पाठ को **90 डिग्री उल्टा** घुमाता है:

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

![पाठ घुमाव](text_rotation.png)

## **टेक्स्ट फ़्रेम के लिये कस्टम घुमाव सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) के लिये कस्टम घुमाव कोण सेट करें।

निम्न कोड उदाहरण शेप के भीतर टेक्स्ट फ़्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम टेक्स्ट घुमाव](custom_text_rotation.png)

## **पैराग्राफ की पंक्ति अंतराल सेट करें**

Aspose.Slides निम्नलिखित के माध्यम से पैराग्राफ अंतराल नियंत्रित करता है: [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-)। इन गुणों का उपयोग इस प्रकार किया जाता है:

* पंक्ति अंतराल को पंक्ति ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिये सकारात्मक मान उपयोग करें।
* पंक्ति अंतराल को पॉइंट में निर्दिष्ट करने के लिये नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के भीतर अंतराल को पंक्ति ऊँचाई के 200 % (दोगुना स्पेसिंग) पर सेट करता है:

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

## **पंक्ति विभाजन नियंत्रित करें**

पैराग्राफ पंक्ति‑विभाजन नियम संकरी टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियन पाठ मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे दिए गये तरीक़े [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन पंक्ति‑विभाजन नियम नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से ईस्ट एशियन पाठ व विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन पंक्ति‑विभाजन नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत व अंत में अक्षर सीमाएँ शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे पंक्ति‑ब्रेक अक्षर नहीं डालते। एक स्पष्ट पंक्ति‑ब्रेक पैराग्राफ में नया पंक्ति बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्वतंत्र उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी व लैटिन पाठ होता है। यह दोनों पंक्ति‑विभाजन विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। नियमों में से किसी एक को प्रयोग करने के लिये संबंधित मान बदलें, जबकि अन्य सेटिंग समान रखें। उदाहरण 24‑पॉइंट Arial व SimSun का उपयोग करता है, फ्रेम चौड़ाई 160 पॉइंट और क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन शून्य है। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) पर सेट किया गया है ताकि पाठ आकार व फ्रेम आकार स्थिर रहें।

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) पात्र विराम चिह्न को पाठ पंक्ति के दायें किनारे से आगे बढ़ने की अनुमति देता है, बजाय अगली पंक्ति में ले जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ़्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial व शून्य क्षैतिज मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दायें टेक्स्ट किनारे से बाहर निकलता है। तुलना के लिये [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स में बिंदु अलग पंक्ति ले लेता है। रैपिंग सक्षम है और ऑटोफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं सकता। ऊपर वर्णित [फ़ॉन्ट व लेआउट शर्तें](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफिट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिये ऑटोफिट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि जब पाठ कंटेनर की सीमा से बाहर हो जाए तो उसका व्यवहार क्या होगा। इसका उपयोग करके आप निर्धारित कर सकते हैं कि पाठ छोटा हो, अधिक निकले या आकार‑स्वचालित रूप से शेप को बदले। निम्न उदाहरण शेप को उसके टेक्स्ट को फिट करने हेतु आकार बदलने के लिये कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है।

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

स्वचालित रैपिंग के बाद पंक्तियों की संख्या गिनने और यह देखने के लिये कि पाठ या शेप की चौड़ाई परिवर्तन परिणाम को कैसे प्रभावित करती है, देखें [Count Rendered Lines](/slides/hi/java/manage-paragraph/)। पंक्तियों की गिनती केवल यह संकेत नहीं देती कि पाठ कंटेनर से पार हो रहा है या नहीं।

## **टेक्स्ट फ़्रेम एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) यह निर्धारित करता है कि पाठ शेप के भीतर लंबवत किस स्थान पर स्थित होगा, जैसे शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले शेप के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है।

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

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिये [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर एक बाएँ‑संतुलित टैब स्टॉप जोड़ता है। ये सेटिंग टैब अक्षर वाले पाठ को प्रभावित करती हैं।

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

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप किसी पाठ हिस्से की प्रूफ़िंग भाषा निर्धारित कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में स्पेलिंग व व्याकरण जांच के लिये उपयोग की जाने वाली भाषा तय करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है, जिसमें पहले स्लाइड में पहला शैप एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है और प्रमाणीकृत चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके वह डिफ़ॉल्ट भाषा परिभाषित करें जो प्रस्तुति लोड या बनाते समय निर्मित पाठ के लिये लागू होगी। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है और उसके पहले पाठ हिस्से के लिये `en-US` प्रिंट करता है।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // टेक्स्ट के साथ एक नया आयताकार शेप जोड़ें।
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

प्रस्तुति स्तर पर डिफ़ॉल्ट पाठ स्वरूपण लागू करने के लिये [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैराग्राफ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप से सेट करता है और इसे "default_text_style.pptx" में सहेजता है। जब तक अधिक विशिष्ट स्वरूपण ओवरराइड न करे, पाठ इन डिफ़ॉल्ट को विरासत में ले सकता है।

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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides से ऐसा पाठ हिस्सा निकालते हैं, तो लाइब्रेरी बिल्कुल वही पाठ लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिये [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) जाँचें और यदि मान `All` हो तो लौटाए गये स्ट्रिंग को बड़े अक्षरों में परिवर्तित करें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला शैप एक टेक्स्ट बॉक्स है। उसका पहला पैराग्राफ का पहला हिस्सा "Hello, Aspose!" रखता है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण **All Caps** प्रभाव लागू होने के साथ टेक्स्ट निकालने को दर्शाता है:

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

**मैं स्लाइड पर तालिका में पाठ कैसे संशोधित करूँ?**

स्लाइड पर तालिका में पाठ बदलने के लिये [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) तथा पैराग्राफ स्वरूपण को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) से अपडेट करें।

**PowerPoint स्लाइड पर पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

पाठ पर ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा तथा पारदर्शिता को कॉन्फ़िगर करें।

संबंधित फीचर: [Format text within slides](/slides/hi/features/text-formatting/).