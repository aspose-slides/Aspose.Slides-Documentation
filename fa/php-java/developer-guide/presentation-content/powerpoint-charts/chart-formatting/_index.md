---
title: قالب‌بندی نمودارهای ارائه در PHP
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/php-java/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "قالب‌بندی نمودارها را در Aspose.Slides برای PHP از طریق Java بیاموزید و ارائه PowerPoint خود را با سبک حرفه‌ای و جذاب ارتقا دهید."
---
## **نمای کلی**

این مقاله نحوه قالب‌بندی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides را شرح می‌دهد. نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، لگندها، ناحیه‌نقشه و پرکردن دیوارها را سفارشی کنید تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه ویژگی‌های قلم برای متن نمودار تنظیم شود، قالب‌های عددی پیش‌تنظیم و سفارشی برای داده‌های نمودار اعمال گردد و لبه‌های گرد برای ناحیه نمودار فعال شود. این مثال‌ها به شما امکان کنترل هم سبک بصری و هم ارائه داده‌های نمودار در یک ارائه را می‌دهند.

## **قالب‌بندی موجودیت‌های نمودار**
Aspose.Slides for PHP via Java به توسعه‌دهندگان اجازه می‌دهد نمودارهای سفارشی را از ابتدا به اسلایدهای خود اضافه کنند. این مقاله نحوه قالب‌بندی موجودیت‌های مختلف نمودار از جمله محور دسته‌بندی و محور مقدار را توضیح می‌دهد.

Aspose.Slides for PHP via Java یک API ساده برای مدیریت موجودیت‌های مختلف نمودار و قالب‌بندی آن‌ها با مقادیر سفارشی ارائه می‌دهد:

1. یک نمونه از کلاس [**Presentation**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از ChartType::LineWithMarkers استفاده می‌کنیم).
1. به محور مقدار نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **Line format** برای خطوط شبکه اصلی محور مقدار
   1. تنظیم **Line format** برای خطوط شبکه فرعی محور مقدار
   1. تنظیم **Number Format** برای محور مقدار
   1. تنظیم **Min, Max, Major and Minor units** برای محور مقدار
   1. تنظیم **Text Properties** برای داده‌های محور مقدار
   1. تنظیم **Title** برای محور مقدار
   1. تنظیم **Line Format** برای محور مقدار
1. به محور دسته‌بندی نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **Line format** برای خطوط شبکه اصلی محور دسته‌بندی
   1. تنظیم **Line format** برای خطوط شبکه فرعی محور دسته‌بندی
   1. تنظیم **Text Properties** برای داده‌های محور دسته‌بندی
   1. تنظیم **Title** برای محور دسته‌بندی
   1. تنظیم **Label Positioning** برای محور دسته‌بندی
   1. تنظیم **Rotation Angle** برای برچسب‌های محور دسته‌بندی
1. به لگند نمودار دسترسی پیدا کنید و **Text Properties** آن را تنظیم کنید
1. نمایش لگندهای نمودار بدون پوشش بر روی نمودار را فعال کنید
1. به **Secondary Value Axis** نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. فعال‌سازی **Value Axis** ثانویه
   1. تنظیم **Line Format** برای محور مقدار ثانویه
   1. تنظیم **Number Format** برای محور مقدار ثانویه
   1. تنظیم **Min, Max, Major and Minor units** برای محور مقدار ثانویه
