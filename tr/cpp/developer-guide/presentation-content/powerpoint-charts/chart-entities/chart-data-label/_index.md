---
title: Sunumlarda С++ Kullanarak Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/cpp/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ kullanarak PowerPoint sunumlarında grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, böylece slaytlar daha etkileyici olur."
---
## **Giriş**

Bir grafikteki veri etiketleri, grafik veri serileri veya tek tek veri noktaları hakkında ayrıntılar gösterir. Okuyucuların veri serilerini hızlıca tanımlamasını sağlar ve grafikleri daha anlaşılır kılar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Bu C++ kodu, bir grafik veri etiketinde veri hassasiyetini nasıl ayarlayacağınızı gösterir:

```c++
	// Belgeler dizinine giden yol
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// İlk slaytı alır
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Varsayılan veriyle bir grafik ekler
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Seri sayı formatını ayarlar
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Sunum dosyasını diske yazar
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Yüzdeleri Etiket Olarak Görüntüleme**
Aspose.Slides for C++, görüntülenen grafiklerde yüzde etiketleri ayarlamanıza olanak tanır. Bu C++ kodu işlemi gösterir:

```c++
	// Belgeler dizinine giden yol
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Creates an instance of the Presentation class
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

	// Grafiği içeren sunumu kaydeder
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarlama**
Bu C++ kodu, bir grafik veri etiketi için yüzde işaretini nasıl ayarlayacağınızı gösterir:

```c++
	// Belgeler dizinine giden yol.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Presentation sınıfının bir örneğini oluşturur
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Bir slaytın referansını indeksiyle alır
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Slayt üzerinde PercentsStackedColumn grafiğini oluşturur
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSource özelliğini false olarak ayarlar
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Grafik veri sayfasının indeksini ayarlar
	int defaultWorksheetIndex = 0;

	// Grafik veri çalışma sayfasını alır
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Varsayılan oluşturulan seriyi siler 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Yeni bir seri ekler
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// İlk grafik serisini alır
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Seri verilerini doldurur
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Seri için dolgu rengini ayarlar
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// LabelFormat özelliklerini ayarlar
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// İkinci grafik serisini alır
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Seri verilerini doldurur
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Seri için dolgu rengini ayarlar
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// LabelFormat özelliklerini ayarlar
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Sunum dosyasını diske yazar
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Etiketi Eksenden Uzaklığa Ayarlama**
Bu C++ kodu, eksenlerden çizilmiş bir grafikle çalışırken kategori ekseninden etiket mesafesini nasıl ayarlayacağınızı gösterir:

```c++
	// Belgeler dizinine giden yol
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Presentation sınıfının bir örneğini oluşturur
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Bir slaytın referansını alır
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Slaytta bir grafik oluşturur
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Grafik serileri koleksiyonunu alır
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Etiketi eksenden uzaklığı ayarlar
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Sunum dosyasını diske yazar
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Etiket Konumunu Ayarlama**

Eksen gerektirmeyen bir grafik (örneğin pasta grafiği) oluşturduğunuzda, grafiğin veri etiketleri kenara çok yakın olabilir. Böyle bir durumda, lider çizgilerin net görünmesi için veri etiketinin konumunu ayarlamanız gerekir.

Bu C++ kodu, bir pasta grafiğinde etiket konumunu nasıl ayarlayacağınızı gösterir:

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

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**

Otomatik etiket yerleşimini, lider çizgileri ve küçültülmüş yazı tipini birleştirin; gerekirse bazı alanları (örneğin kategori) gizleyin veya yalnızca uç/anahtar noktalar için etiketleri gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için görünümü kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stilini nasıl sağlayabilirim?**

Yazı tiplerini (aile, boyut) açıkça ayarlayın ve yedekleme olmaması için render tarafında yazı tipinin mevcut olduğunu doğrulayın.