---
title: PPT और PPTX को .NET में PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint को PDF में
type: docs
weight: 40
url: /hi/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- PowerPoint को PDF में
- प्रस्तुति को PDF में
- PPT को PDF में
- PPT को PDF में बदलें
- PPTX को PDF में
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- अटैचमेंट
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ C# कोड उदाहरणों और उन्नत रूपांतरण विकल्पों सहित।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP, आदि) को C# में PDF फ़ॉर्मेट में परिवर्तित करने के कई लाभ होते हैं, जिनमें विभिन्न उपकरणों के बीच संगतता और आपके प्रेजेंटेशन की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित करें, छवि गुणवत्ता नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड‑प्रोटेक्ट करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, विशिष्ट स्लाइड्स का चयन करके रूपांतरण करें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित फ़ॉर्मेट की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रेजेंटेशन को PDF में परिवर्तित करने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास के आर्ग्युमेंट के रूप में पास करें और फिर [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड का उपयोग करके प्रेजेंटेशन को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास वह [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड प्रदान करता है जिसे सामान्यतः प्रेजेंटेशन को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण नंबर डालता है। उदाहरण के लिए, जब एक प्रेजेंटेशन को PDF में बदला जाता है, तो Aspose.Slides *Application* फ़ील्ड को "*Aspose.Slides*" और *PDF Producer* फ़ील्ड को "*Aspose.Slides v XX.XX*" के रूप में भरता है। **Note** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने का निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूप में रूपांतरण करने की अनुमति देता है:

* पूरे प्रेजेंटेशन को PDF में
* प्रेजेंटेशन से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे निकाले गए PDF मूल प्रस्तुति के बहुत करीब होते हैं। रूपांतरण के दौरान तत्व और गुण ठीक से रेंडर किए जाते हैं, जिसमें शामिल हैं:

* छवियां
* टेक्स्ट बॉक्स और आकृतियां
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides अधिकतम गुणवत्ता स्तर पर उपयुक्त सेटिंग्स के साथ प्रदान किए गए प्रेजेंटेशन को PDF में बदलने का प्रयास करता है।

निम्न उदाहरण एक प्रेजेंटेशन लोड करता है और सभी दृश्यमान स्लाइड्स को डिफ़ॉल्ट एक्सपोर्ट सेटिंग्स के साथ PDF में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कन्वर्टर के साथ एक परीक्षण चला सकते हैं ताकि यहाँ वर्णित प्रक्रिया को वास्तविक समय में देखा जा सके।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रोपर्टीज़—प्रदान करता है, जिससे आप निर्मित PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से सुरक्षित कर सकते हैं, या रूपांतरण प्रक्रिया के कार्य प्रवाह को निर्धारित कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग, मेटा‑फ़ाइलों के हैंडलिंग, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI आदि परिभाषित कर सकते हैं।

निम्न उदाहरण एक प्रेजेंटेशन को PDF 1.5 के साथ निर्यात करता है जिसमें JPEG गुणवत्ता 90, छवि रिज़ॉल्यूशन 300 DPI, मेटा‑फ़ाइलें PNG के रूप में सहेजी जाती हैं, और Flate टेक्स्ट संपीड़न लागू होता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट के रूप में संरक्षित रखें**

यदि प्रेजेंटेशन में एंबेडेड Excel वर्कबुक है, तो आप PDF प्राप्तकर्ताओं को वर्कबुक डेटा तक पहुँच प्रदान कर सकते हैं साथ ही स्लाइड्स देख सकते हैं। निर्मित PDF में एंबेडेड OLE फ़ाइलों को अटैचमेंट के रूप में संरक्षित रखने के लिए [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) को `true` सेट करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पृष्ठ पर रेंडर होती है, लेकिन उसकी एंबेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। इसे `true` करने से फ़ाइल डेटा भी अटैचमेंट में शामिल हो जाता है। प्रीव्यू केवल दृश्य प्रतिनिधित्व रहता है; अटैचमेंट प्राप्तकर्ता को एंबेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पृष्ठ पर इंटरैक्टिव Excel शीट नहीं बन जाता।

निम्न उदाहरण एक एंबेडेड Excel वर्कबुक वाला प्रेजेंटेशन लोड करता है और उसे वर्कबुक अटैचमेंट के साथ PDF में निर्यात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

परिणाम जाँचने के लिए:

