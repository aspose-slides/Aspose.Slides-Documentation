---
title: Android पर प्रस्तुतियों में Picture Frames का प्रबंधन
linktitle: Picture Frame
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
- रेस्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया गया क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम फ़ॉर्मेटिंग
- चित्र फ्रेम गुण
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
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में picture frames जोड़ें। अपने कार्य प्रवाह को सरल बनाएं और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

एक picture frame वह shape है जो एक image को समाहित करता है—यह फ्रेम में पड़ी picture जैसा है।

आप एक slide में picture frame के जरिए image जोड़ सकते हैं। इस तरह आप picture frame को फ़ॉर्मेट करके image को फ़ॉर्मेट कर सकते हैं।

{{% alert title="सलाह" color="primary" %}} 
Aspose मुफ्त converters प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को images से जल्दी presentations बनाने में मदद करते हैं। 
{{% /alert %}} 

## **चित्र फ्रेम बनाएं**

1. Presentation क्लास की एक instance बनाएं।
2. स्लाइड का reference उसके index के माध्यम से प्राप्त करें।
3. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में image जोड़कर एक [IPPImage]() ऑब्जेक्ट बनाएं, जिसे shape को भरने के लिए उपयोग किया जाएगा।
4. image की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. `AddPictureFrame` मेथड के माध्यम से, referenced slide से जुड़े shape ऑब्जेक्ट पर, image की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PictureFrame) बनाएं।
6. स्लाइड में picture frame (जिसमें picture है) जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दिखाता है कि picture frame कैसे बनाएं:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का एक उदाहरण बनाता है
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

image के सापेक्ष स्केल को बदलकर आप एक अधिक जटिल picture frame बना सकते हैं।

1. Presentation क्लास की एक instance बनाएं।
2. स्लाइड का reference उसके index के माध्यम से प्राप्त करें।
3. प्रस्तुति की image collection में एक image जोड़ें।
4. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में image जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसे shape को भरने के लिए उपयोग किया जाएगा।
5. picture frame में image की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दिखाता है कि सापेक्ष स्केल के साथ picture frame कैसे बनाएं:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इंस्टैंशिएट करें
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ें
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

आप [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PictureFrame) ऑब्जेक्ट्स से रास्टर छवियां निकाल सकते हैं और उन्हें PNG, JPG तथा अन्य फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि "sample.pptx" दस्तावेज़ से एक image कैसे निकालें और PNG फ़ॉर्मेट में सहेजें।

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

जब किसी प्रस्तुति में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) shape के अंदर रखे होते हैं, तो Aspose.Slides for Android via Java आपको मूल vector images को पूर्ण fidelity के साथ प्राप्त करने देता है। स्लाइड की shape collection को ट्रैवर्स करके आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि नीचे का [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) SVG सामग्री रखता है या नहीं, और फिर उस image को डिस्क या स्ट्रीम में उसके मूल SVG फ़ॉर्मेट में सहेज सकते हैं।

निम्नलिखित कोड उदाहरण दिखाता है कि picture frame से SVG image कैसे निकाली जाए:

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

Aspose.Slides आपको image पर लागू पारदर्शिता प्रभाव प्राप्त करने देता है। यह Java कोड इस ऑपरेशन को दर्शाता है:

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

## **चित्र फ्रेम फॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें picture frame पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके आप picture frame को विशिष्ट आवश्यकताओं के अनुरूप बदल सकते हैं।

