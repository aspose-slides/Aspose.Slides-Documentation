---
title: Aplicar fórmulas de hoja de cálculo en presentaciones en PHP
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/php-java/chart-worksheet-formulas/
keywords:
- hoja de cálculo del gráfico
- hoja de cálculo del gráfico
- fórmula del gráfico
- fórmula de hoja de cálculo
- fórmula de hoja de cálculo
- libro de datos del gráfico
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
- PHP
- Aspose.Slides
description: "Aplicar fórmulas al estilo de Excel en las hojas de cálculo de gráficos de Aspose.Slides para PHP a través de Java, recalcular valores y usar los resultados en los gráficos de PowerPoint."
---
## **Resumen**

Los gráficos de PowerPoint suelen almacenar sus datos origen en una hoja de cálculo incrustada. En Aspose.Slides para PHP a través de Java, puede acceder a esa hoja mediante el libro de datos del gráfico, escribir valores de entrada, asignar fórmulas a celdas, calcular las fórmulas compatibles y utilizar las celdas calculadas como datos del gráfico.

Este artículo explica el flujo de trabajo completo de fórmulas: crear un gráfico, rellenar su hoja de cálculo, asignar fórmulas en estilo A1 o R1C1, volver a calcularlas, leer los valores calculados, conectar esas celdas a una serie del gráfico y guardar la presentación. También describe la sintaxis de fórmulas compatible, el subconjunto de funciones incorporadas, los valores almacenados en caché, las fórmulas no compatibles y los errores específicos de la hoja de cálculo.

## **Hojas de cálculo de gráficos y fórmulas**

Una hoja de cálculo de gráfico contiene las categorías, los nombres de series y los valores utilizados por un gráfico. En PowerPoint, puede inspeccionar la hoja abriendo el editor de datos del gráfico:

![Gráfico de PowerPoint con su hoja de cálculo incrustada abierta, mostrando datos de categorías y series](chart-worksheet-formulas_1.png)

En Aspose.Slides, la hoja se expone a través de la clase [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/). Use [ChartDataCell::setFormula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setFormula) para fórmulas estilo A1 y [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setR1C1Formula) para fórmulas estilo R1C1. Después de modificar celdas de entrada o fórmulas, llame a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) para volver a calcular las fórmulas compatibles y actualizar los valores correspondientes de las celdas.

