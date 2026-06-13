---
title: Node.js के लिए Aspose.Slides (Java के माध्यम से) में मल्टीथ्रेडिंग
linktitle: मल्टीथ्रेडिंग
type: docs
weight: 310
url: /hi/nodejs-java/multithreading/
keywords:
- मल्टीथ्रेडिंग
- कई थ्रेड
- समानांतर कार्य
- स्लाइड्स परिवर्तित करें
- स्लाइड्स से छवियां
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides (Java के माध्यम से) में मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रोसेसिंग को तेज करता है। कुशल प्रस्तुति कार्यप्रवाहों के लिए सर्वश्रेष्ठ प्रथाओं की खोज करें।"
---
## **परिचय**

जबकि प्रस्तुतियों के साथ समानांतर कार्य संभव है (पार्सिंग/लोडिंग/क्लोनिंग के अलावा) और अधिकांश समय सब कुछ ठीक चलता है, तब भी थोड़ी संभावना है कि आप लाइब्रेरी को कई थ्रेड्स में उपयोग करने पर गलत परिणाम प्राप्त कर सकते हैं।

हम दृढ़ता से अनुशंसा करते हैं कि आप मल्टी-थ्रेडिंग परिवेश में एक एकल [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) इंस्टेंस का उपयोग **न** करें क्योंकि इससे अप्रत्याशित त्रुटियां या विफलताएं हो सकती हैं जिन्हें आसानी से पता नहीं लगाया जा सकता।

यह **सुरक्षित नहीं** है कि कई थ्रेड्स में [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास के एक इंस्टेंस को लोड, सेव या क्लोन किया जाए। ऐसे संचालन **समर्थित नहीं** हैं। यदि आपको ऐसे कार्य करने की आवश्यकता है, तो आपको कई सिंगल-थ्रेडेड प्रक्रियाओं का उपयोग करके संचालन को समानांतर करना होगा — और इन प्रत्येक प्रक्रियाओं को अपना स्वयं का प्रस्तुति इंस्टेंस उपयोग करना चाहिए।

## **समांतर रूप से प्रस्तुति स्लाइड्स को छवियों में परिवर्तित करें**

मान लेते हैं कि हम सभी स्लाइड्स को एक PowerPoint प्रस्तुति से PNG छवियों में समांतर रूप से परिवर्तित करना चाहते हैं। चूँकि कई थ्रेड्स में एकल `Presentation` इंस्टेंस का उपयोग असुरक्षित है, हम प्रस्तुति स्लाइड्स को अलग-अलग प्रस्तुतियों में विभाजित करते हैं और प्रत्येक प्रस्तुति को अलग थ्रेड में उपयोग करके स्लाइड्स को छवियों में समांतर रूप से परिवर्तित करते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि यह कैसे किया जाता है।

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // स्लाइड i को एक अलग प्रस्तुति में निकालें।
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // सभी कार्यों के पूर्ण होने की प्रतीक्षा करें।
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रत्येक थ्रेड में लाइसेंस सेटअप को कॉल करना आवश्यक है?**

नहीं। प्रक्रिया/ऐप डोमेन के प्रति एक बार इसे करना पर्याप्त है, थ्रेड्स शुरू होने से पहले। यदि [license setup](/slides/hi/nodejs-java/licensing/) समानांतर रूप से (उदाहरण के लिए, लेज़ी इनिशियलाइज़ेशन के दौरान) कॉल किया जा सकता है, तो उस कॉल को समन्वित करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड-सेफ नहीं है।

**क्या मैं `Presentation` या `Slide` ऑब्जेक्ट्स को थ्रेड्स के बीच पास कर सकता हूँ?**

थ्रेड्स के बीच "लाइव" प्रस्तुति ऑब्जेक्ट्स को पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र इंस्टेंस का उपयोग करें या प्रत्येक थ्रेड के लिए अलग प्रस्तुतियों/स्लाइड कंटेनरों को पूर्व-निर्मित करें। यह दृष्टिकोण सामान्य अनुशंसा के अनुरूप है कि एकल प्रस्तुति इंस्टेंस को थ्रेड्स के बीच साझा न करें।

**क्या प्रत्येक थ्रेड के पास अपना स्वयं का `Presentation` इंस्टेंस होने पर विभिन्न फ़ॉर्मैट (PDF, HTML, images) में निर्यात को समांतर करना सुरक्षित है?**

हाँ। स्वतंत्र इंस्टेंस और अलग-अलग आउटपुट पाथ के साथ, ऐसे कार्य आमतौर पर सही ढंग से समांतर हो जाते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम से बचें।

**मल्टी-थ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर्स, सब्स्टिट्यूशन) के साथ मुझे क्या करना चाहिए?**

थ्रेड्स शुरू करने से पहले सभी ग्लोबल फ़ॉन्ट सेटिंग्स को इनिशियलाइज़ करें और समांतर कार्य के दौरान उन्हें बदले नहीं। इससे साझा फ़ॉन्ट संसाधनों तक पहुँच में रेस स्थितियाँ समाप्त हो जाती हैं।