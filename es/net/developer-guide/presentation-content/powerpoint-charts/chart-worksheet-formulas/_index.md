---
title: Aplicar fórmulas de hoja de cálculo en presentaciones en .NET
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/net/chart-worksheet-formulas/
keywords:
- hoja de cálculo de diagrama
- hoja de trabajo del diagrama
- fórmula de diagrama
- fórmula de hoja de cálculo
- fórmula de hoja de cálculo
- libro de datos del diagrama
- cálculo de fórmulas
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
- .NET
- C#
- Aspose.Slides
description: "Aplicar fórmulas al estilo Excel en las hojas de cálculo de diagramas de Aspose.Slides para .NET, recalcular valores y usar los resultados en diagramas de PowerPoint."
---
## **Visión general**

Los diagramas de PowerPoint normalmente almacenan sus datos origen en una hoja de cálculo incrustada. En Aspose.Slides for .NET, puedes acceder a esa hoja a través del libro de datos del diagrama, escribir valores de entrada, asignar fórmulas a celdas, calcular las fórmulas compatibles y usar las celdas calculadas como datos del diagrama.

Este artículo explica el flujo completo de fórmulas: crear un diagrama, rellenar su hoja, asignar fórmulas estilo A1 o R1C1, recalcularlas, leer los valores calculados, conectar esas celdas a una serie del diagrama y guardar la presentación. También describe la sintaxis de fórmulas admitida, el subconjunto de funciones incorporado, los valores almacenados, las fórmulas no compatibles y los errores específicos de la hoja de cálculo.

## **Hojas de cálculo del diagrama y fórmulas**

Una hoja de cálculo del diagrama contiene las categorías, nombres de series y valores usados por un diagrama. En PowerPoint, puedes inspeccionar la hoja abriendo el editor de datos del diagrama:

![Diagrama de PowerPoint con su hoja de cálculo incrustada abierta, mostrando datos de categorías y series](chart-worksheet-formulas_1.png)

En Aspose.Slides, la hoja se expone a través del [chart data workbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/). Usa la propiedad [Formula](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/formula/) para fórmulas estilo A1 y la propiedad [R1C1Formula](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/r1c1formula/) para fórmulas estilo R1C1. Después de cambiar celdas de entrada o fórmulas, llama a [CalculateFormulas](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) para recalcular las fórmulas compatibles y actualizar los valores correspondientes de las celdas.

Una celda calculada sigue exponiendo su resultado a través de la propiedad [Value](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/value/). Esto es importante cuando necesitas inspeccionar el resultado de una fórmula en código o usar la celda como punto de datos del diagrama.

## **Crear un diagrama y calcular fórmulas de la hoja**

El siguiente ejemplo muestra un flujo de trabajo completo. Crea un diagrama de columnas agrupadas, elimina los datos de ejemplo, escribe valores trimestrales de ingresos y gastos, calcula el beneficio con fórmulas, lee los resultados, usa las celdas calculadas como valores del diagrama y guarda la presentación.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Los puntos de datos del diagrama hacen referencia a `D2:D4`, por lo que el diagrama utiliza los valores de beneficio calculados. No hay una llamada separada para refrescar el diagrama en este flujo: recalcula el libro primero, luego usa o guarda los datos del diagrama que apuntan a las celdas calculadas.

## **Usar fórmulas estilo A1**

