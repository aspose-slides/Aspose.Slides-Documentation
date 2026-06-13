---
title: PHP का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन
type: docs
weight: 10
url: /hi/php-java/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
- वेब से
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- EMF
- SVG
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument में Aspose.Slides for PHP via Java के साथ छवि प्रबंधन को सुगम बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियाँ प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइल, इंटरनेट या अन्य स्थानों से चित्रों को स्लाइड्स पर डाल सकते हैं। इसी प्रकार, Aspose.Slides आपको विभिन्न प्रक्रियाओं के माध्यम से आपके प्रस्तुतियों की स्लाइड्स में छवियां जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रस्तुतियों बनाने की अनुमति देते हैं। 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
यदि आप किसी छवि को फ्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप इसका आकार बदलने, प्रभाव जोड़ने आदि के लिए मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बना रहे हैं—तो देखें [Picture Frame](/slides/hi/php-java/picture-frame/)।
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
आप छवियों और PowerPoint प्रस्तुतियों से संबंधित इनपुट/आउटपुट ऑपरेशन्स को संचालित कर सकते हैं ताकि एक छवि को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में बदल सकें। इन पृष्ठों को देखें: परिवर्तित करें [image to JPG](https://products.aspose.com/slides/hi/php-java/conversion/image-to-jpg/); परिवर्तित करें [JPG to image](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-image/); परिवर्तित करें [JPG to PNG](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-png/), परिवर्तित करें [PNG to JPG](https://products.aspose.com/slides/hi/php-java/conversion/png-to-jpg/); परिवर्तित करें [PNG to SVG](https://products.aspose.com/slides/hi/php-java/conversion/png-to-svg/), परिवर्तित करें [SVG to PNG](https://products.aspose.com/slides/hi/php-java/conversion/svg-to-png/)।
{{% /alert %}}

Aspose.Slides इन लोकप्रिय फ़ॉर्मेट्स में छवियों के साथ ऑपरेशन्स को सपोर्ट करता है: JPEG, PNG, GIF, और अन्य। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर की एक या कई छवियों को प्रस्तुति की स्लाइड पर जोड़ सकते हैं। यह नमूना कोड आपको दिखाता है कि एक छवि को स्लाइड में कैसे जोड़ें:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप इसे सीधे वेब से जोड़ सकते हैं। 

यह नमूना कोड आपको दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **स्लाइड मास्टर्स में छवियों को जोड़ें**

स्लाइड मास्टर वह शीर्ष स्लाइड है जो इसके नीचे सभी स्लाइड्स की जानकारी (थीम, लेआउट, आदि) संग्रहीत और नियंत्रित करता है। इसलिए, जब आप स्लाइड मास्टर में एक छवि जोड़ते हैं, वह छवि उस स्लाइड मास्टर के तहत सभी स्लाइड्स पर दिखाई देती है। 

यह Java नमूना कोड आपको दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **स्लाइड पृष्ठभूमि के रूप में छवियों को जोड़ें**

आप एक विशिष्ट स्लाइड या कई स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग करने का निर्णय ले सकते हैं। ऐसी स्थिति में, आपको देखना होगा कि [Set an Image as a Slide Background](/slides/hi/php-java/presentation-background/#set-an-image-as-a-slide-background) कैसे करें।

## **प्रस्तुतियों में SVG जोड़ें**
आप किसी भी छवि को प्रस्तुति में जोड़ या सम्मिलित कर सकते हैं, इसके लिए आप [addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) मेथड का उपयोग कर सकते हैं जो [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास का हिस्सा है।

SVG छवि के आधार पर एक इमेज ऑब्जेक्ट बनाने के लिए, आप इसे इस प्रकार कर सकते हैं:

1. SvgImage ऑब्जेक्ट बनाएं और इसे ImageShapeCollection में डालें
2. ISvgImage से PPImage ऑब्जेक्ट बनाएं
3. PPImage क्लास का उपयोग करके PictureFrame ऑब्जेक्ट बनाएं

यह नमूना कोड आपको दिखाता है कि ऊपर वर्णित कदमों को लागू करके SVG छवि को प्रस्तुति में कैसे जोड़ें:
```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SVG को आकारों के सेट में बदलें**
Aspose.Slides' conversion of SVG to a set of shapes is similar to the PowerPoint functionality used to work with SVG images:

![PowerPoint Popup Menu](img_01_01.png)

The functionality is provided by one of the overloads of the [addGroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addgroupshape/) method of the [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) class that takes an [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) object as the first argument.

This sample code shows you how to use the described method to convert an SVG file to a set of shapes:

```php
  # नई प्रस्तुति बनाएं
  $presentation = new Presentation();
  try {
    # SVG फ़ाइल सामग्री पढ़ें
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # SvgImage ऑब्जेक्ट बनाएं
    $svgImage = new SvgImage($svgContent);
    # स्लाइड आकार प्राप्त करें
    $slideSize = $presentation->getSlideSize()->getSize();
    # SVG छवि को आकारों के समूह में बदलें और स्लाइड आकार के अनुसार स्केल करें
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **स्लाइड्स में EMF के रूप में छवियों को जोड़ें**
Aspose.Slides for PHP via Java आपको Excel शीट्स से EMF छवियाँ उत्पन्न करने और उन्हें Aspose.Cells के साथ स्लाइड्स में EMF के रूप में जोड़ने की अनुमति देता है।  

This sample code shows you how to perform the described task:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # वर्कबुक को स्ट्रीम में सहेजें
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **इमेज कलेक्शन में छवियों को बदलें**
Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन में संग्रहीत छवियों (स्लाइड आकारों द्वारा उपयोग की गई छवियों सहित) को बदलने की अनुमति देता है। इस अनुभाग में कलेक्शन में छवियों को अपडेट करने के कई तरीके दिखाए गए हैं। API कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि को बदलने के सरल तरीके प्रदान करता है।

1. Presentation क्लास का उपयोग करके उन छवियों वाली प्रस्तुति फ़ाइल लोड करें।
2. फ़ाइल से एक नई छवि को बाइट ऐरे में लोड करें।
3. बाइट ऐरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. दूसरे तरीके में, छवि को एक IImage ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद किसी छवि से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें।
$presentation = new Presentation("sample.pptx");
try {
    // पहला तरीका।
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // दूसरा तरीका।
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // तीसरा तरीका।
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // प्रस्तुति को फ़ाइल में सहेजें।
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose FREE [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर का उपयोग करके, आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं, टेक्स्ट से GIF बना सकते हैं, आदि। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि डालने के बाद मूल रेज़ोल्यूशन बना रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम स्वरूप इस बात पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/php-java/picture-frame/) कैसे स्केल किया गया है और सहेजते समय कोई संपीड़न लागू हुआ है या नहीं।

**कई स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति के इमेज कलेक्शन में बदलें—अपडेट उस संसाधन का उपयोग करने वाले सभी तत्वों में फैल जाएगा।

**क्या सम्मिलित SVG को संपादन योग्य आकारों में बदला जा सकता है?**

हाँ। आप SVG को आकारों के समूह में बदल सकते हैं, उसके बाद व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं कई स्लाइड्स की पृष्ठभूमि के रूप में एक चित्र को एक साथ कैसे सेट करूँ?**

[Assign the image as the background](/slides/hi/php-java/presentation-background/) को मास्टर स्लाइड या संबंधित लेआउट पर सेट करें—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में ले लेगी।

**मैं कई चित्रों के कारण प्रस्तुति के आकार के "ballooning" को कैसे रोकूँ?**

डुप्लिकेट की बजाय एक ही छवि संसाधन का पुन: उपयोग करें, उचित रेज़ोल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उचित हो दोहराई गई ग्राफिक्स को मास्टर पर रखें।