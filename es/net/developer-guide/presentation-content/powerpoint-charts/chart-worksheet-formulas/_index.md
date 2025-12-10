---
title: Aplicar fórmulas de hoja de trabajo de gráfico en presentaciones en .NET
linktitle: Fórmulas de hoja de trabajo
type: docs
weight: 70
url: /es/net/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
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
- .NET
- C#
- Aspose.Slides
description: "Aplicar fórmulas al estilo Excel en Aspose.Slides para .NET en hojas de cálculo de gráficos y automatizar informes en archivos PPT y PPTX."
---

## **Acerca de las fórmulas de hoja de cálculo de gráficos en presentaciones**
**Hoja de cálculo de gráfico** (o hoja de trabajo de gráfico) en una presentación es la fuente de datos del gráfico. La hoja de cálculo de gráfico contiene datos, que se representan en el gráfico de forma gráfica. Cuando crea un gráfico en PowerPoint, la hoja de trabajo asociada a ese gráfico se crea automáticamente también. La hoja de trabajo se crea para todo tipo de gráficos: gráfico de líneas, gráfico de barras, gráfico de explosión, gráfico circular, etc. Para ver la hoja de cálculo del gráfico en PowerPoint debe hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La hoja de cálculo del gráfico contiene los nombres de los elementos del gráfico (Nombre de categoría: *Category1*, Nombre de serie) y una tabla con datos numéricos correspondientes a esas categorías y series. Por defecto, cuando crea un gráfico nuevo, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puede cambiar los datos de la hoja manualmente.

Normalmente, el gráfico representa datos complejos (p. ej., analistas financieros, analistas científicos), con celdas que se calculan a partir de los valores de otras celdas o de otros datos dinámicos. Calcular el valor de una celda manualmente y codificarlo directamente en la celda dificulta su posterior modificación. Si cambia el valor de una celda determinada, todas las celdas dependientes también deberán actualizarse. Además, los datos de la tabla pueden depender de datos de otras tablas, creando un esquema de datos de presentación complejo que necesita actualizarse de forma fácil y flexible.

**La fórmula de hoja de cálculo de gráfico** en una presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una celda o un conjunto de celdas. La fórmula es una fórmula matemática o lógica que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esa celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, y luego ese valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/net/) la hoja de cálculo de gráfico se representa con la propiedad [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook). La fórmula de hoja de cálculo puede asignarse y modificarse con la propiedad [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula). La siguiente funcionalidad es compatible para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias de celda estilo A1
- Referencias de celda estilo R1C1
- Funciones predefinidas



Normalmente, las hojas de cálculo almacenan los últimos valores calculados de las fórmulas. Si después de cargar la presentación los datos del gráfico no fueron modificados, la propiedad **IChartDataCell.Value** devuelve esos valores al leer. Pero, si los datos de la hoja se cambiaron, al leer la propiedad **ChartDataCell.Value** se lanza la excepción **CellUnsupportedDataException** para las fórmulas no compatibles. Esto ocurre porque, cuando las fórmulas se analizan correctamente, se determinan las dependencias de celdas y la corrección de los últimos valores. Si la fórmula no puede analizarse, no se puede garantizar la corrección del valor de la celda.
## **Agregar una fórmula de hoja de cálculo de gráfico a una presentación**
Primero, agregue un gráfico con datos de ejemplo a la primera diapositiva de una presentación nueva con [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1). La hoja de trabajo del gráfico se crea automáticamente y puede accederse con la propiedad [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook):
``` csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```




Escribamos algunos valores en celdas con la propiedad [**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) del tipo **Object**, lo que significa que puede establecer cualquier valor en la propiedad:
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```




Ahora, para escribir una fórmula en la celda, puede usar la propiedad [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula):
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*Nota*: la propiedad [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) se usa para establecer referencias de celda estilo A1.



Para establecer la referencia de celda [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), puede usar la propiedad [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


Luego use el método [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) para calcular todas las fórmulas dentro del libro y actualizar los valores de las celdas correspondientes:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **Constantes lógicas**
Puede usar constantes lógicas como *FALSE* y *TRUE* en fórmulas de celdas:




## **Constantes numéricas**
Los números pueden usarse en notación decimal o científica para crear fórmulas de hoja de cálculo de gráfico:




## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:




## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda mientras su valor aún se está calculando.
- #N/A - falta información o no está disponible. Algunas causas pueden ser: celdas usadas en la fórmula vacías, un carácter de espacio extra, error ortográfico, etc.
- #NAME? - no se puede encontrar una celda o otro objeto de fórmula por su nombre.
- #NULL! - puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio usado en lugar de dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado grande o demasiado pequeño, etc.
- #REF! - referencia de celda no válida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, valor de cadena asignado a una celda numérica.




## **Operadores aritméticos**
Puede usar todos los operadores aritméticos en fórmulas de hoja de cálculo de gráficos:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|+ (signo más)|Suma o signo positivo unario|2 + 3|
|- (signo menos)|Resta o negación|2 - 3<br>-3|
|* (asterisco)|Multiplicación|2 * 3|
|/ (barra diagonal)|División|2 / 3|
|% (signo de porcentaje)|Porcentaje|30%|
|^ (acento circunflejo)|Exponenciación|2 ^ 3|


*Nota*: para cambiar el orden de evaluación, encierre entre paréntesis la parte de la fórmula que debe calcularse primero.


## **Operadores de comparación**
Puede comparar los valores de celdas con los operadores de comparación. Cuando dos valores se comparan usando estos operadores, el resultado es un valor lógico *TRUE* o *FALSE*:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|= (signo igual)|Igual a|A2 = 3|
|<> (signo distinto)|Distinto de|A2 <> 3|
|> (mayor que)|Mayor que|A2 > 3|
|>= (mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias de celda estilo A1**
**Las referencias de celda estilo A1** se usan en las hojas de cálculo, donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila tiene un identificador numérico (p. ej., "*1*"). Las referencias estilo A1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**| | |
| :- | :- | :- | :- |
| |Absoluta|Relativa|Mixta|
|Celda|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Fila|$2:$2|2:2|-|
|Columna|$A:$A|A:A|-|
|Rango|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí hay un ejemplo de cómo usar una referencia de celda estilo A1 en una fórmula:




## **Referencias de celda estilo R1C1**
**Las referencias de celda estilo R1C1** se usan en las hojas de cálculo, donde tanto la fila como la columna tienen identificador numérico. Las referencias estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**| | |
| :- | :- | :- | :- |
| |Absoluta|Relativa|Mixta|
|Celda|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila|R2|R[2]|-|
|Columna|C3|C[3]|-|
|Rango|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí hay un ejemplo de cómo usar una referencia de celda estilo A1 en una fórmula:




## **Funciones predefinidas**
Existen funciones predefinidas que pueden usarse en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más usadas, como:

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

Sí. Aspose.Slides admite libros externos como [fuente de datos de un gráfico](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/), lo que permite usar fórmulas de un XLSX fuera de la presentación.

**¿Pueden las fórmulas de gráfico hacer referencia a hojas dentro del mismo libro por nombre de hoja?**

Sí. Las fórmulas siguen el modelo estándar de referencias de Excel, por lo que puede referenciar otras hojas dentro del mismo libro o un libro externo. Para referencias externas, incluya la ruta y el nombre del libro usando la sintaxis de Excel.