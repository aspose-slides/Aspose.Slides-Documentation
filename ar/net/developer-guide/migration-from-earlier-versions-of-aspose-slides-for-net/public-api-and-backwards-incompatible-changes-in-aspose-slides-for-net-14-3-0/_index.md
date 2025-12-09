---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.3.0"
linktitle: "Aspose.Slides لـ .NET 14.3.0"
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **إضافة تعداد Aspose.Slides.ShapeThumbnailBounds وطرق Aspose.Slides.IShape.GetThumbnail()**
تُستخدم الطريقتان GetThumbnail() و GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) لإنشاء صورة مصغرة منفصلة للشكل. يُعرّف تعداد ShapeThumbnailBounds أنواع حدود الصورة المصغرة للشكل الممكنة.
### **تمت إضافة الخاصية UniqueId إلى Aspose.Slides.IShape**
تُعيد الخاصية Aspose.Slides.IShape.UniqueId معرّفًا فريدًا للشكل ضمن نطاق العرض التقديمي. تُخزن هذه المعرفات الفريدة في وسوم مخصصة للشكل.
### **تم تغيير توقيع طريقة SetGroupingItem في IChartCategoryLevelsManager**
توقيع طريقة IChartCategoryLevelsManager

```csharp
 void SetGroupingItem(int level, IChartDataCell value);
```

أصبح الآن غير صالح وتم استبداله بالتوقيع

```csharp
 void SetGroupingItem(int level, object value);
```

الآن الاستدعاءات مثل

```csharp
 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
```

يجب تغييرها إلى استدعاءات مثل

```csharp
 .SetGroupingItem(1, "Group 1");
```

مرّر قيمة مثل "Group 1" إلى SetGroupingItem ولكن ليس قيمة من النوع IChartDataCell. إنشاء IChartDataCell باستخدام ورقة عمل محددة وصف وعمود لمستويات الفئات يتعين أن يفي ببعض المتطلبات وقد تم تغليفه داخل طريقة SetGroupingItem(int, object).
### **تمت إضافة الخاصية SlideId إلى واجهة Aspose.Slides.IBaseSlide**
تُعيد الخاصية SlideId معرّفًا فريدًا للشرائح.
### **تمت إضافة الخاصية SoundName إلى ISlideShowTransition**
سلسلة قابلة للقراءة والكتابة. تحدد اسمًا مقروءًا للبشر لصوت الانتقال. يجب تعيين الخاصية Sound للحصول على اسم الصوت أو تعيينه. يظهر هذا الاسم في واجهة المستخدم لبرنامج PowerPoint عند تكوين صوت الانتقال يدويًا. قد تُسبب استثناء PptxException إذا لم يتم تعيين الخاصية Sound.
### **تم تغيير نوع خاصية ChartSeriesGroup.Type**
تم تغيير خاصية ChartSeriesGroup.Type من تعداد ChartType إلى تعداد CombinableSeriesTypesGroup الجديد. يمثل تعداد CombinableSeriesTypesGroup مجموعات أنواع السلاسل القابلة للجمع.
### **تمت إضافة الدعم لإنشاء صور مصغرة فردية للأشكال**
Aspose.Slides.ShapeThumbnailBounds

الأعضاء الجدد في Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)