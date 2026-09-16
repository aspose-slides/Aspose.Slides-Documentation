---
title: एंड्रॉइड पर प्रस्तुति हाइपरलिंक्स प्रबंधित करें
linktitle: हाइपरलिंक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/androidjava/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक का स्वरूप निर्धारित करें
- हाइपरलिंक्स हटाएँ
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स को जोड़ें, उनका स्वरूप निर्धारित करें, अपडेट करें और हटाएँ, Java उदाहरणों का उपयोग करके।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति सामग्री को किसी वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* पाठ, आकृति, या मीडिया फ्रेम से वेबसाइट खोलें।
* एक अन्य स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for Android via Java आपको इन लिंक को जोड़ने, उनके स्वरूप और ध्वनि को नियंत्रित करने, उनके गुणों को अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दर्शाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक्स के साथ कैसे काम किया जाता है और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक्स तक कैसे पहुंचा जाता है।

{{% alert color="info" title="ध्यान दें" %}}

आप मुफ्त ऑनलाइन Aspose PowerPoint संपादक के साथ भी प्रस्तुतियों को संपादित कर सकते हैं[free online Aspose PowerPoint editor](https://products.aspose.app/slides/hi/editor)।

{{% /alert %}} 

## **URL हाइपरलिंक्स जोड़ें**

आप टेक्स्ट, आकृति या मीडिया फ्रेम को वेबसाइट URL आवंटित कर सकते हैं। जिस तत्व को आप हाइपरलिंक देते हैं, वह क्लिक योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित पाठ को लिंक करता है, जबकि आकृति या फ्रेम स्लाइड वस्तु को लिंक करता है।

### **टेक्स्ट में URL हाइपरलिंक्स जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) मेथड में एक [Hyperlink](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/hyperlink/) पास करें, जैसा कि नीचे दिखाया गया है। केवल वही पाठ भाग क्लिक योग्य बन जाता है।

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

आकृति या फ्रेम को क्लिक योग्य बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) मेथड को कॉल करें। हाइपरलिंक वस्तु स्वयं से जुड़ा होता है, न कि उसके भीतर के किसी टेक्स्ट भाग से।

इसी तरह चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू होता है: फ्रेम को हाइपरलिंक आवंटित करें और आवश्यकता होने पर [setTooltip](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) कॉल करें।

नीचे दिया गया उदाहरण एक आयत को क्लिक योग्य बनाता है:

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

## **सामग्री तालिका बनाने के लिए हाइपरलिंक्स का उपयोग करें**

आंतरिक हाइपरलिंक्स पाठकों को सामग्री तालिका से विशिष्ट स्लाइड पर जंप करने की अनुमति देते हैं। नीचे दिया गया उदाहरण पहले स्लाइड पर "Page 2" टेक्स्ट को दूसरे स्लाइड से लिंक करने के लिए [setInternalHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) का उपयोग करता है।

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

## **हाइपरलिंक्स का स्वरूप निर्धारित करें**

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/) की [setColorSource](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) मेथड यह निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करेगा या टेक्स्ट भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/hyperlinkcolorsource/) चुनें और भाग की Fill रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

नीचे दिया गया उदाहरण दो टेक्स्ट हाइपरलिंक्स को एक ही स्लाइड पर जोड़ता है। पहला लाल टेक्स्ट फ़िल के साथ, जबकि दूसरा डिफॉल्ट हाइपरलिंक रंग बनाए रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दिए मेथड्स का उपयोग करें:

- [IHyperlink.setSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) हाइपरलिंक से जुड़ी ऑडियो निर्दिष्ट करता है।
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) तय करता है कि हाइपरलिंक सक्रिय होने पर पहले की ध्वनि बंद होनी चाहिए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

नीचे दिया गया उदाहरण `sampleaudio.wav` लोड करता है और पहले स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि बजती है और अगली स्लाइड पर जाता है। उसी स्लाइड पर दूसरा आकृति क्लिक होने पर पिछले ध्वनि को रोकता है, बिना नेविगेशन किए।

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

