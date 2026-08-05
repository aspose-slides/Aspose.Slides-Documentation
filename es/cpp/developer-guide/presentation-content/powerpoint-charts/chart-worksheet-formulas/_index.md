---
title: Aplicar fórmulas de hoja de cálculo de gráfico en presentaciones usando C++
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/cpp/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
- hoja de trabajo del gráfico
- fórmula de gráfico
- fórmula de hoja de cálculo
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
description: "Aplicar fórmulas al estilo Excel en Aspose.Slides para hojas de cálculo de gráficos en C++ y automatizar informes en archivos PPT y PPTX."
---
## **Visión general**

Una hoja de cálculo de gráfico es la fuente de datos detrás de un gráfico en una presentación. Almacena los nombres de categorías y series junto con los valores numéricos mostrados por el gráfico. En Aspose.Slides, esta hoja de cálculo está disponible a través del libro de datos del gráfico, lo que permite trabajar con los datos del gráfico mediante programación.

Este artículo explica cómo usar fórmulas en la hoja de cálculo del gráfico para que los valores de las celdas se calculen y actualicen automáticamente en lugar de introducirse manualmente. Muestra cómo asignar fórmulas, utilizar referencias de estilo A1 y R1C1, recalcular las fórmulas del libro y trabajar con las constantes, operadores, referencias a celdas y funciones predefinidas compatibles con las hojas de cálculo de gráficos en presentaciones.

## **Acerca de las fórmulas de hoja de cálculo de gráfico en presentaciones**
**Chart spreadsheet** (o hoja de cálculo de gráfico) en una presentación es la fuente de datos del gráfico. La hoja de cálculo del gráfico contiene datos, que se representan en el gráfico de forma gráfica. Cuando creas un gráfico en PowerPoint, la hoja de cálculo asociada a ese gráfico se crea automáticamente también. La hoja de cálculo del gráfico se crea para todo tipo de gráficos: gráfico de líneas, gráfico de barras, gráfico de sunburst, gráfico circular, etc. Para ver la hoja de cálculo del gráfico en PowerPoint debes hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La hoja de cálculo del gráfico contiene los nombres de los elementos del gráfico (Nombre de categoría: *Category1*, Nombre de serie) y una tabla con datos numéricos correspondientes a esas categorías y series. Por defecto, cuando creas un gráfico nuevo, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puedes cambiar los datos de la hoja manualmente.

Normalmente, el gráfico representa datos complejos (p. ej., analistas financieros, analistas científicos), teniendo celdas que se calculan a partir de los valores de otras celdas o de otros datos dinámicos. Calcular el valor de una celda manualmente y codificarlo directamente en la celda dificulta su posterior modificación. Si cambias el valor de una celda determinada, todas las celdas dependientes de ella también deberán actualizarse. Además, los datos de la tabla pueden depender de datos de otras tablas, creando un esquema de datos de presentación complejo que necesita actualizarse de forma fácil y flexible.

**Chart spreadsheet formula** en una presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una celda o conjunto de celdas. La fórmula de hoja de cálculo es una fórmula matemática o lógica, que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esa celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, asignándolo luego a la celda. Las fórmulas de hoja de cálculo en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminadas para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/es/cpp/) la hoja de cálculo del gráfico está representada con el método [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.i_chart_data_workbook). La fórmula de hoja de cálculo puede asignarse y modificarse con [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). La funcionalidad siguiente es compatible con las fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas estilo A1
- Referencias a celdas estilo R1C1
- Funciones predefinidas



Normalmente, las hojas de cálculo almacenan los valores calculados más recientes de las fórmulas. Si después de cargar la presentación los datos del gráfico no se cambiaron, el método **IChartDataCell.get_Value()** devuelve esos valores al leer. Pero, si los datos de la hoja se modificaron, al leer **ChartDataCell.get_Value()** se lanza la **CellUnsupportedDataException** por las fórmulas no admitidas. Esto ocurre porque, cuando las fórmulas se analizan correctamente, se determinan las dependencias de las celdas y la corrección de los últimos valores. Si la fórmula no puede analizarse, no se puede garantizar la corrección del valor de la celda.


