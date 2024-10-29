---
title: Creando un Gráfico de Excel e Insertándolo en una Presentación como Objeto OLE
type: docs
weight: 30
url: /es/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

En las diapositivas de PowerPoint, el uso de gráficos editables para la visualización gráfica de los datos es una actividad común. Aspose proporciona el soporte para crear gráficos de Excel utilizando Aspose.Cells para Java y, posteriormente, estos gráficos se pueden integrar como un Objeto OLE en la diapositiva de PowerPoint a través de Aspose.Slides para PHP mediante Java. Este artículo cubre los pasos requeridos junto con la implementación para crear e insertar un Gráfico de Excel como un Objeto OLE en una presentación de PowerPoint utilizando Aspose.Cells para Java y Aspose.Slides para PHP mediante Java.

{{% /alert %}} 
## **Pasos Requeridos**
La siguiente secuencia de pasos es necesaria para crear e insertar un Gráfico de Excel como un Objeto OLE en la Diapositiva de PowerPoint:# Crear un Gráfico de Excel utilizando Aspose.Cells para Java.# Establecer el tamaño OLE del Gráfico de Excel utilizando Aspose.Cells para Java.# Obtener la imagen del Gráfico de Excel con Aspose.Cells para Java.# Insertar el Gráfico de Excel como un Objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para PHP mediante Java.# Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para abordar el Problema del Objeto Cambiado.# Guardar la presentación de salida en disco en formato PPTX
## **Implementación de los Pasos Requeridos**
La implementación de los pasos anteriores es la siguiente:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

La presentación creada mediante el método anterior llevará el gráfico de Excel como Objeto OLE que se puede activar haciendo doble clic en el Marco del Objeto OLE.

{{% /alert %}} 
## **Conclusión**
{{% alert color="primary" %}} 

Al utilizar Aspose.Cells para Java junto con Aspose.Slides para PHP mediante Java, podemos crear cualquiera de los Gráficos de Excel soportados por Aspose.Cells para Java e insertar el gráfico creado como un Objeto OLE en una Diapositiva de PowerPoint. También se puede definir el Tamaño OLE del Gráfico de Excel. Los usuarios finales pueden editar además el Gráfico de Excel como cualquier otro Objeto OLE.

{{% /alert %}} 
## **Secciones Relacionadas**
[Solución Funcional para el Cambio de Tamaño de Gráficos](/slides/es/php-java/working-solution-for-chart-resizing-in-pptx/)

[Problema del Objeto Cambiado](/slides/es/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)