1. Presentation क्लास की एक instance बनाएं।
2. स्लाइड का reference उसके index के माध्यम से प्राप्त करें।
3. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में image जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं, जिसे shape को भरने के लिए उपयोग किया जाएगा।
4. image की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. [AddPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड द्वारा, referenced slide से जुड़े [IShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट पर, image की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएं।
6. स्लाइड में picture frame (जिसमें picture है) जोड़ें।
7. picture frame की line color सेट करें।
8. picture frame की line width सेट करें।
9. picture frame को सकारात्मक या नकारात्मक मान देकर घुमाएँ।
   * सकारात्मक मान image को clockwise घुमाता है।
   * नकारात्मक मान image को anti‑clockwise घुमाता है।
10. picture frame (जिसमें picture है) को फिर से स्लाइड में जोड़ें।
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड picture frame फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का एक उदाहरण बनाता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ता है
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

{{% alert title="सलाह" color="primary" %}} 
Aspose ने हाल ही में एक मुफ्त [Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG images को मिलाना हो, या [फ़ोटो से grids बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) हो, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}} 

## **छवि को लिंक के रूप में जोड़ें**

बड़ी प्रस्तुति आकारों से बचने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के जरिए images (या videos) जोड़ सकते हैं। यह Java कोड दिखाता है कि placeholder में image और video कैसे जोड़े जाएँ:

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

यह Java कोड दिखाता है कि स्लाइड पर मौजूद मौजूदा image को कैसे क्रॉप किया जाए:

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

    // एक स्लाइड में PictureFrame जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // इमेज को क्रॉप करता है (प्रतिशत मान)
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

यदि आप फ्रेम में सम्मिलित image के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई image या मूल image को लौटाता है यदि क्रॉप आवश्यक नहीं है।

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पहली स्लाइड से PictureFrame प्राप्त करता है
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame इमेज के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई इमेज लौटाता है
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // परिणाम सहेजता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="नोट" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई image को प्रस्तुति की image collection में जोड़ता है। यदि image केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) में उपयोग हुई है, तो यह सेटअप प्रस्तुति का आकार कम कर सकता है। अन्यथा, परिणामी प्रस्तुति में images की संख्या बढ़ेगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF metafiles को raster PNG image में परिवर्तित करता है। 
{{% /alert %}} 

## **छवियों को संपीड़ित करें**

आप एक प्रस्तुति में picture को [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) मेथड द्वारा संपीड़ित कर सकते हैं। यह मेथड shape के आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर size को कम करके image को संपीड़ित करता है, साथ ही वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाया जा सकता है।

यह PowerPoint के **Picture Format > Compress Pictures > Resolution** फ़ीचर के समान तरीके से picture का size और resolution समायोजित करता है।

निम्नलिखित Java उदाहरण दिखाते हैं कि लक्ष्य resolution निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में image को कैसे संपीड़ित किया जाए:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // इमेज को 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
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

या सीधे एक कस्टम DPI मान का उपयोग करके:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // इमेज को 150 DPI (वेब रिज़ॉल्यूशन) तक संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="नोट" color="warning" %}} 
यह मेथड shape के आकार और प्रदान किए गए DPI के आधार पर image को कम resolution में परिवर्तित करता है। क्रॉप किए गए क्षेत्रों को हटाया जा सकता है ताकि फ़ाइल आकार ऑप्टिमाइज़ हो सके।  
यदि image एक metafile (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं किया जाएगा। JPEG की गुणवत्ता भी resolution के आधार पर समान रूप से बनी रहती है या हल्का घटती है, जैसा कि PowerPoint उच्च‑resolution JPEG को संभालता है। 
{{% /alert %}} 

## **आस्पेक्ट अनुपात को लॉक करें**

यदि आप चाहते हैं कि image वाली shape के आयाम बदलने पर भी उसका aspect ratio बना रहे, तो आप [setAspectRatioLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं।

यह Java कोड दिखाता है कि shape के aspect ratio को कैसे लॉक किया जाए:

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

    // आकार को रिसाइज़ करने पर aspect ratio को बनाए रखने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="नोट" color="warning" %}} 
यह *Lock Aspect Ratio* सेटिंग केवल shape के aspect ratio को संरक्षित करती है, न कि उसमें सम्मिलित image को। 
{{% /alert %}} 

## **StretchOff प्रॉपर्टी का उपयोग करें**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat) क्लास की [StretchOffsetLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) प्रॉपर्टी का उपयोग करके आप एक fill rectangle निर्दिष्ट कर सकते हैं।

जब image के लिए stretching निर्दिष्ट किया जाता है, तो एक source rectangle को निर्दिष्ट fill rectangle में फिट करने के लिए स्केल किया जाता है। fill rectangle का प्रत्येक किनारा shape के bounding box के संबंधित किनारे से प्रतिशत offset द्वारा परिभाषित होता है। सकारात्मक प्रतिशत inset दर्शाता है जबकि नकारात्मक प्रतिशत outset दर्शाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास की एक instance बनाएं।
2. स्लाइड का reference उसके index के माध्यम से प्राप्त करें।
3. एक `AutoShape` rectangle जोड़ें।
4. एक image बनाएं।
5. shape की fill type सेट करें।
6. shape की picture fill mode सेट करें।
7. shape को भरने के लिए एक सेट image जोड़ें।
8. shape के bounding box के संबंधित किनारे से image offsets निर्दिष्ट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड StretchOff प्रॉपर्टी के उपयोग वाली प्रक्रिया दर्शाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx क्लास को इंस्टैंशिएट करता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Rectangle के रूप में सेट की गई AutoShape जोड़ता है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // shape का fill type सेट करता है
    aShape.getFillFormat().setFillType(FillType.Picture);

    // shape का picture fill mode सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // shape को भरने के लिए image सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // shape की बाउंडिंग बॉक्स के संबंधित किनारे से image offsets निर्दिष्ट करता है
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

## **अक्सर पूछे जाने वाले प्रश्न**

**PictureFrame के लिए कौन से image फ़ॉर्मेट समर्थित हैं, यह मैं कैसे जानूँ?**

Aspose.Slides raster images (PNG, JPEG, BMP, GIF आदि) और vector images (जैसे SVG) दोनों का समर्थन करता है, जो एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) को असाइन किए गए image ऑब्जेक्ट के माध्यम से होते हैं। समर्थित फ़ॉर्मेट की सूची आम तौर पर slide और image conversion इंजन की क्षमताओं के साथ ओवरलैप करती है।

**दहाड़ों बड़े images जोड़ने से PPTX आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?**

बड़ी images को embed करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; images को लिंक करने से प्रस्तुति का आकार छोटा रहता है, लेकिन बाहरी फ़ाइलों को सुलभ रखना आवश्यक है। Aspose.Slides लिंक द्वारा images जोड़ने की क्षमता प्रदान करता है ताकि फ़ाइल आकार कम किया जा सके।

**मैं accidental move/resize से image ऑब्जेक्ट को कैसे लॉक करूँ?**

आप [shape locks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) का उपयोग करके एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) को लॉक कर सकते हैं (जैसे, moving या resizing को डिसेबल करना)। यह लॉकिंग मैकेनिज़्म विभिन्न shape प्रकारों के लिए समर्थित है, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) भी शामिल है।

**PDF/images में एक्सपोर्ट करने पर SVG vector की fidelity बनी रहती है क्या?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) से SVG को मूल vector के रूप में निकालने देता है। जब आप [PDF में एक्सपोर्ट](/slides/hi/androidjava/convert-powerpoint-to-pdf/) या [raster फ़ॉर्मेट में एक्सपोर्ट](/slides/hi/androidjava/convert-powerpoint-to-png/) करते हैं, तो परिणाम export सेटिंग्स पर निर्भर करता है; मूल SVG को vector के रूप में संग्रहीत रखने की पुष्टि extraction behavior से होती है।