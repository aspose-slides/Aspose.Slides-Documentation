---
title: Aspose.Slides for Java में मल्टीथ्रेडिंग
linktitle: मल्टीथ्रेडिंग
type: docs
weight: 310
url: /hi/java/multithreading/
keywords:
- मल्टीथ्रेडिंग
- एकाधिक थ्रेड्स
- समानांतर कार्य
- स्लाइड्स को रूपांतरित करें
- स्लाइड्स को छवियों में बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रोसेसिंग को बढ़ाता है। कुशल प्रस्तुति कार्यप्रवाहों के लिए सर्वोत्तम प्रथाओं की खोज करें।"
---
## **परिचय**

जबकि प्रस्तुतियों के साथ समानांतर कार्य संभव है (पार्सिंग/लोडिंग/क्लोनिंग के अलावा) और अधिकांश समय सब ठीक चलता है, कई थ्रेड्स में लाइब्रेरी का उपयोग करने पर गलत परिणाम मिलने की थोड़ी संभावना रहती है।

हम दृढ़ता से अनुशंसा करते हैं कि आप मल्टी‑थ्रेडिंग वातावरण में एकल [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) इंस्टेंस का उपयोग **न** करें क्योंकि इससे अप्रत्याशित त्रुटियां या विफलताएं उत्पन्न हो सकती हैं जिन्हें आसानी से पता नहीं लगाया जा सकता।

कई थ्रेड्स में एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस लोड, सेव या क्लोन करना **सुरक्षित नहीं** है। ऐसी क्रियाओं का समर्थन **नहीं** किया जाता है। यदि आपको इन कार्यों को करने की आवश्यकता है, तो आपको कई सिंगल‑थ्रेडेड प्रोसेस का उपयोग करके कार्यों को समानांतर करना होगा—और इन प्रत्येक प्रोसेस को अपना स्वयं का प्रस्तुति इंस्टेंस उपयोग करना चाहिए।

## **समानांतर रूप से प्रस्तुति स्लाइड्स को इमेज में बदलें**

मान लीजिए हम सभी स्लाइड्स को एक PowerPoint प्रस्तुति से PNG इमेज में समानांतर रूप से बदलना चाहते हैं। क्योंकि कई थ्रेड्स में एकल `Presentation` इंस्टेंस का उपयोग असुरक्षित है, हम प्रस्तुति स्लाइड्स को अलग-अलग प्रस्तुतियों में विभाजित करते हैं और प्रत्येक प्रस्तुति को अलग थ्रेड में उपयोग करके स्लाइड्स को इमेज में बदलते हैं। निम्नलिखित कोड उदाहरण दर्शाता है कि यह कैसे किया जाए।

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // स्लाइड i को एक अलग प्रस्तुति में निकालें।
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // स्लाइड को एक अलग कार्य में छवि में परिवर्तित करें।
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// सभी कार्यों के पूरा होने की प्रतीक्षा करें.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे हर थ्रेड में लाइसेंस सेटअप को कॉल करना आवश्यक है?**

नहीं। थ्रेड शुरू होने से पहले प्रक्रिया/ऐप डोमेन में एक बार इसे करना पर्याप्त है। यदि [license setup](/slides/hi/java/licensing/) समानांतर रूप से (उदाहरण के लिए, लेज़ी इनिशियलाइज़ेशन के दौरान) बुलाया जा सकता है, तो उस कॉल को सिंक्रनाइज़ करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड‑सेफ़ नहीं है।

**क्या मैं `Presentation` या `Slide` ऑब्जेक्ट्स को थ्रेड्स के बीच पास कर सकता हूँ?**

थ्रेड्स के बीच "लाइव" प्रस्तुति ऑब्जेक्ट्स को पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र इंस्टेंस उपयोग करें या प्रत्येक थ्रेड के लिए अलग प्रस्तुतियों/स्लाइड कंटेनर पहले से बनाएं। यह तरीका सामान्य सिफ़ारिश के अनुरूप है कि एकल प्रस्तुति इंस्टेंस को थ्रेड्स के बीच साझा न किया जाए।

**यदि प्रत्येक थ्रेड के पास अपना `Presentation` इंस्टेंस हो, तो विभिन्न फ़ॉर्मेट्स (PDF, HTML, इमेज) में एक्सपोर्ट को समानांतर करना सुरक्षित है क्या?**

हाँ। स्वतंत्र इंस्टेंस और अलग आउटपुट पाथ्स के साथ, ऐसे कार्य सामान्यतः सही ढंग से समानांतर हो जाते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम्स से बचें।

**मल्टीथ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर्स, सब्स्टिट्यूशन) के साथ मुझे क्या करना चाहिए?**

थ्रेड्स शुरू करने से पहले सभी ग्लोबल [font settings](/slides/hi/java/powerpoint-fonts/) को इनिशियलाइज़ करें और समानांतर कार्य के दौरान उन्हें बदलें नहीं। इससे साझा फ़ॉन्ट संसाधनों तक पहुँचने के दौरान रेस कंडीशन समाप्त हो जाती है।