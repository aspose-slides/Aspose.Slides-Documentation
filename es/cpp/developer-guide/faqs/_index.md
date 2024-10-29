---
title: Preguntas Frecuentes
type: docs
weight: 340
url: /es/cpp/faqs/
keywords:
- Pregunta Frecuente
- PowerPoint
- formato de presentación
- excepción de memoria insuficiente
- tamaño de diapositiva
- extraer texto
- recuperar texto
- tamaño de párrafo
- formatear tablas
- fuente
- С++
- Aspose.Slides para С++
---

## **Formatos de Archivo Soportados**

**P: ¿Qué formatos de archivo soporta Aspose.Slides para C++?**

**R**: Aspose.Slides para C++ soporta los formatos de archivo descritos en [Formatos de Archivo Soportados](/slides/es/cpp/supported-file-formats/).

## **Excepciones**

**P: Estoy recibiendo una excepción de memoria insuficiente al cargar un archivo PPT grande con imágenes. ¿Hay una limitación en Aspose.Slides respecto al tamaño del archivo?**

**R**: No hay una fórmula específica para calcular el tamaño de la presentación soportada por Aspose.Slides. Debería haber suficiente espacio para acomodar toda la estructura de la presentación y las imágenes en memoria. Normalmente, las imágenes en la memoria ocupan más espacio que en el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides para C++ puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajando con Diapositivas**

**P: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**R**: Puedes usar el método `get_SlideSize` expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**P: ¿Hay alguna forma de definir diapositivas de diferente tamaño en una presentación?**

**R**: Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacer esto.

**P: ¿Aspose.Slides para C++ soporta la vista previa de una diapositiva antes de guardar?**

**R**: Puedes renderizar las diapositivas de la presentación a imágenes y usar estas imágenes para previsualizar las diapositivas.

## **Trabajando con Texto**

**P: ¿Es posible recuperar todo el texto de una presentación?**

**R**: Aspose.Slides para C++ proporciona la clase [SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/) bajo el espacio de nombres `Aspose::Slides::Util` que ofrece varios métodos para recuperar todo el texto de las presentaciones.

**P: ¿Por qué los tamaños de párrafo son diferentes en los sistemas operativos Windows y Linux?**

**R**: El cálculo de los tamaños de párrafo se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza por la fuente más similar, pero esta fuente tiene métricas diferentes a las originales. Como resultado, el cálculo de los tamaños de párrafo en diferentes sistemas dará lugar a resultados diferentes según el conjunto de fuentes instaladas. Para lograr el mismo resultado en diferentes sistemas operativos, debes instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [fuentes externas](/slides/es/cpp/custom-font/).

## **Formateo e Imágenes**

**P: ¿Cómo puedo establecer el color de un borde de tabla?**

**R**: Puedes cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, usa el método `get_CellFormat` de la interfaz [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/). Para el borde de toda la tabla, debes iterar sobre las celdas y cambiar el color de los bordes exteriores.

**P: ¿Qué medida utiliza Aspose.Slides para C++ para colocar imágenes?**

**R**: Las coordenadas y los tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajando con Fuentes**

**P: Al convertir PPT a PDF o imágenes, ¿por qué las fuentes son diferentes en los documentos de salida?**

**R**: Este problema podría indicar que las fuentes usadas en la presentación faltan en el sistema operativo en el que se ejecutó el código. Debes instalar las fuentes en el sistema operativo o cargarlas como fuentes externas utilizando la clase [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) como se muestra a continuación:
```cpp
auto folders = MakeObject<Array<String>>(1, "ruta_a_una_carpeta_con_fuentes");
FontsLoader::LoadExternalFonts(folders);
```