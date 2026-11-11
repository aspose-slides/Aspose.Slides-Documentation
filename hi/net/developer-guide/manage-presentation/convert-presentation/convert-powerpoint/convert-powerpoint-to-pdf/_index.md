---
title: PPT और PPTX को .NET में PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint को PDF में
type: docs
weight: 40
url: /hi/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को बदलें
- प्रेजेंटेशन को बदलें
- PowerPoint को PDF में
- प्रेजेंटेशन को PDF में
- PPT को PDF में
- PPT को PDF में बदलें
- PPTX को PDF में
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च गुणवत्ता, खोजनीय PDFs में बदलें, तेज़ C# कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को C# में PDF स्वरूप में बदलने से कई लाभ मिलते हैं, जिनमें विभिन्न उपकरणों के बीच संगतता और आपकी प्रस्तुति के लेआउट व फ़ॉर्मेटिंग को संरक्षित रखना शामिल है। यह गाइड प्रस्तुतियों को PDF दस्तावेज़ों में बदलना, छवि गुणवत्ता नियंत्रित करने के लिए विविध विकल्पों का उपयोग करना, छिपी स्लाइड्स को शामिल करना, PDF फ़ाइलों को पासवर्ड से सुरक्षित करना, फ़ॉन्ट प्रतिस्थापन का पता लगाना, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनना, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करना दर्शाता है।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित स्वरूपों में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

