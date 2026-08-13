---
title: Android पर PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ सम्मिलित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- PowerPoint से PDF
- प्रेज़ेंटेशन से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च गुणवत्ता, खोज योग्य PDFs में बदलें, तेज कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

Android में PowerPoint प्रेजेंटेशन (PPT, PPTX, ODP आदि) को PDF फ़ॉर्मेट में बदलने से कई लाभ मिलते हैं, जिनमें विभिन्न डिवाइसों के बीच संगतता और आपके प्रेजेंटेशन की लेआउट और फॉर्मेटिंग को संरक्षित रखना शामिल है। यह गाइड दिखाता है कि प्रेजेंटेशन को PDF दस्तावेज़ में कैसे बदलें, इमेज क्वालिटी को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी हुई स्लाइड्स को शामिल करें, PDF फ़ाइल को पासवर्ड-प्रोटेक्ट करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, बदलने के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ पर अनुपालन मानक लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्न फ़ॉर्मेट के प्रेजेंटेशन को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

प्रेजेंटेशन को PDF में बदलने के लिए फ़ाइल नाम को एक तर्क के रूप में [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास को पास करें और फिर `save` मेथड का उपयोग करके प्रेजेंटेशन को PDF के रूप में सेव करें। [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास `save` मेथड को उजागर करता है जो आमतौर पर प्रेजेंटेशन को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert title="ध्यान देँ" color="warning"%}} 

Aspose.Slides for Android via Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब प्रेजेंटेशन को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **Note** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने का निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूपांतरण करने की अनुमति देता है:

* पूरे प्रेजेंटेशन को PDF में
* प्रेजेंटेशन से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रेजेंटेशन को PDF में एक्सपोर्ट करता है, जिससे उत्पन्न PDF मूल प्रेजेंटेशन के बहुत करीब रहता है। रूपांतरण के दौरान तत्व और विशेषताएँ सटीक रूप से रेंडर की जाती हैं, जिसमें शामिल हैं:

* इमेजेस
* टेक्स्ट बॉक्स और शैप्स
* टेक्स्ट फॉर्मेटिंग
* पैराग्राफ फॉर्मेटिंग
* हाइपरलिंक्स
* हेडर और फुटर
* बुलेट्स
* टेबल्स

## **PowerPoint को PDF में बदलें**

डिफ़ॉल्ट विकल्पों के साथ मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया का उपयोग किया जाता है। इस स्थिति में, Aspose.Slides प्रदान किए गए प्रेजेंटेशन को अधिकतम गुणवत्ता स्तरों पर अनुकूल सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह कोड示ाता है कि प्रेजेंटेशन (PPT, PPTX, ODP आदि) को PDF में कैसे बदलें:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाते हैं जो PowerPoint या OpenDocument फ़ाइल को दर्शाता है।
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // प्रेजेंटेशन को PDF के रूप में सहेजें।
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info"%}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf)提供 करता है जो प्रेजेंटेशन‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कन्‍वर्टर के साथ एक परीक्षण चलाकर यहाँ वर्णित प्रक्रिया को लाइव देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के तहत प्रॉपर्टीज़—प्रदान करता है जो आपको परिणामी PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या रूपांतरण प्रक्रिया के प्रवाह को निर्दिष्ट करने की अनुमति देती हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर इमेजेस के लिए वांछित क्वालिटी सेटिंग, मेटा‑फ़ाइल्स को कैसे हैंडल किया जाए, टेक्स्ट के लिए कम्प्रेशन लेवल, इमेजेस के DPI आदि निर्दिष्ट कर सकते हैं।

निम्न कोड उदाहरण दिखाता है कि कई कस्टम विकल्पों के साथ PowerPoint प्रेजेंटेशन को PDF में कैसे बदलें:

