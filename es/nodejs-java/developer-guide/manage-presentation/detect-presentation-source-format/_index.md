---
title: Determinar el formato original de la presentación en Node.js
linktitle: Formato de origen
type: docs
weight: 35
url: /es/nodejs-java/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lea el formato original de una presentación cargada en Node.js con Aspose.Slides para Node.js vía Java, compare las API de detección y maneje archivos, flujos y formatos heredados."
---
## **Visión general**

Después de cargar una presentación, llame al método [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSourceFormat) para determinar su formato original. Úselo cuando el procesamiento posterior dependa del formato con el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no modifica el formato de origen de la instancia existente.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSourceFormat), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Reconocer los valores compatibles**

La clase [SourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sourceformat/) define constantes enteras que distinguen los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor de SourceFormat | Extension | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentación Office Open XML |
| `Pptm` | `.pptm` | Presentación Office Open XML con macros |
| `Pps` | `.pps` | Presentación de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Presentación de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | Presentación de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | Plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | Plantilla Office Open XML |
| `Potm` | `.potm` | Plantilla Office Open XML con macros |
| `Odp` | `.odp` | Presentación OpenDocument |
| `Otp` | `.otp` | Plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | Presentación ODF Flat XML |
| `Xml` | `.xml` | Presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria simula una entrada recibida sin nombre de archivo, como un valor de base de datos o un arreglo de bytes cargado. El constructor [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) recibe solo el flujo.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS y POT utilizan el mismo formato binario subyacente. Al cargar mediante una ruta de archivo, la extensión puede ayudar a distinguir una presentación de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado de PPS y POT puede informarse como `SourceFormat.Ppt`; el ejemplo de PPS anterior muestra el valor entero de `SourceFormat.Ppt`.

Si su aplicación debe conservar la diferencia, mantenga el nombre de archivo original o los metadatos de subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de cargar**

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) y [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) cuando necesite inspeccionar un archivo antes de cargar su modelo de objeto de presentación completo. Utilice [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSourceFormat) cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` y muestra los valores enteros de `LoadFormat.Pptx` y `SourceFormat.Pptx`, respectivamente. En producción, elija la API adecuada a su etapa de procesamiento; una presentación ya cargada no necesita una segunda inspección únicamente para obtener su formato de origen.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Los resultados utilizan constantes de clases diferentes: [LoadFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sourceformat/). No compare sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. PowerPoint XML puede informarse como `LoadFormat.Unknown` antes de cargar y como `SourceFormat.Xml` después de cargar.

## **Mantener separados los formatos de origen y de salida**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Muestra el valor entero de `SourceFormat.Pptx` tanto antes como después de guardar la instancia original. Solo la nueva instancia cargada desde la salida ODP informa `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Una presentación creada desde cero con `new Presentation()` informa `SourceFormat.Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Controle por separado si su aplicación creó o cargó la instancia si esa distinción es importante.

## **Mapear un formato de origen a una extensión**

El siguiente ejemplo requiere `sample.pptx`. Asocia cada valor de [SourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sourceformat/) actualmente soportado a una extensión convencional, sin analizar el nombre de archivo de entrada. La alternativa evita asignar silenciosamente una extensión a un valor no reconocido.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Esta asignación no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga del flujo. Para guardar realmente, seleccione explícitamente un [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/), o utilice la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y reabriendo**

Este ejemplo autónomo crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo los archivos con los mismos nombres. Reabre cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, la carga por ruta informa `Pps`, mientras que la carga de los mismos bytes sin nombre de archivo informa `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

La tabla siguiente resume la identificación del formato de origen para presentaciones con extensiones coincidentes. Los nombres denotan constantes; los ejemplos en JavaScript imprimen sus valores enteros:

| Formato guardado | SourceFormat desde una ruta de archivo | SourceFormat desde un flujo sin nombre |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual que la ruta del archivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual que la ruta del archivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual que la ruta del archivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual que la ruta del archivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT se identifica como `Ppt` para flujos sin nombre. La tabla describe la identificación del formato, no la preservación de todas las características de la presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `Pptx`. Una instancia cargada desde el archivo ODP guardado informa `Odp`.

**¿Puede un flujo distinguir siempre una presentación heredada, una presentación de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Mantenga el nombre de archivo o los metadatos de subtipo por separado cuando sea necesario distinguirlos.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSourceFormat). Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspeccionar antes de cargar.