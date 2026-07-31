---
title: C++ में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को बदलें
- प्रेजेंटेशन को बदलें
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
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, खोजने योग्य PDFs में बदलें, साथ में तेज़ कोड उदाहरण और उन्नत रूपांतरण विकल्प।"
---
## **अवलोकन**

C++ में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF स्वरूप में बदलने के कई लाभ हैं, जैसे विभिन्न उपकरणों के बीच संगतता और प्रस्तुति की लेआउट व फ़ॉर्मेटिंग को संरक्षित रखना। यह गाइड दर्शाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड‑सुरक्षित बनाएं, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, परिवर्तन के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF परिवर्तन**

Aspose.Slides का उपयोग करके आप निम्नलिखित प्रारूपों की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

प्रस्तुति को PDF में बदलने के लिए फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास के आर्गुमेंट के रूप में पास करें और फिर `Save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास `Save` मेथड को उजागर करता है जिसका सामान्यतः प्रयोग प्रस्तुति को PDF में बदलने के लिए किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप आउटपुट दस्तावेज़ों से इस जानकारी को बदल या हटाने के लिए Aspose.Slides को निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित बदलने की सुविधा देता है:

* पूरी प्रस्तुतियों को PDF में बदलना
* प्रस्तुति की विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे उत्पन्न PDFs मूल प्रस्तुतियों के करीब होते हैं। परिवर्तन के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF परिवर्तन प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस स्थिति में, Aspose.Slides अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ प्रदान की गई प्रस्तुति को PDF में बदलने का प्रयत्न करता है।

यह C++ कोड दर्शाता है कि प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में कैसे बदला जाए:

```c++
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF कन्वर्टर**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF परिवर्तन प्रक्रिया को दर्शाता है। आप इस कन्वर्टर के साथ परीक्षण करके यहाँ वर्णित प्रक्रिया को लाइव देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है, जिनसे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या परिवर्तन प्रक्रिया के प्रवाह को निर्दिष्ट कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम परिवर्तन विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग, मेटा फ़ाइलों के हैंडलिंग, टेक्स्ट के लिए कम्प्रेशन स्तर, छवियों के DPI आदि परिभाषित कर सकते हैं।

नीचे दिया गया कोड उदाहरण कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में बदलना दर्शाता है।

```c++
// PdfOptions क्लास को इनस्टैंशिएट करें।
auto pdfOptions = MakeObject<PdfOptions>();

// JPG छवियों की गुणवत्ता सेट करें।
pdfOptions->set_JpegQuality(90);

// छवियों के लिए DPI सेट करें।
pdfOptions->set_SufficientResolution(300);

// मेटा फ़ाइलों के व्यवहार को सेट करें।
pdfOptions->set_SaveMetafilesAsPng(true);

// पाठ्य सामग्री के लिए टेक्स्ट कम्प्रेशन स्तर सेट करें।
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF अनुपालन मोड परिभाषित करें।
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// प्रेजेंटेशन को PDF दस्तावेज़ के रूप में सहेजें।
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **छिपी स्लाइड्स सहित PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास की [set_ShowHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) मेथड का उपयोग करके छिपी स्लाइड्स को परिणामस्वरूप PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह C++ कोड दिखाता है कि छिपी स्लाइड्स सहित PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```c++
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions क्लास को इनस्टैंशिएट करें।
auto pdfOptions = MakeObject<PdfOptions>();

// छिपी स्लाइड्स जोड़ें।
pdfOptions->set_ShowHiddenSlides(true);

// प्रेजेंटेशन को PDF के रूप में सहेजें।
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **पासवर्ड‑सुरक्षित PDF में PowerPoint को बदलें**

यह C++ कोड दर्शाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के प्रोटेक्शन पैरामीटर्स का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑सुरक्षित PDF में कैसे बदला जाए:

```c++
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions क्लास को इनस्टैंशिएट करें।
auto pdfOptions = MakeObject<PdfOptions>();

// PDF पासवर्ड और एक्सेस अनुमतियाँ सेट करें।
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// प्रेजेंटेशन को PDF के रूप में सहेजें।
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत [set_WarningCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_warningcallback/) मेथड प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF परिवर्तन प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह C++ कोड फ़ॉन्ट प्रतिस्थापन का पता लगाने को दर्शाता है:

```c++
// चेतावनी कॉलबैक का कार्यान्वयन।
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें।
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // प्रेजेंटेशन को PDF के रूप में सहेजें।
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

फ़ॉन्ट प्रतिस्थापन के दौरान रेंडरिंग प्रक्रिया में कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें: [Getting Warning Callbacks for Fonts Substitution](/slides/hi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें: [Font Substitution](/slides/hi/cpp/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति की केवल विशिष्ट स्लाइड्स को PDF में कैसे बदला जाए:

```C++
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// स्लाइड नंबरों की एरे सेट करें।
auto slides = MakeArray<int32_t>({ 1, 3 });

// प्रेजेंटेशन को PDF के रूप में सहेजें।
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह C++ कोड दर्शाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ एक नई प्रस्तुति बनाएं।
auto resizedPresentation = MakeObject<Presentation>();

// कस्टम स्लाइड आकार सेट करें।
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **नोट्स स्लाइड व्यू में PDF के साथ PowerPoint को बदलें**

यह C++ कोड दर्शाता है कि नोट्स सहित PDF बनाने के लिए PowerPoint प्रस्तुति को कैसे बदला जाए:

```C++
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// PDF विकल्पों को नोट्स लेआउट के साथ कॉन्फ़िगर करें।
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// प्रेजेंटेशन को नोट्स के साथ PDF में सहेजें।
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF के लिए पहुँच योग्यता और अनुपालन मानक**

Aspose.Slides आपको एक परिवर्तन प्रक्रिया का उपयोग करने देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए निम्नलिखित अनुपालन मानकों में से कोई भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C++ कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF परिवर्तन प्रक्रिया को दर्शाता है:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ॉर्मेट्स में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष फ़ॉर्मेट्स—[PDF to SVG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एकल आकृति के रूप में मानता है। व्यक्तिगत पथ तत्व अलग‑अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक पाठ केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **FAQ**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच में PDF में बदलने का समर्थन करता है। आप फ़ाइलों पर इटरट करके परिवर्तन प्रक्रिया को प्रोग्रामेटिक रूप से लागू कर सकते हैं।

**क्या बदले गए PDF को पासवर्ड‑सुरक्षित किया जा सकता है?**

बिल्कुल। परिवर्तन प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास की `set_ShowHiddenSlides` मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप `set_JpegQuality` और `set_SufficientResolution` जैसी मेथड्स का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास में छवि गुणवत्ता नियंत्रित कर सकते हैं, ताकि आपका PDF उच्च‑गुणवत्ता वाली छवियों को शामिल करे।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides विभिन्न मानकों जैसे PDF/A1a, PDF/A1b, और PDF/UA के साथ संगत PDFs निर्यात करने की सुविधा देता है, जिससे आपके दस्तावेज़ पहुँच योग्यता और अभिलेखीय आवश्यकताओं को पूरा कर सकें।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for C++ Documentation](/slides/hi/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/hi/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)