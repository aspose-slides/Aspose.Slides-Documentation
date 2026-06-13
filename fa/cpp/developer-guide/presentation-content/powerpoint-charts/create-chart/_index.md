---
title: ایحاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در C++
linktitle: ایحاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/cpp/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت‌نقشه
- نمودار سهام
- نمودار جعبه‌ای و شانه‌ای
- نمودار قیفی
- نمودار خورشیدگرد
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای C++ ایجاد و سفارشی کنید. نمودارها را اضافه، قالب‌بندی و ویرایش کنید با مثال‌های کد عملی در C++."
---
## **بررسی کلی**

این مقاله راهنمای جامعی برای ایجاد و سفارشی‌سازی نمودارها با Aspose.Slides ارائه می‌دهد. شما خواهید آموخت که چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلفی را برای مطابقت با نیازهای طراحی خاص خود اعمال کنید. در طول مقاله، مثال‌های کد دقیق هر گام را نشان می‌دهند؛ از مقداردهی اولیهٔ ارائه و شیء نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با دنبال کردن این راهنما، درک محکمی از چگونگی یکپارچه‌سازی تولید دینامیک نمودار در برنامه‌های خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا داده‌ها را به‌سرعت تجسم کنند و بینش‌هایی پیدا کنند که شاید از یک جدول یا صفحه‌گسترده به‌وضوح دیده نشود.

**چرا باید نمودار بسازیم؟**

استفاده از نمودارها به شما این امکان را می‌دهد که

* مقادیر زیاد داده را در یک اسلاید جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و روندهای داده را آشکار کنید
* جهت و شتاب داده را در طول زمان یا نسبت به واحد اندازه‌گیری خاصی استنتاج کنید
* نقاط دورنگام، ناهنجاری‌ها، انحراف‌ها، خطاها، داده‌های بی‌معنی و غیره را شناسایی کنید
* داده‌های پیچیده را به‌صورت مؤثر ارتباط یا ارائه دهید

در PowerPoint می‌توانید از طریق تابع Insert نمودارها را ایجاد کنید؛ این تابع قالب‌های متنوعی برای طراحی انواع مختلف نمودارها فراهم می‌کند. با استفاده از Aspose.Slides می‌توانید نمودارهای معمولی (بر پایهٔ انواع مشهور نمودار) و نمودارهای سفارشی بسازید.

{{% alert color="primary" %}} 

برای ایجاد نمودار، Aspose.Slides کلاس enum [ChartType](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) را تحت فضایی‌نام [Aspose::Slides::Charts](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.charts/) ارائه می‌کند. مقادیر این enum به انواع مختلف نمودارها متناظر هستند. 

{{% /alert %}} 

### **ایجاد نمودارهای عادی**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های اولیه اضافه کنید و نوع نمودار مورد نظر خود را تعیین کنید.  
1. عنوانی برای نمودار تعیین کنید.  
1. به کاربرگ دادهٔ نمودار دسترسی پیدا کنید.  
1. تمام سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
1. رنگ پر کردن برای سری‌های نمودار تنظیم کنید.  
1. برچسب‌هایی برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار عادی ایجاد کنید:

