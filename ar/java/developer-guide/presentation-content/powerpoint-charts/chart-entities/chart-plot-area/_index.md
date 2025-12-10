---
title: تخصيص مناطق رسم المخططات في العروض التقديمية باستخدام Java
linktitle: منطقة الرسم
type: docs
url: /ar/java/chart-plot-area/
keywords:
- مخطط
- منطقة الرسم
- عرض منطقة الرسم
- ارتفاع منطقة الرسم
- حجم منطقة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Java. حسّن مظهر شرائحك بسهولة."
---

## **الحصول على عرض وارتفاع منطقة رسم المخطط**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) قبل الحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي للمحور X (اليسار) لعنصر المخطط نسبة إلى الزاوية العليا اليسرى للمخطط.
1. الحصول على الموضع العلوي الفعلي لعنصر المخطط نسبة إلى الزاوية العليا اليسرى للمخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.
```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين وضع تخطيط منطقة رسم المخطط**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط منطقة رسم المخطط. تمت إضافة الطريقتين [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) إلى الفئة [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) والواجهة [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). إذا تم تعريف تخطيط منطقة الرسم يدوياً، تحدد هذه الخاصية ما إذا كان سيتم تخطيط المنطقة من داخلها (بدون المحاور وعناوين المحاور) أو من خارجها (مع المحاور وعناوين المحاور). هناك قيمتان محتملتان معرّفتان في تعداد [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - يحدد أن حجم منطقة الرسم يحدد الحجم دون علامات الفواصل وعناوين المحاور.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - يحدد أن حجم منطقة الرسم يحدد الحجم بما يشمل علامات الفواصل وعناوين المحاور.

العينة البرمجية موضحة أدناه.
```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**بأي وحدات يتم إرجاع القيم الفعلية x و y والعرض والارتفاع؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل منطقة المخطط العناصر المحيطة (العنوان، وسيلة الإيضاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم x و y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدوياً؟**

إنها كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم إلغاء التمركز التلقائي وتُستخدم الكسور التي تم ضبطها.

**لماذا تغير موضع منطقة الرسم بعد إضافة/تحريك وسيلة الإيضاح؟**

تقع وسيلة الإيضاح في منطقة المخطط خارج منطقة الرسم ولكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد يتحرك موقع منطقة الرسم عندما يكون التمركز التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)