---
title: "تعزيز عروضك التقديمية باستخدام AutoFit في PHP"
linktitle: "إعدادات Autofit"
type: docs
weight: 30
url: /ar/php-java/manage-autofit-settings/
keywords:
- "مربع نص"
- "ملاءمة تلقائية"
- "عدم ملاءمة تلقائية"
- "ضبط النص"
- "تقليل النص"
- "تغليف النص"
- "إعادة تحجيم الشكل"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "إدارة إعدادات AutoFit في Aspose.Slides لـ PHP لتحسين عرض النص في عروض PowerPoint و OpenDocument وتحسين قراءة المحتوى."
---

افتراضيًا، عندما تضيف مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لمربع النص — فهو يعيد تحجيم مربع النص تلقائيًا لضمان أن النص دائمًا يتناسب معه. 

![مربع نص في PowerPoint](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص — يزيد ارتفاعه — للسماح له بحمل نص أكبر. 
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص — يقلل ارتفاعه — لإزالة المساحة الزائدة. 

في PowerPoint، هذه هي المعلمات الأربعة الهامة أو الخيارات التي تتحكم في سلوك الملاءمة التلقائية لمربع النص: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![خيارات الملاءمة التلقائية في PowerPoint](autofit-options-powerpoint.png)

توفر Aspose.Slides للـ PHP عبر Java خيارات مماثلة — بعض الخصائص ضمن الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) — التي تتيح لك التحكم في سلوك الملاءمة التلقائية لمربعات النص في العروض التقديمية.

## **إعادة تحجيم الشكل ليتناسب مع النص**

إذا كنت ترغب في أن يتناسب النص داخل صندوق دائمًا مع الصندوق بعد إجراء تغييرات على النص، يجب عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `Shape`.

![إعداد الملاءمة الدائمة في PowerPoint](alwaysfit-setting-powerpoint.png)

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


إذا أصبح النص أطول أو أكبر، سيتم إعادة تحجيم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان أن جميع النص يتناسب معه. إذا أصبح النص أقصر، يحدث العكس. 

## **عدم الملاءمة التلقائية**

إذا كنت ترغب في أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، يجب عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `None`.

![إعداد عدم الملاءمة التلقائية في PowerPoint](donotautofit-setting-powerpoint.png)

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


عندما يصبح النص أطول من الصندوق، ينسكب خارج الصندوق. 

## **تقليص النص عند الفائض**

إذا أصبح النص طويلاً جدًا بالنسبة لصندوقه، من خلال خيار **Shrink text on overflow** يمكنك تحديد أن حجم النص والمسافات بين الأحرف يجب أن تُقلص لتناسب الصندوق. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `Normal`.

![إعداد تقليل النص عند الفائض في PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يُطبق الإعداد فقط عندما يصبح النص أطول من الصندوق. 
{{% /alert %}}

## **التفاف النص**

إذا كنت ترغب في أن يلتف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام المعامل **Wrap text in shape**. لتحديد هذا الإعداد، يجب تعيين الخاصية [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `true`.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
إذا قمت بتعيين الخاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يتم تمديد النص خارج حدود الشكل على سطر واحد. 
{{% /alert %}}

## **FAQ**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit?**  
نعم. يقلل الحشو (الهوامش الداخلية) من مساحة النص المتاحة، لذا سيتدخل AutoFit مبكرًا — تقليل الخط أو إعادة تحجيم الشكل في وقت أقرب. تحقق من الهوامش وقم بضبطها قبل ضبط AutoFit.

**كيف يتفاعل AutoFit مع فواصل الأسطر اليدوية والناعمة؟**  
تظل الفواصل القسرية موجودة، ويتكيف AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليل النص بواسطة AutoFit.

**هل يؤثر تغيير خط السمة أو تفعيل استبدال الخط على نتائج AutoFit؟**  
نعم. استبدال الخط بخط يملك مقاييس رموز مختلفة يغير عرض/ارتفاع النص، مما قد يغير حجم الخط النهائي وتفاف السطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.