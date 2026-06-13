---
title: PHP का उपयोग करके प्रस्तुतियों में चित्र फ्रेम का प्रबंधन
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/php-java/picture-frame/
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
- चित्र फ्रेम फॉर्मेटिंग
- चित्र फ्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

एक चित्र फ्रेम वह आकार है जो एक छवि को समाहित करता है—यह फ्रेम में चित्र की तरह है।

आप एक चित्र फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस प्रकार, आप चित्र फ्रेम को फॉर्मेट करके छवि को फॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त कनवर्टर्स प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से तेज़ी से प्रस्तुतियां बनाने की अनुमति देते हैं। 
{{% /alert %}} 

## **एक चित्र फ्रेम बनाएं**

1. Presentation क्लास का एक instance बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट के जुड़े हुए ImageCollection में छवि जोड़कर एक PPImage ऑब्जेक्ट बनाएं, जिसे आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. संदर्भित स्लाइड की shape ऑब्जेक्ट पर उपलब्ध `addPictureFrame` मेथड का उपयोग करके PictureFrame बनाएं।  
6. स्लाइड में एक चित्र फ्रेम (जैसे चित्र शामिल) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दिखाता है कि कैसे एक चित्र फ्रेम बनाया जाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # Image क्लास को इंस्टैंसिएट करता है
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # चित्र की समान ऊँचाई और चौड़ाई के साथ एक picture frame जोड़ता है
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Picture frames आपको छवियों के आधार पर जल्दी से प्रस्तुतियों के स्लाइड बनाने की सुविधा देते हैं। जब आप चित्र फ्रेम को Aspose.Slides के सेव ऑप्शन के साथ जोड़ते हैं, तो आप इनपुट/आउटपुट ऑपरेशनों को नियंत्रित कर सकते हैं ताकि छवियों को एक फॉर्मेट से दूसरे में बदल सकें। आप इन पृष्ठों को देखना चाह सकते हैं: convert [image to JPG](https://products.aspose.com/slides/hi/php-java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/php-java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/php-java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **सापेक्ष स्केल के साथ एक चित्र फ्रेम बनाएं**

एक छवि की सापेक्ष स्केलिंग को बदलकर आप अधिक जटिल चित्र फ्रेम बना सकते हैं।

1. Presentation क्लास का एक instance बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रस्तुति की ImageCollection में एक छवि जोड़ें।  
4. प्रस्तुति ऑब्जेक्ट के जुड़े हुए ImageCollection में छवि जोड़कर एक PPImage ऑब्जेक्ट बनाएं, जिसे आकार को भरने के लिए उपयोग किया जाएगा।  
5. चित्र फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दर्शाता है कि कैसे सापेक्ष स्केल के साथ चित्र फ्रेम बनाया जाता है:

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # Image क्लास को इंस्टैंसिएट करता है
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ता है
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट कर रहा है
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चित्र फ्रेम से रेस्टर छवियों को निकालें**

आप PictureFrame ऑब्जेक्ट्स से रेस्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG तथा अन्य प्रारूपों में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे दस्तावेज़ "sample.pptx" से छवि निकाली जाए और PNG प्रारूप में सहेजी जाए।

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

## **चित्र फ्रेम से SVG छवियों को निकालें**

जब किसी प्रस्तुति में SVG ग्राफिक्स को PictureFrame आकार के भीतर रखा जाता है, तो Aspose.Slides for PHP via Java आपको मूल वेक्टर छवियों को पूर्ण स्तरीयता के साथ पुनः प्राप्त करने देता है। स्लाइड की shape कलेक्शन को पार करके आप प्रत्येक PictureFrame की पहचान कर सकते हैं, जाँच सकते हैं कि अंतर्निहित PPImage में SVG सामग्री है या नहीं, और फिर उस छवि को उसके मूल SVG फ़ॉर्मैट में डिस्क या स्ट्रीम में सहेज सकते हैं।

निम्नलिखित कोड उदाहरण दर्शाता है कि कैसे एक PictureFrame से SVG छवि निकाली जाती है:

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

## **छवि की पारदर्शिता प्राप्त करें**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने की अनुमति देता है। यह PHP कोड इस ऑपरेशन को दर्शाता है:

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

## **चित्र फ्रेम फॉर्मेटिंग**

Aspose.Slides विभिन्न फॉर्मेटिंग विकल्प प्रदान करता है जो एक चित्र फ्रेम पर लागू किए जा सकते हैं। इन विकल्पों का उपयोग करके आप चित्र फ्रेम को विशिष्ट आवश्यकताओं के अनुसार बदल सकते हैं।

1. Presentation क्लास का एक instance बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट के जुड़े हुए ImageCollection में छवि जोड़कर एक PPImage ऑब्जेक्ट बनाएं, जिसे आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. संदर्भित स्लाइड की ShapeCollection ऑब्जेक्ट पर उपलब्ध [addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) मेथड का उपयोग करके PictureFrame बनाएं।  
6. स्लाइड में चित्र फ्रेम (जैसे चित्र शामिल) जोड़ें।  
7. चित्र फ्रेम की लाइन कलर सेट करें।  
8. चित्र फ्रेम की लाइन चौड़ाई सेट करें।  
9. चित्र फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को घड़ी की विपरीत दिशा में घुमाता है।  
10. चित्र फ्रेम (जैसे चित्र शामिल) को फिर से स्लाइड में जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड चित्र फ्रेम फॉर्मेटिंग प्रक्रिया को प्रदर्शित करता है:

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # Image क्लास को इंस्टैंसिएट करता है
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # चित्र की समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ता है
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx पर कुछ फॉर्मेटिंग लागू करता है
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}} 
Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG को मर्ज] करना हो या PNG छवियों को मिलाना हो, या [फ़ोटो ग्रिड बनाना] हो, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ें**

