---
title: Convertir PPT a PPTX en Android
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/androidjava/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- PPT a PPTX
- guardar PPT como PPTX
- exportar PPT a PPTX
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Convierte archivos PPT heredados a PPTX en Android con Aspose.Slides. Incluye ejemplos en Java para conversión de un solo archivo y por lotes, gestión de errores y notas sobre la fidelidad."
---
## **Resumen**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides para Android mediante Java puede cargar un archivo PPT y guardarlo como PPTX sin necesidad de Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo de origen con la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/), luego llame a [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/#Pptx). El bloque `finally` libera la presentación y sus recursos.

```java
// Cargar la presentación PPT heredada.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Guardar la presentación en formato PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La extensión del archivo no selecciona el formato de salida por sí sola; el argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/#Pptx) lo hace. Mantenga diferentes las rutas de entrada y salida si necesita conservar el archivo PPT original.

## **Convertir varios archivos PPT**

El siguiente ejemplo convierte cada archivo `.ppt` en un directorio. Cada archivo se procesa de forma independiente, de modo que una conversión fallida no detiene el resto del lote.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Para cargas de trabajo de producción, registre la excepción completa, decida si un archivo de salida existente puede ser sobrescrito y escriba los nombres de los archivos fallidos en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña abiertos sin la contraseña requerida, las rutas inaccesibles y el contenido no compatible pueden provocar que la conversión falle. Consulte [Presentaciones protegidas con contraseña](/androidjava/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión suele conservar diapositivas, patrones, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan todas las características de la misma manera exacta. Una característica heredada que no tiene equivalente en PPTX, o que no está soportada por la biblioteca, puede normalizarse, omitirse o mostrarse de forma diferente.

Compruebe el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o enlazados, controles ActiveX, medios incrustados, fuentes poco comunes o macros VBA. Un archivo PPTX simple no es un formato con macros habilitadas, por lo que debe usar un flujo de trabajo adecuado con macros cuando VBA deba mantenerse disponible. También verifique que las fuentes requeridas y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, vuelva a abrir el PPTX generado programáticamente e inspeccione el número de diapositivas y el contenido clave, y luego compare su apariencia y el comportamiento de la presentación en el visor previsto. No considere que una llamada exitosa a [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) sea prueba de que cada característica heredada tiene una representación PPTX exacta.

## **Cuándo usar PPTX**

Use PPTX cuando la presentación se vaya a editar en versiones actuales de PowerPoint, se intercambie con sistemas que trabajen con paquetes Open XML o se almacene en un formato más fácil de inspeccionar y recuperar que el binario heredado PPT. Conserve el PPT original como copia de archivo o de reversión hasta que la presentación convertida haya superado sus comprobaciones de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica del formato en [Convertir presentaciones a varios formatos](/slides/es/androidjava/convert-presentation/) en lugar de asumir que todos los destinos conservan las características editables de PowerPoint.

## **Convertidor en línea**

Para un archivo ocasional o una comparación rápida, puede usar el [convertidor en línea de PPT a PPTX](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, utilice la API de Android mediante Java.

## **Artículos relacionados**

- [PPT vs PPTX](/slides/es/androidjava/ppt-vs-pptx/)
- [Guardar presentaciones en Android](/slides/es/androidjava/save-presentation/)
- [Formatos de archivo compatibles](/slides/es/androidjava/supported-file-formats/)
- [Abrir presentaciones en Android](/slides/es/androidjava/open-presentation/)

## **Preguntas frecuentes**

**¿Puedo convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí. Aspose.Slides para Android mediante Java carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿La conversión de PPT a PPTX preservará todo el contenido exactamente?**

Preserva el contenido típico de la presentación, pero no se garantiza una fidelidad exacta para cada característica heredada o no soportada. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o fuentes poco comunes.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar el archivo. Una contraseña ausente o incorrecta hace que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Conserve el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le importan. Esto proporciona una copia de reversión si una característica heredada se convierte de forma distinta.