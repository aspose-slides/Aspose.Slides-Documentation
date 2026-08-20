---
title: Convertir PPT a PPTX en Java
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Convertir archivos PPT heredados a PPTX en Java con Aspose.Slides. Incluye ejemplos Java para conversión de un solo archivo y por lotes, manejo de errores y notas de fidelidad."
---
## **Visión general**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides for Java puede cargar un archivo PPT y guardarlo como PPTX sin necesidad de Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo de origen con la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/), luego llame a [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/#Pptx). El bloque `finally` libera la presentación y sus recursos.

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

La extensión del archivo no determina el formato de salida por sí sola; lo hace el argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/#Pptx). Mantenga las rutas de entrada y salida diferentes si necesita conservar el archivo PPT original.

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

Para cargas de trabajo de producción, registre la excepción completa, decida si se puede sobrescribir un archivo de salida existente y escriba los nombres de los archivos que fallaron en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña abiertos sin la contraseña requerida, las rutas inaccesibles y el contenido no compatible pueden causar que una conversión falle. Consulte [Presentaciones protegidas con contraseña](/java/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión normalmente conserva diapositivas, maestros, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan cada característica de la misma forma. Una característica heredada que no tiene equivalente PPTX, o que no es compatible con la biblioteca, puede normalizarse, omitirse o mostrarse de manera diferente.

Revise el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o vinculados, controles ActiveX, medios incrustados, fuentes poco comunes o macros VBA. Un archivo PPTX simple no es un formato con capacidad de macros, por lo que debe usar un flujo de trabajo adecuado con macros cuando VBA deba permanecer disponible. También verifique que las fuentes requeridas y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, vuelva a abrir el PPTX generado programáticamente e inspeccione recuentos clave de diapositivas y contenido, y luego compare su apariencia y comportamiento de presentación en el visor previsto. No trate una llamada exitosa a [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) como prueba de que cada característica heredada tiene una representación PPTX exacta.

## **Cuándo usar PPTX**

Utilice PPTX cuando la presentación se vaya a editar en versiones actuales de PowerPoint, se intercambie con sistemas que trabajen con paquetes Open XML, o se almacene en un formato más fácil de inspeccionar y recuperar que el binario heredado PPT. Mantenga el PPT original como copia de archivo o de reversión hasta que la presentación convertida haya superado sus comprobaciones de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica de formato en [Convertir presentaciones a varios formatos](/java/convert-presentation/) en lugar de asumir que todos los destinos preservan las características editables de PowerPoint.

## **Convertidor en línea**

Para un archivo ocasional o una comparación rápida, puede usar el [convertidor en línea de PPT a PPTX](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, utilice la API de Java.

## **Artículos relacionados**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Guardar presentaciones en Java](/java/save-presentation/)
- [Formatos de archivo compatibles](/java/supported-file-formats/)
- [Abrir presentaciones en Java](/java/open-presentation/)

## **FAQ**

**¿Puedo convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí. Aspose.Slides for Java carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿La conversión de PPT a PPTX preservará todo el contenido exactamente?**

Preserva el contenido de presentación común, pero no se garantiza una fidelidad exacta para cada característica heredada o no compatible. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o fuentes poco comunes.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar el archivo. Una contraseña ausente o incorrecta hace que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Conserve el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le interesen. Esto proporciona una copia de reversión si una característica heredada se convierte de forma diferente.