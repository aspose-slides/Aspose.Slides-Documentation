---
title: Aplicar fórmulas de hoja de cálculo en presentaciones en Python mediante Java
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/python-java/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
- hoja de trabajo del gráfico
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
- Python
- Java
- Aspose.Slides
description: "Aplicar fórmulas al estilo Excel en hojas de cálculo de gráficos de Aspose.Slides para Python mediante Java, recalcular valores y usar los resultados en gráficos de PowerPoint."
---
## **Resumen**

Los gráficos de PowerPoint normalmente almacenan sus datos de origen en una hoja de cálculo incrustada. En Aspose.Slides para Python mediante Java, puedes acceder a esa hoja a través del libro de datos del gráfico, escribir valores de entrada, asignar fórmulas a celdas, calcular las fórmulas admitidas y usar las celdas calculadas como datos del gráfico.

Este artículo explica el flujo de trabajo completo de fórmulas: crear un gráfico, rellenar su hoja de cálculo, asignar fórmulas en estilo A1 o R1C1, recalcularlas, leer los valores calculados, conectar esas celdas a una serie del gráfico y guardar la presentación. También describe la sintaxis de fórmulas admitida, el subconjunto de funciones incorporadas, los valores en caché, las fórmulas no soportadas y los errores específicos de hojas de cálculo.

## **Hojas de cálculo de gráficos y fórmulas**

Una hoja de cálculo de gráfico contiene las categorías, nombres de series y valores utilizados por un gráfico. En PowerPoint, puedes inspeccionar la hoja abriendo el editor de datos del gráfico:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

En Aspose.Slides, la hoja se expone a través de la clase [ChartDataWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/). Usa [ChartDataCell.setFormula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setFormula) para fórmulas estilo A1 y [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setR1C1Formula) para fórmulas estilo R1C1. Después de cambiar celdas de entrada o fórmulas, llama a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) para recalcular las fórmulas admitidas y actualizar los valores de celda correspondientes.

