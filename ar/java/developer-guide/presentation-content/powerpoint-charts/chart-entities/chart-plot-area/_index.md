---
title: تخصيص مناطق رسم المخططات في العروض التقديمية بلغة Java
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
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على العرض والارتفاع لمنطقة رسم المخطط**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط مع البيانات الافتراضية.
4. استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) قبل الحصول على القيم الفعلية.
5. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
6. الحصول على أعلى العنصر الفعلي للمخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
7. الحصول على العرض الفعلي لعنصر المخطط.
8. الحصول على الارتفاع الفعلي لعنصر المخطط.
```java
// إنشاء كائن من فئة Presentation
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
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط منطقة رسم المخطط. تم إضافة الطريقتين **setLayoutTargetType** و **getLayoutTargetType** إلى الفئة **ChartPlotArea** والواجهة **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان سيتم تخطيط المنطقة من داخلها (بدون المحاور وعناوين المحاور) أو من خارجها (مع المحاور وعناوين المحاور). هناك قيمتان محتملتان تم تعريفهما في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم يحدد حجم منطقة الرسم، دون تضمين علامات التجزئة وعناوين المحاور.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم يحدد حجم منطقة الرسم، وعلامات التجزئة، وعناوين المحاور.

الكود النموذجي موضح أدناه.
```java
// إنشاء كائن من فئة Presentation
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


## **الأسئلة الشائعة**

**ما هي الوحدات التي تُرجع بها القيم الفعلية X و Y والعرض والارتفاع؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل منطقة المخطط العناصر المحيطة (العنوان، وسيلة الإيضاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X و Y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التحديد الآلي للموقع وتُستخدم الكسور التي تحددها.

**لماذا تغير موقع منطقة الرسم بعد إضافة/نقل وسيلة الإيضاح؟**

تقع وسيلة الإيضاح في منطقة المخطط خارج منطقة الرسم ولكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد تتغير منطقة الرسم عندما يكون التحديد الآلي للموقع مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)