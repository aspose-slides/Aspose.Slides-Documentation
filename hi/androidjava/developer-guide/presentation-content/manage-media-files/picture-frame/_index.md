---
title: Android में प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/androidjava/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया हुआ क्षेत्र
- StretchOff प्रॉपर्टी
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- पिक्चर फ्रेम प्रॉपर्टीज़
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
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

एक पिक्चर फ्रेम वह आकार है जो एक छवि को समाहित करता है—यह फ्रेम में एक चित्र की तरह है।

आप एक पिक्चर फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस प्रकार, आप पिक्चर फ्रेम को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert  title="टिप" color="info" %}} 
Aspose मुफ्त कन्वर्टर्स—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—प्रदान करता है जो लोगों को छवियों से तेज़ी से प्रस्तुतियाँ बनाने की अनुमति देता है। 
{{% /alert %}} 

## **पिक्चर फ्रेम बनाना**

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. प्रेजेंटेशन ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में छवि जोड़कर एक [IPPImage]() ऑब्जेक्ट बनाएं जो आकार को भरने के लिए उपयोग किया जाएगा।
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. संदर्भित स्लाइड से जुड़े Shape ऑब्जेक्ट द्वारा प्रदर्शित `AddPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PictureFrame) बनाएं।
6. स्लाइड में एक पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दिखाता है कि पिक्चर फ्रेम कैसे बनाएं:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का इंस्टैंस बनाता है
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

## **सापेक्ष स्केल के साथ पिक्चर फ्रेम बनाना**

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. प्रेजेंटेशन की इमेज कलेक्शन में एक छवि जोड़ें।
4. प्रेजेंटेशन ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं जो आकार को भरने के लिए उपयोग किया जाएगा।
5. पिक्चर फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।
6. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दिखाता है कि सापेक्ष स्केल के साथ पिक्चर फ्रेम कैसे बनाएं:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इंस्टैंसिएट करें
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ें
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट कर रहे हैं
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **पिक्चर फ्रेम से रास्टर इमेज निकालना**

आप [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PictureFrame) ऑब्जेक्ट से रास्टर इमेज निकाल सकते हैं और उन्हें PNG, JPG और अन्य फॉर्मेट में सेव कर सकते हैं। नीचे दिया गया कोड उदाहरण "sample.pptx" दस्तावेज़ से एक इमेज निकालकर PNG फॉर्मेट में सेव करने का प्रदर्शन करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **पिक्चर फ्रेम से SVG इमेज निकालना**

जब किसी प्रेजेंटेशन में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) शेप में रखे होते हैं, तो Aspose.Slides for Android via Java मूल वेक्टर इमेज को पूरी शुद्धता के साथ पुनः प्राप्त करने की सुविधा देता है। एक बार जब आपके पास ऐसा [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) हो जिसका [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) SVG कंटेंट रखता हो, तो आप उस SVG इमेज को पढ़ कर डिस्क या स्ट्रीम में उसके मूल SVG फॉर्मेट में सेव कर सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पिक्चर फ्रेम से SVG इमेज कैसे निकाली जाए:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **छवि की पारदर्शिता प्राप्त करना**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव प्राप्त करने की अनुमति देता है। यह Java कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
import com.aspose.slides.*;

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

## **छवि की चमक और कंट्रास्ट प्राप्त करना**

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव प्राप्त करने की अनुमति देता है। यह इफ़ेक्ट [ILuminance](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iluminance/) इंटरफ़ेस द्वारा प्रतिनिधित्व किया जाता है।

यह Java कोड दिखाता है कि पिक्चर फ्रेम से चमक और कंट्रास्ट सेटिंग्स कैसे प्राप्त करें:

```java
import com.aspose.slides.*;

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

