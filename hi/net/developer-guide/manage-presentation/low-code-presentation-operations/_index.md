---
title: ".NET में लो-कोड प्रेजेंटेशन ऑपरेशन्स"
linktitle: "लो-कोड API"
type: docs
weight: 50
url: /hi/net/low-code-presentation-operations/
keywords:
- "लो-कोड प्रेजेंटेशन API"
- "प्रेजेंटेशन परिवर्तित करें"
- "प्रेजेंटेशन मिलाएँ"
- "स्लाइड्स पर पुनरावृति करें"
- "शेप्स पर पुनरावृति करें"
- "टेक्स्ट पर पुनरावृति करें"
- "शेप्स एकत्र करें"
- "प्रेजेंटेशन संकुचित करें"
- "अनुपयोगी मास्टर स्लाइड्स हटाएँ"
- "अनुपयोगी लेआउट स्लाइड्स हटाएँ"
- "एम्बेडेड फ़ॉन्ट्स संकुचित करें"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET में Aspose.Slides लो-कोड API का उपयोग करके प्रेजेंटेशन को परिवर्तित और मिलाएँ, सामग्री पर पुनरावृति करें, शेप्स एकत्र करें, और प्रेजेंटेशन आकार को घटाएँ।"
---
## **अवलोकन**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code हेल्पर्स सबसे उपयोगी तब होते हैं जब ऑपरेशन पूरे फ़ाइल या प्रस्तुति पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है। जब आपको व्यक्तिगत स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, एक्सपोर्ट सेटिंग्स, या प्रस्तुति तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण चाहिए, तो पूर्ण [Aspose.Slides object model](https://reference.aspose.com/slides/hi/net/aspose.slides/) का उपयोग करें।

नीचे तालिका उपलब्ध हेल्पर्स का सारांश देती है:

| हेल्पर | किसके लिये उपयोग करें |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/) | एक प्रस्तुति को सीधे फ़ाइल-से-फ़ाइल कॉल के साथ दूसरे फ़ॉर्मेट में बदलना। |
| [Merger](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/merger/) | एक ही फ़ॉर्मेट की पूर्ण प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/) | प्रत्येक स्लाइड, शेप, पैराग्राफ, या टेक्स्ट पोर्शन के लिये कार्रवाई चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/collect/) | पूरा प्रस्तुति से शेप्स को प्राप्त करना ताकि दोबारा प्रोसेसिंग या विश्लेषण हो सके। |
| [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) | अप्रयुक्त मास्टर्स और लेआउट्स को हटाना और एम्बेडेड फ़ॉन्ट डेटा को घटाना। |

## **एक प्रस्तुति को बदलें**

जब आउटपुट फ़ाइल एक्सटेंशन एक्सपोर्ट फ़ॉर्मेट चुनने के लिए पर्याप्त हो, तो [Convert.AutoByExtension](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/autobyextension/) का उपयोग करें। यह मेथड स्रोत प्रस्तुति को खोलता है, आउटपुट पाथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/) क्लास PDF, SVG, JPEG, PNG, और TIFF आउटपुट के लिये विशेष मेथड्स भी प्रदान करती है। जब आपको निर्यात से पहले प्रस्तुति की जांच या संशोधित करना हो या कोई ऐसा निर्यात विकल्प कॉन्फ़िगर करना हो जो चयनित हेल्पर द्वारा उपलब्ध नहीं है, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। फ़ॉर्मेट-विशिष्ट वर्कफ़्लोज़ और विकल्पों के लिये [Convert Presentation](/slides/hi/net/convert-presentation/) देखें।

## **प्रेजेंटेशन को मिलाएँ**

[Merger.Process](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/merger/process/) का उपयोग करके एक कॉल में पूर्ण प्रस्तुति फ़ाइलें मिलाएँ। इनपुट प्रस्तुतियों का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

जब सभी स्लाइड्स को एक परिणाम में जोड़ना हो और उन्हें व्यक्तिगत रूप से चयन या पुनःमैपिंग न करना हो, तो यह हेल्पर उपयुक्त है। जब आपको चयनित स्लाइड्स को मर्ज करना हो, लक्ष्य मास्टर या लेआउट लागू करना हो, सेक्शन को स्पष्ट रूप से संरक्षित करना हो, या विभिन्न स्लाइड आकारों को समन्वयित करना हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। इन परिस्थितियों के लिये [Merge Presentations](/slides/hi/net/merge-presentation/) देखें।

## **प्रेजेंटेशन तत्वों पर पुनरावृति करें**

[ForEach](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/) क्लास प्रत्येक अनुरोधित प्रकार के प्रेजेंटेशन तत्व के लिये एक कॉलबैक को कॉल करती है। यह नेस्टेड कलेक्शन लूप्स से बचती है और प्रेजेंटेशन-व्यापी निरीक्षण या फ़ॉर्मेटिंग परिवर्तन के लिये सुविधाजनक है।

निम्न उदाहरण [ForEach.Slide](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/paragraph/), और [ForEach.Portion](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/portion/) का उपयोग करके संबंधित तत्वों की जाँच करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

