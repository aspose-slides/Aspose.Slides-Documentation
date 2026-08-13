---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.5.0"
linktitle: "Aspose.Slides لـ .NET 14.5.0"
type: docs
weight: 70
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تسرد هذه الصفحة جميع الفئات، والطرق، والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) أخرى و[تغييرات](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) تم تقديمها مع Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **الواجهات والفئات والخصائص والطرق المضافة**
#### **تم إضافة واجهة Aspose.Slides.IPresentationInfo والفئة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

- الخاصية المنطقية IsEncrypted تُعيد True إذا كان العرض التقديمي مشفرًا، وإلا تُعيد False.
- الخاصية LoadFormat تُعيد نوع العرض التقديمي.
#### **تم إضافة الخاصية Aspose.Slides.IShape.IsGrouped**
تحدد الخاصية Aspose.Slides.IShape.IsGrouped ما إذا كان الشكل مجموعًا.
#### **تم إضافة الخاصية Aspose.Slides.IShape.ParentGroup**
تُعيد الخاصية Aspose.Slides.IShape.ParentGroup كائن GroupShape الأب إذا كان الشكل مجموعًا. وإلا تُعيد null.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.AddGroupShape()**
تنشئ الطريقة Aspose.Slides.IShapeCollection.AddGroupShape() كائن GroupShape جديد وتضيفه إلى نهاية المجموعة.
سيُضبط حجم الإطار وموقع GroupShape ليتناسب مع المحتوى عند إضافة شكل جديد.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.Clear()**
تزيل الطريقة Aspose.Slides.IShapeCollection.Clear() جميع الأشكال من المجموعة.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
تنشئ الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int) كائن GroupShape جديد وتدرجه في المجموعة عند موضع الفهرس المحدد.
سيُضبط حجم الإطار وموقع GroupShape ليتناسب مع المحتوى عند إضافة شكل جديد.
#### **تم إضافة الطرق IPresentationFactory.GetPresentationInfo(string file) وIPresentationFactory.GetPresentationInfo(Stream stream)**
تتيح هذه الطرق الحصول على معلومات حول ملف عرض تقديمي أو تدفق دون تحميل العرض بالكامل.
#### **تم إضافة الخاصية IPresentationFactory PresentationFactory.Instance**
تُتيح هذه الخاصية للمطورين استخدام وظائف المصنع دون الحاجة إلى إنشاء كائن.
### **القيود**
#### **قيود على IShape.Frame**
تم إضافة قيود للاستخدام القيم غير المعرفة لـ IShape.Frame. الشيفرة التي تحاول تعيين إطار غير معرف إلى IShape.Frame لا معنى لها في معظم الحالات (خاصة عندما يكون كائن GroupShape الأب متداخلًا في {{GroupShape}}s أخرى). على سبيل المثال:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// يرمي استثناء ArgumentException: يجب تعريف قيم الإطار.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

أو

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// يرمي استثناء ArgumentException: يجب تعريف x و y والعرض والارتفاع.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

يمكن أن يتسبب مثل هذا الشيفرة في مواقف غير واضحة. لذلك تمت إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. يجب تعريف قيم x وy والعرض والارتفاع وflipH وflipV وزاوية الدوران (وليست مضبوطة إلى float.NaN أو NullableBool.NotDefined). الآن يُطلق الشيفرة أعلاه استثناء ArgumentException.
ينطبق ذلك على حالات الاستخدام التالية:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// لا يمكن أن تكون معلمات x و y والعرض والارتفاع float.NaN، ولا يمكن أن تكون flipH و flipV
// لا يمكن أن تكون NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// ينطبق نفس القيد على كل طريقة تنشئ شكلاً:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

لكن خصائص إطار IShape.RawFrame يمكن أن تكون غير معرفة. هذا منطقي عندما يكون الشكل مرتبطًا بعنصر نائب. حينها يتم استبدال قيم إطار الشكل غير المعرفة من العنصر النائب الأب. إذا لم يكن هناك عنصر نائب أب، يستخدم الشكل القيم الافتراضية عند تقييم الإطار الفعّال بناءً على IShape.RawFrame. القيم الافتراضية هي 0 وNullableBool.False لـ x وy والعرض والارتفاع وflipH وflipV وزاوية الدوران. على سبيل المثال:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // الشكل مرتبط بعنصر نائب
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // الآن يرث الشكل قيم x و y والارتفاع و flipH و flipV من العنصر النائب ويستبدل العرض=100 وزاوية الدوران=0.
}
``` 
### **الخصائص المتغيرة**
#### **تم تغيير اسم النوع الخاصية Aspose.Slides.IShapeCollection.Parent**
- تم تغيير نوع الخاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى الواجهة الجديدة IGroupShape. الواجهة IGroupShape تُشتق من ISlideComponent لذا لا تحتاج الشيفرة الحالية إلى تعديل.
- تم تغيير اسم الخاصية Aspose.Slides.IShapeCollection.Parent من Parent إلى ParentGroup.
#### **تم تغيير نوعي الخصائص Aspose.Slides.IShapeFrame.FlipH و .FlipV**
- تم تغيير نوع الخاصية Aspose.Slides.IShapeFrame.FlipH من bool إلى NullableBool.
- تُعيد خاصية IShape.Frame نسخة فعّالة من IShapeFrame (جميع خصائصها لها قيم فعّالة معرفة).
- تُعيد خاصية IShape.RawFrame نسخة من IShapeFrame يمكن أن تكون لكل خاصية منها قيمة غير معرفة (خاصة FlipH أو FlipV يمكن أن تكون NullableBool.NotDefined).