---
title: PHP में प्रेजेंटेशन इंक ऑब्जेक्ट्स प्रबंधित करें
linktitle: इंक प्रबंधित करें
type: docs
weight: 95
url: /hi/php-java/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक बनाएं
- ड्रॉइंग
- इंक निर्यात
- इंक रेंडरिंग
- इंक छुपाएं
- InkOptions
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें, ट्रेसेस और ब्रश प्रॉपर्टीज़ को संपादित करें, और PDF, HTML, SVG, TIFF और इमेज एक्सपोर्ट के दौरान इंक दिखावट को Aspose.Slides for PHP via Java के साथ नियंत्रित करें।"
---
## **परिचय**

PowerPoint में इंक सुविधा है जो आपको मुक्त‑रूप स्ट्रोक बनाने देती है। इंक का उपयोग अन्य वस्तुओं को उजागर करने, कनेक्शन और प्रक्रियाएँ दिखाने, तथा स्लाइड पर विशिष्ट आइटमों पर ध्यान आकर्षित करने के लिए किया जा सकता है।

Aspose.Slides इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक प्रकार प्रदान करता है। उदाहरण के लिए, [Ink](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ink/) क्लास स्लाइड पर एक इंक ऑब्जेक्ट का प्रतिनिधित्व करती है।

## **सामान्य ऑब्जेक्ट्स और इंक ऑब्जेक्ट्स के बीच अंतर**

