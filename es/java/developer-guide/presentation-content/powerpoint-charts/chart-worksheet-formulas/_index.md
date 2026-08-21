---
title: Aplicar fórmulas de hoja de cálculo de gráficos en presentaciones en Java
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/java/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
- hoja de trabajo de gráfico
- fórmula de gráfico
- fórmula de hoja de cálculo
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
- Java
- Aspose.Slides
description: "Aplicar fórmulas al estilo Excel en las hojas de cálculo de gráficos de Aspose.Slides para Java, recalcular valores y usar los resultados en gráficos de PowerPoint."
---
## **Visión general**

Los gráficos de PowerPoint suelen almacenar sus datos de origen en una hoja de cálculo incrustada. En Aspose.Slides para Java, puedes acceder a esa hoja a través del libro de datos del gráfico, escribir valores de entrada, asignar fórmulas a celdas, calcular las fórmulas compatibles y utilizar las celdas calculadas como datos del gráfico.

Este artículo explica el flujo completo de trabajo con fórmulas: crear un gráfico, rellenar su hoja de cálculo, asignar fórmulas estilo A1 o estilo R1C1, recalcularlas, leer los valores calculados, conectar esas celdas a una serie del gráfico y guardar la presentación. También describe la sintaxis de fórmulas compatible, el subconjunto de funciones incorporadas, los valores en caché, las fórmulas no compatibles y los errores específicos de hojas de cálculo.

## **Hojas de cálculo de gráficos y fórmulas**

Una hoja de cálculo de gráfico contiene las categorías, los nombres de series y los valores que usa un gráfico. En PowerPoint, puedes inspeccionar la hoja abriendo el editor de datos del gráfico:

![Gráfico de PowerPoint con su hoja de cálculo incrustada abierta, mostrando datos de categorías y series](chart-worksheet-formulas_1.png)

En Aspose.Slides, la hoja está expuesta a través de la interfaz [IChartDataWorkbook](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/). Usa [IChartDataCell.setFormula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) para fórmulas estilo A1 y [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) para fórmulas estilo R1C1. Después de cambiar celdas de entrada o fórmulas, llama a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) para recalcular las fórmulas compatibles y actualizar los valores correspondientes de las celdas.

