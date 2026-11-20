---
title: Android पर प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/androidjava/text-formatting/
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
- पाठ फ़्रेम
- पंक्ति अंतराल
- ऑटोफ़िट गुण
- पाठ फ़्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अन्य विकल्पों को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Android को Java के माध्यम से उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट करने के तरीके को दर्शाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, अनुच्छेद अंतराल, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा नहीं बताया गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला अनुच्छेद नीचे दिखाए गए पाठ को शामिल करता है। स्लाइड और आकार दोनों की सूचकांक शून्य-आधारित हैं। बड़े भागों को चुनते समय प्रभावी फ़ॉर्मेटिंग का उपयोग किया जाता है, जिसमें विरासत में प्राप्त बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![नमूना पाठ](sample_text.png)

शाब्दिक पाठ या नियमित अभिव्यक्ति मिलानों को खोजने और चिह्नित करने के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/androidjava/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग निर्धारित करें**

एक अनुच्छेद के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत पाठ हिस्सों के लिए [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण प्रथम अनुच्छेद के लिए डिफ़ॉल्ट रूप से हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे अनुच्छेद के लिए हाइलाइट रंग निर्धारित करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे अनुच्छेद](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ हिस्सों** के लिए पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

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
            // पाठ हिस्से के लिए हाइलाइट रंग निर्धारित करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे पाठ हिस्से](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

पाठ फ़्रेम के भीतर अनुच्छेद संरेखण सेट करने के लिए [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) का उपयोग करें। मान को केंद्रित, बाएँ-समरूप, दाएँ-समरूप, औचित्य सहित अन्य विकल्पों में सेट किया जा सकता है।

निम्न कोड उदाहरण अनुच्छेद को **केंद्र** में संरेखित करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // अनुच्छेद का संरेखण केंद्र में निर्धारित करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पंक्ति के भीतर फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार वाले पाठ हिस्सों को एक पंक्ति के भीतर लंबवत संरेखित करने के लिए [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) का उपयोग करें। यह सेटिंग पूरे अनुच्छेद पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वनिर्भर उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक अनुच्छेद में 18, 36, और 54 पॉइंट के समान पाठ होते हैं, लेकिन प्रत्येक का फ़ॉन्ट संरेखण अलग होता है। यह Arial का उपयोग करता है, ऑटोफ़िट और रैपिंग को निष्क्रिय करता है, तथा टेक्स्ट फ़्रेम को केवल एक पंक्ति के लिये पर्याप्त बड़ा रखता है।

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

![Baseline, Top, Center, Bottom फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मेट्रिक्स पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के स्पष्ट किनारे ठीक-ठीक मेल नहीं खा सकते। उदाहरण में एक बड़े अक्षर और एक डिसेंडर दोनों शामिल हैं ताकि बेसलाइन और नीचे वाले संरेखण के बीच अंतर दिखे। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, प्रयुक्त अक्षर और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, पंक्ति अंतराल, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) से अलग है, जो क्षैतिज अनुच्छेद संरेखण नियंत्रित करता है, और [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) से भी, जो आकार के भीतर पाठ ब्लॉक को लंबवत स्थित करता है। [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) के माध्यम से अपर और अधोस्क्रिप्ट फ़ॉर्मेटिंग व्यक्तिगत हिस्सों को बेसलाइन के सापेक्ष स्थानांतरित करती है, न कि अनुच्छेद की पंक्तियों के फ़ॉन्ट संरेखण को सेट करती है।

## **पाठ के लिए पारदर्शिता निर्धारित करें**

पारदर्शिता को [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) को असाइन किए गए रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे दिए गए उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरे अनुच्छेद** पर पारदर्शिता लागू करने को दर्शाता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पाठ का भराव रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ हिस्सों** पर पारदर्शिता लागू करने को दर्शाता है:

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
            // पाठ हिस्से की पारदर्शिता निर्धारित करें।
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

![पारदर्शी पाठ हिस्से](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल निर्धारित करें**

एक टेक्स्ट बॉक्स में अक्षर अंतराल को विस्तारित या घटाने के लिए [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) का उपयोग करें। उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान पाठ को घटाते हैं।

निम्न Java कोड **पूरे अनुच्छेद** में अक्षर अंतराल को बढ़ाने को दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर अंतराल को संकुचित करने के लिये नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल को विस्तारित करें।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **पाठ हिस्सों** में अक्षर अंतराल को बढ़ाने को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: अक्षर अंतराल को संकुचित करने के लिये नकारात्मक मानों का उपयोग करें।
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

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखने वाले पाठ से थोड़ा अधिक कसकर दिखाई दे सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी मौजूद हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिए, आप उन पाठ हिस्सों में केरनिंग अक्षम कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। इसे करने के लिए [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण "presentation.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो। यह प्रभावी फ़ॉन्ट नामों, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, को जाँचता है और Roboto का उपयोग करने वाले हिस्सों के लिए 100 पॉइंट सीमा निर्धारित करता है। यह 100 पॉइंट से कम फ़ॉन्ट आकार वाले मेल खाने वाले हिस्सों के लिए केरनिंग अक्षम कर देता है:

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

सीमा से नीचे के मिलते हुए पाठ के लिए, यह सेटिंग केरनिंग को रोकती है और प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद करती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण अनुच्छेद स्तर पर [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण प्रथम अनुच्छेद की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // अनुच्छेद के लिए फ़ॉन्ट गुण निर्धारित करें।
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

![अनुच्छेद के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन हिस्सों पर 13‑पॉइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // पाठ हिस्से के लिए फ़ॉन्ट गुण निर्धारित करें।
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

![पाठ हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को पुनः उत्पन्न करने या अक्षर ऊँचाई में अंतर की जाँच करने के लिए [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) का उपयोग करें। PowerPoint में, सामान्यीकरण सक्षम करने से व्यक्तिगत अक्षर लंबवत रूप से खिंचते या संकुचित होते हैं ताकि वे पाठ हिस्से के भीतर समान दृश्य ऊँचाई प्राप्त कर सकें। यह विभिन्न फ़ॉन्ट्स के बीच समान पाठ ऊँचाई की गारंटी नहीं देता।

स्वयं स्पष्ट रूप से सामान्यीकरण को सक्षम या अक्षम करने के लिए [NullableBool.True or False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) सेट करें। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि हिस्सा अनुच्छेद के [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) से मान विरासत में ले सके। इसका अर्थ `False` नहीं है। हल्के फ़ॉर्मेटिंग को पढ़ने के लिए [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) और [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) का उपयोग करके परिणामी Boolean मान प्राप्त करें।

निम्न स्वनिर्भर उदाहरण **Arial** के स्थापित होने की आवश्यकता रखता है। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, डिसेंडर और 54 पॉइंट पर एक्सेंटेड अक्षर होते हैं। दोनों अनुच्छेद डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। शीर्ष हिस्सा स्पष्ट रूप से इसे अक्षम करता है; निचला हिस्सा इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और अनुच्छेद अंतराल समान हैं, तथा रैपिंग और ऑटोफ़िट निष्क्रिय हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: false` और `NotDefined: true` प्रिंट करता है, फिर "text_height_normalization.pptx" को सहेजता है।

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

नीचे दिया गया तुलना सहेजे गए प्रस्तुतीकरण से निर्यात किया गया है। शीर्ष पंक्ति में सामान्यीकरण अक्षम (`False`) है; निचली पंक्ति विरासत में लेता है (`NotDefined` → `True`)। इस दृश्य को पुनः उत्पन्न करने के लिये Arial स्थापित रखें।

![Arial 54‑पॉइंट पाठ (ऊपर सामान्यीकरण अक्षम, नीचे विरासत में मिला)](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदलता है जबकि असाइन किया गया [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) मान अपरिवर्तित रहता है, जो फ़ॉन्ट आकार पॉइंट में दर्शाता है। अनुच्छेद [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) पंक्ति अंतराल नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) टेक्स्ट या उसके कंटेनर को फिट करने के लिये आकार बदलता है। ये सेटिंग्स अलग‑अलग उद्देश्यों के लिये हैं और समग्र लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। अनुच्छेद फ़ॉर्मेटिंग और विरासत के बारे में अधिक जानकारी के लिये देखें [Manage Paragraph](/slides/hi/androidjava/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

टेक्स्ट हिस्से पर स्ट्राइकथ्रू लागू करने के लिये [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) का उपयोग करें, जिससे संशोधित, रद्द किए गए शब्द या पिछले मूल्य बिना मूल पाठ को हटाए दिखाए जा सकते हैं। इसे [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) पर सेट करने से पाठ पर एक या दो रेखाएँ लगती हैं।

स्ट्राइकथ्रू हटाने के लिये [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) पास करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास की फ़ॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करे। इसके विपरीत, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अपरिभाषित छोड़ देता है, जिससे हिस्सा पैराग्राफ से फ़ॉर्मेटिंग विरासत में ले सकता है। यह अनिवार्य नहीं करता कि स्ट्राइकथ्रू हट गया हो। परिणामी फ़ॉर्मेटिंग, जिसमें विरासत मान भी शामिल हैं, को पढ़ने के लिये [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) का उपयोग करें।

निम्न स्वनिर्भर उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक अनुच्छेद में लेबल, पुराना मूल्य और वर्तमान मूल्य के लिये अलग-अलग हिस्से होते हैं, इसलिए केवल पुराना मूल्य प्रभावित होता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; बाकी पंक्तियों में क्रमशः एक और दो रेखा स्ट्राइकथ्रू बना रहता है। इस सेटिंग को बदलने से पाठ और उसके अन्य फ़ॉर्मेटिंग, जैसे बोल्ड पुराना मूल्य, बना रहता है।

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

परिणाम (ऊपर से नीचे): कोई स्ट्राइकथ्रू नहीं, एक रेखा स्ट्राइकथ्रू, दो रेखा स्ट्राइकथ्रू।

![पहले मूल्य बिना स्ट्राइकथ्रू, एक रेखा स्ट्राइकथ्रू, दो रेखा स्ट्राइकथ्रू](strikethrough.png)

## **पाठ घूर्णन निर्धारित करें**

एक आकार के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करने के लिये [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्न कोड उदाहरण आकार में पाठ अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) पर सेट करता है, जिससे पाठ **90 डिग्री प्रतिक्लॉकवाइज़** घूमेंगा:

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

## **टेक्स्ट फ़्रेम के लिये कस्टम घूर्णन निर्धारित करें**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) के लिये कस्टम घूर्णन कोण सेट किया जा सकता है।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ़्रेम को 3 डिग्री क्लॉकवाइज़ घुमा देता है:

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

## **अनुच्छेदों की पंक्ति अंतराल निर्धारित करें**

Aspose.Slides निम्न प्रॉपर्टीज़ प्रदान करता है: [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), और [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) ताकि अनुच्छेद अंतराल नियंत्रित किया जा सके। इनका प्रयोग इस प्रकार है:

* पंक्ति अंतराल को पंक्ति ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिये धनात्मक मान उपयोग करें।
* पंक्ति अंतराल को पॉइंट में निर्दिष्ट करने के लिये ऋणात्मक मान उपयोग करें।

निम्न उदाहरण प्रथम अनुच्छेद के भीतर अंतराल को पंक्ति ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![अनुच्छेद में पंक्ति अंतराल](line_spacing.png)

## **पंक्ति विभाजन नियंत्रित करें**

संकीर्ण टेक्स्ट ब्लॉकों और लैटिन तथा ईस्ट एशियन पाठ के मिश्रण वाले प्रस्तुतियों में अनुच्छेद पंक्ति‑विच्छेद नियम उपयोगी होते हैं। निम्न विधियाँ [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) की हैं, इसलिए वे पूरे अनुच्छेद पर लागू होती हैं:

* [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) लैटिन पंक्ति‑विच्छेद नियम नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से आस-पास के ईस्ट एशियन पाठ एवं विराम चिह्नों के रैप भी बदल सकते हैं।
* [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन पंक्ति‑विच्छेद नियम नियंत्रित करता है, जिसमें पंक्ति की शुरुआत या अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। वे तभी लेआउट को प्रभावित करते हैं जब रैपिंग होती है; वे पंक्ति‑विच्छेद अक्षर नहीं डालते। एक स्पष्ट पंक्ति‑विच्छेद नई पंक्ति बनाता है, चाहे उपलब्ध चौड़ाई कुछ भी हो।

निम्न स्वनिर्भर उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन पाठ सम्मिलित है। यह दोनों पंक्ति‑विच्छेद विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। प्रत्येक नियम को प्रयोग करने के लिये, एक मान बदलें जबकि दूसरे को समान रखें। उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग करता है, फ्रेम चौड़ाई 160‑पॉइंट और क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन शून्य हैं। [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) पर सेट किया गया है ताकि पाठ आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैन्गिंग विराम चिह्न नियंत्रित करें**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) योग्य विराम चिह्नों को पाठ पंक्ति के दाएँ किनारे से आगे बढ़ने की अनुमति देता है, न कि अगले पंक्ति में ले जाता है। यह पूरे अनुच्छेद पर लागू होता है और हैन्गिंग इंडेंट से अलग है।

निम्न स्वनिर्भर उदाहरण 100‑पॉइंट‑चौड़ाई के टेक्स्ट फ़्रेम में हैन्गिंग विराम चिह्न सक्रिय करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से आगे निकल जाता है। तुलना के लिये प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, बिंदु एक अलग पंक्ति ले लेगा। रैपिंग सक्रिय है और ऑटोफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैन्ग नहीं कर सकता। उपरोक्त वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिये ऑटोफ़िट प्रकार निर्धारित करें**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) निर्धारित करता है कि जब टेक्स्ट कंटेनर की सीमाओं से अधिक हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिये करें कि टेक्स्ट सिकुड़ता है, बाहर निकलता है, या आकार को स्वचालित रूप से बदलता है। निम्न उदाहरण आकार को उसके पाठ के अनुसार रिसाइज़ करने के लिये कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

स्वचालित रैपिंग के बाद पंक्तियों की संख्या गिनने और यह देखने के लिये कि पाठ या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/androidjava/manage-paragraph/)। पंक्ति गणना अकेले यह नहीं दर्शाती कि पाठ कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ़्रेम के एंकर को निर्धारित करें**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) आकार के भीतर टेक्स्ट को लंबवत किस स्थिति पर रखा जायेगा, जैसे शीर्ष, मध्य या नीचे, यह तय करता है। निम्न उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

## **टेक्स्ट टैबुलेशन निर्धारित करें**

[**IParagraphFormat.setDefaultTabSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) और [**IParagraphFormat.getTabs**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) का उपयोग करके अनुच्छेद में टैब स्टॉप कॉन्फ़िगर कर सकते हैं। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर एक बाएँ‑संगत टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षरों वाले पाठ को प्रभावित करती हैं।

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

![अनुच्छेद टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा निर्धारित करें**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जिससे आप पाठ हिस्से के लिये प्रूफ़िंग भाषा निर्धारित कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिये प्रयुक्त भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो और कम से कम एक अनुच्छेद हो। यह प्रथम अनुच्छेद की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजता है:

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

    // प्रूफ़िंग भाषा की Id निर्धारित करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **भाषा मेटाडेटा कॉपी करें**

जब किसी टेम्पलेट से बहुभाषी पाठ कॉपी किया जाये, तो दोनों [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) और [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) को संरक्षित रखें। निम्न स्वनिर्भर उदाहरण स्रोत भाग बनाता है जिसका भाषा US English है और वैकल्पिक भाषा French है, तथा टेक्स्ट और पहचानकर्ताओं को नई प्रस्तुति के एक भाग में कॉपी करता है।

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
    // यदि स्रोत में वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ़ करता है।
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

वैकल्पिक भाषा के बिना स्रोत को आज़माने के लिये, `"fr-FR"` असाइनमेंट को हटा दें। तब वैकल्पिक पहचानकर्ता `null` रहेगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को बिना किसी डिफ़ॉल्ट मान के जोड़ता है, भले ही गंतव्य में पहले कोई वैकल्पिक भाषा असाइन हो।

ये पहचानकर्ता भाषा मेटाडेटा संग्रहीत करते हैं। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint वर्तनी या व्याकरण जांच के लिये कौन-सा शब्दकोश चुनेगा।

## **डिफ़ॉल्ट भाषा निर्धारित करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए जाने वाले पाठ की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट पाठ भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके प्रथम पाठ हिस्से के लिये `en-US` प्रिंट करता है।

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

    // पहले हिस्से की भाषा जाँचें।
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट पाठ शैली निर्धारित करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट पाठ फ़ॉर्मेटिंग लागू करने के लिये [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) का प्रयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के अनुच्छेदों के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप में सेट करता है और "default_text_style.pptx" में सहेजता है। जब तक अधिक विशिष्ट फ़ॉर्मेटिंग ओवरराइड न करे, पाठ इन डिफ़ॉल्ट्स को विरासत में ले सकता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // शीर्ष‑स्तर के अनुच्छेद फ़ॉर्मेट प्राप्त करें।
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

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ इस प्रकार का पाठ भाग प्राप्त करने पर लाइब्रेरी वही स्ट्रिंग लौटाती है जैसा इनपुट किया गया था। प्रदर्शित पाठ से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) जाँचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो। उसके प्रथम अनुच्छेद का पहला भाग "Hello, Aspose!" को **All Caps** प्रभाव के साथ रखता है, जैसा नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** प्रभाव लागू हुए पाठ को निकालने को दर्शाता है:

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

**मैं स्लाइड में तालिका के पाठ को कैसे संशोधित करूँ?**

स्लाइड में तालिका के पाठ को संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से लूप करें और प्रत्येक कोशिका को [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) के माध्यम से अपडेट करें तथा अनुच्छेद फ़ॉर्मेट को [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) से अपडेट करें।

**मैं PowerPoint स्लाइड पर पाठ के लिये ग्रेडिएंट रंग कैसे लागू करूँ?**

पाठ पर ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) का उपयोग करें। [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा तथा पारदर्शिता को कॉन्फ़िगर करें।