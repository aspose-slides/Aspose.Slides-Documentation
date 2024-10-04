---
title: Fórmulas de Hoja de Cálculo de Gráficos
type: docs
weight: 70
url: /cpp/chart-worksheet-formulas/
keywords: "ecuaciones de powerpoint, fórmulas de hoja de cálculo de powerpoint"
description: "Ecuaciones y Fórmulas de Hoja de Cálculo de PowerPoint"
---


## **Acerca de la Fórmula de Hoja de Cálculo de Gráficos en Presentaciones**
La **hoja de cálculo de gráficos** (o hoja de trabajo de gráficos) en una presentación es la fuente de datos del gráfico. La hoja de cálculo de gráficos contiene datos que se representan en el gráfico de manera gráfica. Cuando creas un gráfico en PowerPoint, la hoja de trabajo asociada a este gráfico se crea automáticamente también. La hoja de trabajo de gráficos se crea para todos los tipos de gráficos: gráfico de líneas, gráfico de barras, gráfico circular, gráfico de pastel, etc. Para ver la hoja de cálculo de gráficos en PowerPoint, debes hacer doble clic en el gráfico:

![todo:texto_alt_imagen](chart-worksheet-formulas_1.png)



La hoja de cálculo de gráficos contiene los nombres de los elementos del gráfico (Nombre de la categoría: *Categoría1*, Nombre de la serie) y una tabla con datos numéricos apropiados a estas categorías y series. Por defecto, cuando creas un nuevo gráfico, los datos de la hoja de cálculo del gráfico se establecen con los datos predeterminados. Luego puedes cambiar manualmente los datos de la hoja de cálculo en la hoja de trabajo.

Por lo general, el gráfico representa datos complicados (ej. analistas financieros, analistas científicos), teniendo celdas que son calculadas a partir de los valores en otras celdas o de otros datos dinámicos. Calcular el valor de una celda manualmente y codificarlo en la celda, hace que sea difícil cambiarlo en el futuro. Si cambias el valor de una cierta celda, todas las celdas dependientes de ella también necesitarán ser actualizadas. Además, los datos de la tabla pueden depender de los datos de otras tablas, creando un esquema de datos de presentación complejo que necesita ser actualizado de manera fácil y flexible.

La **fórmula de hoja de cálculo de gráficos** en una presentación es una expresión para calcular y actualizar automáticamente los datos de la hoja de cálculo de gráficos. La fórmula de hoja de cálculo define la lógica de cálculo de datos para una cierta celda o un conjunto de celdas. La fórmula de hoja de cálculo es una fórmula matemática o una fórmula lógica, que utiliza: referencias a celdas, funciones matemáticas, operadores lógicos, operadores aritméticos, funciones de conversión, constantes de cadena, etc. La definición de la fórmula se escribe en una celda, y esta celda no contiene un valor simple. La fórmula de hoja de cálculo calcula el valor y lo devuelve, luego este valor se asigna a la celda. Las fórmulas de hoja de cálculo de gráficos en presentaciones son en realidad las mismas que las fórmulas de Excel, y se admiten las mismas funciones, operadores y constantes predeterminados para su implementación.

En [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) la hoja de cálculo de gráficos se representa con el método 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) del tipo 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
La fórmula de hoja de cálculo puede ser asignada y cambiada con el método 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
La siguiente funcionalidad es compatible para fórmulas en Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadena
- Constantes de error
- Operadores aritméticos
- Operadores de comparación
- Referencias a celdas estilo A1
- Referencias a celdas estilo R1C1
- Funciones predefinidas



Por lo general, las hojas de cálculo almacenan los últimos valores de fórmula calculados. Si después de cargar la presentación, los datos del gráfico no han cambiado, el método **IChartDataCell.get_Value()** devuelve esos valores mientras se lee. Pero, si los datos de la hoja de cálculo han cambiado, al leer el método **ChartDataCell.get_Value()** lanza la **CellUnsupportedDataException** para las fórmulas no soportadas. Esto se debe a que cuando las fórmulas se analizan correctamente, se determinan las dependencias de las celdas y se determina la precisión de los últimos valores. Sin embargo, si la fórmula no se puede analizar, no se puede garantizar la precisión del valor de la celda.


## **Agregar Fórmula de Hoja de Cálculo de Gráficos a la Presentación**
Primero, agrega un gráfico a la primera diapositiva de una nueva presentación con 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
La hoja de trabajo del gráfico se crea automáticamente y se puede acceder con el método 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Ahora escribamos algunos valores en las celdas con el método 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 
de tipo **Object**, lo que significa que puedes pasar cualquier valor al método:



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Ahora, para escribir una fórmula en la celda, puedes usar el método 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):





*Nota*: El método [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) se utiliza para establecer referencias a celdas estilo A1. 



