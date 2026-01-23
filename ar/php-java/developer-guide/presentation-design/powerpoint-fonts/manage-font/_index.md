---
title: إدارة الخطوط في العروض التقديمية باستخدام PHP
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /ar/php-java/manage-fonts/
keywords:
- إدارة الخطوط
- خصائص الخط
- فقرة
- تنسيق النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "التحكم في الخطوط في PHP باستخدام Aspose.Slides: تضمين الخطوط، استبدالها، وتحميل خطوط مخصصة للحفاظ على وضوح عروض PPT و PPTX و ODP وتوافقها مع العلامة التجارية وتناسقها."
---

## **إدارة خصائص الخط المتعلقة**
{{% alert color="primary" %}} 

عادةً ما تحتوي العروض التقديمية على كلٍ من النصوص والصور. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام وكلمات محددة أو للامتثال لأنماط الشركة. يساعد تنسيق النص المستخدمين على تغيير مظهر محتوى العرض التقديمي. تُظهر هذه المقالة كيفية استخدام Aspose.Slides for PHP via Java لتكوين خصائص الخط للفقرات النصية على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) في الشريحة وتحويل نوعها إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. الحصول على الـ[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) من الـ[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) التي تُعرضها [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. تبرير الفقرة.
1. الوصول إلى نص الـ[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) عبر الـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) وتعيين **Font** لنص الـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) وفقًا لذلك.
   1. تعيين الخط إلى غامق.
   1. تعيين الخط إلى مائل.
1. تعيين لون الخط باستخدام الـ[FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) التي تُعرضها كائن الـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات المذكورة أعلاه موضح أدناه. يأخذ عرضًا تقديميًا بسيطًا ويُنسق الخطوط في إحدى الشرائح. تُظهر لقطات الشاشة التالية ملف الإدخال وكيفية تعديل الشيفرة له. تُغيّر الشيفرة الخط واللون ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص مع تنسيق محدث**|
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # الوصول إلى شريحة باستخدام موضعها
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # الوصول إلى الفقرة الأولى
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # محاذاة الفقرة
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
    # تعيين الخط إلى غامق
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين الخط إلى مائل
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين لون الخط
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # حفظ ملف PPTX إلى القرص
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضبط خصائص خط النص**
{{% alert color="primary" %}} 

كما هو مذكور في **إدارة خصائص الخط المتعلقة**، يُستخدم الـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) لحفظ النص ذي نمط تنسيق موحد داخل الفقرة. تُظهر هذه المقالة كيفية استخدام Aspose.Slides for PHP via Java لإنشاء مربع نص يحتوي على بعض النصوص ثم تحديد خط معين، بالإضافة إلى خصائص أخرى لفئة عائلة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص داخله:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بالـ[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. الوصول إلى الـ[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالـ[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. إضافة بعض النصوص إلى الـ[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. الوصول إلى كائن الـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) المرتبط بالـ[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. تعريف الخط الذي سيُستخدم للـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. تعيين خصائص أخرى للخط مثل الغامق، المائل، التحته خط، اللون والارتفاع باستخدام الخصائص المناسبة التي تُعرضها كائن الـ[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات المذكورة أعلاه موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي تم ضبطها بواسطة Aspose.Slides for PHP via Java**|
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # إزالة أي نمط تعبئة مرتبط بـ AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى TextFrame المرتبط بـ AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # الوصول إلى Portion المرتبط بـ TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # تحديد الخط للجزء
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # تعيين خاصية الغامق للخط
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين خاصية المائل للخط
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين خاصية التسطير للخط
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # تحديد ارتفاع الخط
    $port->getPortionFormat()->setFontHeight(25);
    # تحديد لون الخط
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # حفظ العرض التقديمي إلى القرص
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
