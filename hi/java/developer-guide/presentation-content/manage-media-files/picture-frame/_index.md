---
title: जावा का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम को प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि को क्रॉप करें
- क्रॉप किया हुआ क्षेत्र
- StretchOff प्रॉपर्टी
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- पिक्चर फ्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने वर्कफ़्लो को सुगम बनाएँ और स्लाइड डिज़ाइन को बेहतर बनाएं।"
---
## **परिचय**

एक पिक्चर फ्रेम एक आकार है जो एक छवि को सम्मिलित करता है—यह फ्रेम में एक तस्वीर की तरह है।

आप एक स्लाइड में पिक्चर फ्रेम के माध्यम से छवि जोड़ सकते हैं। इस तरह, आप पिक्चर फ्रेम को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="primary" %}} 

Aspose मुफ्त कन्वर्टर्स प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से तेज़ी से प्रस्तुतियाँ बनाने की अनुमति देते हैं। 

{{% /alert %}} 

## **पिक्चर फ्रेम बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) वर्ग की एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रेजेंटेशन ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage]() ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. संदर्भित स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा प्रदर्शित `AddPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PictureFrame) बनाएं।  
6. स्लाइड में एक पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड आपको दिखाता है कि पिक्चर फ्रेम कैसे बनाएं:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation वर्ग का निर्माण करता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image वर्ग का निर्माण करता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ता है
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

पिक्चर फ्रेम आपको छवियों के आधार पर शीघ्रता से प्रस्तुति स्लाइड बनाने की अनुमति देता है। जब आप पिक्चर फ्रेम को Aspose.Slides की सहेजने विकल्पों के साथ मिलाते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित करके छवियों को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में बदल सकते हैं। आप इन पृष्ठों को देखना चाहेंगे: परिवर्तित करें [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); परिवर्तित करें [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); परिवर्तित करें [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), परिवर्तित करें [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); परिवर्तित करें [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), परिवर्तित करें [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/). 

{{% /alert %}}

## **सापेक्ष स्केल के साथ पिक्चर फ्रेम बनाएं**

एक छवि के सापेक्ष स्केल को बदलकर, आप अधिक जटिल पिक्चर फ्रेम बना सकते हैं। 

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) वर्ग की एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रेजेंटेशन इमेज कलेक्शन में एक छवि जोड़ें।  
4. प्रेजेंटेशन ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
5. पिक्चर फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड आपको दिखाता है कि सापेक्ष स्केल के साथ पिक्चर फ्रेम कैसे बनाएं:

```java
// PPTX का प्रतिनिधित्व करने वाले Presentation वर्ग को इंस्टैंशिएट करें
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image वर्ग को इंस्टैंशिएट करें
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ें
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // सापेक्ष स्केल की ऊँचाई और चौड़ाई सेट कर रहे हैं
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **पिक्चर फ्रेम से रास्टर छवियों को निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PictureFrame) ऑब्जेक्ट से रास्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG तथा अन्य फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दर्शाता है कि "sample.pptx" दस्तावेज़ से एक छवि को कैसे निकालें और PNG फ़ॉर्मेट में सहेजें।

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **पिक्चर फ्रेम से SVG छवियां निकालें**

जब कोई प्रस्तुति SVG ग्राफ़िक्स को [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) आकारों के भीतर रखती है, तो Aspose.Slides for Java आपको मूल वेक्टर छवियों को पूर्ण शुद्धता के साथ प्राप्त करने की सुविधा देता है। स्लाइड की shape कलेक्शन को ट्रैवर्स करके, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसकी मूल SVG फ़ॉर्मेट में डिस्क या स्ट्रीम में सहेज सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पिक्चर फ्रेम से SVG छवि को कैसे निकाला जाए:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **छवि की पारदर्शिता प्राप्त करें**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने की सुविधा देता है। यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **पिक्चर फ्रेम फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें पिक्चर फ्रेम पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके, आप पिक्चर फ्रेम को विशिष्ट आवश्यकताओं के अनुसार बदल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) वर्ग की एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रेजेंटेशन ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. संदर्भित स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदर्शित [AddPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड के माध्यम से `PictureFrame` बनाएं।  
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।  
7. पिक्चर फ्रेम की लाइन का रंग सेट करें।  
8. पिक्चर फ्रेम की लाइन की चौड़ाई सेट करें।  
9. पिक्चर फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को घड़ी के विपरीत दिशा में घुमाता है।  
10. पिक्चर फ्रेम (जिसमें चित्र है) को फिर से स्लाइड में जोड़ें।  
11. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड पिक्चर फ्रेम फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```java
// PPTX का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इंस्टैंशिएट करता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ता है
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx पर कुछ फ़ॉर्मेटिंग लागू करता है
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG को मर्ज] करने या PNG छवियों को एक साथ जोड़ने, या फ़ोटो से ग्रिड बनाने की आवश्यकता पड़े, तो आप इस सेवा का उपयोग कर सकते हैं। 

