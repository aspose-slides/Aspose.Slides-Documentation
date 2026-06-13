---
title: Java में PPT और PPTX को PDF में बदलें [उन्नत सुविधाओं सहित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PowerPoint से PDF
- प्रस्तुति को PDF
- PPT को PDF
- PPT को PDF में बदलें
- PPTX को PDF
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
description: "Aspose.Slides का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोजयोग्य PDFs में बदलें, त्वरित कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **सामान्य अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को Java में PDF फ़ॉर्मेट में बदलने के कई लाभ हैं, जैसे विभिन्न उपकरणों में संगतता और प्रस्तुति का लेआउट व फ़ॉर्मेटिंग बनाए रखना। यह गाइड प्रस्तुतियों को PDF दस्तावेज़ों में बदलना, इमेज क्वालिटी नियंत्रित करने के विकल्प, छिपी स्लाइडों को शामिल करना, PDF फ़ाइलों को पासवर्ड‑प्रोटेक्ट करना, फ़ॉन्ट प्रतिस्थापन का पता लगाना, रूपांतरण के लिए विशिष्ट स्लाइडों का चयन करना, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करना दिखाता है।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्न फ़ॉर्मेट की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में आर्गुमेंट के रूप में पास करें और फिर `save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास `save` मेथड प्रदान करती है जिसे सामान्यतः प्रस्तुति को PDF में बदलने के लिए प्रयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Java आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या सम्मिलित करता है। उदाहरण के तौर पर, जब प्रस्तुति को PDF में बदलते हैं, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को यह जानकारी बदलने या हटाने के निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको निम्न रूपांतरण करने देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुतियों से विशिष्ट स्लाइडों को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे उत्पन्न PDF मूल प्रस्तुति के बहुत करीब होते हैं। रूपांतरण के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिनमें शामिल हैं:

* इमेज
* टेक्स्ट बॉक्स और शेप
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* टेबल

## **PowerPoint को PDF में बदलें**

डिफ़ॉल्ट विकल्पों के साथ मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया चलती है। इस मामले में, Aspose.Slides अधिकतम गुणवत्ता स्तर पर इष्टतम सेटिंग्स के साथ प्रदान की गई प्रस्तुति को PDF में बदलने का प्रयास करता है।

नीचे दिया गया कोड दिखाता है कि प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में कैसे बदला जाए:

```java
// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कन्वर्टर के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया को लाइव देख सकते हैं।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के तहत प्रो퍼टीज़—प्रदान करता है, जिससे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, पासवर्ड से लॉक कर सकते हैं, या रूपांतरण प्रक्रिया के प्रवाह को निर्धारित कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रैस्टर इमेज की इच्छित क्वालिटी सेट कर सकते हैं, मेटा फ़ाइलों को कैसे हैंडल किया जाए निर्धारित कर सकते हैं, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, इमेज के DPI को कॉन्फ़िगर कर सकते हैं, आदि।

नीचे दिया गया कोड उदाहरण कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में बदलना प्रदर्शित करता है:

```java
// PdfOptions क्लास का एक उदाहरण बनाइए।
PdfOptions pdfOptions = new PdfOptions();

// JPG इमेज की क्वालिटी सेट करें।
pdfOptions.setJpegQuality((byte)90);

// इमेज के लिए DPI सेट करें।
pdfOptions.setSufficientResolution(300);

// मेटा फ़ाइलों के व्यवहार को सेट करें।
pdfOptions.setSaveMetafilesAsPng(true);

// पाठ सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें।
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF अनुपालन मोड परिभाषित करें।
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजें।
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **छिपी स्लाइडों के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइडें हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास की `setShowHiddenSlides` मेथड का उपयोग करके छिपी स्लाइडों को परिणामस्वरूप PDF में पेज के रूप में सम्मिलित कर सकते हैं।

यह कोड दर्शाता है कि छिपी स्लाइडों को शामिल करके PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```java
// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का एक उदाहरण बनाइए।
    PdfOptions pdfOptions = new PdfOptions();

    // छिपी स्लाइडें जोड़ें।
    pdfOptions.setShowHiddenSlides(true);

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **पासवर्ड‑प्रोटेक्टेड PDF के साथ PowerPoint को बदलें**

यह कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के संरक्षण पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑प्रोटेक्टेड PDF में कैसे बदला जाए:

```java
// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास का एक उदाहरण बनाइए।
    PdfOptions pdfOptions = new PdfOptions();

    // PDF पासवर्ड और पहुंच अनुमतियों को सेट करें।
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के तहत `setWarningCallback` मेथड प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह कोड फ़ॉन्ट प्रतिस्थापन का पता लगाने का उदाहरण दर्शाता है:

```java
public static void main(String[] args) {
    // Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है.
    Presentation presentation = new Presentation("sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // प्रस्तुति को PDF के रूप में सहेजें.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// चेतावनी कॉलबैक का कार्यान्वयन.
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

रेंडरिंग प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन के लिए कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें: [Getting Warning Callbacks for Fonts Substitution](/slides/hi/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें: [Font Substitution](/slides/hi/java/font-substitution/) लेख।
{{% /alert %}} 

## **PowerPoint में चयनित स्लाइडों को PDF में बदलें**

यह कोड दर्शाता है कि PowerPoint प्रस्तुति से केवल चयनित स्लाइडों को PDF में कैसे बदला जाए:

```java
// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // स्लाइड नंबरों की एरे सेट करें।
    int[] slides = { 1, 3 };

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह कोड दर्शाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```java
float slideWidth = 612;
float slideHeight = 792;

// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ एक नई प्रस्तुति बनाइए।
Presentation resizedPresentation = new Presentation();

try {
    // कस्टम स्लाइड आकार सेट करें।
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // मूल प्रस्तुति से पहली स्लाइड को क्लोन करें।
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // रिसाइज़्ड प्रस्तुति को नोट्स के साथ PDF में सहेजें।
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

यह कोड दर्शाता है कि नोट्स सहित PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```java
// Presentation क्लास का एक उदाहरण बनाइए जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // नोट्स लेआउट के साथ PDF विकल्प कॉन्फ़िगर करें।
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // प्रस्तुति को नोट्स के साथ PDF में सहेजें।
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप PowerPoint दस्तावेज़ को PDF में निर्यात करते समय इन अनुपालन मानकों में से किसी को भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

नीचे दिया गया कोड विभिन्न अनुपालन मानकों पर आधारित कई PDF उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

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

{{% alert title="Note" color="warning" %}} 
Aspose.Slides PDF रूपांतरण संचालन का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल फ़ॉर्मेट में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशिष्ट फ़ॉर्मेट—[PDF to SVG](https://products.aspose.com/slides/hi/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/java/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/java/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्व अलग कंटेंट के रूप में संरक्षित नहीं रहते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए उपलब्ध कराया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**  
हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच रूप में PDF में बदलने का समर्थन करता है। आप अपनी फ़ाइलों पर इटरेट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या बदले हुए PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**  
बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियाँ निर्धारित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइडों को कैसे शामिल करूँ?**  
परिणामी PDF में छिपी स्लाइडों को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास की `setShowHiddenSlides` मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च इमेज क्वालिटी बनाए रख सकता है?**  
हाँ, आप `setJpegQuality` और `setSufficientResolution` जैसे मेथड्स का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास में इमेज की गुणवत्ता को नियंत्रित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**  
हाँ, Aspose.Slides आपको ऐसे PDF निर्यात करने देता है जो [विविध मानकों](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfcompliance/) के अनुरूप हैं, जिनमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ अभिगम्यता और संग्रहण आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Java Documentation](/slides/hi/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/hi/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)