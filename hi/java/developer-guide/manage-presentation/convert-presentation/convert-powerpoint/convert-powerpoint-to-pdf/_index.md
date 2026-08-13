---
title: Java में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint को PDF में
type: docs
weight: 40
url: /hi/java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint परिवर्टित करें
- प्रेज़ेंटेशन परिवर्तित करें
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
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, सर्चेबल PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ."
---
## **समीक्षा**

जावा में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF स्वरूप में बदलने से कई लाभ मिलते हैं, जैसे विभिन्न उपकरणों में संगतता और आपकी प्रस्तुति की लेआउट व फ़ॉर्मेटिंग को संरक्षित रखना। यह गाइड प्रस्तुतियों को PDF दस्तावेज़ों में बदलने, छवि गुणवत्ता को नियंत्रित करने के विभिन्न विकल्पों का उपयोग करने, छुपी स्लाइड्स को शामिल करने, PDF फ़ाइलों को पासवर्ड‑प्रोटेक्ट करने, फ़ॉन्ट प्रतिस्थापन का पता लगाने, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनने, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करने का तरीका दर्शाता है।

## **PowerPoint को PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्न स्वरूपों की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में तर्क के रूप में पास करें और फिर `save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास `save` मेथड को उजागर करती है, जो आम तौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग की जाती है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूपांतरण करने की अनुमति देता है:

* पूरी प्रस्तुति को PDF में बदलना
* प्रस्तुति से विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे उत्पन्न PDF मूल प्रस्तुतियों से बहुत करीब मेल खाते हैं। रूपांतरण के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकृतियाँ
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides उपलब्ध प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर अनुकूलित सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह कोड दिखाता है कि कैसे प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में बदला जाए:

```java
import com.aspose.slides.*;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है, जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कनवर्टर के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के तहत गुण—प्रदान करता है, जिससे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या रूपांतरण प्रक्रिया के प्रवाह को निर्दिष्ट कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेट कर सकते हैं, मेटाफाइल्स को कैसे संभालना है निर्धारित कर सकते हैं, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के लिए DPI कॉन्फ़िगर कर सकते हैं, आदि।

नीचे दिया गया कोड उदाहरण कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में बदलने को दर्शाता है।

```java
import com.aspose.slides.*;

// PdfOptions क्लास का उदाहरण बनाएं।
PdfOptions pdfOptions = new PdfOptions();

// JPG छवियों की गुणवत्ता सेट करें।
pdfOptions.setJpegQuality((byte)90);

// छवियों के लिए DPI सेट करें।
pdfOptions.setSufficientResolution(300);

// मेटा फ़ाइलों के व्यवहार को सेट करें।
pdfOptions.setSaveMetafilesAsPng(true);

// पाठ्य सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें।
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF अनुपालन मोड को परिभाषित करें।
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

### **छुपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छुपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) मेथड का उपयोग करके छुपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह कोड दिखाता है कि कैसे छुपी स्लाइड्स सहित PowerPoint प्रस्तुति को PDF में बदला जाए:

```java
import com.aspose.slides.*;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
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

यह कोड दिखाता है कि कैसे [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के सुरक्षा पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑प्रोटेक्टेड PDF में बदला जाए:

```java
import com.aspose.slides.*;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का उदाहरण बनाएं।
    PdfOptions pdfOptions = new PdfOptions();

    // PDF का पासवर्ड और पहुँच अनुमतियाँ सेट करें।
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) मेथड प्रदान करता है, जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाने में सक्षम बनाता है।

यह कोड दिखाता है कि कैसे फ़ॉन्ट प्रतिस्थापन का पता लगाया जाए:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
    Presentation presentation = new Presentation("sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें।
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// चेतावनी कॉलबैक का कार्यान्वयन।
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

{{%  alert color="info"  %}} 

फ़ॉन्ट प्रतिस्थापन के दौरान रेंडरिंग प्रक्रिया में कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें: [Getting Warning Callbacks for Fonts Substitution](/slides/hi/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें: [Font Substitution](/slides/hi/java/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint में चयनित स्लाइड्स को PDF में बदलें**

यह कोड दर्शाता है कि कैसे PowerPoint प्रस्तुति से केवल विशिष्ट स्लाइड्स को PDF में बदला जाए:

```java
import com.aspose.slides.*;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
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

यह कोड दर्शाता है कि कैसे निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में बदला जाए:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाएं।
Presentation resizedPresentation = new Presentation();

try {
    // कस्टम स्लाइड आकार सेट करें।
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // मूल प्रस्तुति से पहली स्लाइड को क्लोन करें।
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // नई प्रस्तुति के साथ बनाई गई खाली स्लाइड को हटाएँ।
    resizedPresentation.getSlides().removeAt(1);

    // रीसाइज़्ड प्रस्तुति को PDF के रूप में सहेजें।
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट्स स्लाइड व्यू में PDF के साथ PowerPoint को बदलें**

यह कोड दर्शाता है कि कैसे नोट्स सहित PowerPoint प्रस्तुति को PDF में बदला जाए:

```java
import com.aspose.slides.*;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Notes लेआउट के साथ PDF विकल्पों को कॉन्फ़़िगर करें।
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

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए निम्नलिखित अनुपालन मानकों में से कोई भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides PDF रूपांतरण संचालन का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष स्वरूपों में PDF रूपांतरण—[PDF to SVG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/java/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और सूत्र को एक ही आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और उन्हें कलाकृति के रूप में चिह्नित किया जा सकता है; वैकल्पिक पाठ केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **FAQ**

### क्या मैं कई PowerPoint फ़ाइलों को बैच में PDF में बदल सकता हूँ?

हां, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों में इटररेट करके प्रोग्रामॅटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

### क्या बदले गए PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?

बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और पहुँच अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

### मैं PDF में छुपी स्लाइड्स को कैसे शामिल करूं?

परिणामी PDF में छुपी स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास में `setShowHiddenSlides` मेथड का उपयोग कर सकते हैं।

### क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?

हां, आप `setJpegQuality` और `setSufficientResolution` जैसी मेथड्स का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास में छवि गुणवत्ता को नियंत्रित कर सकते हैं, जिससे आपके PDF में उच्च‑गुणवत्ता वाली छवियां मिलेंगी।

### क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?

हां, Aspose.Slides आपको उन PDF को निर्यात करने की अनुमति देता है जो [विविध मानकों](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfcompliance/) के साथ संगत होते हैं, जिनमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ अभिगम्यता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Java Documentation](/slides/hi/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/hi/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)