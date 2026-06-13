---
title: PHP में PDF या HTML से प्रस्तुतियों का आयात
linktitle: प्रस्तुति आयात
type: docs
weight: 60
url: /hi/php-java/import-presentation/
keywords:
- प्रस्तुति आयात
- स्लाइड आयात
- PDF आयात
- HTML आयात
- PDF से प्रस्तुति
- PDF से PPT
- PDF से PPTX
- PDF से ODP
- HTML से प्रस्तुति
- HTML से PPT
- HTML से PPTX
- HTML से ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides के साथ PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में निरंतर, उच्च-प्रदर्शन स्लाइड प्रोसेसिंग के लिए आयात करें।"
---
## **परिचय**

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/hi/php-java/) का उपयोग करके आप अन्य फ़ॉर्मैट में फ़ाइलों से प्रस्तुतियों को आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) क्लास प्रदान करता है जिससे आप PDF, HTML दस्तावेज आदि से प्रस्तुतियों को आयात कर सकते हैं।

## **PDF से PowerPoint आयात करें**

इस उदाहरण में, आप PDF को PowerPoint प्रस्तुति में परिवर्तित कर सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/) क्लास का उदाहरण बनाएं।
2. [addFromPdf()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) मेथड को कॉल करें और PDF फ़ाइल पास करें।
3. फ़ाइल को PowerPoint फ़ॉर्मैट में सहेजने के लिए [save()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करें।

यह PHP कोड PDF से PowerPoint परिवर्तन को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="Tip" color="primary" %}} 

आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब एप्लिकेशन को देख सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन है। 

{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस उदाहरण में, आप एक HTML दस्तावेज़ को PowerPoint प्रस्तुति में परिवर्तित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/) क्लास का उदाहरण बनाएं।
2. [addFromHtml()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) मेथड को कॉल करें और HTML फ़ाइल पास करें।
3. फ़ाइल को PowerPoint फ़ॉर्मैट में सहेजने के लिए [save()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करें।

यह PHP कोड HTML से PowerPoint परिवर्तन को दर्शाता है:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF आयात करने पर तालिकाएँ संरक्षित रहती हैं, और उनकी पहचान में सुधार किया जा सकता है?**

आयात के दौरान तालिकाओं को पहचाना जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfimportoptions/) में [setDetectTables](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfimportoptions/#setDetectTables) मेथड शामिल है जो तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।

{{% alert title="Note" color="warning" %}} 

आप Aspose.Slides का उपयोग करके HTML को अन्य लोकप्रिय फ़ाइल फ़ॉर्मैट में भी बदल सकते हैं:

* [HTML to image](https://products.aspose.com/slides/hi/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/hi/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/hi/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/hi/php-java/conversion/html-to-tiff/)

{{% /alert %}}