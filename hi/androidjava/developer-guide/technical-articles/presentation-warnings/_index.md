---
title: Android पर प्रस्तुति चेतावनियों को संभालें
type: docs
weight: 90
url: /hi/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी callback
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति को लोड, रेंडर, रूपांतरित और सहेजते समय चेतावनियों को एकत्रित, वर्गीकृत और कार्य करने के तरीके जानें।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति को लोड, रेंडर, कनवर्ट या सहेजते समय पुनर्प्राप्त करने योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरणों में क्षतिग्रस्त स्रोत रिकॉर्ड, ऐसी सामग्री जो संरक्षित नहीं की जा सकती, फ़ॉन्ट प्रतिस्थापन, और लक्ष्य स्वरूप की सीमाएँ शामिल हैं। एक warning callback एप्लिकेशन को इन स्थितियों को रिकॉर्ड करने और यह निर्णय लेने की अनुमति देता है कि वर्तमान ऑपरेशन जारी रखा जा सकता है या नहीं।

[IWarningCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iwarningcallback/) इंटरफ़ेस को लागू करें और [IWarningInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iwarninginfo/) के माध्यम से प्रदान किए गए [getWarningType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) और [getDescription](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) मानों का निरीक्षण करें। चेतावनी को स्वीकार करने के लिए [ReturnAction.Continue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/returnaction/#Continue) लौटाएँ या ऑपरेशन को रोकने के लिए [ReturnAction.Abort](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/returnaction/#Abort) लौटाएँ।

[LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) का उपयोग करें जब प्रस्तुति खोलते समय चेतावनियां उत्पन्न हों। रेंडरिंग और एक्सपोर्ट विकल्प क्लासेज़ [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) को विरासत में लेती हैं, जो स्लाइड रेंडरिंग, कनवर्ज़न और सहेजने से चेतावनियों को प्राप्त करती हैं। चूंकि चेतावनी स्वयं एप्लिकेशन ऑपरेशन को पहचानती नहीं है, इसलिए संयुक्त रिपोर्ट बनाते समय प्रत्येक callback इंस्टेंस को एक ऑपरेशन चरण के साथ जोड़ें।

## **चेतावनियाँ और अपवाद**

एक चेतावनी उस स्थिति का वर्णन करती है जिससे Aspose.Slides callback द्वारा `ReturnAction.Continue` लौटाए जाने पर पुनर्प्राप्त कर सकता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूरा नहीं हो सकता; अपवादों को चेतावनियों में परिवर्तित नहीं किया जाता और उन्हें चेतावनी नीति द्वारा संभाला नहीं जा सकता।

`ReturnAction.Abort` लौटाने से warning dispatcher को एक अपवाद उठाकर वर्तमान ऑपरेशन को समाप्त करने के लिए कहा जाता है। सार्वजनिक अपवाद ऑपरेशन और प्रस्तुति स्वरूप पर निर्भर करता है। उदाहरण के लिए, लोडिंग के दौरान एक [PptxReadException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptreadexception/) उत्पन्न हो सकते हैं, जबकि सहेजने या निर्यात करने पर एक [PptxException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxexception/) उत्पन्न हो सकता है। अपवाद को ऑपरेशन की सीमा पर संभालें और चेतावनी रिपोर्ट का उपयोग यह निर्धारित करने के लिए करें कि क्या एप्लिकेशन नीति ने समाप्ति का कारण बना, न कि केवल एक अपवाद उपप्रकार या संदेश पर भरोसा करें। callback `ReturnAction.Abort` लौटाने से पहले चेतावनी को रिकॉर्ड करता है, जिससे कारण एप्लिकेशन के लिए उपलब्ध रहता है।

## **चेतावनी श्रेणियाँ**

[WarningType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/) क्लास निम्नलिखित श्रेणियों के लिए पूर्णांक स्थिरांक प्रदान करती है:

| चेतावनी प्रकार | अर्थ | सामान्य नीति |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | स्रोत प्रस्तुति में भ्रष्टाचार है जो मूल स्वरूप में सहेजे गए दस्तावेज़ को उपयोग योग्य नहीं बना सकता। | Abort. |
| [DataLoss](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/#DataLoss) | लोड या सहेजने के बाद पाठ, चार्ट, छवियां या अन्य डेटा अनुपलब्ध हो सकते हैं। | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | प्रस्तुति महत्वपूर्ण फ़ॉर्मेटिंग खो सकती है। | सख्त वैधता मोड में Abort; अन्यथा रिकॉर्ड करें और जारी रखें। |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | एक सीमित फ़ॉर्मेटिंग अंतर हो सकता है। | डायग्नोस्टिक्स के लिए रिकॉर्ड करें और जारी रखें। |
| [CompatibilityIssue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | परिणाम कुछ एप्लिकेशन या पुराने संस्करणों में नहीं खुल सकता या सही ढंग से काम नहीं कर सकता। | यदि संगतता अनिवार्य नहीं है तो लॉग करें और जारी रखें। |
| [UnexpectedContent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | स्रोत में असमर्थित या अपरिचित सामग्री है जिसका प्रभाव अभी ज्ञात नहीं हो सकता। | रिकॉर्ड करें और जारी रखें, या सख्त नीति में इसे त्रुटि मानें। |

श्रेणी को नीति निर्णय को संचालित करना चाहिए। डायग्नोस्टिक्स के लिए [getDescription](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गए मान को संग्रहित करें, लेकिन एप्लिकेशन लॉजिक के लिए उसके शब्दों पर निर्भर न रहें क्योंकि संदेश का पाठ चेतावनी परिदृश्यों और उत्पाद संस्करणों के बीच बदल सकता है।

## **चेतावनियों को एकत्रित और वर्गीकृत करें**

निम्न उदाहरण पूरी प्रोसेसिंग पाइपलाइन के लिए एक एप्लिकेशन-लेवल रिपोर्ट का उपयोग करता है। एक अलग callback इंस्टेंस लोडिंग, रेंडरिंग, PDF कनवर्ज़न और PPTX सहेजने से उत्पन्न चेतावनियों को लेबल करता है। नीति स्रोत भ्रष्टाचार या डेटा हानि पर abort करती है, वैकल्पिक रूप से major formatting loss पर abort करती है, और अन्य चेतावनियों के लिए जारी रहती है।

`input.pptx` को लेखनीय एप्लिकेशन डायरेक्टरी में रखें और उस डायरेक्टरी को `PresentationWarningExample.run` में पास करें। उदाहरण अपने आउटपुट उसी डायरेक्टरी में सहेजता है। Android यूज़र इंटरफ़ेस को प्रतिक्रियाशील रखने के लिए प्रस्तुति प्रोसेसिंग को बैकग्राउंड थ्रेड पर चलाएँ।

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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


यदि major formatting differences स्वीकार्य हैं तो `WarningPolicy` बनाते समय `abortOnMajorFormattingLoss` के लिए `false` पास करें। Compatibility issues, minor formatting loss, and unexpected content are still retained in the report even when the operation continues. Extend `WarningPolicy.getAction` if the application must reject any of those categories.

## **सामान्य चेतावनी परिदृश्य**

चेतावनियां वर्कफ़्लो के विभिन्न चरणों में दिखाई दे सकती हैं:

- **Digital signatures:** एक साइन की गई प्रस्तुति लोडिंग के दौरान एक चेतावनी उत्पन्न कर सकती है कि इसका हस्ताक्षर प्रक्रिया के दौरान खो जाएगा। Aspose.Slides इस `DataLoss` स्थिति को [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) के माध्यम से रिपोर्ट करता है। एक load-stage callback एप्लिकेशन को फ़ाइल को अस्वीकार करने या रिपोर्ट किए गए नुकसान को स्पष्ट रूप से स्वीकार करने की अनुमति देता है।
- **Font substitution:** एक अवैध फ़ॉन्ट को स्लाइड रेंडर या निर्यात करते समय प्रतिस्थापित किया जा सकता है। फ़ॉन्ट प्रतिस्थापन चेतावनियां `DataLoss` के रूप में रिपोर्ट की जाती हैं, इसलिए उपरोक्त सख्त नीति abort करती है भले ही एप्लिकेशन किसी विशेष प्रतिस्थापन को दृश्यात्मक रूप से स्वीकार्य मानता हो। इस व्यवहार को देखने के लिए ऐसी प्रस्तुति का उपयोग करें जिसमें ऐसा फ़ॉन्ट हो जो रनटाइम में उपलब्ध न हो। चेतावनी विवरण प्रतिस्थापन को पहचानता है; आवश्यक फ़ॉन्ट्स को कॉन्फ़िगर करें या [font substitution rules](/slides/hi/androidjava/font-substitution/) पहले से सेट करें फिर पुनः प्रयास करें।
- **Unsupported or unexpected content:** एक लोडर ऐसे रिकॉर्ड या सुविधाएं पा सकता है जिन्हें वह पहचान नहीं पाता। ऐसी चेतावनियां `UnexpectedContent` या अधिक गंभीर श्रेणी का उपयोग कर सकती हैं यदि डेटा या फ़ॉर्मेटिंग प्रभावित है।
- **Format compatibility:** किसी अन्य प्रस्तुति स्वरूप में सहेजने से सुविधाएँ हट सकती हैं या परिणाम कुछ एप्लिकेशनों में अलग व्यवहार कर सकता है। उदाहरण के लिए, आठ से अधिक क्षैतिज या ऊर्ध्वाधर ड्राइंग गाइड्स वाले प्रस्तुति को लेगेसी PPT में सहेजने पर `CompatibilityIssue` रिपोर्ट होता है। save-stage callback हानि को रिकॉर्ड कर जारी रख सकता है, या यदि सभी गाइड्स को संरक्षित रखना आवश्यक है तो अस्वीकार कर सकता है।
- **Loading behavior:** लोडिंग विकल्प और लेगेसी व्यवहार भी चेतावनियां उत्पन्न कर सकते हैं। उदाहरण के लिए, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) एक पुरानी प्रस्तुति-लॉकिंग व्यवहार के उपयोग को `CompatibilityIssue` के रूप में पहचानता है।

चेतावनियां स्रोत दस्तावेज़, लक्ष्य स्वरूप, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करती हैं। यह मान न रखें कि हर फ़ाइल चेतावनी उत्पन्न करेगी या कोई परिदृश्य हमेशा केवल एक श्रेणी में ही आता है।

## **रोक दी गई ऑपरेशनों को सुरक्षित रूप से संभालें**

जब एक callback `ReturnAction.Abort` लौटाता है, तो उस वस्तु का उपयोग न करें जो लोड होने में विफल रही और यह मान न लें कि रेंडर या सहेजने का आउटपुट पूर्ण है। ऑपरेशन आउटपुट फ़ाइल बनाकर भी उसे समाप्त करने से पहले समाप्त हो सकता है।

मान्य परिणामों को किसी अलग पथ जैसे `validated-output.pptx` में सहेजें। ऑपरेशन सफलतापूर्वक समाप्त होने, चेतावनी रिपोर्ट एप्लिकेशन नीति को संतुष्ट करने, और आउटपुट को खोला और जांचा जा सके, तभी मौजूदा प्रस्तुति को प्रतिस्थापित करें। इससे अधूरे या अस्वीकृत परिणाम से वैध स्रोत फ़ाइल ओवरराइट होने से बचा जा सकता है।

एक खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि हर स्रोत सुविधा संरक्षित रही है। एप्लिकेशन द्वारा आवश्यक किसी भी अतिरिक्त सामग्री और दृश्य जांच को लागू करें। अतिरिक्त जानकारी के लिए देखें [Open Presentations](/slides/hi/androidjava/open-presentation/) और [Save Presentations](/slides/hi/androidjava/save-presentation/)।

## **FAQ**

**क्या warning callback हर Aspose.Slides त्रुटि को संभाल सकता है?**

नहीं। यह केवल उन पुनर्प्राप्त करने योग्य स्थितियों को संभालता है जो चेतावनियों के रूप में रिपोर्ट होती हैं। callback से स्वतंत्र रूप से उत्पन्न अपवादों को लोडिंग, रेंडरिंग, कनवर्ज़न या सहेजने के कॉल के आसपास एप्लिकेशन द्वारा संभालना होगा।

**क्या `ReturnAction.Continue` लौटाने से समान आउटपुट की गारंटी मिलती है?**

नहीं। यह केवल प्रोसेसिंग को जारी रखने की अनुमति देता है। रिपोर्ट की गई स्थिति अभी भी डेटा, फ़ॉर्मेटिंग या संगतता में अंतर पैदा कर सकती है, इसलिए एकत्रित चेतावनी प्रकार और विवरण की समीक्षा करें।

**एक एप्लिकेशन कैसे पहचान सकता है कि कौन सा ऑपरेशन चेतावनी उत्पन्न कर रहा है?**

प्रत्येक ऑपरेशन के लिए एक callback इंस्टेंस बनाएं और `getWarningType` तथा `getDescription` द्वारा लौटाए गए मानों के साथ एप्लिकेशन-परिभाषित चरण को संग्रहीत करें, जैसा कि उदाहरण में दिखाया गया है।