---
title: Android पर प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/androidjava/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएँ
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाएं, पहचाने, स्वरूपित करें और अपडेट करें।"
---
## **परिचय**

Aspose.Slides for Android via Java में, स्लाइड टेक्स्ट को टेक्स्ट फ्रेम्स में संग्रहीत किया जाता है जो आकारों (shapes) से जुड़े होते हैं। [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) इंटरफ़ेस सबसे सामान्य टेक्स्ट‑धारक आकार का प्रतिनिधित्व करता है और इसके टेक्स्ट को [IAutoShape.getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) मेथड के माध्यम से एक्सपोज़ करता है।

{{% alert color="info" title="Note" %}}
हर ऑटो‑शेप [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) को लागू करता है, लेकिन हर आकार ऑटो‑शेप नहीं होता या टेक्स्ट फ्रेम का समर्थन नहीं करता। किसी मौजूदा प्रस्तुति को प्रोसेस करते समय, टेक्स्ट तक पहुंचने से पहले यह जांचें कि वह आकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) को लागू करता है या नहीं।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

टेक्स्ट बॉक्स बनाने के लिए, स्लाइड में एक ऑटो‑शेप जोड़ें, उसके टेक्स्ट फ्रेम में टेक्स्ट डालें, और प्रस्तुति सहेजें। निम्न उदाहरण एक आयताकार टेक्स्ट बॉक्स बनाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) को पास किए गए निर्देशांक और आयाम पॉइंट्स में मापे जाते हैं। [IAutoShape.addTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) प्रदान किए गए टेक्स्ट के साथ टेक्स्ट फ्रेम को प्रारंभ करता है।

## **टेक्स्ट बॉक्स आकार की जाँच करना**

