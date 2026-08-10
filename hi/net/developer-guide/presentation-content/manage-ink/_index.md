---
title: .NET में प्रेजेंटेशन इंक ऑब्जेक्ट्स को प्रबंधित करें
linktitle: इंक प्रबंधित करें
type: docs
weight: 95
url: /hi/net/manage-ink/
keywords:
- इंक
- इंक वस्तु
- इंक ट्रेस
- इंक का प्रबंधन
- इंक ड्रॉ
- ड्राइंग
- इंक निर्यात
- इंक रेंडरिंग
- इंक छुपाएँ
- IInkOptions
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint इंक ऑब्जेक्ट्स का प्रबंधन करें, ट्रेसेस और ब्रश प्रॉपर्टीज़ को संपादित करें, और PDF, HTML, SVG, TIFF और इमेज एक्सपोर्ट के दौरान इंक की उपस्थिति को नियंत्रित करें।"
---
## **परिचय**

PowerPoint एक इंक फीचर प्रदान करता है जो आपको फ्री‑फ़ॉर्म स्ट्रोक ड्रॉ करने की अनुमति देता है। इंक का उपयोग अन्य वस्तुओं को उजागर करने, कनेक्शन और प्रक्रियाओं को दिखाने, और स्लाइड पर विशिष्ट आइटम्स पर ध्यान आकर्षित करने के लिए किया जा सकता है।

[Aspose.Slides.Ink](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/) नामस्थान में इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक क्लासेज़ और इंटरफ़ेस शामिल हैं। उदाहरण के लिए, [IInk](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iink/) इंटरफ़ेस स्लाइड पर एक इंक ऑब्जेक्ट का प्रतिनिधित्व करता है।

## **सामान्य वस्तुओं और इंक वस्तुओं के बीच अंतर**

PowerPoint स्लाइड पर मौजूद वस्तुएँ सामान्यतः शैप ऑब्जेक्ट्स द्वारा प्रदर्शित की जाती हैं। सबसे सरल रूप में, शैप एक कंटेनर होता है जो वस्तु के क्षेत्र (उसका फ्रेम) को परिभाषित करता है तथा कंटेनर के आकार, आकार, और बैकग्राउंड जैसी प्रॉपर्टीज़ को रखता है। अधिक जानकारी के लिए देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/net/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट को संभालता है, तो वह कंटेनर (फ़्रेम) की सभी प्रॉपर्टीज़ को छोड़ देता है सिवाय उसके आकार के। कंटेनर के क्षेत्र का आकार मानक [IShape.Width](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/width/) और [IShape.Height](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/height/) प्रॉपर्टीज़ द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेस**

इंक ट्रेस एक बुनियादी तत्व है जो उपयोगकर्ता द्वारा डिजिटल इंक लिखते समय पेन की गति को रिकॉर्ड करता है। एक ट्रेस जुड़े हुए पॉइंट्स की श्रृंखला को संग्रहीत करता है।

एन्कोडिंग का सबसे सरल रूप प्रत्येक सैंपल पॉइंट के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी जुड़े हुए पॉइंट्स रेंडर किए जाते हैं, तो वे इस प्रकार की छवि बनाते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश प्रॉपर्टीज़**

ब्रश का उपयोग इंक ट्रेस के पॉइंट्स को जोड़ने वाली लाइनों को ड्रॉ करने के लिए किया जाता है। ब्रश का अपना रंग और आकार होता है, जिसे [IInkBrush.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iinkbrush/color/) और [IInkBrush.Size](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iinkbrush/size/) प्रॉपर्टीज़ द्वारा दर्शाया जाता है।

### **इंक ब्रश का रंग सेट करें**

यह C# कोड इंक ब्रश का रंग सेट करने का तरीका दर्शाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **इंक ब्रश का आकार सेट करें**

यह C# कोड इंक ब्रश का आकार सेट करने का तरीका दर्शाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश का आकार नहीं दिखाता (संबंधित डेटा सेक्शन ग्रे हो जाता है)। जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint अपना आकार इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिए, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को ध्यान में नहीं रखता—यह हमेशा मानता है कि रेखा की मोटाई शून्य है (पिछली छवि देखें)।

इसलिए पूरे इंक ऑब्जेक्ट के दृश्य क्षेत्र को निर्धारित करने के लिए, उसके ट्रेसेस के ब्रश आकार को ध्यान में रखना आवश्यक है। यहाँ लक्ष्य ऑब्जेक्ट (हस्तलेख टेक्स्ट ट्रेस) को कंटेनर (फ़्रेम) के आकार में स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है, और उल्टा भी।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint इस व्यवहार को टेक्स्ट ऑब्जेक्ट्स पर भी लागू करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **एक्सपोर्ट और रेंडरिंग के दौरान इंक की उपस्थिति नियंत्रित करें**

Aspose.Slides [IInkOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/) इंटरफ़ेस प्रदान करता है जिससे आप एक्सपोर्ट या रेंडर किए गए आउटपुट में इंक ऑब्जेक्ट्स की उपस्थिति को नियंत्रित कर सकते हैं। आप इसकी प्रॉपर्टीज़ का उपयोग करके इंक को पूरी तरह छुपा सकते हैं या इंक ब्रश मास्क ऑपरेशन्स की व्याख्या बदल सकते हैं।

इंक विकल्प कई आउटपुट प्रकारों के एक्सपोर्ट या रेंडरिंग विकल्पों के माध्यम से उपलब्ध हैं:

| आउटपुट | इंक विकल्प प्रॉपर्टी |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/inkoptions/) |
| स्लाइड इमेज | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/inkoptions/) |

इन प्रॉपर्टीज़ के माध्यम से दो समान सेटिंग्स उपलब्ध हैं:

