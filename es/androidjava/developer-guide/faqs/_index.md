---
title: Preguntas Frecuentes
type: docs
weight: 340
url: /es/androidjava/faqs/
keywords:
- FAQ
- PowerPoint
- formato de presentación
- error de falta de memoria
- tamaño de diapositiva
- extraer texto
- recuperar texto
- tamaño del párrafo
- formatear tablas
- fuente
- Android
- Java
- Aspose.Slides para Android a través de Java
---

## **Formatos de Archivo Soportados**

**Q: ¿Qué formatos de archivo soporta Aspose.Slides para Android a través de Java?**

**A**: Aspose.Slides para Android a través de Java soporta los formatos de archivo descritos en [Formatos de Archivo Soportados](/slides/es/androidjava/supported-file-formats/).

## **Excepciones**

**Q: Estoy recibiendo una excepción de falta de memoria al cargar un archivo PPT grande con imágenes. ¿Hay alguna limitación en Aspose.Slides con respecto al tamaño del archivo?**

**A**: No hay una fórmula específica para calcular el tamaño de la presentación soportado por Aspose.Slides. Debe haber suficiente espacio para acomodar toda la estructura de la presentación y las imágenes en memoria. Normalmente, las imágenes en la memoria ocupan más espacio que el disco duro, especialmente cuando las imágenes tienen efectos adicionales.

En general, Aspose.Slides para Android a través de Java puede manejar fácilmente archivos de presentación de alrededor de 300 MB en un servidor con 4 GB de RAM.

## **Trabajando con Diapositivas**

**Q: ¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

**A**: Puede usar el método `getSlideSize` expuesto por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) para definir el tamaño de las diapositivas en una presentación.

**Q: ¿Hay alguna manera de definir diapositivas de diferente tamaño en una presentación?**

**A**: Dado que el tamaño de las diapositivas se define a nivel de presentación en los documentos de Microsoft PowerPoint, no hay forma de hacerlo.

**Q: ¿Aspose.Slides para Android a través de Java soporta previsualizar una diapositiva antes de guardar?**

**A**: Puede renderizar las diapositivas de la presentación a imágenes y puede usar estas imágenes para previsualizar las diapositivas.

## **Trabajando con Texto**

**Q: ¿Es posible recuperar todo el texto de una presentación?**

**A**: Aspose.Slides para Android a través de Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideutil/) que ofrece varios métodos para recuperar todo el texto de las presentaciones.

**Q: ¿Por qué los tamaños de los párrafos son diferentes en PC y Android?**

**A**: El cálculo de los tamaños de los párrafos se basa en el cálculo del tamaño del texto que representa el párrafo dado. El cálculo del tamaño del texto se basa en las métricas de la fuente especificada en la presentación de PowerPoint. Si la fuente especificada falta, se reemplaza con la fuente más similar, pero esta fuente tiene métricas diferentes a las originales. Como resultado, el cálculo de los tamaños de párrafo en diferentes sistemas llevará a diferentes resultados dependiendo del conjunto de fuentes instaladas. Para lograr el mismo resultado en diferentes sistemas operativos, necesita instalar las mismas fuentes en los sistemas o cargarlas en tiempo de ejecución como [fuentes externas](/slides/es/androidjava/custom-font/).

## **Formateo e Imágenes**

**Q: ¿Cómo puedo establecer el color de un borde de tabla?**

**A**: Puede cambiar el color de todos los bordes de la tabla o solo el borde alrededor de toda la tabla. Para cambiar todos los bordes, utilice el método `getCellFormat` de la interfaz [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/). Para el borde de toda la tabla, debe iterar sobre las celdas y cambiar el color de los bordes exteriores.

**Q: ¿Qué medida utiliza Aspose.Slides para Android a través de Java para colocar imágenes?**

**A**: Las coordenadas y tamaños de todas las formas en las diapositivas se miden en puntos (72 dpi).

## **Trabajando con Fuentes**

**Q: Al convertir PPT a PDF o imágenes, ¿por qué son diferentes las fuentes en los documentos de salida?**

**A**: Este problema puede indicar que las fuentes utilizadas en la presentación faltan en el sistema operativo en el que se ejecutó el código. Debe instalar las fuentes en el sistema operativo o cargarlas como fuentes externas utilizando la clase [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) como se muestra a continuación:
```java
String[] folders = new String[] { "ruta_a_una_carpeta_con_fuentes" };
FontsLoader.loadExternalFonts(folders);
```