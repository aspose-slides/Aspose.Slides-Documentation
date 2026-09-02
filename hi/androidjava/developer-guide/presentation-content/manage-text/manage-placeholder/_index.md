---
title: Android पर प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/androidjava/manage-placeholder/
keywords:
- प्लेसहोल्डर
- पाठ प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट पाठ
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से इस्तेमाल करके पाठ, चित्र, चार्ट और सामग्री प्लेसहोल्डर की जाँच और संपादन कैसे करें और प्लेसहोल्डर विरासत को समझें।"
---
## **समीक्षा**

एक प्लेसहोल्डर वह आकृति है जो प्रस्तुति टेम्प्लेट में किसी विशिष्ट प्रकार की सामग्री के लिए स्थान आरक्षित करती है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट, और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। एक सामान्य आकृति के विपरीत, प्लेसहोल्डर अपनी स्थिति, आकार, स्वरूपण और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में प्राप्त कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [IShape.getPlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) मेथड के माध्यम से उजागर करता है। यह मेथड एक [IPlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) ऑब्जेक्ट लौटाता है या सामान्य आकृति के लिए `null`। यह निर्धारित करने के लिए कि प्लेसहोल्डर में क्या होना चाहिए, [IPlaceholder.getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) का उपयोग करें।

प्लेसहोल्डर प्रकार जानने के बाद आकृति इंटरफ़ेस अभी भी महत्वपूर्ण है:

- एक खाली टेक्स्ट, चित्र, चार्ट, या सामग्री प्लेसहोल्डर आमतौर पर एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) द्वारा दर्शाया जाता है।
- एक भरे हुए चित्र प्लेसहोल्डर को एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरे हुए चार्ट प्लेसहोल्डर को एक [IChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/) द्वारा दर्शाया जा सकता है।
- एक सामग्री प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। प्रत्येक प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) मानने के बजाय [IPlaceholder.getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) और रन‑टाइम आकृति इंटरफ़ेस दोनों को जांचें।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकृति के रन‑टाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा प्रकार जाँच का उपयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलीयों को परिभाषित करती है और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर भी रखती है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था को परिभाषित करती है और मास्टर से विरासत में ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर को रखती है और अपने लेआउट से विरासत में ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) को कॉल करें। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकृति का कोई बेस प्लेसहोल्डर नहीं होता तो यह मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर को सूचीबद्ध करता है और उनके बेस प्लेसहोल्डर को रिपोर्ट करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

एक सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से सभी स्लाइडों पर असर पड़ सकता है जो अभी भी वह सेटिंग विरासत में लेती हैं। एक स्थानीय सामान्य आकृति का कोई बेस प्लेसहोल्डर नहीं होता और वह केवल समान निर्देशांक होने के कारण विरासत शुरू नहीं करती।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्र‑शीर्षक, उपशीर्षक, बॉडी, और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट को सपोर्ट करते हैं। इसका [getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) मेथड उपयोग करने से पहले [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) की जाँच करें।

निम्न उदाहरण पहले स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम संग्रहीत करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) में कास्ट करने से बचाता है। यह प्लेसहोल्डर को उसके उद्देश्य से पहचानता है बजाय कि अस्थिर आकृति इंडेक्स पर भरोसा करने के।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिजाइन‑टाइम निर्देश है जो खाली प्लेसहोल्डर में दिखता है, जैसे *Click to add title*। प्रॉम्प्ट टेक्स्ट को लेआउट प्लेसहोल्डर पर सेट करें, न कि सामान्य स्लाइड की आकृति संग्रह के माध्यम से पहुँचने की कोशिश करें। लेआउट तक पहुँचने के लिए [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) का उपयोग करें और [ILayoutSlide.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/) द्वारा लौटाए गए संग्रह पर इटररेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट को बदलता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर दे, प्रॉम्प्ट अब दिखता नहीं है। प्रॉम्प्ट बदलने से लेआउट का उपयोग करने वाली स्लाइडों पर मौजूद टेक्स्ट प्रतिस्थापित नहीं होता।

