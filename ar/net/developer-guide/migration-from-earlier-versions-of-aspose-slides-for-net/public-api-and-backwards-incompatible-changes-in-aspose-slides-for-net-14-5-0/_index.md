---
title: واجهة API العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.5.0
type: docs
weight: 70
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

تشمل هذه الصفحة جميع [الإضافات](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) جديدة وتغييرات أخرى [مقدمة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) مع واجهة API لـ Aspose.Slides لـ .NET 14.5.0.

{{% /alert %}} 
## **واجهة API العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **الواجهات والفئات والخصائص والأساليب المضافة**
#### **تمت إضافة واجهة Aspose.Slides.IPresentationInfo وفئة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

- خاصية Boolean IsEncrypted تأخذ قيمة True إذا كان العرض التقديمي مشفرًا، وإلا تأخذ قيمة False.
- خاصية LoadFormat LoadFormat تأخذ نوع العرض التقديمي.
#### **تمت إضافة خاصية Aspose.Slides.IShape.IsGrouped**
تحدد خاصية Aspose.Slides.IShape.IsGrouped ما إذا كانت الشكل مجمعًا.
#### **تمت إضافة خاصية Aspose.Slides.IShape.ParentGroup**
تعيد خاصية Aspose.Slides.IShape.ParentGroup كائن GroupShape الأب إذا كانت الشكل مجمعًا. خلاف ذلك، تعيد null.
#### **تمت إضافة طريقة Aspose.Slides.IShapeCollection.AddGroupShape()**
تقوم طريقة Aspose.Slides.IShapeCollection.AddGroupShape() بإنشاء GroupShape جديد وإضافته إلى نهاية المجموعة.
سيتم ضبط حجم وموضع إطار GroupShape ليتناسب مع المحتوى عند إضافة شكل جديد.
#### **تمت إضافة طريقة Aspose.Slides.IShapeCollection.Clear()**
تقوم طريقة Aspose.Slides.IShapeCollection.Clear() بإزالة جميع الأشكال من المجموعة.
#### **تمت إضافة طريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
تقوم طريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int) بإنشاء GroupShape جديد وإدخاله في المجموعة عند موضع الفهرس المحدد.
سيتم ضبط حجم وموضع إطار GroupShape ليتناسب مع المحتوى عند إضافة شكل جديد.
#### **تمت إضافة طرق IPresentationFactory.GetPresentationInfo(string file) و IPresentationFactory.GetPresentationInfo(Stream stream)**
تسمح هذه الطرق بالحصول على معلومات حول ملف أو تدفق العرض التقديمي دون تحميله بالكامل.
#### **تمت إضافة خاصية IPresentationFactory PresentationFactory.Instance**
تسمح هذه الخاصية للمطورين باستخدام وظيفة المصنع دون الحاجة إلى التهيئة.
### **القيود**
#### **القيود على IShape.Frame**
تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.Frame. الكود الذي يحاول تعيين إطار غير معرف لـ IShape.Frame لا معنى له في معظم الحالات (خصوصًا عندما يتم تضمين GroupShape الأب في {{GroupShape}} أخرى متعددة). على سبيل المثال:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

أو

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

يمكن أن تؤدي مثل هذه الشيفرة إلى حالات غير واضحة. لذا تمت إضافة قيود لاستخدام القيم غير المعرفة لـ IShape.Frame. يجب أن تكون قيم x وy وwidth وheight وflipH وflipV وrotationAngle معرفة (وليس تعيينها إلى float.NaN أو NullableBool.NotDefined). الشيفرة المثال أعلاه الآن ترمي استثناء ArgumentException.
ينطبق هذا على هذه الاستخدامات:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // لا يمكن أن تكون غير معرّفة

IShapeCollection shapes = ...;

// لا يمكن أن تكون القيم x وy وwidth وheight float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

لكن يمكن أن تكون خصائص إطار IShape.RawFrame غير معرفة. هذا له معنى عندما يرتبط الشكل بمكان الحجز. ثم يتم تجاوز قيم إطار الشكل غير المعرفة من شكل المكان الحجز الأب. إذا لم يكن هناك شكل مكان الحجز أب، فإن الشكل يستخدم القيم الافتراضية عند تقييم إطار الفعلي بناءً على IShape.RawFrame الخاص به. القيم الافتراضية هي 0 وNullableBool.False لـ x وy وwidth وheight وflipH وflipV وrotationAngle. على سبيل المثال:

``` csharp

 IShape shape = ...; // الشكل مرتبط بالمكان الحجز

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// الآن الشكل يرث قيم x وy وheight وflipH وflipV من المكان الحجز ويعوض width=100 وrotationAngle=0.

``` 
### **الخصائص المتغيرة**
#### **تغيير اسم ونوع خاصية Aspose.Slides.IShapeCollection.Parent**
- تم تغيير نوع خاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى واجهة IGroupShape الجديدة. واجهة IGroupShape هي سليل لـ ISlideComponent لذا لا تحتاج الشيفرة الحالية إلى تعديلات.
- تم تغيير اسم خاصية Aspose.Slides.IShapeCollection.Parent من Parent إلى ParentGroup.
#### **تغيير أنواع خصائص Aspose.Slides.IShapeFrame.FlipH و.FlipV**
- تم تغيير نوع خاصية Aspose.Slides.IShapeFrame.FlipH من bool إلى NullableBool.
- ترجع خاصية IShape.Frame نسخة فعالة من IShapeFrame (جميع خصائصها لها قيم فعالة معرفة).
- ترجع خاصية IShape.RawFrame نسخة من IShapeFrame يمكن أن تكون لكل خاصية فيها قيمة غير معرفة (خصوصًا يمكن أن تحتوي FlipH أو FlipV على قيمة NullableBool.NotDefined).