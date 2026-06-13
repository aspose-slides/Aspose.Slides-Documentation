---
title: जावास्क्रिप्ट का उपयोग कर प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/nodejs-java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- चित्र जोड़ें
- चित्र बनाएं
- चित्र निकालें
- रास्टर चित्र
- वेक्टर चित्र
- चित्र को क्रॉप करें
- क्रॉप्ड क्षेत्र
- StretchOff प्रॉपर्टी
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- पिक्चर फ्रेम गुण
- रिलेटिव स्केल
- चित्र प्रभाव
- अनुपात
- चित्र पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइन को बेहतर बनाएं।"
---
## **परिचय**

एक picture frame वह आकार है जो एक छवि को समाहित करता है—यह एक फ्रेम में चित्र की तरह है।

आप एक picture frame के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस तरह, आप picture frame को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert title="सलाह" color="primary" %}} 

Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रस्तुति बनाने में मदद करते हैं। 

{{% /alert %}} 

## **चित्र फ्रेम बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग की एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `PPImage` ऑब्जेक्ट बनाएं, जिससे प्रस्तुति ऑब्जेक्ट से जुड़े [ImagesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) में एक छवि जोड़कर आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. रेफ़रेंस किए गए स्लाइड के shape ऑब्जेक्ट द्वारा प्रदान किए गए `addPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFrame) बनाएं।  
6. स्लाइड में एक picture frame (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह JavaScript कोड आपको दिखाता है कि कैसे एक picture frame बनाएं:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // Image क्लास बनाता है
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // चित्र की समान ऊँचाई और चौड़ाई के साथ picture frame जोड़ता है
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

picture frames आपको छवियों के आधार पर जल्दी से प्रस्तुति स्लाइड बनाने की अनुमति देते हैं। जब आप picture frame को Aspose.Slides के save विकल्पों के साथ मिलाते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित करके छवियों को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में परिवर्तित कर सकते हैं।

## **रिलेटिव स्केल के साथ चित्र फ्रेम बनाएं**

छवि के रिलेटिव स्केल को बदलकर, आप एक अधिक जटिल picture frame बना सकते हैं।  

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग की एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ें।  
4. `PPImage` ऑब्जेक्ट बनाएं, जिससे प्रस्तुति ऑब्जेक्ट से जुड़े [ImagesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) में एक छवि जोड़कर आकार को भरने के लिए उपयोग किया जाएगा।  
5. picture frame में छवि की रिलेटिव चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह JavaScript कोड आपको दिखाता है कि कैसे रिलेटिव स्केल के साथ picture frame बनाएं:

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // Image क्लास को इंस्टैंसिएट करें
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ें
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट कर रहा है
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **picture frames से रास्टर इमेज निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFrame) ऑब्जेक्ट से रास्टर इमेज निकाल सकते हैं और उन्हें PNG, JPG और अन्य फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे दस्तावेज़ “sample.pptx” से एक इमेज निकाली जाए और PNG फ़ॉर्मेट में सहेजी जाए।

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **picture frames से SVG इमेज निकालें**

जब किसी प्रस्तुति में SVG ग्राफ़िक्स को [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) आकारों के अंदर रखा जाता है, तो Aspose.Slides for Node.js via Java आपको मूल वेक्टर इमेज को पूर्ण फ़िडेलिटी के साथ पुनः प्राप्त करने की अनुमति देता है। स्लाइड की shape कलेक्शन को ट्रैवर्स करके, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) में SVG कंटेंट है या नहीं, और फिर उस इमेज को डिस्क या स्ट्रीम में उसके नेटिव SVG फ़ॉर्मेट में सहेज सकते हैं।

निम्न कोड उदाहरण दिखाता है कि कैसे एक picture frame से SVG इमेज निकाली जाए:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **इमेज की ट्रांसपरेंसी प्राप्त करें**

