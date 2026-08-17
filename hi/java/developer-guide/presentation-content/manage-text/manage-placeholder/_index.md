---
title: Java में प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- पाठ प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java के लिए Aspose.Slides के साथ पाठ, चित्र, चार्ट और सामग्री प्लेसहोल्डर का निरीक्षण और संपादन करना तथा प्लेसहोल्डर विरासत को समझना सीखें।"
---
## **सारांश**

एक placeholder वह shape होता है जो प्रस्तुति टेम्पलेट में किसी विशेष प्रकार की सामग्री के लिए एक स्थान सुरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट, और सामान्य‑उद्देश्यीय सामग्री placeholders शामिल हैं। एक सामान्य shape के विपरीत, एक placeholder अपनी स्थिति, आकार, फ़ॉर्मेटिंग और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में ले सकता है।

Aspose.Slides placeholder जानकारी को [IShape.getPlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) मेथड के माध्यम से उपलब्ध कराता है। यह मेथड एक [IPlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य shape के लिए `null` लौटाता है। यह निर्धारित करने के लिए कि placeholder में क्या रखना उद्देश्य है, [IPlaceholder.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) का उपयोग करें।

placeholder प्रकार जानने के बाद shape इंटरफ़ेस अभी भी महत्वपूर्ण है:

- एक खाली टेक्स्ट, चित्र, चार्ट, या सामग्री placeholder आमतौर पर एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) द्वारा प्रतिनिधित्व किया जाता है।
- एक भरा हुआ चित्र placeholder एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक भरा हुआ चार्ट placeholder एक [IChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक सामग्री placeholder कई प्रकार की सामग्री रख सकता है। यह मानने के बजाय कि हर placeholder एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) है, दोनों [IPlaceholder.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) और रन‑टाइम shape इंटरफ़ेस की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) एक placeholder की भूमिका का वर्णन करता है; यह shape के रन‑टाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा प्रकार जाँच करें।
{{% /alert %}}

## **Placeholder विरासत को समझें**

Placeholders एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: प्रयोग योग्य शैली निर्धारित करती है और कुछ मामलों में मास्टर‑लेवल placeholders को परिभाषित करती है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था को परिभाषित करती है और मास्टर से विरासत में ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के placeholders को रखती है और अपने लेआउट से विरासत में ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) को कॉल करें। एक स्लाइड placeholder सामान्यतः अपना लेआउट placeholder लौटाता है; एक लेआउट placeholder अपना मास्टर placeholder लौटा सकता है। जब shape का कोई बेस placeholder नहीं होता तो मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर placeholders की सूची देता है और उनके बेस placeholders को रिपोर्ट करता है:

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

सामान्य स्लाइड पर एक placeholder को संपादित करने से उस स्लाइड के लिए एक स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से सभी स्लाइडों पर प्रभाव पड़ सकता है जो अभी भी वह सेटिंग विरासत में लेती हैं। एक स्थानीय सामान्य shape का कोई बेस placeholder नहीं होता और केवल उसी निर्देशांक पर स्थित होने के कारण विरासत शुरू नहीं करता।

## **Placeholder में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी, और टेक्स्ट placeholders सामान्यतः टेक्स्ट का समर्थन करते हैं। इसका [getTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) मेथड उपयोग करने से पहले [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) की जाँच करें।

निम्न उदाहरण पहले स्लाइड पर पहले शीर्षक placeholder को अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया placeholders को [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) में कैस्ट करने से बचाता है। यह भी placeholder को उसके उद्देश्य से पहचानता है न कि अस्थिर shape इंडेक्स पर निर्भर होकर।

## **लेआउट पर Prompt टेक्स्ट सेट करें**

Prompt टेक्स्ट एक खाली placeholder में दिखाया गया डिजाइन‑टाइम निर्देश होता है, जैसे *Click to add title*। सामान्य स्लाइड के shape संग्रह के माध्यम से पहुँचने के बजाय लेआउट placeholder पर कस्टम prompt टेक्स्ट सेट करें। लेआउट को [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) से प्राप्त करें और [ILayoutSlide.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/) द्वारा लौटाए गए संग्रह पर इटररेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक prompts को बदलता है:

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

