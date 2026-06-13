---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में इमेज प्रबंधन को अनुकूलित करें
linktitle: इमेज प्रबंधन करें
type: docs
weight: 10
url: /hi/nodejs-java/image/
keywords:
- इमेज जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- इमेज बदलें
- चित्र बदलें
- वेब से
- बैकग्राउंड
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- EMF
- SVG
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के साथ PowerPoint और OpenDocument में इमेज प्रबंधन को सुव्यवस्थित करें, प्रदर्शन को अनुकूलित करें और कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियाँ प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइल, इंटरनेट या अन्य स्थानों से चित्रों को स्लाइड्स पर सम्मिलित कर सकते हैं। इसी प्रकार, Aspose.Slides विभिन्न तरीकों से आपके प्रस्तुतियों में स्लाइड्स में छवियों को जोड़ने की सुविधा देता है।

{{% alert  title="Tip" color="primary" %}} 

Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से शीघ्रता से प्रस्तुतियाँ बनाने की अनुमति देते हैं। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप छवि को फ्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप इसका आकार बदलने, प्रभाव जोड़ने आदि के लिए मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बनाते हैं—तो देखें [चित्र फ़्रेम](https://docs.aspose.com/slides/hi/nodejs-java/picture-frame/)। 

{{% /alert %}} 

Aspose.Slides इन लोकप्रिय फ़ॉर्मैट्स—JPEG, PNG, GIF और अन्य—में छवियों के साथ संचालन को समर्थन देता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ना**

आप अपने कंप्यूटर से एक या कई छवियों को प्रस्तुति की स्लाइड पर जोड़ सकते हैं। नीचे दिया गया जावास्क्रिप्ट नमूना कोड आपको दिखाता है कि कैसे एक छवि को स्लाइड में जोड़ा जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **स्ट्रीम से छवियों को स्लाइड्स में जोड़ना**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर में उपलब्ध नहीं है, तो आप उसे सीधे वेब से जोड़ सकते हैं। 

यह नमूना कोड आपको जावास्क्रिप्ट में वेब से छवि को स्लाइड में जोड़ना दर्शाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // एक एक्सेल फ़ाइल को स्ट्रीम में लोड करता है
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // एम्बेड करने के लिए डेटा ऑब्जेक्ट बनाता है
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Ole ऑब्जेक्ट फ़्रेम शैप जोड़ता है
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **स्लाइड मास्टर में छवियों को जोड़ना**

स्लाइड मास्टर वह शीर्ष स्लाइड है जो नीचे की सभी स्लाइड्स की जानकारी (थीम, लेआउट आदि) को संग्रहीत और नियंत्रित करती है। इसलिए, जब आप स्लाइड मास्टर में छवि जोड़ते हैं, वह छवि उस मास्टर के अंतर्गत सभी स्लाइड्स में दिखाई देती है। 

यह जावास्क्रिप्ट नमूना कोड आपको दिखाता है कि कैसे एक छवि को स्लाइड मास्टर में जोड़ा जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **छवियों को स्लाइड बैकग्राउंड के रूप में जोड़ना**

आप एक विशिष्ट स्लाइड या कई स्लाइड्स के लिए चित्र को बैकग्राउंड के रूप में उपयोग करने का निर्णय ले सकते हैं। ऐसे में आपको *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/hi/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* देखना चाहिए।

## **प्रेजेंटेशन में SVG जोड़ना**
आप प्रस्तुति में किसी भी छवि को जोड़ या सम्मिलित कर सकते हैं, इसके लिए आप [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) क्लास की [addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) मेथड का उपयोग कर सकते हैं। 

SVG छवि के आधार पर एक इमेज ऑब्जेक्ट बनाने के लिए आप इसे इस प्रकार कर सकते हैं:

1. ImageShapeCollection में सम्मिलित करने के लिए SvgImage ऑब्जेक्ट बनाएं  
2. ISvgImage से PPImage ऑब्जेक्ट बनाएं  
3. PPImage क्लास का उपयोग करके PictureFrame ऑब्जेक्ट बनाएं  

यह नमूना कोड आपको दिखाता है कि उपर्युक्त चरणों को कैसे लागू करके प्रस्तुति में SVG छवि जोड़ी जाए:

```javascript
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SVG को शैप्स के सेट में बदलना**
Aspose.Slides में SVG को शैप्स के सेट में बदलना PowerPoint की SVG छवियों को संभालने की कार्यक्षमता के समान है:

![PowerPoint पॉपअप मेनू](img_01_01.png)

यह कार्यक्षमता [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) क्लास की [addGroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो पहले तर्क के रूप में एक [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SvgImage) ऑब्जेक्ट लेती है।

यह नमूना कोड आपको दिखाता है कि वर्णित मेथड का उपयोग करके SVG फ़ाइल को शैप्स के सेट में कैसे परिवर्तित किया जाए:

```javascript
// नई प्रस्तुति बनाएं
var presentation = new aspose.slides.Presentation();
try {
    // SVG फ़ाइल की सामग्री पढ़ें
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // SvgImage ऑब्जेक्ट बनाएं
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // स्लाइड आकार प्राप्त करें
    var slideSize = presentation.getSlideSize().getSize();
    // SVG छवि को शैप्स के समूह में बदलें और इसे स्लाइड आकार के अनुसार स्केल करें
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **स्लाइड्स में EMF के रूप में छवियों को जोड़ना**
Aspose.Slides for Node.js via Java आपको Excel शीट्स से EMF छवियों को जनरेट करने और उन्हें Aspose.Cells के साथ स्लाइड्स में EMF के रूप में जोड़ने की सुविधा देता है।  

यह नमूना कोड आपको बताएगा कि कैसे वर्णित कार्य किया जाए:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **इमेज कलेक्शन में छवियों को बदलना**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन (जिसमें स्लाइड शैप्स द्वारा उपयोग की गई छवियां शामिल हैं) में संग्रहीत छवियों को बदलने की अनुमति देता है। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीके दर्शाता है। API उन विधियों को प्रदान करता है जिनसे आप कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में मौजूदा किसी अन्य छवि का उपयोग करके छवि को बदल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके उन छवियों वाली प्रस्तुति फ़ाइल लोड करें।  
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।  
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।  
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और उस ऑब्जेक्ट से लक्ष्य छवि को बदलें।  
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद किसी छवि से बदलें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

```js
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें।
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // पहला तरीका।
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // दूसरा तरीका।
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // तीसरा तरीका।
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose FREE [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर का उपयोग करके आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं, टेक्स्ट से GIF बना सकते हैं, आदि। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**इसे सम्मिलित करने के बाद मूल छवि रेज़ोल्यूशन बरकरार रहता है क्या?**  
हां। स्रोत पिक्सेल संरक्षित रहते हैं, पर अंतिम रूप इस पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/nodejs-java/picture-frame/) को कैसे स्केल किया गया है और सेव करने पर कौन-सी संपीड़न लागू हुई है।

**एक साथ दर्जनों स्लाइड्स में समान लोगो को बदलने का सर्वोत्तम तरीका क्या है?**  
लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति के इमेज कलेक्शन में बदलें—अपडेट्स उन सभी तत्वों तक पहुँचेंगे जो उस रिसोर्स का उपयोग करते हैं।

**क्या डाली गई SVG को संपादन योग्य शैप्स में बदल जा सकता है?**  
हां। आप SVG को शैप्स के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक शैप गुणों से संपादन योग्य हो जाते हैं।

**मैं कई स्लाइड्स के लिए एक साथ चित्र को बैकग्राउंड कैसे सेट कर सकता हूँ?**  
[इमेज को बैकग्राउंड के रूप में असाइन करें](/slides/hi/nodejs-java/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—जो भी स्लाइड्स उस मास्टर/लेआउट का उपयोग करती हैं, वे बैकग्राउंड को विरासत में प्राप्त करेंगी।

**कई चित्रों के कारण प्रस्तुति का आकार बड़े होने से मैं कैसे बचाऊँ?**  
डुप्लिकेट के बजाय एक ही इमेज रिसोर्स को पुनः प्रयोग करें, उचित रेज़ोल्यूशन चुनें, सेव करने पर संपीड़न लागू करें, और जहाँ उपयुक्त हो दोहराए गए ग्राफिक्स को मास्टर पर रखें।