La notación A1 identifica columnas con letras y filas con números. Asigna expresiones estilo A1 mediante [IChartDataCell.Formula](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Formas de referencia A1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `A2` | `$A$2` | `A$2`, `$A2` |
| Fila | `2:2` | `$2:$2` | — |
| Columna | `A:A` | `$A:$A` | — |
| Rango | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Las referencias relativas pueden cambiar cuando una fórmula se mueve o copia en una aplicación de hoja de cálculo. Las referencias absolutas mantienen ambas coordenadas fijas, mientras que las referencias mixtas fijan solo una fila o una columna.

## **Usar fórmulas estilo R1C1**

La notación R1C1 identifica tanto filas como columnas numéricamente. Las referencias relativas usan desplazamientos entre corchetes. Asigna esta sintaxis mediante [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
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
| Lógico | `TRUE`, `FALSE` | Se pueden usar directamente en expresiones lógicas, por ejemplo `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Se admiten notación común y notación científica. |
| Cadena | `"abc"`, `"2/3/2020 12:00"` | Los literales de texto se encierran entre comillas dobles dentro de la fórmula. |
| Resultado de error | `#DIV/0!`, `#N/A`, `#REF!` | Una fórmula válida puede evaluar a un valor de error de hoja de cálculo en lugar de un resultado normal. |

Este ejemplo usa varios tipos de constantes:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Falso
var numericValue = workbook.GetCell(0, "C2").Value; // 1,5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0,003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
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

## **Funciones predefinidas admitidas**

Aspose.Slides incluye un evaluador de fórmulas incorporado para hojas de cálculo de diagramas, pero no es un motor de cálculo completo de Excel. El conjunto de funciones documentado está limitado a las siguientes. No asumas que una función arbitraria de Excel pueda recalcularse con [CalculateFormulas](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Función | Propósito o forma admitida | Ejemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Redondear un número hacia arriba al múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleccionar un valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concatenar valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concatenar valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crear un valor de fecha usando el sistema de fechas 1900 | `DATE(2026,8,19)` |
| `DAYS` | Devolver el número de días entre fechas | `DAYS(B2,A2)` |
| `FIND` | Encontrar un texto dentro de otro | `FIND("-",A2)` |
| `FINDB` | Búsqueda de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referencia | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vectorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vectorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Sumar valores | `SUM(B2:B5)` |
| `VLOOKUP` | Búsqueda vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Las restricciones mostradas en la tabla son significativas: `INDEX` está documentada en forma de referencia, mientras que `LOOKUP` y `MATCH` están documentadas en sus formas vectoriales. `DATE` usa el sistema de fechas 1900. Las características y funciones que no aparecen aquí deben considerarse no compatibles con el evaluador de fórmulas de Aspose.Slides, salvo que estén documentadas por separado.

## **Recalculación y valores almacenados**

Los archivos de hoja de cálculo suelen almacenar tanto una fórmula como su último valor calculado. Aspose.Slides puede leer un valor almacenado desde [IChartDataCell.Value](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/value/) cuando se carga una presentación y los datos del diagrama no se han modificado.

Después de cambiar celdas de entrada o fórmulas, no confíes en un resultado almacenado antiguo. Llama a [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) antes de leer los valores calculados o guardar los datos del diagrama que dependan de ellos.

Para fórmulas fuera del subconjunto admitido, Aspose.Slides puede no ser capaz de analizar la fórmula o establecer sus dependencias. Si el libro se ha modificado, el valor almacenado previamente ya no puede considerarse fiable. En esa situación, leer el valor de una celda con datos no compatibles puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Si tu diagrama depende de funciones de Excel que Aspose.Slides no evalúa, calcula esas fórmulas con un motor de hoja de cálculo que las admita y escribe los valores resultantes de vuelta en el libro del diagrama. No sustituyas fórmulas no compatibles por valores adivinados.

## **Gestionar errores de fórmula**

Hay dos tipos diferentes de problemas a distinguir.

Una fórmula puede ser válida pero producir un resultado de error de hoja de cálculo como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. En ese caso, el token de error es un resultado de celda y puede devolverse a través de `Value`.

Una fórmula también puede fallar en el nivel de análisis, referencia, dependencia o datos compatibles. Aspose.Slides proporciona excepciones específicas de hoja de cálculo para estos casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) y [CellUnsupportedDataException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Cuando las fórmulas provienen de plantillas o de la entrada del usuario, maneja estas excepciones alrededor de la recalculación y el acceso al valor:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Limitaciones prácticas**

El soporte de fórmulas en hojas de cálculo de diagramas está pensado para un subconjunto definido de cálculos de hoja, no para una compatibilidad completa con Excel. Ten en cuenta estas limitaciones al diseñar un flujo de trabajo de generación de informes:

- Usa solo las constantes, operadores, referencias y funciones documentadas cuando necesites que Aspose.Slides recalcule fórmulas.
- Recalcula después de cambiar celdas de las que dependen los resultados de las fórmulas.
- Trata los valores almacenados de presentaciones cargadas como instantáneas, no como sustituto de la recalculación después de ediciones.
- Prueba las fórmulas de plantillas existentes antes de confiar en sus valores calculados, sobre todo si usan funciones fuera de la lista documentada.
- Para fórmulas que requieran un motor completo de cálculo de hoja, calcúlalas externamente y luego actualiza el libro del diagrama con los valores resultantes.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre `Formula` y `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/formula/) almacena una expresión estilo A1 como `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/r1c1formula/) almacena una expresión estilo R1C1 como `RC[-2]-RC[-1]`. Utiliza la notación que mejor se ajuste a cómo generas o copias las fórmulas.

**¿Debo leer la propia celda o su valor después del cálculo?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/getcell/) devuelve un `IChartDataCell`. Para obtener el resultado calculado, lee la propiedad [Value](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/value/) de esa celda después de la recalculación.

**¿Cuándo debo llamar a `CalculateFormulas`?**

Llama a [CalculateFormulas](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) después de cambiar valores de entrada o fórmulas y antes de depender de los resultados calculados. Esto actualiza los valores de las fórmulas que el evaluador incorporado admite.

**¿Aspose.Slides admite todas las funciones de Excel?**

No. El evaluador incorporado admite un subconjunto documentado de funciones. No se debe asumir que las funciones fuera de ese subconjunto se recalculen correctamente. Si necesitas compatibilidad total con fórmulas de Excel, realiza el cálculo con un motor de hoja de cálculo adecuado y escribe los valores finales en el libro del diagrama.

**¿Qué ocurre si una presentación cargada contiene una fórmula no compatible?**

Si los datos del diagrama no han cambiado, el libro puede seguir conteniendo un valor almacenado calculado previamente. Tras modificar los datos relacionados, ese valor almacenado puede dejar de ser válido. Acceder a una celda cuya fórmula no pueda gestionarse puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**¿Los valores de error de fórmula son lo mismo que las excepciones .NET?**

No. Un resultado como `#DIV/0!` es un valor de hoja de cálculo producido por un cálculo válido. Las excepciones como [CellInvalidFormulaException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/es/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indican que la fórmula no puede procesarse de forma normal.

**¿Un diagrama se actualiza automáticamente cuando cambia una celda de fórmula?**

Una serie del diagrama puede hacer referencia a celdas del libro. Recalcula el libro primero, luego guarda o renderiza la presentación. Si los puntos de datos del diagrama hacen referencia a las celdas calculadas, el diagrama usará esos valores actualizados; no se requiere un método de refresco separado para este flujo.

**¿Los diagramas pueden usar un libro de Excel externo?**

Sí, los datos del diagrama pueden configurarse para usar un libro externo mediante la API de datos del diagrama. Sin embargo, el flujo de cálculo de fórmulas descrito en este artículo se refiere al libro de datos del diagrama y al subconjunto de fórmulas evaluado por Aspose.Slides. No asumas que [CalculateFormulas](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ofrece una recalculación completa de fórmulas arbitrarias en un archivo XLSX externo.

**¿Puedo usar fórmulas que hagan referencia a otra hoja de cálculo o a otro libro?**

Las referencias al estilo Excel pueden existir en los libros de diagramas, pero la evaluación de fórmulas está limitada por el analizador y el conjunto de funciones admitidos. Si una referencia cruzada de hoja o externa es esencial, verifica esa fórmula exacta con la versión de Aspose.Slides que uses. Para flujos que requieran una amplia compatibilidad de referencias de Excel, calcula el libro externamente y escribe los valores resueltos de vuelta en los datos del diagrama.

**¿Deben las cadenas de fórmula comenzar con `=`?**

Los ejemplos de la API de Aspose.Slides asignan expresiones como `B2-C2` o `SUM(B2:B5)` sin el `=` inicial. Usar esa forma mantiene las fórmulas generadas coherentes con los ejemplos documentados de la API.