Una celda calculada sigue exponiendo su resultado a través de [ChartDataCell::getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#getValue). Esto es importante cuando necesita inspeccionar el resultado de una fórmula en código o usar la celda como punto de datos del gráfico.

## **Crear un gráfico y calcular fórmulas de la hoja de cálculo**

El siguiente ejemplo muestra un flujo de trabajo completo. Crea un gráfico de columnas agrupadas, borra los datos de ejemplo, escribe los valores de ingresos y gastos trimestrales, calcula el beneficio con fórmulas, lee los resultados, usa las celdas calculadas como valores del gráfico y guarda la presentación.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Los puntos de datos del gráfico hacen referencia a `D2:D4`, por lo que el gráfico utiliza los valores de beneficio calculados. No hay una llamada separada para refrescar el gráfico en este flujo: recalcule primero el libro de trabajo y luego use o guarde los datos del gráfico que apuntan a las celdas calculadas.

## **Usar fórmulas en estilo A1**

La notación A1 identifica columnas con letras y filas con números. Asigne expresiones estilo A1 mediante [ChartDataCell::setFormula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Las formas de referencia A1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `A2` | `$A$2` | `A$2`, `$A2` |
| Fila | `2:2` | `$2:$2` | — |
| Columna | `A:A` | `$A:$A` | — |
| Rango | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Las referencias relativas pueden cambiar cuando una fórmula se mueve o copia en una aplicación de hoja de cálculo. Las referencias absolutas mantienen ambas coordenadas fijas, mientras que las referencias mixtas fijan solo una fila o una columna.

## **Usar fórmulas en estilo R1C1**

La notación R1C1 identifica filas y columnas numéricamente. Las referencias relativas usan desplazamientos entre corchetes. Asigne esta sintaxis mediante [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Las formas de referencia R1C1 comunes son:

| Referencia | Relativa | Absoluta | Mixta |
|---|---|---|---|
| Celda | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Fila | `R[2]` | `R2` | — |
| Columna | `C[3]` | `C3` | — |
| Rango | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por ejemplo, en la celda `D2`, `RC[-2]` indica la celda en la misma fila dos columnas a la izquierda (`B2`).

## **Constantes y operadores de fórmulas**

El evaluador de fórmulas incorporado admite valores lógicos, literales numéricos, cadenas, valores de error de hoja de cálculo, operadores aritméticos y operadores de comparación.

### **Constantes y literales**

| Tipo | Ejemplos | Notas |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Puede usarse directamente en expresiones lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Se admiten notación común y notación científica. |
| Cadena | `"abc"`, `"2/3/2020 12:00"` | Los literales de texto se encierran entre comillas dobles dentro de la fórmula. |
| Resultado de error | `#DIV/0!`, `#N/A`, `#REF!` | Una fórmula válida puede evaluar a un valor de error de hoja de cálculo en lugar de un resultado normal. |

Este ejemplo usa varios tipos de constantes:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // falso
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
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

Use paréntesis para hacer explícito el orden de evaluación, por ejemplo `(A2+B2)*C2`.

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

Aspose.Slides incluye un evaluador de fórmulas incorporado para hojas de cálculo de gráficos, pero no es un motor de cálculo completo de Excel. El conjunto de funciones documentado se limita a las funciones siguientes. No asuma que una función arbitraria de Excel pueda recalcularse mediante [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Función | Propósito o forma compatible | Ejemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Redondear un número hacia arriba al múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleccionar un valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concatenar valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concatenar valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crear un valor de fecha usando el sistema de fechas 1900 | `DATE(2026,8,19)` |
| `DAYS` | Devuelve el número de días entre fechas | `DAYS(B2,A2)` |
| `FIND` | Buscar un texto dentro de otro | `FIND("-",A2)` |
| `FINDB` | Búsqueda de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referencia | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vectorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vectorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Sumar valores | `SUM(B2:B5)` |
| `VLOOKUP` | Búsqueda vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Las restricciones mostradas en la tabla son significativas: `INDEX` se documenta en forma de referencia, mientras que `LOOKUP` y `MATCH` se documentan en sus formas vectoriales. `DATE` usa el sistema de fechas 1900. Las características y funciones que no aparecen aquí deben considerarse no compatibles con el evaluador de fórmulas de Aspose.Slides, a menos que se documenten por separado.

## **Recalculo y valores en caché**

Los archivos de hoja de cálculo suelen almacenar tanto una fórmula como su último valor calculado. Por ello, Aspose.Slides puede leer un valor en caché desde [ChartDataCell::getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#getValue) cuando se carga una presentación y los datos del gráfico relevantes no han sido modificados.

Después de modificar celdas de entrada o fórmulas, no confíe en un resultado en caché antiguo. Llame a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) antes de leer los valores calculados o guardar los datos del gráfico que dependen de ellos.

Para fórmulas fuera del subconjunto compatible, Aspose.Slides puede ser incapaz de analizar la fórmula o establecer sus dependencias. Si el libro de trabajo ha sido modificado, el valor en caché anterior ya no puede considerarse fiable. En esa situación, leer el valor de una celda con datos no compatibles puede generar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellunsupporteddataexception/).

Si su gráfico depende de funciones de Excel que Aspose.Slides no evalúa, calcule esas fórmulas con un motor de hoja de cálculo que las admita y escriba los valores resultantes de nuevo en el libro de datos del gráfico. No reemplace fórmulas no compatibles con valores adivinados.

## **Manejar errores de fórmulas**

Existen dos tipos diferentes de problemas a distinguir.

Una fórmula puede ser válida pero producir un resultado de error de hoja de cálculo como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. En este caso, el token de error es un resultado de celda y puede devolverse a través de [ChartDataCell::getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#getValue).

Una fórmula también puede fallar en el nivel de análisis, referencia, dependencia o datos compatibles. Aspose.Slides proporciona excepciones específicas de hoja de cálculo para estos casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellcircularreferenceexception/), y [CellUnsupportedDataException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellunsupporteddataexception/).

En PHP a través de Java, las excepciones Java se exponen mediante `JavaException`. Cuando las fórmulas provienen de plantillas o de la entrada del usuario, maneje la excepción alrededor del recálculo y el acceso al valor. La excepción Java reportada en la traza de la pila identifica la falla específica de la hoja de cálculo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Limitaciones prácticas**

El soporte de fórmulas en hojas de cálculo de gráficos está pensado para un subconjunto definido de cálculos de hoja, no para una compatibilidad total con Excel. Tenga en cuenta estas limitaciones al diseñar un flujo de trabajo de generación de informes:

- Utilice solo los constantes, operadores, referencias y funciones documentados cuando necesite que Aspose.Slides recalcule fórmulas.
- Recalcule después de modificar celdas de las que dependen los resultados de las fórmulas.
- Considere los valores en caché de presentaciones cargadas como instantáneas, no como sustituto del recálculo después de editar.
- Pruebe las fórmulas de plantillas existentes antes de confiar en sus valores calculados, sobre todo cuando usan funciones fuera de la lista documentada.
- Para fórmulas que requieran un motor completo de cálculo de hoja de cálculo, calcúlelas externamente y luego actualice el libro de datos del gráfico con los valores resultantes.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre [ChartDataCell::setFormula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setFormula) y [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setFormula) almacena una expresión estilo A1 como `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setR1C1Formula) almacena una expresión estilo R1C1 como `RC[-2]-RC[-1]`. Use la notación que mejor se ajuste a cómo genera o copia las fórmulas.

**¿Necesito leer la propia celda o su valor después del cálculo?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#getCell) devuelve un [ChartDataCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/). Para obtener el resultado calculado, llame al método [ChartDataCell::getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#getValue) de esa celda después del recálculo.

**¿Cuándo debo llamar a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Llame a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) después de cambiar valores de entrada o fórmulas y antes de depender de los resultados calculados. Esto actualiza los valores de las fórmulas que el evaluador incorporado admite.

**¿Aspose.Slides admite todas las funciones de Excel?**

No. El evaluador incorporado admite un subconjunto documentado de funciones. No se debe asumir que las funciones fuera de ese subconjunto se recalculen correctamente. Si necesita compatibilidad total con fórmulas de Excel, realice el cálculo con un motor de hoja de cálculo adecuado y escriba los valores finales en el libro de datos del gráfico.

**¿Qué ocurre si una presentación cargada contiene una fórmula no compatible?**

Si los datos del gráfico no se han modificado, el libro de trabajo puede seguir conteniendo un valor en caché calculado previamente. Después de modificar los datos relacionados, ese valor en caché puede dejar de ser válido. Acceder a una celda cuya fórmula no puede manejarse puede generar [CellUnsupportedDataException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellunsupporteddataexception/).

**¿Los valores de error de fórmula son lo mismo que las excepciones PHP?**

No. Un resultado como `#DIV/0!` es un valor de hoja de cálculo producido por un cálculo válido. Los fallos de procesamiento de hojas de cálculo, como [CellInvalidFormulaException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellcircularreferenceexception/), son excepciones Java que se exponen a PHP mediante `JavaException`.

**¿El gráfico se actualiza automáticamente cuando cambia una celda con fórmula?**

Una serie del gráfico puede referenciar celdas del libro de trabajo. Recalcule primero el libro de trabajo y luego guarde o renderice la presentación. Si los puntos de datos del gráfico hacen referencia a las celdas calculadas, el gráfico utiliza esos valores actualizados; no se requiere un método de actualización de gráfico separado para este flujo.

**¿Los gráficos pueden usar un libro de Excel externo?**

Sí, los datos del gráfico pueden configurarse para usar un libro externo mediante la API de datos del gráfico. Sin embargo, el flujo de cálculo de fórmulas descrito en este artículo se refiere al libro de datos del gráfico y al subconjunto de fórmulas evaluado por Aspose.Slides. No asuma que [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) proporciona un recálculo completo de fórmulas arbitrarias en un archivo XLSX externo.

**¿Puedo usar fórmulas que hagan referencia a otra hoja de cálculo o libro?**

Las referencias al estilo Excel pueden existir en los libros de datos de los gráficos, pero la evaluación de fórmulas está limitada por el analizador y el conjunto de funciones compatibles. Si una referencia cruzada de hoja o externa es esencial, valide esa fórmula exacta con la versión de Aspose.Slides que utiliza. Para flujos que requieran una compatibilidad amplia de referencias de Excel, calcule el libro externamente y escriba los valores resueltos de nuevo en los datos del gráfico.

**¿Deben las cadenas de fórmula comenzar con `=`?**

Los ejemplos de la API de Aspose.Slides asignan expresiones como `B2-C2` o `SUM(B2:B5)` sin un `=` inicial. Usar esa forma mantiene las fórmulas generadas coherentes con los ejemplos documentados de la API.