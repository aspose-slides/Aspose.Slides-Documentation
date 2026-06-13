---
title: प्रस्तुति स्लाइड पर आकार बदलें
type: docs
weight: 110
url: /hi/java/re-sizing-shapes-on-slide/
keywords:
- आकार बदलें
- आकार का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument स्लाइड्स पर आकार आसानी से बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides for Java ग्राहकों के सबसे आम प्रश्नों में से एक है स्लाइड का आकार बदलते समय आकारों को कैसे पुनःआकार दिया जाए ताकि डेटा कट न जाए। यह छोटा तकनीकी लेख दर्शाता है कि इसे कैसे किया जाता है।

## **आकार को पुनःआकार दें**

स्लाइड का आकार बदलते समय आकारों के विसंरेखित होने से बचने के लिए, प्रत्येक आकार की स्थिति और आयामों को अपडेट करें ताकि वे नई स्लाइड लेआउट के अनुरूप हों।

```java
// प्रेजेंटेशन फ़ाइल लोड करें।
Presentation presentation = new Presentation("sample.ppt");
try {
    // मूल स्लाइड आकार प्राप्त करें।
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // मौजूदा आकारों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // हर स्लाइड पर आकारों को पुनःआकार दें और पुनःस्थिति करें।
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

{{% alert color="primary" %}} 
यदि स्लाइड में तालिका (टेबल) सम्मिलित है, तो ऊपर दिया गया कोड सही ढंग से कार्य नहीं करेगा। उस स्थिति में, तालिका की प्रत्येक सेल को पुनःआकार देना आवश्यक है। 
{{% /alert %}} 

उन स्लाइडों को पुनःआकार देने के लिए नीचे दिया गया कोड उपयोग करें जिनमें तालिका हो। तालिकाओं के लिए चौड़ाई या ऊँचाई सेट करना एक विशेष मामला है: आपको तालिका के कुल आकार को बदलने के लिए व्यक्तिगत पंक्तियों की ऊँचाई और कॉलम की चौड़ाई को समायोजित करना होगा।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // मूल स्लाइड आकार प्राप्त करें।
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // मौजूदा आकारों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // आकृति के आकार को स्केल करें।
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // आकृति की स्थिति को स्केल करें।
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // आकृति के आकार को स्केल करें।
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // आकृति की स्थिति को स्केल करें।
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // आकृति के आकार को स्केल करें।
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // आकृति की स्थिति को स्केल करें।
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकार विकृत या कट क्यों जाते हैं?**

जब स्लाइड का आकार बदलते हैं, तो आकार अपनी मूल स्थिति और आकार को बनाए रखते हैं जब तक कि स्केल स्पष्ट रूप से न बदला जाए। इससे सामग्री कट सकती है या आकार विसंरेखित हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

बुनियादी उदाहरण अधिकांश आकार प्रकारों (टेक्स्ट बॉक्स, छवियाँ, चार्ट आदि) के लिए काम करता है। हालांकि, तालिकाओं के लिए आपको पंक्तियों और कॉलमों को अलग से संभालना होगा, क्योंकि तालिका की ऊँचाई और चौड़ाई व्यक्तिगत कोशिकाओं के आयामों द्वारा निर्धारित होती है।

**स्लाइड का आकार बदलते समय तालिकाओं को कैसे पुनःआकार दें?**

आपको तालिका की सभी पंक्तियों और कॉलमों के माध्यम से लूप करना होगा और उनके ऊँचाई और चौड़ाई को अनुपातिक रूप से पुनःआकार देना होगा, जैसा कि दूसरे कोड उदाहरण में दिखाया गया है।

**क्या यह पुनःआकार काम करेगा मास्टर स्लाइड और लेआउट स्लाइड के लिए भी?**

हाँ, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getMasters--) और [Layout slides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getLayoutSlides--) के माध्यम से भी लूप करना चाहिए और उनके आकारों पर वही स्केलिंग लॉजिक लागू करना चाहिए ताकि प्रस्तुति में निरंतरता बनी रहे।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को पुनःआकार के साथ बदल सकता हूँ?**

हां। आप [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#setOrientation-int-) का उपयोग करके अभिविन्यास बदल सकते हैं। लेआउट बनाए रखने के लिए स्केलिंग लॉजिक को उसी अनुसार सेट करें।

**क्या स्लाइड आकार सेट करने पर कोई सीमा है?**

Aspose.Slides कस्टम आकारों का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों की संगतता को प्रभावित कर सकते हैं।

**मैं फिक्स्ड आस्पेक्ट रेशियो वाले आकारों को विकृत होने से कैसे बचा सकता हूँ?**

आप आकार को स्केल करने से पहले `getAspectRatioLocked` मेथड की जाँच कर सकते हैं। यदि यह लॉक है, तो व्यक्तिगत रूप से स्केल करने के बजाय चौड़ाई या ऊँचाई को अनुपातिक रूप से समायोजित करें।