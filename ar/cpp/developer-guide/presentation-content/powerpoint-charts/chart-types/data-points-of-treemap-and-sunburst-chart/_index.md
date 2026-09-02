---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في C++
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط Treemap
- مخطط Sunburst
- مخطط هرمي
- نقطة بيانات
- تسمية البيانات
- لون الفرع
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

توفر مخططات Treemap و Sunburst طريقة عرض لنفس نوع البيانات الهرمية، لكنهما تستخدمان تخطيطات مختلفة. يرسم Treemap الهرمية كمستطيلات متداخلة تمثل مساحات القيم النهائية. يرسم Sunburst الهرمية كدوائر متحدة المركز: المجموعات العليا تكون قريبة من المركز، والفئات النهائية تكون على الحلقة الخارجية.

في Aspose.Slides for C++، كل قيمة رقمية هي [IChartDataPoint](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/). توفر طريقة [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) إمكانية الوصول إلى الفئة النهائية ومجموعاتها الأصلية. يشرح هذا المقال ذلك التعيين ويُظهر كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس بيانات العينة.

![مخطط Treemap مع فروع المستهلك والأعمال](treemap-hierarchy.png)

![مخطط Sunburst مع نفس هيراركية المستهلك والأعمال](sunburst-hierarchy.png)

## **فهم الفئات ونقاط البيانات والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئوية وسلسلة عددية واحدة:

| الفرع | السِّاق | الورقة | الإيرادات |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

كل صف ينشئ فئة نهائية واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من هذه الفئة النهائية إلى أصولها. بالنسبة للصف الأول، فإن المسار هو `Consumer > Computers > Laptops`.

المؤشرات التي تُرجعها [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) تبدأ من الفئة النهائية صعودًا:

| `get_DataPointLevels()` index | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | ورقة | مستطيل القيمة | قطعة الحلقة الخارجية |
| `1` | سِّاق | مستطيل الأصل أو العنوان | قطعة الحلقة الوسطى |
| `2` | فرع | مستطيل المستوى الأعلى أو العنوان | قطعة الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخططات رغم اختلاف تخطيطاتهما البصرية. يُشارك قطعة الأصل عدة فئات نهائية. لتنسيقها، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ سِّاق `Software` بنقطة `Licenses`. الاحتفاظ بمراجع لتلك النقاط أوضح وأكثر أمانًا من استخدام تعبيرات غير مفسَّرة مثل `dataPoints->idx_get(0)` أو `dataPoints->idx_get(6)`.

## **إنشاء وتخصيص كلا نوعي المخططات**

المثال الكامل التالي ينشئ Treemap في الشريحة الأولى وSunburst في الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يطبق ألوان ثابتة على مستويات مختارة، ينسق تسمية فرع، ويحفظ العرض التقديمي.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // إضافة فئات الأوراق. يتم تعيين عنصر التجميع فقط عندما يبدأ مجموعة جديدة؛
    // الفئات التالية تظل في تلك المجموعة حتى يتم تعيين عنصر آخر.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // إظهار الفئة والقيمة على ورقة Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // تنسيق فرع Consumer من خلال أول ورقة في ذلك الفرع.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // تنسيق سِّاق Software من خلال أول ورقة في ذلك السِّاق.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout يؤثر على تسميات الأصل في مخطط Treemap؛ يستخدم Sunburst قطاعات الحلقة.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تستخدم خلايا الفئات وخلايا القيم نفس صف ورقة العمل، لذا تظل مواضع مجموعاتهم متراصة. عند العمل على مخطط موجود بدلاً من إنشاء واحد، افحص صفوف الفئات أولًا وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **الاختلافات بين Treemap و Sunburst**

