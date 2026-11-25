---
title: Android पर दीर्घकालिक प्रस्तुति संचालन को बाधित करें
linktitle: प्रस्तुति संचालन को बाधित करें
type: docs
weight: 120
url: /hi/androidjava/support-for-interruptable-library/
keywords:
- बाध्यशील संचालन
- बाधा टोकन
- रद्दीकरण टोकन
- दीर्घकालिक कार्य
- कार्य बाधित करें
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में दीर्घकालिक प्रस्तुति संचालन को रद्द करना सीखें और स्लाइड्स को लूप में निर्यात करते समय एक आंशिक परिणाम लौटाएँ।"
---
## **अवलोकन**

Aspose.Slides for Android via Java लोडिंग, सहेजने और प्रस्तुति रेंडरिंग जैसी दीर्घकालिक संचालन को बाधित कर सकता है। आपका अनुप्रयोग वही interruption token उपयोग करके अगली स्लाइड को प्रोसेस करने से पहले लूप को रोक सकता है।

## **प्रस्तुति ऑपरेशन को बाधित करें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) बनाएं, उसका टोकन [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--) से प्राप्त करें, और टोकन को [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) में पास करें। लोड विकल्पों को [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) में पास करें। रद्दीकरण का अनुरोध करने के लिए, स्रोत पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करें। एक बाध्यशील ऑपरेशन अनुरोध को देख लेते ही रुक जाता है।

उदाहरण बैकग्राउंड थ्रेड पर `sample.pptx` को `sample.ppt` में परिवर्तित करता है। कॉल करने वाला थ्रेड रूपांतरण समाप्त होने के लिए अधिकतम 10 सेकंड तक प्रतीक्षा करता है। यदि रूपांतरण अभी भी चल रहा है, तो यह रद्दीकरण का अनुरोध करता है और कार्यकर्ता के समाप्त होने का इंतजार करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
        // बैकग्राउंड थ्रेड से कॉल करें और context.getFilesDir() पास करें, जिसमें sample.pptx शामिल है।
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
                } finally {
                    presentation.dispose();
                }
            } catch (OperationCanceledException canceled) {
                System.out.println("Conversion canceled");
            }
        });

        worker.start();
        worker.join(10000);
        if (worker.isAlive()) {
            source.interrupt();
            worker.join();
        }
    }
}
```
## **Aspose.Slides के साथ Java टाइमआउट को जोड़ें**

प्रस्तुति ऑपरेशन पर समय सीमा निर्धारित करने के लिए, एक [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) का उपयोग करके टाइमआउट समाप्त होने पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करें। उदाहरण 20 सेकंड की अनुमति देता है `sample.pptx` को लोड करने और उसे `sample.pdf` में निर्यात करने के लिए। यदि निर्यात जल्दी समाप्त हो जाता है, तो एप्लिकेशन शेड्यूल किए गए अनुरोध को रद्द कर देता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // बैकग्राउंड थ्रेड से कॉल करें और context.getFilesDir() पास करें, जिसमें sample.pptx शामिल है।
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```
## **अगली स्लाइड प्रोसेस करने से पहले रोकें**

प्रस्तुति और उस लूप दोनों के लिए जो उसकी स्लाइड्स को निर्यात करता है, एक ही [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) का उपयोग करें। प्रत्येक निर्यात से पहले [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) को जांचें। यदि कॉलर आधा परिणाम उपयोग कर सकता है, तो सफलतापूर्वक पूर्ण हुए निर्यातों के लिए स्लाइड नंबर लौटाएँ।

एक `sample.pptx` नामक प्रस्तुति प्रयोग करें जिसमें कम से कम दो स्लाइड हों। वह [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) ओवरलोड जो स्लाइड नंबरों की एरे लेता है, 1 से गिनती शुरू करता है। उदाहरण प्रत्येक स्लाइड को अलग PDF में सहेजता है और पहली सफल निर्यात को रिकॉर्ड करने के बाद तुरंत रद्दीकरण का अनुरोध करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }

    // बैकग्राउंड थ्रेड से कॉल करें और context.getFilesDir() पास करें, जिसमें sample.pptx शामिल है।
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

उदाहरण `slide-1.pdf` लिखता है और `Starting slide 1` प्रिंट करता है, उसके बाद `Completed: [1]`। लूप स्लाइड 2 शुरू करने से पहले अनुरोध को देखता है। यदि सहेजने के दौरान रद्दीकरण आता है, तो लूप उस स्लाइड को पूर्ण के रूप में रिकॉर्ड करने से पहले बाहर निकल जाता है।

यदि कॉलर को रद्दीकरण को संभालना आवश्यक है, तो लूप के शीर्ष पर जांच और उसका `break` को `token.throwIfInterruptionRequested()` से बदलें। सहेजने के आसपास का `try`/`catch` हटाएँ ताकि निर्यात के दौरान रद्दीकरण भी कॉलर तक पहुँचे। समान इनपुट के साथ, उदाहरण केवल `Starting slide 1` प्रिंट करता है और `slide-1.pdf` लिखता है। दूसरे इटरशन की शुरुआत में, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException` को थ्रो करता है, जिससे अगला निर्यात शुरू नहीं होता। मेथड कोई सूची नहीं लौटाता।

## **FAQ**

**रद्दीकरण का अनुरोध कब करना चाहिए?**

जब कोई ऑपरेशन आपके समय सीमा से अधिक हो जाता है या जब आपका अनुप्रोग्राम अब परिणाम की आवश्यकता नहीं रखता है, तब रद्दीकरण का अनुरोध करें।

**[InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) के बीच क्या अंतर है?**

स्रोत आपके अनुप्रयोग को रद्दीकरण का अनुरोध करने देता है। टोकन Aspose.Slides और आपके अनुप्रयोग को उस अनुरोध की जाँच करने देता है।

**क्या मैं Java टाइमर से एक ऑपरेशन रद्द कर सकता हूँ?**

हाँ। प्रस्तुति से जुड़े स्रोत पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) को शेड्यूल करके कॉल करें।

**मैं किन ऑपरेशनों को बाधित कर सकता हूँ?**

आप लोडिंग, सहेजने और रेंडरिंग को बाधित कर सकते हैं। टोकन को [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) में [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) के माध्यम से पास करें। तब प्रस्तुति बाद के ऑपरेशनों जैसे PDF में सहेजने के दौरान रद्दीकरण को देख सकती है।

**क्या ऑपरेशन तुरंत रुक जाता है?**

रद्दीकरण सहयोगी है। एक ऑपरेशन टोकन को समय‑समय पर जांचता है और अनुरोध को देख लेते ही रुक जाता है।

**यदि मैं किसी ऑपरेशन के समाप्त होने के बाद [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) कॉल करता हूँ तो क्या होता है?**

पूरा हुआ ऑपरेशन अपना परिणाम बरकरार रखता है।

**क्या कई ऑपरेशनों में एक ही [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) साझा किया जा सकता है?**

हाँ। [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करने से उस स्रोत से टोकन उपयोग करने वाले हर ऑपरेशन के लिए रद्दीकरण का अनुरोध होता है। प्रत्येक ऑपरेशन को स्वतंत्र रूप से रद्द करना चाहते हैं तो अलग स्रोत उपयोग करें।