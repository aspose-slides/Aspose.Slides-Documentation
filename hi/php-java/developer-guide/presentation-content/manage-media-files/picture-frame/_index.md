---
title: PHP का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/php-java/picture-frame/
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
- पिक्चर फ्रेम फॉर्मेटिंग
- पिक्चर फ्रेम प्रॉपर्टीज़
- रिलेटिव स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने कार्यप्रवाह को सुव्यवस्थित करें और स्लाइड डिज़ाइन को बेहतर बनायें।"
---
## **परिचय**

एक पिक्चर फ्रेम वह आकार है जो छवि को समाहित करता है—यह फ्रेम में चित्र की तरह होता है।  

आप पिक्चर फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस तरह, आप पिक्चर फ्रेम को फॉर्मेट करके छवि को फॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="primary" %}} 

Aspose मुफ्त रूपांतरण उपकरण प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से शीघ्रता से प्रस्तुतियाँ बनाने की अनुमति देते हैं। 

{{% /alert %}} 

## **पिक्चर फ्रेम बनाना**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड की इंडेक्स के माध्यम से उसका रेफ़रेंस प्राप्त करें।  
3. उस छवि को जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसे प्रस्तुतिकरण ऑब्जेक्ट से जुड़े [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) में रखा जाएगा और आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा प्रदान किए गए `addPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) बनाएं।  
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड आपको पिक्चर फ्रेम बनाने का तरीका दिखाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # Image क्लास को इंस्टैंशिएट करता है
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # चित्र की समान ऊँचाई और चौड़ाई के साथ एक पिक्चर फ्रेम जोड़ता है
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTX फ़ाइल को डिस्क में लिखता है
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

पिक्चर फ्रेम आपको छवियों के आधार पर शीघ्रता से प्रस्तुति स्लाइड बनाने की सुविधा देता है। जब आप पिक्चर फ्रेम को Aspose.Slides के सेव विकल्पों के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित करके छवियों को एक फ़ॉर्मेट से दूसरे में रूपांतरित कर सकते हैं। आप इन पृष्ठों को देखना चाहेंगे: [image to JPG](/slides/hi/php-java/conversion/image-to-jpg/); [JPG to image](/slides/hi/php-java/conversion/jpg-to-image/); [JPG to PNG](/slides/hi/php-java/conversion/jpg-to-png/), [PNG to JPG](/slides/hi/php-java/conversion/png-to-jpg/); [PNG to SVG](/slides/hi/php-java/conversion/png-to-svg/), [SVG to PNG](/slides/hi/php-java/conversion/svg-to-png/).  

{{% /alert %}}

## **रिलेटिव स्केल के साथ पिक्चर फ्रेम बनाना**

छवि के रिलेटिव स्केल को बदलकर आप अधिक जटिल पिक्चर फ्रेम बना सकते हैं।  

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड की इंडेक्स के माध्यम से उसका रेफ़रेंस प्राप्त करें।  
3. प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ें।  
4. उस छवि को जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसे प्रस्तुतिकरण ऑब्जेक्ट से जुड़े [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) में रखा जाएगा और आकार को भरने के लिए उपयोग किया जाएगा।  
5. पिक्चर फ्रेम में छवि की रिलेटिव चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड आपको रिलेटिव स्केल के साथ पिक्चर फ्रेम बनाने का तरीका दिखाता है:

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # Image क्लास को इंस्टैंशिएट करता है
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ता है
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट करता है
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX फ़ाइल को डिस्क में लिखता है
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **पिक्चर फ्रेम से रास्टर छवियाँ निकालना**

आप [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) ऑब्जेक्ट से रास्टर छवियों को निकालकर PNG, JPG और अन्य फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दस्तावेज़ “sample.pptx” से छवि निकालकर PNG फ़ॉर्मेट में सहेजता है।

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **पिक्चर फ्रेम से SVG छवियाँ निकालना**

जब प्रस्तुति में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) आकारों में रखी होती हैं, तो Aspose.Slides for PHP via Java आपको मूल वेक्टर छवियों को पूर्ण फ़िडेलिटी के साथ पुनः प्राप्त करने देता है। स्लाइड की shape कलेक्शन को पार करके आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) की पहचान कर सकते हैं, यह जांच सकते हैं कि अंतर्निहित [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसकी मूल SVG फ़ॉर्मेट में डिस्क या स्ट्रीम पर सहेज सकते हैं।

निम्नलिखित कोड उदाहरण दर्शाता है कि पिक्चर फ्रेम से SVG छवि कैसे निकाली जाए:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **छवि की ट्रांसपरेंसी प्राप्त करना**

Aspose.Slides आपको छवि पर लागू ट्रांसपरेंसी प्रभाव प्राप्त करने की सुविधा देता है। यह PHP कोड इस कार्य को दर्शाता है:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **छवि की ब्राइटनेस और कॉन्ट्रास्ट प्राप्त करना**

Aspose.Slides आपको छवि पर लागू ब्राइटनेस और कॉन्ट्रास्ट प्रभाव प्राप्त करने की सुविधा देता है। यह इफ़ेक्ट [Luminance](https://reference.aspose.com/slides/hi/php-java/aspose.slides/luminance/) क्लास द्वारा दर्शाया जाता है।  

यह PHP कोड पिक्चर फ्रेम से ब्राइटनेस और कॉन्ट्रास्ट सेटिंग्स को प्राप्त करने का तरीका दिखाता है:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **पिक्चर फ्रेम फॉर्मेटिंग**

Aspose.Slides पिक्चर फ्रेम पर लागू किए जाने वाले कई फॉर्मेटिंग विकल्प प्रदान करता है। इन विकल्पों का उपयोग करके आप पिक्चर फ्रेम को विशिष्ट मानकों के अनुरूप बना सकते हैं।  

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड की इंडेक्स के माध्यम से उसका रेफ़रेंस प्राप्त करें।  
3. उस छवि को जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसे प्रस्तुतिकरण ऑब्जेक्ट से जुड़े [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) में रखा जाएगा और आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. स्लाइड से जुड़े [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएं।  
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।  
7. पिक्चर फ्रेम की लाइन रंग सेट करें।  
8. पिक्चर फ्रेम की लाइन चौड़ाई सेट करें।  
9. पिक्चर फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को clockwise घुमाता है।  
   * नकारात्मक मान छवि को anti‑clockwise घुमाता है।  
10. पिक्चर फ्रेम (जिसमें चित्र है) को फिर से स्लाइड में जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड पिक्चर फ्रेम फॉर्मेटिंग प्रक्रिया को दर्शाता है:

```php
  # PPTX को दर्शाने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # Image क्लास को इंस्टैंशिएट करता है
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # चित्र की समान ऊँचाई और चौड़ाई के साथ पिक्चर फ्रेम जोड़ता है
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx पर कुछ फॉर्मेटिंग लागू करता है
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX फ़ाइल को डिस्क में लिखता है
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी भी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाने, या फ़ोटो से ग्रिड बनाने की आवश्यकता हो, तो आप इस सेवा का उपयोग कर सकते हैं।  

