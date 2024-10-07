---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.3.0
type: docs
weight: 50
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **تمت إضافة تعداد Aspose.Slides.ShapeThumbnailBounds وطرق Aspose.Slides.IShape.GetThumbnail()**
تستخدم طرق GetThumbnail() وGetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) لإنشاء صورة مصغرة منفصلة للشكل. يحدد تعداد ShapeThumbnailBounds أنواع حدود الصورة المصغرة الممكنة.
### **تمت إضافة خاصية UniqueId إلى Aspose.Slides.IShape**
تحصل خاصية Aspose.Slides.IShape.UniqueId على معرّف فريد للشكل في نطاق العرض التقديمي. يتم تخزين هذه المعرفات الفريدة في علامات الشكل المخصصة.
### **تغيرت توقيع طريقة SetGroupingItem في IChartCategoryLevelsManager**
توقيع طريقة IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

أصبح غير متاح الآن وتم استبداله بالتوقيع

``` csharp

 void SetGroupingItem(int level, object value);

``` 

يجب الآن تغيير الاستدعاءات مثل

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

إلى استدعاءات مثل

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

تمرير قيمة مثل "Group 1" إلى SetGroupingItem ولكن ليس قيمة من نوع IChartDataCell. يجب أن يتوافق بناء IChartDataCell مع ورقة عمل محددة، صف وعمود لمستويات الفئة مع بعض المتطلبات وقد تم encapsulated في الطريقة SetGroupingItem(int, object).
### **تمت إضافة خاصية SlideId إلى واجهة Aspose.Slides.IBaseSlide**
تحصل خاصية SlideId على معرّف شريحة فريد.
### **تمت إضافة خاصية SoundName إلى ISlideShowTransition**
نص قابل للقراءة والكتابة. يحدد اسمًا قابلًا للقراءة البشرية لصوت الانتقال. يجب تعيين خاصية Sound للحصول على أو تعيين اسم الصوت. يظهر هذا الاسم في واجهة مستخدم PowerPoint عند تكوين صوت الانتقال يدويًا. قد يؤدي إلى إثارة PptxException عندما لا يتم تعيين خاصية Sound.
### **تغير نوع خاصية ChartSeriesGroup.Type**
تم تغيير خاصية ChartSeriesGroup.Type من تعداد ChartType إلى تعداد CombinableSeriesTypesGroup الجديد. يمثل تعداد CombinableSeriesTypesGroup مجموعات من أنواع السلاسل القابلة للجمع.
### **إضافة دعم لإنشاء صور مصغرة منفصلة للشكل**
Aspose.Slides.ShapeThumbnailBounds

أعضاء جدد في Aspose.Slides.IShape، Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)