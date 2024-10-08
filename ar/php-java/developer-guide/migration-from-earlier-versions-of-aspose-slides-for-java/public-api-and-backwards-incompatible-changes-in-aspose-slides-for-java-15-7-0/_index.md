---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 15.7.0
type: docs
weight: 150
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الإضافات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) أو [الإزالات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وغيرها من التغييرات المقدمة مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.7.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة Enum com.aspose.slides.ImagePixelFormat**
تمت إضافة Enum com.aspose.slides.ImagePixelFormat لتحديد تنسيق بكسل الصور المولدة.
#### **تمت إضافة طريقة com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
تُرجع هذه الطريقة لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة وفهرس نقطة البيانات وparentSeriesGroup والقيم isColorVaried ونمط الرسم البياني. يُستخدم هذا اللون بشكل افتراضي إذا كانت fillType تساوي NotDefined.
#### **تمت إضافة طرق getPixelFormat() و setPixelFormat(int) إلى com.aspose.slides.ITiffOptions**
تمت إضافة طرق getPixelFormat() و setPixelFormat(/ImagePixelFormat/int) إلى com.aspose.slides.ITiffOptions و com.aspose.slides.TiffOptions لتحديد تنسيق بكسل الصور المولدة بتنسيق TIFF.

```php
  $pres = new Presentation("demo.pptx");
  $options = new TiffOptions();
  $options->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
  $pres->save("demo-out.tiff", SaveFormat::Tiff, $options);

```