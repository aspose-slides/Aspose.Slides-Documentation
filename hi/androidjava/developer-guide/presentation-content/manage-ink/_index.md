---
title: एन्ड्रॉइड पर प्रस्तुति इंक ऑब्जेक्ट्स का प्रबंधन
linktitle: इंक प्रबंधन
type: docs
weight: 95
url: /hi/androidjava/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधन
- इंक ड्रॉ करना
- चित्रण
- इंक निर्यात
- इंक रेंडरिंग
- इंक छिपाएँ
- IInkOptions
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PDF, HTML, SVG, TIFF और इमेज एक्सपोर्ट के दौरान PowerPoint इंक ऑब्जेक्ट्स का प्रबंधन, ट्रेसेज़ और ब्रश गुणों को संपादित करना, और इंक की उपस्थिति को नियंत्रित करना।"
---
## **परिचय**

PowerPoint एक इंक फीचर प्रदान करता है जो आपको फ्रीफ़ॉर्म स्ट्रोक्स ड्रॉ करने देता है। इंक का उपयोग अन्य वस्तुओं को हाइलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, तथा स्लाइड पर विशिष्ट आइटम्स पर ध्यान आकर्षित करने के लिए किया जा सकता है।

Aspose.Slides इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक टाइप्स प्रदान करता है। उदाहरण के लिए, [IInk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iink/) इंटरफ़ेस स्लाइड पर एक इंक ऑब्जेक्ट का प्रतिनिधित्व करता है।

## **सामान्य वस्तुओं और इंक वस्तुओं के बीच अंतर**

PowerPoint स्लाइड पर वस्तुएँ आमतौर पर shape ऑब्जेक्ट्स द्वारा प्रतिनिधित्व की जाती हैं। सबसे सरल रूप में, एक shape वह कंटेनर है जो वस्तु के स्वयं के क्षेत्र (उसका फ्रेम) के साथ कंटेनर का आकार, आकार और पृष्ठभूमि जैसी विशेषताएँ परिभाषित करता है। अधिक जानकारी के लिए, देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/androidjava/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint एक इंक ऑब्जेक्ट को संभालता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी विशेषताओं को उसकी आकार के अलावा अनदेखा कर देता है। कंटेनर क्षेत्र का आकार मानक [IShape.getWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getWidth--) और [IShape.getHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getHeight--) मेथड्स द्वारा निर्धारित किया जाता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेसेज़**

इंक ट्रेस वह बुनियादी तत्व है जिसका उपयोग पेन की गति को रिकॉर्ड करने के लिये किया जाता है जब उपयोगकर्ता डिजिटल इंक लिखता है। एक ट्रेस जुड़े हुए बिंदुओं की श्रृंखला को संग्रहीत करता है।

एन्कोडिंग का सबसे सरल रूप प्रत्येक सैंपल बिंदु के X और Y निर्देशांक को निर्दिष्ट करता है। जब सभी जुड़े बिंदुओं को रेंडर किया जाता है, तो वे इस प्रकार की छवि उत्पन्न करते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिये ब्रश प्रॉपर्टीज़**

ब्रश का उपयोग इंक ट्रेस के बिंदुओं को जोड़ने वाली लाइनों को ड्रॉ करने के लिये किया जाता है। ब्रश का अपना रंग और आकार होता है, जिसे [IInkBrush.getColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkbrush/#getColor--) और [IInkBrush.getSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkbrush/#getSize--) मेथड्स द्वारा दर्शाया गया है।

### **इंक ब्रश का रंग सेट करें**

यह Java कोड दिखाता है कि इंक ब्रश का रंग कैसे सेट किया जाए:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **इंक ब्रश का आकार सेट करें**

यह Java कोड दिखाता है कि इंक ब्रश का आकार कैसे सेट किया जाए:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाते, इसलिए PowerPoint ब्रश का आकार प्रदर्शित नहीं करता (संबंधित डेटा सेक्शन ग्रे हो जाता है)। जब ब्रश की चौड़ाई और ऊँचाई मेल खाते हैं, तो PowerPoint इसका आकार इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिये, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को ध्यान में नहीं रखता—यह हमेशा मानता है कि रेखा की मोटाई शून्य है (पिछली छवि देखें)।

इसलिए, पूरे इंक ऑब्जेक्ट के दृश्य क्षेत्र को निर्धारित करने के लिये उसके ट्रेसेज़ के ब्रश आकार को ध्यान में रखा जाना चाहिए। यहाँ, लक्ष्य ऑब्जेक्ट (हाथ से लिखा गया टेक्स्ट ट्रेस) को कंटेनर (फ़्रेम) के आकार तक स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है, और इसके विपरीत।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट ऑब्जेक्ट्स के लिये समान व्यवहार का उपयोग करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **एक्सपोर्ट और रेंडरिंग के दौरान इंक की उपस्थिति को नियंत्रित करें**

Aspose.Slides [IInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/) इंटरफ़ेस प्रदान करता है जिससे आप एक्सपोर्ट या रेंडर किए गए आउटपुट में इंक ऑब्जेक्ट्स की उपस्थिति को नियंत्रित कर सकते हैं। आप इसकी प्रॉपर्टीज़ का उपयोग करके इंक को पूरी तरह से छिपा सकते हैं या इंक ब्रश मास्क ऑपरेशन्स की व्याख्या बदल सकते हैं।

इंक विकल्प कई आउटपुट प्रकारों के लिये एक्सपोर्ट या रेंडरिंग विकल्पों के माध्यम से उपलब्ध हैं:

| आउटपुट | इंक विकल्प गुण |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| स्लाइड इमेज | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

निम्नलिखित [IInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/) मेथड्स दो समान सेटिंग्स को उजागर करते हैं:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) निर्धारित करता है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल हों या नहीं। इसका डिफ़ॉल्ट मान `false` है।
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) निर्धारित करता है कि रेंडरिंग के दौरान इंक ब्रश के लिये मास्क ऑपरेशन को अपारदर्शिता के रूप में समझा जाए या नहीं। इसका डिफ़ॉल्ट मान `true` है; `false` के साथ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) को कॉल करके ROP ऑपरेशन का उपयोग करें।

