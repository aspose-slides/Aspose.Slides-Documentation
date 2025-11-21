---
title: Aplicar fórmulas de hoja de cálculo de gráfico en presentaciones con Python
linktitle: Fórmulas de hoja de cálculo
type: docs
weight: 70
url: /es/python-net/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráfico
- hoja de trabajo de gráfico
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
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aplicar fórmulas al estilo Excel en Aspose.Slides para Python mediante hojas de cálculo de gráfico .NET y automatizar informes en archivos PPT, PPTX y ODP."
---

## **Acerca de la fórmula de hoja de cálculo de gráfico en la presentación**
**Chart spreadsheet** (o hoja de cálculo de gráfico) en una presentación es la fuente de datos del gráfico. La hoja de cálculo del gráfico contiene datos, que se representan en el gráfico de forma gráfica. Cuando crea un gráfico en PowerPoint, la hoja de cálculo asociada a ese gráfico se crea automáticamente. La hoja de cálculo del gráfico se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de explosión, gráfico circular, etc. Para ver la hoja de cálculo del gráfico en PowerPoint debe hacer doble clic en el gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La hoja de cálculo del gráfico contiene los nombres de los elementos del gráfico (Nombre de categoría: *Category1*, Nombre de serie) y una tabla con datos numéricos correspondientes a esas categorías y series. Por defecto, cuando crea un gráfico nuevo, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puede cambiar los datos de la hoja manualmente.

Normalmente, el gráfico representa datos complejos (p. ej., analistas financieros, analistas científicos), con celdas que se calculan a partir de los valores de otras celdas o de otros datos dinámicos. Calcular el valor de una celda manualmente y codificarlo directamente en la celda dificulta su modificación futura. Si cambia el valor de una celda determinada, todas las celdas dependientes de ella también deberán actualizarse. Además, los datos de la tabla pueden depender de datos de otras tablas, creando un esquema de datos de presentación complejo que necesita ser actualizado de forma fácil y flexible.

**Chart spreadsheet formula** en la presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo del gráfico. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una celda o conjunto de celdas. La fórmula de hoja de cálculo es una fórmula matemática o lógica, que usa: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esa celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, y luego ese valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) la hoja de cálculo del gráfico se representa con la propiedad [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/). La fórmula de hoja de cálculo puede asignarse y modificarse con la propiedad [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/). La siguiente funcionalidad está soportada para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas estilo A1
- Referencias a celdas estilo R1C1
- Funciones predefinidas



