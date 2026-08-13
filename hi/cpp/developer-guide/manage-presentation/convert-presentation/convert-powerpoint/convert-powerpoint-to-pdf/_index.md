---
title: C++ में PPT और PPTX को PDF में परिवर्तित करें [उन्नत सुविधाओं सहित]
linktitle: PowerPoint को PDF में
type: docs
weight: 40
url: /hi/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरण
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
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में परिवर्तित करें, तेज़ 코ड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ."
---
## **अवलोकन**

C++ में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF फ़ॉर्मेट में बदलने से कई लाभ होते हैं, जिसमें विभिन्न डिवाइसों के बीच संगतता और आपकी प्रस्तुति की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह गाइड दिखाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित किया जाए, छवि गुणवत्ता को नियंत्रित करने के विभिन्न विकल्पों का उपयोग कैसे किया जाए, छिपी स्लाइड्स को शामिल किया जाए, PDF फ़ाइलों को पासवर्ड से सुरक्षित किया जाए, फ़ॉन्ट प्रतिस्थापन का पता लगाया जाए, परिवर्तन के लिए विशिष्ट स्लाइड्स का चयन किया जाए, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू किया जाए।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित फ़ॉर्मेट में प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में परिवर्तित करने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास के आर्ग्युमेंट के रूप में पास करें और फिर `Save` मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास `Save` मेथड को प्रदर्शित करती है, जिसे सामान्यतः प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{%  alert title="ध्यान दें"  color="warning"   %}} 

C++ के लिए Aspose.Slides अपने API जानकारी और संस्करण नंबर को आउटपुट दस्तावेज़ों में डालता है। उदाहरण के लिए, जब किसी प्रस्तुति को PDF में रूपांतरित किया जाता है, Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" के रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को आउटपुट दस्तावेज़ों से बदलने या हटाने के लिए नहीं कह सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित को परिवर्तित करने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* किसी प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि परिणामी PDF मूल प्रस्तुतियों से बहुत मेल खाता है। तत्व और गुण रूपांतरण में सटीक रूप से प्रदर्शित होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फॉर्मैटिंग
* पैराग्राफ फॉर्मैटिंग
* हाइपरलिंक्स
* हेडर और फ़ूटर
* बुलेट्स
* टेबल्स

## **PowerPoint को PDF में परिवर्तित करें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर अनुकूल सेटिंग्स का उपयोग करके PDF में बदलने का प्रयास करता है।

यह C++ कोड दर्शाता है कि प्रस्तुति (PPT, PPTX, ODP आदि) को PDF में कैसे परिवर्तित किया जाए:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कन्वर्टर**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कन्वर्टर के साथ एक परीक्षण चला सकते हैं ताकि यहाँ वर्णित प्रक्रिया का वास्तविक कार्यान्वयन देखा जा सके।

