---
title: Preguntas Frecuentes
type: docs
weight: 340
url: /net/faqs/
keywords:
- FAQ
- PowerPoint
- formato de presentación
- excepción de falta de memoria
- tamaño de diapositiva
- extraer texto
- recuperar texto
- tamaño de párrafo
- formatear tablas
- fuente
- C#
- .NET
- Aspose.Slides para .NET
---

## **Formatos de Archivo Soportados**

**P: ¿Qué formatos de archivo soporta Aspose.Slides para .NET?**

**R**: Aspose.Slides para .NET soporta los formatos de archivo descritos en [Formatos de Archivo Soportados](/slides/net/supported-file-formats/).

## **Excepciones**

**P: Estoy recibiendo una OutOfMemoryException al cargar un archivo PPT grande con imágenes. ¿Hay alguna limitación en Aspose.Slides respecto al tamaño del archivo?**

**R**: No hay una fórmula específica para calcular el tamaño de presentación soportado por Aspose.Slides. Debe haber suficiente espacio para acomodar toda la estructura de la presentación y las imágenes en memoria. Normalmente, las imágenes en memoria ocupan más espacio que en el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides para .NET puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajando con Diapositivas**

**P: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**R**: Puede usar la propiedad `SlideSize` expuesta por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**P: ¿Hay alguna manera de definir diapositivas de diferentes tamaños en una presentación?**

**R**: Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacer esto.

**P: ¿Aspose.Slides para .NET soporta la vista previa de una diapositiva antes de guardarla?**

**R**: Puede renderizar las diapositivas de la presentación como imágenes y usar estas imágenes para previsualizar las diapositivas.

## **Trabajando con Texto**

**P: ¿Es posible recuperar todo el texto de una presentación?**

**R**: Aspose.Slides para .NET proporciona la clase [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) bajo el espacio de nombres `Aspose.Slides.Util` que ofrece varios métodos para recuperar todo el texto de las presentaciones.

**P: ¿Por qué los tamaños de párrafo son diferentes en los sistemas operativos Windows y Linux?**

**R**: El cálculo de los tamaños de párrafo se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza por la fuente más similar, pero esta fuente tiene métricas diferentes de las originales. Como resultado, el cálculo de los tamaños de párrafo en diferentes sistemas dará lugar a diferentes resultados dependiendo del conjunto de fuentes instaladas. Para lograr el mismo resultado en diferentes sistemas operativos, es necesario instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [fuentes externas](/slides/net/custom-font/).

## **Formato e Imágenes**

**P: ¿Cómo puedo establecer el color de un borde de tabla?**

**R**: Puede cambiar el color de todos los bordes de la tabla o solo el borde de toda la tabla. Para cambiar todos los bordes, use la propiedad `CellFormat` de la interfaz [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Para el borde de toda la tabla, debe iterar sobre las celdas y cambiar el color de los bordes exteriores.

**P: ¿Qué medida utiliza Aspose.Slides para .NET para colocar imágenes?**

**R**: Las coordenadas y tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajando con Fuentes**

**P: Al convertir PPT a PDF o imágenes, ¿por qué son diferentes las fuentes en los documentos de salida?**

**R**: Este problema puede indicar que las fuentes utilizadas en la presentación faltan en el sistema operativo en el que se ejecutó el código. Debe instalar las fuentes en el sistema operativo o cargarlas como fuentes externas usando la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) como se muestra a continuación:
```cs
var folders = new string[] { "ruta_a_una_carpeta_con_fuentes" };
FontsLoader.LoadExternalFonts(folders);
```