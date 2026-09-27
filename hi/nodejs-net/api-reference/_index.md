---
title: एपीआई संदर्भ
type: docs
weight: 50
url: /hi/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET को Aspose.Slides for .NET API संदर्भ द्वारा दस्तावेज़ीकृत किया गया है। देखें कि .NET क्लास और सदस्य नाम JavaScript में कैसे मैप होते हैं।"
---
## **अवलोकन**

Aspose.Slides for Node.js via .NET का अपना कोई API संदर्भ नहीं है। पैकेज Aspose.Slides for .NET की क्लासों को समान नामों के साथ, camelCase सदस्य नामों के साथ JavaScript में उजागर करता है, इसलिए [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hi/net/) उसकी क्लास, सदस्य और एनेमरेशन को दस्तावेज़ करता है।

## **.NET नामों को JavaScript में मैप करें**

.NET API संदर्भ में आप जो सदस्य देखते हैं, उनका उपयोग करने के लिए इन नियमों को लागू करें:

- **क्लासेज और एनेमरेशन अपने .NET नामों को बनाए रखते हैं**, और एनेमरेशन वैल्यूज़ भी: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`। उन्हें पैकेज से इम्पोर्ट करें: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`।
- **प्रॉपर्टीज़ और मेथड्स लोअर‑केस अक्षर से शुरू होते हैं।** `Presentation.Slides` बन जाता है `presentation.slides`, और `ShapeCollection.AddAutoShape` बन जाता है `shapes.addAutoShape`। प्रॉपर्टीज़ वही रहती हैं: आप उन्हें बिना कोष्ठकों के पढ़ते और असाइन करते हैं।
- **कलेक्शन आइटम्स को `get(index)` से पढ़ा जाता है**, और आइटम्स की संख्या `count` से: `presentation.slides.get(0)` के बजाय `presentation.Slides[0]`।
- **कुछ ओवरलोड्स को अलग-अलग नाम मिलते हैं।** उदाहरण के लिए, `Slide.GetImage(Size)` ओवरलोड `slide.getImageWithImageSize({ width, height })` बन जाता है। अन्य ओवरलोड्स एक ही मेथड को वैकल्पिक अतिरिक्त आर्ग्यूमेंट्स के साथ साझा करते हैं: `presentation.save(path, format, options, slides)` कई `Presentation.Save` ओवरलोड्स को कवर करता है, और `new Presentation(null, buffer)` एक `Buffer` से प्रस्तुति खोलता है। प्रत्येक क्लास पैकेज के `lib` फ़ोल्डर में एक फ़ाइल होती है (उदाहरण के लिए, `node_modules/aspose.slides.via.net/lib/Slide.js`), जहाँ आप सटीक नाम देख सकते हैं।
- **जब आप उनका उपयोग समाप्त कर लें तो `dispose` के साथ प्रस्तुतियों को रिलीज़ करें**; JavaScript में `using` स्टेटमेंट नहीं है।

पैकेज हर .NET सदस्य को रैप नहीं करता। यदि .NET API संदर्भ से कोई सदस्य क्लास फ़ाइल में नहीं है, तो वह JavaScript में उपलब्ध नहीं होगा।

## **उदाहरण**

निम्नलिखित स्क्रिप्ट उपरोक्त नियमों का उपयोग करती है। प्रत्येक टिप्पणी अगली पंक्ति के अनुरूप .NET कॉल को दर्शाती है। यह पहले स्लाइड में टेक्स्ट के साथ एक आयत जोड़ती है, स्लाइड को 960 × 540 पिक्सेल PNG छवि के रूप में रेंडर करती है, और प्रस्तुति को PDF के रूप में सहेजती है। इसे उस प्रोजेक्ट फ़ोल्डर से चलाएँ जहाँ पैकेज स्थापित किया गया है जैसा कि [स्थापना](/slides/hi/nodejs-net/installation/) में बताया गया है।

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `slide.png` और `slide.pdf` को वर्तमान फ़ोल्डर में लिखती है। दोनों में आयत और उसका टेक्स्ट दिखता है। बिना लाइसेंस के, वे एक मूल्यांकन वॉटरमार्क भी दिखाते हैं; देखें [लाइसेंसिंग](/slides/hi/nodejs-net/licensing/)।

यहाँ उपयोग किए गए सदस्यों के विवरण के लिए, Aspose.Slides for .NET API संदर्भ में [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/text/) और [Slide.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage/) देखें।