नीचे दिया गया उदाहरण ऊपर निर्मित प्रस्तुति को खोलता है और पहले आकृति की हाइपरलिंक ऑडियो को मेमोरी में पढ़ता है, इसके लिए [getSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#getSound--) और [getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudio/#getBinaryData--) का उपयोग किया गया है।

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

टेक्स्ट या आकृति को हाइपरलिंक आवंटित करने के बाद आप नीचे दिए गए [IHyperlink](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/) मेथड्स को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) लिंक के लिये दर्शक द्वारा दिखाए जाने वाले संकेत पाठ को सेट करता है।
- [setTargetFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) लागू होने पर पैरेंट HTML फ्रेमसेट में लक्ष्य फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) तय करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखे गए हाइपरलिंक्स की सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) नियंत्रित करता है कि क्लिक होने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुति से हाइपरलिंक्स हटाएँ**

हाइपरलिंक कंटेनर एकत्र करने के लिये [getAnyHyperlinks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) का उपयोग करें, जिसमें टेक्स्ट‑पोर्टियन लिंक भी शामिल हैं, तथा फिर उन्हें बदलें। नीचे दिया गया उदाहरण पहले स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने हेतु केवल [removeHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) कॉल करें; क्लिक एक्शन हटाने से उसका माउस‑ओवर समकक्ष नहीं हटता।

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

बिना शर्त हटाने के लिये, [removeAllHyperlinks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक कॉल में हटा देता है। चयनात्मक सफाई और मास्टर, लेआउट, नोट्स सहित सभी स्कोप को कवर करने हेतु देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **एक पूर्ण हाइपरलिंक इन्वेंटरी बनाएं**

प्रस्तुति वितरित करने से पहले उसके इंटरैक्टिव क्रियाओं और वेब लिंक दोनों को इन्वेंटरी बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि साधारण URL स्ट्रिंग्स की सूची। प्रत्येक कंटेनर पर [getHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) जांचें। वे स्वतंत्र होते हैं: एक ही कंटेनर दोनों क्रियाएँ धारण कर सकता है, इसलिए पूर्ण रिपोर्ट के लिये प्रत्येक कंटेनर में दो पंक्तियों की आवश्यकता हो सकती है।

केवल आकृति‑स्तर के हाइपरलिंक्स को स्कैन करने से टेक्स्ट‑पोर्टियन लिंक छूट सकते हैं। उचित स्कोप को क्वेरी करें और लौटाए गए कंटेनरों को रखें, ताकि बाद में उनकी क्रियाओं को अपडेट या हटाया जा सके।

### **प्रस्तुति, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करें**

[IHyperlinkQueries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/) इंटरफ़ेस उपलब्ध है [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), और [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) के माध्यम से। प्रत्येक स्कोप समान क्वेरी सपोर्ट करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) क्लिक क्रिया वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) दोनों या कोई भी क्रिया रखने वाले कंटेनर लौटाता है।

नीचे दिया गया उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, टेक्स्ट माउस‑ओवर लिंक और मैक्रो एक्शन शामिल हैं। यह इन कार्यों को नहीं चलाता। वही तीन क्वेरी हर स्कोप में काम करती हैं; गिनती कंटेनरों की है, कुल क्रियाओं की नहीं। टेक्स्ट‑फ़्रेम स्कोप में enclosing आकृति के अपने लिंक शामिल नहीं होते।

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

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर और तीन “या तो” कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक वर्ग में एक कंटेनर रिपोर्ट करती है।

### **क्रिया और गंतव्य वर्गीकृत करें**

क्रिया को उसके गंतव्य से पहले समझने के लिये [IHyperlink.getActionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#getActionType--) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से आगे के विकल्प प्रदान करते हैं:

| मान | ऑडिट के लिये अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसकी स्कीम जांचें। |
| `JumpSpecificSlide` | विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | निर्मित स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग जांचें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या बंद करें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्य नहीं, या अज्ञात कार्य जिसे समीक्षा की आवश्यकता है। |

बाहरी गंतव्य को [getExternalUrl](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) से और विशिष्ट आंतरिक गंतव्य को [getTargetSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) से पढ़ें। आंतरिक क्रिया एवं निर्मित कमांड में अक्सर बाहरी URL नहीं होता; खाली URL यह नहीं दर्शाता कि कंटेनर में कोई क्रिया नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) मान सामान्यीकृत URL से भिन्न हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) द्वारा लौटाई गई टूलटिप भी शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, सफाई, और सत्यापन करें**

