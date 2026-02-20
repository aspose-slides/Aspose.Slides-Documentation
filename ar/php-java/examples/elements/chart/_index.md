---
title: مخطط
type: docs
weight: 60
url: /ar/php-java/examples/elements/chart/
keywords:
- مخطط
- إضافة مخطط
- الوصول إلى مخطط
- إزالة مخطط
- تحديث مخطط
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في PHP باستخدام Aspose.Slides: إضافة البيانات، تنسيق السلاسل والمحاور والتسميات، تغيير الأنواع، وتصديرها—تعمل مع PPT و PPTX و ODP."
---
أمثلة على الإضافة والوصول والإزالة وتحديث أنواع المخططات المختلفة باستخدام **Aspose.Slides for PHP via Java**. توضح المقاطع البرمجية أدناه عمليات المخطط الأساسية.

## **إضافة مخطط**

تضيف هذه الطريقة مخطط منطقة بسيط إلى الشريحة الأولى.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إضافة مخطط عمودي بسيط إلى الشريحة.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى مخطط**

استرجع المخطط من مجموعة الأشكال.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول مخطط على الشريحة.
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

## **إزالة مخطط**

الكود التالي يزيل مخططًا من شريحة.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول على الشريحة هو المخطط.
        $chart = $slide->getShapes()->get_Item(0);

        // إزالة المخطط.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تحديث بيانات المخطط**

يمكنك تغيير خصائص المخطط مثل العنوان.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول على الشريحة هو المخطط.
        $chart = $slide->getShapes()->get_Item(0);

        // تغيير عنوان المخطط.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```