बड़ी प्रस्तुति आकारों से बचने के लिए आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियों (या वीडियो) को जोड़ सकते हैं। यह PHP कोड दिखाता है कि कैसे एक प्लेसहोल्डर में छवि और वीडियो लिंक जोड़ें:

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

## **छवियों को क्रॉप करें**

यह PHP कोड दिखाता है कि स्लाइड पर मौजूदा छवि को कैसे क्रॉप किया जाए:

```php
  $pres = new Presentation();
  # नई छवि वस्तु बनाता है
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
    # स्लाइड में एक PictureFrame जोड़ता है
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # छवि को क्रॉप करता है (प्रतिशत मान)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # परिणाम सहेजता है
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चित्र के क्रॉप किए हुए क्षेत्रों को हटाएं**

यदि आप फ्रेम में मौजूद छवि के क्रॉप किए हुए क्षेत्रों को हटाना चाहते हैं, तो आप [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि को लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह PHP कोड इस ऑपरेशन को दर्शाता है:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # पहली स्लाइड से PictureFrame प्राप्त करता है
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame छवि के क्रॉप किए हुए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # परिणाम सहेजता है
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) मेथड क्रॉप की हुई छवि को प्रस्तुति की ImageCollection में जोड़ता है। यदि छवि केवल प्रोसेस किए गए PictureFrame में उपयोग हुई है, तो यह सेटअप प्रस्तुति आकार को कम कर सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ जाएगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटाफाइल को रास्टर PNG छवि में बदलता है। 
{{% /alert %}}

## **छवियों को संपीड़ित करें**

आप प्रस्तुति में चित्र को [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) मेथड का उपयोग करके संपीड़ित कर सकते हैं। यह मेथड आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर छवि का आकार घटाकर संपीड़न करता है, और वैकल्पिक रूप से क्रॉप किए हुए क्षेत्रों को हटाने की सुविधा देता है।

यह PowerPoint के **Picture Format → Compress Pictures → Resolution** फीचर के समान कार्य करता है।

निम्नलिखित PHP उदाहरण दर्शाते हैं कि कैसे लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए हुए क्षेत्रों को हटाकर प्रस्तुति में छवि को संपीड़ित किया जाए:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 150 DPI (Web resolution) के लक्ष्य रिज़ॉल्यूशन के साथ छवि को संपीड़ित करें और क्रॉप किए हुए क्षेत्रों को हटाएँ।
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

या सीधे कस्टम DPI मान का उपयोग करके:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # छवि को 150 DPI (वेब रिज़ोल्यूशन) पर संपीड़ित करें, क्रॉप किए हुए क्षेत्रों को हटाते हुए।
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
यह मेथड आकार और प्रदान किए गए DPI के आधार पर छवि को कम रिज़ॉल्यूशन में बदलता है। क्रॉप किए हुए क्षेत्रों को भी हटाया जा सकता है ताकि फ़ाइल आकार अनुकूलित हो। यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं होगा। JPEG की गुणवत्ता भी रिज़ॉल्यूशन के अनुसार समान रूप से बनी रहती है या थोड़ा घटती है, जैसा कि PowerPoint उच्च‑रिज़ॉल्यूशन JPEG को संभालता है। 
{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करें**

यदि आप चाहते हैं कि छवि वाले आकार को छवि के आयाम बदलने पर भी उसका आस्पेक्ट रेशियो बना रहे, तो आप [setAspectRatioLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) मेथड का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं।

यह PHP कोड दिखाता है कि कैसे आकार का आस्पेक्ट रेशियो लॉक किया जाए:

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
    # री‑साइज़ करने पर आकृति के आस्पेक्ट रेशियो को सुरक्षित रखने के लिए सेट करें
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
यह *Lock Aspect Ratio* सेटिंग केवल आकार के आस्पेक्ट रेशियो को संरक्षित करती है, छवि को नहीं। 
{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) क्लास की [setStretchOffsetLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) और [setStretchOffsetBottom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) मेथड्स का उपयोग करके आप एक भराव आयत निर्दिष्ट कर सकते हैं।

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत आयत को निर्धारित भराव आयत में फिट करने के लिए स्केल किया जाता है। भराव आयत का प्रत्येक किनारा आकार की बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। सकारात्मक प्रतिशत इन्सेट को दर्शाता है जबकि नकारात्मक प्रतिशत आउटसेट को।

1. Presentation क्लास का एक instance बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. एक AutoShape आयत जोड़ें।  
4. एक छवि बनाएं।  
5. आकार की भराव प्रकार सेट करें।  
6. आकार की चित्र भराव मोड सेट करें।  
7. आकार को भरने के लिए सेट छवि जोड़ें।  
8. आकार की बाउंडिंग बॉक्स के संबंधित किनारे से छवि के ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दर्शाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # ImageEx क्लास को इंस्टैंसिएट करता है
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Rectangle पर सेट किया गया AutoShape जोड़ता है
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # आकृति का फ़िल टाइप सेट करता है
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # आकृति का चित्र भराव मोड सेट करता है
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # आकृति को भरने के लिए छवि सेट करता है
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # आकृति के बाउंडिंग बॉक्स के संबंधित किनारे से छवि के ऑफ़सेट निर्दिष्ट करता है
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**How can I find out which image formats are supported for PictureFrame?**  
Aspose.Slides रास्टर छवियों (PNG, JPEG, BMP, GIF आदि) और वेक्टर छवियों (जैसे SVG) दोनों का समर्थन करता है, जब छवि ऑब्जेक्ट को एक PictureFrame को असाइन किया जाता है। समर्थित फ़ॉर्मैटों की सूची आम तौर पर स्लाइड और इमेज कनवर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

**How will adding dozens of large images affect PPTX size and performance?**  
बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; लिंक के माध्यम से छवियों को जोड़ने से प्रस्तुति आकार कम रहता है लेकिन बाहरी फ़ाइलों की उपलब्धता आवश्यक होती है। Aspose.Slides लिंक द्वारा छवियां जोड़ने की सुविधा प्रदान करता है जिससे फ़ाइल आकार घटाया जा सकता है।

**How can I lock an image object from accidental moving/resizing?**  
आप PictureFrame के लिए [shape locks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/getpictureframelock/) का उपयोग कर सकते हैं (जैसे मूविंग या रिसाइज़िंग को अक्षम करना)। लॉकिंग मैकेनिज्म विभिन्न shape प्रकारों के लिए समर्थित है, जिसमें PictureFrame भी शामिल है।

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  
Aspose.Slides आपको एक PictureFrame से मूल वेक्टर के रूप में SVG निकालने देता है। जब PDF या रास्टर फ़ॉर्मैट्स में एक्सपोर्ट किया जाता है, तो परिणाम एक्सपोर्ट सेटिंग्स पर निर्भर करता है; मूल SVG को वेक्टर के रूप में संग्रहीत रखा जाता है, जो Extraction व्यवहार द्वारा प्रमाणित होता है।