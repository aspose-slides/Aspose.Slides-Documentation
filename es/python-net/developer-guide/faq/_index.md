---
title: Preguntas frecuentes
type: docs
weight: 340
url: /es/python-net/faq/
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
- Python
- Aspose.Slides
description: "Obtenga respuestas a las preguntas frecuentes sobre Aspose.Slides para Python vía .NET, que cubren el soporte de PowerPoint y OpenDocument, guía de instalación, licenciamiento y solución de problemas."
---

## **Formatos de archivo compatibles**

**Q: ¿Qué formatos de archivo admite Aspose.Slides for Python via .NET?**

**A**: Aspose.Slides for Python via .NET admite los formatos de archivo descritos en [Supported File Formats](/slides/es/python-net/supported-file-formats/).

## **Excepciones**

**Q: ¿Obtengo una excepción de falta de memoria al cargar un archivo PPT grande con imágenes? ¿Existe alguna limitación en Aspose.Slides respecto al tamaño del archivo?**

**A**: No hay una fórmula específica para calcular el tamaño de presentación que admite Aspose.Slides. Debe haber suficiente espacio para alojar toda la estructura de la presentación e imágenes en memoria. Normalmente, las imágenes en la memoria ocupan más espacio que en el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides for Python via .NET puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajar con diapositivas**

**Q: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**A**: Puede usar la propiedad `slide_size` expuesta por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**Q: ¿Existe una forma de definir diapositivas de diferentes tamaños en una presentación?**

**A**: Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacerlo.

**Q: ¿Aspose.Slides for Python via .NET admite la vista previa de una diapositiva antes de guardarla?**

**A**: Puede renderizar las diapositivas de la presentación a imágenes y usar esas imágenes para previsualizar las diapositivas.

## **Trabajar con texto**

**Q: ¿Es posible recuperar todo el texto de una presentación?**

**A**: Aspose.Slides for Python via .NET proporciona la clase [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) bajo el espacio de nombres `aspose.slides.util` que ofrece varios métodos para recuperar todo el texto de las presentaciones.

**Q: ¿Por qué los tamaños de los párrafos son diferentes en los sistemas operativos Windows y Linux?**

**A**: El cálculo de los tamaños de los párrafos se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza con la fuente más similar, pero esa fuente tiene métricas diferentes a las originales. Como resultado, el cálculo de los tamaños de los párrafos en diferentes sistemas producirá resultados distintos según el conjunto de fuentes instaladas. Para obtener el mismo resultado en diferentes sistemas operativos, debe instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [external fonts](/slides/es/python-net/custom-font/).

## **Formato e imágenes**

**Q: ¿Cómo puedo establecer el color del borde de una tabla?**

**A**: Puede cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, utilice la propiedad `cell_format` de la clase [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Para el borde de toda la tabla, debe iterar las celdas y cambiar el color de los bordes exteriores.

**Q: ¿Qué medida usa Aspose.Slides for Python via .NET para colocar imágenes?**

**A**: Las coordenadas y tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajar con fuentes**

**Q: Al convertir PPT a PDF o imágenes, ¿por qué las fuentes son diferentes en los documentos de salida?**

**A**: Este problema puede indicar que las fuentes usadas en la presentación no están presentes en el sistema operativo donde se ejecutó el código. Debe instalar las fuentes en el sistema operativo o cargarlas como fuentes externas usando la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) como se muestra a continuación:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
