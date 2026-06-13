---
title: "سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst با استفاده از С++"
linktitle: "نقاط داده در نمودارهای Treemap و Sunburst"
type: docs
url: /fa/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- "نمودار treemap"
- "نمودار sunburst"
- "نقطه داده"
- "رنگ برچسب"
- "رنگ شاخه"
- "PowerPoint"
- "ارائه"
- "С++"
- "Aspose.Slides"
description: "یاد بگیرید چگونه نقاط داده را در نمودارهای treemap و sunburst با Aspose.Slides برای С++ مدیریت کنید، سازگار با فرمت‌های PowerPoint."
---
## **مقدمه**

در میان انواع دیگر نمودارهای PowerPoint، دو نوع «سلسله‌مراتبی» وجود دارد - نمودار **Treemap** و نمودار **Sunburst** (که همچنین به عنوان Sunburst Graph، Sunburst Diagram، Radial Chart، Radial Graph یا Multi Level Pie Chart شناخته می‌شود). این نمودارها داده‌های سلسله‌مراتبی را که به صورت درختی سازماندهی شده‌اند - از برگ‌ها تا بالای شاخه - نمایش می‌دهند. برگ‌ها توسط نقاط دادهٔ سری تعریف می‌شوند و هر سطح گروه‌بندی تو در تو بعدی توسط دسته‌بندی مربوطه تعریف می‌شود. Aspose.Slides برای C++ امکان قالب‌بندی نقاط دادهٔ نمودار Sunburst و Treemap را در C++ فراهم می‌کند.

در اینجا یک نمودار Sunburst وجود دارد که داده‌های ستون Series1 گره‌های برگ را تعریف می‌کند، در حالی که ستون‌های دیگر نقاط دادهٔ سلسله‌مراتبی را تعریف می‌کنند:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

بیایید با افزودن یک نمودار Sunburst جدید به ارائه شروع کنیم:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [**ایجاد نمودار Sunburst**](/slides/fa/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

اگر نیازی به قالب‌بندی نقاط دادهٔ نمودار وجود دارد، باید از موارد زیر استفاده کنیم:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)، 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/) classes و [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method دسترسی به قالب‌بندی نقاط دادهٔ نمودارهای Treemap و Sunburst را فراهم می‌کنند.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) برای دسترسی به دسته‌بندی‌های چندسطحی استفاده می‌شود - این شیء حاوی اشیای [**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/) است. 
در اصل این یک wrapper برای [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) است که ویژگی‌های خاص برای نقاط داده را اضافه می‌کند. 
کلاس [**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/) دو متد دارد: [**get_Format()**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) و [**get_Label()**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) که دسترسی به تنظیمات مربوطه را فراهم می‌کنند.

## **نمایش مقدار نقطه داده**
نمایش مقدار نقطه داده "Leaf 4":

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **تنظیم برچسب و رنگ نقطه داده**
برچسب دادهٔ "Branch 1" را تنظیم کنید تا به جای نام دسته، نام سری ("Series1") را نشان دهد. سپس رنگ متن را به زرد تغییر دهید:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **تنظیم رنگ شاخه نقطه داده**

رنگ شاخه "Stem 4" را تغییر دهید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **سوالات متداول**

**آیا می‌توانم ترتیب (مرتب‌سازی) بخش‌ها در Sunburst/Treemap را تغییر دهم؟**

خیر. PowerPoint بخش‌ها را به‌صورت خودکار (معمولاً بر اساس مقادیر نزولی، در جهت ساعت‌گرد) مرتب می‌کند. Aspose.Slides این رفتار را بازتاب می‌دهد: نمی‌توانید ترتیب را به‌صورت مستقیم تغییر دهید؛ برای این کار باید داده‌ها را پیش‌پردازش کنید.

**قالب ارائه چگونه بر رنگ‌های بخش‌ها و برچسب‌ها تأثیر می‌گذارد؟**

رنگ‌های نمودار، مگر اینکه به‌طور صریح پرها/فونت‌ها را تنظیم کنید، از [theme/palette](/slides/fa/cpp/presentation-theme/) ارائه ارث می‌برند. برای نتایج ثابت، پرهای ثابت و قالب‌بندی متن را در سطوح مورد نیاز قفل کنید.

**آیا خروجی به PDF/PNG رنگ‌های سفارشی شاخه و تنظیمات برچسب را حفظ می‌کند؟**

بله. هنگام خروجی گرفتن از ارائه، تنظیمات نمودار (پرها، برچسب‌ها) در قالب‌های خروجی حفظ می‌شوند زیرا Aspose.Slides با تنظیمات قالب‌بندی نمودار رندر می‌کند.

**آیا می‌توانم مختصات واقعی یک برچسب/عنصر را برای قرار دادن پوشش سفارشی بر روی نمودار محاسبه کنم؟**

بله. پس از تأیید چیدمان نمودار، مختصات X واقعی و Y واقعی برای عناصر در دسترس هستند (به‌عنوان مثال، یک [DataLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/datalabel/)) که برای موقعیت‌یابی دقیق پوشش‌ها مفید است.