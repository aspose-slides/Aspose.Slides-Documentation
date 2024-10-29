---
title: Creando Gráficos de Excel e Incrustándolos en Presentaciones como Objetos OLE
type: docs
weight: 30
url: /es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

En las Diapositivas de PowerPoint, el uso de gráficos editables para la representación gráfica de los datos es una actividad común. Aspose proporciona el soporte para crear gráficos de Excel con el uso de Aspose.Cells para Java y, además, estos gráficos se pueden incrustar como un Objeto OLE en la Diapositiva de PowerPoint a través de Aspose.Slides para Java. Este artículo cubre los pasos requeridos junto con la implementación en Java para crear e incrustar un Gráfico de Excel como un Objeto OLE en la presentación de PowerPoint utilizando Aspose.Cells para Java y Aspose.Slides para Java.

{{% /alert %}} 
## **Pasos Requeridos**
La siguiente secuencia de pasos es necesaria para crear e incrustar un Gráfico de Excel como un Objeto OLE en la Diapositiva de PowerPoint:
# Crear un Gráfico de Excel usando Aspose.Cells para Java.
# Establecer el tamaño OLE del Gráfico de Excel usando Aspose.Cells para Java.
# Obtener la imagen del Gráfico de Excel con Aspose.Cells para Java.
# Incrustar el Gráfico de Excel como un Objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para Java.
# Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para solucionar el Problema de Objeto Cambiado.
# Guardar la presentación de salida en disco en formato PPTX.
## **Implementación de los Pasos Requeridos**
La implementación de los pasos anteriores en Java es la siguiente:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

La presentación creada a través del método anterior llevará el gráfico de Excel como un Objeto OLE que se puede activar haciendo doble clic en el Marco del Objeto OLE.

{{% /alert %}} 
## **Conclusión**
{{% alert color="primary" %}} 

Al utilizar Aspose.Cells para Java junto con Aspose.Slides para Java, podemos crear cualquiera de los Gráficos de Excel soportados por Aspose.Cells para Java e incrustar el gráfico creado como un Objeto OLE en una Diapositiva de PowerPoint. El tamaño OLE del Gráfico de Excel también se puede definir. Los usuarios finales pueden editar aún más el Gráfico de Excel como cualquier otro Objeto OLE.

{{% /alert %}} 
## **Secciones Relacionadas**
[Solución Funcional para el Cambio de Tamaño de Gráficos](/slides/es/java/working-solution-for-chart-resizing-in-pptx/)

[Problema de Objeto Cambiado](/slides/es/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)