---
title: PPT और PPTX को .NET में PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ C# कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

C# में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF फ़ॉर्मेट में बदलने से कई लाभ मिलते हैं, जिसमें विभिन्न डिवाइसों पर संगतता और आपकी प्रस्तुति की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदला जाए, छवि गुणवत्ता नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग कैसे किया जाए, छिपी हुई स्लाइड्स को शामिल किया जाए, PDF फ़ाइलों को पासवर्ड‑सुरक्षित कैसे बनाया जाए, फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाया जाए, रूपांतरण के लिए विशिष्ट स्लाइड्स कैसे चुनी जाएँ, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को कैसे लागू किया जाए।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित फार्मेट में प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

किसी प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को एक तर्क के रूप में [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास को पास करें और फिर [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड को उजागर करती है, जिसे आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब प्रस्तुति को PDF में परिवर्तित किया जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देशित नहीं कर सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित को बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* एक प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे परिणामी PDF मूल प्रस्तुतियों के करीब होते हैं। रूपांतरण में तत्व और विशेषताएँ सटीक रूप से प्रस्तुत की जाती हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकृतियाँ
* टेक्स्ट फ़ॉर्मेटिंग
* अनुच्छेद फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* टेबल

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर अनुकूल सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह C# कोड दिखाता है कि प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में कैसे बदलें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
using var presentation = new Presentation("PowerPoint.ppt");

// प्रस्तुति को PDF के रूप में सहेजें।
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose एक मुफ्त ऑनलाइन **PowerPoint to PDF converter**(https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कनवर्टर के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का वास्तविक कार्यान्वयन देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है, जिससे आप परिणामी PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या यह निर्दिष्ट कर सकते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग निर्धारित कर सकते हैं, मेटाफाइल्स को कैसे संभालना है यह निर्दिष्ट कर सकते हैं, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के लिए DPI कॉन्फ़िगर कर सकते हैं, और भी बहुत कुछ।

नीचे दिया गया कोड उदाहरण दर्शाता है कि कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में कैसे बदला जाए।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PdfOptions क्लास का उदाहरण बनाएं।
var pdfOptions = new PdfOptions
{
    // JPG छवियों की गुणवत्ता सेट करें।
    JpegQuality = 90,

    // छवियों के लिए DPI सेट करें।
    SufficientResolution = 300,

    // मेटाफाइल्स के व्यवहार को सेट करें।
    SaveMetafilesAsPng = true,

    // टेक्स्ट सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें।
    TextCompression = PdfTextCompression.Flate,

    // PDF अनुपालन मोड निर्धारित करें।
    Compliance = PdfCompliance.Pdf15
};

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
using var presentation = new Presentation("PowerPoint.pptx");

// प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजें।
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **छुपी हुई स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि किसी प्रस्तुति में छुपी हुई स्लाइड्स हों, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास की [ShowHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी का उपयोग करके छुपी हुई स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह C# कोड दिखाता है कि छुपी हुई स्लाइड्स को शामिल करके PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions क्लास का उदाहरण बनाएं।
var pdfOptions = new PdfOptions();

// छुपी हुई स्लाइड्स जोड़ें।
pdfOptions.ShowHiddenSlides = true;

// प्रस्तुति को PDF के रूप में सहेजें।
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **पासवर्ड‑सुरक्षित PDF में PowerPoint बदलें**

यह C# कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के सुरक्षा पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑सुरक्षित PDF में कैसे बदला जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions क्लास का उदाहरण बनाएं।
var pdfOptions = new PdfOptions();

// PDF पासवर्ड और अभिगमन अनुमतियों को सेट करें।
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// प्रस्तुति को PDF के रूप में सहेजें.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के तहत [WarningCallback](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/warningcallback/) प्रॉपर्टी प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह C# कोड दिखाता है कि फ़ॉन्ट प्रतिस्थापन कैसे पता लगाए जाएँ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं। 
    using var presentation = new Presentation("sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें।
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// चेतावनी कॉलबैक का कार्यान्वयन।
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

रेंडरिंग प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापनों के लिए कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें [Getting Warning Callbacks for Fonts Substitution](/slides/hi/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/net/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

यह C# कोड दर्शाता है कि PowerPoint प्रस्तुति से केवल विशिष्ट स्लाइड्स को PDF में कैसे बदला जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं.
using var presentation = new Presentation("PowerPoint.pptx");

// स्लाइड नंबरों की array सेट करें.
int[] slides = { 1, 3 };

// प्रस्तुति को PDF के रूप में सहेजें.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह C# कोड दर्शाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// PowerPoint प्रस्तुति लोड करें.
using var presentation = new Presentation("SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाएं.
using var resizedPresentation = new Presentation();

// कस्टम स्लाइड आकार सेट करें.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// मूल प्रस्तुति से पहली स्लाइड की क्लोन बनाएं.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// नई प्रस्तुति के साथ बनी खाली स्लाइड को हटाएं.
resizedPresentation.Slides.RemoveAt(1);

// रिसाइज़्ड प्रस्तुति को PDF के रूप में सहेजें.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

यह C# कोड दर्शाता है कि नोट्स सहित PDF बनाने के लिए PowerPoint प्रस्तुति को कैसे बदला जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint प्रस्तुति लोड करें.
using var presentation = new Presentation("NotesFile.pptx");

// नोट्स लेआउट के साथ PDF विकल्प कॉन्फ़िगर करें.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// प्रस्तुति को नोट्स सहित PDF में सहेजें.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C# कोड दर्शाता है कि विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया कैसे काम करती है:

```c#
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में परिवर्तित कर सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/net/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष स्वरूपों में PDF रूपांतरण—[PDF to SVG](https://products.aspose.com/slides/hi/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/net/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/net/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एक ही आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्व अलग सामग्री के रूप में संरक्षित नहीं रहते और उन्हें कलाकृतियों के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटरेट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

### क्या बदले गए PDF को पासवर्ड‑सुरक्षित करना संभव है?

बिल्कुल। आप रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास का उपयोग कर सकते हैं।

### मैं PDF में छुपी हुई स्लाइड्स को कैसे शामिल करूँ?

`ShowHiddenSlides` प्रॉपर्टी को [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास में `true` सेट करके आप परिणामी PDF में छुपी हुई स्लाइड्स को शामिल कर सकते हैं।

### क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?

हाँ, आप `JpegQuality` और `SufficientResolution` जैसे प्रॉपर्टीज़ को [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास में सेट करके अपने PDF में उच्च‑गुणवत्ता की छवियाँ सुनिश्चित कर सकते हैं।

### क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?

हाँ, Aspose.Slides आपको विभिन्न मानकों, जिनमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, का पालन करने वाले PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ अभिगम्यता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET दस्तावेज़](/slides/hi/net/)
- [Aspose.Slides for .NET API रेफरेंस](https://reference.aspose.com/slides/hi/net/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/hi/conversion)