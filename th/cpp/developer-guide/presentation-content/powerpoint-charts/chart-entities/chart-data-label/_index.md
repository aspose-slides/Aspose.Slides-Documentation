---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ C++
linktitle: ป้ายข้อมูล
type: docs
url: /th/cpp/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งของป้าย
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ C++ เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น"
---
## **แนะนำ**

ป้ายข้อมูลบนแผนภูมิแสดงรายละเอียดเกี่ยวกับชุดข้อมูลของแผนภูมิหรือจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุชุดข้อมูลได้อย่างรวดเร็วและทำให้แผนภูมิเข้าใจง่ายขึ้น

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลของแผนภูมิ**

โค้ด C++ นี้แสดงวิธีตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลของแผนภูมิ:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// ดึงสไลด์แรก
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// ตั้งค่ารูปแบบตัวเลขของชุดข้อมูล
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// เขียนไฟล์งานนำเสนอลงดิสก์
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **แสดงเปอร์เซ็นต์เป็นป้าย**

Aspose.Slides for C++ อนุญาตให้คุณตั้งค่าป้ายเปอร์เซ็นต์บนแผนภูมิที่แสดง โค้ด C++ นี้สาธิตการทำงาน:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation
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

	// บันทึกงานนำเสนอที่มีแผนภูมิ
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลของแผนภูมิ**

โค้ด C++ นี้แสดงวิธีตั้งสัญลักษณ์เปอร์เซ็นต์สำหรับป้ายข้อมูลของแผนภูมิ:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// ดึงอ้างอิงสไลด์โดยใช้ดัชนี
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// สร้างแผนภูมิ PercentsStackedColumn บนสไลด์
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// ตั้งค่า NumberFormatLinkedToSource เป็น false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// ตั้งดัชนีของแผ่นข้อมูลแผนภูมิ
	int defaultWorksheetIndex = 0;

	// ดึงแผ่นงานข้อมูลแผนภูมิ
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// ลบชุดข้อมูลที่สร้างโดยอัตโนมัติ 
	chart->get_ChartData()->get_Series()->Clear();
	

	// เพิ่มชุดข้อมูลใหม่
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// รับชุดข้อมูลแผนภูมิแรก
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// ใส่ข้อมูลให้ชุดข้อมูล
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// ตั้งค่าสีเติมสำหรับชุดข้อมูล
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// ตั้งค่าคุณสมบัติของ LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// รับชุดข้อมูลแผนภูมิที่สอง
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// ใส่ข้อมูลให้ชุดข้อมูล
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// ตั้งค่าสีเติมสำหรับชุดข้อมูล
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// ตั้งค่าคุณสมบัติของ LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// บันทึกไฟล์งานนำเสนอลงดิสก์
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **ตั้งระยะห่างของป้ายจากแกน**

โค้ด C++ นี้แสดงวิธีตั้งระยะห่างของป้ายจากแกนประเภทเมื่อคุณทำงานกับแผนภูมิที่วางจากแกน:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// ดึงอ้างอิงสไลด์
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// สร้างแผนภูมิบนสไลด์
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// ดึงคอลเลกชันชุดข้อมูลของแผนภูมิ
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// ตั้งค่าระยะห่างของป้ายจากแกน
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// บันทึกไฟล์งานนำเสนอลงดิสก์
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ปรับตำแหน่งป้าย**

เมื่อคุณสร้างแผนภูมิที่ไม่พึ่งพาแกนใด ๆ เช่น แผนภูมิวงกลม ป้ายข้อมูลของแผนภูมิอาจอยู่ใกล้ขอบมากเกินไป ในกรณีเช่นนี้ คุณต้องปรับตำแหน่งของป้ายข้อมูลเพื่อให้เส้นเชื่อมแสดงได้อย่างชัดเจน

โค้ด C++ นี้แสดงวิธีปรับตำแหน่งป้ายบนแผนภูมิวงกลม:

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

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันบนแผนภูมิที่แน่นได้อย่างไร?**

ผสานการวางป้ายอัตโนมัติ, เส้นเชื่อม, และการลดขนาดฟอนต์; หากจำเป็นให้ซ่อนฟิลด์บางอย่าง (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะจุดที่สำคัญ/ขอบเขตเท่านั้น

**ฉันจะปิดการแสดงป้ายสำหรับค่าศูนย์ ค่าติดลบ หรือค่าที่ว่างเปล่าได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้ป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าเป็นลบ, หรือค่าที่ขาดหายตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

ตั้งค่าฟอนต์ (ครอบครัว, ขนาด) อย่างชัดเจนและตรวจสอบว่าฟอนต์พร้อมใช้งานบนด้านการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง