---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في .NET
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط Treemap
- مخطط Sunburst
- مخطط هرمي
- نقطة بيانات
- تسمية البيانات
- لون الفرع
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

توضح مخططات Treemap و Sunburst نفس نوع البيانات الهرمية، لكنهما تستخدمان تخطيطات مختلفة. يرسم Treemap التسلسل الهرمي كمستطيلات متداخلة تمثل مساحتها قيم الأوراق. يرسم Sunburst ذلك كحلقة متحدة المركز: المجموعات الأعلى مستوى تكون قرب المركز، وفئات الأوراق تكون على الحلقة الخارجية.

في Aspose.Slides for .NET، كل قيمة عددية هي [IChartDataPoint](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/). توفر مجموعة [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) وصولاً إلى الورقة ومجموعاتها الأصلية. يشرح هذا المقال هذا الربط ويظهر كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس بيانات العينة.

![مخطط Treemap مع فروع المستهلك والأعمال](treemap-hierarchy.png)

![مخطط Sunburst مع نفس تسلسل المستهلك والأعمال](sunburst-hierarchy.png)

## **فهم الفئات ونقاط البيانات والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئات وسلسلة رقمية واحدة:

| الفرع | الجذع | الورقة | الإيرادات |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

كل صف يخلق فئة ورقية واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الورقة إلى المجموعات الأصلية لها. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

تبدأ الفهارس في [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) من الورقة نحو الأعلى:

| فهرس `DataPointLevels` | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | ورقة | مستطيل القيمة | قطاع الحلقة الخارجية |
| `1` | جذع | مستطيل أو رأس الأصل | قطاع الحلقة المتوسطة |
| `2` | فرع | مستطيل أو رأس أعلى المستوى | قطاع الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخططين رغم اختلاف تخطيطهما البصري. يتم مشاركة قطاع الأصل بين عدة أوراق. لتنسيقه، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ جذع `Software` بنقطة `Licenses`. الحفاظ على مراجع لتلك النقاط يكون أوضح وأكثر أمانًا من استخدام تعبيرات غير مفسرة مثل `dataPoints[0]` أو `dataPoints[6]`.

## **إنشاء وتخصيص كلا نوعي المخططات**

المثال الكامل التالي ينشئ مخطط Treemap في الشريحة الأولى ومخطط Sunburst في الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يطبق ألوانًا ثابتة على المستويات المختارة، ينسق تسمية فرع، ويحفظ العرض التقديمي.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // أضف فئات الأوراق. يتم تعيين عنصر تجميع فقط عندما يبدأ مجموعة جديدة;
    // الفئات التالية تظل في تلك المجموعة حتى يتم تعيين عنصر آخر.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // اعرض الفئة والقيمة على ورقة Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // قم بتنسيق فرع Consumer من خلال أول ورقة في ذلك الفرع.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // قم بتنسيق جذع Software من خلال أول ورقة في ذلك الجذع.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout يؤثر على تسميات أصل Treemap؛ Sunburst يستخدم قطاعات الحلقة.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

تستخدم خلايا الفئة وخلايا القيم نفس صف ورقة العمل، لذا تظل مواضع مجموعاتها متراصة. عند العمل مع مخطط موجود بدلاً من إنشائه، افحص صفوف الفئات أولاً وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **الاختلافات بين Treemap و Sunburst**

- يستخدم Treemap المساحة لتوضيح القيمة والمستطيلات المتداخلة لتوضيح الهرمية. تتحكم خاصية [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/parentlabellayout/) في كيفية ظهور تسميات الأصل في هذا النوع من المخططات.
- يستخدم Sunburst الزاوية لتوضيح القيمة وعمق الحلقة لتوضيح الهرمية. لا تتحكم [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/parentlabellayout/) في تسميات حلقاته.
- يستخدم كلا النوعين نفس مستويات تجميع الفئات ونفس ترتيب الورقة إلى الأصل في `DataPointLevels`، لذا يمكن مشاركة شفرة بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأصل من أوراقه التابعة. لا تقم بإضافة نقاط عددية منفصلة للفروع أو الجذوع.

### **الفرز وترتيب القطاعات**

يحدد محرك تخطيط المخطط الموضع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئات المرتبطة معًا قبل إضافتها، لكن لا تعتمد على موضع مستطيل محدد أو زاوية بداية معينة. إذا كان التسلسل يحمل معنى، فضمنه في التسميات أو استخدم نوع مخطط يحتوي على محور فئة صريح.

### **السمة والألوان الثابتة**

تورث مستويات المخطط غير المنسقة ألوانها من سمة العرض التقديمي. يستخدم المثال تعبئات RGB صريحة للحصول على مخرجات متوقعة. إذا كان المخطط يجب أن يتبع تغييرات السمة، فاستخدم ألوان المخطط بدلاً من قيم RGB ثابتة وتجنب الكتابة فوق كل مستوى. تحقق أيضًا من تباين التسميات بعد تغيير تعبئة فرع أو جذع.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقتطع التسميات عندما يكون القطاع صغيرًا جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسميات عادةً ما ينتج نتيجة أوضح. يمكن للتسمية دمج اسم الفئة، اسم السلسلة، والقيمة عبر [IDataLabelFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/)، لكن تمكين كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والعرض**

حفظ الملف بصيغة PPTX يبقي المخطط قابلًا للتحرير. عندما يقوم Aspose.Slides بتصيير العرض التقديمي إلى PDF أو صورة، تُعرض التعبئات وإعدادات التسميات المدعومة مع المخطط. قد تغير استبدال الخطوط والفروقات الصغيرة في مساحة التخطيط المتاحة التفاف الأسطر أو ظهور التسميات، لذا ثبّت الخطوط المطلوبة وتحقق من أهداف التصدير المهمة.

## **الأسئلة الشائعة**

**لماذا يؤدي تغيير مستوى الأصل إلى تأثير عدة أوراق؟**

الفرع أو الجذع هو قطاع بصري مشترك. يمكن الوصول إلى [IChartDataPointLevel](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointlevel/) عبر ورقة تابعة، لكن التنسيق ينتمي إلى القطاع المشترك للأصل وليس إلى تلك الورقة فقط.

**لماذا تغيب تسمية البيانات؟**

أولاً فعل الحقول المطلوبة في كائن [IDataLabelFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/) الخاص بالتسمية. ثم تحقق مما إذا كان للقطاع مساحة كافية. يؤثر تخطيط تسمية الأصل في Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة على إمكانية عرض التسمية.

**هل يمكنني تحديد الترتيب أو إحداثيات القطاعات بدقة؟**

يمكنك التحكم في ترتيب صفوف المصدر والحفاظ على كل مجموعة متصلة، لكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط ذلك من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض التقديمي؟**

تُصمم التعبئات المعتمدة على السمة لتتبع لوحة ألوان العرض. استخدم ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو حافظ على ألوان المخطط عند تفضيل التكيف مع سمة جديدة.

**هل سيحفظ التنسيق المخصص في تصدير PDF والصور؟**

نعم، تُضمن تعبئات المخطط المدعومة وإعدادات التسميات أثناء العرض. للحصول على نتائج متسقة عبر الأنظمة، وفّر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسمية تعتمد على التخطيط.

## **انظر أيضًا**

- [إنشاء مخططات شجرة](/slides/ar/net/create-chart/#create-tree-map-charts)
- [إنشاء مخططات Sunburst](/slides/ar/net/create-chart/#create-sunburst-charts)
- [تصدير مخططات العرض التقديمي](/slides/ar/net/export-chart/)
- [إدارة سمات العرض التقديمي](/slides/ar/net/presentation-theme/)