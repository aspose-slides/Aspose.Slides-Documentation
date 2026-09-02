---
title: जावा में प्रस्तुति इंक ऑब्जेक्ट्स का प्रबंधन
linktitle: इंक प्रबंधन
type: docs
weight: 95
url: /hi/java/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक ड्रॉ करें
- ड्रॉइंग
- इंक निर्यात
- इंक रेंडरिंग
- इंक छिपाएँ
- IInkOptions
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें, ट्रेस और ब्रश गुणों को संपादित करें, और PDF, HTML, SVG, TIFF और इमेज निर्यात के दौरान इंक की उपस्थिति को नियंत्रित करें।"
---
## **परिचय**

PowerPoint एक इंक सुविधा प्रदान करता है जो आपको मुक्त‑रूप में स्ट्रोक ड्रॉ करने की अनुमति देती है। इंक का उपयोग अन्य वस्तुओं को हाइलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, और स्लाइड पर विशिष्ट आइटम्स पर ध्यान आकर्षित करने के लिए किया जा सकता है।

Aspose.Slides इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक प्रकार प्रदान करता है। उदाहरण के लिए, [IInk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iink/) इंटरफ़ेस एक स्लाइड पर इंक ऑब्जेक्ट का प्रतिनिधित्व करता है।

## **सामान्य वस्तुओं और इंक वस्तुओं के बीच अंतर**

PowerPoint स्लाइड पर वस्तुओं को आमतौर पर आकार (shape) वस्तु के रूप में दर्शाया जाता है। सबसे सरल रूप में, एक shape एक कंटेनर होता है जो स्वयं वस्तु (उसका फ्रेम) के क्षेत्र को परिभाषित करता है और कंटेनर का आकार, रूप, तथा पृष्ठभूमि जैसी गुण प्रदान करता है। अधिक जानकारी के लिये देखें [आकार लेआउट प्रारूप](https://docs.aspose.com/slides/hi/java/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट को संभालता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) के सभी गुणों को, आकार को छोड़कर, अनदेखा कर देता है। कंटेनर क्षेत्र का आकार मानक [IShape.getWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getWidth--) और [IShape.getHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getHeight--) विधियों द्वारा निर्धारित किया जाता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेसेस**

इंक ट्रेस वह बुनियादी तत्व है जिसका उपयोग पेन की गति को रिकॉर्ड करने के लिये किया जाता है जब उपयोगकर्ता डिजिटल इंक लिखता है। एक ट्रेस जुड़े हुए बिंदुओं की श्रृंखला को संग्रहीत करता है।

एन्कोडिंग का सबसे सरल रूप प्रत्येक नमूना बिंदु के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी जुड़े हुए बिंदुओं को रेंडर किया जाता है, तो वे इस प्रकार की छवि बनाते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश गुण**

ब्रश का उपयोग इंक ट्रेस के बिंदुओं को जोड़ने वाली रेखाओं को ड्रॉ करने के लिये किया जाता है। ब्रश का अपना रंग और आकार होता है, जिसे [IInkBrush.getColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkbrush/#getColor--) और [IInkBrush.getSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkbrush/#getSize--) विधियों द्वारा दर्शाया जाता है।

### **इंक ब्रश रंग सेट करें**

यह Java कोड दिखाता है कि इंक ब्रश का रंग कैसे सेट किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **इंक ब्रश आकार सेट करें**

यह Java कोड दिखाता है कि इंक ब्रश का आकार कैसे सेट किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई समान नहीं होती, इसलिए PowerPoint ब्रश आकार को प्रदर्शित नहीं करता (संबंधित डेटा सेक्शन ग्रे किया जाता है)। जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint इसका आकार इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिये, चलिए इंक ऑब्जेक्ट की ऊँचाई बढ़ाते हैं और महत्वपूर्ण आयामों की समीक्षा करते हैं:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को ध्यान में नहीं रखता— यह हमेशा मानता है कि रेखा की मोटाई शून्य है (पिछली छवि देखें)।

इसलिए पूरे इंक ऑब्जेक्ट के दृश्य क्षेत्र को निर्धारित करने के लिये, उसके ट्रेसेस के ब्रश आकार को ध्यान में रखना आवश्यक है। यहाँ लक्ष्य ऑब्जेक्ट (हस्तलिखित टेक्स्ट ट्रेस) को कंटेनर (फ़्रेम) के आकार के अनुसार स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश आकार स्थिर रहता है, और इसके विपरीत।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint इसी तरह के व्यवहार का उपयोग टेक्स्ट ऑब्जेक्ट्स के लिये करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **निर्यात और रेंडरिंग के दौरान इंक उपस्थिति को नियंत्रित करें**

Aspose.Slides इंक ऑब्जेक्ट्स की निर्यात या रेंडर किए गए आउटपुट में उपस्थिति को नियंत्रित करने के लिये [IInkOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/) इंटरफ़ेस प्रदान करता है। आप इसकी गुणों का उपयोग इंक को पूरी तरह छिपाने या इंक ब्रश मास्क ऑपरेशन्स की व्याख्या को बदलने के लिये कर सकते हैं।

इंक विकल्प कई आउटपुट प्रकारों के लिये निर्यात या रेंडरिंग विकल्पों के माध्यम से उपलब्ध हैं:

| आउटपुट | इंक विकल्प गुण |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

निम्नलिखित [IInkOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/) विधियाँ समान दो सेटिंग्स उजागर करती हैं:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#getHideInk--) निर्धारित करती है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल हों या नहीं। इसका डिफ़ॉल्ट मान `false` है।
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) निर्धारित करती है कि रेंडरिंग के समय इंक ब्रश के लिये मास्क ऑपरेशन को अपैसिटी के रूप में व्याख्या किया जाए या नहीं। इसका डिफ़ॉल्ट मान `true` है; `false` के साथ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) को कॉल करके ROP ऑपरेशन उपयोग करें।

