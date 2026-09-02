---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في PHP
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/php-java/data-points-of-treemap-and-sunburst-chart/
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
- PHP
- Aspose.Slides
description: "تعرف على كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides للغة PHP عبر Java."
---
## **نظرة عامة**

تُظهر مخططات Treemap و Sunburst نفس نوع البيانات الهرمية، لكنها تستخدم تخطيطات مختلفة. يرسم مخطط Treemap الهرمية كمستطيلات متداخلة تمثل مساحتها قيم الفروع النهائية. يرسم مخطط Sunburstها كحلقات مت concentric: المجموعات العليا تكون قرب المركز، والفروع النهائية تكون على الحلقة الخارجية.

في Aspose.Slides for PHP عبر Java، كل قيمة عددية هي [ChartDataPoint](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/). توفر طريقة [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) الوصول إلى الفروع النهائية ومجموعاتها الأصلية. يشرح هذا المقال هذا الخرائط ويظهر كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس بيانات العينة.

![مخطط Treemap مع فروع المستهلك والأعمال](treemap-hierarchy.png)

![مخطط Sunburst مع نفس هرمية المستهلك والأعمال](sunburst-hierarchy.png)

## **فهم الفئات ونقاط البيانات والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئة وسلسلة عددية واحدة:

| الفرع | الساق | الفئة | الإيرادات |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

كل صف ينشئ فئة نهائية واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الفئة النهائية إلى أصلها. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

المؤشرات التي تُرجعها [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) تكون من الفئة النهائية صعودًا:

| فهرس `getDataPointLevels()` | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | الفئة النهائية | مستطيل القيمة | قطاع الحلقة الخارجية |
| `1` | الساق | مستطيل الأصل أو العنوان | قطاع الحلقة المتوسطة |
| `2` | الفرع | مستطيل المستوى الأعلى أو العنوان | قطاع الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخطط رغم اختلاف تخطيطاتهما البصرية. يُشترك قطاع الأصل بين عدة فروع نهائية. لتنسيقه، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ الساق `Software` بنقطة `Licenses`. الحفاظ على مراجع لتلك النقاط أوضح وأكثر أمانًا من استخدام تعبيرات غير مفسرة مثل `$dataPoints->get_Item(0)` أو `$dataPoints->get_Item(6)`.

## **إنشاء وتخصيص كلا نوعي المخططات**

المثال الكامل التالي ينشئ مخطط Treemap في الشريحة الأولى ومخطط Sunburst في الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يطبق ألوانًا ثابتة على المستويات المختارة، ينسق تسمية فرع، ويحفظ العرض التقديمي.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // أضف فئات الأوراق. يتم تعيين عنصر التجميع فقط عندما يبدأ مجموعة جديدة;
        // الفئات التالية تبقى في تلك المجموعة حتى يتم تعيين عنصر آخر.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // اعرض الفئة والقيمة على ورقة Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // نسق فرع Consumer عبر أول ورقة في ذلك الفرع.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // نسق ساق Software عبر أول ورقة في تلك الساق.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout يؤثر على تسميات أصل Treemap؛ Sunburst يستخدم قطاعات الحلقة.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

خلايا الفئات وخلايا القيم تستخدم نفس صف ورقة العمل، لذا تظل مواقع مجموعاتها متراصة. عندما تعمل على مخطط موجود بدلاً من إنشاء واحد، افحص صفوف الفئات أولاً وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **اختلافات Treemap و Sunburst**

- يستخدم Treemap المساحة للتواصل القيمة والمستطيلات المتداخلة للتواصل الهرمية. تتحكم طريقة [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#setParentLabelLayout) في كيفية ظهور تسميات الأصل في هذا النوع من المخطط.
- يستخدم Sunburst الزاوية للتواصل القيمة وعمق الحلقة للتواصل الهرمية. لا تتحكم [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#setParentLabelLayout) في تسميات حلقاته.
- كلا النوعين يستخدمان نفس مستويات تجميع الفئات ونفس ترتيب الفئة النهائية إلى الأصل الذي تعيده [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getDataPointLevels)، لذا يمكن مشاركة كود بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأصل من فروعه التابعة. لا تضف نقاطًا عددية منفصلة للفروع أو الساقات.

### **الفرز وترتيب القطاعات**

يقرر محرك تخطيط المخطط الموضع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئات ذات الصلة معًا قبل إضافتها، لكن لا تعتمد على موضع مستطيل معين أو زاوية بدء معينة. إذا كان الترتيب يحمل معنى، ضعه في التسميات أو استخدم نوع مخطط يحتوي على محور فئة صريح.

### **السمة والألوان الثابتة**

المستويات غير المُنسقة في المخطط تُورث ألوانها من سمة العرض التقديمي. يستخدم المثال ملء RGB صريح للحصول على مخرجات متوقعة. إذا كان المخطط يجب أن يتبع تغيّر السمة، استخدم ألوان المخطط (scheme colors) بدلًا من قيم RGB ثابتة وتجنب تجاوز كل مستوى. تحقق أيضًا من تباين التسمية بعد تغيير لون فرع أو ساق.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقص التسميات عندما يكون القطاع صغيرًا جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسمية عادةً ما ينتج نتيجة أوضح. يمكن للتسمية أن تجمع بين اسم الفئة، اسم السلسلة، والقيمة عبر [DataLabelFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datalabelformat/)، لكن تمكين كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير وإعادة الرسم**

حفظ إلى PPTX يبقي المخطط قابلًا للتحرير. عندما يقوم Aspose.Slides برندرة العرض التقديمي إلى PDF أو صورة، تُرسم الملءات وإعدادات التسميات المدعومة مع المخطط. قد يؤدي استبدال الخطوط والفروق الصغيرة في مساحة التخطيط المتاحة إلى تغيير لف الأسطر أو رؤية التسمية، لذا ثبت الخطوط المطلوبة وتحقق من الأهداف المهمة للتصدير.

## **الأسئلة المتكررة**

**لماذا يؤدي تغيير مستوى أب إلى تأثير عدة فروع؟**

الفرع أو الساق هو قطاع بصري مشترك. يمكن الوصول إلى [ChartDataPointLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapointlevel/) عبر فرع تابع، لكن التنسيق ينتمي إلى القطاع المشترك وليس إلى الفرع التابع فقط.

**لماذا فقدت تسمية البيانات؟**

أولًا فعل الحقول المطلوبة على كائن [DataLabelFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datalabelformat/) للتسمية. ثم تحقق مما إذا كان للقطاع مساحة كافية. يؤثر تخطيط تسمية الأصل في Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة جميعًا على إمكانية عرض التسمية.

**هل يمكنني تعيين الترتيب أو إحداثيات القطاعات بدقة؟**

يمكنك التحكم بترتيب صف المصدر والحفاظ على تجميع كل مجموعة بشكل متتابع، لكن لا يمكنك تحديد مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه القيم من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض التقديمي؟**

الملء القائم على السمة مصمم ليتبع لوحة ألوان العرض التقديمي. ضع ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو احتفظ بألوان المخطط عند التكيف مع سمة جديدة إذا كان ذلك مفضلاً.

**هل سيتم الحفاظ على التنسيق المخصص في تصدير PDF والصور؟**

نعم، تُدرج ملءات المخطط المدعومة وإعدادات التسميات أثناء الرندرة. للحصول على نتائج متسقة عبر الأنظمة، وفر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسمية تعتمد على التخطيط.

## **انظر أيضًا**

- [Create Treemap charts](/slides/ar/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ar/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ar/php-java/export-chart/)
- [Manage presentation themes](/slides/ar/php-java/presentation-theme/)