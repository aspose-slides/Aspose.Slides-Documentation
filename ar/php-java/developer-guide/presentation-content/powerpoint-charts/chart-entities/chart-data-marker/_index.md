---
title: إدارة علامات بيانات المخطط في العروض التقديمية باستخدام PHP
linktitle: علامة البيانات
type: docs
url: /ar/php-java/chart-data-marker/
keywords:
- مخطط
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع التعبئة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية تخصيص علامات بيانات المخطط في Aspose.Slides لـ PHP، مما يعزز تأثير العروض التقديمية عبر صيغ PPT و PPTX مع أمثلة برمجية واضحة."
---

## **ضبط خيارات علامات المخطط**
يمكن ضبط العلامات على نقاط بيانات المخطط داخل السلاسل المحددة. لتحديد خيارات علامات المخطط، يرجى اتباع الخطوات أدناه:

- إنشاء فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- الحصول على أول سلسلة مخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بضبط خيارات علامات المخطط على مستوى نقاط البيانات.
```php
  # إنشاء عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء المخطط الافتراضي
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # الحصول على فهرس ورقة العمل لبيانات المخطط الافتراضي
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف سلسلة العرض التجريبية
    $chart->getChartData()->getSeries()->clear();
    # إضافة سلسلة جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # تحميل الصورة 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # تحميل الصورة 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # أخذ سلسلة المخطط الأولى
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Add new point (1:3) there.
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
    # تغيير علامة سلسلة المخطط
    $series->getMarker()->setSize(15);
    # حفظ العرض التقديمي مع المخطط
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**ما هي أشكال العلامات المتاحة جاهزة؟**

الأشكال القياسية متاحة (دائرة، مربع، ماسي، مثلث، إلخ)؛ تُحدد القائمة بواسطة فئة [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/) . إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة مع تعبئة صورة لمحاكاة الرسوم المخصصة.

**هل تُحافظ العلامات عند تصدير مخطط إلى صورة أو SVG؟**

نعم. عند تصيير المخططات إلى [raster formats](/slides/ar/php-java/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم، التعبئة، والحد الخارجي.