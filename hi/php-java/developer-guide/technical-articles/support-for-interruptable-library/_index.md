---
title: PHP में लंबी‑चलने वाली प्रस्तुति संचालन को बाधित करें
linktitle: प्रस्तुति संचालन को बाधित करें
type: docs
weight: 120
url: /hi/php-java/support-for-interruptable-library/
keywords:
- विचलन टोकन
- रद्दीकरण
- रूपांतरण टाइमआउट
- स्लाइड निर्यात
- PowerPoint
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ टाइमर पर प्रस्तुति रूपांतरण को रद्द करने और रद्दीकरण से पहले निर्यात की गई स्लाइड्स वापस करने का तरीका सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java लंबी अवधि चलने वाली प्रक्रियाओं जैसे लोडिंग, सेविंग और प्रेजेंटेशन रेंडरिंग को बाधित कर सकता है। एक लूप में जहाँ एक‑एक स्लाइड निर्यात की जाती है, वही टोकन आपके अनुप्रयोग को अगली स्लाइड से पहले रोकने और पूर्ण हुए निर्यातों की सूची लौटाने की अनुमति देता है।

दोनों PHP उदाहरण मानते हैं कि आपका बूटस्ट्रैप `define("JAVA_PREFER_VALUES", 1);` को `Java.inc` को लोड करने से पहले कॉल करता है, फिर `aspose.slides.php` को लोड करता है। यह सेटिंग PHP को कॉल के दौरान Java अपवादों को पकड़ने देती है। उदाहरण रैप्ड अपवाद के कारण की जाँच करते हैं ताकि अन्य रूपांतरण त्रुटियाँ कॉलर तक पहुँच सकें।

## **प्रेजेंटेशन ऑपरेशन को बाधित करें**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), obtain its token with [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), and pass it to [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Supply these options when constructing the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Calling [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) requests cancellation. A running operation stops when it observes the request.

### **रूपांतरण टाइमआउट सेट करें**

जब PHP PHP/Java Bridge के माध्यम से सिंक्रोनस लोड या सेव की प्रतीक्षा करता है, एक Java टाइमर अलग थ्रेड पर रद्दीकरण का अनुरोध कर सकता है। नीचे दिया गया हेल्पर `ConversionTimeout.java` के रूप में सहेजें, क्लासपाथ पर Aspose.Slides JAR के साथ इसे कंपाइल करें, और कम्पाइल्ड क्लास को पुल के तहत उसके पैकेज नाम `example.ConversionTimeout` के साथ उपलब्ध कराएँ।

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

पुल और Aspose.Slides PHP रैपर लोड होने के बाद, नीचे दिया गया उदाहरण `sample.pptx` के साथ चलाएँ जो Java प्रक्रिया की वर्किंग डायरेक्टरी में हो, या उस प्रक्रिया के लिये उपलब्ध निरपेक्ष पाथ उपयोग करें। 20‑सेकंड की सीमा लोडिंग और PDF निर्यात दोनों को कवर करती है। यदि रूपांतरण शीघ्र समाप्त हो जाता है, तो PHP टाइमर को रद्द कर देगा। पुराने PowerPoint फॉर्मेट को 10‑सेकंड की सीमा के साथ रूपांतरित करने के लिये `sample.ppt`, `SaveFormat::Ppt`, और `10000` मिलिसेकंड का प्रयोग करें।

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **अगली स्लाइड के प्रोसेसिंग से पहले रोकें**

प्रत्येक निर्यात से पहले [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) की जाँच करें। चयनित स्लाइड्स के लिये [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) ओवरलोड स्लाइड नंबर 1 से शुरू लेता है। प्रत्येक स्लाइड के लिये अलग PDF लिखने हेतु एक‑तत्व वाली एरे पास करें।

कम से कम दो स्लाइड्स वाला `sample.pptx` उपयोग करें। निर्यातों के बीच रद्दीकरण दिखाने के लिये, उदाहरण पहले स्लाइड को रिकॉर्ड करने के तुरंत बाद अनुरोध करता है।

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

उदाहरण `slide-1.pdf` लिखता है और `Completed: [1]` प्रिंट करता है। दूसरा इटरेशन अनुरोध को दूसरे निर्यात से पहले देखता है। यदि सेव के दौरान रद्दीकरण हो जाता है, तो सूची में केवल पहले पुष्टि किए गये निर्यात ही होते हैं। एक बाधित सेव डिस्क पर अपूर्ण फ़ाइल छोड़ सकता है।

कॉलर को रद्दीकरण पहुँचाने के लिये, लूप की शुरुआत में जाँच को `$token->throwIfInterruptionRequested();` से बदलें और अंदर के `try`/`catch` को हटाएँ, जबकि सेव और उसके बाद की जाँच को रखें। समान इनपुट के साथ, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) स्लाइड 2 से पहले एक्सेप्शन उठाता है और कॉलर को कोई सूची प्राप्त नहीं होती।

## **अक्सर पूछे जाने वाले प्रश्न**

**मुझे रद्दीकरण का अनुरोध कब करना चाहिए?**

जब कोई डेडलाइन समाप्त हो जाती है या कॉलर को परिणाम की अब आवश्यकता नहीं रहती, तब रद्दीकरण का अनुरोध करें। ऑपरेशन समाप्त होने के बाद किया गया अनुरोध उसका परिणाम अपरिवर्तित छोड़ देता है।

**स्रोत और टोकन में क्या अंतर है?**

स्रोत अनुप्रयोग को रद्दीकरण का अनुरोध करने देता है। टोकन Aspose.Slides और अनुप्रयोग कोड को वह अनुरोध देख पाने की अनुमति देता है।

**क्या कई ऑपरेशन्स एक ही स्रोत को साझा कर सकते हैं?**

हाँ। एक अनुरोध उस स्रोत से प्राप्त टोकन का उपयोग करने वाले सभी ऑपरेशन्स पर लागू होता है। स्वतंत्र रद्दीकरण की आवश्यकता वाली ऑपरेशन्स के लिये अलग-अलग स्रोत बनाएँ।