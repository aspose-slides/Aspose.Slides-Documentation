---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides for .NET 14.5.0
linktitle: Aspose.Slides لـ .NET 14.5.0
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتقوم بترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ، وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) وتغييرات [أخرى](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for .NET 14.5.0.

{{% /alert %}} 
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف**
### **الواجهات والفئات والخصائص والطرق التي تم إضافتها**
#### **تم إضافة واجهة Aspose.Slides.IPresentationInfo وفئة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

- الخاصية Boolean IsEncrypted تُعيد True إذا كان العرض التقديمي مشفرًا، وإلا تُعيد False.
- الخاصية LoadFormat تُعيد نوع العرض التقديمي.
#### **تم إضافة الخاصية Aspose.Slides.IShape.IsGrouped**
تحدد الخاصية Aspose.Slides.IShape.IsGrouped ما إذا كان الشكل مُجَمَّعًا.
#### **تم إضافة الخاصية Aspose.Slides.IShape.ParentGroup**
تُعيد الخاصية Aspose.Slides.IShape.ParentGroup كائن GroupShape الأب إذا كان الشكل مُجَمَّعًا. وإلا تُعيد null.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.AddGroupShape()**
تُنشئ الطريقة Aspose.Slides.IShapeCollection.AddGroupShape() كائن GroupShape جديد وتضيفه إلى نهاية المجموعة.
سيتم ضبط حجم وإحداثيات إطار GroupShape لتتناسب مع المحتوى عند إضافة شكل جديد.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.Clear()**
تُزيل الطريقة Aspose.Slides.IShapeCollection.Clear() جميع الأشكال من المجموعة.
#### **تم إضافة الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
تُنشئ الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int) كائن GroupShape جديد وتدرجه في المجموعة في الموضع المحدد.
سيتم ضبط حجم وإحداثيات إطار GroupShape لتتناسب مع المحتوى عند إضافة شكل جديد.
#### **تم إضافة الطرق IPresentationFactory.GetPresentationInfo(string file)، IPresentatoinFactory.GetPresentationInfo(Stream stream)**
تتيح هذه الطرق الحصول على معلومات حول ملف العرض التقديمي أو التدفق دون تحميل العرض بالكامل.
#### **تم إضافة الخاصية IPresentationFactory PresentationFactory.Instance**
تُتيح هذه الخاصية للمطورين استخدام وظائف المصنع دون إنشاء كائن.
### **القيود**
#### **قيود على IShape.Frame**
تم إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. الشيفرة التي تحاول تعيين إطار غير معرف إلى IShape.Frame لا معنى لها في معظم الحالات (خاصة عندما يكون الـ GroupShape الأب مُدمجًا عدة مرات داخل {{GroupShape}} أخرى). على سبيل المثال:

```csharp
 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

أو

```csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

مثل هذا الشيفرة قد يؤدي إلى أوضاع غير واضحة. لذا تم إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. يجب أن تكون قيم x و y والعرض والارتفاع و flipH و flipV و rotationAngle معرفة (وليس من القيم float.NaN أو NullableBool.NotDefined). الشيفرة في المثال أعلاه الآن تُطلق استثناء ArgumentException.
ينطبق ذلك على حالات الاستخدام التالية:

```csharp
 IShape shape = ...;

shape.Frame = ...; // لا يمكن أن تكون غير معرفة

IShapeCollection shapes = ...;

// لا يمكن أن تكون معلمات x و y والعرض والارتفاع float.NaN:
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

لكن خصائص إطار IShape.RawFrame يمكن أن تكون غير معرفة. هذا منطقي عندما يكون الشكل مرتبطًا بمكان حفظ مؤقت (placeholder). عندها تُستبدل قيم إطار الشكل غير المعرفة من قبل الشكل المؤقت الأب. إذا لم يكن هناك شكل مؤقت أب، فإن هذا الشكل يستخدم القيم الافتراضية عندما يقيّم الإطار الفعلي بناءً على IShape.RawFrame. القيم الافتراضية هي 0 و NullableBool.False لـ x و y والعرض والارتفاع و flipH و flipV و rotationAngle. على سبيل المثال:

```csharp
 IShape shape = ...; // الشكل مرتبط بمكان حفظ مؤقت
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// الآن يرث الشكل قيم x و y والارتفاع و flipH و flipV من المكان المؤقت ويُستبدل العرض =100 والزاوية =0.
``` 
### **الخصائص التي تم تغييرها**
#### **تم تغيير اسم نوع خاصية Aspose.Slides.IShapeCollection.Parent**
- تم تغيير نوع خاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى الواجهة الجديدة IGroupShape. الواجهة IGroupShape هي فرع من ISlideComponent لذا لا يحتاج الكود الحالي إلى تعديل.
- تم تغيير اسم خاصية Aspose.Slides.IShapeCollection.Parent من Parent إلى ParentGroup.
#### **تم تغيير نوع خصائص Aspose.Slides.IShapeFrame.FlipH و .FlipV**
- تم تغيير نوع خاصية Aspose.Slides.IShapeFrame.FlipH من bool إلى NullableBool.
- خاصية IShape.Frame تُعيد نسخة فعّالة من IShapeFrame (جميع خصائصها لها قيم فعّالة معرفة).
- خاصية IShape.RawFrame تُعيد نسخة من IShapeFrame يمكن أن تكون كل خاصية فيها غير معرفة (خصوصًا FlipH أو FlipV يمكن أن يكون لهما القيمة NullableBool.NotDefined).