---
title: "PHP में PPT और PPTX को PDF में परिवर्तित करें [उन्नत सुविधाएँ शामिल]"
linktitle: "PowerPoint से PDF"
type: docs
weight: 40
url: /hi/php-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint परिवर्तित करें"
- "प्रेज़ेंटेशन परिवर्तित करें"
- "PowerPoint से PDF"
- "प्रेज़ेंटेशन से PDF"
- "PPT से PDF"
- "PPT को PDF में परिवर्तित करें"
- "PPTX से PDF"
- "PPTX को PDF में परिवर्तित करें"
- "PowerPoint को PDF के रूप में सहेजें"
- "PPT को PDF के रूप में सहेजें"
- "PPTX को PDF के रूप में सहेजें"
- "PPT को PDF में निर्यात करें"
- "PPTX को PDF में निर्यात करें"
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint PPT/PPTX को उच्च गुणवत्ता, खोजने योग्य PDFs में परिवर्तित करें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP, आदि) को PHP में PDF प्रारूप में परिवर्तित करने से कई लाभ मिलते हैं, जिसमें विभिन्न उपकरणों में संगतता और प्रस्तुति की लेआउट एवं स्वरूपण को संरक्षित करना शामिल है। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित करें, छवि गुणवत्ता को नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स को शामिल करें, PDF फ़ाइलों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, विशिष्ट स्लाइड्स का चयन करें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्न प्रारूपों की प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में परिवर्तित करने के लिए फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास में एक तर्क के रूप में पास करें और फिर `save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास `save` मेथड को उजागर करता है जिसे आमतौर पर प्रस्तुति को PDF में परिवर्तित करने के लिए उपयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब प्रस्तुति को PDF में परिवर्तित किया जाता है, तो Aspose.Slides एप्लिकेशन फ़ील्ड को "*Aspose.Slides*" से और PDF प्रोड्यूसर फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने का निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको रूपांतरण करने की अनुमति देता है:

* पूरे प्रस्तुतियों को PDF में
* एक प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे उत्पन्न PDF मूल प्रस्तुति के बहुत करीब रहता है। रूपांतरण में तत्व और गुण सटीक रूप से प्रदर्शित होते हैं, जिसमें शामिल हैं:

* छवियां
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट स्वरूपण
* पैराग्राफ स्वरूपण
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में परिवर्तित करें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में परिवर्तित करने का प्रयास करता है।

यह कोड दिखाता है कि प्रस्तुति (PPT, PPTX, ODP, आदि) को PDF में कैसे परिवर्तित किया जाए:

```php
# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("PowerPoint.pptx");
try {
    # प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस रूपांतरक के साथ एक परीक्षण चला सकते हैं ताकि यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन देखा जा सके।

{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ परिवर्तित करें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PdfOptions) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है, जिनसे आप परिणामी PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या यह निर्दिष्ट कर सकते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ परिवर्तित करें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग परिभाषित कर सकते हैं, मेटा‑फ़ाइलों को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर, छवियों के लिए DPI आदि निर्धारित कर सकते हैं।

```php
# PdfOptions क्लास को इनस्टैंशिएट करें।
$pdfOptions = new PdfOptions();

# JPG छवियों के लिए गुणवत्ता सेट करें।
$pdfOptions->setJpegQuality(90);

# छवियों के लिए DPI सेट करें।
$pdfOptions->setSufficientResolution(300);

# मेटा‑फ़ाइलों के व्यवहार को सेट करें।
$pdfOptions->setSaveMetafilesAsPng(true);

# टेक्स्ट सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें।
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# PDF अनुपालन मोड को परिभाषित करें।
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("PowerPoint.pptx");
try {
    # प्रेज़ेंटेशन को PDF दस्तावेज़ के रूप में सहेजें।
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint को PDF में छिपी स्लाइड्स के साथ परिवर्तित करें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड का उपयोग करके छिपी स्लाइड्स को उत्पन्न PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

```php
# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions क्लास को इनस्टैंशिएट करें।
    $pdfOptions = new PdfOptions();

    # छिपी स्लाइड्स जोड़ें।
    $pdfOptions->setShowHiddenSlides(true);

    # प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint को पासवर्ड‑सुरक्षित PDF में परिवर्तित करें**

यह कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/) क्लास के प्रोटेक्शन पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑सुरक्षित PDF में कैसे परिवर्तित किया जाए:

```php
# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions क्लास को इनस्टैंशिएट करें।
    $pdfOptions = new PdfOptions();

    # PDF पासवर्ड और एक्सेस अनुमतियों को सेट करें।
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setWarningCallback) मेथड प्रदान करता है, जो आपको प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाने की सुविधा देता है।

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// PDF विकल्पों में चेतावनी कॉलबैक सेट करें।
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("sample.pptx");
try {
    // प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें: [Font Substitution](/slides/hi/php-java/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint में विशिष्ट स्लाइड्स को PDF में परिवर्तित करें**

यह कोड दिखाता है कि PowerPoint प्रस्तुति से केवल विशिष्ट स्लाइड्स को PDF में कैसे परिवर्तित किया जाए:

```php
# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("PowerPoint.pptx");
try {
    # स्लाइड संख्याओं की सरणी सेट करें।
    $slides = array(1, 3);

    # प्रेज़ेंटेशन को PDF के रूप में सहेजें।
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में परिवर्तित करें**

यह कोड दिखाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("SelectedSlides.pptx");

# समायोजित स्लाइड आकार के साथ नई प्रेज़ेंटेशन बनाएं।
$resizedPresentation = new Presentation();

try {
    # कस्टम स्लाइड आकार सेट करें।
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # मूल प्रेज़ेंटेशन से पहली स्लाइड को क्लोन करें।
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # रिसाइज़्ड प्रेज़ेंटेशन को नोट्स सहित PDF में सहेजें।
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में परिवर्तित करें**

यह कोड दिखाता है कि नोट्स सहित एक PDF बनाने के लिए PowerPoint प्रस्तुति को कैसे परिवर्तित किया जाए:

```php
# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # नोट्स लेआउट के साथ PDF विकल्पों को कॉन्फ़िगर करें।
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # प्रेज़ेंटेशन को नोट्स के साथ PDF में सहेजें।
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक ऐसी रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDF उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides PDF रूपांतरण ऑपरेशनों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष स्वरूपों—[PDF to SVG](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/php-java/conversion/pdf-to-xml/)—के लिए भी समर्थन उपलब्ध है।

{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एक ही आकृति के रूप में माना जाता है। व्यक्तिगत पाथ तत्वों को अलग‑अलग सामग्री के रूप में नहीं रखा जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक पाठ केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक साथ कई PowerPoint फ़ाइलों को PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच में PDF में बदलने का समर्थन करता है। आप प्रोग्रामेटिक रूप से फ़ाइलों पर इटररेट करके रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित किया जा सकता है?**

बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियाँ निर्धारित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**PDF में छिपी स्लाइड्स को कैसे शामिल किया जाए?**

छुपी स्लाइड्स को परिणामस्वरूप PDF में शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/) क्लास की `setShowHiddenSlides` मेथड का उपयोग कर सकते हैं।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप `setJpegQuality` और `setSufficientResolution` जैसी मेथडों का उपयोग करके PDF में छवियों की उच्च गुणवत्ता को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**

हाँ, Aspose.Slides विभिन्न मानकों—PDF/A1a, PDF/A1b, और PDF/UA—के अनुरूप PDF निर्यात करने की सुविधा देता है, जिससे आपके दस्तावेज़ अभिगम्यता और संग्रहण आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for PHP via Java Documentation](/slides/hi/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/hi/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)