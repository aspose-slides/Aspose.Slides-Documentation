---
title: PPT और PPTX को .NET में PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PowerPoint को PDF में
- प्रस्तुति को PDF में
- PPT को PDF में
- PPT को PDF में बदलें
- PPTX को PDF में
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT निर्यात PDF में
- PPTX निर्यात PDF में
- संलग्नक
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ C# कोड उदाहरण और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **परिचय**

PowerPoint प्रेजेंटेशन (PPT, PPTX, ODP, आदि) को C# में PDF स्वरूप में बदलना कई लाभ प्रदान करता है, जिसमें विभिन्न डिवाइसों के बीच संगतता और प्रेजेंटेशन की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह गाइड दर्शाता है कि प्रेजेंटेशन को PDF दस्तावेज़ों में कैसे बदलें, इमेज गुणवत्ता नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड‑सुरक्षित बनाएं, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित स्वरूपों में प्रेजेंटेशन को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रेजेंटेशन को PDF में बदलने के लिए, फ़ाइल नाम को तर्क के रूप में [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास में पास करें और फिर PDF के रूप में प्रेजेंटेशन को एक [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड का उपयोग करके सहेजें। [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड को उजागर करती है जो आमतौर पर प्रेजेंटेशन को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET अपनी API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब एक प्रेजेंटेशन को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" स्वरूप में मान से भरता है। **ध्यान दें** कि आप Aspose.Slides को इस सूचना को आउटपुट दस्तावेज़ों से बदलने या हटाने के लिए नहीं कह सकते।
{{% /alert %}}

Aspose.Slides आपको बदलने की अनुमति देता है:

* संपूर्ण प्रेजेंटेशन को PDF में बदलना
* प्रेजेंटेशन से विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रेजेंटेशन को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि उत्पन्न PDF मूल प्रेजेंटेशन से बहुत करीब मिलते हैं। रूपांतरण में तत्व और एट्रिब्यूट सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हैडर और फुटर
* बुलेट
* टेबल्स

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान किए गए प्रेजेंटेशन को अधिकतम गुणवत्ता स्तर पर इष्टतम सेटिंग्स के साथ PDF में बदलने की कोशिश करता है।

निम्नलिखित उदाहरण एक प्रेजेंटेशन लोड करता है और डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके सभी दृश्यमान स्लाइड्स को PDF में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF रूपांतरणकर्ता**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रेजेंटेशन‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस रूपांतरणकर्ता के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन देख सकते हैं।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के तहत प्रॉपर्टीज़—प्रदान करता है जो आपको उत्पन्न PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या रूपांतरण प्रक्रिया को कैसे आगे बढ़ाना है, यह निर्दिष्ट करने की अनुमति देते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर इमेज के लिए पसंदीदा गुणवत्ता सेटिंग, मेटाफाइल संभालने का तरीका, टेक्स्ट के लिए संपीड़न स्तर, इमेज DPI आदि निर्धारित कर सकते हैं।

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

### **इमेज संपीड़न का स्वचालित चयन**

जब प्रेजेंटेशन में कई फ़ोटोग्राफ़ या स्क्रीनशॉट होते हैं, तो निर्यात किए गए PDF का आकार कम करने से इसे ई‑मेल या डाउनलोड करना आसान हो सकता है। निर्यात के दौरान प्रत्येक इमेज के लिए सबसे उपयुक्त संपीड़न एल्गोरिद्म स्वचालित रूप से चुनने के लिए [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) को `true` सेट करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

यह विकल्प प्रत्येक इमेज के लिए एक संपीड़न एल्गोरिद्म चुनता है। [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) को कम करने से JPEG इमेज की गुणवत्ता घटती है, जबकि [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) को कम करने से इमेज को कम रिज़ॉल्यूशन पर डाउनसैंपल किया जाता है, जिससे विवरण घट सकता है। स्वचालित संपीड़न चयन का उपयोग स्वयं इन सेटिंग्स को नहीं घटाता।

इमेज संपीड़न एल्गोरिद्म का चयन अतिरिक्त प्रोसेसिंग समय और मेमोरी लेता है। आकार हटाना प्रेजेंटेशन की इमेज और निर्यात सेटिंग्स पर निर्भर करता है; हर प्रेजेंटेशन के लिए निश्चित घटाव की गारंटी नहीं है।

### **PDF अटैचमेंट्स के रूप में एम्बेडेड OLE फ़ाइलों को संरक्षित रखें**

यदि प्रेजेंटेशन में एम्बेडेड Excel वर्कबुक है, तो आप चाहते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा भी देख सकें। एम्बेडेड OLE फ़ाइलों को परिणामस्वरूप PDF में अटैचमेंट के रूप में संरक्षित करने के लिए [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) को `true` सेट करें।

डिफ़ॉल्ट रूप में यह मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पेज पर रेंडर होती है, लेकिन उसका एम्बेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। इसे `true` करने पर फ़ाइल डेटा भी अटैचमेंट में सम्मिलित हो जाता है। प्रीव्यू अभी भी एक दृश्य प्रतिनिधित्व रहता है; अटैचमेंट प्राप्तकर्ता को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पेज पर एक इंटरैक्टिव Excel वर्कशीट नहीं बनता।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

परिणाम की जाँच करने के लिए:

