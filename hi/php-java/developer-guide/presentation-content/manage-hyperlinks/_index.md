---
title: PHP में प्रस्तुति हाइपरलिंक्स प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/php-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएँ
- हाइपरलिंक अपडेट करें
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स को आसानी से प्रबंधित करें — मिनटों में इंटरैक्टिविटी और कार्यप्रवाह को बेहतर बनाएं।"
---
## **परिचय**

हाइपरलिंक एक वस्तु, डेटा या किसी स्थान का संदर्भ है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक्स हैं:

* पाठ, आकार या मीडिया के भीतर वेबसाइटों के लिंक
* स्लाइडों के लिंक

Aspose.Slides for PHP via Java आपको प्रस्तुतियों में हाइपरलिंक्स से संबंधित कई कार्य करने की अनुमति देता है।

{{% alert color="primary" %}} 

आप Aspose Simple, [नि:शुल्क ऑनलाइन PowerPoint संपादक।](https://products.aspose.app/slides/hi/editor) को देखना चाह सकते हैं।

{{% /alert %}}

## **URL हाइपरलिंक्स जोड़ें**

### **पाठ में URL हाइपरलिंक्स जोड़ें**

यह PHP कोड बताता है कि कैसे एक वेबसाइट हाइपरलिंक को पाठ में जोड़ें:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **आकार या फ्रेम में URL हाइपरलिंक्स जोड़ें**

यह नमूना कोड दिखाता है कि कैसे एक वेबसाइट हाइपरलिंक को आकार में जोड़ें:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **मीडिया में URL हाइपरलिंक्स जोड़ें**

Aspose.Slides आपको छवियों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है।

यह नमूना कोड दिखाता है कि कैसे एक **छवि** में हाइपरलिंक जोड़ें:

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में छवि जोड़ता है
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # पहले जोड़ी गई छवि के आधार पर स्लाइड 1 पर चित्र फ्रेम बनाता है
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यह नमूना कोड दिखाता है कि कैसे एक **ऑडियो फ़ाइल** में हाइपरलिंक जोड़ें:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यह नमूना कोड दिखाता है कि कैसे एक **वीडियो** में हाइपरलिंक जोड़ें:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="सलाह"  color="primary"  %}} 

आप *[Manage OLE](/slides/hi/php-java/manage-ole/)* देखना चाह सकते हैं।

{{% /alert %}}

## **हाइपरलिंक्स का उपयोग करके तालिका सामग्री बनाएं**

चूंकि हाइपरलिंक्स आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके तालिका सामग्री बना सकते हैं।

यह नमूना कोड दिखाता है कि कैसे हाइपरलिंक्स के साथ तालिका सामग्री बनाएं:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **हाइपरलिंक्स स्वरूपित करें**

### **रंग**

आप [setColorSource](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/setcolorsource/) मेथड का उपयोग करके [Hyperlink](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/) क्लास में हाइपरलिंक्स का रंग निर्धारित कर सकते हैं और हाइपरलिंक्स से रंग जानकारी प्राप्त भी कर सकते हैं। यह सुविधा पहली बार PowerPoint 2019 में पेश की गई थी, इसलिए इस प्रॉपर्टी में परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते।

यह नमूना कोड एक ऑपरेशन दर्शाता है जहाँ विभिन्न रंगों के हाइपरलिंक्स एक ही स्लाइड में जोड़े गए:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्रस्तुतियों से हाइपरलिंक्स हटाएँ**

### **पाठ से हाइपरलिंक्स हटाएँ**

यह PHP कोड दर्शाता है कि कैसे एक प्रस्तुति स्लाइड के पाठ से हाइपरलिंक हटाएँ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **आकार या फ्रेम से हाइपरलिंक्स हटाएँ**

यह PHP कोड दर्शाता है कि कैसे एक प्रस्तुति स्लाइड के आकार से हाइपरलिंक हटाएँ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **परिवर्तनीय हाइपरलिंक**

[Hyperlink](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/) क्लास परिवर्तनीय है। इस क्लास का उपयोग करके आप इन प्रॉपर्टीज़ के मान बदल सकते हैं:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

यह कोड स्निपेट दिखाता है कि कैसे एक स्लाइड में हाइपरलिंक जोड़ें और बाद में उसका टूलटिप संपादित करें:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **IHyperlinkQueries में समर्थित प्रॉपर्टीज़**

आप किसी प्रस्तुति, स्लाइड, या पाठ से [HyperlinkQueries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/) को एक्सेस कर सकते हैं, जिसके लिए हाइपरलिंक परिभाषित है।

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/gethyperlinkqueries/)

[HyperlinkQueries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/) क्लास इन मेथड्स और प्रॉपर्टीज़ को सपोर्ट करती है:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं केवल स्लाइड पर नहीं, बल्कि एक "सेक्शन" या सेक्शन की पहली स्लाइड पर भी आंतरिक नेविगेशन कैसे बनाऊँ?**

PowerPoint में सेक्शन स्लाइडों के समूह होते हैं; नेविगेशन तकनीकी रूप से एक विशिष्ट स्लाइड को लक्षित करता है। "सेक्शन पर नेविगेट" करने के लिए, आमतौर पर आप उसकी पहली स्लाइड से लिंक करते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। ऐसे लिंक चाइल्ड स्लाइडों पर दिखाई देते हैं और स्लाइडशो के दौरान क्लिक करने योग्य होते हैं।

**क्या PDFs, HTML, इमेजेज या वीडियो में निर्यात करते समय हाइपरलिंक संरक्षित रहेंगे?**

[PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) में, हां—लिंक सामान्यतः संरक्षित रहते हैं। जब [images](/slides/hi/php-java/convert-powerpoint-to-png/) और [video](/slides/hi/php-java/convert-powerpoint-to-video/) में निर्यात करते हैं, तो क्लिक करने की क्षमता नहीं रहती क्योंकि इन फ़ॉर्मैट्स (रास्टर फ्रेम्स/वीडियो) हाइपरलिंक का समर्थन नहीं करते।