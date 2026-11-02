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
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- शकल हाइपरलिंक
- इमेज हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके, Java उदाहरणों के साथ, PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स जोड़ें, स्वरूपित करें, अपडेट करें और हटाएँ।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुतिकरण सामग्री को एक वेबसाइट या प्रस्तुतिकरण के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* टेक्स्ट, शकल या मीडिया फ्रेम से वेबसाइट खोलें।
* उदाहरण के लिए, सामग्री-सूची से किसी अन्य स्लाइड पर जाएँ।

Aspose.Slides for Android via Java आपको इन लिंक को जोड़ने, उनके दिखावट और ध्वनि को नियंत्रित करने, उनके गुणों को अद्यतन करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक्स के साथ कैसे काम करें और प्रस्तुति, स्लाइड या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक्स तक कैसे पहुँचें।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक्स जोड़ें**

आप टेक्स्ट, शकल या मीडिया फ्रेम को एक वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट से लिंक होता है, जबकि शकल या फ्रेम स्लाइड ऑब्जेक्ट से लिंक होता है।

रिलेटिव हाइपरलिंक्स वाली प्रस्तुतियों के लिए, [हाइपरलिंक बेस प्रबंधित करें](/slides/hi/androidjava/presentation-properties/#manage-the-hyperlink-base) देखें ताकि आप दस्तावेज़-स्तरीय बेस को पढ़, बदल या साफ़ कर सकें।

### **टेक्स्ट में URL हाइपरलिंक्स जोड़ें**

टेक्स्ट को किसी वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) विधि में एक [हाइपरलिंक](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) पास करें। केवल वह टेक्स्ट भाग क्लिक करने योग्य बन जाएगा।

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

### **शक्लों और मीडिया फ्रेमों में URL हाइपरलिंक्स जोड़ें**

एक शकल या फ्रेम को क्लिक करने योग्य बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) विधि को कॉल करें। हाइपरलिंक स्वयं वस्तु से जुड़ा होता है न कि उसके भीतर के टेक्स्ट भाग से।

चित्र, ऑडियो और वीडियो फ्रेमों पर भी यही तरीका लागू होता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यकता होने पर [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) को कॉल करें।

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

## **हाइपरलिंक्स का उपयोग करके सामग्री-सूची बनाएं**

आंतरिक हाइपरलिंक्स पाठकों को सामग्री-सूची से किसी विशिष्ट स्लाइड पर जाने की अनुमति देते हैं। निम्न उदाहरण पहले स्लाइड के “Page 2” टेक्स्ट को दूसरी स्लाइड से जोड़ने के लिए [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) का उपयोग करता है।

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

## **हाइपरलिंक्स को स्वरूपित करें**

### **रंग**

[setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) विधि [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) के द्वारा निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) चुनें और भाग के भराव रंग को सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड में दो टेक्स्ट हाइपरलिंक्स जोड़ता है। पहला लाल टेक्स्ट भराव का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग को बरकरार रखता है।

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