Una celda calculada sigue exponiendo su resultado mediante [ChartDataCell.getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#getValue). Esto es importante cuando necesitas inspeccionar el resultado de una fórmula en código o usar la celda como punto de datos del gráfico.

## **Crear un gráfico y calcular fórmulas de la hoja de cálculo**

El siguiente ejemplo muestra un flujo de trabajo de extremo a extremo. Crea un gráfico de columnas agrupadas, elimina los datos de muestra, escribe valores trimestrales de ingresos y gastos, calcula el beneficio con fórmulas, lee los resultados, usa las celdas calculadas como valores del gráfico y guarda la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Los puntos de datos del gráfico hacen referencia a `D2:D4`, por lo que el gráfico utiliza los valores de beneficio calculados. No hay una llamada separada de actualización del gráfico en este flujo: recalcula el libro primero, luego usa o guarda los datos del gráfico que apuntan a las celdas calculadas.

## **Usar fórmulas en estilo A1**

La notación A1 identifica columnas con letras y filas con números. Asigna expresiones en estilo A1 mediante [ChartDataCell.setFormula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Formas comunes de referencia A1 son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `A2` | `$A$2` | `A$2`, `$A2` |
| Fila | `2:2` | `$2:$2` | — |
| Columna | `A:A` | `$A:$A` | — |
| Rango | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Las referencias relativas pueden cambiar cuando una fórmula se mueve o copia en una aplicación de hoja de cálculo. Las referencias absolutas mantienen fijos ambos coordenados, mientras que las referencias mixtas fijan solo una fila o una columna.

## **Usar fórmulas en estilo R1C1**

La notación R1C1 identifica tanto filas como columnas numéricamente. Las referencias relativas usan desplazamientos entre corchetes. Asigna esta sintaxis mediante [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
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

El evaluador de fórmulas incorporado admite valores lógicos, literales numéricos, cadenas, valores de error de hoja de cálculo, operadores aritméticos y operadores de comparación.

### **Constantes y literales**

| Tipo | Ejemplos | Comentarios |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Puede usarse directamente en expresiones lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Se admiten notación común y notación científica. |
| Cadena | `"abc"`, `"2/3/2020 12:00"` | Los literales de texto se encierran entre comillas dobles dentro de la fórmula. |
| Resultado de error | `#DIV/0!`, `#N/A`, `#REF!` | Una fórmula válida puede evaluarse a un valor de error de hoja de cálculo en lugar de un resultado normal. |

Este ejemplo usa varios tipos de constantes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Falso
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Operadores aritméticos**

| Operador | Significado | Ejemplo |
|---|---|---|
| `+` | Suma o signo positivo unario | `2+3` |
| `-` | Resta o negación | `2-3`, `-3` |
| `*` | Multiplicación | `2*3` |
| `/` | División | `2/3` |
| `%` | Porcentaje | `30%` |
| `^` | Potenciación | `2^3` |

Usa paréntesis para hacer explícito el orden de evaluación, por ejemplo `(A2+B2)*C2`.

### **Operadores de comparación**

Las expresiones de comparación devuelven valores lógicos.

| Operador | Significado | Ejemplo |
|---|---|---|
| `=` | Igual a | `A2=3` |
| `<>` | Distinto de | `A2<>3` |
| `>` | Mayor que | `A2>3` |
| `>=` | Mayor o igual que | `A2>=3` |
| `<` | Menor que | `A2<3` |
| `<=` | Menor o igual que | `A2<=3` |

## **Funciones predefinidas compatibles**

Aspose.Slides incluye un evaluador de fórmulas incorporado para hojas de cálculo de gráficos, pero no es un motor de cálculo completo de Excel. El conjunto de funciones documentado está limitado a las funciones siguientes. No supongas que una función arbitraria de Excel puede ser recalculada por [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

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
| `FIND` | Buscar un valor de texto dentro de otro | `FIND("-",A2)` |
| `FINDB` | Búsqueda de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referencia | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vectorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vectorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Sumar valores | `SUM(B2:B5)` |
| `VLOOKUP` | Búsqueda vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Las restricciones mostradas en la tabla son significativas: `INDEX` está documentada en forma de referencia, mientras que `LOOKUP` y `MATCH` se documentan en sus formas vectoriales. `DATE` usa el sistema de fechas 1900. Las características y funciones no listadas aquí deben considerarse no compatibles con el evaluador de fórmulas de Aspose.Slides salvo que estén documentadas por separado.

## **Calcular fórmulas con una cultura preferida**

Algunas funciones del libro de gráficos interpretan texto según reglas específicas de cultura. Esto es especialmente importante para funciones destinadas a idiomas que usan juegos de caracteres de doble byte (DBCS). Para calcular esas fórmulas correctamente, crea [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/), establece la cultura preferida con [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/es/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), asigna las opciones de hoja mediante [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) y, a continuación, carga la presentación.

El siguiente ejemplo selecciona la cultura japonesa, abre una presentación con las opciones de carga configuradas y llama a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) para cada libro de gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

La cultura preferida forma parte de la configuración de carga de la presentación, por lo que debes especificarla antes de crear la instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). Usa la cultura que esperan las fórmulas del libro; por ejemplo, `ja-JP` para fórmulas que deben seguir las reglas de cálculo DBCS japonesas.

## **Recalculado y valores en caché**

Los archivos de hoja de cálculo suelen almacenar tanto una fórmula como su último valor calculado. Aspose.Slides puede leer un valor en caché mediante [ChartDataCell.getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#getValue) cuando se carga una presentación y los datos del gráfico relevantes no se han modificado.

Después de cambiar celdas de entrada o fórmulas, no confíes en un resultado en caché antiguo. Llama a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) antes de leer valores calculados o guardar datos del gráfico que dependan de ellos.

Para fórmulas fuera del subconjunto admitido, Aspose.Slides puede no ser capaz de analizar la fórmula o de establecer sus dependencias. Si el libro ha sido modificado, el valor en caché anterior ya no puede considerarse fiable. En esa situación, leer el valor de una celda con datos no soportados puede generar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellunsupporteddataexception/).

Si tu gráfico depende de funciones de Excel que Aspose.Slides no evalúa, calcula esas fórmulas con un motor de hoja de cálculo que las admita y escribe los valores resultantes de nuevo en el libro del gráfico. No reemplaces fórmulas no soportadas por valores adivinados.

## **Gestionar errores de fórmulas**

Existen dos tipos diferentes de problemas a distinguir.

Una fórmula puede ser válida pero producir un resultado de error de hoja de cálculo como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. En este caso, el token de error es un resultado de celda y puede devolverse mediante [ChartDataCell.getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#getValue).

Una fórmula también puede fallar en el análisis, referencia, dependencia o nivel de datos admitidos. Aspose.Slides proporciona excepciones específicas de hoja de cálculo para estos casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellcircularreferenceexception/) y [CellUnsupportedDataException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellunsupporteddataexception/).

Cuando las fórmulas provienen de plantillas o de la entrada del usuario, maneja estas excepciones alrededor del recalculado y el acceso al valor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Limitaciones prácticas**

El soporte de fórmulas en hojas de cálculo de gráficos está destinado a un subconjunto definido de cálculos de hoja, no a una compatibilidad total con Excel. Ten en cuenta estas restricciones al diseñar un flujo de trabajo de informes:

- Usa solo las constantes, operadores, referencias y funciones documentadas cuando necesites que Aspose.Slides recalcule fórmulas.
- Recalcula después de cambiar celdas de las que dependen los resultados de las fórmulas.
- Trata los valores en caché de presentaciones cargadas como instantáneas, no como sustitutos del recalculado tras ediciones.
- Prueba las fórmulas de plantillas existentes antes de confiar en sus valores calculados, sobre todo si utilizan funciones fuera de la lista documentada.
- Para fórmulas que requieren un motor completo de cálculo de hoja de cálculo, calcúlalas externamente y luego actualiza el libro del gráfico con los valores resultantes.

## **FAQ**

**¿Cuál es la diferencia entre [ChartDataCell.setFormula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setFormula) y [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setFormula) almacena una expresión en estilo A1 como `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#setR1C1Formula) almacena una expresión en estilo R1C1 como `RC[-2]-RC[-1]`. Usa la notación que mejor se ajuste a cómo generas o copias las fórmulas.

**¿Debo leer la propia celda o su valor después del cálculo?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#getCell) devuelve un [ChartDataCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/). Para obtener el resultado calculado, llama al método [ChartDataCell.getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatacell/#getValue) de esa celda después del recalculado.

**¿Cuándo debo llamar a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Llama a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) después de cambiar valores de entrada o fórmulas y antes de depender de los resultados calculados. Esto actualiza los valores de las fórmulas que el evaluador incorporado soporta.

**¿Aspose.Slides admite todas las funciones de Excel?**

No. El evaluador incorporado admite un subconjunto documentado de funciones. No se debe asumir que las funciones fuera de ese subconjunto se recalculan correctamente. Si se requiere compatibilidad total con fórmulas de Excel, realiza el cálculo con un motor de hoja de cálculo apropiado y escribe los valores finales en el libro del gráfico.

**¿Qué ocurre si una presentación cargada contiene una fórmula no soportada?**

Si los datos del gráfico no se han modificado, el libro puede seguir conteniendo un valor en caché calculado previamente. Tras modificar los datos relacionados, ese valor en caché puede dejar de ser válido. Acceder a una celda cuya fórmula no puede gestionarse puede generar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellunsupporteddataexception/).

**¿Los valores de error de fórmula son lo mismo que las excepciones?**

No. Un resultado como `#DIV/0!` es un valor de hoja de cálculo producido por un cálculo válido. Las excepciones como [CellInvalidFormulaException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellcircularreferenceexception/) indican que la fórmula no puede procesarse de forma normal.

**¿Un gráfico se actualiza automáticamente cuando cambia una celda de fórmula?**

Una serie de gráfico puede referenciar celdas del libro. Recalcula el libro primero, luego guarda o renderiza la presentación. Si los puntos de datos del gráfico hacen referencia a las celdas calculadas, el gráfico usará esos valores actualizados; no se requiere un método de actualización de gráfico separado para este flujo.

**¿Los gráficos pueden usar un libro de Excel externo?**

Sí, los datos del gráfico pueden configurarse para usar un libro externo mediante la API de datos del gráfico. Sin embargo, el flujo de trabajo de cálculo de fórmulas descrito en este artículo se refiere al libro de datos del gráfico y al subconjunto de fórmulas evaluado por Aspose.Slides. No asumas que [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) proporciona un recalculado completo de fórmulas arbitrarias en un archivo XLSX externo.

**¿Puedo usar fórmulas que hagan referencia a otra hoja de cálculo o a otro libro?**

Pueden existir referencias al estilo Excel en los libros de gráficos, pero la evaluación de fórmulas está limitada por el analizador y el conjunto de funciones admitidos. Si una referencia cruzada de hoja o externa es esencial, valida esa fórmula exacta con la versión de Aspose.Slides que utilices. Para flujos que requieran una compatibilidad amplia de referencias Excel, calcula el libro externamente y escribe los valores resueltos de nuevo en los datos del gráfico.

**¿Deben las cadenas de fórmula comenzar con `=`?**

Los ejemplos de la API de Aspose.Slides asignan expresiones como `B2-C2` o `SUM(B2:B5)` sin un `=` inicial. Usar esa forma mantiene las fórmulas generadas coherentes con los ejemplos documentados de la API.