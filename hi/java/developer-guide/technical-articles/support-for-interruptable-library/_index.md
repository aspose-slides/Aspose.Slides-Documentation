---
title: Java में लंबी चलने वाली प्रेजेंटेशन ऑपरेशन्स को रोकें
linktitle: प्रेजेंटेशन ऑपरेशन्स को रोकें
type: docs
weight: 120
url: /hi/java/support-for-interruptable-library/
keywords:
- रोकने योग्य ऑपरेशन्स
- इंटरप्शन टोकन
- रद्दीकरण टोकन
- लंबी चलने वाला कार्य
- कार्य को रोकें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में लंबी चलने वाली प्रेजेंटेशन ऑपरेशन्स को कैसे रद्द करें और लूप में स्लाइड्स निर्यात करते समय आंशिक परिणाम कैसे लौटाएँ, यह जानें।"
---
## **अवलोकन**

Aspose.Slides for Java लंबी चलने वाली प्रक्रियाओं जैसे लोडिंग, सेविंग और प्रेजेंटेशन रेंडरिंग को बाधित कर सकता है। आपका एप्लिकेशन उसी इंटरप्शन टोकन का उपयोग करके अगले स्लाइड को प्रोसेस करने से पहले लूप को रोक सकता है।

## **प्रेजेंटेशन ऑपरेशन को बाधित करें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) बनाएँ, उसका टोकन [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--) से प्राप्त करें, और टोकन को [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) में पास करें। लोड विकल्पों को [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) में पास करें। रद्दीकरण का अनुरोध करने के लिए स्रोत पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करें। जब इंटरप्टेबल ऑपरेशन अनुरोध को देखता है, तो वह रुक जाता है।

उदाहरण पृष्ठभूमि थ्रेड में `sample.pptx` को `sample.ppt` में बदलता है। कॉल करने वाला थ्रेड रूपांतरण समाप्त होने के लिए अधिकतम 10 सेकंड तक इंतजार करता है। यदि रूपांतरण अभी भी चल रहा है, तो यह रद्दीकरण का अनुरोध करता है और कार्यकर्ता के समाप्त होने की प्रतीक्षा करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
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
```

## **Java टाइमआउट को Aspose.Slides से जोड़ें**

प्रेजेंटेशन ऑपरेशन पर समय सीमा निर्धारित करने के लिए, [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) का उपयोग करके टाइमआउट समाप्त होने पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करें। उदाहरण 20 सेकंड देता है `sample.pptx` लोड करने और इसे `sample.pdf` में निर्यात करने के लिए। यदि निर्यात जल्दी समाप्त हो जाता है, तो एप्लिकेशन नियोजित अनुरोध को रद्द कर देता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **अगले स्लाइड को प्रोसेस करने से पहले रोकें**

प्रेजेंटेशन और उसकी स्लाइड्स को निर्यात करने वाले लूप दोनों के लिए वही [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) प्रयोग करें। प्रत्येक निर्यात से पहले [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) जांचें। यदि कॉलर आधा परिणाम उपयोग कर सकता है, तो सफलतापूर्वक निर्यात हुई स्लाइड नंबरों को लौटाएँ।

`sample.pptx` नामक प्रेजेंटेशन जिसका कम से कम दो स्लाइड हैं, उपयोग करें। वह [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) ओवरलोड जो स्लाइड नंबरों की एरे लेता है, 1 से गिनती शुरू करता है। उदाहरण प्रत्येक स्लाइड को अलग PDF में सहेजता है और पहले सफल निर्यात को रिकॉर्ड करने के बाद तुरंत रद्दीकरण का अनुरोध करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
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
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

उदाहरण `slide-1.pdf` बनाता है और `Starting slide 1` प्रिंट करता है, उसके बाद `Completed: [1]`। स्लाइड 2 शुरू करने से पहले लूप अनुरोध को देखता है। यदि सहेजते समय रद्दीकरण आता है, तो लूप उस स्लाइड को पूर्ण के रूप में रिकॉर्ड करने से पहले बाहर निकल जाता है।

यदि कॉलर को रद्दीकरण संभालना है, तो लूप के शीर्ष पर जांच और उसका `break` को `token.throwIfInterruptionRequested()` से बदल दें। सहेजने के आसपास का `try`/`catch` हटाएँ ताकि निर्यात के दौरान रद्दीकरण भी कॉलर तक पहुंच सके। समान इनपुट के साथ, उदाहरण केवल `Starting slide 1` प्रिंट करता है और `slide-1.pdf` बनाता है। दूसरे इटरशन की शुरुआत में, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException` फेंकता है अगला निर्यात शुरू होने से पहले। यह मेथड कोई सूची नहीं लौटाता।

## **अक्सर पूछे जाने वाले प्रश्न**

**कभी रद्दीकरण का अनुरोध करना चाहिए?**

जब कोई ऑपरेशन आपके समय सीमा से अधिक हो जाता है या आपका एप्लिकेशन परिणाम की आवश्यकता नहीं रखता, तब रद्दीकरण का अनुरोध करें।

**[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) के बीच अंतर क्या है?**

स्रोत आपके एप्लिकेशन को रद्दीकरण का अनुरोध करने देता है। टोकन Aspose.Slides और आपके एप्लिकेशन को उस अनुरोध की जाँच करने देता है।

**क्या मैं Java टाइमर से ऑपरेशन को रद्द कर सकता हूँ?**

हाँ। प्रेजेंटेशन से जुड़े स्रोत पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) को शेड्यूल करके कॉल करें।

**मैं कौन से ऑपरेशन को बाधित कर सकता हूँ?**

आप लोडिंग, सेविंग और रेंडरिंग को बाधित कर सकते हैं। टोकन को [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) में [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) के माध्यम से पास करें। इसके बाद प्रेजेंटेशन बाद के ऑपरेशन्स जैसे PDF में सहेजना के दौरान रद्दीकरण देख सकता है।

**क्या ऑपरेशन तुरंत रुक जाता है?**

रद्दीकरण सहयोगी होता है। ऑपरेशन समय-समय पर टोकन जांचता है और अनुरोध को देखे जाने पर रुक जाता है।

**यदि मैं ऑपरेशन समाप्त होने के बाद [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करता हूँ तो क्या होता है?**

पूरा हुआ ऑपरेशन अपना परिणाम बनाये रखता है।

**क्या कई ऑपरेशन्स एक [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) साझा कर सकते हैं?**

हाँ। [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) को कॉल करने से उस स्रोत से टोकन उपयोग करने वाले सभी ऑपरेशन्स का रद्दीकरण अनुरोध हो जाता है। प्रत्येक ऑपरेशन को स्वतंत्र रूप से रद्द करने के लिए अलग स्रोत उपयोग करें।