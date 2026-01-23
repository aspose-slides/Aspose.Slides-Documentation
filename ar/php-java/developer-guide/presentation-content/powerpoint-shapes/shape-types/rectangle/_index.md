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
description: "عزّز عروض PowerPoint التقديمية الخاصة بك بإضافة مستطيلات باستخدام Aspose.Slides للـ PHP عبر Java — صمّم وعدّل الأشكال برمجياً بسهولة."
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، هذا الموضوع أيضًا يدور حول إضافة شكل وهذه المرة الشكل الذي سنناقشه هو **Rectangle**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسقة إلى شرائحهم باستخدام Aspose.Slides للـ PHP عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى شريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من نوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) التي تُعرَض عبر كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) .
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع إهليلج
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
لإضافة مستطيل مُنسق إلى شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من نوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) التي تُعرَض عبر كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) .
- تعيين [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للمستطيل إلى Solid.
- تعيين لون المستطيل باستخدام طريقة [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) التي تُعرَض عبر كائن [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) المرتبط بكائن [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .
- تعيين لون خطوط المستطيل.
- تعيين عرض خطوط المستطيل.
- كتابة العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات السابقة في المثال المعطى أدناه.
```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع إهليلج
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # تطبيق بعض التنسيقات على شكل الإهليلج
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # تطبيق بعض التنسيقات على خط الإهليلج
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

**كيف أضيف مستطيل بزوايا مستديرة؟**
استخدم [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) ذو الزوايا المستديرة وقم بتعديل نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التقويس على كل زاوية على حدة عبر تعديل الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**
اختر [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للصور، وفّر مصدر الصورة، وقم بتهيئة أوضاع [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) .

**هل يمكن أن يحتوي المستطيل على ظل وتوهج؟**
نعم. تتوفر [Outer/inner shadow, glow, and soft edges](/slides/ar/php-java/shape-effect/) مع معلمات قابلة للتعديل.

**هل يمكن تحويل المستطيل إلى زر مع رابط تشعبي؟**
نعم. [Assign a hyperlink](/slides/ar/php-java/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحريك والتغييرات؟**
استخدم أقفال الشكل: يمكنك منع التحريك، إعادة التحجيم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**
نعم. يمكنك [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**
[Use the shape’s effective properties](/slides/ar/php-java/shape-effective-properties/): تُعيد API قيمًا مُحسوبة تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.