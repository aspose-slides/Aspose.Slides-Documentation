---
title: PHP में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PowerPoint से PDF
- प्रस्तुति से PDF
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
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint PPT/PPTX को उच्च गुणवत्ता, खोजनीय PDFs में बदलें, तेज़ कोड उदाहरण और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **सारांश**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PHP में PDF प्रारूप में बदलने से कई लाभ मिलते हैं, जैसे विभिन्न डिवाइसों में संगतता और आपके प्रस्तुतीकरण की लेआउट और फ़ॉर्मेटिंग को बनाए रखना। यह गाइड बताता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स को शामिल करें, PDF फ़ाइलों को पासवर्ड‑सुरक्षित बनाएं, फ़ॉन्ट प्रतिस्थापन का पता लगाएं, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानक लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित स्वरूपों में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

किसी प्रस्तुतीकरण को PDF में बदलने के लिए फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास में तर्क के रूप में पास करें और फिर [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) मेथड का उपयोग करके प्रस्तुतीकरण को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) मेथड उजागर करता है जो सामान्यतः प्रस्तुतीकरण को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब किसी प्रस्तुतीकरण को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **Note** कि आप आउटपुट दस्तावेज़ों से इस जानकारी को बदल या हटाने के लिए Aspose.Slides को निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको निम्नलिखित बदलने की अनुमति देता है:

* पूर्ण प्रस्तुतियों को PDF में बदलना
* प्रस्तुतीकरण से विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे निर्मित PDF मूल प्रस्तुतियों के बहुत करीब होते हैं। रूपांतरण में तत्व और गुण सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान किए गए प्रस्तुतीकरण को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

निम्नलिखित उदाहरण एक प्रस्तुतीकरण को लोड करता है और सभी दृश्यमान स्लाइड्स को डिफ़ॉल्ट निर्यात सेटिंग्स के साथ PDF में सहेजता है।

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
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कनवर्टर**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुतीकरण‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन करने के लिए इस कनवर्टर के साथ परीक्षण चला सकते हैं।
{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत गुण—प्रदान करता है जिससे आप परिणामी PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या निर्धारित कर सकते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **PowerPoint को कस्टम विकल्पों के साथ PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेट कर सकते हैं, मेटाफाइल्स को कैसे संभालना है निर्धारित कर सकते हैं, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के लिए DPI कॉन्फ़िगर कर सकते हैं, आदि।

निम्नलिखित उदाहरण प्रस्तुतीकरण को PDF 1.5 के साथ JPEG गुणवत्ता 90, छवि रिज़ॉल्यूशन 300 DPI, मेटाफाइल्स को PNG के रूप में सहेजता है, और Flate टेक्स्ट संपीड़न लागू करता है।

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

### **एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट के रूप में संरक्षित रखें**

यदि किसी प्रस्तुतीकरण में एम्बेडेड Excel वर्कबुक है, तो आप चाह सकते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा भी देख सकें। परिणामस्वरूप PDF में एम्बेडेड OLE फ़ाइलों को अटैचमेंट के रूप में संरक्षित करने के लिए `true` के साथ [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) को कॉल करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट का पूर्वावलोकन छवि या आइकन PDF पृष्ठ पर रेंडर होता है, लेकिन उसकी एम्बेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। विकल्प को `true` सेट करने से फ़ाइल डेटा अतिरिक्त रूप से शामिल हो जाता है। पूर्वावलोकन एक दृश्य प्रतिनिधित्व बना रहता है; अटैचमेंट प्राप्तकर्ता को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पृष्ठ पर एक इंटरैक्टिव Excel वर्कशीट में नहीं बदलता।

निम्नलिखित उदाहरण एक प्रस्तुतीकरण लोड करता है जिसमें पहले से एम्बेडेड Excel वर्कबुक है और वर्कबुक को अटैचमेंट के साथ PDF में निर्यात करता है।

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

परिणाम की जाँच करने के लिए:

1. ऐसी व्यूअर में निर्यातित PDF खोलें जो फ़ाइल अटैचमेंट का समर्थन करता हो, जैसे Adobe Acrobat Reader.
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें.
3. अटैचमेंट को सहेजें और डेटा का निरीक्षण करने के लिए Excel में खोलें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पृष्ठ पर पूर्वावलोकन अटैचमेंट से अलग रहता है.

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A अटैचमेंट की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जिसमें Excel वर्कबुक भी शामिल हैं, की अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides के विशिष्ट प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दिखाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि किसी प्रस्तुतीकरण में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) मेथड का उपयोग करके छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुतीकरण को PDF में निर्यात करता है, जिसमें सभी छिपी स्लाइड्स भी शामिल हैं।

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

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

निम्नलिखित उदाहरण एक प्रस्तुतीकरण को ऐसे PDF में निर्यात करता है जिसे खोलने के लिए पासवर्ड `password` आवश्यक है। एक्सेस अनुमतियों में प्रिंटिंग, जिसमें उच्च‑गुणवत्ता प्रिंटिंग शामिल है, सक्षम हैं।

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

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) मेथड प्रदान करता है, जिससे आप प्रस्तुतीकरण‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापनों का पता लगा सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुतीकरण को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। केवल तब चेतावनी प्रदर्शित होती है जब निर्यात के दौरान अनुपलब्ध फ़ॉन्ट को प्रतिस्थापित किया जाता है।

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

