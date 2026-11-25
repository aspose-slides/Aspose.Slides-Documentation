---
title: Python में दीर्घकालिक प्रस्तुति संचालन को बाधित करें
linktitle: प्रस्तुति संचालन को बाधित करें
type: docs
weight: 120
url: /hi/python-java/support-for-interruptable-library/
keywords:
- बाध्यात्मक संचालन
- इंटरप्शन टोकन
- रद्दीकरण टोकन
- दीर्घकालिक कार्य
- कार्य को बाधित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में दीर्घकालिक प्रस्तुति संचालन को रद्द करने और लूप में स्लाइड निर्यात करते समय आंशिक परिणाम लौटाने का तरीका सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java लोडिंग, सेविंग और प्रस्तुति रेंडरिंग जैसी लंबी अवधि वाली ऑपरेशनों को रोक सकता है। आपका एप्लिकेशन समान इंटरप्शन टोकन का उपयोग करके लूप को अगले स्लाइड को प्रोसेस करने से पहले रोक सकता है।

## **प्रस्तुति संचालन को रोकें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) बनाएँ, उसका टोकन [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) से प्राप्त करें, और टोकन को [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) में पास करें। लोड विकल्पों को [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) को पास करें। रद्दीकरण का अनुरोध करने के लिए स्रोत पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करें। एक इंटरप्टेबल ऑपरेशन अनुरोध को देख लेता ही रुक जाता है। Python में Java अपवाद `com.aspose.slides.exceptions.OperationCanceledException` को पकड़ने के लिए `jpype.JClass` का उपयोग करें।

उदाहरण में पृष्ठभूमि थ्रेड पर `sample.pptx` को `sample.ppt` में बदला जाता है। कॉल करने वाला थ्रेड रूपांतरण के समाप्त होने के लिए अधिकतम 10 सेकंड तक प्रतीक्षा करता है। यदि रूपांतरण अभी भी चल रहा है, तो वह रद्दीकरण का अनुरोध करता है और कार्यकर्ता के समाप्त होने की प्रतीक्षा करता है।

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **पाइथन टाइमआउट को Aspose.Slides से जोड़ें**

प्रस्तुति संचालन पर समय सीमा निर्धारित करने के लिए, टाइमआउट समाप्त होने पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करने हेतु एक [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) का उपयोग करें। उदाहरण में `sample.pptx` को लोड करने और `sample.pdf` में निर्यात करने के लिए 20 सेकंड की अनुमति दी गई है। यदि निर्यात जल्दी समाप्त हो जाता है, तो एप्लिकेशन निर्धारित अनुरोध को रद्द कर देता है।

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **अगले स्लाइड को प्रोसेस करने से पहले रोकें**

प्रस्तुति और उसके स्लाइड निर्यात करने वाले लूप के लिए समान [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) का उपयोग करें। प्रत्येक निर्यात से पहले [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) की जाँच करें। यदि कॉलर आंशिक परिणाम का उपयोग कर सकता है, तो सफलतापूर्वक पूर्ण हुए निर्यातों के स्लाइड नंबर लौटाएँ।

`sample.pptx` नामक प्रस्तुति का उपयोग करें जिसमें कम से कम दो स्लाइड हों। वह [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ओवरलोड जो Java `int[]` लेता है, स्लाइड नंबर 1 से शुरू करता है। Python में वह एरे बनाने के लिये `jpype.JArray(jpype.JInt)` का उपयोग करें। उदाहरण में प्रत्येक स्लाइड को अलग PDF में सहेजा जाता है और पहले सफल निर्यात को रिकॉर्ड करने के तुरंत बाद रद्दीकरण का अनुरोध किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

उदाहरण `slide-1.pdf` लिखता है और `Starting slide 1` प्रिंट करता है, इसके बाद `Completed: [1]` दिखाता है। लूप स्लाइड 2 शुरू करने से पहले अनुरोध को देख लेता है। यदि सहेजते समय रद्दीकरण आता है, तो लूप उस स्लाइड को पूर्ण के रूप में रिकॉर्ड किए बिना बाहर निकल जाता है।

यदि कॉलर को रद्दीकरण संभालना है, तो लूप के शीर्ष पर जांच और उसका `break` को `token.throwIfInterruptionRequested()` से बदलें। सहेजने के चारों ओर का `try`/`except` हटाएँ ताकि निर्यात के दौरान रद्दीकरण भी कॉलर तक पहुँच सके। समान इनपुट से उदाहरण केवल `Starting slide 1` प्रिंट करता है और `slide-1.pdf` लिखता है। दूसरे इटरिशन की शुरुआत में, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) अगले निर्यात शुरू होने से पहले `com.aspose.slides.exceptions.OperationCanceledException` उठाता है। अपवाद फ़ंक्शन के सूची लौटाने से पहले कॉलर तक प्रसारित हो जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मुझे कब रद्दीकरण का अनुरोध करना चाहिए?**  
जब कोई ऑपरेशन आपके समय सीमा से अधिक हो जाए या आपका एप्लिकेशन अब परिणाम की आवश्यकता न रखे, तब रद्दीकरण का अनुरोध करें।

**[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) में अंतर क्या है?**  
स्रोत आपके एप्लिकेशन को रद्दीकरण का अनुरोध करने देता है। टोकन Aspose.Slides और आपके एप्लिकेशन को उस अनुरोध की जाँच करने देता है।

**क्या मैं Python टाइमर से किसी ऑपरेशन को रद्द कर सकता हूँ?**  
हां। प्रस्तुति से जुड़े स्रोत पर [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करने के लिए शेड्यूल करें।

**मैं किन ऑपरेशनों को रोक सकता हूँ?**  
आप लोडिंग, सेविंग और रेंडरिंग को रोक सकते हैं। टोकन को [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) के माध्यम से [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) को पास करें। इसके बाद प्रस्तुति बाद की ऑपरेशनों जैसे PDF में सहेजने के दौरान रद्दीकरण देख सकती है।

**क्या कोई ऑपरेशन तुरंत रुक जाता है?**  
रद्दीकरण सहयोगी होता है। ऑपरेशन टोकन को समय-समय पर जांचता है और अनुरोध को देख लेते ही रुक जाता है।

**यदि ऑपरेशन समाप्त होने के बाद मैं [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) कॉल करता हूँ तो क्या होता है?**  
पूरा हुआ ऑपरेशन अपना परिणाम रखता है।

**क्या कई ऑपरेशन एक [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) साझा कर सकते हैं?**  
हां। [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करने से उस स्रोत के टोकन का उपयोग करने वाले सभी ऑपरेशनों के लिए रद्दीकरण का अनुरोध किया जाता है। ऐसी प्रत्येक ऑपरेशन के लिये जो आप स्वतंत्र रूप से रद्द करना चाहते हैं, एक अलग स्रोत प्रयोग करें।