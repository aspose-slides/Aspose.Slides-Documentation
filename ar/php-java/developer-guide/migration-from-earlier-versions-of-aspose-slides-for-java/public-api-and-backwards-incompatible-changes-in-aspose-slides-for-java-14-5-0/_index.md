---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 14.5.0
type: docs
weight: 40
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع الفئات [المضافة](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) والأساليب والخصائص وما إلى ذلك، وأي [قيود](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) جديدة والتغييرات الأخرى [المقدمة](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 14.5.0.

{{% /alert %}} 
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **فئات وأساليب مضافة**
#### **تمت إضافة واجهة Aspose.Slides.IPresentationInfo وفئة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

الطريقة Boolean isEncrypted() تعيد True إذا كان العرض التقديمي مشفراً، وإلا تعيد False.

الطريقة LoadFormat getLoadFormat() تعيد نوع العرض التقديمي.
#### **تمت إضافة طريقة Aspose.Slides.IShape.isGrouped()**
تحدد الطريقة Aspose.Slides.IShape.isGrouped() ما إذا كان الشكل مجمعًا.
#### **تمت إضافة طريقة Aspose.Slides.IShape.getParentGroup()**
تعيد الطريقة Aspose.Slides.IShape.getParentGroup() كائن GroupShape الأصلي إذا كان الشكل مجمعًا. وإلا، تعيد null.
#### **تمت إضافة طريقة Aspose.Slides.IShapeCollection.addGroupShape()**
تخلق الطريقة Aspose.Slides.IShapeCollection.addGroupShape() GroupShape جديدة وتضيفها إلى نهاية المجموعة.

سيتم ضبط حجم الإطار وموقع GroupShape ليتناسب مع المحتوى عند إضافة الشكل الجديد إلى GroupShape.
#### **تمت إضافة طريقة Aspose.Slides.IShapeCollection.clear()**
تزيل الطريقة Aspose.Slides.IShapeCollection.clear() جميع الأشكال من المجموعة.
#### **تمت إضافة طريقة Aspose.Slides.IShapeCollection.insertGroupShape(int)**
تخلق الطريقة Aspose.Slides.IShapeCollection.insertGroupShape(int) GroupShape جديدة وتدرجها في المجموعة عند الفهرس المحدد.
سيتم ضبط حجم الإطار وموقع GroupShape ليتناسب مع المحتوى عند إضافة الشكل الجديد إلى GroupShape.
#### **تمت إضافة طرق IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
تسمح هذه الطرق للمطورين بتلقي معلومات حول ملف/تيار العرض التقديمي دون تحميل العرض التقديمي بالكامل.
#### **تمت إضافة طريقة IPresentationFactory PresentationFactory.getInstance()**
تسمح باستخدام وظائف المصنع دون الحاجة إلى إنشاء مثيل.
### **قيود**
#### **تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.getFrame()**
الكود الذي يحاول تعيين إطار غير معرف إلى IShape.setFrame(IShapeFrame) لا معنى له في الحالات العامة (خصوصًا عندما يكون GroupShape الأصل متعدد التعشيش في GroupShape أخرى). على سبيل المثال:

```php
  $shape = $$missing$;
  $shape->setFrame(new ShapeFrame(Float::NaN, Float::NaN, Float::NaN, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, Float::NaN));

```

أو

```php
  slide.Shapes->AddAutoShape(ShapeType::RoundCornerRectangle, Float::NaN, Float::NaN, Float::NaN, Float::NaN);

```

يمكن أن يؤدي هذا الكود إلى حالات غير واضحة. لذلك تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.Frame. يجب أن تكون القيم x وy وwidth وheight وflipH وflipV وrotationAngle محددة (وليس Float.NaN أو NullableBool.NotDefined). الآن الكود المثال أعلاه يثير استثناء ArgumentException.
هذا ينطبق على حالات الاستخدام هذه:

```php
  $shape = $$missing$;
  $shape->setFrame();// لا يمكن أن تكون غير معرفة

  $shapes = $$missing$;
  # لا يمكن أن تكون معلمات x وy وwidth وheight Float.NaN:
  {
    $shapes->addAudioFrameCD();
    $shapes->addAudioFrameEmbedded();
    $shapes->addAudioFrameLinked();
    $shapes->addAutoShape();
    $shapes->addChart();
    $shapes->addConnector();
    $shapes->addOleObjectFrame();
    $shapes->addPictureFrame();
    $shapes->addSmartArt();
    $shapes->addTable();
    $shapes->addVideoFrame();
    $shapes->insertAudioFrameEmbedded();
    $shapes->insertAudioFrameLinked();
    $shapes->insertAutoShape();
    $shapes->insertChart();
    $shapes->insertConnector();
    $shapes->insertOleObjectFrame();
    $shapes->insertPictureFrame();
    $shapes->insertTable();
    $shapes->insertVideoFrame();
  }
```

لكن يمكن أن يكون إطار IShape.getRawFrame() غير محدد. هذا منطقي عندما يكون الشكل مرتبطًا بعنصر نائب. ثم يتم تجاوز قيم إطار الشكل غير المعرفة من عنصر نائب الأصل. إذا لم يكن هناك عنصر نائب أصل لذلك الشكل، فإنه يستخدم القيم الافتراضية عند تقييم الإطار الفعال بناءً على IShape.getRawFrame(). القيم الافتراضية هي 0 وNullableBool.False للقيم x وy وwidth وheight وflipH وflipV وrotationAngle. على سبيل المثال:

```php
  $shape = $$missing$;// الشكل مرتبط بعنصر نائب

  $shape->setRawFrame(new ShapeFrame(Float::NaN, Float::NaN, 100, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, 0));
  # الآن الشكل يرث قيم x وy وheight وflipH وflipV من العنصر النائب ويتجاوز width=100 وrotationAngle=0.

```
### **الخصائص المتغيرة**
#### **تغيير نوع واسم طريقة Aspose.Slides.IShapeCollection.getParent()**
تم تغيير نوع خاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى واجهة IGroupShape الجديدة. واجهة IGroupShape هي فرع من ISlideComponent لذا لا يحتاج الكود الحالي إلى تعديل.

تم تغيير اسم طريقة Aspose.Slides.IShapeCollection.getParent() من getParent إلى getParentGroup().
#### **تغيير نوع طرق Aspose.Slides.IShapeFrame.getFlipH() و.getFlipV()**
تم تغيير نوع طريقة Aspose.Slides.IShapeFrame.getFlipH() من bool إلى NullableBool.

ترجع طريقة IShape.getFrame() المثيل الفعال لـ IShapeFrame (التي تحتوي جميع خصائصها على قيم فعالة محددة).

ترجع طريقة IShape.getRawFrame() مثيلًا لـ IShapeFrame يمكن أن تحتوي كل خاصية فيه على قيمة غير محددة (خصوصًا FlipH أو FlipV يمكن أن تحتوي على قيمة NullableBool.NotDefined).