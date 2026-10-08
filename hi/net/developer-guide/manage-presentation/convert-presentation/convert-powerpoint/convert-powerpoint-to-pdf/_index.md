---
title: .NET में PPT और PPTX को PDF में रूपांतरित करें [उन्नत सुविधाएँ सम्मिलित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- PowerPoint से PDF
- प्रस्तुति से PDF
- PPT से PDF
- PPT को PDF में परिवर्तित करें
- PPTX से PDF
- PPTX को PDF में परिवर्तित करें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- संलग्नक
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोजयोग्य PDFs में रूपांतरित करें, तेज़ C# कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **परिचय**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को C# में PDF प्रारूप में परिवर्तित करने से कई लाभ मिलते हैं, जिनमें विभिन्न उपकरणों में संगतता और आपके प्रस्तुतिकरण का लेआउट एवं स्वरूप बनाए रखना शामिल है। यह गाइड दिखाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित करें, इमेज गुणवत्ता नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपे हुए स्लाइड शामिल करें, PDF फ़ाइलों को पासवर्ड‑प्रोटेक्ट करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, विशिष्ट स्लाइड चयनित करके परिवर्तन करें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint को PDF में रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्न स्वरूपों में प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुतिकरण को PDF में परिवर्तित करने के लिए, फ़ाइल नाम को [प्रेजेंटेशन](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास के तर्क के रूप में पास करें और फिर [सेव](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) विधि का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [प्रेजेंटेशन](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास [सेव](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) विधि प्रदान करता है जिसे आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या सम्मिलित करता है। उदाहरण के तौर पर, जब एक प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप आउटपुट दस्तावेज़ों से इस जानकारी को बदल या हटाने के लिए Aspose.Slides को निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्न विकल्पों के साथ परिवर्तन करने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में बदलना
* प्रस्तुति से विशिष्ट स्लाइड को PDF में बदलना

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे उत्पन्न PDFs मूल प्रस्तुतियों के करीब होते हैं। परिवर्तन के दौरान तत्व और विशेषताएँ सटीक रूप से रेंडर की जाती हैं, जिसमें शामिल हैं:

* इमेज
* टेक्स्ट बॉक्स और शेप
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* टेबल

## **PowerPoint को PDF में बदलें**

डिफ़ॉल्ट विकल्पों के साथ मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया उपयोग की जाती है। इस स्थिति में, Aspose.Slides अधिकतम गुणवत्ता स्तर पर अनुकूल सेटिंग्स के साथ प्रदान की गई प्रस्तुति को PDF में बदलने का प्रयास करता है।

निम्न उदाहरण एक प्रस्तुति को लोड करता है और डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके सभी दृश्यमान स्लाइड को PDF में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose एक मुफ्त ऑनलाइन [PowerPoint से PDF रूपांतरणकर्ता](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस रूपांतरणकर्ता के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का वास्तविक कार्यान्वयन देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में रूपांतरण**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के तहत कस्टम विकल्प—गुण—पेश करता है, जिससे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, PDF पर पासवर्ड लगा सकते हैं, या रूपांतरण प्रक्रिया के प्रवाह को निर्धारित कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में रूपांतरण**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रैस्टर इमेज के लिए वांछित गुणवत्ता सेटिंग, मेटा‑फ़ाइल प्रोसेसिंग, टेक्स्ट के लिए संपीड़न स्तर, इमेज DPI आदि निर्दिष्ट कर सकते हैं।

निम्न उदाहरण प्रस्तुति को PDF 1.5 में निर्यात करता है, जहाँ JPEG गुणवत्ता 90, इमेज रिज़ॉल्यूशन 300 DPI, मेटा‑फ़ाइल PNG के रूप में सहेजी गईं, और Flate टेक्स्ट संपीड़न लागू किया गया है।

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

### **एम्बेडेड OLE फ़ाइलों को PDF संलग्नक के रूप में बनाए रखें**

यदि एक प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप PDF प्राप्तकर्ताओं को वर्कबुक का डेटा भी उपलब्ध कराना चाह सकते हैं। [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) को `true` पर सेट करके एम्बेडेड OLE फ़ाइलों को परिणामस्वरूप PDF में संलग्नक के रूप में रखा जाता है।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पृष्ठ पर रेंडर होती है, परंतु एम्बेडेड फ़ाइल संलग्नक के रूप में शामिल नहीं होती। इसे `true` पर सेट करने से फ़ाइल डेटा भी शामिल हो जाता है। प्रीव्यू केवल एक दृश्य प्रतिनिधित्व रहता है; संलग्नक प्राप्तकर्ता को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने देता है। OLE ऑब्जेक्ट PDF पृष्ठ पर इंटरैक्टिव Excel शीट नहीं बन जाता।

निम्न उदाहरण एक ऐसी प्रस्तुति को लोड करता है जिसमें पहले से एम्बेडेड Excel वर्कबुक है और इसे वर्कबुक संलग्नक के साथ PDF में निर्यात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

परिणाम की जांच करने के लिए:

1. फ़ाइल संलग्नक को सपोर्ट करने वाले व्यूअर (जैसे Adobe Acrobat Reader) में निर्यातित PDF खोलें।
2. व्यूअर की **Attachments** पैनल खोलें और एम्बेडेड वर्कबुक खोजें।
3. संलग्नक को सहेजें और Excel में खोलकर डेटा जाँचें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पृष्ठ पर प्रीव्यू संलग्नक से अलग रहता है।

{{% alert color="info" title="Note" %}}

PDF/A मानक संलग्नकों पर प्रतिबंध लगाते हैं: PDF/A‑1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A‑2 केवल PDF/A संलग्नकों की अनुमति देता है, और PDF/A‑3 अन्य फ़ाइल प्रकारों, जिसमें Excel वर्कबुक शामिल हैं, को अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides की विशिष्ट सीमाएँ नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात को नहीं दर्शाता।

{{% /alert %}}

### **छिपे हुए स्लाइड के साथ PowerPoint को PDF में रूपांतरण**

यदि प्रस्तुति में छिपे हुए स्लाइड हैं, तो आप [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) गुण को [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास से `true` पर सेट करके उत्पन्न PDF में छिपे हुए स्लाइड को पृष्ठों के रूप में शामिल कर सकते हैं।

निम्न उदाहरण छिपे हुए स्लाइड को भी शामिल करते हुए प्रस्तुति को PDF में निर्यात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **पासवर्ड‑प्रोटेक्टेड PDF के साथ PowerPoint को रूपांतरण**

निम्न उदाहरण प्रस्तुति को एक ऐसे PDF में निर्यात करता है जिसे खोलने के लिए पासवर्ड `password` की आवश्यकता होती है। एक्सेस अनुमति में प्रिंटिंग, जिसमें हाई‑क्वालिटी प्रिंटिंग भी शामिल है, सक्षम है।

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

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के तहत [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) गुण प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

निम्न उदाहरण प्रस्तुति को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। केवल तब चेतावनी प्रदर्शित होती है जब निर्यात के दौरान अनुपलब्ध फ़ॉन्ट का प्रतिस्थापन किया जाता है।

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

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) लेख देखें।

{{% /alert %}} 

### **समर्पित बोल्ड टाइपफ़ेस न होने वाले फ़ॉन्ट को संभालें**

एक प्रस्तुति टेक्स्ट पर बोल्ड फ़ॉर्मेट लागू कर सकती है भले ही उसके फ़ॉन्ट में समर्पित बोल्ड टाइपफ़ेस न हो। टेक्स्ट फिर भी सिंथेटिक बोल्डिंग के द्वारा दिख सकता है, जो नियमित ग्लिफ़ को कृत्रिम रूप से मोटा करता है। जब यह टेक्स्ट PDF में बहुत भारी या अपेक्षित रूप से अलग दिखता है, तो [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) को `true` पर सेट करने का प्रयास करें। यह विकल्प PDF निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप के रूप में रेंडर करता है और कुछ फ़ॉन्ट के लिए इसकी उपस्थिति में सुधार कर सकता है। इसका डिफ़ॉल्ट मान `false` है।

नमूना प्रस्तुति में दो टेक्स्ट बॉक्स हैं: एक सामान्य टेक्स्ट के साथ और दूसरा उसी फ़ॉन्ट में बोल्ड फ़ॉर्मेट के साथ, जिसके पास समर्पित बोल्ड टाइपफ़ेस नहीं है। निम्न उदाहरण प्रस्तुति को लोड करता है, असमर्थित फ़ॉन्ट शैलियों की रास्टराइज़ेशन सक्षम करता है, और इसे PDF में निर्यात करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

निम्न प्रीव्यू में अक्षम आउटपुट और सक्षम आउटपुट दिखाया गया है। इस उदाहरण में, विकल्प अक्षम होने पर बोल्ड टेक्स्ट में मोटी स्ट्रोक होती हैं। विकल्प सक्षम होने पर स्ट्रोक पतली हो जाती है; सामान्य टेक्स्ट अपरिवर्तित रहता है। अपने प्रस्तुति की सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प बंद (`false`, डिफ़ॉल्ट) | विकल्प चालू (`true`) |
|---|---|
| ![असमर्थित फ़ॉन्ट शैली रास्टराइजेशन अक्षम PDF](unsupported-bold-disabled.png) | ![असमर्थित फ़ॉन्ट शैली रास्टराइजेशन सक्षम PDF](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प सक्षम करने से केवल बोल्ड टेक्स्ट बिटमैप में बदल जाता है: इसे बिना OCR के चयन, कॉपी या टेक्स्ट रूप में खोजा नहीं जा सकता, और 800 % ज़ूम पर किनारे हल्के दिखते हैं। सामान्य टेक्स्ट खोज योग्य बना रहता है। विकल्प अक्षम होने पर दोनों स्ट्रिंग्स टेक्स्ट ही रहती हैं।

यह विकल्प उन फ़ॉन्टों के लिए टेक्स्ट को रास्टराइज़ करता है जिनमें समर्पित बोल्ड टाइपफ़ेस नहीं होता। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) के बजाय मूल फ़ॉन्ट उपलब्ध न होने पर दूसरा फ़ॉन्ट चुना जाता है।

## **PowerPoint से PDF में चयनित स्लाइड्स को निर्यात करें**

निम्न उदाहरण प्रस्तुति से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर 1‑आधारित होते हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड होंनी चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में निर्यात करें**

निम्न उदाहरण पहले स्लाइड को 612 × 792 पॉइंट (8.5 × 11 इंच) आकार के साथ नई प्रस्तुति में कॉपी करता है, स्लाइड सामग्री को फिट करने के लिए स्केल करता है, और एकल स्लाइड को PDF में निर्यात करता है।

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

// नई प्रस्तुति के साथ बनाई गई खाली स्लाइड को हटाएँ।
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में निरूपित करें**

निम्न उदाहरण प्रस्तुति को PDF में निर्यात करता है, जहाँ प्रत्येक स्लाइड के नीचे उसके स्पीकर नोट्स रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति उपयोग करें।

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

## **PDF के लिए पहुँचयोग्यता और अनुपालन मानक**

Aspose.Slides आपको ऐसी रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [वेब सामग्री एक्सेसिबिलिटी गाइडलाइन्स (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के साथ संगत हो। आप PowerPoint दस्तावेज़ को निम्नलिखित अनुपालन मानकों में से किसी एक के साथ PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C# कोड विभिन्न अनुपालन मानकों पर आधारित कई PDFs उत्पन्न करने की प्रक्रिया दर्शाता है:

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

Aspose.Slides PDF रूपांतरण कार्यों को समर्थन देता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ॉर्मेट में परिवर्तित कर सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF से इमेज](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष फ़ॉर्मेट—जैसे [PDF से SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **नोट:** PDF/UA निर्यात के दौरान, Aspose.Slides SmartArt, चार्ट और फ़ॉर्मूला जैसी जटिल ग्राफ़िक्स को एकल आकृति के रूप में प्रोसेस करता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में नहीं रखा जाता और उन्हें आर्टिफ़ैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल संपूर्ण आकृति के लिए उपलब्ध कराया जाता है।

## **FAQ**

**क्या मैं कई PowerPoint फ़ाइलें एक साथ PDF में बदल सकता हूँ?**

हां, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों के माध्यम से इटररेट करके प्रोग्रामेटिक रूप से परिवर्तन प्रक्रिया लागू कर सकते हैं।

**क्या रूपांतरित PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**

हां। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपे हुए स्लाइड कैसे शामिल करूँ?**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास में [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) गुण को `true` पर सेट करके परिणामस्वरूप PDF में छिपे हुए स्लाइड शामिल कर सकते हैं।

**क्या Aspose.Slides PDF में उच्च इमेज गुणवत्ता बना सकता है?**

हां, आप [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) और [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) जैसे गुणों को [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) में सेट करके PDF में उच्च‑गुणवत्ता वाली इमेज सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हां, Aspose.Slides विभिन्न मानकों जैसे PDF/A1a, PDF/A1b, और PDF/UA के साथ संगत PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ पहुँचयोग्यता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET Documentation](/slides/hi/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)