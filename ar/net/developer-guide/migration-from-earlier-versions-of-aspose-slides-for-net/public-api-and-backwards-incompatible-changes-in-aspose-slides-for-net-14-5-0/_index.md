---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.5.0
linktitle: Aspose.Slides لـ .NET 14.5.0
type: docs
weight: 70
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- الترحيل
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
description: راجع تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint (PPT، PPTX) وODP بسلاسة.
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)، وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) و[تغييرات](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) جديدة تم تقديمها مع Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **API العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **الواجهات، الفئات، الخصائص والطرق المضافة**
#### **إضافة واجهة Aspose.Slides.IPresentationInfo وفئة PresentationInfo**
تمثيل معلومات عن العرض التقديمي.

- الخاصية البوليانية IsEncrypted تُرجع True إذا كان العرض مشفرًا، وإلا تُرجع False.  
- الخاصية LoadFormat تُرجع نوع العرض التقديمي.  
#### **إضافة الخاصية Aspose.Slides.IShape.IsGrouped**
تحدد الخاصية ما إذا كان الشكل مجمعًا.  
#### **إضافة الخاصية Aspose.Slides.IShape.ParentGroup**
تُعيد الخاصية كائن GroupShape الأب إذا كان الشكل مجمعًا. وإلا تُعيد null.  
#### **إضافة الطريقة Aspose.Slides.IShapeCollection.AddGroupShape()**
تنشئ الطريقة GroupShape جديدًا وتضيفه إلى نهاية المجموعة. سيتم ملاءمة حجم وإحداثيات إطار GroupShape للمحتوى عند إضافة شكل جديد.  
#### **إضافة الطريقة Aspose.Slides.IShapeCollection.Clear()**
تزيل الطريقة جميع الأشكال من المجموعة.  
#### **إضافة الطريقة Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
تنشئ الطريقة GroupShape جديدًا وتدرجه في المجموعة عند الموضع المحدد. سيتم ملاءمة حجم وإحداثيات إطار GroupShape للمحتوى عند إضافة شكل جديد.  
#### **إضافة الطرق IPresentationFactory.GetPresentationInfo(string file)، IPresentationFactory.GetPresentationInfo(Stream stream)**
تتيح هذه الطرق الحصول على معلومات حول ملف العرض أو التدفق دون تحميل كامل للعرض.  
#### **إضافة الخاصية IPresentationFactory PresentationFactory.Instance**
تسمح هذه الخاصية للمطورين باستخدام وظائف المصنع دون إنشاء كائن.  
### **القيود**
#### **القيود على IShape.Frame**
تمت إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. الشيفرة التي تحاول تعيين إطار غير معرف إلى IShape.Frame لا معنى لها في معظم الحالات (خاصةً عندما يكون الكائن GroupShape الأب متداخلًا في {{GroupShape}}s أخرى). على سبيل المثال:

``` csharp
 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

أو

``` csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

يمكن أن يؤدي مثل هذا الشيفرة إلى أوضاع غير واضحة. لذلك تمت إضافة قيود لاستخدام قيم غير معرفة لـ IShape.Frame. يجب تعريف قيم x و y والعرض والارتفاع و flipH و flipV و rotationAngle (ولا تُضبط إلى float.NaN أو NullableBool.NotDefined). الآن يرمى الشيفرة السابقة استثناء ArgumentException. ينطبق ذلك على الحالات التالية:

``` csharp
 IShape shape = ...;

shape.Frame = ...; // لا يمكن أن تكون غير معرفة

IShapeCollection shapes = ...;

// لا يمكن أن تكون المعلمات x ، y ، العرض ، الارتفاع من النوع float.NaN:
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

لكن خصائص إطار IShape.RawFrame يمكن أن تكون غير معرفة. هذا منطقي عندما يكون الشكل مرتبطًا بعنصر نائب. عندها تُستبدل القيم غير المعرفة من العنصر النائب الأب. إذا لم يكن هناك عنصر نائب أب، يستخدم الشكل القيم الافتراضية عند تقييم الإطار الفعلي بناءً على IShape.RawFrame. القيم الافتراضية هي 0 و NullableBool.False لـ x و y والعرض والارتفاع و flipH و flipV و rotationAngle. على سبيل المثال:

``` csharp
 IShape shape = ...; // الشكل مرتبط بعنصر نائب

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// الآن يرث الشكل قيم x و y والارتفاع و flipH و flipV من العنصر النائب ويستبدل العرض=100 و rotationAngle=0.
``` 
### **الخصائص المتغيرة**
#### **تغيير اسم ونوع الخاصية Aspose.Slides.IShapeCollection.Parent**
- تم تغيير نوع الخاصية Aspose.Slides.IShapeCollection.Parent من ISlideComponent إلى الواجهة الجديدة IGroupShape. الواجهة IGroupShape هي سلف لـ ISlideComponent لذلك لا تحتاج الشيفرة الموجودة إلى تعديل.  
- تم تغيير اسم الخاصية من Parent إلى ParentGroup.  
#### **تغيير نوعي الخصائص Aspose.Slides.IShapeFrame.FlipH و .FlipV**
- تم تغيير نوع الخاصية Aspose.Slides.IShapeFrame.FlipH من bool إلى NullableBool.  
- خاصية IShape.Frame تُعيد نسخة فعالة من IShapeFrame (جميع خصائصها لها قيم فعّالة معرفة).  
- خاصية IShape.RawFrame تُعيد نسخة من IShapeFrame يمكن لكل خاصية فيها أن تكون غير معرفة (خاصية FlipH أو FlipV يمكن أن تكون NullableBool.NotDefined).