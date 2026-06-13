---
title: نمودار
type: docs
weight: 60
url: /fa/androidjava/examples/elements/chart/
keywords:
- نمونه کد
- نمودار
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "نمودارها را با Aspose.Slides برای Android به‌طور کامل مدیریت کنید: ایجاد، قالب‌بندی، بایند کردن داده‌ها و استخراج نمودارها در فرمت‌های PPT، PPTX و ODP با مثال‌های Java."
---
نمونه‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودارها با **Aspose.Slides for Android via Java**. قطعات کد زیر عملیات پایه‌ای بر روی نمودارها را نشان می‌دهند.

## **افزودن یک نمودار**

این روش یک نمودار ناحیه‌ای ساده را به اسلاید اول اضافه می‌کند.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک نمودار ناحیه‌ای ساده به اسلاید اول اضافه کنید.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به یک نمودار**

پس از ایجاد یک نمودار، می‌توانید آن را از طریق مجموعه شکل‌ها بازیابی کنید.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // دسترسی به اولین نمودار در اسلاید.
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

## **حذف یک نمودار**

کد زیر یک نمودار را از یک اسلاید حذف می‌کند.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // نمودار را حذف کنید.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی داده‌های نمودار**

می‌توانید خصوصیات نمودار را مانند عنوان تغییر دهید.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // تغییر عنوان نمودار.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```