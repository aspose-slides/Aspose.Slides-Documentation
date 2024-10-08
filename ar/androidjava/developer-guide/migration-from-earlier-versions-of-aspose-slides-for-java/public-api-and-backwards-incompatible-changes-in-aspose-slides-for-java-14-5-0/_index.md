---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides لـ Java 14.5.0
type: docs
weight: 40
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بإدراج جميع [المضافات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) من الفئات والطرق والخصائص وما إلى ذلك، وأي [قيود](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) جديدة وأي [تغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) أخرى تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.5.0.

{{% /alert %}} 
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف**
### **الفئات والطرق المضافة**
#### **تم إضافة واجهة Aspose.Slides.IPresentationInfo وفئة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

الطريقة Boolean isEncrypted() تُعيد True إذا كان العرض التقديمي مشفراً، وإلا تُعيد False.

الطريقة LoadFormat getLoadFormat() تُعيد نوع العرض التقديمي.
#### **تم إضافة الطريقة Aspose.Slides.IShape.isGrouped()**
تحدد الطريقة Aspose.Slides.IShape.isGrouped() ما إذا كان الشكل مجموعة.
#### **تم إضافة الطريقة Aspose.Slides.IShape.getParentGroup()**
تُعيد الطريقة Aspose.Slides.IShape.getParentGroup() كائن GroupShape الأب إذا كان الشكل مجموعة. خلاف ذلك، تُعيد null.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.addGroupShape()**
تقوم الطريقة Aspose.Slides.IShapeCollection.addGroupShape() بإنشاء GroupShape جديدة وإضافتها إلى نهاية المجموعة.

سيتم ضبط حجم إطار GroupShape وموقعه ليناسب المحتوى عند إضافة الشكل الجديد إلى GroupShape.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.clear()**
تقوم الطريقة Aspose.Slides.IShapeCollection.clear() بإزالة جميع الأشكال من المجموعة.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.insertGroupShape(int)**
تقوم الطريقة Aspose.Slides.IShapeCollection.insertGroupShape(int) بإنشاء GroupShape جديدة وإدراجها في المجموعة عند الفهرس المحدد.
سيتم ضبط حجم إطار GroupShape وموقعه ليناسب المحتوى عند إضافة الشكل الجديد إلى GroupShape.
#### **تم إضافة الطريقة IPresentationFactory.getPresentationInfo(string file)، IPresentatoinFactory.getPresentationInfo(InputStream stream)**
تسمح هذه الطرق للمطورين بالحصول على معلومات حول ملف/تدفق العرض التقديمي دون الحاجة إلى تحميل العرض التقديمي بالكامل.
#### **تم إضافة الطريقة IPresentationFactory PresentationFactory.getInstance()**
يسمح باستخدام وظيفة المصنع دون الحاجة إلى إنشاء كائن.
### **القيود**
#### **تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.getFrame()**
لا يكون للكود الذي يحاول تعيين إطار غير محدد لـ IShape.setFrame(IShapeFrame) معنى في الحالات العامة (خصوصاً عندما يكون GroupShape الأب متعدد التداخل في GroupShapes أخرى). على سبيل المثال:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

أو

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

يمكن أن يؤدي مثل هذا الكود إلى حالات غير واضحة. لذلك تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.Frame. يجب أن تكون قيم x وy والعرض والارتفاع والـ flipH وflipV وزاوية الدوران معرفة (ليست Float.NaN أو NullableBool.NotDefined). الآن، الكود المثال أعلاه يلقي استثناء ArgumentException.
ينطبق هذا على هذه الحالات:

``` java

 IShape shape = ...;

shape.setFrame(...); // لا يمكن أن تكون غير معرفة

IShapeCollection shapes = ...;

// لا يمكن أن تكون معلمات x وy وwidth وheight Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

لكن يمكن أن تكون إطارات IShape.getRawFrame() غير محددة. هذه له معنى عندما يكون الشكل مرتبطاً بمكان الحجز. ثم يتم تجاوز قيم إطار الشكل غير المحددة من شكل مكان الحجز الأب. إذا لم يكن هناك شكل مكان حجز أب لهذا الشكل، فإنه يستخدم القيم الافتراضية عند تقييم الإطار الفعال استناداً إلى IShape.getRawFrame(). القيم الافتراضية هي 0 وNullableBool.False لـ x وy وwidth وheight وflipH وflipV وزاوية الدوران. على سبيل المثال:

``` java

 IShape shape = ...; // الشكل مرتبط بمكان الحجز

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// الآن يرث الشكل قيم x وy وheight وflipH وflipV من مكان الحجز ويتجاوز width=100 وrotationAngle=0.

```
### **الخصائص المتغيرة**
#### **تم تغيير نوع واسم الطريقة Aspose.Slides.IShapeCollection.getParent()**
تم تغيير نوع خاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى واجهة IGroupShape الجديدة. واجهة IGroupShape هي سليل لـ ISlideComponent لذلك لا يتطلب الكود الموجود أي تعديل.

تم تغيير اسم الطريقة Aspose.Slides.IShapeCollection.getParent() من getParent إلى getParentGroup().
#### **تغيير نوع Aspose.Slides.IShapeFrame.getFlipH() و.getFlipV()**
تم تغيير نوع الطريقة Aspose.Slides.IShapeFrame.getFlipH() من bool إلى NullableBool.

تقوم الطريقة IShape.getFrame() بإرجاع المثيل الفعال من IShapeFrame (جميع خصائصه لها قيم فعالة معرفة).

تقوم الطريقة IShape.getRawFrame() بإرجاع مثيل IShapeFrame يمكن أن يكون لكل خاصية فيه قيمة غير معرفة (خصوصاً يمكن أن تكون قيمة FlipH أو FlipV قيمة NullableBool.NotDefined).