क्या कोई ऑटो‑शेप टेक्स्ट बॉक्स के रूप में माना जाता है, यह निर्धारित करने के लिए [IAutoShape.isTextBox](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#isTextBox--) मेथड का उपयोग करें। यह तब उपयोगी होता है जब प्रस्तुति में टेक्स्ट‑धारक और केवल ग्राफ़िकल ऑटो‑शेप दोनों हों।

![एक टेक्स्ट बॉक्स और एक आकार](istextbox.png)

निम्न उदाहरण प्रस्तुति में प्रत्येक ऑटो‑शेप का निरीक्षण करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

नया जोड़ा गया ऑटो‑शेप तब तक टेक्स्ट बॉक्स नहीं माना जाता जब तक उसमें गैर‑खाली टेक्स्ट न हो। आप वह टेक्स्ट [IAutoShape.addTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) या [ITextFrame.setText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) द्वारा उपलब्ध करा सकते हैं। खाली स्ट्रिंग जोड़ने या असाइन करने से [IAutoShape.isTextBox](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#isTextBox--) `false` लौटाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

पहले दो कॉल `true` प्रिंट करेंगे; अंतिम दो `false`।

## **ऐसे आकार को खोजें जो टेक्स्ट फ्रेम का मालिक है**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड को कभी‑कभी एक [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) मिल सकता है, लेकिन यह नहीं पता चलता कि कौन‑सी प्रस्तुति वस्तु इसे रखती है। मालिक वाले [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) तक नेविगेट करने के लिए केवल‑पढ़ने योग्य [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--) मेथड का उपयोग करें।

ऑटो‑शेप या किसी अन्य टेक्स्ट‑धारक आकार द्वारा मौजुद टेक्स्ट फ्रेम के लिए, [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--) मालिक लौटाता है और [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null`। एक्सेस करने से पहले लौटाए गए मान की जाँच करें। आकार और टेबल‑सेल दोनों मालिकों की पहचान करने, जिसमें SmartArt नोड्स से जुड़े आकार भी शामिल हैं, के लिए देखें [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ना**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) मेथड टेक्स्ट फ्रेम को कॉलमों में विभाजित करता है, जबकि [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) कॉलमों के बीच की दूरी पॉइंट्स में सेट करता है। दोनों सेटिंग्स [ITextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/) से संबंधित हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ्रेम के माध्यम से बदली जा सकती हैं। पाठ वही आकार के भीतर कॉलमों के बीच पुनः प्रवाहित होता है; यह किसी अन्य आकार में नहीं चलता।

निम्न उदाहरण 10 पॉइंट कॉलम स्पेसिंग के साथ तीन‑कॉलम टेक्स्ट बॉक्स बनाता है, प्रस्तुति सहेजता है, और आउटपुट फ़ाइल से संग्रहीत सेटिंग्स को फिर पढ़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत कॉलम से टेक्स्ट निकालना**

[ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) का उपयोग करके किसी मौजूदा टेक्स्ट फ्रेम में प्रत्येक दृश्य कॉलम में असाइन किया गया टेक्स्ट प्राप्त किया जा सकता है। यह मेथड प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है, कॉलम‑आधारित पढ़ने के क्रम में। एक‑कॉलम टेक्स्ट फ्रेम एक तत्व वाले एरे को लौटाता है, और खाली कॉलम को खाली स्ट्रिंग से प्रतिनिधित्व किया जाता है। स्ट्रिंग्स में केवल साधारण टेक्स्ट होता है; भाग‑स्तर पर फॉर्मेटिंग संरक्षित नहीं रहती।

यह उपयोगी है जब आपको आवश्यकता हो:

- कॉलम‑आधारित पढ़ने के क्रम को बनाए रखते हुए टेक्स्ट निकालना।
- मल्टी‑कॉलम स्लाइड्स की सामग्री को इंडेक्स या तुलना करना।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड या अन्य गंतव्य पर निर्यात करना।
- कॉलम संख्या को बदलने पर, स्पेसिंग, फ़ॉन्ट या टेक्स्ट‑फ़्रेम आकार को बदलने पर टेक्स्ट के पुनर्वितरण को देखना, जिसका नियंत्रण [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) आदि से किया जाता है।

यह मेथड वर्तमान [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) के भीतर वितरित टेक्स्ट की रिपोर्ट करता है; यह अलग‑अलग आकार या टेक्स्ट बॉक्स के बीच स्वचालित रूप से प्रवाह नहीं करता। कॉलम वितरण उपलब्ध फ़ॉन्ट और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर कर सकता है, इसलिए जब सुसंगत परिणाम आवश्यक हों तो आवश्यक फ़ॉन्ट उपलब्ध हों, यह सुनिश्चित करें।

निम्न उदाहरण एक प्रस्तुति लोड करता है, पहले मल्टी‑कॉलम ऑटो‑शेप के टेक्स्ट फ्रेम को खोजता है, उसकी कॉन्फ़िगर की गई कॉलम संख्या पढ़ता है, और प्रत्येक कॉलम के टेक्स्ट को अलग‑अलग फ़ाइल में लिखता है। जिन आकारों में टेक्स्ट फ्रेम नहीं होता, उन्हें छोड़ दिया जाता है।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट अपडेट करना**

पूरी प्रस्तुति में टेक्स्ट अपडेट करने के लिए, स्लाइड और आकारों को इटररेट करें, ऑटो‑शेप चुनें, और फिर उनके टेक्स्ट भागों को संपादित करें। भाग‑स्तर पर काम करने से आप टेक्स्ट और कैरेक्टर फॉर्मेटिंग दोनों बदल सकते हैं।

निम्न उदाहरण प्रत्येक `years` को `months` से बदलता है और प्रभावित प्रत्येक भाग को बोल्ड करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह ट्रैवर्सल केवल ऑटो‑शेप्स में टेक्स्ट अपडेट करता है। तालिकाओं, चार्ट्स, SmartArt या समूहित आकारों में संग्रहीत टेक्स्ट को अपडेट करने के लिए उन वस्तुओं के अपने संग्रहों को ट्रैवर्स करना आवश्यक है।

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ना**

हाइपरलिंक को किसी विशिष्ट टेक्स्ट भाग से असाइन किया जा सकता है, ताकि केवल वह भाग ही क्लिक करने योग्य हो। भाग को बाहरी URL से जोड़ने के लिए [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) का उपयोग करें।

निम्न उदाहरण लिंक्ड टेक्स्ट बनाता है और उसे एक प्रस्तुति में सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**मास्टर या लेआउट स्लाइड पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/androidjava/manage-placeholder/) अपनी स्थिति और फॉर्मेटिंग को [master slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterslide/) या [layout slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/) से विरासत में ले सकता है। एक नियमित टेक्स्ट बॉक्स उस स्लाइड पर स्वतंत्र आकार होता है जहाँ इसे बनाया गया था और लेआउट बदलने पर प्लेसहोल्डर व्यवहार नहीं अपनाता।

**मैं चार्ट, टेबल या SmartArt में टेक्स्ट बदले बिना टेक्स्ट कैसे बदल सकता हूँ?**

जैसा कि Update Text उदाहरण में दिखाया गया है, केवल उन आकारों को ट्रैवर्स करें जो [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) को लागू करते हैं। चार्ट, टेबल और SmartArt अपने स्वयं के ऑब्जेक्ट मॉडल में टेक्स्ट संग्रहीत करते हैं, इसलिए वह लूप उन वस्तुओं को संशोधित नहीं करता।