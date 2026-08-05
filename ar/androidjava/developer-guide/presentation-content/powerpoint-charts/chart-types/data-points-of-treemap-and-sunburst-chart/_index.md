---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst على Android
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط treemap
- مخطط sunburst
- مخطط هرمي
- نقطة بيانات
- تسمية بيانات
- لون الفرع
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرف على كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides لـ Android عبر Java."
---
## **نظرة عامة**

تُظهر مخططات Treemap و Sunburst نفس نوع البيانات الهرمية، لكنهما تستخدمان تخطيطات مختلفة. ترسم مخطّط Treemap الهرمية على شكل مستطيلات متداخلة تمثل مساحتها قيم الأوراق. أما مخطّط Sunburst فيظهرها كحلقيْن متتاليين: المجموعات ذات المستوى الأعلى تكون قرب المركز، وفئات الأوراق تكون على الحلقة الخارجية.

في Aspose.Slides for Android عبر Java، كل قيمة رقمية هي [IChartDataPoint](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/). طريقة [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) توفر الوصول إلى الورقة والمجموعات الأبوية لها. توضح هذه المقالة ذلك التعيين وتبين كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس البيانات النموذجية.

![مخطّط Treemap مع فروع Consumer و Business](treemap-hierarchy.png)

![مخطّط Sunburst مع نفس هرمية Consumer و Business](sunburst-hierarchy.png)

## **فهم الفئات، نقاط البيانات، والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئوية وسلسلة رقمية واحدة:

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

كل صف يُنشئ فئة ورقة واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الورقة إلى الأبوين. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

الفهارس التي تُعيدها طريقة [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) تبدأ من الورقة صعودًا:

| فهرس `getDataPointLevels()` | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | الورقة | مستطيل القيمة | قطاع الحلقة الخارجية |
| `1` | الجذع | مستطيل أو رأس الأب | قطاع الحلقة الوسطية |
| `2` | الفرع | مستطيل أو رأس المستوى الأعلى | قطاع الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخططات رغم اختلاف تخطيطاتهما البصرية. يُشارك مقطع أب متعدد الأوراق. لتنسيقه، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ جذع `Software` بنقطة `Licenses`. الاحتفاظ بمراجع لتلك النقاط أوضح وأكثر أمانًا من استخدام تعبيرات غير موضّحة مثل `dataPoints.get_Item(0)` أو `dataPoints.get_Item(6)`.

## **إنشاء وتخصيص كلا نوعي المخططات**

المثال الكامل التالي يُنشئ مخطّط Treemap في الشريحة الأولى ومخطّط Sunburst في الشريحة الثانية. يُبني الهرمية، يُظهر القيمة لـ `Tablets`، يُطبق ألوانًا ثابتة على المستويات المختارة، يُنسق تسمية فرع، ويحفظ العرض التقديمي.

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

        // إضافة فئات الأوراق. يتم تعيين عنصر تجميع فقط عندما يبدأ مجموعة جديدة;
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

        // عرض الفئة والقيمة على ورقة Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // تنسيق فرع Consumer عبر أول ورقة في ذلك الفرع.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // تنسيق جذع Software عبر أول ورقة في ذلك الجذع.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout يؤثر على تسميات الأبوين في مخطط Treemap؛ يستخدم Sunburst قطاعات الحلقة.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

خلايا الفئات وخلايا القيم تستخدم نفس صف ورقة العمل، لذا تظل مواضع مجموعاتها متراصفة. عند العمل مع مخطّط موجود بدلاً من إنشائه، افحص صفوف الفئات أولاً وخزن مراجع مسمّاة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **اختلافات Treemap و Sunburst**

