---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.7.0
type: docs
weight: 150
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [الإضافات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) أو [الإزالات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) للفئات، والأساليب، والخصائص، وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.7.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة Enum com.aspose.slides.ImagePixelFormat**
تمت إضافة Enum com.aspose.slides.ImagePixelFormat لتحديد تنسيق البيكسل للصور الناتجة.
#### **تمت إضافة دالة com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
ترجع هذه الدالة لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة، وفهرس نقطة البيانات، ومجموعة السلسلة الأم، وقيم isColorVaried، ونمط الرسم البياني. يُستخدم هذا اللون بشكل افتراضي إذا كان fillType يساوي NotDefined.
#### **تمت إضافة طرق getPixelFormat() و setPixelFormat(int) إلى com.aspose.slides.ITiffOptions**
تمت إضافة طرق getPixelFormat() و setPixelFormat(/ImagePixelFormat/int) إلى com.aspose.slides.ITiffOptions و com.aspose.slides.TiffOptions لتحديد تنسيق البيكسل للصور TIFF الناتجة.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```