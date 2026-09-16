---
title: Java में प्रस्तुति हाइपरलिंक्स को प्रबंधित करें
linktitle: हाइपरलिंक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकृति हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएं, Java उदाहरणों के साथ।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुतिकरण सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की सेवा करते हैं:

* पाठ, आकृति, या मीडिया फ्रेम से वेबसाइट खोलें।
* किसी अन्य स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for Java आपको ये लिंक जोड़ने, उनके स्वरूप और ध्वनि नियंत्रित करने, गुणों को अपडेट करने, और उन्हें हटाने की सुविधा देता है। नीचे के उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम किया जाए और प्रस्तुति, स्लाइड, या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुंचा जाए।

{{% alert color="info" title="Note" %}}
आप भी प्रस्तुतियों को [मुफ़्त ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/hi/editor) के साथ संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक्स जोड़ें**

आप पाठ, आकृति, या मीडिया फ्रेम को एक वेबसाइट URL असाइन कर सकते हैं। जिस तत्व पर आप हाइपरलिंक असाइन करते हैं, वह क्लिक योग्य क्षेत्र निर्धारित करता है: एक पाठ भाग चयनित पाठ को लिंक करता है, जबकि एक आकृति या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

### **पाठ में URL हाइपरलिंक्स जोड़ें**

वेबसाइट से पाठ को लिंक करने के लिए, नीचे दिखाए अनुसार, पाठ भाग के [setHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) मेथड को एक [Hyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/hyperlink/) पास करें। केवल वही पाठ भाग क्लिक करने योग्य बनता है।

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

### **आकृतियों और मीडिया फ्रेम में URL हाइपरलिंक्स जोड़ें**

एक आकृति या फ्रेम को क्लिक योग्य बनाने के लिए, उसके [setHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) मेथड को कॉल करें। हाइपरलिंक ऑब्जेक्ट स्वयं से जुड़ा होता है, न कि उसके भीतर के किसी पाठ भाग से।

एक ही विधि चित्र, ऑडियो, और वीडियो फ्रेम पर लागू होती है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक होने पर [setTooltip](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) को कॉल करें।

नीचे का उदाहरण एक आयत को क्लिक योग्य बनाता है:

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

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से एक विशिष्ट स्लाइड पर कूदने की अनुमति देते हैं। नीचे का उदाहरण पहले स्लाइड पर “Page 2” पाठ को दूसरे स्लाइड से लिंक करने के लिए [setInternalHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) का उपयोग करता है।

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

## **हाइपरलिंक्स को स्वरूपित करें**

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/) की [setColorSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setColorSource-int-) मेथड यह निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करेगा या पाठ भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/hyperlinkcolorsource/) चुनें और भाग के भराव रंग को सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड में दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट भराव के साथ है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग बनाए रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न मेथड का उपयोग करें:

- [IHyperlink.setSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) हाइपरलिंक से संबद्ध ऑडियो को निर्दिष्ट करता है।
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) नियंत्रित करता है कि हाइपरलिंक सक्रिय होने पर पिछली ध्वनि बंद हो जाए।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और पहली स्लाइड पर एक बटन के साथ जोड़ता है। बटन पर क्लिक करने से ध्वनि चलता है और अगले स्लाइड पर जाता है। उसी स्लाइड पर दूसरा आकार क्लिक होने पर पूर्व ध्वनि को रोकता है, बिना नेविगेशन कार्रवाई के।

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

निम्न उदाहरण ऊपर निर्मित प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getSound--) और [getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudio/#getBinaryData--) के माध्यम से मेमोरी में पढ़ता है।

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

पाठ या आकृति पर हाइपरलिंक असाइन करने के बाद आप निम्न [IHyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/) मेथड को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) वह टेक्स्ट सेट करता है जो दर्शक लिंक के संकेत के रूप में प्रदर्शित कर सकता है।
- [setTargetFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) आवश्यक होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) नियंत्रित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखी गई हाइपरलिंक सूची में जोड़ा जाए।
- [setHighlightClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) नियंत्रित करता है कि क्लिक होने पर हाइपरलिंक हाइलाइट हो।

## **प्रस्तुति से हाइपरलिंक्स हटाएँ**

परिवर्तनों से पहले सभी हाइपरलिंक कंटेनर, जिसमें टेक्स्ट‑पोर्टियन लिंक भी शामिल हैं, को इकट्ठा करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) का उपयोग करें। नीचे का उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए आप केवल [removeHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) को कॉल करें; क्लिक कार्रवाई को हटाने से उसकी माउस‑ओवर समकक्ष नहीं हटता।

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

बिना शर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक कॉल में हटाता है। मास्टर, लेआउट, और नोट्स सहित चयनात्मक सफाई और कवरेज के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **पूरा हाइपरलिंक इन्वेंटरी बनाएं**

प्रस्तुति वितरित करने से पहले, उसकी इंटरएक्टिव क्रियाओं और वेब लिंक दोनों की सूची बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की फ्लैट सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) की जांच करें। वे स्वतंत्र होते हैं: वही कंटेनर दोनों क्रियाओं को उजागर कर सकता है, इसलिए पूर्ण रिपोर्ट में प्रत्येक कंटेनर के लिए अधिकतम दो पंक्तियों की आवश्यकता होती है।

केवळ आकृति‑स्तर के हाइपरलिंक को स्कैन करने से टेक्स्ट‑पोर्टियन लिंक छूट सकते हैं। उचित स्कोप पर क्वेरी करें, और लौटाए गए कंटेनर को रखें ताकि बाद में उनके क्रिया को अपडेट या हटाया जा सके।

### **प्रस्तुति, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप की क्वेरी करें**

[IHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/) इंटरफ़ेस [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), और [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरी का समर्थन करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) क्लिक क्रिया वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) किसी भी या दोनों क्रियाओं वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस‑ओवर लिंक, और एक मैक्रो क्रिया शामिल है। यह इन कार्यों में से कोई भी निष्पादित नहीं करता। वही तीन क्वेरी हर स्कोप पर काम करती हैं; गणना कंटेनर की संख्या देती है, न कि कुल क्रिया की। टेक्स्ट‑फ़्रेम स्कोप में enclosing आकृति की अपनी लिंक शामिल नहीं होती।

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

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन कंटेनर (कोई भी क्रिया) रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों का वर्गीकरण**

एक क्रिया को उसके गंतव्य को समझने से पहले व्याख्या करने के लिए [IHyperlink.getActionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getActionType--) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | बाह्य हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JumpSpecificSlide` | किसी विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल होता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अपरिचित कार्रवाई जिसे समीक्षा की आवश्यकता है। |

बाहरी गंतव्य को [getExternalUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getExternalUrl--) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [getTargetSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getTargetSlide--) से। आंतरिक क्रियाओं और बिल्ट‑इन कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का अर्थ कंटेनर में कोई क्रिया नहीं है नहीं। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) का मान सामान्यीकृत URL से भिन्न हो तो उसे संरक्षित रखें, और जब उपलब्ध हो तो [getTooltip](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getTooltip--) द्वारा लौटाया गया टूलटिप शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, सैनिटाइज़, और सत्यापित करें**

नीचे दिया गया Java उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर बने फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर से खोलकर दोनों सक्रियता प्रकारों को फिर से जांचता है। यह कंटेनर को बदलने से पहले इकट्ठा करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिए रेफ़रेंस समानता का उपयोग करता है। प्रस्तुति क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंटरी के लिए यह स्पष्ट रूप से मैस्टर, लेआउट, नोट्स, और नोट्स व हैंडआउट मैस्टर को भी क्वेरी करती है जब मौजूद हों।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getSlideId--) को रिकॉर्ड करती है। [ISlideComponent.getSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनर के लिए स्वामित्व वाली स्लाइड प्रदान करता है। मैस्टर, लेआउट, और नोट्स का साधारण स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकार कंटेनर और टेक्स्ट‑पोर्टियन फ़ॉर्मेटिंग कंटेनर को अलग‑अलग लेबल किया जाता है; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को एक रिपोर्ट‑स्थानीय ID मिलती है ताकि उसकी दो क्रियाओं को संबंधित किया जा सके। रिपोर्ट में क्रिया प्रकार को Java एनोमरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत किया जाता है।

यह अनुशंसात्मक अनुप्रयोग नीति केवल पूर्ण HTTPS URL और वैध आंतरिक स्लाइड टार्गेट की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल क्रियाएँ, अन्य स्लाइडशो क्रियाएँ, अज्ञात क्रियाएँ, और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकर्तियाँ नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसेमंद नहीं है: अपने अनुप्रयोग के लिए होस्ट अलॉwlists और अन्य जाँचें जोड़ें। मूल तथा सामान्यीकृत दोनों बाहरी URL जांचे जाते हैं। उदाहरण मेटाडाटा की ऑडिट करता है बिना लिंक का अनुसरण किए या कार्रवाई चलाए।

सुधार के लिए, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्रवाई को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिए `replaceExternalClicks` को `false` रखें। तैनाती से पहले एक अनुप्रयोग‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का निर्यात फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्रवाई और किसी भी बाहरी लिंक या विशिष्ट स्लाइड जम्प के अलावा की क्रिया को संभावित रूप से असमर्थित के रूप में चिह्नित करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनचिह्नित लिंक निर्यात में जीवित रहेंगे। समर्थित [PDF](/slides/hi/java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/java/convert-powerpoint-to-html/) निर्यात हाइपरलिंक को संरक्षित कर सकते हैं, क्रिया, निर्यात विकल्प, और व्यूअर पर निर्भर करता है। रास्टर [images](/slides/hi/java/convert-powerpoint-to-png/) और [video](/slides/hi/java/convert-powerpoint-to-video/) इंटरएक्टिव हाइपरलिंक को संरक्षित नहीं कर सकते; उन आउटपुट के लिए ऑडिट करते समय हर कार्रवाई को चिह्नित करें।

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

    // अतिरिक्त JSON निर्भरता के बिना इस रिपोर्ट की समतल पंक्तियों को क्रमबद्ध करें.
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

ऊपर निर्मित इनपुट के साथ, रिपोर्ट में पाँच क्रिया पंक्तियाँ हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बरकरार हैं। सत्यापन शून्य प्रतिबंधित क्रिया प्रिंट करता है। प्रतिबंधित बाहरी क्लिक URL वाली इनपुट भी प्रतिस्थापन शाखा को चलाती है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपनी क्लिक कार्रवाई रखता है।

यह चयनात्मक सफाई [removeAllHyperlinks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक क्रिया की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट, या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता जांचता है।

## **FAQ**

**मैं किसी सेक्शन या उसकी पहली स्लाइड से कैसे लिंक कर सकता हूँ?**

PowerPoint में सेक्शन स्लाइड्स को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्ष्य बनाता है। एक सेक्शन के लिए नेविगेशन बनाने हेतु उस सेक्शन की पहली स्लाइड को लिंक करें।

**क्या मैं मास्टर स्लाइड के तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि वह सभी स्लाइड्स पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक स्लाइड शो के दौरान उन स्लाइड्स पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**PDF, HTML, इमेज या वीडियो में निर्यात करते समय हाइपरलिंक सुरक्षित रहते हैं?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर इमेज और वीडियो नहीं कर सकते। विवरण के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।