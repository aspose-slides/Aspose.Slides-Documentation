---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 14.5.0
linktitle: Aspose.Slides لجافا 14.5.0
type: docs
weight: 40
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- الهجرة
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for Java للقيام بعملية ترحيل سلسة لحلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تقوم هذه الصفحة بإدراج جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)، وأي [قيود](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) أخرى و[تغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) التي تم تقديمها مع Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة**
### **الفئات والطرق المضافة**
#### **إضافة واجهة Aspose.Slides.IPresentationInfo وفئات PresentationInfo**
تمثل معلومات حول العرض التقديمي.

طريقة Boolean isEncrypted() تُعيد True إذا كان العرض التقديمي مشفرًا، وإلا تُعيد False.

طريقة LoadFormat getLoadFormat() تُعيد نوع العرض التقديمي.
#### **إضافة طريقة Aspose.Slides.IShape.isGrouped()**
تحدد طريقة Aspose.Slides.IShape.isGrouped() ما إذا كان الشكل مضمّنًا في مجموعة.
#### **إضافة طريقة Aspose.Slides.IShape.getParentGroup()**
تُعيد طريقة Aspose.Slides.IShape.getParentGroup() كائن GroupShape الأب إذا كان الشكل مضمّنًا في مجموعة. وإلا تُعيد null.
#### **إضافة طريقة Aspose.Slides.IShapeCollection.addGroupShape()**
تنشئ طريقة Aspose.Slides.IShapeCollection.addGroupShape() GroupShape جديد وتضيفه إلى نهاية المجموعة.

سيتم ضبط حجم إطار GroupShape وموقعه ليتناسب مع المحتوى عند إضافة شكل جديد إلى GroupShape.
#### **إضافة طريقة Aspose.Slides.IShapeCollection.clear()**
تزيل طريقة Aspose.Slides.IShapeCollection.clear() جميع الأشكال من المجموعة.
#### **إضافة طريقة Aspose.Slides.IShapeCollection.insertGroupShape(int)**
تنشئ طريقة Aspose.Slides.IShapeCollection.insertGroupShape(int) GroupShape جديد وتدرجه في المجموعة عند الفهرس المحدد.

سيتم ضبط حجم إطار GroupShape وموقعه ليتناسب مع المحتوى عند إضافة شكل جديد إلى GroupShape.
#### **إضافة طرق IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
تسمح هذه الطرق للمطورين بالحصول على معلومات حول ملف/تيار العرض التقديمي دون تحميل العرض بالكامل.
#### **إضافة طريقة IPresentationFactory PresentationFactory.getInstance()**
تتيح استخدام وظيفة المصنع دون إنشاء كائن.
### **القيود**
#### **تم إضافة قيود على استخدام قيم غير معرفة لـ IShape.getFrame()**
الرمز الذي يحاول تعيين إطار غير معرف إلى IShape.setFrame(IShapeFrame) لا معنى له في الحالات العامة (خصوصًا عندما يكون GroupShape الأب متداخلًا عدة مرات داخل {{GroupShape}} أخرى). على سبيل المثال:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // يطرح استثناء ArgumentException: يجب تحديد قيم الإطار.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

or

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // يطرح استثناء ArgumentException: يجب تحديد قيم x و y والعرض والارتفاع.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

قد يؤدي مثل هذا الرمز إلى مواقف غير واضحة. لذلك تم إضافة قيود على استخدام قيم غير معرفة لـ IShape.Frame. يجب أن تكون قيم x و y والعرض والارتفاع و flipH و flipV و rotationAngle مُحددة (ليس Float.NaN أو NullableBool.NotDefined). الآن يُطلق الرمز المثال أعلاه استثناءً من نوع ArgumentException.

ينطبق ذلك على حالات الاستخدام التالية:

``` java
// الإطار الممرَّر إلى IShape.setFrame(IShapeFrame) لا يمكن أن يحتوي على قيم غير معرفة.

// معلمات x و y والعرض والارتفاع للطرق التالية في IShapeCollection
// لا يمكن أن تكون Float.NaN أيضًا:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

لكن إطار IShape.getRawFrame() يمكن أن يكون غير معرف. هذا منطقي عندما يكون الشكل مرتبطًا بعنصر نائب. ثم تُستبدل قيم إطار الشكل غير المعرفة من الشكل النائب الأب. إذا لم يكن هناك شكل نائب أب لذلك الشكل، فإنه يستخدم القيم الافتراضية عند تقييم الإطار الفعلي بناءً على IShape.getRawFrame(). القيم الافتراضية هي 0 و NullableBool.False لـ x و y والعرض والارتفاع و flipH و flipV و rotationAngle. على سبيل المثال:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // الشكل مرتبط بعنصر نائب.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // الآن يرث الشكل قيم x و y والارتفاع و flipH و flipV من العنصر النائب
    // ويستبدل العرض = 100 وزاوية الدوران = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **الخصائص المعدلة**
#### **تغيير النوع والاسم لطريقة Aspose.Slides.IShapeCollection.getParent()**
تم تغيير نوع الخاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى واجهة IGroupShape الجديدة. واجهة IGroupShape هي فرع من ISlideComponent لذا لا يحتاج الكود الموجود إلى تعديل.

تم تغيير اسم طريقة Aspose.Slides.IShapeCollection.getParent() من getParent إلى getParentGroup().
#### **تغيير نوع طرق Aspose.Slides.IShapeFrame.getFlipH() و .getFlipV()**
تم تغيير نوع طريقة Aspose.Slides.IShapeFrame.getFlipH() من bool إلى NullableBool.

تعيد طريقة IShape.getFrame() نسخة فعالة من IShapeFrame (جميع خصائصها لها قيم فعالة معرفة).

تعيد طريقة IShape.getRawFrame() نسخة من IShapeFrame يمكن أن تكون لكل خاصية قيمة غير معرفة (خصوصًا يمكن أن تكون قيمة FlipH أو FlipV هي NullableBool.NotDefined).