1. حال سری اول نمودار را روی محور مقدار ثانویه رسم کنید
1. رنگ پرکردن دیوار پشت نمودار را تنظیم کنید
1. رنگ پرکردن ناحیه نمودار را تنظیم کنید
1. ارائه اصلاح‌شده را در یک فایل PPTX ذخیره کنید

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # دسترسی به اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن نمودار نمونه
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # تنظیم عنوان نمودار
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تنظیم قالب خطوط شبکه اصلی برای محور مقدار
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # تنظیم قالب خطوط شبکه فرعی برای محور مقدار
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تنظیم قالب عددی محور مقدار
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # تنظیم حداکثر و حداقل مقادیر نمودار
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # تنظیم ویژگی‌های متن محور مقدار
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # تنظیم عنوان محور مقدار
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تنظیم قالب خطوط شبکه اصلی برای محور دسته‌بندی
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # تنظیم قالب خطوط شبکه فرعی برای محور دسته‌بندی
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تنظیم ویژگی‌های متن محور دسته‌بندی
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # تنظیم عنوان دسته‌بندی
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تنظیم موقعیت برچسب محور دسته‌بندی
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # تنظیم زاویه چرخش برچسب محور دسته‌بندی
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # تنظیم ویژگی‌های متن لگندها
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # تنظیم نمایش لگندهای نمودار بدون همپوشانی با نمودار
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # تنظیم محور مقدار ثانویه
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # تنظیم قالب عددی محور مقدار ثانویه
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # تنظیم حدمکسیمم و حداقل مقادیر نمودار
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # تنظیم رنگ دیوار پشت نمودار
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # تنظیم رنگ ناحیه نقشه
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # ذخیره ارائه
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**
Aspose.Slides for PHP via Java پشتیبانی از تنظیم ویژگی‌های مرتبط با قلم برای نمودار را فراهم می‌کند. لطفاً برای تنظیم ویژگی‌های قلم برای نمودار مراحل زیر را دنبال کنید.

- شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را نمونه‌سازی کنید.
- نمودار را به اسلاید اضافه کنید.
- ارتفاع قلم را تنظیم کنید.
- ارائه اصلاح‌شده را ذخیره کنید.

نمونه مثال زیر ارائه شده است.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم قالب عددی**
Aspose.Slides for PHP via Java یک API ساده برای مدیریت قالب داده‌های نمودار ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از **ChartType::ClusteredColumn** استفاده می‌شود).
1. قالب عددی پیش‌تنظیم‌شده را از مقادیر پیش‌تنظیم موجود انتخاب کنید.
1. در هر سری نمودار به سلول داده‌های نمودار مراجعه کنید و قالب عددی آن‌ را تنظیم کنید.
1. ارائه را ذخیره کنید.
1. قالب عددی سفارشی را تنظیم کنید.
1. در هر سری نمودار به سلول داده‌ها مراجعه کنید و قالب عددی متفاوتی را برای آن تنظیم کنید.
1. ارائه را ذخیره کنید.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # دسترسی به اولین اسلاید ارائه
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن نمودار ستونی خوشه‌ای پیش‌فرض
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # دسترسی به مجموعه سری‌های نمودار
    $series = $chart->getChartData()->getSeries();
    # پیمایش در تمام سری‌های نمودار
    foreach($series as $ser) {
      # پیمایش در تمام سلول‌های داده‌ای در سری
      foreach($ser->getDataPoints() as $cell) {
        # تنظیم قالب عددی
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%
      }
    }
    # ذخیره ارائه
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

مقادیر پیش‌تنظیم قالب عددی به همراه شاخص پیش‌تنظیم آنها که می‌توان استفاده کرد در زیر آمده است:

|**0**|عمومی|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تنظیم مرزهای گرد ناحیه نمودار**
Aspose.Slides for PHP via Java پشتیبانی از تنظیم ناحیه نمودار را فراهم می‌کند. متدهای [**hasRoundedCorners**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/hasroundedcorners/) و [**setRoundedCorners**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setroundedcorners/) به کلاس [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Chart) اضافه شده‌اند.

1. شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) را نمونه‌سازی کنید.
1. نمودار را به اسلاید اضافه کنید.
1. نوع پرکردن و رنگ پرکردن نمودار را تنظیم کنید.
1. خصوصیت لبه‌های گرد را بر روی True تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

نمونه مثال زیر ارائه شده است.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**آیا می‌توانم پرکردن نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه مات باقی بماند؟**

بله. شفافیت پرکردن و خطوط حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در تجسم‌های پرتراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده‌ای که هم‌پوشانی دارند برخورد کنم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، موقعیت/جای‌گذاری برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط منتخب برچسب نمایش دهید، یا قالب را به «مقدار + لگند» تغییر دهید.

**آیا می‌توانم پرکردن گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. معمولاً پرکردن‌های ثابت و گرادیان/الگو در دسترس هستند. در عمل، استفاده از گرادیان‌ها را به‌کار ببرید و ترکیب‌هایی که کنتراست را با شبکه و متن کاهش می‌دهند، خودداری کنید.