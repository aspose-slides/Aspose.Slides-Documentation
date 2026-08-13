---
title: जावा का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएँ
- छवि जोड़ें
- छवि बनाएँ
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया गया क्षेत्र
- StretchOff प्रॉपर्टी
- पिक्चर फ्रेम फॉर्मेटिंग
- पिक्चर फ्रेम प्रॉपर्टीज़
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने कार्यप्रवाह को सुव्यवस्थित करें और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

एक पिक्चर फ्रेम वह आकार है जो छवि को सम्मिलित करता है—यह एक फ्रेम में तस्वीर की तरह है।

आप एक पिक्चर फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस तरह, आप पिक्चर फ्रेम को फॉर्मेट करके छवि को फॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="info" %}} 

Aspose मुफ्त रूपांतरणकर्ता प्रदान करता है—[JPEG को PowerPoint में](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG को PowerPoint में](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रस्तुति बनाने की सुविधा देता है। 

{{% /alert %}} 

## **पिक्चर फ्रेम बनाना**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रेजेंटेशन ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में छवि जोड़कर एक [IPPImage]() ऑब्जेक्ट बनाएं जो आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. रेफ़रेंस किए गए स्लाइड से जुड़े शेम ऑब्जेक्ट द्वारा प्रदर्शित `AddPictureFrame` मेथड का उपयोग करके छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PictureFrame) बनाएं।  
6. स्लाइड में एक पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दर्शाता है कि पिक्चर फ्रेम कैसे बनाएं:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का उदाहरण बनाता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ एक पिक्चर फ्रेम जोड़ता है
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

पिक्चर फ्रेम आपको छवियों के आधार पर शीघ्रता से प्रस्तुति स्लाइड बनाने की अनुमति देता है। जब आप पिक्चर फ्रेम को Aspose.Slides की सहेजने विकल्पों के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट ऑपरेशनों को नियंत्रित करके एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवियों को परिवर्तित कर सकते हैं। आप इन पृष्ठों को देखना चाहेंगे: रूपांतरण [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); रूपांतरण [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); रूपांतरण [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), रूपांतरण [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); रूपांतरण [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), रूपांतरण [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/). 

{{% /alert %}}

## **सापेक्ष स्केल के साथ पिक्चर फ्रेम बनाना**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रेजेंटेशन की इमेज कलेक्शन में एक छवि जोड़ें।  
4. प्रेजेंटेशन ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं जो आकार को भरने के लिए उपयोग किया जाएगा।  
5. पिक्चर फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दर्शाता है कि सापेक्ष स्केल के साथ पिक्चर फ्रेम कैसे बनाएं:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX को दर्शाने वाले Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का उदाहरण बनाता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ता है
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट कर रहा है
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **पिक्चर फ्रेम से रास्टर इमेज निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PictureFrame) ऑब्जेक्ट से रास्टर इमेज निकाल सकते हैं और उन्हें PNG, JPG और अन्य फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दर्शाता है कि दस्तावेज़ “sample.pptx” से इमेज कैसे निकाली जाए और PNG फ़ॉर्मेट में सहेजी जाए।

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

## **पिक्चर फ्रेम से SVG इमेज निकालें**

जब कोई प्रस्तुति SVG ग्राफिक्स को [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) आकारों के अंदर रखती है, तो Aspose.Slides for Java आपको मूल वेक्टर इमेज को पूर्ण सटीकता के साथ पुनः प्राप्त करने की सुविधा देता है। स्लाइड के आकार संग्रह को पार करके आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस इमेज को डिस्क या स्ट्रीम में मूल SVG फ़ॉर्मेट में सहेज सकते हैं।

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

        // जब चित्र रास्टर इमेज होता है, तो getSvgImage null लौटाता है।
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **छवि की पारदर्शिता प्राप्त करें**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने की सुविधा देता है। यह Java कोड ऑपरेशन को दर्शाता है:

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

## **छवि की चमक और कंट्रास्ट प्राप्त करें**

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव को प्राप्त करने की सुविधा देता है। [ILuminance](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iluminance/) इंटरफ़ेस इस इमेज ट्रांसफ़ॉर्म प्रभाव का प्रतिनिधित्व करता है।

यह Java कोड दर्शाता है कि पिक्चर फ्रेम से चमक और कंट्रास्ट सेटिंग्स कैसे प्राप्त करें:

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

