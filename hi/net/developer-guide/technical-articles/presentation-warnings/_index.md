---
title: ".NET में प्रस्तुति चेतावनियों को संभालें"
type: docs
weight: 120
url: /hi/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- चेतावनी नीति
- डेटा हानि
- स्रोत भ्रष्टाचार
- संगतता समस्या
- फ़ॉन्ट प्रतिस्थापन
- डिजिटल हस्ताक्षर
- प्रस्तुति लोडिंग
- प्रस्तुति रेंडरिंग
- प्रस्तुति रूपांतरण
- प्रस्तुति सहेजना
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रस्तुतियों को लोड, रेंडर, परिवर्तित और सहेजते समय चेतावनियों को एकत्रित, वर्गीकृत और कार्य करने के बारे में जानें।"
---
## **परिचय**

Aspose.Slides लोड, रेंडर, परिवर्तित या प्रस्तुति सहेजते समय पुनर्प्राप्त योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरण में भ्रष्ट स्रोत रिकॉर्ड, ऐसी सामग्री जो संरक्षित नहीं की जा सकती, फ़ॉन्ट प्रतिस्थापन, और लक्षित स्वरूप की सीमाएं शामिल हैं। एक warning कॉलबैक अनुप्रयोग को इन स्थितियों को रिकॉर्ड करने और यह तय करने की अनुमति देता है कि वर्तमान ऑपरेशन जारी रखा जा सकता है या नहीं।

[IWarningCallback](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/iwarningcallback/) इंटरफ़ेस को लागू करें और [WarningType](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/iwarninginfo/warningtype/) और [Description](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/iwarninginfo/description/) प्रॉपर्टीज़ की जांच करें जो [IWarningInfo](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/iwarninginfo/) के माध्यम से प्रदान की गई हैं। चेतावनी को स्वीकार करने के लिए [ReturnAction.Continue](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/returnaction/) लौटाएँ या ऑपरेशन को रोकने के लिए `ReturnAction.Abort` करें।

[LoadOptions.WarningCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/warningcallback/) का उपयोग करें चेतावनियों के लिए जो प्रस्तुति खोलते समय उठती हैं। रेंडरिंग और निर्यात विकल्प क्लासेज़ [SaveOptions.WarningCallback](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/warningcallback/) को इनहेरिट करती हैं, जो स्लाइड रेंडरिंग, परिवर्तन, और सहेजने से चेतावनियां प्राप्त करती हैं। क्योंकि चेतावनी स्वयं एप्लिकेशन ऑपरेशन को पहचानती नहीं है, संयोजित रिपोर्ट बनाते समय प्रत्येक कॉलबैक इंस्टेंस को एक ऑपरेशन चरण के साथ जोड़ें।

## **चेतावनियां और अपवाद**

एक चेतावनी ऐसी स्थिति का वर्णन करती है जिससे Aspose.Slides पुनर्प्राप्त हो सकता है यदि कॉलबैक `ReturnAction.Continue` लौटाता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूरा नहीं हो सकता; अपवादों को चेतावनियों में परिवर्तित नहीं किया जाता और उन्हें चेतावनी नीति द्वारा संभाला नहीं जा सकता।

`ReturnAction.Abort` लौटाने पर चेतावनी डिस्पैचर को एक अपवाद उठाकर वर्तमान ऑपरेशन को समाप्त करने को कहा जाता है। सार्वजनिक अपवाद ऑपरेशन और प्रस्तुति स्वरूप पर निर्भर करता है। उदाहरण के लिए, लोडिंग के दौरान एक [PptxReadException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptreadexception/) उत्पन्न हो सकता है, जबकि सहेजने या निर्यात करने पर एक [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) उत्पन्न हो सकता है। ऑपरेशन की सीमा पर अपवाद को संभालें और यह निर्धारित करने के लिए चेतावनी रिपोर्ट का उपयोग करें कि क्या अनुप्रयोग नीति ने समाप्ति का कारण बना, न कि केवल एक अपवाद उपप्रकार या संदेश पर निर्भर रहें। `ReturnAction.Abort` लौटाने से पहले कॉलबैक चेतावनी को रिकॉर्ड करता है, जिससे कारण अनुप्रयोग के लिए उपलब्ध रहता है।

## **चेतावनी श्रेणियां**

[WarningType](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/warningtype/) एन्यूमरेशन निम्नलिखित श्रेणियां प्रदान करता है:

