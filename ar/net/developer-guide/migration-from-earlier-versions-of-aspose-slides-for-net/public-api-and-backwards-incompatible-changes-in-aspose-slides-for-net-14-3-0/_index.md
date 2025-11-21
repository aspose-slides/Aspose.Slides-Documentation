---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.3.0
linktitle: Aspose.Slides لـ .NET 14.3.0
type: docs
weight: 50
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- الهجرة
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجذرية في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP الخاصة بك."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **تم إضافة تعداد Aspose.Slides.ShapeThumbnailBounds وطرق Aspose.Slides.IShape.GetThumbnail()**
تُستخدم الطريقتان GetThumbnail() و GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) لإنشاء صورة مصغرة منفصلة للشكل. يعرّف تعداد ShapeThumbnailBounds أنواع الحدود الممكنة لصورة الشكل المصغرة.
### **تم إضافة الخاصية UniqueId إلى Aspose.Slides.IShape**
تُعيد الخاصية Aspose.Slides.IShape.UniqueId معرفًا فريدًا للشكل داخل نطاق العرض التقديمي. تُحفظ هذه المعرفات الفريدة في وسوم مخصصة للشكل.
### **تم تغيير توقيع طريقة SetGroupingItem في IChartCategoryLevelsManager**
توقيع طريقة IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

أصبح الآن مهجورًا وتم استبداله بالتوقيع

``` csharp

 void SetGroupingItem(int level, object value);

``` 

الآن يجب أن تكون الاستدعاءات مثل

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

يجب تغييرها إلى استدعاءات مثل

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

مرّر قيمة مثل "Group 1" إلى SetGroupingItem وليس قيمة من النوع IChartDataCell. إنشاء IChartDataCell باستخدام ورقة عمل محددة وصف وعمود لمستويات الفئات يجب أن يفي ببعض المتطلبات وقد تم تغليفه في طريقة SetGroupingItem(int, object).
### **تم إضافة الخاصية SlideId إلى واجهة Aspose.Slides.IBaseSlide**
تُعيد الخاصية SlideId معرفًا فريدًا للشريحة.
### **تم إضافة الخاصية SoundName إلى ISlideShowTransition**
سلسلة قابلة للقراءة والكتابة. تحدد اسمًا قابلاً للقراءة البشرية لصوت الانتقال. يجب تعيين الخاصية Sound للحصول على اسم الصوت أو تعيينه. يظهر هذا الاسم في واجهة مستخدم PowerPoint عند تكوين صوت الانتقال يدويًا. قد يتم إلقاء PptxException عندما لا يتم تعيين الخاصية Sound.
### **تم تغيير نوع الخاصية ChartSeriesGroup.Type**
تم تغيير الخاصية ChartSeriesGroup.Type من تعداد ChartType إلى تعداد CombinableSeriesTypesGroup الجديد. يمثل تعداد CombinableSeriesTypesGroup مجموعات أنواع السلاسل القابلة للجمع.
### **تم إضافة دعم إنشاء صور مصغرة فردية للأشكال**
Aspose.Slides.ShapeThumbnailBounds

الأعضاء الجدد في Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)