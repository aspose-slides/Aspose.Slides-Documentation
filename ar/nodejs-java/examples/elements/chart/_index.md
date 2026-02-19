---
title: مخطط
type: docs
weight: 60
url: /ar/nodejs-java/examples/elements/chart/
keywords:
- مثال على الكود
- مخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلّم إنشاء وتنسيق وربط البيانات وتصدير المخططات باستخدام Aspose.Slides لـ Node.js عبر Java في صيغ PPT و PPTX و ODP مع أمثلة JavaScript."
---
أمثلة على إضافة، والوصول، وإزالة، وتحديث أنواع المخططات المختلفة باستخدام **Aspose.Slides for Node.js via Java**. توضح المقتطفات أدناه عمليات المخطط الأساسية.

## **إضافة مخطط**

هذه الطريقة تُضيف مخطط منطقة بسيط إلى الشريحة الأولى.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // أضف مخطط منطقة بسيط إلى الشريحة الأولى.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى مخطط**

بعد إنشاء مخطط، يمكنك استرجاعه عبر مجموعة الأشكال.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى المخطط الأول على الشريحة.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة مخطط**

الشفرة التالية تزيل المخطط من الشريحة.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // إزالة المخطط.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديث بيانات المخطط**

يمكنك تغيير خصائص المخطط مثل العنوان.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // تغيير عنوان المخطط.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```