```java
import com.aspose.slides.*;

// PdfOptions क्लास को instantiate करें।
PdfOptions pdfOptions = new PdfOptions();

// JPG इमेजेस की क्वालिटी सेट करें।
pdfOptions.setJpegQuality((byte)90);

// इमेजेस के लिए DPI सेट करें।
pdfOptions.setSufficientResolution(300);

/// मेटा फ़ाइलों के व्यवहार को सेट करें।
pdfOptions.setSaveMetafilesAsPng(true);

// टेक्स्ट सामग्री के लिए टेक्स्ट कम्प्रेशन लेवल सेट करें।
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF अनुपालन मोड परिभाषित करें।
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // प्रेज़ेंटेशन को PDF दस्तावेज़ के रूप में सहेजें।
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **छिपी हुई स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रेजेंटेशन में छिपी हुई स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के `setShowHiddenSlides` मेथड का उपयोग करके छिपी हुई स्लाइड्स को परिणामी PDF में पेज के रूप में शामिल कर सकते हैं।

यह कोड दिखाता है कि छिपी हुई स्लाइड्स के साथ PowerPoint प्रेजेंटेशन को PDF में कैसे बदलें:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का उदाहरण बनाएं।
    PdfOptions pdfOptions = new PdfOptions();

    // छुपी स्लाइड्स जोड़ें।
    pdfOptions.setShowHiddenSlides(true);

    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **पासवर्ड‑प्रोटेक्टेड PDF के साथ PowerPoint को बदलें**

यह कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के प्रोटेक्शन पैरामीटर्स का उपयोग करके PowerPoint प्रेजेंटेशन को पासवर्ड‑प्रोटेक्टेड PDF में कैसे बदलें:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का उदाहरण बनाएं।
    PdfOptions pdfOptions = new PdfOptions();

    // PDF पासवर्ड और एक्सेस अनुमतियां सेट करें।
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के तहत `setWarningCallback` मेथड प्रदान करता है, जिससे आप प्रेजेंटेशन‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह कोड दिखाता है कि फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाएँ:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
    Presentation presentation = new Presentation("sample.pptx");

    // PDF विकल्पों में warning callback सेट करें।
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// warning callback का कार्यान्वयन।
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info"%}} 

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें [Font Substitution](/slides/hi/androidjava/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

यह कोड सिर्फ विशिष्ट स्लाइड्स को PowerPoint प्रेजेंटेशन से PDF में बदलने का प्रदर्शन करता है:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // स्लाइड नंबरों की एरे सेट करें।
    int[] slides = { 1, 3 };

    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह कोड निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रेजेंटेशन को PDF में बदलने का प्रदर्शन करता है:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ नई प्रेज़ेंटेशन बनाएं।
Presentation resizedPresentation = new Presentation();

try {
    // कस्टम स्लाइड आकार सेट करें।
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // मूल प्रेज़ेंटेशन से पहली स्लाइड को क्लोन करें।
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // नई बनाई गई प्रेज़ेंटेशन में मौजूद खाली स्लाइड को हटाएँ।
    resizedPresentation.getSlides().removeAt(1);

    // रिज़ाइज़्ड प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट स्लाइड व्यू में PDF के साथ PowerPoint को बदलें**

यह कोड नोट्स सहित PDF उत्पन्न करने के लिए PowerPoint प्रेजेंटेशन को कैसे बदलें, दर्शाता है:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // PDF विकल्पों को नोट्स लेआउट के साथ कॉन्फ़िगर करें।
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // प्रेज़ेंटेशन को नोट्स के साथ PDF में सहेजें।
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF के लिए एक्सेसिबिलिटी और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को निम्नलिखित अनुपालन मानकों में से किसी एक का उपयोग करके PDF में एक्सपोर्ट कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDF उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="नोट" color="warning"%}} 

Aspose.Slides PDF रूपांतरण ऑपरेशन्स का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल फ़ॉर्मेट में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य PDF रूपांतरण ऑपरेशन्स—[PDF to SVG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/java/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **Note:** जब PDF/UA में एक्सपोर्ट किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एकल फ़िगर के रूप में ट्रीट करता है। व्यक्तिगत पाथ एलेमेंट्स को अलग कंटेंट के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में मार्क किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरे फ़िगर के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कई PowerPoint फ़ाइलों को बैच में PDF में बदल सकता हूँ?

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटरेट कर सकते हैं और प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

### क्या बदलाए गए PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?

बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस परमिशन्स परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

### मैं PDF में छिपी हुई स्लाइड्स को कैसे शामिल करूँ?

परिणामी PDF में छिपी हुई स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास में `setShowHiddenSlides` मेथड का उपयोग करें।

### क्या Aspose.Slides PDF में उच्च इमेज क्वालिटी बनाए रख सकता है?

हाँ, आप `setJpegQuality` और `setSufficientResolution` जैसे मेथड्स का उपयोग करके PDF में उच्च‑गुणवत्ता वाली इमेजेस सुनिश्चित कर सकते हैं।

### क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?

हाँ, Aspose.Slides आपको विभिन्न मानकों जैसे PDF/A1a, PDF/A1b, और PDF/UA के अनुरूप PDF एक्सपोर्ट करने की अनुमति देता है, जिससे आपके दस्तावेज़ एक्सेसिबिलिटी और आर्काइविंग आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Android via Java Documentation](/slides/hi/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/hi/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)