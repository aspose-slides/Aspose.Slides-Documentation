---
title: Aplicar fórmulas de hoja de trabajo en presentaciones con Python
linktitle: Fórmulas de hoja de trabajo
type: docs
weight: 70
url: /es/python-net/chart-worksheet-formulas/
keywords:
- hoja de cálculo del gráfico
- hoja de trabajo del gráfico
- fórmula del gráfico
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
- Python
- Aspose.Slides
description: "Aplicar fórmulas al estilo Excel en las hojas de cálculo de gráficos de Aspose.Slides para Python via .NET, recalcular valores y usar los resultados en gráficos de PowerPoint."
---
## **Visión general**

Los gráficos de PowerPoint suelen almacenar sus datos fuente en una hoja de cálculo incrustada. En Aspose.Slides for Python via .NET, puedes acceder a esa hoja a través del libro de datos del gráfico, escribir valores de entrada, asignar fórmulas a celdas, calcular fórmulas compatibles y usar las celdas calculadas como datos del gráfico.

Este artículo explica el flujo completo de trabajo de fórmulas: crear un gráfico, rellenar su hoja de cálculo, asignar fórmulas en estilo A1 o R1C1, recalcularlas, leer los valores calculados, conectar esas celdas a una serie del gráfico y guardar la presentación. También describe la sintaxis de fórmulas admitida, el subconjunto de funciones integradas, valores en caché, fórmulas no compatibles y errores específicos de hojas de cálculo.

## **Hojas de cálculo de gráficos y fórmulas**

Una hoja de cálculo de gráfico contiene las categorías, nombres de series y valores utilizados por un gráfico. En PowerPoint, puedes inspeccionar la hoja abriendo el editor de datos del gráfico:

![Gráfico de PowerPoint con su hoja de cálculo incrustada abierta, mostrando datos de categorías y series](chart-worksheet-formulas_1.png)

En Aspose.Slides, la hoja está expuesta a través del [libro de datos del gráfico](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdataworkbook/). Usa la propiedad [formula](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/formula/) para fórmulas en estilo A1 y la propiedad [r1c1_formula](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) para fórmulas en estilo R1C1. Después de cambiar celdas de entrada o fórmulas, llama a [calculate_formulas](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) para recalcular las fórmulas compatibles y actualizar los valores de las celdas correspondientes.

Una celda calculada sigue exponiendo su resultado a través de la propiedad [value](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/value/). Esto es importante cuando necesitas inspeccionar el resultado de una fórmula en código o usar la celda como punto de datos del gráfico.

## **Crear un gráfico y calcular fórmulas de la hoja de cálculo**

El siguiente ejemplo muestra un flujo de trabajo de extremo a extremo. Crea un gráfico de columnas agrupadas, borra los datos de ejemplo, escribe valores trimestrales de ingresos y gastos, calcula el beneficio con fórmulas, lee los resultados, utiliza las celdas calculadas como valores del gráfico y guarda la presentación.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Los puntos de datos del gráfico hacen referencia a `D2:D4`, por lo que el gráfico utiliza los valores de beneficio calculados. No hay una llamada separada para actualizar el gráfico en este flujo: recalcule primero el libro y luego use o guarde los datos del gráfico que apuntan a las celdas calculadas.

## **Usar fórmulas en estilo A1**

