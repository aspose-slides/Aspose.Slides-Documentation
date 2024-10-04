---
title: Solución Funcional para el Redimensionamiento de Gráficos en PPTX
type: docs
weight: 40
url: /java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Se ha observado que los Gráficos de Excel incrustados como OLE en una Presentación de PowerPoint a través de componentes de Aspose se redimensionan a una escala no identificada después de la activación por primera vez. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados anterior y posterior a la activación del gráfico. El equipo de Aspose, con la ayuda del equipo de Microsoft, ha investigado este problema en detalle y ha encontrado la solución a este problema. Este artículo cubre las razones y la solución a este problema.

{{% /alert %}} 
## **Antecedentes**
En [el artículo anterior](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), hemos explicado cómo crear un Gráfico de Excel utilizando Aspose.Cells para Java y luego incrustar este gráfico en una Presentación de PowerPoint utilizando Aspose.Slides para Java. Para acomodar el [problema de objeto cambiado](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/), asignamos la imagen del gráfico al Marco del Objeto OLE del Gráfico. En la presentación de salida, cuando hacemos doble clic en el Marco del Objeto OLE que muestra la Imagen del Gráfico, se activa el Gráfico de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el Libro de Excel real y luego regresar a la Diapositiva correspondiente haciendo clic fuera del Libro de Excel activado. El tamaño del Marco del Objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para distintos tamaños del Marco del Objeto OLE y del Libro de Excel incrustado.
## **Causa del Redimensionamiento**
Dado que el Libro de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Por otro lado, el Marco del Objeto OLE tendrá su propio tamaño. Según Microsoft, en la activación del Libro de Excel, Excel y PowerPoint negocian el tamaño y aseguran que esté en las proporciones correctas como parte de la operación de incrustación. Basado en las diferencias en el tamaño de las Ventanas de Excel y el tamaño / posición del Marco del Objeto OLE, se produce el redimensionamiento.
## **Solución Funcional**
Hay dos escenarios posibles para la creación de Presentaciones de PowerPoint utilizando Aspose.Slides para Java. **Escenario 1:** Crear la presentación basada en una plantilla existente **Escenario 2:** Crear la presentación desde cero. La solución que proporcionaremos aquí será válida para ambos escenarios. La base de todos los enfoques de solución será la misma. Es decir: **El tamaño de la Ventana del Objeto OLE incrustado debe ser el mismo que el del Marco del Objeto OLE** **en la Diapositiva de PowerPoint**. Ahora, discutiremos los dos enfoques de la solución.
## **Primer Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño de la ventana del Libro de Excel incrustado equivalente al tamaño del Marco del Objeto OLE en la Diapositiva de PowerPoint. **Escenario 1** Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Digamos que hay alguna forma en el índice 2 de la plantilla donde queremos colocar un Marco OLE que transporta un Libro de Excel incrustado. En este escenario, el tamaño del Marco del Objeto OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 de la plantilla). Todo lo que tenemos que hacer: establecer el tamaño de la ventana del Libro igual al tamaño de la Forma. El siguiente fragmento de código servirá para este propósito:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}

**Escenario 2
**Supongamos que queremos crear una presentación desde cero y deseamos un Marco de Objeto OLE de cualquier tamaño con un Libro de Excel incrustado. En el siguiente fragmento de código, hemos creado un Marco de Objeto OLE con una altura de 4 pulgadas y un ancho de 9.5 pulgadas en la diapositiva en x-eje=0.5 pulgadas e y-eje=1 pulgada. Además, hemos establecido el tamaño de la ventana equivalente del Libro de Excel, es decir: altura 4 pulgadas y ancho 9.5 pulgadas.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}

## **Segundo Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño del gráfico presente en el Libro de Excel incrustado equivalente al tamaño del Marco del Objeto OLE en la Diapositiva de PowerPoint. Este enfoque es útil cuando se conoce el tamaño del gráfico desde el principio y nunca cambiará. **Escenario 1** Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Digamos que hay alguna forma en el índice 2 de la plantilla donde queremos colocar un Marco OLE que transporta un Libro de Excel incrustado. En este escenario, el tamaño del Marco OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 de la plantilla). Todo lo que tenemos que hacer: establecer el tamaño del gráfico en el Libro igual al tamaño de la forma. El siguiente fragmento de código servirá para este propósito:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Escenario 2**: Supongamos que queremos crear una presentación desde cero y deseamos un Marco de Objeto OLE de cualquier tamaño con un Libro de Excel incrustado. En el siguiente fragmento de código, hemos creado un Marco de Objeto OLE con una altura de 4 pulgadas y un ancho de 9.5 pulgadas en la diapositiva en x-eje=0.5 pulgadas e y-eje=1 pulgada. Además, hemos establecido el tamaño del Gráfico equivalente, es decir: altura 4 pulgadas y ancho 9.5 pulgadas.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Conclusión**
{{% alert color="primary" %}} 

Hay dos enfoques para solucionar el problema de redimensionamiento del gráfico. La selección del enfoque apropiado depende del requisito y el caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite en el tamaño del Marco del Objeto OLE en la solución.

{{% /alert %}}