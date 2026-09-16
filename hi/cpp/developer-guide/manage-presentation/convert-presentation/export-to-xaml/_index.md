---
title: C++ में प्रस्तुतियों को XAML में निर्यात करें
linktitle: प्रस्तुति को XAML में
type: docs
weight: 30
url: /hi/cpp/export-to-xaml/
keywords:
- PowerPoint निर्यात करें
- OpenDocument निर्यात करें
- प्रस्तुति निर्यात करें
- PowerPoint रूपांतरण करें
- OpenDocument रूपांतरण करें
- प्रस्तुति रूपांतरण करें
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें - एक तेज़, Office-रहित समाधान जो आपके लेआउट को अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रेज़ेंटेशन को XAML में निर्यात करने की प्रक्रिया समझाता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रेज़ेंटेशन को XAML में कैसे सहेजें, और निर्यात को [XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) के माध्यम से कैसे कस्टमाइज़ करें, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। यह लेख फॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी देता है।

## **XAML के बारे में**

XAML एक XML-आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसे फ्रेमवर्क में यूज़र इंटरफ़ेस का वर्णन करने के लिए किया जाता है।

आप XAML फ़ाइलों को विज़ुअल डिज़ाइनर में काम कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रेज़ेंटेशन निर्यात**

निम्नलिखित C++ उदाहरण डिफ़ॉल्ट सेटिंग्स के साथ प्रेज़ेंटेशन को XAML में निर्यात करने का तरीका दिखाता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइड्स प्रोसेस की वर्तमान कार्यशील डायरेक्टरी के `pres` सबफ़ोल्डर में सहेजी जाती हैं, जैसा कि [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/hi/cpp/system.io/directory/getcurrentdirectory/) द्वारा लौटाया जाता है। यह फ़ोल्डर स्वतः बनाया जाता है, और आवश्यक चित्र भी वहां सहेजे जाते हैं।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से बिना एक्सटेंशन के लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम से बनाई जाती हैं। यदि आप इनपुट प्रेज़ेंटेशन के लिए पूर्ण पथ भेजते हैं, तो आउटपुट फ़ोल्डर वर्तमान कार्यशील डायरेक्टरी के सापेक्ष बनाया जाता है, न कि इनपुट फ़ाइल के साथ।

## **कस्टम विकल्पों के साथ XAML में प्रेज़ेंटेशन निर्यात**

Aspose.Slides के द्वारा प्रेज़ेंटेशन को XAML में निर्यात करने के तरीके को नियंत्रित करने के लिए आप [IXamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/ixamloptions/) इंटरफ़ेस का उपयोग कर सकते हैं।

आउटपुट को कस्टम स्थान पर सहेजने के लिए, [IXamlOutputSaver](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/ixamloutputsaver/) को लागू करें और अपनी इम्प्लीमेंटेशन का एक इंस्टेंस [set_OutputSaver](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) मेथड में [XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) को पास करें।

छिपी स्लाइडों को XAML आउटपुट में शामिल करने के लिए, नीचे दिखाए गए C++ उदाहरण के अनुसार [set_ExportHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) मेथड को `true` पास करें:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **सभी उत्पन्न XAML वस्तुओं को कैप्चर करें**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़ के साथ अलग‑अलग चित्र और सहायक संसाधन भी बना सकता है। इन वस्तुओं को डिफ़ॉल्ट फ़ाइल‑सिस्टम सेवर के बजाय प्राप्त करने के लिए एक कस्टम [IXamlOutputSaver](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/ixamloutputsaver/) को [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) में पास करें। निर्यात को XAML‑विशिष्ट [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) ओवरलोड के साथ प्रारम्भ करें जो XAML विकल्प स्वीकार करता है।

### **कॉलबैक लाइफ़साइकल को समझें**

सेवर प्रत्येक उत्पन्न वस्तु के लिए [IXamlOutputSaver::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) को अलग‑अलग कॉल करता है:

