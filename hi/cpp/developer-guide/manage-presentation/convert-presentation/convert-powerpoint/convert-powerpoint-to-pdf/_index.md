---
title: C++ में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ सम्मिलित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- PowerPoint से PDF
- प्रेज़ेंटेशन से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
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
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **परिचय**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को C++ में PDF प्रारूप में बदलने से कई लाभ मिलते हैं, जिसमें विभिन्न उपकरणों के बीच संगतता और प्रस्तुति का लेआउट व फ़ॉर्मेटिंग बनाए रखना शामिल है। यह गाइड यह दर्शाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित किया जाए, छवि गुणवत्ता को नियंत्रित करने के विभिन्न विकल्पों का उपयोग कैसे किया जाए, छिपी स्लाइड्स को शामिल किया जाए, PDF फ़ाइलों को पासवर्ड‑सुरक्षित कैसे बनाया जाए, फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाया जाए, परिवर्तन के लिए विशिष्ट स्लाइड्स का चयन कैसे किया जाए, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को कैसे लागू किया जाए।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित स्वरूपों की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) वर्ग में तर्क के रूप में पास करें और फिर प्रस्तुति को PDF के रूप में [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) विधि का उपयोग करके सहेजें। [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) वर्ग वह [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) विधि प्रदान करता है, जिसे आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या सम्मिलित करता है। उदाहरण के लिए, जब प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides *Application* फ़ील्ड को "*Aspose.Slides*" और *PDF Producer* फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को आउटपुट दस्तावेज़ों से बदलने या हटाने के लिए निर्देशित नहीं कर सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूपांतरण करने देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे उत्पन्न PDF मूल प्रस्तुति के बहुत निकट मिलता है। रूपांतरण के दौरान तत्व और विशेषताएँ सटीक रूप से रेंडर होती हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है और सभी दृश्यमान स्लाइड्स को डिफ़ॉल्ट निर्यात सेटिंग्स के साथ PDF में सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप इस कन्वर्टर के साथ परीक्षण करके यहाँ वर्णित प्रक्रिया को वास्तविक रूप में देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) वर्ग के अंतर्गत प्रॉपर्टीज़—प्रदान करता है, जिससे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या रूपांतरण प्रक्रिया के प्रवाह को निर्धारित कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग, मेटाफाइल्स के हैंडलिंग, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI आदि को परिभाषित कर सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF 1.5 में निर्यात करता है, जिसमें JPEG गुणवत्ता 90, छवि रिज़ॉल्यूशन 300 DPI, मेटाफाइल्स PNG के रूप में सहेजे गए, और Flate टेक्स्ट संपीड़न लागू है।

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **एम्बेडेड OLE फ़ाइलों को PDF संलग्नक के रूप में संरक्षित करें**

यदि प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप चाहते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा भी देख सके। इस हेतु `[PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/)` को `true` के साथ कॉल करें ताकि एम्बेडेड OLE फ़ाइलें परिणामस्वरूप PDF में संलग्नक के रूप में बनी रहें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू छवि या आइकन PDF पृष्ठ पर रेंडर होती है, परंतु उसका एम्बेडेड फ़ाइल संलग्नक के रूप में नहीं होती। विकल्प को `true` करने से फ़ाइल डेटा अतिरिक्त रूप से शामिल हो जाता है। प्रीव्यू केवल दृश्य प्रतिनिधित्व रहता है; संलग्नक प्राप्तकर्ता को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पृष्ठ पर इंटरैक्टिव Excel शीट नहीं बनता।

निम्नलिखित उदाहरण एक ऐसी प्रस्तुति को लोड करता है जिसमें पहले से एम्बेडेड Excel वर्कबुक है और उसे PDF के साथ वर्कबुक संलग्नक के रूप में निर्यात करता है।

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

परिणाम की जाँच करने के लिए:

