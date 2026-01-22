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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y con capacidad de búsqueda usando Aspose.Slides para Node.js, con ejemplos de código rápidos y opciones avanzadas de conversión."
---

## **Resumen**

Convertir presentaciones PowerPoint y OpenDocument (PPT, PPTX, ODP, etc.) a formato PDF con JavaScript ofrece varias ventajas, incluida la compatibilidad entre dispositivos y la preservación del diseño y formato de la presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pasa el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y luego guarda la presentación como PDF usando un método `save`. La clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) expone el método `save` que normalmente se usa para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en forma "*Aspose.Slides v XX.XX*". **Note** que no puedes indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

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

Este código muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:
```js
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Guardar la presentación como PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose ofrece un [**convertidor gratuito en línea de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Puedes realizar una prueba con este conversor para una implementación en vivo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)— que permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puedes definir tu configuración de calidad preferida para imágenes raster, especificar cómo se deben manejar los metarchivos, establecer un nivel de compresión para texto, configurar DPI para imágenes y más.

El ejemplo de código a continuación demuestra cómo convertir una presentación PowerPoint a PDF con varias opciones personalizadas.
```js
// Instanciar la clase PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality(java.newByte(90));

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Guardar la presentación como documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) de la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código JavaScript muestra cómo convertir una presentación PowerPoint a PDF con las diapositivas ocultas incluidas:
```js
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanciar la clase PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Agregar diapositivas ocultas.
    pdfOptions.setShowHiddenSlides(true);

    // Guardar la presentación como PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código JavaScript demuestra cómo convertir una presentación PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions):
```js
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanciar la clase PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Establecer una contraseña PDF y permisos de acceso.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Guardar la presentación como PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) bajo la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código JavaScript muestra cómo detectar sustituciones de fuentes:
```js
// Establecer la devolución de llamada de advertencia en las opciones PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument file.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Guardar la presentación como PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```


{{%  alert color="primary"  %}} 

Para obtener más información sobre la sustitución de fuentes, consulta el artículo [Font Substitution](/slides/es/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

Este código JavaScript muestra cómo convertir solo diapositivas específicas de una presentación PowerPoint a PDF:
```js
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Establecer matriz de números de diapositiva.
    let slides = java.newArray("int", [1, 3]);

    // Guardar la presentación como PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código JavaScript muestra cómo convertir una presentación PowerPoint a PDF con un tamaño de diapositiva especificado:
```js
const slideWidth = 612;
const slideHeight = 792;

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Crear una nueva presentación con un tamaño de diapositiva ajustado.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Establecer el tamaño de diapositiva personalizado.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Clonar la primera diapositiva de la presentación original.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Guardar la presentación redimensionada en un PDF con notas.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Convertir PowerPoint a PDF en Vista de Diapositiva de Notas**

Este código JavaScript muestra cómo convertir una presentación PowerPoint a un PDF que incluye notas:
```js
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Configurar las opciones PDF con diseño de notas.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Guardar la presentación en un PDF con notas.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Accesibilidad y Normas de Cumplimiento para PDF**

Aspose.Slides permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código JavaScript demuestra un proceso de conversión de PowerPoint a PDF que produce varios PDF según diferentes normas de cumplimiento:
```js
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides admite operaciones de conversión de PDF, permitiendo convertir archivos PDF a formatos de archivo populares. Puedes realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF a JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)— también son compatibles.

{{% /alert %}}

## **FAQ**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puedes iterar sobre tus archivos y aplicar el proceso de conversión de forma programática.

**¿Es posible proteger con contraseña el PDF convertido?**

Absolutamente. Utiliza la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Usa el método `setShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener una alta calidad de imagen en el PDF?**

Sí, puedes controlar la calidad de imagen utilizando métodos como `setJpegQuality` y `setSufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) para garantizar imágenes de alta calidad en tu PDF.

**¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides permite exportar PDFs que cumplen con varias normas, incluidas PDF/A1a, PDF/A1b y PDF/UA, asegurando que tus documentos cumplan con requisitos de accesibilidad y archivo.

## **Recursos Adicionales**

- [Documentación de Aspose.Slides para Node.js vía Java](/slides/es/nodejs-java/)
- [Referencia de API de Aspose.Slides para Node.js vía Java](https://reference.aspose.com/slides/nodejs-java/)
- [Convertidores Gratuitos en Línea de Aspose](https://products.aspose.app/slides/conversion)