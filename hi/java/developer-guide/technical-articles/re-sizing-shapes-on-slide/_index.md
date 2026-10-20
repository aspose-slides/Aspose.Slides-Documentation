---
title: जावा में प्रस्तुति स्लाइड्स पर आकृतियों का आकार बदलें
type: docs
weight: 130
url: /hi/java/resizing-shapes-on-slide/
aliases:
  - /hi/java/re-sizing-shapes-on-slide/
  /java/re-sizing-shapes-on-slide/
keywords:
- आकार बदलें आकृति
- आकृति का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से आकृतियों का आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **सारांश**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको नए आयामों में फिट करने के लिए उसकी आकृतियों का आकार बदलना और उन्हें पुनः स्थित करना पड़ सकता है। यह लेख दिखाता है कि आकृतियों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड्स, मास्टर्स और लेआउट्स में तालिकाओं को कैसे संभाला जाए।

## **आकृतियों का आकार बदलें**

हर आकृति की सापेक्ष स्थिती और आकार को संरक्षित करने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। उसकी लंबवत निर्देशांक और ऊँचाई पर संबंधित ऊँचाई अनुपात लागू करें।

पहला उदाहरण एक प्रस्तुति को लोड करता है जिसकी स्लाइड्स में कोई तालिका नहीं होती, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि बाद का लूप स्केलिंग को नियंत्रित करे। अनुपात बिना इकाई के होते हैं; आकृति की स्थितियों और आयामों को पॉइंट में मापा जाता है। अलग-अलग चौड़ाई और ऊँचाई के अनुपात आकृतियों को विकृत कर सकते हैं, और आकृति के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
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
तालिकाओं को अलग-अलग संभालने की आवश्यकता होती है: उनकी कॉलम चौड़ाई और पंक्ति ऊँचाई को स्केल करें, बजाय तालिका की कुल चौड़ाई और ऊँचाई निर्दिष्ट करने के। यदि सेल की सामग्री को अधिक स्थान चाहिए तो पंक्ति ऊँचाई अनुरोधित आकार से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकार को मास्टर और लेआउट्स तथा व्यक्तिगत स्लाइड्स पर प्रोसेस करता है, फिर री‑सेज़्ड प्रस्तुति को सहेजता है। इसका हेल्पर प्रत्येक [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) को कॉलम चौड़ाई को [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) से और न्यूनतम पंक्ति ऊँचाई को [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) से स्केल करके संभालता है। फिर यह तालिका की स्थितियों को स्केल करता है बिना उसकी कुल आयामों को अलग से स्केल किए।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // तालिका के आयाम कॉलम चौड़ाई और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
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
    // स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // मास्टर और लेआउट पर परिभाषित आकृतियों के साथ-साथ व्यक्तिगत स्लाइड्स के आकार को बदलें।
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

**स्लाइड का आकार बदलने के बाद आकृतियाँ विकृत या कट क्यों जाती हैं?**  
यदि आप स्लाइड आकार बदलते हैं बिना आकृतियों को स्केल किए, तो वे अपनी मूल स्थितियों और आयामों को बरकरार रखते हैं और स्लाइड से बाहर निकल सकती हैं। चौड़ाई और ऊँचाई को अलग-अलग अनुपात से स्केल करने से भी आकृतियाँ विकृत हो सकती हैं।

**क्या प्रदान किया गया कोड सभी आकृति प्रकारों के लिए काम करता है?**  
पहला उदाहरण आकार सीमा को सीधे बदलता है और तालिका रहित स्लाइड्स के लिए है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामी लेआउट, विशेषकर टेक्स्ट और तालिकाओं की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकारों को स्केल नहीं करते और तालिका सामग्री पंक्ति ऊँचाई को सीमित कर सकती है।

**स्लाइड के आकार बदलते समय तालिकाओं का आकार कैसे बदलूँ?**  
कॉलम चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए काम करेगा?**  
हाँ। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) और प्रत्येक मास्टर के [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) के माध्यम से इटरेट करता है और उनके आकृतियों पर समान आकार बदलने की लॉजिक लागू करता है।

**क्या मैं आकार बदलते समय स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) भी बदल सकता हूँ?**  
हाँ। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) को कॉल करें, ताकि स्केल फैक्टर अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार सेट करने की कोई सीमा है?**  
आप [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति प्रारूप और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाली आकृतियों को विकृति से कैसे बचा सकता हूँ?**  
चौड़ाई और ऊँचाई के लिए समान स्केल फैक्टर उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा अनुपात चुनें। इससे अनुपात बनी रहती है लेकिन एक किनारे पर कुछ अप्रयुक्त स्थान रह सकता है।