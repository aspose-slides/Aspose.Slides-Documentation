---
title: Android पर प्रस्तुति स्लाइड मास्टर प्रबंधित करें
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
description: "Aspose.Slides for Android via Java में स्लाइड मास्टर को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **अवलोकन**

एक **स्लाइड मास्टर** कई स्लाइडों के समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकृतियाँ, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फ़ूटर सेटिंग्स हो सकती हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना यह सुनिश्चित करने का सामान्य तरीका है कि प्रस्तुति समान रहे बिना प्रत्येक स्लाइड पर वही स्वरूप दोहराए।

Aspose.Slides for Android via Java समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स सीधे मास्टर स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है।

क्रम संरचना इस प्रकार है:

1. **स्लाइड मास्टर** - साझा डिज़ाइन और थीम को परिभाषित करता है।  
1. **लेआउट स्लाइड** - प्लेसहोल्डर और लेआउट‑स्तरीय फ़ॉर्मेटिंग का विशिष्ट विन्यास परिभाषित करता है।  
1. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री को सम्मिलित करती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड्स, लेआउट स्लाइड्स, और सामान्य स्लाइड्स की क्रम संरचना](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [IMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया गया है। किसी प्रस्तुति में सभी मास्टर स्लाइड्स को [Presentation.getMasters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getMasters--) संग्रह के माध्यम से उपलब्ध किया जा सकता है, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) को लागू करता है। पूर्ण Android via Java API सतह के लिए, देखें [com.aspose.slides API reference](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/)।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर की प्रॉपर्टी लागू होती है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि को परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/slides/hi/androidjava/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंचें**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर व्यू खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुँचने के लिए `getMasters()` संग्रह का उपयोग करें:

```java
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

आप सामान्य स्लाइड के लेआउट के माध्यम से उपयोग में लाई गई मास्टर स्लाइड को भी प्राप्त कर सकते हैं:

```java
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

## **स्लाइड मास्टर में क्या होता है**

एक मास्टर स्लाइड एक स्लाइड‑जैसा ऑब्जेक्ट है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्य इस प्रकार हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground()` | मास्टर‑स्तर स्लाइड पृष्ठभूमि को सेट करता है। |
| `getShapes()` | मास्टर पर रखी गई आकृतियों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `getLayoutSlides()` | उन लेआउट स्लाइड्स को संग्रहीत करता है जो मास्टर से संबंधित हैं। |
| `getThemeManager()` | मास्टर थीम API तक पहुँच प्रदान करता है। |
| `getHeaderFooterManager()` | मास्टर और उसकी चाइल्ड लेआउट्स के लिए हेडर, फ़ूटर, तिथियों और स्लाइड नंबरों को नियंत्रित करता है। |
| `getDependingSlides()` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट के माध्यम से मास्टर पर निर्भर करती हैं। |

## **स्लाइड मास्टर में चित्र जोड़ें**

जब आप मास्टर स्लाइड में एक चित्र जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देता है जो उस मास्टर से लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण प्रथम मास्टर स्लाइड में एक लोगो जोड़ता है:

```java
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

## **प्लेसहोल्डर के साथ काम करें**

प्लेसहोल्डर सामान्यतः लेआउट स्लाइड्स पर परिभाषित किए जाते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करता है जिसे लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ स्थित हैं।

PowerPoint में, प्लेसहोल्डर कमांड्स स्लाइड मास्टर व्यू में उपलब्ध हैं।

![PowerPoint स्लाइड मास्टर व्यू में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर जोड़ने के लिए, मास्टर से संबंधित लेआउट स्लाइड के साथ कार्य करें:

```java
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

आप पहले से मौजूद मास्टर स्लाइड पर प्लेसहोल्डर आकृतियों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:

```java
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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेट किया गया शीर्षक प्लेसहोल्डर](slide-master_8.png)

प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के बारे में अधिक जानकारी के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/androidjava/manage-placeholder/) और [Text Formatting](/slides/hi/androidjava/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि को लेआउट और स्लाइड्स द्वारा विरासत में लिया जाता है जब तक कि वे उसे ओवरराइड न करें। निम्न उदाहरण प्रथम मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/androidjava/presentation-background/) और [Presentation Theme](/slides/hi/androidjava/presentation-theme/)।

## **मास्टर स्लाइड को अन्य प्रस्तुति में क्लोन करें**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) का उपयोग करके एक मास्टर स्लाइड को अन्य प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर फिर लक्षित प्रस्तुति में लेआउट और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```java
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

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग‑अलग ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को सम्मिलित और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन की नीचे एक लेआउट बनाता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

मास्टर स्लाइड्स की तुलना `equals` मेथड द्वारा की जा सकती है जो [IBaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/) से विरासत में मिलता है। तुलना संरचना और स्थैतिक सामग्री जैसे आकृतियों, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन और अन्य स्लाइड सेटिंग्स को जांचती है। यह स्लाइड IDs जैसे अद्वितीय पहचानकर्ताओं या वर्तमान तिथि जैसे गतिशील प्लेसहोल्डर मानों की तुलना नहीं करती।

```java
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

[ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करके PowerPoint के पहले खुलने वाले व्यू को नियंत्रित करें। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अधिक व्यू सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/androidjava/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

कभी‑कभी प्रस्तुतियों में ऐसे मास्टर स्लाइड्स होते हैं जो अब किसी सामान्य स्लाइड द्वारा उपयोग नहीं किए जाते। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्पलेट रखरखाव सरल बनता है।

`removeUnused` का उपयोग करके `getMasters()` संग्रह से अप्रयुक्त मास्टर को हटाएँ:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप कम‑कोड [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड का भी प्रयोग कर सकते हैं:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकृतियों और टेक्स्ट शैलियों जैसे साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है और प्लेसहोल्डर का विशिष्ट विन्यास निर्धारित करती है। सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में लेती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हां। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। जब विभिन्न अनुभागों को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होती है, तो कई मास्टर का उपयोग करें।

**मास्टर स्लाइड में या लेआउट स्लाइड में प्लेसहोल्डर जोड़ना चाहिए?**

अधिकांश मामलों में प्लेसहोल्डर लेआउट स्लाइड में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर लेआउट पर रखें जिन्हें सामान्य स्लाइड्स उपयोग करती हैं।

**क्या मैं अभी भी उपयोग में मौजूद मास्टर स्लाइड को हटा सकता हूँ?**

नहीं। जिस मास्टर स्लाइड पर निर्भर स्लाइड्स हैं, उसे सीधे हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट में स्थानांतरित करें, या एक ऐसा क्लीन‑अप मेथड उपयोग करें जो केवल अप्रयुक्त मास्टर को ही हटाए।