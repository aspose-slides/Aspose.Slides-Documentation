---
title: Crear Gráficos de Presentaciones de PowerPoint en C++
linktitle: Crear Gráfico
type: docs
weight: 10
url: /es/cpp/create-chart/
keywords: "Crear gráfico, gráfico disperso, gráfico de sectores, gráfico de mapa de árbol, gráfico de acciones, gráfico de caja y bigotes, gráfico de histograma, gráfico de embudo, gráfico de sol naciente, gráfico multicategoría, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Crear gráfico en presentación de PowerPoint en C++"
---

## **Crear Gráfico**

Los gráficos ayudan a las personas a visualizar rápidamente los datos y obtener información que puede no ser obvia a partir de una tabla o una hoja de cálculo.

**¿Por qué crear gráficos?**

Usando gráficos, puedes

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* exponer patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o con respecto a una unidad de medida específica
* detectar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc.
* comunicar o presentar datos complejos

En PowerPoint, puedes crear gráficos a través de la función de inserción, que proporciona plantillas utilizadas para diseñar muchos tipos de gráficos. Usando Aspose.Slides, puedes crear gráficos regulares (basados en tipos de gráficos populares) y gráficos personalizados.

{{% alert color="primary" %}} 

Para permitirte crear gráficos, Aspose.Slides proporciona la clase de enumeración [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) dentro del espacio de nombres [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/). Los valores de esta clase de enumeración corresponden a diferentes tipos de gráficos.

{{% /alert %}} 

### **Creando Gráficos Normales**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con algunos datos y especifica tu tipo de gráfico preferido.
1. Agrega un título para el gráfico.
1. Accede a la hoja de cálculo de datos del gráfico.
1. Limpia todas las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega algunos nuevos datos de gráfico para las series del gráfico.
1. Agrega un color de relleno para las series del gráfico.
1. Agrega etiquetas para las series del gráfico.
1. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo crear un gráfico normal:

```c++
// La ruta al directorio de documentos.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//Instancia una clase de presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Agrega un gráfico con datos predeterminados
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Establece el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtiene la hoja de datos del gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Establece el título del gráfico
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Título de Muestra");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Elimina las series y categorías generadas por defecto
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Agrega una nueva serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Serie 2")), chart->get_Type());

	// Agrega categorías
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Categoría 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Categoría 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Categoría 3")));

	
	// Toma la primera serie del gráfico
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Población de los datos de la serie
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Establece el color de relleno para la serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Toma la segunda serie del gráfico
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Población de los datos de la serie
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Establece el color de relleno para la serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// La primera etiqueta se establece para mostrar el nombre de la categoría
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Muestra el valor para la tercera etiqueta
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Creando Gráficos Dispersos**
Los gráficos dispersos (también conocidos como gráficos dispersos o gráficos x-y) se utilizan a menudo para verificar patrones o demostrar correlaciones entre dos variables.

Es posible que desees usar un gráfico disperso cuando

* tengas datos numéricos emparejados
* tengas 2 variables que se emparejan bien
* quieras determinar si 2 variables están relacionadas
* tengas una variable independiente que tiene múltiples valores para una variable dependiente

Este código C++ te muestra cómo crear un gráfico disperso con una serie diferente de marcadores:

```c++
// La ruta al directorio de documentos.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//Instancia una clase de presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Agrega un gráfico con datos predeterminados
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Establece el título del gráfico
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Título de Muestra");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Elimina las series generadas por defecto 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Establece el índice para la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtiene la hoja de datos del gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Agrega una nueva serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Serie 2")), chart->get_Type());

	// Toma la primera serie del gráfico
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Agrega un nuevo punto (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Agrega un nuevo punto (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Edita el tipo de serie
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Cambia el marcador de la serie del gráfico
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Toma la segunda serie del gráfico
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Agrega un nuevo punto (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Agrega un nuevo punto (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Agrega un nuevo punto (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Agrega un nuevo punto (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Cambia el marcador de la serie del gráfico
	series->get_Marker()->set_Size (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Establece el borde del sector
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width (3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Establece el borde del sector
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Establece el borde del sector
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Crea las etiquetas personalizadas para cada categoría de la nueva serie
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

	// Muestra las líneas de líder para el gráfico
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Establece el ángulo de rotación para sectores de gráficos de pastel
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Creando Gráficos de Pastel**
Los gráficos de pastel son los mejores para mostrar la relación parte-todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si tus datos contienen muchas partes o etiquetas, es posible que desees considerar usar un gráfico de barras en su lugar.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Pie`).
1. Accede al libro de datos del gráfico IChartDataWorkbook.
1. Limpia las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Agrega nuevos puntos para gráficos y agrega colores personalizados para los sectores del gráfico de pastel.
1. Establece etiquetas para las series.
1. Establece líneas de líder para las etiquetas de las series.
1. Establece el ángulo de rotación para los sectores del gráfico de pastel.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ muestra cómo crear un gráfico de pastel:

```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/PieChart_out.pptx";

	//Instancia una clase de Presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Agrega un gráfico con datos predeterminados
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Establece el título del gráfico
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Título de Muestra");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Elimina las series y categorías generadas por defecto
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Establece el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtiene la hoja de datos del gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Agrega categorías
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Primer Trimestre")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Segundo Trimestre")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Tercer Trimestre")));

	// Agrega una nueva serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());
	
	// Toma la primera serie del gráfico
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Población de los datos de la serie
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Establece el borde del sector
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width(3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Establece el borde del sector
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width(3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Establece el borde del sector
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width(2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Crea etiquetas personalizadas para cada una de las categorías para la nueva serie
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

	// Establece la serie para mostrar líneas de líder para el gráfico
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Establece el ángulo de rotación para los sectores del gráfico circular
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Creando Gráficos de Líneas**

Los gráficos de líneas (también conocidos como gráficos de líneas) son los mejores para situaciones en las que deseas demostrar cambios en el valor a lo largo del tiempo. Usando un gráfico de líneas, puedes comparar muchos datos a la vez, rastrear cambios y tendencias a lo largo del tiempo, resaltar anomalías en las series de datos, etc.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType::Line`).
1. Accede al libro de datos del gráfico IChartDataWorkbook.
1. Limpia las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ muestra cómo crear un gráfico de líneas:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

De forma predeterminada, los puntos en un gráfico de líneas están unidos por líneas continuas rectas. Si deseas que los puntos estén unidos por guiones en su lugar, puedes especificar tu tipo de guion preferido de esta manera:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Creando Gráficos de Mapa**

Un gráfico de mapa es una visualización de un área que contiene datos. Los gráficos de mapa son los mejores para comparar datos o valores en regiones geográficas.

Este código C++ muestra cómo crear un gráfico de mapa:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Creando Gráficos de Embudo**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.Funnel).
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ muestra cómo crear un gráfico de embudo:

```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/FunnelChart_out.pptx";

	//Instancia una clase de Presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Categoría 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Categoría 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Categoría 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Categoría 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Categoría 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Categoría 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));

	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Creando Gráficos de Árbol**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.TreeMap`).
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ muestra cómo crear un gráfico de mapa de árbol:

```c++
// La ruta al directorio de documentos.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//Instancia una clase de Presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Rama 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Hoja1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Tallo1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Rama1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Hoja2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Hoja3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Tallo2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Hoja4")));

	// Rama 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Hoja5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Tallo3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Rama2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Hoja6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Hoja7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Tallo4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Hoja8")));

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

	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Creando Gráficos de Acciones**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.OpenHighLowClose).
1. Accede al libro de datos del gráfico IChartDataWorkbook.
1. Limpia las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Especifica el formato de HiLowLines.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ muestra cómo crear un gráfico de acciones:

```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/AddStockChart_out.pptx";

	//Instancia una clase de Presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Agrega un gráfico con datos predeterminados
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Establece el índice para la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtiene la hoja de datos del gráfico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Elimina las series y categorías generadas por defecto
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Agrega categorías
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Agrega nuevas series
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Abrir")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Alto")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Bajo")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Cerrar")), chart->get_Type());


	// Toma la primera serie del gráfico
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Población de los datos de la primera serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Población de los datos de la segunda serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Población de los datos de la tercera serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Población de los datos de la cuarta serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Establece el grupo de series
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Creando Gráficos de Caja y Bigotes**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.BoxAndWhisker).
1. Accede al libro de datos IChartDataWorkbook.
1. Limpia las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega datos de gráfico para las series del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ muestra cómo crear un gráfico de caja y bigotes:

```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	//Instancia una clase de Presentación que representa un archivo PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Categoría 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Categoría 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Categoría 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Categoría 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Categoría 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Categoría 6")));

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


	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Creando Gráficos Combinados**

Un gráfico combinado (o gráfico combo) es un gráfico que combina dos o más gráficos en un solo gráfico. Tal gráfico te permite resaltar, comparar o revisar diferencias entre dos (o más) conjuntos de datos. De esta manera, ves la relación (si la hay) entre los conjuntos de datos.

Este código C++ muestra cómo crear un gráfico combinado en PowerPoint:

```c++
void CreateComboChart()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
    System::SharedPtr<IChart> chart = CreateChart(pres->get_Slide(0));
    AddFirstSeriesToChart(chart);
    AddSecondSeriesToChart(chart);
    pres->Save(u"combo-chart.pptx", SaveFormat::Pptx);
}

System::SharedPtr<IChart> CreateChart(System::SharedPtr<ISlide> slide)
{
    System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 400.0f);
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartSeriesCollection> seriesCollection = chartData->get_Series();
    System::SharedPtr<IChartCategoryCollection> categories = chartData->get_Categories();

    seriesCollection->Clear();
    categories->Clear();

    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(u"Serie 1")), chart->get_Type());
    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(u"Serie 2")), chart->get_Type());

    categories->Add(workbook->GetCell(worksheetIndex, 1, 0, System::ExplicitCast<System::Object>(u"Categoría 1")));
    categories->Add(workbook->GetCell(worksheetIndex, 2, 0, System::ExplicitCast<System::Object>(u"Categoría 2")));
    categories->Add(workbook->GetCell(worksheetIndex, 3, 0, System::ExplicitCast<System::Object>(u"Categoría 3")));

    System::SharedPtr<IChartDataPointCollection> dataPoints = chartData->get_ChartSeries(0)->get_DataPoints();

    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, System::ExplicitCast<System::Object>(20)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, System::ExplicitCast<System::Object>(50)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, System::ExplicitCast<System::Object>(30)));

    dataPoints = chartData->get_ChartSeries(1)->get_DataPoints();

    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, System::ExplicitCast<System::Object>(30)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, System::ExplicitCast<System::Object>(10)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, System::ExplicitCast<System::Object>(60)));

    return chart;
}

void AddFirstSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 3, System::ExplicitCast<System::Object>(u"Serie 3")), ChartType::ScatterWithSmoothLines);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(3)), workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(5)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(7)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 3, System::ExplicitCast<System::Object>(20)), workbook->GetCell(worksheetIndex, 2, 4, System::ExplicitCast<System::Object>(12)));

    series->set_PlotOnSecondAxis(true);
}

void AddSecondSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 5, System::ExplicitCast<System::Object>(u"Serie 4")), ChartType::ScatterWithStraightLinesAndMarkers);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(5)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(2)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 5, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 6, System::ExplicitCast<System::Object>(7)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 5, System::ExplicitCast<System::Object>(15)), workbook->GetCell(worksheetIndex, 2, 6, System::ExplicitCast<System::Object>(12)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 3, 5, System::ExplicitCast<System::Object>(12)), workbook->GetCell(worksheetIndex, 3, 6, System::ExplicitCast<System::Object>(9)));

    series->set_PlotOnSecondAxis(true);
}
```

## **Actualizando Gráficos**

1. Instancia una clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que representa la presentación que contiene el gráfico.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Recorre todas las formas para encontrar el gráfico deseado.
4. Accede a la hoja de datos del gráfico.
5. Modifica los datos de la serie del gráfico cambiando los valores de la serie.
6. Agrega una nueva serie y puebla los datos en ella.
7. Escribe la presentación modificada como un archivo PPTX.

Este código C++ muestra cómo actualizar un gráfico:

```c++
// Instancia una clase de Presentación que representa un archivo PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Accede a la primera diapositiva
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agrega un gráfico con datos predeterminados
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Establece el índice para la hoja de datos del gráfico
int32_t defaultWorksheetIndex = 0;

// Obtiene la hoja de datos del gráfico
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Cambia el nombre de la categoría del gráfico
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Categoría Modificada 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Categoría Modificada 2"));

// Toma la primera serie del gráfico
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Actualiza los datos de la serie
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"Nueva_Serie1"));
// Modifica el nombre de la serie
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Toma la segunda serie del gráfico
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Ahora actualizando los datos de la serie
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"Nueva_Serie2"));
// Modifica el nombre de la serie
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Ahora, agregando una nueva serie
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Serie 3")), chart->get_Type());

// Toma la tercera serie del gráfico
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Ahora poblando los datos de la serie
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Guarda la presentación con el gráfico
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Estableciendo el Rango de Datos para Gráficos**

1. Abre una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que contiene el gráfico.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Recorre todas las formas para encontrar el gráfico deseado.
4. Accede a los datos del gráfico y establece el rango.
5. Guarda la presentación modificada como un archivo PPTX.

Este código C++ muestra cómo establecer el rango de datos para un gráfico:

```cpp
// La ruta al directorio de documentos.
String dataDir = GetDataPath();

// Instancia una clase de Presentación que representa un archivo PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Accede a la primera diapositiva y agrega un gráfico con datos predeterminados
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Hoja1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **Usando Marcadores Predeterminados en Gráficos**

Cuando usas un marcador predeterminado en gráficos, cada serie de gráficos obtiene diferentes símbolos de marcador predeterminados automáticamente.

Este código C++ muestra cómo establecer un marcador de serie de gráfico automáticamente:

```cpp
// La ruta al directorio de documentos.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Serie 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Serie 2")), chart->get_Type());

// Toma la segunda serie del gráfico
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// Población de los datos de la segunda serie
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```