किसी प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास के आर्ग्यूमेंट के रूप में पास करें और फिर प्रस्तुति को [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड का उपयोग करके PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास वह [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड उजागर करता है जो आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या डालता है। उदाहरण के तौर पर, जब एक प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides *Application* फ़ील्ड को "*Aspose.Slides*" और PDF *Producer* फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **Note** कि आप आउटपुट दस्तावेज़ों से इस जानकारी को बदल या हटाने का निर्देश Aspose.Slides को नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* एक प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में एक्सपोर्ट करता है, जिससे उत्पन्न PDFs मूल प्रस्तुतियों के बहुत करीब होते हैं। रूपांतरण में तत्व और गुण सही तरीके से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियां
* टेक्स्ट बॉक्स और शकलें
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* टेबल

## **PowerPoint को PDF में बदलना**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ प्रदान की गई प्रस्तुति को PDF में बदलने का प्रयास करता है।

निम्नलिखित उदाहरण एक प्रस्तुति लोड करता है और सभी दृश्यमान स्लाइड्स को डिफ़ॉल्ट एक्सपोर्ट सेटिंग्स के साथ PDF में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF परिवर्तक**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन परीक्षण कर सकते हैं।
{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ बदलना**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है जो आपको निर्मित PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या रूपांतरण प्रक्रिया को नियंत्रित करने की अनुमति देते हैं।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ बदलना**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग परिभाषित कर सकते हैं, मेटा‑फ़ाइलों को कैसे संभालना है निर्दिष्ट कर सकते हैं, टेक्स्ट के लिए कम्प्रेशन स्तर तय कर सकते हैं, छवियों के DPI को कॉन्फ़िगर कर सकते हैं, आदि।

निम्नलिखित उदाहरण प्रस्तुति को PDF 1.5 के साथ JPEG गुणवत्ता 90, छवि रिज़ॉल्यूशन 300 DPI, मेटा‑फ़ाइलें PNG के रूप में सहेजें, और Flate टेक्स्ट कम्प्रेशन लागू करते हुए एक्सपोर्ट करता है।

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

> **Note:** आप `PdfOptions.SufficientResolution` को अधिक मान (जैसे `300`) पर सेट करके टेक्स्ट शैडो और प्रतिबिंब प्रभावों की रेंडरिंग गुणवत्ता को बढ़ा सकते हैं। यह PDF आउटपुट को Microsoft PowerPoint में दिखने वाले रूप के अधिक निकट बनाता है।

### **छवि कम्प्रेशन का स्वचालित चयन**

जब किसी प्रस्तुति में कई फ़ोटो या स्क्रीनशॉट होते हैं, तो निर्यातित PDF का आकार कम करना ई‑मेल या डाउनलोड को आसान बना सकता है। PDF निर्यात के दौरान प्रत्येक छवि के लिए सबसे उपयुक्त कम्प्रेशन एल्गोरिथ्म को स्वचालित रूप से चुनने के लिए [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) को `true` सेट करें।

निम्नलिखित उदाहरण मौजूदा प्रस्तुति लोड करता है, स्वचालित छवि कम्प्रेशन चयन को सक्षम करता है, और उसे PDF दस्तावेज़ के रूप में सहेजता है। सभी अन्य PDF निर्यात सेटिंग्स अपनी डिफ़ॉल्ट मानों को बरकरार रखती हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

यह विकल्प प्रत्येक छवि के लिए कम्प्रेशन एल्गोरिथ्म चुनता है। [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) को कम करने से JPEG छवि गुणवत्ता घटती है, जबकि [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) को कम करने से छवियों को कम रिज़ॉल्यूशन पर डाउनसैंपल किया जाता है, जिससे विवरण घट सकता है। स्वचालित कम्प्रेशन चयन को सक्षम करना स्वयं इन सेटिंग्स को कम नहीं करता।

छवि कम्प्रेशन एल्गोरिथ्म का चयन अतिरिक्त प्रोसेसिंग समय और मेमोरी की माँग करता है। आकार में कमी प्रस्तुति की छवियों और निर्यात सेटिंग्स पर निर्भर करती है; हर प्रस्तुति के लिए निश्चित कमी की गारंटी नहीं है।

### **एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट के रूप में संरक्षित करना**

यदि प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप चाहते हैं कि PDF प्राप्तकर्ता वर्कबुक के डेटा तक भी पहुँच सकें और स्लाइड्स को भी देख सकें। एम्बेडेड OLE फ़ाइलों को परिणामस्वरूप PDF में अटैचमेंट के रूप में संरक्षित करने के लिए [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) को `true` सेट करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पेज पर रेंडर होती है, लेकिन उसकी एम्बेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। इसे `true` करने से फ़ाइल डेटा अतिरिक्त रूप से शामिल हो जाता है। प्रीव्यू केवल दृश्य प्रतिनिधित्व बना रहता है; अटैचमेंट प्राप्तकर्ता को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की सुविधा देता है। OLE ऑब्जेक्ट PDF पेज पर एक इंटरैक्टिव Excel वर्कशीट नहीं बनता।

निम्नलिखित उदाहरण एक प्रस्तुति लोड करता है जिसमें पहले से एम्बेडेड Excel वर्कबुक है और उसे वर्कबुक अटैचमेंट के साथ PDF में निर्यात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

परिणाम की जांच करने के लिए:

1. ऐसे व्यूअर में निर्यातित PDF खोलें जो फ़ाइल अटैचमेंट का समर्थन करता हो, जैसे Adobe Acrobat Reader।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें।
3. अटैचमेंट को सहेजें और Excel में खोलकर डेटा निरीक्षण करें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू अटैचमेंट से अलग रहता है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A‑1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A‑2 केवल PDF/A अटैचमेंट की अनुमति देता है, और PDF/A‑3 अन्य फ़ाइल प्रकार, सहित Excel वर्कबुक, की अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides की कोई विशेष प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दर्शाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलना**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास से [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी का उपयोग करके छिपी स्लाइड्स को परिणामस्वरूप PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

निम्नलिखित उदाहरण छिपी स्लाइड्स सहित प्रस्तुति को PDF में निर्यात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलना**

निम्नलिखित उदाहरण प्रस्तुति को ऐसे PDF में निर्यात करता है जिसे खोलने के लिए पासवर्ड `password` आवश्यक है। एक्सेस परमिशन प्रिंटिंग, जिसमें हाई‑क्वालिटी प्रिंटिंग भी शामिल है, की अनुमति देती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाना**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) प्रॉपर्टी प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

निम्नलिखित उदाहरण प्रस्तुति को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। जब निर्यात के दौरान कोई अनुपलब्ध फ़ॉन्ट प्रतिस्थापित होता है, तभी चेतावनी प्रिंट होती है।

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
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें: [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) लेख।
{{% /alert %}}

### **बिना समर्पित बोल्ड टाइपफ़ेस वाले फ़ॉन्ट्स को संभालना**

एक प्रस्तुति में तब भी बोल्ड फ़ॉर्मेटिंग लागू की जा सकती है जब फ़ॉन्ट का कोई समर्पित बोल्ड टाइपफ़ेस न हो। इस स्थिति में टेक्स्ट सिंथेटिक बोल्डिंग के द्वारा दिखाया जाता है, जो सामान्य ग्लिफ़ को कृत्रिम रूप से मोटा कर देता है। यदि PDF में यह टेक्स्ट बहुत भारी या इच्छित रूप से अलग दिखे, तो [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) को `true` सेट करने का प्रयत्न करें। यह विकल्प PDF निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप के रूप में रास्टराइज़ करता है और कुछ फ़ॉन्ट्स के लिए उसकी उपस्थिति में सुधार कर सकता है। इसका डिफ़ॉल्ट मान `false` है।

निम्नलिखित उदाहरण प्रस्तुति लोड करता है, असमर्थित फ़ॉन्ट शैलियों की रास्टराइज़ेशन सक्षम करता है, और उसे PDF में निर्यात करता है:

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

नीचे दोनों स्थितियों के प्रीव्यू दिखाए गए हैं। इस उदाहरण में, विकल्प अक्षम होने पर बोल्ड टेक्स्ट के स्ट्रोक अधिक मोटे होते हैं। विकल्प सक्षम होने पर स्ट्रोक हल्के होते हैं; सामान्य टेक्स्ट अपरिवर्तित रहता है। अपने प्रस्तुति के लिए सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प अक्षम (`false`, डिफ़ॉल्ट) | विकल्प सक्षम (`true`) |
|---|---|
| ![असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन अक्षम वाला PDF](unsupported-bold-disabled.png) | ![असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन सक्षम वाला PDF](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प को सक्षम करने पर केवल बोल्ड टेक्स्ट बिटमैप बन जाता है: इसे OCR के बिना चयन, कॉपी या खोज नहीं किया जा सकता, और 800 % ज़ूम पर किनारे अधिक नरम दिखाई देते हैं। सामान्य टेक्स्ट खोज योग्य बना रहता है। विकल्प अक्षम होने पर दोनों स्ट्रिंग्स टेक्स्ट ही रहती हैं।

यह विकल्प तब बोल्ड के रूप में फ़ॉर्मेट किए गए टेक्स्ट को रास्टराइज़ करता है जब फ़ॉन्ट का कोई समर्पित बोल्ड टाइपफ़ेस नहीं होता। फ़ॉन्ट प्रतिस्थापन ([फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/)) इसके बजाय मूल फ़ॉन्ट उपलब्ध न होने पर कोई अन्य फ़ॉन्ट चुनता है।

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलना**

निम्नलिखित उदाहरण प्रस्तुति की स्लाइड 1 और 3 को PDF में निर्यात करता है। इस सरणी में स्लाइड नंबर एक‑आधारित होते हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड्स होनी चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलना**

निम्नलिखित उदाहरण पहली स्लाइड को 612 × 792 पॉइंट (8.5 × 11 इंच) के स्लाइड आकार वाले नई प्रस्तुति में कॉपी करता है। यह स्लाइड सामग्री को फिट करने के लिए स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

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

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलना**

निम्नलिखित उदाहरण प्रस्तुति को PDF में निर्यात करता है, जहाँ प्रत्येक स्लाइड के नीचे उसके स्पीकर नोट्स रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

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

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप PowerPoint दस्तावेज़ को किसी भी निम्नलिखित अनुपालन मानक के तहत PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

निम्न C# कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया दर्शाता है:

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
Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेषीकृत स्वरूपों—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—के लिए भी समर्थन उपलब्ध है।
{{% /alert %}}

> **Note:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides SmartArt, चार्ट और फ़ॉर्मूला जैसी जटिल ग्राफ़िक्स को एकल आकृति के रूप में ट्रीट करता है। व्यक्तिगत पाथ तत्व अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल संपूर्ण आकृति के लिए प्रदान किया जाता है।

## **FAQ**

**क्या मैं कई PowerPoint फ़ाइलें एक साथ PDF में बदल सकता हूं?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच में PDF में बदलने का समर्थन करता है। आप अपने फ़ाइलों पर इटरेट करके रूपांतरण प्रक्रिया को प्रोग्रामmatically लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड से सुरक्षित किया जा सकता है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस परमिशन निर्धारित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूं?**

परिणामस्वरूप PDF में छिपी स्लाइड्स को शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास में [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी को `true` सेट करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) क्लास में [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) और [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) जैसे प्रॉपर्टीज़ सेट करके अपने PDF में उच्च‑गुणवत्ता वाली छवियां सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको विभिन्न मानकों, जैसे PDF/A1a, PDF/A1b, और PDF/UA के अनुरूप PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ अभिगम्यता और आर्काइविंग आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET Documentation](/slides/hi/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)

संबंधित फीचर: [Export presentations to PDF](/slides/hi/features/pdf-export/).