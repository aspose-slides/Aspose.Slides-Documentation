---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.7.0
type: docs
weight: 150
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [المضاف](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) أو [المزال](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) الفئات، والأساليب، والخصائص، وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.7.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة enum com.aspose.slides.ImagePixelFormat**
تمت إضافة enum com.aspose.slides.ImagePixelFormat لتحديد تنسيق البكسل للصور المولدة.
#### **تمت إضافة طريقة com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
ترجع هذه الطريقة لونًا تلقائيًا لنقطة البيانات استنادًا إلى فهرس السلسلة، وفهرس نقطة البيانات، ومجموعة السلسلة الأصلية، وقيم isColorVaried، ونمط الرسم البياني. يتم استخدام هذا اللون بشكل افتراضي إذا كانت fillType تساوي NotDefined.
#### **تمت إضافة طرق getPixelFormat()، setPixelFormat(int) إلى com.aspose.slides.ITiffOptions**
تمت إضافة طرق getPixelFormat()، setPixelFormat(/ImagePixelFormat/int) إلى com.aspose.slides.ITiffOptions و com.aspose.slides.TiffOptions لتحديد تنسيق البكسل للصور TIFF المولدة.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```