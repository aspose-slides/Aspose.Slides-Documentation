---
title: "Android पर प्रस्तुति प्लेसहोल्डर प्रबंधित करें"
linktitle: "प्लेसहोल्डर प्रबंधित करें"
type: docs
weight: 10
url: /hi/androidjava/manage-placeholder/
keywords:
- "प्लेसहोल्डर"
- "टेक्स्ट प्लेसहोल्डर"
- "छवि प्लेसहोल्डर"
- "चार्ट प्लेसहोल्डर"
- "सामग्री प्लेसहोल्डर"
- "प्रॉम्प्ट टेक्स्ट"
- "PowerPoint"
- "प्रस्तुतीकरण"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करते हुए टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर की जाँच और संपादन कैसे करें और प्लेसहोल्डर विरासत को समझें।"
---
## **अवलोकन**

एक प्लेसहोल्डर वह आकृति है जो प्रस्तुति टेम्प्लेट में किसी विशिष्ट प्रकार की सामग्री के लिए स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। सामान्य आकृति के विपरीत, एक प्लेसहोल्डर अपना स्थान, आकार, स्वरूपण और अन्य सेटिंग्स लेआउट स्लाइड या मास्टर स्लाइड से विरासत में प्राप्त कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) मेथड के माध्यम से उजागर करता है। यह मेथड एक [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य आकृति के लिए `null` वापस देता है। प्लेसहोल्डर में क्या होना चाहिए, यह निर्धारित करने के लिए [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) का उपयोग करें।

प्लेसहोल्डर प्रकार ज्ञात होने के बाद भी आकृति इंटरफ़ेस महत्वपूर्ण रहता है:

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट प्लेसहोल्डर आम तौर पर एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) द्वारा प्रदर्शित किया जाता है।
- एक भरा हुआ चित्र प्लेसहोल्डर एक [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरा हुआ चार्ट प्लेसहोल्डर एक [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) द्वारा दर्शाया जा सकता है।
- एक कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। प्रत्येक प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) मानने की बजाए दोनों [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) और रन‑टाइम आकृति इंटरफ़ेस की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकृति के रन‑टाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा प्रकार की जाँच करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: प्रयोग योग्य शैलियों को परिभाषित करती है और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर रखती है।  
2. एक लेआउट स्लाइड वह व्यवस्था निर्धारित करती है जो एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाती है और यह मास्टर से विरासत में ले सकती है।  
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर रखती है और अपने लेआउट से विरासत में ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) को कॉल करें। एक स्लाइड प्लेसहोल्डर आम तौर पर अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकृति का कोई बेस प्लेसहोल्डर नहीं होता तो यह मेथड `null` लौटाता है।

पहली स्लाइड पर प्लेसहोल्डर सूचीबद्ध करने और उनके बेस प्लेसहोल्डर रिपोर्ट करने वाला उदाहरण:

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

एक सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से वह स्लाइड के लिए स्थानीय ओवरराइड बनाया या बदलता है। संबंधित लेआउट या मास्टर को संपादित करना उन सभी स्लाइडों को प्रभावित कर सकता है जो अभी भी वह सेटिंग विरासत में ले रही हैं। एक स्थानीय सामान्य आकृति का कोई बेस प्लेसहोल्डर नहीं होता और केवल यही कारण नहीं बनता कि वह समान निर्देशांक पर स्थित हो।

## **प्लेसहोल्डर स्थिति हटाएँ**

टेम्प्लेट को अनुकूलित करते समय, मौजूदा ऑब्जेक्ट को सामान्य आकृति के रूप में रखने के लिए [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) का उपयोग करें। इसका [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) मेथड `null` लौटाता है, लेकिन आकृति स्लाइड के संग्रह में बनी रहती है। इसके विपरीत, [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) आकार को उस संग्रह से हटा देता है।

न्यूनतम एक स्लाइड और पहली स्लाइड पर एक गैर‑खाली टेक्स्ट प्लेसहोल्डर वाले `template.pptx` फ़ाइल की आवश्यकता वाले निम्न उदाहरण को देखें। लेआउट या मास्टर से विरासत में प्राप्त स्वरूपण वाले प्लेसहोल्डर का उपयोग करके संबंध हटाने के प्रभाव को देखें। उदाहरण वही आकृति बनी रहती है, फिर उसी सामान्य आकृति पर मेथड को दोबारा बुलाता है और परिणाम सहेजता है।

