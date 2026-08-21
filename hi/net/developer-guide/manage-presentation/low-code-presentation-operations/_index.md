---
title: .NET में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/net/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति परिवर्तित करें
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स पर पुनरावृति
- आकृतियों पर पुनरावृति
- पाठ पर पुनरावृति
- आकृतियों को एकत्र करें
- प्रस्तुति संकुचित करें
- अनउपयोगी मास्टर स्लाइड्स हटाएँ
- अनउपयोगी लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संकुचित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides लो-कोड API को .NET में उपयोग करके प्रस्तुतियों को बदलें और मिलाएँ, सामग्री पर पुनरावृति करें, आकृतियों को एकत्र करें, और प्रस्तुति का आकार कम करें।"
---
## **अवलोकन**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/hi/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/) | किसी प्रस्तुति को दूसरे फ़ॉर्मेट में सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ बदलना। |
| [Merger](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/merger/) | समान फ़ॉर्मेट की पूरी प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/) | प्रत्येक स्लाइड, शेप, पैराग्राफ या टेक्स्ट पोर्शन के लिए एक्शन चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/collect/) | पूरे प्रस्तुति से शेप्स को पुनःप्रसंस्करण या विश्लेषण के लिये एकत्र करना। |
| [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) | अनउपयोगी मास्टर और लेआउट हटाना तथा एम्बेडेड फ़ॉन्ट डेटा को घटाना। |

## **एक प्रस्तुति को बदलें**

उपयोग करें [Convert.AutoByExtension](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/autobyextension/) जब आउटपुट फ़ाइल एक्सटेंशन स्वरूप चुनने के लिये पर्याप्त हो। यह मेथड स्रोत प्रस्तुति खोलता है, आउटपुट पाथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/net/convert-presentation/) for format-specific workflows and options.

## **प्रस्तुतियों को मिलाएँ**

उपयोग करें [Merger.Process](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/merger/process/) एक कॉल से पूरी प्रस्तुति फ़ाइलों को संयोजित करने के लिए। इनपुट प्रस्तुतियों का फ़ॉर्मेट समान होना चाहिए।

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

यह हेल्पर तब उपयुक्त होता है जब सभी स्लाइड्स को एक परिणाम में बिना व्यक्तिगत चयन या पुनःमैपिंग के जोड़ना हो। Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/net/merge-presentation/) for those scenarios.

## **प्रस्तुति तत्वों के माध्यम से आवर्तित करें**

The [ForEach](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

डिफ़ॉल्ट रूप से, प्रस्तुति‑व्यापी शेप और टेक्स्ट प्रवास सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करता है। `includeNotes` पैरामीटर वाले ओवरलोड भी नोट्स स्लाइड्स को प्रोसेस कर सकते हैं। जब प्रवास क्रम, शीघ्र निकास, कॉलबैक से पहले फ़िल्टरिंग, या विस्तृत पैरेंट‑चाइल्ड नियंत्रण आवश्यक हो तो सीधे कलेक्शन लूप का उपयोग करें।

## **शेप्स एकत्र करें**

उपयोग करें [Collect.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/collect/shapes/) जब आपको प्रस्तुति में सभी शेप्स का संग्रह चाहिए न कि प्रत्येक शेप के लिये कॉलबैक चाहिए। यह तब उपयोगी है जब वही सेट कई बार फ़िल्टर, गिनती या प्रोसेस किया जाएगा।

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

जब प्रत्येक शेप को तुरंत संभाला जा सकता है और संग्रहित परिणाम की आवश्यकता नहीं होती, तब [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/) का उपयोग करें।

## **प्रस्तुति सामग्री को संकुचित करें**

The [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) लेआउट स्लाइड्स को हटाता है जो कोई सामान्य स्लाइड संदर्भित नहीं करतीं।
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग में नहीं हैं।
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) एम्बेडेड फ़ॉन्ट्स से अनउपयोगी वर्णों को हटाता है।

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

लेआउट को अनउपयोगी होने से पहले हटाएँ, फिर अनउपयोगी मास्टर हटाएँ ताकि लेआउट सफ़ाई के बाद अप्रयुक्त मास्टर भी हटाया जा सके। यदि आपको बाद में मूल मास्टर, लेआउट या पूरी एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता पड़ सकती है, तो अनुकूलित प्रस्तुति को नई फ़ाइल में सेव रखें। अधिक जानकारी के लिये देखें [Slide Master](/net/slide-master/) और [Embedded Font](/net/embedded-font/)।

## **FAQ**

**Low-code API को पूर्ण ऑब्जेक्ट मॉडल के बजाय कब उपयोग करें?**

जब कोई मानक ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब low-code हेल्पर्स प्रयोग करें। जब आपको विशिष्ट स्लाइड्स चुनने, मास्टर और लेआउट संबंधों को नियंत्रित करने, मध्यवर्ती अवस्था का निरीक्षण करने, या ऐसा व्यवहार कॉन्फ़िगर करने की आवश्यकता हो जो हेल्पर प्रदान नहीं करता, तब पूर्ण ऑब्जेक्ट मॉडल उपयोग करें।

**क्या Merger अलग‑अलग फ़ाइल फ़ॉर्मेट वाली प्रस्तुतियों को जोड़ सकता है?**

नहीं। [Merger.Process](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/merger/process/) को इनपुट प्रस्तुतियों का फ़ॉर्मेट समान होना आवश्यक है। पहले इनपुट फ़ाइलों को एक सामान्य फ़ॉर्मेट में बदलें,例えば [Convert.AutoByExtension](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/convert/autobyextension/) से, और फिर परिवर्तित फ़ाइलों को मिलाएँ।

**क्या ForEach मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach.Slide](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/slide/) सामान्य प्रस्तुति स्लाइड्स को आवृत करता है। प्रस्तुति‑व्यापी [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/paragraph/), और [ForEach.Portion](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/portion/) डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। नोट्स स्लाइड्स को शामिल करने के लिये उनके ओवरलोड को `includeNotes` को `true` सेट करके उपयोग करें।

**ForEach.Shape और Collect.Shapes में क्या अंतर है?**

जब आप प्रत्येक शेप को तुरंत कॉलबैक के माध्यम से प्रोसेस करना चाहते हैं, तब [ForEach.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/shape/) का उपयोग करें। जब आपको एक संग्रह योग्य परिणाम चाहिए जिसे बरकरार रखा, फ़िल्टर किया, गिना या बार‑बार पार किया जा सके, तब [Collect.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/collect/shapes/) का उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस पर निर्भर करता है कि प्रस्तुति में अनउपयोगी लेआउट, अनउपयोगी मास्टर या अनउपयोगी वर्णों वाला एम्बेडेड फ़ॉन्ट मौजूद है या नहीं। यदि इनमें से कुछ भी नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) ऑपरेशन फ़ाइल आकार को नहीं घटा सकते।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वतः सहेजे जाते हैं?**

नहीं। ये हेल्पर्स लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट पर मेमोरी में काम करते हैं। [ForEach](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/foreach/) कॉलबैक या [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) चलाने के बाद, परिणाम लिखने के लिये [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) को कॉल करें।

## **संबंधित लेख**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)