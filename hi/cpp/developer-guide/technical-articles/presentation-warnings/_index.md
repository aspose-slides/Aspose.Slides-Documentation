---
title: C++ में प्रस्तुति चेतावनियों को संभालना
type: docs
weight: 70
url: /hi/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- चेतावनी नीति
- डेटा हानि
- स्रोत भ्रष्टाचार
- संगतता समस्या
- फ़ॉन्ट प्रतिस्थापन
- डिजिटल हस्ताक्षर
- प्रेजेंटेशन लोडिंग
- प्रेजेंटेशन रेंडरिंग
- प्रेजेंटेशन रूपांतरण
- प्रेजेंटेशन सहेजना
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुतियों को लोड, रेंडर, रूपांतरित और सहेजते समय चेतावनियों को एकत्रित, वर्गीकृत और उनका कार्यान्वयन कैसे करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides लोड, रेंडर, कनवर्ट या सहेजते समय पुनर्प्राप्ती योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरणों में क्षतिग्रस्त स्रोत रिकॉर्ड, ऐसा कंटेंट जो संरक्षित नहीं किया जा सकता, फ़ॉन्ट प्रतिस्थापन, और लक्ष्य प्रारूप की सीमाएँ शामिल हैं। एक चेतावनी कॉलबैक एप्लिकेशन को इन स्थितियों को रिकॉर्ड करने और यह तय करने की अनुमति देता है कि वर्तमान ऑपरेशन जारी रह सकता है या नहीं।

[IWarningCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/iwarningcallback/) इंटरफ़ेस को लागू करें और [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) तथा [IWarningInfo::get_Description](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/iwarninginfo/get_description/) मेथड्स की जाँच करें जो [IWarningInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/iwarninginfo/) के माध्यम से उपलब्ध कराए जाते हैं। चेतावनी स्वीकार करने के लिए [ReturnAction::Continue](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/returnaction/) लौटाएँ या संचालन को रोकने के लिए `ReturnAction::Abort` लौटाएँ।

प्रेजेंटेशन खोलते समय उठी चेतावनियों के लिए [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_warningcallback/) का उपयोग करें। रेंडरिंग और एक्सपोर्ट ऑप्शन क्लासेस [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_warningcallback/) को विरासत में प्राप्त करती हैं, जो स्लाइड रेंडरिंग, कनवर्ज़न और सहेजने से जुड़ी चेतावनियों को प्राप्त करती है। चूँकि चेतावनी स्वयं एप्लिकेशन ऑपरेशन की पहचान नहीं करती, एक सम्मिलित रिपोर्ट बनाते समय प्रत्येक कॉलबैक इंस्टेंस को ऑपरेशन चरण के साथ संबद्ध करें।

## **चेतावनियां और अपवाद**

एक चेतावनी उस स्थिति को दर्शाती है जिससे Aspose.Slides `ReturnAction::Continue` लौटाने पर पुनः प्राप्त कर सकता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूरा नहीं हो सकता; अपवादों को चेतावनियों में परिवर्तित नहीं किया जाता और उन्हें चेतावनी नीति द्वारा संभाला नहीं जा सकता।

`ReturnAction::Abort` लौटाने पर चेतावनी डिस्पैचर वर्तमान ऑपरेशन को समाप्त करने के लिए एक अपवाद उठाता है। सार्वजनिक अपवाद ऑपरेशन और प्रेजेंटेशन फॉर्मेट पर निर्भर करता है। उदाहरण के लिए, लोडिंग के दौरान एक [PptxReadException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptreadexception/) उभर सकता है, जबकि सहेजने या एक्सपोर्ट करते समय एक [PptxException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxexception/) उभर सकता है। ऑपरेशन की सीमा पर अपवाद को हैंडल करें और यह निर्धारित करने के लिए चेतावनी रिपोर्ट का उपयोग करें कि क्या एप्लिकेशन नीति ने समाप्ति का कारण बना या नहीं, केवल एक अपवाद उपप्रकार या संदेश पर भरोसा न करें। कॉलबैक `ReturnAction::Abort` लौटाने से पहले चेतावनी को रिकॉर्ड करता है, जिससे कारण एप्लिकेशन के लिए उपलब्ध रहता है।

## **चेतावनी श्रेणियां**

[WarningType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/warningtype/) एनोमरेशन निम्नलिखित श्रेणियों को प्रदान करता है:

