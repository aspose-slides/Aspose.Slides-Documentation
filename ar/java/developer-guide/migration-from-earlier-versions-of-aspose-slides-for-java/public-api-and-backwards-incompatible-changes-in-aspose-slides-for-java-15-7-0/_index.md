---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- الهجرة
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المدمرة في Aspose.Slides for Java للانتقال بسلاسة إلى حلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---
{{% alert color="info" %}}

هذه الصفحة تسرد جميع [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) أو [المحذوفة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) الفئات، الطرق، الخصائص وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for Java 15.7.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تم إضافة Enum com.aspose.slides.ImagePixelFormat**
تم إضافة Enum com.aspose.slides.ImagePixelFormat لتحديد تنسيق البكسل للصور المولدة.
#### **تم إضافة طريقة com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
تُعيد هذه الطريقة لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة، فهرس نقطة البيانات، parentSeriesGroup، قيم isColorVaried ونمط المخطط. يتم استخدام هذا اللون بشكل افتراضي إذا كان fillType يساوي NotDefined.
#### **تمت إضافة طرق getPixelFormat() و setPixelFormat(int) إلى com.aspose.slides.ITiffOptions**
تمت إضافة طرق getPixelFormat() و setPixelFormat(/ImagePixelFormat/int) إلى com.aspose.slides.ITiffOptions و com.aspose.slides.TiffOptions لتحديد تنسيق البكسل للصور TIFF المولدة.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```