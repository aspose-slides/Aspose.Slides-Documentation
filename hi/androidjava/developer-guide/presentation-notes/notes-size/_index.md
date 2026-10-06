---
title: Android पर नोट्स पेज का आकार और अभिविन्यास बदलें
linktitle: नोट्स पेज आकार
type: docs
weight: 10
url: /hi/androidjava/notes-size/
keywords:
- नोट्स पेज आकार
- नोट्स अभिविन्यास
- लैंडस्केप नोट्स
- पोर्ट्रेट नोट्स
- हैंडआउट आकार
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से नोट्स पेज के आयाम पढ़ें और बदलें, अभिविन्यास स्विच करें, सहेजे गए आकारों की जांच करें, और नोट्स या हैंडआउट को PDF और छवियों में निर्यात करें।"
---
## **अवलोकन**

उपयोग करें [Presentation.getNotesSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getNotesSize--) प्रस्तुति के नोट्स पृष्ठ सेटिंग्स तक पहुँचने के लिए। यह एक [INotesSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotessize/) ऑब्जेक्ट लौटाता है जिसका [setSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) मेथड पृष्ठ आयाम सेट करता है। यद्यपि सेटिंग्स ऑब्जेक्ट को बदला नहीं जा सकता, आप इस मेथड के माध्यम से नए आयाम असाइन कर सकते हैं।

चौड़ाई और ऊंचाई **पॉइंट्स** में निर्दिष्ट की जाती है, जहाँ प्रति इंच 72 पॉइंट्स होते हैं। उदाहरण के तौर पर, 900 × 600 पॉइंट्स 12.5 × 8⅓ इंच के बराबर है। ये सेटिंग्स संपूर्ण प्रस्तुति पर लागू होती हैं, न कि किसी एकल स्लाइड के नोट्स पर।

| सेटिंग | उद्देश्य |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getNotesSize--) | नोट्स पेज आयाम और हैंडआउट निर्यात के लिए उपयोग किए जाने वाले पेज आयाम को नियंत्रित करता है। |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideSize--) | सामान्य प्रस्तुति स्लाइड आयाम को [ISlideSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/) के माध्यम से नियंत्रित करता है। |

एक सेटिंग को बदलने से दूसरी स्वचालित रूप से नहीं बदलती। नोट्स पेज अभिविन्यास बदलने से सामान्य स्लाइड्स का घुमा नहीं जाता। सामान्य स्लाइड्स के आकार बदलने के लिए देखें [Slide Size](/slides/hi/androidjava/slide-size/).

नीचे के उदाहरण एक मौजूदा `sample.pptx` का उपयोग करते हैं। निर्यात उदाहरणों के लिए, ऐसी प्रस्तुति उपयोग करें जिसमें कम से कम एक स्लाइड में स्पीकर नोट्स हों। प्रत्येक उदाहरण को स्वतंत्र रूप से चलाया जा सकता है।

## **नोट्स पेज आकार और अभिविन्यास पढ़ें**

चौड़ाई और ऊंचाई को पढ़ें और उनकी तुलना करके अभिविन्यास निर्धारित करें: चौड़ा पेज लैंडस्केप होता है, ऊँचा पेज पोर्ट्रेट होता है, और समान आयाम स्क्वेयर पेज दर्शाते हैं। यह उदाहरण वास्तविक आयाम पॉइंट्स में प्रिंट करता है, बिना मानक कागज़ आकार माने।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **पेपर आकार बदले बिना लैंडस्केप में स्विच करें**

केवल अभिविन्यास बदलने के लिए, मौजूदा चौड़ाई और ऊँचाई को अदला-बदली करें। यह दोनों पक्षों की लंबाई को संरक्षित करता है, जिसमें कस्टम पेपर आकार की लंबाई भी शामिल है। नीचे की शर्त पहले से लैंडस्केप पेज को पुनः पोर्ट्रेट में स्विच होने से रोकती है और स्क्वायर पेज को अपरिवर्तित रखती है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पोर्ट्रेट अभिविन्यास के लिए, वही असाइनमेंट उपयोग करें जब `size.getWidth() > size.getHeight()` हो। जब तक आप पेपर आकार भी बदलना नहीं चाहते, A4 या Letter आयामों को न बदलें।

