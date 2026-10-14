---
title: .NET में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/net/convert-powerpoint-to-png/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से PNG
- प्रस्तुति से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों को उच्च-गुणवत्ता वाली PNG छवियों में शीघ्रता से बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके प्रस्तुति स्लाइड्स को PNG छवियों में परिवर्तित करने के तरीके को समझाता है। आप PPT, PPTX, और ODP जैसे स्वरूपों में प्रस्तुतियों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और इसे एक अलग PNG छवि के रूप में सहेज सकते हैं।

नीचे दिए गए उदाहरण थंबनेल रेंडरिंग, स्केल फैक्टर सेट करने, पिक्सेल में आउटपुट आयाम निर्दिष्ट करने, और ग्रेडिएंट रेंडरिंग शैली चुनने को प्रदर्शित करते हैं।

## **PowerPoint को PNG में बदलें**

एक प्रस्तुति को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास से लोड करें और उसकी स्लाइड्स को [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह के माध्यम से पहुँचें। यह उदाहरण प्रत्येक स्लाइड को बिना पैरामीटर के [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) का उपयोग करके थंबनेल बनाने हेतु रेंडर करता है। फिर यह [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) को [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) के साथ कॉल करता है ताकि प्रत्येक रेंडर की गई स्लाइड को PNG छवि के रूप में सहेजा जा सके।

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
पैरामीटर रहित [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) ओवरलोड 0.2 स्केल पर रेंडर करता है। उदाहरण के लिए, 720 × 540 पॉइंट की स्लाइड 144 × 108 पिक्सेल का थंबनेल बनाती है। आउटपुट आयाम को नियंत्रित करने के लिए, नीचे दर्शाए गए स्केल फैक्टर्स या स्पष्ट छवि आकार के साथ ओवरलोड्स का उपयोग करें।
{{% /alert %}}

## **PowerPoint को कस्टम आयामों के साथ PNG में बदलें**

रेंडर किए गए आयामों को नियंत्रित करने के लिए [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) को क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर पास करें। इस उदाहरण में दोनों फैक्टर 2 हैं, इसलिए 720 × 540 पॉइंट की स्लाइड 1440 × 1080 पिक्सेल की छवि बनाती है। समान स्केल फैक्टर्स स्लाइड के अनुपात को बनाए रखते हैं। प्रत्येक छवि को [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) के साथ PNG फॉर्मेट में सहेजा जाता है।

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **PowerPoint को कस्टम आकार के साथ PNG में बदलें**

आउटपुट आयाम पिक्सेल में निर्दिष्ट करने के लिए, स्केल फैक्टर्स के बजाय [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) को आकार पास करें। यह उदाहरण प्रत्येक स्लाइड को 960 × 720 पिक्सेल पर रेंडर करता है और परिणाम को [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) से सहेजता है। छवि को खिंचाव से बचाने के लिए स्लाइड के अनुपात के अनुरूप आयाम चुनें।

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **ग्रेडिएंट रेंडरिंग शैली चुनें**

मान लीजिए किसी स्लाइड में ग्रेडिएंट भराव हैं, लेकिन निर्यातित PNG में ट्रांज़िशन PowerPoint में दिखने वाले की तुलना में हल्के या अलग लगते हैं। आप ग्रेडिएंट की रेंडरिंग को चुनने के लिए [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) की [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) प्रॉपर्टी का उपयोग कर सकते हैं।

[gradient-styles.pptx](gradient-styles.pptx) को डाउनलोड करें और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में दो रैखिक ग्रेडिएंट हैं: ऊपर सियान से नारंगी और नीचे नीले से पीले तक। प्रत्येक ग्रेडिएंट के दो स्टॉप हैं, 0% और 100% पर।

निम्न उदाहरण इस प्रस्तुति को लोड करता है और [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) के साथ दोनों मोड में पहली स्लाइड को रेंडर करता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

| डिफ़ॉल्ट | PowerPointUI |
| --- | --- |
| ![डिफ़ॉल्ट के साथ रेंडर किए गए सियान-से-ऑरेंज और ब्लू-से-येलो ग्रेडिएंट](gradient-Default.png) | ![PowerPointUI के साथ रेंडर किए गए समान ग्रेडिएंट](gradient-PowerPointUI.png) |

इस उदाहरण में, `Default` हल्के मध्यवर्ती रंग बनाता है, जबकि `PowerPointUI` गहरे मध्यवर्ती रंग बनाता है। अंतर ग्रेडिएंट में रंगों और स्टॉप्स पर निर्भर करता है।

`Default` चुनें जब मानक Aspose.Slides आउटपुट आपकी आवश्यकता को पूरा करता हो। `PowerPointUI` आज़माएँ जब आपका प्राथमिक लक्ष्य PowerPoint में दिखावट से मेल खाने का हो। दोनों आउटपुट की तुलना अपने इच्छित परिणाम से करें; कोई भी मोड सार्वभौमिक रूप से श्रेष्ठ नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरे स्लाइड के बजाय किसी विशिष्ट आकार, जैसे चार्ट या चित्र, को कैसे निर्यात करूँ?**

Aspose.Slides [व्यक्तिगत आकारों के लिए थंबनेल बनाने](/slides/hi/net/create-shape-thumbnails/) का समर्थन करता है, जिससे आप किसी आकार को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ। प्रत्येक थ्रेड या प्रक्रिया के लिए एक अलग प्रस्तुति इंस्टेंस उपयोग करें; [थ्रेड्स के बीच एक ही इंस्टेंस साझा न करें](/slides/hi/net/multithreading/)।

**PNG निर्यात करते समय मूल्यांकन सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/net/licensing/) लागू करता है।