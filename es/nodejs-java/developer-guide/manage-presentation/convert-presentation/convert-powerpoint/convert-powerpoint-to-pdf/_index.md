---
title: Convertir PPT y PPTX a PDF en JavaScript [Funciones avanzadas incluidas]
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir presentación
- PowerPoint a PDF
- presentación a PDF
- PPT a PDF
- convertir PPT a PDF
- PPTX a PDF
- convertir PPTX a PDF
- guardar PowerPoint como PDF
- guardar PPT como PDF
- guardar PPTX como PDF
- exportar PPT a PDF
- exportar PPTX a PDF
- adjunto
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y buscables usando Aspose.Slides para Node.js, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint y OpenDocument (PPT, PPTX, ODP, etc.) a formato PDF en JavaScript ofrece varias ventajas, entre ellas la compatibilidad con diferentes dispositivos y la preservación del diseño y formato de la presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar distintas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger el PDF con contraseña, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pasa el nombre del archivo como argumento a la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y luego guarda la presentación como PDF mediante el método [guardar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). La clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) expone el método [guardar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) que se utiliza normalmente para convertir una presentación a PDF.

{{% alert color="info" title="Nota" %}}

Aspose.Slides para Node.js a través de Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Aplicación con "*Aspose.Slides*" y el campo Productor PDF con un valor en formato "*Aspose.Slides v XX.XX*". **Nota** que no puedes indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides te permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Cabeceras y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles máximos de calidad.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles a PDF usando la configuración de exportación predeterminada.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}

Aspose ofrece un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito en línea que demuestra el proceso de conversión de presentación a PDF. Puedes probar este conversor para ver una implementación en vivo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)— que te permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Con opciones de conversión personalizadas, puedes definir la configuración de calidad preferida para imágenes raster, especificar cómo se deben gestionar los metarchivos, establecer un nivel de compresión para texto, configurar DPI para imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen en 300 DPI, metarchivos guardados como PNG y compresión de texto Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Preservar Archivos OLE Insertados como Adjuntos PDF**

Si una presentación contiene un libro de Excel insertado, puede que desees que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Llama a [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) con `true` para preservar los archivos OLE insertados como adjuntos en el PDF resultante.

El valor predeterminado es `false`: la imagen de vista previa o el icono del objeto OLE se renderiza en la página PDF, pero su archivo insertado no se incluye como adjunto. Establecer la opción a `true` incluye adicionalmente los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo insertado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva en la página PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel insertado y la exporta a PDF con el libro adjunto.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Para comprobar el resultado:

1. Abre el PDF exportado en un visor que admita adjuntos, como Adobe Acrobat Reader.
2. Abre el panel **Adjuntos** del visor y localiza el libro insertado.
3. Guarda el adjunto y ábrelo en Excel para inspeccionar sus datos, o ábrelo directamente si el visor lo permite. La vista previa en la página PDF es independiente del adjunto.

{{% alert color="info" title="Nota" %}}

Las normas PDF/A imponen restricciones sobre los adjuntos: PDF/A‑1 prohíbe archivos insertados, PDF/A‑2 permite solo adjuntos PDF/A y PDF/A‑3 permite otros tipos de archivo, incluidos libros de Excel. Estas son exigencias de las normas, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no muestra una exportación PDF/A.

{{% /alert %}}

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a un PDF Protegido con Contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), lo que te permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime advertencias de sustitución de fuentes en la consola. Sólo se imprime una advertencia cuando se sustituye una fuente no disponible durante la exportación.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}

Para obtener más información sobre la sustitución de fuentes, consulta el artículo [Sustitución de fuentes](/slides/es/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Gestionar Fuentes sin Variante Negrita Dedicada**

Una presentación puede aplicar formato negrita a texto aunque su fuente no disponga de una variante negrita dedicada. El texto puede aparecer en negrita mediante negrita sintética, que engrosa artificialmente los glifos normales. Cuando ese texto se ve demasiado grueso o difiere de la apariencia deseada en el PDF, prueba a llamar a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) con `true`. Esta opción renderiza el texto afectado como un mapa de bits durante la exportación a PDF y puede mejorar su apariencia para ciertas fuentes. Su valor predeterminado es `false`.

La presentación de ejemplo contiene dos cuadros de texto: uno con texto normal y otro con formato negrita aplicado a la misma fuente, que no tiene variante negrita dedicada. El siguiente ejemplo carga la presentación, habilita la rasterización de estilos de fuente no compatibles y la exporta a PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Las siguientes vistas previas muestran la salida desactivada y la salida activada. En este ejemplo, el texto en negrita tiene trazos más gruesos con la opción desactivada. Con la opción activada, sus trazos son más ligeros; el texto normal permanece sin cambios. Compara los resultados antes de elegir la configuración para tu presentación.

| Opción desactivada (`false`, por defecto) | Opción activada (`true`) |
|---|---|
| ![PDF con rasterización de estilo de fuente no compatible desactivada](unsupported-bold-disabled.png) | ![PDF con rasterización de estilo de fuente no compatible activada](unsupported-bold-enabled.png) |

En este ejemplo, al activar la opción sólo el texto en negrita se convierte en mapa de bits: no puede seleccionarse, copiarse o buscarse como texto sin OCR, y sus bordes aparecen más suaves al 800 % de zoom. El texto normal sigue siendo buscable. Con la opción desactivada, ambas cadenas permanecen como texto.

Esta opción rasteriza el texto formateado como negrita cuando su fuente no tiene una variante negrita dedicada. La [sustitución de fuentes](/slides/es/nodejs-java/font-substitution/) selecciona en cambio otra fuente cuando la original no está disponible.

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este arreglo son base‑uno, y la presentación de entrada debe contener al menos tres diapositivas.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación a una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarlo y exporta la diapositiva única a PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Eliminar la diapositiva vacía con la que se creó la nueva presentación.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF en Vista de Notas de Diapositiva**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva bajo la propia diapositiva. Usa una presentación que contenga notas del orador para ver el resultado.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accesibilidad y Normas de Cumplimiento para PDF**

Aspose.Slides te permite usar un procedimiento de conversión que cumpla con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento PowerPoint a PDF utilizando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que produce varios PDFs basados en diferentes normas de cumplimiento:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}

Aspose.Slides admite operaciones de conversión a PDF, lo que te permite convertir archivos PDF a formatos de archivo populares. Puedes realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF a JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)— también son compatibles.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **FAQ**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puedes iterar sobre tus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Usa la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Llama a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) con `true` en la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puedes controlar la calidad de imagen usando métodos como [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) y [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) en la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para garantizar imágenes de alta calidad en tu PDF.

**¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides te permite exportar PDFs que cumplan con [varias normas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), incluidas PDF/A1a, PDF/A1b y PDF/UA, asegurando que tus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para Node.js a través de Java](/slides/es/nodejs-java/)
- [Referencia de API de Aspose.Slides para Node.js a través de Java](https://reference.aspose.com/slides/nodejs-java/)
- [Conversores gratuitos en línea de Aspose](https://products.aspose.app/slides/conversion)