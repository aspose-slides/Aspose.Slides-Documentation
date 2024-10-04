---
title: Preguntas Frecuentes
type: docs
weight: 340
url: /python-net/faqs/
keywords:
- FAQ
- PowerPoint
- formato de presentación
- error de memoria insuficiente
- tamaño de diapositiva
- extraer texto
- recuperar texto
- tamaño de párrafo
- formatear tablas
- fuente
- Python
- Aspose.Slides para Python a través de .NET
---

## **Formatos de Archivo Soportados**

**P: ¿Qué formatos de archivo soporta Aspose.Slides para Python a través de .NET?**

**R**: Aspose.Slides para Python a través de .NET soporta los formatos de archivo descritos en [Formatos de Archivo Soportados](/slides/python-net/supported-file-formats/).

## **Excepciones**

**P: Estoy recibiendo una excepción de memoria insuficiente al cargar un archivo PPT grande con imágenes. ¿Hay una limitación en Aspose.Slides respecto al tamaño del archivo?**

**R**: No hay una fórmula específica para calcular el tamaño de la presentación que soporta Aspose.Slides. Debe haber suficiente espacio para acomodar toda la estructura de la presentación y las imágenes en memoria. Normalmente, las imágenes en memoria ocupan más espacio que el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides para Python a través de .NET puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajando con Diapositivas**

**P: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**R**: Puedes usar la propiedad `slide_size` expuesta por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**P: ¿Hay una manera de definir diapositivas de diferente tamaño en una presentación?**

**R**: Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay manera de hacer esto.

**P: ¿Aspose.Slides para Python a través de .NET soporta la vista previa de una diapositiva antes de guardarla?**

**R**: Puedes renderizar las diapositivas de la presentación en imágenes y usar estas imágenes para previsualizar las diapositivas.

## **Trabajando con Texto**

**P: ¿Es posible recuperar todo el texto de una presentación?**

**R**: Aspose.Slides para Python a través de .NET proporciona la clase [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) bajo el espacio de nombres `aspose.slides.util` que ofrece varios métodos para recuperar todo el texto de las presentaciones.

**P: ¿Por qué los tamaños de párrafo son diferentes en sistemas operativos Windows y Linux?**

**R**: El cálculo de los tamaños de párrafo se basa en el tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza con la fuente más similar, pero esta fuente tiene métricas diferentes de las originales. Como resultado, el cálculo de los tamaños de párrafo en diferentes sistemas llevará a resultados distintos dependiendo del conjunto de fuentes instaladas. Para lograr el mismo resultado en diferentes sistemas operativos, necesitas instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [fuentes externas](/slides/python-net/custom-font/).

## **Formateo e Imágenes**

**P: ¿Cómo puedo establecer el color de un borde de tabla?**

**R**: Puedes cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, utiliza la propiedad `cell_format` de la clase [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Para el borde de toda la tabla, debes iterar las celdas y cambiar el color de los bordes externos.

**P: ¿Qué medida utiliza Aspose.Slides para Python a través de .NET para colocar imágenes?**

**R**: Las coordenadas y los tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajando con Fuentes**

**P: Al convertir PPT a PDF o imágenes, ¿por qué las fuentes son diferentes en los documentos de salida?**

**R**: Este problema puede indicar que las fuentes utilizadas en la presentación faltan en el sistema operativo en el que se ejecutó el código. Debes instalar las fuentes en el sistema operativo o cargarlas como fuentes externas utilizando la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) como se muestra a continuación:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```