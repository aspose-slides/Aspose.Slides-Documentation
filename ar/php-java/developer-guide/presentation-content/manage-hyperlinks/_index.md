---
title: إدارة ارتباطات العرض التقديمي في PHP
linktitle: إدارة الارتباط التشعبي
type: docs
weight: 20
url: /ar/php-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشرائح
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة الروابط التشعبية بسهولة في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides لـ PHP عبر Java — تحسين التفاعلية وسير العمل في دقائق."
---

الارتباط التشعبي هو مرجع إلى كائن أو بيانات أو مكان في شيء ما. هذه أمثلة على الارتباطات التشعبية الشائعة في عروض PowerPoint:

* روابط إلى مواقع الويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

Aspose.Slides for PHP via Java تتيح لك تنفيذ العديد من المهام المتعلقة بالارتباطات التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose البسيط، [محرر PowerPoint المجاني عبر الإنترنت.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **إضافة ارتباطات URL**

### **إضافة ارتباطات URL إلى النص**

يعرض لك هذا الكود PHP كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:
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


### **إضافة ارتباطات URL إلى الأشكال أو الإطارات**

يعرض لك هذا الكود النموذجى كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:
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


### **إضافة ارتباطات URL إلى الوسائط**

يتيح لك Aspose.Slides إضافة ارتباطات تشعبية إلى ملفات الصور والصوت والفيديو. 

يعرض لك هذا الكود النموذجى كيفية إضافة ارتباط تشعبي إلى **صورة**:
```php
  $pres = new Presentation();
  try {
    # يضيف صورة إلى العرض التقديمي
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ينشئ إطار صورة على الشريحة 1 استنادًا إلى الصورة المضافة مسبقًا
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


يعرض لك هذا الكود النموذجى كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:
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


يعرض لك هذا الكود النموذجى كيفية إضافة ارتباط تشعبي إلى **فيديو**:
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


{{%  alert  title="Tip"  color="primary"  %}} 
قد ترغب في الاطلاع على *[إدارة OLE](/slides/ar/php-java/manage-ole/)*.
{{% /alert %}}

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

نظرًا لأن الارتباطات التشعبية تسمح لك بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات. 

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


## **تنسيق الارتباطات التشعبية**

### **اللون**

باستخدام خاصية [ColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink#setColorSource-int-) في واجهة [IHyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink)، يمكنك تعيين اللون للارتباطات التشعبية وكذلك الحصول على معلومات اللون منها. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint القديمة.

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


## **إزالة الارتباطات التشعبية من العروض التقديمية**

### **إزالة الارتباطات التشعبية من النص**

يعرض لك هذا الكود PHP كيفية إزالة الارتباط التشعبي من نص في شريحة عرض تقديمي:
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


### **إزالة الارتباطات التشعبية من الأشكال أو الإطارات**

يعرض لك هذا الكود PHP كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض تقديمي:
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


## **الارتباط التشعبي القابل للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير القيم للخصائص التالية:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

يعرض لك مقطع الشفرة كيفية إضافة ارتباط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:
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


## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) من عرض تقديمي أو شريحة أو نص تم تعريف الارتباط التشعبي له.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

فئة [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) تدعم هذه الطرق والخصائص:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **الأسئلة الشائعة**

**How can I create internal navigation not just to a slide, but to a "section" or the first slide of a section?**  
الأقسام في PowerPoint هي مجموعات من الشرائح؛ وتستهدف عملية التنقل شريحة محددة تقنيًا. للانتقال إلى قسم، عادةً ما تقوم بالربط إلى شريحته الأولى.

**Can I attach a hyperlink to master slide elements so it works on all slides?**  
نعم. تدعم عناصر الشريحة الرئيسية وتخطيط الشريحة الارتباطات التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر أثناء عرض الشرائح.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**  
في [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، نعم — عادةً ما يتم الحفاظ على الروابط. عند التصدير إلى [الصور](/slides/ar/php-java/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/php-java/convert-powerpoint-to-video/)، لن يتم نقل القدرة على النقر لأن هذه الصيغ (إطارات نقطية/فيديو) لا تدعم الارتباطات التشعبية.