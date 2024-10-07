---
title: إدارة الخطوط - واجهة برمجة تطبيقات PowerPoint Java
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /php-java/manage-fonts/
description: العروض التقديمية تحتوي عادة على نصوص وصور. يوضح هذا المقال كيفية استخدام واجهة برمجة تطبيقات PowerPoint Java لتكوين خصائص الخط للنصوص على الشرائح.
---

## **إدارة خصائص الخط المرتبطة**
{{% alert color="primary" %}} 

العروض التقديمية تحتوي عادة على نصوص وصور. يمكن تنسيق النص بطرق متنوعة، إما لتسليط الضوء على أقسام وكلمات معينة أو للت conform مع الأنماط المؤسسية. يساعد تنسيق النص المستخدمين في تغيير مظهر محتوى العرض التقديمي. يوضح هذا المقال كيفية استخدام Aspose.Slides لـ PHP عبر Java لتكوين خصائص الخط للفقرات النصية على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرات باستخدام Aspose.Slides لـ PHP عبر Java:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى الأشكال [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder) في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. احصل على [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) من [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. قم بتبرير الفقرة.
1. الوصول إلى [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph)'s نص [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData) واضبط **Font** لنص [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) وفقًا لذلك.
   1. تعيين الخط ليكون عريض.
   1. تعيين الخط ليكون مائل.
1. تعيين لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. حفظ العرض التقديمي المعدل كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه. يأخذ عرضًا تقديميًا بدون زخرفة ويقوم بتنسيق الخطوط على واحدة من الشرائح. تعرض لقطات الشاشة التي تليها ملف الإدخال وكيف تغيره مقتطفات الكود. يقوم الكود بتغيير الخط، اللون، وأسلوب الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص مع تنسيق محدث**|

```php
  # إنشئ كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # الوصول إلى شريحة باستخدام موقعها
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصرين الأول والثاني في الشريحة وتحويلهما كـ AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # الوصول إلى الفقرة الأولى
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # تبرير الفقرة
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # الوصول إلى الجزء الأول
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # تعريف خطوط جديدة
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # تعيين خطوط جديدة للجزء
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # تعيين الخط ليكون عريض
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين الخط ليكون مائل
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين لون الخط
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # حفظ ملف PPTX على القرص
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين خصائص خط النص**
{{% alert color="primary" %}} 

كما ذُكِر في **إدارة خصائص الخط المرتبطة**، يتم استخدام [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) لحمل النص مع نمط تنسيق مشابه في فقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides لـ PHP عبر Java لإنشاء صندوق نص يحتوي على بعض النصوص ثم تعريف خط معين، والعديد من الخصائص الأخرى من فئة الخط.

{{% /alert %}} 

لإنشاء صندوق نص وتعيين خصائص الخط للنص داخله:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع شريحة باستخدام فهرسها.
1. أضف [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) من نوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. الوصول إلى كائن [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) المرتبط بـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. تحديد الخط الذي سيتم استخدامه لـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. تعيين خصائص خط أخرى مثل العريض، المائل، التسطير، اللون، والارتفاع باستخدام الخصائص ذات الصلة المعروضة بواسطة كائن [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. كتابة العرض التقديمي المعدل كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط المحددة بواسطة Aspose.Slides لـ PHP عبر Java**|

```php
  # إنشئ كائن Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # احصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # أضف AutoShape من نوع Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # إزالة أي نمط تعبئة مرتبط بـ AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى TextFrame المرتبط بـ AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # الوصول إلى Portion المرتبط بـ TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # تعيين الخط لـ Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # تعيين خاصية العريض للخط
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين خاصية المائل للخط
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين خاصية التسطير للخط
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # تعيين ارتفاع الخط
    $port->getPortionFormat()->setFontHeight(25);
    # تعيين لون الخط
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # حفظ العرض التقديمي على القرص
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```