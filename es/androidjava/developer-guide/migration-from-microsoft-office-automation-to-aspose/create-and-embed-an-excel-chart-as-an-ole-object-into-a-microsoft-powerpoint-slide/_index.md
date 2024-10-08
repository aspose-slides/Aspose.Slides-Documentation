---
title: Crear e incrustar un gráfico de Excel como un objeto OLE en una diapositiva de Microsoft PowerPoint
type: docs
weight: 60
url: /es/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Los gráficos son representaciones visuales de tus datos y se utilizan ampliamente en las diapositivas de presentación. Este artículo te mostrará el código para crear e incrustar un gráfico de Excel como un objeto OLE en la diapositiva de PowerPoint programáticamente utilizando [VSTO](/slides/es/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) y [Aspose.Slides para Android a través de Java](/slides/es/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Creando e incrustando un gráfico de Excel**
Los dos ejemplos de código a continuación son largos y detallados porque la tarea que describen es compleja. Creas un libro de trabajo de Microsoft Excel, creas un gráfico y luego creas la presentación de Microsoft PowerPoint en la que incrustarás el gráfico. Los objetos OLE contienen enlaces al documento original, por lo que un usuario que haga doble clic en el archivo incrustado abrirá el archivo y su aplicación.
### **Ejemplo de VSTO**
Utilizando VSTO, se realizan los siguientes pasos:

1. Crear una instancia del objeto Microsoft Excel ApplicationClass.
1. Crear un nuevo libro de trabajo con una hoja en él.
1. Agregar un gráfico a la hoja.
1. Guardar el libro de trabajo.
1. Abrir el libro de trabajo de Excel que contiene la hoja de cálculo con los datos del gráfico.
1. Obtener la colección ChartObjects para la hoja.
1. Obtener el gráfico a copiar.
1. Crear una presentación de Microsoft PowerPoint.
1. Agregar una diapositiva en blanco a la presentación.
1. Copiar el gráfico de la hoja de Excel al portapapeles.
1. Pegar el gráfico en la presentación de PowerPoint.
1. Posicionar el gráfico en la diapositiva.
1. Guardar la presentación.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Ejemplo de Aspose.Slides para Android a través de Java**
Utilizando Aspose.Slides para .NET, se realizan los siguientes pasos:

1. Crear un libro de trabajo usando Aspose.Cells para Java.
1. Crear un gráfico de Microsoft Excel.
1. Establecer el tamaño OLE del gráfico de Excel.
1. Obtener una imagen del gráfico.
1. Incrustar el gráfico de Excel como un objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para Android a través de Java.
1. Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para solucionar el problema del objeto cambiado.
1. Escribir la presentación de salida en el disco en formato PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}