```c++
// مسیر پوشه اسناد.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// اندیس شیت دادهٔ نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// ورق کار دادهٔ نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// عنوان نمودار را تنظیم می‌کند
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// سری‌ها و دسته‌بندی‌های پیش‌فرض تولید‌شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// یک سری جدید اضافه می‌کند
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// دسته‌بندی‌ها را اضافه می‌کند
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// سری اول نمودار را می‌گیرد
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// داده‌های سری را پر می‌کند
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// رنگ پر کردن سری را تنظیم می‌کند
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// سری دوم نمودار را می‌گیرد
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// داده‌های سری را پر می‌کند
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// رنگ پر کردن سری را تنظیم می‌کند
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// برچسب اول به‌طوری تنظیم می‌شود که نام دسته را نشان دهد
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// مقدار برچسب سوم نشان داده می‌شود
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **ایجاد نمودارهای پراکنده**
نمودارهای پراکنده (که به‌عنوان scatter plots یا گراف‌های x‑y نیز شناخته می‌شوند) برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر اغلب استفاده می‌شوند.

ممکن است بخواهید از نمودار پراکنده استفاده کنید وقتی که

* داده‌های عددی جفت‌ شده دارید
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* یک متغیر مستقل دارید که برای یک متغیر وابسته مقادیر متعددی دارد

این کد C++ نشان می‌دهد چگونه یک نمودار پراکنده با سری‌های مختلف نشانگرها ایجاد کنید:

```c++
// مسیر پوشه اسناد.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// عنوان نمودار را تنظیم می‌کند
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// سری‌های پیش‌فرض تولید‌شده را حذف می‌کند 
	chart->get_ChartData()->get_Series()->Clear();
	
	// اندیس شیت دادهٔ نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// ورق کار دادهٔ نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// یک سری جدید اضافه می‌کند
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// سری اول نمودار را می‌گیرد
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// یک نقطه جدید اضافه می‌کند (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// یک نقطه جدید اضافه می‌کند (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// نوع سری را ویرایش می‌کند
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// نشانگر سری نمودار را تغییر می‌دهد
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// سری دوم نمودار را می‌گیرد
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// یک نقطه جدید اضافه می‌کند (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// یک نقطه جدید اضافه می‌کند (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// یک نقطه جدید اضافه می‌کند (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// یک نقطه جدید اضافه می‌کند (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// نشانگر سری نمودار را تغییر می‌دهد
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// حاشیهٔ بخش را تنظیم می‌کند
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// حاشیهٔ بخش را تنظیم می‌کند
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->set_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// حاشیهٔ بخش را تنظیم می‌کند
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// برچسب‌های سفارشی برای هر دسته از سری جدید ایجاد می‌کند
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// خطوط راهنمای نمودار را نشان می‌دهد
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// زاویهٔ چرخش بخش‌های نمودار دایره‌ای را تنظیم می‌کند
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای دایره‌ای**
نمودارهای دایره‌ای برای نشان دادن نسبت بخش به کل داده‌ها، به‌ویژه زمانی که داده‌ها شامل برچسب‌های رده‌ای با مقادیر عددی باشند، مناسب هستند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به جای آن از نمودار ستونی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (در این مورد، `ChartType.Pie`) اضافه کنید.  
1. به کاربرگ دادهٔ نمودار IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای تنظیم کنید.  
1. برچسب‌ها را برای سری‌ها تنظیم کنید.  
1. خطوط رهنمایی برای برچسب‌های سری تنظیم کنید.  
1. زاویهٔ چرخش اسلایدهای نمودار دایره‌ای را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/PieChart_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل PPTX را نمایان می‌سازد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// عنوان نمودار را تنظیم می‌کند
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// سری‌ها و دسته‌بندی‌های پیش‌فرض تولید‌شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// ایندکس برگه دادهٔ نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// برگه کار دادهٔ نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// دسته‌بندی‌ها را اضافه می‌کند
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// یک سری جدید اضافه می‌کند
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// سری اول نمودار را می‌گیرد
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// داده‌های سری را پر می‌کند
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// حاشیهٔ بخش را تنظیم می‌کند
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// حاشیهٔ بخش را تنظیم می‌کند
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// حاشیهٔ بخش را تنظیم می‌کند
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// برچسب‌های سفارشی برای هر دسته از سری جدید ایجاد می‌کند
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// سری را طوری تنظیم می‌کند که خطوط راهنما برای نمودار نمایش داده شود
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// زاویهٔ چرخش بخش‌های نمودار دایره‌ای را تنظیم می‌کند
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان line graphs نیز شناخته می‌شوند) برای نمایش تغییرات مقدار در طول زمان مناسب‌اند. با استفاده از نمودار خطی می‌توانید داده‌های زیادی را هم‌زمان مقایسه کنید، تغییرات و روندها را در طول زمان ردیابی کنید، ناهنجاری‌ها را در سری‌های داده برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (در این مورد، `ChartType::Line`) اضافه کنید.  
1. به کاربرگ دادهٔ نمودار IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار خطی ایجاد کنید:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

به‌طور پیش‌فرض نقاط یک نمودار خطی توسط خطوط مستقیم پیوسته به‌هم متصل می‌شوند. اگر می‌خواهید به‌جای خطوط پیوسته از خط‌های نقطه‌چین استفاده کنید، می‌توانید نوع dash دلخواه خود را به‌این شکل مشخص کنید:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **ایجاد نمودارهای درخت‌نقشه (Tree Map)**

