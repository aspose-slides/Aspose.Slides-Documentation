---
title: Android पर प्रस्तुति टेक्स्ट फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/androidjava/text-formatting/
keywords:
- पैराग्राफ को संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट प्रॉपर्टीज़
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट प्रॉपर्टी
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि कैसे PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को Aspose.Slides for Android via Java का उपयोग करके फ़ॉर्मेट किया जाए। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट प्रॉपर्टीज़, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स, और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा उल्लेख न किया गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। पहले स्लाइड पर पहला शेप एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को सम्मिलित करता है। स्लाइड और शेप दोनों के इंडेक्स शून्य‑आधारित हैं। बोल्ड हिस्सों को चुनने वाले उदाहरण प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

साक्ष्य टेक्स्ट या रेगुलर‑एक्सप्रेशन मिलान को खोजने और हाईलाइट करने के लिए देखें [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग को पैराग्राफ के लिए सेट करने हेतु [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्के ग्रे हाइलाइट को डिफ़ॉल्ट रूप में सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

नीचे दिया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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

## **टेक्स्ट पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने हेतु [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बाएँ, दाएँ, समानांतर आदि हो सकते हैं।

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

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार वाले टेक्स्ट हिस्सों को एक ही लाइन में लंबवत संरेखित करने हेतु [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक लाइन के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक ही स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36, और 54 पॉइंट का समान टेक्स्ट होता है, जिसकी फ़ॉन्ट संरेखण अलग‑अलग है। यह Arial उपयोग करता है, ऑटोफ़िट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एकल लाइन के लिये पर्याप्त बड़ा रखता है।

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

![Baseline, Top, Center, और Bottom फ़ॉन्ट संरेखण का मिश्रित फ़ॉन्ट आकारों के साथ तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों की दृश्यमान किनारे ठीक‑ठीक नहीं मिल सकते। उदाहरण में एक बड़े अक्षर और एक नीचे गिरने वाला अक्षर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के बीच अंतर स्पष्ट हो सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आकार, मार्जिन, लाइन स्पेसिंग, रैपिंग, और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का प्रयोग करें।

यह सेटिंग [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) से भी अलग है, जो शेप के भीतर टेक्स्ट ब्लॉक को लम्बवत रूप से स्थित करता है। [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग करने से व्यक्तिगत हिस्से बेसलाइन से शिफ्ट होते हैं, न कि पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट होता है।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि प्रतिशत।

नीचे दिया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // टेक्स्ट का फ़िल रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर पारदर्शिता कैसे लागू की जाए:

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

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या सघन करने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को सघन करते हैं।

निम्न Java कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे विस्तारित किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल विस्तारित करें।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में अक्षर अंतराल कैसे विस्तारित किया जाए:

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
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल विस्तारित करें।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट हिस्सों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए कर्निंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए टेक्स्ट से थोड़ा अधिक कसकर दिख सकता है। यह इसलिए होता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में PowerPoint के निकटतम रेंडरिंग प्राप्त करने के लिए, आप उन टेक्स्ट हिस्सों के लिए कर्निंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। इसके लिए [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। इस उदाहरण में "presentation.pptx" आवश्यक है, जिसमें पहले स्लाइड पर पहला शेप एक टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नाम (विर्सित फ़ॉन्ट्स सहित) जाँचता है और Roboto उपयोग करने वाले हिस्सों के लिए 100‑पॉइंट सीमा सेट करता है। इससे 100 पॉइंट से कम आकार वाले मिलते‑जुलते हिस्सों के लिए कर्निंग निष्क्रिय हो जाता है:

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

सीमा से नीचे के मिलते टेक्स्ट के लिये यह सेटिंग कर्निंग को रोकती है और Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के अधिक करीब लाने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ प्रबंधित करें**

फ़ॉन्ट प्रॉपर्टीज़ को पैराग्राफ स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) द्वारा या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) द्वारा सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक फ़ॉर्मेट और डॉटेड अंडरलाइन को उन हिस्सों पर लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट हिस्से के लिए फ़ॉन्ट प्रॉपर्टीज़ सेट करें।
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

![टेक्स्ट हिस्सों के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने हेतु [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइज़** घुमाता है:

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

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम रोटेशन सेट करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) का कस्टम रोटेशन एंगल सेट किया जा सकता है।

नीचे दिया कोड उदाहरण टेक्स्ट फ्रेम को शेप के भीतर 3 डिग्री क्लॉकवाइज़ घुमाता है:

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

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) के माध्यम से पैराग्राफ स्पेसिंग को नियंत्रित करता है। ये प्रॉपर्टीज़ इस प्रकार उपयोग की जाती हैं:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ की लाइन स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

पैराग्राफ लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे की विधियाँ [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होती हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिन्हों के रैपिंग स्थान भी बदल सकते हैं।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक अक्षर सम्मिलित नहीं करते। एक स्पष्ट लाइन‑ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ के भीतर नई लाइन उत्पन्न करता है।

निम्न स्वतंत्र उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट दोनों होते हैं। यह दोनों लाइन‑ब्रेक विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, अन्य सेटिंग को स्थिर रखते हुए संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun फ़ॉन्ट, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन का उपयोग करता है। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) से कॉल किया जाता है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पंक्चुएशन नियंत्रित करें**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) योग्य विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे से बाहर तक विस्तारित करने की अनुमति देता है, बजाय अगले लाइन में ले जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑वाइड टेक्स्ट फ्रेम में हैंगिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक बढ़ता है। तुलना हेतु प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) पर सेट करें: इस सेटिंग में बिंदु अलग लाइन लेता है। रैपिंग सक्षम है और ऑटोफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिन्ह हैंग नहीं हो सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से अधिक होने पर वह कैसे व्यवहार करेगा। इसका उपयोग यह नियंत्रित करने के लिये किया जाता है कि टेक्स्ट छोटा हो, बाहर निकले, या शेप को स्वतः री‑साइज़ करे। निम्न उदाहरण शेप को उसके टेक्स्ट को फिट करने के लिये री‑साइज़ सेट करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

स्वतः रैपिंग के बाद लाइनों की संख्या गिनने और टेक्स्ट या शेप की चौड़ाई के परिणाम में परिवर्तन को देखने के लिये देखें [Count Rendered Lines](/slides/hi/androidjava/manage-paragraph/). केवल लाइनों की गणना यह नहीं दर्शाती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) यह निर्धारित करता है कि टेक्स्ट शेप के भीतर लम्बवत रूप से कहाँ स्थित होगा, जैसे शीर्ष, मध्य, या नीचे। निम्न उदाहरण टेक्स्ट को पहले शेप के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

पैराग्राफ में टैब स्टॉप्स कॉन्फ़िगर करने के लिये [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर एक बाएँ‑संतुलित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप टेक्स्ट हिस्से की प्रूफ़िंग भाषा निर्धारित कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिये प्रयुक्त भाषा को निर्धारित करती है।

निम्न उदाहरण के लिये "presentation.pptx" आवश्यक है, जिसमें पहले स्लाइड पर पहला शेप एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहला पैराग्राफ "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और Simplified Chinese प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

लोडिंग या प्रस्तुति बनाते समय निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित करने के लिये [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करें। नीचे दिया उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट हिस्से के लिये `en-US` प्रिंट करता है।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // नया आयताकार शेप टेक्स्ट के साथ जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले हिस्से की भाषा जांचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैराग्राफ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग इन्हें ओवरराइड न करे।

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

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट हिस्सा प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को बिल्कुल उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मिलाने के लिये, [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाई गई स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" आवश्यक करता है, जिसमें पहले स्लाइड पर पहला शेप एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ की पहली हिस्से में "Hello, Aspose!" है, जिस पर All Caps इफ़ेक्ट लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल‑कैप्स इफ़ेक्ट](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू होने पर टेक्स्ट कैसे निकाला जाए:

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

**मैं स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से पुनरावृत्ति करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, और पारदर्शिता को कॉन्फ़िगर करें।