## **Añadir una fórmula de hoja de cálculo de gráfico a una presentación**
Primero, añade un gráfico a la primera diapositiva de una nueva presentación con [IShapeCollection::AddChart()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). La hoja de cálculo del gráfico se crea automáticamente y puede accederse con [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) método:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Escribamos algunos valores en celdas con [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) método del tipo **Object**, lo que significa que puedes pasar cualquier valor al método:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Ahora, para escribir una fórmula en la celda, puedes usar el método [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):

*Nota*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) se utiliza para establecer referencias a celdas estilo A1.

Para establecer la referencia de celda R1C1Formula, puedes usar el método [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

Luego, si intentas leer los valores de las celdas B2 y C2, se calcularán:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Constantes lógicas**
Puedes usar constantes lógicas como *FALSE* y *TRUE* en fórmulas de celda:

## **Constantes numéricas**
Los números pueden usarse en notación común o científica para crear fórmulas de hoja de cálculo de gráfico:

## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se utiliza tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:

## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda mientras su valor todavía se está calculando.
- #N/A - la información falta o no está disponible. Algunas causas pueden ser: las celdas usadas en la fórmula están vacías, un espacio extra, error tipográfico, etc.
- #NAME? - no se puede encontrar una celda u otro objeto de fórmula por su nombre.
- #NULL! - puede aparecer cuando hay un error en la fórmula, como:  (,) o un espacio usado en lugar de dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia a celda no válida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, un valor de cadena asignado a una celda numérica.

## **Operadores aritméticos**
Puedes usar todos los operadores aritméticos en fórmulas de hoja de cálculo de gráfico:

|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Suma o positivo unario|2 + 3|
|- (signo menos) |Resta o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra diagonal)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (acento circunflejo) |Exponenciación |2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierra entre paréntesis la parte de la fórmula que debe calcularse primero.

## **Operadores de comparación**
Puedes comparar los valores de celdas con los operadores de comparación. Cuando dos valores se comparan usando estos operadores, el resultado es un valor lógico *TRUE* o *FALSE*:

|**Operador** |**Significado** |**Significado** |
| :- | :- | :- |
|= (signo igual) |Igual a |A2 = 3|
|<> (signo de diferente) |Distinto de|A2 <> 3|
|> (signo mayor que) |Mayor que|A2 > 3|
|>= (signo mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo menor que)|Menor que|A2 < 3|
|<= (signo menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias a celdas estilo A1**
**Las referencias a celdas estilo A1** se usan para las hojas de cálculo, donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila un identificador numérico (p. ej., "*1*"). Las referencias a celdas estilo A1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

A continuación se muestra un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:

## **Referencias a celdas estilo R1C1**
**Las referencias a celdas estilo R1C1** se usan para las hojas de cálculo, donde tanto la fila como la columna tienen identificador numérico. Las referencias a celdas estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

A continuación se muestra un ejemplo de cómo usar una referencia a celda estilo R1C1 en una fórmula:

## **Funciones predefinidas**
Existen funciones predefinidas que pueden usarse en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más utilizadas, como:

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

## **Preguntas frecuentes**

**¿Se admiten archivos Excel externos como fuente de datos para un gráfico con fórmulas?**

Sí. Aspose.Slides admite libros externos como una [fuente de datos del gráfico](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdatasourcetype/), lo que permite usar fórmulas de un XLSX fuera de la presentación.

**¿Pueden las fórmulas del gráfico referenciar hojas dentro del mismo libro por nombre de hoja?**

Sí. Las fórmulas siguen el modelo de referencia estándar de Excel, por lo que puedes referenciar otras hojas dentro del mismo libro o un libro externo. Para referencias externas, incluye la ruta y el nombre del libro usando la sintaxis de Excel.