1. PDF को ऐसे व्यूअर में खोलें जो फ़ाइल अटैचमेंट को सपोर्ट करता हो, जैसे Adobe Acrobat Reader।
2. व्यूअर की **Attachments** पैनल खोलें और एंबेडेड वर्कबुक को खोजें।
3. अटैचमेंट को सहेजें और Excel में खोलकर डेटा जाँचें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू अटैचमेंट से अलग रहती है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A-1 एंबेडेड फ़ाइलों को निषेध करता है, PDF/A-2 केवल PDF/A अटैचमेंट की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जिनमें Excel वर्कबुक भी शामिल हैं, को अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides की विशिष्ट प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दर्शाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रेजेंटेशन में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी का उपयोग करके छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

निम्न उदाहरण एक प्रेजेंटेशन को PDF में निर्यात करता है, जिसमें सभी छिपी स्लाइड्स भी शामिल होती हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **पासवर्ड‑प्रोटेक्टेड PDF के साथ PowerPoint को बदलें**

निम्न उदाहरण एक प्रेजेंटेशन को ऐसे PDF में निर्यात करता है जिसे खोलने के लिए पासवर्ड `password` आवश्यक है। एक्सेस परमिशन प्रिंटिंग की अनुमति देते हैं, जिसमें हाई‑क्वालिटी प्रिंटिंग भी शामिल है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के तहत [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) प्रॉपर्टी प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

निम्न उदाहरण एक प्रेजेंटेशन को PDF में निर्यात करता है और कंसोल पर फ़ॉन्ट प्रतिस्थापन वार्निंग प्रिंट करता है। वार्निंग केवल तब प्रिंट होती है जब निर्यात के दौरान कोई अनुपलब्ध फ़ॉन्ट प्रतिस्थापित किया जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/net/font-substitution/) लेख।
{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

निम्न उदाहरण प्रेजेंटेशन से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर 1‑आधारित होते हैं, और इनपुट प्रेजेंटेशन में कम से कम तीन स्लाइड्स होनी चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

निम्न उदाहरण पहले स्लाइड को 612 × 792 पॉइंट (8.5 × 11 इंच) की स्लाइड साइज वाले नए प्रेजेंटेशन में कॉपी करता है, स्लाइड कंटेंट को स्केल करके फिट करता है, और एकल स्लाइड को PDF में निर्यात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **नोट्स स्लाइड व्यू में PDF के साथ PowerPoint को बदलें**

निम्न उदाहरण एक प्रेजेंटेशन को PDF में निर्यात करता है, जहाँ प्रत्येक स्लाइड के नीचे स्पीकर नोट्स रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रेजेंटेशन का उपयोग करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF के लिए पहुँच और अनुपालन मानक**

Aspose.Slides आपको ऐसा रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [वेब कंटेंट एक्सेसिबिलिटी गाइडलाइन्स (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं, जिसमें ये अनुपालन मानक समर्थित हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C# कोड कई PDFs उत्पन्न करता है, जो विभिन्न अनुपालन मानकों के आधार पर हैं:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="Note" %}}
Aspose.Slides PDF रूपांतरण कार्यों को सपोर्ट करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ॉर्मेट में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष फ़ॉर्मेट—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **Note:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides स्मार्टआर्ट, चार्ट, और फ़ॉर्मूले जैसी जटिल ग्राफ़िक्स को एकल फ़िगर के रूप में ट्रीट करता है। व्यक्तिगत पाथ एलिमेंट अलग कंटेंट के रूप में संरक्षित नहीं होते और उन्हें आर्टिफ़ैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी फ़िगर के लिए प्रदान किया जाता है।

## **FAQ**

**क्या मैं एक साथ कई PowerPoint फ़ाइलों को PDF में बैच में बदल सकता हूँ?**

हां, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण को सपोर्ट करता है। आप प्रोग्रामmatically अपने फ़ाइलों को इटररेट करके रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या बदले गए PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**

हां। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस परमिशन परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के भीतर [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी को `true` सेट करें ताकि छिपी स्लाइड्स परिणामी PDF में शामिल हो जाएँ।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हां, आप [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) और [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) जैसी प्रॉपर्टीज़ को [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास में सेट करके अपने PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**

हां, Aspose.Slides आपको PDF निर्यात करने की अनुमति देता है जो विभिन्न मानकों—PDF/A1a, PDF/A1b, और PDF/UA—के अनुरूप होते हैं, जिससे आपके दस्तावेज़ पहुँच और अभिलेखीय आवश्यकताओं को पूरा किया जाता है।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET Documentation](/slides/hi/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)