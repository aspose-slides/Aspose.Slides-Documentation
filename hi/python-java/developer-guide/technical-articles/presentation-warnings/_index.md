---
title: Python के माध्यम से Java में प्रस्तुति चेतावनियों को संभालें
type: docs
weight: 90
url: /hi/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुति को लोड करने, रेंडर करने, रूपांतरण करने और सहेजने के दौरान चेतावनियों को एकत्रित, वर्गीकृत व कार्य करने का तरीका सीखें।"
---
## **सारांश**

Aspose.Slides प्रस्तुति को लोड करने, रेंडर करने, परिवर्तित करने या सहेजने के दौरान पुनःप्राप्ति योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरणों में क्षतिग्रस्त स्रोत रिकॉर्ड, जो सामग्री संरक्षित नहीं की जा सकती, फ़ॉन्ट प्रतिस्थापन, और लक्ष्य फ़ॉर्मेट की सीमाएँ शामिल हैं। एक warning callback अनुप्रयोग को इन स्थितियों को रिकॉर्ड करने और यह निर्णय लेने की अनुमति देता है कि वर्तमान ऑपरेशन जारी रखा जा सकता है या नहीं।

`jpype.JProxy` के माध्यम से `IWarningCallback` इंटरफ़ेस को लागू करें और `IWarningInfo` द्वारा प्रदान किए गए `getWarningType` और `getDescription` मानों की जाँच करें। चेतावनी को स्वीकार करने के लिए [ReturnAction.Continue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/returnaction/#Continue) लौटाएँ या ऑपरेशन को रोकने के लिए [ReturnAction.Abort](https://reference.aspose.com/slides/hi/python-java/aspose.slides/returnaction/#Abort) लौटाएँ।

[LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setWarningCallback) का उपयोग करके प्रस्तुति खोलते समय उत्पन्न होने वाली चेतावनियों को संभालें। रेंडरिंग और निर्यात विकल्प क्लासें [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setWarningCallback) को विरासत में प्राप्त करती हैं, जो स्लाइड रेंडरिंग, रूपांतरण और सहेजने से मिलने वाली चेतावनियों को प्राप्त करती हैं। क्योंकि चेतावनी स्वयं अनुप्रयोग की क्रिया को पहचानती नहीं है, संयुक्त रिपोर्ट बनाते समय प्रत्येक callback इंस्टेंस को एक ऑपरेशन चरण के साथ संबद्ध करें।

## **चेतावनियाँ और अपवाद**

एक चेतावनी वह स्थिति दर्शाती है जिससे Aspose.Slides `ReturnAction.Continue` वापस करने पर पुनः प्राप्त कर सकता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूरा नहीं हो सकता; अपवादों को चेतावनियों में बदल नहीं किया जाता और उन्हें warning नीति द्वारा संभाला नहीं जा सकता।

`ReturnAction.Abort` लौटाने से warning dispatcher को वर्तमान ऑपरेशन को समाप्त करके एक अपवाद उठाने को कहा जाता है। सार्वजनिक अपवाद ऑपरेशन और प्रस्तुति फ़ॉर्मेट पर निर्भर करता है। उदाहरण के लिए, लोडिंग के दौरान एक [PptxReadException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptreadexception/) उत्पन्न हो सकता है, जबकि सहेजने या निर्यात करने पर एक [PptxException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxexception/) उत्पन्न हो सकता है। ऑपरेशन की सीमा पर अपवाद को संभालें और चेतावनी रिपोर्ट का उपयोग यह निर्धारित करने के लिए करें कि क्या अनुप्रयोग नीति ने समाप्ति का कारण बना, न कि केवल एक अपवाद उपप्रकार या संदेश पर निर्भर रहें। callback चेतावनी को रिकॉर्ड करता है और फिर `ReturnAction.Abort` लौटाता है, जिससे कारण अनुप्रयोग के लिए उपलब्ध रहता है।

## **चेतावनी श्रेणियाँ**

[WarningType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/) क्लास निम्नलिखित श्रेणियों के लिए पूर्णांक स्थिरांक प्रदान करती है:

| चेतावनी प्रकार | अर्थ | सामान्य नीति |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/#SourceFileCorruption) | स्रोत प्रस्तुति में भ्रष्टाचार है जो मूल फ़ॉर्मेट में सहेजे गए दस्तावेज़ को अनुपयोगी बना सकता है। | रोकें। |
| [DataLoss](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/#DataLoss) | लोड या सहेजने के बाद पाठ, चार्ट, चित्र या अन्य डेटा अनुपस्थित हो सकता है। | रोकें। |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | प्रस्तुति महत्वपूर्ण फॉर्मेटिंग खो सकती है। | सख्त सत्यापन मोड में रोकें; अन्यथा रिकॉर्ड करें और जारी रखें। |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | सीमित फॉर्मेटिंग अंतर हो सकता है। | निदान के लिए रिकॉर्ड करें और जारी रखें। |
| [CompatibilityIssue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/#CompatibilityIssue) | परिणाम कुछ अनुप्रयोगों या पुराने संस्करणों में खुलने या सही व्यवहार न करने की संभावना है। | लॉग करें और जारी रखें, जब तक संगतता अनिवार्य न हो। |
| [UnexpectedContent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/warningtype/#UnexpectedContent) | स्रोत में असमर्थित या अज्ञात सामग्री है, जिसका प्रभाव अभी ज्ञात नहीं हो सकता। | रिकॉर्ड करें और जारी रखें, या सख्त नीति में इसे त्रुटि मानें। |

श्रेणी नीति निर्णय को निर्देशित करनी चाहिए। निदान के लिए `getDescription` द्वारा लौटाए गए मान को संग्रहित करें, लेकिन आवेदन लॉजिक के लिए उसके शब्दों पर निर्भर न रहें क्योंकि संदेश पाठ विभिन्न चेतावनि परिस्थितियों और उत्पाद संस्करणों में बदल सकता है।

## **चेतावनियों को एकत्र और वर्गीकृत करना**

निम्न उदाहरण संपूर्ण प्रोसेसिंग पाइपलाइन के लिए एक एप्लिकेशन‑स्तरीय रिपोर्ट का उपयोग करता है। एक अलग callback इंस्टेंस लोडिंग, रेंडरिंग, PDF रूपांतरण और PPTX सहेजने से उत्पन्न चेतावनियों को लेबल करता है। नीति स्रोत भ्रष्टाचार या डेटा हानि पर रोकती है, वैकल्पिक रूप से प्रमुख फॉर्मेटिंग हानि पर भी रोक सकती है, और अन्य चेतावनियों के लिए जारी रखती है।

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

यदि प्रमुख फॉर्मेटिंग अंतर स्वीकार्य हैं तो `WarningPolicy` बनाते समय `abort_on_major_formatting_loss` को `False` पास करें। संगतता मुद्दे, मामूली फॉर्मेटिंग हानि, और अप्रत्याशित सामग्री अभी भी रिपोर्ट में रखी जाती हैं, भले ही ऑपरेशन जारी रहे। यदि अनुप्रयोग को इन श्रेणियों में से किसी को भी अस्वीकार करना हो तो `WarningPolicy.get_action` को विस्तारित करें।

## **आम चेतावनी परिदृश्य**

चेतावनियाँ कार्यप्रवाह के विभिन्न चरणों पर दिखाई दे सकती हैं:

- **डिजिटल हस्ताक्षर:** एक हस्ताक्षरित प्रस्तुति लोड करते समय चेतावनी दे सकती है कि उसका हस्ताक्षर प्रक्रिया के दौरान खो जाएगा। Aspose.Slides इस `DataLoss` स्थिति को `IPresentationSignedWarningInfo` के माध्यम से रिपोर्ट करता है। लोड‑स्तर का callback अनुप्रयोग को फ़ाइल अस्वीकार करने या रिपोर्ट किए गए नुकसान को स्पष्ट रूप से स्वीकार करने की अनुमति देता है।
- **फ़ॉन्ट प्रतिस्थापन:** किसी अनुपलब्ध फ़ॉन्ट को स्लाइड रेंडर या निर्यात होते समय बदला जा सकता है। फ़ॉन्ट प्रतिस्थापन की चेतावनियों को `DataLoss` के रूप में रिपोर्ट किया जाता है, इसलिए ऊपर दी गई सख्त नीति भी तब रोक देती है जब अनुप्रयोग किसी विशेष प्रतिस्थापन को दृश्य रूप से स्वीकार्य मानता हो। इस व्यवहार को देखने के लिए ऐसी प्रस्तुति इनपुट करें जिसमें ऐसी फ़ॉन्ट हो जो रन‑टाइम में उपलब्ध न हो। चेतावनी विवरण प्रतिस्थापन को पहचानता है; आवश्यक फ़ॉन्ट स्थापित करें या [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/python-java/font-substitution/) को कॉन्फ़िगर करें और फिर पुनः प्रयास करें।
- **असमर्थित या अप्रत्याशित सामग्री:** लोडर ऐसी प्रस्तुति रिकॉर्ड या विशेषताएँ पा सकता है जिन्हें वह पहचान नहीं पाता। ऐसी चेतावनियाँ `UnexpectedContent` या अधिक गंभीर श्रेणी का उपयोग कर सकती हैं जब डेटा या फॉर्मेटिंग पर प्रभाव ज्ञात हो।
- **फ़ॉर्मेट संगतता:** किसी अन्य प्रस्तुति फ़ॉर्मेट में सहेजने से विशेषताएँ हट सकती हैं या परिणाम कुछ अनुप्रयोगों में अलग व्यवहार कर सकता है। उदाहरण के लिए, आठ से अधिक क्षैतिज या ऊर्ध्वाधर ड्राइंग गाइड वाले प्रस्तुति को पुरानी PPT में सहेजने पर `CompatibilityIssue` रिपोर्ट होता है। सहेजने‑स्तर का callback इस हानि को रिकॉर्ड कर सकता है और जारी रख सकता है, या यदि सभी गाइड संरक्षित करने की आवश्यकता हो तो इसे अस्वीकार कर सकता है।
- **लोडिंग व्यवहार:** लोडिंग विकल्प और लेगेसी व्यवहार भी चेतावनियाँ उत्पन्न कर सकते हैं। उदाहरण के लिए, `IObsoletePresLockingBehaviorWarningInfo` एक अप्रचलित प्रस्तुति‑लॉकिंग व्यवहार को `CompatibilityIssue` के रूप में पहचानता है।

चेतावनियों का निर्धारण स्रोत दस्तावेज़, लक्ष्य फ़ॉर्मेट, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करता है। यह न मानें कि हर फ़ाइल चेतावनी देती है या किसी परिदृश्य में हमेशा केवल एक ही श्रेणी लागू होती है।

## **रोके गये ऑपरेशनों को सुरक्षित रूप से संभालना**

जब callback `ReturnAction.Abort` लौटाता है, तब उस वस्तु का उपयोग न करें जो लोड नहीं हुई और यह न मानें कि रेंडर या सहेजने का आउटपुट पूर्ण है। ऑपरेशन आउटपुट फ़ाइल बनाकर लेकिन उसे समाप्त करने से पहले समाप्त हो सकता है।

वैध परिणामों को `validated-output.pptx` जैसी अलग पथ पर सहेजें। मौजूदा प्रस्तुति को केवल तब ही प्रतिस्थापित करें जब ऑपरेशन सफलतापूर्वक समाप्त हो, चेतावनी रिपोर्ट अनुप्रयोग नीति को संतुष्ट करे, और आउटपुट को खोला और जाँचा जा सके। इससे भागिक या अस्वीकृत परिणाम से वैध स्रोत फ़ाइल को ओवरराइट करने से बचा जा सकेगा।

एक खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि प्रत्येक स्रोत विशेषता संरक्षित हुई है। अनुप्रयोग द्वारा आवश्यक अतिरिक्त सामग्री और दृश्य जाँच लागू करें। अतिरिक्त रूप से देखें: [Open Presentations](/slides/hi/python-java/open-presentation/) और [Save Presentations](/slides/hi/python-java/save-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक warning callback सभी Aspose.Slides त्रुटियों को संभाल सकता है?**

नहीं। यह केवल चेतावनियों के रूप में रिपोर्ट की गई पुनःप्राप्ति योग्य स्थितियों को संभालता है। ऐसी अपवाद जो callback से स्वतंत्र होते हैं, उन्हें लोडिंग, रेंडरिंग, रूपांतरण या सहेजने के कॉल के चारों ओर अनुप्रयोग द्वारा संभालना आवश्यक है।

**क्या `ReturnAction.Continue` लौटाने से समान आउटपुट की गारंटी मिलती है?**

नहीं। यह केवल प्रक्रिया को जारी रखने की अनुमति देता है। रिपोर्ट की गई स्थिति अभी भी डेटा, फॉर्मेटिंग या संगतता में अंतर पैदा कर सकती है, इसलिए एकत्रित चेतावनी प्रकार और विवरण की समीक्षा करें।

**एक अनुप्रयोग कैसे पहचान सकता है कि कौन‑सी ऑपरेशन ने चेतावनी उत्पन्न की?**

प्रत्येक ऑपरेशन के लिए एक callback इंस्टेंस बनाएं और `getWarningType` तथा `getDescription` द्वारा लौटाए गए मानों के साथ एक अनुप्रयोग‑परिभाषित चरण को संग्रहीत करें, जैसा कि उदाहरण में दिखाया गया है।