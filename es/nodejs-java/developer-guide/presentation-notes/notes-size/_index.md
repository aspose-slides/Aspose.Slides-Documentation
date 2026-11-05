---
title: Cambiar el tamaño y la orientación de la página de notas en JavaScript
linktitle: Tamaño de página de notas
type: docs
weight: 10
url: /es/nodejs-java/notes-size/
keywords:
- tamaño de página de notas
- orientación de notas
- notas horizontales
- notas verticales
- tamaño de folleto
- PowerPoint
- presentación
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer y cambiar las dimensiones de la página de notas en Aspose.Slides para Node.js a través de Java, cambiar la orientación, verificar los tamaños guardados y exportar notas o folletos a PDF e imágenes."
---
## **Visión general**

Utilice [Presentation.getNotesSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getnotessize/) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [NotesSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notessize/) cuyo método [setSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notessize/setsize/) establece las dimensiones de la página. Aunque el objeto de configuración no puede sustituirse, puede asignar nuevas dimensiones mediante este método.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos son 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, no a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getnotessize/) | Controla las dimensiones de la página de notas y las dimensiones de la página usadas para la exportación de folletos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslidesize/) | Controla las dimensiones habituales de las diapositivas mediante [SlideSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesize/). |

Cambiar una de las configuraciones no modifica automáticamente la otra. Cambiar la orientación de la página de notas tampoco gira las diapositivas normales. Consulte [Slide Size](/slides/es/nodejs-java/slide-size/) para cambiar el tamaño de las diapositivas habituales.

Los ejemplos siguientes utilizan un `sample.pptx` existente. Para los ejemplos de exportación, use una presentación que contenga al menos una diapositiva con notas del expositor. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una más alta es vertical y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin suponer un tamaño de papel estándar.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Cambiar a horizontal sin modificar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto conserva las longitudes de ambos lados, incluidas las de un tamaño de papel personalizado. La condición a continuación evita que una página ya horizontal se vuelva a convertir en vertical y deja sin cambios una página cuadrada.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para orientación vertical, use la misma asignación cuando `size.getWidth() > size.getHeight()`. No sustituya dimensiones A4 o Letter a menos que también quiera cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones a la vez y luego utilice [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/save/) para guardar la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y vuelve a abrir el archivo guardado para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de coma flotante; no garantiza precisión para cada formato de archivo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

El resultado esperado es `900 x 600 points` y `Size preserved: true`. Comprobar una presentación recién abierta verifica el archivo guardado, no solo la configuración en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para los diseños de notas o folletos. No activan esos diseños por sí mismos: también configure las opciones de exportación. La exportación de diapositivas normales sigue usando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG mediante [Slide.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getImage) y [RenderingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notespositions/) mantiene las notas en una sola página; las notas que no entren pueden truncarse. El PDF utiliza páginas de 900 × 600 puntos. Con la escala de imagen 1 × 1 usada a continuación, el PNG tiene 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Para la exportación a PDF con notas extensas, [BottomFull](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notespositions/) permite páginas adicionales según sea necesario. No use ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo soporta. Después de redimensionar, revise la salida para detectar notas recortadas y la colocación de los objetos existentes del maestro de notas; cambiar solo el tamaño de la página no garantiza que todo el contenido quepa. Vea [Convert PowerPoint to PDF with Notes](/slides/es/nodejs-java/convert-powerpoint-to-pdf-with-notes/) para más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/handoutlayoutingoptions/) para obtener varias miniaturas de diapositivas en una página. El ejemplo siguiente establece una página de 900 × 600 puntos y usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/handouttype/) para disponer hasta cuatro diapositivas por página. El ajuste horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula del folleto sin cambiar las dimensiones de las diapositivas de origen. Para imágenes de folletos, utilice [Presentation.getImages](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getimages/) con el diseño de folleto, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, la representación de folletos a nivel de presentación usa las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folleto. Vea [Handout Mode](/slides/es/nodejs-java/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visualizadores, exportación e impresión**

Mantenga separados el tamaño almacenado de la presentación, el tamaño de página exportado y el tamaño de papel impreso:

- **Visualizadores de presentaciones:** Un visualizador puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, vuelva a abrirlo y compruebe nuevamente las dimensiones; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster utilizan dimensiones de píxeles enteras y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de la imagen. Exportar diapositivas normales no aplica el tamaño de la página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y la configuración de ajuste a la página pueden modificar la salida física sin cambiar las dimensiones almacenadas en la presentación o en el PDF. Para un tamaño de papel específico, ajuste la configuración de la impresora y revise la vista previa de impresión.

## **FAQ**

**¿Puedo establecer el tamaño de las notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden contener diferentes contenidos de notas, pero esta propiedad no permite un tamaño de página separado para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas normales tienen dimensiones independientes. Utilice la configuración de tamaño de diapositiva regular cuando desee redimensionar las propias diapositivas.

**¿Por qué el resultado guardado o impreso tiene un tamaño diferente?**

Primero vuelva a abrir la presentación guardada y compare sus dimensiones de notas. Si esas cambiaron, compruebe si al guardar o convertir el archivo en otra aplicación se modificaron los ajustes de página. Si no, revise el diseño de exportación, la escala de imagen, la configuración del visualizador y la selección de papel de la impresora.