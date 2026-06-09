---
title: Gerenciar Rótulos de Dados de Gráficos em Apresentações Usando C++
linktitle: Rótulo de Dados
type: docs
url: /pt/cpp/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão de dados
- percentual
- distância do rótulo
- localização do rótulo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados de gráfico em apresentações PowerPoint usando Aspose.Slides para C++ para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados em um gráfico exibem detalhes sobre a série de dados do gráfico ou pontos de dados individuais. Eles permitem que os leitores identifiquem rapidamente as séries de dados e também facilitam a compreensão dos gráficos.

## **Definir Precisão dos Dados nos Rótulos do Gráfico**

Este código C++ mostra como definir a precisão dos dados em um rótulo de gráfico:

```c++
	// O caminho para o diretório de documentos
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Instancia a classe Presentation que representa um arquivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtém o primeiro slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Adiciona um gráfico com dados padrão
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Define o formato numérico da série
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Grava o arquivo de apresentação no disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Exibir Percentuais como Rótulos**
Aspose.Slides for C++ permite definir rótulos de percentual em gráficos exibidos. Este código C++ demonstra a operação:

```c++
	// O caminho para o diretório de documentos
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Cria uma instância da classe Presentation
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

	// Salva a apresentação que contém o gráfico
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Definir o Sinal de Percentual nos Rótulos do Gráfico**
Este código C++ mostra como definir o sinal de percentual para um rótulo de gráfico:

```c++
	// O caminho para o diretório de documentos.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Cria uma instância da classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtém a referência de um slide através do seu índice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Cria o gráfico PercentsStackedColumn em um slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Define NumberFormatLinkedToSource como false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Define o índice da planilha de dados do gráfico
	int defaultWorksheetIndex = 0;

	// Obtém a planilha de dados do gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Exclui a série gerada por padrão 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Adiciona uma nova série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Obtém a primeira série do gráfico
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Preenche os dados da série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Define a cor de preenchimento para a série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Define as propriedades de LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Obtém a segunda série do gráfico
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Preenche os dados da série
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Define a cor de preenchimento para a série
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Define as propriedades de LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Grava o arquivo de apresentação no disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Definir Distância do Rótulo ao Eixo**
Este código C++ mostra como definir a distância do rótulo a um eixo de categoria ao trabalhar com um gráfico plotado a partir de eixos:

```c++
	// O caminho para o diretório de documentos
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Cria uma instância da classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtém a referência de um slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Cria um gráfico no slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Obtém a coleção de séries do gráfico
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Define a distância do rótulo a partir de um eixo
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Grava o arquivo de apresentação no disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ajustar a Posição do Rótulo**

Ao criar um gráfico que não depende de nenhum eixo, como um gráfico de pizza, os rótulos de dados do gráfico podem ficar muito próximos de sua borda. Nesse caso, é necessário ajustar a posição do rótulo de dados para que as linhas de chamada sejam exibidas claramente.

Este código C++ mostra como ajustar a posição do rótulo em um gráfico de pizza:

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

**Como posso impedir que os rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de chamada e tamanho de fonte reduzido; se necessário, oculte alguns campos (por exemplo, a categoria) ou exiba rótulos apenas para pontos extremos/chave.

**Como desabilitar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar os rótulos e desative a exibição para valores 0, valores negativos ou valores ausentes de acordo com uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente as fontes (família, tamanho) e verifique se a fonte está disponível no lado de renderização para evitar fallback.