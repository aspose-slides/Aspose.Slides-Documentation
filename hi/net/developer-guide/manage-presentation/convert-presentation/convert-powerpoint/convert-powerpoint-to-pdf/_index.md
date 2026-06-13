---
title: PPT और PPTX को .NET में PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/net/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, खोजनीय PDFs में बदलें, तेज़ C# कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **परिचय**

C# में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF प्रारूप में बदलने से कई लाभ प्राप्त होते हैं, जिनमें विभिन्न उपकरणों में अनुकूलता और प्रस्तुति की लेआउट व स्वरूप को संरक्षित रखना शामिल है। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स को शामिल करें, PDF फ़ाइलों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित प्रारूपों की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास के तर्क के रूप में पास करें और फिर [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास वह [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड उजागर करती है जिसे आमतौर पर प्रस्तुति को PDF में बदलने के लिए प्रयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के तौर पर, जब प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए नहीं कह सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूपांतरण करने की सुविधा देता है:

* पूरे प्रस्तुतियों को PDF में बदलना
* प्रस्तुति से विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि परिणामी PDFs मूल प्रस्तुतियों से यथासंभव मिलते-जुलते हों। रूपांतरण के दौरान तत्वों और गुणों को सटीक रूप से रेंडर किया जाता है, जिनमें शामिल हैं:

* छवियां
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक्स
* हेडर और फ़ूटर
* बुलेट्स
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस स्थिति में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह C# कोड दिखाता है कि प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में कैसे बदला जाए:

```c#
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं.
using var presentation = new Presentation("PowerPoint.ppt");

// प्रेजेंटेशन को PDF के रूप में सहेजें.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कनवर्टर**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को प्रदर्शित करता है। आप इस कनवर्टर के साथ एक परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का प्रत्यक्ष कार्यान्वयन देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत उपलब्ध गुण—प्रदान करता है, जिससे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, पासवर्ड के साथ PDF को लॉक कर सकते हैं, या रूपांतरण प्रक्रिया के व्यवहार को निर्धारित कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग, मेटाफाइल्स को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI आदि परिभाषित कर सकते हैं।

नीचे दिया गया कोड उदाहरण कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में बदलना दर्शाता है।

```c#
// PdfOptions क्लास का इंस्टेंस बनाएं.
var pdfOptions = new PdfOptions
{
    // JPG छवियों की गुणवत्ता सेट करें.
    JpegQuality = 90,

    // छवियों के लिए DPI सेट करें.
    SufficientResolution = 300,

    // मेटाफाइल्स के व्यवहार को सेट करें.
    SaveMetafilesAsPng = true,

    // पाठ सामग्री के लिए टेक्स्ट कंप्रेशन स्तर सेट करें.
    TextCompression = PdfTextCompression.Flate,

    // PDF अनुपालन मोड निर्धारित करें.
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं.
using var presentation = new Presentation("PowerPoint.pptx");

// प्रेजेंटेशन को PDF दस्तावेज़ के रूप में सहेजें.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास की [ShowHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी का उपयोग करके छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह C# कोड दिखाता है कि छिपी स्लाइड्स सहित PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```c#
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions क्लास का इंस्टेंस बनाएं.
var pdfOptions = new PdfOptions();

// छिपी स्लाइड्स जोड़ें.
pdfOptions.ShowHiddenSlides = true;

// प्रेजेंटेशन को PDF के रूप में सहेजें.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

यह C# कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के सुरक्षा पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑सुरक्षित PDF में कैसे बदला जाए:

```c#
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं.
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions क्लास का इंस्टेंस बनाएं.
var pdfOptions = new PdfOptions();

// PDF पासवर्ड और एक्सेस अनुमतियाँ सेट करें.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// प्रेजेंटेशन को PDF के रूप में सहेजें.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के तहत [WarningCallback](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/warningcallback/) प्रॉपर्टी प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह C# कोड दिखाता है कि फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाया जाए:

```c#
public static void Main()
{
    // PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं. 
    using var presentation = new Presentation("sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // प्रेजेंटेशन को PDF के रूप में सहेजें.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// चेतावनी कॉलबैक का कार्यान्वयन.
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

{{%  alert color="primary"  %}} 

रेंडरिंग प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन के लिए कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें: [Getting Warning Callbacks for Fonts Substitution](/slides/hi/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अतिरिक्त जानकारी के लिए देखें: [Font Substitution](/slides/hi/net/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से PDF में केवल चयनित स्लाइड्स बदलें**

यह C# कोड दिखाता है कि PowerPoint प्रस्तुति से केवल विशिष्ट स्लाइड्स को PDF में कैसे बदला जाए:

```c#
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं.
using var presentation = new Presentation("PowerPoint.pptx");

// स्लाइड नंबरों की एरे सेट करें.
int[] slides = { 1, 3 };

// प्रेजेंटेशन को PDF के रूप में सहेजें.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह C# कोड दिखाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **नोट्स स्लाइड व्यू में PDF के साथ PowerPoint को बदलें**

यह C# कोड दिखाता है कि नोट्स सहित PDF बनाने के लिए PowerPoint प्रस्तुति को कैसे बदला जाए:

```c#
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

// प्रेजेंटेशन को नोट्स सहित PDF में सहेजें.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF के लिए पहुँच और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [वेब कंटेंट एक्सेसिबिलिटी गाइडलाइन (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए निम्नलिखित अनुपालन मानकों में से किसी को भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C# कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

```c#
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

Aspose.Slides PDF रूपांतरण कार्यों को समर्थन देता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल प्रारूपों में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/hi/net/conversion/pdf-to-html/), [PDF से इमेज](https://products.aspose.com/slides/hi/net/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/hi/net/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/hi/net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। विशेषीकृत प्रारूपों—[PDF से SVG](https://products.aspose.com/slides/hi/net/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/hi/net/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/hi/net/conversion/pdf-to-xml/)—के लिए भी अन्य PDF रूपांतरण कार्य समर्थित हैं।

{{% /alert %}}

> **नोट:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और सूत्रों को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्व अलग-अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक पाठ केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **FAQ**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हां, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच रूप में PDF में बदलने का समर्थन करता है। आप अपने फ़ाइलों पर लूप चलाकर प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या रूपांतरित PDF को पासवर्ड‑सुरक्षित किया जा सकता है?**

बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियाँ निर्धारित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास की `ShowHiddenSlides` प्रॉपर्टी को `true` सेट करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हां, आप `JpegQuality` और `SufficientResolution` जैसी प्रॉपर्टीज़ को [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास में सेट करके PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हां, Aspose.Slides विभिन्न मानकों, जैसे PDF/A1a, PDF/A1b, और PDF/UA के साथ अनुकूल PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ पहुँचयोग्यता और अभिलेखागार आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET दस्तावेज़ीकरण](/slides/hi/net/)
- [Aspose.Slides for .NET API संदर्भ](https://reference.aspose.com/slides/hi/net/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/hi/conversion)