Para establecer la referencia de celda R1C1, puedes usar el método [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):





Luego, si intentas leer los valores de las celdas B2 y C2, se calcularán:



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Constantes Lógicas**
Puedes usar constantes lógicas como *FALSO* y *VERDADERO* en fórmulas de celdas:




## **Constantes Numéricas**
Los números pueden ser utilizados en notaciones comunes o científicas para crear fórmulas de hojas de cálculo de gráficos:




## **Constantes de Cadena**
Una constante de cadena (o literal) es un valor específico que se utiliza tal como es y no cambia. Las constantes de cadena pueden ser: fechas, textos, números, etc.:




## **Constantes de Error**
A veces no es posible calcular el resultado mediante la fórmula. En ese caso, el código de error se muestra en la celda en lugar de su valor. Cada tipo de error tiene un código específico:

- #DIV/0! - la fórmula intenta dividir entre cero.
- #GETTING_DATA - puede mostrarse en una celda, mientras su valor aún se está calculando.
- #N/A - falta información o no está disponible. Algunas razones pueden ser: las celdas utilizadas en la fórmula están vacías, un carácter de espacio adicional, errores de escritura, etc.
- #NAME? - una cierta celda u otros objetos de fórmula no pueden ser encontrados por su nombre. 
- #NULL! - puede aparecer cuando hay un error en la fórmula, como: (,) o un carácter de espacio utilizado en lugar de dos puntos (:).
- #NUM! - el numérico en la fórmula puede ser inválido, demasiado largo o demasiado pequeño, etc.
- #REF! - referencia de celda inválida.
- #VALUE! - tipo de valor inesperado. Por ejemplo, un valor de cadena establecido en una celda numérica.




## **Operadores Aritméticos**
Puedes usar todos los operadores aritméticos en las fórmulas de hoja de cálculo de gráficos:



|**Operador** |**Significado** |**Ejemplo**|
| :- | :- | :- |
|+ (signo más) |Adición o suma unaria|2 + 3|
|- (signo menos) |Sustracción o negación |2 - 3<br>-3|
|* (asterisco)|Multiplicación |2 * 3|
|/ (barra inclinada)|División |2 / 3|
|% (signo de porcentaje) |Porcentaje |30%|
|^ (acento circunflejo) |Exponenciación |2 ^ 3|


*Nota*: Para cambiar el orden de evaluación, encierra entre paréntesis la parte de la fórmula que debe ser calculada primero.


## **Operadores de Comparación**
Puedes comparar los valores de las celdas con los operadores de comparación. Cuando se comparan dos valores mediante estos operadores, el resultado es un valor lógico, ya sea *VERDADERO* o *FALSO*:



|**Operador** |**Significado** |**Significado** |
| :- | :- | :- |
|= (signo igual) |Igual a |A2 = 3|
|<> (signo de diferente) |No igual a|A2 <> 3|
|> (signo mayor que) |Mayor que|A2 > 3|
|>= (signo mayor o igual que)|Mayor o igual que|A2 >= 3|
|< (signo menor que)|Menor que|A2 < 3|
|<= (signo menor o igual que)|Menor o igual que|A2 <= 3|

## **Referencias a Celdas Estilo A1**
Las **referencias a celdas estilo A1** son utilizadas para las hojas de trabajo, donde la columna tiene un identificador de letra (ej. "*A*") y la fila tiene un identificador numérico (ej. "*1*"). Las referencias a celdas estilo A1 se pueden usar de la siguiente manera:



|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Fila |$2:$2 |2:2 |-|
|Columna |$A:$A |A:A |-|
|Rango |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aquí hay un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:




## **Referencias a Celdas Estilo R1C1**
Las **referencias a celdas estilo R1C1** son utilizadas para las hojas de trabajo, donde tanto una fila como una columna tienen el identificador numérico. Las referencias a celdas estilo R1C1 se pueden usar de la siguiente manera:



|**Referencia de celda**|**Ejemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mixta|
|Celda |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Fila |R2|R[2]|-|
|Columna |C3|C[3]|-|
|Rango |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aquí hay un ejemplo de cómo usar una referencia a celda estilo A1 en una fórmula:




## **Funciones Predefinidas**
Hay funciones predefinidas que se pueden usar en las fórmulas para simplificar su implementación. Estas funciones encapsulan las operaciones más comúnmente utilizadas, como: 

- ABS
- PROMEDIO
- TECHO
- ELEGIR
- CONCAT
- CONCATENAR
- FECHA (sistema de fecha 1900)
- DÍAS
- ENCONTRAR
- ENCONTRARB
- SI
- ÍNDICE (forma de referencia)
- BUSCAR (forma vectorial)
- COINCIDIR (forma vectorial)
- MAX
- SUMA
- BUSCARV