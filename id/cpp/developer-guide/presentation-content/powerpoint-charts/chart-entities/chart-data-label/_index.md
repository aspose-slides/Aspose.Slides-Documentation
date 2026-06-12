---
title: Kelola Label Data Diagram dalam Presentasi Menggunakan С++
linktitle: Label Data
type: docs
url: /id/cpp/chart-data-label/
keywords:
- diagram
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk С++ untuk slide yang lebih menarik."
---
## **Pendahuluan**

Label data pada diagram menampilkan detail tentang serangkaian data diagram atau titik data individu. Mereka memungkinkan pembaca dengan cepat mengidentifikasi serangkaian data dan juga membuat diagram lebih mudah dipahami.

## **Atur Presisi Data pada Label Data Diagram**

Kode C++ berikut menunjukkan cara mengatur presisi data pada label data diagram:

```c++
	// Jalur ke direktori dokumen
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Membuat instance kelas Presentation yang mewakili file PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Mengambil slide pertama
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Menambahkan diagram dengan data default
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Mengatur format angka seri
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Menulis file presentasi ke disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Tampilkan Persentase sebagai Label**

Aspose.Slides untuk C++ memungkinkan Anda mengatur label persentase pada diagram yang ditampilkan. Kode C++ berikut mendemonstrasikan operasi tersebut:

```c++
	// Jalur ke direktori dokumen
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Membuat instance kelas Presentation
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

	// Menyimpan presentasi yang berisi diagram
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Atur Tanda Persentase dengan Label Data Diagram**

Kode C++ berikut menunjukkan cara mengatur tanda persentase untuk label data diagram:

```c++
	// Jalur ke direktori dokumen.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Membuat instance kelas Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Mendapatkan referensi slide melalui indeksnya
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Membuat diagram PercentsStackedColumn pada slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Mengatur NumberFormatLinkedToSource menjadi false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Mengatur indeks lembar data diagram
	int defaultWorksheetIndex = 0;

	// Mendapatkan lembar kerja data diagram
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Menghapus seri default yang dihasilkan 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Menambahkan seri baru
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Mengambil seri diagram pertama
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Mengisi data seri
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Mengatur warna isi untuk seri
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Mengatur properti LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Mengambil seri diagram kedua
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Mengisi data seri
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Mengatur warna isi untuk seri
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Mengatur properti LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Menulis file presentasi ke disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Atur Jarak Label dari Sumbu**

Kode C++ berikut menunjukkan cara mengatur jarak label dari sumbu kategori ketika Anda bekerja dengan diagram yang dipetakan dari sumbu:

```c++
	// Jalur ke direktori dokumen
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Membuat instance kelas Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Mendapatkan referensi slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Membuat diagram pada slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Mendapatkan koleksi seri diagram
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Mengatur jarak label dari sumbu
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Menulis file presentasi ke disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Sesuaikan Lokasi Label**

Saat Anda membuat diagram yang tidak bergantung pada sumbu apa pun seperti diagram pai, label data diagram dapat berakhir terlalu dekat dengan tepinya. Dalam kasus seperti itu, Anda harus menyesuaikan lokasi label data sehingga garis penghubung ditampilkan dengan jelas.

Kode C++ berikut menunjukkan cara menyesuaikan lokasi label pada diagram pai:

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

## **FAQ**

**Bagaimana cara mencegah label data saling tumpang tindih pada diagram yang padat?**

Gabungkan penempatan label otomatis, garis penghubung, dan ukuran font yang lebih kecil; jika perlu, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk titik ekstrem/kunci.

**Bagaimana cara menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Filter titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai aturan yang ditentukan.

**Bagaimana cara memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**

Tetapkan font secara eksplisit (famili, ukuran) dan verifikasi bahwa font tersedia di sisi rendering untuk menghindari fallback.