---
title: जावास्क्रिप्ट में प्रस्तुति आकारों का प्रबंधन
linktitle: आकार परिवर्तन
type: docs
weight: 40
url: /hi/nodejs-java/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छुपाएँ
- आकार क्रम बदलें
- Interop आकार ID प्राप्त करें
- आकार वैकल्पिक टेक्स्ट
- आकार लेआउट फ़ॉर्मैट
- आकार SVG रूप में
- SVG में आकार
- आकार संरेखित करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js via Java का उपयोग करके आकार बनाना, संपादित करना और अनुकूलित करना सीखें और उच्च-प्रदर्शन PowerPoint प्रस्तुतियां प्रदान करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में आकारों के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड पर आकार को कैसे खोजें, उसे क्लोन करें, हटाएँ, छुपाएँ, उसका क्रम बदलें, उसका Interop shape ID प्राप्त करें, और पहचान तथा आगे की प्रक्रिया के लिए वैकल्पिक टेक्स्ट सेट करें।

यह आकारों के लेआउट फ़ॉर्मैट तक पहुँचने, आकार को SVG के रूप में रेंडर करने, स्लाइड पर आकारों को संरेखित करने, और क्षैतिज एवं ऊर्ध्वाधर मिररिंग के लिए फ़्लिप प्रॉपर्टीज़ का उपयोग करने के बारे में भी बताता है। अतिरिक्त रूप से, लेख में आकार संयोजन, स्टैकिंग क्रम, और आकार लॉकिंग से संबंधित एक छोटा FAQ शामिल है।

## **स्लाइड में आकार खोजें**
यह विषय स्लाइड पर किसी विशिष्ट आकार को उसके आंतरिक Id के बिना खोजने की एक सरल तकनीक वर्णन करता है। यह जानना आवश्यक है कि PowerPoint प्रस्तुतियों में स्लाइड पर आकारों की पहचान के लिए कोई अन्य तरीका नहीं है सिवाय आंतरिक विशिष्ट Id के। डेवलपर्स के लिए आंतरिक Id से आकार खोजने में कठिनाई होती है। सभी जोड़े गए आकारों में कुछ वैकल्पिक टेक्स्ट होता है। हम डेवलपर्स को सुझाव देते हैं कि वे विशिष्ट आकार खोजने के लिए वैकल्पिक टेक्स्ट का उपयोग करें। आप भविष्य में बदलने वाले ऑब्जेक्ट्स के लिए MS PowerPoint में वैकल्पिक टेक्स्ट परिभाषित कर सकते हैं।

किसी भी इच्छित आकार का वैकल्पिक टेक्स्ट सेट करने के बाद, आप Aspose.Slides for Node.js via Java का उपयोग करके प्रस्तुति खोल सकते हैं और स्लाइड में जोड़े गए सभी आकारों के माध्यम से इटररेट कर सकते हैं। प्रत्येक इटरशन में आप आकार के वैकल्पिक टेक्स्ट की जाँच कर सकते हैं और मिलते‑जुलते वैकल्पिक टेक्स्ट वाला आकार वही होगा जिसकी आपको आवश्यकता है। इस तकनीक को बेहतर तरीके से दिखाने के लिए हमने एक मेथड बनाया है, [findShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) जो स्लाइड में विशिष्ट आकार खोज कर उसे लौटाता है।

```javascript
// एक Presentation क्लास का उदाहरण बनाता है जो प्रस्तुति फ़ाइल को दर्शाता है
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // खोजे जाने वाले आकार का वैकल्पिक टेक्स्ट
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **आकार क्लोन करें**
Aspose.Slides for Node.js via Java का उपयोग करके किसी आकार को स्लाइड में क्लोन करने के लिए:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

नीचे दिया गया उदाहरण एक समूह आकार को स्लाइड में जोड़ता है।

```javascript
// Presentation क्लास को इंस्टैंसिएट करें
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकार हटाएँ**
Aspose.Slides for Node.js via Java डेवलपर्स को किसी भी आकार को हटाने की सुविधा देता है। किसी स्लाइड से आकार हटाने के लिए नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Remove the shape.
1. Save file to disk.

