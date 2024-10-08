---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ Java 14.8.0
type: docs
weight: 70
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضافات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) من الأصناف والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **إضافة Aspose.Slides.Charts.IChartSeries.getOverlap() و IChartSeriesGroup.getOverlap() و setOverlap(byte)**
تقوم Aspose.Slides.Charts.IChartSeries.getOverlap() بالحصول على مقدار تداخل الأشرطة والأعمدة في الرسوم البيانية ثنائية الأبعاد (في نطاق من -100 إلى 100).
هذه الطريقة ليست مخصصة لسلسلة معينة ولكن لجميع سلسلة مجموعة السلاسل الأصلية - هذه هي إسقاط خاصية المجموعة المناسبة.

- استخدم طريقة IChartSeries.getParentSeriesGroup() للوصول إلى مجموعة السلاسل الأصلية.
- استخدم طرق IChartSeriesGroup.getOverlap() و setOverlap(byte) لإدارة القيمة.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **إضافة قيمة Enum لـ ShapeThumbnailBounds.Appearance**
تسمح هذه الطريقة من إنشاء مصغرات الأشكال للمطورين بإنشاء مصغرات لشكل ضمن حدود مظهره. إنها تأخذ بعين الاعتبار جميع تأثيرات الشكل. المصغرة الناتجة مقيدة بحدود الشريحة.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **إضافة فئة VbaProject وواجهة IVbaProject، وتغيير Presentation.getVbaProject() و setVbaProject(VbaProject)**
تتيح ميزة جديدة للمطورين إنشاء وتحرير مشاريع VBA في عرض تقديمي.

``` java

 Presentation pres = new Presentation();

// إنشاء مشروع VBA جديد

pres.setVbaProject(new VbaProject());

// إضافة وحدة فارغة إلى مشروع VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// تعيين مصدر شفرة الوحدة

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// إنشاء مرجع إلى <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// إنشاء مرجع إلى Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// إضافة مراجع إلى مشروع VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```