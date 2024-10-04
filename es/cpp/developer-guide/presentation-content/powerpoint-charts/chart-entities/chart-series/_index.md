---
title: Series de Gráficos
type: docs
url: /cpp/chart-series/
---

Una serie es una fila o columna de números trazados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer Superposición de Series de Gráficos**

Con el método [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb), puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series padre: esta es una proyección de la propiedad del grupo apropiado.

Utiliza el método `get_ParentSeriesGroup()::set_Overlap()` para establecer tu valor preferido para `Overlap`. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Agrega un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie de gráfico.
1. Accede al `ParentSeriesGroup` de la serie de gráfico y establece tu valor de superposición preferido para la serie. 
1. Escribe la presentación modificada en un archivo PPTX.

Este código C++ te muestra cómo establecer la superposición para una serie de gráficos:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Agrega el gráfico
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Establece la superposición de la serie
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Escribe el archivo de presentación en disco
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Cambiar el Color de la Serie**
Aspose.Slides para C++ te permite cambiar el color de una serie de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Agrega un gráfico en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar. 
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código C++ te muestra cómo cambiar el color de una serie:

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

## **Cambiar el Color de la Categoría de la Serie**
Aspose.Slides para C++ te permite cambiar el color de la categoría de una serie de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Agrega un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código en C++ te muestra cómo cambiar el color de la categoría de una serie:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Cambiar el Nombre de la Serie** 

Por defecto, los nombres de leyenda para un gráfico son los contenidos de las celdas encima de cada columna o fila de datos. 

En nuestro ejemplo (imagen de muestra), 

* las columnas son *Serie 1, Serie 2,* y *Serie 3*;
* las filas son *Categoría 1, Categoría 2, Categoría 3,* y *Categoría 4.* 

Aspose.Slides para C++ te permite actualizar o cambiar el nombre de una serie en sus datos de gráfico y leyenda. 

Este código C++ te muestra cómo cambiar el nombre de una serie en sus datos de gráfico `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"Nuevo nombre"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Este código C++ te muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"Nuevo nombre"));
```

## **Establecer Color de Relleno de la Serie de Gráficos**

Aspose.Slides para C++ te permite establecer el color de relleno automático para las series de gráficos dentro de un área de trama de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Agrega un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType::ClusteredColumn`).
1. Accede a la serie de gráficos y establece el color de relleno en Automático.
1. Guarda la presentación en un archivo PPTX.

Este código C++ te muestra cómo establecer el color de relleno automático para una serie de gráficos:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Crea un gráfico de columnas agrupadas
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Establece el formato de relleno de la serie en automático
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Escribe el archivo de presentación en disco
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Establecer Colores de Relleno Invertidos de las Series de Gráficos**
Aspose.Slides permite establecer el color de relleno invertido para las series de gráficos dentro de un área de trama de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Agrega un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType::ClusteredColumn`).
1. Accede a la serie de gráficos y establece el color de relleno en invertir.
1. Guarda la presentación en un archivo PPTX.

Este código C++ demuestra la operación:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Agrega nuevas series y categorías
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Serie 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Categoría 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Categoría 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Categoría 3")));

// Toma la primera serie de gráficos y poblala con sus datos.
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


## **Establecer Invertir las Series Cuando el Valor es Negativo**
Aspose.Slides permite establecer inversiones a través de los métodos `IChartDataPoint::set_InvertIfNegative()` y `ChartDataPoint.set_InvertIfNegative()`. Cuando se establece una inversión utilizando los métodos, el punto de datos invierte sus colores cuando obtiene un valor negativo. 

Este código C++ demuestra la operación:

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

## **Limpiar Datos de Puntos de Datos Específicos**
Aspose.Slides para C++ te permite limpiar los datos de `DataPoints` para una serie de gráficos específica de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Obtén la referencia de un gráfico a través de su índice.
4. Itera a través de todos los `DataPoints` del gráfico y establece `XValue` y `YValue` en nulo.
5. Limpia todos los `DataPoints` para una serie de gráficos específica.
6. Escribe la presentación modificada en un archivo PPTX.

Este código C++ demuestra la operación:

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

## **Establecer Ancho de Espacio de la Serie**
Aspose.Slides para C++ te permite establecer el Ancho de Espacio de una serie a través del método **`set_GapWidth()`** de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Accede a cualquier serie de gráficos.
1. Establece la propiedad `GapWidth`.
1. Escribe la presentación modificada en un archivo PPTX.

Este código en C++ te muestra cómo establecer el Ancho de Espacio de una serie:

```cpp
// Crea una presentación vacía 
auto presentation = System::MakeObject<Presentation>();

// Accede a la primera diapositiva de la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// Agrega un gráfico con datos predeterminados
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Establece el índice de la hoja de datos del gráfico
int32_t worksheetIndex = 0;

// Obtiene la hoja de datos del gráfico
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Agrega series
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Serie 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Serie 2")), chart->get_Type());

// Agrega Categorías
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Categoría 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Categoría 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Categoría 3")));

// Toma la segunda serie de gráficos
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Población de los datos de la serie
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