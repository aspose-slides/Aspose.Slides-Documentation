---
title: Administrar etiquetas de datos de gráficos en presentaciones usando С++
linktitle: Etiqueta de datos
type: docs
url: /es/cpp/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de la etiqueta
- ubicación de la etiqueta
- PowerPoint
- presentación
- С++
- Aspose.Slides
description: "Aprenda a agregar y formatear etiquetas de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para С++ para diapositivas más atractivas."
---

Las etiquetas de datos en un gráfico muestran detalles sobre la serie de datos del gráfico o puntos de datos individuales. Permiten a los lectores identificar rápidamente las series de datos y también hacen que los gráficos sean más fáciles de entender.

## **Establecer la precisión de los datos en las etiquetas de datos del gráfico**

Este código C++ le muestra cómo establecer la precisión de los datos en una etiqueta de datos del gráfico:
```c++
	// La ruta al directorio de documentos
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Instancia la clase Presentation que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtiene la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Añade un gráfico con datos predeterminados
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Establece el formato numérico de la serie
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Guarda el archivo de la presentación en disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Mostrar porcentajes como etiquetas**

Aspose.Slides para C++ le permite establecer etiquetas de porcentaje en los gráficos mostrados. Este código C++ demuestra la operación:
```c++
	// La ruta al directorio de documentos
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Crea una instancia de la clase Presentation
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


## **Establecer el signo de porcentaje con las etiquetas de datos del gráfico**

Este código C++ le muestra cómo establecer el signo de porcentaje para una etiqueta de datos del gráfico:
```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Crea una instancia de la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtiene la referencia de una diapositiva mediante su índice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crea el gráfico PercentsStackedColumn en una diapositiva
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Establece NumberFormatLinkedToSource a false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Establece el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtiene la hoja de datos del gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Elimina la serie generada por defecto 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Añade una nueva serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Toma la primera serie del gráfico
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
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
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Toma la segunda serie del gráfico
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
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

	// Guarda el archivo de la presentación en disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Establecer la distancia de la etiqueta desde el eje**

Este código C++ le muestra cómo establecer la distancia de la etiqueta desde un eje de categorías cuando se trata de un gráfico trazado a partir de ejes:
```c++
	// La ruta al directorio de documentos
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Crea una instancia de la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtiene la referencia de una diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crea un gráfico en la diapositiva
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Obtiene la colección de series del gráfico
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Establece la distancia de la etiqueta desde un eje
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Guarda el archivo de la presentación en disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Ajustar la ubicación de la etiqueta**

Cuando crea un gráfico que no depende de ningún eje, como un gráfico circular, las etiquetas de datos del gráfico pueden quedar demasiado cerca de su borde. En tal caso, debe ajustar la ubicación de la etiqueta de datos para que las líneas guía se muestren claramente.

Este código C++ le muestra cómo ajustar la ubicación de la etiqueta en un gráfico circular:
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

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se superpongan en gráficos densos?**

Combine la colocación automática de etiquetas, líneas guía y un tamaño de fuente reducido; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para los puntos extremos/clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta coherente al exportar a PDF/imagenes?**

Establezca explícitamente las fuentes (familia, tamaño) y verifique que la fuente esté disponible en el lado de renderizado para evitar sustituciones.