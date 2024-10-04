---
title: Etiqueta de Datos del Gráfico
type: docs
url: /cpp/chart-data-label/
keywords: "Etiqueta de datos del gráfico, distancia de etiqueta, C++, CPP, Aspose.Slides para C++"
description: "Establecer etiqueta de datos del gráfico de PowerPoint y distancia en C++"
---

Las etiquetas de datos en un gráfico muestran detalles sobre la serie de datos del gráfico o puntos de datos individuales. Permiten a los lectores identificar rápidamente las series de datos y también hacen que los gráficos sean más fáciles de entender.

## **Establecer Precisión de los Datos en la Etiqueta de Datos del Gráfico**

Este código C++ te muestra cómo establecer la precisión de los datos en una etiqueta de datos del gráfico:

```c++
	// La ruta al directorio de documentos
	const String outPath = u"../out/EstablecerPrecisionDeLaEtiquetaDeDatos_out.pptx";

	// Instancia una clase de Presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtiene la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Agrega un gráfico con datos predeterminados
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Establece el formato de número de la serie
	chart->set_HasDataTable(true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues(u"#,##0.00");

	// Escribe el archivo de presentación en el disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Mostrar Porcentaje como Etiquetas**
Aspose.Slides para C++ te permite establecer etiquetas de porcentaje en gráficos mostrados. Este código C++ demuestra la operación:

```c++
	// La ruta al directorio de documentos
	const String outPath = u"../out/MostrarPorcentajeComoEtiquetas_out.pptx";

	// Crea una instancia de la clase Presentación
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

	// Guarda la presentación que contiene el gráfico
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Establecer Signo de Porcentaje con Etiqueta de Datos del Gráfico**
Este código C++ te muestra cómo establecer el signo de porcentaje para una etiqueta de datos del gráfico:

```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/EtiquetasDeDatosSignoPorcentaje_out.pptx";

	// Crea una instancia de la clase Presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtiene una referencia de la diapositiva a través de su índice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crea el gráfico de Columnas Apiladas en Porcentaje en una diapositiva
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Establece el NumberFormatLinkedToSource en falso
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Establece el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtiene la hoja de trabajo de datos del gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Elimina las series generadas de manera predeterminada 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Agrega una nueva serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Serie 2")), chart->get_Type());


	// Toma la primera serie de gráficos
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Rojo")), chart->get_Type());
	// Rellena los datos de la serie
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Establece el color de relleno para la serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Establece las propiedades de LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Toma la segunda serie de gráficos
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Azules")), chart->get_Type());
	// Rellena los datos de la serie
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Establece el color de relleno para la serie
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Establece las propiedades de LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Escribe el archivo de presentación en el disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Establecer Distancia de Etiqueta Desde el Eje**
Este código C++ te muestra cómo establecer la distancia de la etiqueta desde un eje de categoría cuando estás tratando con un gráfico trazado desde ejes:

```c++
	// La ruta al directorio de documentos
	const String outPath = u"../out/DistanciaEtiquetaEjeCategoria_out.pptx";

	// Crea una instancia de la clase Presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtiene una referencia de la diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crea un gráfico en la diapositiva
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Obtiene la colección de series del gráfico
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Establece la distancia de la etiqueta desde un eje
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

	// Escribe el archivo de presentación en el disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ajustar Ubicación de Etiqueta**

Cuando creas un gráfico que no depende de ningún eje, como un gráfico circular, las etiquetas de datos del gráfico pueden terminar demasiado cerca de su borde. En tal caso, debes ajustar la ubicación de la etiqueta de datos para que las líneas de líder se muestren claramente.

Este código C++ te muestra cómo ajustar la ubicación de la etiqueta en un gráfico circular:

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