| चेतावनी प्रकार | अर्थ | सामान्य नीति |
| --- | --- | --- |
| `SourceFileCorruption` | स्रोत प्रस्तुति में भ्रष्टाचार है जो मूल स्वरूप में सहेजी गई दस्तावेज़ को अनुपयोगी बना सकता है। | रोकें। |
| `DataLoss` | पाठ, चार्ट, चित्र, या अन्य डेटा लोड या सहेजने के बाद अनुपस्थित हो सकता है। | रोकें। |
| `MajorFormattingLoss` | प्रस्तुति महत्वपूर्ण फ़ॉर्मेटिंग खो सकती है। | सख्त मान्यता मोड में रोकें; अन्यथा रिकॉर्ड करें और जारी रखें। |
| `MinorFormattingLoss` | एक सीमित फ़ॉर्मेटिंग अंतर हो सकता है। | डायग्नॉस्टिक के लिए रिकॉर्ड करें और जारी रखें। |
| `CompatibilityIssue` | परिणाम कुछ अनुप्रयोगों या पुराने संस्करणों में नहीं खुलेगा या सही तरीके से काम नहीं करेगा। | लॉग करें और जारी रखें जब तक संगतता अनिवार्य न हो। |
| `UnexpectedContent` | स्रोत में असमर्थित या अपरिचित कंटेंट है जिसका प्रभाव अभी ज्ञात नहीं है। | रिकॉर्ड करें और जारी रखें, या सख्त नीति में इसे त्रुटि मानें। |

श्रेणी को नीति निर्णय को संचालित करना चाहिए। डायग्नॉस्टिक के लिए `Description` को संग्रहीत करें, लेकिन एप्लिकेशन लॉजिक के लिए उसके शब्दांकन पर निर्भर न हों क्योंकि संदेश पाठ चेतावनी परिदृश्यों और उत्पाद संस्करणों के बीच भिन्न हो सकता है।

## **चेतावनियों को एकत्रित और वर्गीकृत करें**

