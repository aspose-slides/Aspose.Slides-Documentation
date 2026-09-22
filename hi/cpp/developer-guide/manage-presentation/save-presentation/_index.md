---
title: C++ में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/cpp/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश
- सहेजने की प्रगति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट तथा प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **अवलोकन**

प्रस्तुति बनाने के बाद या किसी मौजूदा प्रस्तुति को [खोलने](/slides/hi/cpp/open-presentation/) के बाद, परिणाम लिखने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड का उपयोग करें। Aspose.Slides for C++ एक प्रस्तुति को PowerPoint, OpenDocument, PDF और अन्य स्वरूपों में फ़ाइल या स्ट्रीम पर सहेज सकता है। निम्नलिखित अनुभाग मानक सहेजने के संचालन और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रस्तुति सहेजें**

फ़ाइल में प्रस्तुति सहेजने के लिए, आउटपुट पथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) मान को [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड में पास करें। फ़ॉर्मेट मान निर्धारित करता है कि Aspose.Slides किस प्रकार की फ़ाइल बनाएगा।

निम्नलिखित उदाहरण एक प्रस्तुति बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// यहाँ प्रस्तुति की सामग्री जोड़ें या संशोधित करें।

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **मूल स्वरूप में प्रस्तुतियों को सहेजें**

फ़ाइल और स्ट्रीम पहचान उदाहरणों, नवीन निर्मित प्रस्तुतियों के व्यवहार, तथा स्रोत और आउटपुट स्वरूपों के अंतर के लिए देखें [Determine the Original Presentation Format](/slides/hi/cpp/detect-presentation-source-format/)।

बैच‑प्रसंस्करण अनुप्रयोग में इनपुट स्वरूप पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, उसके मूल स्वरूप को [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sourceformat/) के साथ पढ़ें। प्राप्त [SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sourceformat/) मान को [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/tosaveformat/) को पास करें ताकि संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) मान प्राप्त हो सके, और फिर संशोधित प्रस्तुति को लिखने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) का उपयोग करें।

