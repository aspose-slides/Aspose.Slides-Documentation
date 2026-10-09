---
title: ایجاد یا به‌روزرسانی نمودارهای ارائهٔ پاورپوینت در C++
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/cpp/create-chart/
aliases:
  - /cpp/update-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت‌نقشه‌ای
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نمودارها را در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای C++ ایجاد و سفارشی‌سازی کنید. نمودارها را با مثال‌های کد عملی در C++ اضافه، قالب‌بندی و ویرایش کنید."
---
## **مرور کلی**

این مقاله راهنمای جامعی برای ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides ارائه می‌دهد. شما یاد می‌گیرید که چگونه برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده پر کنید و گزینه‌های قالب‌بندی مختلفی را اعمال کنید تا متناسب با نیازهای طراحی خاص شما باشد. در تمام مقاله، مثال‌های کد تفصیلی هر گام را نشان می‌دهند، از مقداردهی اولیهٔ ارائه و شیء نمودار تا پیکربندی س series، محورها و افسانه‌ها. با پیروی از این راهنما، درک کاملی از چگونگی ادغام تولید دینامیک نمودار در برنامه‌های خود به‌دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا داده‌ها را به‌سرعت تجسم کرده و بینش‌هایی کسب کنند که ممکن است از جدول یا صفحه‌گسترده به‌وضوح نمایان نشود.

**چرا نمودار ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید

* حجم زیادی از داده‌ها را در یک اسلاید ارائه خلاصه، فشرده یا تجمیع کنید
* الگوها و روندهای داده را نمایان کنید
* جهت و شتاب داده‌ها را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید
* نواقص، انحرافات، خطاها، داده‌های غیرمنطقی و موارد مشابه را شناسایی کنید
* داده‌های پیچیده را ارتباطی یا ارائه کنید

در PowerPoint می‌توانید نمودارها را از طریق عملکرد Insert ایجاد کنید که قالب‌های متنوعی برای طراحی انواع نمودارها فراهم می‌کند. با Aspose.Slides می‌توانید نمودارهای معمولی (بر پایه انواع نمودارهای محبوب) و نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" %}} 

برای ایجاد نمودارها، Aspose.Slides کلاس enum [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) را در فضای نام [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/) ارائه می‌دهد. مقادیر این enum به انواع مختلف نمودارها مربوط می‌شوند.

{{% /alert %}} 

### **ایجاد نمودارهای معمولی**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار مورد نظر خود را مشخص کنید.  
1. عنوانی برای نمودار اضافه کنید.  
1. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.  
1. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. برخی داده‌های جدید برای سری نمودار اضافه کنید.  
1. یک رنگ پر برای سری نمودار اضافه کنید.  
1. برچسب‌هایی برای سری نمودار اضافه کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار معمولی ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// مسیر به پوشهٔ اسناد.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// یک کلاس ارائه ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اولین اسلاید دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// اندیس صفحه‌کار داده‌های نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// صفحه‌کار داده‌های نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// عنوان نمودار را تنظیم می‌کند
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// یک سری جدید اضافه می‌کند
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// دسته‌ها را اضافه می‌کند
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// سری اول نمودار را می‌گیرد
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// داده‌های سری را پر می‌کند
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// رنگ پر را برای سری تنظیم می‌کند
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// سری دوم نمودار را می‌گیرد
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// داده‌های سری را پر می‌کند
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// رنگ پر را برای سری تنظیم می‌کند
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// برچسب اول برای نمایش نام دسته تنظیم می‌شود
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// مقدار برای برچسب سوم نشان داده می‌شود
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **ایجاد نمودارهای پراکنده**
نمودارهای پراکنده (که به‌عنوان scatter plots یا نمودارهای x‑y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

ممکن است بخواهید از یک نمودار پراکنده استفاده کنید وقتی

* داده‌های عددی جفت‌گیری شده دارید
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا خیر
* یک متغیر مستقل دارید که برای یک متغیر وابسته مقادیر متعددی دارد

این کد C++ نشان می‌دهد چگونه یک نمودار پراکنده با مجموعهٔ مختلفی از نشانگرها ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartSeriesGroupCollection.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IMarker.h>
#include <DOM/Chart/MarkerStyleType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

// مسیر به پوشه اسناد.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	// یک کلاس ارائه ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اولین اسلاید دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// عنوان نمودار را تنظیم می‌کند
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// سری‌های پیش‌فرض تولید شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	
	// اندیس صفحه‌کار داده‌های نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// صفحه‌کار داده‌های نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// یک سری جدید اضافه می‌کند
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// سری اول نمودار را می‌گیرد
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// یک نقطه جدید (1:3) اضافه می‌کند
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// یک نقطه جدید (2:10) اضافه می‌کند
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// نوع سری را ویرایش می‌کند
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// تغییر نشانگر سری نمودار
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// سری دوم نمودار را می‌گیرد
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// یک نقطه جدید (5:2) اضافه می‌کند
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// یک نقطه جدید (3:1) اضافه می‌کند
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// یک نقطه جدید (2:2) اضافه می‌کند
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// یک نقطه جدید (5:1) اضافه می‌کند
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// تغییر نشانگر سری نمودار
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
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// حاشیهٔ بخش را تنظیم می‌کند
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// برچسب‌های سفارشی برای هر دستهٔ سری جدید ایجاد می‌کند
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

	// خطوط راهنما برای نمودار نشان داده می‌شوند
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// زاویهٔ چرخش بخش‌های نمودار دایره‌ای را تنظیم می‌کند
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای دایره‌ای**
نمودارهای دایره‌ای بهترین گزینه برای نشان دادن رابطهٔ بخش به کل در داده‌ها هستند، به‌ویژه وقتی داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی هستند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به‌جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (در اینجا `ChartType.Pie`) را تعیین کنید.  
1. به کاربرگ داده‌های IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری نمودار اضافه کنید.  
1. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی برای بخش‌های دایره‌ای تعیین کنید.  
1. برچسب‌ها را برای سری تنظیم کنید.  
1. خطوط راهنما برای برچسب‌های سری تنظیم کنید.  
1. زاویهٔ چرخش اسلایدهای نمودار دایره‌ای را تنظیم کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartSeriesGroupCollection.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/PieChart_out.pptx";

	// یک کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اولین اسلاید دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// عنوان نمودار را تنظیم می‌کند
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// اندیس صفحه‌کار داده‌های نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// صفحه‌کار داده‌های نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// دسته‌ها را اضافه می‌کند
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
	// حاشیه بخش را تنظیم می‌کند
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// حاشیه بخش را تنظیم می‌کند
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// حاشیه بخش را تنظیم می‌کند
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// برچسب‌های سفارشی برای هر یک از دسته‌های سری جدید ایجاد می‌کند
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

	// تنظیم سری برای نمایش خطوط راهنما در نمودار
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// تنظیم زاویه چرخش بخش‌های نمودار دایره‌ای
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان line graphs نیز شناخته می‌شوند) بهترین گزینه برای موقعیت‌هایی هستند که می‌خواهید تغییرات مقدار در طول زمان را نشان دهید. با استفاده از یک نمودار خطی می‌توانید داده‌های زیاد را به‌صورت همزمان مقایسه کنید، تغییرات و روندها را در طول زمان پیگیری کنید، ناهنجاری‌های سری داده را برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (در اینجا `ChartType::Line`) را تعیین کنید.  
1. به کاربرگ داده‌های IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری نمودار اضافه کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار خطی ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

