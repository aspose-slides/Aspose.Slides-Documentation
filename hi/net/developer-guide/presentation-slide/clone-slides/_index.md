---
title: ".NET में प्रस्तुति स्लाइड्स को क्लोन करें"
linktitle: "स्लाइड्स को क्लोन करें"
type: docs
weight: 40
url: /hi/net/clone-slides/
keywords:
- "स्लाइड क्लोन"
- "स्लाइड कॉपी"
- "स्लाइड सहेजें"
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स को तुरंत डुप्लिकेट करें। हमारे स्पष्ट कोड उदाहरणों का पालन करके सेकंडों में PPT बनाना स्वचालित करें और मैनुअल कार्य को समाप्त करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जो किसी वस्तु की बिल्कुल समान प्रति या नकल बनाने के लिए उपयोग की जाती है। Aspose.Slides आपको किसी भी स्लाइड को कॉपी (क्लोन) करने और फिर क्लोन की गई स्लाइड को वर्तमान प्रस्तुति या किसी अन्य खुले प्रस्तुति में सम्मिलित करने की अनुमति देता है। स्लाइड क्लोनिंग एक नई स्लाइड बनाती है जिसे डेवलपर मूल स्लाइड को प्रभावित किए बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई तरीके हैं:

- प्रस्तुति के अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थान पर क्लोन करें।
- किसी अन्य प्रस्तुति के अंत में क्लोन करें।
- किसी अन्य प्रस्तुति में किसी अन्य स्थान पर क्लोन करें।
- किसी अन्य प्रस्तुति में विशिष्ट स्थान पर क्लोन करें।