एक हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दी गई विधियों का उपयोग करें:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) हाइपरलिंक से जुड़ी ऑडियो निर्धारित करता है।
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) नियंत्रित करता है कि हाइपरलिंक सक्रिय करने पर पूर्व ध्वनि बंद होनी चाहिए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` को लोड करता है और इसे पहले स्लाइड के बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि चलती है और अगली स्लाइड पर जाता है। उसी स्लाइड का दूसरा शकल क्लिक करने पर पूर्व ध्वनि को रोकता है, बिना नेविगेशन कार्रवाई के।

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

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले शकल की हाइपरलिंक ऑडियो को मेमोरी में पढ़ता है, इसके लिए [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) और [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) का उपयोग करता है।

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

टेक्स्ट या शकल को हाइपरलिंक असाइन करने के बाद आप नीचे दी गई [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) विधियों को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) वह टेक्स्ट सेट करता है जो दर्शक लिंक के लिए संकेत के रूप में प्रदर्शित कर सकता है।
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्षित फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) नियंत्रित करता है कि लिंक सक्रिय करने पर उसका गंतव्य देखे गए हाइपरलिंक्स की सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक को हाइलाइट किया जाए या नहीं।

## **प्रस्तुतियों से हाइपरलिंक्स हटाएं**

[getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) का उपयोग करके हाइपरलिंक कंटेनरों को एकत्र करें, जिसमें टेक्स्ट-भाग लिंक भी शामिल हैं, इससे पहले कि आप उन्हें बदलें। निम्न उदाहरण पहले स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) को कॉल करें; क्लिक कार्रवाई हटाने से उसका माउस-ओवर समकक्ष नहीं हटता।

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

अशर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) चयनित स्कोप में एक कॉल में दोनों सक्रियता प्रकार हटाता है। चयनात्मक सफ़ाई और मास्टर, लेआउट, एवं नोट्स को कवर करने के लिए, देखें [रिपोर्ट, स्वच्छता, और हाइपरलिंक सत्यापन](#report-sanitize-and-verify-hyperlinks)।

## **एक पूर्ण हाइपरलिंक इन्वेंटरी बनाएं**

एक प्रस्तुति वितरित करने से पहले, उसके इंटरैक्टिव क्रियाओं और वेब लिंक की इन्वेंटरी बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) वस्तुओं को लौटाता है, न कि URL स्ट्रिंग्स की सपाट सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) का निरीक्षण करें। वे स्वतंत्र हैं: एक ही कंटेनर दोनों क्रियाओं को उजागर कर सकता है, इसलिए एक पूर्ण रिपोर्ट को प्रत्येक कंटेनर के लिए दो पंक्तियों तक की आवश्यकता हो सकती है।

केवल शकल-स्तर के हाइपरलिंक्स को स्कैन करने से टेक्स्ट भागों से जुड़े लिंक छूट सकते हैं। इसके बजाय उचित स्कोप को क्वेरी करें, और लौटाए गए कंटेनरों को रखें ताकि बाद में आप उनकी क्रियाओं को अपडेट या हटाना कर सकें।

### **प्रस्तुति, स्लाइड, और टेक्स्ट-फ़्रेम स्कोप्स को क्वेरी करें**

इंटरफ़ेस [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--) [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) और [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरीज को सपोर्ट करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) क्लिक कार्रवाई वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) माउस-ओवर कार्रवाई वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) एक या दोनों क्रियाओं वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस-ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस-ओवर लिंक, और एक मैक्रो कार्रवाई शामिल है। यह इनमें से किसी भी कार्रवाई को निष्पादित नहीं करता। वही तीन क्वेरीज प्रत्येक स्कोप पर काम करती हैं; गिनती कंटेनरों को दर्शाती है, न कि क्रिया कुल को। टेक्स्ट-फ़्रेम स्कोप में enclosing शकल के अपने लिंक नहीं शामिल होते।

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

इस उदाहरण के लिए, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस-ओवर कंटेनर, और एक या दोनों कार्रवाई वाले तीन कंटेनर रिपोर्ट करती हैं। टेक्स्ट-फ़्रेम क्वेरी प्रत्येक वर्गीकरण में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों को वर्गीकृत करें**

[IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) का उपयोग करके किसी कार्रवाई की व्याख्या उसके गंतव्य की व्याख्या से पहले करें। [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जाँच करें। |
| `JumpSpecificSlide` | किसी विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या एक कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URLs से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या एक अपरिचित कार्रवाई जो समीक्षा की आवश्यकता है। |

बाहरी गंतव्यों को [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) से। आंतरिक क्रियाओं और बिल्ट‑इन कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर में कोई कार्रवाई नहीं है। जब मान सामान्यीकृत URL से भिन्न हो तो [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) द्वारा लौटाए गए मान को संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) द्वारा लौटाए गए टूलटिप को शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, स्वच्छता, और सत्यापन करें**

निम्न Java उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर निर्मित फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर से खोलकर दोनों सक्रियता प्रकारों की पुनः जाँच करता है। यह बदलने से पहले कंटेनरों को एकत्र करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिए रेफ़रेंस समानता का उपयोग करता है। प्रस्तुति क्वेरीज साधारण स्लाइड्स को कवर करती हैं; पैकेज-व्यापी इन्वेंटरी के लिए, यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स, और नोट्स एवं हैंडआउट मास्टर को भी क्वेरी करता है जब वे मौजूद हों।

रिपोर्ट एक-आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) को रिकॉर्ड करती है। [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनरों के लिए स्वामित्व वाली स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स का साधारण स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। शकल कंटेनर और टेक्स्ट-भाग फ़ॉर्मेटिंग कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपना रनटाइम टाइप नाम बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट-स्थानीय आईडी मिलती है ताकि उसकी दो क्रियाओं को संगत किया जा सके। रिपोर्ट कार्रवाई प्रकारों को जावा एन्‍युमरेशन द्वारा परिभाषित पूर्णांक स्थिरांकों के रूप में संग्रहीत करती है।

यह जानबूझकर प्रतिबंधित एप्लिकेशन नीति केवल पूर्ण HTTPS URL और मान्य आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाई, अन्य स्लाइडशो कार्रवाई, अज्ञात कार्रवाई और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृतियाँ नीति निर्णय हैं, न कि Aspose.Slides सुरक्षा निर्णय। केवल HTTPS भरोसे को स्थापित नहीं करता: अपने एप्लिकेशन के लिए होस्ट अलाउलिस्ट और अन्य जाँचें जोड़ें। मूल तथा सामान्यीकृत बाहरी URLs दोनों की जाँच की जाती है। उदाहरण मेटाडेटा का ऑडिट करता है बिना लिंक को फ़ॉलो किए या कार्रवाई को चलाए।

सुधार के लिए, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) को सपोर्ट करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्रवाई को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिए `replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एप्लिकेशन‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF रिव्यू नीति उपयोग करता है: माउस‑ओवर कार्रवाई और कोई भी चीज़ जो बाहरी लिंक या विशिष्ट स्लाइड जंप नहीं है, उसे संभावित असमर्थित के रूप में फ़्लैग करें। यह एक रिव्यू संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक एक्सपोर्ट में टिकेंगे। समर्थित [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/) एक्सपोर्ट हाइपरलिंक्स को संरक्षित कर सकते हैं, कार्रवाई, एक्सपोर्ट विकल्प और व्यूवर पर निर्भर करता है। रास्टर [images](/slides/hi/androidjava/convert-powerpoint-to-png/) और [video](/slides/hi/androidjava/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक्स को संरक्षित नहीं कर सकते; उन आउटपुट के लिए ऑडिट करते समय प्रत्येक कार्रवाई को फ़्लैग करें।

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

    // इस रिपोर्ट की फ्लैट पंक्तियों को अतिरिक्त JSON निर्भरता के बिना सीरियलाइज़ करें।
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

ऊपर निर्मित इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए जाते हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्रवाई दिखाता है। प्रतिबंधित बाहरी क्लिक URL वाले इनपुट से भी प्रतिस्थापन शाखा चलती है। एक कंटेनर जिसमें अनुमति प्राप्त क्लिक और प्रतिबंधित माउस‑ओवर है, वह अपना क्लिक कार्रवाई रखता है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटाता है। यहाँ सत्यापन केवल हाइपरलिंक क्रियाओं की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता जाँचता है।

## **आम प्रश्न**

**मैं किसी सेक्शन या उसके पहले स्लाइड से कैसे लिंक करूं?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन में नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि यह सभी स्लाइड्स पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक्स का समर्थन करते हैं। इन तत्वों पर लगाए गए लिंक उन स्लाइड शो में उपलब्ध होते हैं जिनमें संबंधित मास्टर या लेआउट का उपयोग किया गया है।

**क्या हाइपरलिंक्स PDF, HTML, इमेज या वीडियो में एक्सपोर्ट करने पर संरक्षित रहेंगे?**

समर्थित PDF और HTML एक्सपोर्ट हाइपरलिंक्स को संरक्षित कर सकते हैं; रास्टर इमेज और वीडियो नहीं कर सकते। निर्यात संबंधी विचारों के लिए देखें [हाइपरलिंक की रिपोर्ट, स्वच्छता, और सत्यापन](#report-sanitize-and-verify-hyperlinks)।