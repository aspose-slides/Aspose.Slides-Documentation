---
title: Android पर प्रस्तुति हाइपरलिंक्स प्रबंधित करें
linktitle: हाइपरलिंक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/androidjava/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक फॉर्मेट करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनशील हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके, Java उदाहरणों के साथ, PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, फॉर्मेट करें, अपडेट करें और हटाएं।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आम तौर पर दो उद्देश्यों की सेवा करते हैं:
* टेक्स्ट, आकार, या मीडिया फ्रेम से वेबसाइट खोलें।
* उदाहरण के लिए, सामग्री तालिका से किसी अन्य स्लाइड पर नेविगेट करें।

Aspose.Slides for Android via Java आपको ये लिंक जोड़ने, उनके रूप और ध्वनि को नियंत्रित करने, उनकी गुणों को अपडेट करने और उन्हें हटाने की अनुमति देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम किया जाए और प्रस्तुति, स्लाइड या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुंचा जाए।

{{% alert color="info" title="Note" %}}
आप प्रस्तुति को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}}

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकार या मीडिया फ्रेम को एक वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिं​क असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

रिलेटिव हाइपरलिंक वाली प्रस्तुतियों के लिए, दस्तावेज़-स्तरीय बेस पढ़ने, बदलने या साफ़ करने हेतु देखें [हाइपरलिंक बेस को प्रबंधित करें](/slides/hi/androidjava/presentation-properties/#manage-the-hyperlink-base)।

### **URL हाइपरलिंक टेक्स्ट में जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग के [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) मेथड में एक [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) पास करें। केवल वह टेक्स्ट भाग क्लिक करने योग्य बन जाएगा।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Shapes और Media Frames में URL हाइपरलिंक जोड़ें**

आयत पर पूरे क्षेत्र को क्लिक करने योग्य बनाने के लिए [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) कॉल करें। जब पाठक आयत पर होवर करते हैं तो गंतव्य के बारे में एक संकेत दिखाने के लिए [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) उपयोग करें। दोनों मेथड चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू होते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर कूदने देते हैं। निम्न उदाहरण पहले स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करने के लिए [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) का उपयोग करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक फ़ॉर्मेट करें**

आप लिंक किए गए टेक्स्ट का रंग बदल सकते हैं, जब पाठक लिंक सक्रिय करे तो ध्वनि चला या रोक सकते हैं, और होवर करने पर दिखाई देने वाला टूलटिप सेट कर सकते हैं।

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) का [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) मेथड निर्धारित करता है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग के फ़ॉर्मेट का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) चुनें और भाग की फ़िल रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

इस उदाहरण में, [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) पहला लिंक टेक्स्ट भाग के लाल फ़िल का उपयोग करने के लिए सेट करता है। दूसरा लिंक प्रस्तुति के हाइपरलिंक रंग को बरकरार रखता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ध्वनि**

हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दिए गए मेथड का उपयोग करें:
- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) हाइपरलिंक से जुड़े ऑडियो को निर्दिष्ट करता है।
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) नियंत्रित करता है कि हाइपरलिंक सक्रिय करने पर पूर्व ध्वनि बंद होनी चाहिए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

पहले स्लाइड पर बटन पाठक के अगले स्लाइड पर जाने पर `sampleaudio.wav` की ऑडियो चलाने के लिए [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) का उपयोग करता है। दूसरी स्लाइड पर, एक अलग बटन प्लेबैक रोकने और पाठक को उसी स्लाइड पर रखने के लिए [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) का उपयोग करता है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **हाइपरलिंक ध्वनि निकालें**

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को मेमोरी में [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) और [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) के माध्यम से पढ़ता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **टूलटिप और इंटरैक्शन सेटिंग्स**

आप टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद नीचे दिए गए [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) मेथड को कॉल कर सकते हैं:
- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) लिंक के लिए दर्शक को संकेत के रूप में दिखाने वाला टेक्स्ट सेट करता है।
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) नियंत्रित करता है कि लिंक सक्रिय करने पर उसका गंतव्य देखे गए हाइपरलिंक की सूची में जोड़ दिया जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएँ**

[getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) का उपयोग करके हाइपरलिंक कंटेनर, जिसमें टेक्स्ट-भाग लिंक भी शामिल हैं, को बदलने से पहले एकत्र करें। नीचे दिया गया उदाहरण पहले स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) को कॉल करें; क्लिक कार्रवाई को हटाने से उसका माउस-ओवर समकक्ष नहीं हटता।

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

