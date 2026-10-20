---
title: प्रस्तुति स्लाइड्स पर Android में शेप्स का आकार बदलें
type: docs
weight: 130
url: /hi/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
  - /hi/androidjava/re-sizing-shapes-on-slide/
keywords:
- आकार बदलें
- शेप का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर आसानी से शेप्स का आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **सारांश**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको उसके शेप्स को नई आयामों में फिट करने के लिए पुनः आकार बदलना और पुनः स्थित करना पड़ सकता है। यह लेख दिखाता है कि कैसे मैन्युअल रूप से शेप्स को स्केल करें और स्लाइड्स, मास्टर्स और लेआउट्स पर तालिकाओं को कैसे संभालें।

## **शेप्स का आकार बदलें**

प्रत्येक शेप की सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान ऊँचाई अनुपात को उसके लंबवत निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक प्रस्तुति लोड करता है जिसमें स्लाइड्स में कोई तालिका नहीं है, स्लाइड आकार को A4 में बदलता है, और परिणाम सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि बाद वाला लूप स्केलिंग को नियंत्रित करे। ये अनुपात इकाई रहित हैं; शेप की स्थितियां और आयाम पॉइंट्स में मापे जाते हैं। अलग-अलग चौड़ाई और ऊँचाई अनुपात शेप्स को विकृत कर सकते हैं, और शेप के आयाम बदलने से उसके फ़ॉन्ट आकार स्केल नहीं होते।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
तालिकाओं को अलग ढंग से संभालना पड़ता है: तालिका की कुल चौड़ाई और ऊँचाई निर्धारित करने के बजाय उनके कॉलम चौड़ाई और पंक्ति ऊँचाई को स्केल करें। यदि सेल सामग्री को अधिक स्थान चाहिए तो पंक्ति ऊँचाई अनुरोधित से अधिक रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकार बदलने वाले प्रस्तुति को सहेजने से पहले मास्टर्स और लेआउट्स तथा व्यक्तिगत स्लाइड्स पर शेप्स को प्रोसेस करता है। इसका हेल्पर प्रत्येक [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) को कॉलम चौड़ाइयों को [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) से स्केल करके और न्यूनतम पंक्ति ऊँचाई को [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) से स्केल करके संभालता है। फिर यह तालिका की स्थिति को स्केल करता है बिना उसके कुल आयामों को अलग से स्केल किए।

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // तालिका के आयाम कॉलम चौड़ाई और पंक्तियों की ऊँचाई द्वारा नियंत्रित होते हैं।
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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // मास्टर्स और लेआउट्स तथा व्यक्तिगत स्लाइड्स पर परिभाषित शेप्स का आकार बदलें।
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

**शेप्स स्लाइड का आकार बदलने के बाद क्यों विकृत या काटे जाते हैं?**

यदि आप स्लाइड का आकार बदलते हुए शेप्स को स्केल नहीं करते हैं, तो वे अपनी मूल स्थिति और आयाम बनाए रखते हैं और स्लाइड से बाहर निकल सकते हैं। चौड़ाई और ऊँचाई को अलग-अलग अनुपात से स्केल करने से भी शेप्स विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी शेप प्रकारों के लिए काम करता है?**

पहला उदाहरण सीधे शेप की सीमाएँ बदलता है और तालिकाओं के बिना स्लाइड्स के लिए है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामी लेआउट, विशेषकर टेक्स्ट और तालिकाओं की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकार को स्केल नहीं करते और तालिका की सामग्री पंक्ति ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं को कैसे री-साइज़ करें?**

कॉलम चौड़ाइयों को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए काम करेगा?**

हां। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) और प्रत्येक मास्टर की [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) के माध्यम से इटररेट करता है और उनके शेप्स पर समान आकार बदलने की लॉजिक लागू करता है।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को आकार बदलते समय बदल सकता हूं?**

हां। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) को कॉल करें, ताकि स्केल फैक्टर अंतिम अभिविन्यास को दर्शाए।

**क्या स्लाइड आकार के लिए कोई सीमा है जिसे मैं सेट कर सकता हूं?**

आप [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति प्रारूप और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाले शेप्स को विकृति से कैसे बचा सकता हूं?**

चौड़ाई और ऊँचाई के लिए समान स्केल फैक्टर उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा अनुपात उपयोग करें। इससे अनुपात बनाए रहता है लेकिन एक किनारे पर अनउपयोगी स्थान बच सकता है।