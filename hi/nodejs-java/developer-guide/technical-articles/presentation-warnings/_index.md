---
title: Node.js में प्रस्तुति चेतावनियों को संभालें
type: docs
weight: 90
url: /hi/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- चेतावनी नीति
- डेटा हानि
- सोर्स क्षति
- संगतता समस्या
- फ़ॉन्ट प्रतिस्थापन
- डिजिटल हस्ताक्षर
- प्रेजेंटेशन लोडिंग
- प्रेजेंटेशन रेंडरिंग
- प्रेजेंटेशन रूपांतरण
- प्रेजेंटेशन सेविंग
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से Java का उपयोग करके प्रस्तुति को लोड, रेंडर, रूपांतरण और सेव करने के दौरान चेतावनियों को एकत्रित, वर्गीकृत और कार्यान्वित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides लोड, रेंडर, कनवर्ट या प्रस्तुति को सेव करते समय पुनर्प्राप्ति योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरणों में क्षतिग्रस्त सोर्स रिकॉर्ड, गैर‑संरक्षित सामग्री, फ़ॉन्ट प्रतिस्थापन और लक्षित फ़ॉर्मेट की सीमाएं शामिल हैं। एक चेतावनी कॉलबैक एप्लिकेशन को इन स्थितियों को रिकॉर्ड करने और यह तय करने देता है कि वर्तमान ऑपरेशन जारी रह सकता है या नहीं।