- يستخدم Treemap المساحة لتوصيل القيمة والمستطيلات المتداخلة لتوصيل الهرمية. تتحكم طريقة [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) في ظهور تسميات الأصل في هذا النوع من المخططات.
- يستخدم Sunburst الزاوية لتوصيل القيمة وعمق الحلقة لتوصيل الهرمية. لا تتحكم [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) في تسميات حلقاته.
- كلا النوعين يستخدمان نفس مستويات تجميع الفئات ونفس ترتيب الفئة النهائية إلى الأصل الذي تُرجعه [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)، لذا يمكن مشاركة شفرة بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأصل من أوراقه المتفرعة. لا تُضف نقاط عددية منفصلة للفروع أو السِّاقات.

### **الفرز وترتيب القطع**

تحدد محرك تخطيط المخطط الموضع النهائي للمستطيلات وقطع الحلقة. رتب صفوف الفئات ذات الصلة معًا قبل إضافتها، لكن لا تعتمد على موضع مستطيل معين أو زاوية بدء محددة. إذا كان للترتيب معنى، أدرجه في التسميات أو استخدم نوع مخطط يحتوي على محور فئوي صريح.

### **السمة والألوان الثابتة**

تورث مستويات المخطط غير المنسقة الألوان من سمة العرض التقديمي. يستخدم المثال تعبئة RGB صريحة للحصول على نتيجة متوقعة. إذا كان المخطط يجب أن يتبع تغيّر السمة، استخدم ألوان المخطط بدلاً من قيم RGB ثابتة وتجنب تجاوز كل مستوى. تحقق أيضًا من تباين التسميات بعد تغيير تعبئة فرع أو سِّاق.

### **التسميات والمساحة المتاحة**

قد يقوم PowerPoint بإخفاء أو تقصير التسميات عندما تكون القطعة صغيرة جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسميات عادةً ما ينتج نتيجة أوضح. يمكن للتسمية دمج اسم الفئة، اسم السلسلة، والقيمة عبر [IDataLabelFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatalabelformat/)، لكن تمكين كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والتصيير**

يحافظ الحفظ بصيغة PPTX على إمكانية تحرير المخطط. عندما تقوم Aspose.Slides بتصيير العرض التقديمي إلى PDF أو صورة، تُصَيَّر التعبئات وإعدادات التسميات المدعومة مع المخطط. قد تتسبب استبدال الخطوط واختلافات صغيرة في مساحة التخطيط المتاحة في تغير تغليف السطور أو رؤية التسميات، لذا قم بتثبيت الخطوط المطلوبة وتحقق من أهداف التصدير المهمة.

## **الأسئلة المتكررة**

**لماذا يؤثر تغيير مستوى الأصل على عدة أوراق؟**

الفرع أو السِّاق هو قطعة بصرية مشتركة. يمكن الوصول إلى [IChartDataPointLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapointlevel/) عبر ورقة متفرعة، لكن التنسيق ينتمي إلى قطعة الأصل المشتركة وليس فقط إلى تلك الورقة.

**لماذا تفتقد تسمية البيانات؟**

أولاً فعل الحقول المطلوبة في كائن [IDataLabelFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatalabelformat/) الخاص بالتسمية. ثم تحقق مما إذا كانت القطعة تملك مساحة كافية. يؤثر تخطيط تسمية الأصل في Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة جميعًا على إمكانية عرض التسمية.

**هل يمكن تحديد الترتيب أو إحداثيات القطع بدقة؟**

يمكنك التحكم في ترتيب صفوف المصدر والحفاظ على أن تكون كل مجموعة متجاورة، لكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه القيم من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض التقديمي؟**

تُصمم التعبئات المعتمدة على السمة لتتبع لوحة ألوان العرض التقديمي. استخدم ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو حافظ على ألوان المخطط عند التكيف مع سمة جديدة إذا كان ذلك مفضلاً.

**هل سيُحفظ التنسيق المخصص في تصدير PDF والصور؟**

نعم، تُدرج التعبئات وإعدادات التسميات المدعومة أثناء التصيير. للحصول على نتائج متسقة عبر الأنظمة، وفّر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسميات تعتمد على التخطيط.

## **انظر أيضًا**

- [Create Treemap charts](/slides/ar/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ar/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ar/cpp/export-chart/)
- [Manage presentation themes](/slides/ar/cpp/presentation-theme/)