---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في Java
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "تعرف على كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

تُظهر مخططات Treemap و Sunburst نفس نوع البيانات الهرمية، ولكنها تستخدم تخطيطات مختلفة. تُرسم مخططة Treemap الهرمية كمستطيلات متداخلة تمثل مساحتها قيم الأوراق. وتُظهر مخططة Sunburst الهرمية كحلقات متتالية: المجموعات ذات المستوى الأعلى تكون قرب المركز، وفئات الأوراق تكون على الحلقة الخارجية.

في Aspose.Slides for Java، كل قيمة رقمية هي [IChartDataPoint](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/). طريقة [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) توفر الوصول إلى الورقة ومجموعاتها الأبوية. توضح هذه المقالة هذا التعيين وتُظهر كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس بيانات العينة.

![مخطط Treemap مع فروع Consumer و Business](treemap-hierarchy.png)

![مخطط Sunburst مع نفس هيكل Consumer و Business](sunburst-hierarchy.png)

## **فهم الفئات ونقاط البيانات والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئة ومجموعة رقمية واحدة:

| الفرع | العمود | الورقة | الإيرادات |
| --- | --- | --- | ---: |
| المستهلك | الحواسيب | لابتوبات | 12 |
| المستهلك | الحواسيب | ديسكتوبات | 8 |
| المستهلك | الهواتف المحمولة | هواتف | 15 |
| المستهلك | الهواتف المحمولة | أجهزة لوحية | 6 |
| الأعمال | الخدمات | استشارات | 10 |
| الأعمال | الخدمات | دعم | 7 |
| الأعمال | البرمجيات | تراخيص | 11 |
| الأعمال | البرمجيات | اشتراكات | 14 |

كل صف ينشئ فئة ورقة واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الورقة إلى الأبوين. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

المؤشرات التي تُرجعها طريقة [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) تبدأ من الورقة صعوداً:

| `getDataPointLevels()` الفهرس | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | الورقة | مستطيل القيمة | جزء الحلقة الخارجية |
| `1` | الساق | مستطيل الأب أو العنوان | جزء الحلقة المتوسطة |
| `2` | الفرع | مستطيل المستوى الأعلى أو العنوان | جزء الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخططات رغم اختلاف تخطيطهما البصري. يتم مشاركة قطعة أب مع عدة أوراق. لتنسيقها، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ سُقّـة `Software` بنقطة `Licenses`. الحفاظ على مراجع لتلك النقاط أوضح وأكثر أماناً من استخدام تعبيرات غير مفسرة مثل `dataPoints.get_Item(0)` أو `dataPoints.get_Item(6)`.

## **إنشاء وتخصيص كلا نوعي المخططات**

المثال الكامل التالي ينشئ مخططة Treemap في الشريحة الأولى ومخططة Sunburst في الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يطبّق ألواناً ثابتة للمستويات المختارة، ينسق تسمية فرع، ويحفظ العرض التقديمي.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // إضافة فئات الأوراق. يتم تعيين عنصر تجميع فقط عند بدء مجموعة جديدة؛
        // الفئات التالية تبقى في تلك المجموعة حتى يتم تعيين عنصر آخر.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // إظهار الفئة والقيمة على ورقة Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // تنسيق فرع Consumer عبر أول ورقة في ذلك الفرع.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // تنسيق سُقّـة Software عبر أول ورقة في تلك السُقّـة.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout يؤثر على تسميات الأبوين في مخطط Treemap؛ يستخدم Sunburst شرائح الحلقة.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تستخدم خلايا الفئة وخلايا القيمة نفس صف ورقة العمل، لذا تبقى مواضع مجموعاتها مت aligned. عند العمل مع مخطط موجود بدلاً من إنشاء واحد، افحص صفوف الفئات أولاً وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **اختلافات Treemap و Sunburst**

