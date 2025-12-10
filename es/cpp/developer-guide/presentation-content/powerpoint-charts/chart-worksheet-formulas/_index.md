---
title: Aplicar fórmulas de hoja de trabajo de gráfico en presentaciones usando С++
linktitle: Fórmulas de hoja de trabajo
type: docs
weight: 70
url: /es/cpp/chart-worksheet-formulas/
keywords:
- hoja de cálculo del gráfico
- hoja de trabajo de gráfico
- fórmula de gráfico
- fórmula de hoja de trabajo
- fórmula de hoja de cálculo
- fuente de datos
- constante lógica
- constante numérica
- constante de cadena
- constante de error
- constante aritmética
- operador de comparación
- estilo A1
- estilo R1C1
- función predefinida
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aplicar fórmulas estilo Excel en Aspose.Slides para hojas de trabajo de gráfico en С++ y automatizar informes en archivos PPT y PPTX."
---

## **Acerca de las fórmulas de hoja de cálculo de gráficos en presentaciones**
**Hoja de cálculo del gráfico** (o hoja de trabajo del gráfico) en la presentación es la fuente de datos del gráfico. La hoja de cálculo del gráfico contiene datos, que se representan en el gráfico de forma visual. Cuando crea un gráfico en PowerPoint, la hoja de trabajo asociada a ese gráfico se crea automáticamente también. La hoja de trabajo del gráfico se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de explosión, gráfico circular, etc. Para ver la hoja de cálculo del gráfico en PowerPoint debe hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La hoja de cálculo del gráfico contiene los nombres de los elementos del gráfico (Nombre de categoría: *Category1*, Nombre de serie) y una tabla con datos numéricos apropiados a esas categorías y series. De forma predeterminada, cuando crea un gráfico nuevo, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puede cambiar los datos de la hoja de cálculo manualmente en la hoja de trabajo.

Normalmente, el gráfico representa datos complejos (p. ej., análisis financieros, análisis científicos), con celdas que se calculan a partir de los valores en otras celdas o de datos dinámicos externos. Calcular manualmente el valor de una celda y codificarlo de forma fija dificulta su modificación futura. Si cambia el valor de una celda determinada, todas las celdas dependientes de ella también deberán actualizarse. Además, los datos de la tabla pueden depender de datos de otras tablas, creando un esquema de datos de presentación complejo que necesita actualizarse de forma sencilla y flexible.

**Fórmula de hoja de cálculo del gráfico** en la presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de la hoja de cálculo define la lógica de cálculo de datos para una celda determinada o un conjunto de celdas. La fórmula de la hoja de cálculo es una fórmula matemática o lógica, que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esa celda no contiene un valor simple. La fórmula de la hoja de cálculo calcula el valor y lo devuelve, asignando ese valor a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y admiten las mismas funciones predeterminadas, operadores y constantes para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) la hoja de cálculo del gráfico se representa con el método [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook). La fórmula de la hoja de cálculo puede asignarse y modificarse con el método [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). La siguiente funcionalidad es compatible con las fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas al estilo A1
- Referencias a celdas al estilo R1C1
- Funciones predefinidas

Normalmente, las hojas de cálculo almacenan los últimos valores calculados de las fórmulas. Si, después de cargar la presentación, los datos del gráfico no se cambiaron, el método **IChartDataCell.get_Value()** devuelve esos valores al leer. Pero, si los datos de la hoja de cálculo se cambiaron, al leer el método **ChartDataCell.get_Value()** lanza la **CellUnsupportedDataException** para las fórmulas no compatibles. Esto ocurre porque, cuando las fórmulas se analizan con éxito, se determinan las dependencias de las celdas y la corrección de los últimos valores. Si la fórmula no puede analizarse, no se puede garantizar la corrección del valor de la celda.

## **Agregar una fórmula de hoja de cálculo de gráfico a una presentación**
Primero, añada un gráfico a la primera diapositiva de una nueva presentación con [IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). La hoja de trabajo del gráfico se crea automáticamente y puede accederse con el método [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):
``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```


Escribamos algunos valores en celdas con el método [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) del tipo **Object**, lo que significa que puede pasar cualquier valor al método:
``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```