डिफ़ॉल्ट रूप से, प्रेजेंटेशन-व्यापी शेप और टेक्स्ट ट्रैवर्सल सामान्य, मास्टर, और लेआउट स्लाइड्स को शामिल करता है। `includeNotes` पैरामीटर वाले ओवरलोड्स नोट्स स्लाइड्स को भी प्रोसेस कर सकते हैं। जब ट्रैवर्सल क्रम, शीघ्र निष्कर्ष, कॉलबैक से पहले फ़िल्टरिंग, या विस्तृत पैरेंट-चाइल्ड नियंत्रण महत्वपूर्ण हो, तो सीधे कलेक्शन लूप्स का उपयोग करें।

## **शेप्स एकत्रित करें**

[Collect.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/collect/shapes/) का उपयोग तब करें जब आपको प्रस्तुति में सभी शेप्स का संग्रह चाहिए, न कि प्रत्येक शेप के लिये कॉलबैक। यह तब उपयोगी है जब वही सेट कई बार फ़िल्टर, गिनती या प्रोसेस किया जाएगा।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

जब प्रत्येक शेप को तुरंत संभालना हो और संग्रहित परिणाम को रखने की आवश्यकता न हो, तो [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/) का उपयोग करें।

## **प्रेजेंटेशन सामग्री को संकुचित करें**

[Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) क्लास अप्रयुक्त संरचनात्मक तत्वों को हटाकर और एम्बेडेड फ़ॉन्ट डेटा को घटाकर मदद कर सकती है:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) उन लेआउट स्लाइड्स को हटाता है जिनका कोई सामान्य स्लाइड संदर्भ नहीं है।
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग में नहीं हैं।
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) एम्बेडेड फ़ॉन्ट्स से अप्रयुक्त अक्षरों को हटाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

अप्रयुक्त लेआउट्स को अप्रयुक्त मास्टर्स से पहले हटाएँ ताकि लेआउट सफ़ाई के बाद अनरफ़रेंस्ड मास्टर भी हटाया जा सके। यदि आपको बाद में मूल मास्टर, लेआउट या पूर्ण एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता पड़ सकती है, तो अनुकूलित प्रस्तुति को नई फ़ाइल में सहेजें। अधिक विवरण के लिये [Slide Master](/slides/hi/net/slide-master/) और [Embedded Font](/slides/hi/net/embedded-font/) देखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं लो-कोड API का उपयोग पूर्ण ऑब्जेक्ट मॉडल के बजाय कब करना चाहिए?**

जब एक मानक ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो-कोड हेल्पर्स का उपयोग करें। जब आपको विशिष्ट स्लाइड्स चुननी हों, मास्टर और लेआउट संबंधों को नियंत्रित करना हो, मध्यवर्ती स्थिति की जांच करनी हो, या ऐसा व्यवहार कॉन्फ़िगर करना हो जो हेल्पर उपलब्ध न कराता हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट्स वाली प्रस्तुतियों को मिलाता है?**

नहीं। [Merger.Process](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/merger/process/) को इनपुट प्रस्तुतियों का समान फ़ॉर्मेट होना आवश्यक है। पहले [Convert.AutoByExtension](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/autobyextension/) का उपयोग करके इनपुट फ़ाइलों को एक सामान्य फ़ॉर्मेट में बदलें, फिर परिवर्तित फ़ाइलों को मिलाएँ।

**क्या ForEach मास्टर, लेआउट, और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach.Slide](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/slide/) सामान्य प्रस्तुति स्लाइड्स को इटररेट करता है। प्रेजेंटेशन-व्यापी [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/paragraph/), और [ForEach.Portion](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/portion/) डिफ़ॉल्ट रूप से सामान्य, मास्टर, और लेआउट स्लाइड्स को शामिल करते हैं। `includeNotes` को `true` पर सेट करके आप नोट्स स्लाइड्स को भी शामिल कर सकते हैं।

**ForEach.Shape और Collect.Shapes में क्या अंतर है?**

जब आप प्रत्येक शेप को तुरंत कॉलबैक के माध्यम से प्रोसेस करना चाहते हैं, तो [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/) का उपयोग करें। जब आपको एक संग्रहित परिणाम चाहिए जिसे रखा, फ़िल्टर किया, गिना या कई बार ट्रैवर्स किया जा सके, तो [Collect.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/collect/shapes/) का उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फाइल को छोटा बनाता है?**

ज़रूर नहीं। परिणाम इस पर निर्भर करता है कि प्रस्तुति में अप्रयुक्त लेआउट्स, अप्रयुक्त मास्टर्स, या अप्रयुक्त अक्षर वाले एम्बेडेड फ़ॉन्ट्स हैं या नहीं। यदि ये मौजूद नहीं हैं, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) ऑपरेशन फ़ाइल आकार को नहीं घटा सकता।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वतः सहेजे जाते हैं?**

नहीं। ये हेल्पर्स मेमोरी में लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट पर काम करते हैं। [ForEach](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/) कॉलबैक या [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) चलाने के बाद, परिणाम लिखने के लिये [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) को कॉल करें।

## **संबंधित लेख**

- [प्रेजेंटेशन बदलें](/slides/hi/net/convert-presentation/)
- [प्रेजेंटेशन मिलाएँ](/slides/hi/net/merge-presentation/)
- [स्लाइड मास्टर](/slides/hi/net/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधन](/slides/hi/net/manage-textbox/)
- [एम्बेडेड फ़ॉन्ट](/slides/hi/net/embedded-font/)