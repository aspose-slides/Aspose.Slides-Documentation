---
title: PHP में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- PowerPoint से PDF
- प्रेजेंटेशन से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- संलग्नक
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, खोजने योग्य PDF में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP, आदि) को PHP में PDF प्रारूप में बदलना कई लाभ प्रदान करता है, जिसमें विभिन्न उपकरणों के बीच संगतता और आपकी प्रस्तुति की लेआउट और स्वरूपण को बनाए रखना शामिल है। यह गाइड दर्शाता है कि कैसे प्रस्तुतियों को PDF दस्तावेज़ों में बदलें, छवि गुणवत्ता को नियंत्रित करने के विभिन्न विकल्प प्रयोग करें, छिपी स्लाइड्स को शामिल करें, PDF फ़ाइलों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, बदलने के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित स्वरूपों में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को एक तर्क के रूप में [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास में पास करें और फिर एक [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास वह [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) मेथड प्रदान करती है जिसे आम तौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब एक प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में मान से भर देता है। **नोट** कि आप Aspose.Slides को इस जानकारी को आउटपुट दस्तावेज़ों से बदलने या हटाने के लिए निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूप में बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* एक प्रस्तुति की विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि बनते PDF मूल प्रस्तुतियों के बहुत करीब हों। परिवर्तन में तत्वों और गुणों को सटीक रूप से रेंडर किया जाता है, जिसमें शामिल हैं:

* छवियां
* टेक्स्ट बॉक्स और आकार
* टेक्ट्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट्स
* टेबल्स

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स का उपयोग करके PDF में बदलने का प्रयास करता है।

निम्नलिखित उदाहरण एक प्रस्तुति लोड करता है और डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके सभी दिखाई देने वाली स्लाइड्स को PDF में सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कनवर्टर**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कनवर्टर के साथ एक परीक्षण चलाकर यहाँ वर्णित प्रक्रिया को वास्तविक रूप में देख सकते हैं।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है जो आपको परिणामस्वरूप PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या यह निर्दिष्ट करने की अनुमति देता है कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर इमेजेज़ के लिए अपनी प्राथमिक गुणवत्ता सेटिंग निर्धारित कर सकते हैं, यह निर्दिष्ट कर सकते हैं कि मेटाफाइल्स को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, इमेजेज़ की DPI कॉन्फ़िगर कर सकते हैं, और भी बहुत कुछ।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF 1.5 में निर्यात करता है जिसमें JPEG गुणवत्ता 90 पर सेट है, इमेज रिज़ॉल्यूशन 300 DPI पर सेट है, मेटाफाइल्स PNG के रूप में सहेजे गए हैं, और Flate टेक्स्ट संपीड़न लागू है।

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **एम्बेडेड OLE फ़ाइलों को PDF अटेचमेंट्स के रूप में संरक्षित रखें**

यदि किसी प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप चाह सकते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा एक्सेस कर सकें और साथ ही स्लाइड्स देख सकें। परिणामस्वरूप PDF में एम्बेडेड OLE फ़ाइलों को अटेचमेंट्स के रूप में संरक्षित रखने के लिए [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) को `true` के साथ कॉल करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पेज पर रेंडर होती है, लेकिन उसकी एम्बेडेड फ़ाइल अटेचमेंट के रूप में शामिल नहीं होती। विकल्प को `true` सेट करने से फ़ाइल डेटा भी शामिल हो जाएगा। प्रीव्यू एक दृश्य प्रतिनिधित्व बना रहता है; अटेचमेंट प्राप्तकर्ताओं को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पेज पर एक इंटरैक्टिव Excel वर्कशीट नहीं बनता।

निम्नलिखित उदाहरण एक प्रस्तुति लोड करता है जिसमें पहले से एक एम्बेडेड Excel वर्कबुक शामिल है और वर्कबुक को अटेचमेंट के रूप में PDF में निर्यात करता है।

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

परिणाम जांचने के लिए:

1. Adobe Acrobat Reader जैसे फ़ाइल अटेचमेंट्स को समर्थन करने वाले व्यूअर में निर्यात किया गया PDF खोलें।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक खोजें।
3. अटेचमेंट को सहेजें और डेटा निरीक्षण के लिए Excel में खोलें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू अटेचमेंट से अलग होता है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटेचमेंट्स पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A अटेचमेंट्स की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों की अनुमति देता है, जिसमें Excel वर्कबुक भी शामिल हैं। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides के लिए विशेष प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दिखाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप परिणामस्वरूप PDF में छिपी स्लाइड्स को पेज के रूप में शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड का उपयोग कर सकते हैं।

निम्नलिखित उदाहरण छिपी स्लाइड्स को शामिल करते हुए प्रस्तुति को PDF में निर्यात करता है।

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **पासवर्ड-संरक्षित PDF में PowerPoint को बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति को ऐसे PDF में निर्यात करता है जिसके खोलने के लिए पासवर्ड `password` आवश्यक है। एक्सेस अनुमति प्रिंटिंग की अनुमति देती हैं, जिसमें हाई‑क्वालिटी प्रिंटिंग भी शामिल है।

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) मेथड प्रदान करता है, जो आपको प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाने में सक्षम बनाता है।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। चेतावनी केवल तभी प्रिंट होती है जब निर्यात के दौरान कोई अनुपलब्ध फ़ॉन्ट प्रतिस्थापित किया जाता है।

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/php-java/font-substitution/) लेख।
{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर 1‑आधारित हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड्स होनी चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति से पहली स्लाइड को 612 × 792 पॉइंट्स (8.5 × 11 इंच) के स्लाइड आकार वाली नई प्रस्तुति में कॉपी करता है। यह स्लाइड सामग्री को फिट करने के लिए स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // नई प्रस्तुति में निर्मित खाली स्लाइड को हटाएँ।
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, जहाँ प्रत्येक स्लाइड के स्पीकर नोट्स स्लाइड के नीचे रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF के लिये सुलभता और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया का उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड एक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है जो विभिन्न अनुपालन मानकों के आधार पर कई PDF बनाता है:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides PDF रूपांतरण संचालन को समर्थन देता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF से image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य PDF रूपांतरण संचालन विशेष स्वरूपों में—[PDF से SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **नोट:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ एलिमेंट्स को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफ़ैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलें एक साथ PDF में बदल सकता हूँ?**  
हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर क्रमशः प्रक्रिया लागू करके प्रोग्रामेटिक रूप से रूपांतरण कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड से सुरक्षित करना संभव है?**  
हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**  
[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास में `true` के साथ [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) को कॉल करके परिणामस्वरूप PDF में छिपी स्लाइड्स को शामिल करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**  
हाँ, आप छवि गुणवत्ता को नियंत्रित कर सकते हैं जैसे कि [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) और [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) मेथड्स का उपयोग करके, जिससे आपके PDF में उच्च‑गुणवत्ता वाली छवियाँ सुनिश्चित हों।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**  
हाँ, Aspose.Slides आपको ऐसे PDF निर्यात करने की अनुमति देता है जो [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) के अनुरूप हों, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ सुलभता और अभिलेखन आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for PHP via Java प्रलेखन](/slides/hi/php-java/)
- [Aspose.Slides for PHP via Java API संदर्भ](https://reference.aspose.com/slides/php-java/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/conversion)