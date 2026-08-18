---
title: ".NET में प्रस्तुति स्लाइड्स को क्लोन करें"
linktitle: "स्लाइड क्लोन करें"
type: docs
weight: 40
url: /hi/net/clone-slides/
keywords:
- "स्लाइड क्लोन"
- "स्लाइड कॉपी"
- "स्लाइड सहेजें"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides के साथ PowerPoint स्लाइड्स को तेज़ी से डुप्लिकेट करें। सेकंडों में PPT निर्माण को स्वचालित करने और मैन्युअल कार्य को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरणों का पालन करें।"
---
## **परिचय**

Cloning वह प्रक्रिया है जिसमें किसी चीज़ की सटीक कॉपी या प्रतिलिपि बनायी़ जाती है। Aspose.Slides आपको किसी भी स्लाइड को कॉपी (क्लोन) करने और फिर क्लोन की गई स्लाइड को वर्तमान प्रस्तुति या किसी अन्य खुली प्रस्तुति में सम्मिलित करने की अनुमति देता है। स्लाइड क्लोनिंग एक नई स्लाइड बनाता है जिसे डेवलपर्स मूल स्लाइड को प्रभावित किए बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई तरीके हैं:

- प्रस्तुति के अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थान पर क्लोन करें।
- दूसरी प्रस्तुति के अंत में क्लोन करें।
- दूसरी प्रस्तुति में किसी अन्य स्थान पर क्लोन करें।
- उसकी मास्टर स्लाइड के साथ मिलाकर दूसरी प्रस्तुति में क्लोन करें।