## **पिक्चर फ्रेम फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जो पिक्चर फ्रेम पर लागू किए जा सकते हैं। इन विकल्पों का उपयोग करके आप पिक्चर फ्रेम को विशिष्ट आवश्यकताओं के अनुसार बदल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. प्रेजेंटेशन ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं जो आकार को भरने के लिए उपयोग किया जाएगा।
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. संदर्भित स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदर्शित [AddPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड के माध्यम से `PictureFrame` बनाएं।
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।
7. पिक्चर फ्रेम की लाइन का रंग सेट करें।
8. पिक्चर फ्रेम की लाइन की चौड़ाई सेट करें।
9. पिक्चर फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।
   * सकारात्मक मान चित्र को clockwise घुमाता है। 
   * नकारात्मक मान चित्र को anti‑clockwise घुमाता है।
10. पिक्चर फ्रेम (जिसमें चित्र है) को फिर से स्लाइड में जोड़ें।
11. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड पिक्चर फ्रेम फ़ॉर्मेटिंग प्रक्रिया दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास को इंस्टैंसिएट करता है
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

{{% alert title="टिप" color="info" %}}
Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी JPG/JPEG या PNG इमेज को मर्ज करने की आवश्यकता पड़े, या फ़ोटो से ग्रिड बनाना हो, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}}

## **छवि को लिंक के रूप में जोड़ना**

प्रेजेंटेशन का आकार बड़ा होने से बचाने के लिए आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियों (या वीडियो) को जोड़ सकते हैं। यह Java कोड दिखाता है कि कैसे एक प्लेसहोल्डर में छवि और वीडियो को लिंक के रूप में जोड़ा जाए:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

## **छवियों को क्रॉप करना**

यह Java कोड दिखाता है कि स्लाइड पर मौजूद मौजूदा छवि को कैसे क्रॉप किया जाए:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// नया इमेज ऑब्जेक्ट बनाता है
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड में एक पिक्चर फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // छवि को क्रॉप करता है (प्रतिशत मान)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // परिणाम को सेव करता है
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पिक्चर के क्रॉप किए गए क्षेत्रों को हटाना**

यदि आप फ्रेम में मौजूद छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई इमेज या मूल इमेज वापस देता है यदि क्रॉपिंग आवश्यक नहीं है।

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पहले स्लाइड से PictureFrame प्राप्त करता है
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame इमेज के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई इमेज लौटाता है
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // परिणाम को सेव करता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ध्यान दें" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई इमेज को प्रेजेंटेशन इमेज कलेक्शन में जोड़ता है। यदि इमेज केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रेजेंटेशन का आकार कम कर सकता है। अन्यथा, परिणामस्वरूप प्रेजेंटेशन में इमेजों की संख्या बढ़ सकती है।

यह मेथड क्रॉपिंग प्रक्रिया में WMF/EMF मेटा फ़ाइलों को रास्टर PNG इमेज में बदलता है। 
{{% /alert %}}

## **छवियों को संकुचित करना**