## **पिक्चर फ्रेम फॉर्मेटिंग**

Aspose.Slides पिक्चर फ्रेम पर लागू किए जा सकने वाले कई फ़ॉर्मेटिंग विकल्प प्रदान करता है। इन विकल्पों का उपयोग करके आप पिक्चर फ्रेम को विशिष्ट आवश्यकताओं के अनुरूप बना सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रेजेंटेशन ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट बनाएं जो आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. रेफ़रेंस किए गए स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदर्शित [AddPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड का उपयोग करके छवि की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएं।  
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।  
7. पिक्चर फ्रेम की लाइन का रंग सेट करें।  
8. पिक्चर फ्रेम की लाइन की चौड़ाई सेट करें।  
9. पिक्चर फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान चित्र को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान चित्र को एंटी‑क्लॉकवाइज़ घुमाता है।  
10. पिक्चर फ्रेम (जिसमें चित्र है) को स्लाइड में फिर से जोड़ें।  
11. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड पिक्चर फ्रेम फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX को दर्शाने वाले Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image क्लास का उदाहरण बनाता है
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ता है
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

{{% alert title="Tip" color="info" %}}

Aspose ने हाल ही में एक [नि:शुल्क कोलाज मेकर](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG मिलाना](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना हो, या [फ़ोटो से ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) हो, तो आप इस सेवा का उपयोग कर सकते हैं। 

{{% /alert %}}

## **एक लिंक के रूप में इमेज जोड़ें**

प्रस्तुति का आकार छोटा रखने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियों (या वीडियो) को जोड़ सकते हैं। यह Java कोड दिखाता है कि प्लेसहोल्डर में इमेज और वीडियो कैसे जोड़ें:

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

## **इमेज क्रॉप करें**

यह Java कोड दिखाता है कि स्लाइड पर मौजूद मौजूदा इमेज को कैसे क्रॉप करें:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

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

    // स्लाइड में एक पिक्चर फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // इमेज को क्रॉप करता है (प्रतिशत मान)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // परिणाम को सहेजता है
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ्रेम की क्रॉप की गई क्षेत्र को हटाएं**

यदि आप फ्रेम में सम्मिलित इमेज के क्रॉप किए हुए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई इमेज या मूल इमेज लौटाता है यदि क्रॉपिंग की आवश्यकता नहीं है।

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पहली स्लाइड से पिक्चर फ्रेम प्राप्त करता है
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // पिक्चर फ्रेम छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि वापस करता है
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // परिणाम को सहेजता है
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) मेथड क्रॉप की गई इमेज को प्रेजेंटेशन इमेज कलेक्शन में जोड़ता है। यदि इमेज केवल प्रक्रिया किए गए [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रस्तुति का आकार घटा सकता है। अन्यथा, परिणामी प्रस्तुति में इमेजों की संख्या बढ़ेगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटाफाइल को रास्टर PNG इमेज में परिवर्तित करता है। 

{{% /alert %}}

## **इमेज कम्प्रेस करें**

आप [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) मेथड का उपयोग करके प्रस्तुति में पिक्चर को कम्प्रेस कर सकते हैं। यह मेथड आकार और निर्दिष्ट रेज़ोल्यूशन के आधार पर इमेज का आकार घटाकर इसे कम्प्रेस करता है, साथ ही क्रॉप किए गए क्षेत्रों को हटाने का विकल्प प्रदान करता है।

यह PowerPoint के **Picture Format -> Compress Pictures -> Resolution** विकल्प के समान कार्य करता है।

निम्न Java उदाहरण दर्शाते हैं कि लक्ष्य रेज़ोल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में इमेज को कैसे कम्प्रेस किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 150 DPI (वेब रिजॉल्यूशन) के लक्ष्य रिजॉल्यूशन के साथ छवि को संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // संपीड़न के परिणाम की जाँच करें।
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
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // छवि को 150 DPI (वेब रिजॉल्यूशन) पर संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

यह मेथड आकार और प्रदान किए गए DPI के आधार पर इमेज को कम रेज़ोल्यूशन में बदलता है। क्रॉप किए गए क्षेत्रों को हटाकर फ़ाइल आकार को अनुकूलित भी किया जा सकता है।  
यदि इमेज एक मेटाफाइल (WMF/EMF) या SVG है, तो कम्प्रेशन लागू नहीं किया जाएगा। JPEG गुणवत्ता रेज़ोल्यूशन के अनुसार बनी रहती है या थोड़ी घटती है, जैसा कि PowerPoint उच्च‑रिज़ोल्यूशन JPEG को संभालता है। 

{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करें**

यदि आप चाहते हैं कि छवि वाली आकार बदलने पर भी उसका आस्पेक्ट रेशियो बना रहे, तो आप [setAspectRatioLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) मेथड का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं। 

यह Java कोड दिखाता है कि आकार का आस्पेक्ट रेशियो कैसे लॉक किया जाए:

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

    // आकार को री‑साइज़ करने पर आस्पेक्ट रेशियो बनाए रखने के लिए सेट करें
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल आकार के आस्पेक्ट रेशियो को संरक्षित करती है, न कि उसमें सम्मिलित छवि को। 

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat) क्लास से [StretchOffsetLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) प्रॉपर्टी का उपयोग करके आप एक फ़िल रेक्टैंगल निर्धारित कर सकते हैं।  

जब किसी इमेज के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत रेक्टैंगल को निर्दिष्ट फ़िल रेक्टैंगल में फिट होने के लिये स्केल किया जाता है। फ़िल रेक्टैंगल का प्रत्येक किनारा आकार के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। सकारात्मक प्रतिशत इंट्रेस्ट दर्शाता है जबकि नकारात्मक प्रतिशत आउट्रेस्ट दर्शाता है।  

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक आयत `AutoShape` जोड़ें।  
4. एक इमेज बनाएं।  
5. आकार की फ़िल टाइप सेट करें।  
6. आकार की पिक्चर फ़िल मोड सेट करें।  
7. आकार को भरने के लिए इमेज सेट करें।  
8. आकार के बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दिखाता है कि StretchOff प्रॉपर्टी का उपयोग कैसे किया जाता है:

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx क्लास का उदाहरण बनाता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Rectangle सेट किया गया AutoShape जोड़ता है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // आकार की फ़िल टाइप सेट करता है
    aShape.getFillFormat().setFillType(FillType.Picture);

    // आकार के चित्र फ़िल मोड को सेट करता है
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // आकार को भरने के लिये इमेज सेट करता है
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // आकार के बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करता है
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### पिक्चर फ्रेम के लिए कौन से इमेज फ़ॉर्मेट समर्थित हैं, मैं कैसे पता करूँ?

Aspose.Slides रास्टर इमेज (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेज (उदाहरण के लिए SVG) दोनों को सपोर्ट करता है, जो एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) को असाइन किए गए इमेज ऑब्जेक्ट के माध्यम से उपयोग होते हैं। समर्थित फ़ॉर्मेट की सूची सामान्यतः स्लाइड और इमेज रूपांतरण इंजन की क्षमताओं के साथ ओवरलैप करती है।

### बहुत सारी बड़ी इमेज जोड़ने से PPTX का आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?

बड़ी इमेज एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; इमेज को लिंक करने से प्रस्तुति का आकार कम रहता है लेकिन बाहरी फ़ाइलों को सुलभ रखना आवश्यक है। Aspose.Slides लिंक द्वारा इमेज जोड़ने की सुविधा प्रदान करता है जिससे फ़ाइल आकार घटाया जा सके।

### इमेज ऑब्जेक्ट को आकस्मिक मूव/रिसाइज़ से कैसे लॉक करूँ?

[shape locks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) का उपयोग करके आप एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) को लॉक कर सकते हैं (उदा., मूव या रिसाइज़ निष्क्रिय करना)। लॉकिंग मेकेनिज़्म अलग से [protection article](/slides/hi/java/applying-protection-to-presentation/) में वर्णित है और विभिन्न आकार प्रकारों, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) भी शामिल है, के लिए समर्थित है।

### SVG वेक्टर फ़िडेलिटी को PDF/इमेज में निर्यात करने पर बनाए रखा जाता है क्या?

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की सुविधा देता है। जब आप PDF में निर्यात करते हैं (/slides/hi/java/convert-powerpoint-to-pdf/) या रास्टर फ़ॉर्मेट में (/slides/hi/java/convert-powerpoint-to-png/), तो परिणाम निर्यात सेटिंग्स के आधार पर रास्टराइज़ हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत रहने की पुष्टि एक्सट्रैक्शन व्यवहार से होती है।