---
title: Administrar series de datos de gráficos en presentaciones usando C++
linktitle: Series de datos
type: docs
url: /es/cpp/chart-series/
keywords:
- series de gráficos
- superposición de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo administrar series de gráficos en C++ para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

Una serie es una fila o columna de números representados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie de datos**

Con el método [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series principal: es una proyección de la propiedad correspondiente del grupo.

Utiliza el método `get_ParentSeriesGroup()::set_Overlap()` para establecer el valor deseado de `Overlap`.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Añade un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie del gráfico.
1. Accede al `ParentSeriesGroup` de la serie del gráfico y establece el valor de superposición deseado para la serie.
1. Guarda la presentación modificada en un archivo PPTX.

Este código en C++ muestra cómo establecer la superposición para una serie de un gráfico:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Establece la superposición de la serie
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```


## **Cambiar el color de la serie de datos**

Aspose.Slides for C++ permite cambiar el color de una serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Añade un gráfico en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar.
1. Establece el tipo de relleno y el color de relleno que prefieras.
1. Guarda la presentación modificada.

Este código en C++ muestra cómo cambiar el color de una serie:
```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Cambiar el color de la categoría de una serie de datos**

Aspose.Slides for C++ permite cambiar el color de una categoría de serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Añade un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece el tipo de relleno y el color de relleno que prefieras.
1. Guarda la presentación modificada.

Este código en C++ muestra cómo cambiar el color de una categoría de serie:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Cambiar el nombre de la serie de datos**

Por defecto, los nombres de leyenda de un gráfico son el contenido de las celdas situadas encima de cada columna o fila de datos.

En nuestro ejemplo (imagen de muestra),

* las columnas son *Series 1, Series 2,* y *Series 3*;
* las filas son *Category 1, Category 2, Category 3,* y *Category 4.*

Aspose.Slides for C++ permite actualizar o cambiar el nombre de una serie en los datos del gráfico y en la leyenda.

Este código en C++ muestra cómo cambiar el nombre de una serie en su `ChartDataWorkbook`:
```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


Este código en C++ muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```


## **Establecer el color de relleno de la serie de datos**

Aspose.Slides for C++ permite establecer el color de relleno automático para las series de un gráfico dentro del área de trazado de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva mediante su índice.
1. Añade un gráfico con datos predeterminados basado en el tipo que prefieras (en el ejemplo usamos `ChartType::ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno a Automático.
1. Guarda la presentación en un archivo PPTX.

Este código en C++ muestra cómo establecer el color de relleno automático para una serie de un gráfico:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Crea un gráfico de columnas agrupadas
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Establece el formato de relleno de la serie a automático
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Escribe el archivo de presentación en disco
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```


## **Establecer colores de relleno invertidos para la serie de datos**

Aspose.Slides permite establecer el color de relleno invertido para las series de un gráfico dentro del área de trazado de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva mediante su índice.
1. Añade un gráfico con datos predeterminados basado en el tipo que prefieras (en el ejemplo usamos `ChartType::ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno a invertido.
1. Guarda la presentación en un archivo PPTX.

Este código en C++ demuestra la operación:
```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Añade nuevas series y categorías
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Toma la primera serie del gráfico y rellena sus datos de serie.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```


## **Establecer color de relleno invertido para una serie de gráfico**

Aspose.Slides permite establecer inversiones mediante los métodos `IChartDataPoint::set_InvertIfNegative()` y `ChartDataPoint.set_InvertIfNegative()`. Cuando se establece una inversión usando estos métodos, el punto de datos invierte sus colores al recibir un valor negativo.

Este código en C++ demuestra la operación:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Borrar valores específicos de puntos de datos**

Aspose.Slides for C++ permite borrar los datos de `DataPoints` de una serie de gráfico específica de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva mediante su índice.
3. Obtén la referencia de un gráfico mediante su índice.
4. Itera a través de todos los `DataPoints` del gráfico y establece `XValue` y `YValue` a null.
5. Borra todos los `DataPoints` de la serie de gráfico específica.
6. Guarda la presentación modificada en un archivo PPTX.

Este código en C++ demuestra la operación:
```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```


## **Establecer el ancho del espacio entre series de datos**

Aspose.Slides for C++ permite establecer el ancho del espacio entre series mediante el método **`set_GapWidth()`** de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Accede a la primera diapositiva.
1. Añade un gráfico con datos predeterminados.
1. Accede a cualquier serie del gráfico.
1. Establece la propiedad `GapWidth`.
1. Guarda la presentación modificada en un archivo PPTX.

Este código en C++ muestra cómo establecer el ancho del espacio entre series:
```cpp
// Crea una presentación vacía 
auto presentation = System::MakeObject<Presentation>();

// Accede a la primera diapositiva de la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// Añade un gráfico con datos predeterminados
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Establece el índice de la hoja de datos del gráfico
int32_t worksheetIndex = 0;

// Obtiene la hoja de cálculo de datos del gráfico
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Añade series
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Añade categorías
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Obtiene la segunda serie del gráfico
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Rellena los datos de la serie
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Establece el valor de GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Guarda la presentación en disco
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un gráfico único?**

Aspose.Slides no impone un límite fijo en el número de series que añadas. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para tu aplicación.

**¿Qué pasa si las columnas dentro de un agrupamiento están demasiado juntas o demasiado separadas?**

Ajusta la configuración de ancho del espacio para esa serie (o su grupo de series principal). Aumentar el valor ensancha el espacio entre columnas, mientras que disminuirlo las acerca más.