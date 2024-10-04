---
title: Fórmulas de Hoja de Cálculo de Gráficos
type: docs
weight: 70
url: /php-java/chart-worksheet-formulas/
keywords: "ecuaciones de powerpoint, fórmulas de hoja de cálculo de powerpoint"
description: "Ecuaciones y Fórmulas de Hoja de Cálculo de PowerPoint"
---

## **Acerca de la Fórmula de Hoja de Cálculo de Gráficos en Presentaciones**
**Hoja de cálculo de gráficos** (o hoja de trabajo de gráficos) en la presentación es la fuente de datos del gráfico. La hoja de cálculo de gráficos contiene datos que se representan en el gráfico de manera gráfica. Cuando creas un gráfico en PowerPoint, la hoja de trabajo asociada con este gráfico se crea automáticamente también. La hoja de trabajo de gráficos se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de sunburst, gráfico de pastel, etc. Para ver la hoja de cálculo de gráficos en PowerPoint, debes hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La hoja de cálculo de gráficos contiene los nombres de los elementos del gráfico (Nombre de Categoría: *Categoría1*, Nombre de Serie) y una tabla con datos numéricos apropiados a estas categorías y series. Por defecto, cuando creas un nuevo gráfico, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puedes cambiar los datos de la hoja de cálculo en la hoja de trabajo manualmente.

Generalmente, el gráfico representa datos complicados (por ejemplo, analistas financieros, analistas científicos), teniendo celdas que se calculan a partir de los valores en otras celdas o de otros datos dinámicos. Calcular el valor de una celda manualmente y codificarlo rígidamente en la celda, hace difícil cambiarlo en el futuro. Si cambias el valor de una cierta celda, todas las celdas dependientes de ella requerirán ser actualizadas también. Además, los datos de la tabla pueden depender de los datos de otras tablas, creando un esquema de datos de presentación complejo que necesita ser actualizado de manera fácil y flexible.

**La fórmula de hoja de cálculo de gráficos** en la presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo de gráficos. La fórmula de la hoja de cálculo define la lógica de cálculo de datos para una cierta celda o un conjunto de celdas. La fórmula de la hoja de cálculo es una fórmula matemática o una fórmula lógica, que utiliza: referencias de celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de la hoja de cálculo calcula el valor y lo devuelve, luego este valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) la hoja de cálculo de gráficos se representa con el método 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) del tipo 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook). 
La fórmula de hoja de cálculo puede ser asignada y cambiada con el método 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-).
La siguiente funcionalidad es admitida para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias de celdas estilo A1
- Referencias de celdas estilo R1C1
- Funciones predefinidas

Por lo general, las hojas de cálculo almacenan los últimos valores de fórmula calculados. Si después de cargar la presentación, los datos del gráfico no cambiaron, el método [**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--) devuelve esos valores al leer. Pero, si los datos de la hoja de cálculo han sido cambiados, al leer la propiedad **ChartDataCell.Value** lanza la excepción [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) para las fórmulas no admitidas. Esto se debe a que cuando las fórmulas se analizan con éxito, se determinan las dependencias de la celda y se determina la corrección de los últimos valores. Pero, si la fórmula no puede ser analizada, no se puede garantizar la corrección del valor de la celda.

## **Agregar Fórmula de Hoja de Cálculo de Gráficos a la Presentación**
Primero, añade un gráfico a la primera diapositiva de una nueva presentación con 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La hoja de trabajo del gráfico se crea automáticamente y se puede acceder con el método 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--):

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Vamos a escribir algunos valores en las celdas con la propiedad 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-) 
de tipo **Object**, lo que significa que puedes establecer cualquier valor en la propiedad:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);
```

Ahora para escribir una fórmula en la celda, puedes usar el método 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-):

*Nota*: El método [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) se usa para establecer referencias de celdas estilo A1.

Para establecer la referencia de celda [R1C1Formula](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getR1C1Formula--), puedes usar el método 
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Luego, si intentas leer los valores de las celdas B2 y C2, serán calculados:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1
```

## **Constantes Lógicas**
Puedes usar constantes lógicas como *FALSE* y *TRUE* en las fórmulas de las celdas:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// el valor contiene booleano "false"
```

## **Constantes Numéricas**
Los números pueden ser usados en notaciones comunes o científicas para crear fórmulas de hoja de cálculo de gráficos:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");
```

## **Constantes de Cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal como es y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");
```

## **Constantes de Error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula trata de dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda, mientras su valor aún se está calculando.
- #N/A - la información está ausente o no disponible. Algunas razones pueden ser: las celdas utilizadas en la fórmula están vacías, un carácter de espacio adicional, errores de escritura, etc.
- #NAME? - una cierta celda u otros objetos de fórmula no se pueden encontrar por su nombre.
- #NULL! - puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio utilizado en lugar de un dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda inválida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, un valor de cadena establecido en una celda numérica.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// el valor contiene la cadena "#DIV/0!"
```

## **Operadores Aritméticos**
Puedes usar todos los operadores aritméticos en las fórmulas de la hoja de trabajo de gráficos:

|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Suma o positivo unario|2 + 3|
|- (signo menos) |Resta o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra inclinada)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (caret) |Exponentiación |2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierra entre paréntesis la parte de la fórmula que se debe calcular primero.

## **Operadores de Comparación**
Puedes comparar los valores de las celdas con los operadores de comparación. Cuando se comparan dos valores utilizando estos operadores, el resultado es un valor lógico ya sea *TRUE* o FALSE:

|**Operador** |**Significado** |**Significado** |
| :- | :- | :- |
|= (signo de igual) |Igual a |A2 = 3|
|<> (signo de no igual) |No igual a|A2 <> 3|
|> (signo de mayor que) |Mayor que|A2 > 3|
|>= (signo de mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo de menor que)|Menor que|A2 < 3|
|<= (signo de menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias de Celdas Estilo A1**
**Las referencias de celdas estilo A1** se usan para las hojas de trabajo, donde la columna tiene un identificador de letra (por ejemplo, "*A*") y la fila tiene un identificador numérico (por ejemplo, "*1*"). Las referencias de celdas estilo A1 se pueden usar de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aquí hay un ejemplo de cómo usar la referencia de celda estilo A1 en una fórmula:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```

## **Referencias de Celdas Estilo R1C1**
**Las referencias de celdas estilo R1C1** se usan para las hojas de trabajo, donde tanto una fila como una columna tienen el identificador numérico. Las referencias de celdas estilo R1C1 se pueden usar de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aquí hay un ejemplo de cómo usar la referencia de celda estilo R1C1 en una fórmula:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funciones Predefinidas**
Hay funciones predefinidas que se pueden usar en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más comúnmente utilizadas, como: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema de fechas de 1900)
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