---
title: مخطط الفقاع
type: docs
url: /ar/nodejs-java/bubble-chart/
---

## **تحجيم حجم مخطط الفقاعات**
توفر مكتبة Aspose.Slides for Node.js via Java دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides for Node.js via Java تم إضافة طرق [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--)،[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) و[**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) . أدناه مثال توضيحي.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تمثيل البيانات كأحجام مخطط الفقاعات**
تم إضافة الطرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) إلى الفئات [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries)،[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) والفئات ذات الصلة. **BubbleSizeRepresentation** يحدد كيف يتم تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) و[**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). بناءً على ذلك، تم إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. مثال الشيفرة موضح أدناه.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يتم دعم "مخطط الفقاع مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل يُسمى "Bubble with 3-D". يطبق نمطًا ثلاثيًا أبعاد على الفقاعات ولكنه لا يضيف محورًا إضافيًا؛ تبقى البيانات X-Y-S (الحجم). النوع متاح في تعداد [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

لا يوجد حد صريح على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لضمان قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**

التصدير إلى الصيغ المدعومة يحافظ على مظهر المخطط؛ يتم إجراء العرض بواسطة محرك Aspose.Slides. بالنسبة إلى الصيغ النقطية/النقطية المتجهة، تُطبق قواعد العرض العامة للرسومات (الدقة، إلغاء التعرج)، لذا يُنصح باختيار DPI كافٍ للطباعة.