- تستخدم مخططة Treemap المساحة للتعبير عن القيمة والمستطيلات المتداخلة للتعبير عن الهرمية. طريقة [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) تتحكم في كيفية ظهور تسميات الأبوين في هذا النوع من المخططات.
- تستخدم مخططة Sunburst الزاوية للتعبير عن القيمة وعمق الحلقة للتعبير عن الهرمية. طريقة [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) لا تتحكم في تسميات حلقاتها.
- كلا النوعين يستخدمان نفس مستويات تجميع الفئات ونفس ترتيب الورقة إلى الأب المُرجع من [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)، لذا يمكن مشاركة كود بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأبوين من أوراقها التابعة. لا تُضف نقاط عددية منفصلة للفروع أو السُقّـات.

### **الفرز وترتيب القطاعات**

محرك تخطيط المخطط يحدد الموضع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئات المرتبطة معاً قبل إضافتها، لكن لا تعتمد على موضع مستطيل محدد أو زاوية بداية معينة. إذا كان التسلسل يحمل معنى، أدرجه في التسميات أو استخدم نوع مخطط يحتوي على محور فئة صريح.

### **السمة والألوان الثابتة**

المستويات غير المنسقة للمخطط ترث ألوانها من سمة العرض التقديمي. يستخدم المثال تعبئة RGB صريحة للحصول على مخرجات قابلة للتوقع. إذا كان المخطط يجب أن يتبع تغييرات السمة، استخدم ألوان المخطط بدلًا من قيم RGB ثابتة وتجنّب تجاوز كل مستوى. تحقق أيضًا من تباين التسميات بعد تغيير تعبئة فرع أو سُقّـة.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقتطع التسميات عندما تكون القطعة صغيرة جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار حقول تسميات أقل عادةً ما ينتج نتيجة أكثر وضوحًا. يمكن لتسمية أن تجمع بين اسم الفئة، اسم السلسلة، والقيمة عبر [IDataLabelFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabelformat/)، لكن تفعيل كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والتصيير**

حفظ العرض كـ PPTX يبقي المخطط قابلاً للتحرير. عندما تقوم Aspose.Slides بتصيير العرض إلى PDF أو صورة، تُرسم التعبئات وإعدادات التسميات المدعومة مع المخطط. استبدال الخطوط واختلافات صغيرة في مساحة التخطيط المتاحة يمكن أن تغير تقليم السطر أو ظهور التسميات، لذا قم بتثبيت الخطوط المطلوبة وتحقق من أهداف التصدير الهامة.

## **الأسئلة الشائعة**

**لماذا يؤدي تغيير مستوى أب إلى تأثير عدة أوراق؟**

الفرع أو السُقّـة هو قطاع بصري مشترك. يمكن الوصول إلى [IChartDataPointLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapointlevel/) عبر ورقة تابعة، لكن التنسيق يخص القطاع الأب المشترك وليس الورقة فقط.

**لماذا تسمة البيانات مفقودة؟**

أولاً فعّل الحقول المطلوبة في كائن [IDataLabelFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabelformat/) الخاص بالتصنيف. ثم تحقق مما إذا كان للقطاع مساحة كافية. يؤثر تخطيط تسمية الأب في Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة جميعًا على إمكانية عرض التسمية.

**هل يمكنني تحديد الترتيب أو إحداثيات القطاعات بدقة؟**

يمكنك التحكم في ترتيب صفوف المصدر وإبقاء كل مجموعة متصلة، لكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه العناصر من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض؟**

التعبئات المعتمدة على السمة مصممة لتتبع لوحة ألوان العرض. ضع ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو احتفظ بألوان المخطط عند تفضيل التكيف مع سمة جديدة.

**هل سيُحفظ التنسيق المخصص في تصديرات PDF والصور؟**

نعم، تعبئات المخطط المدعومة وإعدادات التسميات تُدرج أثناء التصيير. للحصول على نتائج متسقة عبر الأنظمة، وفّر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسميات تعتمد على التخطيط.

## **أنظر أيضاً**

- [Create Treemap charts](/slides/ar/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ar/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ar/java/export-chart/)
- [Manage presentation themes](/slides/ar/java/presentation-theme/)