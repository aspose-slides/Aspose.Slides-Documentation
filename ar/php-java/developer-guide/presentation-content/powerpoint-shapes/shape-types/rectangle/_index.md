---
title: إضافة مستطيلات إلى العروض التقديمية في PHP
linktitle: مستطيل
type: docs
weight: 80
url: /ar/php-java/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "عزز عروض PowerPoint التقديمية بإضافة مستطيلات باستخدام Aspose.Slides للـ PHP عبر Java — صمم وعدّل الأشكال برمجياً بسهولة."
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل، وهذه المرة سنناقش الشكل **Rectangle**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسقة إلى شرائحهم باستخدام Aspose.Slides for PHP عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى شريحة**
لإضافة مستطيل بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع الشكل البيضاوي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # كتابة ملف PPTX إلى القرص
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة مستطيل مُنسق إلى شريحة**
لإضافة مستطيل مُنسق إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- ضبط [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للمستطيل إلى Solid.
- ضبط لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) كما هو معروض في كائن [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- ضبط لون خطوط المستطيل.
- ضبط عرض خطوط المستطيل.
- كتابة العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات المذكورة أعلاه في المثال أدناه.
```php
  # إنشاء كائن من فئة Presentation يمثل PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع الشكل البيضاوي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # تطبيق بعض التنسيقات على شكل البيضاوي
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # تطبيق بعض التنسيقات على خط البيضاوي
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # كتابة ملف PPTX إلى القرص
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) المستديرة الزوايا وقم بتعديل نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التقويس لكل زاوية عبر تعديلات الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**

حدد [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للصورة، قدم مصدر الصورة، وقم بتهيئة [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**هل يمكن أن يكون للمستطيل ظل وتألق؟**

نعم. [Outer/inner shadow, glow, and soft edges](/slides/ar/php-java/shape-effect/) متوفرون مع معلمات قابلة للتعديل.

**هل يمكنني تحويل مستطيل إلى زر مع ارتباط تشعبي؟**

نعم. [Assign a hyperlink](/slides/ar/php-java/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية مستطيل من الحركة والتغييرات؟**

[Use shape locks](/slides/ar/php-java/applying-protection-to-presentation/): يمكنك منع الحركة، تغيير الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل مستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

[Use the shape’s effective properties](/slides/ar/php-java/shape-effective-properties/): تُرجع API قيمًا محسوبة تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.