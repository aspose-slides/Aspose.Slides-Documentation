---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.3.0"
linktitle: "Aspose.Slides لـ .NET 14.3.0"
type: docs
weight: 50
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET للقيام بترحيل سلس لحلول عروض PowerPoint PPT و PPTX و ODP."
---

## **‏واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **تم إضافة تعداد Aspose.Slides.ShapeThumbnailBounds وطرق Aspose.Slides.IShape.GetThumbnail()**
تُستخدم الطُرُق GetThumbnail() و GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) لإنشاء صورة مصغَّرة للشكل منفصلة. يُعرّف تعداد ShapeThumbnailBounds الأنواع الممكنة لحدود الصورة المصغرة للشكل.

### **تم إضافة الخاصية UniqueId إلى Aspose.Slides.IShape**
تُعيد الخاصية Aspose.Slides.IShape.UniqueId معرفًا فريدًا للشكل داخل نطاق العرض التقديمي. تُخزن هذه المعرفات الفريدة في وسوم مخصصة للشكل.

### **تم تغيير توقيع طريقة SetGroupingItem في IChartCategoryLevelsManager**
كان توقيع طريقة IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

قديمًا الآن وتم استبداله بالتوقيع

``` csharp

 void SetGroupingItem(int level, object value);

``` 

لذلك يجب تغيير الاستدعاءات مثل

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

إلى استدعاءات مثل

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

مرّر قيمة مثل "Group 1" إلى SetGroupingItem بدلاً من قيمة من نوع IChartDataCell. إن بناء IChartDataCell باستخدام ورقة عمل محددة، صف وعمود لمستويات الفئة يتطلب بعض المتطلبات وقد تم تغليفه داخل طريقة SetGroupingItem(int, object).

### **تم إضافة الخاصية SlideId إلى واجهة Aspose.Slides.IBaseSlide**
تُعيد الخاصية SlideId معرفًا فريدًا للشفرة.

### **تم إضافة الخاصية SoundName إلى ISlideShowTransition**
سلسلة قابلة للقراءة والكتابة. تُحدد اسمًا مقروءًا للبشر لصوت الانتقال. يجب تعيين الخاصية Sound لتحديد أو الحصول على اسم الصوت. يظهر هذا الاسم في واجهة PowerPoint عند تكوين صوت الانتقال يدويًا. قد تُطلق استثناء PptxException إذا لم يتم تعيين الخاصية Sound.

### **تم تغيير نوع الخاصية ChartSeriesGroup.Type**
تم تغيير الخاصية ChartSeriesGroup.Type من تعداد ChartType إلى تعداد CombinableSeriesTypesGroup الجديد. يُمثِّل تعداد CombinableSeriesTypesGroup مجموعات الأنواع القابلة للجمع لسلاسل البيانات.

### **تم إضافة دعم إنشاء صور مصغرة فردية للأشكال**
Aspose.Slides.ShapeThumbnailBounds

الأعضاء الجدد في Aspose.Slides.IShape و Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)