{{% /alert %}}

## **छवि को लिंक के रूप में जोड़ें**

बड़ी प्रस्तुति फ़ाइल आकार से बचने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियों (या वीडियो) को जोड़ सकते हैं। यह Java कोड दिखाता है कि प्लेसहोल्डर में छवि और वीडियो कैसे जोड़े जाएँ:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **छवियों को क्रॉप करें**

यह Java कोड दिखाता है कि स्लाइड पर मौजूद मौजूदा छवि को कैसे क्रॉप करें:

```java
Presentation pres = new Presentation();
// नया इमेज ऑब्जेक्ट बनाता है
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड में एक PictureFrame जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // इमेज को क्रॉप करता है (प्रतिशत मान)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // परिणाम को सहेजता है
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़्रेम की क्रॉप की गई क्षेत्रों को हटाएँ**

यदि आप फ़्रेम में सम्मिलित छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि वापस करता है यदि क्रॉप आवश्यक नहीं है।

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पहले स्लाइड से PictureFrame प्राप्त करता है
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि वापस करता है
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // परिणाम सहेजता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई छवि को प्रस्तुति इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रस्तुति आकार को कम कर सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ जाएगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटा‑फ़ाइलों को रास्टर PNG छवि में बदलता है। 

{{% /alert %}}

## **छवियों को संकुचित करें**

आप प्रस्तुति में एक चित्र को [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके संकुचित कर सकते हैं। यह मेथड आकार और निर्दिष्ट रेज़ोल्यूशन के आधार पर छवि का आकार घटाकर संकुचित करता है, तथा वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाने का विकल्प देता है।

यह PowerPoint के **Picture Format -> Compress Pictures -> Resolution** फीचर के समान रूप से चित्र का आकार और रेज़ोल्यूशन समायोजित करता है।

निम्न Java उदाहरण दर्शाते हैं कि लक्ष्य रेज़ोल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को कैसे संकुचित किया जाए:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) के लक्षित रिज़ॉल्यूशन के साथ संकुचित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

या सीधे कस्टम DPI मान का उपयोग करके:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) तक संकुचित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

यह मेथड आकार और प्रदान किए गए DPI के आधार पर छवि को कम रेज़ोल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है।  
यदि छवि एक मेटा‑फ़ाइल (WMF/EMF) या SVG है, तो संकुचन लागू नहीं होगा। साथ ही, JPEG की गुणवत्ता रेज़ोल्यूशन के आधार पर थोड़ी कम या अपरिवर्तित रहती है, जैसे PowerPoint उच्च‑रेज़ोल्यूशन JPEG को संभालता है। 

{{% /alert %}}

## **आस्पेक्ट अनुपात लॉक करें**

यदि आप चाहते हैं कि छवि वाला आकार छवि के आयाम बदलने पर भी अपना आस्पेक्ट अनुपात बना रहे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने के लिए [setAspectRatioLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग कर सकते हैं। 

यह Java कोड दिखाता है कि आकार का आस्पेक्ट अनुपात कैसे लॉक किया जाए:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // आकार को री-साइज़ करने पर आस्पेक्ट अनुपात को सुरक्षित रखने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल आकार के आस्पेक्ट अनुपात को संरक्षित करती है, न कि उसके भीतर मौजूद छवि को। 

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[StretchOffsetLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) प्रॉपर्टी को [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat) क्लास से उपयोग करके, आप एक फ़िल रैक्टैंगल निर्दिष्ट कर सकते हैं। 

जब किसी छवि के लिए स्ट्रेचिंग निर्धारित की जाती है, तो स्रोत रैक्टैंगल को निर्धारित फ़िल रैक्टैंगल में फिट करने के लिए स्केल किया जाता है। फ़िल रैक्टैंगल के प्रत्येक किनारे को आकार के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। सकारात्मक प्रतिशत इन्सेट को दर्शाता है जबकि नकारात्मक प्रतिशत आउटसेट को।  

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) वर्ग की एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. एक आयत `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. आकार का फ़िल टाइप सेट करें।  
6. आकार की पिक्चर फ़िल मोड सेट करें।  
7. आकार को भरने के लिए सेट छवि जोड़ें।  
8. आकार के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दर्शाता है कि StretchOff प्रॉपर्टी का उपयोग कैसे किया जाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx क्लास को इंस्टैंशिएट करता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // एक AutoShape जोड़ता है जो Rectangle है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // आकार का फ़िल टाइप सेट करता है
    aShape.getFillFormat().setFillType(FillType.Picture);

    // आकार का पिक्चर फ़िल मोड सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // आकार को भरने के लिए छवि सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // आकार की बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्धारित करता है
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **बार‑बार पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि पिक्चर फ्रेम के लिए कौन‑से छवि फ़ॉर्मेट समर्थित हैं?**

