---
title: Crear un gráfico en una presentación de Microsoft PowerPoint
type: docs
weight: 70
url: /php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Los gráficos son representaciones visuales de datos que se utilizan ampliamente en presentaciones. Este artículo muestra el código para crear un gráfico en Microsoft PowerPoint de forma programática utilizando [VSTO](/slides/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/) y [Aspose.Slides para PHP a través de Java](/slides/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Creando un Gráfico**
Los ejemplos de código a continuación describen el proceso de agregar un gráfico de columnas agrupadas en 3D simple utilizando VSTO. Se crea una instancia de presentación, se le añade un gráfico predeterminado. Luego, se utiliza un libro de trabajo de Microsoft Excel para acceder y modificar los datos del gráfico junto con establecer las propiedades del gráfico. Por último, se guarda la presentación.
### **Ejemplo de VSTO**
Usando VSTO, se realizan los siguientes pasos:

1. Crear una instancia de una presentación de Microsoft PowerPoint.
1. Agregar una diapositiva en blanco a la presentación.
1. Agregar un gráfico de **columnas agrupadas en 3D** y acceder a él.
1. Crear una nueva instancia de libro de trabajo de Microsoft Excel y cargar los datos del gráfico.
1. Acceder a la hoja de datos del gráfico utilizando la instancia del libro de trabajo de Microsoft Excel.
1. Establecer el rango del gráfico en la hoja de trabajo y eliminar las series 2 y 3 del gráfico.
1. Modificar los datos de categoría del gráfico en la hoja de datos del gráfico.
1. Modificar los datos de la serie 1 del gráfico en la hoja de datos del gráfico.
1. Ahora, acceder al título del gráfico y establecer las propiedades relacionadas con la fuente.
1. Acceder al eje de valores del gráfico y establecer la unidad mayor, unidades menores, valor máximo y valores mínimos.
1. Acceder a la profundidad del gráfico o eje de la serie y eliminarlo, ya que en este ejemplo solo se utiliza una serie.
1. Ahora, establecer los ángulos de rotación del gráfico en dirección X e Y.
1. Guardar la presentación.
1. Cerrar las instancias de Microsoft Excel y PowerPoint.

**La presentación de salida, creada con VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Ejemplo de Aspose.Slides para PHP a través de Java**
Usando Aspose.Slides para PHP a través de Java, se realizan los siguientes pasos:

1. Crear una instancia de una presentación de Microsoft PowerPoint.
1. Agregar una diapositiva en blanco a la presentación.
1. Agregar un gráfico de **columnas agrupadas en 3D** y acceder a ese.
1. Acceder a la hoja de datos del gráfico utilizando una instancia de libro de trabajo de Microsoft Excel.
1. Eliminar las series 2 y 3 no utilizadas.
1. Acceder a las categorías del gráfico y modificar las etiquetas.
1. Acceder a la serie 1 y modificar los valores de la serie.
1. Ahora, acceder al título del gráfico y establecer las propiedades de fuente.
1. Acceder al eje de valores del gráfico y establecer la unidad mayor, unidades menores, valor máximo y valores mínimos.
1. Ahora, establecer los ángulos de rotación del gráfico en dirección X e Y.
1. Guardar la presentación en formato PPTX.

**La presentación de salida, creada con Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}