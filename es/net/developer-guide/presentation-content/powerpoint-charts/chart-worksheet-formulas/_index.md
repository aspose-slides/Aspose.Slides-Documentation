---
title: Fórmulas de Hoja de Cálculo de Gráficos
type: docs
weight: 70
url: /net/chart-worksheet-formulas/
keywords: "Hoja de cálculo de gráficos, fórmula de gráfico, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Hoja de cálculo de gráficos y fórmula en presentación de PowerPoint en C# o .NET"
---

## **Acerca de la Fórmula de Hoja de Cálculo de Gráficos en Presentación**
La **hoja de cálculo de gráficos** (o hoja de trabajo de gráficos) en la presentación es la fuente de datos del gráfico. La hoja de cálculo de gráficos contiene datos, que se representan en el gráfico de manera gráfica. Cuando creas un gráfico en PowerPoint, la hoja de trabajo asociada a este gráfico también se crea automáticamente. La hoja de trabajo de gráficos se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de sol, gráfico circular, etc. Para ver la hoja de cálculo de gráficos en PowerPoint, debes hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La hoja de cálculo de gráficos contiene los nombres de los elementos del gráfico (Nombre de Categoría: *Categoría1*, Nombre de Serie) y una tabla con datos numéricos apropiados a estas categorías y series. Por defecto, cuando creas un nuevo gráfico, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puedes cambiar los datos de la hoja de cálculo en la hoja de trabajo manualmente.

Por lo general, el gráfico representa datos complicados (por ejemplo, analistas financieros, analistas científicos), teniendo celdas que se calculan a partir de los valores en otras celdas o de otros datos dinámicos. Calcular manualmente el valor de una celda y codificarlo en la celda, dificulta cambiarlo en el futuro. Si cambias el valor de una cierta celda, todas las celdas que dependen de ella también deberán ser actualizadas. Además, los datos de la tabla pueden depender de los datos de otras tablas, creando un esquema de datos de presentación complejo que necesita ser actualizado de una manera fácil y flexible.

La **fórmula de hoja de cálculo de gráficos** en presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo de gráficos. La fórmula de la hoja de cálculo define la lógica de cálculo de datos para una cierta celda o un conjunto de celdas. La fórmula de la hoja de cálculo es una fórmula matemática o una fórmula lógica, que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de la hoja de cálculo calcula el valor y lo devuelve, luego este valor se asigna a la celda. Las fórmulas de las hojas de cálculo de gráficos en las presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminadas para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/net/)la hoja de cálculo de gráficos se representa con la propiedad 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) del tipo 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook). 
La fórmula de la hoja de cálculo puede ser asignada y cambiada con la propiedad 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula). 
La siguiente funcionalidad es admitida para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas estilo A1
- Referencias a celdas estilo R1C1
- Funciones predeterminadas

Por lo general, las hojas de cálculo almacenan los últimos valores calculados de la fórmula. Si después de cargar la presentación, los datos del gráfico no se han cambiado, la propiedad **IChartDataCell.Value** devuelve esos valores al leer. Pero, si los datos de la hoja de cálculo han cambiado, al leer la propiedad **ChartDataCell.Value** lanza la **CellUnsupportedDataException** para las fórmulas no admitidas. Esto se debe a que cuando las fórmulas se analizan correctamente, se determinan las dependencias de las celdas y se determina la corrección de los últimos valores. Pero, si la fórmula no puede ser analizada, la corrección del valor de la celda no puede ser garantizada.
## **Agregar Fórmula de Hoja de Cálculo de Gráficos a la Presentación**
Primero, agrega un gráfico con algunos datos de muestra a la primera diapositiva de una nueva presentación con 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1). 
La hoja de trabajo del gráfico se crea automáticamente y puede ser accedida con 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) propiedad:



``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```


Vamos a escribir algunos valores en las celdas con la propiedad 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) 
del tipo **Object**, lo que significa que puedes establecer cualquier valor en la propiedad:



``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```


Ahora para escribir una fórmula en la celda, puedes usar la propiedad 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula):

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Nota*: La propiedad [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) se usa para establecer referencias a celdas estilo A1. 



Para establecer la referencia de celda [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), puedes usar la propiedad [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Luego usa el método [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) para calcular todas las fórmulas dentro del libro de trabajo y actualizar los valores de las celdas correspondientes:



``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Constantes Lógicas**
Puedes usar constantes lógicas como *FALSE* y *TRUE* en las fórmulas de celdas:




## **Constantes Numéricas**
Los números pueden ser utilizados en notaciones comunes o científicas para crear fórmulas de hoja de cálculo de gráficos:




## **Constantes de Cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:




## **Constantes de Error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir entre cero.
- #GETTING_DATA - puede mostrarse en una celda, mientras su valor aún se está calculando.
- #N/A - falta información o no está disponible. Algunas razones pueden ser: las celdas utilizadas en la fórmula están vacías, un carácter de espacio adicional, errores tipográficos, etc.
- #NAME? - una cierta celda u otros objetos de fórmula no pueden ser encontrados por su nombre. 
- #NULL! - puede aparecer cuando hay un error en la fórmula, como:  (,) o un carácter de espacio usado en lugar de un dos puntos (:).
- #NUM! - el numérico en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda no válida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, un valor de cadena establecido en una celda numérica.




## **Operadores Aritméticos**
Puedes usar todos los operadores aritméticos en las fórmulas de hoja de trabajo de gráficos:



|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Suma o más unario|2 + 3|
|- (signo menos) |Resta o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra inclinada)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (caret) |Exponenciación |2 ^ 3|


*Nota*: Para cambiar el orden de evaluación, encierra entre paréntesis la parte de la fórmula que debe ser calculada primero.


## **Operadores de Comparación**
Puedes comparar los valores de las celdas con los operadores de comparación. Cuando dos valores son comparados mediante estos operadores, el resultado es un valor lógico ya sea *TRUE* o FALSE:



|**Operador** |**Significado** |**Significado** |
| :- | :- | :- |
|= (signo de igual) |Igual a |A2 = 3|
|<> (signo de no igual) |No igual a|A2 <> 3|
|> (signo mayor que) |Mayor que|A2 > 3|
|>= (signo mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo menor que)|Menor que|A2 < 3|
|<= (signo menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias de Celdas Estilo A1**
Las **referencias de celdas estilo A1** se utilizan para las hojas de trabajo, donde la columna tiene un identificador de letra (por ejemplo, "*A*") y la fila tiene un identificador numérico (por ejemplo, "*1*"). Las referencias de celdas estilo A1 pueden ser utilizadas de la siguiente manera:



|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí tienes un ejemplo de cómo usar una referencia de celda estilo A1 en la fórmula:




## **Referencias de Celdas Estilo R1C1**
Las **referencias de celdas estilo R1C1** se utilizan para las hojas de trabajo, donde tanto una fila como una columna tienen el identificador numérico. Las referencias de celdas estilo R1C1 pueden ser utilizadas de la siguiente manera:



|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí tienes un ejemplo de cómo usar una referencia de celda estilo A1 en la fórmula:




## **Funciones Predeterminadas**
Existen funciones predeterminadas que pueden ser utilizadas en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más comúnmente utilizadas, como: 

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