Ahora, para escribir una fórmula en la celda, puede usar el método [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):

*Nota*: el método [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) se usa para establecer referencias a celdas al estilo A1.

Para establecer la referencia de celda R1C1Formula, puede usar el método [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

Luego, si intenta leer los valores de las celdas B2 y C2, se calcularán:
``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Constantes lógicas**
Puede usar constantes lógicas como *FALSE* y *TRUE* en las fórmulas de celdas:

## **Constantes numéricas**
Los números pueden usarse en notaciones comunes o científicas para crear fórmulas de hoja de cálculo de gráficos:

## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:

## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda mientras su valor todavía se está calculando.
- #N/A - falta información o no está disponible. Algunas causas pueden ser: celdas usadas en la fórmula vacías, un carácter de espacio extra, error ortográfico, etc.
- #NAME? - no se puede encontrar una cierta celda u otro objeto de fórmula por su nombre.
- #NULL! - puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio usado en lugar de dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda no válida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, valor de cadena en una celda numérica.

## **Operadores aritméticos**
Puede usar todos los operadores aritméticos en las fórmulas de la hoja de trabajo del gráfico:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|+ (signo más)|Suma o signo positivo unario|2 + 3|
|- (signo menos)|Resta o negación|2 - 3<br>-3|
|* (asterisco)|Multiplicación|2 * 3|
|/ (barra diagonal)|División|2 / 3|
|% (signo de porcentaje)|Porcentaje|30%|
|^ (caret)|Exponenciación|2 ^ 3|

*Nota*: para cambiar el orden de evaluación, encierre entre paréntesis la parte de la fórmula que debe calcularse primero.

## **Operadores de comparación**
Puede comparar los valores de celdas con los operadores de comparación. Cuando dos valores se comparan usando estos operadores, el resultado es un valor lógico *TRUE* o *FALSE*:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|= (signo igual)|Igual a|A2 = 3|
|<> (signo distinto)|Distinto de|A2 <> 3|
|> (signo mayor que)|Mayor que|A2 > 3|
|>= (signo mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo menor que)|Menor que|A2 < 3|
|<= (signo menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias de celda al estilo A1**
**Las referencias de celda al estilo A1** se usan en las hojas de trabajo, donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila tiene un identificador numérico (p. ej., "*1*"). Las referencias de celda al estilo A1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|**Absoluta**|**Relativa**|**Mixta**|
| :- | :- | :- | :- | :- |
|Celda|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Fila|$2:$2|2:2|-|
|Columna|$A:$A|A:A|-|
|Rango|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

A continuación se muestra un ejemplo de cómo usar una referencia de celda al estilo A1 en una fórmula:

## **Referencias de celda al estilo R1C1**
**Las referencias de celda al estilo R1C1** se usan en las hojas de trabajo, donde tanto la fila como la columna tienen identificadores numéricos. Las referencias de celda al estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|**Absoluta**|**Relativa**|**Mixta**|
| :- | :- | :- | :- | :- |
|Celda|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila|R2|R[2]|-|
|Columna|C3|C[3]|-|
|Rango|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

A continuación se muestra un ejemplo de cómo usar una referencia de celda al estilo R1C1 en una fórmula:

## **Funciones predefinidas**
Existen funciones predefinidas que pueden usarse en las fórmulas para simplificar su implementación. Estas funciones incapsulan las operaciones más utilizadas, como:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema de fechas 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (forma de referencia)
- LOOKUP (forma vectorial)
- MATCH (forma vectorial)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**¿Se admiten archivos Excel externos como fuente de datos para un gráfico con fórmulas?**

Sí. Aspose.Slides admite libros de trabajo externos como [fuente de datos de un gráfico](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdatasourcetype/), lo que permite usar fórmulas de un archivo XLSX fuera de la presentación.

**¿Pueden las fórmulas de gráficos hacer referencia a hojas dentro del mismo libro mediante el nombre de la hoja?**

Sí. Las fórmulas siguen el modelo de referencia estándar de Excel, por lo que puede referenciar otras hojas dentro del mismo libro o en un libro externo. Para referencias externas, incluya la ruta y el nombre del libro usando la sintaxis de Excel.