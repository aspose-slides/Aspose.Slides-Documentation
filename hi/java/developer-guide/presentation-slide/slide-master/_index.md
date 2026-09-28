---
title: जावा में प्रस्तुति स्लाइड मास्टर्स का प्रबंधन
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/java/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- कई मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- मास्टर स्लाइड डुप्लिकेट करें
- अनउपयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड मास्टर्स का प्रबंधन: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **अवलोकन**

एक **slide master** स्लाइड समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फुटर सेटिंग्स हो सकती हैं। PowerPoint में, slide master को संपादित करना प्रस्तुति को लगातार बनाए रखने का सामान्य तरीका है, जिससे प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराने की आवश्यकता नहीं रहती।

Aspose.Slides for Java समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक master slide हो सकते हैं, और प्रत्येक master slide में कई layout slide हो सकते हैं। सामान्य स्लाइडें सीधे master slide को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक layout slide का उपयोग करती है, और वह layout slide किसी master slide से जुड़ी होती है।

क्रम संरचना इस प्रकार है:

1. **Slide master** – साझा डिज़ाइन और थीम को परिभाषित करता है।  
1. **Layout slide** – प्लेसहोल्डर और लेआउट‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **Normal slide** – वास्तविक प्रस्तुति सामग्री रखती है और एक layout slide का उपयोग करती है।

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Aspose.Slides में, एक slide master को [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया जाता है। प्रस्तुति में सभी master slide `Presentation.getMasters` कलेक्शन के माध्यम से उपलब्ध होते हैं, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) को लागू करता है।

{{% alert color="info" title="Inheritance" %}}

जब एक ही प्रॉपर्टी कई स्तरों पर परिभाषित होती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि master slide और layout slide दोनों कोई पृष्ठभूमि परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइडें layout की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें: [Apply or Change Slide Layouts](/slides/hi/java/slide-layout/)।

{{% /alert %}}

## **Slide Masters तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से Slide Master दृश्य खोल सकते हैं।

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Aspose.Slides में, master slide तक पहुँचने के लिए `getMasters()` कलेक्शन का उपयोग करें:

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

आप सामान्य स्लाइड द्वारा उपयोग किए गए master slide को उसके layout के माध्यम से भी प्राप्त कर सकते हैं:

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

## **एक Slide Master में क्या होता है**

एक master slide स्लाइड‑समान ऑब्जेक्ट है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और layout स्लाइड्स द्वारा उपयोग की जाने वाली कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है। master‑विशिष्ट सदस्य [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्यतः उपयोग किए जाने वाले master slide सदस्य शामिल हैं:

| Member | Purpose |
| --- | --- |
| `getBackground()` | master‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `getShapes()` | master पर रखे गए आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `getLayoutSlides()` | उन layout slides को संग्रहीत करता है जो master से संबंधित हैं। |
| `getThemeManager()` | master थीम API तक पहुँच प्रदान करता है। |
| `getHeaderFooterManager()` | master और उसकी चाइल्ड लेआउट्स के हेडर, फ़ूटर, तिथि और स्लाइड नंबर को नियंत्रित करता है। |
| `getDependingSlides()` | उन normal slides को लौटाता है जो अपने लेआउट के माध्यम से master पर निर्भर हैं। |

## **Slide Master में चित्र जोड़ना**

जब आप master slide में एक चित्र जोड़ते हैं, तो वह उन सभी स्लाइड्स पर दिखाई देता है जो उस master के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले master slide में एक लोगो जोड़ता है:

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

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें: [Picture Frame](/slides/hi/java/picture-frame/)।

## **Master ग्राफ़िक्स की दृश्यता नियंत्रित करना**

[IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) का उपयोग करके आप विरासत में मिले master ग्राफ़िक्स (जैसे लोगो या सजावटी आकार) को हटाए बिना छुपा सकते हैं। जिस स्लाइड पर आप उन ग्राफ़िक्स को हटाना चाहते हैं, उस पर `false` पास करें — `Slide.setShowMasterShapes` पर — और उन स्लाइड्स पर `true` रखें जहाँ उन्हें दिखाना है।

निम्न स्व-समावेशी उदाहरण एक master पर नीला सजावटी बैंड बनाता है और दो स्लाइड्स पर वही खाली लेआउट उपयोग करता है। बैंड पहली स्लाइड पर दिखता है और दूसरी स्लाइड पर छुपा रहता है। कोई इनपुट प्रस्तुति या चित्र आवश्यक नहीं है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

यह उदाहरण नई प्रस्तुति में उपलब्ध **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के स्वयं के प्लेसहोल्डर को हटा देता है।

### **सेटिंग का दायरा चुनें**

एक normal slide अपने master को [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getLayoutSlide--) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) के माध्यम से उपयोग करती है। व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल वही स्लाइड प्रभावित होती है। `false` पास करने से — [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) — उस साझा लेआउट का उपयोग करने वाली सभी स्लाइड्स के लिए master ग्राफ़िक्स छुपते हैं, भले ही उनके अपने सेटिंग `true` हों। केवल एक ही स्लाइड पर ग्राफ़िक्स छुपाने के लिए, स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को अपरिवर्तित रहें।

