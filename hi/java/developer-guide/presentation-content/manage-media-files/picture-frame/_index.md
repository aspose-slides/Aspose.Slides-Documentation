---
title: जावा का उपयोग करके प्रस्तुतियों में चित्र फ्रेम प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/java/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि काटें
- कटा हुआ क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम स्वरूपण
- चित्र फ्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइन को सुधारें।"
---
## **परिचय**

एक चित्र फ्रेम वह आकार है जिसमें छवि सम्मिलित होती है—यह फ्रेम में चित्र के समान है।

आप स्लाइड में एक चित्र फ्रेम के माध्यम से छवि जोड़ सकते हैं। इस प्रकार, आप चित्र फ्रेम को फॉर्मेट करके छवि को फॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रेजेंटेशन बनाने की अनुमति देते हैं। 
{{% /alert %}} 

## **एक चित्र फ्रेम बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रेजेंटेशन ऑब्जेक्ट के साथ जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage]() ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. संदर्भित स्लाइड से जुड़े आकार ऑब्जेक्ट द्वारा प्रदान किए गए `AddPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PictureFrame) बनाएं।
6. स्लाइड में एक चित्र फ्रेम (जिसमें चित्र है) जोड़ें।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि एक चित्र फ्रेम कैसे बनाएं:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का उदाहरण बनाता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ एक चित्र फ्रेम जोड़ता है
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
चित्र फ्रेम आपको छवियों के आधार पर तेज़ी से प्रस्तुति स्लाइड बनाने की अनुमति देता है। जब आप चित्र फ्रेम को Aspose.Slides के सहेजने विकल्पों के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट ऑपरेशनों को नियंत्रित करके छवियों को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में बदल सकते हैं। आप इन पृष्ठों को देख सकते हैं: बदलें [image को JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); बदलें [JPG को image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); बदलें [JPG को PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), बदलें [PNG को JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); बदलें [PNG को SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), बदलें [SVG को PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/)।
{{% /alert %}}

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाएं**

छवि के सापेक्ष स्केल को बदलकर आप एक अधिक जटिल चित्र फ्रेम बना सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रेजेंटेशन इमेज कलेक्शन में एक छवि जोड़ें।
4. प्रेजेंटेशन ऑब्जेक्ट के साथ जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।
5. चित्र फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।
6. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि सापेक्ष स्केल के साथ चित्र फ्रेम कैसे बनाएं:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इंस्टैंशिएट करें
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ चित्र फ्रेम जोड़ें
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // सापेक्ष स्केल की ऊँचाई और चौड़ाई सेट करना
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **चित्र फ्रेम से रास्टर छवियां निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PictureFrame) ऑब्जेक्ट्स से रास्टर छवियां निकाल सकते हैं और उन्हें PNG, JPG और अन्य फ़ॉर्मेट्स में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि दस्तावेज़ "sample.pptx" से एक छवि कैसे निकालें और उसे PNG फ़ॉर्मेट में सहेजें।

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

जब किसी प्रेजेंटेशन में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) आकार के भीतर रखे होते हैं, तो Aspose.Slides for Java आपको मूल वेक्टर छवियों को पूरी शुद्धता के साथ प्राप्त करने देता है। स्लाइड के आकार संग्रह को ट्रवर्स करके, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को डिस्क या स्ट्रीम में उसके मूल SVG फ़ॉर्मेट में सहेज सकते हैं।

निम्न कोड उदाहरण दर्शाता है कि कैसे एक चित्र फ्रेम से SVG छवि निकाली जाए:

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

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव प्राप्त करने की अनुमति देता है। यह Java कोड इस ऑपरेशन को दर्शाता है:

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

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव प्राप्त करने की अनुमति देता है। [ILuminance](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iluminance/) इंटरफ़ेस इस छवि रूपांतरण प्रभाव का प्रतिनिधित्व करता है।

यह Java कोड दिखाता है कि चित्र फ्रेम से चमक और कंट्रास्ट सेटिंग्स कैसे प्राप्त करें:

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

## **चित्र फ्रेम का फॉर्मेटिंग**

Aspose.Slides कई फॉर्मेटिंग विकल्प प्रदान करता है जिन्हें एक चित्र फ्रेम पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके आप चित्र फ्रेम को बदल सकते हैं ताकि वह विशिष्ट आवश्यकताओं के अनुरूप हो सके।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रेजेंटेशन ऑब्जेक्ट के साथ जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. संदर्भित स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) द्वारा प्रदान किए गए [AddPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएं।
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।
7. चित्र फ्रेम की लाइन का रंग सेट करें।
8. चित्र फ्रेम की लाइन की मोटाई सेट करें।
9. चित्र फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।
   * सकारात्मक मान चित्र को घड़ी की दिशा में घूमाता है।
   * नकारात्मक मान चित्र को विपरीत दिशा में घूमाता है।
10. चित्र फ्रेम (जिसमें चित्र है) को स्लाइड में फिर से जोड़ें।
11. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड चित्र फ्रेम फॉर्मेटिंग प्रक्रिया को दर्शाता है:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का इंस्टैंस बनाता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ चित्र फ्रेम जोड़ता है
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx पर कुछ फॉर्मेटिंग लागू करता है
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
Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG को मिलाना](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियां चाहिए, या [फोटो से ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) चाहते हैं, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}}

## **लिंक के रूप में छवि जोड़ें**

बड़ी प्रेजेंटेशन फाइल आकार से बचने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियां (या वीडियो) जोड़ सकते हैं। यह Java कोड आपको दिखाता है कि प्लेसहोल्डर में छवि और वीडियो कैसे जोड़ें:

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

यह Java कोड आपको दिखाता है कि स्लाइड पर मौजूदा छवि को कैसे क्रॉप करें:

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

    // छवि को क्रॉप करता है (प्रतिशत मान)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // परिणाम सहेजता है
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **चित्र के क्रॉप किए गए क्षेत्रों को हटाएं**

यदि आप फ्रेम में सम्मिलित छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पहले स्लाइड से PictureFrame प्राप्त करता है
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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई छवि को प्रेजेंटेशन इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रसंस्कृत [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) में उपयोग होती है, तो यह सेटअप प्रेजेंटेशन आकार को कम कर सकता है। अन्यथा, परिणामी प्रेजेंटेशन में छवियों की संख्या बढ़ जाएगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटाफाइल को रास्टर PNG छवि में बदलता है। 
{{% /alert %}}

## **छवियों को संकुचित करें**

आप एक प्रेजेंटेशन में चित्र को [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके संकुचित कर सकते हैं। यह मेथड आकार के आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर छवि का आकार घटाकर उसे संकुचित करता है, और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाने का विकल्प देता है।

यह चित्र के आकार और रिज़ॉल्यूशन को PowerPoint की **Picture Format -> Compress Pictures -> Resolution** फ़ीचर के समान समायोजित करता है।

निम्न Java उदाहरण दिखाते हैं कि लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रेजेंटेशन में छवि को कैसे संकुचित करें:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) के लक्षित रिज़ॉल्यूशन के साथ संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // संपीड़न के परिणाम की जांच करें।
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

