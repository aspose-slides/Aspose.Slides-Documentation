---
title: Aplicar fórmulas de hoja de cálculo de gráficos en presentaciones usando PHP
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/php-java/chart-worksheet-formulas/
keywords:
- hoja de cálculo del gráfico
- hoja de trabajo del gráfico
- fórmula de gráfico
- fórmula de hoja de trabajo
- fórmula de hoja de cálculo
- origen de datos
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
- PHP
- Aspose.Slides
description: "Aplicar fórmulas al estilo de Excel en Aspose.Slides para PHP mediante hojas de trabajo de gráficos Java y automatizar informes en archivos PPT y PPTX."
---

## **Acerca de las fórmulas de hoja de cálculo del gráfico en presentaciones**
**Hoja de cálculo del gráfico** (o hoja de cálculo del gráfico) en una presentación es el origen de datos del gráfico. La hoja de cálculo del gráfico contiene datos que se representan en el gráfico de forma gráfica. Cuando crea un gráfico en PowerPoint, la hoja de cálculo asociada a este gráfico se crea automáticamente también. La hoja de cálculo del gráfico se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de explosión, gráfico circular, etc. Para ver la hoja de cálculo del gráfico en PowerPoint debe hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


La hoja de cálculo del gráfico contiene los nombres de los elementos del gráfico (Nombre de categoría: *Category1*, Nombre de serie) y una tabla con datos numéricos apropiados a esas categorías y series. Por defecto, cuando crea un gráfico nuevo, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puede cambiar los datos de la hoja de cálculo en la hoja manualmente.

Normalmente, el gráfico representa datos complejos (p. ej., analistas financieros, analistas científicos), con celdas que se calculan a partir de los valores de otras celdas o de otros datos dinámicos. Calcular manualmente el valor de una celda y codificarlo duro en la celda dificulta su cambio futuro. Si cambia el valor de una celda determinada, todas las celdas dependientes de ella también requerirán actualización. Además, los datos de la tabla pueden depender de los datos de otras tablas, creando un esquema de datos de presentación complejo que necesita ser actualizado de forma fácil y flexible.

**Fórmula de hoja de cálculo del gráfico** en una presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una celda determinada o un conjunto de celdas. La fórmula de hoja de cálculo es una fórmula matemática o lógica que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, luego ese valor se asigna a la celda. Las fórmulas de hoja de cálculo del gráfico en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) la hoja de cálculo del gráfico está representada con el método
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) del tipo
[**ChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
Una fórmula de hoja de cálculo puede asignarse y modificarse con el método
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula).
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


Normalmente, las hojas de cálculo almacenan los últimos valores calculados de las fórmulas. Si después de cargar la presentación los datos del gráfico no se cambiaron, el método [**ChartDataCell::getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#getValue) devuelve esos valores al leer. Pero, si los datos de la hoja de cálculo se han cambiado, al leer el valor se lanza la excepción [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) para las fórmulas no admitidas. Esto ocurre porque cuando las fórmulas se analizan con éxito, se determinan las dependencias de las celdas y la corrección de los últimos valores. Pero, si la fórmula no puede analizarse, no se puede garantizar la corrección del valor de la celda.

## **Añadir una fórmula de hoja de cálculo del gráfico a una presentación**
Primero, añada un gráfico a la primera diapositiva de una presentación nueva con
[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart).
La hoja de cálculo del gráfico se crea automáticamente y puede accederse con el método
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook):
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


Escribamos algunos valores en celdas con el método
[**ChartDataCell::setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) del tipo **Object**, lo que significa que puede establecer cualquier valor:
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```


Ahora, para escribir una fórmula en la celda, puede usar el método
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula).

*Nota*: el método [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) se usa para establecer referencias a celdas estilo A1.

Para establecer una fórmula en estilo R1C1, puede usar el método [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Entonces, si intenta leer los valores de las celdas B2 y C2, serán calculados:
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **Constantes lógicas**
Puede usar constantes lógicas como *FALSE* y *TRUE* en fórmulas de celdas:
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// el valor contiene el booleano "false"
```


## **Constantes numéricas**
Los números pueden usarse en notaciones comunes o científicas para crear fórmulas de hoja de cálculo del gráfico:
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");
```


## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");
```


## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, se muestra el código de error en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! – la fórmula intenta dividir por cero.
- #GETTING_DATA – puede mostrarse en una celda mientras su valor aún se está calculando.
- #N/A – falta información o no está disponible. Algunas causas pueden ser: las celdas usadas en la fórmula están vacías, hay un carácter de espacio extra, error ortográfico, etc.
- #NAME? – no se puede encontrar una celda determinada u otro objeto de fórmula por su nombre.
- #NULL! – puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio usado en lugar de dos puntos (:).
- #NUM! – el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! – referencia a celda inválida.
- #VALUE! – tipo de valor inesperado. Por ejemplo, valeur de cadena asignada a una celda numérica.
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// el valor contiene la cadena "#DIV/0!"


```


## **Operadores aritméticos**
Puede usar todos los operadores aritméticos en fórmulas de hoja de cálculo del gráfico:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|+ (signo más)|Suma o más unario|2 + 3|
|- (signo menos)|Resta o negación|2 - 3<br>-3|
|* (asterisco)|Multiplicación|2 * 3|
|/ (barra)|División|2 / 3|
|% (porcentaje)|Porcentaje|30%|
|^ (caret)|Exponenciación|2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierre entre paréntesis la parte de la fórmula que se debe calcular primero.

## **Operadores de comparación**
Puede comparar los valores de celdas con los operadores de comparación. Cuando dos valores se comparan usando estos operadores, el resultado es un valor lógico *TRUE* o *FALSE*:

|**Operador**|**Significado**|**Significado**|
| :- | :- | :- |
|= (signo igual)|Igual a|A2 = 3|
|<> (signo no igual)|No igual a|A2 <> 3|
|> (mayor que)|Mayor que|A2 > 3|
|>= (mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias a celdas estilo A1**
**Las referencias a celdas estilo A1** se usan para las hojas de cálculo, donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila tiene un identificador numérico (p. ej., "*1*"). Las referencias a celdas estilo A1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta|Relativa|Mixta|
|Celda|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Fila|$2:$2|2:2|-|
|Columna|$A:$A|A:A|-|
|Rango|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí hay un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **Referencias a celdas estilo R1C1**
**Las referencias a celdas estilo R1C1** se usan para las hojas de cálculo, donde tanto la fila como la columna tienen identificador numérico. Las referencias a celdas estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta|Relativa|Mixta|
|Celda|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila|R2|R[2]|-|
|Columna|C3|C[3]|-|
|Rango|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí hay un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


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

**¿Se admiten archivos Excel externos como origen de datos para un gráfico con fórmulas?**

Sí. Aspose.Slides admite libros de trabajo externos como [origen de datos del gráfico](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/), lo que le permite usar fórmulas de un XLSX fuera de la presentación.

**¿Pueden las fórmulas de gráfico referenciar hojas dentro del mismo libro de trabajo por nombre de hoja?**

Sí. Las fórmulas siguen el modelo de referencia estándar de Excel, por lo que puede referenciar otras hojas dentro del mismo libro de trabajo o un libro externo. Para referencias externas, incluya la ruta y el nombre del libro usando la sintaxis de Excel.