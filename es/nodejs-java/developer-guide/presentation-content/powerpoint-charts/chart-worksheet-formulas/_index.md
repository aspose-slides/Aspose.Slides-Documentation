---
title: Fórmulas de hoja de trabajo de gráfico
type: docs
weight: 70
url: /es/nodejs-java/chart-worksheet-formulas/
keywords: "ecuaciones de PowerPoint, fórmulas de hoja de cálculo de PowerPoint"
description: "Ecuaciones de PowerPoint y fórmulas de hoja de cálculo"
---

## **Acerca de la fórmula de hoja de cálculo de gráfico en la presentación**
**Hoja de cálculo de gráfico** (o hoja de trabajo del gráfico) en una presentación es la fuente de datos del gráfico. La hoja de cálculo contiene datos que se representan en el gráfico de forma gráfica. Cuando crea un gráfico en PowerPoint, la hoja de trabajo asociada a ese gráfico se crea automáticamente. La hoja de trabajo se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de anillos, gráfico circular, etc. Para ver la hoja de cálculo en PowerPoint debe hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


La hoja de cálculo contiene los nombres de los elementos del gráfico (Nombre de categoría: *Category1*, Nombre de serie) y una tabla con datos numéricos correspondientes a esas categorías y series. Por defecto, cuando crea un gráfico nuevo, los datos de la hoja de cálculo se establecen con los datos predeterminados. Luego puede cambiar los datos de la hoja manualmente.

Normalmente, el gráfico representa datos complejos (p. ej., analistas financieros, analistas científicos), con celdas que se calculan a partir de los valores de otras celdas o de datos dinámicos. Calcular el valor de una celda manualmente y codificarlo directamente en la celda dificulta su modificación futura. Si cambia el valor de una celda determinada, todas las celdas dependientes también deberán actualizarse. Además, los datos de la tabla pueden depender de datos de otras tablas, creando un esquema de datos de presentación complejo que necesita actualizarse de forma fácil y flexible.

**La fórmula de hoja de cálculo de gráfico** en la presentación es una expresión que calcula y actualiza automáticamente los datos de la hoja. La fórmula define la lógica de cálculo de datos para una celda o un conjunto de celdas. La fórmula es una fórmula matemática o lógica que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esa celda no contiene un valor simple. La fórmula calcula el valor y lo devuelve, y luego ese valor se asigna a la celda. Las fórmulas de hoja de cálculo en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones predeterminadas, operadores y constantes para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) la hoja de cálculo del gráfico se representa con el método [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) del tipo [**ChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook). La fórmula puede asignarse y modificarse con el método [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-). La siguiente funcionalidad es compatible para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas estilo A1
- Referencias a celdas estilo R1C1
- Funciones predefinidas


Normalmente, las hojas almacenan los últimos valores calculados de las fórmulas. Si después de cargar la presentación los datos del gráfico no se cambiaron, el método [**ChartDataCell.getValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getValue--) devuelve esos valores al leer. Pero, si los datos de la hoja se modificaron, al leer la propiedad **ChartDataCell.Value** se lanza la excepción [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellUnsupportedDataException) por fórmulas no compatibles. Esto se debe a que, cuando las fórmulas se analizan correctamente, se determinan las dependencias de las celdas y la validez de los últimos valores. Si la fórmula no puede analizarse, no se puede garantizar la validez del valor de la celda.

## **Agregar fórmula de hoja de cálculo de gráfico a la presentación**
Primero, agregue un gráfico a la primera diapositiva de una nueva presentación con [ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-). La hoja del gráfico se crea automáticamente y puede accederse con el método [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--):
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Escribamos algunos valores en celdas con la propiedad [**ChartDataCell.setValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) del tipo **Object**, lo que significa que puede asignar cualquier valor a la propiedad:
```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```


Ahora, para escribir una fórmula en la celda, puede usar el método [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-):

*Nota*: el método [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) se usa para establecer referencias a celdas estilo A1.

Para establecer la referencia de celda [R1C1Formula](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--), puede usar el método [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-):

Luego, si lee los valores de las celdas B2 y C2, se calcularán:
```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```