1. उस व्यूअर में निर्यात किया गया PDF खोलें जो फ़ाइल अटैचमेंट्स का समर्थन करता है, जैसे Adobe Acrobat Reader.
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को ढूँढ़ें.
3. अटैचमेंट को सहेजें और Excel में खोलकर डेटा का निरीक्षण करें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू अटैचमेंट से अलग होता है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A अटैचमेंट्स की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जिसमें Excel वर्कबुक शामिल है, को अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides की विशिष्ट प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दिखाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रेजेंटेशन में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास की [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी का उपयोग करके छिपी स्लाइड्स को उत्पन्न PDF में पेज के रूप में शामिल कर सकते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को PDF में बदलें**

निम्न उदाहरण एक प्रेजेंटेशन को ऐसे PDF में निर्यात करता है जिसमें खोलने के लिए पासवर्ड `password` चाहिए। एक्सेस अनुमतियों में प्रिंटिंग, जिसमें उच्च‑गुणवत्ता प्रिंटिंग शामिल है, की अनुमति है।

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

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के तहत [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) प्रॉपर्टी प्रदान करता है, जिससे आप प्रेजेंटेशन‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

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
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) लेख।
{{% /alert %}} 

### **डेडिकेटेड बोल्ड टाइफ़ेस वाले फ़ॉन्ट को संभालें**

किसी प्रेजेंटेशन में टेक्स्ट पर बोल्ड फ़ॉर्मेटिंग लागू की जा सकती है जबकि फ़ॉन्ट का कोई डेडिकेटेड बोल्ड टाइफ़ेस न हो। इस स्थिति में टेक्स्ट सिंथेटिक बोल्डिंग के द्वारा मोटा दिखाया जाता है, जो नियमित ग्लिफ़ को कृत्रिम रूप से मोटा करता है। यदि PDF में यह टेक्स्ट बहुत भारी या इच्छित रूप से अलग दिखता है, तो [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) को `true` सेट करने का प्रयास करें। यह विकल्प PDF निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप के रूप में रेंडर करता है और कुछ फ़ॉन्ट्स के लिए इसकी उपस्थिति में सुधार कर सकता है। इसका डिफ़ॉल्ट मान `false` है।

निम्न उदाहरण में दो टेक्स्ट बॉक्स हैं: एक सामान्य टेक्स्ट के साथ और एक समान फ़ॉन्ट पर बोल्ड फ़ॉर्मेटिंग लागू किया गया है, जिसका कोई डेडिकेटेड बोल्ड टाइफ़ेस नहीं है। उदाहरण में प्रेजेंटेशन लोड किया गया है, असमर्थित फ़ॉन्ट शैली की रास्टराइज़ेशन सक्षम की गई है, और इसे PDF में निर्यात किया गया है:

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

नीचे दोनों स्थितियों की तुलना दिखायी गई है। इस उदाहरण में, विकल्प अक्षम होने पर बोल्ड टेक्स्ट की स्ट्रोक मोटी होती है। विकल्प सक्षम होने पर स्ट्रोक हल्की होती है; सामान्य टेक्स्ट अपरिवर्तित रहता है। अपनी प्रेजेंटेशन के लिए सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प अक्षम (`false`, डिफ़ॉल्ट) | विकल्प सक्षम (`true`) |
|---|---|
| ![PDF जिसमें असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन अक्षम है](unsupported-bold-disabled.png) | ![PDF जिसमें असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन सक्षम है](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प सक्षम करने से केवल बोल्ड टेक्स्ट बिटमैप में बदल जाता है: यह OCR के बिना चयन, कॉपी या टेक्स्ट के रूप में खोजा नहीं जा सकता, और 800% ज़ूम पर किनारे अधिक नरम दिखते हैं। सामान्य टेक्स्ट सर्च योग्य बना रहता है। विकल्प अक्षम करने पर दोनों स्ट्रिंग्स टेक्स्ट ही रहती हैं।

यह विकल्प तब रास्टराइज़ करता है जब फ़ॉन्ट में डेडिकेटेड बोल्ड टाइफ़ेस नहीं होता। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) तब मूल फ़ॉन्ट उपलब्ध न होने पर किसी अन्य फ़ॉन्ट को चुनता है।

## **PowerPoint से PDF में चयनित स्लाइड्स को बदलें**

निम्न उदाहरण प्रेजेंटेशन की स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर 1‑आधारित होते हैं, और इनपुट प्रेजेंटेशन में कम से कम तीन स्लाइड्स होनी चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

निम्न उदाहरण कई 612 × 792 पॉइंट (8.5 × 11 इंच) आकार की स्लाइड के साथ नई प्रेजेंटेशन बनाकर पहले स्लाइड को कॉपी करता है। यह स्लाइड सामग्री को स्केल करके फिट करता है और एकल स्लाइड को PDF में निर्यात करता है।

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

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

निम्न उदाहरण प्रेजेंटेशन को PDF में निर्यात करता है, प्रत्येक स्लाइड के नीचे स्पीकर नोट्स रखता है। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रेजेंटेशन का उपयोग करें।

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

## **PDF के लिए एक्सेसिबिलिटी और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए इन अनुपालन मानकों में से कोई भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C# कोड विभिन्न अनुपालन मानकों पर आधारित कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

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
Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ॉर्मेट में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF से इमेज](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष फ़ॉर्मेट के लिए PDF रूपांतरण कार्य—[PDF से SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **ध्यान दें:** PDF/UA निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एकल आकृति के रूप में ट्रीट करता है। व्यक्तिगत पाथ एलिमेंट्स को अलग कंटेंट के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में मार्क किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों के माध्यम से लूप करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास की [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी को `true` सेट कर सकते हैं।

**क्या Aspose.Slides PDF में उच्च इमेज गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास में [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) और [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) जैसी प्रॉपर्टीज़ सेट करके अपने PDF में उच्च‑गुणवत्ता इमेज सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको विभिन्न मानकों, जैसे PDF/A1a, PDF/A1b, और PDF/UA के अनुरूप PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ एक्सेसिबिलिटी और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET दस्तावेज़ीकरण](/slides/hi/net/)
- [Aspose.Slides for .NET API रेफ़रेंस](https://reference.aspose.com/slides/net/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/conversion)