### **PDF आउटपुट में इंक ऑब्जेक्ट्स को छिपाएँ**

डिफ़ॉल्ट रूप से, निर्यात के दौरान इंक ऑब्जेक्ट्स दृश्यमान रहते हैं। हस्तलिखित एनोटेशन या अन्य इंक सामग्री के बिना साफ़ आउटपुट बनाने के लिये, [IInkOptions.setHideInk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) को `true` के साथ कॉल करें।

निम्न Java उदाहरण सभी इंक ऑब्जेक्ट्स को छिपाते हुए प्रस्तुति को PDF में निर्यात करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **स्लाइड को इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छिपाएँ**

स्लाइड को बिटमैप इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छिपाने के लिये, [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/renderingoptions/#getInkOptions--) को कॉन्फ़िगर करें और रेंडरिंग विकल्पों को [ISlide.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) को पास करें।

निम्न Java उदाहरण पहला स्लाइड PNG इमेज के रूप में बिना इंक ऑब्जेक्ट्स के रेंडर करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **इंक मास्क रेंडरिंग को नियंत्रित करें**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) सेटिंग इंक ब्रश को रेंडर करते समय मास्क ऑपरेशन्स की व्याख्या को नियंत्रित करती है। डिफ़ॉल्ट मान `true` है, जो अपैसिटी का उपयोग करता है। ROP ऑपरेशन उपयोग करने के लिये, [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) को `false` के साथ कॉल करें।

निम्न Java उदाहरण स्लाइड को SVG में निर्यात करता है और इंक मास्क ऑपरेशन्स के लिये ROP‑आधारित रेंडरिंग का उपयोग करता है:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

एक ही सेटिंग को [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#getInkOptions--) के माध्यम से भी लागू किया जा सकता है जब प्रस्तुति को TIFF में निर्यात किया जाता है या स्लाइड को TIFF के रूप में रेंडर किया जाता है।

### **इंक को छिपाना या बनाए रखना चुनें**

जब आपको वितरण के लिये एनोटेटेड प्रस्तुति का एक साफ़ संस्करण चाहिए और समीक्षा मार्क नहीं चाहिये, तो निर्यात के दौरान [IInkOptions.setHideInk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) को `true` के साथ कॉल करें।

यदि इंक एनोटेशन वांछित सामग्री का हिस्सा हैं (जैसे समीक्षा टिप्पणी, हस्तलिखित नोट्स, हाइलाइट्स या ड्रॉइंग) तो [IInkOptions.getHideInk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#getHideInk--) को डिफ़ॉल्ट `false` पर रखें। इससे एप्लिकेशन समान प्रस्तुति से अलग‑अलग समीक्षा और अंतिम आउटपुट उत्पन्न कर सकते हैं बिना स्रोत इंक ऑब्जेक्ट्स को संशोधित किए।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक का रंग या आकार बदल सकता हूँ?**

हाँ। [IInk.getTraces](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iink/#getTraces--) से ट्रेस प्राप्त करें, फिर उसके [IInkTrace.getBrush](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinktrace/#getBrush--) को बदलें। रंग बदलने के लिये [IInkBrush.setColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) या आकार बदलने के लिये [IInkBrush.setSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) को कॉल करें।

**क्या इंक को छिपाने से स्रोत प्रस्तुति बदल जाती है?**

नहीं। [IInkOptions.setHideInk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) को कॉल करने से केवल रेंडर किया गया या निर्यात किया गया परिणाम प्रभावित होता है; यह स्रोत प्रस्तुति में इंक ऑब्जेक्ट्स को हटाता या संशोधित नहीं करता।

**कौन‑से निर्यात फ़ॉर्मेट इंक विकल्पों का समर्थन करते हैं?**

आप ऊपर दिखाए गए संबंधित निर्यात या रेंडरिंग विकल्पों के माध्यम से PDF, HTML, SVG, TIFF, और बिटमैप स्लाइड इमेज के लिये इंक विकल्प कॉन्फ़िगर कर सकते हैं।

**अतिरिक्त पढ़ाई**

* सामान्य रूप में श Shapes के बारे में पढ़ने के लिये देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/java/powerpoint-shapes/) अनुभाग।
* प्रभावी मानों के बारे में अधिक जानकारी के लिये देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/java/shape-effective-properties/#get-effective-font-height-value)।
* PDF निर्यात पर विस्तार से जानने के लिये देखें [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hi/java/convert-powerpoint-to-pdf/)।
* HTML निर्यात पर विस्तार से जानने के लिये देखें [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hi/java/convert-powerpoint-to-html/)।
* SVG निर्यात पर विस्तार से जानने के लिये देखें [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hi/java/render-a-slide-as-an-svg-image/)।
* TIFF निर्यात पर विस्तार से जानने के लिये देखें [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hi/java/convert-powerpoint-to-tiff/)।
* स्लाइड‑से‑इमेज रेंडरिंग पर विस्तार से जानने के लिये देखें [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hi/java/convert-slide/).