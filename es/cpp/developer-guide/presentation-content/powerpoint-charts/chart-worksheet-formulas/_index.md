---
title: Aplicar fórmulas de hoja de cálculo de gráficos en presentaciones usando C++
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/cpp/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
- hoja de trabajo de gráfico
- fórmula de gráfico
- fórmula de hoja de trabajo
- fórmula de hoja de cálculo
- libro de datos del gráfico
- cálculo de fórmula
- cultura preferida
- fórmula específica de cultura
- DBCS
- constante lógica
- constante numérica
- constante de cadena
- constante de error
- operador aritmético
- operador de comparación
- estilo A1
- estilo R1C1
- función predefinida
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aplicar fórmulas al estilo de Excel en las hojas de cálculo de gráficos de Aspose.Slides para C++, recalcular valores y usar los resultados en gráficos de PowerPoint."
---
## **Visión general**

Los gráficos de PowerPoint normalmente almacenan sus datos de origen en una hoja de cálculo incrustada. En Aspose.Slides para C++, puedes acceder a esa hoja mediante el libro de datos del gráfico, escribir valores de entrada, asignar fórmulas a celdas, calcular las fórmulas admitidas y utilizar las celdas calculadas como datos del gráfico.

Este artículo explica todo el flujo de trabajo de fórmulas: crear un gráfico, rellenar su hoja de cálculo, asignar fórmulas en estilo A1 o R1C1, volver a calcularlas, leer los valores calculados, conectar esas celdas a una serie del gráfico y guardar la presentación. También describe la sintaxis de fórmulas admitida, el subconjunto de funciones incorporadas, los valores almacenados, las fórmulas no compatibles y los errores específicos de hojas de cálculo.

## **Hojas de cálculo de gráficos y fórmulas**

Una hoja de cálculo de gráfico contiene las categorías, los nombres de serie y los valores utilizados por un gráfico. En PowerPoint, puedes inspeccionar la hoja abriendo el editor de datos del gráfico:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

En Aspose.Slides, la hoja se expone a través de la interfaz [IChartDataWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/). Usa [IChartDataCell::set_Formula](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/set_formula/) para fórmulas en estilo A1 y [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) para fórmulas en estilo R1C1. Después de cambiar celdas de entrada o fórmulas, llama a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) para volver a calcular las fórmulas admitidas y actualizar los valores de celda correspondientes.

Una celda calculada sigue exponiendo su resultado a través de [IChartDataCell::get_Value](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/get_value/). Esto es importante cuando necesitas inspeccionar el resultado de una fórmula en código o usar la celda como punto de datos del gráfico.

## **Crear un gráfico y calcular fórmulas de la hoja**

El siguiente ejemplo demuestra un flujo de trabajo completo. Crea un gráfico de columnas agrupadas, elimina los datos de ejemplo, escribe valores trimestrales de ingresos y gastos, calcula el beneficio con fórmulas, lee los resultados, usa las celdas calculadas como valores del gráfico y guarda la presentación.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Los puntos de datos del gráfico hacen referencia a `D2:D4`, por lo que el gráfico utiliza los valores de beneficio calculados. No hay una llamada separada para refrescar el gráfico en este flujo: recalcúla el libro primero, luego usa o guarda los datos del gráfico que apuntan a las celdas calculadas.

## **Usar fórmulas en estilo A1**