{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ना**

बड़ी प्रस्तुति फ़ाइलों के आकार को कम करने के लिए आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियाँ (या वीडियो) जोड़ सकते हैं। यह PHP कोड आपको एक प्लेसहोल्डर में छवि और वीडियो जोड़ने का तरीका दिखाता है:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **छवियों को क्रॉप करना**

यह PHP कोड आपको स्लाइड पर मौजूद छवि को क्रॉप करने का तरीका दिखाता है:

```php
  $pres = new Presentation();
  # नई इमेज ऑब्जेक्ट बनाता है
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # स्लाइड में पिक्चर फ्रेम जोड़ता है
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # छवि को क्रॉप करता है (प्रतिशत मान)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # परिणाम को सहेजता है
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **पिक्चर के क्रॉप किए गए क्षेत्रों को हटाना**

यदि आप फ्रेम में स्थित छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।  

यह PHP कोड इस ऑपरेशन को दर्शाता है:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # पहली स्लाइड से पिक्चर फ्रेम प्राप्त करता है
    $picFrame = $slide->getShapes()->get_Item(0);
    # पिक्चर फ्रेम छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # परिणाम को सहेजता है
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) मेथड क्रॉप की गई छवि को प्रस्तुति इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रस्तुति के आकार को कम कर सकता है। अन्यथा, परिणामस्वरूप प्रस्तुति में छवियों की संख्या बढ़ेगी।  

यह मेथड क्रॉपिंग प्रक्रिया में WMF/EMF मेटाफाइल को रास्टर PNG छवि में बदलता है।  

{{% /alert %}}

## **छवियों को संपीड़ित करना**

आप प्रस्तुति में चित्र को [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) मेथड का उपयोग करके संपीड़ित कर सकते हैं। यह मेथड आकार को शैप के आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर घटाता है, साथ ही क्रॉप किए गए क्षेत्रों को हटाने का विकल्प देता है।  

यह PowerPoint के **Picture Format -> Compress Pictures -> Resolution** फीचर के समान कार्य करता है।  

निम्नलिखित PHP उदाहरण लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को संपीड़ित करने का तरीका दर्शाते हैं:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ छवि को संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएं।
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # संपीड़न के परिणाम की जाँच करें।
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

या सीधे एक कस्टम DPI मान का उपयोग करके:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # छवि को 150 DPI (वेब रिज़ॉल्यूशन) तक संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

यह मेथड शैप के आकार और प्रदान किए गए DPI के आधार पर छवि को कम रिज़ॉल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए हुए क्षेत्रों को भी हटाया जा सकता है।  
यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं किया जाएगा। JPEG की गुणवत्ता रिज़ॉल्यूशन के अनुसार संरक्षित या थोड़ा कम की जाएगी, जैसे PowerPoint उच्च‑रिज़ॉल्यूशन JPEG को संभालता है।  

{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करना**

यदि आप चाहते हैं कि छवि युक्त शैप नई छवि आयाम बदलने के बाद भी अपना आस्पेक्ट रेशियो बनाए रखे, तो आप [setAspectRatioLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) मेथड का उपयोग करके *Lock Aspect Ratio* सेटिंग को सेट कर सकते हैं।  

यह PHP कोड दिखाता है कि शैप के आस्पेक्ट रेशियो को कैसे लॉक किया जाए:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # आकार को बदलते समय आस्पेक्ट रेशियो बरकरार रखने के लिए सेट करें
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल शैप के आस्पेक्ट रेशियो को संरक्षित करती है, न कि उसमें सम्मिलित छवि को।  

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करना**

[PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) क्लास की [setStretchOffsetLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) और [setStretchOffsetBottom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) मेथड्स का उपयोग करके आप एक फिल रेक्टैंगल निर्दिष्ट कर सकते हैं।  

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो एक स्रोत रेक्टैंगल को निर्दिष्ट फिल रेक्टैंगल में फिट करने के लिए स्केल किया जाता है। फिल रेक्टैंगल के प्रत्येक किनारे को शैप की बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा 정의 किया जाता है। सकारात्मक प्रतिशत एक इनसेट दर्शाता है जबकि नकारात्मक प्रतिशत एक आउटसेट दर्शाता है।  

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड की इंडेक्स के माध्यम से उसका रेफ़रेंस प्राप्त करें।  
3. एक रेक्टैंगल `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. शैप का फिल टाइप सेट करें।  
6. शैप का पिक्चर फिल मोड सेट करें।  
7. शैप को भरने के लिए छवि सेट करें।  
8. शैप की बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दिखाता है कि StretchOff प्रॉपर्टी का उपयोग कैसे किया जाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # ImageEx क्लास को इंस्टैंशिएट करता है
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Rectangle सेट के साथ एक AutoShape जोड़ता है
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # shape की fill प्रकार सेट करता है
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # shape की picture fill मोड सेट करता है
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # shape को भरने के लिए इमेज सेट करता है
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # shape की बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफसेट निर्दिष्ट करता है
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX फ़ाइल को डिस्क में लिखता है
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**PictureFrame के लिए कौन से इमेज फ़ॉर्मेट समर्थित हैं, यह मैं कैसे पता कर सकता हूँ?**

Aspose.Slides रास्टर इमेज (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेज (जैसे SVG) दोनों को उस इमेज ऑब्जेक्ट के माध्यम से समर्थन करता है जिसे एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) को असाइन किया गया है। समर्थित फ़ॉर्मेट की सूची सामान्यतः स्लाइड और इमेज रूपांतरण इंजन की क्षमताओं के साथ ओवरलैप करती है।  

**दसियों बड़ी छवियों को जोड़ने से PPTX का आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति का आकार छोटा रहता है लेकिन बाहरी फ़ाइलों को सुलभ रखना आवश्यक है। Aspose.Slides फ़ाइल आकार घटाने के लिए लिंक द्वारा छवियों को जोड़ने की सुविधा प्रदान करता है।  

**मैं आकस्मिक मूव या रिसाइज़ से छवि ऑब्जेक्ट को कैसे लॉक कर सकता हूँ?**

एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) के लिए आप [shape locks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/getpictureframelock/) का उपयोग कर सकते हैं (जैसे मूव या रिसाइज़ को अक्षम करना)। लॉकिंग मैकेनिज़्म विभिन्न शैप प्रकारों के लिए समर्थित है, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) भी शामिल है।  

**PDF/छवियों में निर्यात करते समय क्या SVG वेक्टर फ़िडेलिटी बनी रहती है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने देता है। जब आप [PDF में निर्यात](/slides/hi/php-java/convert-powerpoint-to-pdf/) या [रास्टर फ़ॉर्मेट](/slides/hi/php-java/convert-powerpoint-to-png/) में निर्यात करते हैं, तो परिणाम निर्यात सेटिंग्स के आधार पर रास्टराइज़ हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहित किया गया रहने की पुष्टि निकाली गई व्यवहार द्वारा होती है।  