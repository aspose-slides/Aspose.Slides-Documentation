---
title: C++ में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint को PDF में
type: docs
weight: 40
url: /hi/cpp/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT/PPTX को उच्च-गुणवक्ता, खोज योग्य PDFs में परिवर्तित करें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **समीक्षा**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को C++ में PDF प्रारूप में बदलने के कई लाभ हैं, जिनमें विभिन्न उपकरणों के बीच संगतता और आपकी प्रस्तुति की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित करें, छवि गुणवत्ता को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स को शामिल करें, PDF फ़ाइलों को पासवर्ड-संरक्षित करें, फ़ॉन्ट प्रतिस्थापनों का पता लगाएँ, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्न प्रारूपों में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में तर्क के रूप में पास करें और फिर `Save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास `Save` मेथड को उजागर करता है जिसे आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब किसी प्रस्तुति को PDF में बदलते हैं, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित करने की अनुमति देता है:

* पूरे प्रस्तुतियों को PDF में बदलना
* प्रस्तुति से विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करता है कि परिणामी PDFs मूल प्रस्तुतियों के बहुत करीब हों। रूपांतरण के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिनमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

स्टैंडर्ड PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर अनुकूल सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह C++ कोड दिखाता है कि कैसे एक प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में बदला जाए:

```c++
// PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ इस परिवर्तक के साथ एक परीक्षण चलाकर इस दस्तावेज़ में वर्णित प्रक्रिया को लाइव लागू कर सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है जो आपको परिणामी PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या रूपांतरण प्रक्रिया के प्रवाह को निर्धारित करने की अनुमति देता है।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग, मेटाफाइल्स के हैंडलिंग, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI आदि परिभाषित कर सकते हैं।

नीचे दिया गया कोड उदाहरण कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में बदलने को दर्शाता है।

```c++
// PdfOptions क्लास को इंस्टैंसिएट करें.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG छवियों की गुणवत्ता सेट करें.
pdfOptions->set_JpegQuality(90);

// छवियों के लिए DPI सेट करें.
pdfOptions->set_SufficientResolution(300);

// मेटाफाइल्स के व्यवहार को सेट करें.
pdfOptions->set_SaveMetafilesAsPng(true);

// पाठ्य सामग्री के लिए टेक्स्ट कम्प्रेशन स्तर सेट करें.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF अनुपालन मोड को परिभाषित करें.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Presentation क्लास को इंस्टैंसिएट करें जो PowerPoint या OpenDocument फ़ाइल को दर्शाता है.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजें.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि किसी प्रस्तुति में छिपी स्लाइड्स हों, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास की `set_ShowHiddenSlides` मेथड का उपयोग करके छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह C++ कोड दिखाता है कि कैसे छिपी स्लाइड्स को शामिल कर PowerPoint प्रस्तुति को PDF में बदला जाए:

```c++
// PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions क्लास को इंस्टैंसिएट करें.
auto pdfOptions = MakeObject<PdfOptions>();

// छिपी स्लाइड्स जोड़ें.
pdfOptions->set_ShowHiddenSlides(true);

// प्रस्तुति को PDF के रूप में सहेजें.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

यह C++ कोड दिखाता है कि कैसे [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के सुरक्षा पैरामीटरों का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑सुरक्षित PDF में बदला जा सकता है:

```c++
// PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions क्लास को इंस्टैंसिएट करें.
auto pdfOptions = MakeObject<PdfOptions>();

// PDF पासवर्ड और एक्सेस अनुमतियों को सेट करें.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// प्रस्तुति को PDF के रूप में सहेजें.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के तहत `set_WarningCallback` मेथड प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापनों का पता लगा सकते हैं।

यह C++ कोड फ़ॉन्ट प्रतिस्थापन का पता लगाने को दर्शाता है:

```c++
// चेतावनी कॉलबैक का कार्यान्वयन.
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
    // PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // प्रस्तुति को PDF के रूप में सहेजें.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

फ़ॉन्ट प्रतिस्थापन के दौरान रेंडरिंग प्रक्रिया में कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें [Getting Warning Callbacks for Fonts Substitution](/slides/hi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें [Font Substitution](/slides/hi/cpp/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

यह C++ कोड दर्शाता है कि कैसे केवल विशिष्ट स्लाइड्स को PowerPoint प्रस्तुति से PDF में बदला जाए:

```C++
// PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// स्लाइड नंबरों की array सेट करें.
auto slides = MakeArray<int32_t>({ 1, 3 });

// प्रस्तुति को PDF के रूप में सहेजें.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह C++ कोड दर्शाता है कि कैसे निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में बदला जाए:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

यह C++ कोड दर्शाता है कि कैसे नोट्स सहित PowerPoint प्रस्तुति को PDF में बदला जाए:

```C++
// PowerPoint या OpenDocument फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// PDF विकल्पों को नोट्स लेआउट के साथ कॉन्फ़िगर करें.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// प्रस्तुति को नोट्स के साथ PDF के रूप में सहेजें.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF के लिए पहुँच और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया का उपयोग करने की अनुमति देता है जो [वेब कंटेंट एक्सेसिबिलिटी गाइडलाइन्स (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप PowerPoint दस्तावेज़ को PDF में निर्यात करते समय इन अनुपालन मानकों में से किसी का भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C++ कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

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

Aspose.Slides PDF रूपांतरण संचालन का समर्थन करता है, जिससे आप PDF फ़ाइलों को विभिन्न लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष स्वरूपों—[PDF to SVG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-xml/)—के लिए भी समर्थन उपलब्ध है।

{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फ़ॉर्मूले को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और वे आर्टिफैक्ट के रूप में चिह्नित हो सकते हैं; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **बारंबार पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फाइलों को बल्क में PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप प्रोग्रामेटिक रूप से फ़ाइलों को क्रमशः पढ़कर रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित किया जा सकता है?**

बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास की `set_ShowHiddenSlides` मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप `set_JpegQuality` और `set_SufficientResolution` जैसी मेथड्स का उपयोग करके PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको PDF/A1a, PDF/A1b, और PDF/UA सहित विभिन्न मानकों के अनुरूप PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ पहुँच और अभिकरण आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for C++ Documentation](/slides/hi/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/hi/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)