निम्नलिखित उदाहरण संपूर्ण प्रोसेसिंग पाइपलाइन के लिए एक एप्लिकेशन-स्तर की रिपोर्ट का उपयोग करता है। एक अलग कॉलबैक इंस्टेंस लोडिंग, रेंडरिंग, PDF परिवर्तित करने और PPTX सहेजने से चेतावनियों को लेबल करता है। नीति स्रोत भ्रष्टाचार या डेटा हानि पर रोक देती है, वैकल्पिक रूप से बड़े फ़ॉर्मेटिंग नुकसान पर रोक देती है, और अन्य चेतावनियों के लिए जारी रहती है।

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

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
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```


`abortOnMajorFormattingLoss` को `false` सेट करें जब बड़े फ़ॉर्मेटिंग अंतर स्वीकार्य हों। संगतता मुद्दे, छोटे फ़ॉर्मेटिंग नुकसान, और अप्रत्याशित कंटेंट अभी भी रिपोर्ट में रखे जाते हैं भले ही ऑपरेशन जारी रहे। यदि एप्लिकेशन को इन में से किसी भी श्रेणी को अस्वीकार करना आवश्यक हो तो `WarningPolicy.GetAction` को विस्तारित करें।

## **सामान्य चेतावनी परिदृश्य**

चेतावनियां कार्य प्रवाह के विभिन्न चरणों पर प्रकट हो सकती हैं:

- **डिजिटल हस्ताक्षर:** एक हस्ताक्षरित प्रस्तुति लोडिंग के दौरान एक चेतावनी उत्पन्न कर सकता है कि उसका हस्ताक्षर प्रोसेसिंग के दौरान खो जाएगा। Aspose.Slides इस `DataLoss` स्थिति को [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/ipresentationsignedwarninginfo/) के माध्यम से रिपोर्ट करता है। एक लोड-स्टेज कॉलबैक एप्लिकेशन को फ़ाइल को अस्वीकार करने या रिपोर्ट किए गए नुकसान को स्पष्ट रूप से स्वीकार करने की अनुमति देता है।
- **फ़ॉन्ट प्रतिस्थापन:** एक अनुपलब्ध फ़ॉन्ट को स्लाइड रेंडर या निर्यात करते समय प्रतिस्थापित किया जा सकता है। फ़ॉन्ट प्रतिस्थापन चेतावनियां `DataLoss` के रूप में रिपोर्ट की जाती हैं, इसलिए ऊपर की सख्त नीति रोक देती है भले ही एप्लिकेशन किसी विशिष्ट प्रतिस्थापन को दृश्य रूप से स्वीकार्य मानता हो। इस व्यवहार को देखने के लिए, एक इनपुट प्रस्तुति का उपयोग करें जिसमें ऐसे फ़ॉन्ट में टेक्स्ट हो जो रनटाइम में उपलब्ध न हो। चेतावनी विवरण प्रतिस्थापन को पहचानता है; पुनः प्रयास करने से पहले आवश्यक फ़ॉन्ट्स या [font substitution rules](/slides/hi/net/font-substitution/) कॉन्फ़िगर करें।
- **असमर्थित या अप्रत्याशित कंटेंट:** एक लोडर प्रस्तुति रिकॉर्ड या फीचर्स से मिल सकता है जिन्हें वह पहचान नहीं पाता। ऐसी चेतावनियां `UnexpectedContent` का उपयोग कर सकती हैं, या यदि डेटा या फ़ॉर्मेटिंग पर प्रभाव ज्ञात हो तो अधिक गंभीर श्रेणी हो सकती है।
- **फ़ॉर्मेट संगतता:** किसी अन्य प्रस्तुति स्वरूप में सहेजने से फीचर्स हट सकते हैं या ऐसा परिणाम बन सकता है जो कुछ अनुप्रयोगों में अलग ढंग से काम करता हो। उदाहरण के लिए, आठ से अधिक क्षैतिज या आठ से अधिक लंबवत ड्रॉइंग गाइड्स के साथ प्रस्तुति को पुराने PPT में सहेजने पर `CompatibilityIssue` रिपोर्ट होती है। सेव-स्टेज कॉलबैक नुकसान को रिकॉर्ड कर सकता है और जारी रख सकता है, या यदि सभी गाइड्स को संरक्षित करना आवश्यक हो तो इसे अस्वीकार कर सकता है।
- **लोडिंग व्यवहार:** लोडिंग विकल्प और लेगेसी व्यवहार भी चेतावनियां उत्पन्न कर सकते हैं। उदाहरण के लिए, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) पुरानी प्रस्तुति-लॉकिंग व्यवहार के उपयोग को `CompatibilityIssue` के रूप में पहचानता है।

चेतावनियां स्रोत दस्तावेज़, लक्षित स्वरूप, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करती हैं। यह न मानें कि प्रत्येक फ़ाइल चेतावनी उत्पन्न करती है या किसी परिदृश्य का हमेशा केवल एक ही श्रेणी से मिलान होता है।

## **रोक दे गए ऑपरेशन्स को सुरक्षित रूप से संभालें**

`ReturnAction.Abort` लौटाने पर, लोड करने में विफल हुए ऑब्जेक्ट का उपयोग न करें और यह न मानें कि रेंडरिंग या सहेजने का आउटपुट पूर्ण है। ऑपरेशन आउटपुट फ़ाइल बनाते ही समाप्त हो सकता है लेकिन पूरा होने से पहले।

`validated-output.pptx` जैसी अलग पाथ पर मान्य परिणाम सहेजें। ऑपरेशन सफलतापूर्वक समाप्त होने, चेतावनी रिपोर्ट एप्लिकेशन नीति को संतुष्ट करने, और आउटपुट को खोला और जांचा जा सके, तब ही मौजूदा प्रस्तुति को बदलें। इससे वैध स्रोत फ़ाइल को आंशिक या अस्वीकृत परिणाम से ओवरराइट करने से बचा जा सकता है।

एक खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि प्रत्येक स्रोत फीचर संरक्षित रहा है। एप्लिकेशन द्वारा आवश्यक कोई भी अतिरिक्त सामग्री और दृश्य जांच लागू करें। देखें भी [Open Presentations](/slides/hi/net/open-presentation/) और [Save Presentations](/slides/hi/net/save-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक warning कॉलबैक हर Aspose.Slides त्रुटि को संभाल सकता है?**

नहीं। यह चेतावनियों के रूप में रिपोर्ट की गई पुनर्प्राप्त योग्य स्थितियों को संभालता है। कॉलबैक से स्वतंत्र रूप से उत्पन्न होने वाले अपवादों को लोडिंग, रेंडरिंग, परिवर्तित करने या सहेजने कॉल के आसपास एप्लिकेशन द्वारा संभालना चाहिए।

**क्या `ReturnAction.Continue` लौटाना समान आउटपुट की गारंटी देता है?**

नहीं। यह केवल प्रोसेसिंग जारी रखने की अनुमति देता है। रिपोर्ट की गई स्थिति अभी भी डेटा, फ़ॉर्मेटिंग या संगतता में अंतर पैदा कर सकती है, इसलिए एकत्रित चेतावनी प्रकार और विवरण की समीक्षा करें।

**कैसे कोई एप्लिकेशन यह पहचान सकता है कि कौन सा ऑपरेशन चेतावनी उत्पन्न कर रहा था?**

प्रत्येक ऑपरेशन के लिए एक कॉलबैक इंस्टेंस बनाएं और उदाहरण में दिखाए अनुसार `WarningType` और `Description` के साथ एक एप्लिकेशन-परिभाषित चरण को संग्रहीत करें।