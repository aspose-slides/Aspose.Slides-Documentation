---
title: एंड्रॉइड पर प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/androidjava/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- सरल आयत
- स्वरूपित आयत
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके अपनी PowerPoint प्रस्तुतियों को आयतें जोड़कर बढ़ाएँ—आकृतियों को प्रोग्रामेटिक रूप से आसानी से डिज़ाइन और संशोधित करें।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयत आकार जोड़ने का तरीका दर्शाता है। यह एक साधारण आयत, स्वरूपित आयत बनाने, और अपडेटेड प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजने को कवर करता है।

आप यह भी देखेंगे कि कैसे बुनियादी आयत फ़ॉर्मेटिंग जैसे सॉलिड फ़िल कलर, लाइन कलर, और लाइन चौड़ाई लागू की जाए। इसके अतिरिक्त, लेख का FAQ आयत से संबंधित कार्यों की ओर संकेत करता है, जिनमें गोल किनारे, चित्र फ़िल, विज़ुअल इफ़ेक्ट, हाइपरलिंक, आकार लॉक, निर्यात विकल्प, और प्रभावी गुण शामिल हैं।

## **स्लाइड में आयत जोड़ें**
स्लाइड की चयनित प्रस्तुति में एक साधारण आयत जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Create an instance of [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

नीचे दिए गए उदाहरण में हमने प्रस्तुति की पहली स्लाइड में एक साधारण आयत जोड़ी है।

```java
// PPTX को दर्शाने वाली Presentation क्लास का उदाहरण बनाएँ
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // ellipse प्रकार का AutoShape जोड़ें
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्लाइड में स्वरूपित आयत जोड़ें**
स्लाइड में स्वरूपित आयत जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Create an instance of [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) object.
- Set the [Fill Type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FillType) of the Rectangle to Solid.
- Set the Color of the Rectangle using [SolidFillColor.setColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) method as exposed by [IFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFillFormat) object associated with the [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape) object.
- Set the Color of the lines of the Rectangle.
- Set the Width of the lines of the Rectangle.
- Write the modified presentation as PPTX file.

उपरोक्त चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // ellipse प्रकार का AutoShape जोड़ें
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // ellipse आकार पर कुछ स्वरूपण लागू करें
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // ellipse की लाइन पर कुछ स्वरूपण लागू करें
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं गोल किनारों वाली आयत कैसे जोड़ सकता हूँ?**

Use the rounded-corner [shape type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapetype/) and adjust the corner radius in the shape’s properties; rounding can also be applied per corner via geometry adjustments.

**मैं आयत को चित्र (टेक्सचर) से कैसे भरूँ?**

Select the picture [fill type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/), provide the image source, and configure [stretching/tiling modes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillmode/).

**क्या आयत में शेडो और ग्लो हो सकता है?**

Yes. [Outer/inner shadow, glow, and soft edges](/slides/hi/androidjava/shape-effect/) are available with adjustable parameters.

**क्या मैं आयत को हाइपरलिंक के साथ बटन में बदल सकता हूँ?**

Yes. [Assign a hyperlink](/slides/hi/androidjava/manage-hyperlinks/) to the shape click (jump to a slide, file, web address, or e-mail).

**मैं आयत को स्थान बदलने और परिवर्तन से कैसे बचा सकता हूँ?**

Use shape locks: you can forbid moving, resizing, selection, or text editing to preserve the layout.

**क्या मैं आयत को रास्टर इमेज या SVG में बदल सकता हूँ?**

Yes. You can [render the shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) to an image with a specified size/scale or [export it as SVG](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) for vector use.

**मैं थीम और विरासत को ध्यान में रखकर आयत के वास्तविक (प्रभावी) गुण जल्दी से कैसे प्राप्त करूँ?**

[Use the shape’s effective properties](/slides/hi/androidjava/shape-effective-properties/): the API returns computed values that account for theme styles, layout, and local settings, simplifying formatting analysis.