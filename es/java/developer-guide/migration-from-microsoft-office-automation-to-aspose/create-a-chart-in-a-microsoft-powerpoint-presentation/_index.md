---
title: Crear gráficos con VSTO y Aspose.Slides para Java
linktitle: Crear gráfico
type: docs
weight: 70
url: /es/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- crear gráfico
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprende a automatizar la creación de gráficos de PowerPoint en Java. Esta guía paso a paso muestra por qué Aspose.Slides para Java es una alternativa más rápida y potente a Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

 Los gráficos son representaciones visuales de datos que se utilizan ampliamente en presentaciones. Este artículo muestra el código para crear un gráfico en Microsoft PowerPoint de forma programática mediante [VSTO](/slides/es/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) y [Aspose.Slides for Java](/slides/es/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Crear un gráfico**
Los ejemplos de código a continuación describen el proceso de añadir un sencillo gráfico de columnas agrupadas 3D utilizando VSTO. Creas una instancia de presentación, le añades un gráfico predeterminado y, a continuación, utilizas un libro de trabajo de Microsoft Excel para acceder y modificar los datos del gráfico junto con la configuración de sus propiedades. Finalmente, guardas la presentación.
### **Ejemplo VSTO**
Con VSTO se realizan los siguientes pasos:

1. Crear una instancia de una presentación de Microsoft PowerPoint.
1. Añadir una diapositiva en blanco a la presentación.
1. Añadir un gráfico **3D clustered column** y acceder a él.
1. Crear una nueva instancia de Microsoft Excel Workbook y cargar los datos del gráfico.
1. Acceder a la hoja de datos del gráfico mediante la instancia de Microsoft Excel Workbook `fromworkbook`.
1. Establecer el rango del gráfico en la hoja y eliminar las series 2 y 3 del gráfico.
1. Modificar los datos de categoría del gráfico en la hoja de datos.
1. Modificar los datos de la serie 1 del gráfico en la hoja de datos.
1. Acceder ahora al título del gráfico y establecer las propiedades relacionadas con la fuente.
1. Acceder al eje de valores del gráfico y definir la unidad mayor, unidades menores, valor máximo y valores mínimos.
1. Acceder al eje de profundidad o eje de series del gráfico y eliminarlo, ya que en este ejemplo solo se utiliza una serie.
1. Establecer ahora los ángulos de rotación del gráfico en las direcciones X e Y.
1. Guardar la presentación.
1. Cerrar las instancias de Microsoft Excel y PowerPoint.

**La presentación de salida, creada con VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Ejemplo Aspose.Slides for Java**
Con Aspose.Slides for Java se realizan los siguientes pasos:

1. Crear una instancia de una presentación de Microsoft PowerPoint.
1. Añadir una diapositiva en blanco a la presentación.
1. Añadir un gráfico **3D clustered column** y acceder a él.
1. Acceder a la hoja de datos del gráfico mediante una instancia de Microsoft Excel Workbook `fromworkbook`.
1. Eliminar las series no utilizadas 2 y 3.
1. Acceder a las categorías del gráfico y modificar las etiquetas.
1. Acceder a `series1` y modificar los valores de la serie.
1. Acceder ahora al título del gráfico y establecer las propiedades de la fuente.
1. Acceder al eje de valores del gráfico y definir la unidad mayor, unidades menores, valor máximo y valores mínimos.
1. Establecer ahora los ángulos de rotación del gráfico en las direcciones X e Y.
1. Guardar la presentación en formato PPTX.

**La presentación de salida, creada con Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### ¿Puedo crear otros tipos de gráficos, como de sectores, líneas o barras, con Aspose.Slides?

Sí. Aspose.Slides admite una amplia gama de [tipos de gráficos](/slides/es/java/create-chart/), incluidos gráficos de sectores, líneas, barras, diagramas de dispersión, burbujas y más. Puedes especificar el tipo de gráfico deseado utilizando la clase [ChartType](https://reference.aspose.com/slides/es/java/com.aspose.slides/charttype/) al añadir un gráfico.

### ¿Puedo aplicar estilos o temas personalizados al gráfico?

Sí. Puedes personalizar completamente la apariencia del gráfico, incluidos colores, fuentes, rellenos, contornos, líneas de cuadrícula y disposición. Sin embargo, aplicar temas de Office exactamente como aparecen en PowerPoint requiere configurar manualmente cada estilo individualmente.

### ¿Puedo exportar el gráfico como una imagen de forma independiente de la diapositiva?

Sí, Aspose.Slides permite exportar cualquier forma —incluidos los gráficos— como una imagen independiente (por ejemplo, PNG, JPEG) mediante el método `getImage` en el [shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/) del gráfico.