Aspose.Slides रास्टर छवियों (PNG, JPEG, BMP, GIF आदि) और वेक्टर छवियों (जैसे SVG) दोनों को [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) को असाइन किए गए इमेज ऑब्जेक्ट के माध्यम से समर्थन देता है। समर्थित फ़ॉर्मेटों की सूची आमतौर पर स्लाइड और इमेज कन्वर्शन इंजन की क्षमताओं के साथ ओवरलैप करती है।

**सैकड़ों बड़ी छवियों को जोड़ने से PPTX फ़ाइल का आकार और प्रदर्शन कैसे प्रभावित होगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति का आकार छोटा रहता है लेकिन बाहरी फ़ाइलों को पहुंच योग्य होना आवश्यक है। Aspose.Slides लिंक द्वारा छवियां जोड़ने की सुविधा प्रदान करता है जिससे फ़ाइल आकार घटाया जा सकता है।

**मैं किसी छवि ऑब्जेक्ट को आकस्मिक रूप से मूव/रीसाइज़ होने से कैसे रोक सकता हूँ?**

आप [shape locks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) का उपयोग करके किसी [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) को लॉक कर सकते हैं (जैसे मूव या रिसाइज़ को निष्क्रिय करना)। लॉकिंग तंत्र के बारे में विवरण अलग [protection article](/slides/hi/java/applying-protection-to-presentation/) में दिया गया है और यह विभिन्न आकार प्रकारों सहित [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) के लिए समर्थित है।

**क्या SVG वेक्टर फ़िडेलिटी को PDF/छवियों में निर्यात करने पर बनाए रखा जाता है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप [PDF में निर्यात](/slides/hi/java/convert-powerpoint-to-pdf/) या [रास्टर फ़ॉर्मेट में निर्यात](/slides/hi/java/convert-powerpoint-to-png/) करते हैं, तो निर्यात सेटिंग्स के आधार पर परिणाम रास्टराइज़ हो सकता है; निष्कर्षण व्यवहार यह पुष्टि करता है कि मूल SVG वेक्टर के रूप में संग्रहीत है।