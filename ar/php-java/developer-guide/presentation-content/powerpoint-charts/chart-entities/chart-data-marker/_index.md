---
title: علامة بيانات الرسم البياني
type: docs
url: /ar/php-java/chart-data-marker/
---

## **تعيين خيارات علامة الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلاسل معينة. من أجل تعيين خيارات علامة الرسم البياني، يرجى اتباع الخطوات أدناه:

- قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة رسم بياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بتعيين خيارات علامة الرسم البياني على مستوى نقاط البيانات.

```php
  # إنشاء عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء الرسم البياني الافتراضي
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # الحصول على فهرس ورقة العمل الافتراضية لبيانات الرسم البياني
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة العمل لبيانات الرسم البياني
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف السلاسل التجريبية
    $chart->getChartData()->getSeries()->clear();
    # إضافة سلسلة جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # تحميل الصورة 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # تحميل الصورة 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # أخذ أول سلسلة رسم بياني
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # إضافة نقطة جديدة (1:3) هناك.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # تغيير علامة سلسلة الرسم البياني
    $series->getMarker()->setSize(15);
    # حفظ العرض التقديمي مع الرسم البياني
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```