به طور پیش‌فرض، نقاط در یک نمودار خطی توسط خطوط مستقیم پیوسته به هم متصل می‌شوند. اگر می‌خواهید به‌جای خطوط مستقیم از خط‌چین استفاده کنید، می‌توانید نوع dash دلخواه خود را به‌این‌صورت تعیین کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **ایجاد نمودارهای درخت‌نقشه‌ای**

نمودارهای درخت‌نقشه‌ای بهترین گزینه برای داده‌های فروش هستند وقتی می‌خواهید اندازهٔ نسبی دسته‌های داده را نشان دهید و همزمان توجه را به آیتم‌هایی که سهم بزرگ‌تری در هر دسته دارند جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (در اینجا `ChartType.TreeMap`) را تعیین کنید.  
1. به کاربرگ داده‌های IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری نمودار اضافه کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار درخت‌نقشه‌ای ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCategoryLevelsManager.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/ParentLabelLayoutType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

// مسیر به پوشه اسناد.
	const String outPath = u"../out/TreemapChart_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// شاخه 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// شاخه 2
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

### **ایجاد نمودارهای سهام**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (`ChartType.OpenHighLowClose`) را تعیین کنید.  
1. به کاربرگ داده‌های IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری نمودار اضافه کنید.  
1. قالب خطوط HiLowLines را مشخص کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

نمونه کد C++ برای ایجاد نمودار سهام:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartSeriesGroupCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IUpDownBarsManager.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// اندیس صفحه‌کار داده‌های نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// صفحه‌کار داده‌های نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// دسته‌ها را اضافه می‌کند
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

### **ایجاد نمودارهای جعبه‌ای و ویسکر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (`ChartType.BoxAndWhisker`) را تعیین کنید.  
1. به کاربرگ داده‌های IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری نمودار اضافه کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار جعبه‌ای و ویسکر ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/QuartileMethodType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
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

### **ایجاد نمودارهای قیفی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (`ChartType.Funnel`) را تعیین کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار قیفی ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/FunnelChart_out.pptx";

	//یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//به اسلاید اول دسترسی می‌یابد
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

### **ایجاد نمودارهای خورشیدی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (در اینجا `ChartType.sunburst`) را تعیین کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار خورشیدی ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCategoryLevelsManager.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// شاخه 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// شاخه 2
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

	// فایل ارائه را بر روی دیسک ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **ایجاد نمودارهای هیستوگرام**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع مورد نظر (`ChartType.Histogram`) را تعیین کنید.  
1. به کاربرگ داده‌های `IChartDataWorkbook` دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

