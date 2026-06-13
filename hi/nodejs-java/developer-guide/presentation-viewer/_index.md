---
title: JavaScript में प्रस्तुति व्यूअर बनाएं
linktitle: प्रस्तुति व्यूअर
type: docs
weight: 50
url: /hi/nodejs-java/presentation-viewer/
keywords:
  - प्रस्तुति देखें
  - प्रस्तुति व्यूअर
  - प्रस्तुति व्यूअर बनाएं
  - PPT देखें
  - PPTX देखें
  - ODP देखें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में एक कस्टम प्रस्तुति व्यूअर बनाएं। Microsoft PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलें प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java का उपयोग स्लाइडों वाली प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइडों को Microsoft PowerPoint आदि में प्रस्तुति खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर्स को स्लाइडों को अपने पसंदीदा इमेज व्यूअर में छवि के रूप में देखना या अपना स्वयं का प्रस्तुति व्यूअर बनाना पड़ सकता है। ऐसे मामलों में, Aspose.Slides आपको व्यक्तिगत स्लाइड को छवि के रूप में निर्यात करने की सुविधा देता है। यह लेख बताता है कि यह कैसे किया जाए।

## **स्लाइड से SVG छवि बनाएं**

Aspose.Slides के साथ प्रस्तुति स्लाइड से SVG छवि बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।  
1. फ़ाइल स्ट्रीम खोलें।  
1. स्लाइड को SVG छवि के रूप में फ़ाइल स्ट्रीम में सहेजें।

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **कस्टम आकार ID वाली SVG बनाएं**

Aspose.Slides का उपयोग करके आप स्लाइड से एक [SVG](https://docs.fileformat.com/page-description-language/svg/) को कस्टम आकार ID के साथ जनरेट कर सकते हैं। इसके लिए, [SvgShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgshape/) से `setId` मेथड का उपयोग करें। `CustomSvgShapeFormattingController` का उपयोग करके आकार ID सेट की जा सकती है।

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **स्लाइड थंबनेल छवि बनाएं**

Aspose.Slides आपको स्लाइडों की थंबनेल छवियां बनाने में मदद करता है। Aspose.Slides के साथ स्लाइड का थंबनेल बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।  
1. परिभाषित स्केल पर संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।  
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **उपयोगकर्ता द्वारा परिभाषित आयामों के साथ स्लाइड थंबनेल बनाएं**

उपयोगकर्ता द्वारा परिभाषित आयामों के साथ स्लाइड थंबनेल छवि बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।  
1. परिभाषित आयामों के साथ संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।  
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ स्लाइड का थंबनेल जनरेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/) क्लास का एक इंस्टेंस बनाएं।  
1. स्पीकर नोट्स की स्थिति सेट करने के लिए `RenderingOptions.setSlidesLayoutOptions` मेथड का उपयोग करें।  
1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।  
1. रेंडरिंग विकल्पों के साथ संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।  
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **लाइव उदाहरण**

आप Aspose.Slides API के साथ क्या लागू कर सकते हैं, इसे देखने के लिए मुफ्त ऐप [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) का उपयोग कर सकते हैं:

![ऑनलाइन पॉवरपॉइंट व्यूवर](online-PowerPoint-viewer.png)

## **FAQ**

**क्या मैं Node.js वेब एप्लिकेशन में एक प्रस्तुति व्यूअर एम्बेड कर सकता हूँ?**

हां। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइडों को छवि या HTML रूप में रेंडर कर सकते हैं और उन्हें ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम फीचर को JavaScript के माध्यम से इंटरैक्टिव अनुभव के लिए लागू किया जा सकता है।

**कस्टम व्यूअर में स्लाइड्स को प्रदर्शित करने का सबसे अच्छा तरीका क्या है?**

सिफ़ारिश किया जाता है कि प्रत्येक स्लाइड को छवि (जैसे PNG या SVG) के रूप में रेंडर करें या Aspose.Slides का उपयोग करके उसे HTML में परिवर्तित करें, फिर आउटपुट को डेस्कटॉप के लिए पिक्चर बॉक्स या वेब के लिए HTML कंटेनर में दिखाएँ।

**कई स्लाइडों वाले बड़े प्रस्तुतियों को मैं कैसे संभालूं?**

बड़े डेक के लिए लेज़ी‑लोडिंग या ऑन‑डिमांड रेंडरिंग विचार करें। इसका अर्थ है कि स्लाइड की सामग्री केवल तभी जनरेट की जाए जब उपयोगकर्ता उसे नेविगेट करे, जिससे मेमोरी उपयोग और लोड समय घटता है।