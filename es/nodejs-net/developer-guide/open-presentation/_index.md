---
title: Abrir presentaciones en Node.js a través de .NET
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/nodejs-net/open-presentation/
keywords:
- abrir presentación
- abrir PowerPoint
- abrir PPTX
- abrir PPT
- abrir ODP
- cargar presentación
- presentación desde búfer
- recuento de diapositivas
- convertir presentación
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Abrir presentaciones PPTX, PPT y ODP en JavaScript con Aspose.Slides para Node.js a través de .NET: cargarlas desde una ruta de archivo o un búfer, leer el número de diapositivas y guardarlas en otro formato."
---
## **Descripción general**

Aspose.Slides for Node.js via .NET abre presentaciones PowerPoint y OpenDocument, como archivos PPTX, PPT y ODP, a partir de una ruta de archivo o de un `Buffer` de Node.js. Este artículo muestra ambas formas, lee el número de diapositivas y guarda una presentación abierta en otro formato.

Los ejemplos esperan una presentación llamada `sample.pptx` en la carpeta del proyecto que configuraste en [Installation](/slides/es/nodejs-net/installation/). Cualquier presentación de PowerPoint sirve. Guarda cada ejemplo como un archivo `.js` en la carpeta del proyecto y ejecútalo desde esa carpeta con `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET no tiene una referencia de API propia. Refleja la API de Aspose.Slides para .NET con nombres camelCase, por lo que los enlaces de API en este artículo conducen a las clases y miembros correspondientes en la [referencia de API de Aspose.Slides para .NET](https://reference.aspose.com/slides/es/net/).
{{% /alert %}}

## **Abrir una presentación desde un archivo**

Para abrir una presentación, pasa su ruta al constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/presentation/). Aspose.Slides detecta el formato a partir del contenido del archivo en lugar de la extensión, por lo que el mismo código abre archivos PPTX, PPT y ODP. Una ruta relativa se resuelve respecto al directorio de trabajo actual, que es la carpeta del proyecto cuando ejecutas el script desde allí.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

El script muestra el número de diapositivas en `sample.pptx`, por ejemplo `Slide count: 9`. La propiedad `count` de la colección de [slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) incluye diapositivas ocultas. Llama a `dispose` en un bloque `finally`, como se muestra, para que los recursos .NET detrás de la presentación se liberen incluso si tu código falla.

## **Abrir una presentación desde un búfer**

Cuando una presentación proviene de una base de datos, una carga HTTP u otra fuente que te proporciona bytes en lugar de una ruta de archivo, pasa un `Buffer` de Node.js como segundo argumento del constructor y `null` como primero. El siguiente ejemplo lee `sample.pptx` en un búfer para simular dicha fuente:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

El script muestra el mismo número de diapositivas que el ejemplo anterior. El segundo argumento debe ser un `Buffer`. Para cualquier otro tipo, como `Uint8Array`, el constructor no informa de error; en su lugar crea una nueva presentación con una diapositiva vacía. Convierte otros tipos binarios con `Buffer.from` primero.

## **Guardar una presentación en otro formato**

Para convertir una presentación a otro formato de presentación, ábrela y guárdala con un valor diferente de [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/). El siguiente ejemplo muestra el formato que Aspose.Slides detectó, que devuelve la propiedad [sourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sourceformat/), y guarda la presentación como una presentación OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

El script muestra `Source format: Pptx` y escribe `sample.odp`, que contiene las mismas diapositivas. `sourceFormat` devuelve `Ppt`, `Pptx` u `Odp`. Para guardar como PDF o como imágenes, consulta [Convert PowerPoint to PDF](/slides/es/nodejs-net/convert-powerpoint-to-pdf/) y [Convert Slides to Images](/slides/es/nodejs-net/convert-slide/).

## **Preguntas frecuentes**

**¿Cómo abrir una presentación protegida con contraseña?**

Crea un objeto [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/), establece su propiedad [password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/) y pasa el objeto como tercer argumento del constructor: `new Presentation("protected.pptx", null, loadOptions)`. Sin la contraseña correcta, el constructor lanza un error.

**¿Por qué el constructor lanza un `Error` con un mensaje vacío?**

Cuando el constructor `Presentation` falla en .NET, por ejemplo porque el archivo falta, no es una presentación o necesita una contraseña diferente, JavaScript recibe un `Error` cuyo mensaje está vacío. Antes de abrir un archivo, verifica que exista respecto al directorio de trabajo, por ejemplo con `fs.existsSync`.

**¿Qué formatos puedo abrir?**

Formatos de presentación PowerPoint y OpenDocument, incluidos PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP y FODP.