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
description: "Convertir PPT/PPTX de PowerPoint a PDFs de alta calidad y buscables usando Aspose.Slides para Node.js, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint y OpenDocument (PPT, PPTX, ODP, etc.) a formato PDF en JavaScript ofrece varias ventajas, incluida la compatibilidad con diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Utilizando Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la [Presentación](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método `save`. La clase [Presentación](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) expone el método `save` que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en formato "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso de conversión estándar de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas con los niveles máximos de calidad.

Este código muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:

```js
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Guardar la presentación como PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose ofrece un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) gratuito en línea que muestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación en tiempo real del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades de la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pdfoptions/)— que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metarchivos, establecer un nivel de compresión para el texto, configurar DPI para las imágenes y más.

El ejemplo de código a continuación muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.

```js
// Instanciar la clase PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Establecer la calidad para imágenes JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Establecer DPI para imágenes.
pdfOptions.setSufficientResolution(300);

// Establecer el comportamiento de los metarchivos.
pdfOptions.setSaveMetafilesAsPng(true);

// Establecer el nivel de compresión de texto para el contenido textual.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definir el modo de cumplimiento del PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Guardar la presentación como documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede utilizar el método [setShowHiddenSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) de la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código JavaScript muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:

```js
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanciar la clase PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Añadir diapositivas ocultas.
    pdfOptions.setShowHiddenSlides(true);

    // Guardar la presentación como PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código JavaScript demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions):

```js
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanciar la clase PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Establecer una contraseña PDF y los permisos de acceso.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Guardar la presentación como PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar sustituciones de fuentes**

Aspose.Slides ofrece el método [setWarningCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) en la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código JavaScript muestra cómo detectar sustituciones de fuentes:

```js
// Establecer la devolución de llamada de advertencia en las opciones PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
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

Para obtener más información sobre la sustitución de fuentes, consulte el artículo [Sustitución de fuentes](/slides/es/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

Este código JavaScript demuestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:

```js
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Establecer la matriz de números de diapositivas.
    let slides = java.newArray("int", [1, 3]);

    // Guardar la presentación como PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código JavaScript muestra cómo convertir una presentación de PowerPoint a PDF con un tamaño de diapositiva especificado:

```js
const slideWidth = 612;
const slideHeight = 792;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
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

## **Convertir PowerPoint a PDF en vista de notas**

Este código JavaScript muestra cómo convertir una presentación de PowerPoint a un PDF que incluya notas:

```js
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
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

## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides le permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad para el Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código JavaScript muestra un proceso de conversión de PowerPoint a PDF que produce varios PDFs basados en diferentes normas de cumplimiento:

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

Aspose.Slides admite operaciones de conversión de PDF, lo que le permite convertir archivos PDF a formatos populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/es/nodejs-java/conversion/pdf-to-html/), [PDF a JPG](https://products.aspose.com/slides/es/nodejs-java/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/es/nodejs-java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/es/nodejs-java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/es/nodejs-java/conversion/pdf-to-tiff/)— también son compatibles.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **FAQ**

**¿Puedo convertir varios archivos de PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sus archivos y aplicar el proceso de conversión mediante programación.

**¿Es posible proteger con contraseña el PDF convertido?**

Absolutamente. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Utilice el método `setShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions) para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de la imagen usando métodos como `setJpegQuality` y `setSufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PdfOptions) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con diversas normas, incluidas PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con los requisitos de accesibilidad y archivado.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para Node.js mediante Java](/slides/es/nodejs-java/)
- [Referencia de API de Aspose.Slides para Node.js mediante Java](https://reference.aspose.com/slides/es/nodejs-java/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/es/conversion)