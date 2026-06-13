---
title: نمودار
type: docs
weight: 60
url: /fa/java/examples/elements/chart/
keywords:
- مثال کد
- نمودار
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "نمودارها را با Aspose.Slides for Java به‌صورت پیشرفته مدیریت کنید: ایجاد، قالب‌بندی، بایند داده‌ها و صادرات نمودارها در فرمت‌های PPT، PPTX و ODP با مثال‌های جاوا."
---
مثال‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودارها با **Aspose.Slides for Java**. قطعات کد زیر عملیات پایه‌ای نمودارها را نشان می‌دهند.

## **افزودن نمودار**

این متد یک نمودار ناحیه ساده را به اولین اسلاید اضافه می‌کند.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک نمودار ناحیه ساده به اسلاید اول اضافه می‌شود.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به نمودار**

پس از ایجاد یک نمودار، می‌توانید آن را از طریق مجموعهٔ اشکال بازیابی کنید.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // دسترسی به اولین نمودار روی اسلاید.
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

## **حذف نمودار**

کد زیر یک نمودار را از یک اسلاید حذف می‌کند.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // حذف نمودار.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی داده‌های نمودار**

می‌توانید ویژگی‌های نمودار مانند عنوان را تغییر دهید.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // عنوان نمودار را تغییر دهید.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```