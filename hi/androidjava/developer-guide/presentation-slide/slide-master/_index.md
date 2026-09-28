---
title: एन्ड्रॉइड पर प्रस्तुति स्लाइड मास्टर्स प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/androidjava/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- मास्टर स्लाइड डुप्लिकेट करें
- अप्रयुक्त मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में स्लाइड मास्टर्स को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतीकरणों में मास्टर स्लाइड्स तक पहुंच, संपादन, क्लोन, तुलना और हटाना।"
---
## **समीक्षा**

एक **स्लाइड मास्टर** स्लाइड्स के समूह के लिए साझा डिजाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फुटर सेटिंग्स शामिल हो सकती हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना वही सामान्य तरीका है जिससे प्रस्तुति को निरंतर रखा जाता है बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for Android via Java समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स आमतौर पर सीधे मास्टर स्लाइड को संदर्भित नहीं करती। इसके बजाय, एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है।

क्रमिकता इस प्रकार है:

1. **स्लाइड मास्टर** – साझा डिजाइन और थीम को परिभाषित करता है।  
1. **लेआउट स्लाइड** – प्लेसहोल्डर्स और लेआउट‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **सामान्य स्लाइड** – वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड्स, लेआउट स्लाइड्स, और सामान्य स्लाइड्स की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [IMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया जाता है। किसी प्रस्तुति में सभी मास्टर स्लाइड्स को [Presentation.getMasters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getMasters--) संग्रह के माध्यम से उपलब्ध किया जा सकता है, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) को लागू करता है। पूरी Android via Java API सतह के लिए, देखें [com.aspose.slides API संदर्भ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/)।

{{% alert color="info" title="विरासत" %}}

जब समान प्रॉपर्टी अधिकतम एक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/slides/hi/androidjava/slide-layout/)।

{{% /alert %}}

## **स्लाइड मास्टर तक पहुँचें**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुँचने के लिए `getMasters()` संग्रह का उपयोग करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

आप सामान्य स्लाइड के लेआउट के माध्यम से उपयोग की गई मास्टर स्लाइड भी प्राप्त कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **एक स्लाइड मास्टर में क्या होता है**

