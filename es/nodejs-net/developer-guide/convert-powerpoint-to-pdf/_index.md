---
title: Convertir PowerPoint a PDF en Node.js mediante .NET
linktitle: PowerPoint a PDF
type: docs
weight: 30
url: /es/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint a PDF
- convertir PowerPoint a PDF
- PPTX a PDF
- PPT a PDF
- ODP a PDF
- guardar presentación como PDF
- PDF/A
- PdfOptions
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir presentaciones PPTX, PPT y ODP a PDF en JavaScript con Aspose.Slides for Node.js mediante .NET, y generar archivos PDF/A de archivado con PdfOptions."
---
## **Visión general**

Aspose.Slides for Node.js via .NET convierte presentaciones de PowerPoint y OpenDocument a PDF sin Microsoft PowerPoint. Cada diapositiva visible se convierte en una página PDF del mismo tamaño que la diapositiva, y el texto permanece seleccionable y buscable. Este artículo muestra la conversión predeterminada y una conversión a PDF/A con [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/).

Los ejemplos esperan una presentación llamada `sample.pptx` en la carpeta del proyecto que configuraste en [Installation](/slides/es/nodejs-net/installation/). Cualquier presentación de PowerPoint sirve. Guarda cada ejemplo como un archivo `.js` en la carpeta del proyecto y ejecútalo desde esa carpeta con `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET no tiene su propia referencia de API. Refleja la API de Aspose.Slides para .NET con nombres camelCase, por lo que los enlaces de API en este artículo conducen a las clases y miembros correspondientes en la [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/es/net/).
{{% /alert %}}

## **Convertir una presentación a PDF**

Para convertir una presentación a PDF, sigue estos pasos:

1. Abre la presentación pasando su ruta al constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/presentation/). El mismo código funciona para archivos PPTX, PPT y ODP.  
2. Llama al método [save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) con la ruta de salida y `SaveFormat.Pdf`.  
3. Llama a `dispose` en un bloque `finally` para liberar los recursos .NET que respaldan la presentación.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

El script escribe `sample.pdf` en la carpeta del proyecto. La conversión usa la configuración predeterminada: cada diapositiva que no esté oculta se convierte en una página, en el orden de las diapositivas. Sin una licencia, cada página también muestra una marca de agua de evaluación; consulta [Licensing](/slides/es/nodejs-net/licensing/).

## **Convertir una presentación a PDF/A**

Para controlar la salida, pasa un objeto [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/) como tercer argumento de `save`. El siguiente ejemplo establece la propiedad [compliance](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/compliance/) a `PdfCompliance.PdfA2b`, lo que produce un archivo PDF/A-2b. PDF/A es el estándar ISO para archivado a largo plazo: entre otras reglas, requiere que todas las fuentes que utiliza el documento estén incrustadas en el archivo.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

El script escribe `sample-pdfa.pdf` con las mismas páginas que la conversión predeterminada. Para confirmar que un archivo cumple con el estándar, revísalo con un validador PDF/A como [veraPDF](https://verapdf.org/). Otros valores de [PdfCompliance](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfcompliance/) seleccionan otros estándares, como `PdfA1b`, `PdfA2a` o `PdfUa` para accesibilidad.

## **Preguntas frecuentes**

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Las diapositivas ocultas se omiten por defecto. Establece la propiedad [showHiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/showhiddenslides/) de `PdfOptions` a `true` y pasa las opciones a `save`.

**¿Puedo proteger el PDF con una contraseña?**

Sí. Establece la propiedad [password](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/password/) de `PdfOptions` antes de llamar a `save`. Los lectores de PDF entonces solicitan esa contraseña antes de abrir el archivo.

**¿Puedo convertir solo algunas diapositivas?**

Sí. Pasa un arreglo de posiciones de diapositivas como cuarto argumento de `save`. Las posiciones empiezan en 1, y el tercer argumento puede ser `null` si no necesitas opciones: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` escribe un PDF con la primera y la tercera diapositiva.

**¿Por qué el texto se ve diferente al convertir en Linux?**

Aspose.Slides solo puede usar fuentes que estén instaladas en la máquina que realiza la conversión. Cuando una presentación usa una fuente que falta, como Calibri en un servidor Linux típico, Aspose.Slides utiliza una fuente instalada en su lugar, lo que puede cambiar el aspecto del texto y dónde se rompen las líneas. Instala las fuentes que utilizan tus presentaciones para obtener el mismo resultado que en Windows.

**¿Puedo obtener el PDF como Buffer en lugar de un archivo?**

Sí. `presentation.saveToBuffer(SaveFormat.Pdf)` devuelve el PDF como un `Buffer` de Node.js, lo que resulta conveniente cuando envías el resultado en una respuesta HTTP. También acepta `PdfOptions` como su segundo argumento.