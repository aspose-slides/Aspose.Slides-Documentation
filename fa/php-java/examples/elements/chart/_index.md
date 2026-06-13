---
title: نمودار
type: docs
weight: 60
url: /fa/php-java/examples/elements/chart/
keywords:
- نمودار
- افزودن نمودار
- دسترسی به نمودار
- حذف نمودار
- به‌روزرسانی نمودار
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در PHP با Aspose.Slides: افزودن داده‌ها، قالب‌بندی سری‌ها، محورها و برچسب‌ها، تغییر انواع، و استخراج—قابل استفاده با PPT، PPTX و ODP."
---
نمونه‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودارها با **Aspose.Slides for PHP via Java**. قطعات کد زیر عملیات پایه‌ای نمودارها را نشان می‌دهند.

## **افزودن نمودار**

این متد یک نمودار ناحیه ساده را به اولین اسلاید اضافه می‌کند.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // یک نمودار ساده ستونی به اسلاید اضافه می‌کند.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به نمودار**

نمودار را از مجموعه اشکال بازیابی کنید.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین نمودار در اسلاید.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف نمودار**

کد زیر یک نمودار را از اسلاید حذف می‌کند.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید نمودار است.
        $chart = $slide->getShapes()->get_Item(0);

        // نمودار را حذف کنید.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **به‌روزرسانی داده‌های نمودار**

می‌توانید ویژگی‌های نمودار مانند عنوان را تغییر دهید.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید نمودار است.
        $chart = $slide->getShapes()->get_Item(0);

        // عنوان نمودار را تغییر دهید.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```