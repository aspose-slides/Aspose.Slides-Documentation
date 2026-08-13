---
title: Crear e incrustar gráficos de Excel como objetos OLE usando VSTO y Aspose.Slides para Java
linktitle: Crear e incrustar gráficos de Excel como objetos OLE
type: docs
weight: 60
url: /es/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- crear gráfico
- incrustar gráfico de Excel
- objeto OLE
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Migra de la automatización de Microsoft Office a Aspose.Slides para Java e incrusta gráficos de Excel como objetos OLE en diapositivas de PowerPoint (PPT, PPTX) con Java."
---
{{% alert color="info" %}} 
Los gráficos son representaciones visuales de sus datos y se utilizan ampliamente en diapositivas de presentación. Este artículo le mostrará el código para crear e incrustar un gráfico de Excel como un objeto OLE en la diapositiva de PowerPoint de forma programática utilizando [VSTO](/slides/es/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) y [Aspose.Slides for Java](/slides/es/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **Creación e incrustación de un gráfico de Excel**
Los dos ejemplos de código a continuación son extensos y detallados porque la tarea que describen es compleja. Usted crea un libro de trabajo de Microsoft Excel, crea un gráfico y luego crea la presentación de Microsoft PowerPoint en la que incrustará el gráfico. Los objetos OLE contienen enlaces al documento original, de modo que un usuario que haga doble clic en el archivo incrustado abrirá el archivo y su aplicación.
### **Ejemplo VSTO**
Usando VSTO, se realizan los siguientes pasos:

1. Crear una instancia del objeto Microsoft Excel ApplicationClass.
1. Crear un nuevo libro de trabajo con una hoja.
1. Añadir un gráfico a la hoja.
1. Guardar el libro de trabajo.
1. Abrir el libro de Excel que contiene la hoja de cálculo con los datos del gráfico.
1. Obtener la colección ChartObjects de la hoja.
1. Obtener el gráfico a copiar.
1. Crear una presentación de Microsoft PowerPoint.
1. Añadir una diapositiva en blanco a la presentación.
1. Copiar el gráfico desde la hoja de Excel al portapapeles.
1. Pegar el gráfico en la presentación de PowerPoint.
1. Posicionar el gráfico en la diapositiva.
1. Guardar la presentación.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Ejemplo de Aspose.Slides for Java**
Usando Aspose.Slides para .NET, se realizan los siguientes pasos:

1. Crear un libro de trabajo usando Aspose.Cells para Java.
1. Crear un gráfico de Microsoft Excel.
1. Establecer el tamaño OLE del gráfico de Excel.
1. Obtener una imagen del gráfico.
1. Incrustar el gráfico de Excel como un objeto OLE dentro de una presentación PPTX usando Aspose.Slides para Java.
1. Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para atender el problema del objeto cambiado.
1. Escribir la presentación de salida en disco en formato PPTX.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}