### **PDF आउटपुट में इंक ऑब्जेक्ट्स को छिपाएँ**

डिफ़ॉल्ट रूप से, एक्सपोर्ट के दौरान इंक ऑब्जेक्ट्स दृश्यमान रहते हैं। हाथ से लिखे एनोटेशन या अन्य इंक सामग्री के बिना साफ़ आउटपुट बनाने के लिये, [IInkOptions.setHideInk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) को `true` के साथ कॉल करें।

निम्नलिखित Java उदाहरण सभी इंक ऑब्जेक्ट्स को छिपाते हुए प्रस्तुति को PDF में एक्सपोर्त करता है:

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

स्लाइड को बिटमैप इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छिपाने के लिये, [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) को कॉन्फ़िगर करें और रेंडरिंग विकल्पों को [ISlide.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) में पास करें।

निम्नलिखित Java उदाहरण पहला स्लाइड PNG इमेज के रूप में इंक ऑब्जेक्ट्स के बिना रेंडर करता है:

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

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) सेटिंग निर्धारित करती है कि इंक ब्रशेस को रेंडर करते समय मास्क ऑपरेशन्स को कैसे व्याख्यायित किया जाए। डिफ़ॉल्ट मान `true` है, जो अपारदर्शिता का उपयोग करता है। ROP ऑपरेशन का उपयोग करने के लिये, इसे `false` के साथ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) को कॉल करें।

निम्नलिखित Java उदाहरण स्लाइड को SVG में एक्सपोर्ट करता है और इंक मास्क ऑपरेशन्स के लिये ROP-आधारित रेंडरिंग का उपयोग करता है:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

इसी सेटिंग को [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) के माध्यम से भी लागू किया जा सकता है जब प्रस्तुति को एक्सपोर्ट किया जाता है या स्लाइड को TIFF में रेंडर किया जाता है।

### **इंक को छिपाना या संरक्षित करना चुनें**

जब आपको वितरण के लिये एनोटेटेड प्रस्तुति का साफ़ संस्करण चाहिए बिना रिव्यू मार्क्स के, तो एक्सपोर्ट के दौरान [IInkOptions.setHideInk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) को `true` के साथ कॉल करें।

यदि इंक एनोटेशन इच्छित सामग्री का भाग हैं—जैसे रिव्यू कमेंट्स, हाथ से लिखे नोट्स, हाइलाइट्स, या ड्रॉइंग्स—तो [IInkOptions.getHideInk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) को डिफ़ॉल्ट `false` पर रखें। इससे एप्लिकेशन एक ही प्रस्तुति से अलग-अलग रिव्यू और फाइनल आउटपुट उत्पन्न कर सकते हैं बिना स्रोत इंक ऑब्जेक्ट्स को बदले।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक का रंग या आकार बदल सकता हूँ?**

हाँ। [IInk.getTraces](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iink/#getTraces--) से ट्रेस प्राप्त करें, फिर उसके [IInkTrace.getBrush](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinktrace/#getBrush--) को बदलें। रंग बदलने के लिये [IInkBrush.setColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) या आकार बदलने के लिये [IInkBrush.setSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) को कॉल करें।

**क्या इंक को छिपाने से स्रोत प्रस्तुति बदलती है?**

नहीं। [IInkOptions.setHideInk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) केवल रेंडर या एक्सपोर्ट परिणाम को प्रभावित करता है; यह स्रोत प्रस्तुति में इंक ऑब्जेक्ट्स को हटाता या संशोधित नहीं करता।

**कौन से एक्सपोर्ट फ़ॉर्मेट इंक विकल्पों का समर्थन करते हैं?**

आप PDF, HTML, SVG, TIFF, और बिटमैप स्लाइड इमेज के लिये ऊपर दिखाए गए संबंधित एक्सपोर्ट या रेंडरिंग विकल्पों के माध्यम से इंक विकल्प कॉन्फ़िगर कर सकते हैं।

**अतिरिक्त पढ़ाई**

* आकृतियों के बारे में सामान्य जानकारी के लिये, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/androidjava/powerpoint-shapes/) अनुभाग।
* प्रभावी मानों के बारे में अधिक जानकारी के लिये, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/androidjava/shape-effective-properties/#get-effective-font-height-value)।
* PDF एक्सपोर्ट के विवरण के लिये, देखें [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hi/androidjava/convert-powerpoint-to-pdf/)।
* HTML एक्सपोर्ट के विवरण के लिये, देखें [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hi/androidjava/convert-powerpoint-to-html/)।
* SVG एक्सपोर्ट के विवरण के लिये, देखें [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hi/androidjava/render-a-slide-as-an-svg-image/)।
* TIFF एक्सपोर्ट के विवरण के लिये, देखें [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hi/androidjava/convert-powerpoint-to-tiff/)।
* स्लाइड‑से‑इमेज रेंडरिंग के विवरण के लिये, देखें [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hi/androidjava/convert-slide/).