नीचे दिया गया Java उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर निर्मित फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दोबारा खोलकर दोनों सक्रियता प्रकारों की पुनः जांच करता है। यह कंटेनरों को बदलने से पहले इकट्ठा करता है और संदर्भ समानता के द्वारा उसी कंटेनर को दो बार प्रोसेस होने से रोकता है। प्रस्तुति क्वेरी सामान्य स्लाइड्स को कवर करती है; पैकेज‑व्यापी इन्वेंटरी के लिये यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स तथा नोट्स और हैंडआउट मास्टर को भी क्वेरी करती है जब उपलब्ध हों।

रिपोर्ट स्लाइड इंडेक्स (1‑आधारित) तथा उपलब्ध होने पर [getSlideId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) रिकॉर्ड करती है। [ISlideComponent.getSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनरों के लिये स्वामित्व वाली स्लाइड प्रदान करता है। मास्टर, लेआउट, नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकृति कंटेनर तथा टेक्स्ट‑पोर्टियन फ़ॉर्मेट कंटेनर अलग‑अलग लेबल होते हैं; अन्य प्रकार अपने रन‑टाइम टाइप नाम को बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसकी दो क्रियाओं को आपस में जोड़ा जा सके। रिपोर्ट में क्रिया प्रकार Java enumeration द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत होते हैं।

यह नीति केवल पूर्ण HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्य, अन्य स्लाइडशो कार्य, अज्ञात कार्य और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृति नीति निर्णय हैं, Aspose.Slides सुरक्षा मूल्यांकन नहीं। केवल HTTPS भरोसा नहीं बनाता: अपनी एप्लिकेशन के लिये होस्ट अनुमति‑सूची और अन्य जाँचें जोड़ें। मूल तथा सामान्यीकृत दोनों बाहरी URL जांचे जाते हैं। उदाहरण लिंक नहीं खोलता या कार्य नहीं चलाता।

सुधार के लिये, कंटेनर की [getHyperlinkManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) द्वारा [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) समर्थित हैं। यहाँ प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया गया; अन्य प्रतिबंधित क्लिक और माउस‑ओवर कार्य स्वतंत्र रूप से हटाए गए। सभी नीति‑उल्लंघन हटाने हेतु `replaceExternalClicks` को `false` रखें। तैनाती से पहले एक एप्लिकेशन‑स्वत्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट की निर्यात फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति उपयोग करती है: माउस‑ओवर कार्य और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असमर्थित चिह्नित किया जाता है। यह एक समीक्षा संकेत है, क्षमता परीक्षण या यह गारंटी नहीं कि अनफ़्लैग्ड लिंक निर्यात में बनी रहेंगे। समर्थित [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/) निर्यात कार्य, कार्य प्रकार, निर्यात विकल्प और दर्शक के आधार पर हाइपरलिंक्स बरकरार रख सकते हैं; रास्टर [images](/slides/hi/androidjava/convert-powerpoint-to-png/) और [video](/slides/hi/androidjava/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक्स नहीं रख सकते; ऐसे आउटपुट के लिये ऑडिट करते समय हर कार्य को फ़्लैग करें।

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

    // बिना अतिरिक्त JSON निर्भरता के इस रिपोर्ट की फ्लैट पंक्तियों को सीरियलाइज़ करें।
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

ऊपर निर्मित इनपुट के साथ, रिपोर्ट में पाँच क्रिया पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्य प्रिंट करता है। एक प्रतिबंधित बाहरी क्लिक URL वाले इनपुट से प्रतिस्थापन शाखा भी सक्रिय होती है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपना क्लिक कार्य रखता है।

यह चयनात्मक सफाई [removeAllHyperlinks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक कार्यों को जांचता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को हटाता नहीं है, न ही निर्यातित PDF या HTML फ़ाइल की वैधता जाँचता है।

## **FAQ**

**मैं किसी सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने हेतु उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि वह सभी स्लाइडों पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर मौजूद लिंक उन स्लाइड शो में उपलब्ध होते हैं जिनमें संबंधित मास्टर या लेआउट प्रयुक्त होते हैं।

**क्या हाइपरलिंक PDF, HTML, चित्रों या वीडियो में निर्यात करने पर संरक्षित रहते हैं?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को बरकरार रख सकते हैं; रास्टर चित्र और वीडियो नहीं रख सकते। अधिक जानकारी के लिये देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।