या सीधे एक कस्टम DPI मान का उपयोग करके:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) तक संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
यह मेथड आकार के आकार और प्रदान किए गए DPI के आधार पर छवि को कम रिज़ॉल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है।  
यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संकुचन लागू नहीं होगा। साथ ही, JPEG गुणवत्ता रिज़ॉल्यूशन के आधार पर बनी रहती है या हल्के से घटती है, जैसे PowerPoint उच्च-रेज़ॉल्यूशन JPEG को संभालता है। 
{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करें**

यदि आप चाहते हैं कि कोई आकार जिसमें छवि है, छवि के आयाम बदलने के बाद भी अपना आस्पेक्ट रेशियो बनाए रखे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने के लिए [setAspectRatioLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग कर सकते हैं।

यह Java कोड दिखाता है कि आकार के आस्पेक्ट रेशियो को कैसे लॉक करें:

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

    // आकार को रीसाइज़ करने पर आस्पेक्ट रेशियो बनाए रखने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
यह *Lock Aspect Ratio* सेटिंग केवल आकार के आस्पेक्ट रेशियो को संरक्षित करती है, न कि उसमें सम्मिलित छवि को। 
{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[StretchOffsetLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) प्रॉपर्टी का उपयोग करके आप एक फ़िल रेक्टेंगल निर्दिष्ट कर सकते हैं।

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत रेक्टेंगल को निर्दिष्ट फ़िल रेक्टेंगल में फिट करने के लिए स्केल किया जाता है। फ़िल रेक्टेंगल के प्रत्येक किनारे को आकार के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। एक सकारात्मक प्रतिशत इनसेट को दर्शाता है जबकि नकारात्मक प्रतिशत आउटसेट को।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक `AutoShape` आयत जोड़ें।
4. एक छवि बनाएं।
5. आकार का फ़िल टाइप सेट करें।
6. आकार का पिक्चर फ़िल मोड सेट करें।
7. आकार को भरने के लिए एक इमेज सेट जोड़ें।
8. आकार के बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करें।
9. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दर्शाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx क्लास का इंस्टैंस बनाता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // एक AutoShape जोड़ता है जिसे Rectangle सेट किया गया है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // आकार का फ़िल टाइप सेट करता है
    aShape.getFillFormat().setFillType(FillType.Picture);

    // आकार के चित्र फ़िल मोड को सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // आकार को भरने के लिए छवि सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // आकार के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करता है
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

**मैं पता कैसे लगाऊं कि PictureFrame के लिए कौन से इमेज फ़ॉर्मेट सपोर्टेड हैं?**

Aspose.Slides रास्टर छवियां (PNG, JPEG, BMP, GIF आदि) और वेक्टर छवियां (उदाहरण के लिए, SVG) दोनों को सपोर्ट करता है, जो एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) को असाइन किए गए इमेज ऑब्जेक्ट के माध्यम से उपलब्ध हैं। समर्थित फ़ॉर्मेट्स की सूची आम तौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं से मेल खाती है।

**बड़ी संख्या में बड़े इमेज जोड़ने से PPTX आकार और प्रदर्शन पर क्या असर पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फाइल आकार और मेमोरी उपयोग बढ़ता है; लिंक के माध्यम से इमेज जोड़ने से प्रेजेंटेशन का आकार कम रहता है लेकिन बाहरी फाइलों को सुलभ रखना आवश्यक होता है। Aspose.Slides लिंक के माध्यम से इमेज जोड़ने की सुविधा देता है जिससे फाइल आकार घटाया जा सके।

**मैं इमेज ऑब्जेक्ट को आकस्मिक मूव/रिज़ाइज़िंग से कैसे लॉक करूं?**

आप [shape locks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) का उपयोग करके एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) को लॉक कर सकते हैं (जैसे मूव या रिसाइज़ को डिसेबल करना)। लॉकिंग मैकेनिज़्म के बारे में अलग से [protection article](/slides/hi/java/applying-protection-to-presentation/) में बताया गया है और यह विभिन्न आकार प्रकारों, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) भी शामिल है, के लिए उपलब्ध है।

**क्या SVG वेक्टर फ़िडेलिटी PDF/छवियों में एक्सपोर्ट करने पर बनी रहती है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने देता है। जब आप PDF (/slides/hi/java/convert-powerpoint-to-pdf/) या रास्टर फ़ॉर्मेट (/slides/hi/java/convert-powerpoint-to-png/) में एक्सपोर्ट करते हैं, तो परिणाम एक्सपोर्ट सेटिंग्स के आधार पर रास्टराइज़ हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत किया जाना निकालने के व्यवहार से पुष्टि होती है।