---
title: एंड्रॉइड पर प्रस्तुतियों में चित्र फ्रेम प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/androidjava/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रैस्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया हुआ क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम स्वरूपण
- चित्र फ्रेम प्रॉपर्टीज़
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सुगम बनाएं और स्लाइड डिज़ाइन को सुधारें।"
---
## **परिचय**

एक चित्र फ्रेम वह आकार है जिसमें छवि होती है—यह फ्रेम में चित्र जैसा है।

आप एक चित्र फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस प्रकार, आप चित्र फ्रेम को स्वरूपित करके छवि को स्वरूपित कर सकते हैं।

{{% alert title="Tip" color="primary" %}} 
Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से तेज़ी से प्रस्तुति बनाने की अनुमति देता है। 
{{% /alert %}} 

## **चित्र फ्रेम बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage]() ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
4. छवि की चौड़ाई और ऊंचाई निर्दिष्ट करें।  
5. संदर्भित स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा प्रदान किए गए `AddPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊंचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PictureFrame) बनाएं।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड आपको चित्र फ्रेम बनाने का तरीका दिखाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इनस्टैंशिएट करता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ एक picture frame जोड़ता है
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाएं**

छवि के सापेक्ष स्केल को बदलकर, आप अधिक जटिल चित्र फ्रेम बना सकते हैं।  

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. प्रस्तुति की छवि संग्रह में एक छवि जोड़ें।  
4. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
5. चित्र फ्रेम में छवि की सापेक्ष चौड़ाई और ऊंचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड आपको सापेक्ष स्केल के साथ चित्र फ्रेम बनाने का तरीका दिखाता है:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इनस्टैंशिएट करें
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // चित्र की ऊँचाई और चौड़ाई के बराबर Picture Frame जोड़ें
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करना
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **चित्र फ्रेम से रैस्टर छवियां निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PictureFrame) ऑब्जेक्ट से रैस्टर छवियां निकाल सकते हैं और उन्हें PNG, JPG और अन्य फ़ॉर्मैट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दस्तावेज़ "sample.pptx" से एक छवि निकालता है और उसे PNG फ़ॉर्मैट में सहेजता है।

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

## **चित्र फ्रेम से SVG छवियां निकालें**

जब प्रस्तुति में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) आकार के भीतर रखे होते हैं, तो Aspose.Slides for Android via Java आपको मूल वेक्टर छवियां पूरी शुद्धता के साथ पुनः प्राप्त करने की अनुमति देता है। स्लाइड के shape कलेक्शन को पार करते हुए, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसकी मूल SVG फ़ॉर्मैट में डिस्क या स्ट्रीम में सहेज सकते हैं।  

निम्नलिखित कोड उदाहरण एक चित्र फ्रेम से SVG छवि निकालने का तरीका दर्शाता है:

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

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव प्राप्त करने की अनुमति देता है। यह Java कोड इस ऑपरेशन को प्रदर्शित करता है:

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

## **छवि की चमक और कंट्रास्ट प्राप्त करें**

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव प्राप्त करने की अनुमति देता है। [ILuminance](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iluminance/) इंटरफ़ेस इस छवि रूपांतरण प्रभाव का प्रतिनिधित्व करता है।  

यह Java कोड आपको चित्र फ्रेम से चमक और कंट्रास्ट सेटिंग्स प्राप्त करने का तरीका दिखाता है:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **चित्र फ्रेम स्वरूपण**

Aspose.Slides कई स्वरूपण विकल्प प्रदान करता है जिन्हें चित्र फ्रेम पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके, आप चित्र फ्रेम को विशिष्ट आवश्यकताओं के अनुरूप बना सकते हैं।  

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
4. छवि की चौड़ाई और ऊंचाई निर्दिष्ट करें।  
5. संदर्भित स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [AddPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड के माध्यम से छवि की चौड़ाई और ऊंचाई के आधार पर एक `PictureFrame` बनाएं।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. चित्र फ्रेम की रेखा का रंग सेट करें।  
8. चित्र फ्रेम की रेखा की चौड़ाई सेट करें।  
9. चित्र फ्रेम को सकारात्मक या नकारात्मक मान दे कर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को विरोधी दिशा में घुमाता है।  
10. चित्र फ्रेम (जिसमें चित्र है) को फिर से स्लाइड में जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड चित्र फ्रेम स्वरूपण प्रक्रिया को दर्शाता है:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इनस्टैंशिएट करता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ता है
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx पर कुछ स्वरूपण लागू करता है
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
Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी भी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना हो, या [फोटो से ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) हो, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ें**

प्रस्तुति का आकार कम रखने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियां (या वीडियो) जोड़ सकते हैं। यह Java कोड आपको एक प्लेसहोल्डर में छवि और वीडियो जोड़ने का तरीका दिखाता है:

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

यह Java कोड आपको स्लाइड पर मौजूदा छवि को क्रॉप करने का तरीका दिखाता है:

```java
Presentation pres = new Presentation();
// नई छवि ऑब्जेक्ट बनाता है
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

    // छवि को क्रॉप करता है (प्रतिशत मान)
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

## **चित्र के क्रॉप किए गए क्षेत्रों को हटाएँ**

यदि आप फ्रेम में मौजूद छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि को लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।  

