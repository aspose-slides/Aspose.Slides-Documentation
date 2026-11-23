---
title: जावा में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/java/text-formatting/
keywords:
- पैरेग्राफ संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
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
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अन्य विकल्पों को अनुकूलित करें।"
---
## **समीक्षा**

यह लेख Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ का स्वरूपण कैसे करें, दर्शाता है। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैरेग्राफ अंतराल, ऑटोफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा नहीं कहा गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। इसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैरेग्राफ नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और आकार दोनों की सूचकांक शून्य‑आधारित है। जो उदाहरण बोल्ड भागों का चयन करते हैं, वे प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला हुआ बोल्ड स्वरूपण भी शामिल है:

![नमूना पाठ](sample_text.png)

साक्षर पाठ या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने के लिए देखें [Search and Replace Text](/slides/hi/java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिये पैराग्राफ के लिये [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिये [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैरेग्राफ के लिये हल्का ग्रे हाइलाइट डिफ़ॉल्ट रूप से सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

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

![ग्रे पैरेग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** के लिये पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

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

![ग्रे पाठ भाग](gray_text_portions.png)

## **पाठ पैरेग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैरेग्राफ संरेखण सेट करने के लिये [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बायाँ‑संतुलित, दायाँ‑संतुलित, समान‑व्याख्यित आदि हो सकता है।

निम्न कोड उदाहरण पैरेग्राफ को **केंद्र** में संरेखित करने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैरेग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित पैरेग्राफ](aligned_paragraph.png)

## **पंक्ति में फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकारों वाले पाठ भागों को एक पंक्ति में ऊर्ध्वाधर रूप से संरेखित करने के लिये [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) का उपयोग करें। यह सेटिंग पूरे पैरेग्राफ पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक ही स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैरेग्राफ में 18, 36, और 54 पॉइंट्स के समान पाठ होते हैं, अलग‑अलग फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटोफिट और रैपिंग अक्षम करता है, तथा टेक्स्ट फ्रेम को एक पंक्ति के लिये पर्याप्त बड़ा रखता है।

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

![Baseline, Top, Center और Bottom फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे आवश्यक रूप से बिल्कुल लकीर में नहीं होते। उदाहरण में एक बड़े अक्षर और एक नीचे वाले अक्षर दोनों शामिल हैं, जिससे बेसलाइन और बॉटम संरेखण के बीच अंतर स्पष्ट होता है। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर और फ़ॉन्ट आकारों का अंतर परिणाम को प्रभावित करता है। फ्रेम आयाम, मार्जिन, लाइन अंतराल, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) (क्षैतिज पैरेग्राफ संरेखण) और [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) (शेप के भीतर पाठ ब्लॉक को ऊर्ध्वाधर रूप से स्थित करने) से अलग है। [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) द्वारा सुपरस्क्रिप्ट व सबस्क्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि पैरेग्राफ लाइनों के लिये फ़ॉन्ट संरेखण सेट करता है।

## **पाठ के लिये पारदर्शिता सेट करें**

पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0‑255 स्केल पर ARGB अल्फा‑चैनल मान है, न कि प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरे पैरेग्राफ** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पाठ का भराव रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैरेग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

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

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिये अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के मध्य अंतराल को विस्तारित या संकुचित करने के लिये [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का प्रयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करते हैं।

निम्न Java कोड **पूरे पैरेग्राफ** में अक्षर अंतराल को विस्तारित करने का तरीका दिखाता है:

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

![पैरेग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** में अक्षर अंतराल विस्तारित करने का तरीका दर्शाता है:

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

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिये कर्निंग निष्क्रिय करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक सघन लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिये कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिये आप उन पाठ भागों के लिये कर्निंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। इसके लिये [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण पहली स्लाइड के पहले आकार में टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, की जांच करता है और Roboto का उपयोग करने वाले भागों के लिये 100‑पॉइंट थ्रेशोल्ड सेट करता है। इससे 100 पॉइंट से छोटे फ़ॉन्ट आकार वाले मिलते‑जुलते भागों की कर्निंग निष्क्रिय हो जाएगी:

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

थ्रेशोल्ड से नीचे के मिलते‑जुलते पाठों के लिये यह सेटिंग कर्निंग को रोकती है और उन फ़ॉन्ट्स के लिये Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैरेग्राफ के डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर प्राथमिकता लेता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैरेग्राफ के फ़ॉन्ट गुण सेट करें।
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

![पैरेग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक स्वरूपण और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी स्वरूपण बोल्ड है:

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

![पाठ भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी पुनः उत्पन्न करने या अक्षर ऊँचाई में अंतर की जाँच करने के लिये [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) का उपयोग करें। PowerPoint में समानता सक्षम करने से व्यक्तिगत अक्षर ऊर्ध्वाधर रूप से खींचे या संकुचित होते हैं ताकि वे पाठ भाग के भीतर समान दृश्यमान ऊँचाई प्राप्त कर सकें। यह विभिन्न फ़ॉन्ट्स में समान पाठ ऊँचाई की गारंटी नहीं देता।

गुण को स्पष्ट रूप से सक्षम या अक्षम करने के लिये [NullableBool.True or False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) सेट करें। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है जिससे भाग पैराग्राफ के [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) से इसे विरासत में लेता है। इसका अर्थ `False` नहीं है। समाधानात्मक मान प्राप्त करने के लिये [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) और [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) का उपयोग करें।

निम्न स्वतंत्र उदाहरण **Arial** के स्थापित होने की आवश्यकता रखता है। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें वही बड़े अक्षर, छोटे अक्षर, नीचे वाले अक्षर और उच्चारित अक्षर 54 पॉइंट पर होते हैं। दोनों पैरेग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम रखते हैं। शीर्ष भाग इसे स्पष्ट रूप से अक्षम करता है; निचला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैरेग्राफ अंतराल समान हैं, रैपिंग और ऑटोफ़िट अक्षम हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: false` और `NotDefined: true` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

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

नीचे की तुलना सहेजी गई प्रस्तुति से निर्यात की गई है। शीर्ष पंक्ति में सामान्यीकरण अक्षम (`False`) है; निचली पंक्ति में वह विरासत में मिला (`NotDefined` → `True`) है। इस दिखावट को पुनः उत्पन्न करने के लिये Arial स्थापित रखें।

![Arial 54‑पॉइंट पाठ, ऊपर सामान्यीकरण अक्षम और नीचे विरासत में सामान्यीकरण सक्षम](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदले बिना असाइन किए गए [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) मान को बदले बिना बदलता है, जो फ़ॉन्ट आकार पॉइंट्स में निर्दिष्ट करता है। पैरेग्राफ का [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) लाइन अंतराल को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम का [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि पाठ या उसका कंटेनर फिट होने के लिये कैसे समायोजित हो। ये सेटिंग्स अलग‑अलग उद्देश्यों के लिये हैं और समग्र लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। अधिक जानकारी के लिये देखें [Manage Paragraph](/slides/hi/java/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू व हटाएँ**

पाठ भाग पर [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) का उपयोग करके आप सुधार, रद्द शब्द या पहले की कीमतें मूल पाठ को हटाए बिना दिखा सकते हैं। इसे [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) पर सेट करने से एक या दो रेखाएँ पाठ के ऊपर खींची जाती हैं।

स्ट्राइकथ्रू हटाने के लिये [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) पास करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास का स्वरूपण स्ट्राइकथ्रू निर्दिष्ट करता हो। इसके विपरीत, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अनिर्धारित छोड़ देता है, जिससे भाग पैराग्राफ से विरासत में स्वरूपण ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामस्वरूप स्वरूपण पढ़ने के लिये, जिसमें विरासत में मिला मान भी शामिल है, [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) का उपयोग करें।

निम्न स्वतंत्र उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैरेग्राफ में लेबल, पूर्व कीमत और वर्तमान कीमत के लिये अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः एक‑रेखा व दो‑रेखा स्ट्राइकथ्रू रहता है। इस सेटिंग को बदलने से पाठ तथा उसके अन्य स्वरूपण, जिसमें बोल्ड पूर्व कीमत भी शामिल है, संरक्षित रहता है।

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

    // स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ।
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, एक‑रेखा स्ट्राइकथ्रू, और दो‑रेखा स्ट्राइकथ्रू।

![पिछली कीमतें बिना स्ट्राइकथ्रू, एक‑रेखा स्ट्राइकथ्रू, और दो‑रेखा स्ट्राइकथ्रू के साथ](strikethrough.png)

## **पाठ घुमाव सेट करें**

शेप के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करने के लिये [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण पाठ अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) पर सेट करता है, जिससे पाठ **90 डिग्री घड़ी की विपरीत दिशा में** घुड़ता है:

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

## **ऊर्ध्वाधर पाठ में अंक साथ‑साथ दिखाएँ**

वर्टिकल जापानी लेबल में दो‑अंकीय संख्या को साथ‑साथ रखने के लिये दोनों अंकों को एक ही पाठ भाग में रखें और उस भाग पर [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) को कॉल करें। उदाहरण में [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) और दोनों लेबल के लिये 40‑पॉइंट MS Gothic का उपयोग किया गया है। केवल संख्यात्मक भाग को पास किया गया [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) मान अलग है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में बायाँ लेबल (`True`) अंक को सीधा और साथ‑साथ दिखाता है (和 और 年 के मध्य)। दायाँ लेबल (`False`) में अंक 90 डिग्री घड़ी की दिशा में घुड़ता है। दोनों लेबल में आसपास के जापानी अक्षर सीधे ही रहते हैं।

![बायाँ लेबल में सीधे अंक और दायाँ लेबल में घुड़े अंक के साथ वर्टिकल तिथि लेबल की PowerPoint तुलना](vertical_date.png)

## **पाठ फ्रेम के लिये अनुकूलित घुमाव सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) के लिये अनुकूलित घुमाव कोण सेट करें।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमा देता है:

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

![अनुकूलित पाठ घुमाव](custom_text_rotation.png)

## **पैरेग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides निम्नलिखित के लिये पैराग्राफ स्पेसिंग नियंत्रित करने वाले मेथड प्रदान करता है: [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-)। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को प्रतिशत के रूप में निर्दिष्ट करने के लिये धनात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिये ऋणात्मक मान का उपयोग करें।

निम्न उदाहरण पहले पैरेग्राफ के भीतर स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![पैरेग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

संकीर्ण टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियन पाठ के मिश्रण वाले प्रस्तुतियों में पैरेग्राफ लाइन‑ब्रेकिंग नियम उपयोगी होते हैं। निम्न मेथड्स [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैरेग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से ईस्ट एशियन पाठ व विराम चिह्नों के रैपिंग स्थान भी बदल सकता है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत व अंत में अक्षरों की प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। ये रैपिंग के समय लेआउट को प्रभावित करते हैं; ये लाइन‑ब्रेक अक्षर नहीं जोड़ते। एक स्पष्ट लाइन‑ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैरेग्राफ के भीतर नई पंक्ति बनाता है।

निम्न स्वतंत्र उदाहरण चीनियों और लैटिन पाठ के साथ संकीर्ण टेक्स्ट ब्लॉक बनाता है। यह दोनों लाइन‑ब्रेक विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को आज़माने के लिये, अन्य सेटिंग को स्थिर रखते हुए संबंधित मान को बदलें। उदाहरण 24‑पॉइंट Arial व SimSun का उपयोग 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ करता है। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) के साथ कॉल किया गया है ताकि पाठ आकार व फ्रेम आयाम स्थिर रहें।

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) पात्रों को पाठ पंक्ति के दायें किनारे से बाहर तक विस्तारित करने की अनुमति देता है, बजाय अगली पंक्ति में ले जाने के। यह पूरे पैरेग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑वाइड टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial व शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दायें किनारे से बाहर तक बढ़ जाता है। तुलना के लिये प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग पंक्ति में दिखेगा। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिये ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि जब पाठ अपने कंटेनर की सीमा से बाहर निकलता है तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिये करें कि क्या पाठ छोटा हो, बाहर निकले या आकार स्वतः बदलकर शैप को फिट करे। निम्न उदाहरण शैप को उसके पाठ के अनुसार आकार बदलने के लिये सेट करता है और परिणाम को "autofit_type.pptx" में सहेजता है।

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

स्वचालित रैपिंग के बाद लाइनों की संख्या गिनने और यह देखने के लिये कि पाठ या शैप की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/java/manage-paragraph/)। केवल लाइन‑काउंट यह निर्धारित नहीं करता कि पाठ कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) शैप के भीतर पाठ को ऊर्ध्वाधर रूप से स्थित करने का तरीका निर्धारित करता है, जैसे ऊपर, मध्य या नीचे। निम्न उदाहरण पहला आकार के नीचे पाठ को एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है।

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

## **टैबुलेशन सेट करें**

पैरेग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिये [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बायाँ‑संतुलित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षर वाले पाठ को प्रभावित करती हैं।

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

![पैरेग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप किसी पाठ भाग के लिये प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिये प्रयुक्त भाषा को निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है, जिसमें पहली स्लाइड पर प्रथम आकार के रूप में एक टेक्स्ट बॉक्स और कम से कम एक पैरेग्राफ हो। यह पहले पैरेग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

### **भाषा मेटाडेटा कॉपी करें**

टेम्पलेट से बहुभाषी पाठ कॉपी करते समय, दोनों [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) और [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) को संरक्षित रखें। निम्न स्वतंत्र उदाहरण एक स्रोत भाग बनाता है जिसकी भाषा US English और वैकल्पिक भाषा French है, और नई प्रस्तुति में एक भाग को पाठ व पहचानकर्ता कॉपी करता है।

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // यदि स्रोत में कोई वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ़ कर देता है।
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

वैकल्पिक भाषा के बिना स्रोत आज़माने के लिये, `"fr-FR"` असाइनमेंट को हटाएँ। तब वैकल्पिक पहचानकर्ता `null` रहेगा, और वही कॉपी स्टेटमेंट इसकी अनुपस्थिति को डिफ़ॉल्ट मान डाले बिना बनाए रखेगा, भले ही गंतव्य में पहले वैकल्पिक भाषा असाइन्ड हो।

इन पहचानकर्ताओं को भाषा मेटाडेटा के रूप में संग्रहीत किया जाता है। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint किस शब्दकोश का उपयोग वर्तनी या व्याकरण जाँच के लिये करता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित पाठ के लिये डिफ़ॉल्ट भाषा निर्धारित करें। निम्न उदाहरण US English को डिफ़ॉल्ट पाठ भाषा के रूप में सेट करके प्रस्तुति बनाता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले पाठ भाग के लिये `en-US` प्रिंट करता है।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // टेक्स्ट के साथ नया आयताकार शैप जोड़ें।
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

प्रस्तुति स्तर पर डिफ़ॉल्ट पाठ स्वरूपण लागू करने के लिये [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैरेग्राफ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। पाठ इन डिफ़ॉल्ट्स को विरासत में ले सकता है, जब तक कि अधिक विशिष्ट स्वरूपण उन्हें अधिलिखित न करे।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष स्तर के पैरेग्राफ फ़ॉर्मेट प्राप्त करें।
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

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसा पाठ भाग निकालने पर लाइब्रेरी मूल रूप से दर्ज किया गया पाठ लौटाती है। प्रदर्शित पाठ से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार टेक्स्ट बॉक्स है। उसके पहले पैरेग्राफ के पहले भाग में "Hello, Aspose!" **All Caps** प्रभाव के साथ है, जैसा कि नीचे दिखाया गया है।

![ऑल‑कैप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** प्रभाव लागू होने वाले पाठ को निकालने का तरीका दर्शाता है:

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

**स्लाइड में तालिका के पाठ को कैसे संशोधित करें?**

स्लाइड में तालिका के पाठ को संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटरिट करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) तथा पैरेग्राफ स्वरूपण को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर पाठ में ग्रेडिएंट रंग कैसे लागू करें?**

पाठ में ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।

संबंधित सुविधा: [Format text within slides](/slides/hi/features/text-formatting/).