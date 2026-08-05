---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام JavaScript
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط treemap
- مخطط sunburst
- مخطط هرمي
- نقطة بيانات
- تسمية البيانات
- لون الفرع
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides for Node.js عبر Java."
---
## **نظرة عامة**

Treemap و Sunburst يعرضان نفس نوع البيانات الهرمية، لكنهما يستخدمان تخطيطات مختلفة. تُظهر Treemap التسلسل الهرمي كمستطيلات متداخلة تمثل مساحتها قيم الفروع النهائية. تُظهر Sunburst ذلك كحلقات متقابلة: المجموعات ذات المستوى الأعلى تكون قرب المركز، والفئات النهائية على الحلقة الخارجية.

في Aspose.Slides for Node.js via Java، كل قيمة رقمية هي [ChartDataPoint](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/). توفر طريقة [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) إمكانية الوصول إلى الفئة النهائية ومجموعاتها الوالدية. يشرح هذا المقال هذا الربط ويظهر كيفية إنشاء وتنسيق كلا نوعي المخطط من نفس بيانات العينة.

![مخطط Treemap مع فروع Consumer و Business](treemap-hierarchy.png)

![مخطط Sunburst مع نفس تسلسل Consumer و Business](sunburst-hierarchy.png)

## **فهم الفئات، نقاط البيانات، والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئوية وسلسلة رقمية واحدة:

| الفرع | الجذر | الفئة الفرعية | الإيرادات |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

كل صف ينشئ فئة نهائية واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الفئة النهائية إلى الوالدين. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

المؤشرات التي تُعيدها طريقة [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) تبدأ من الفئة النهائية صعودًا:

| `getDataPointLevels()` index | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | الفئة النهائية | مستطيل القيمة | قطاع الحلقة الخارجية |
| `1` | الجذر | مستطيل الوالد أو العنوان | قطاع الحلقة المتوسطة |
| `2` | الفرع | مستطيل المستوى الأعلى أو العنوان | قطاع الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا النوعين على الرغم من اختلاف تخطيطاتهما البصرية. يُشارك قطاع الوالد بين عدة فروع نهائية. لتنسيقه، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ الجذر `Software` بنقطة `Licenses`. الاحتفاظ بالمراجع إلى تلك النقاط أوضح وأكثر أمانًا من استخدام تعبيرات غير مفسرة مثل `dataPoints.get_Item(0)` أو `dataPoints.get_Item(6)`.

## **إنشاء وتخصيص كلا نوعي المخطط**

المثال الكامل التالي ينشئ مخطط Treemap في الشريحة الأولى ومخطط Sunburst في الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يطبق ألوانًا ثابتة على مستويات مختارة، ينسق تسمية فرع، ويحفظ العرض التقديمي.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // أضف فئات الأوراق. يتم تعيين عنصر تجميع فقط عندما يبدأ مجموعة جديدة;
        // الفئات التالية تبقى في تلك المجموعة حتى يتم تعيين عنصر آخر.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // إظهار الفئة والقيمة على الفئة الفرعية Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // تنسيق فرع Consumer عبر أول ورقة في ذلك الفرع.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // تنسيق جذر Software عبر أول ورقة في ذلك الجذر.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // يؤثر ParentLabelLayout على تسميات الوالد في Treemap؛ يستخدم Sunburst قطاعات الحلقة.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تستخدم خلايا الفئات وخلايا القيم نفس صف ورقة العمل، لذا تظل مواضع مجموعاتها محاذاة. عند التعامل مع مخطط موجود بدلاً من إنشاء واحد، افحص صفوف الفئات أولاً وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **اختلافات Treemap و Sunburst**

- تستخدم Treemap المساحة للتواصل عن القيمة والمستطيلات المتداخلة للتواصل عن الهرمية. طريقة [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) تتحكم في كيفية ظهور تسميات الوالد في هذا النوع من المخططات.
- تستخدم Sunburst الزاوية للتواصل عن القيمة وعمق الحلقة للتواصل عن الهرمية. طريقة [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) لا تتحكم في تسميات حلقاتها.
- يستخدم كلا النوعين نفس مستويات تجميع الفئات ونفس ترتيب الفئة النهائية إلى الوالد الذي تُعيده طريقة [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels)، لذا يمكن مشاركة كود بناء البيانات وتنسيق المستويات.
- تُحسب قيم الوالد من فروعه الفرعية. لا تُضف نقاطًا رقمية منفصلة للفروع أو الجذور.