आप [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके प्रेजेंटेशन में एक चित्र को संकुचित कर सकते हैं। यह मेथड शैल आकार और निर्दिष्ट रेज़ोल्यूशन के आधार पर इमेज का आकार घटाकर उसे संकुचित करता है, तथा क्रॉप किए गए क्षेत्रों को हटाने का विकल्प भी प्रदान करता है।

यह पावरपॉइंट की **Picture Format > Compress Pictures > Resolution** सुविधा के समान चित्र के आकार और रेज़ोल्यूशन को समायोजित करता है।

निम्न Java उदाहरण दर्शाते हैं कि लक्ष्य रेज़ोल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाते हुए प्रेजेंटेशन में इमेज को कैसे संकुचित किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // चित्र को लक्ष्य रिज़ॉल्यूशन 150 DPI (वेब रिज़ॉल्यूशन) के साथ संकुचित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // संकुचन के परिणाम की जाँच करें।
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
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // चित्र को 150 DPI (वेब रिज़ॉल्यूशन) तक संकुचित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ध्यान दें" color="warning" %}} 
यह मेथड शैल आकार और प्रदान किए गए DPI के आधार पर इमेज को कम रेज़ोल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है।  
यदि इमेज एक मेटा फ़ाइल (WMF/EMF) या SVG है, तो संकुचन लागू नहीं होगा। साथ ही, JPEG की क्वालिटी रेज़ोल्यूशन के आधार पर बरकरार रहती है या थोड़ा घटती है, बिलकुल पावरपॉइंट के उच्च‑रिज़ोल्यूशन JPEG प्रोसेसिंग की तरह। 
{{% /alert %}}

## **आस्पेक्ट अनुपात लॉक करना**

यदि आप चाहते हैं कि छवि को समाहित करने वाला आकार छवि के आयाम बदलने पर भी अपना आस्पेक्ट अनुपात बनाए रखे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने के लिए [setAspectRatioLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग कर सकते हैं।

यह Java कोड दिखाता है कि आकार का आस्पेक्ट अनुपात कैसे लॉक किया जाए:

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // आकार को रिसाइज़ करने पर आस्पेक्ट रेशियो बनाए रखने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ध्यान दें" color="warning" %}} 
यह *Lock Aspect Ratio* सेटिंग केवल आकार के आस्पेक्ट अनुपात को संरक्षित करती है, न कि उसमें मौजूद छवि को। 
{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करना**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat) क्लास के द्वारा प्रदान की गई [StretchOffsetLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) प्रॉपर्टी का उपयोग करके आप एक फ़िल लेआउट निर्धारित कर सकते हैं।

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत आयत को निर्दिष्ट फ़िल आयत में फिट करने के लिए स्केल किया जाता है। फ़िल आयत के प्रत्येक किनारे को आकार की बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। सकारात्मक प्रतिशत इनसेट को दर्शाता है जबकि नकारात्मक प्रतिशत आउटसेट को।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक आयत `AutoShape` जोड़ें। 
4. एक छवि बनाएं।
5. आकार का फ़िल टाइप सेट करें।
6. आकार का पिक्चर फ़िल मोड सेट करें।
7. आकार को भरने के लिए इमेज सेट करें।
8. आकार की बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करें।
9. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दिखाता है कि StretchOff प्रॉपर्टी का उपयोग कैसे किया जाता है:

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx क्लास को इंस्टैंसिएट करता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Rectangle सेट के साथ एक AutoShape जोड़ता है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // शैल के फ़िल प्रकार को सेट करता है
    aShape.getFillFormat().setFillType(FillType.Picture);

    // शैल के पिक्चर फ़िल मोड को सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // शैल को भरने के लिए इमेज सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // शैल की बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करता है
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### पिक्चर फ्रेम के लिए कौन से इमेज फॉर्मेट सपोर्टेड हैं, मैं कैसे पता करूँ?

Aspose.Slides रास्टर इमेज (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेज (जैसे SVG) दोनों को सपोर्ट करता है, जब इमेज ऑब्जेक्ट को एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) से संबद्ध किया जाता है। सपोर्टेड फॉर्मेट की सूची आम तौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

### कई बड़ी इमेज जोड़ने से PPTX फाइल का आकार और परफ़ॉर्मेंस पर क्या असर पड़ेगा?

बड़ी इमेज को एम्बेड करने से फाइल का आकार और मेमोरी उपयोग बढ़ता है; इमेज को लिंक करने से प्रेजेंटेशन का आकार कम रहता है, लेकिन बाहरी फ़ाइलें उपलब्ध रहनी चाहिए। Aspose.Slides लिंक द्वारा इमेज जोड़ने की सुविधा देता है जिससे फाइल का आकार घटाया जा सके।

### इमेज ऑब्जेक्ट को अनजाने में मूव/रिसाइज़ होने से कैसे लॉक करूँ?

[shape locks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) का उपयोग करके आप एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) को लॉक कर सकते हैं (जैसे मूविंग या रिसाइज़िंग को डिसेबल करना)। यह लॉकिंग मैकेनिज़्म विभिन्न शैल प्रकारों के लिए समर्थित है, जिसमें [PictureFrame] भी शामिल है।

### PDF/इमेज में एक्सपोर्ट करने पर क्या SVG वेक्टर फ़िडेलिटी बनी रहती है?

Aspose.Slides आपको किसी [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG एक्सट्रैक्ट करने की अनुमति देता है। जब आप PDF या रास्टर फॉर्मेट (/slides/hi/androidjava/convert-powerpoint-to-pdf/, /slides/hi/androidjava/convert-powerpoint-to-png/) में एक्सपोर्ट करते हैं, तो एक्सपोर्ट सेटिंग्स के आधार पर परिणाम रास्टराइज़ हो सकता है; हालांकि मूल SVG वेक्टर के रूप में संग्रहीत रहता है, जैसा कि एक्सट्रैक्शन व्यवहार से पुष्टि होती है।