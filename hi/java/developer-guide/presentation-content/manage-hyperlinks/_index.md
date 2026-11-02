---
title: Java में प्रस्तुति हाइपरलिंक्स प्रबंधित करें
linktitle: हाइपरलिंक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक फ़ॉर्मेट करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- इमेज हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java के लिए Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स जोड़ें, फ़ॉर्मेट करें, अपडेट करें और हटाएं, Java उदाहरणों का उपयोग करके।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति की सामग्री को किसी वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आमतौर पर दो उद्देश्यों की सेवा करते हैं:

* टेक्स्ट, आकार या मीडिया फ्रेम से एक वेबसाइट खोलें।
* किसी अन्य स्लाइड पर जाएँ, उदाहरण के लिए, एक सामग्री तालिका से।

Aspose.Slides for Java आपको ये लिंक जोड़ने, उनकी उपस्थिति और ध्वनि नियंत्रित करने, गुण अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक्स के साथ कैसे काम किया जाए और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक्स तक कैसे पहुँचा जाए।

{{% alert color="info" title="Note" %}}
आप [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) से भी प्रस्तुतियों को संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक्स जोड़ें**

आप टेक्स्ट, आकार या मीडिया फ्रेम को एक वेबसाइट URL सौंप सकते हैं। जिस तत्व को आप हाइपरलिंक सौंपते हैं, वह क्लिक करने योग्य क्षेत्र तय करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

परिचित हाइपरलिंक्स वाली प्रस्तुतियों के लिए, दस्तावेज़‑स्तरीय बेस पढ़ने, बदलने या साफ़ करने हेतु देखें [Manage the Hyperlink Base](/slides/hi/java/presentation-properties/#manage-the-hyperlink-base)।

### **टेक्स्ट में URL हाइपरलिंक्स जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) विधि को एक [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) पास करें। केवल वही टेक्स्ट भाग क्लिक करने योग्य बन जाएगा।

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

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक्स जोड़ें**

एक आकार या फ्रेम को क्लिक करने योग्य बनाने के लिए उसकी [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) विधि को कॉल करें। हाइपरलिंक ऑब्जेक्ट स्वयं से जुड़ा होता है, न कि उसके अंदर के टेक्स्ट भाग से।

एक ही दृष्टिकोण चित्र, ऑडियो और वीडियो फ्रेम पर लागू होता है: फ्रेम को हाइपरलिंक सौंपें और यदि आवश्यक हो तो [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) को कॉल करें।

निम्न उदाहरण एक आयत को क्लिक करने योग्य बनाता है:

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

## **हाइपरलिंक्स का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक्स पाठकों को सामग्री तालिका से एक विशिष्ट स्लाइड पर ले जा सकते हैं। नीचे दिया गया उदाहरण [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) का उपयोग करता है ताकि पहली स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से जोड़ा जा सके।

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **हाइपरलिंक्स को फॉर्मेट करें**

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) की [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) विधि निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग के फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) चुनें और भाग के भराव रंग को सेट करें। यह सुविधा PowerPoint 2019 में प्रस्तुत की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड पर दो टेक्स्ट हाइपरलिंक्स जोड़ता है। पहला लाल टेक्स्ट भराव का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग बरकरार रखता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

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

हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दी गई विधियों का उपयोग करें:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) निर्धारित करता है कि हाइपरलिंक सक्रिय होने पर पहले की ध्वनि रोक दी जाए।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और इसे पहली स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि चलेगी और अगली स्लाइड पर नेविगेट होगा। उस स्लाइड पर दूसरा आकार क्लिक होने पर पूर्व ध्वनि को रोक देगा, बिना नेविगेशन क्रिया के।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) तथा [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) के माध्यम से मेमोरी में पढ़ता है।

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

टेक्स्ट या आकार को हाइपरलिंक सौंपने के बाद आप नीचे दी गई [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) विधियों को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) वह टेक्स्ट सेट करता है जिसे दर्शक लिंक के संकेत के रूप में प्रदर्शित कर सकता है।
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) जब लागू हो तो पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) निर्धारित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखे गए हाइपरलिंक्स की सूची में जोड़ दिया जाए।
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक को हाइलाइट किया जाए या नहीं।

## **प्रस्तुतियों से हाइपरलिंक्स हटाएँ**

परिवर्तन करने से पहले टेक्स्ट‑पोर्टियन लिंक सहित हाइपरलिंक कंटेनर एकत्र करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) का उपयोग करें। नीचे दिया गया उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए केवल [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) को कॉल करें; क्लिक कार्रवाई को हटाने से उसका माउस‑ओवर समकक्ष नहीं हटता।

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

अशर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) चयनित स्कोप में दोनो सक्रियता प्रकारों को एक कॉल में हटा देता है। चयनात्मक सफ़ाई और मास्टर, लेआउट तथा नोट्स को कवर करने के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **पूरा हाइपरलिंक इन्वेंटरी बनायें**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव क्रियाओं और वेब लिंक्स दोनों की सूची बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की फ्लैट सूची। प्रत्येक कंटेनर पर [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) तथा [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) दोनों का निरीक्षण करें। ये स्वतंत्र हैं: समान कंटेनर दोनों क्रियाओं को प्रकट कर सकता है, इसलिए पूर्ण रिपोर्ट के लिए प्रत्येक कंटेनर में दो पंक्तियों की आवश्यकता हो सकती है।

