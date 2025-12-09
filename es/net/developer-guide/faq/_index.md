---
title: Preguntas frecuentes
type: docs
weight: 340
url: /es/net/faqs/
keywords:
- Preguntas frecuentes
- PowerPoint
- formato de presentación
- error de falta de memoria
- tamaño de diapositiva
- extraer texto
- recuperar texto
- tamaño de párrafo
- formatear tablas
- fuente
- .NET
- C#
- Aspose.Slides
description: "Obtenga respuestas a las preguntas frecuentes sobre Aspose.Slides para .NET, que cubren el soporte de PowerPoint y OpenDocument, guías de instalación, licencias y solución de problemas."
---

## **Formatos de archivo compatibles**

**P:** ¿Qué formatos de archivo admite Aspose.Slides para .NET?  

**R:** Aspose.Slides para .NET admite los formatos de archivo descritos en [Formatos de archivo compatibles](/slides/es/net/supported-file-formats/).

## **Excepciones**

**P:** Obtengo una OutOfMemoryException al cargar un archivo PPT grande con imágenes. ¿Existe alguna limitación en Aspose.Slides respecto al tamaño del archivo?  

**R:** No hay una fórmula específica para calcular el tamaño de la presentación que admite Aspose.Slides. Debe haber suficiente espacio para alojar toda la estructura de la presentación e imágenes en memoria. Normalmente, las imágenes en la memoria ocupan más espacio que en el disco duro, sobre todo cuando tienen efectos adicionales.

En general, Aspose.Slides para .NET puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajar con diapositivas**

**P:** ¿Puedo cambiar el tamaño de las diapositivas en una presentación?  

**R:** Puede usar la propiedad `SlideSize` expuesta por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**P:** ¿Existe una forma de definir diapositivas de diferentes tamaños en una presentación?  

**R:** Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacerlo.

**P:** ¿Aspose.Slides para .NET admite la previsualización de una diapositiva antes de guardarla?  

**R:** Puede renderizar las diapositivas de la presentación a imágenes y utilizar esas imágenes para previsualizar las diapositivas.

## **Trabajar con texto**

**P:** ¿Es posible recuperar todo el texto de una presentación?  

**R:** Aspose.Slides para .NET proporciona la clase [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) bajo el espacio de nombres `Aspose.Slides.Util` que ofrece varios métodos para obtener todo el texto de las presentaciones.

**P:** ¿Por qué los tamaños de los párrafos son diferentes en los sistemas operativos Windows y Linux?  

**R:** El cálculo de los tamaños de los párrafos se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se fundamenta en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza por la fuente más similar, pero esta fuente tiene métricas diferentes a las originales. Como resultado, el cálculo de los tamaños de los párrafos en diferentes sistemas producirá resultados distintos según el conjunto de fuentes instaladas. Para obtener el mismo resultado en distintos sistemas operativos, necesita instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [fuentes externas](/slides/es/net/custom-font/).

## **Formato e imágenes**

**P:** ¿Cómo puedo establecer el color del borde de una tabla?  

**R:** Puede cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, utilice la propiedad `CellFormat` de la interfaz [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Para el borde de toda la tabla, debe iterar las celdas y cambiar el color de los bordes exteriores.

**P:** ¿Qué medida usa Aspose.Slides para .NET para colocar imágenes?  

**R:** Las coordenadas y tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajar con fuentes**

**P:** Al convertir PPT a PDF o imágenes, ¿por qué las fuentes son diferentes en los documentos de salida?  

**R:** Este problema puede indicar que las fuentes utilizadas en la presentación no están instaladas en el sistema operativo donde se ejecutó el código. Debe instalar las fuentes en el sistema operativo o cargarlas como fuentes externas usando la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) como se muestra a continuación:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