### **الترتيب وتتابع القطاعات**

محرك تخطيط المخطط يحدد الموضع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئات ذات الصلة معًا قبل إضافتها، لكن لا تعتمد على موضع مستطيل محدد أو زاوية بداية معينة. إذا كان التتابع يحمل معنى، أدمجه في التسميات أو استخدم نوع مخطط يحتوي على محور فئة صريح.

### **السمة والألوان الثابتة**

المستويات غير المنسقة للمخطط ترث ألوانها من سمة العرض التقديمي. يستخدم المثال تعبئة RGB صريحة للحصول على مخرجات متوقعة. إذا كان المخطط ينبغي أن يتبع تغيرات السمة، استخدم ألوان المخطط بدلًا من قيم RGB الثابتة وتجنب تجاوز كل مستوى. تحقق أيضًا من تباين التسميات بعد تغيير تعبئة فرع أو جذر.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقتطع التسميات عندما يكون القطاع صغيرًا جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسميات عادةً ما ينتج نتيجة أوضح. يمكن للتسمية دمج اسم الفئة، اسم السلسلة، والقيمة عبر [DataLabelFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/)، لكن تفعيل كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والرسم**

حفظ الملف بصيغة PPTX يبقي المخطط قابلًا للتعديل. عندما تقوم Aspose.Slides برسم العرض التقديمي إلى PDF أو صورة، تُرسم التعبئات وإعدادات التسميات المدعومة مع المخطط. استبدال الخطوط والاختلافات الصغيرة في مساحة التخطيط المتاحة قد يغيّر التفاف السطر أو رؤية التسميات، لذا ثبّت الخطوط المطلوبة وتحقق من أهداف التصدير المهمة.

## **الأسئلة الشائعة**

**لماذا يؤدي تغيير مستوى الوالد إلى تأثير عدة فروع نهائية؟**

الفرع أو الجذر هو قطاع بصري مشترك. يمكن الوصول إلى [ChartDataPointLevel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapointlevel/) عبر فرع تابع، لكن التنسيق يخص القطاع المشترك للوالد وليس فقط لتلك الفئة النهائية.

**لماذا نقصت تسمية البيانات؟**

أولاً فعّل الحقول المطلوبة على كائن [DataLabelFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/) للتسمية. ثم تحقق مما إذا كان للقطاع مساحة كافية. تخطيط تسمية الوالد في Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة كلها تؤثر على إمكانية عرض التسمية.

**هل يمكنني تحديد الترتيب أو إحداثيات القطاعات بدقة؟**

يمكنك التحكم بترتيب صفوف المصدر والحفاظ على كل مجموعة متتالية، ولكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه القيم بناءً على الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض التقديمي؟**

التعبئات المعتمدة على السمة مصممة لتتبع لوحة ألوان العرض. ضع ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو حافظ على ألوان المخطط عند التكيف مع سمة جديدة إذا كان ذلك مفضلاً.

**هل سيُحافظ التنسيق المخصص في صادري PDF والصورة؟**

نعم، تُدرج تعبئات المخطط المدعومة وإعدادات التسميات أثناء الرسم. للحصول على نتائج متسقة عبر الأنظمة، احرص على توفير الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسميات تعتمد على التخطيط.

## **انظر أيضًا**

- [إنشاء مخططات Treemap](/slides/ar/nodejs-java/create-chart/#creating-tree-map-charts)
- [إنشاء مخططات Sunburst](/slides/ar/nodejs-java/create-chart/#creating-sunburst-charts)
- [تصدير مخططات العرض التقديمي](/slides/ar/nodejs-java/export-chart/)
- [إدارة سمات العرض التقديمي](/slides/ar/nodejs-java/presentation-theme/)