master slide स्वयं पर यह सेटिंग दृश्यता नियंत्रण के रूप में समर्थित नहीं है। master पर, [getShowMasterShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterslide/#getShowMasterShapes--) हमेशा `false` लौटाता है, और [setShowMasterShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) पर `true` पास करने से अपवाद उत्पन्न होता है। इसे normal slide या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग पहचानें**

| Operation | Effect |
| --- | --- |
| Hide master graphics | विरासत में मिले master आकारों को हटाए बिना उनकी दृश्यता को नियंत्रित करता है। |
| Change the slide background fill | पृष्ठभूमि का रंग, ग्रेडिएंट या चित्र बदलता है। master ग्राफ़िक्स अलग आकार होते हैं और पृष्ठभूमि के ऊपर दिखाई दे सकते हैं। देखें: [Presentation Background](/slides/hi/java/presentation-background/)। |
| Delete a shape from the master | साझा स्रोत आकार को हटाता है, इसलिए वह किसी भी slide के लिए उपलब्ध नहीं रहता जो उस master का उपयोग करती है। |

## **Placeholders के साथ कार्य करना**

Placeholders आम तौर पर layout slides पर परिभाषित होते हैं। master slide साझा शैली और थीम प्रदान करता है, जिसे layout विरासत में लेते हैं, जबकि प्रत्येक layout तय करता है कि कौन‑से placeholders उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, placeholder कमांड्स Slide Master दृश्य में उपलब्ध होते हैं।

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Aspose.Slides के साथ नए placeholders जोड़ने के लिए, उस layout slide के साथ काम करें जो master से संबंधित है:

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

आप master slide पर पहले से मौजूद placeholder आकारों को भी फ़ॉर्मेट कर सकते हैं। नीचे दिया गया उदाहरण शीर्षक placeholder खोजता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

अधिक placeholder और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें: [Set Prompt Text in Placeholder](/slides/hi/java/manage-placeholder/) और [Text Formatting](/slides/hi/java/text-formatting/)।

## **Slide Master पृष्ठभूमि बदलना**

master पृष्ठभूमि को layouts और उन स्लाइड्स द्वारा विरासत में लिया जाता है जो इसे ओवरराइड नहीं करतीं। नीचे दिया गया उदाहरण पहले master slide के लिए ठोस पृष्ठभूमि रंग सेट करता है:

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

संबंधित विषयों के लिए देखें: [Presentation Background](/slides/hi/java/presentation-background/) और [Presentation Theme](/slides/hi/java/presentation-theme/)।

## **Slide Master को किसी अन्य प्रस्तुति में क्लोन करना**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) का उपयोग करके आप एक master slide को दूसरी प्रस्तुति में कॉपी कर सकते हैं। कॉपी किया गया master फिर लक्ष्य प्रस्तुति में लेआउट और स्लाइड्स द्वारा उपयोग किया जा सकता है।

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

यदि आपको master के साथ normal स्लाइड्स को भी क्लोन करने की आवश्यकता है, तो देखें: [Clone Slides](/slides/hi/java/clone-slides/)।

## **एकाधिक Slide Masters जोड़ना**

एक प्रस्तुति में कई master slide हो सकते हैं। यह तब उपयोगी होता है जब विभिन्न सेक्शन को विभिन्न ब्रांडिंग, पृष्ठ संरचना या थीम सेटिंग्स की आवश्यकता हो।

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट master को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन्ड master के नीचे एक layout बनाता है, और उस layout के आधार पर एक नई स्लाइड जोड़ता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **Slide Masters की तुलना करना**

master slides की तुलना `equals` मेथड से की जा सकती है, जो [IBaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/) से विरासत में मिली है। तुलना संरचना और स्थैतिक सामग्री (जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स) की जाँच करती है। यह स्लाइड IDs जैसी अद्वितीय पहचानकर्ताओं या वर्तमान तिथि जैसी डायनामिक placeholder मानों की तुलना नहीं करती।

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

अधिक जानकारी के लिए देखें: [Compare Presentation Slides](/slides/hi/java/compare-slides/)।

## **Slide Master दृश्य को डिफ़ॉल्ट दृश्य बनाना**

[ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करके आप PowerPoint के पहले खोलने वाले दृश्य को नियंत्रित कर सकते हैं। नीचे दिया गया उदाहरण प्रस्तुति को Slide Master दृश्य में खोलता है:

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

अधिक दृश्य सेटिंग्स के लिए देखें: [Save Presentation](/slides/hi/java/save-presentation/)।

## **अनुपयोगी Master Slides को हटाना**

कभी‑कभी प्रस्तुतियों में ऐसे master slide होते हैं जो किसी normal स्लाइड द्वारा अब उपयोग नहीं किए जाते। अनुपयोगी masters को हटाने से फ़ाइल आकार घटाया जा सकता है और टेम्प्लेट रख‑रखाव सरल बनता है।

`removeUnused` का प्रयोग करके `getMasters()` कलेक्शन से अनुपयोगी masters को हटाएँ:

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

आप कम‑कोड [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड का भी उपयोग कर सकते हैं:

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

## **FAQ**

**Slide master और layout slide में क्या अंतर है?**

Slide master थीम, पृष्ठभूमि, सामान्य आकार और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। Layout slide एक master slide से जुड़ी होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। Normal slide एक layout slide का उपयोग करती है, इसलिए वह दोनों layout और master से विरासत में प्राप्त करती है।

**क्या किसी प्रस्तुति में कई slide masters हो सकते हैं?**

हां। एक प्रस्तुति में कई slide masters हो सकते हैं। विभिन्न सेक्शन को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होने पर कई masters का प्रयोग करें।

**क्या मुझे placeholders master slide पर जोड़ने चाहिए या layout slide पर?**

अधिकांश मामलों में placeholders को layout slides में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग master slide पर रखें, और सामग्री placeholders को उन layouts पर रखें जो normal slides उपयोग करती हैं।

**क्या मैं ऐसे master slide को हटा सकता हूँ जो अभी भी उपयोग में है?**

नहीं। किसी master slide जिसमें निर्भर slides हैं, उसे सीधे हटाना सुरक्षित नहीं है। पहले उन slides को किसी अन्य master के तहत मौजूद लेआउट में स्थानांतरित करें, या एक ऐसा क्लीन‑अप मेथड उपयोग करें जो केवल अनुपयोगी masters को हटाए।