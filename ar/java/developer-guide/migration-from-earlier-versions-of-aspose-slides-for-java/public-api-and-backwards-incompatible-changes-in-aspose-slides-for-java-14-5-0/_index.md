---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides ل Java 14.5.0
type: docs
weight: 40
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [الطبقات المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) والطُرق والخصائص وما إلى ذلك، وأي [قيود جديدة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) وأي [تغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides ل Java 14.5.0.

{{% /alert %}} 
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **الطبقات والطُرق المضافة**
#### **تمت إضافة واجهة Aspose.Slides.IPresentationInfo وطبقة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

الطريقة Boolean isEncrypted() تعيد True إذا كان العرض التقديمي مشفراً، وإلا تعيد False.

الطريقة LoadFormat getLoadFormat() تعيد نوع العرض التقديمي.
#### **تمت إضافة الطريقة Aspose.Slides.IShape.isGrouped()**
تحدد الطريقة Aspose.Slides.IShape.isGrouped() ما إذا كانت الشكل مُجمع.
#### **تمت إضافة الطريقة Aspose.Slides.IShape.getParentGroup()**
تُعيد الطريقة Aspose.Slides.IShape.getParentGroup() كائن GroupShape الأب إذا كانت الشكل مُجمعة. وإلا تعيد null.
#### **تمت إضافة الطريقة Aspose.Slides.IShapeCollection.addGroupShape()**
تقوم الطريقة Aspose.Slides.IShapeCollection.addGroupShape() بإنشاء GroupShape جديدة وإضافتها إلى نهاية المجموعة.

سيتم ضبط حجم وإطار GroupShape على المحتوى عندما يتم إضافة شكل جديد إلى GroupShape.
#### **تمت إضافة الطريقة Aspose.Slides.IShapeCollection.clear()**
تقوم الطريقة Aspose.Slides.IShapeCollection.clear() بإزالة جميع الأشكال من المجموعة.
#### **تمت إضافة الطريقة Aspose.Slides.IShapeCollection.insertGroupShape(int)**
تقوم الطريقة Aspose.Slides.IShapeCollection.insertGroupShape(int) بإنشاء GroupShape جديدة وإضافتها إلى المجموعة في الفهرس المحدد.
سيتم ضبط حجم وإطار GroupShape على المحتوى عندما يتم إضافة شكل جديد إلى GroupShape.
#### **تمت إضافة الطرق IPresentationFactory.getPresentationInfo(string file) وIPresentatoinFactory.getPresentationInfo(InputStream stream)**
تسمح هذه الطرق للمطورين بالحصول على معلومات حول ملف العرض التقديمي/التدفق دون تحميل العرض التقديمي بالكامل.
#### **تمت إضافة الطريقة IPresentationFactory PresentationFactory.getInstance()**
تسمح باستخدام وظائف المصنع دون الحاجة إلى إنشاء مثيل.
### **القيود**
#### **تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.getFrame()**
الكود الذي يحاول تعيين إطار غير معرف لـ IShape.setFrame(IShapeFrame) لا يعتبر منطقيًا في الحالات العامة (خصوصًا عندما يكون GroupShape الأب متعدد التداخل في {{GroupShape}}s أخرى). على سبيل المثال:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

أو

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

يمكن أن يؤدي مثل هذا الكود إلى حالات غير واضحة. لذا، تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.Frame. يجب أن تكون قيم x وy وwidth وheight وflipH وflipV وrotationAngle معرفّة (ليس Float.NaN أو NullableBool.NotDefined). الكود المثال أعلاه الآن يُثير استثناء ArgumentException.
ينطبق هذا على حالات الاستخدام التالية:

``` java

 IShape shape = ...;

shape.setFrame(...); // لا يمكن أن تكون غير معرفة

IShapeCollection shapes = ...;

// x وy وwidth وheight لا يمكن أن تكون Float.NaN:

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

لكن إطار IShape.getRawFrame() يمكن أن يكون غير معرف. هذا يعتبر منطقيًا عندما يكون الشكل مرتبطًا بعنصر نائب. ثم يتم تجاوز قيم إطار الشكل غير المعروفة من شكل العنصر النائب الأب. إذا لم يكن هناك شكل عنصر نائب أب لذلك الشكل فيتم استخدام القيم الافتراضية عند تقييم إطار الشكل الفعال استنادًا إلى IShape.getRawFrame(). القيم الافتراضية هي 0 وNullableBool.False لـ x وy وwidth وheight وflipH وflipV وrotationAngle. على سبيل المثال:

``` java

 IShape shape = ...; // الشكل مرتبط بعنصر نائب

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// الآن الشكل يرث قيم x وy وheight وflipH وflipV من العنصر نائب ويتجاوز width=100 وrotationAngle=0.

```
### **الخصائص المتغيرة**
#### **تم تغيير النوع واسم الطريقة Aspose.Slides.IShapeCollection.getParent()**
تم تغيير نوع خاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى واجهة IGroupShape الجديدة. واجهة IGroupShape هي سليل لـ ISlideComponent لذا لا يحتاج الكود الحالي إلى تعديل.

تم تغيير اسم الطريقة Aspose.Slides.IShapeCollection.getParent() من getParent إلى getParentGroup().
#### **تغيير نوع طريقتي Aspose.Slides.IShapeFrame.getFlipH() و.getFlipV()**
تم تغيير نوع الطريقة Aspose.Slides.IShapeFrame.getFlipH() من bool إلى NullableBool.

تعيد الطريقة IShape.getFrame() المثيل الفعال لـ IShapeFrame (التي جميع خصائصها تحتوي على قيم فعلية معرفة).

تعيد الطريقة IShape.getRawFrame() مثيل IShapeFrame الذي يمكن أن تحتوي كل خاصية فيه على قيمة غير معرفة (خصوصًا يمكن أن تحتوي FlipH أو FlipV على قيمة NullableBool.NotDefined).