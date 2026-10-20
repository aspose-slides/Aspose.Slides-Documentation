---
title: Node.js में प्रेजेंटेशन स्लाइड्स पर शैप्स का आकार बदलें
type: docs
weight: 130
url: /hi/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
keywords:
  - शैप का आकार बदलें
  - शैप का आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर शैप्स को आसानी से पुनः आकार दें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएं।"
---
## **परिचय**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको नई मापदण्डों के अनुसार शैप्स को पुनः आकार देना और उनका स्थान बदलना भी पड़ सकता है। यह लेख दिखाता है कि शैप्स को मैन्युअल रूप से कैसे स्केल करें और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभालें।

## **शेप्स को पुनः आकार दें**

प्रत्येक शैप के सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। ऊँचाई के अनुपात को उसके लंबवत निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसकी स्लाइड में कोई टेबल नहीं होते, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि बाद की लूप स्केलिंग को नियंत्रित करे। अनुपात इकाई रहित हैं; शैप की स्थितियों और आयामों को पॉइंट में मापा जाता है। अलग-अलग चौड़ाई और ऊँचाई के अनुपात शैप्स को विकृत कर सकते हैं, और शैप के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
टेबलों को अलग से संभालना पड़ता है: टेबल की कुल चौड़ाई और ऊँचाई निर्धारित करने के बजाय उनके कॉलम की चौड़ाई और पंक्तियों की ऊँचाई को स्केल करें। यदि सेल की सामग्री को अधिक स्थान चाहिए तो पंक्तियों की ऊँचाई अनुरोध से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण टेबलों को समर्थन देता है और आकार बदली प्रस्तुति को सहेजने से पहले मास्टर और लेआउट तथा व्यक्तिगत स्लाइड में शैप्स को प्रोसेस करता है। इसका हेल्पर प्रत्येक [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) को कॉलम की चौड़ाई को [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) से और न्यूनतम पंक्ति ऊँचाई को [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) से स्केल करके संभालता है। फिर यह टेबल की स्थिति को स्केल करता है बिना उसके कुल आयामों को अलग से स्केल किए।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // टेबल का आकार कॉलम की चौड़ाई और पंक्ति की ऊँचाई द्वारा नियंत्रित होता है।
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // मास्टर्स और लेआउट्स तथा व्यक्तिगत स्लाइड्स पर परिभाषित शैप्स को पुनः आकार दें।
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद शैप्स विकृत या कटे क्यों होते हैं?**

यदि आप स्लाइड का आकार बदलते हैं लेकिन शैप्स को स्केल नहीं करते, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड से बाहर तक फैल सकते हैं। चौड़ाई और ऊँचाई को विभिन्न अनुपातों से स्केल करने से भी शैप्स विकृत हो सकते हैं।

**क्या दिया गया कोड सभी शैप प्रकारों के लिए काम करता है?**

पहला उदाहरण शैप की सीमाओं को सीधे बदलता है और टेबल बिना वाली स्लाइड के लिए अभिप्रेत है। दूसरा उदाहरण टेबलों को अलग से संभालता है। परिणामी लेआउट, विशेषकर टेक्स्ट और टेबल, को जांचें, क्योंकि ये उदाहरण फ़ॉन्ट आकार को स्केल नहीं करते और टेबल की सामग्री पंक्ति की ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय टेबल को कैसे पुनः आकार दें?**

कॉलम की चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर टेबल की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड और लेआउट स्लाइड के लिए कार्य करेगा?**

हां। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) और प्रत्येक मास्टर की [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) के माध्यम से इटररेट करता है और उनके शैप्स पर समान आकार बदलने की लॉजिक लागू करता है।

**क्या मैं आकार बदलने के साथ स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) भी बदल सकता हूँ?**

हां। स्लाइड आकार बदलने के बाद और लक्षित आयाम पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) को कॉल करें, ताकि स्केल कारक अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार के लिए कोई सीमा है जिसे मैं सेट कर सकता हूँ?**

आप [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**मैं कैसे सुनिश्चित करूँ कि स्थिर अनुपात वाले शैप्स विकृत न हों?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर का उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई के अनुपात में से छोटा अनुपात उपयोग करें। इससे अनुपात सुरक्षित रहता है लेकिन एक किनारे पर अनुपयोगी स्थान रहने की संभावना है।