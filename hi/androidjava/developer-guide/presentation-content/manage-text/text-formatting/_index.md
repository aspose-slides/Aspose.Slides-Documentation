---
title: Android पर प्रस्तुति टेक्स्ट को स्वरूपित करें
linktitle: टेक्स्ट स्वरूपण
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
- टेक्स्ट फ़्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- टेक्स्ट फ़्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **परिचय**

यह लेख दिखाता है कि Aspose.Slides for Android (Java के माध्यम से) का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित किया जाए। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा नहीं बताया गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए पाठ को शामिल करता है। स्लाइड और आकार दोनों के इंडेक्स शून्य-आधारित हैं। जो उदाहरण बोल्ड भागों को चयनित करते हैं, वे प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड स्वरूपण भी शामिल है:

![उदाहरण पाठ](sample_text.png)

पाठ खोजें और बदलें देखें: [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/).

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

किसी पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाइलाइट को डिफ़ॉल्ट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

![धूसर पैराग्राफ](gray_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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
            // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बाएँ-समंरुद्ध, दाएँ-समंरुद्ध, व्यवस्थित, आदि हो सकता है।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

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

![संरूपित पैराग्राफ](aligned_paragraph.png)

## **पंक्ति के भीतर फ़ॉन्ट संरेखित करें**

पंक्ति के भीतर विभिन्न फ़ॉन्ट आकारों वाले टेक्स्ट भागों को लंबवत संरेखित करने के लिए [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में समान पाठ 18, 36, और 54 पॉइंट पर होता है, प्रत्येक फ़ॉन्ट संरेखण अलग है। यह Arial का उपयोग करता है, ऑटोफ़िट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ़्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![विभिन्न फ़ॉन्ट आकारों के साथ बेसलाइन, शीर्ष, मध्य और निचला फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे बिल्कुल नहीं मिल सकते। उदाहरण में एक अपरकेस अक्षर और एक डिसेंडर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता एवं प्रतिस्थापन, उपयोग किए गए वर्ण, तथा फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आकार, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग का उपयोग करें।

यह सेटिंग [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) से, जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि पैराग्राफ लाइनों के लिए फ़ॉन्ट संरेखण सेट करता है।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे दिए उदाहरणों में `alpha = 50` ARGB अल्फा-चैनल मान है 0–255 स्केल पर, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरा पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // टेक्स्ट का भराव रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता कैसे लागू की जाए:

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
            // टेक्स्ट भाग की पारदर्शिता सेट करें।
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

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाने या घटाने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें। उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्न Java कोड दिखाता है कि **पूरा पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

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

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल कैसे बढ़ाया जाए:

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

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए कर्निंग अक्षम करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट से थोड़ा अधिक टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसी स्थितियों में रेंडर किए गए आउटपुट को PowerPoint के करीब लाने के लिए आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट भागों के लिए कर्निंग अक्षम कर सकते हैं। वास्तविक फ़ॉन्ट आकार से बड़े मान पर [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) सेट करें। यह उदाहरण "presentation.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) की जाँच करता है, और Roboto का उपयोग करने वाले भागों के लिए 100 पॉइंट थ्रेशहोल्ड सेट करता है। यह 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले भागों के लिए कर्निंग अक्षम करता है:

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

थ्रेशहोल्ड से नीचे के मिलते हुए टेक्स्ट के लिए यह सेटिंग कर्निंग को रोकती है और उन फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint की दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है, जो इस PowerPoint-विशिष्ट व्यवहार से प्रभावित होते हैं।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ के डिफ़ॉल्ट फ़ॉन्ट को 12-पॉइंट Times New Roman में बोल्ड, इटैलिक और डॉटेड अंडरलाइन स्वरूपण के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर प्राथमिकता लेता है:

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

![पैराग्राफ के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13-पॉइंट Times New Roman, इटैलिक स्वरूपण और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी स्वरूपण बोल्ड है:

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

![टेक्स्ट भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को पुनः उत्पन्न करने या अक्षर ऊँचाई में अंतर की जांच करने के लिए [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षर ऊँभवतया खिंचते या संकुचित होते हैं ताकि टेक्स्ट भाग के भीतर उनका दृश्य ऊँचाई समान हो सके। यह विभिन्न फ़ॉन्ट्स में समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

इस गुण को स्पष्ट रूप से सक्षम या अक्षम करने के लिए [NullableBool.True or False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) सेट करें। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट रखता है जिससे भाग पैराग्राफ के [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) से मान विरासत में लेता है। इसका अर्थ `False` नहीं है। हल किए गए बूलियन मान प्राप्त करने के लिए [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) और [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) पढ़ें।

निम्न स्व-निहित उदाहरण को **Arial** स्थापित होना आवश्यक है। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें समान अपरकेस अक्षर, लोअरकेस अक्षर, डिसेंडर और 54 पॉइंट पर एक्सेंटेड अक्षर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। ऊपर वाला भाग स्पष्ट रूप से इसे अक्षम करता है; नीचे वाला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटोफ़िट निष्क्रिय हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: false` और `NotDefined: true` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

नीचे की तुलना सहेजे गए प्रेजेंटेशन से निर्यातित है। शीर्ष पंक्ति में सामान्यीकरण अक्षम है (`False`); नीचे की पंक्ति में सक्षम सेटिंग विरासत में ली गई है (`NotDefined` → `True`)। इस रूप को पुनः उत्पन्न करने के लिए Arial स्थापित रखें।

![Arial 54‑बिंदु टेक्स्ट, ऊपर सामान्यीकरण अक्षम, नीचे विरासत में सामान्यीकरण सक्षम](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदलता है बिना असाइन किए गए [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) मान को बदले, जो पॉइंट में फ़ॉन्ट आकार निर्दिष्ट करता है। पैराग्राफ [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) टेक्स्ट या उसके कंटेनर को फ़िट करने के तरीके को नियंत्रित करता है। ये सेटिंग्स अलग उद्देश्यों की सेवा करती हैं और समग्र लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ स्वरूपण और विरासत के बारे में अधिक जानकारी के लिए देखें [Manage Paragraph](/slides/hi/androidjava/manage-paragraph/)।

## **स्ट्राइक्रॉफ़्ट लागू करें और हटाएँ**

टेक्स्ट भाग पर [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) का उपयोग करके सुधार, रद्द किए गए शब्द या पूर्व कीमतें बिना मूल पाठ हटाए प्रदर्शित कर सकते हैं। इसे [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) पर सेट करके टेक्स्ट पर एक या दो रेखाएँ लागू की जा सकती हैं।

स्ट्राइक्रॉफ़्ट हटाने के लिए [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) पास करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास का स्वरूपण स्ट्राइक्रॉफ़्ट निर्दिष्ट करता हो। इसके विपरीत, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अनपरिभाषित छोड़ देता है, जिससे भाग पैराग्राफ आदि से स्वरूपण विरासत में लेता है। यह गारंटी नहीं देता कि स्ट्राइक्रॉफ़्ट हट गया है। परिणामी स्वरूपण, जिसमें विरासत वाले मान शामिल हैं, पढ़ने के लिए [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) का उपयोग करें।

निम्न स्व‑निहित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व मूल्य और वर्तमान मूल्य के लिए अलग-अलग भाग होते हैं, इसलिए केवल पूर्व मूल्य प्रभावित होता है। पहली पंक्ति स्ट्राइक्रॉफ़्ट लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः एकल और दोहरी स्ट्राइक्रॉफ़्ट रहती है। इस सेटिंग को बदलने से टेक्स्ट और उसका अन्य स्वरूपण, जिसमें बोल्ड पूर्व मूल्य शामिल है, संरक्षित रहता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // स्ट्राइक्रॉफ़्ट लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ।
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइक्रॉफ़्ट नहीं, एकल स्ट्राइक्रॉफ़्ट, और दोहरी स्ट्राइक्रॉफ़्ट।

![बिना स्ट्राइक्रॉफ़्ट के पिछले मूल्य, एकल स्ट्राइक्रॉफ़्ट और दोहरी स्ट्राइक्रॉफ़्ट वाले मूल्य](strikethrough.png)

## **टेक्स्ट घूर्णन सेट करें**

आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइज़** घुमाता है:

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

## **वर्टिकल टेक्स्ट में अंक एक साथ दिखाएँ**

वर्टिकल जापानी लेबल में दो-अंकीय संख्या को साथ रखने के लिए दोनों अंकों को एक टेक्स्ट भाग में रखें और उस भाग पर [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) कॉल करें। उदाहरण [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) और दोनों लेबल के लिए 40‑पॉइंट MS Gothic का उपयोग करता है। केवल संख्यात्मक भाग को पास किया गया [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) मान अलग है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

PowerPoint में, बायें लेबल (`True`) में अंक 和 और 年 के बीच सीधे और साथ में दिखते हैं। दायें लेबल (`False`) में यह जोड़ी 90 डिग्री घड़ी की दिशा में घुमी हुई होती है। दोनों लेबल में आसपास के जापानी अक्षर सीधे रहते हैं।

![वर्टिकल डेट लेबल में बायें अंक सीधे और दायें घुड़े हुए की तुलना](vertical_date.png)

## **टेक्स्ट फ़्रेम्स के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

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

Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के भीतर स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

पैरेग्रेस में लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉक्स और लैटिन व ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्न विधियाँ [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए ये पूरे पैराग्राफ पर लागू होती हैं:

* [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलना पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिह्न की रैपिंग को भी बदल सकता है।
* [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत पर अक्षरों की सीमाएँ शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को बदलते नहीं हैं, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। रैपिंग होने पर ये लेआउट को प्रभावित करते हैं; ये लाइन‑ब्रेक वर्ण नहीं डालते। एक स्पष्ट लाइन ब्रेक पैराग्राफ के भीतर नई पंक्ति बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्व‑निहित उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट होता है। यह दोनों लाइन‑ब्रेकिंग विकल्प स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी नियम के साथ प्रयोग करने के लिए संबंधित मान बदलें जबकि अन्य सेटिंग समान रखें। उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग करता है, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) के साथ बुलाया जाता है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) योग्य विराम चिह्न को टेक्स्ट लाइन के दाहिने किनारे से आगे बढ़ाने की अनुमति देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्व‑निहित उदाहरण 100‑पॉइंट-चौड़ी टेक्स्ट फ़्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से आगे बढ़ता है। तुलना के लिए गुण को [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स में बिंदु अलग लाइन ले लेता है। रैपिंग सक्षम है और ऑटोफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

सभी विराम चिह्न हैंग नहीं कर सकते। ऊपर वर्णित [फ़ॉन्ट और लेआउट स्थितियां](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ़्रेम्स के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि कंटेनर की सीमा से बाहर जाने पर टेक्स्ट कैसे व्यवहार करता है। इसका उपयोग टेक्स्ट को छोटा करना, ओवरफ़्लो करना, या आकार को स्वचालित रूप से री‑साइज़ करना नियंत्रित करने के लिए करें। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार री‑साइज़ करता है और परिणाम को "autofit_type.pptx" में सहेजता है:

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

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/androidjava/manage-paragraph/)। केवल लाइनों की संख्या यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर है या नहीं।

## **टेक्स्ट फ़्रेम्स का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) निर्धारित करता है कि आकार के भीतर टेक्स्ट को ऊँभवतया कैसे स्थित किया जाए, जैसे ऊपर, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है:

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

पैराग्राफ में टैब स्टॉप को कॉन्फ़िगर करने के लिए [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर एक बाएँ‑समंरुद्ध टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब वर्ण वाले टेक्स्ट को प्रभावित करती हैं:

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

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण "presentation.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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

### **भाषा मेटाडाटा कॉपी करें**

टेम्पलेट से बहुभाषी टेक्स्ट कॉपी करते समय [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) और [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) दोनों को संरक्षित रखें। निम्न स्व‑निहित उदाहरण स्रोत भाग को US English भाषा और French वैकल्पिक भाषा के साथ बनाता है और टेक्स्ट तथा पहचानकर्ताओं को नई प्रस्तुति के एक भाग में कॉपी करता है:

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
    // यदि स्रोत के पास कोई वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ कर देता है।
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

वैकल्पिक भाषा के बिना स्रोत आज़माने के लिए `"fr-FR"` असाइनमेंट को हटाएँ। वैकल्पिक पहचानकर्ता तब `null` हो जाएगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को बिना डिफ़ॉल्ट मान डाले संरक्षित रखेगा, चाहे लक्ष्य में पहले वैकल्पिक भाषा असाइन की गई हो।

ये पहचानकर्ता भाषा मेटाडाटा के रूप में संग्रहीत होते हैं। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint वर्तनी या व्याकरण जांच के लिए कौन-सा शब्दकोश चुनता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या बनाए जाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ प्रस्तुति बनाता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
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

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट स्वरूपण लागू करने के लिए [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट स्वरूपण उन्हें ओवरराइड न करे।

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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर अपरकेस दिखाई देता है, भले ही वह मूल रूप से लोअरकेस में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी प्रकार वापस करती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल‑कैप्स प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू हुए टेक्स्ट को कैसे निकालें:

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

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं पर इटररेट करें और प्रत्येक को [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) एवं पैराग्राफ स्वरूपण को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।