{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ परिवर्तित करें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़— प्रदान करता है जो आपको परिणामी PDF को कस्टमाइज़ करने, PDF को पासवर्ड से लॉक करने, या यह निर्दिष्ट करने की अनुमति देते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ परिवर्तित करें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग निर्धारित कर सकते हैं, यह निर्दिष्ट कर सकते हैं कि मेटाफाइल्स कैसे संभाले जाएँ, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के लिए DPI कॉन्फ़िगर कर सकते हैं, और भी कई चीज़ें कर सकते हैं।

नीचे दिया गया कोड उदाहरण दिखाता है कि कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए।

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// PdfOptions क्लास का उदाहरण बनाएं।
auto pdfOptions = MakeObject<PdfOptions>();

// JPG छवियों की गुणवत्ता निर्धारित करें।
pdfOptions->set_JpegQuality(90);

// छवियों के लिए DPI सेट करें।
pdfOptions->set_SufficientResolution(300);

// मेटाफाइल्स के व्यवहार को निर्धारित करें।
pdfOptions->set_SaveMetafilesAsPng(true);

// पाठ सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें।
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF अनुपालन मोड को परिभाषित करें।
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजें।
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint को PDF में छिपी स्लाइड्स के साथ परिवर्तित करें**

यदि किसी प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास की [set_ShowHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) मेथड का उपयोग करके परिणामस्वरूप PDF में छिपी स्लाइड्स को पृष्ठों के रूप में शामिल कर सकते हैं।

यह C++ कोड दर्शाता है कि छिपी स्लाइड्स सहित PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions क्लास का उदाहरण बनाएं।
auto pdfOptions = MakeObject<PdfOptions>();

// छिपी स्लाइड्स जोड़ें।
pdfOptions->set_ShowHiddenSlides(true);

// प्रस्तुति को PDF के रूप में सहेजें।
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint को पासवर्ड‑सुरक्षित PDF में परिवर्तित करें**

यह C++ कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के प्रोटेक्शन पैरामीटर का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड‑सुरक्षित PDF में कैसे परिवर्तित किया जाए:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions क्लास का उदाहरण बनाएं।
auto pdfOptions = MakeObject<PdfOptions>();

// PDF पासवर्ड और एक्सेस अनुमतियां सेट करें।
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// प्रस्तुति को PDF के रूप में सहेजें।
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास के तहत [set_WarningCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_warningcallback/) मेथड प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह C++ कोड दर्शाता है कि फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाया जाए:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

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
    // Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF विकल्पों में चेतावनी कॉलबैक सेट करें।
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // प्रस्तुति को PDF के रूप में सहेजें।
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

रेंडरिंग प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन के लिए कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए, देखें [फ़ॉन्ट प्रतिस्थापन के लिए वार्निंग कॉलबैक प्राप्त करना](/slides/hi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/) लेख।

{{% /alert %}} 

## **PowerPoint से PDF में चयनित स्लाइड्स को परिवर्तित करें**

यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति से केवल विशिष्ट स्लाइड्स को PDF में कैसे परिवर्तित किया जाए:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// स्लाइड नंबरों की एरे सेट करें।
auto slides = MakeArray<int32_t>({ 1, 3 });

// Save the presentation as a PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint को कस्टम स्लाइड आकार के साथ PDF में परिवर्तित करें**

यह C++ कोड दर्शाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाएं।
auto resizedPresentation = MakeObject<Presentation>();

// कस्टम स्लाइड आकार सेट करें।
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// मूल प्रस्तुति से पहली स्लाइड को क्लोन करें।
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// रिसाइज़्ड प्रस्तुति को नोट्स के साथ PDF में सहेजें।
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint को नोट्स स्लाइड व्यू में PDF में परिवर्तित करें**

यह C++ कोड दर्शाता है कि नोट्स सहित PDF बनाने के लिए PowerPoint प्रस्तुति को कैसे परिवर्तित किया जाए:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का उदाहरण बनाएं जो PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// PDF विकल्पों को नोट्स लेआउट के साथ कॉन्फ़िगर करें।
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// प्रस्तुति को नोट्स के साथ PDF में सहेजें।
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के साथ संगत है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C++ कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया दर्शाता है:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert title="ध्यान दें" color="warning" %}} 

Aspose.Slides PDF रूपांतरण कार्यों को समर्थन देता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल फ़ॉर्मेट्स में परिवर्तित कर सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-html/), [PDF से इमेज](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य PDF रूपांतरण कार्य—[PDF से SVG](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/hi/cpp/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **नोट:** PDF/UA में निर्यात करते समय, Aspose.Slides स्मार्टआर्ट, चार्ट और फ़ॉर्मूले जैसी जटिल ग्राफ़िक्स को एकल चित्र के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरे चित्र के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कई PowerPoint फ़ाइलों को बल्क में PDF में परिवर्तित कर सकता हूँ?

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटरिट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

### क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित किया जा सकता है?

बिल्कुल। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियाँ परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास का उपयोग कर सकते हैं।

### मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?

छिपी स्लाइड्स को शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास में `set_ShowHiddenSlides` मेथड का उपयोग करें।

### क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?

हाँ, आप `set_JpegQuality` और `set_SufficientResolution` जैसी विधियों का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/) क्लास में छवि गुणवत्ता को नियंत्रित कर सकते हैं, जिससे आपके PDF में उच्च‑गुणवत्ता वाली छवियाँ सुनिश्चित हों।

### क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?

हाँ, Aspose.Slides आपको PDF/A1a, PDF/A1b, और PDF/UA सहित विभिन्न मानकों के अनुरूप PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ अभिगम्यता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for C++ दस्तावेज़ीकरण](/slides/hi/cpp/)
- [Aspose.Slides for C++ API संदर्भ](https://reference.aspose.com/slides/hi/cpp/)
- [Aspose मुफ्त ऑनलाइन कन्वर्टर](https://products.aspose.app/slides/hi/conversion)