نمودارهای درخت‌نقشه برای داده‌های فروش مناسب هستند وقتی که می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و هم‌زمان به‌سرعت توجه را به آیتم‌های بزرگ‌مساهم هر دسته جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (در این مورد، `ChartType.TreeMap`) اضافه کنید.  
1. به کاربرگ دادهٔ نمودار IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار درخت‌نقشه ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// شاخه ۱
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// شاخه ۲
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Treemap);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	series->set_ParentLabelLayout(Aspose::Slides::Charts::ParentLabelLayoutType::Overlapping);

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای سهام (Stock)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (`ChartType.OpenHighLowClose`) اضافه کنید.  
1. به کاربرگ دادهٔ نمودار IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. قالب‌بندی خطوط HiLowLines را مشخص کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

مثال کد C++ برای ایجاد نمودار سهام:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/AddStockChart_out.pptx";

	//یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// اندیس شیت دادهٔ نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// ورق کار دادهٔ نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// سری‌ها و دسته‌بندی‌های پیش‌فرض تولید‌شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// دسته‌بندی‌ها را اضافه می‌کند
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// یک سری جدید اضافه می‌کند
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// سری اول نمودار را می‌گیرد
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// داده‌های سری اول را پر می‌کند
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// داده‌های سری دوم را پر می‌کند
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// داده‌های سری دوم را پر می‌کند
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// داده‌های سری دوم را پر می‌کند
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// گروه سری‌ها را تنظیم می‌کند
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای جعبه‌ای و شانه‌ای (Box and Whisker)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (`ChartType.BoxAndWhisker`) اضافه کنید.  
1. به کاربرگ دادهٔ نمودار IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار جعبه‌ای و شانه‌ای ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 1")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::BoxAndWhisker);

	series->set_QuartileMethod(Aspose::Slides::Charts::QuartileMethodType::Exclusive);
	series->set_ShowMeanLine(true);
	series->set_ShowMeanMarkers(true);
	series->set_ShowInnerPoints(true);
	series->set_ShowOutlierPoints(true);

	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(41)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(23)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(16)));


	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای قیفی (Funnel)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (`ChartType.Funnel`) اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار قیفی ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));


	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای خورشیدگرد (Sunburst)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (در این مورد، `ChartType.sunburst`) اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار خورشیدگرد ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// شاخه ۱
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// شاخه ۲
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Sunburst);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	// فایل ارائه را بر روی دیسک می‌نویسد
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای هیستوگرام (Histogram)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های اولیه اضافه کنید و نوع دلخواه خود (`ChartType.Histogram`) را تعیین کنید.  
1. به کاربرگ دادهٔ نمودار `IChartDataWorkbook` دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Histogram, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Histogram);
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A2", System::ObjectExt::Box<int32_t>(-41)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A5", System::ObjectExt::Box<int32_t>(-23)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A6", System::ObjectExt::Box<int32_t>(16)));

	chart->get_Axes()->get_HorizontalAxis()->set_AggregationType(Aspose::Slides::Charts::AxisAggregationType::Automatic);

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای رادار (Radar)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های اولیه اضافه کنید و نوع دلخواه خود (`ChartType.Radar`) را تعیین کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار رادار ایجاد کنید:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای چنددسته‌ای (Multi-Category)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه (`ChartType.ClusteredColumn`) اضافه کنید.  
1. به کاربرگ دادهٔ نمودار IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد کنید:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// اندیس شیت دادهٔ نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// ورق کار دادهٔ نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// کاربرگ را پاک می‌کند
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// دسته‌بندی‌ها را اضافه می‌کند
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// یک سری جدید اضافه می‌کند
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"Series 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای نقشه (Map)**

نقشه‌نمودار تصویری از یک ناحیه با داده‌هاست. نمودارهای نقشه برای مقایسه داده‌ها یا مقادیر در مناطق جغرافیایی مختلف مناسب هستند.

این کد C++ نشان می‌دهد چگونه یک نمودار نقشه ایجاد کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **ایجاد نمودارهای ترکیبی (Combination)**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و ارتباطات بین آن‌ها را شناسایی کنید.

![The combination chart](combination_chart.png)

کد C++ زیر نحوهٔ ایجاد نمودار ترکیبی نمایش داده‌شده در بالا را در یک ارائهٔ PowerPoint نشان می‌دهد:

