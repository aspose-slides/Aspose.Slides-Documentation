---
title: مستطيل
type: docs
weight: 80
url: /php-java/rectangle/
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، هذا الموضوع يتعلق أيضًا بإضافة شكل، وهذه المرة الشكل الذي سنتحدث عنه هو **مستطيل**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مصفوفة إلى شرائحهم باستخدام Aspose.Slides لـ PHP عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى الشريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- قم بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- احصل على مرجع للشريحة باستخدام الفهرس الخاص بها.
- أضف [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع مستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- قم بكتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.

```php
  # قم بإنشاء نسخة من فئة Prseetation التي تمثل PPTX
  $pres = new Presentation();
  try {
    # احصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # أضف AutoShape من نوع بيضاوي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # قم بكتابة ملف PPTX على القرص
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة مستطيل مصفوف إلى الشريحة**
لإضافة مستطيل مصفوف إلى شريحة، يرجى اتباع الخطوات أدناه:

- قم بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- احصل على مرجع للشريحة باستخدام الفهرس الخاص بها.
- أضف [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع مستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- قم بتعيين [نوع التعبئة](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للمستطيل إلى صلب.
- قم بتعيين لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) كما هو موضح بواسطة كائن [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- قم بتعيين لون خطوط المستطيل.
- قم بتعيين عرض خطوط المستطيل.
- قم بكتابة العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات أعلاه في المثال الموضح أدناه.

```php
  # قم بإنشاء نسخة من فئة Prseetation التي تمثل PPTX
  $pres = new Presentation();
  try {
    # احصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # أضف AutoShape من نوع بيضاوي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # قم بتطبيق بعض التنسيقات على شكل البيضاوي
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # قم بتطبيق بعض التنسيقات على خط البيضاوي
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # قم بكتابة ملف PPTX على القرص
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```