## **एक कस्टम नोट्स पेज आकार सेट करें और सत्यापित करें**

दोनों आयाम एक साथ असाइन करें, फिर प्रस्तुति लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) उपयोग करें। यह उदाहरण 900 × 600 पॉइंट लैंडस्केप पेज सेट करता है, इसे PPTX के रूप में सहेजता है, और फिर सहेजी गई फ़ाइल को फिर से खोलकर स्थिर मानों की जाँच करता है। तुलना फ्लोटिंग पॉइंट मानों के लिए 0.01 पॉइंट सहनशीलता की अनुमति देती है; यह प्रत्येक फ़ाइल प्रारूप के लिए सटीकता की गारंटी नहीं है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

अपेक्षित परिणाम `900.0 x 600.0 पॉइंट्स` और `Size preserved: true` है। नई खोली गई प्रस्तुति की जाँच सहेजी फ़ाइल की पुष्टि करती है, न कि केवल इन-मेमोरी सेटिंग्स की।

## **नोट्स और हैंडआउट निर्यात**

पृष्ठ आयाम नोट्स या हैंडआउट लेआउट के उपलब्ध क्षेत्र को निर्धारित करते हैं। वे अकेले उन लेआउट को सक्षम नहीं करते: निर्यात विकल्प भी कॉन्फ़िगर करें। सामान्य स्लाइड निर्यात अभी भी स्लाइड आयामों का उपयोग करता है।

### **PDF और PNG में नोट्स निर्यात**

[NotesCommentsLayoutingOptions] को [PdfOptions.setSlidesLayoutOptions] में असाइन करें ताकि PDF में नोट्स शामिल हों। यह उदाहरण [Slide.getImage] और [RenderingOptions] का उपयोग करके नोट्स के साथ पहली स्लाइड को PNG में भी रेंडर करता है।

[BottomTruncated] मोड नोट्स को एक पेज पर रखता है; जो नोट्स पूरी नहीं होते उन्हें ट्रंकेट किया जा सकता है। PDF 900 × 600 पॉइंट पेजों का उपयोग करता है। नीचे उपयोग किए गए 1 × 1 इमेज स्केल पर, PNG 900 × 600 पिक्सेल है। पॉइंट्स पृष्ठ ज्यामिति को दर्शाते हैं; पिक्सेल रैस्टर आउटपुट को दर्शाते हैं, जिनका आकार रेंडरिंग स्केल पर भी निर्भर करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

लंबे नोट्स वाले PDF निर्यात के लिए, [BottomFull] आवश्यकता अनुसार अतिरिक्त पेजों की अनुमति देता है। ऊपर के सिंगल-स्लाइड इमेज कॉल के साथ इस मोड का उपयोग न करें, क्योंकि वह इसका समर्थन नहीं करता। आकार बदलने के बाद, क्लिप किए गए नोट्स और मौजूदा notes-master ऑब्जेक्ट्स की प्लेसमेंट के लिए आउटपुट जांचें; केवल पेज आयाम बदलना यह गारंटी नहीं देता कि सभी सामग्री फिट होगी। नोट्स निर्यात के बारे में अधिक जानकारी के लिए देखें [Convert PowerPoint to PDF with Notes](/slides/hi/androidjava/convert-powerpoint-to-pdf-with-notes/)।

### **PDF में हैंडआउट निर्यात**

एक पेज पर कई स्लाइड थंबनेल के लिए [HandoutLayoutingOptions] का उपयोग करें। निम्न उदाहरण 900 × 600 पॉइंट पेज सेट करता है और [HandoutType.Handouts4Horizontal] का उपयोग करके प्रति पेज अधिकतम चार स्लाइड व्यवस्थित करता है। हॉरिज़ॉन्टल प्रीसेट स्लाइड क्रम को नियंत्रित करता है; पेज अभिविन्यास उसकी चौड़ाई और ऊँचाई से निर्धारित होता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