La notación A1 identifica columnas con letras y filas con números. Asigna expresiones en estilo A1 a través de [IChartDataCell.formula](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Formas comunes de referencia A1 son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `A2` | `$A$2` | `A$2`, `$A2` |
| Fila | `2:2` | `$2:$2` | — |
| Columna | `A:A` | `$A:$A` | — |
| Rango | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Las referencias relativas pueden cambiar cuando una fórmula se mueve o copia en una aplicación de hoja de cálculo. Las referencias absolutas mantienen ambas coordenadas fijas, mientras que las referencias mixtas fijan solo una fila o una columna.

## **Usar fórmulas en estilo R1C1**

La notación R1C1 identifica filas y columnas numéricamente. Las referencias relativas usan desplazamientos entre corchetes. Asigna esta sintaxis a través de [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Formas comunes de referencia R1C1 son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Fila | `R[2]` | `R2` | — |
| Columna | `C[3]` | `C3` | — |
| Rango | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por ejemplo, en la celda `D2`, `RC[-2]` significa la celda en la misma fila dos columnas a la izquierda (`B2`).

## **Constantes y operadores de fórmula**

El evaluador de fórmulas integrado admite valores lógicos, literales numéricos, cadenas, valores de error de hoja de cálculo, operadores aritméticos y operadores de comparación.

### **Constantes y literales**

| Tipo | Ejemplos | Notas |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Puede usarse directamente en expresiones lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Se admiten notación común y notación científica. |
| Cadena | `"abc"`, `"2/3/2020 12:00"` | Los literales de texto van entre comillas dobles dentro de la fórmula. |
| Resultado de error | `#DIV/0!`, `#N/A`, `#REF!` | Una fórmula válida puede evaluarse a un valor de error de hoja de cálculo en lugar de un resultado normal. |

Este ejemplo usa varios tipos de constantes:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Falso
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
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

Utiliza paréntesis para hacer explícito el orden de evaluación, por ejemplo `(A2+B2)*C2`.

### **Operadores de comparación**

Las expresiones de comparación devuelven valores lógicos.

| Operador | Significado | Ejemplo |
|---|---|---|
| `=` | Igual a | `A2=3` |
| `<>` | No igual a | `A2<>3` |
| `>` | Mayor que | `A2>3` |
| `>=` | Mayor o igual que | `A2>=3` |
| `<` | Menor que | `A2<3` |
| `<=` | Menor o igual que | `A2<=3` |

## **Funciones predefinidas admitidas**

Aspose.Slides incluye un evaluador de fórmulas integrado para hojas de cálculo de gráficos, pero no es un motor de cálculo completo de Excel. El conjunto de funciones documentado se limita a las funciones siguientes. No asumas que una función de Excel arbitraria pueda ser recalculada por [calculate_formulas](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

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
| `FIND` | Buscar una cadena dentro de otra | `FIND("-",A2)` |
| `FINDB` | Búsqueda de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referencia | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vectorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vectorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Sumar valores | `SUM(B2:B5)` |
| `VLOOKUP` | Búsqueda vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Las limitaciones mostradas en la tabla son importantes: `INDEX` está documentado en forma de referencia, mientras que `LOOKUP` y `MATCH` están documentados en sus formas vectoriales. `DATE` usa el sistema de fechas 1900. Las características y funciones no listadas aquí deben considerarse no compatibles con el evaluador de fórmulas de Aspose.Slides a menos que estén documentadas por separado.

## **Calcular fórmulas con una cultura preferida**

Algunas funciones del libro de datos del gráfico interpretan texto según reglas específicas de cultura. Esto es especialmente importante para funciones destinadas a idiomas que usan conjuntos de caracteres de doble byte (DBCS). Para calcular esas fórmulas correctamente, crea [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/), establece [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/es/python-net/aspose.slides/spreadsheetoptions/) a través de [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/spreadsheet_options/) y luego carga la presentación.

El siguiente ejemplo selecciona la cultura japonesa, abre una presentación con las opciones de carga configuradas y llama a [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) para cada libro de datos del gráfico:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

La cultura preferida forma parte de la configuración de carga de la presentación, por lo que debe especificarse antes de crear la instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Usa la cultura que esperan las fórmulas del libro; por ejemplo, `ja-JP` para fórmulas que deben seguir las reglas de cálculo DBCS japonesas.

## **Recalculación y valores en caché**

Los archivos de hoja de cálculo suelen almacenar tanto una fórmula como su último valor calculado. Aspose.Slides puede leer un valor en caché desde [IChartDataCell.value](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/value/) cuando se carga una presentación y los datos del gráfico relevantes no se han cambiado.

Después de cambiar celdas de entrada o fórmulas, no confíes en un resultado antiguo en caché. Llama a [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) antes de leer valores calculados o guardar datos del gráfico que dependan de ellos.

Para fórmulas fuera del subconjunto admitido, Aspose.Slides puede ser incapaz de analizar la fórmula o establecer sus dependencias. Si el libro ha sido modificado, el valor en caché anterior ya no se puede considerar fiable. En esa situación, leer el valor de una celda con datos no compatibles puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Si tu gráfico depende de funciones de Excel que Aspose.Slides no evalúa, calcula esas fórmulas con un motor de hoja de cálculo que las admita y escribe los valores resultantes de nuevo en el libro de datos del gráfico. No reemplaces fórmulas no compatibles por valores adivinados.

## **Manejar errores de fórmula**

Existen dos tipos diferentes de problemas a distinguir.

Una fórmula puede ser válida pero producir un resultado de error de hoja de cálculo como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. En este caso, el token de error es un resultado de celda y puede devolverse a través de `value`.

Una fórmula también puede fallar en el nivel de análisis, referencia, dependencia o datos admitidos. Aspose.Slides ofrece excepciones específicas de hoja de cálculo para estos casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) y [CellUnsupportedDataException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Cuando las fórmulas provienen de plantillas o de la entrada del usuario, gestiona estas excepciones alrededor de la recalculación y el acceso al valor:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Limitaciones prácticas**

El soporte de fórmulas en las hojas de cálculo de gráficos está pensado para un subconjunto definido de cálculos de hoja, no para compatibilidad total con Excel. Ten en cuenta estas limitaciones al diseñar un flujo de trabajo de informes:

- Utiliza solo las constantes, operadores, referencias y funciones documentadas cuando necesites que Aspose.Slides recalcule fórmulas.
- Recalcula después de cambiar celdas de las que dependen los resultados de las fórmulas.
- Considera los valores en caché de las presentaciones cargadas como instantáneas, no como sustituto de la recalculación tras ediciones.
- Prueba las fórmulas de plantillas existentes antes de confiar en sus valores calculados, especialmente cuando usan funciones fuera de la lista documentada.
- Para fórmulas que requieren un motor de cálculo completo de hoja de cálculo, calcúlalas externamente y luego actualiza el libro de datos del gráfico con los valores resultantes.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre `formula` y `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/formula/) almacena una expresión en estilo A1 como `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) almacena una expresión en estilo R1C1 como `RC[-2]-RC[-1]`. Usa la notación que mejor se ajuste a cómo generas o copias las fórmulas.

**¿Necesito leer la celda en sí o su valor después del cálculo?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) devuelve un `IChartDataCell`. Para obtener el resultado calculado, lee la propiedad [value](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichartdatacell/value/) de esa celda después de la recalculación.

**¿Cuándo debo llamar a `calculate_formulas`?**

Llama a [calculate_formulas](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) después de modificar valores de entrada o fórmulas y antes de depender de los resultados calculados. Esto actualiza los valores de las fórmulas que el evaluador integrado admite.

**¿Aspose.Slides admite todas las funciones de Excel?**

No. El evaluador integrado admite un subconjunto documentado de funciones. Las funciones fuera de ese subconjunto no deben asumirse como recalculables correctamente. Si se requiere compatibilidad total con fórmulas de Excel, realiza el cálculo con un motor de hoja de cálculo adecuado y escribe los valores finales en el libro de datos del gráfico.

**¿Qué ocurre si una presentación cargada contiene una fórmula no compatible?**

Si los datos del gráfico no han cambiado, el libro puede seguir conteniendo un valor en caché calculado previamente. Tras modificar los datos relacionados, ese valor en caché puede dejar de ser válido. Acceder a una celda cuya fórmula no pueda procesarse puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**¿Los valores de error de fórmula son lo mismo que las excepciones de Python?**

No. Un resultado como `#DIV/0!` es un valor de hoja de cálculo producido por un cálculo válido. Excepciones como [CellInvalidFormulaException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indican que la fórmula no puede procesarse normalmente.

**¿Un gráfico se actualiza automáticamente cuando cambia una celda de fórmula?**

Una serie del gráfico puede hacer referencia a celdas del libro. Recalcula el libro primero, luego guarda o renderiza la presentación. Si los puntos de datos del gráfico hacen referencia a las celdas calculadas, el gráfico usa esos valores actualizados; no se requiere un método de actualización separado para este flujo de trabajo.

**¿Los gráficos pueden usar un libro de Excel externo?**

Sí, los datos del gráfico pueden configurarse para usar un libro externo mediante la API de datos del gráfico. Sin embargo, el flujo de cálculo de fórmulas descrito en este artículo se refiere al libro de datos del gráfico y al subconjunto de fórmulas evaluado por Aspose.Slides. No asumas que [calculate_formulas](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) proporciona una recalculación completa de fórmulas arbitrarias en un archivo XLSX externo.

**¿Puedo usar fórmulas que hagan referencia a otra hoja de cálculo o libro?**

Las referencias al estilo Excel pueden existir en los libros de datos del gráfico, pero la evaluación de fórmulas está limitada por el analizador y el conjunto de funciones admitidos. Si una referencia cruzada de hoja o externa es esencial, valida esa fórmula exacta con la versión de Aspose.Slides que utilizas. Para flujos que requieren una compatibilidad amplia de referencias de Excel, calcula el libro externamente y escribe los valores resueltos de nuevo en los datos del gráfico.

**¿Deben las cadenas de fórmula comenzar con `=`?**

Los ejemplos de la API de Aspose.Slides asignan expresiones como `B2-C2` o `SUM(B2:B5)` sin un `=` inicial. Usar esa forma mantiene las fórmulas generadas consistentes con los ejemplos documentados de la API.