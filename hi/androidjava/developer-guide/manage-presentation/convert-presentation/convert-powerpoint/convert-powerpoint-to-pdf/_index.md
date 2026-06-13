---
title: "Android पर PPT और PPTX को PDF में बदलें [उन्नत सुविधाओं सहित]"
linktitle: "PowerPoint से PDF"
type: docs
weight: 40
url: /hi/androidjava/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint परिवर्तित करें"
- "प्रेजेंटेशन परिवर्तित करें"
- "PowerPoint से PDF"
- "प्रेजेंटेशन से PDF"
- "PPT से PDF"
- "PPT को PDF में बदलें"
- "PPTX से PDF"
- "PPTX को PDF में बदलें"
- "PowerPoint को PDF रूप में सहेजें"
- "PPT को PDF रूप में सहेजें"
- "PPTX को PDF रूप में सहेजें"
- "PPT को PDF में निर्यात करें"
- "PPTX को PDF में निर्यात करें"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, खोजी जाने योग्य PDFs में बदलें, तेज़ कोड उदाहरण और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को Android में PDF फ़ॉर्मेट में बदलने के कई लाभ होते हैं, जिसमें विभिन्न उपकरणों पर संगतता और आपकी प्रस्तुति का लेआउट तथा फ़ॉर्मेटिंग संरक्षित रहना शामिल है। यह गाइड दिखाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित किया जाए, इमीज क्वालिटी को नियंत्रित करने के विभिन्न विकल्पों का उपयोग कैसे किया जाए, छिपी स्लाइड्स को शामिल किया जाए, PDF फ़ाइलों को पासवर्ड‑प्रोटेक्ट किया जाए, फ़ॉन्ट प्रतिस्थापन का पता लगाया जाए, विशिष्ट स्लाइड्स का चयन किया जाए, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू किया जाए।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्न फ़ॉर्मेट की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास में एक आर्ग्यूमेंट के रूप में पास करें और फिर `save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास `save` मेथड को उजागर करता है जिसे आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{%  alert title="ध्यान दें"  color="warning"   %}} 

Aspose.Slides for Android via Java अपनी API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब कोई प्रस्तुति PDF में बदली जाती है, तो Aspose.Slides *Application* फ़ील्ड को “*Aspose.Slides*” और PDF Producer फ़ील्ड को “*Aspose.Slides v XX.XX*” रूप में सेट करता है। **ध्यान रखें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देशित नहीं कर सकते।

{{% /alert %}}

Aspose.Slides आपको निम्न रूपांतरण करने की अनुमति देता है:

* संपूर्ण प्रस्तुतियों को PDF में
* प्रस्तुति में से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि उत्पन्न PDFs मूल प्रस्तुतियों के बहुत करीब हों। रूपांतरण में तत्व और एट्रीब्यूट सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* चित्र
* टेक्स्ट बॉक्स और शेप्स
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह कोड दिखाता है कि प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में कैसे बदला जाए:

```java
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को प्रदर्शित करता है। आप इस कंवर्टर के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया को लाइव देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है जिससे आप बनते PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या रूपांतरण प्रक्रिया की दिशा निर्धारित कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर इमेजेज़ के लिए वांछित गुणवत्ता सेट कर सकते हैं, मेटा‑फ़ाइल्स को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर, इमेजेज़ के DPI आदि निर्धारित कर सकते हैं।

नीचे का कोड उदाहरण दर्शाता है कि कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```java
// PdfOptions क्लास का इंस्टैंस बनाएं।
PdfOptions pdfOptions = new PdfOptions();

// JPG इमेजेज़ की क्वालिटी सेट करें।
pdfOptions.setJpegQuality((byte)90);

// इमेजेज़ के लिए DPI सेट करें।
pdfOptions.setSufficientResolution(300);

/// मेटाफ़ाइल्स के व्यवहार को सेट करें।
pdfOptions.setSaveMetafilesAsPng(true);

// टेक्स्ट सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें।
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF अनुपालन मोड परिभाषित करें।
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Presentation क्लास का इंस्टैंस बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजें।
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास की `setShowHiddenSlides` मेथड का उपयोग करके छिपी स्लाइड्स को परिणामस्वरूप PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह कोड दिखाता है कि छिपी स्लाइड्स सहित PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```java
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का इंस्टैंस बनाएं।
    PdfOptions pdfOptions = new PdfOptions();

    // छिपी स्लाइड्स जोड़ें।
    pdfOptions.setShowHiddenSlides(true);

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **पासवर्ड‑प्रोटेक्टेड PDF के साथ PowerPoint को बदलें**

यह कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के सुरक्षा पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑प्रोटेक्टेड PDF में कैसे बदला जाए:

```java
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का इंस्टैंस बनाएं।
    PdfOptions pdfOptions = new PdfOptions();

    // PDF पासवर्ड और एक्सेस अनुमतियाँ सेट करें।
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास के अंतर्गत `setWarningCallback` मेथड प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह कोड दिखाता है कि फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाया जाए:

```java
public static void main(String[] args) {
    // PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
    Presentation presentation = new Presentation("sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें।
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
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

{{%  alert color="primary"  %}} 

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/androidjava/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

यह कोड केवल विशिष्ट स्लाइड्स को PowerPoint प्रस्तुति से PDF में बदलने का प्रदर्शन करता है:

```java
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // स्लाइड नंबरों की array सेट करें।
    int[] slides = { 1, 3 };

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Custom Slide Size के साथ PowerPoint को PDF में बदलें**

यह कोड निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में बदलने का प्रदर्शन करता है:

```java
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाएं।
Presentation resizedPresentation = new Presentation();

try {
    // कस्टम स्लाइड आकार सेट करें।
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // मूल प्रस्तुति से पहली स्लाइड की क्लोन बनाएं।
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // रीसाइज़ की गई प्रस्तुति को नोट्स सहित PDF में सहेजें।
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Notes Slide View में PowerPoint को PDF में बदलें**

यह कोड नोट्स सहित PowerPoint प्रस्तुति को PDF में बदलने का प्रदर्शन करता है:

```java
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Notes Layout के साथ PDF विकल्प कॉन्फ़िगर करें।
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // प्रेजेंटेशन को नोट्स सहित PDF में सहेजें।
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF के लिए एक्सेसिबिलिटी और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए इन अनुपालन मानकों में से किसी का भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

```java
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

{{% alert title="ध्यान दें" color="warning" %}} 

Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ॉर्मेट में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। विशेषीकृत फ़ॉर्मेट—[PDF to SVG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/java/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-xml/)—के लिए भी समर्थन उपलब्ध है।

{{% /alert %}}

> **ध्यान दें:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फ़ॉर्मूले को एकल आकृति के रूप में लेता है। व्यक्तिगत पाथ एलिमेंट्स को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टीफ़ैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए उपलब्ध है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**  
हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच में PDF में बदलने का समर्थन करता है। आप प्रोग्रामmatically अपने फ़ाइलों पर लूप लगा कर रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या बदले गए PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**  
बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**  
परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) क्लास में `setShowHiddenSlides` मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च इमेज क्वालिटी बनाए रख सकता है?**  
हाँ, आप `setJpegQuality` और `setSufficientResolution` जैसी मेथड्स का उपयोग करके PDF में इमेज क्वालिटी को उच्च रख सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**  
हाँ, Aspose.Slides विभिन्न मानकों, जैसे PDF/A1a, PDF/A1b, और PDF/UA के अनुरूप PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ एक्सेसिबिलिटी और आर्काइविंग आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Android via Java Documentation](/slides/hi/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/hi/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)