- `path` वस्तु को पहचानता है और इसमें सापेक्ष डायरेक्टरी शामिल हो सकती हैं। इस जानकारी को रखें क्योंकि XAML सापेक्ष पाथ का उपयोग करके संसाधनों को संदर्भित कर सकता है।
- `data` में वस्तु के बाइट होते हैं। चित्र और अन्य बाइनरी संसाधनों को टेक्स्ट के रूप में डिकोड नहीं किया जाना चाहिए।
- सेवर को डेटा को लौटाने से पूर्व उसे बनाए रखने या स्थायी करने की ज़िम्मेदारी होती है। उदाहरण प्रत्येक बाइट एरे को एप्लिकेशन‑स्वामित्व वाले मेमोरी में कॉपी करते हैं।
- निर्यात को केवल तब सफल मानें जब प्रेज़ेंटेशन सहेजने का ऑपरेशन लौटता है और हर कॉलबैक सफलतापूर्वक पूरा हो चुका हो। स्टोरेज त्रुटियों को अनदेखा न करें या पृष्ठभूमि में अनदेखे लिखे शुरू न करें। यदि स्थायित्व बाद में होता है, तो कुल सफलता की रिपोर्ट केवल उसी चरण के सफल होने के बाद दें।

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) कस्टम सेवर पर भी लागू होता है। डिफ़ॉल्ट सेटिंग `false` छिपी‑स्लाइड XAML दस्तावेज़ों को बाहर रखती है। इसे `true` करने से वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गिनती प्रेज़ेंटेशन पर निर्भर करती है; एक स्लाइड पर एक कॉलबैक या स्थिर क्रम मानने से बचें।

### **मेमोरी में निर्यात करें और वस्तुओं का निरीक्षण करें**

यह पूर्ण उदाहरण `pres.pptx` को लोड करता है, प्रत्येक वस्तु को एक [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/hi/cpp/system.collections.generic/dictionary/) में इकट्ठा करता है, और उसका नाम, प्रकार तथा बाइट गिनती प्रिंट करता है। यह प्रदान किए गए नामों को बिल्कुल वैसा ही रखता है। डुप्लिकेट नाम संग्रह को विफल कर देते हैं, न कि चुपचाप वस्तु को अधिलिखित करते हैं।

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // केवल XAML को डिकोड करें, और केवल तभी जब पाठ्य निरीक्षण आवश्यक हो।
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

