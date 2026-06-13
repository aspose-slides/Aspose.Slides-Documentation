---
title: Java में प्रस्तुति स्लाइड मास्टर को प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/java/slide-master/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाएँ।"
---
## **अवलोकन**

एक **स्लाइड मास्टर** समूह में स्लाइड्स के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फुटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना एक सामान्य तरीका है जिससे प्रस्तुति को लगातार बनाए रखा जा सके बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for Java समान मॉडल को समर्थन देता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स आमतौर पर सीधे एक मास्टर स्लाइड का संदर्भ नहीं देतीं। बल्कि, एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है।

क्रमशः संरचना इस प्रकार है:

1. **स्लाइड मास्टर** - साझा डिज़ाइन और थीम को परिभाषित करता है।
2. **लेआउट स्लाइड** - प्लेसहोल्डर्स और लेआउट-स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
3. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड, लेआउट स्लाइड और सामान्य स्लाइड का क्रमशः संरचना](slide-master_2.jpg)

Aspose.Slides में, स्लाइड मास्टर को [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया गया है। प्रस्तुति में सभी मास्टर स्लाइड्स [Presentation.getMasters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getMasters--) संग्रह के माध्यम से उपलब्ध होती हैं, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) को लागू करती है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित की जाती है, तो अधिक विशिष्ट स्तर को प्राथमिकता मिलती है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि को परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए, देखें [Apply or Change Slide Layouts](/slides/hi/java/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

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

आप किसी सामान्य स्लाइड द्वारा उपयोग की गई मास्टर स्लाइड को उसके लेआउट के माध्यम से भी प्राप्त कर सकते हैं:

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

एक मास्टर स्लाइड एक स्लाइड-समान वस्तु है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग की जाने वाली कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है। मास्टर-विशिष्ट सदस्य [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) API पेज पर सूचीबद्ध हैं।

सामान्य रूप से उपयोग किए जाने वाले मास्टर स्लाइड सदस्य शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground()` | मास्टर-स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `getShapes()` | मास्टर पर रखे गये आकार संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `getLayoutSlides()` | मास्टर से संबंधित लेआउट स्लाइड्स को संग्रहीत करता है। |
| `getThemeManager()` | मास्टर थीम APIs तक पहुँच प्रदान करता है। |
| `getHeaderFooterManager()` | मास्टर और उसके चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथि और स्लाइड नंबर नियंत्रित करता है। |
| `getDependingSlides()` | लेआउट्स के माध्यम से मास्टर पर निर्भर सामान्य स्लाइड्स को लौटाता है। |

## **स्लाइड मास्टर में छवि जोड़ें**

जब आप एक मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उस मास्टर के लेआउट्स का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड, और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण में पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

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

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/java/picture-frame/)।

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर्स आमतौर पर लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करता है जिसे ये लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, प्लेसहोल्डर कमांड्स स्लाइड मास्टर दृश्य में उपलब्ध हैं।

![PowerPoint स्लाइड मास्टर दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर्स जोड़ने के लिए, मास्टर से जुड़े लेआउट स्लाइड के साथ कार्य करें:

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

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकार को भी फॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रेखीय ग्रेडिएंट फ़िल लागू करता है:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![सामान्य स्लाइड्स द्वारा विरासत में ली गई स्वरूपित शीर्षक प्लेसहोल्डर](slide-master_8.png)

और अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/java/manage-placeholder/) और [Text Formatting](/slides/hi/java/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

एक मास्टर पृष्ठभूमि को लेआउट्स और उन स्लाइड्स द्वारा विरासत में प्राप्त किया जाता है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```java
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

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/java/presentation-background/) और [Presentation Theme](/slides/hi/java/presentation-theme/)।

## **एक स्लाइड मास्टर को अन्य प्रस्तुति में क्लोन करें**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) का उपयोग करके एक मास्टर स्लाइड को अन्य प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर फिर लक्ष्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

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

यदि आपको उनके मास्टर के साथ सामान्य स्लाइड्स को क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/slides/hi/java/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकते हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग-अलग ब्रांडिंग, पेज संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को सम्मिलित और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को एक अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट के आधार पर एक नई स्लाइड जोड़ता है:

```java
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

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड्स की तुलना [IBaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/) से विरासत में मिले `equals` मेथड से की जा सकती है। तुलना संरचना और स्थैतिक सामग्री जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स की जाँच करती है। यह अद्वितीय पहचानकर्ताओं जैसे स्लाइड IDs, या डायनामिक प्लेसहोल्डर मान जैसे वर्तमान तिथि की तुलना नहीं करती।

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

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/java/compare-slides/)।

## **स्लाइड मास्टर दृश्य को डिफ़ॉल्ट दृश्य के रूप में सेट करें**

[ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करके PowerPoint द्वारा पहली बार खोला जाने वाला दृश्य नियंत्रित करें। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर दृश्य में खोलता है:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/java/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

प्रस्तुतियों में कभी-कभी ऐसी मास्टर स्लाइड्स होती हैं जो अब किसी सामान्य स्लाइड द्वारा उपयोग नहीं की जा रही हैं। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्प्लेट रखरखाव सरल हो जाता है।

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

आप कम-कोड [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड का भी उपयोग कर सकते हैं:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड के बीच क्या अंतर है?**

एक स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकार, और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। एक लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है। एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, इसलिए यह लेआउट और मास्टर दोनों से विरासत में लेती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हां। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। विभिन्न अनुभागों को अलग-अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होने पर कई मास्टर का उपयोग करें।

**क्या मुझे प्लेसहोल्डर्स मास्टर स्लाइड में जोड़ने चाहिए या लेआउट स्लाइड में?**

अधिकांश मामलों में, प्लेसहोल्डर्स को लेआउट स्लाइड में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर्स को उन लेआउट्स में रखें जो सामान्य स्लाइड्स उपयोग करेंगे।

**क्या मैं एक मास्टर स्लाइड को हटाने सकता हूँ जिसे अभी भी उपयोग किया जा रहा है?**

नहीं। एक मास्टर स्लाइड जिसमें निर्भर स्लाइड्स हैं, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में ले जाएं, या एक अप्रयुक्त-मास्टर सफाई विधि का उपयोग करें जो केवल उन मास्टर को हटाती है जो उपयोग में नहीं हैं।