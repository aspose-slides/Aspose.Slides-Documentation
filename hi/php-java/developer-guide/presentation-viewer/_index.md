---
title: PHP में प्रेजेंटेशन व्यूअर बनाएं
linktitle: प्रेजेंटेशन व्यूअर
type: docs
weight: 50
url: /hi/php-java/presentation-viewer/
keywords: 
- प्रेजेंटेशन देखें
- प्रेजेंटेशन व्यूअर
- प्रेजेंटेशन व्यूअर बनाएं
- PPT देखें
- PPTX देखें
- ODP देखें
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके एक कस्टम प्रेजेंटेशन व्यूअर बनाएं। Microsoft PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलें प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for PHP via Java का उपयोग स्लाइडों वाले प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइडों को Microsoft PowerPoint आदि में प्रेजेंटेशन खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर्स को स्लाइडों को अपनी पसंद के इमेज व्यूअर में इमेज के रूप में देखना या अपना स्वयं का प्रेजेंटेशन व्यूअर बनाना पड़ता है। ऐसे मामलों में, Aspose.Slides आपको व्यक्तिगत स्लाइड को इमेज के रूप में एक्सपोर्ट करने की अनुमति देता है। यह लेख बताता है कि इसे कैसे करें।

## **स्लाइड से SVG इमेज उत्पन्न करें**

Aspose.Slides के साथ प्रेजेंटेशन स्लाइड से SVG इमेज उत्पन्न करने के लिये, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. फ़ाइल स्ट्रीम खोलें।
1. स्लाइड को फ़ाइल स्ट्रीम में SVG इमेज के रूप में सहेजें।

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **कस्टम शेप आईडी के साथ SVG उत्पन्न करें**

Aspose.Slides का उपयोग कस्टम शेप आईडी के साथ स्लाइड से एक [SVG](https://docs.fileformat.com/page-description-language/svg/) उत्पन्न करने के लिये किया जा सकता है। ऐसा करने के लिये, [SvgShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgshape/) से `setId` मेथड का उपयोग करें। `CustomSvgShapeFormattingController` का उपयोग करके शेप आईडी सेट की जा सकती है।

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **स्लाइड थंबनेल इमेज बनाएं**

Aspose.Slides आपको स्लाइडों की थंबनेल इमेज बनाने में मदद करता है। Aspose.Slides का उपयोग करके स्लाइड का थंबनेल उत्पन्न करने के लिये, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. निर्धारित स्केल पर रेफ़रेंस की गई स्लाइड की थंबनेल इमेज प्राप्त करें।
1. थंबनेल इमेज को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **उपयोगकर्ता परिभाषित आयामों के साथ स्लाइड थंबनेल बनाएं**

उपयोगकर्ता परिभाषित आयामों के साथ स्लाइड थंबनेल इमेज बनाने के लिये, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. परिभाषित आयामों के साथ रेफ़रेंस की गई स्लाइड की थंबनेल इमेज प्राप्त करें।
1. थंबनेल इमेज को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

स्पीकर नोट्स के साथ स्लाइड का थंबनेल Aspose.Slides का उपयोग करके उत्पन्न करने के लिये, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/) क्लास का इंस्टेंस बनाएं।
1. `RenderingOptions.setSlidesLayoutOptions` मेथड का उपयोग करके स्पीकर नोट्स की पोजीशन सेट करें।
1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. रेफ़रेंस की गई स्लाइड की थंबनेल इमेज रेंडरिंग विकल्पों के साथ प्राप्त करें।
1. थंबनेल इमेज को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **लाइव उदाहरण**

आप Aspose.Slides API के साथ क्या लागू कर सकते हैं, यह देखने के लिये नि:शुल्क ऐप [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) आज़मा सकते हैं:

![ऑनलाइन पावरपॉइंट व्यूअर](online-PowerPoint-viewer.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं वेब एप्लिकेशन में प्रेजेंटेशन व्यूअर एम्बेड कर सकता/सकती हूँ?**

हाँ। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइडों को इमेज या HTML के रूप में रेंडर कर सकते हैं और उन्हें ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम फीचर जावास्क्रिप्ट के साथ इंटरेक्टिव अनुभव के लिये लागू किए जा सकते हैं।

**कस्टम व्यूअर के अंदर स्लाइड्स को प्रदर्शित करने का सर्वोत्तम तरीका क्या है?**

सिफारिश किए गए तरीके में प्रत्येक स्लाइड को इमेज (जैसे PNG या SVG) के रूप में रेंडर करना या Aspose.Slides का उपयोग करके उसे HTML में परिवर्तित करना शामिल है, और फिर इसे डेस्कटॉप के लिये पिक्चर बॉक्स या वेब के लिये HTML कंटेनर में दिखाना।

**मैं कई स्लाइड वाली बड़ी प्रेजेंटेशन्स को कैसे संभालूँ?**

बड़ी डेक्स के लिये, स्लाइड्स को लेज़ी-लोडिंग या ऑन-डिमांड रेंडरिंग पर विचार करें। इसका अर्थ है कि स्लाइड की सामग्री केवल तभी उत्पन्न करें जब उपयोगकर्ता उसे नेविगेट करे, जिससे मेमोरी और लोड टाइम कम हो जाता है।