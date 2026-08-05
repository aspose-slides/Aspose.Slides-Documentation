---
title: Quản lý Nhãn Dữ liệu Biểu đồ trong Bài thuyết trình sử dụng C++
linktitle: Nhãn Dữ liệu
type: docs
url: /vi/cpp/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bài thuyết trình PowerPoint bằng Aspose.Slides cho C++ để tạo các slide sinh động hơn."
---
## **Giới thiệu**

Nhãn dữ liệu trên biểu đồ hiển thị chi tiết về chuỗi dữ liệu của biểu đồ hoặc các điểm dữ liệu riêng lẻ. Chúng cho phép người đọc nhanh chóng xác định chuỗi dữ liệu và cũng làm cho biểu đồ dễ hiểu hơn.

## **Đặt độ chính xác dữ liệu trong nhãn dữ liệu biểu đồ**

Đoạn mã C++ này cho bạn thấy cách đặt độ chính xác dữ liệu trong một nhãn dữ liệu biểu đồ:

```c++
	// Đường dẫn tới thư mục tài liệu
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Lấy slide đầu tiên
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Thêm biểu đồ với dữ liệu mặc định
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Đặt định dạng số cho chuỗi
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Ghi tệp trình chiếu ra đĩa
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hiển thị tỷ lệ phần trăm dưới dạng nhãn**
Aspose.Slides cho C++ cho phép bạn đặt nhãn phần trăm trên các biểu đồ hiển thị. Đoạn mã C++ này minh họa cách thực hiện:

```c++
	// Đường dẫn tới thư mục tài liệu
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Tạo một thể hiện của lớp Presentation
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

	// Lưu bản trình chiếu chứa biểu đồ
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Đặt ký hiệu phần trăm cho nhãn dữ liệu biểu đồ**
Đoạn mã C++ này cho bạn cách đặt ký hiệu phần trăm cho một nhãn dữ liệu biểu đồ:

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Tạo một thể hiện của lớp Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Lấy tham chiếu của slide thông qua chỉ số của nó
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Tạo biểu đồ PercentsStackedColumn trên một slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Đặt NumberFormatLinkedToSource thành false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Đặt chỉ số của sheet dữ liệu biểu đồ
	int defaultWorksheetIndex = 0;

	// Lấy worksheet dữ liệu biểu đồ
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Xóa series được tạo mặc định 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Thêm một series mới
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Lấy series biểu đồ đầu tiên
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Điền dữ liệu cho series
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Đặt màu nền cho series
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Đặt các thuộc tính LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Lấy series biểu đồ thứ hai
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Điền dữ liệu cho series
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Đặt màu nền cho series
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Đặt các thuộc tính LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Ghi tệp trình chiếu ra đĩa
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Đặt khoảng cách nhãn so với trục**
Đoạn mã C++ này cho bạn cách đặt khoảng cách nhãn so với trục danh mục khi bạn làm việc với biểu đồ được vẽ từ các trục:

```c++
	// Đường dẫn tới thư mục tài liệu
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Tạo một thể hiện của lớp Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Lấy tham chiếu của slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Tạo biểu đồ trên slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Lấy bộ sưu tập series của biểu đồ
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Đặt khoảng cách nhãn so với một trục
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Ghi tệp trình chiếu ra đĩa
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Điều chỉnh vị trí nhãn**

Khi bạn tạo một biểu đồ không dựa vào bất kỳ trục nào như biểu đồ tròn, các nhãn dữ liệu của biểu đồ có thể quá gần cạnh của nó. Trong trường hợp đó, bạn cần điều chỉnh vị trí của nhãn dữ liệu để các đường dẫn (leader lines) hiển thị rõ ràng.

Đoạn mã C++ này cho bạn cách điều chỉnh vị trí nhãn trên biểu đồ tròn:

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

## **Câu hỏi thường gặp**

**Làm thế nào để ngăn nhãn dữ liệu chồng lấn trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, các đường dẫn và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các điểm cực/extreme hoặc quan trọng.

**Làm thế nào để tắt nhãn chỉ cho các giá trị bằng 0, âm hoặc trống?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị 0, giá trị âm hoặc giá trị thiếu theo quy tắc đã định nghĩa.

**Làm thế nào để đảm bảo kiểu nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Đặt rõ phông chữ (họ, kích thước) và xác minh rằng phông chữ có sẵn ở phía render để tránh việc thay thế.