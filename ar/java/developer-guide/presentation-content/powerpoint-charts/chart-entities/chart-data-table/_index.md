---
title: جدول بيانات الرسم البياني
type: docs
url: /java/chart-data-table/
---

## **تعيين خصائص الخط لجدول بيانات الرسم البياني**
يوفر Aspose.Slides لـ Java دعمًا لتغيير لون الفئات في لون السلسلة.

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف الرسم البياني إلى الشريحة.
1. قم بتعيين جدول الرسم البياني.
1. قم بتعيين ارتفاع الخط.
1. احفظ العرض التقديمي المعدل.

 أدناه مثال على ذلك.

```java
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```