---
title: Aplicar fórmulas de hoja de cálculo de gráficos en presentaciones usando Java
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/java/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
- hoja de trabajo del gráfico
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
- Java
- Aspose.Slides
description: "Aplicar fórmulas estilo Excel en Aspose.Slides para Java en hojas de trabajo de gráficos y automatizar informes en archivos PPT y PPTX."
---

## **Acerca de las fórmulas de hoja de cálculo de gráficos en presentaciones**
**Chart spreadsheet** (o chart worksheet) en la presentación es la fuente de datos del gráfico. Chart spreadsheet contiene datos, que se representan en el gráfico de forma gráfica. Cuando crea un gráfico en PowerPoint, la hoja de cálculo asociada a este gráfico se crea automáticamente también. Chart worksheet se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de ráfaga, gráfico circular, etc. Para ver la hoja de cálculo del gráfico en PowerPoint debe hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet contiene los nombres de los elementos del gráfico (Category Name: *Category1*, Serie Name) y una tabla con datos numéricos apropiados a estas categorías y series. Por defecto, cuando crea un gráfico nuevo, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puede cambiar los datos de la hoja manualmente.

Normalmente, el gráfico representa datos complejos (p. ej., analistas financieros, analistas científicos), teniendo celdas calculadas a partir de los valores en otras celdas o de otros datos dinámicos. Calcular manualmente el valor de una celda y codificarlo de forma fija en la celda dificulta su modificación futura. Si cambia el valor de una celda determinada, todas las celdas dependientes también deberán actualizarse. Además, los datos de la tabla pueden depender de datos de otras tablas, creando un esquema de datos de presentación complejo que necesita actualizarse de forma sencilla y flexible.

**Chart spreadsheet formula** en una presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una celda determinada o un conjunto de celdas. La fórmula de hoja de cálculo es una fórmula matemática o lógica, que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, luego este valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/java/) chart spreadsheet se representa con 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) método del
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) tipo. 
La fórmula de hoja de cálculo puede asignarse y modificarse con 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) método. 
La siguiente funcionalidad está soportada para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas estilo A1
- Referencias a celdas estilo R1C1
- Funciones predefinidas


Normalmente, las hojas de cálculo almacenan los últimos valores calculados de las fórmulas. Si, después de cargar la presentación, los datos del gráfico no se cambiaron, el método [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) devuelve esos valores al leer. Pero, si los datos de la hoja se modificaron, al leer la propiedad **ChartDataCell.Value** se lanza la excepción [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) para las fórmulas no admitidas. Esto ocurre porque cuando las fórmulas se analizan correctamente, se determinan las dependencias de las celdas y la validez de los últimos valores. Pero, si la fórmula no se puede analizar, no se puede garantizar la exactitud del valor de la celda.

## **Agregar una fórmula de hoja de cálculo de gráfico a una presentación**
Primero, agregue un gráfico a la primera diapositiva de una nueva presentación con 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
La hoja de cálculo del gráfico se crea automáticamente y puede accederse con 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) método:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


Escribamos algunos valores en celdas con 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) propiedad 
del tipo **Object**, lo que significa que puede establecer cualquier valor en la propiedad:
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


Ahora, para escribir una fórmula en la celda, puede usar el 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) método:

*Nota*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) se usa para establecer referencias a celdas estilo A1. 

Para establecer la referencia de celda [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) , puede usar el método [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Luego, si intenta leer los valores de las celdas B2 y C2, se calcularán:
```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **Constantes lógicas**
Puede usar constantes lógicas como *FALSE* y *TRUE* en fórmulas de celdas:
```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // el valor contiene booleano "false"
```


## **Constantes numéricas**
Los números pueden usarse en notaciones comunes o científicas para crear fórmulas de hoja de cálculo de gráficos:
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, se muestra el código de error en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda mientras su valor aún se está calculando.
- #N/A - falta información o no está disponible. Algunas causas pueden ser: las celdas usadas en la fórmula están vacías, un carácter de espacio extra, error ortográfico, etc.
- #NAME? - no se puede encontrar una celda o otro objeto de fórmula por su nombre. 
- #NULL! - puede aparecer cuando hay un error en la fórmula, como:  (,) o un carácter de espacio usado en lugar de dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda inválida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, valor de cadena asignado a una celda numérica.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // el valor contiene la cadena "#DIV/0!"
```


## **Operadores aritméticos**
Puede usar todos los operadores aritméticos en fórmulas de la hoja de cálculo del gráfico:

|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Suma o signo unario positivo|2 + 3|
|- (signo menos) |Resta o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra inclinada)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (caret) |Exponenciación |2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierre entre paréntesis la parte de la fórmula que debe calcularse primero.

## **Operadores de comparación**
Puede comparar los valores de celdas con los operadores de comparación. Cuando se comparan dos valores usando estos operadores, el resultado es un valor lógico *TRUE* o FALSE:

|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|= (signo igual) |Igual a |A2 = 3|
|<> (signo distinto) |Distinto de|A2 <> 3|
|> (signo mayor que) |Mayor que|A2 > 3|
|>= (signo mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo menor que)|Menor que|A2 < 3|
|<= (signo menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias a celdas estilo A1**
**Las referencias a celdas estilo A1** se usan para las hojas de cálculo, donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila tiene un identificador numérico (p. ej., "*1*"). Las referencias a celdas estilo A1 pueden usarse de la siguiente manera:

|**Referencia a celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí hay un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **Referencias a celdas estilo R1C1**
**Las referencias a celdas estilo R1C1** se usan para las hojas de cálculo, donde tanto la fila como la columna tienen identificador numérico. Las referencias a celdas estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia a celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí hay un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


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

Sí. Aspose.Slides admite libros de trabajo externos como [fuente de datos del gráfico](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatasourcetype/), lo que le permite usar fórmulas de un XLSX fuera de la presentación.

**¿Pueden las fórmulas de gráficos referenciar hojas dentro del mismo libro por nombre de hoja?**

Sí. Las fórmulas siguen el modelo de referencia estándar de Excel, por lo que puede referenciar otras hojas dentro del mismo libro o de un libro externo. Para referencias externas, incluya la ruta y el nombre del libro usando la sintaxis de Excel.