### **समर्पित बोल्ड टाइपफ़ेस के बिना फ़ॉन्ट्स को संभालें**

एक प्रस्तुतीकरण समान फ़ॉन्ट पर बोल्ड फ़ॉर्मेटिंग लागू कर सकता है, भले ही उस फ़ॉन्ट का समर्पित बोल्ड टाइपफ़ेस न हो। इस स्थिति में टेक्स्ट सिंथेटिक बोल्डिंग के माध्यम से बोल्ड दिख सकता है, जो नियमित ग्लिफ़ को कृत्रिम रूप से मोटा करता है। जब वह टेक्स्ट PDF में बहुत भारी या इच्छित स्वरूप से अलग दिखे, तो `true` के साथ [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) को कॉल करने का प्रयास करें। यह विकल्प PDF निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप रूप में रेंडर करता है और कुछ फ़ॉन्ट्स के लिए उपस्थिति सुधार सकता है। इसका डिफ़ॉल्ट मान `false` है।

नमूना प्रस्तुतीकरण में दो टेक्स्ट बॉक्स हैं: एक सामान्य टेक्स्ट वाला और दूसरा वही फ़ॉन्ट पर बोल्ड फ़ॉर्मेटिंग वाला, जिसके पास समर्पित बोल्ड टाइपफ़ेस नहीं है। निम्नलिखित उदाहरण प्रस्तुतीकरण को लोड करता है, असमर्थित फ़ॉन्ट शैलियों की रास्टराइज़ेशन सक्षम करता है, और इसे PDF में निर्यात करता है:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

निम्नलिखित प्रीव्यू में अक्षम आउटपुट और सक्षम आउटपुट दिखाए गए हैं। इस उदाहरण में, विकल्प अक्षम होने पर बोल्ड टेक्स्ट की स्ट्रोक मोटी है। विकल्प सक्षम होने पर उसकी स्ट्रोक हल्की होती है; सामान्य टेक्स्ट अपरिवर्तित रहता है। अपने प्रस्तुतीकरण के लिए सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प अक्षम (`false`, डिफ़ॉल्ट) | विकल्प सक्षम (`true`) |
|---|---|
| ![असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन अक्षम PDF](unsupported-bold-disabled.png) | ![समर्थित फ़ॉन्ट शैली रास्टराइज़ेशन सक्षम PDF](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प सक्षम करने से केवल बोल्ड टेक्स्ट बिटमैप में बदल जाता है: यह OCR के बिना चयन, कॉपी या खोज योग्य नहीं रहता, और 800 % ज़ूम पर किनारे नरम दिखते हैं। सामान्य टेक्स्ट फिर भी खोज योग्य रहता है। विकल्प अक्षम होने पर, दोनों स्ट्रिंग्स टेक्स्ट ही रहती हैं।

यह विकल्प उन फ़ॉन्ट्स के लिए टेक्स्ट को रास्टराइज़ करता है जिनमें समर्पित बोल्ड टाइपफ़ेस नहीं है। फ़ॉन्ट प्रतिस्थापन [फ़ॉन्ट प्रतिस्थापन](/slides/hi/php-java/font-substitution/) के बजाय मूल फ़ॉन्ट उपलब्ध न होने पर अन्य फ़ॉन्ट चुनता है।

## **PowerPoint से PDF में चयनित स्लाइड्स बदलें**

निम्नलिखित उदाहरण प्रस्तुतीकरण की स्लाइड्स 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर एक‑आधारित हैं, और इनपुट प्रस्तुतीकरण में कम से कम तीन स्लाइड्स होनी चाहिए।

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

निम्नलिखित उदाहरण पहला स्लाइड एक नए प्रस्तुतीकरण में कॉपी करता है जिसका स्लाइड आकार 612 × 792 पॉइंट (8.5 × 11 इंच) है। यह स्लाइड सामग्री को फिट करने के लिए स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

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

    // नई प्रस्तुति के साथ बनाई गई खाली स्लाइड को हटाएँ।
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

निम्नलिखित उदाहरण एक प्रस्तुतीकरण को PDF में निर्यात करता है, प्रत्येक स्लाइड के नीचे स्पीकर नोट्स रखता है। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुतीकरण का उपयोग करें।

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

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया का उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के साथ अनुपालन करता है। आप किसी PowerPoint दस्तावेज़ को इन मानकों में से किसी एक का उपयोग करके PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया दर्शाता है:

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
Aspose.Slides PDF रूपांतरण संचालन का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF से इमेज](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। विशेष स्वरूपों के लिए अन्य PDF रूपांतरण संचालन—[PDF से SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **नोट:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और सूत्रों को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग कंटेंट के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफ़ैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए उपलब्ध कराया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को बड़ी मात्रा में PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटेरेट कर सकते हैं और प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित बनाया जा सकता है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं कैसे PDF में छिपी स्लाइड्स शामिल करूँ?**

छिपी स्लाइड्स को परिणामी PDF में शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास में `true` के साथ [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) को कॉल करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) और [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) जैसी विधियों का उपयोग करके अपने PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको [विभिन्न मानकों](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) के साथ अनुपालन करने वाले PDF निर्यात करने की अनुमति देता है, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ अभिगम्यता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for PHP via Java दस्तावेज़](/slides/hi/php-java/)
- [Aspose.Slides for PHP via Java API संदर्भ](https://reference.aspose.com/slides/php-java/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/conversion)