केवल आकार‑स्तर के हाइपरलिंक को स्कैन करने से टेक्स्ट‑पोर्टियन से जुड़ी लिंक छूट सकती हैं। उचित स्कोप को क्वेरी करें, और लौटाए गए कंटेनर को सुरक्षित रखें ताकि बाद में आप उनके क्रियाओं को अपडेट या हटाएँ।

### **प्रेज़ेंटेशन, स्लाइड और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करना**

[IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) इंटरफ़ेस निम्न तरीकों से उपलब्ध है: [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), और [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--)। प्रत्येक स्कोप समान क्वेरी को सपोर्ट करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) क्लिक क्रिया वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) या तो दोनों या किसी एक क्रिया वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस‑ओवर लिंक और एक मैक्रो क्रिया शामिल है। यह इनमें से किसी भी क्रिया को निष्पादित नहीं करता। वही तीन क्वेरी प्रत्येक स्कोप पर काम करती हैं; गणना कंटेनर को दर्शाती है, क्रिया की कुल संख्या नहीं। टेक्स्ट‑फ़्रेम स्कोप enclosing आकार के अपने लिंक को बाहर रखता है।

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

इस उदाहरण में, प्रेज़ेंटेशन और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर और तीन मिश्रित कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों का वर्गीकरण करें**

एक क्रिया को उसके गंतव्य को समझने से पहले व्याख्यायित करने हेतु [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से परे कई प्रकार को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JumpSpecificSlide` | विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | निर्मित स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करना या कस्टम शो शुरू करना। |
| `StartMacro` | मैक्रो चलाएँ। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या दूसरी प्रस्तुति खोलें; वेब URL से अलग जाँचें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन क्रिया नहीं, या अज्ञात क्रिया जिसे समीक्षा की आवश्यकता है। |

बाहरी गंतव्यों को [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) से पढ़ें और विशिष्ट आंतरिक गंतव्यों को [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--) से। आंतरिक क्रियाओं और निर्मित कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर में कोई क्रिया नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) का मान सामान्यीकृत URL से भिन्न हो, तो उसे संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) द्वारा लौटाए गए टूलटिप को शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, सफ़ाई और सत्यापन करें**

निम्न Java उदाहरण मौजूद प्रस्तुति (ऊपर बनाई गई फ़ाइल) को पढ़ता है, `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दोनो सक्रियता प्रकारों को फिर से जांचने के लिए पुनः खोलता है। यह बदलने से पहले कंटेनर एकत्र करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिए रेफ़रेंस समानता का उपयोग करता है। प्रेज़ेंटेशन क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंट्री के लिए यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स और नोट्स एवं हैंडआउट मास्टर को भी क्वेरी करता है जब वे मौजूद हों।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) को रिकॉर्ड करती है। [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनर के मालिक स्लाइड को प्रदान करता है। मास्टर, लेआउट और नोट्स में सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकार कंटेनर और टेक्स्ट‑पोर्टियन फ़ॉर्मेटिंग कंटेनर अलग‑अलग लेबल होते हैं; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम बरकरार रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID मिलती है जिससे उसकी दो क्रियाओं को जोड़ा जा सके। रिपोर्ट क्रिया प्रकारों को Java एनीमरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत करती है।

यह सशक्त नीति केवल निरपेक्ष HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल क्रिया, अन्य स्लाइडशो क्रिया, अज्ञात क्रिया तथा अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकरण नीति‑निर्णय हैं, न कि Aspose.Slides सुरक्षा निर्णय। केवल HTTPS भरोसेमंद नहीं है: अपनी एप्लिकेशन के लिए होस्ट एलाउलिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL की जाँच की जाती है। उदाहरण लिंक का अनुसरण या क्रिया चलाए बिना मेटा‑डेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर की [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) निम्न कार्यसमूह समर्थन करती है: [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदला जाता है; अन्य प्रतिबंधित क्लिक और माउस‑ओवर क्रियाओं को स्वतंत्र रूप से हटाया जाता है। सभी नीति‑उल्लंघनों को हटाने के लिए `replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एक एप्लिकेशन‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का निर्यात फ़्लैग सावधानीपूर्वक PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर क्रियाओं और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा अन्य सभी को संभावित असमर्थित के रूप में चिन्हित करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि बिना चिन्हित लिंक निर्यात में बना रहेगा। समर्थित [PDF](/slides/hi/java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/java/convert-powerpoint-to-html/) निर्यात क्रिया, निर्यात विकल्प और दर्शक के आधार पर हाइपरलिंक संरक्षित कर सकते हैं। रास्टर [images](/slides/hi/java/convert-powerpoint-to-png/) और [video](/slides/hi/java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक को संरक्षित नहीं कर सकते; उन आउटपुट के लिए ऑडिट करते समय हर क्रिया को चिन्हित करें।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

ऊपर बनाई गई इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित क्रिया प्रदर्शित करता है। एक प्रतिबंधित बाहरी क्लिक URL वाली इनपुट भी प्रतिस्थापन शाखा को सक्रिय करती है। अनुमति‑प्राप्त क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपनी क्लिक क्रिया रखता है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) से भिन्न है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देती है। यहाँ जांच केवल हाइपरलिंक क्रियाओं तक सीमित है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यात किए गए PDF या HTML फ़ाइल का सत्यापन करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि वह सभी स्लाइड पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक स्लाइड शो के दौरान उन स्लाइडों पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या PDF, HTML, इमेज या वीडियो में निर्यात करने पर हाइपरलिंक्स संरक्षित रहते हैं?**

समर्थित PDF और HTML निर्यात हाइपरलिंक्स को संरक्षित कर सकते हैं; रास्टर इमेज और वीडियो नहीं कर सकते। विवरण के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।