---
title: Crear e Incrustar un Gráfico de Excel como un Objeto OLE en una Diapositiva de Microsoft PowerPoint
type: docs
weight: 60
url: /php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Los gráficos son representaciones visuales de tus datos y se utilizan ampliamente en diapositivas de presentación. Este artículo te mostrará el código para crear e incrustar un Gráfico de Excel como un Objeto OLE en la Diapositiva de PowerPoint programáticamente utilizando [VSTO](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) y [Aspose.Slides para PHP a través de Java](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Creación e Incrustación de un Gráfico de Excel**
Los dos ejemplos de código a continuación son largos y detallados porque la tarea que describen es compleja. Creas un libro de trabajo de Microsoft Excel, creas un gráfico y luego creas la presentación de Microsoft PowerPoint en la que incrustarás el gráfico. Los objetos OLE contienen enlaces al documento original, por lo que un usuario que haga doble clic en el archivo incrustado abrirá el archivo y su aplicación.
### **Ejemplo de VSTO**
Utilizando VSTO, se realizan los siguientes pasos:

1. Crear una instancia del objeto Microsoft Excel ApplicationClass.
1. Crear un nuevo libro de trabajo con una hoja en él.
1. Agregar un gráfico a la hoja.
1. Guardar el libro de trabajo.
1. Abrir el libro de trabajo de Excel que contiene la hoja de trabajo con los datos del gráfico.
1. Obtener la colección de ChartObjects para la hoja.
1. Obtener el gráfico para copiar.
1. Crear una presentación de Microsoft PowerPoint.
1. Agregar una diapositiva en blanco a la presentación.
1. Copiar el gráfico de la hoja de trabajo de Excel al portapapeles.
1. Pegar el gráfico en la presentación de PowerPoint.
1. Posicionar el gráfico en la diapositiva.
1. Guardar la presentación.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Ejemplo de Aspose.Slides para PHP a través de Java**
Utilizando Aspose.Slides para .NET, se realizan los siguientes pasos:

1. Crear un libro de trabajo utilizando Aspose.Cells para Java.
1. Crear un gráfico de Microsoft Excel.
1. Establecer el tamaño OLE del Gráfico de Excel.
1. Obtener una imagen del gráfico.
1. Incrustar el gráfico de Excel como un Objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para PHP a través de Java.
1. Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para atender el problema del objeto cambiado.
1. Escribir la presentación de salida en el disco en formato PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}