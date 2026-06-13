---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از С++
linktitle: برچسب داده
type: docs
url: /fa/cpp/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- С++
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای С++ اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **معرفی**

برچسب‌های داده در یک نمودار جزئیاتی دربارهٔ سری‌های دادهٔ نمودار یا نقاط دادهٔ منفرد نشان می‌دهند. این برچسب‌ها به خوانندگان امکان می‌دهند تا سری‌های داده را به سرعت شناسایی کنند و همچنین نمودارها را راحت‌تر درک کنند.

## **تنظیم دقت داده در برچسب‌های دادهٔ نمودار**

این کد C++ به شما نشان می‌دهد چگونه دقت داده را در یک برچسب دادهٔ نمودار تنظیم کنید:

```c++
	// مسیر به پوشه اسناد
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// یک شیء از کلاس Presentation ایجاد می‌کند که نشان‌دهنده یک فایل PPTX است
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// اسلاید اول را دریافت می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// نموداری با داده‌های پیش‌فرض اضافه می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// قالب عددی سری‌ها را تنظیم می‌کند
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// فایل ارائه را بر روی دیسک می‌نویسد
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **نمایش درصدها به‌عنوان برچسب‌ها**

Aspose.Slides برای C++ به شما اجازه می‌دهد برچسب‌های درصدی را بر روی نمودارهای نمایش‌ داده شده تنظیم کنید. این کد C++ عملیات را نشان می‌دهد:

```c++
	// مسیر به پوشه اسناد
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند
	System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

	System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::StackedColumn, 20, 20, 400, 400);
	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	System::SharedPtr<IChartCategory> cat;
	System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(chart->get_ChartData()->get_Categories()->get_Count(), 0);
	for (int32_t k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
	{
		cat = chart->get_ChartData()->get_Categories()->idx_get(k);

		for (int32_t i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
		{
			total_for_Cat[k] = total_for_Cat[k] + System::Convert::ToDouble(chart->get_ChartData()->get_Series()->idx_get(i)->get_DataPoints()->idx_get(k)->get_Value()->get_Data());
		}
	}

	double dataPontPercent = 0.f;

	for (int32_t x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(x);
		series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

		for (int32_t j = 0; j < series->get_DataPoints()->get_Count(); j++)
		{
			System::SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(j)->get_Label();
			dataPontPercent = (System::Convert::ToDouble(series->get_DataPoints()->idx_get(j)->get_Value()->get_Data()) / total_for_Cat[j]) * 100;

			System::SharedPtr<IPortion> port = System::MakeObject<Portion>();
			port->set_Text(System::String::Format(u"{0:F2} %", dataPontPercent));
			port->get_PortionFormat()->set_FontHeight(8.f);
			lbl->get_TextFrameForOverriding()->set_Text(u"");
			System::SharedPtr<IParagraph> para = lbl->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
			para->get_Portions()->Add(port);

			lbl->get_DataLabelFormat()->set_ShowSeriesName(false);
			lbl->get_DataLabelFormat()->set_ShowPercentage(false);
			lbl->get_DataLabelFormat()->set_ShowLegendKey(false);
			lbl->get_DataLabelFormat()->set_ShowCategoryName(false);
			lbl->get_DataLabelFormat()->set_ShowBubbleSize(false);
		}
	}

	// ارائه حاوی نمودار را ذخیره می‌کند
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

این کد C++ به شما نشان می‌دهد چگونه علامت درصد را برای یک برچسب دادهٔ نمودار تنظیم کنید:

```c++
	// مسیر به پوشه اسناد.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// مرجع اسلاید را از طریق شاخص آن دریافت می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// نمودار PercentsStackedColumn را بر روی اسلاید ایجاد می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSource را به false تنظیم می‌کند
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// شاخص شیت داده‌های نمودار را تنظیم می‌کند
	int defaultWorksheetIndex = 0;

	// شیت کار کتاب داده‌های نمودار را دریافت می‌کند
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// حذف سری‌های پیش‌فرض تولید شده 
	chart->get_ChartData()->get_Series()->Clear();
	

	// افزودن یک سری جدید
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// دریافت اولین سری نمودار
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// پر کردن داده‌های سری
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// تنظیم رنگ پر برای سری
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// تنظیم ویژگی‌های LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// دریافت دومین سری نمودار
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// پر کردن داده‌های سری
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// تنظیم رنگ پر برای سری
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// تنظیم ویژگی‌های LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// فایل ارائه را بر روی دیسک می‌نویسد
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم فاصله برچسب از محور**

این کد C++ به شما نشان می‌دهد چگونه فاصله برچسب را از محور دسته‌بندی تنظیم کنید زمانی که با یک نمودار رسم‌شده از محورها سر و کار دارید:

```c++
	// مسیر به پوشه اسناد
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// یک نمونه از کلاس Presentation ایجاد می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// مرجع یک اسلاید را دریافت می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک نمودار بر روی اسلاید ایجاد می‌کند
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// کلکسیون سری‌های نمودار را دریافت می‌کند
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// فاصله برچسب از محور را تنظیم می‌کند
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// فایل ارائه را بر روی دیسک می‌نویسد
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم موقعیت برچسب**

زمانی که یک نمودار ایجاد می‌کنید که به هیچ محور وابسته نیست، مانند نمودار دایره‌ای، ممکن است برچسب‌های دادهٔ نمودار بسیار نزدیک به لبهٔ آن شوند. در چنین حالتی، باید موقعیت برچسب داده را تنظیم کنید تا خطوط راهنما به‌وضوح نمایش داده شوند.

این کد C++ به شما نشان می‌دهد چگونه موقعیت برچسب را در یک نمودار دایره‌ای تنظیم کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> chart = pres->get_Slide(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 200.0f, 200.0f);

System::SharedPtr<IChartSeriesCollection> series = chart->get_ChartData()->get_Series();
System::SharedPtr<IDataLabel> label = series->idx_get(0)->get_Label(0);
System::SharedPtr<IDataLabelFormat> dataLabelFormat = label->get_DataLabelFormat();

dataLabelFormat->set_ShowValue(true);
dataLabelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای متراکم جلوگیری کنم؟**

از ترکیب قرارگذاری خودکار برچسب، خطوط راهنما و کاهش اندازه فونت استفاده کنید؛ اگر لازم باشد، برخی فیلدها (مثلاً دسته‌بندی) را مخفی کنید یا فقط برای نقاط بحرانی/کلیدی برچسب نشان دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را قبل از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر صفر، مقادیر منفی یا مقادیر گمشده را بر اساس یک قانون تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب را هنگام خروجی به PDF/تصاویر ثابت نگه دارم؟**

به‌صراحت قلم‌ها (خانواده، اندازه) را تنظیم کنید و اطمینان حاصل کنید که قلم بر روی سمت رندر موجود است تا از استفادهٔ جایگزین جلوگیری شود.