Prompt टेक्स्ट सामान्य स्लाइड की सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली placeholders के लिए अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर देता है, तो prompt प्रदर्शित नहीं होता। Prompt बदलने से उन स्लाइडों पर मौजूदा टेक्स्ट प्रतिस्थापित नहीं होता जो उस लेआउट का उपयोग करती हैं।

## **चित्र Placeholder को अपडेट करें**

दो स्थितियों को संभालना है:

- यदि चित्र placeholder पहले से ही भरा हुआ है और एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) द्वारा प्रतिनिधित्व किया गया है, तो [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) और [ISlidesPicture.setImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/) के माध्यम से चित्र बदलें।
- यदि यह अभी भी एक खाली placeholder है, तो [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) से placeholder के निर्देशांक पर एक picture frame जोड़ें और खाली placeholder को हटा दें।

अगला उदाहरण दोनों स्थितियों को सपोर्ट करता है और प्रस्तुति को सहेजता है:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

खाली placeholder के लिए बनाया गया प्रतिस्थापन एक स्थानीय picture frame है, नया placeholder नहीं, क्योंकि [IShape.getPlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) में सेट्टर नहीं है। यह आरक्षित स्थान को रखता है लेकिन अब placeholder‑विशिष्ट व्यवहार विरासत में नहीं लेता। यदि placeholder संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में placeholder तैयार और भरें, फिर Aspose.Slides से resultant [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य picture‑विशिष्ट प्रभावों के लिए, देखें [Manage Picture Frames](/slides/hi/java/picture-frame/)। ये ऑपरेशन picture frame या picture fill से संबंधित हैं, न कि placeholder मेटाडाटा से।

## **चार्ट और सामग्री Placeholders के साथ काम करें**

एक भरा हुआ चार्ट placeholder एक [IChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/) द्वारा प्रतिनिधित्व किया जा सकता है। यह उदाहरण placeholder प्रकार और रन‑टाइम इंटरफ़ेस दोनों के आधार पर ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

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

एक सामान्य सामग्री placeholder आमतौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई सामग्री प्रकारों जैसे चार्ट, टेबल, डायग्राम, चित्र और मीडिया के लिए लॉन्चर के रूप में कार्य करता है। एक बार भरा जाने के बाद, वास्तविक shape इंटरफ़ेस की जाँच करके पता लगाएँ कि इसमें क्या है। विशिष्ट लेआउट भी [PlaceholderType.Chart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholdertype/), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides केवल [IPlaceholder.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) को बदलकर एक खाली [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) placeholder को [IChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/) में परिवर्तित नहीं करता; इंटरफ़ेस के माध्यम से प्रकार को बदला नहीं जा सकता। एक खाली चार्ट या सामग्री क्षेत्र को प्रोग्रामmatically भरने के लिए, आवश्यक ऑब्जेक्ट को placeholder के निर्देशांक पर जोड़ें और फिर खाली placeholder को हटाएँ। निम्न उदाहरण चार्ट के लिए यह करता है:

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

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह placeholder के क्षेत्र को घेरता है लेकिन लेआउट placeholder से विरासत नहीं लेता। जब आपको इसकी श्रेणियों, सीरीज़ या वर्कबुक डेटा को बदलना हो, तो समर्पित [chart management articles](/slides/hi/java/powerpoint-charts/) देखें।

## **पूर्ण उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

निम्न अंत‑से‑अंत उदाहरण एक टेम्पलेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र placeholder खोजता है, placeholder और shape प्रकारों की जाँच करता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। उदाहरण जानबूझकर shape इंडेक्स मानने या हर placeholder को समान इंटरफ़ेस में कास्ट करने से बचता है।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

**एक बेस placeholder क्या है?**

एक बेस placeholder वह संबंधित shape है जो लेआउट या मास्टर पर मौजूद होता है जिससे दूसरा placeholder विरासत में लेता है। इसे प्राप्त करने के लिए [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) का उपयोग करें। एक सामान्य स्थानीय shape `null` लौटाता है क्योंकि वह placeholder पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट placeholder को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या prompt टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत रहती है। पूरे प्रस्तुति में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइडों पर इटररेट करें और प्रत्येक शीर्षक placeholder को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर placeholders को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप पर हेडर और फुटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/java/presentation-header-and-footer/).