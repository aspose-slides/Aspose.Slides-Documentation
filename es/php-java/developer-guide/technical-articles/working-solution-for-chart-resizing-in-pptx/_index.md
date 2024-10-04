---
title: Solución Funcional para el Redimensionamiento de Gráficos en PPTX
type: docs
weight: 40
url: /es/php-java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Se ha observado que los gráficos de Excel incrustados como OLE en una presentación de PowerPoint a través de componentes de Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados de activación previa y posterior del gráfico. El equipo de Aspose, con la ayuda del equipo de Microsoft, ha investigado este problema en detalle y ha encontrado la solución. Este artículo cubre las razones y la solución a este problema.

{{% /alert %}} 
## **Antecedentes**
En [el artículo anterior](/slides/es/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), hemos explicado cómo crear un gráfico de Excel usando Aspose.Cells para Java y luego incrustar este gráfico en una presentación de PowerPoint usando Aspose.Slides para PHP a través de Java. Para abordar el [problema de cambio de objeto](/slides/es/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación de salida, cuando hacemos doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el libro de trabajo de Excel y luego volver a la diapositiva correspondiente haciendo clic fuera del libro de trabajo de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para diferentes tamaños del marco del objeto OLE y del libro de trabajo de Excel incrustado.
## **Causa del Redimensionamiento**
Dado que el libro de trabajo de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Por otro lado, el marco del objeto OLE tendrá su propio tamaño. Según Microsoft, al activar el libro de trabajo de Excel, Excel y PowerPoint negocian el tamaño y aseguran que esté en las proporciones correctas como parte de la operación de incrustación. Basado en las diferencias en el tamaño de las ventanas de Excel y en el tamaño / posición del marco de objeto OLE, se lleva a cabo el redimensionamiento.
## **Solución Funcional**
Existen dos escenarios posibles para la creación de presentaciones de PowerPoint utilizando Aspose.Slides para PHP a través de Java. **Escenario 1:** Crear la presentación basada en una plantilla existente. **Escenario 2:** Crear la presentación desde cero. La solución que proporcionaremos aquí será válida para ambos escenarios. La base de todos los enfoques de solución será la misma. Es decir: **El tamaño de la ventana del objeto OLE incrustado debe ser el mismo que el del marco del objeto OLE** **en la diapositiva de PowerPoint**. Ahora, discutiremos los dos enfoques de la solución.
## **Primer Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño de la ventana del libro de trabajo de Excel incrustado equivalente al tamaño del marco del objeto OLE en la diapositiva de PowerPoint. **Escenario 1** Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Supongamos que hay alguna forma en el índice 2 en la plantilla donde queremos colocar un marco OLE que contenga un libro de trabajo de Excel incrustado. En este escenario, el tamaño del marco del objeto OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 de la plantilla). Todo lo que tenemos que hacer es: establecer el tamaño de la ventana del libro de trabajo igual al tamaño de la forma. El siguiente fragmento de código servirá para este propósito:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}





**Escenario 2** Supongamos que queremos crear una presentación desde cero y deseamos un marco de objeto OLE de cualquier tamaño con un libro de trabajo de Excel incrustado. En el siguiente fragmento de código, hemos creado un marco de objeto OLE con 4 pulgadas de altura y 9.5 pulgadas de ancho en la diapositiva en x-eje=0.5 pulgadas y y-eje=1 pulgada. Además, hemos establecido el tamaño de ventana equivalente del libro de trabajo de Excel, es decir: altura 4 pulgadas y ancho 9.5 pulgadas.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **Segundo Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño del gráfico presente en el libro de trabajo de Excel incrustado equivalente al tamaño del marco del objeto OLE en la diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico es conocido de antemano y nunca cambiará. **Escenario 1** Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Supongamos que hay alguna forma en el índice 2 en la plantilla donde queremos colocar un marco OLE que contenga un libro de trabajo de Excel incrustado. En este escenario, el tamaño del marco OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 de la plantilla). Todo lo que tenemos que hacer es: establecer el tamaño del gráfico en el libro de trabajo igual al tamaño de la forma. El siguiente fragmento de código servirá para este propósito:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Escenario 2** Supongamos que queremos crear una presentación desde cero y deseamos un marco de objeto OLE de cualquier tamaño con un libro de trabajo de Excel incrustado. En el siguiente fragmento de código, hemos creado un marco de objeto OLE con 4 pulgadas de altura y 9.5 pulgadas de ancho en la diapositiva en x-eje=0.5 pulgadas y y-eje=1 pulgada. Además, hemos establecido el tamaño equivalente del gráfico, es decir: altura 4 pulgadas y ancho 9.5 pulgadas.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Conclusión**
{{% alert color="primary" %}} 

Existen dos enfoques para solucionar el problema de redimensionamiento de gráficos. La selección del enfoque apropiado depende del requisito y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en la solución.

{{% /alert %}}