Una celda calculada sigue exponiendo su resultado a través de [IChartDataCell.getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#getValue--). Esto es importante cuando necesitas inspeccionar el resultado de una fórmula en código o usar la celda como punto de datos del gráfico.

## **Crear un gráfico y calcular fórmulas de la hoja de cálculo**

El siguiente ejemplo demuestra un flujo de trabajo de extremo a extremo. Crea un gráfico de columnas agrupadas, elimina los datos de ejemplo, escribe valores trimestrales de ingresos y gastos, calcula el beneficio con fórmulas, lee los resultados, usa las celdas calculadas como valores del gráfico y guarda la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Los puntos de datos del gráfico hacen referencia a `D2:D4`, por lo que el gráfico utiliza los valores de beneficio calculados. No hay una llamada separada de actualización del gráfico en este flujo: recalcula primero el libro y luego usa o guarda los datos del gráfico que apuntan a las celdas calculadas.

## **Usar fórmulas estilo A1**

La notación A1 identifica columnas con letras y filas con números. Asigna expresiones estilo A1 mediante [IChartDataCell.setFormula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Formas de referencia A1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `A2` | `$A$2` | `A$2`, `$A2` |
| Fila | `2:2` | `$2:$2` | — |
| Columna | `A:A` | `$A:$A` | — |
| Rango | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Las referencias relativas pueden cambiar cuando una fórmula se mueve o copia en una aplicación de hoja de cálculo. Las referencias absolutas mantienen fijas ambas coordenadas, mientras que las referencias mixtas fijan solo una fila o una columna.

## **Usar fórmulas estilo R1C1**

La notación R1C1 identifica tanto filas como columnas numéricamente. Las referencias relativas usan desplazamientos entre corchetes. Asigna esta sintaxis mediante [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Formas de referencia R1C1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Fila | `R[2]` | `R2` | — |
| Columna | `C[3]` | `C3` | — |
| Rango | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por ejemplo, en la celda `D2`, `RC[-2]` significa la celda de la misma fila dos columnas a la izquierda (`B2`).

## **Constantes y operadores de fórmulas**

El evaluador de fórmulas incorporado admite valores lógicos, literales numéricos, cadenas, valores de error de hoja de cálculo, operadores aritméticos y operadores de comparación.

### **Constantes y literales**

| Tipo | Ejemplos | Observaciones |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Puede usarse directamente en expresiones lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Se admiten notación común y notación científica. |
| Cadena | `"abc"`, `"2/3/2020 12:00"` | Los literales de texto se encierran entre comillas dobles dentro de la fórmula. |
| Resultado de error | `#DIV/0!`, `#N/A`, `#REF!` | Una fórmula válida puede evaluarse a un valor de error de hoja de cálculo en lugar de un resultado normal. |

Este ejemplo usa varios tipos de constantes:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
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

Los operadores de comparación devuelven valores lógicos.

| Operador | Significado | Ejemplo |
|---|---|---|
| `=` | Igual a | `A2=3` |
| `<>` | Distinto de | `A2<>3` |
| `>` | Mayor que | `A2>3` |
| `>=` | Mayor o igual que | `A2>=3` |
| `<` | Menor que | `A2<3` |
| `<=` | Menor o igual que | `A2<=3` |

## **Funciones predefinidas compatibles**

Aspose.Slides incluye un evaluador de fórmulas incorporado para hojas de cálculo de gráficos, pero no es un motor de cálculo completo de Excel. El conjunto de funciones documentado está limitado a las funciones siguientes. No asumas que una función arbitraria de Excel pueda recalcularse mediante [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Función | Propósito o forma compatible | Ejemplo |
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

Las restricciones mostradas en la tabla son significativas: `INDEX` se documenta en forma de referencia, mientras que `LOOKUP` y `MATCH` se documentan en sus formas vectoriales. `DATE` usa el sistema de fechas 1900. Las características y funciones no listadas aquí deben considerarse no compatibles con el evaluador de fórmulas de Aspose.Slides, a menos que estén documentadas por separado.

## **Calcular fórmulas con una cultura preferida**

Algunas funciones del libro de datos del gráfico interpretan texto según reglas específicas de la cultura. Esto es especialmente importante para funciones destinadas a idiomas que utilizan conjuntos de caracteres de doble byte (DBCS). Para calcular esas fórmulas correctamente, crea [LoadOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/), establece la cultura preferida con [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/es/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), asigna las opciones de hoja de cálculo mediante [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), y luego carga la presentación.

El siguiente ejemplo selecciona la cultura japonesa, abre una presentación con las opciones de carga configuradas y llama a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) para cada libro de datos del gráfico:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La cultura preferida forma parte de la configuración de carga de la presentación, por lo que debe especificarse antes de crear la instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). Usa la cultura esperada por las fórmulas del libro; por ejemplo, usa `ja-JP` para fórmulas que deben seguir reglas de cálculo DBCS japonesas.

## **Recalculo y valores almacenados en caché**

Los archivos de hoja de cálculo suelen almacenar tanto una fórmula como su último valor calculado. Aspose.Slides puede leer, por tanto, un valor en caché desde [IChartDataCell.getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#getValue--) cuando se carga una presentación y los datos del gráfico relevantes no han cambiado.

Después de modificar celdas de entrada o fórmulas, no confíes en un resultado en caché anterior. Llama a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) antes de leer valores calculados o guardar datos del gráfico que dependan de ellos.

Para fórmulas fuera del subconjunto compatible, Aspose.Slides puede no ser capaz de analizar la fórmula o establecer sus dependencias. Si el libro ha sido modificado, el valor almacenado previamente ya no puede considerarse fiable. En esa situación, leer el valor de una celda con datos no compatibles puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellunsupporteddataexception/).

Si tu gráfico depende de funciones de Excel que Aspose.Slides no evalúa, calcula esas fórmulas con un motor de hoja de cálculo que las admita y escribe los valores resultantes en el libro de datos del gráfico. No sustituyas fórmulas no compatibles por valores adivinados.

## **Manejar errores de fórmula**

Existen dos tipos diferentes de problemas que distinguir.

Una fórmula puede ser válida pero producir un resultado de error de hoja de cálculo como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. En este caso, el token de error es un resultado de celda y puede devolverse mediante [IChartDataCell.getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#getValue--).

Una fórmula también puede fallar en el nivel de análisis, referencia, dependencia o datos compatibles. Aspose.Slides proporciona excepciones específicas de hoja de cálculo para estos casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellcircularreferenceexception/), y [CellUnsupportedDataException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellunsupporteddataexception/).

Cuando las fórmulas provienen de plantillas o de la entrada del usuario, maneja estas excepciones alrededor del recálculo y el acceso al valor:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Limitaciones prácticas**

El soporte de fórmulas en hojas de cálculo de gráficos está pensado para un subconjunto definido de cálculos de hoja, no para una compatibilidad completa con Excel. Ten en cuenta estas limitaciones al diseñar un flujo de trabajo de informes:

- Utiliza solo las constantes, operadores, referencias y funciones documentadas cuando necesites que Aspose.Slides vuelva a calcular fórmulas.
- Vuelve a calcular después de modificar celdas de las que dependen los resultados de las fórmulas.
- Considera los valores en caché de presentaciones cargadas como instantáneas, no como sustituto del recálculo después de ediciones.
- Prueba las fórmulas de plantillas existentes antes de confiar en sus valores calculados, especialmente cuando usan funciones fuera de la lista documentada.
- Para fórmulas que requieran un motor de cálculo completo de hoja de cálculo, cálculalas externamente y luego actualiza el libro de datos del gráfico con los valores resultantes.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre [IChartDataCell.setFormula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) y [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) almacena una expresión estilo A1 como `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) almacena una expresión estilo R1C1 como `RC[-2]-RC[-1]`. Usa la notación que mejor se adapte a cómo generas o copias las fórmulas.

**¿Necesito leer la celda en sí o su valor después del cálculo?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) devuelve un [IChartDataCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/). Para obtener el resultado calculado, llama al método [IChartDataCell.getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#getValue--) de esa celda después del recálculo.

**¿Cuándo debo llamar a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Llama a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) después de cambiar valores de entrada o fórmulas y antes de depender de los resultados calculados. Esto actualiza los valores de las fórmulas que el evaluador incorporado soporta.

**¿Aspose.Slides admite todas las funciones de Excel?**

No. El evaluador incorporado admite un subconjunto documentado de funciones. No debe asumirse que las funciones fuera de ese subconjunto se recalculen correctamente. Si se requiere compatibilidad total con fórmulas de Excel, realiza el cálculo con un motor de hoja de cálculo apropiado y escribe los valores finales en el libro de datos del gráfico.

**¿Qué ocurre si una presentación cargada contiene una fórmula no compatible?**

Si los datos del gráfico no han cambiado, el libro puede seguir conteniendo un valor en caché calculado previamente. Tras modificar los datos relacionados, ese valor en caché puede ya no ser válido. Acceder a una celda cuya fórmula no puede gestionarse puede lanzar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellunsupporteddataexception/).

**¿Los valores de error de fórmula son lo mismo que las excepciones de Java?**

No. Un resultado como `#DIV/0!` es un valor de hoja de cálculo producido por un cálculo válido. Las excepciones como [CellInvalidFormulaException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/es/java/com.aspose.slides/cellcircularreferenceexception/) indican que la fórmula no puede procesarse de forma normal.

**¿Un gráfico se actualiza automáticamente cuando cambia una celda de fórmula?**

Una serie del gráfico puede hacer referencia a celdas del libro. Recalcula primero el libro y luego guarda o renderiza la presentación. Si los puntos de datos del gráfico hacen referencia a las celdas calculadas, el gráfico usa esos valores actualizados; no se requiere un método de actualización de gráfico separado para este flujo de trabajo.

**¿Los gráficos pueden usar un libro de Excel externo?**

Sí, los datos del gráfico pueden configurarse para usar un libro externo mediante la API de datos del gráfico. Sin embargo, el flujo de cálculo de fórmulas descrito en este artículo se refiere al libro de datos del gráfico y al subconjunto de fórmulas evaluado por Aspose.Slides. No asumas que [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) proporciona un recálculo completo de fórmulas arbitrarias en un archivo XLSX externo.

**¿Puedo usar fórmulas que referencien otra hoja de cálculo o libro?**

Pueden existir referencias al estilo Excel en los libros de gráficos, pero la evaluación de fórmulas está limitada por el analizador y el conjunto de funciones compatibles. Si una referencia cruzada de hoja o externa es esencial, valida esa fórmula exacta con la versión de Aspose.Slides que utilices. Para flujos que requieran una amplia compatibilidad de referencias de Excel, calcula el libro externamente y escribe los valores resueltos en los datos del gráfico.

**¿Deben las cadenas de fórmula comenzar con `=`?**

Los ejemplos de la API de Aspose.Slides asignan expresiones como `B2-C2` o `SUM(B2:B5)` sin un `=` inicial. Usar esa forma mantiene las fórmulas generadas coherentes con los ejemplos documentados de la API.