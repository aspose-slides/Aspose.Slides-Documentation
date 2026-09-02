---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در C++
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- نمودار treemap
- نمودار sunburst
- نمودار سلسله‌مراتبی
- نقطه داده
- برچسب داده
- رنگ شاخه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "بیاموزید چگونه داده‌های سلسله‌مراتبی ایجاد کنید و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای C++ سفارشی کنید."
---
## **نمای کلی**

نقشه‌های Treemap و Sunburst داده‌های سلسله‌مراتبی یک نوع را نمایش می‌دهند، اما از چیدمان‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به‌صورت مستطیل‌های تو در تو می‌کشد که مساحت آن‌ها مقادیر برگ‌ها را نشان می‌دهد. یک Sunburst آن را به‌صورت حلقه‌های کانونی نشان می‌دهد: گروه‌های سطح بالا نزدیک به مرکز قرار دارند و دسته‌های برگ در حلقه بیرونی هستند.

در Aspose.Slides for C++، هر مقدار عددی یک [IChartDataPoint](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/) است. متد [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله آن نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه با استفاده از داده‌های نمونه یکسان هر دو نوع نمودار را ایجاد و قالب‌بندی کنیم.

![نقشه Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![نقشه Sunburst با همان سلسله‌مراتب Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونه استفاده شده در زیر دارای سه سطح دسته‌بندی و یک سری عددی است:

| شاخه | دم | برگ | درآمد |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

هر ردیف یک دسته‌بندی برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته‌بندی مسیر از آن برگ تا والدینش را توصیف می‌کند. برای ردیف اول، مسیر `Consumer > Computers > Laptops` است.

اندیس‌های بازگردانده‌شده توسط [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) از برگ به سمت بالا می‌روند:

| `get_DataPointLevels()` index | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | Value rectangle | Outer-ring segment |
| `1` | دم | Parent rectangle or header | Middle-ring segment |
| `2` | شاخه | Top-level rectangle or header | Inner-ring segment |

این ترتیب برای هر دو نوع نمودار یکسان است، حتی اگر چیدمان‌های بصری آن‌ها متفاوت باشد. یک بخش والد توسط چندین برگ به‌اشتراک گذاشته می‌شود. برای قالب‌بندی آن، از سطح متناظر اولین نقطه داده در آن گروه استفاده کنید. برای مثال، شاخه `Consumer` با نقطه `Laptops` شروع می‌شود، در حالی که دم `Software` با نقطه `Licenses` شروع می‌شود. نگهداری ارجاع به آن نقاط واضح‌تر و ایمن‌تر از استفاده از عبارات نامشخصی مانند `dataPoints->idx_get(0)` یا `dataPoints->idx_get(6)` است.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap در اسلاید اول و یک Sunburst در اسلاید دوم ایجاد می‌کند. این مثال سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخاب‌شده اعمال می‌کند، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌کند.

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

    // دسته‌بندی‌های برگ را اضافه کنید. یک آیتم گروه‌بندی تنها زمانی تنظیم می‌شود که یک گروه جدید آغاز شود؛
    // دسته‌بندی‌های بعدی تا زمانی که آیتم دیگری تنظیم شود در همان گروه می‌مانند.
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

    // نمایش دسته‌بندی و مقدار بر روی برگ Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // قالب‌بندی شاخه Consumer از طریق اولین برگ در آن شاخه.
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

    // قالب‌بندی دم Software از طریق اولین برگ در آن دم.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از بخش‌های حلقه استفاده می‌کند.
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

سلول‌های دسته‌بندی و سلول‌های مقدار از همان ردیف worksheet استفاده می‌کنند، بنابراین موقعیت‌های مجموعه آن‌ها هم‌راستا می‌مانند. زمانی که با یک نمودار موجود کار می‌کنید به‌جای ایجاد آن، ابتدا ردیف‌های دسته‌بندی را بررسی کنید و ارجاعات نام‌دار به نقاط داده و سطوحی که قصد دارید قالب‌بندی کنید، ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- یک Treemap از مساحت برای انتقال مقدار و مستطیل‌های تو در تو برای انتقال سلسله‌مراتب استفاده می‌کند. متد [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) نحوه نمایش برچسب‌های والد را در این نوع نمودار کنترل می‌کند.
- یک Sunburst از زاویه برای انتقال مقدار و عمق حلقه برای انتقال سلسله‌مراتب استفاده می‌کند. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) برچسب‌های حلقه‌های آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته‌بندی یکسان و همان ترتیب برگ‑به‑والد برگردانده‌شده توسط [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) استفاده می‌کنند، بنابراین کد ساخت داده و قالب‌بندی سطوح می‌تواند مشترک باشد.
- مقادیر والد از برگ‌های فرزندی محاسبه می‌شوند. نقاط عددی جداگانه برای شاخه‌ها یا دم‌ها اضافه نکنید.

### **مرتب‌سازی و ترتیب بخش‌ها**

موتور چیدمان نمودار مکان نهایی مستطیل‌ها و بخش‌های حلقه را تعیین می‌کند. ردیف‌های دسته‌بندی مرتبط را قبل از افزودن آنها کنار هم قرار دهید، اما به موقعیت خاص مستطیل یا زاویه شروع وابسته نشوید. اگر ترتیب معنا دارد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری با محور دسته‌بندی صریح استفاده کنید.

### **تم و رنگ‌های ثابت**

سطوح نمودار بدون قالب، رنگ‌ها را از تم ارائه به ارث می‌برند. مثال از پرکردن‌های RGB صریح برای خروجی پیش‌بینی‌شده استفاده می‌کند. اگر نمودار باید تغییرات تم را دنبال کند، به جای مقادیر ثابت RGB از رنگ‌های طرح‌بندی استفاده کنید و از بازنویسی هر سطح خودداری کنید. همچنین پس از تغییر پرکنش یک شاخه یا دم، تضاد برچسب‌ها را بررسی کنید.

### **برچسب‌ها و فضاهای موجود**

PowerPoint ممکن است برچسب‌ها را وقتی یک بخش خیلی کوچک باشد مخفی یا کوتاه کند. افزایش اندازه نمودار، کوتاه کردن نام‌های دسته‌بندی، یا نمایش فیلدهای برچسب کمتر معمولاً نتیجه واضح‌تری می‌دهد. یک برچسب می‌تواند نام دسته، نام سری و مقدار را از طریق [IDataLabelFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatalabelformat/) ترکیب کند، اما فعال‌سازی همه فیلدها اغلب نمودارهای سلسله‌مراتبی را خواندن دشوار می‌کند.

### **صدور و رندرینگ**

ذخیره به PPTX نمودار را قابل ویرایش نگه می‌دارد. وقتی Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پرکردن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی فونت و اختلافات کوچک در فضای چیدمان موجود می‌تواند بسته شدن خط یا قابل مشاهده بودن برچسب را تغییر دهد، بنابراین فونت‌های لازم را نصب کنید و هدف‌های مهم صدور را بررسی کنید.

## **پرسش‌های متداول**

**چرا تغییر سطح والد بر چندین برگ تاثیر می‌گذارد؟**

یک شاخه یا دم یک بخش بصری مشترک است. [IChartDataPointLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/) آن می‌تواند از طریق یک برگ فرزند دسترسی پیدا شود، اما قالب‌بندی به بخش والد مشترک تعلق دارد نه فقط به آن برگ.

**چرا یک برچسب داده‌ای گم شده است؟**

ابتدا فیلدهای مورد نیاز را در شیء [IDataLabelFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatalabelformat/) برچسب فعال کنید. سپس بررسی کنید آیا بخش فضای کافی دارد یا خیر. چیدمان برچسب والد Treemap، ابعاد نمودار، طول برچسب، اندازه فونت و تعداد فیلدهای فعال همه بر این که آیا برچسب می‌تواند نمایش داده شود تاثیر دارند.

**آیا می‌توانم ترتیب یا مختصات دقیق بخش‌ها را تعیین کنم؟**

می‌توانید ترتیب ردیف‌های منبع را کنترل کنید و هر گروه را متصل نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زاویه‌های Sunburst را تعیین کنید. موتور چیدمان نمودار آن‌ها را بر اساس سلسله‌مراتب، مقادیر و فضای در دسترس محاسبه می‌کند.

**چرا رنگ‌ها پس از تغییر تم ارائه تغییر می‌کنند؟**

پرکردن‌های مبتنی بر تم برای دنبال کردن پالت ارائه طراحی شده‌اند. رنگ‌های RGB صریح را به سطوحی که باید ثابت بمانند اعمال کنید، یا در زمانی که تطبیق با تم جدید ترجیح داده می‌شود، رنگ‌های طرح‌بندی را حفظ کنید.

**آیا قالب‌بندی سفارشی در خروجی‌های PDF و تصویر حفظ می‌شود؟**

بله، پرکردن‌های پشتیبانی‌شده نمودار و تنظیمات برچسب هنگام رندر گنجانده می‌شوند. برای نتایج سازگار بین سیستم‌ها، فونت‌های لازم را در دسترس قرار دهید و اندازه نهایی خروجی را تست کنید زیرا جایگذاری برچسب به چیدمان وابسته است.

## **موارد مرتبط**

- [ایجاد نمودارهای Treemap](/slides/fa/cpp/create-chart/#create-tree-map-charts)
- [ایجاد نمودارهای Sunburst](/slides/fa/cpp/create-chart/#create-sunburst-charts)
- [صدور نمودارهای ارائه](/slides/fa/cpp/export-chart/)
- [مدیریت تم‌های ارائه](/slides/fa/cpp/presentation-theme/)