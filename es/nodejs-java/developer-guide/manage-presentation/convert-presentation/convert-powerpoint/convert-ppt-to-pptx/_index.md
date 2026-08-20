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
description: "Convertir archivos PPT heredados a PPTX en Node.js con Aspose.Slides. Incluye ejemplos JavaScript para conversión de un solo archivo y por lotes, manejo de errores y notas de fidelidad."
---
## **Visión general**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides for Node.js via Java puede cargar un archivo PPT y guardarlo como PPTX sin Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo de origen con la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y luego llame a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/). El bloque `finally` elimina la presentación y libera sus recursos.

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

La extensión del archivo no selecciona el formato de salida por sí sola; lo hace el argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/). Mantenga las rutas de entrada y salida diferentes si necesita conservar el archivo PPT original.

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

Para entornos de producción, registre el error completo, decida si un archivo de salida existente puede sobrescribirse y escriba los nombres de los archivos que fallaron en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña que se abren sin la contraseña requerida, rutas inaccesibles y contenido no admitido pueden provocar que la conversión falle. Consulte [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión normalmente conserva diapositivas, patrones, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan cada característica de la misma manera exacta. Una característica heredada que no tiene equivalente PPTX, o que no es compatible con la biblioteca, puede normalizarse, omitirse o mostrarse de forma diferente.

Revise el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o vinculados, controles ActiveX, medios incrustados, fuentes poco comunes o macros VBA. Un archivo PPTX simple no es un formato habilitado para macros, por lo que debe emplear un flujo de trabajo apropiado con macros cuando VBA deba permanecer disponible. Además, verifique que las fuentes requeridas y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, vuelva a abrir el PPTX generado mediante código y examine el recuento de diapositivas y el contenido clave, y luego compare su apariencia y comportamiento de presentación en el visor previsto. No trate una llamada exitosa a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) como prueba de que cada característica heredada tiene una representación PPTX exacta.

## **Cuándo usar PPTX**

Use PPTX cuando la presentación se vaya a editar en versiones actuales de PowerPoint, se intercambie con sistemas que trabajen con paquetes Open XML o se almacene en un formato más fácil de inspeccionar y recuperar que el binario heredado PPT. Conserve el PPT original como copia de archivo o de reversión hasta que la presentación convertida haya superado sus comprobaciones de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica de formato en [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) en lugar de suponer que todos los destinos conservan las características editables de PowerPoint.

## **Conversor en línea**

Para un archivo ocasional o una comparación rápida, puede usar el [online PPT to PPTX converter](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, use la API Node.js via Java.

## **Artículos relacionados**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**¿Puedo convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí. Aspose.Slides for Node.js via Java carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿La conversión de PPT a PPTX preservará todo el contenido exactamente?**

Preserva el contenido de presentación más común, pero no se garantiza una fidelidad exacta para cada característica heredada o no compatible. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o fuentes poco comunes.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar el archivo. Falta o una contraseña incorrecta provocará que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Conserve el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le importan. Esto le proporciona una copia de reversión si una característica heredada se convierte de forma distinta.