---
title: जावा में प्रस्तुति स्लाइड्स पर आकार बदलें
type: docs
weight: 130
url: /hi/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /hi/java/re-sizing-shapes-on-slide/
keywords:
  - आकार बदलें
  - शेप आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument स्लाइड्स पर आकार आसानी से बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति की स्लाइड का आकार बदलते हैं, तो आपको नई मापों के अनुसार उसके आकारों को पुनः आकार देना और उनका स्थान बदलना भी आवश्यक हो सकता है। यह लेख दर्शाता है कि आकारों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट पर तालिकाओं को कैसे संभाला जाए।

## **आकार बदलें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान अनुपात को ऊँचाई के लिए उसके लंबवत निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसकी स्लाइडों में कोई तालिका नहीं होती, स्लाइड का आकार A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि बाद वाला लूप स्केलिंग को नियंत्रित कर सके। अनुपात बिना इकाई के होते हैं; आकार की स्थितियां और आयाम पॉइंट में मापे जाते हैं। विभिन्न चौड़ाई और ऊँचाई अनुपात आकारों को विकृत कर सकते हैं, और आकार के आयाम बदलने से फ़ॉन्ट आकार स्केल नहीं होते।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
तालिकाओं को अलग तरह से संभालना आवश्यक है: तालिका की कुल चौड़ाई और ऊँचाई को असाइन करने के बजाय उनके कॉलम की चौड़ाई और पंक्तियों की ऊँचाई को स्केल करें। यदि सेल की सामग्री को अधिक स्थान चाहिए तो पंक्ति की ऊँचाई अनुरोध से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकारों को मास्टर और लेआउट तथा व्यक्तिगत स्लाइडों पर प्रोसेस करता है, फिर पुनः आकार वाली प्रस्तुति को सहेजता है। इसका हेल्पर प्रत्येक [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) को कॉलम की चौड़ाई को [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) और न्यूनतम पंक्ति ऊँचाई को [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) से स्केल करके संभालता है। फिर यह तालिका की स्थिति को स्केल करता है बिना उसकी कुल मापों को अलग से स्केल किए।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // तालिका के आयाम कॉलम की चौड़ाई और पंक्ति की ऊँचाई द्वारा नियंत्रित होते हैं।
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // मास्टर और लेआउट तथा व्यक्तिगत स्लाइडों पर परिभाषित आकारों को पुनः आकार दें।
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```
## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकार क्यों विकृत या कट गए?**

यदि आप स्लाइड का आकार बिना आकारों को स्केल किए बदलते हैं, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड के बाहर तक फैल सकते हैं। चौड़ाई और ऊँचाई को अलग-अलग अनुपात से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार की सीमाओं को सीधे बदलता है और बिना तालिकाओं वाली स्लाइडों के लिए अभिप्रेत है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामी लेआउट, विशेष रूप से पाठ और तालिकाओं, की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकारों को स्केल नहीं करते और तालिका की सामग्री पंक्ति ऊँचाई को सीमित कर सकती है।

**जब स्लाइड का आकार बदलते हैं तो तालिकाओं को कैसे पुनः आकार दें?**

कॉलम की चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर जैसा कि दूसरे उदाहरण में दिखाया गया है, तालिका की स्थिति को स्केल करें।

**क्या यह री-साइज़िंग मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए काम करेगी?**

हाँ। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) और प्रत्येक मास्टर की [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) पर इटेरेट करता है और उनके आकारों पर समान री-साइज़िंग लॉजिक लागू करता है।

**क्या मैं री-साइज़िंग के साथ स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) बदल सकता हूँ?**

हाँ। स्लाइड का आकार बदलने के बाद और लक्ष्य माप पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) को कॉल करें, ताकि स्केल फ़ैक्टर अंतिम अभिविन्यास को दर्शाएँ।

**क्या सेट की जा सकने वाली स्लाइड आकार की कोई सीमा है?**

आप कस्टम स्लाइड माप [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) के साथ निर्धारित कर सकते हैं। समर्थित माप प्रस्तुति प्रारूप और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**मैं स्थायी आस्पेक्ट अनुपात वाले आकारों को विकृत होने से कैसे रोक सकता हूँ?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर उपयोग करें। मूल लेआउट को नई स्लाइड मापों में फिट करने के लिए, दोनों मापों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा अनुपात उपयोग करें। यह अनुपात को बनाए रखता है लेकिन एक किनारे पर खाली स्थान रह सकता है।