## **चित्र प्लेसहोल्डर को अपडेट करें**

निपटने के दो मामले हैं:

- यदि चित्र प्लेसहोल्डर पहले से भरा है और एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) द्वारा दर्शाया गया है, तो चित्र को [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) और [ISlidesPicture.setImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/) के माध्यम से बदलें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) से प्लेसहोल्डर के निर्देशांक पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर को हटा दें।

निम्न उदाहरण दोनों मामलों को संभालता है और प्रस्तुति को संग्रहीत करता है:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [IShape.getPlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) में सेट्टर नहीं है। यह आरक्षित स्थान को बनाए रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार विरासत में नहीं लेता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides से परिणामस्वरूप [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिए, देखें [Manage Picture Frames](/slides/hi/androidjava/picture-frame/)। ये संचालन चित्र फ्रेम या चित्र फ़िल में होते हैं, न कि प्लेसहोल्डर मेटाडेटा में।

## **चार्ट और सामग्री प्लेसहोल्डर के साथ काम करें**

एक भरा हुआ चार्ट प्लेसहोल्डर एक [IChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/) द्वारा दर्शाया जा सकता है। यह उदाहरण ऐसे चार्ट को प्लेसहोल्डर प्रकार और रन‑टाइम इंटरफ़ेस दोनों से ढूँढता है, उसका शीर्षक बदलता है, और फ़ाइल को सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक सामान्य सामग्री प्लेसहोल्डर आमतौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई सामग्री प्रकारों—जैसे चार्ट, टेबल, डायग्राम, चित्र और मीडिया—के लिए लॉन्चर का कार्य करता है। भरने के बाद, वास्तविक आकृति इंटरफ़ेस को निरीक्षण करके पता करें कि उसमें क्या है। विशिष्ट लेआउट भी [PlaceholderType.Chart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholdertype/), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides केवल [IPlaceholder.getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) को बदल कर खाली [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) प्लेसहोल्डर को [IChart] में नहीं बदलता; इंटरफ़ेस के माध्यम से प्रकार बदला नहीं जा सकता। किसी खाली चार्ट या सामग्री क्षेत्र को प्रोग्रामेटिक रूप से भरने के लिए, आवश्यक वस्तु को प्लेसहोल्डर के निर्देशांक पर जोड़ें और फिर खाली प्लेसहोल्डर को हटा दें। निम्न उदाहरण इस कार्य को चार्ट के लिये करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। जब आपको उसकी श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलना हो, तो समर्पित [chart management articles](/slides/hi/androidjava/powerpoint-charts/) देखें।

## **पूरा उदाहरण: टेक्स्ट या छवि सामग्री अपडेट करें**

निम्न अंत‑से‑अंत उदाहरण एक टेम्प्लेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकृति प्रकारों की जाँच करता है, उचित सामग्री अपडेट करता है, और आउटपुट को सहेजता है। यह उदाहरण जानबूझकर आकार‑इंडेक्स मानने या प्रत्येक प्लेसहोल्डर को समान इंटरफ़ेस में कास्ट करने से बचता है।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक बेस प्लेसहोल्डर क्या है?**

एक बेस प्लेसहोल्डर वह संबंधित आकृति है जो लेआउट या मास्टर पर स्थित होती है, जिससे अन्य प्लेसहोल्डर विरासत में लेते हैं। इसे प्राप्त करने के लिए [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) उपयोग करें। एक सामान्य स्थानीय आकृति `null` लौटाती है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित कर सभी स्लाइड शीर्षकों को बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत स्वरूपण या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन वास्तविक शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत होती है। पूरे प्रेजेंटेशन में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइडों पर इटररेट करके प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्तर पर हेडर और फुटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/androidjava/presentation-header-and-footer/).