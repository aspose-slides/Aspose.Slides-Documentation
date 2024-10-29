---
title: جدول بيانات المخطط
type: docs
url: /ar/androidjava/chart-data-table/
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
تقدم Aspose.Slides لـ Android عبر Java دعمًا لتغيير لون الفئات في لون السلسلة.

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. قم بتعيين جدول المخطط.
1. قم بتعيين ارتفاع الخط.
1. احفظ العرض المعدل.

 أدناه تم إعطاء مثال نموذجي.

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