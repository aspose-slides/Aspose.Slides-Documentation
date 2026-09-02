---
title: Convertir PPT a PPTX en Node.js
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierte archivos PPT heredados a PPTX en Node.js con Aspose.Slides. Incluye ejemplos en JavaScript para conversión de un solo archivo y por lotes, manejo de errores y notas de fidelidad."
---
## **Visión general**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides para Node.js mediante Java puede cargar un archivo PPT y guardarlo como PPTX sin Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo de origen con la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/), luego llame a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/). El bloque `finally` libera la presentación y libera sus recursos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cargar la presentación PPT heredada.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Guardar la presentación en formato PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La extensión del archivo no selecciona el formato de salida por sí misma; el argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/) lo hace. Mantenga las rutas de entrada y salida diferentes si necesita conservar el archivo PPT original.

## **Convertir varios archivos PPT**

El siguiente ejemplo convierte cada archivo `.ppt` en un directorio. Cada archivo se procesa de forma independiente, de modo que una conversión fallida no detiene el resto del lote.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Para entornos de producción, registre el error completo, decida si se puede sobrescribir un archivo de salida existente y escriba los nombres de los archivos que fallaron en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña abiertos sin la contraseña requerida, las rutas inaccesibles y el contenido no compatible pueden provocar que la conversión falle. Consulte [Presentaciones con contraseña protegida](/slides/es/nodejs-java/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión normalmente preserva diapositivas, patrones, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan cada característica de la misma manera exacta. Una característica heredada que no tenga equivalente en PPTX, o que no sea compatible con la biblioteca, puede ser normalizada, omitida o mostrada de forma diferente.

Revise el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o vinculados, controles ActiveX, medios incrustados, fuentes poco comunes o macros VBA. Un archivo PPTX simple no es un formato compatible con macros, por lo que debe usar un flujo de trabajo compatible con macros cuando VBA deba permanecer disponible. También verifique que las fuentes requeridas y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, vuelva a abrir el PPTX generado programáticamente e inspeccione el recuento de diapositivas y el contenido clave, luego compare su aspecto y comportamiento de presentación en el visor previsto. No considere que una llamada exitosa a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) sea prueba de que cada característica heredada tenga una representación exacta en PPTX.

## **Cuándo usar PPTX**

Utilice PPTX cuando la presentación se vaya a editar en versiones actuales de PowerPoint, intercambiarse con sistemas que trabajen con paquetes Open XML o almacenarse en un formato más fácil de inspeccionar y recuperar que el binario heredado PPT. Mantenga el PPT original como copia de archivo o de respaldo hasta que la presentación convertida haya superado sus controles de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica de formato en [Convertir presentaciones a varios formatos](/slides/es/nodejs-java/convert-presentation/) en lugar de suponer que todos los destinos conservan las características editables de PowerPoint.

## **Convertidor en línea**

Para un archivo ocasional o una comparación rápida, puede usar el [convertidor en línea de PPT a PPTX](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, utilice la API de Node.js mediante Java.

## **Artículos relacionados**

- [PPT vs PPTX](/slides/es/nodejs-java/ppt-vs-pptx/)
- [Guardar presentaciones en Node.js](/slides/es/nodejs-java/save-presentation/)
- [Formatos de archivo compatibles](/slides/es/nodejs-java/supported-file-formats/)
- [Abrir presentaciones en Node.js](/slides/es/nodejs-java/open-presentation/)

## **FAQ**

**¿Puedo convertir PPT a PPTX sin Microsoft PowerPoint instalado?**

Sí. Aspose.Slides para Node.js mediante Java carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿La conversión de PPT a PPTX preservará todo el contenido exactamente?**

Preserva el contenido común de la presentación, pero la fidelidad exacta no está garantizada para cada característica heredada o no compatible. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o fuentes poco comunes.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar el archivo. Una contraseña ausente o incorrecta hace que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Mantenga el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le importan. Esto proporciona una copia de respaldo si una característica heredada se convierte de forma diferente.