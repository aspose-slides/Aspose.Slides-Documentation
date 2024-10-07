---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 14.8.0
type: docs
weight: 70
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

تحتوي هذه الصفحة على قائمة بجميع [المضاف](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) الفئات والطرق والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) المقدمة مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 14.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة Aspose.Slides.Charts.IChartSeries.getOverlap()، IChartSeriesGroup.getOverlap()، و setOverlap(byte) طرق**
تقوم Aspose.Slides.Charts.IChartSeries.getOverlap() بالحصول على مقدار تداخل الأشرطة والأعمدة في الرسوم البيانية ثنائية الأبعاد (في نطاق من -100 إلى 100).
هذه الطريقة ليست فقط لسلاسل محددة ولكن لجميع سلاسل مجموعة السلاسل الأب - هذه هي إسقاط خاصية المجموعة المناسبة.

- استخدم IChartSeries.getParentSeriesGroup() للوصول إلى مجموعة السلاسل الأب.
- استخدم IChartSeriesGroup.getOverlap() و setOverlap(byte) لإدارة القيمة.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **تمت إضافة ShapeThumbnailBounds.Appearance قيمة Enum**
تسمح هذه الطريقة لإنشاء مصغرات للأشكال للمطورين بإنشاء مصغرات الشكل في حدود مظهرها. تأخذ في الاعتبار جميع تأثيرات الشكل. تكون مصغرات الشكل التي تم إنشاؤها مقيدة بحدود الشريحة.

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);

```
### **تمت إضافة VbaProject Class و IVbaProject Interface، وتم تغيير Presentation.getVbaProject() و setVbaProject(VbaProject) طرق**
تتيح ميزة جديدة للمطورين إنشاء وتحرير مشاريع VBA في عرض تقديمي.

```php
  $pres = new Presentation();
  # إنشاء مشروع VBA جديد
  $pres->setVbaProject(new VbaProject());
  # إضافة وحدة فارغة إلى مشروع VBA
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
  # تعيين كود مصدر الوحدة
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # إنشاء مرجع إلى <stdole>
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # إنشاء مرجع إلى Office
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  # إضافة المراجع إلى مشروع VBA
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);

```