---
title: Fórmulas de Hoja de Cálculo de Gráficos
type: docs
weight: 70
url: /es/androidjava/chart-worksheet-formulas/
keywords: "ecuaciones de powerpoint, fórmulas de hoja de cálculo de powerpoint"
description: "Ecuaciones y Fórmulas de Hoja de Cálculo de PowerPoint"
---


## **Acerca de la Fórmula de Hoja de Cálculo de Gráficos en Presentaciones**
La **hoja de cálculo de gráficos** (o hoja de trabajo de gráficos) en una presentación es la fuente de datos del gráfico. La hoja de cálculo de gráficos contiene datos, que se representan de manera gráfica en el gráfico. Cuando creas un gráfico en PowerPoint, la hoja de trabajo asociada a este gráfico también se crea automáticamente. La hoja de trabajo de gráficos se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de tipo "sunburst", gráfico circular, etc. Para ver la hoja de cálculo de gráficos en PowerPoint, debes hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


La hoja de cálculo de gráficos contiene los nombres de los elementos del gráfico (Nombre de la Categoría: *Categoría1*, Nombre de la Serie) y una tabla con datos numéricos apropiados para estas categorías y series. Por defecto, cuando creas un nuevo gráfico, los datos de la hoja de cálculo del gráfico se configuran con los datos predeterminados. Luego puedes cambiar los datos de la hoja de cálculo en la hoja de trabajo manualmente.

Por lo general, el gráfico representa datos complicados (por ejemplo, analistas financieros, analistas científicos), teniendo celdas que se calculan a partir de los valores en otras celdas o de otros datos dinámicos. Calcular manualmente el valor de una celda y codificarlo en la celda, hace que sea difícil cambiarlo en el futuro. Si cambias el valor de una celda determinada, todas las celdas que dependen de ella requerirán ser actualizadas también. Además, los datos de la tabla pueden depender de los datos de otras tablas, creando un esquema de datos de presentación complejo que necesita ser actualizado de manera fácil y flexible.

La **fórmula de hoja de cálculo de gráficos** en una presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una celda determinada o un conjunto de celdas. La fórmula de hoja de cálculo es una fórmula matemática o lógica, que utiliza: referencias de celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, luego este valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) la hoja de cálculo de gráficos se representa con el método [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook). 
La fórmula de hoja de cálculo puede ser asignada y cambiada con el método [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) . 
La siguiente funcionalidad es compatible con las fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias de celdas estilo A1
- Referencias de celdas estilo R1C1
- Funciones predefinidas


Por lo general, las hojas de cálculo almacenan los últimos valores de fórmula calculados. Si, después de cargar la presentación, los datos del gráfico no se han cambiado, el método [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) devuelve esos valores al leer. Pero, si los datos de la hoja de cálculo han sido cambiados, al leer la propiedad **ChartDataCell.Value** lanza la excepción [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) para las fórmulas no soportadas. Esto se debe a que cuando las fórmulas se analizan con éxito, se determinan las dependencias de las celdas y se determina la corrección de los últimos valores. Pero, si la fórmula no puede ser analizada, la corrección del valor de la celda no puede ser garantizada.

## **Agregar Fórmula de Hoja de Cálculo de Gráficos a la Presentación**
Primero, agrega un gráfico a la primera diapositiva de una nueva presentación con [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La hoja de trabajo del gráfico se crea automáticamente y se puede acceder con el método [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) :

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

Vamos a escribir algunos valores en celdas con la propiedad [**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) del tipo **Object**, lo que significa que puedes establecer cualquier valor en la propiedad:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Ahora, para escribir una fórmula en la celda, puedes usar el método [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Nota*: el método  [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) se utiliza para establecer referencias de celdas estilo A1. 

Para establecer la referencia de celda [R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) , puedes usar el método [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Entonces, si intentas leer los valores de las celdas B2 y C2, se calcularán:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Constantes Lógicas**
Puedes usar constantes lógicas como *FALSE* y *TRUE* en las fórmulas de las celdas:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // el valor contiene booleano "false"
```

## **Constantes Numéricas**
Los números se pueden usar en notaciones comunes o científicas para crear fórmulas de hoja de cálculo de gráficos:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Constantes de Cadena**
Una constante de cadena (o literal) es un valor específico que se utiliza tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Constantes de Error**
A veces no es posible calcular el resultado por la fórmula. En ese caso, se muestra el código de error en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda, mientras su valor todavía se está calculando.
- #N/A - falta información o no está disponible. Algunas razones pueden ser: las celdas utilizadas en la fórmula están vacías, un carácter de espacio extra, errores de escritura, etc.
- #NAME? - no se puede encontrar una celda determinada u otros objetos de fórmula por su nombre. 
- #NULL! - puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio utilizado en lugar de dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda inválida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, valor de cadena establecido en celda numérica.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // el valor contiene la cadena "#DIV/0!"
```

## **Operadores Aritméticos**
Puedes usar todos los operadores aritméticos en las fórmulas de hoja de cálculo de gráficos:

|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Adición o más unario|2 + 3|
|- (signo menos) |Sustracción o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra inclinada)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (caret) |Exponentiación |2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierra entre paréntesis la parte de la fórmula que se debe calcular primero.

## **Operadores de Comparación**
Puedes comparar los valores de las celdas con los operadores de comparación. Cuando se comparan dos valores utilizando estos operadores, el resultado es un valor lógico ya sea *TRUE* o FALSE:

|**Operador** |**Significado** |**Significado** |
| :- | :- | :- |
|= (signo igual) |Igual a |A2 = 3|
|<> (signo de no igual) |No igual a|A2 <> 3|
|> (signo de mayor que) |Mayor que|A2 > 3|
|>= (signo de mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo de menor que)|Menor que|A2 < 3|
|<= (signo de menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias de Celdas Estilo A1**
Las **referencias de celdas estilo A1** se utilizan para las hojas de cálculo, donde la columna tiene un identificador de letra (por ejemplo, "*A*") y la fila tiene un identificador numérico (por ejemplo, "*1*"). Las referencias de celdas estilo A1 se pueden utilizar de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí hay un ejemplo de cómo usar la referencia de celda estilo A1 en una fórmula:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Referencias de Celdas Estilo R1C1**
Las **referencias de celdas estilo R1C1** se utilizan para las hojas de cálculo, donde tanto una fila como una columna tienen un identificador numérico. Las referencias de celdas estilo R1C1 se pueden utilizar de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí hay un ejemplo de cómo usar la referencia de celda estilo A1 en una fórmula:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funciones Predefinidas**
Existen funciones predefinidas que se pueden usar en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más comúnmente utilizadas, como: 

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