{{% alert color="warning" title="Warning" %}}
प्लेसहोल्डर स्थिति हटाने से विरासत में मिले हुए स्वरूपण सेटिंग्स स्वतः संरक्षित नहीं रहतीं। नीचे दिया गया उदाहरण जानबूझकर उन सेटिंग्स को जैसा है वैसा छोड़ देता है, इसलिए आउटपुट अलग दिख सकता है। एक ऐसी आकृति जिसका स्थान और आकार पूरी तरह से विरासत में मिला हो, कॉल के बाद शून्य निर्देशांक और आयाम प्राप्त कर सकती है और संग्रह में बनी रहे बावजूद अदृश्य हो सकती है।
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // साधारण आकृति पर मेथड को कॉल करने से कोई प्रभाव नहीं पड़ता।
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

एक मिलते‑जुलते प्लेसहोल्डर के लिए, सभी तीन जाँचें `true` प्रिंट करती हैं। टेक्स्ट बना रहता है, लेकिन विरासत में मिला स्थान, आकार, घूर्णन, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट‑फ़्रेम मार्जिन, वर्टिकल एंकरिंग, फ़िल, और लाइन सेटिंग्स प्लेसहोल्डर संबंध हटाने पर बदल सकती हैं। उदाहरण के तौर पर, विरासत में मिला शीर्षक स्वरूपण सामान्य टेक्स्ट स्वरूपण में गिर सकता है। लेआउट के बारे में अधिक जानकारी के लिए देखें [स्लाइड लेआउट](/slides/hi/androidjava/slide-layout/)।

इच्छित स्वरूपण बनाए रखने के लिए, कॉल से पहले हल किया गया स्थान, आकार और घूर्णन कैप्चर करें, और आवश्यक प्रभावी स्वरूपण मानों को अलग‑अलग वेरिएबल में कॉपी करें। इन मानों को [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) , [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) , [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--) , [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--) और [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) के माध्यम से प्राप्त करें। केवल प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट पर निर्भर न रहें, क्योंकि उनके टेक्स्ट‑फ़ॉर्मेटिंग मान संबंध हटाने के बाद बदल सकते हैं। कैप्चर किए गए मानों को बाद में सामान्य आकृति पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट परिवार, आकार, शैली, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट‑फ़्रेम सेटिंग्स, फ़िल और लाइन शामिल हों जो आपके टेम्प्लेट द्वारा उपयोग किए जाते हैं।

विरासत में मिली आकृति ज्यामिति को भी [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) के माध्यम से स्पष्ट रूप से सेट करना पड़ सकता है। आयताकार टेक्स्ट प्लेसहोल्डर के लिए, इसका अर्थ है [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle) को असाइन करना; केवल फ़िल और लाइन को पुनर्स्थापित करने से दृश्य आयत नहीं बन सकती। अतिरिक्त प्रभाव या अधिक जटिल स्वरूपण वाले टेम्प्लेट को भी इन सेटिंग्स को संभालना आवश्यक है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। इसका [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) मेथड उपयोग करने से पहले [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) के लिए जाँच करें।

यह उदाहरण पहली स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) में कास्ट करने से बचाता है। यह प्लेसहोल्डर को उसके उद्देश्य से पहचानता है बजाय कि नाज़ुक आकृति अनुक्रमांक पर निर्भर रहने के।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिज़ाइन‑टाइम निर्देश है जो एक खाली प्लेसहोल्डर में दिखाया जाता है, जैसे *Click to add title*। कस्टम प्रॉम्प्ट टेक्स्ट को सामान्य स्लाइड की आकृति संग्रह के माध्यम से पहुँचने की बजाय लेआउट प्लेसहोल्डर पर सेट करें। लेआउट तक पहुँचने के लिए [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) का उपयोग करें और फिर [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/) द्वारा लौटाए गए संग्रह पर इटरेट करें।

