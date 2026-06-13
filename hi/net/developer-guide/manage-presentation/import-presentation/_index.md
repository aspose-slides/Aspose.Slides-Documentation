---
title: PDF या HTML से .NET में प्रस्तुतियों का आयात
linktitle: प्रस्तुति आयात
type: docs
weight: 60
url: /hi/net/import-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides के साथ .NET में PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में आसानी से आयात करें, जिससे सहज और उच्च-प्रदर्शन स्लाइड प्रोसेसिंग संभव हो।"
---
## **परिचय**

Aspose.Slides का उपयोग करके आप अन्य प्रारूपों की फ़ाइलों से प्रस्तुतियाँ आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/) क्लास प्रदान करता है, जो PDF और HTML दस्तावेज़ों से प्रस्तुतियों को आयात करने की अनुमति देता है।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप PDF को PowerPoint प्रस्तुति में रूपांतरित कर सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ। 
2. [AddFromPdf](https://reference.aspose.com/slides/hi/net/aspose.slides.slidecollection/addfrompdf/methods/1) मेथड को कॉल करें और PDF फ़ाइल पास करें। 
3. फ़ाइल को PowerPoint प्रारूप में सहेजने के लिए [Save](https://reference.aspose.com/slides/hi/net/aspose.slides.presentation/save/methods/5) मेथड का उपयोग करें।

यह C# कोड PDF से PowerPoint परिवर्तन को दर्शाता है:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 

आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब एप्लिकेशन देख सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन है। 

{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप एक HTML दस्तावेज़ को PowerPoint प्रस्तुति में रूपांतरित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ। 
2. [AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) मेथड को कॉल करें और HTML फ़ाइल पास करें। 
3. फ़ाइल को PowerPoint दस्तावेज़ के रूप में सहेजने के लिए [Save](https://apireference.aspose.com/slides/hi/net/aspose.slides.presentation/save/methods/5) मेथड का उपयोग करें।

यह C# कोड HTML से PowerPoint परिवर्तन को दर्शाता है: 

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **प्रश्नोत्तर**

**क्या PDF आयात करते समय तालिकाओं को संरक्षित किया जाता है, और क्या उनकी पहचान में सुधार किया जा सकता है?**

आयात के दौरान तालिकाओं का पता लगाया जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.import/pdfimportoptions/) में [DetectTables](https://reference.aspose.com/slides/hi/net/aspose.slides.import/pdfimportoptions/detecttables/) पैरामीटर शामिल है जो तालिका पहचान सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।

{{% alert title="Note" color="warning" %}} 

आप Aspose.Slides का उपयोग करके HTML को अन्य लोकप्रिय फ़ाइल स्वरूपों में भी रूपांतरित कर सकते हैं: 

* [HTML से चित्र](https://products.aspose.com/slides/hi/net/conversion/html-to-image/)
* [HTML से JPG](https://products.aspose.com/slides/hi/net/conversion/html-to-jpg/)
* [HTML से XML](https://products.aspose.com/slides/hi/net/conversion/html-to-xml/)
* [HTML से TIFF](https://products.aspose.com/slides/hi/net/conversion/html-to-tiff/)

{{% /alert %}}