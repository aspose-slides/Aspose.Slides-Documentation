---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 14.8.0
linktitle: Aspose.Slides للـ Java 14.8.0
type: docs
weight: 70
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for Java لضمان ترحيل سلس لحلول عروض PowerPoint (PPT و PPTX) و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تُدرج هذه الصفحة جميع [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) الفئات، الأساليب، الخصائص وما إلى ذلك، وأي قيود جديدة و[التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for Java 14.8.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة الأساليب Aspose.Slides.Charts.IChartSeries.getOverlap()، IChartSeriesGroup.getOverlap()، و setOverlap(byte)**
تُعيد الدالة Aspose.Slides.Charts.IChartSeries.getOverlap() مقدار تداخل الأشرطة والأعمدة في المخططات ثنائية الأبعاد (في نطاق من -100 إلى 100). هذه الدالة ليست مخصصة لسلسلة معينة فقط بل لجميع السلاسل في مجموعة السلاسل الأب — وهي تمثيل للخاصية المناسبة للمجموعة.

- استخدم الدالة IChartSeries.getParentSeriesGroup() للوصول إلى مجموعة السلاسل الأب.
- استخدم الدالتين IChartSeriesGroup.getOverlap() و setOverlap(byte) لإدارة القيمة.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **تمت إضافة قيمة العددي ShapeThumbnailBounds.Appearance**
تُتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين إنشاء صورة مصغرة للشكل ضمن حدود مظهره. تأخذ جميع تأثيرات الشكل في الاعتبار. تكون الصورة المصغرة الناتجة مقيدة بحدود الشريحة.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **تمت إضافة الفئة VbaProject والواجهة IVbaProject، وتم تعديل الدالتين Presentation.getVbaProject() و setVbaProject(VbaProject)**
تتيح ميزة جديدة للمطورين إنشاء وتحرير مشاريع VBA داخل عرض تقديمي.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// إنشاء مشروع VBA جديد

pres.setVbaProject(new VbaProject());

// إضافة وحدة فارغة إلى مشروع VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// تعيين شفرة المصدر للوحدة

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// إنشاء إشارة إلى <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// إنشاء إشارة إلى Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// إضافة إشارات إلى مشروع VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```