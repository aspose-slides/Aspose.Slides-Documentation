---
title: Node.js में लंबी-चलाने वाली प्रस्तुति ऑपरेशनों को बाधित करें
linktitle: प्रस्तुति ऑपरेशनों को बाधित करें
type: docs
weight: 120
url: /hi/nodejs-java/support-for-interruptable-library/
keywords:
- विच्छेदन योग्य ऑपरेशन्स
- विच्छेदन टोकन
- रद्दीकरण टोकन
- रूपांतरण टाइमआउट
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में लंबी-चलाने वाली प्रस्तुति ऑपरेशनों को रद्द करें, रूपांतरण टाइमआउट सेट करें, और रद्दीकरण से पहले निर्यात की गई स्लाइडों का ट्रैक रखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java लोड करने, सहेजने, या प्रस्तुति को रेंडर करने के समय रद्दीकरण का समर्थन करता है। आप अपने स्वयं के निर्यात लूप में समान टोकन की जाँच भी कर सकते हैं ताकि अगली स्लाइड से पहले रुकें और पहले से सहेजी गई स्लाइडों की संख्या लौटाएँ।

## **प्रेजेंटेशन ऑपरेशन को बाधित करें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/) बनाएं, उसका टोकन [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) से प्राप्त करें, और उसे [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken) को पास करें। इन विकल्पों का उपयोग [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाते समय करें। स्रोत पर [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करने से वर्तमान ऑपरेशन रद्दीकरण का अनुरोध करता है। Aspose.Slides अगले बार टोकन की जाँच करने पर रुक जाता है।

### **रूपांतरण टाइमआउट सेट करें**

निम्न उदाहरण `sample.pptx` को खोलने और `sample.pdf` के रूप में सहेजने के लिए 20 सेकंड की अनुमति देता है। कंस्ट्रक्टर और सहेजना दोनों Java ब्रिज के माध्यम से असिंक्रोनस रूप से चलते हैं ताकि Node.js टाइमर किसी भी ऑपरेशन के दौरान फ़ायर हो सके। उदाहरण लोड करने के बाद और सहेजने के बाद टोकन की जाँच करता है, क्योंकि लाइब्रेरी कॉल रद्दीकरण अनुरोध के बाद भी लौट सकती है। यह ऑपरेशन समाप्त होने पर प्रस्तुति को रिलीज़ करता है और यदि रूपांतरण जल्दी समाप्त हो जाता है तो टाइमर को साफ़ करता है। यदि सहेजने के दौरान रद्दीकरण होता है, तो आउटपुट फ़ाइल पहले से मौजूद हो सकती है और अधूरी हो सकती है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

पुराने PowerPoint फ़ॉर्मेट में 10‑सेकंड सीमा के साथ रूपांतरित करने के लिए, आखिरी तीन तर्कों के रूप में `"sample.ppt"`, `slides.SaveFormat.Ppt`, और `10000` पास करें।

## **अगली स्लाइड प्रक्रिया से पहले रोकें**

जब कॉलर आंशिक परिणाम का उपयोग कर सकता है, तो प्रत्येक निर्यात से पहले [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) का उपयोग करें। चयनित स्लाइडों के लिए [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) ओवरलोड Java `int[]` लेता है जिसमें स्लाइड नंबर 1 से शुरू होते हैं। प्रत्येक संख्या को केवल तभी रिकॉर्ड करें जब उसका PDF सफलतापूर्वक सहेजा गया हो।

उदाहरण को `sample.pptx` नामक प्रस्तुति के साथ चलाएँ जिसमें कम से कम दो स्लाइड हों। निर्यातों के बीच रद्दीकरण दिखाने के लिए, उदाहरण पहले स्लाइड को सहेजने के तुरंत बाद इसका अनुरोध करता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

उदाहरण `slide-1.pdf` लिखता है और `Starting slide 1` के बाद `Completed: [1]` प्रिंट करता है। लूप स्लाइड 2 शुरू करने से पहले रद्दीकरण का निरीक्षण करता है। यदि सहेजना स्वयं बाधित हो जाता है, तो लौटी हुई सूची केवल पूर्व के सफल निर्यातों को रखती है।

कॉलर को रद्दीकरण को त्रुटि के रूप में संभालने के लिए, लूप के शीर्ष पर जांच और उसके `break` को [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) से बदलें, जिसे `token.throwIfInterruptionRequested()` के रूप में कॉल किया जाता है। सहेजने के बाद समान थ्रोज़ जांच का उपयोग करें और उसके चारों ओर के `try`/`catch` को हटा दें। समान इनपुट के साथ, पहला PDF अभी भी लिखा जाता है, और दूसरा इटरशन फ़ंक्शन के सूची लौटने से पहले थ्रो होता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं रद्दीकरण कब अनुरोध करूँ?**  
जब समय सीमा समाप्त हो जाए या एप्लीकेशन को परिणाम की अब आवश्यकता न रहे, तो रद्दीकरण का अनुरोध करें। लोड करना, सहेजना, और रेंडर करना सभी निर्माण के समय प्रस्तुति को पास किए गए टोकन का उपयोग कर सकते हैं।

**स्रोत और टोकन में क्या अंतर है?**  
स्रोत एप्लीकेशन को रद्दीकरण अनुरोध करने की अनुमति देता है। टोकन Aspose.Slides और आपके अपने कोड को उस अनुरोध की जाँच करने देता है।

**क्या Node.js टाइमर सिंक्रोनस सहेजने को बाधित कर सकता है?**  
एक सिंक्रोनस सहेजना कॉलिंग थ्रेड पर JavaScript को ब्लॉक करता है। टाइमर को सहेजने के चलने के दौरान रद्दीकरण का अनुरोध करने देने के लिए टाइमआउट उदाहरण में दिखाए गए असिंक्रोनस Java ब्रिज कॉल्स का उपयोग करें।

**क्या रद्दीकरण तुरंत प्रभावी हो जाता है?**  
रद्दीकरण सहयोगी होता है। चल रहा ऑपरेशन तब रुकता है जब वह अनुरोध देखता है। जिसने पहले ही समाप्त किया है, वह अपना परिणाम रखता है।

**क्या कई ऑपरेशन्स एक स्रोत साझा कर सकते हैं?**  
हां। `interrupt()` को कॉल करने से उस स्रोत से टोकन उपयोग करने वाले प्रत्येक ऑपरेशन के लिए रद्दीकरण अनुरोध किया जाता है। उन ऑपरेशनों के लिए अलग स्रोत उपयोग करें जिन्हें आप स्वतंत्र रूप से रद्द करना चाहते हैं।