## **Constantes lógicas**
Puede usar constantes lógicas como *FALSE* y *TRUE* en fórmulas de celda:
```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// el valor contiene el booleano "false"
```


## **Constantes numéricas**
Los números pueden usarse en notación común o científica para crear fórmulas de hoja de cálculo de gráfico:
```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:
```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, se muestra el código de error en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! – la fórmula intenta dividir por cero.
- #GETTING_DATA – puede mostrarse en una celda mientras su valor aún se está calculando.
- #N/A – falta información o no está disponible. Algunas causas pueden ser: celdas usadas en la fórmula vacías, un espacio extra, error ortográfico, etc.
- #NAME? – no se puede encontrar una celda u otro objeto de fórmula por su nombre.
- #NULL! – puede aparecer cuando hay un error en la fórmula, como (,) o un espacio en lugar de dos puntos (:).
- #NUM! – el número en la fórmula es inválido, demasiado largo o demasiado pequeño, etc.
- #REF! – referencia de celda no válida.
- #VALUE! – tipo de valor inesperado. Por ejemplo, valor de cadena asignado a una celda numérica.
```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// el valor contiene la cadena "#DIV/0!"
```


## **Operadores aritméticos**
Puede usar todos los operadores aritméticos en fórmulas de hoja de cálculo de gráfico:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|+ (signo más)|Suma o signo positivo unario|2 + 3|
|- (signo menos)|Resta o negación|2 - 3<br>-3|
|* (asterisco)|Multiplicación|2 * 3|
|/ (barra diagonal)|División|2 / 3|
|% (signo de porcentaje)|Porcentaje|30%|
|^ (caret)|Exponenciación|2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierre entre paréntesis la parte de la fórmula que se debe calcular primero.

## **Operadores de comparación**
Puede comparar los valores de celdas con los operadores de comparación. Cuando dos valores se comparan con estos operadores, el resultado es un valor lógico *TRUE* o *FALSE*:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|= (signo igual)|Igual a|A2 = 3|
|<> (signo distinto)|Distinto de|A2 <> 3|
|> (mayor que)|Mayor que|A2 > 3|
|>= (mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias a celdas estilo A1**
**Las referencias a celdas estilo A1** se usan en hojas donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila un identificador numérico (p. ej., "*1*"). Las referencias estilo A1 pueden usarse de la siguiente manera:

|**Referencia a celda**|**Ejemplo**|**Absoluta**|**Relativa**|**Mixta**|
| :- | :- | :- | :- | :- |
|Celda|$A$2|A2|A$2<br>$A2|
|Fila|$2:$2|2:2|-|
|Columna|$A:$A|A:A|-|
|Rango|$A$2:$C$4|A2:C4|$A$2:C4<br>A$2:$C4|

Aquí hay un ejemplo de cómo usar una referencia estilo A1 en una fórmula:
```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **Referencias a celdas estilo R1C1**
**Las referencias a celdas estilo R1C1** se usan en hojas donde tanto la fila como la columna tienen identificadores numéricos. Las referencias estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia a celda**|**Ejemplo**|**Absoluta**|**Relativa**|**Mixta**|
| :- | :- | :- | :- | :- |
|Celda|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila|R2|R[2]|-|
|Columna|C3|C[3]|-|
|Rango|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aquí hay un ejemplo de cómo usar una referencia estilo R1C1 en una fórmula:
```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Funciones predefinidas**
Existen funciones predefinidas que pueden usarse en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más comunes, como:

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

**¿Se admiten archivos de Excel externos como fuente de datos para un gráfico con fórmulas?**

Sí. Aspose.Slides admite libros de trabajo externos como [fuente de datos del gráfico](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatasourcetype/), lo que le permite usar fórmulas de un archivo XLSX fuera de la presentación.

**¿Pueden las fórmulas del gráfico referenciar hojas dentro del mismo libro por nombre de hoja?**

Sí. Las fórmulas siguen el modelo de referencias estándar de Excel, por lo que puede referenciar otras hojas dentro del mismo libro o en un libro externo. Para referencias externas, incluya la ruta y el nombre del libro usando la sintaxis de Excel.