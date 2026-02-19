---
title: مخطط
type: docs
weight: 60
url: /ar/androidjava/examples/elements/chart/
keywords:
- مثال على الكود
- مخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحكم في المخططات باستخدام Aspose.Slides for Android: إنشاء، تنسيق، ربط البيانات، وتصدير المخططات بصيغ PPT و PPTX و ODP مع أمثلة Java."
---
أمثلة على إضافة، والوصول، وإزالة، وتحديث أنواع المخططات المختلفة باستخدام **Aspose.Slides for Android via Java**. توضح المقاطع البرمجية أدناه عمليات المخطط الأساسية.

## **إضافة مخطط**
تضيف هذه الطريقة مخطط منطقة بسيط إلى الشريحة الأولى.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إضافة مخطط منطقة بسيط إلى الشريحة الأولى.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى مخطط**
بعد إنشاء مخطط، يمكنك استرجاعه من خلال مجموعة الأشكال.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // الوصول إلى المخطط الأول في الشريحة.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة مخطط**
الكود التالي يزيل مخططًا من شريحة.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // إزالة المخطط.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديث بيانات المخطط**
يمكنك تغيير خصائص المخطط مثل العنوان.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // تغيير عنوان المخطط.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```