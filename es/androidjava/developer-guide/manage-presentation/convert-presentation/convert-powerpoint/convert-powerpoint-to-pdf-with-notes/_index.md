---
title: Convertir presentaciones de PowerPoint a PDF con notas en Android
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PDF
- presentación a PDF
- diapositiva a PDF
- PPT a PDF
- PPTX a PDF
- guardar presentación como PDF
- guardar PPT como PDF
- guardar PPTX como PDF
- exportar PPT a PDF
- exportar PPTX a PDF
- notas del presentador
- PDF con notas
- Android
- Java
- Aspose.Slides
description: "Convertir los formatos PPT y PPTX a PDF con notas usando Aspose.Slides para Android mediante Java. Conservar diseños y notas del presentador para presentaciones profesionales."
---
## **Descripción general**

En este artículo, aprenderá cómo convertir presentaciones de PowerPoint al formato PDF con notas del presentador usando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF conservando las notas del presentador.  
- Personalizar el PDF de salida para garantizar que las notas del presentador se incluyan y formateen según sus requisitos.

## **Convertir PowerPoint a PDF con notas**

El método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) se puede usar para convertir una presentación PPT o PPTX a un PDF con notas del presentador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño usando la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notescommentslayoutingoptions/) para incluir las notas del presentador y luego guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a un PDF en la vista de diapositiva de notas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Configurar opciones PDF para renderizar notas del presentador.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizar notas del presentador debajo de la diapositiva.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Guardar la presentación en PDF con notas del presentador.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 

Puede que desee consultar el [Convertidor en línea de PowerPoint a PDF](https://products.aspose.app/slides/es/conversion) de Aspose. 

{{% /alert %}}