`java.newProxy` का उपयोग करके [IWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarningcallback/) Java इंटरफ़ेस को JavaScript में लागू करें और [getWarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getWarningType--) तथा [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) मानों की जाँच करें जो [IWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/) के माध्यम से प्रदान किए जाते हैं। चेतावनी को स्वीकार करने के लिए [ReturnAction.Continue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/returnaction/#Continue) लौटाएँ या ऑपरेशन को रोकने के लिए [ReturnAction.Abort](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/returnaction/#Abort) लौटाएँ।

प्रेजेंटेशन खोलते समय उत्पन्न चेतावनियों के लिये [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) का प्रयोग करें। रेंडरिंग और एक्सपोर्ट ऑप्शन क्लासेस [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) को विरासत में प्राप्त करती हैं, जो स्लाइड रेंडरिंग, कनवर्ज़न और सेविंग से चेतावनियां प्राप्त करती हैं। क्योंकि चेतावनी स्वयं एप्लिकेशन ऑपरेशन को पहचानती नहीं है, संयुक्त रिपोर्ट बनाते समय प्रत्येक कॉलबैक इंस्टेंस को एक ऑपरेशन चरण के साथ संबद्ध करें।

## **चेतावनियां और अपवाद**

एक चेतावनी वह स्थिति दर्शाती है जिससे Aspose.Slides पुनर्प्राप्ति कर सकता है यदि कॉलबैक `ReturnAction.Continue` लौटाता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूर्ण नहीं हो सकता; अपवादों को चेतावनियों में परिवर्तित नहीं किया जाता और चेतावनी नीति द्वारा संभाला नहीं जा सकता।

`ReturnAction.Abort` लौटाने पर चेतावनी डिस्पैचर वर्तमान ऑपरेशन को एक अपवाद उठाकर समाप्त कर देता है। सार्वजनिक अपवाद ऑपरेशन और प्रस्तुति फ़ॉर्मेट पर निर्भर करता है। उदाहरण के लिए, लोडिंग के दौरान [PptxReadException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptreadexception/) उत्पन्न हो सकते हैं, जबकि सेविंग या एक्सपोर्ट के दौरान [PptxException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxexception/) उत्पन्न हो सकता है। ऑपरेशन की सीमा पर Java ब्रिज से त्रुटि को पकड़ें और यह निर्धारित करने के लिये चेतावनी रिपोर्ट का उपयोग करें कि एप्लिकेशन नीति ने समाप्ति का कारण बना या नहीं, केवल किसी एक अपवाद उपप्रकार या संदेश पर निर्भर न रहें। कॉलबैक `ReturnAction.Abort` लौटाने से पहले चेतावनी को रिकॉर्ड करता है, जिससे कारण एप्लिकेशन के लिए उपलब्ध रहता है।

## **चेतावनी श्रेणियां**

[WarningType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/) क्लास निम्नलिखित श्रेणियों के लिये पूर्णांक स्थिरांक प्रदान करती है:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | स्रोत प्रस्तुति में ऐसी क्षति है जिससे मूल फ़ॉर्मेट में सहेगा गया दस्तावेज़ अभ्यर्थी नहीं रह सकता। | Abort. |
| [DataLoss](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/#DataLoss) | लोडिंग या सेविंग के बाद टेक्स्ट, चार्ट, चित्र या अन्य डेटा अनुपस्थित हो सकता है। | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | प्रस्तुतिकरण महत्वपूर्ण फ़ॉर्मेटिंग खो सकता है। | सख्त वैधता मोड में Abort; अन्यथा रिकॉर्ड करें और जारी रखें। |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | एक सीमित फ़ॉर्मेटिंग अंतर हो सकता है। | निदान हेतु रिकॉर्ड करें और जारी रखें। |
| [CompatibilityIssue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | परिणाम कुछ अनुप्रयोगों या पुराने संस्करणों में सही से नहीं खुल सकता या काम नहीं कर सकता। | लॉग करें और जारी रखें जब तक संगतता अनिवार्य न हो। |
| [UnexpectedContent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | स्रोत में असमर्थित या अपरिचित सामग्री है जिसका प्रभाव अभी ज्ञात नहीं है। | रिकॉर्ड करें और जारी रखें, या सख्त नीति में इसे त्रुटि मानें। |

श्रेणी को नीति निर्णय निर्धारित करना चाहिए। निदान हेतु [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गए मान को संग्रहीत करें, लेकिन एप्लिकेशन लॉजिक के लिये उसके शब्दों पर निर्भर न रहें क्योंकि संदेश पाठ चेतावनी परिदृश्यों और उत्पाद संस्करणों के बीच बदल सकता है।

## **चेतावनियों को एकत्रित और वर्गीकृत करें**

निम्नलिखित JavaScript उदाहरण संपूर्ण प्रोसेसिंग पाइपलाइन के लिये एक एप्लिकेशन‑स्तर की रिपोर्ट का उपयोग करता है। एक अलग कॉलबैक इंस्टेंस लोडिंग, रेंडरिंग, PDF कनवर्ज़न और PPTX सेविंग से आने वाली चेतावनियों को लेबल करता है। नीति स्रोत क्षति या डेटा हानि पर Abort करती है, वैकल्पिक रूप से प्रमुख फ़ॉर्मेटिंग हानि पर Abort करती है, और अन्य चेतावनियों के लिये जारी रखती है।

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

यदि प्रमुख फ़ॉर्मेटिंग अंतर स्वीकार्य हैं तो `WarningPolicy` बनाते समय `abortOnMajorFormattingLoss` के लिये `false` पास करें। संगतता समस्याएं, छोटे फ़ॉर्मेटिंग नुकसान और अप्रत्याशित सामग्री अभी भी रिपोर्ट में रखी जाती हैं भले ही ऑपरेशन जारी रहे। यदि एप्लिकेशन को इन श्रेणियों में से कोई भी अस्वीकार करना हो तो `WarningPolicy.getAction` को विस्तारित करें।

## **सामान्य चेतावनी परिदृश्य**

चेतावनियां वर्कफ़्लो के विभिन्न चरणों पर उत्पन्न हो सकती हैं:

- **Digital signatures:** एक साइन की गई प्रस्तुति लोडिंग के दौरान चेतावनी दे सकती है कि उसकी हस्ताक्षर प्रोसेसिंग के दौरान खो जाएगी। Aspose.Slides इस `DataLoss` स्थिति को [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationsignedwarninginfo/) के माध्यम से रिपोर्ट करता है। लोड‑स्टेज कॉलबैक एप्लिकेशन को फ़ाइल को अस्वीकार करने या रिपोर्टेड नुकसान को स्पष्ट रूप से स्वीकार करने देता है।
- **Font substitution:** एक अनुपलब्ध फ़ॉन्ट को स्लाइड रेंडर या एक्सपोर्ट करते समय प्रतिस्थापित किया जा सकता है। फ़ॉन्ट प्रतिस्थापन चेतावनियां `DataLoss` के रूप में रिपोर्ट होती हैं, इसलिए ऊपर दी गई सख्त नीति भी अनुक्रमण के दृश्य रूप से स्वीकार्य होने पर Abort करती है। इस व्यवहार को देखने के लिये ऐसी प्रस्तुति का उपयोग करें जिसमें ऐसा फ़ॉन्ट हो जो रन‑टाइम में उपलब्ध न हो। चेतावनी विवरण प्रतिस्थापन की पहचान करता है; आवश्यक फ़ॉन्ट कॉन्फ़िगर करें या पुनः प्रयास करने से पहले [font substitution rules](/slides/hi/nodejs-java/font-substitution/) सेट करें।
- **Unsupported or unexpected content:** लोडर ऐसी प्रस्तुति रिकॉर्ड या फीचर पा सकता है जिसे वह पहचान नहीं पाता। ऐसी चेतावनियां `UnexpectedContent` या अधिक गंभीर श्रेणी ले सकती हैं जब डेटा या फ़ॉर्मेटिंग पर प्रभाव ज्ञात हो।
- **Format compatibility:** किसी अन्य प्रस्तुति फ़ॉर्मेट में सेव करने से फीचर छोड़ दिए जा सकते हैं या परिणाम कुछ अनुप्रयोगों में अलग तरह से व्यवहार कर सकता है। उदाहरण के लिये, आठ से अधिक क्षैतिज या ऊर्ध्वाधर ड्राइंग गाइड वाले प्रस्तुति को लेगेसी PPT में सेव करने से `CompatibilityIssue` प्राप्त होता है। सेव‑स्टेज कॉलबैक नुकसान को रिकॉर्ड कर जारी रख सकता है, या यदि सभी गाइड संरक्षित रखना आवश्यक हो तो उसे अस्वीकार कर सकता है।
- **Loading behavior:** लोडिंग विकल्प और लेगेसी व्यवहार भी चेतावनियां दे सकते हैं। उदाहरण के लिये, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) एक अप्रचलित प्रस्तुति‑लॉकिंग व्यवहार के उपयोग को `CompatibilityIssue` के रूप में पहचानता है।

चेतावनियां स्रोत दस्तावेज़, लक्ष्य फ़ॉर्मेट, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करती हैं। यह न मानें कि हर फ़ाइल चेतावनी देगी या कोई परिदृश्य हमेशा केवल एक श्रेणी में मानचित्रित होगा।

## **रोक दी गई ऑपरेशन्स को सुरक्षित रूप से संभालें**

जब कॉलबैक `ReturnAction.Abort` लौटाता है, तो उस वस्तु का उपयोग न करें जो लोड नहीं हुई और यह न मानें कि रेंडर या सेव आउटपुट पूर्ण है। ऑपरेशन आउटपुट फ़ाइल बनाकर भी उसे समाप्त होने से पहले समाप्त हो सकता है।

जांचित परिणामों को किसी अलग पथ पर सहेजें, उदाहरण के लिये `validated-output.pptx`। केवल तब मौजूदा प्रस्तुति को बदलें जब ऑपरेशन सफलतापूर्वक समाप्त हो, चेतावनी रिपोर्ट एप्लिकेशन नीति को संतुष्ट करे, और आउटपुट को खोला व जांचा जा सके। इससे वैध स्रोत फ़ाइल को आंशिक या अस्वीकृत परिणाम से अधिलेखित करने से बचा जा सकता है।

एक खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि हर स्रोत फ़ीचर संरक्षित रह गया है। एप्लिकेशन द्वारा आवश्यक अतिरिक्त सामग्री और दृश्य जांचें लागू करें। अतिरिक्त जानकारी के लिये देखें [Open Presentations](/slides/hi/nodejs-java/open-presentation/) तथा [Save Presentations](/slides/hi/nodejs-java/save-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक चेतावनी कॉलबैक हर Aspose.Slides त्रुटि को संभाल सकता है?**

नहीं। यह उन पुनर्प्राप्ति योग्य स्थितियों को संभालता है जो चेतावनियों के रूप में रिपोर्ट की गई हैं। जो अपवाद कॉलबैक से स्वतंत्र रूप से होते हैं, उन्हें लोडिंग, रेंडरिंग, कनवर्ज़न या सेव कॉल के आसपास एप्लिकेशन द्वारा संभालना आवश्यक है।

**क्या `ReturnAction.Continue` लौटाने से समान आउटपुट की गारंटी मिलती है?**

नहीं। यह केवल प्रोसेसिंग को जारी रखने की अनुमति देता है। रिपोर्टेड स्थिति अभी भी डेटा, फ़ॉर्मेटिंग या संगतता में अंतर उत्पन्न कर सकती है, इसलिए एकत्रित चेतावनी प्रकारों और विवरणों की समीक्षा करें।

**एक एप्लिकेशन कैसे पहचान सकता है कि किस ऑपरेशन ने चेतावनी उत्पन्न की?**

प्रत्येक ऑपरेशन के लिये एक कॉलबैक इंस्टेंस बनाएं और [getWarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getWarningType--) तथा [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गये मानों को एक एप्लिकेशन‑परिभाषित चरण के साथ संग्रहीत करें, जैसा कि उदाहरण में दिखाया गया है।