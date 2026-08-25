---
title: जावास्क्रिप्ट के साथ प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/nodejs-java/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- सेक्शन स्लाइड प्राप्त करें
- सेक्शन स्लाइड प्रक्रिया करें
- पावरपॉइंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ स्लाइड सेक्शन प्रबंधित करें: PPTX प्रस्तुतियों में सेक्शन स्लाइड बनाएं, नाम बदलें, क्रम बदलें, प्राप्त करें और प्रोसेस करें।"
---
## **परिचय**

सेक्शन क्रमिक स्लाइडों को नामित समूहों में व्यवस्थित करते हैं बिना स्लाइड सामग्री बदले। Aspose.Slides for Node.js via Java के साथ, आप सेक्शन को बनाना, क्रम बदलना, नाम बदलना, निरीक्षण करना और हटाना [Presentation.getSections](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSections) मेथड के माध्यम से कर सकते हैं।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- किसी बड़ी प्रस्तुति को तर्कसंगत विषयों या अध्यायों में विभाजित करने की आवश्यकता हो;
- विभिन्न स्लाइड समूह विभिन्न सहयोगियों को सौंपे गए हों;
- स्लाइडों को समूहों के रूप में प्रोसेस, ले जाया या मिलाया जाना हो।

ऐसे संक्षिप्त सेक्शन नाम चुनें जो समूहित स्लाइडों के उद्देश्य को वर्णित करें। चूंकि सेक्शन प्रस्तुति संरचना का हिस्सा होते हैं, इसलिए सेक्शन APIs का उपयोग करके सदस्यता निर्धारित करें, न कि स्लाइड स्थितियों से निकालें।

## **सेक्शन बनाना और प्रबंधन**

एक सेक्शन बनाते समय उसका नाम और प्रारंभिक स्लाइड निर्दिष्ट करने के लिए आप [SectionCollection.addSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/#addSection) का उपयोग कर सकते हैं। Aspose.Slides वर्तमान सेक्शन संरचना के आधार पर तय करता है कि कौन सी स्लाइडें सेक्शन में आती हैं।

एक ही [SectionCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/) निम्नलिखित कार्य भी संभव बनाता है:

- स्लाइडों के साथ एक सेक्शन को स्थानांतरित करने के लिए [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) का प्रयोग करें;
- केवल सेक्शन परिभाषा हटाने के लिए [SectionCollection.removeSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/#removeSection) का उपयोग करें, जिससे उसकी स्लाइडें बरकरार रहती हैं;
- सेक्शन और उसकी स्लाइडें दोनों हटाने के लिए [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) का प्रयोग करें;
- अंत में एक खाली सेक्शन जोड़ने के लिए [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) का उपयोग करें।

निम्नलिखित उदाहरण दो सेक्शन बनाता है, उनमें से एक को स्थानांतरित करता है, उसे उसकी स्लाइडों सहित हटाता है, और एक खाली सेक्शन जोड़ता है:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

इन संचालन के बाद प्रस्तुति में `Introduction` सेक्शन उसकी स्लाइडों के साथ और एक खाली `Appendix` सेक्शन सम्मिलित रहता है। `Results` सेक्शन और उसकी स्लाइडें हटा दी गई हैं।

## **सेक्शन का नाम बदलना**

सेक्शन का नाम बदलने के लिए उसके [Section.setName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#setName) मेथड को कॉल करें। सेक्शन की स्लाइडें और स्थिति अपरिवर्तित रहती हैं।

निम्नलिखित उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **सेक्शन से स्लाइड प्राप्त करना**

[Presentation.getSections](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSections) मेथड एक [SectionCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectioncollection/) लौटाता है जिसे आप अनुक्रमांक द्वारा एक्सेस कर सकते हैं। प्रत्येक [Section](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/) के लिए, वर्तमान में उससे संबंधित स्लाइडें प्राप्त करने हेतु [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) को कॉल करें। यह मेथड एक [SectionSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectionslidecollection/) लौटाता है, जो गिनती और अनुक्रमांकित पहुँच प्रदान करता है।

निम्नलिखित उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [name](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getStartedFromSlide), स्लाइड गिनती और स्लाइड नंबर प्रिंट करता है। यह [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) का उपयोग करके पहले स्लाइड और संग्रह की प्रत्येक स्लाइड पढ़ता है। खाली सेक्शन के लिये, लौटाया गया संग्रह शून्य आकार का होता है, अनुक्रमांकित पहुँच छोड़ दी जाती है, और लूप कोई कार्य नहीं करता।

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

सेक्शन सदस्यता प्रस्तुति की सेक्शन संरचना द्वारा निर्धारित होती है। [Section.getStartedFromSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getStartedFromSlide), स्लाइड अनुक्रमांक और अगले सेक्शन की प्रारंभिक स्लाइड से सेक्शन की सीमा को मैन्युअल रूप से गणना न करें।

संरचनात्मक संशोधन किसी सेक्शन के लिए लौटाई गई स्लाइडों और उनकी स्लाइड संख्याओं दोनों को बदल सकते हैं। इसमें स्लाइडों का क्रम बदलना, किसी स्लाइड को सेक्शन में क्लोन करना, सेक्शन को उसकी स्लाइडों के साथ ले जाना, स्लाइडें हटाना और सेक्शन हटाना शामिल है। अगला उदाहरण प्रत्येक ऐसे परिवर्तन के बाद [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) को कॉल करता है, बजाय इसके कि पहले की सीमाओं के बारे में मान्यताएँ बनाए रखें।

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

जब भी स्लाइडें या सेक्शन पुन:क्रमित, क्लोन, ले जाएँ या हटाए जाएँ, तब [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) को पुनः कॉल करें। यह वर्तमान प्रस्तुति संरचना के साथ बाद के प्रसंस्करण को संगत रखता है।

PPT (PowerPoint 97–2003) स्वरूप सेक्शन मेटाडेटा को संरक्षित नहीं करता। इस कार्यप्रवाह का उपयोग ऐसे स्वरूप के साथ करें जो सेक्शन को समर्थन देता हो, जैसे PPTX; PPT में रूपांतरण करने पर बाद के पुनरावृत्ति हेतु आवश्यक सेक्शन संरचना हट जाती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPT (PowerPoint 97–2003) स्वरूप में सहेजते समय सेक्शन संरक्षित रहते हैं?**

नहीं। PPT स्वरूप सेक्शन मेटाडेटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन ग्रुपिंग खो जाती है।

**क्या पूरे सेक्शन को "छिपाया" जा सकता है?**

नहीं। सेक्शन में कोई दृश्यता स्थिति नहीं होती। इसकी सामग्री को छिपाने के लिए सेक्शन की प्रत्येक स्लाइड पर [Slide.setHidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#setHidden) को कॉल करना होगा।

**मैं कैसे पता कर सकूँ कि कौन सा सेक्शन किसी स्लाइड को शामिल करता है?**

[Presentation.getSections](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSections) द्वारा लौटाए गए संग्रह में प्रत्येक सेक्शन तक पहुँचें, प्रत्येक सेक्शन के लिए [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) को कॉल करें, और लौटाई गई स्लाइडों की तुलना लक्षित स्लाइड से करें। गैर‑खाली सेक्शन के लिये, [Section.getStartedFromSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getStartedFromSlide) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिये यह `null` लौटाता है।