```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // عنوان نمودار را تنظیم کنید.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // افسانه (legend) نمودار را تنظیم کنید.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // سری‌ها و دسته‌بندی‌های پیش‌فرض تولید‌شده را حذف کنید.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // دسته‌بندی‌های جدید را اضافه کنید.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // اولین سری را اضافه کنید.
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<double>(4.3)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));

    return chart;
}

static void AddSecondSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<double>(2.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<double>(4.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<double>(1.8)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 2, ObjectExt::Box<double>(2.8)));
}

static void AddThirdSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box<String>(u"Series 3"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Line);

    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box<double>(3.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box<double>(5.0)));

    series->set_PlotOnSecondAxis(true);
}

static void SetAxisTitle(SharedPtr<IAxis> axis, String axisTitle)
{
    axis->set_HasTitle(true);
    axis->get_Title()->set_Overlay(false);
    auto titleParagraph = axis->get_Title()->AddTextFrameForOverriding(axisTitle)->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(12.0);
}

static void SetPrimaryAxesFormat(SharedPtr<IChart> chart)
{
    // محور افقی را تنظیم کنید.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // محور عمودی را تنظیم کنید.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // رنگ خطوط شبکه اصلی عمودی را تنظیم کنید.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // محور افقی ثانویه را تنظیم کنید.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // محور عمودی ثانویه را تنظیم کنید.
    auto secondaryVerticalAxis = chart->get_Axes()->get_SecondaryVerticalAxis();
    secondaryVerticalAxis->set_Position(AxisPositionType::Right);
    secondaryVerticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    secondaryVerticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(secondaryVerticalAxis, u"Y Axis 2");
}

static void CreateComboChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = CreateChartWithFirstSeries(slide);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation->Save(u"combo-chart.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **به‌روزرسانی نمودارها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) که شامل نمودار مورد نظر است، ایجاد کنید.  
2. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. تمام اشکال را مرور کنید تا نمودار مورد نظر را پیدا کنید.  
4. به کاربرگ دادهٔ نمودار دسترسی پیدا کنید.  
5. داده‌های سری‌های نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.  
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.  
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```c++
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// به اسلاید اول دسترسی می‌یابد
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// اندیس شیت دادهٔ نمودار را تنظیم می‌کند
int32_t defaultWorksheetIndex = 0;

// ورق کار دادهٔ نمودار را دریافت می‌کند
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// نام دسته‌بندی نمودار را تغییر می‌دهد
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// سری اول نمودار را می‌گیرد
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// داده‌های سری را به‌روزرسانی می‌کند
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// تغییر نام سری
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// سری دوم نمودار را می‌گیرد
series = chart->get_ChartData()->get_Series()->idx_get(1);

// اکنون داده‌های سری را به‌روزرسانی می‌کند
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// تغییر نام سری
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// حالا، یک سری جدید اضافه می‌کند
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// سری سوم نمودار را می‌گیرد
series = chart->get_ChartData()->get_Series()->idx_get(2);

// اکنون داده‌های سری را پر می‌کند
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// ذخیرهٔ ارائه همراه با نمودار
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم بازهٔ داده برای نمودارها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) که شامل نمودار است باز کنید.  
2. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. تمام اشکال را مرور کنید تا نمودار مورد نظر را پیدا کنید.  
4. به داده‌های نمودار دسترسی پیدا کنید و بازه را تنظیم کنید.  
5. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه بازهٔ داده برای یک نمودار تنظیم شود:

```cpp
// مسیر پوشه اسناد.
String dataDir = GetDataPath();

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// به اولین اسلاید دسترسی می‌یابد و یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**
هنگامی که از نشانگر پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار نماد نشانگر پیش‌فرض متفاوتی دریافت می‌کند.

این کد C++ نشان می‌دهد چگونه نشانگر سری نمودار به‌صورت خودکار تنظیم شود:

```cpp
// مسیر پوشه اسناد.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// سری دوم نمودار را می‌گیرد
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// داده‌های سری را پر می‌کند
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**کدام انواع نمودارها توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides دامنهٔ وسیعی از انواع نمودارها را شامل می‌شود؛ از جمله نمودارهای ستونی، خطی، دایره‌ای، مساحتی، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم دادهٔ خود انتخاب کنید.

**چگونه می‌توانم یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد می‌کنید، اسلاید مورد نظر را با استفاده از ایندکس آن بازیابی می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید؛ در این متد نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً در ارائهٔ شما وارد می‌کند.

**چگونه می‌توانم داده‌های نمایش‌داده‌شده در یک نمودار را به‌روزرسانی کنم؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب‌کار دادهٔ آن ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/))، پاک کردن سری‌ها و دسته‌بندی‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود، به‌روزرسانی کنید. این کار به‌صورت برنامه‌نویسی امکان تازه‌سازی نمودار برای نمایش جدیدترین داده‌ها را فراهم می‌کند.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و عناصر قالب‌بندی دیگر را برای تطبیق ظاهر نمودار با نیازهای طراحی خاص خود تغییر دهید.