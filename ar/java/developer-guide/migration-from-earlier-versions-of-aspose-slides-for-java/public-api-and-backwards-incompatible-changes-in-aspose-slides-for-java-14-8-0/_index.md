---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 14.8.0
type: docs
weight: 70
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [الإضافات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأي [تغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **إضافة طرق Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), و setOverlap(byte)**
تحصل Aspose.Slides.Charts.IChartSeries.getOverlap() على مدى تداخل الأشرطة والأعمدة في المخططات ثنائية الأبعاد (في نطاق من -100 إلى 100).
هذه الطريقة ليست فقط للسلاسل المحددة ولكن لجميع سلاسل مجموعة السلاسل الأم - هذا هو عرض لخاصية المجموعة المناسبة.

- استخدم طريقة IChartSeries.getParentSeriesGroup() للوصول إلى مجموعة السلاسل الأم.
- استخدم IChartSeriesGroup.getOverlap() و setOverlap(byte) لإدارة القيمة.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **إضافة قيمة ShapeThumbnailBounds.Appearance Enum**
تسمح هذه الطريقة لإنشاء مصغرات الأشكال للمطورين بإنشاء مصغرات الأشكال ضمن حدود مظهرها. تأخذ في الاعتبار جميع تأثيرات الشكل. تقتصر المصغرة المولدة على حدود الشريحة.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **إضافة فئة VbaProject وواجهة IVbaProject، وتغيير طرق Presentation.getVbaProject() و setVbaProject(VbaProject)**
تتيح ميزة جديدة للمطورين إنشاء وتحرير مشاريع VBA في عرض تقديمي.

``` java

 Presentation pres = new Presentation();

// إنشاء مشروع VBA جديد

pres.setVbaProject(new VbaProject());

// إضافة وحدة فارغة إلى مشروع VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// تعيين كود مصدر الوحدة

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// إنشاء مرجع إلى <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// إنشاء مرجع إلى Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// إضافة المراجع إلى مشروع VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```