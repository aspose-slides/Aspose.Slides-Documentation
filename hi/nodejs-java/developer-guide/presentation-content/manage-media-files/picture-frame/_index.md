---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम्स प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/nodejs-java/picture-frame/
keywords:
  - चित्र फ्रेम
  - चित्र फ्रेम जोड़ें
  - चित्र फ्रेम बनाएं
  - छवि जोड़ें
  - छवि बनाएं
  - छवि निकालें
  - रास्टर छवि
  - वेक्टर छवि
  - छवि क्रॉप करें
  - क्रॉप किया हुआ क्षेत्र
  - StretchOff प्रॉपर्टी
  - चित्र फ्रेम फ़ॉर्मेटिंग
  - चित्र फ्रेम प्रोपर्टी
  - सापेक्ष स्केल
  - छवि प्रभाव
  - आस्पेक्ट रेशियो
  - छवि पारदर्शिता
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सुव्यवस्थित करें और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

Picture Frame एक ऐसा आकार है जो छवि को समाहित करता है—यह फ्रेम में पड़ी तस्वीर जैसा है।

आप एक स्लाइड में चित्र फ़्रेम के माध्यम से छवि जोड़ सकते हैं। इस तरह, आप चित्र फ़्रेम को फॉर्मेट करके छवि को फॉर्मेट कर सकते हैं।

{{% alert  title="टिप" color="primary" %}} 

Aspose मुफ्त कनवर्टर्स—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—प्रदान करता है जिससे लोग छवियों से तेजी से प्रस्तुतियाँ बना सकते हैं। 

{{% /alert %}} 

