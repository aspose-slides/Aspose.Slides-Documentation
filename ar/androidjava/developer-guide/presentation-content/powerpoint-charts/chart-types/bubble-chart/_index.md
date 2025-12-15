---
title: تخصيص مخططات الفقاعات في العروض التقديمية على Android
linktitle: مخطط الفقاعات
type: docs
url: /ar/androidjava/bubble-chart/
keywords:
- مخطط الفقاعات
- حجم الفقاع
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص مخططات الفقاعات القوية في PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java لتعزيز تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides لنظام Android عبر Java دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides لنظام Android عبر Java تم إضافة الطرق [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و[**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) . تم توفير مثال توضيحي أدناه.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تمثيل البيانات كأحجام مخطط الفقاعات**
تمت إضافة الطرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) إلى واجهات [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) والفئات ذات الصلة. **BubbleSizeRepresentation** يحدد كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) و[**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). بناءً على ذلك، تم إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. تم توفير عينة كود أدناه.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يتم دعم "مخطط الفقاعات مع تأثير ثلاثي الأبعاد" وكيف يختلف عن المخطط العادي؟**
نعم. هناك نوع مخطط منفصل يُدعى "Bubble with 3-D". يضيف تنسيقًا ثلاثي الأبعاد إلى الفقاعات لكنه لا يضيف محورًا إضافيًا؛ تبقى البيانات X-Y-S (الحجم). النوع متاح في فئة [نوع المخطط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) .

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**
ليس هناك حد ثابت على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط ضمن مستوى معقول لضمان وضوح القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**
يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم تنفيذ العرض بواسطة محرك Aspose.Slides. بالنسبة للصيغ النقطية/المتجهية، تُطبق قواعد العرض العامة للرسوم البيانية (الدقة، مكافحة التسنين)، لذا يجب اختيار DPI كافٍ للطباعة.