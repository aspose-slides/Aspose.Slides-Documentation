---
title: Preguntas frecuentes
type: docs
weight: 340
url: /es/java/faqs/
keywords:
- Preguntas frecuentes
- formato de presentación
- error de falta de memoria
- tamaño de diapositiva
- extraer texto
- recuperar texto
- tamaño de párrafo
- formateo de tablas
- fuente
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Obtenga respuestas a las preguntas frecuentes sobre Aspose.Slides for Java, que cubren el soporte de PowerPoint y OpenDocument, la guía de instalación, licencias y solución de problemas."
---

## **Formatos de archivo admitidos**

**Q: ¿Qué formatos de archivo admite Aspose.Slides for Java?**

**A:** Aspose.Slides for Java admite los formatos de archivo descritos en [Formatos admitidos](/slides/es/java/supported-file-formats/).

## **Excepciones**

**Q: Obtengo una excepción de falta de memoria al cargar un archivo PPT grande con imágenes. ¿Existe alguna limitación en Aspose.Slides respecto al tamaño del archivo?**

**A:** No hay una fórmula específica para calcular el tamaño de la presentación admitido por Aspose.Slides. Debe haber suficiente espacio para alojar toda la estructura de la presentación y las imágenes en memoria. Normalmente, las imágenes en la memoria ocupan más espacio que en el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides for Java puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajando con diapositivas**

**Q: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**A:** Puedes usar el método `getSlideSize` expuesto por la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**Q: ¿Hay alguna forma de definir diapositivas de distinto tamaño en una presentación?**

**A:** Ya que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacerlo.

**Q: ¿Aspose.Slides for Java admite la vista previa de una diapositiva antes de guardarla?**

**A:** Puedes renderizar las diapositivas de la presentación a imágenes y utilizarlas para previsualizar las diapositivas.

## **Trabajando con texto**

**Q: ¿Es posible recuperar todo el texto de una presentación?**

**A:** Aspose.Slides for Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/) que ofrece varios métodos para recuperar todo el texto de las presentaciones.

**Q: ¿Por qué los tamaños de párrafo son diferentes en los sistemas operativos Windows y Linux?**

**A:** El cálculo de los tamaños de párrafo se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza por la fuente más similar, pero esa fuente tiene métricas diferentes a las originales. Como resultado, el cálculo de los tamaños de párrafo en diferentes sistemas producirá resultados distintos según el conjunto de fuentes instaladas. Para obtener el mismo resultado en diferentes sistemas operativos, debes instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [fuentes externas](/slides/es/java/custom-font/).

## **Formato e Imágenes**

**Q: ¿Cómo puedo establecer el color del borde de una tabla?**

**A:** Puedes cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, usa el método `getCellFormat` de la interfaz [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). Para el borde de toda la tabla, deberías iterar las celdas y cambiar el color de los bordes exteriores.

**Q: ¿Qué unidad de medida usa Aspose.Slides for Java para ubicar imágenes?**

**A:** Las coordenadas y tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajando con fuentes**

**Q: Al convertir PPT a PDF o imágenes, ¿por qué las fuentes son diferentes en los documentos de salida?**

**A:** Este problema puede indicar que las fuentes usadas en la presentación no están presentes en el sistema operativo donde se ejecutó el código. Debes instalar las fuentes en el sistema operativo o cargarlas como fuentes externas usando la clase [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) como se muestra a continuación:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```