एक मास्टर स्लाइड एक स्लाइड‑समान ऑब्जेक्ट है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग की जाने वाली कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground()` | मास्टर‑स्तर स्लाइड पृष्ठभूमि निर्धारित करता है। |
| `getShapes()` | मास्टर पर रखे गए आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `getLayoutSlides()` | उन लेआउट स्लाइड्स को संग्रहीत करता है जो मास्टर से संबंधित हैं। |
| `getThemeManager()` | मास्टर थीम API तक पहुंच प्रदान करता है। |
| `getHeaderFooterManager()` | हेडर, फुटर, तिथियों और स्लाइड नंबरों को मास्टर और उसकी चाइल्ड लेआउट्स के लिए नियंत्रित करता है। |
| `getDependingSlides()` | उन सामान्य स्लाइड्स को लौटाता है जो अपनी लेआउट के माध्यम से मास्टर पर निर्भर हैं। |

## **स्लाइड मास्टर में कोई चित्र जोड़ें**

जब आप मास्टर स्लाइड में एक चित्र जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देता है जो उस मास्टर की लेआउट्स का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहला मास्टर स्लाइड में एक लोगो जोड़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/androidjava/picture-frame/)।

## **मास्टर ग्राफ़िक्स की दृश्यता नियंत्रित करें**

[आईबेसस्लाइड.setShowMasterShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) का उपयोग करके, आप इनहेरिटेड मास्टर ग्राफ़िक्स (जैसे लोगो या सजावटी आकार) को हटाए बिना छिपा सकते हैं। स्लाइड पर `false` पास करें ताकि उन ग्राफ़िक्स को छोड़ दिया जाए, और उन स्लाइड्स पर `true` रखें जहाँ उन्हें दिखाना है।

निम्न स्व-निहित उदाहरण एक मास्टर पर नीला सजावटी बैंड बनाता है और दो स्लाइड्स बनाता है जो समान खाली लेआउट का उपयोग करती हैं। बैंड पहली स्लाइड पर दिखाई देता है और दूसरी पर छिपा रहता है। कोई इनपुट प्रस्तुति या चित्र आवश्यक नहीं है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

उदाहरण एक नई प्रस्तुति के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने प्लेसहोल्डर्स को हटाता है।

### **सेटिंग के दायरे को चुनें**

एक सामान्य स्लाइड अपने मास्टर तक [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getLayoutSlide--) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--) के माध्यम से पहुँचती है। व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल वह स्लाइड प्रभावित होती है। `false` पास करने से [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) उन स्लाइड्स के लिए मास्टर ग्राफ़िक्स छिपा देता है जो उस साझा लेआउट का उपयोग करती हैं, भले ही उनके अपने सेटिंग `true` हों। केवल एक स्लाइड पर ग्राफ़िक्स छिपाने के लिए, स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को अपरिवर्तित छोड़ें।

मास्टर स्लाइड स्वयं पर दृश्यता नियंत्रण के रूप में यह सेटिंग समर्थित नहीं है। मास्टर पर [getShowMasterShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) हमेशा `false` लौटाता है, और [setShowMasterShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) पर `true` पास करने से अपवाद उत्पन्न होता है। इसे सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करें**

| ऑपरेशन | प्रभाव |
| --- | --- |
| मास्टर ग्राफ़िक्स छिपाएँ | इनहेरिटेड मास्टर आकारों की दृश्यता को हटाए बिना नियंत्रित करता है, और स्लाइड के अपने आकारों को नहीं बदलता। |
| स्लाइड पृष्ठभूमि भर बदलें | पृष्ठभूमि का रंग, ग्रेडिएंट या चित्र बदलता है। मास्टर ग्राफ़िक्स अलग आकार होते हैं और उस पृष्ठभूमि के ऊपर दृश्य रह सकते हैं। देखें [Presentation Background](/slides/hi/androidjava/presentation-background/)। |
| मास्टर से आकार हटाएँ | साझा स्रोत आकार को हटा देता है, इसलिए अब वह किसी भी स्लाइड के लिए उपलब्ध नहीं रहता जो उस मास्टर का उपयोग करती हैं। |

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर्स आमतौर पर लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करता है जिसे लेआउट्स इनहेरिट करते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और उन्हें कहाँ रखा गया है।

PowerPoint में, प्लेसहोल्डर कमांड्स स्लाइड मास्टर दृश्य में उपलब्ध होते हैं।

![PowerPoint स्लाइड मास्टर दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर्स जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से संबंधित है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप मौजूदा मास्टर स्लाइड पर मौजूद प्लेसहोल्डर आकारों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![सामान्य स्लाइड्स द्वारा इनहेरिटेड फ़ॉर्मेटेड शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/androidjava/manage-placeholder/) और [Text Formatting](/slides/hi/androidjava/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि उन लेआउट्स और स्लाइड्स द्वारा इनहेरिटेड होती है जो उसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/androidjava/presentation-background/) और [Presentation Theme](/slides/hi/androidjava/presentation-theme/)।

## **एक स्लाइड मास्टर को दूसरी प्रस्तुति में क्लोन करें**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) का उपयोग करके मास्टर स्लाइड को किसी अन्य प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर फिर गंतव्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

यदि आपको सामान्य स्लाइड्स को उनके मास्टर के साथ क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/slides/hi/androidjava/clone-slides/)।

## **कई स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न सेक्शन को अलग‑अलग ब्रांडिंग, पेज संरचना या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को सम्मिलित और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट के आधार पर एक नई स्लाइड जोड़ता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड्स की तुलना [IBaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/) से विरासत में मिली `equals` मेथड से की जा सकती है। तुलना संरचना और स्थिर सामग्री जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स को जाँचती है। यह स्लाइड IDs जैसे अद्वितीय पहचानकर्ताओं या वर्तमान तिथि जैसे डायनामिक प्लेसहोल्डर मानों की तुलना नहीं करती।

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/androidjava/compare-slides/)।

## **डिफ़ॉल्ट व्यू के रूप में स्लाइड मास्टर व्यू सेट करें**

[ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करके उस दृश्य को नियंत्रित करें जिसे PowerPoint सबसे पहले खोलता है। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अधिक व्यू सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/androidjava/save-presentation/)।

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कभी‑कभी प्रस्तुतियों में ऐसे मास्टर स्लाइड्स होते हैं जो अब किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं किए जाते। अनुपयोगी मास्टर को हटाने से फ़ाइल आकार घट सकता है और टेम्प्लेट रखरखाव सरल हो सकता है।

`removeUnused` का उपयोग करके `getMasters()` संग्रह से अनुपयोगी मास्टर को हटा सकते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप कम‑कोड [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड का भी उपयोग कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकार और टेक्स्ट शैलियों जैसी साझा डिजाइन सेटिंग्स को परिभाषित करता है। एक लेआउट स्लाइड एक मास्टर स्लाइड से जुड़ी होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है। एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से इनहेरिट करती है।

**क्या एक प्रस्तुति कई स्लाइड मास्टर रख सकती है?**

हाँ। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। विभिन्न सेक्शन को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की जरूरत होने पर कई मास्टर का उपयोग करें।

**क्या मुझे प्लेसहोल्डर्स मास्टर स्लाइड पर जोड़ने चाहिए या लेआउट स्लाइड पर?**

अधिकतर मामलों में प्लेसहोल्डर्स को लेआउट स्लाइड्स पर जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को मास्टर स्लाइड पर रखें, फिर उन लेआउट्स पर कंटेंट प्लेसहोल्डर्स रखें जो सामान्य स्लाइड्स उपयोग करेंगे।

**क्या मैं अभी भी उपयोग में आने वाली मास्टर स्लाइड को हटा सकता हूँ?**

नहीं। कोई मास्टर स्लाइड जो डिपेंडेंट स्लाइड्स रखती है, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या ऐसे क्लीन‑अप मेथड का उपयोग करें जो केवल अनउपयोगी मास्टर को हटाता है।