पहली स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट बदलने वाला निम्न उदाहरण देखें:

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

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन ऐप्लिकेशन में खाली प्लेसहोल्डर के लिये अभिप्रेत है। उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान करने पर प्रॉम्प्ट प्रदर्शित नहीं रहता। प्रॉम्प्ट बदलने से लेआउट का उपयोग करने वाली स्लाइडों पर मौजूद टेक्स्ट नहीं हटता।

## **चित्र प्लेसहोल्डर अपडेट करें**

दो मामलों को संभालना होता है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) द्वारा दर्शाया गया है, तो [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) और [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) के माध्यम से चित्र बदलें।  
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो प्लेसहोल्डर के निर्देशांक पर [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) से एक चित्र फ़्रेम जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

निम्न उदाहरण दोनों मामलों को सपोर्ट करता है और प्रस्तुति सहेजता है:

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

खाली प्लेसहोल्डर के लिये बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ़्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) में कोई सेट्टर नहीं होता। यह आरक्षित स्थान रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार नहीं विरासत में लेता। यदि प्लेसहोल्डर संबंध बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides से परिणामी [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) को अपडेट करें।

चित्र की पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिये देखें [Manage Picture Frames](/slides/hi/androidjava/picture-frame/)। ये ऑपरेशन चित्र फ़्रेम या चित्र फ़िल के अंतर्गत आते हैं, न कि प्लेसहोल्डर मेटाडेटा के।

## **चार्ट और कंटेंट प्लेसहोल्डर के साथ काम करें**

भरे हुए चार्ट प्लेसहोल्डर को एक [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) द्वारा दर्शाया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रन‑टाइम इंटरफ़ेस दोनों से ऐसे चार्ट को खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

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

एक सामान्य कंटेंट प्लेसहोल्डर आम तौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों (चार्ट, टेबल, डायग्राम, चित्र, मीडिया) के लिये लॉन्चर के रूप में काम करता है। एक बार यह भरा होने पर, वास्तविक आकृति इंटरफ़ेस की जाँच करके पता लगाया जा सकता है कि इसमें क्या है। विशेष लेआउट [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) भी प्रकट कर सकते हैं।

Aspose.Slides केवल [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) को बदलकर खाली [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) प्लेसहोल्डर को [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) में नहीं बदलता; प्रकार इंटरफ़ेस के माध्यम से नहीं बदला जा सकता। खाली चार्ट या कंटेंट एरिया को प्रोग्रामेटिक रूप से भरने के लिये, प्लेसहोल्डर के निर्देशांक पर आवश्यक ऑब्जेक्ट जोड़ें और फिर खाली प्लेसहोल्डर हटाएँ। निम्न उदाहरण एक चार्ट के लिये यही करता है:

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

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। जब आपको इसकी श्रेणियाँ, श्रृंखलाएँ या वर्कबुक डेटा बदलने की आवश्यकता हो तो समर्पित [chart management articles](/slides/hi/androidjava/powerpoint-charts/) देखें।

## **पूरा उदाहरण: टेक्स्ट या छवि सामग्री अपडेट करें**

निम्न एंड‑टू‑एंड उदाहरण एक टेम्प्लेट खोलता है, पहली स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकृति प्रकार की जाँच करता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण जानबूझकर आकृति अनुक्रमांक या सभी प्लेसहोल्डर को समान इंटरफ़ेस में कास्ट करने पर निर्भर नहीं रहता।

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

## **अधिकतर पूछे जाने वाले प्रश्न (FAQ)**

**एक बेस प्लेसहोल्डर क्या है?**

एक बेस प्लेसहोल्डर वह संबंधित आकृति है जो लेआउट या मास्टर पर स्थित है, जिससे कोई अन्य प्लेसहोल्डर विरासत प्राप्त करता है। इसे प्राप्त करने के लिये [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) का उपयोग करें। एक सामान्य स्थानीय आकृति `null` लौटाती है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिला स्वरूपण या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, पर वास्तविक शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत होती है। पूरे प्रस्तुतीकरण में शीर्षक टेक्स्ट बदलने के लिये स्लाइडों पर इटरेट करके प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फूटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्तर पर हेडर और फूटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिये देखें [Manage Presentation Header and Footer](/slides/hi/androidjava/presentation-header-and-footer/)。