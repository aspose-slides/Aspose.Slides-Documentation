---
title: Java के साथ प्रस्तुतियों में स्लाइड सेक्शन व्यवस्थापित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/java/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- सेक्शन स्लाइड्स पुनः प्राप्त करें
- सेक्शन स्लाइड्स प्रोसेस करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ स्लाइड सेक्शन प्रबंधित करें: बनाएं, पुनःनाम दें, पुनःक्रमित करें, पुनः प्राप्त करें, और PPTX प्रस्तुतियों में सेक्शन स्लाइड्स प्रोसेस करें।"
---
## **परिचय**

सेक्शन क्रमागत स्लाइड्स को नामित समूहों में व्यवस्थित करते हैं बिना स्लाइड सामग्री बदले। Aspose.Slides for Java के साथ, आप सेक्शन को बनाते, पुन: क्रमबद्ध करते, पुन:नामित करते, निरीक्षण करते और हटाते हैं [Presentation.getSections](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSections--) मेथड के माध्यम से।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- किसी बड़ी प्रस्तुति को तार्किक विषयों या अध्यायों में विभाजित करने की आवश्यकता होती है;
- विभिन्न समूहों की स्लाइड्स विभिन्न सहयोगियों को सौंपे जाते हैं;
- स्लाइड्स को समूह के रूप में प्रोसेस, स्थानांतरित या मर्ज करने की आवश्यकता होती है।

संक्षिप्त सेक्शन नाम चुनें जो समूहित स्लाइड्स के उद्देश्य को दर्शाते हों। क्योंकि सेक्शन प्रस्तुति संरचना का भाग होते हैं, सदस्यता निर्धारित करने के लिए सेक्शन APIs का उपयोग करें, न कि स्लाइड स्थितियों से अनुमान लगाएँ।

## **सेक्शन बनाएं और प्रबंधित करें**

[ISectionCollection.addSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) का उपयोग करके सेक्शन का नाम और प्रारंभिक स्लाइड निर्दिष्ट करके सेक्शन बनाएं। Aspose.Slides वर्तमान सेक्शन संरचना के आधार पर निर्धारित करता है कि कौन सी स्लाइड्स सेक्शन से संबंधित हैं।

इसी [ISectionCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/) के माध्यम से आप भी कर सकते हैं:

- [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) का उपयोग करके सेक्शन को उसकी स्लाइड्स के साथ स्थानांतरित करें;
- केवल सेक्शन परिभाषा को हटाएं [ISectionCollection.removeSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) से, जो स्लाइड्स को बरकरार रखता है;
- सेक्शन और उसकी स्लाइड्स दोनों को हटाएं [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) से;
- अंत में एक खाली सेक्शन जोड़ें [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) से।

निम्न उदाहरण दो सेक्शन बनाता है, उनमें से एक को स्थानांतरित करता है, उसे उसकी स्लाइड्स के साथ हटाता है, और एक खाली सेक्शन जोड़ता है:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

इन ऑपरेशनों के बाद, प्रस्तुति में `Introduction` सेक्शन उसकी स्लाइड्स के साथ और एक खाली `Appendix` सेक्शन रहता है। `Results` सेक्शन और उसकी स्लाइड्स हटा दी गई हैं।

## **सेक्शन का नाम बदलें**

एक सेक्शन का नाम बदलने के लिए, उसके [ISection.setName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#setName-java.lang.String-) मेथड को कॉल करें। सेक्शन की स्लाइड्स और उसकी स्थिति अपरिवर्तित रहती है।

निम्न उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **सेक्शन से स्लाइड्स प्राप्त करें**

[Presentation.getSections](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSections--) मेथड एक [ISectionCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectioncollection/) लौटाता है जिसे आप इटरेट कर सकते हैं। प्रत्येक [ISection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/) के लिए, उस सेक्शन की वर्तमान स्लाइड्स प्राप्त करने हेतु [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getSlidesListOfSection--) को कॉल करें। यह मेथड एक [ISectionSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectionslidecollection/) लौटाता है, जो गिनती, अनुक्रमिक पहुँच और इटरेशन प्रदान करता है।

निम्न उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [name](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getStartedFromSlide--), स्लाइड गिनती और स्लाइड नंबर प्रिंट करता है। यह पहले स्लाइड को पढ़ने के लिए [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) का उपयोग करता है और प्रत्येक स्लाइड को प्रोसेस करने के लिए एक उन्नत `for` स्टेटमेंट लागू करता है। खाली सेक्शन के लिए, लौटाई गई कलेक्शन का आकार शून्य होता है, मेथड नहीं बुलाया जाता, और इटरेशन कोई ऑपरेशन नहीं करता।

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

सेक्शन सदस्यता प्रस्तुति की सेक्शन संरचना द्वारा निर्धारित होती है। [ISection.getStartedFromSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getStartedFromSlide--) या स्लाइड इंडेक्स और अगले सेक्शन की प्रारंभिक स्लाइड से सेक्शन की सीमा को मैन्युअली गणना न करें।

संरचनात्मक बदलावों से किसी सेक्शन के लिए लौटाई गई स्लाइड्स और उनके स्लाइड नंबर दोनों बदल सकते हैं। इसमें स्लाइड्स का पुन: क्रमबद्ध करना, स्लाइड को किसी सेक्शन में क्लोन करना, सेक्शन को उसकी स्लाइड्स के साथ स्थानांतरित करना, स्लाइड्स हटाना, और सेक्शन हटाना शामिल है। अगला उदाहरण हर ऐसे परिवर्तन के बाद [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getSlidesListOfSection--) को कॉल करता है, बजाय इसके कि सेक्शन की पूर्व सीमाओं के बारे में धारणाएँ बनाए रखें।

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

जब भी स्लाइड्स या सेक्शन को पुन: क्रमबद्ध, क्लोन, स्थानांतरित या हटाया जाए, फिर से [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getSlidesListOfSection--) को कॉल करें। यह बाद की प्रोसेसिंग को वर्तमान प्रस्तुति संरचना के साथ संरेखित रखता है।

PPT (PowerPoint 97–2003) फ़ॉर्मेट सेक्शन मेटाडेटा को संरक्षित नहीं करता। इस वर्कफ़्लो को ऐसे फ़ॉर्मेट के साथ उपयोग करें जो सेक्शन का समर्थन करता हो, जैसे PPTX; PPT में कनवर्ट करने से बाद की इटरेशन के लिए आवश्यक सेक्शन संरचना हट जाती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सेक्शन को PPT (PowerPoint 97–2003) फ़ॉर्मेट में सेव करने पर संरक्षित रखा जाता है?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा का समर्थन नहीं करता, इसलिए .ppt में सेव करने पर सेक्शन समूह खो जाता है।

**क्या किसी पूरे सेक्शन को "छिपाया" जा सकता है?**

नहीं। सेक्शन की कोई दृश्यता स्थिति नहीं होती। इसकी सामग्री को छिपाने के लिए, सेक्शन की प्रत्येक स्लाइड के लिए [ISlide.setHidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#setHidden-boolean-) को कॉल करें।

**मैं किसी स्लाइड को शामिल करने वाले सेक्शन को कैसे खोजूँ?**

[Presentation.getSections](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSections--) से प्राप्त कलेक्शन को इटरेट करें, प्रत्येक सेक्शन के लिए [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getSlidesListOfSection--) को कॉल करें, और लौटाई गई स्लाइड्स की लक्ष्य स्लाइड से तुलना करें। गैर-खाली सेक्शन के लिए, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getStartedFromSlide--) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिए यह `null` लौटाता है।