PowerPoint स्लाइड पर वस्तुओं का सामान्यतः [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट द्वारा प्रतिनिधित्व किया जाता है। सबसे सरल रूप में, एक Shape एक कंटेनर है जो वस्तु के स्वयं के क्षेत्र (फ्रेम) को परिभाषित करता है तथा कंटेनर का आकार, आकार, और पृष्ठभूमि जैसी प्रॉपर्टीज़ शामिल करता है। अधिक जानकारी के लिए, देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/php-java/shape-manipulations/#access-layout-formats-for-shape)।

हालांकि, जब PowerPoint एक इंक ऑब्जेक्ट को संभालता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी प्रॉपर्टीज़ को छोड़कर केवल आकार को ही मानता है। कंटेनर क्षेत्र का आकार मानक [Shape.getWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getWidth) और [Shape.getHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getHeight) मेथड्स द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेसेस**

एक इंक ट्रेस बुनियादी तत्व है जिसका उपयोग पेन की गति को रिकॉर्ड करने के लिए किया जाता है जब उपयोगकर्ता डिजिटल इंक लिखता है। एक ट्रेस जुड़े हुए बिंदुओं की श्रृंखला को संग्रहीत करता है।

एन्कोडिंग का सबसे सरल रूप प्रत्येक सैंपल बिंदु के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी जुड़े बिंदुओं को रेंडर किया जाता है, तो यह इस प्रकार की छवि बनती है:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉ करने के लिए ब्रश प्रॉपर्टीज़**

एक ब्रश का उपयोग इंक ट्रेस के बिंदुओं को जोड़ने वाली रेखाएँ खींचने के लिए किया जाता है। ब्रश का अपना रंग और आकार होता है, जो [InkBrush.getColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkbrush/#getColor) और [InkBrush.getSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkbrush/#getSize) मेथड्स द्वारा दर्शाया जाता है।

### **इंक ब्रश का रंग सेट करें**

यह PHP कोड दिखाता है कि इंक ब्रश का रंग कैसे सेट किया जाता है:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **इंक ब्रश का आकार सेट करें**

यह PHP कोड दिखाता है कि इंक ब्रश का आकार कैसे सेट किया जाता है:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

आमतौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश का आकार नहीं दिखाता (संबंधित डेटा सेक्शन ग्रे हो जाता है)। जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint अपना आकार इस प्रकार दर्शाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिए, चलिए इंक ऑब्जेक्ट की ऊँचाई बढ़ाते हैं और महत्वपूर्ण आयामों की समीक्षा करते हैं:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को ध्यान में नहीं रखता—यह हमेशा मान लेता है कि रेखा की मोटाई शून्य है (पिछली छवि देखें)।

इसलिए, पूरे इंक ऑब्जेक्ट के दिखने वाले क्षेत्र को निर्धारित करने के लिए उसके ट्रेसेस के ब्रश आकार को ध्यान में रखना आवश्यक है। यहाँ, लक्ष्य ऑब्जेक्ट (हाथ से लिखे टेक्स्ट ट्रेस) को कंटेनर (फ़्रेम) के आकार में स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश आकार स्थिर रहता है, और इसके विपरीत भी।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट ऑब्जेक्ट्स के लिए समान व्यवहार उपयोग करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **एक्सपोर्ट और रेंडरिंग के दौरान इंक दिखावट को नियंत्रित करें**

Aspose.Slides [InkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/) क्लास प्रदान करता है जिससे आप यह नियंत्रित कर सकते हैं कि एक्सपोर्ट या रेंडर किए गए आउटपुट में इंक ऑब्जेक्ट्स कैसे दिखें। आप इसकी प्रॉपर्टीज़ का उपयोग इंक को पूरी तरह से छुपाने या इंक ब्रश मास्क ऑपरेशन की व्याख्या बदलने के लिए कर सकते हैं।

इंक विकल्प कई आउटपुट प्रकारों के लिए एक्सपोर्ट या रेंडरिंग विकल्पों के माध्यम से उपलब्ध हैं:

| आउटपुट | इंक विकल्प प्रॉपर्टी |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| स्लाइड इमेज | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/#getInkOptions) |

निम्नलिखित [InkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/) मेथड्स समान दो सेटिंग्स को उजागर करते हैं:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#getHideInk) निर्धारित करता है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल किए जाएँ या नहीं। इसका डिफ़ॉल्ट मान `false` है।  
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) निर्धारित करता है कि इंक ब्रश को रेंडर करते समय मास्क ऑपरेशन को अपारदर्शिता के रूप में व्याख्यायित किया जाए या नहीं। इसका डिफ़ॉल्ट मान `true` है; इसके बजाय ROP ऑपरेशन उपयोग करने के लिए [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) को `false` के साथ कॉल करें।

### **PDF आउटपुट में इंक ऑब्जेक्ट्स को छुपाएँ**

डिफ़ॉल्ट रूप से, एक्सपोर्ट के दौरान इंक ऑब्जेक्ट्स दिखाई देते हैं। हस्तलिखित नोट्स या अन्य इंक सामग्री के बिना एक साफ़ आउटपुट बनाने के लिए, [InkOptions.setHideInk](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#setHideInk) को `true` के साथ कॉल करें।

निम्नलिखित PHP उदाहरण सभी इंक ऑब्जेक्ट्स को छुपाते हुए एक प्रेजेंटेशन को PDF में एक्सपोर्ट करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **स्लाइड को इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छुपाएँ**

बिटमैप इमेज के रूप में स्लाइड्स को रेंडर करते समय इंक ऑब्जेक्ट्स को छुपाने के लिए, [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/#getInkOptions) को कॉन्फ़िगर करें और रेंडरिंग विकल्पों को [Slide.getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) को पास करें।

निम्नलिखित PHP उदाहरण पहला स्लाइड PNG इमेज के रूप में बिना इंक ऑब्जेक्ट्स के रेंडर करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **इंक मास्क रेंडरिंग को नियंत्रित करें**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) सेटिंग नियंत्रित करती है कि इंक ब्रश को रेंडर करते समय मास्क ऑपरेशन को कैसे व्याख्यायित किया जाए। डिफ़ॉल्ट मान `true` है, जो अपारदर्शिता का उपयोग करता है। इसके बजाय ROP ऑपरेशन उपयोग करने के लिए, [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) को `false` के साथ कॉल करें।

निम्नलिखित PHP उदाहरण एक स्लाइड को SVG में एक्सपोर्ट करता है और इंक मास्क ऑपरेशनों के लिए ROP-आधारित रेंडरिंग का उपयोग करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

इसी सेटिंग को [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getInkOptions) के माध्यम से भी लागू किया जा सकता है जब प्रेजेंटेशन को एक्सपोर्ट किया जा रहा हो या स्लाइड को TIFF में रेंडर किया जा रहा हो।

### **इंक को छुपाएँ या संरक्षित रखें, यह चुनें**

जब आपको समीक्षा चिह्नों के बिना वितरण के लिए एनोटेटेड प्रेजेंटेशन का एक साफ़ संस्करण चाहिए, तो एक्सपोर्ट के दौरान [InkOptions.setHideInk](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#setHideInk) को `true` के साथ कॉल करें।

जब इंक एनोटेशन इच्छित कंटेंट का हिस्सा हों, जैसे समीक्षा टिप्पणी, हाथ से लिखे नोट्स, हाइलाइट्स, या ड्रॉइंग्स जिन्हें एक्सपोर्ट परिणाम में दिखना चाहिए, तो [InkOptions.getHideInk](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#getHideInk) को उसके डिफ़ॉल्ट मान `false` पर रखें। इससे एप्लिकेशन एक ही प्रेजेंटेशन से अलग-अलग समीक्षा और अंतिम आउटपुट बना सकते हैं बिना स्रोत इंक ऑब्जेक्ट्स को बदलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक के रंग या आकार को बदल सकता हूँ?**

हाँ। ट्रेस को [Ink.getTraces](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ink/#getTraces) से प्राप्त करें, फिर उसके [InkTrace.getBrush](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inktrace/#getBrush) को बदलें। ब्रश को बदलने के लिए [InkBrush.setColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkbrush/#setColor) या [InkBrush.setSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkbrush/#setSize) को कॉल करें।

**क्या इंक को छुपाने से स्रोत प्रेजेंटेशन बदलता है?**

नहीं। [InkOptions.setHideInk](https://reference.aspose.com/slides/hi/php-java/aspose.slides/inkoptions/#setHideInk) को कॉल करने से केवल रेंडर या एक्सपोर्ट किए गए परिणाम पर प्रभाव पड़ता है; यह स्रोत प्रेजेंटेशन में इंक ऑब्जेक्ट्स को नहीं हटाता या नहीं बदलता।

**कौनसे एक्सपोर्ट फ़ॉर्मैट इंक विकल्पों को समर्थन देते हैं?**

आप PDF, HTML, SVG, TIFF, और बिटमैप स्लाइड इमेज के लिए उपर्युक्त संबंधित एक्सपोर्ट या रेंडरिंग विकल्पों के माध्यम से इंक विकल्प कॉन्फ़िगर कर सकते हैं।

**आगे पढ़ें**

* सामान्य रूप से आकृतियों के बारे में पढ़ने के लिए, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/php-java/powerpoint-shapes/) सेक्शन.  
* प्रभावी मानों के बारे में अधिक जानकारी के लिए, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/php-java/shape-effective-properties/#get-effective-font-height-value).  
* PDF एक्सपोर्ट के विवरण के लिए, देखें [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hi/php-java/convert-powerpoint-to-pdf/).  
* HTML एक्सपोर्ट के विवरण के लिए, देखें [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hi/php-java/convert-powerpoint-to-html/).  
* SVG एक्सपोर्ट के विवरण के लिए, देखें [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hi/php-java/render-a-slide-as-an-svg-image/).  
* TIFF एक्सपोर्ट के विवरण के लिए, देखें [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hi/php-java/convert-powerpoint-to-tiff/).  
* स्लाइड‑से‑इमेज रेंडरिंग के विवरण के लिए, देखें [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hi/php-java/convert-slide/).