Normalmente, las hojas de cálculo almacenan los últimos valores calculados de las fórmulas. Si después de cargar la presentación los datos del gráfico no se cambiaron, la propiedad **IChartDataCell.Value** devuelve esos valores al leer. Pero, si los datos de la hoja se modificaron, al leer la propiedad **ChartDataCell.Value** se lanza la excepción **CellUnsupportedDataException** por las fórmulas no admitidas. Esto ocurre porque, cuando las fórmulas se analizan correctamente, se determinan las dependencias de celdas y la corrección de los últimos valores. Sin embargo, si la fórmula no puede analarse, no se puede garantizar la corrección del valor de la celda.
## **Agregar fórmula de hoja de cálculo de gráfico a la presentación**
Primero, agregue un gráfico con algunos datos de ejemplo a la primera diapositiva de una nueva presentación con [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/). La hoja de cálculo del gráfico se crea automáticamente y puede accederse con la propiedad [**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/):
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```




Escribamos algunos valores en celdas con la propiedad [**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) del tipo **Object**, lo que significa que puede establecer cualquier valor en la propiedad:
```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```




Ahora, para escribir una fórmula en la celda, puede usar la propiedad [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/):
```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```


*Nota*: La propiedad [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) se usa para establecer referencias a celdas estilo A1. 



Para establecer la referencia de celda [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/), puede usar la propiedad [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/):
```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```


Luego use el método [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) para calcular todas las fórmulas dentro del libro y actualizar los valores de las celdas correspondientes:
```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```



## **Constantes lógicas**
Puede usar constantes lógicas como *FALSE* y *TRUE* en las fórmulas de celda:




## **Constantes numéricas**
Los números pueden usarse en notación común o científica para crear fórmulas de hoja de cálculo de gráfico:




## **Constantes de cadena**
Una constante de cadena (o literal) es un valor específico que se usa tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:




## **Constantes de error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda mientras su valor todavía se está calculando.
- #N/A - falta información o no está disponible. Algunas razones pueden ser: las celdas usadas en la fórmula están vacías, un carácter de espacio extra, error ortográfico, etc.
- #NAME? - no se puede encontrar una cierta celda u otro objeto de fórmula por su nombre.
- #NULL! - puede aparecer cuando hay un error en la fórmula, como:  (,) o un carácter de espacio usado en lugar de dos puntos (:).
- #NUM! - el número en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia a celda inválida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, valor de cadena asignado a una celda numérica.




## **Operadores aritméticos**
Puede usar todos los operadores aritméticos en las fórmulas de la hoja de cálculo del gráfico:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|+ (signo más)|Suma o signo positivo unario|2 + 3|
|- (signo menos)|Resta o negación|2 - 3<br>-3|
|* (asterisco)|Multiplicación|2 * 3|
|/ (barra inclinada)|División|2 / 3|
|% (signo de porcentaje)|Porcentaje|30%|
|^ (acento circunflejo)|Exponenciación|2 ^ 3|

*Nota*: Para cambiar el orden de evaluación, encierre entre paréntesis la parte de la fórmula que debe calcularse primero.


## **Operadores de comparación**
Puede comparar los valores de las celdas con los operadores de comparación. Cuando se comparan dos valores con estos operadores, el resultado es un valor lógico *TRUE* o FALSE:

|**Operador**|**Significado**|**Ejemplo**|
| :- | :- | :- |
|= (signo igual)|Igual a|A2 = 3|
|<> (signo distinto)|Distinto de|A2 <> 3|
|> (signo mayor que)|Mayor que|A2 > 3|
|>= (signo mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo menor que)|Menor que|A2 < 3|
|<= (signo menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias a celdas estilo A1**
**Las referencias a celdas estilo A1** se usan para las hojas donde la columna tiene un identificador de letra (p. ej., "*A*") y la fila tiene un identificador numérico (p. ej., "*1*"). Las referencias estilo A1 pueden usarse de la siguiente manera:

|**Referencia**|**Ejemplo**|**Absoluta**|**Relativa**|**Mixta**|
| :- | :- | :- | :- | :- |
|Celda|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Fila|$2:$2|2:2|-|
|Columna|$A:$A|A:A|-|
|Rango|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

A continuación se muestra un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:




## **Referencias a celdas estilo R1C1**
**Las referencias a celdas estilo R1C1** se usan para las hojas donde tanto la fila como la columna tienen identificador numérico. Las referencias estilo R1C1 pueden usarse de la siguiente manera:

|**Referencia**|**Ejemplo**|**Absoluta**|**Relativa**|**Mixta**|
| :- | :- | :- | :- | :- |
|Celda|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila|R2|R[2]|-|
|Columna|C3|C[3]|-|
|Rango|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

A continuación se muestra un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:




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

## **Preguntas frecuentes**

**¿Se admiten archivos Excel externos como fuente de datos para un gráfico con fórmulas?**

Sí. Aspose.Slides admite libros externos como [fuente de datos de un gráfico](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/), lo que permite usar fórmulas de un XLSX fuera de la presentación.

**¿Pueden las fórmulas de un gráfico referenciar hojas dentro del mismo libro por nombre de hoja?**

Sí. Las fórmulas siguen el modelo estándar de referencias de Excel, por lo que puede referenciar otras hojas dentro del mismo libro o un libro externo. Para referencias externas, incluya la ruta y el nombre del libro usando la sintaxis de Excel.