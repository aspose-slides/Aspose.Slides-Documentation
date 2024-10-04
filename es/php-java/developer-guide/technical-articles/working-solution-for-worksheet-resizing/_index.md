---
title: Solución Funcional para el Redimensionamiento de Hojas de Cálculo
type: docs
weight: 20
url: /es/php-java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Se ha observado que las Hojas de Cálculo de Excel embebidas como OLE en una Presentación de PowerPoint a través de componentes de Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados de activación del gráfico antes y después. Hemos investigado este problema en detalle y encontrado la solución a este problema que se ha cubierto en este artículo.

{{% /alert %}} 
## **Antecedentes**
En el [artículo Agregar Marcos Ole]() hemos explicado cómo agregar un Marco Ole en la presentación de una Presentación de PowerPoint utilizando Aspose.Slides para PHP a través de Java. Para acomodar el [problema de objeto cambiado](/slides/es/php-java/object-changed-issue-when-adding-oleobjectframe/), asignamos la imagen de la hoja de cálculo del área seleccionada al Marco de Objeto OLE del Gráfico. En la presentación de salida, cuando hacemos doble clic en el Marco de Objeto OLE que muestra la imagen de la hoja de cálculo, se activa el Gráfico de Excel. Los usuarios finales pueden hacer cualquier cambio deseado en el Libro de Trabajo de Excel y luego regresar a la Diapositiva correspondiente haciendo clic fuera del Libro de Trabajo de Excel activado. El tamaño del Marco de Objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para diferentes tamaños de Marco de Objeto OLE y Libro de Trabajo de Excel embebido.
## **Causa del Redimensionamiento**
Dado que el Libro de Trabajo de Excel tiene su propio tamaño de ventana, intenta retener su tamaño original en la primera activación. Por otro lado, el Marco de Objeto OLE tendrá su propio tamaño. Según Microsoft, al activar el Libro de Trabajo de Excel, Excel y PowerPoint negocian el tamaño y aseguran que esté en las proporciones correctas como parte de la operación de embebido. Basado en las diferencias en el tamaño de las Ventanas de Excel y el tamaño / posición del Marco de Objeto OLE, se produce el redimensionamiento.
## **Solución Funcional**
Hay dos soluciones posibles para evitar el efecto de redimensionamiento.* Escalar el tamaño del marco Ole en PPT para que coincida con el tamaño en términos de altura/ancho del número deseado de filas/columnas en el Marco Ole * Mantener el tamaño del marco Ole constante y escalar el tamaño de las filas/columnas participantes para que quepan en el tamaño del marco Ole seleccionado
## **Escalar el tamaño del marco Ole al tamaño de filas/columnas seleccionadas de la Hoja de Cálculo**
En este enfoque, aprenderemos cómo establecer el tamaño del marco Ole del Libro de Trabajo de Excel embebido equivalente al tamaño acumulativo del número de filas y columnas participantes en la Hoja de Cálculo de Excel.
## **Ejemplo**
Supongamos que hemos definido una plantilla de hoja de Excel y deseamos agregarla a la presentación como marco Ole. En este escenario, el tamaño del Marco de Objeto OLE se calculará primero en función de la altura acumulativa de las filas y el ancho de las columnas de las filas y columnas participantes del Libro de Trabajo respectivamente. Luego, estableceremos el tamaño del marco Ole a ese valor calculado. Para evitar el mensaje rojo de **Objeto Embebido** para el marco Ole en PowerPoint, también obtendremos la imagen de las porciones deseadas de filas y columnas en el Libro de Trabajo y configuraremos eso como la imagen del marco Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **Escalar la altura de las filas y el ancho de las columnas de la hoja de cálculo según el tamaño del marco Ole**
En este enfoque, aprenderemos cómo escalar las alturas de las filas participantes y el ancho de la columna participante de acuerdo con el tamaño del marco ole establecido a medida.
## **Ejemplo**
Supongamos que hemos definido una plantilla de hoja de Excel y deseamos agregarla a la presentación como marco Ole. En este escenario, establecemos el tamaño del marco Ole y escalamos el tamaño de las filas y columnas que participan en el área del marco Ole. Luego guardaremos el libro en un flujo para guardar los cambios y convertirlo en un arreglo de bytes para agregarlo en el marco Ole. Para evitar el mensaje rojo de **Objeto Embebido** para el marco Ole en PowerPoint, también obtendremos la imagen de las porciones deseadas de filas y columnas en el Libro de Trabajo y configuraremos eso como la imagen del marco Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Conclusión**
{{% alert color="primary" %}} 

Hay dos enfoques para solucionar el problema de redimensionamiento de la hoja de cálculo. La selección del enfoque apropiado depende del requisito y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite en el tamaño del Marco de Objeto OLE en la solución.

{{% /alert %}}