---
title: نمودار
type: docs
weight: 60
url: /fa/nodejs-java/examples/elements/chart/
keywords:
- مثال کد
- نمودار
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نمودارها را با Aspose.Slides برای Node.js از طریق Java به‌صورت حرفه‌ای مدیریت کنید: ایجاد، قالب‌بندی، اتصال داده‌ها و صادر کردن نمودارها در فرمت‌های PPT، PPTX و ODP با مثال‌های JavaScript."
---
نمونه‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودار با **Aspose.Slides for Node.js via Java**. قطعه‌کدهای زیر عملیات پایه‌ای نمودار را نشان می‌دهند.

## **افزودن یک نمودار**

این روش یک نمودار مساحت ساده را به اسلاید اول اضافه می‌کند.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // یک نمودار مساحت ساده به اسلاید اول اضافه کنید.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به یک نمودار**

پس از ایجاد یک نمودار، می‌توانید آن را از طریق مجموعهٔ اشکال بازیابی کنید.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به اولین نمودار در اسلاید.
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

## **حذف یک نمودار**

کد زیر نمودار را از اسلاید حذف می‌کند.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // نمودار را حذف کنید.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی داده‌های نمودار**

می‌توانید ویژگی‌های نمودار مانند عنوان را تغییر دهید.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // عنوان نمودار را تغییر دهید.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```