| चेतावनी प्रकार | अर्थ | सामान्य नीति |
| --- | --- | --- |
| `SourceFileCorruption` | स्रोत प्रस्तुति में भ्रष्टाचार है जो मूल प्रारूप में सहेजे गए दस्तावेज़ को अनुपयोगी बना सकता है। | रोकें। |
| `DataLoss` | लोड या सहेजने के बाद टेक्स्ट, चार्ट, छवि या अन्य डेटा अनुपलब्ध हो सकता है। | रोकें। |
| `MajorFormattingLoss` | प्रस्तुति महत्वपूर्ण फ़ॉर्मेटिंग खो सकती है। | सख्त सत्यापन मोड में रोकें; अन्यथा रिकॉर्ड करें और जारी रखें। |
| `MinorFormattingLoss` | सीमित फ़ॉर्मेटिंग अंतर हो सकता है। | निदान हेतु रिकॉर्ड करें और जारी रखें। |
| `CompatibilityIssue` | परिणाम कुछ एप्लिकेशन या पुराने संस्करणों में सही ढंग से नहीं खुल सकता या व्यवहार में अंतर आ सकता है। | लॉग करें और जारी रखें जब तक संगतता अनिवार्य न हो। |
| `UnexpectedContent` | स्रोत में असमर्थित या अज्ञात कंटेंट है जिसका प्रभाव अभी ज्ञात नहीं है। | रिकॉर्ड करें और जारी रखें, या सख्त नीति में इसे त्रुटि मानें। |

श्रेणी नीति निर्णय को संचालित करनी चाहिए। निदान के लिए चेतावनी विवरण संग्रहीत करें, लेकिन एप्लिकेशन लॉजिक में उसके शब्दांकन पर निर्भर न रहें क्योंकि संदेश पाठ चेतावनी परिदृश्यों और उत्पाद संस्करणों के बीच बदल सकता है।

## **चेतावनियों को एकत्रित और वर्गीकरण करें**

निम्न उदाहरण एक एप्लिकेशन-स्तरीय रिपोर्ट का उपयोग करता है जो पूर्ण प्रोसेसिंग पाइपलाइन को कवर करता है। एक अलग कॉलबैक इंस्टेंस लोडिंग, रेंडरिंग, PDF कनवर्ज़न और PPTX सहेजने से उत्पन्न चेतावनियों को लेबल करता है। नीति स्रोत भ्रष्टाचार या डेटा नुकसान पर रोक देती है, वैकल्पिक रूप से प्रमुख फ़ॉर्मेटिंग नुकसान पर रोक देती है, और अन्य चेतावनियों के लिए जारी रखती है।

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

`abortOnMajorFormattingLoss` को `false` सेट करें जब प्रमुख फ़ॉर्मेटिंग अंतर स्वीकार्य हों। संगतता मुद्दे, मामूली फ़ॉर्मेटिंग नुकसान, और अप्रत्याशित कंटेंट अभी भी रिपोर्ट में रखे जाते हैं भले ही ऑपरेशन जारी रहे। यदि एप्लिकेशन को इन श्रेणियों में से किसी को भी अस्वीकार करना हो तो `WarningPolicy::GetAction` को विस्तारित करें।

## **सामान्य चेतावनी परिदृश्य**

चेतावनियां वर्कफ़्लो के विभिन्न चरणों में प्रकट हो सकती हैं:

