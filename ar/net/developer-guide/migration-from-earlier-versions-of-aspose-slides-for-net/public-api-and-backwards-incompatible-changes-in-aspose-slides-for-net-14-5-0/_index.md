---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides for .NET 14.5.0
linktitle: Aspose.Slides for .NET 14.5.0
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسورة في Aspose.Slides for .NET للقيام بترحيل سلس لحلول عروض PowerPoint بصيغ PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) الفئات، الطرق، الخصائص وما إلى ذلك، وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) جديدة و[تغييرات](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) أخرى تم تقديمها مع Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **API العامة والتغييرات غير المتوافقة للخلف**
### **الواجهات والفئات والخصائص والطرق المضافة**
#### **إضافة واجهة Aspose.Slides.IPresentationInfo وفئة PresentationInfo**
تمثل معلومات حول العرض التقديمي.

- الخاصية Boolean IsEncrypted تُرجع True إذا كان العرض التقديمي مشفرًا، وإلا تُرجع False.  
- الخاصية LoadFormat تُرجع نوع العرض التقديمي.  
#### **إضافة الخاصية Aspose.Slides.IShape.IsGrouped**
تحدد الخاصية Aspose.Slides.IShape.IsGrouped ما إذا كان الشكل مُجمّعًا.  
#### **إضافة الخاصية Aspose.Slides.IShape.ParentGroup**
تُرجع الخاصية Aspose.Slides.IShape.ParentGroup كائن GroupShape الأب إذا كان الشكل مُجمّعًا. وإلا تُرجع null.  
#### **إضافة الطريقة Aspose.Slides.IShapeCollection.AddGroupShape()**
تنشئ الطريقة Aspose.Slides.IShapeCollection.AddGroupShape() كائن GroupShape جديد وتضيفه في نهاية المجموعة.  
سيتم ضبط حجم وإحداثيات إطار GroupShape ليتناسب مع المحتوى عند إضافة شكل جديد.  
#### **إضافة الطريقة Aspose.Slides.IShapeCollection.Clear()**
تُزيل الطريقة Aspose.Slides.IShapeCollection.Clear() جميع الأشكال من المجموعة.  
#### **إضافة الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
تنشئ الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int) كائن GroupShape جديد وتدرجه في المجموعة عند الفهرس المحدد.  
سيتم ضبط حجم وإحداثيات إطار GroupShape ليتناسب مع المحتوى عند إضافة شكل جديد.  
#### **إضافة الأساليب IPresentationFactory.GetPresentationInfo(string file)، IPresentatoinFactory.GetPresentationInfo(Stream stream)**
تسمح هذه الأساليب بالحصول على معلومات حول ملف العرض التقديمي أو الدفق دون تحميل العرض بالكامل.  
#### **إضافة الخاصية IPresentationFactory PresentationFactory.Instance**
تُتيح هذه الخاصية للمطورين استخدام وظائف المصنع دون الحاجة إلى إنشاء كائن.  
### **القيود**
#### **قيود على IShape.Frame**
تمت إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. الكود الذي يحاول تعيين إطار غير معرف إلى IShape.Frame لا يكون منطقياً في معظم الحالات (خصوصاً عندما يكون GroupShape الأب متداخلًا داخل {{GroupShape}}s أخرى). على سبيل المثال:

``` csharp
 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

أو

``` csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

يمكن أن يؤدي مثل هذا الكود إلى حالات غير واضحة. لذلك تمت إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. يجب أن تكون قيم x، y، العرض، الارتفاع، flipH، flipV و rotationAngle معرفة (وليست float.NaN أو NullableBool.NotDefined). الكود المثال أعلاه الآن يُطلق استثناء ArgumentException.  
ينطبق ذلك على الحالات التالية:

``` csharp
 IShape shape = ...;

shape.Frame = ...; // لا يمكن أن تكون غير معرفة

IShapeCollection shapes = ...;

// لا يمكن أن تكون المعلمات x، y، العرض، الارتفاع float.NaN:
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

لكن خصائص إطار IShape.RawFrame يمكن أن تكون غير معرفة. هذا منطقي عندما يكون الشكل مرتبطًا بعنصر نائب. في هذه الحالة تُستبدل قيم إطار الشكل غير المعرفة من عنصر النائب الأب. إذا لم يوجد عنصر نائب أب، فإن الشكل يستخدم القيم الافتراضية عند حساب الإطار الفعّال بناءً على IShape.RawFrame. القيم الافتراضية هي 0 و NullableBool.False لـ x، y، العرض، الارتفاع، flipH، flipV و rotationAngle. على سبيل المثال:

``` csharp
 IShape shape = ...; // الشكل مرتبط بعنصر نائب
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// الآن يرث الشكل قيم x، y، الارتفاع، flipH، flipV من العنصر النائب ويستبدل العرض=100 وزاوية الدوران=0.
``` 
### **الخصائص المتغيَّرة**
#### **تغيير اسم ونوع خاصية Aspose.Slides.IShapeCollection.Parent**
- تم تغيير نوع خاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى الواجهة الجديدة IGroupShape. الواجهة IGroupShape تُعد فرعًا من ISlideComponent لذا لا تحتاج الشفرة القائمة إلى تعديل.  
- تم تغيير اسم خاصية Aspose.Slides.IShapeCollection.Parent من Parent إلى ParentGroup.  
#### **تغيير نوعي خاصيات Aspose.Slides.IShapeFrame.FlipH و .FlipV**
- تم تغيير نوع خاصية Aspose.Slides.IShapeFrame.FlipH من bool إلى NullableBool.  
- خاصية IShape.Frame تُعيد نسخة فعّالة من IShapeFrame (جميع خصائصها لها قيم فعّالة معرفة).  
- خاصية IShape.RawFrame تُعيد نسخة من IShapeFrame يمكن لكل خاصية فيها أن تكون غير معرفة (خصوصاً FlipH أو FlipV يمكن أن تكون NullableBool.NotDefined).