Aspose.Slides आपको इमेज पर लागू ट्रांसपरेंसी इफ़ेक्ट प्राप्त करने की सुविधा देता है। यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **picture frame फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें picture frame पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके, आप picture frame को विशिष्ट आवश्यकताओं के अनुसार बदल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग की एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `PPImage` ऑब्जेक्ट बनाएं, जिससे प्रस्तुति ऑब्जेक्ट से जुड़े [ImagesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) में एक छवि जोड़कर आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. [addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) मेथड द्वारा प्रदान किए गए `PictureFrame` को छवि की चौड़ाई और ऊँचाई के आधार पर बनाएं, जो [Shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट से जुड़ा है।  
6. स्लाइड में picture frame (जिसमें चित्र है) जोड़ें।  
7. picture frame की लाइन का रंग सेट करें।  
8. picture frame की लाइन की चौड़ाई सेट करें।  
9. picture frame को एक सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को क्लॉकवाइज़ घुमाता है।  
   * नकारात्मक मान छवि को एंटी‑क्लॉकवाइज़ घुमाता है।  
10. picture frame (जिसमें चित्र है) को स्लाइड में जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह JavaScript कोड picture frame फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```javascript
// PPTX का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // Image क्लास को इंस्टैंसिएट करता है
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ता है
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PictureFrameEx पर कुछ फ़ॉर्मेटिंग लागू करता है
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="सलाह" color="primary" %}}

Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी भी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाने की आवश्यकता हो, या [फोटो से ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) हो, तो आप इस सेवा का उपयोग कर सकते हैं। 

{{% /alert %}}

## **इमेज को लिंक के रूप में जोड़ें**

प्रस्तुति का आकार बड़ा होने से बचाने के लिए, आप फाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से इमेज (या वीडियो) जोड़ सकते हैं। यह JavaScript कोड आपको दिखाता है कि कैसे एक प्लेसहोल्डर में इमेज और वीडियो जोड़ें:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **इमेज को क्रॉप करें**

यह JavaScript कोड आपको दिखाता है कि स्लाइड पर मौजूद इमेज को कैसे क्रॉप किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
// नया इमेज ऑब्जेक्ट बनाता है
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // स्लाइड में एक PictureFrame जोड़ता है
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // इमेज को क्रॉप करता है (प्रतिशत मान)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // परिणाम सहेजता है
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **picture की क्रॉप्ड एरिया हटाएं**

यदि आप फ्रेम में मौजूद इमेज के क्रॉप्ड क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप्ड इमेज या मूल इमेज लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // पहले स्लाइड से PictureFrame प्राप्त करता है
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame इमेज के क्रॉप्ड क्षेत्रों को हटाता है और क्रॉप्ड इमेज लौटाता है
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // परिणाम सहेजता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप्ड इमेज को प्रस्तुति इमेज कलेक्शन में जोड़ता है। यदि इमेज केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रस्तुति का आकार कम कर सकता है। अन्यथा, परिणामी प्रस्तुति में इमेज की संख्या बढ़ जाएगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मीटाफाइल को रास्टर PNG इमेज में बदलता है। 

{{% /alert %}}

## **इमेज कॉम्प्रेस करें**

आप प्रस्तुति में एक picture को [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके कॉम्प्रेस कर सकते हैं। यह मेथड आकार को shape के आकार और निर्दिष्ट रेज़ोल्यूशन के आधार पर कम करके इमेज को कॉम्प्रेस करता है, साथ ही क्रॉप्ड एरिया को हटाने का विकल्प भी देता है।

यह PowerPoint के **Picture Format → Compress Pictures → Resolution** फीचर के समान है।

निम्न JavaScript उदाहरण दिखाते हैं कि कैसे लक्षित रेज़ोल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप्ड एरिया हटाकर प्रस्तुति में इमेज को कॉम्प्रेस किया जाए:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ इमेज को कॉम्प्रेस करें और क्रॉप्ड क्षेत्रों को हटाएँ।
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // कॉम्प्रेशन के परिणाम की जाँच करें।
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

या एक अन्य पूर्वनिर्धारित DPI मान का उपयोग करके:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // इमेज को 96 DPI (ईमेल रिज़ॉल्यूशन) पर कॉम्प्रेस करें, क्रॉप्ड क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

यह मेथड shape के आकार और प्रदान किए गए DPI के आधार पर इमेज को कम रेज़ोल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप्ड क्षेत्रों को भी हटाया जा सकता है।  
यदि इमेज एक मीटाफाइल (WMF/EMF) या SVG है, तो कॉम्प्रेशन लागू नहीं होगा। साथ ही, JPEG क्वालिटी रेज़ोल्यूशन के आधार पर बरकरार रहती है या थोड़ा घटती है, जैसे PowerPoint उच्च‑रेज़ोल्यूशन JPEG को संभालता है।

{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करें**

यदि आप चाहते हैं कि इमेज वाला shape इमेज के आयाम बदलने के बाद भी अपना आस्पेक्ट रेशियो बनाए रखे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने के लिए [setAspectRatioLocked](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग कर सकते हैं।

यह JavaScript कोड आपके लिए दिखाता है कि कैसे shape का आस्पेक्ट रेशियो लॉक करें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // आकार को रिसाइज़िंग पर आस्पेक्ट रेशियो सुरक्षित रखने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल shape के आस्पेक्ट रेशियो को सुरक्षित रखती है, न कि उसके भीतर की इमेज को।

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat) क्लास की [setStretchOffsetLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) और [setStretchOffsetBottom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) मेथड का उपयोग करके, आप एक भराव आयत निर्दिष्ट कर सकते हैं।

जब किसी इमेज के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत आयत को निर्दिष्ट भराव आयत में फिट करने के लिए स्केल किया जाता है। भराव आयत का प्रत्येक किनारा shape की बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। एक सकारात्मक प्रतिशत इन्सेट दर्शाता है जबकि एक नकारात्मक प्रतिशत आउटसेट दर्शाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक `AutoShape` आयत जोड़ें।  
4. एक इमेज बनाएं।  
5. shape की fill टाइप सेट करें।  
6. shape की picture fill मोड सेट करें।  
7. shape को भरने के लिए सेट इमेज जोड़ें।  
8. shape की बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह JavaScript कोड दर्शाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Prseetation क्लास को इंस्टैंसिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // ImageEx क्लास को इंस्टैंसिएट करता है
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Rectangle के रूप में सेट किया गया AutoShape जोड़ता है
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // shape की fill टाइप सेट करता है
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // shape के picture fill मोड को सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // छवि को shape में भरने के लिए सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // shape की बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करता है
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**PictureFrame के लिए कौन से इमेज फ़ॉर्मेट समर्थित हैं, यह मैं कैसे जानूँ?**  

Aspose.Slides दोनों रास्टर इमेज (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेज (जैसे SVG) को उस इमेज ऑब्जेक्ट के माध्यम से समर्थन करता है जो एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) से जुड़ा है। समर्थित फ़ॉर्मेट की सूची आम तौर पर स्लाइड और इमेज रूपांतरण इंजन की क्षमताओं के साथ ओवरलैप करती है।

**दसों बड़ी इमेज जोड़ने से PPTX का आकार और प्रदर्शन कैसे प्रभावित होगा?**  

बड़ी इमेज को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; इमेज को लिंक के माध्यम से जोड़ने से प्रस्तुति का आकार छोटा रहता है लेकिन बाहरी फ़ाइलों को एक्सेसिबल रखना आवश्यक होता है। Aspose.Slides लिंक द्वारा इमेज जोड़ने की सुविधा प्रदान करता है ताकि फ़ाइल आकार कम किया जा सके।

**मैं इमेज ऑब्जेक्ट को अनजाने में मूव/रीसाइज़ होने से कैसे लॉक करूँ?**  

एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) के लिए आप [shape locks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) का उपयोग कर सकते हैं (जैसे मूविंग या रीไซज़िंग को डिसेबल करना)। यह लॉकिंग मैकेनिज़्म विभिन्न shape प्रकारों के लिए समर्थित है, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) भी शामिल है।

**PDF/इमेज में प्रस्तुति एक्सपोर्ट करने पर क्या SVG वेक्टर फ़िडेलिटी बनी रहती है?**  

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप [PDF में एक्सपोर्ट](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) या [रास्टर फ़ॉर्मेट्स](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में बदलते हैं, तो एक्सपोर्ट सेटिंग्स के आधार पर परिणाम रास्टराइज़ हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहित होने की पुष्टि एक्सट्रैक्शन व्यवहार से होती है।