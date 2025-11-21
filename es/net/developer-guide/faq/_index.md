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
- formato de tablas
- fuente
- .NET
- C#
- Aspose.Slides
description: "Obtenga respuestas a preguntas frecuentes sobre Aspose.Slides para .NET, que cubren el soporte de PowerPoint y OpenDocument, guía de instalación, licenciamiento, solución de problemas."
---

## **Formatos de archivo compatibles**

**Q: ¿Qué formatos de archivo admite Aspose.Slides para .NET?**

**A**: Aspose.Slides para .NET admite los formatos de archivo descritos en [Supported File Formats](/slides/es/net/supported-file-formats/).

## **Excepciones**

**Q: Estoy recibiendo una OutOfMemoryException al cargar un archivo PPT grande con imágenes. ¿Existe alguna limitación en Aspose.Slides respecto al tamaño del archivo?**

**A**: No hay una fórmula específica para calcular el tamaño de presentación que admite Aspose.Slides. Debe haber suficiente espacio para alojar toda la estructura de la presentación y las imágenes en memoria. Normalmente, las imágenes en memoria ocupan más espacio que en el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides para .NET puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajar con diapositivas**

**Q: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**A**: Puede usar la propiedad `SlideSize` expuesta por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**Q: ¿Existe alguna forma de definir diapositivas de diferentes tamaños en una presentación?**

**A**: Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacerlo.

**Q: ¿Aspose.Slides para .NET admite la vista previa de una diapositiva antes de guardarla?**

**A**: Puede renderizar las diapositivas de la presentación a imágenes y usar estas imágenes para previsualizar las diapositivas.

## **Trabajar con texto**

**Q: ¿Es posible obtener todo el texto de una presentación?**

**A**: Aspose.Slides para .NET proporciona la clase [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) bajo el espacio de nombres `Aspose.Slides.Util` que ofrece varios métodos para obtener todo el texto de las presentaciones.

**Q: ¿Por qué los tamaños de párrafo son diferentes en los sistemas operativos Windows y Linux?**

**A**: El cálculo de los tamaños de párrafo se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza por la fuente más similar, pero esa fuente tiene métricas diferentes a las originales. Como resultado, el cálculo de los tamaños de párrafo en diferentes sistemas producirá resultados distintos según el conjunto de fuentes instaladas. Para obtener el mismo resultado en diferentes sistemas operativos, debe instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [external fonts](/slides/es/net/custom-font/).

## **Formato e imágenes**

**Q: ¿Cómo puedo establecer el color del borde de una tabla?**

**A**: Puede cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, utilice la propiedad `CellFormat` de la interfaz [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Para el borde de toda la tabla, debe iterar las celdas y cambiar el color de los bordes exteriores.

**Q: ¿Qué unidad de medida usa Aspose.Slides para .NET para colocar imágenes?**

**A**: Las coordenadas y tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajar con fuentes**

**Q: Al convertir PPT a PDF o imágenes, ¿por qué las fuentes son diferentes en los documentos de salida?**

**A**: Este problema puede indicar que las fuentes usadas en la presentación faltan en el sistema operativo donde se ejecutó el código. Debe instalar las fuentes en el sistema operativo o cargarlas como fuentes externas usando la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) como se muestra a continuación:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
