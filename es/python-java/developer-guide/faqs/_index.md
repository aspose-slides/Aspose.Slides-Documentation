---
title: Preguntas frecuentes
type: docs
weight: 340
url: /es/python-java/faqs/
keywords:
- Preguntas frecuentes
- formato de presentación
- error de falta de memoria
- tamaño de diapositiva
- extraer texto
- tamaño de párrafo
- bordes de tabla
- fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Encuentre respuestas a preguntas habituales sobre Aspose.Slides para Python vía Java, incluidos los formatos de archivo, el uso de memoria, los tamaños de diapositiva, el texto, las tablas, las imágenes y las fuentes."
---
## **Visión general**

Esta FAQ cubre los formatos de archivo compatibles, el uso de memoria con presentaciones grandes, los tamaños y vistas previas de diapositivas, la extracción de texto, los bordes de tablas, la ubicación de imágenes y las diferencias de fuentes al convertir presentaciones a PDF o imágenes.

## **Preguntas frecuentes**

### **Formatos de archivo compatibles**

**¿Qué formatos de archivo admite Aspose.Slides for Python vía Java?**

Consulte [Formatos de archivo compatibles](/slides/es/python-java/supported-file-formats/) para obtener información sobre los formatos de presentación, documento e imagen compatibles y sus capacidades de importación y exportación.

### **Excepciones**

**¿Por qué recibo un error de falta de memoria al cargar una presentación grande con imágenes? ¿Existe un límite de tamaño de archivo?**

No hay un umbral único de tamaño de archivo que prediga si una presentación cabrá en memoria. Los requisitos de memoria dependen de la estructura de la presentación, las imágenes descomprimidas, los efectos y las operaciones que realice. Las imágenes pueden ocupar mucha más memoria que su tamaño comprimido en disco.

Aspose.Slides for Python vía Java utiliza el motor Java a través de JPype, por lo que el heap de la JVM debe disponer de espacio suficiente para el procesamiento. La RAM del sistema disponible por sí sola no indica cuánta memoria puede usar la JVM. Libere las presentaciones con [Presentation.dispose](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#dispose) cuando termine de utilizarlas. Para la configuración del entorno, consulte [Requisitos del sistema](/slides/es/python-java/system-requirements/) e [Instalación](/slides/es/python-java/installation/).

### **Trabajo con diapositivas**

**¿Puedo cambiar el tamaño de las diapositivas en una presentación?**

Sí. Utilice [Presentation.getSlideSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getslidesize) para acceder a la configuración del tamaño de diapositiva de la presentación y luego use [SlideSize.setSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesize/#setsize) para establecer las dimensiones y elegir cómo se escalan los contenidos existentes.

**¿Pueden las diapositivas de la misma presentación tener tamaños diferentes?**

No. Los documentos de Microsoft PowerPoint definen el tamaño de la diapositiva a nivel de presentación, por lo que todas las diapositivas comparten las mismas dimensiones.

**¿Puedo obtener una vista previa de una diapositiva antes de guardar la presentación?**

Sí. Renderice la diapositiva a una imagen y muestre esa imagen en su aplicación. No es necesario guardar la presentación primero.

### **Trabajo con texto**

**¿Puedo obtener todo el texto de una presentación?**

Sí. La clase [SlideUtil](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/) ofrece métodos para recuperar texto de presentaciones y diapositivas individuales.

**¿Por qué los tamaños de párrafo difieren en Windows y Linux?**

Las dimensiones del párrafo dependen de las métricas de las fuentes usadas para renderizar el texto. Si falta una fuente, un sustituto puede tener anchos de carácter y alturas de línea diferentes, lo que altera el ajuste de línea y las dimensiones del párrafo. Instale las mismas fuentes en ambos sistemas o cargue los mismos archivos de fuentes con [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadexternalfonts) antes de crear o cargar presentaciones.

### **Formato e imágenes**

**¿Cómo puedo establecer el color del borde de una tabla?**

Use [Cell.getCellFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/#getcellformat) para acceder al formato de borde de cada celda y establecer el color de relleno para los bordes pertinentes. Para cambiar todos los bordes, procese todas las celdas. Para cambiar solo el contorno de la tabla, actualice únicamente los bordes exteriores de las celdas situadas en sus márgenes.

**¿Qué unidades se usan para posicionar y dimensionar imágenes?**

Las coordenadas y dimensiones de las formas se miden en puntos. Una pulgada equivale a 72 puntos; estos valores no son coordenadas de píxeles.

### **Trabajo con fuentes**

**¿Por qué cambian las fuentes al convertir una presentación a PDF o imágenes?**

Las fuentes necesarias pueden faltar en la máquina que realiza la conversión. Instale las fuentes originales o utilice [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadexternalfonts) para añadir carpetas que las contengan. Cargue fuentes externas antes de crear o abrir presentaciones.

El siguiente ejemplo registra una carpeta de fuentes. Reemplace la ruta por una carpeta existente que contenga sus archivos de fuentes. Se asume el entorno descrito en [Instalación](/slides/es/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

El ejemplo deja la JVM en ejecución para operaciones posteriores con presentaciones. Para el uso en cuadernos y restricciones del ciclo de vida de la JVM, consulte [Limitaciones y diferencias de API](/slides/es/python-java/limitations-and-api-differences/).