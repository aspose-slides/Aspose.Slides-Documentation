---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام Java
linktitle: مخطط فقاعات
type: docs
url: /ar/java/bubble-chart/
keywords:
- مخطط فقاعات
- حجم الفقعة
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتخصيص مخططات فقاعات قوية في PowerPoint باستخدام Aspose.Slides for Java لتعزيز تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides for Java دعمًا لتحجيم حجم مخطط الفقاعات. تمت إضافة طرق [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--),[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و[**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) في Aspose.Slides for Java. يتم إعطاء مثال عينة أدناه.
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
تمت إضافة طرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) إلى واجهات [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries)،[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) والفئات المرتبطة. **BubbleSizeRepresentation** تحدد كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) و[**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width). وفقًا لذلك، تمت إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. يُعطى كود العينة أدناه.
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


## **FAQ**

**هل يتم دعم "مخطط الفقاعات مع تأثير ثلاثي الأبعاد" وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل يُسمى "Bubble with 3-D". يطبق تنسيقًا ثلاثي الأبعاد على الفقاعات لكنه لا يضيف محورًا إضافيًا؛ تبقى البيانات على شكل X‑Y‑S (الحجم). النوع متاح في فئة [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) .

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

لا يوجد حد صارم على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لتحسين قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، الصور)؟**

يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم تنفيذ عملية الرسم بواسطة محرك Aspose.Slides. بالنسبة إلى الصيغ النقطية/المتجهة، تُطبق قواعد رسم الرسوم البيانية العامة (الدقة، مضاد التعرج)، لذا يُنصح باختيار DPI كافٍ للطباعة.