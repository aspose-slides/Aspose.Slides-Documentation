---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لل.NET 14.3.0
linktitle: Aspose.Slides لل.NET 14.3.0
type: docs
weight: 50
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتكسرة في Aspose.Slides لل.NET لتسهيل ترحيل حلول عروض PowerPoint (PPT, PPTX) و ODP الخاصة بك."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **تم إضافة تعداد Aspose.Slides.ShapeThumbnailBounds وطرق Aspose.Slides.IShape.GetThumbnail()**
تُستخدم الطريقتان GetThumbnail() وGetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) لإنشاء صورة مصغرة منفصلة للشكل. يُعرّف تعداد ShapeThumbnailBounds أنواع الحدود الممكنة للصور المصغرة للأشكال.
### **تم إضافة الخاصية UniqueId إلى Aspose.Slides.IShape**
خاصية Aspose.Slides.IShape.UniqueId تُعيد معرفًا فريدًا للشكل ضمن نطاق العرض التقديمي. تُخزن هذه المعرفات الفريدة في علامات مخصصة للشكل.
### **تم تغيير توقيع طريقة SetGroupingItem في IChartCategoryLevelsManager**
توقيع طريقة IChartCategoryLevelsManager

```csharp
 void SetGroupingItem(int level, IChartDataCell value);
``` 

أصبح الآن مهجورًا وتم استبداله بالتوقيع

```csharp
 void SetGroupingItem(int level, object value);
``` 

الآن يجب تعديل الاستدعاءات مثل

```csharp
 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
``` 

لتصبح استدعاءات مثل

```csharp
 .SetGroupingItem(1, "Group 1");
``` 

مرّر قيمة مثل "Group 1" إلى SetGroupingItem بدلاً من قيمة من نوع IChartDataCell. إنشاء IChartDataCell باستخدام ورقة عمل محددة وصف وعمود لمستويات الفئات يتطلب بعض المتطلبات وتم تجميعه في طريقة SetGroupingItem(int, object).
### **تم إضافة الخاصية SlideId إلى واجهة Aspose.Slides.IBaseSlide**
خاصية SlideId تُعيد معرفًا فريدًا للشفرة.
### **تم إضافة الخاصية SoundName إلى ISlideShowTransition**
سلسلة قراءة-كتابة. تحدد اسمًا قابلًا للقراءة من قبل الإنسان لصوت الانتقال. يجب تعيين خاصية Sound للحصول على اسم الصوت أو تعيينه. يظهر هذا الاسم في واجهة مستخدم PowerPoint عند تكوين صوت الانتقال يدويًا. قد تُلقي استثناء PptxException عندما لا تكون خاصية Sound مُعينة.
### **تم تغيير نوع الخاصية ChartSeriesGroup.Type**
تم تغيير خاصية ChartSeriesGroup.Type من تعداد ChartType إلى تعداد CombinableSeriesTypesGroup الجديد. يمثل تعداد CombinableSeriesTypesGroup مجموعات الأنواع القابلة للجمع من السلسلات.
### **تم إضافة دعم إنشاء صور مصغرة فردية للأشكال**
Aspose.Slides.ShapeThumbnailBounds

الأعضاء الجدد في Aspose.Slides.IShape، Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)