- **डिजिटल हस्ताक्षर:** एक साइन की गई प्रस्तुति लोडिंग के दौरान एक चेतावनी उत्पन्न कर सकती है कि उसका हस्ताक्षर प्रोसेसिंग के दौरान खो जाएगा। Aspose.Slides इस `DataLoss` स्थिति को [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/) के माध्यम से रिपोर्ट करता है। लोड-स्टेज कॉलबैक एप्लिकेशन को फ़ाइल को अस्वीकार करने या रिपोर्ट किए गए नुकसान को स्पष्ट रूप से स्वीकार करने की अनुमति देता है।
- **फ़ॉन्ट प्रतिस्थापन:** जब कोई फ़ॉन्ट उपलब्ध नहीं होता तो उसे स्लाइड रेंडर या एक्सपोर्ट करते समय बदला जा सकता है। फ़ॉन्ट प्रतिस्थापन चेतावनियां `DataLoss` के रूप में रिपोर्ट होती हैं, इसलिए ऊपर दी गई सख्त नीति भी तब रोक देती है जब एप्लिकेशन किसी विशेष प्रतिस्थापन को दृश्य रूप से स्वीकार्य मानता हो। इस व्यवहार को देखने के लिए ऐसी इनपुट प्रस्तुति उपयोग करें जिसमें ऐसा फ़ॉन्ट हो जो रन‑टाइम में उपलब्ध न हो। चेतावनी विवरण प्रतिस्थापन की पहचान करता है; आवश्यक फ़ॉन्ट्स या [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/cpp/font-substitution/) को कॉन्फ़िगर करके पुनः प्रयास करें।
- **असमर्थित या अप्रत्याशित कंटेंट:** लोडर ऐसी प्रस्तुति रिकॉर्ड या फीचर पा सकता है जो पहचान में नहीं आते। ऐसी चेतावनियां `UnexpectedContent` या अधिक गंभीर श्रेणी में हो सकती हैं जब डेटा या फ़ॉर्मेटिंग प्रभावित हो।
- **फ़ॉर्मेट संगतता:** किसी अन्य प्रस्तुति फ़ॉर्मेट में सहेजने पर फीचर छूट सकते हैं या परिणाम कुछ एप्लिकेशन में अलग व्यवहार दिखा सकते हैं। उदाहरण के लिए, आठ से अधिक क्षैतिज या ऊर्ध्वाधर ड्राइंग गाइड्स वाले प्रस्तुति को लेगसी PPT में सहेजने पर एक `CompatibilityIssue` रिपोर्ट होती है। सहेजने-स्टेज कॉलबैक नुकसान को रिकॉर्ड कर जारी रख सकता है, या यदि सभी गाइड्स को संरक्षित करना आवश्यक हो तो अस्वीकार कर सकता है।
- **लोडिंग व्यवहार:** लोडिंग विकल्प और लेगसी व्यवहार भी चेतावनियां उत्पन्न कर सकते हैं। उदाहरण के लिए, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) एक `CompatibilityIssue` के रूप में पुरानी प्रस्तुति‑लॉकिंग व्यवहार के उपयोग की पहचान करता है।

चेतावनियां स्रोत दस्तावेज़, लक्ष्य फ़ॉर्मेट, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करती हैं। यह न मानें कि हर फ़ाइल चेतावनी उत्पन्न करेगी या कोई परिदृश्य केवल एक ही श्रेणी में आएगा।

## **रोकिए गए संचालन को सुरक्षित रूप से संभालें**

जब कॉलबैक `ReturnAction::Abort` लौटाता है, तो उन ऑब्जेक्ट का उपयोग न करें जो लोड नहीं हुए और यह न मानें कि रेंडर या सहेजने का आउटपुट पूरा है। ऑपरेशन आउटपुट फ़ाइल बनाकर उसे पूरी तरह समाप्त होने से पहले समाप्त हो सकता है।

सत्यापित परिणामों को किसी अलग पथ जैसे `validated-output.pptx` में सहेजें। मौजूदा प्रस्तुति को तभी बदलें जब ऑपरेशन सफलतापूर्वक समाप्त हो, चेतावनी रिपोर्ट एप्लिकेशन नीति को संतुष्ट करे, और आउटपुट को खोला और जांचा जा सके। इससे अधूरे या अस्वीकृत परिणाम के साथ वैध स्रोत फ़ाइल को ओवरराइट करने से बचा जाता है।

एक खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि सभी स्रोत फीचर संरक्षित हैं। एप्लिकेशन द्वारा आवश्यक अतिरिक्त कंटेंट और दृश्य जांच लागू करें। देखें [प्रस्तुतियाँ खोलें](/slides/hi/cpp/open-presentation/) और [प्रस्तुतियाँ सहेजें](/slides/hi/cpp/save-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक चेतावनी कॉलबैक हर Aspose.Slides त्रुटि को संभाल सकता है?**

नहीं। यह केवल चेतावनियों के रूप में रिपोर्ट की गई पुनर्प्राप्ती योग्य स्थितियों को संभालता है। कॉलबैक से स्वतंत्र रूप से उत्पन्न अपवादों को लोडिंग, रेंडरिंग, कनवर्ज़न या सहेजने कॉल के चारों ओर एप्लिकेशन द्वारा संभालना चाहिए।

**क्या `ReturnAction::Continue` लौटाने से समान आउटपुट सुनिश्चित होता है?**

नहीं। यह केवल प्रोसेसिंग को जारी रखने की अनुमति देता है। रिपोर्ट की गई स्थिति अभी भी डेटा, फ़ॉर्मेटिंग या संगतता अंतर पैदा कर सकती है, इसलिए एकत्रित चेतावनी प्रकार और विवरण की समीक्षा करें।

**कैसे कोई एप्लिकेशन यह पहचान सकता है कि किस ऑपरेशन ने चेतावनी उत्पन्न की?**

प्रत्येक ऑपरेशन के लिए एक कॉलबैक इंस्टेंस बनाएं और चेतावनी प्रकार व विवरण के साथ एक एप्लिकेशन‑परिभाषित चरण को संग्रहीत करें, जैसा कि उदाहरण में दिखाया गया है।