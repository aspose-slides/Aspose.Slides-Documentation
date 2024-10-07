---
title: جدول بيانات الرسم البياني
type: docs
url: /php-java/chart-data-table/
---

## **ضبط خصائص الخط لجدول بيانات الرسم البياني**
تقدم Aspose.Slides لـ PHP عبر Java دعمًا لتغيير لون الفئات في لون السلسلة.

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف الرسم البياني إلى الشريحة.
1. قم بضبط جدول الرسم البياني.
1. ضبط ارتفاع الخط.
1. احفظ العرض التقديمي المعدل.

 يوجد أدناه مثال توضيحي.

```php
  # إنشاء عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```