## **Picture Frame बनाना**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।  
2. उसके इंडेक्स के द्वारा स्लाइड का रेफ़रेंसम प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट से जुड़े [ImagesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) में छवि जोड़कर एक `PPImage` ऑब्जेक्ट बनाएं, जिसे आकार को भरने में उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्धारित करें।  
5. संदर्भित स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा प्रदान किए गए `addPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFrame) बनाएं।  
6. स्लाइड में picture frame (जिसमें तस्वीर है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड दिखाता है कि picture frame कैसे बनाते हैं:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // Image क्लास को इंस्टैंशिएट करता है
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // चित्र की समतुल्य ऊँचाई और चौड़ाई के साथ एक picture frame जोड़ता है
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

Picture frames आपको छवियों के आधार पर जल्दी से प्रस्तुति स्लाइड बनाने में मदद करते हैं। जब आप picture frame को Aspose.Slides की save options के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित करके एक फॉर्मेट से दूसरे फॉर्मेट में छवियों को बदल सकते हैं।

## **रिलेटिव स्केल के साथ Picture Frame बनाना**

छवि के रिलेटिव स्केल को बदलकर आप एक अधिक जटिल picture frame बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।  
2. उसके इंडेक्स के द्वारा स्लाइड का रेफ़रेंसम प्राप्त करें।  
3. प्रस्तुति की image collection में एक छवि जोड़ें।  
4. प्रस्तुति ऑब्जेक्ट से जुड़े [ImagesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) में छवि जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं, जिसे आकार को भरने में उपयोग किया जाएगा।  
5. picture frame में छवि की रिलेटिव चौड़ाई और ऊँचाई निर्धारित करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड दिखाता है कि रिलेटिव स्केल के साथ picture frame कैसे बनाते हैं:

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // Image क्लास को इंस्टैंशिएट करें
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ें
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट करना
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

## **Picture Frames से रास्टर छवियों को निकालना**

आप [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFrame) ऑब्जेक्ट्स से रास्टर छवियाँ निकाल सकते हैं और उन्हें PNG, JPG और अन्य फॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे दस्तावेज़ “sample.pptx” से एक छवि निकाली जाए और उसे PNG फॉर्मेट में सहेजा जाए।

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

## **Picture Frames से SVG छवियों को निकालना**

जब किसी प्रस्तुति में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) आकारों के भीतर रखे होते हैं, तो Aspose.Slides for Node.js via Java आपको मूल वेक्टर छवियों को पूरी सटीकता के साथ प्राप्त करने देता है। स्लाइड की shape collection को ट्रैवर्स करके, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसकी मूल SVG फॉर्मेट में डिस्क या स्ट्रीम पर सहेज सकते हैं।

निम्न कोड उदाहरण दर्शाता है कि picture frame से SVG छवि कैसे निकालते हैं:

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

## **छवि की ट्रांसपेरेंसी प्राप्त करना**

Aspose.Slides आपको छवि पर लागू ट्रांसपेरेंसी इफ़ेक्ट प्राप्त करने की सुविधा देता है। यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

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

## **छवि की ब्राइटनेस और कंट्रास्ट प्राप्त करना**

Aspose.Slides आपको छवि पर लागू ब्राइटनेस और कंट्रास्ट इफ़ेक्ट प्राप्त करने की सुविधा देता है। [Luminance](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/luminance/) क्लास इस छवि ट्रांसफ़ॉर्म इफ़ेक्ट का प्रतिनिधित्व करता है।

यह JavaScript कोड picture frame से ब्राइटनेस और कंट्रास्ट सेटिंग्स प्राप्त करने को दर्शाता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Picture Frame फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें picture frame पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके, आप picture frame को विशिष्ट आवश्यकताओं के अनुरूप बदल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।  
2. उसके इंडेक्स के द्वारा स्लाइड का रेफ़रेंसम प्राप्त करें।  
3. प्रस्तुति के साथ जुड़े [ImagesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) में छवि जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं, जिसे shape को भरने के लिये उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्धारित करें।  
5. [addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) मेथड द्वारा [Shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट से छवि की चौड़ाई‑ऊँचाई के आधार पर एक `PictureFrame` बनाएं।  
6. स्लाइड में picture frame (जिसमें तस्वीर है) जोड़ें।  
7. picture frame की लाइन रंग सेट करें।  
8. picture frame की लाइन चौड़ाई सेट करें।  
9. picture frame को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को घड़ी की उल्टी दिशा में घुमाता है।  
10. picture frame (जिसमें तस्वीर है) को फिर से स्लाइड में जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड picture frame फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // Image क्लास को इंस्टैंशिएट करता है
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

{{% alert title="टिप" color="primary" %}}

Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी भी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मर्ज करना हो, या [फोटो ग्रिड बनाना हो](https://products.aspose.app/slides/hi/collage/photo-grid), तो आप इस सेवा का उपयोग कर सकते हैं। 

{{% /alert %}}

## **लिंक के रूप में छवि जोड़ना**

बड़ी प्रस्तुति आकार को कम रखने के लिये, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियाँ (या वीडियो) जोड़ सकते हैं। यह JavaScript कोड आपको एक placeholder में छवि और वीडियो जोड़ना दिखाता है:

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

## **छवि क्रॉप करना**

यह JavaScript कोड आपको स्लाइड पर मौजूदा छवि को क्रॉप करने का तरीका दिखाता है:

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
    // छवि को क्रॉप करता है (प्रतिशत मान)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // परिणाम को सहेजता है
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Picture के क्रॉप किए गए क्षेत्रों को हटाना**

यदि आप फ़्रेम में मौजूद छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // पहली स्लाइड से PictureFrame प्राप्त करता है
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // परिणाम को सहेजता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई छवि को प्रस्तुति की image collection में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) में उपयोग होती है, तो यह सेटअप प्रस्तुति आकार को घटा सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ जाएगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटाफाइल को रास्टर PNG छवि में बदल देता है। 

{{% /alert %}}

## **छवियों को संपीड़ित करना**

आप प्रस्तुति में एक चित्र को [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके संपीड़ित कर सकते हैं। यह मेथड आकार को shape के आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर कम करता है, और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाने की सुविधा देता है।

यह PowerPoint के **Picture Format → Compress Pictures → Resolution** फीचर के समान ही चित्र का आकार और रिज़ॉल्यूशन समायोजित करता है।

निम्न JavaScript उदाहरण दर्शाते हैं कि लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को कैसे संपीड़ित किया जाए:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ संकुचित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // संकुचन के परिणाम की जाँच करें।
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

या किसी अन्य पूर्वनिर्धारित DPI मान का उपयोग करके:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // छवि को 96 DPI (ईमेल रिज़ॉल्यूशन) पर संकुचित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

यह मेथड shape के आकार और दिए गए DPI के आधार पर छवि को निम्न रिज़ॉल्यूशन में बदल देता है। फ़ाइल आकार को अनुकूलित करने के लिये क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है। यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं होगा। JPEG की गुणवत्ता भी रिज़ॉल्यूशन के अनुसार बनाए रखी या हल्की घटाई जाएगी, बिल्कुल PowerPoint की तरह।

{{% /alert %}}

## **आस्पेक्ट रेशियो को लॉक करना**

यदि आप चाहते हैं कि छवि वाले shape का आस्पेक्ट रेशियो, छवि के आयाम बदलने के बाद भी बरकरार रहे, तो आप [setAspectRatioLocked](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं।

यह JavaScript कोड दिखाता है कि shape के आस्पेक्ट रेशियो को कैसे लॉक किया जाए:

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
    // रीसाइज़ पर आकार का आस्पेक्ट रेशियो बरकरार रखने के लिये shape सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल shape के आस्पेक्ट रेशियो को संरक्षित करती है, न कि उसके भीतर की छवि को।

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करना**

[PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat) क्लास की [setStretchOffsetLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) और [setStretchOffsetBottom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) मेथड्स का उपयोग करके, आप एक fill rectangle निर्दिष्ट कर सकते हैं।

जब किसी छवि के लिये स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत rectangle को निर्दिष्ट fill rectangle में फिट करने के लिये स्केल किया जाता है। fill rectangle के प्रत्येक किनारे को shape के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। सकारात्मक प्रतिशत एक इनसेट दर्शाता है जबकि नकारात्मक प्रतिशत एक आउटसेट दर्शाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।  
2. उसके इंडेक्स के द्वारा स्लाइड का रेफ़रेंसम प्राप्त करें।  
3. एक rectangle `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. shape की fill प्रकार सेट करें।  
6. shape की picture fill मोड सेट करें।  
7. shape को भरने के लिये छवि सेट करें।  
8. shape के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्धारित करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड दर्शाता है कि StretchOff प्रॉपर्टी कैसे उपयोग की जाती है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // ImageEx क्लास को इंस्टैंशिएट करता है
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Rectangle के रूप में AutoShape जोड़ता है
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // shape की fill प्रकार सेट करता है
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // shape की picture fill मोड सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // shape को भरने के लिये छवि सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // shape के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्धारित करता है
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