La notación A1 identifica columnas con letras y filas con números. Asigna expresiones en estilo A1 mediante [IChartDataCell::set_Formula](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Formas de referencia A1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `A2` | `$A$2` | `A$2`, `$A2` |
| Fila | `2:2` | `$2:$2` | — |
| Columna | `A:A` | `$A:$A` | — |
| Rango | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Las referencias relativas pueden cambiar cuando una fórmula se mueve o copia en una aplicación de hoja de cálculo. Las referencias absolutas fijan ambas coordenadas, mientras que las referencias mixtas fijan solo una fila o una columna.

## **Usar fórmulas en estilo R1C1**

La notación R1C1 identifica tanto filas como columnas numéricamente. Las referencias relativas usan desplazamientos entre corchetes. Asigna esta sintaxis mediante [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Formas de referencia R1C1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Fila | `R[2]` | `R2` | — |
| Columna | `C[3]` | `C3` | — |
| Rango | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por ejemplo, en la celda `D2`, `RC[-2]` significa la celda en la misma fila dos columnas a la izquierda (`B2`).

## **Constantes y operadores de fórmulas**

El evaluador de fórmulas incorporado admite valores lógicos, literales numéricos, cadenas, valores de error de hoja de cálculo, operadores aritméticos y operadores de comparación.

### **Constantes y literales**

| Tipo | Ejemplos | Observaciones |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Puede usarse directamente en expresiones lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Se admiten notación común y notación científica. |
| Cadena | `"abc"`, `"2/3/2020 12:00"` | Los literales de texto se encierran entre comillas dobles dentro de la fórmula. |
| Resultado de error | `#DIV/0!`, `#N/A`, `#REF!` | Una fórmula válida puede evaluarse a un valor de error de hoja de cálculo en lugar de un resultado normal. |

Este ejemplo usa varios tipos de constante:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Falso
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Operadores aritméticos**

| Operador | Significado | Ejemplo |
|---|---|---|
| `+` | Suma o signo positivo unario | `2+3` |
| `-` | Resta o negación | `2-3`, `-3` |
| `*` | Multiplicación | `2*3` |
| `/` | División | `2/3` |
| `%` | Porcentaje | `30%` |
| `^` | Exponenciación | `2^3` |

Usa paréntesis para hacer explícito el orden de evaluación, por ejemplo `(A2+B2)*C2`.

### **Operadores de comparación**

Las expresiones de comparación devuelven valores lógicos.

| Operador | Significado | Ejemplo |
|---|---|---|
| `=` | Igual a | `A2=3` |
| `<>` | Diferente de | `A2<>3` |
| `>` | Mayor que | `A2>3` |
| `>=` | Mayor o igual que | `A2>=3` |
| `<` | Menor que | `A2<3` |
| `<=` | Menor o igual que | `A2<=3` |

## **Funciones predefinidas compatibles**

Aspose.Slides incluye un evaluador de fórmulas incorporado para hojas de cálculo de gráficos, pero no es un motor de cálculo completo de Excel. El conjunto de funciones documentado está limitado a las siguientes. No asumas que una función arbitraria de Excel pueda ser recalculada por [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Función | Propósito o forma admitida | Ejemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Redondear un número hacia arriba al múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleccionar un valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Unir valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Unir valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crear un valor de fecha usando el sistema de fechas 1900 | `DATE(2026,8,19)` |
| `DAYS` | Devolver el número de días entre fechas | `DAYS(B2,A2)` |
| `FIND` | Buscar un valor de texto dentro de otro | `FIND("-",A2)` |
| `FINDB` | Búsqueda de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referencia | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vectorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vectorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Sumar valores | `SUM(B2:B5)` |
| `VLOOKUP` | Búsqueda vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Las restricciones mostradas en la tabla son significativas: `INDEX` se documenta en forma de referencia, mientras que `LOOKUP` y `MATCH` se documentan en sus formas vectoriales. `DATE` usa el sistema de fechas 1900. Las características y funciones que no aparecen aquí deben considerarse no compatibles con el evaluador de fórmulas de Aspose.Slides, salvo que estén documentadas por separado.

## **Calcular fórmulas con una cultura preferida**

Algunas funciones del libro de datos del gráfico interpretan texto según reglas específicas de cultura. Esto es especialmente importante para funciones destinadas a idiomas que usan juegos de caracteres de doble byte (DBCS). Para calcular esas fórmulas correctamente, crea [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/), configura [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/es/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) mediante [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), y luego carga la presentación.

El siguiente ejemplo selecciona la cultura japonesa, abre una presentación con las opciones de carga configuradas y llama a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) para cada libro de datos del gráfico:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

La cultura preferida forma parte de la configuración de carga de la presentación, por lo que debes especificarla antes de crear la instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). Usa la cultura esperada por las fórmulas del libro; por ejemplo, `ja-JP` para fórmulas que deben seguir las reglas de cálculo DBCS japonesas.

## **Recalculo y valores almacenados**

Los archivos de hoja de cálculo suelen almacenar tanto una fórmula como su último valor calculado. Aspose.Slides puede leer un valor almacenado desde [IChartDataCell::get_Value](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/get_value/) cuando se carga una presentación y los datos del gráfico no han sido modificados.

Después de cambiar celdas de entrada o fórmulas, no confíes en un resultado almacenado antiguo. Llama a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) antes de leer valores calculados o guardar datos del gráfico que dependan de ellos.

Para fórmulas fuera del subconjunto admitido, Aspose.Slides puede no ser capaz de analizar la fórmula o determinar sus dependencias. Si el libro ha sido modificado, el valor almacenado previo ya no es fiable. En esa situación, leer el valor de una celda con datos no compatibles puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Si tu gráfico depende de funciones de Excel que Aspose.Slides no evalúa, calcula esas fórmulas con un motor de hoja de cálculo que sí lo haga y escribe los valores resultantes de nuevo en el libro del gráfico. No sustituyas fórmulas no compatibles por valores adivinados.

## **Manejar errores de fórmula**

Existen dos tipos diferentes de problemas a distinguir.

