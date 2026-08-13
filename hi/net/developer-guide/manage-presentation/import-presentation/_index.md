---
title: ".NET में PDF या HTML से प्रस्तुतियों को आयात करें"
linktitle: "प्रेज़ेंटेशन आयात करें"
type: docs
weight: 60
url: /hi/net/import-presentation/
keywords:
- "प्रेज़ेंटेशन आयात"
- "स्लाइड आयात"
- "PDF आयात"
- "HTML आयात"
- "PDF से प्रेज़ेंटेशन"
- "PDF से PPT"
- "PDF से PPTX"
- "PDF से ODP"
- "HTML से प्रेज़ेंटेशन"
- "HTML से PPT"
- "HTML से PPTX"
- "HTML से ODP"
- "PowerPoint"
- "OpenDocument"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides के साथ .NET में PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में आसानी से आयात करें, जिससे सहज और उच्च-प्रदर्शन वाली स्लाइड प्रोसेसिंग प्राप्त हो।"
---
## **परिचय**

Aspose.Slides का उपयोग करके, आप अन्य फ़ॉर्मेट की फ़ाइलों से प्रस्तुतियों को आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/) क्लास प्रदान करता है, जो आपको PDF और HTML दस्तावेज़ों से प्रस्तुतियों को आयात करने की अनुमति देता है।

## **PDF से PowerPoint आयात**

इस मामले में, आप PDF को PowerPoint प्रस्तुति में बदल सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं। 
2. [AddFromPdf](https://reference.aspose.com/slides/hi/net/aspose.slides.slidecollection/addfrompdf/methods/1) मेथड को कॉल करें और PDF फ़ाइल पास करें। 
3. फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजने के लिए [Save](https://reference.aspose.com/slides/hi/net/aspose.slides.presentation/save/methods/5) मेथड का उपयोग करें।

यह C# कोड PDF से PowerPoint ऑपरेशन को दर्शाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब ऐप को देखना चाह सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन है। 
{{% /alert %}} 

## **HTML से PowerPoint आयात**

इस मामले में, आप एक HTML दस्तावेज़ को PowerPoint प्रस्तुति में बदल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं। 
2. [AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) मेथड को कॉल करें और HTML फ़ाइल पास करें। 
3. फ़ाइल को PowerPoint दस्तावेज़ के रूप में सहेजने के लिए [Save](https://apireference.aspose.com/slides/hi/net/aspose.slides.presentation/save/methods/5) मेथड का उपयोग करें।

यह C# कोड HTML से PowerPoint ऑपरेशन को दर्शाता है: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या PDF आयात के दौरान तालिकाएँ संरक्षित रहती हैं, और उनके पहचान को सुधारना संभव है?

आयात के दौरान तालिकाओं का पता लगाया जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.import/pdfimportoptions/) में एक [DetectTables](https://reference.aspose.com/slides/hi/net/aspose.slides.import/pdfimportoptions/detecttables/) पैरामीटर शामिल है जो तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।

{{% alert title="Note" color="warning" %}} 
आप Aspose.Slides का उपयोग करके HTML को अन्य लोकप्रिय फ़ाइल फ़ॉर्मेट में भी बदल सकते हैं: 

* [HTML to image](https://products.aspose.com/slides/hi/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/hi/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/hi/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/hi/net/conversion/html-to-tiff/)

{{% /alert %}}