पेज आकार बदलने से हैंडआउट ग्रिड के उपलब्ध क्षेत्र में परिवर्तन होता है बिना स्रोत स्लाइड्स के आयाम बदले। हैंडआउट इमेज के लिए, व्यक्तिगत स्लाइड इमेज मेथड के बजाय हैंडआउट लेआउट के साथ [Presentation.getImages] का उपयोग करें। Aspose.Slides में, प्रस्तुति-स्तर हैंडआउट रेंडरिंग नोट्स पेज आयामों का उपयोग करती है, जबकि व्यक्तिगत स्लाइड इमेज कॉल हैंडआउट पेज नहीं बनाता। लेआउट विकल्पों के लिए देखें [Handout Mode](/slides/hi/androidjava/convert-powerpoint-in-handout-mode/)।

## **व्यूअर्स, निर्यात और प्रिंटिंग में पेज आकार**

संचित प्रस्तुति आकार, निर्यात पेज आकार, और प्रिंटेड पेपर आकार को अलग रखें:

- **Presentation viewers:** एक व्यूअर अपने लेआउट नियमों का उपयोग करके नोट्स प्रदर्शित या प्रिंट कर सकता है। यदि कोई अन्य एप्लिकेशन फ़ाइल सहेजता है, तो उसे पुनः खोलें और आयाम फिर से जांचें; उस एप्लिकेशन का फ़ॉर्मेट रूपांतरण उन्हें सामान्य कर सकता है।
- **Export formats:** ऊपर के नोट्स और हैंडआउट PDF उदाहरण कॉन्फ़िगर किए गए पेज आयामों का उपयोग करते हैं। रास्टर इमेज पूर्णांक पिक्सेल आयाम और एक रेंडरिंग स्केल उपयोग करती हैं, इसलिए फ्रैक्शनल पॉइंट मान इमेज आउटपुट में राउंड हो सकते हैं। सामान्य स्लाइड निर्यात में नोट्स पेज आकार लागू नहीं होता।
- **Printer drivers:** पेपर चयन, ऑटोमैटिक रोटेशन और फिट-टू-पेज सेटिंग्स भौतिक आउटपुट को बदल सकती हैं बिना प्रस्तुति या PDF में संग्रहीत आयाम बदले। किसी विशिष्ट पेपर आकार के लिए, प्रिंटर सेटिंग्स मिलाएँ और प्रिंट प्रीव्यू जांचें।

## **FAQ**

**क्या मैं केवल एक स्लाइड के लिए नोट्स आकार सेट कर सकता हूँ?**

नोट्स पेज आकार प्रस्तुति-स्तर सेटिंग है। व्यक्तिगत स्लाइड्स में विभिन्न नोट्स सामग्री हो सकती है, पर यह प्रॉपर्टी प्रत्येक स्लाइड के लिए अलग पेज आकार प्रदान नहीं करती।

**नोट्स अभिविन्यास बदलने से मेरी स्लाइड्स क्यों नहीं बदलीं?**

नोट्स पेज और सामान्य स्लाइड्स के आयाम स्वतंत्र होते हैं। यदि आप स्वयं स्लाइड्स का आकार बदलना चाहते हैं तो नियमित स्लाइड आकार सेटिंग्स का उपयोग करें।

**मेरे सहेजे या प्रिंट किए गए परिणाम का आकार अलग क्यों है?**

पहले सहेजी गई प्रस्तुति को पुनः खोलें और उसके नोट्स आयामों की तुलना करें। यदि वे बदल गए हैं, तो देखें कि क्या किसी अन्य एप्लिकेशन में फ़ाइल सहेजने या रूपांतरित करने से पेज सेटिंग्स बदल गईं। यदि नहीं, तो निर्यात लेआउट, इमेज स्केल, व्यूअर सेटिंग्स, और प्रिंटर पेपर चयन जांचें।