Una fórmula puede ser válida pero producir un resultado de error de hoja de cálculo como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. En este caso, el token de error es un resultado de celda y puede devolverse a través de [IChartDataCell::get_Value](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Una fórmula también puede fallar en el análisis, la referencia, la dependencia o el nivel de datos soportados. Aspose.Slides proporciona excepciones específicas de hoja de cálculo para estos casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) y [CellUnsupportedDataException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Cuando las fórmulas provienen de plantillas o de entrada del usuario, maneja estas excepciones alrededor del recálculo y el acceso al valor:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Manejar una fórmula inválida.
}
catch (CellInvalidReferenceException&)
{
    // Manejar una referencia de celda inválida.
}
catch (CellCircularReferenceException&)
{
    // Manejar una referencia circular.
}
catch (CellUnsupportedDataException&)
{
    // Manejar datos de hoja de cálculo no compatibles.
}
```

## **Limitaciones prácticas**

El soporte de fórmulas en las hojas de cálculo de gráficos está pensado para un subconjunto definido de cálculos de hoja, no para una compatibilidad total con Excel. Ten en cuenta estas restricciones al diseñar un flujo de trabajo de informes:

- Usa solo las constantes, operadores, referencias y funciones documentadas cuando necesites que Aspose.Slides recalcule fórmulas.
- Recalcula después de cambiar celdas de las que dependen los resultados de las fórmulas.
- Trata los valores almacenados de presentaciones cargadas como instantáneas, no como sustitutos del recálculo tras ediciones.
- Prueba las fórmulas de plantillas existentes antes de confiar en sus valores calculados, sobre todo si usan funciones fuera de la lista documentada.
- Para fórmulas que requieran un motor completo de cálculo de hoja, calcúlalas externamente y luego actualiza el libro del gráfico con los valores resultantes.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre `set_Formula` y `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/set_formula/) almacena una expresión en estilo A1 como `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) almacena una expresión en estilo R1C1 como `RC[-2]-RC[-1]`. Usa la notación que mejor se adapte a cómo generas o copias las fórmulas.

**¿Debo leer la propia celda o su valor después del cálculo?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) devuelve un `IChartDataCell`. Para obtener el resultado calculado, lee el valor de esa celda mediante [IChartDataCell::get_Value](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/get_value/) después del recálculo.

**¿Cuándo debo llamar a `CalculateFormulas`?**

Llama a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) después de cambiar valores de entrada o fórmulas y antes de depender de los resultados calculados. Esto actualiza los valores de las fórmulas que el evaluador incorporado admite.

**¿Aspose.Slides soporta todas las funciones de Excel?**

No. El evaluador incorporado admite un subconjunto documentado de funciones. Las funciones fuera de ese subconjunto no deben asumirse como recalculables correctamente. Si necesitas compatibilidad total con fórmulas de Excel, realiza el cálculo con un motor de hoja de cálculo adecuado y escribe los valores finales en el libro del gráfico.

**¿Qué ocurre si una presentación cargada contiene una fórmula no compatible?**

Si los datos del gráfico no han cambiado, el libro puede seguir conteniendo un valor almacenado calculado previamente. Tras modificar los datos relacionados, ese valor almacenado puede ya no ser válido. Acceder a una celda cuya fórmula no puede ser manejada puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**¿Los valores de error de fórmula son lo mismo que las excepciones de C++?**

No. Un resultado como `#DIV/0!` es un valor de hoja de cálculo producido por un cálculo válido. Las excepciones como [CellInvalidFormulaException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/es/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) indican que la fórmula no puede procesarse de forma normal.

**¿Un gráfico se actualiza automáticamente cuando cambia una celda de fórmula?**

Una serie del gráfico puede hacer referencia a celdas del libro. Recalcúla el libro primero, luego guarda o renderiza la presentación. Si los puntos de datos del gráfico hacen referencia a las celdas calculadas, el gráfico usará esos valores actualizados; no se requiere un método de refresco de gráfico separado para este flujo.

**¿Los gráficos pueden usar un libro de Excel externo?**

Sí, los datos del gráfico pueden configurarse para usar un libro externo mediante la API de datos del gráfico. Sin embargo, el flujo de cálculo de fórmulas descrito en este artículo se refiere al libro de datos del gráfico y al subconjunto de fórmulas evaluadas por Aspose.Slides. No asumas que [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) proporciona recálculo completo de fórmulas arbitrarias en un archivo XLSX externo.

**¿Puedo usar fórmulas que referencien otra hoja de cálculo o libro?**

Pueden existir referencias al estilo Excel en los libros de gráficos, pero la evaluación de fórmulas está limitada por el analizador y el conjunto de funciones soportados. Si una referencia cruzada de hoja o externa es esencial, valida esa fórmula exacta con la versión de Aspose.Slides que vas a usar. Para flujos que requieran amplia compatibilidad de referencias de Excel, calcula el libro externamente y escribe los valores resueltos de nuevo en los datos del gráfico.

**¿Deben las cadenas de fórmula comenzar con `=`?**

Los ejemplos de la API de Aspose.Slides asignan expresiones como `B2-C2` o `SUM(B2:B5)` sin un `=` inicial. Usar esa forma mantiene las fórmulas generadas coherentes con los ejemplos documentados de la API.