- [`HideInk`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/hideink/) निर्धारित करता है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल हों या नहीं। इसका डिफ़ॉल्ट मान `false` है।
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) निर्धारित करता है कि रेंडरिंग के दौरान इंक ब्रश के लिए मास्क ऑपरेशन को अपैसिटी के रूप में व्याख्या किया जाए या नहीं। इसका डिफ़ॉल्ट मान `true` है; `false` सेट करने पर ROP ऑपरेशन उपयोग किया जाएगा।

### **PDF आउटपुट में इंक वस्तुओं को छुपाएँ**

डिफ़ॉल्ट रूप से, एक्सपोर्ट के दौरान इंक ऑब्जेक्ट्स दिखाई देते रहते हैं। जब आपको हस्तलेख टिप्पणी या अन्य इंक सामग्री के बिना साफ़ आउटपुट चाहिए, तो [IInkOptions.HideInk](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/hideink/) को `true` सेट करें।

निम्न C# उदाहरण सभी इंक वस्तुओं को छुपाते हुए प्रस्तुति को PDF में एक्सपोर्ट करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **स्लाइड को इमेज के रूप में रेंडर करते समय इंक वस्तुओं को छुपाएँ**

स्लाइड को बिटमैप इमेज के रूप में रेंडर करते समय इंक वस्तुओं को छुपाने के लिए [RenderingOptions.InkOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/inkoptions/) को कॉन्फ़िगर करें और रेंडरिंग विकल्पों को [ISlide.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) मेथड में पास करें।

निम्न C# उदाहरण पहली स्लाइड को PNG इमेज के रूप में इंक वस्तुओं के बिना रेंडर करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **इंक मास्क रेंडरिंग नियंत्रित करें**

[IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) प्रॉपर्टी यह नियंत्रित करती है कि इंक ब्रश रेंडरिंग के समय मास्क ऑपरेशन को अपैसिटी के रूप में व्याख्या किया जाए या नहीं। डिफ़ॉल्ट मान `true` है, जो अपैसिटी उपयोग करता है। इस प्रॉपर्टी को `false` सेट करने पर ROP ऑपरेशन उपयोग होगा।

निम्न C# उदाहरण एक स्लाइड को SVG में एक्सपोर्ट करता है और इंक मास्क ऑपरेशन्स के लिए ROP‑आधारित रेंडरिंग का उपयोग करता है:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

उसी सेटिंग को [TiffOptions.InkOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/inkoptions/) के माध्यम से भी उपयोग किया जा सकता है जब प्रस्तुति को एक्सपोर्ट या स्लाइड को TIFF में रेंडर किया जाता है।

### **इंक को छुपाने या बनाए रखने का चयन करें**

जब एक्सपोर्ट की गई फ़ाइल में एनोटेटेड प्रस्तुति का साफ़ संस्करण चाहिए (जैसे वितरण के लिए अंतिम कॉपी), तो [IInkOptions.HideInk](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/hideink/) को `true` सेट करें।

यदि इंक एनोटेशन वांछित सामग्री का हिस्सा हैं—जैसे रिव्यू कमेंट्स, हस्तलेख नोट्स, हाइलाइट्स या ड्राइंग्स—तो [IInkOptions.HideInk](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/hideink/) को डिफ़ॉल्ट `false` पर रखें। यह अनुप्रयोगों को एक ही प्रस्तुति से अलग रिव्यू और अंतिम आउटपुट बनाने की सुविधा देता है, बिना स्रोत इंक ऑब्जेक्ट्स को बदलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक का रंग या आकार बदल सकता हूँ?**

हाँ। पहले [IInk.Traces](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iink/traces/) से ट्रेस प्राप्त करें, फिर उसके [IInkTrace.Brush](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iinktrace/brush/) को बदलें। आप ब्रश की [IInkBrush.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iinkbrush/color/) और [IInkBrush.Size](https://reference.aspose.com/slides/hi/net/aspose.slides.ink/iinkbrush/size/) प्रॉपर्टीज़ सेट कर सकते हैं।

**क्या इंक को छुपाने से स्रोत प्रस्तुति बदलती है?**

नहीं। [IInkOptions.HideInk](https://reference.aspose.com/slides/hi/net/aspose.slides.export/iinkoptions/hideink/) केवल रेंडर या एक्सपोर्ट किए गए परिणाम को प्रभावित करता है; यह स्रोत प्रस्तुति में इंक ऑब्जेक्ट्स को नहीं हटाता या बदलता।

**कौन से एक्सपोर्ट फ़ॉर्मेट्स इंक विकल्पों को समर्थन देते हैं?**

आप ऊपर दिखाए गए संबंधित एक्सपोर्ट या रेंडरिंग विकल्पों के माध्यम से PDF, HTML, SVG, TIFF, और बिटमैप स्लाइड इमेज के लिए इंक विकल्प कॉन्फ़िगर कर सकते हैं।

**और पढ़ें**

* शैप्स के बारे में सामान्य जानकारी के लिए देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/net/powerpoint-shapes/) सेक्शन।
* प्रभावी मानों के बारे में अधिक जानकारी के लिए देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/net/shape-effective-properties/#get-effective-font-height-value)।
* PDF एक्सपोर्ट के विवरण के लिए देखें [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hi/net/convert-powerpoint-to-pdf/)।
* HTML एक्सपोर्ट के विवरण के लिए देखें [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hi/net/convert-powerpoint-to-html/)।
* SVG एक्सपोर्ट के विवरण के लिए देखें [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hi/net/render-a-slide-as-an-svg-image/)।
* TIFF एक्सपोर्ट के विवरण के लिए देखें [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hi/net/convert-powerpoint-to-tiff/)।
* स्लाइड‑से‑इमेज रेंडरिंग के विवरण के लिए देखें [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hi/net/convert-slide/).