अपने एप्लिकेशन से `InMemoryXamlExample::Run` को कॉल करें। एक्सटेंशन जांच निरीक्षण के लिए उपयोगी हैं; सभी वस्तुएँ, जिसमें अपरिचित संसाधन प्रकार भी शामिल हैं, को रखें। स्टोर या ट्रांसमिट करते समय बाइट को जैसा है वैसा ही रखें। केवल उन XAML के लिए जिनमें टेक्स्ट प्रोसेसिंग आवश्यक है, UTF‑8 एन्कोडिंग के साथ [Encoding::GetString](https://reference.aspose.com/slides/hi/cpp/system.text/encoding/getstring/) का उपयोग करें।

### **संकलित वस्तुओं को ZIP अभिलेख में पैकेज करें**

यह स्वतंत्र उदाहरण निर्यात को इकट्ठा करता है, उसके नामों को मान्य करता है, और मूल बाइट को ZIP अभिलेख में लिखता है। एक विशिष्ट अभिलेख नाम समानांतर निर्यात कार्यों को अलग करता है। ZIP प्रविष्टियों में फॉरवर्ड स्लैश का प्रयोग होता है और सापेक्ष डायरेक्टरी बरकरार रहती है। अनसेफ़ नाम या सामान्यीकरण के बाद टकराने वाले नाम पूरे पैकेज को लिखे जाने से पहले ही अस्वीकृत कर देते हैं।

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // सेव ZIP डायरेक्टरी को अंतिम रूप देता है; सफलता की रिपोर्ट करने से पहले फ़ाइल को बंद करें।
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

अपने एप्लिकेशन से `ZipXamlExample::Run` को कॉल करें। यह उदाहरण C++ रन‑टाइम की `Aspose::Zip::ZipFile` का उपयोग करके एक स्थानीय अभिलेख बनाता है; निर्यातकर्ता स्वयं ढीली XAML या चित्र फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए, अभिलेख‑लेखन चरण को संग्रहीत बाइट एरे की अपलोड से बदलें। निर्यात‑कार्य पहचानकर्ता के साथ पूर्ण सापेक्ष वस्तु नाम को ब्लॉब कुंजी के रूप में उपयोग करें, या कार्य पहचानकर्ता, सापेक्ष नाम, तथा बाइनरी डेटा को डेटाबेस पंक्ति में संग्रहीत करें। सभी अपलोड पूर्ण या डेटाबेस ट्रांज़ैक्शन कमिट होने के बाद ही कार्य को प्रकाशित करें। यदि स्थायित्व विफल हो तो आंशिक आउटपुट को साफ़ करें।

बड़ी प्रेज़ेंटेशन के लिए, एक कस्टम सेवर प्रत्येक वस्तु को सीधे एप्लिकेशन स्टोरेज में स्थायी कर सकता है जिससे संपूर्ण निर्यात की अतिरिक्त प्रतिलिपि मेमोरी में रखने की आवश्यकता नहीं रहती। निर्यातकर्ता अभी भी सभी उत्पन्न वस्तुओं को मेमोरी में इकट्ठा करता है, फिर सेवर को कॉल करता है। प्रत्येक कॉलबैक को निर्यातकर्ता के दृष्टिकोण से सिंक्रोनस रखें: बाइट स्वीकार किए जाने के बाद ही रिटर्न करें, और त्रुटियों को कॉलर तक पहुँचने दें।

### **संसाधन नामों को संरक्षित रखें और संदर्भों की जाँच करें**

- यदि गंतव्य को आवश्यकता हो तो पाथ सेपरेटर्स को सामान्यीकृत करें, लेकिन सापेक्ष डायरेक्टरी को बरकरार रखें। केवल तब तक [Path::GetFileName](https://reference.aspose.com/slides/hi/cpp/system.io/path/getfilename/) का प्रयोग न करें जब तक प्रत्येक उत्पन्न नाम की अनोखापन व संसाधन संदर्भ वैधता सुनिश्चित न हो जाए।
- गंतव्य‑विशिष्ट नाम सत्यापन लागू करें। ढीली फ़ाइलें लिखते समय, रूटेड पाथ और ट्रैवर्सल सेगमेंट को अस्वीकार करें, गंतव्य को [Path::GetFullPath](https://reference.aspose.com/slides/hi/cpp/system.io/path/getfullpath/) से हल करें, और यह जाँचें कि यह इच्छित निर्यात डायरेक्टरी के भीतर बना रहे, जिसमें containment‑जाँच में डायरेक्टरी सेपरेटर को शामिल किया गया हो। अभिलेख‑लेखन को ऐसे डायरेक्टरी में रखें जहाँ सिंबलिक लिंक न हों जो लिखने को पुनर्निर्देशित कर सकें।
- प्रत्येक निर्यात कार्य के लिए अलग‑अलग सेवर और स्टोरेज नेमस्पेस का प्रयोग करें। सेपरेटर सामान्यीकरण के बाद तथा गंतव्य की केस‑संवेदनशीलता नियमों के अनुसार टकराव का पता लगाएँ।
- प्रकाशित करने से पहले प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसकी फ़ाइल‑आधारित संसाधन संदर्भों—जैसे चित्र `Source` या `ImageSource` एट्रिब्यूट—की जाँच करें। प्रत्येक सापेक्ष URI को सम्मिलित XAML वस्तु की डायरेक्टरी के विरुद्ध हल करें, परिणामी स्टोरेज नाम को सामान्यीकृत करें, और सुनिश्चित करें कि संबंधित डिक्शनरी कुंजी, ZIP प्रविष्टि, या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्क‑अप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग‑अलग संभालें।

उदाहरण के तौर पर, यदि `pres/Slide_1.xaml` में `images/image1.png` का संदर्भ है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखना इस संबंध को तोड़ देगा। ऑब्जेक्ट स्टोरेज के लिये, कार्य उपसर्ग के तहत समान लेआउट बनाये रखें और उन संसाधन URLs को XAML उपभोक्ता के लिये सुलभ बनाएँ। पूर्ण ZIP को फिर से खोलें और प्रविष्टि नाम तथा संसाधन बाइट्स की जाँच करें, तथा लक्ष्य XAML पर्यावरण में नमूना स्लाइड लोड कर यह सत्यापित करें कि चित्र सही ढंग से हल हो रहे हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं फ़ॉन्ट की भविष्यवाणी कैसे सुनिश्चित करूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) में [set_DefaultRegularFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) का उपयोग करें — यह निर्यात के दौरान मूल फ़ॉन्ट के अभाव में एक फॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। यह गारंटी नहीं देता कि उत्पन्न XAML फॉलबैक फ़ॉन्ट को संदर्भित करेगा या फ़ॉन्ट लक्ष्य मशीन पर उपलब्ध होगा। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट उस वातावरण में उपलब्ध हों जहाँ यह प्रदर्शित होगा।

**क्या निर्यात किया गया XAML केवल WPF के लिये है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

Aspose.Slides सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। UWP और Xamarin.Forms जैसे अन्य XAML स्टैक्स के साथ संगतता गारंटी नहीं है। उत्पन्न मार्कअप का लक्ष्य पर्यावरण में परीक्षण करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकें?**

डिफ़ॉल्ट रूप से, छिपी स्लाइडें शामिल नहीं होतीं। आप इस व्यवहार को [XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) में [set_ExportHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) के माध्यम से नियंत्रित कर सकते हैं — यदि आपको उन्हें निर्यात करने की आवश्यकता नहीं है तो इसे अक्षम रखें।