## **FAQ**

**मैं कैसे पता करूँ कि PictureFrame के लिये कौन‑से छवि फॉर्मेट समर्थित हैं?**

Aspose.Slides दोनों रास्टर छवियों (PNG, JPEG, BMP, GIF, आदि) और वेक्टर छवियों (जैसे SVG) को सपोर्ट करता है, जो एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) को असाइन किए गए image ऑब्जेक्ट के माध्यम से उपलब्ध होते हैं। समर्थित फॉर्मेट की सूची सामान्यतः स्लाइड और इमेज कनवर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

**दर्जनों बड़े चित्र जोड़ने से PPTX आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति आकार घटता है, लेकिन बाहरी फ़ाइलों को सुपलब्ध रखना आवश्यक होता है। Aspose.Slides लिंक के द्वारा छवियों को जोड़ने की सुविधा देता है जिससे फ़ाइल आकार कम रहता है।

**मैं कैसे एक छवि ऑब्जेक्ट को आकस्मिक मूव/रिसाइज़ से लॉक कर सकता हूँ?**

[shape locks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) का उपयोग करके आप एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) (जैसे मूव या रिसाइज़ निष्क्रिय करना) को लॉक कर सकते हैं। यह लॉकिंग तंत्र विभिन्न shape प्रकारों के लिये समर्थित है, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) भी शामिल है।

**क्या PDF/छवियों में निर्यात करते समय SVG वेक्टर फिडेलिटी बरकरार रहती है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप [PDF में निर्यात](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) या [रास्टर फॉर्मेट](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में निर्यात करते हैं, तो सेटिंग्स के आधार पर परिणाम रास्टराइज़ हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत रहने की पुष्टि एक्सट्रैक्शन व्यवहार से होती है।