```javascript
// Presentation ऑब्जेक्ट बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // आयत प्रकार का ऑटोशेप जोड़ें
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकार छुपाएँ**
Aspose.Slides for Node.js via Java डेवलपर्स को किसी भी आकार को छुपाने की सुविधा देता है। किसी स्लाइड से आकार छुपाने के लिए नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Hide the shape.
1. Save file to disk.

```javascript
// PPTX को दर्शाने वाली Presentation क्लास का उदाहरण बनाएँ
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // आयत प्रकार का ऑटोशेप जोड़ें
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकारों का क्रम बदलें**
Aspose.Slides for Node.js via Java डेवलपर्स को आकारों का क्रम बदलने की सुविधा देता है। क्रम बदलने से यह निर्धारित होता है कि कौन सा आकार सामने है या पीछे है। किसी स्लाइड से आकार का क्रम बदलने के लिए नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Add a shape.
1. Add some text in shape's text frame.
1. Add another shape with the same co-ordinates.
1. Reorder the shapes.
1. Save file to disk.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Interop Shape ID प्राप्त करें**
Aspose.Slides for Node.js via Java डेवलपर्स को स्लाइड स्तर पर एक विशिष्ट आकार पहचानकर्ता (Interop Shape ID) प्राप्त करने की सुविधा देता है, जो [getUniqueId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getUniqueId--) मेथड के विपरीत है। मेथड [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) को [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape) क्लास में जोड़ा गया है। इस मेथड द्वारा लौटाया गया मान Microsoft.Office.Interop.PowerPoint.Shape ऑब्जेक्ट के Id के मान के समान है। नीचे एक नमूना कोड दिया गया है।

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // स्लाइड स्कोप में विशिष्ट आकार पहचानकर्ता प्राप्त करना
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकार के लिए वैकल्पिक टेक्स्ट सेट करें**
Aspose.Slides for Node.js via Java डेवलपर्स को किसी भी आकार के AlternateText को सेट करने की सुविधा देता है। प्रस्तुति में आकारों को [AlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) या [Shape Name](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) मेथड द्वारा पहचाना जा सकता है। [setAlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) और [getAlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getAlternativeText--) मेथड Aspose.Slides और Microsoft PowerPoint दोनों द्वारा पढ़े या सेट किए जा सकते हैं। इस मेथड का उपयोग करके आप एक आकार को टैग कर सकते हैं और विभिन्न ऑपरेशन कर सकते हैं जैसे आकार हटाना, आकार छुपाना या स्लाइड पर आकारों का क्रम बदलना। आकार का AlternateText सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Do some work with the newly added shape.
1. Traverse through shapes to find a shape.
1. Set the AlternativeText.
1. Save file to disk.

