---
title: प्रेजेंटेशन स्लाइड्स पर आकृतियों का आकार बदलें
type: docs
weight: 110
url: /hi/java/re-sizing-shapes-on-slide/
keywords:
- आकृति का आकार बदलें
- आकृति आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से आकृतियों का आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides for Java के ग्राहकों से अक्सर पूछे जाने वाले प्रश्नों में से एक है कि स्लाइड का आकार बदलने पर आकृतियों का आकार कैसे बदलें ताकि डेटा कट न जाए। यह संक्षिप्त तकनीकी लेख दिखाता है कि इसे कैसे किया जाए।

## **आकृतियों का आकार बदलें**

स्लाइड का आकार बदलने पर आकृतियों का असंतुलन न हो, इसके लिए प्रत्येक आकृति की स्थिति और आकार को नए स्लाइड लेआउट के अनुसार अद्यतन करें।

```java
import com.aspose.slides.*;

// प्रेजेंटेशन फ़ाइल लोड करें।
Presentation presentation = new Presentation("sample.ppt");
try {
    // मौलिक स्लाइड आकार प्राप्त करें।
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // मौजूदा आकृतियों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // प्रत्येक स्लाइड पर आकृतियों का आकार बदलें और उनकी स्थिति पुनः निर्धारित करें।
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // आकृति का आकार स्केल करें।
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // आकृति की स्थिति स्केल करें।
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
टेबल को कोई विशेष उपचार नहीं चाहिए: टेबल की चौड़ाई और ऊँचाई सेट करने पर उसके कॉलम और पंक्तियाँ अनुपातिक रूप से पुनः स्केल हो जाती हैं, इसलिए पंक्ति की ऊँचाई और कॉलम की चौड़ाई को फिर से स्केल करने से अनुपात दो बार लागू हो जाएगा। 
{{% /alert %}} 

ऊपर दिया गया कोड केवल स्लाइडों पर मौजूद आकृतियों को बदलता है। मास्टर स्लाइड और लेआउट स्लाइड अपनी स्वयं की आकृतियों को रखते हैं, इसलिए यदि आप संपूर्ण प्रस्तुति को नए स्लाइड आकार के अनुरूप बनाना चाहते हैं तो उन्हें भी स्केल करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // मौलिक स्लाइड आकार प्राप्त करें।
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // मौजूदा आकृतियों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // आकृति का आकार स्केल करें।
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // आकृति की स्थिति स्केल करें।
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // आकृति का आकार स्केल करें।
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // आकृति की स्थिति स्केल करें।
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // आकृति का आकार स्केल करें।
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // आकृति की स्थिति स्केल करें।
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### स्लाइड का आकार बदलने के बाद आकृतियाँ बिगड़ या कट क्यों जाती हैं?

स्लाइड का आकार बदलने पर, जब तक स्केल स्पष्ट रूप से नहीं बदला जाता, आकृतियाँ अपनी मूल स्थिति और आकार रखती हैं। इससे सामग्री कट सकती है या आकृतियों का असंतुलन हो सकता है।

### क्या प्रदान किया गया कोड सभी आकृति प्रकारों के लिए काम करता है?

हाँ। ऊँचाई और चौड़ाई सेट करना टेक्स्ट बॉक्स, छवियों, चार्ट और टेबल सभी के लिए समान रूप से काम करता है।

### स्लाइड का आकार बदलते समय टेबल का आकार कैसे बदलूँ?

टेबल आकृति को स्वयं स्केल करें, बिल्कुल अन्य आकृतियों की तरह। उसकी पंक्तियों और कॉलमों का अनुपातिक रूप से स्केल हो जाता है, इसलिए बाद में उन्हें फिर से स्केल न करें।

### क्या यह आकार बदलना मास्टर स्लाइड और लेआउट स्लाइड के लिए भी काम करेगा?

हाँ, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getMasters--) और [Layout slides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getLayoutSlides--) के माध्यम से भी लूप करना चाहिए और उनकी आकृतियों पर समान स्केलिंग लॉजिक लागू करना चाहिए ताकि प्रस्तुति में सुसंगतता बनी रहे।

### क्या मैं स्लाइड का अभिविन्यास (पोर्ट्रेट/लैंडस्केप) बदलते हुए आकार बदल सकता हूँ?

हाँ। आप [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#setOrientation-int-) का उपयोग करके अभिविन्यास बदल सकते हैं। लेआउट को बनाए रखने के लिए स्केलिंग लॉजिक को उसी अनुसार सेट करना सुनिश्चित करें।

### मैं जिस स्लाइड आकार को सेट कर सकता हूँ, उसके लिए कोई सीमा है क्या?

Aspose.Slides अनुकूलित आकारों को सपोर्ट करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों के साथ संगतता को प्रभावित कर सकते हैं।

### नियत अनुपात वाली आकृतियों के विकृत होने से कैसे बचूँ?

आप स्केल करने से पहले आकृति के `getAspectRatioLocked` मेथड की जाँच कर सकते हैं। यदि यह लॉक है, तो व्यक्तिगत रूप से स्केल करने के बजाय चौड़ाई या ऊँचाई को अनुपातिक रूप से समायोजित करें।