---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/androidjava/examples/elements/master-slide/
keywords:
- कोड उदाहरण
- मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के मास्टर स्लाइड उदाहरणों का अन्वेषण करें: PPT, PPTX और ODP में स्पष्ट Java कोड के साथ मास्टर, प्लेसहोल्डर और थीम बनाएं, संपादित करें और स्टाइल करें।"
---
मास्टर स्लाइड्स PowerPoint में स्लाइड वंशानुक्रम की शीर्ष स्तर बनाते हैं। एक **मास्टर स्लाइड** सामान्य डिज़ाइन तत्वों जैसे पृष्ठभूमि, लोगो और टेक्स्ट फ़ॉर्मेटिंग को परिभाषित करती है। **लेआउट स्लाइड्स** मास्टर स्लाइड्स से वंशानुक्रमित होती हैं, और **नॉर्मल स्लाइड्स** लेआउट स्लाइड्स से वंशानुक्रमित होती हैं।

यह लेख Aspose.Slides for Android को Java के माध्यम से उपयोग करके मास्टर स्लाइड्स को बनाना, संशोधित करना और प्रबंधित करना दर्शाता है।

## **मास्टर स्लाइड जोड़ें**

यह उदाहरण दिखाता है कि डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करके नई मास्टर स्लाइड कैसे बनाई जाए। फिर यह लेआउट वंशानुक्रम के माध्यम से सभी स्लाइड्स में कंपनी नाम बैनर जोड़ता है।

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें।
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // मास्टर स्लाइड के शीर्ष पर कंपनी नाम के साथ बैनर जोड़ें।
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // नए मास्टर स्लाइड को लेआउट स्लाइड को असाइन करें।
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // लेआउट स्लाइड को प्रस्तुति की पहली स्लाइड को असाइन करें।
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** मास्टर स्लाइड्स सभी स्लाइड्स में सुसंगत ब्रांडिंग या साझा डिज़ाइन तत्वों को लागू करने का तरीका प्रदान करती हैं। मास्टर में किए गए कोई भी परिवर्तन स्वचालित रूप से निर्भर लेआउट और नॉर्मल स्लाइड्स में परिलक्षित होंगे।

> 💡 **Note 2:** मास्टर स्लाइड में जोड़े गए कोई भी आकार या फ़ॉर्मेटिंग लेआउट स्लाइड्स द्वारा विरासत में मिलते हैं और बदले में उन लेआउट्स का उपयोग करने वाली सभी नॉर्मल स्लाइड्स में।  
> नीचे दिया गया चित्र दर्शाता है कि मास्टर स्लाइड में जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वचालित रूप से कैसे प्रदर्शित होता है।

![Master Inheritance Example](master-slide-banner.png)

## **मास्टर स्लाइड तक पहुंचें**

आप प्रस्तुति मास्टर संग्रह का उपयोग करके मास्टर स्लाइड्स तक पहुंच सकते हैं। यहाँ बताया गया है कि उन्हें कैसे प्राप्त करें और उनके साथ काम करें:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // पृष्ठभूमि का प्रकार बदलें।
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

        // रेफ़रेंस द्वारा एक मास्टर स्लाइड हटाएँ।
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

कुछ प्रस्तुति में ऐसे मास्टर स्लाइड्स होते हैं जो उपयोग में नहीं हैं। इन स्लाइड्स को हटाने से फ़ाइल आकार कम करने में मदद मिल सकती है।

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // सभी अप्रयुक्त मास्टर स्लाइड्स हटाएँ (भले ही उन्हें Preserve के रूप में चिह्नित किया गया हो)।
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```