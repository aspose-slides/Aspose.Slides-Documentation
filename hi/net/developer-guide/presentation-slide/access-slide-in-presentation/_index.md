---
title: .NET में प्रस्तुति स्लाइड्स तक पहुँचें
linktitle: स्लाइड पहुँचें
type: docs
weight: 20
url: /hi/net/access-slide-in-presentation/
keywords:
- स्लाइड पहुँचें
- स्लाइड सूचकांक
- स्लाइड आईडी
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड नंबर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुँचने और उनका प्रबंधन करने का तरीका सीखें। कोड उदाहरणों के साथ उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड्स तक पहुँचने और उन्हें प्रबंधित करने के तरीकों को समझाता है। यह `Slides` संग्रह से शून्य-आधारित सूचकांक द्वारा स्लाइड्स को प्राप्त करने और `GetSlideById` विधि का उपयोग करके स्लाइड को उसके अनूठे ID से पहुँचाने का तरीका दिखाता है।

आप यह भी सीखेंगे कि `SlideNumber` प्रॉपर्टी सेट करके स्लाइड की स्थिति को कैसे बदला जाए और `FirstSlideNumber` प्रॉपर्टी के साथ प्रस्तुति के प्रारंभिक स्लाइड नंबर को कैसे निर्धारित किया जाए। उदाहरणों में प्रस्तुति लोड करना, स्लाइड संदर्भ प्राप्त करना, स्लाइड क्रम या क्रमांक को अद्यतन करना, और संशोधित प्रस्तुति को सहेजना दिखाया गया है।

## **इंडेक्स द्वारा स्लाइड तक पहुँच**

एक प्रस्तुति में सभी स्लाइड्स को स्लाइड स्थिति के आधार पर क्रमांकित किया जाता है, जो 0 से शुरू होता है। पहली स्लाइड इंडेक्स 0 से पहुंची जा सकती है; दूसरी स्लाइड इंडेक्स 1 से पहुंची जाती है; आदि।

Presentation क्लास, जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है, सभी स्लाइड्स को एक [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) संग्रह ( [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) वस्तुओं का संग्रह) के रूप में उजागर करता है। यह C# कोड आपको दिखाता है कि इंडेक्स के माध्यम से स्लाइड तक कैसे पहुँचा जाए:

```c#
// एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation presentation = new Presentation("AccessSlides.pptx");

// उसकी इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करता है
ISlide slide = presentation.Slides[0];
```

## **ID द्वारा स्लाइड तक पहुँच**

प्रस्तुति में प्रत्येक स्लाइड का एक अनूठा ID जुड़ा होता है। आप उस ID को लक्ष्य बनाने के लिए [GetSlideById](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/getslidebyid) विधि (जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास द्वारा प्रदान की गई है) का उपयोग कर सकते हैं। यह C# कोड आपको दिखाता है कि वैध स्लाइड ID कैसे प्रदान करें और उस स्लाइड तक [GetSlideById](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/getslidebyid) विधि से कैसे पहुँचा जाए:

```c#
// एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation presentation = new Presentation("AccessSlides.pptx");

// एक स्लाइड ID प्राप्त करता है
uint id = presentation.Slides[0].SlideId;

// उसके ID के माध्यम से स्लाइड तक पहुँचता है
IBaseSlide slide = presentation.GetSlideById(id);
```

## **स्लाइड स्थिति बदलें**
Aspose.Slides आपको स्लाइड स्थिति बदलने की अनुमति देता है। उदाहरण के लिए, आप यह निर्दिष्ट कर सकते हैं कि पहली स्लाइड दूसरी स्लाइड बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएँ।
2. उस स्लाइड का संदर्भ प्राप्त करें (जिसकी स्थिति बदलनी है) उसके इंडेक्स के माध्यम से।
3. स्लाइड के लिए नया स्थान [SlideNumber](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/slidenumber/) प्रॉपर्टी के माध्यम से सेट करें। 
4. संशोधित प्रस्तुति को सहेजें।

यह C# कोड एक ऑपरेशन दर्शाता है जिसमें स्थिति 1 की स्लाइड को स्थिति 2 में ले जाया जाता है:

```c#
// एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // वह स्लाइड प्राप्त करता है जिसकी स्थिति बदली जाएगी
    ISlide sld = pres.Slides[0];

    // स्लाइड के लिए नई स्थिति सेट करता है
    sld.SlideNumber = 2;

    // संशोधित प्रस्तुति को सहेजता है
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

पहली स्लाइड दूसरी बन गई; दूसरी स्लाइड पहली बन गई। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स स्वचालित रूप से समायोजित हो जाती हैं।

## **स्लाइड नंबर सेट करें**
[FirstSlideNumber](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/firstslidenumber/) प्रॉपर्टी (जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास द्वारा प्रदान की गई है) का उपयोग करके आप प्रस्तुति में पहली स्लाइड के लिए नया नंबर निर्दिष्ट कर सकते हैं। यह ऑपरेशन अन्य स्लाइड नंबरों को पुनः गणना करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएँ।
2. स्लाइड नंबर प्राप्त करें।
3. स्लाइड नंबर सेट करें।
4. संशोधित प्रस्तुति को सहेजें।

यह C# कोड एक ऑपरेशन दर्शाता है जहाँ पहली स्लाइड नंबर को 10 सेट किया गया है:

```c#
 // एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // स्लाइड नंबर प्राप्त करता है
    int firstSlideNumber = presentation.FirstSlideNumber;

    // स्लाइड नंबर सेट करता है
    presentation.FirstSlideNumber=10;
    
    // संशोधित प्रस्तुति को सहेजता है
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

यदि आप पहली स्लाइड को छोड़ना पसंद करते हैं, तो आप क्रमांकण को दूसरी स्लाइड से शुरू कर सकते हैं (और पहली स्लाइड के लिए क्रमांकण को छिपा सकते हैं) इस प्रकार:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // पहली प्रस्तुति स्लाइड का नंबर सेट करता है
    presentation.FirstSlideNumber = 0;

    // सभी स्लाइड्स के लिए स्लाइड नंबर दिखाता है
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // पहली स्लाइड के लिए स्लाइड नंबर को छिपाता है
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // संशोधित प्रस्तुति को सहेजता है
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता द्वारा देखे जाने वाला स्लाइड नंबर संग्रह के शून्य-आधारित सूचकांक से मेल खाता है?**

स्लाइड पर दिखाया गया नंबर मनचाहे मान (उदाहरणार्थ, 10) से शुरू हो सकता है और यह इंडेक्स से मेल खाने की आवश्यकता नहीं है; यह संबंध प्रस्तुति के [first slide number](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/firstslidenumber/) सेटिंग द्वारा नियंत्रित होता है।

**क्या छुपी हुई स्लाइड्स इंडेक्सिंग को प्रभावित करती हैं?**

हां। एक छुपी हुई स्लाइड संग्रह में बनी रहती है और इंडेक्सिंग में गणना की जाती है; "hidden" केवल प्रदर्शन को दर्शाता है, न कि उसकी स्थिति को संग्रह में।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड का इंडेक्स बदलता है?**

हां। इंडेक्स हमेशा स्लाइड्स के वर्तमान क्रम को दर्शाते हैं और सम्मिलित, हटाने और ले जाने के ऑपरेशनों पर पुनः गणना होते हैं।