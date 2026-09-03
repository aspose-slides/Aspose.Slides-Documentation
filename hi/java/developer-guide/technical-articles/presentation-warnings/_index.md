---
title: "Java में प्रेज़ेंटेशन चेतावनियों को संभालें"
type: docs
weight: 90
url: /hi/java/presentation-warnings/
aliases:
- "/java/अस्पोज-स्लाइड्स-में-फ़ॉन्ट-प्रतिस्थापन-के-लिए-चेतावनी-कॉलबैक-प्राप्त-करना/"
keywords:
- "चेतावनी कॉलबैक"
- "चेतावनी नीति"
- "डेटा नुकसान"
- "स्रोत भ्रष्टाचार"
- "संगतता समस्या"
- "फ़ॉन्ट प्रतिस्थापन"
- "डिजिटल हस्ताक्षर"
- "प्रेज़ेंटेशन लोडिंग"
- "प्रेज़ेंटेशन रेंडरिंग"
- "प्रेज़ेंटेशन रूपांतरण"
- "प्रेज़ेंटेशन सेविंग"
- "PowerPoint"
- "OpenDocument"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java के साथ प्रेज़ेंटेशन को लोड करने, रेंडर करने, रूपांतरण करने और सेव करने के दौरान चेतावनियों को एकत्रित, वर्गीकृत और कार्यान्वित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides लोड, रेंडर, कनवर्ट या प्रेजेंटेशन को सेव करने के दौरान पुनर्प्राप्त योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरणों में क्षतिग्रस्त स्रोत रिकॉर्ड, ऐसी सामग्री जो संरक्षित नहीं की जा सकती, फ़ॉन्ट परिवर्तन, और लक्ष्य फ़ॉर्मेट की सीमाएँ शामिल हैं। एक वार्निंग कॉलबैक एप्लिकेशन को इन स्थितियों को रिकॉर्ड करने और यह तय करने की अनुमति देता है कि वर्तमान ऑपरेशन जारी रह सकता है या नहीं।

[IWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarningcallback/) इंटरफ़ेस को लागू करें और [IWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/) के माध्यम से प्रदान किए गए [getWarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getWarningType--) और [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) मानों का परीक्षण करें। चेतावनी को स्वीकार करने के लिए [ReturnAction.Continue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/returnaction/#Continue) लौटाएँ या ऑपरेशन को रोकने के लिए [ReturnAction.Abort](https://reference.aspose.com/slides/hi/java/com.aspose.slides/returnaction/#Abort) लौटाएँ।

[LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) का उपयोग उन चेतावनियों के लिए करें जो प्रेजेंटेशन खोलते समय उत्पन्न होती हैं। रेंडरिंग और निर्यात विकल्प वर्ग [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) को विरासत में लेते हैं, जो स्लाइड रेंडरिंग, रूपांतरण और सेविंग से चेतावनियों को प्राप्त करता है। क्योंकि चेतावनी स्वयं एप्लिकेशन ऑपरेशन को निर्दिष्ट नहीं करती, संयोजित रिपोर्ट बनाते समय प्रत्येक कॉलबैक इंस्टेंस को एक ऑपरेशन चरण के साथ संबद्ध करें।

## **चेतावनियाँ और अपवाद**

एक चेतावनी उस स्थिति का वर्णन करती है जिससे Aspose.Slides `ReturnAction.Continue` लौटाने पर पुनर्प्राप्त कर सकता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूरा नहीं हो सकता; अपवादों को चेतावनियों में परिवर्तित नहीं किया जाता और उन्हें चेतावनी नीति द्वारा संभाला नहीं जा सकता।

`ReturnAction.Abort` लौटाने पर चेतावनी डिस्पैचर को एक अपवाद उठाकर वर्तमान ऑपरेशन को समाप्त करने का निर्देश देता है। सार्वजनिक अपवाद ऑपरेशन और प्रेजेंटेशन फ़ॉर्मेट पर निर्भर करता है। उदाहरण के लिए, लोडिंग के दौरान एक [PptxReadException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptreadexception/) उत्पन्न हो सकता है, जबकि सेविंग या एक्सपोर्ट करने पर एक [PptxException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxexception/) उत्पन्न हो सकता है। ऑपरेशन की सीमा पर अपवाद को संभालें और चेतावनी रिपोर्ट का उपयोग यह निर्धारित करने के लिए करें कि क्या एप्लिकेशन नीति ने समाप्ति का कारण बना, न कि केवल किसी एक अपवाद उपप्रकार या संदेश पर निर्भर रहें। कॉलबैक `ReturnAction.Abort` लौटाने से पहले चेतावनी को रिकॉर्ड करता है, जिससे कारण एप्लिकेशन के लिए उपलब्ध रहता है।

## **चेतावनी श्रेणियाँ**

[WarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/) वर्ग निम्नलिखित श्रेणियों के लिए पूर्णांक स्थिरांक प्रदान करता है:

| चेतावनी प्रकार | अर्थ | सामान्य नीति |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/#SourceFileCorruption) | स्रोत प्रेजेंटेशन में भ्रष्टाचार है जिससे मूल प्रारूप में सहेजी गई दस्तावेज़ अनुपयोगी हो सकता है। | Abort. |
| [DataLoss](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/#DataLoss) | लोडिंग या सेव करने के बाद टेक्स्ट, चार्ट, चित्र या अन्य डेटा अनुपस्थित हो सकता है। | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | प्रेजेंटेशन महत्वपूर्ण फ़ॉर्मेटिंग खो सकता है। | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | एक सीमित फ़ॉर्मेटिंग अंतर हो सकता है। | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/#CompatibilityIssue) | परिणाम कुछ एप्लिकेशन या पुराने संस्करणों में खुल नहीं सकता या सही व्यवहार नहीं कर सकता। | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/warningtype/#UnexpectedContent) | स्रोत में असमर्थित या अज्ञात सामग्री है जिसका प्रभाव अभी ज्ञात नहीं हो सकता। | Record and continue, or treat as an error in a strict policy. |

श्रेणी नीति निर्णय को प्रेरित करनी चाहिए। निदान हेतु [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गए मान को संग्रहित करें, लेकिन एप्लिकेशन लॉजिक में उसके शब्दों पर निर्भर न हों क्योंकि संदेश पाठ विभिन्न चेतावना परिदृश्यों और उत्पाद संस्करणों में भिन्न हो सकता है।

## **चेतावनियों को एकत्रित और वर्गीकृत करें**

निम्नलिखित उदाहरण पूर्ण प्रसंस्करण पाइपलाइन के लिए एक एप्लिकेशन‑स्तरीय रिपोर्ट का उपयोग करता है। अलग‑अलग कॉलबैक इंस्टैंस लोडिंग, रेंडरिंग, PDF रूपांतरण और PPTX सेविंग से मिलने वाली चेतावनियों को लेबल करते हैं। नीति स्रोत भ्रष्टाचार या डेटा नुकसान पर अवरोधन करती है, वैकल्पिक रूप से प्रमुख फ़ॉर्मेटिंग नुकसान पर भी अवरोधन करती है, और अन्य चेतावनियों के लिए जारी रखती है।

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

`WarningPolicy` का निर्माण करते समय यदि प्रमुख फ़ॉर्मेटिंग अंतर स्वीकार्य हैं तो `abortOnMajorFormattingLoss` के लिए `false` पास करें। संगतता मुद्दे, छोटे फ़ॉर्मेटिंग नुकसान, और अप्रत्याशित सामग्री अभी भी रिपोर्ट में रखी जाती हैं भले ही ऑपरेशन जारी रहे। यदि एप्लिकेशन को इनमें से किसी भी श्रेणी को अस्वीकार करना आवश्यक हो तो `WarningPolicy.getAction` को विस्तारित करें।

## **सामान्य चेतावनी परिदृश्य**

चेतावनियाँ वर्कफ़्लो के विभिन्न चरणों में दिखाई दे सकती हैं:

- **डिजिटल हस्ताक्षर:** एक हस्ताक्षरित प्रेजेंटेशन लोडिंग के दौरान यह चेतावनी उत्पन्न कर सकता है कि उसका हस्ताक्षर प्रोसेसिंग के दौरान खो जाएगा। Aspose.Slides इस `DataLoss` स्थिति को [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationsignedwarninginfo/) के माध्यम से रिपोर्ट करता है। एक लोड‑स्टेज कॉलबैक एप्लिकेशन को फ़ाइल को अस्वीकार करने या रिपोर्ट किए गए नुकसान को स्पष्ट रूप से स्वीकार करने की अनुमति देता है।
- **फ़ॉन्ट परिवर्तन:** जब कोई फ़ॉन्ट उपलब्ध नहीं होता तो स्लाइड रेंडरिंग या निर्यात के दौरान उसे बदल दिया जाता है। फ़ॉन्ट परिवर्तन चेतावनियाँ `DataLoss` के रूप में रिपोर्ट की जाती हैं, इसलिए ऊपर दी गई सख्त नीति में यह भी अवरोधन करती है भले ही एप्लिकेशन किसी विशिष्ट परिवर्तन को दृश्यात्मक रूप से स्वीकार्य मानता हो। इस व्यवहार को देखना चाहते हैं तो ऐसी इनपुट प्रेजेंटेशन का उपयोग करें जिसमें ऐसी फ़ॉन्ट हो जो रनटाइम में उपलब्ध नहीं हो। चेतावनी विवरण परिवर्तन को पहचानता है; आवश्यक फ़ॉन्ट कॉन्फ़िगर करें या [फ़ॉन्ट परिवर्तन नियम](/slides/hi/java/font-substitution/) सेट करें और फिर पुनः प्रयास करें।
- **असमर्थित या अप्रत्याशित सामग्री:** एक लोडर प्रेजेंटेशन रिकॉर्ड या फीचर से मिल सकता है जिसे वह नहीं पहचानता। ऐसी चेतावनियाँ `UnexpectedContent` हो सकती हैं, या यदि डेटा या फ़ॉर्मेटिंग प्रभावित हो तो अधिक गंभीर श्रेणी हो सकती है।
- **फ़ॉर्मेट संगतता:** किसी अन्य प्रेजेंटेशन फ़ॉर्मेट में सेव करने से विशेषताएँ हट सकती हैं या परिणाम कुछ एप्लिकेशन में अलग व्यवहार कर सकता है। उदाहरण के लिए, यदि प्रेजेंटेशन में आठ से अधिक क्षैतिज या ऊर्ध्वाधर ड्रॉइंग गाइड्स हों तो लेगेसी PPT में यह `CompatibilityIssue` रिपोर्ट करता है। सेव‑स्टेज कॉलबैक इस नुकसान को रिकॉर्ड कर जारी रख सकता है, या यदि सभी गाइड्स को संरक्षित रखना आवश्यक हो तो इसे अस्वीकार कर सकता है।
- **लोडिंग व्यवहार:** लोडिंग विकल्प और लेगेसी व्यवहार भी चेतावनियाँ दे सकते हैं। उदाहरण के लिए, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) एक पुरानी प्रेजेंटेशन‑लॉकिंग व्यवहार के उपयोग को `CompatibilityIssue` के रूप में पहचानता है।

चेतावनियाँ स्रोत दस्तावेज़, लक्ष्य फ़ॉर्मेट, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करती हैं। यह न मानें कि हर फ़ाइल चेतावनी देगी या प्रत्येक परिदृश्य केवल एक ही श्रेणी में आएगा।

## **रोकिए गए ऑपरेशनों को सुरक्षित रूप से संभालें**

जब कॉलबैक `ReturnAction.Abort` लौटाता है, तो उस ऑब्जेक्ट का उपयोग न करें जो लोड नहीं हुआ और न ही मानें कि रेंडर या सेव आउटपुट पूर्ण है। ऑपरेशन आउटपुट फ़ाइल बनाकर समाप्त हो सकता है, लेकिन उसे पूरी तरह लिखे बिना ही समाप्त हो सकता है।

मान्य परिणाम को किसी अलग पथ जैसे `validated-output.pptx` में सेव करें। मौजूदा प्रेजेंटेशन को केवल तब ही बदलें जब ऑपरेशन सफलतापूर्वक समाप्त हो, चेतावनी रिपोर्ट एप्लिकेशन नीति को संतुष्ट करे, और आउटपुट को खोला और जांचा जा सके। यह वैध स्रोत फ़ाइल को आंशिक या अस्वीकृत परिणाम से अधिलेखित होने से रोकता है।

एक खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि प्रत्येक स्रोत विशेषता संरक्षित रही है। एप्लिकेशन द्वारा आवश्यक अतिरिक्त सामग्री और दृश्य जांच लागू करें। देखें [Open Presentations](/slides/hi/java/open-presentation/) और [Save Presentations](/slides/hi/java/save-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक चेतावनी कॉलबैक प्रत्येक Aspose.Slides त्रुटि को संभाल सकता है?**

नहीं। यह केवल उन पुनर्प्राप्त योग्य स्थितियों को संभालता है जो चेतावनियों के रूप में रिपोर्ट की जाती हैं। उन अपवादों को जिन्हें कॉलबैक स्वतंत्र रूप से नहीं पकड़ता, लोडिंग, रेंडरिंग, रूपांतरण या सेव कॉल के आसपास एप्लिकेशन द्वारा संभालना आवश्यक है।

**क्या `ReturnAction.Continue` लौटाने से समान आउटपुट की गारंटी मिलती है?**

नहीं। यह केवल प्रक्रिया को जारी रखने की अनुमति देता है। रिपोर्ट की गई स्थिति अभी भी डेटा, फ़ॉर्मेटिंग या संगतता में अंतर का कारण बन सकती है, इसलिए एकत्रित चेतावनी प्रकार और विवरण की समीक्षा करें।

**एप्लिकेशन कैसे पहचान सकता है कि कौन सा ऑपरेशन चेतावनी उत्पन्न कर रहा है?**

प्रत्येक ऑपरेशन के लिए एक कॉलबैक इंस्टेंस बनाएं और [getWarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getWarningType--) और [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गए मानों के साथ एप्लिकेशन‑परिभाषित चरण को संग्रहीत रखें, जैसा कि उदाहरण में दिखाया गया है।