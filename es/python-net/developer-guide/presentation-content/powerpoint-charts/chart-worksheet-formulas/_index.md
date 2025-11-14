---
title: Aplicar fórmulas de la hoja de cálculo del gráfico en presentaciones con Python
linktitle: Fórmulas de la hoja de cálculo
type: docs
weight: 70
url: /es/python-net/chart-worksheet-formulas/
keywords:
- hoja de cálculo de gráficos
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
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aplicar fórmulas de estilo Excel en las hojas de cálculo de gráficos de Aspose.Slides for Python via .NET y automatizar informes en archivos PPT, PPTX y ODP."
---


## **Acerca de la Fórmula de Hoja de Cálculo de Gráficos en Presentaciones**
**Hoja de cálculo de gráficos** (o hoja de trabajo de gráficos) en la presentación es la fuente de datos del gráfico. La hoja de cálculo de gráficos contiene datos, que se representan en el gráfico de manera gráfica. Cuando creas un gráfico en PowerPoint, la hoja de trabajo asociada con este gráfico también se crea automáticamente. La hoja de cálculo de gráficos se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico de sol, gráfico circular, etc. Para ver la hoja de cálculo de gráficos en PowerPoint debes hacer doble clic en el gráfico:

![todo:texto_alt_imagen](chart-worksheet-formulas_1.png)



La hoja de cálculo de gráficos contiene los nombres de los elementos del gráfico (Nombre de Categoría: *Categoría1*, Nombre de Serie) y una tabla con datos numéricos apropiados a estas categorías y series. Por defecto, cuando creas un nuevo gráfico, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puedes cambiar manualmente los datos de la hoja de cálculo en la hoja de trabajo.

Generalmente, el gráfico representa datos complicados (por ejemplo, analistas financieros, analistas científicos), teniendo celdas que se calculan a partir de los valores en otras celdas o de otros datos dinámicos. Calcular el valor de una celda manualmente y codificarlo de forma rígida en la celda, dificulta cambiarlo en el futuro. Si cambias el valor de una celda determinada, todas las celdas que dependen de ella también deberán actualizarse. Además, los datos de la tabla pueden depender de los datos de otras tablas, creando un esquema de datos de presentación compleja que necesita actualizarse de manera fácil y flexible.

**Fórmula de hoja de cálculo de gráficos** en la presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo de gráficos. La fórmula de la hoja de cálculo define la lógica de cálculo de datos para una celda determinada o un conjunto de celdas. La fórmula de la hoja de cálculo es una fórmula matemática o una fórmula lógica, que utiliza: referencias de celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de la hoja de cálculo calcula el valor y lo devuelve, luego este valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminadas para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) la hoja de cálculo de gráficos se representa con la propiedad 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) del tipo 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/). 
La fórmula de la hoja de cálculo puede ser asignada y cambiada con la propiedad 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/). 
La siguiente funcionalidad es compatible para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias de celdas estilo A1
- Referencias de celdas estilo R1C1
- Funciones predefinidas



Normalmente, las hojas de cálculo almacenan los últimos valores calculados de la fórmula. Si después de cargar la presentación, los datos del gráfico no han cambiado - la propiedad **IChartDataCell.Value** devuelve esos valores al leer. Pero, si los datos de la hoja de cálculo han cambiado, al leer la propiedad **ChartDataCell.Value** lanza la **CellUnsupportedDataException** para las fórmulas no soportadas. Esto se debe a que cuando las fórmulas han sido analizadas con éxito, se determinan las dependencias de las celdas y se verifica la corrección de los últimos valores. Pero, si la fórmula no puede ser analizada, no se puede garantizar la corrección del valor de la celda.
## **Agregar Fórmula de Hoja de Cálculo de Gráficos a la Presentación**
Primero, agrega un gráfico con algunos datos de muestra a la primera diapositiva de una nueva presentación con 
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/). 
La hoja de trabajo del gráfico se crea automáticamente y se puede acceder con la propiedad 
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) :



```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```



Vamos a escribir algunos valores en celdas con la propiedad 
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 
de tipo **Object**, lo que significa que puedes establecer cualquier valor en la propiedad:



```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```



Ahora, para escribir una fórmula en la celda, puedes usar la propiedad 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Nota*: la propiedad [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) se utiliza para establecer referencias de celda estilo A1. 



Para establecer la referencia de celda [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/), puedes usar la propiedad [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Luego, utiliza el método [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) para calcular todas las fórmulas dentro de la hoja de cálculo y actualizar los valores de las celdas correspondientes:



```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **Constantes Lógicas**
Puedes usar constantes lógicas como *FALSE* y *TRUE* en fórmulas de celdas:




## **Constantes Numéricas**
Los números pueden ser utilizados en notaciones comunes o científicas para crear fórmula de hoja de cálculo de gráficos:




## **Constantes de Cadena**
La constante de cadena (o literal) es un valor específico que se utiliza tal cual y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:




## **Constantes de Error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir por cero.
- #GETTING_DATA - puede mostrarse en una celda, mientras su valor todavía se está calculando.
- #N/A - la información está faltante o no disponible. Algunas razones pueden ser: las celdas utilizadas en la fórmula están vacías, un carácter de espacio adicional, error de escritura, etc.
- #NAME? - una celda determinada u otros objetos de fórmula no pueden ser encontrados por su nombre. 
- #NULL! - puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio utilizado en lugar de dos puntos (:).
- #NUM! - el numérico en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda inválida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, valor de cadena establecido en celda numérica.




## **Operadores Aritméticos**
Puedes usar todos los operadores aritméticos en fórmulas de hoja de cálculo de gráficos:



|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Suma o más unario|2 + 3|
|- (signo menos) |Resta o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra inclinada)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (caret) |Exponentiación |2 ^ 3|


*Nota*: Para cambiar el orden de evaluación, encierra entre paréntesis la parte de la fórmula que debe ser calculada primero.


## **Operadores de Comparación**
Puedes comparar los valores de las celdas con los operadores de comparación. Cuando se comparan dos valores utilizando estos operadores, el resultado es un valor lógico ya sea *TRUE* o *FALSE*:



|**Operador** |**Significado** |**Significado** |
| :- | :- | :- |
|= (signo igual) |Igual a |A2 = 3|
|<> (signo de no igual) |No igual a|A2 <> 3|
|> (signo de mayor que) |Mayor que|A2 > 3|
|>= (signo de mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo de menor que)|Menor que|A2 < 3|
|<= (signo de menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias de Celdas Estilo A1**
**Referencias de celdas estilo A1** se utilizan para las hojas de cálculo, donde la columna tiene un identificador de letra (por ejemplo, "*A*") y la fila tiene un identificador numérico (por ejemplo, "*1*"). Las referencias de celdas estilo A1 se pueden usar de la siguiente manera:



|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí hay un ejemplo de cómo usar la referencia de celda estilo A1 en la fórmula:




## **Referencias de Celdas Estilo R1C1**
**Referencias de celdas estilo R1C1** se utilizan para las hojas de cálculo, donde tanto una fila como una columna tienen el identificador numérico. Las referencias de celdas estilo R1C1 se pueden usar de la siguiente manera:



|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí hay un ejemplo de cómo usar la referencia de celda estilo A1 en la fórmula:




## **Funciones Predefinidas**
Hay funciones predefinidas que se pueden usar en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más comúnmente utilizadas, como: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema de fecha 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (forma de referencia)
- LOOKUP (forma de vector)
- MATCH (forma de vector)
- MAX
- SUM
- VLOOKUP