Aspose.Slides for .NET में, स्लाइड संग्रह (जो [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) ऑब्जेक्ट्स का संग्रह है) जिसे [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट द्वारा उजागर किया गया है, [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/insertclone/) मेथड्स प्रदान करता है जिससे ऊपर वर्णित स्लाइड क्लोनिंग कार्य किए जा सकते हैं।

## **प्रस्तुति के अंत में स्लाइड को क्लोन करें**

यदि आप एक स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास का एक उदाहरण बनाएं।
3. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदान किया गया [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड कॉल करें और क्लोन की जाने वाली स्लाइड को [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड के पैरामीटर के रूप में पास करें।
4. संशोधित प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने एक स्लाइड (जो प्रस्तुति के पहले स्थान – शून्य इंडेक्स – पर स्थित थी) को प्रस्तुति के अंत में क्लोन किया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टैंस बनाएं
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // वांछित स्लाइड को उसी प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **प्रस्तुति के भीतर किसी अन्य स्थान पर स्लाइड को क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में लेकिन अलग स्थान पर उपयोग करना चाहते हैं, तो [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह को संदर्भित करके क्लास का एक उदाहरण बनाएं।
3. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदान किया गया [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड कॉल करें और क्लोन की जाने वाली स्लाइड को नई स्थिति के लिए इंडेक्स के साथ [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड के पैरामीटर के रूप में पास करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने एक स्लाइड (जो प्रस्तुति के इंडेक्स 1 – स्थिति 2 – पर थी) को इंडेक्स 2 – स्थिति 3 – पर क्लोन किया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टैंस बनाएं
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // वांछित स्लाइड को उसी प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.Slides;

    // वांछित स्लाइड को उसी प्रस्तुति में निर्दिष्ट इंडेक्स पर क्लोन करें
    slds.InsertClone(2, pres.Slides[1]);

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **दूसरी प्रस्तुति के अंत में स्लाइड को क्लोन करें**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके दूसरी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में जोड़ना है:

1. स्लाइड जहाँ से क्लोन की जाएगी, उस प्रस्तुति को सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य प्रस्तुति जिसमें स्लाइड जोड़ी जाएगी, उसे सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
3. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास का एक उदाहरण बनाएं।
4. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदान किया गया [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड कॉल करें और स्रोत प्रस्तुति से स्लाइड को [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड के पैरामीटर के रूप में पास करें।
5. संशोधित लक्ष्य प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के पहले इंडेक्स से एक स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन किया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टैंस बनाएं
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // गंतव्य PPTX (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास का इंस्टैंस बनाएं
    using (Presentation destPres = new Presentation())
    {
        // स्रोत प्रस्तुति से वांछित स्लाइड को गंतव्य प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **दूसरी प्रस्तुति में किसी अन्य स्थान पर स्लाइड को क्लोन करें**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके दूसरी प्रस्तुति फ़ाइल में विशिष्ट स्थान पर उपयोग करना है:

1. स्रोत प्रस्तुति जिसमें स्लाइड क्लोन की जाएगी, उसे सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य प्रस्तुति जिसमें स्लाइड जोड़ी जाएगी, उसे सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
3. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास का एक उदाहरण बनाएं।
4. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदान किया गया [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड कॉल करें और स्रोत प्रस्तुति से स्लाइड को इच्छित स्थिति के साथ [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/insertclone/methods/1) मेथड के पैरामीटर के रूप में पास करें।
5. संशोधित लक्ष्य प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स से एक स्लाइड को लक्ष्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टैंस बनाएं
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // गंतव्य PPTX (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास का इंस्टैंस बनाएं
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **मास्टर स्लाइड के साथ स्लाइड को दूसरी प्रस्तुति में क्लोन करें**
यदि आपको एक प्रस्तुति से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके दूसरी प्रस्तुति में उपयोग करना है, तो पहले स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति में क्लोन करना आवश्यक है। इसके बाद उस मास्टर स्लाइड का उपयोग करके स्लाइड को मास्टर के साथ क्लोन करना होगा। **AddClone(ISlide, IMasterSlide)** लक्ष्य प्रस्तुति से मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत प्रस्तुति से। मास्टर के साथ स्लाइड को क्लोन करने के लिए नीचे दिए गए कदमों का पालन करें:

1. स्रोत प्रस्तुति जिसमें स्लाइड क्लोन की जाएगी, उसे सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य प्रस्तुति जिसमें स्लाइड क्लोन की जाएगी, उसे सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
3. क्लोन की जाने वाली स्लाइड तथा उसकी मास्टर स्लाइड तक पहुँचें।
4. लक्ष्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर किए गए Masters संग्रह को संदर्भित करके [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection) क्लास का एक उदाहरण बनाएं।
5. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection) ऑब्जेक्ट द्वारा प्रदान किया गया [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड कॉल करें और स्रोत PPTX से क्लोन की जाने वाली मास्टर स्लाइड को [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड के पैरामीटर के रूप में पास करें।
6. लक्ष्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) क्लास का एक उदाहरण बनाएं।
7. [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) ऑब्जेक्ट द्वारा प्रदान किया गया [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड कॉल करें और स्रोत प्रस्तुति से क्लोन की जाने वाली स्लाइड तथा मास्टर स्लाइड को [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड के पैरामीटर के रूप में पास करें।
8. संशोधित लक्ष्य प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स पर स्थित एक मास्टर के साथ स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन किया है, जिसमें स्रोत स्लाइड से मास्टर का उपयोग किया गया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टैंस बनाएं

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // गंतव्य प्रस्तुति (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास का इंस्टैंस बनाएं
    using (Presentation destPres = new Presentation())
    {

        // स्रोत प्रस्तुति में स्लाइड संग्रह से ISlide को साथ में बनाएं
        // मास्टर स्लाइड
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में
        // गंतव्य प्रस्तुति
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में
        // गंतव्य प्रस्तुति
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // स्रोत प्रस्तुति से वांछित मास्टर के साथ वांछित स्लाइड को अंत में क्लोन करें
        // गंतव्य प्रस्तुति में स्लाइड संग्रह
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में // गंतव्य प्रस्तुति
        // गंतव्य प्रस्तुति को डिस्क पर सहेजें
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड को क्लोन करें**

Aspose.Slides for .NET के साथ, आप प्रस्तुति के एक सेक्शन से स्लाइड को क्लोन करके उसी प्रस्तुति के दूसरे सेक्शन में सम्मिलित कर सकते हैं। इस मामले में, आपको [ISlideCollection] इंटरफ़ेस के [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/methods/addclone/index) मेथड का उपयोग करना होगा।

यह C# कोड दिखाता है कि कैसे स्लाइड को क्लोन करके निर्दिष्ट सेक्शन में सम्मिलित किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **स्लाइड आकार का मिलान सुनिश्चित करें**

जब स्लाइडों को दूसरी प्रस्तुति में क्लोन किया जाता है, तो सुनिश्चित करें कि लक्ष्य प्रस्तुति का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार अलग हैं, तो Aspose.Slides क्लोन किए गए शैप्स का आकार स्वतः नहीं बदलता—उनके मूल निर्देशांक और आयाम संरक्षित रहते हैं, जिससे सामग्री गलत संरेखित या स्लाइड की सीमाओं से बाहर हो सकती है।

आप मास्टर और स्लाइड को क्लोन करने से पहले लक्ष्य प्रस्तुति का स्लाइड आकार स्रोत से मिलान करने के लिए सेट कर सकते हैं:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

क्लोन करने से पहले यह चरण करें।

## **FAQ**

**क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन होते हैं?**

हां। नोट्स पेज और रिव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते हैं, तो सम्मिलन के बाद उन्हें [remove them](/slides/hi/net/presentation-notes/) करें।

**चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?**

चार्ट ऑब्जेक्ट, फ़ॉर्मैटिंग और एम्बेडेड डेटा कॉपी किए जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे, OLE-एम्बेडेड वर्कबुक) से लिंक किया गया था, तो वह लिंक एक [OLE object](/slides/hi/net/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रिफ्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन के सम्मिलन स्थान और सेक्शन को नियंत्रित कर सकता हूँ?**

हां। आप क्लोन को किसी विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुने हुए [section](/slides/hi/net/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।