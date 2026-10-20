---
title: Android पर प्रस्तुति स्लाइड्स पर आकारों को पुनः आकार दें
type: docs
weight: 130
url: /hi/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
  - आकार बदलें
  - आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Android
  - Aspose.Slides
description: "Aspose.Slides for Android के साथ Java के माध्यम से PowerPoint और OpenDocument स्लाइड्स पर आकारों को आसानी से पुनः आकार दें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको उसके आकारों को नया आकार देने और उनके स्थान को समायोजित करने की भी आवश्यकता पड़ सकती है ताकि वे नई मापों में फिट हों। यह लेख दिखाता है कि आकारों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट में टेबल को कैसे संभालें।

## **आकार बदलें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। उसके ऊर्ध्वाधर निर्देशांक और ऊँचाई पर संबंधित ऊँचाई अनुपात लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति लोड करता है जहाँ स्लाइड में कोई टेबल नहीं होते, स्लाइड आकार को A4 में बदलता है, और परिणाम सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि आगे का लूप स्केलिंग को नियंत्रित कर सके। अनुपात बिना इकाइयों के होते हैं; आकार की स्थितियों और आयामों को पॉइंट में मापा जाता है। अलग-अलग चौड़ाई और ऊँचाई अनुपात आकारों को विकृति दे सकते हैं, तथा आकार के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल फैक्टरों की गणना करें।
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
टेबल को अलग‑अलग संभालना पड़ता है: पूर्ण टेबल की चौड़ाई और ऊँचाई निर्धारित करने के बजाय उसकी स्तम्भ चौड़ाइयों और पंक्ति ऊँचाइयों को स्केल करें। यदि सेल की सामग्री अधिक स्थान की माँग करती है तो पंक्ति की ऊँचाई अनुरोधित मान से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण टेबल को सपोर्ट करता है और मास्टर तथा लेआउट के आकारों को साथ ही व्यक्तिगत स्लाइडों को भी प्रोसेस करता है, फिर पुनः आकार वाली प्रस्तुति को सहेजता है। इसका हेल्पर प्रत्येक [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) को [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) से स्तम्भ चौड़ाइयों को और [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) से न्यूनतम पंक्ति ऊँचाइयों को स्केल करके संभालता है। फिर वह टेबल की स्थितियों को स्केल करता है, बिना उसकी समग्र आयामों को अलग से स्केल किए।

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // तालिका के आयाम स्तम्भ चौड़ाइयों और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
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
    // स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल फैक्टरों की गणना करें।
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // मास्टर और लेआउट पर तथा व्यक्तिगत स्लाइडों पर परिभाषित आकारों को पुनः आकार दें।
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

**स्लाइड का आकार बदलने के बाद आकार क्यों विकृत या कटे दिखते हैं?**

यदि आप स्लाइड आकार बदलते समय आकारों को स्केल नहीं करते, तो वे अपनी मौलिक स्थिति और आयाम रखेंगे और स्लाइड से बाहर तक विस्तृत हो सकते हैं। विभिन्न चौड़ाई और ऊँचाई अनुपातों से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या दिया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार की सीमाओं को सीधे बदलता है और उन स्लाइडों के लिए है जिनमें टेबल नहीं होते। दूसरा उदाहरण टेबल को अलग से संभालता है। परिणामस्वरूप लेआउट, विशेषकर टेक्स्ट और टेबल, की जाँच करें क्योंकि ये उदाहरण फ़ॉन्ट आकार को स्केल नहीं करते और टेबल की सामग्री पंक्ति ऊँचाइयों को प्रतिबंधित कर सकती है।

**स्लाइड का आकार बदलते समय टेबल को कैसे री‑साइज़ करूँ?**

स्तम्भ चौड़ाइयों को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाइयों को ऊँचाई अनुपात से स्केल करें, फिर टेबल की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह री‑साइज़िंग मास्टर स्लाइड और लेआउट स्लाइड के लिए काम करेगी?**

हां। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) और प्रत्येक मास्टर की [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) के माध्यम से इटरिट करता है और उनके आकारों पर समान री‑साइज़िंग लॉजिक लागू करता है।

**क्या मैं स्लाइड की अभिमुखता (पोर्ट्रेट/लैंडस्केप) को री‑साइज़िंग के साथ बदल सकता हूँ?**

हां। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) को कॉल करें, ताकि स्केल फैक्टर्स अंतिम अभिमुखता को प्रतिबिंबित करें।

**क्या स्लाइड आकार के सेट करने की कोई सीमा है?**

आप [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) से कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति प्रारूप और फ़ाइल को खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाले आकारों को विकृति से बचाने के लिए क्या करें?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा मान उपयोग करें। यह अनुपात को संरक्षित रखता है, लेकिन एक किनारे पर खाली स्थान बच सकता है।