यह Java कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पहली स्लाइड से PictureFrame प्राप्त करता है
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // परिणाम को सहेजता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई छवि को प्रस्तुति छवि संग्रह में जोड़ता है। यदि छवि केवल प्रक्रिया किए गए [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) में उपयोग होती है, तो यह सेटअप प्रस्तुति के आकार को घटा सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ेगी।  

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटाफाइल को रैस्टर PNG छवि में परिवर्तित करता है। 
{{% /alert %}}

## **छवियों को संकुचित करें**

आप [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके प्रस्तुति में मौजूद चित्र को संकुचित कर सकते हैं। यह मेथड आकार को आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर कम करके, और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर छवि को संकुचित करता है।  

यह PowerPoint के **Picture Format > Compress Pictures > Resolution** फ़ीचर के समान काम करता है।  

निम्नलिखित Java उदाहरण लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके, तथा वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर, प्रस्तुति में छवि को संकुचित करने का तरीका दिखाते हैं:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // लक्ष्य रिज़ॉल्यूशन 150 DPI (वेब रिज़ॉल्यूशन) के साथ छवि को संकुचित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // संकुचन का परिणाम जाँचें।
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

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) पर संकुचित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
यह मेथड आकार और प्रदान किए गए DPI के आधार पर छवि को कम रिज़ॉल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है। यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संकुचन लागू नहीं होगा। साथ ही JPEG की गुणवत्ता रिज़ॉल्यूशन के अनुसार संरक्षित या हल्के से घटेगी, जैसा कि PowerPoint उच्च रिज़ॉल्यूशन JPEG को संभालता है। 
{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करें**

यदि आप चाहते हैं कि छवि वाली आकार के आयाम बदलने के बाद भी उसका आस्पेक्ट रेशियो बना रहे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने के लिए [setAspectRatioLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग कर सकते हैं।  

यह Java कोड आपको आकार के आस्पेक्ट रेशियो को लॉक करने का तरीका दिखाता है:

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

    // आकार को रिसाइज़ करने पर आस्पेक्ट अनुपात को संरक्षित करने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
यह *Lock Aspect Ratio* सेटिंग केवल आकार का आस्पेक्ट रेशियो संरक्षित करती है, न कि उसमें मौजूद छवि का। 
{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat) क्लास की [StretchOffsetLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) प्रॉपर्टी का उपयोग करके, आप एक भराव आयत निर्दिष्ट कर सकते हैं।  

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत आयत को निर्दिष्ट भराव आयत में फिट होने के लिए स्केल किया जाता है। भराव आयत का प्रत्येक किनारा आकार के बॉन्डिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। सकारात्मक प्रतिशत एक इनसेट को दर्शाता है जबकि नकारात्मक प्रतिशत एक आउटसेट को।  

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. एक आयत `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. आकार का fill प्रकार सेट करें।  
6. आकार के picture fill मोड को सेट करें।  
7. fill करने के लिए एक सेट इमेज जोड़ें।  
8. आकार के बॉन्डिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दर्शाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx क्लास को इनस्टैंशिएट करता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Rectangle पर सेट किया गया AutoShape जोड़ता है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // shape की fill प्रकार सेट करता है
    aShape.getFillFormat().setFillType(FillType.Picture);

    // shape की picture fill मोड सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // shape को भरने के लिए छवि सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // shape के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करता है
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

## **FAQ**

**मैं कैसे पता कर सकता हूँ कि PictureFrame के लिए कौनसे छवि फ़ॉर्मैट समर्थित हैं?**  

Aspose.Slides दोनों रैस्टर छवियों (PNG, JPEG, BMP, GIF आदि) और वेक्टर छवियों (जैसे SVG) को एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) को सौंपे गए छवि ऑब्जेक्ट के माध्यम से समर्थन करता है। समर्थित फ़ॉर्मैट की सूची सामान्यतः स्लाइड और इमेज कनवर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।  

**दर्जनों बड़ी छवियों को जोड़ने से PPTX का आकार और प्रदर्शन कैसे प्रभावित होगा?**  

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति का आकार कम रहता है, लेकिन बाहरी फ़ाइलों को उपलब्ध रखना आवश्यक होता है। Aspose.Slides लिंक के माध्यम से छवियां जोड़ने की सुविधा प्रदान करता है ताकि फ़ाइल आकार घटाया जा सके।  

**मैं छवि ऑब्जेक्ट को आकस्मिक रूप से मूव/रीसाइज़ होने से कैसे लॉक कर सकता हूँ?**  

[shape locks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) का उपयोग करके आप एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) को लॉक कर सकते हैं (जैसे मूव या री-साइज़ को निष्क्रिय करना)। यह लॉकिंग मैकैनिज़्म विभिन्न shape प्रकारों के लिए समर्थित है, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) भी शामिल है।  

**क्या SVG वेक्टर फ़िडेलिटी बनाए रखी जाती है जब प्रस्तुति को PDF/छवियों में निर्यात किया जाता है?**  

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप [PDF में निर्यात](/slides/hi/androidjava/convert-powerpoint-to-pdf/) या [रैस्टर फ़ॉर्मैट में निर्यात](/slides/hi/androidjava/convert-powerpoint-to-png/) करते हैं, तो परिणाम निर्यात सेटिंग्स के आधार पर रैस्टर हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत किया जाता है, जिसका प्रमाण एक्सट्रैक्शन व्यवहार है।