अशर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) चयनित स्कोप में एक कॉल में दोनों सक्रियता प्रकारों को हटाता है। चयनात्मक सफ़ाई और मास्टर, लेआउट और नोट्स को कवर करने के लिए, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

### **SmartArt टेक्स्ट बदलने से पहले हाइपरलिंक साफ़ करें**

जब आप मौजूदा SmartArt नोड में एक पैराग्राफ बदलते हैं, तो उसके टेक्स्ट भागों को साफ़ करने से पुराना हाइपरलिंक प्रभाव में रह सकता है। पैराग्राफ को [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getTextFrame--) के माध्यम से प्राप्त करें। उसके भागों को साफ़ करने से पहले, पैराग्राफ दिखाने वाले नोड आकार के टेक्स्ट फ्रेम पर [getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) कॉल करें, फिर लौटाए गए ऑब्जेक्ट पर [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) कॉल करें। यह फ्रेम में हर हाइपरलिंक को हटाता है, जिसमें उसके अन्य पैराग्राफ के लिंक भी शामिल हैं।

उदाहरण मानता है कि `SmartArtHyperlink.pptx` की पहली स्लाइड पर तीसरा आकार एक SmartArt ग्राफ़िक है। यह चौथे नोड के पहले पैराग्राफ को बदलता है। इस प्रस्तुति में, नोड का पहला आकार वह पैराग्राफ दिखाता है।

दोनों भाग जोड़ने के बाद, उदाहरण उनके प्रभावी फ़ॉर्मेट को [getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) से पढ़ता है। उस फ़ॉर्मेट पर, [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) पहला भाग के लिए नया हाइपरलिंक और दूसरे के लिए `null` लौटाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(2);
    ISmartArtNode node = smartArt.getAllNodes().get_Item(3);
    IParagraph paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    IPortion link = new Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    IPortion text = new Portion(" (updated)");
    paragraph.getPortions().add(text);

    System.out.println(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    System.out.println(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक इन्वेंटरी बनाएं**

प्रस्तुति वितरित करने से पहले, उसके इंटरैक्टिव कार्यों और वेब लिंक की इन्वेंटरी बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की एक साधारण सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) जांचें। वे स्वतंत्र होते हैं: एक ही कंटेनर दोनों कार्यों को प्रकट कर सकता है, इसलिए पूर्ण रिपोर्ट को प्रत्येक कंटेनर के लिए दो पंक्तियों तक की आवश्यकता हो सकती है।

केवल आकार-स्तर के हाइपरलिंक स्कैन करने से टेक्स्ट भाग से जुड़े लिंक छूट सकते हैं। इसके बजाय उचित स्कोप को क्वेरी करें, और लौटाए गए कंटेनर को रखे ताकि बाद में आप उनके कार्यों को अपडेट या हटाने सकें।

### **प्रस्तुति, स्लाइड और टेक्स्ट-फ़्रेम स्कोप क्वेरी करें**

इंटरफ़ेस [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), और [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरी का समर्थन करता है:
- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) क्लिक कार्य वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) माउस-ओवर कार्य वाले कंटेनर लौटाता है.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) एक या दोनों कार्यों वाले कंटेनर लौटाता है.

यह उदाहरण एक आकार और उसके टेक्स्ट को क्लिक तथा माउस-ओवर कार्य असाइन करता है, और एक अलग बटन को मैक्रो कार्य। यह [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) द्वारा लौटाए गए कंटेनर की संख्या को प्रत्येक सक्रियता प्रकार की गिनती से तुलना करता है। टेक्स्ट-फ़्रेम क्वेरी केवल टेक्स्ट में लिंक गिनती है। संलग्न आकार के अपने कार्य स्लाइड और प्रस्तुति क्वेरी में दिखाई देते हैं।

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस-ओवर कंटेनर और एक या दोनों कार्य वाले तीन कंटेनर रिपोर्ट करती हैं। टेक्स्ट-फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **कार्यों और गंतव्यों को वर्गीकृत करें**

[IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) का उपयोग करके किसी कार्य की व्याख्या करने से पहले उसके गंतव्य की व्याख्या करें। [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JumpSpecificSlide` | किसी विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | इनबिल्ट स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | एक मैक्रो चलाएँ। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्य नहीं, या एक अपरिचित कार्य जिसे समीक्षा की आवश्यकता है। |

[getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) से बाहरी गंतव्य पढ़ें और [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) से विशिष्ट आंतरिक गंतव्य। आंतरिक कार्य और इनबिल्ट कमांड में बाहरी URL नहीं हो सकता; खाली URL यह नहीं दर्शाता कि कंटेनर में कोई कार्य नहीं है। जब यह सामान्यीकृत URL से भिन्न हो तो [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) द्वारा लौटाई गई मान को बनाए रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) द्वारा लौटाए गए टूलटिप को शामिल करें।

### **हाइपरलिंक रिपोर्ट, साफ़-सफ़ाई और सत्यापन**

यह उदाहरण पिछले उदाहरण की प्रस्तुति खोलता है और प्रत्येक कार्य के लिए एक JSON रिकॉर्ड लिखता है। यह सामान्य स्लाइड, मास्टर, लेआउट और नोट्स पर कंटेनर एकत्र करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) का उपयोग करता है, जिसमें नोट्स और हैंडआउट मास्टर भी शामिल हैं यदि मौजूद हों। यह प्रत्येक कंटेनर को एक बार गिनने के लिए रेफ़रेंस समानता का उपयोग करता है, नीचे वर्णित नीति लागू करता है, और सहेजी गई प्रस्तुति को पुनः खोलकर दोनों क्लिक और माउस-ओवर कार्यों की जांच करता है।

रिपोर्ट एक-आधारित स्लाइड अनुक्रमांक और उपलब्ध होने पर [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) रिकॉर्ड करती है। [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनर के स्वामी स्लाइड को प्रदान करता है। मास्टर, लेआउट और नोट्स का कोई सामान्य स्लाइड अनुक्रमांक नहीं होता और उन्हें उनके स्कोप से पहचाना जाता है। आकार कंटेनर और टेक्स्ट-भाग फ़ॉर्मेटिंग कंटेनर अलग-अलग लेबल्ड होते हैं; अन्य कंटेनर प्रकार अपने रनटाइम टाइप नाम को बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट-स्थानीय ID मिलती है ताकि उसके दो कार्यों को जोड़ा जा सके। रिपोर्ट कार्य प्रकार को जावा एन्नमरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत करती है।

यह जानबूझकर प्रतिबंधित एप्लिकेशन नीति केवल निरपेक्ष HTTPS URL और मान्य आंतरिक स्लाइड लक्ष्य को ही अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाई, अन्य स्लाइडशो कार्रवाई, अज्ञात कार्रवाई और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृतियां नीति निर्णय हैं, न कि Aspose.Slides की सुरक्षा निर्णय। केवल HTTPS विश्वास स्थापित नहीं करता: अपने एप्लिकेशन के लिए होस्ट अलाउलिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL जांचे जाते हैं। उदाहरण लिंक या कार्य चलाए बिना मेटाडेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस-ओवर कार्य को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिए `replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एक एप्लिकेशन-स्वामित्व पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस-ओवर कार्य और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असहाय के रूप में फ़्लैग करें। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक एक्सपोर्ट में टिकेंगे। समर्थित [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/) एक्सपोर्ट कार्य, एक्सपोर्ट विकल्प और व्यूअर पर निर्भर करते हुए हाइपरलिंक को बनाए रख सकते हैं। रास्टर [images](/slides/hi/androidjava/convert-powerpoint-to-png/) और [video](/slides/hi/androidjava/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक को नहीं रख सकते; उन आउटपुट के लिए ऑडिट करते समय हर कार्य को फ़्लैग करें।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // इस रिपोर्ट की फ्लैट पंक्तियों को बिना अतिरिक्त JSON निर्भरता के सीरियलाइज़ करें।
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

ऊपर बनाए गए इनपुट के साथ, रिपोर्ट में पाँच कार्य पंक्तियाँ हैं। फ़ाइल माउस-ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बने रहते हैं। सत्यापन शून्य प्रतिबंधित कार्य प्रदर्शित करता है। प्रतिबंधित बाहरी क्लिक URL वाला इनपुट भी प्रतिस्थापन शाखा को सक्रिय करता है। अनुमत क्लिक और प्रतिबंधित माउस-ओवर वाला कंटेनर अपना क्लिक कार्य रखता है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक कार्यों को जांचता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को हटाता नहीं है, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता जांचता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक सेक्शन या उसके पहले स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइड को समूहित करते हैं, लेकिन एक आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन को नेविगेट करने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को सपोर्ट करते हैं। इन तत्वों पर लिंक उस स्लाइड शो के दौरान उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का प्रयोग करते हैं।

**क्या हाइपरलिंक PDF, HTML, इमेज या वीडियो में एक्सपोर्ट करने पर बनाए रहेंगे?**

समर्थित PDF और HTML एक्सपोर्ट हाइपरलिंक को बनाए रख सकते हैं; रास्टर इमेज और वीडियो नहीं रख सकते। एक्सपोर्ट विचारों के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।