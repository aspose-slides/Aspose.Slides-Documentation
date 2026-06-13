---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/java/examples/elements/master-slide/
keywords:
- कोड उदाहरण
- मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java मास्टर स्लाइड उदाहरणों का अन्वेषण करें: PPT, PPTX, और ODP में स्पष्ट जावा कोड के साथ मास्टर्स, प्लेसहोल्डर्स और थीम्स को बनाएँ, संपादित करें और स्टाइल करें।"
---
मास्टर स्लाइड्स PowerPoint में स्लाइड वंशानुक्रम की शीर्ष स्तर बनाते हैं। एक **master slide** पृष्ठभूमि, लोगो और टेक्स्ट फॉर्मेटिंग जैसी सामान्य डिजाइन तत्वों को परिभाषित करती है। **Layout slides** मास्टर स्लाइड्स से विरासत में प्राप्त होती हैं, और **normal slides** लेआउट स्लाइड्स से विरासत में प्राप्त होती हैं।

यह लेख Aspose.Slides for Java का उपयोग करके मास्टर स्लाइड्स को बनाने, संशोधित करने और प्रबंधित करने का तरीका दर्शाता है।

## **मास्टर स्लाइड जोड़ें**

यह उदाहरण डिफॉल्ट मास्टर स्लाइड को क्लोन करके नई मास्टर स्लाइड बनाने का तरीका दर्शाता है। इसके बाद यह लेआउट विरासत के माध्यम से सभी स्लाइड्स में कंपनी का नाम बैनर जोड़ता है।

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें।
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // मास्टर स्लाइड के शीर्ष पर कंपनी नाम वाला बैनर जोड़ें।
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // नई मास्टर स्लाइड को लेआउट स्लाइड को असाइन करें।
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // लेआउट स्लाइड को प्रस्तुति की पहली स्लाइड को असाइन करें।
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** मास्टर स्लाइड्स सभी स्लाइड्स में सुसंगत ब्रांडिंग या साझा डिज़ाइन तत्व लागू करने का तरीका प्रदान करती हैं। मास्टर में किए गए कोई भी परिवर्तन स्वतः ही निर्भर लेआउट और सामान्य स्लाइड्स पर प्रतिबिंबित होते हैं।

> 💡 **Note 2:** मास्टर स्लाइड में जोड़े गए कोई भी आकार या फॉर्मेटिंग लेआउट स्लाइड्स द्वारा विरासत में प्राप्त होते हैं और बदले में उन लेआउट्स का उपयोग करने वाली सभी सामान्य स्लाइड्स में भी।  
> नीचे की छवि दर्शाती है कि कैसे मास्टर स्लाइड पर जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वचालित रूप से रेंडर होता है।

![मास्टर इनहेरिटेंस उदाहरण](master-slide-banner.png)

## **मास्टर स्लाइड तक पहुँचें**

आप प्रस्तुति मास्टर संग्रह का उपयोग करके मास्टर स्लाइड्स तक पहुँच सकते हैं। यह रहा उन्हें प्राप्त करने और उनके साथ काम करने का तरीका:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // पृष्ठभूमि प्रकार बदलें।
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **मास्टर स्लाइड हटाएँ**

मास्टर स्लाइड्स को इंडेक्स या संदर्भ द्वारा हटाया जा सकता है।

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // इंडेक्स द्वारा एक मास्टर स्लाइड हटाएँ।
        presentation.getMasters().removeAt(0);

        // संदर्भ द्वारा एक मास्टर स्लाइड हटाएँ।
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कुछ प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो उपयोग में नहीं हैं। इन स्लाइड्स को हटाने से फ़ाइल आकार कम करने में मदद मिलती है।

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // सभी अनुपयोगी मास्टर स्लाइड्स हटाएँ (भले ही वे Preserve के रूप में चिह्नित हों)।
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```