```javascript
// PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // आयत प्रकार का ऑटोशेप जोड़ें
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकार के लिए लेआउट फ़ॉर्मेट एक्सेस करें**
Aspose.Slides for Node.js via Java आकार के लिए लेआउट फ़ॉर्मेट एक्सेस करने के लिए एक सरल API प्रदान करता है। यह लेख दर्शाता है कि आप लेआउट फ़ॉर्मेट कैसे एक्सेस कर सकते हैं।

नीचे नमूना कोड दिया गया है।

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकार को SVG के रूप में रेंडर करें**
अब Aspose.Slides for Node.js via Java आकार को SVG के रूप में रेंडर करने का समर्थन करता है। मेथड [writeAsSvg](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (और इसका ओवरलोड) को [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape) क्लास में जोड़ा गया है। यह मेथड आकार की सामग्री को SVG फ़ाइल के रूप में सहेजने की सुविधा देता है। नीचे कोड स्निपेट दिखाता है कि स्लाइड के आकार को SVG फ़ाइल में कैसे निर्यात करें।

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **आकार संरेखण**
Aspose.Slides आकारों को या तो स्लाइड मार्जिन के सापेक्ष या एक‑दूसरे के सापेक्ष संरेखित करने की सुविधा देता है। इस उद्देश्य के लिए ओवरलोडेड मेथड [SlidesUtil.alignShape()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) जोड़ा गया है। एनेमरेशन [ShapesAlignmentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapesAlignmentType) संभावित संरेखण विकल्पों को परिभाषित करता है।

**उदाहरण 1**

नीचे दिया गया स्रोत कोड आकारों के इंडेक्स 1,2 और 4 को स्लाइड की शीर्ष सीमा के साथ संरेखित करता है।

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**उदाहरण 2**

निम्न उदाहरण दिखाता है कि पूरे आकार संग्रह को संग्रह में सबसे नीचे स्थित आकार के सापेक्ष कैसे संरेखित किया जाए।

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **फ़्लिप प्रॉपर्टीज़**

Aspose.Slides में, [ShapeFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeframe/) क्लास `flipH` और `flipV` प्रॉपर्टीज़ के माध्यम से आकारों के क्षैतिज एवं ऊर्ध्वाधर मिररिंग को नियंत्रित करती है। दोनों प्रॉपर्टीज़ `byte` प्रकार की हैं, जहाँ `1` फ़्लिप दर्शाता है, `0` बिना फ़्लिप के, और `-1` डिफ़ॉल्ट व्यवहार के लिए प्रयोग किया जाता है। ये मान आकार के [Frame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getFrame) से प्राप्त किए जा सकते हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, वर्तमान स्थिति और आकार, वांछित `flipH` और `flipV` मान, तथा घूर्णन कोण के साथ एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeframe/) इंस्टेंस बनाया जाता है। इस इंस्टेंस को आकार के [Frame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getFrame) में असाइन कर प्रस्तुति सहेजने से मिरर ट्रांसफ़ॉर्मेशन लागू हो जाता है।

मान लीजिए हमारे पास sample.pptx फ़ाइल है जिसमें पहली स्लाइड में डिफ़ॉल्ट फ़्लिप सेटिंग वाला एकल आकार है, जैसा कि नीचे दिखाया गया है।

![The shape to be flipped](shape_to_be_flipped.png)

निम्न कोड उदाहरण आकार की वर्तमान फ़्लिप प्रॉपर्टीज़ को प्राप्त करता है और उसे क्षैतिज तथा ऊर्ध्वाधर दोनों रूप में फ़्लिप करता है।

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // आकार की क्षैतिज फ़्लिप प्रॉपर्टी को प्राप्त करें।
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // आकार की लंबवत फ़्लिप प्रॉपर्टी को प्राप्त करें।
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Flip horizontally.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Flip vertically.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The flipped shape](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं डेस्कटॉप एडिटर की तरह स्लाइड पर आकारों (union/intersect/subtract) को मिलाकर उपयोग कर सकता हूँ?**

ऐसी अंतर्निहित Boolean ऑपरेशन API नहीं है। आप इच्छित रूपरेखा स्वयं बनाकर इसे लगभग बना सकते हैं—उदाहरण के लिए, resulting geometry को गणना करके (via [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/geometrypath/)) नई आकार बना सकते हैं और मूल आकारों को वैकल्पिक रूप से हटा सकते हैं।

**मैं स्टैकिंग क्रम (z-order) को कैसे नियंत्रित कर सकता हूँ ताकि कोई आकार हमेशा “सर्वोच्च” रहे?**

स्लाइड के [shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getShapes) संग्रह में insertion/move क्रम बदलें। पूर्वानुमेय परिणामों के लिए सभी अन्य स्लाइड परिवर्तन समाप्त करने के बाद z-order को अंतिम रूप दें।

**क्या मैं PowerPoint में उपयोगकर्ताओं को आकार संपादित करने से रोकने के लिए “लॉक” कर सकता हूँ?**

हाँ। आकार‑स्तर की सुरक्षा फ़्लैग सेट करें (जैसे चयन, स्थानांतरण, आकार बदलना, टेक्स्ट संपादन को लॉक करना)। आवश्यकता होने पर मास्टर या लेआउट पर प्रतिबंध लागू करें। ध्यान दें कि यह UI‑स्तर की सुरक्षा है, पूर्ण सुरक्षा के लिये फ़ाइल‑स्तर प्रतिबंध जैसे [read‑only recommendations or passwords](/slides/hi/nodejs-java/password-protected-presentation/) के साथ संयोजन करें।