Aspose.Slides for .NET में, स्लाइड संग्रह (एक [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) ऑब्जेक्ट्स का संग्रह) जिसे [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट प्रदर्शित करता है, ऊपर वर्णित स्लाइड क्लोनिंग संचालन को करने के लिये [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/insertclone/) मेथड्स प्रदान करता है।

## **प्रस्तुति के अंत में स्लाइड को क्लोन करना**

यदि आप किसी स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड का प्रयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
2. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास को इंस्टैंसिएट करें।  
3. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदान किए गए [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को पैरामीटर के रूप में पास करें।  
4. संशोधित प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्थिति (जिरो इंडेक्स) पर स्थित एक स्लाइड को प्रस्तुति के अंत में क्लोन किया है।

```c#
// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **एक ही प्रस्तुति में किसी अन्य स्थिति पर स्लाइड को क्लोन करना**
यदि आप स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में लेकिन अलग स्थिति पर उपयोग करना चाहते हैं, तो [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
2. **Slides** संग्रह को संदर्भित करके [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट द्वारा प्रदर्शित क्लास को इंस्टैंसिएट करें।  
3. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदर्शित [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड के साथ साथ नए स्थान के इंडेक्स को पैरामीटर के रूप में पास करें।  
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की जिरो इंडेक्स (स्थिति 1) पर स्थित एक स्लाइड को इंडेक्स 1 — स्थिति 2 — पर क्लोन किया है।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएँ
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.Slides;

    // इच्छित स्लाइड को उसी प्रस्तुति में निर्दिष्ट इंडेक्स पर क्लोन करें
    slds.InsertClone(2, pres.Slides[1]);

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **दूसरी प्रस्तुति के अंत में स्लाइड को क्लोन करना**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके दूसरे प्रस्तुति फ़ाइल में, मौजूदा स्लाइडों के अंत में उपयोग करना है:

1. उस प्रस्तुति को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं जिससे स्लाइड क्लोन की जाएगी।  
2. लक्ष्य प्रस्तुति को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
3. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित **Slides** संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास को इंस्टैंसिएट करें।  
4. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को पैरामीटर के रूप में पास करें।  
5. संशोधित लक्ष्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के पहले इंडेक्स से एक स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन किया है।

```c#
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // लक्ष्य PPTX (जहाँ स्लाइड क्लोन की जानी है) के लिए Presentation क्लास को इंस्टैंसिएट करें
    using (Presentation destPres = new Presentation())
    {
        // स्रोत प्रस्तुति से इच्छित स्लाइड को लक्ष्य प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // लक्ष्य प्रस्तुति को डिस्क पर लिखें
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **दूसरी प्रस्तुति में किसी अन्य स्थिति पर स्लाइड को क्लोन करना**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके दूसरे प्रस्तुति में, विशिष्ट स्थिति पर उपयोग करना है:

1. स्रोत प्रस्तुति को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
2. लक्ष्य प्रस्तुति को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
3. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास को इंस्टैंसिएट करें।  
4. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदर्शित [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड तथा वांछित स्थिति को पैरामीटर के रूप में पास करें।  
5. संशोधित लक्ष्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के जिरो इंडेक्स से एक स्लाइड को लक्ष्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```c#
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // गंतव्य PPTX (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इंस्टैंसिएट करें
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **दूसरी प्रस्तुति में विशिष्ट स्थान पर स्लाइड को क्लोन करना**
यदि आपको एक प्रस्तुति से मास्टर स्लाइड सहित स्लाइड को क्लोन करके दूसरे प्रस्तुति में उपयोग करना है, तो पहले स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति में क्लोन करना होगा। फिर उस मास्टर स्लाइड का उपयोग करके स्लाइड को क्लोन किया जाएगा। **AddClone(ISlide, IMasterSlide)** मेथड लक्ष्य प्रस्तुति से मास्टर स्लाइड की अपेक्षा करता है, स्रोत प्रस्तुति से नहीं। मास्टर के साथ स्लाइड को क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. स्रोत प्रस्तुति को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
2. लक्ष्य प्रस्तुति को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
3. क्लोन की जाने वाली स्लाइड तथा उसके मास्टर स्लाइड तक पहुँचें।  
4. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Masters संग्रह को संदर्भित करके [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection) क्लास को इंस्टैंसिएट करें।  
5. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection) ऑब्जेक्ट द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड को कॉल करें और स्रोत PPTX से मास्टर स्लाइड को पैरामीटर के रूप में पास करें।  
6. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास को इंस्टैंसिएट करें।  
7. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड और मास्टर स्लाइड को पैरामीटर के रूप में पास करें।  
8. संशोधित लक्ष्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के जिरो इंडेक्स पर स्थित एक स्लाइड (मास्टर सहित) को लक्ष्य प्रस्तुति के अंत में, स्रोत स्लाइड के मास्टर का उपयोग करके क्लोन किया है।

```c#
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // लक्ष्य प्रस्तुति (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इंस्टैंसिएट करें
    using (Presentation destPres = new Presentation())
    {

        // स्रोत प्रस्तुति के स्लाइड संग्रह से ISlide को मास्टर स्लाइड के साथ इंस्टैंसिएट करें
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति के मास्टर संग्रह में क्लोन करें
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति के मास्टर संग्रह में क्लोन करें
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // इच्छित मास्टर के साथ स्रोत प्रस्तुति से स्लाइड को लक्ष्य प्रस्तुति के स्लाइड संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // इच्छित मास्टर स्लाइड को स्रोत प्रस्तुति से लक्ष्य प्रस्तुति के मास्टर संग्रह में क्लोन करें
        // लक्ष्य प्रस्तुति को डिस्क पर सहेजें
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड को क्लोन करना**

Aspose.Slides for .NET के साथ, आप एक प्रस्तुति के किसी सेक्शन से स्लाइड क्लोन करके उसी प्रस्तुति के दूसरे सेक्शन में सम्मिलित कर सकते हैं। इस मामले में आपको [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) इंटरफ़ेस से [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड का उपयोग करना होगा।

यह C# कोड दिखाता है कि कैसे स्लाइड को क्लोन करके क्लोन की गई स्लाइड को निर्दिष्ट सेक्शन में सम्मिलित किया जा सकता है:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // क्लोन करने के लिए
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूअर टिप्पणी भी क्लोन हो जाती हैं?**  
हां। नोट्स पेज और रिव्यू टिप्पणी क्लोन में शामिल हैं। यदि आप इन्हें नहीं चाहते तो सम्मिलन के बाद उन्हें [उन्हें हटाएँ](/slides/hi/net/presentation-notes/)।

**चार्ट और उनके डेटा स्रोत कैसे संभाले जाते हैं?**  
चार्ट ऑब्जेक्ट, फॉर्मेटिंग और एम्बेडेड डेटा कॉपी हो जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE object](/slides/hi/net/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रीफ़्रेश व्यवहार को सत्यापित करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन को नियंत्रित कर सकता हूँ?**  
हां। आप क्लोन को किसी विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और इसे चुनी हुई [section](/slides/hi/net/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएं।