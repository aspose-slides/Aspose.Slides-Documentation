---
title: .NET में प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 100
url: /hi/net/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- सेक्शन स्लाइड प्राप्त करें
- सेक्शन स्लाइड प्रोसेस करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ स्लाइड सेक्शन प्रबंधित करें: PPTX प्रस्तुतियों में सेक्शन स्लाइड बनाएं, नाम बदलें, पुनः क्रमित करें, प्राप्त करें और प्रोसेस करें।"
---
## **परिचय**

सेक्शन लगातार स्लाइडों को नामित समूहों में व्यवस्थित करते हैं बिना स्लाइड सामग्री बदले। Aspose.Slides for .NET के साथ, आप [Presentation.Sections](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sections/) प्रॉपर्टी के माध्यम से सेक्शन बनाना, पुनः क्रमित करना, नाम बदलना, निरीक्षण करना और हटाना कर सकते हैं।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- एक बड़ी प्रस्तुति को तर्कसंगत विषयों या अध्यायों में विभाजित करना आवश्यक हो;
- विभिन्न स्लाइड समूह विभिन्न सहयोगियों को सौंपे गए हों;
- स्लाइडों को समूहों के रूप में प्रोसेस, स्थानांतरित या मर्ज करने की आवश्यकता हो।

समूहित स्लाइडों के उद्देश्य को दर्शाने वाले संक्षिप्त सेक्शन नाम चुनें। चूंकि सेक्शन प्रस्तुति संरचना का हिस्सा होते हैं, सदस्यता निर्धारित करने के लिये सेक्शन API का उपयोग करें, न कि स्लाइड स्थितियों से निष्कर्ष निकालें।

## **सेक्शन बनाना और प्रबंधित करना**

[ISectionCollection.AddSection](https://reference.aspose.com/slides/hi/net/aspose.slides/sectioncollection/addsection/) का उपयोग करके उसका नाम और प्रारंभिक स्लाइड निर्दिष्ट करके एक सेक्शन बनाएं। Aspose.Slides प्रस्तुति की वर्तमान सेक्शन संरचना से निर्धारित करता है कि कौन सी स्लाइडें सेक्शन से संबंधित हैं।

समान [ISectionCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isectioncollection/) आपको भी सक्षम करता है:

- [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/sectioncollection/reordersectionwithslides/) का उपयोग करके एक सेक्शन को उसकी स्लाइडों के साथ स्थानांतरित करें;
- [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/hi/net/aspose.slides/sectioncollection/removesection/) के साथ केवल सेक्शन परिभाषा हटाएँ, जो उसकी स्लाइडों को बनाए रखता है;
- [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/sectioncollection/removesectionwithslides/) के साथ एक सेक्शन और उसकी स्लाइडें हटाएँ;
- [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/hi/net/aspose.slides/sectioncollection/appendemptysection/) के साथ अंत में एक खाली सेक्शन जोड़ें।

निम्न उदाहरण दो सेक्शन बनाता है, उनमें से एक को स्थानांतरित करता है, उसे उसकी स्लाइडों के साथ हटाता है, और एक खाली सेक्शन जोड़ता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

इन संचालन के बाद, प्रस्तुति में `Introduction` सेक्शन उसकी स्लाइडों के साथ और एक खाली `Appendix` सेक्शन सम्मिलित रहता है। `Results` सेक्शन और उसकी स्लाइडें हटा दी गई हैं।

## **सेक्शन का नाम बदलना**

सेक्शन का नाम बदलने के लिये, उसके [ISection.Name](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/name/) प्रॉपर्टी को सेट करें। सेक्शन की स्लाइडें और स्थिति अपरिवर्तित रहती हैं।

निम्न उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **सेक्शन से स्लाइड प्राप्त करना**

[Presentation.Sections](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sections/) प्रॉपर्टी एक [ISectionCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isectioncollection/) लौटाती है जिसे आप क्रमबद्ध कर सकते हैं। प्रत्येक [ISection](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/) के लिये, वर्तमान में उससे संबंधित स्लाइडें प्राप्त करने हेतु [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/getslideslistofsection/) को कॉल करें। यह मेथड एक [ISectionSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isectionslidecollection/) लौटाता है, जो गिनती, अनुक्रमित पहुँच और क्रमबद्धरण प्रदान करता है।

निम्न उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [name](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/sectionid/), [starting slide](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/startedfromslide/), स्लाइड गिनती, और स्लाइड नंबर प्रिंट करता है। यह संग्रह इंडेक्सर का उपयोग करके पहली स्लाइड पढ़ता है और `foreach` से प्रत्येक स्लाइड को प्रोसेस करता है। खाली सेक्शन के लिये, लौटाया गया संग्रह शून्य गिनती रखता है, इंडेक्सर तक पहुँच नहीं की जाती, और क्रमबद्धरण कोई पुनरावृत्ति नहीं करता।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

सेक्शन सदस्यता प्रस्तुति की सेक्शन संरचना द्वारा निर्धारित होती है। ISection.StartedFromSlide, स्लाइड सूचकांकों, और अगले सेक्शन की प्रारंभिक स्लाइड से मैन्युअल रूप से सेक्शन की सीमा गणना न करें।

संरचनात्मक संपादन एक सेक्शन के लिये लौटाई गई स्लाइडें और उनके स्लाइड नंबर दोनों को बदल सकते हैं। इसमें स्लाइडों का पुनः क्रमित करना, किसी स्लाइड को सेक्शन में क्लोन करना, सेक्शन को उसकी स्लाइडों के साथ स्थानांतरित करना, स्लाइडें हटाना, और सेक्शन हटाना शामिल है। अगला उदाहरण प्रत्येक ऐसे परिवर्तन के बाद [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/getslideslistofsection/) को कॉल करता है, बजाय सेक्शन की पूर्व सीमाओं के बारे में धारणाएँ बनाए रखने के।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

जब भी स्लाइडें या सेक्शन पुनः क्रमित, क्लोन, स्थानांतरित या हटाए जाएँ, तब [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/getslideslistofsection/) को फिर से कॉल करें। यह बाद की प्रोसेसिंग को वर्तमान प्रस्तुति संरचना के अनुरूप रखता है।

PPT (PowerPoint 97–2003) फ़ॉर्मेट सेक्शन मेटाडेटा को बनाए नहीं रखता। इस कार्यप्रवाह का उपयोग ऐसे फ़ॉर्मेट के साथ करें जो सेक्शन का समर्थन करता हो, जैसे PPTX; PPT में बदलने से बाद में क्रमबद्ध करने के लिये आवश्यक सेक्शन संरचना हट जाती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन समूह खो जाता है।

**क्या पूर्ण सेक्शन को "छुपाया" जा सकता है?**

नहीं। एक सेक्शन की कोई दृश्यता स्थिति नहीं होती। उसके सामग्री को छुपाने के लिये, सेक्शन की प्रत्येक स्लाइड के लिये [ISlide.Hidden](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/hidden/) प्रॉपर्टी सेट करें।

**मैं किसी स्लाइड को शामिल करने वाले सेक्शन को कैसे खोजूँ?**

[Presentation.Sections](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sections/) को क्रमबद्ध करें, प्रत्येक सेक्शन के लिये [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/getslideslistofsection/) को कॉल करें, और लौटाए गये स्लाइडों की लक्ष्य स्लाइड से तुलना करें। गैर-खाली सेक्शन के लिये, [ISection.StartedFromSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/startedfromslide/) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिये, यह `null` लौटाता है।