- يستخدم Treemap المساحة لتوصيل القيمة والمستطيلات المتداخلة لتوصيل الهرمية. تُتحكم طريقة [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) في كيفية ظهور تسميات الأبوين في هذا النوع من المخططات.
- يستخدم Sunburst الزاوية لتوصيل القيمة وعمق الحلقة لتوصيل الهرمية. لا تُتحكم طريقة [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) في تسميات حلقاته.
- كلا النوعين يستخدمان نفس مستويات تجميع الفئات ونفس ترتيب الورقة إلى الأب الذي تُعيده طريقة [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)، لذا يمكن مشاركة كود بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأبوين من أوراقها التابعة. لا تُضيف نقاطًا رقمية منفصلة للفروع أو الجذوع.

### **الترتيب وتحديد مواقع القطاعات**

محرك تخطيط المخطط يحدد الموضع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئات ذات الصلة معًا قبل إضافتها، لكن لا تعتمد على موقع مستطيل محدد أو زاوية بدء معينة. إذا كان الترتيب يحمل معنى، أدرجه في التسميات أو استخدم نوع مخطط يحتوي على محور فئات صريح.

### **السمة والألوان الثابتة**

المستويات غير المُنسَّقة للمخطط ترث ألوانها من سمة العرض التقديمي. يستخدم المثال ملء RGB صريح للحصول على نتيجة قابلة للتنبؤ. إذا كان المخطط يجب أن يتبع تغيّر السمة، استخدم ألوان المخطط بدلاً من قيم RGB ثابتة وتجنّب تجاوز كل مستوى. كما تحقق من تباين التسميات بعد تغيير تعبئة فرع أو جذع.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقتطع التسميات عندما يكون القطاع صغيرًا جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسمية عادة ما ينتج نتيجة أوضح. يمكن للتسمية أن تجمع بين اسم الفئة، اسم السلسلة، والقيمة عبر [IDataLabelFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idatalabelformat/)، لكن تفعيل كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والرندرة**

حفظ الملف بصيغة PPTX يبقِي المخطّط قابلًا للتحرير. عندما تُرندر Aspose.Slides العرض التقديمي إلى PDF أو صورة، تُرسم الملء والتنسيقات المدعومة مع المخطّط. قد تُغيّر استبدال الخطوط واختلافات طفيفة في مساحة التخطيط المتاحة طريقة لف التف أو ظهور التسميات، لذا ركب الخطوط المطلوبة وتحقق من أهداف التصدير الهامة.

## **الأسئلة المتكررة**

**لماذا يؤدي تغيير مستوى أب إلى تأثير عدة أوراق؟**

الفرع أو الجذع هو قطاع بصري مشترك. يمكن الوصول إلى [IChartDataPointLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapointlevel/) الخاص به عبر ورقة تابعة، لكن التنسيق ينتمي إلى القطاع الأب المشترك وليس إلى تلك الورقة فقط.

**لماذا فإن التسمية البيانية مفقودة؟**

أولاً فعّل الحقول المطلوبة في كائن [IDataLabelFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idatalabelformat/) الخاص بالتسمية. ثم تحقق مما إذا كان للقطاع مساحة كافية. تؤثر إعدادات تخطيط تسميات أب Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة جميعًا على إمكانية عرض التسمية.

**هل يمكنني تحديد الترتيب الدقيق أو إحداثيات القطاعات؟**

يمكنك التحكم في ترتيب صفوف المصدر والحفاظ على كل مجموعة متجاورة، لكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه القيم من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغيّر الألوان بعد تغيير سمة العرض التقديمي؟**

الملء القائم على السمة مصمم ليتبع لوحة ألوان العرض. استخدم ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو احتفظ بألوان المخطط عند تفضيل التكيّف مع سمة جديدة.

**هل سيتم الحفاظ على التنسيقات المخصّصة في تصدير PDF والصور؟**

نعم، تُدرج ملء المخطط المدعوم وإعدادات التسميات أثناء الرندرة. للحصول على نتائج متسقة عبر الأنظمة، وفّر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسميات تعتمد على التخطيط.

## **انظر أيضًا**

- [Create Treemap charts](/slides/ar/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ar/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ar/androidjava/export-chart/)
- [Manage presentation themes](/slides/ar/androidjava/presentation-theme/)