निम्नलिखित पूर्ण उदाहरण इनपुट निर्देशिका की प्रत्येक फ़ाइल को प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और उसे उसी स्वरूप में आउटपुट निर्देशिका में सहेजता है जिससे वह लोड किया गया था:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/tosaveformat/) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रस्तुति सहेजने के स्वरूपों से मिलाता है। यह केवल प्रस्तुति स्रोत स्वरूपों को मैप करता है; यह PDF, HTML, TIFF या छवि जैसे निर्यात स्वरूपों को चुनने के लिए नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sourceformat/) मान पास करने पर एक [ArgumentException](https://reference.aspose.com/slides/hi/cpp/system/argumentexception/) उत्पन्न होता है।

Legacy PPT, PPS, और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रस्तुति को फ़ाइल एक्सटेंशन के बिना स्ट्रीम से लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन पुराने उप‑प्रकारों को संरक्षित करना आवश्यक है, तो मूल फ़ाइलनाम या स्वरूप मेटाडेटा को अलग से रखें और आउटपुट फ़ाइलनाम तथा स्वरूप चुनते समय उसका उपयोग करें।

## **स्ट्रीम्स में प्रस्तुतियों को सहेजें**

अंतिम फ़ाइल पथ पर निर्भर हुए बिना प्रस्तुति लिखने के लिए, एक लिखने योग्य [Stream](https://reference.aspose.com/slides/hi/cpp/system.io/stream/) और एक [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) मान को [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड में पास करें। यह तरीका तब उपयोगी होता है जब आउटपुट को वेब सर्विस से लौटाना हो, डेटाबेस में संग्रहित करना हो, या मेमोरी में प्रोसेस करना हो।

निम्नलिखित उदाहरण एक नई प्रस्तुति को फ़ाइल स्ट्रीम में सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

आप सहेजी गई प्रस्तुति को PowerPoint द्वारा प्रारंभिक रूप से खोलते समय दृश्य निर्दिष्ट कर सकते हैं। सहेजने से पहले एक [ViewType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewtype/) मान के साथ [ViewProperties::set_LastView](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/set_lastview/) को कॉल करें।

निम्नलिखित उदाहरण Slide Master दृश्य को प्रारंभिक दृश्य के रूप में कॉन्फ़िगर करता है:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **स्ट्रिक्ट Office Open XML स्वरूप में प्रस्तुतियों को सहेजें**

Office Open XML के स्ट्रिक्ट प्रोफ़ाइल के अनुरूप PPTX फ़ाइल बनाने के लिए, एक [PptxOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/) इंस्टेंस बनाएं और `Conformance::Iso29500_2008_Strict` के साथ [PptxOptions::set_Conformance](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/set_conformance/) को कॉल करें। फिर विकल्पों को [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड को पास करें।

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **ZIP64 मोड में Office Open XML स्वरूप में प्रस्तुतियों को सहेजें**

एक मानक ZIP संग्रह प्रत्येक प्रविष्टि के संकुचित और असंकुचित आकार, कुल संग्रह आकार, तथा प्रविष्टियों की संख्या को सीमित करता है। चूंकि PPTX फ़ाइल एक ZIP संग्रह है, एक बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन लागू आकार और प्रविष्टि‑गणना सीमाओं को बढ़ाते हैं।

[ PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) का उपयोग करके निर्धारित करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- `IfNecessary` केवल तब ZIP64 का उपयोग करता है जब प्रस्तुति मानक ZIP सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` ZIP64 एक्सटेंशन को अक्षम करता है।
- `Always` हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्नलिखित उदाहरण आउटपुट प्रस्तुति के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
यदि `Zip64Mode` को `Never` सेट किया जाता है और प्रस्तुति मानक ZIP सीमाओं में फिट नहीं होती, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxexception/) फेंकेगा।
{{% /alert %}}

## **कम्प्रेशन स्तर के साथ Office Open XML स्वरूप में प्रस्तुतियों को सहेजें**

PPTX आउटपुट के लिए, आप [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) को कॉल करके सहेजने की गति और फ़ाइल आकार के बीच संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/compressionlevel/) enumeration निम्न मान प्रदान करती है:

- `None` डेटा को बिना कम्प्रेशन के संग्रहीत करता है।
- `Level1` सबसे तेज़ कम्प्रेशन और सबसे बड़ा संकुचित आउटपुट प्रदान करता है।
- `Level2` से `Level5` क्रमशः सहेजने की गति की तुलना में छोटे आउटपुट को प्राथमिकता देते हैं।
- `Level6` सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट स्तर है।
- `Level7` और `Level8` छोटे आउटपुट को अधिक प्राथमिकता देते हैं।
- `Level9` सबसे मजबूत कम्प्रेशन प्रदान करता है और सबसे अधिक प्रक्रिया समय लेता है।

निम्नलिखित उदाहरण बिना कम्प्रेशन के एक प्रस्तुति सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

निम्नलिखित उदाहरण अधिकतम कम्प्रेशन स्तर का उपयोग करता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **थंबनेल रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

जब प्रस्तुति को PPTX के रूप में सहेजा जाता है, तो [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) उसके दस्तावेज़ थंबनेल को नियंत्रित करता है:

- `true` सहेजने के दौरान थंबनेल को पुनः उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `false` मौजूदा थंबनेल को संरक्षित रखता है। यदि प्रस्तुति में थंबनेल नहीं है, तो Aspose.Slides नया थंबनेल नहीं बनाता।

निम्नलिखित उदाहरण थंबनेल को रीफ़्रेश किए बिना प्रस्तुति सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
थंबनेल रीफ़्रेश को अक्षम करने से PPTX फ़ाइल को सहेजने में लगने वाले समय को कम किया जा सकता है।
{{% /alert %}}

## **प्रति प्रतिशत में सहेजने की प्रगति अपडेट करें**

सहेजने के ऑपरेशन की निगरानी करने के लिए, [IProgressCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करें और उसे [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isaveoptions/set_progresscallback/) को पास करें। Aspose.Slides तब निर्यात के दौरान प्रगति मूल्यों के साथ [IProgressCallback::Reporting](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprogresscallback/reporting/) को कॉल करता है।

निम्नलिखित उदाहरण PDF निर्यात की प्रगति को कंसोल पर रिपोर्ट करता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose एक निःशुल्क [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जो Aspose.Slides API के साथ निर्मित है। यह प्रस्तुति के चयनित स्लाइड्स को अलग-अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides इन्क्रिमेंटल या “फास्ट सेव” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने का ऑपरेशन पूरी आउटपुट फ़ाइल लिखता है, न कि केवल बदले हुए भागों को।

**क्या कई थ्रेड एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/cpp/multithreading/)। प्रत्येक इंस्टेंस तक केवल एक थ्रेड ही एक समय में पहुंच और सहेज सकता है।

**जब मैं प्रस्तुति सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक्ड फ़ाइलों का क्या होता है?**

[हाइपरलिंक](/slides/hi/cpp/manage-hyperlinks/) प्रस्तुति में बने रहते हैं। Aspose.Slides बाहरी लिंक्ड फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजी गई प्रस्तुति को अभी भी उनके स्थानों तक पहुंचना चाहिए।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसी दस्तावेज़ मेटाडेटा सहेज सकता हूँ?**

हाँ। सहेजने से पहले उचित [दस्तावेज़ प्रॉपर्टीज़](/slides/hi/cpp/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिख देगा।