1. ऐसी व्यूअर में निर्यातित PDF खोलें जो फ़ाइल संलग्नकों का समर्थन करता हो, जैसे Adobe Acrobat Reader।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें।
3. संलग्नक को सहेजें और Excel में खोलेँ ताकि डेटा निरीक्षण किया जा सके, या यदि व्यूअर अनुमति देता हो तो सीधे खोलें। PDF पृष्ठ पर प्रीव्यू संलग्नक से अलग रहता है।

{{% alert color="info" title="Note" %}}

PDF/A मानक संलग्नकों पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A संलग्नकों की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जिसमें Excel वर्कबुक भी शामिल हैं, की अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, न कि Aspose.Slides की विशेष प्रतिबंध। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दिखाता।

{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) वर्ग की [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) विधि का उपयोग करके छिपी स्लाइड्स को उत्पन्न PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, जिसमें सभी छिपी स्लाइड्स शामिल होती हैं।

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति को PDF के रूप में निर्यात करता है, जिसे खोलने के लिए `password` पासवर्ड आवश्यक है। एक्सेस अनुमतियों में प्रिंटिंग, जिसमें उच्च‑गुणवत्ता प्रिंटिंग शामिल है, की अनुमति है।

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) वर्ग के तहत [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) विधि प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है और कंसोल पर फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रदर्शित करता है। चेतावनी केवल तब प्रदर्शित होती है जब कोई अनुपलब्ध फ़ॉन्ट निर्यात के दौरान प्रतिस्थापित किया जाता है।

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें लेख [Font Substitution](/slides/hi/cpp/font-substitution/)।

{{% /alert %}} 

## **चयनित स्लाइड्स को PowerPoint से PDF में बदलें**

निम्नलिखित उदाहरण प्रस्तुति की स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड संख्याएँ 1‑आधारित हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड्स होनी चाहिए।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

निम्नलिखित उदाहरण पहली स्लाइड को 612 × 792 पॉइंट (8.5 × 11 इंच) के स्लाइड आकार वाले नए प्रस्तुति में कॉपी करता है। यह स्लाइड सामग्री को स्केल करता है ताकि फिट हो, और एकल स्लाइड को PDF में निर्यात करता है।

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **नोट्स स्लाइड दृश्य में PDF के साथ PowerPoint को बदलें**

निम्नलिखित उदाहरण प्रस्तुति को PDF में निर्यात करता है, जहाँ प्रत्येक स्लाइड के स्पीकर नोट्स स्लाइड के नीचे रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **PDF के लिए पहुँच और अनुपालन मानक**

Aspose.Slides आपको ऐसा रूपांतरण प्रक्रिया उपयोग करने देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के साथ संगत हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए इन अनुपालन मानकों में से किसी का उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह C++ कोड विभिन्न अनुपालन मानकों के आधार पर कई PDF उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

```cpp
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

{{% alert color="info" title="Note" %}}

Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। विशेष स्वरूपों के लिए अन्य PDF रूपांतरण कार्य—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **ध्यान दें:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फ़ॉर्मूलों को एकल चित्र के रूप में मानता है। व्यक्तिगत पाथ तत्व अलग-अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरे चित्र के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को बैच‑रूप में PDF में बदलने का समर्थन करता है। आप अपने फ़ाइलों पर क्रमशः इटररेट करके रूपांतरण प्रक्रिया को प्रोग्रामैटिक रूप से लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित बनाया जा सकता है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) वर्ग का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

आप [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) वर्ग में [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) विधि का उपयोग करके उत्पन्न PDF में छिपी स्लाइड्स को शामिल कर सकते हैं।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) वर्ग में [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) और [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) जैसी विधियों का उपयोग करके अपने PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको ऐसे PDF निर्यात करने देता है जो विभिन्न मानकों, जैसे PDF/A1a, PDF/A1b, और PDF/UA, के अनुरूप हों, जिससे आपके दस्तावेज़ पहुँचयोग्य और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for C++ Documentation](/slides/hi/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)