```c++
#include <DOM/Chart/AxisAggregationType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
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

### **ایجاد نمودارهای رادار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع مورد نظر (`ChartType.Radar`) را تعیین کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار رادار ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **ایجاد نمودارهای چنددسته‌ای**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع مورد نظر (`ChartType.ClusteredColumn`) را تعیین کنید.  
1. به کاربرگ داده‌های IChartDataWorkbook دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری نمودار اضافه کنید.  
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCategoryLevelsManager.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

	// مسیر به پوشه اسناد.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اسلاید اول دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// اندیس صفحه‌کار داده‌های نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// صفحه‌کار داده‌های نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// دفتر کار را پاک می‌کند
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// دسته‌ها را اضافه می‌کند
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

### **ایجاد نمودارهای نقشه‌ای**

نمودار نقشه‌ای تصویری از یک ناحیه شامل داده‌هاست. نمودارهای نقشه‌ای بهترین گزینه برای مقایسه داده‌ها یا مقادیر در مناطق جغرافیایی مختلف هستند.

این کد C++ نشان می‌دهد چگونه یک نمودار نقشه‌ای ایجاد کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا بیش از دو نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما اجازه می‌دهد تا تفاوت‌ها بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی کنید.

![نمودار ترکیبی](combination_chart.png)

کد C++ زیر نشان می‌دهد چگونه نمودار ترکیبی نشان داده‌شده در بالا را در یک ارائهٔ PowerPoint ایجاد کنید:

```cpp
#include <DOM/Chart/AxisPositionType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IAxisFormat.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/LegendPositionType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // تنظیم عنوان نمودار.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // تنظیم افسانهٔ نمودار.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // حذف سری‌ها و دسته‌های پیش‌فرض تولید شده.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // اضافه کردن دسته‌های جدید.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // اضافه کردن سری اول.
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
    // تنظیم محور افقی.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // تنظیم محور عمودی.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // تنظیم رنگ خطوط ردیف اصلی عمودی.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // تنظیم محور افقی ثانویه.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // تنظیم محور عمودی ثانویه.
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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ایجاد کنید که شامل نمودار مورد نظر است.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. تمام اشکال را پیمایش کنید تا نمودار مطلوب را پیدا کنید.  
4. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.  
5. داده‌های سری نمودار را با تغییر مقادیر سری تغییر دهید.  
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.  
7. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// به اولین اسلاید دسترسی می‌یابد
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// اندیس صفحه‌کار داده‌های نمودار را تنظیم می‌کند
int32_t defaultWorksheetIndex = 0;

// صفحه‌کار داده‌های نمودار را دریافت می‌کند
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

// در حال به‌روزرسانی داده‌های سری
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// تغییر نام سری
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// در حال افزودن یک سری جدید
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// سری سوم نمودار را می‌گیرد
series = chart->get_ChartData()->get_Series()->idx_get(2);

// در حال پر کردن داده‌های سری
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// ذخیرهٔ ارائه با نمودار
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم محدودهٔ داده برای نمودارها**

برای بررسی محدوده‌ای که توسط یک نمودار موجود استفاده شده است، به [Retrieve a Chart's Data Range](/slides/fa/cpp/chart-workbook/#retrieve-a-charts-data-range) مراجعه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) باز کنید که شامل نمودار است.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. تمام اشکال را پیمایش کنید تا نمودار مطلوب را پیدا کنید.  
4. به داده‌های نمودار دسترسی پیدا کنید و محدوده را تنظیم کنید.  
5. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه محدودهٔ داده برای یک نمودار تنظیم شود:

``` cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

// مسیر به پوشهٔ اسناد.
String dataDir = u"../documents/";

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نشان می‌دهد
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// به اولین اسلاید دسترسی می‌یابد و یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**
هنگامی که از یک نشانگر پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار نماد نشانگر پیش‌فرض متفاوتی دریافت می‌کند.

این کد C++ نشان می‌دهد چگونه به‌صورت خودکار یک نشانگر سری نمودار تنظیم شود:

``` cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

// مسیر به پوشهٔ اسناد.
String dataDir = u"../documents/";

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

Aspose.Slides طیف وسیعی از انواع نمودارها از جمله میله‌ای، خطی، دایره‌ای، ناحیه‌ای، پراکنده، هیستوگرام، رادار و بسیاری دیگر را پشتیبانی می‌کند. این انعطاف‌پذیری به شما امکان می‌دهد مناسب‌ترین نوع نمودار را برای نیازهای تجسم دادهٔ خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید، اسلاید مورد نظر را با استفاده از ایندکس آن بازیابی کنید و سپس متد افزودن نمودار را صدا بزنید، نوع نمودار و داده‌های اولیه را مشخص کنید. این فرآیند نمودار را مستقیماً در ارائهٔ شما یکپارچه می‌کند.

**چگونه می‌توان داده‌های نمایش‌داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به دفتر کار داده آن ([IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/))، پاک‌کردن سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود به‌روز کنید. این کار امکان تازه‌سازی برنامه‌ایتیک نمودار را برای نمایش جدیدترین داده‌ها فراهم می‌کند.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر قالب‌بندی را تغییر دهید تا ظاهر نمودار را مطابق با نیازهای طراحی خاص خود تنظیم کنید.