---
title: Cambiar el tamaño y la orientación de la página de notas en Java
linktitle: Tamaño de la página de notas
type: docs
weight: 10
url: /es/java/notes-size/
keywords:
- tamaño de la página de notas
- orientación de las notas
- notas en orientación horizontal
- notas en orientación vertical
- tamaño del folleto
- PowerPoint
- presentación
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Leer y cambiar las dimensiones de la página de notas en Aspose.Slides para Java, cambiar la orientación, verificar los tamaños guardados y exportar notas o folletos a PDF e imágenes."
---
## **Resumen**

Utilice [Presentation.getNotesSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getNotesSize--) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [INotesSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/inotessize/) cuyo método [setSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) establece las dimensiones de la página. Aunque el objeto de configuración no puede ser reemplazado, puede asignar nuevas dimensiones mediante este método.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos equivalen a 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, y no a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getNotesSize--) | Controla las dimensiones de la página de notas y las dimensiones de página usadas para la exportación de folletos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSlideSize--) | Controla las dimensiones de las diapositivas normales de la presentación mediante [ISlideSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidesize/). |

Cambiar cualquiera de las configuraciones no modifica automáticamente la otra. Cambiar la orientación de la página de notas tampoco rota las diapositivas normales. Consulte [Slide Size](/slides/es/java/slide-size/) para cambiar el tamaño de las diapositivas normales.

Los ejemplos a continuación utilizan un archivo `sample.pptx` existente. Para los ejemplos de exportación, use una presentación con al menos una diapositiva que contenga notas del orador. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una página más alta es vertical, y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin asumir un tamaño de papel estándar.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Cambiar a horizontal sin modificar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto conserva las longitudes de ambos lados, incluidos los de un tamaño de papel personalizado. La condición a continuación evita que una página ya horizontal se vuelva a cambiar a vertical y deja una página cuadrada sin modificaciones.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para la orientación vertical, utilice la misma asignación cuando `size.getWidth() > size.getHeight()`. No sustituya las dimensiones de A4 o Carta a menos que también desee cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones juntas, luego use [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) para guardar la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y vuelve a abrir el archivo guardado para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de coma flotante; no es una garantía de precisión para cada formato de archivo.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

El resultado esperado es `900.0 x 600.0 points` y `Size preserved: true`. Verificar una presentación recién abierta confirma el archivo guardado, y no solo la configuración en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para los diseños de notas o folletos. No activan esos diseños por sí mismas: también es necesario configurar las opciones de exportación. La exportación de diapositivas normales sigue utilizando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) y [RenderingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/java/com.aspose.slides/notespositions/) mantiene las notas en una sola página; las notas que no quepan pueden truncarse. El PDF utiliza páginas de 900 × 600 puntos. Con la escala de imagen de 1 × 1 utilizada a continuación, el PNG es de 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Para la exportación a PDF con notas largas, [BottomFull](https://reference.aspose.com/slides/es/java/com.aspose.slides/notespositions/) permite páginas adicionales según sea necesario. No use ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo admite. Después de cambiar el tamaño, inspeccione la salida para detectar notas recortadas y la ubicación de los objetos maestros de notas existentes; cambiar solo las dimensiones de la página no debe considerarse una garantía de que todo el contenido encajará. Consulte [Convert PowerPoint to PDF with Notes](/slides/es/java/convert-powerpoint-to-pdf-with-notes/) para obtener más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/handoutlayoutingoptions/) para varias miniaturas de diapositivas en una página. El siguiente ejemplo establece una página de 900 × 600 puntos y usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/es/java/com.aspose.slides/handouttype/) para disponer hasta cuatro diapositivas por página. La preconfiguración horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula del folleto sin cambiar las dimensiones de las diapositivas de origen. Para imágenes de folletos, use [Presentation.getImages](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) con el diseño de folleto, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, la renderización de folletos a nivel de presentación utiliza las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no genera la página del folleto. Consulte [Handout Mode](/slides/es/java/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

Mantenga separados el tamaño almacenado de la presentación, el tamaño de página exportado y el tamaño de papel impreso:

- **Visores de presentaciones:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, vuelva a abrirlo y compruebe nuevamente las dimensiones; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster utilizan dimensiones de píxeles enteros y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de la imagen. La exportación de diapositivas normales no aplica el tamaño de la página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y los ajustes de ajuste al página pueden cambiar la salida física sin modificar las dimensiones almacenadas en la presentación o PDF. Para un tamaño de papel específico, coincida los ajustes de la impresora e inspeccione la vista previa de impresión.

## **Preguntas frecuentes**

**¿Puedo establecer el tamaño de las notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden tener contenido de notas diferente, pero esta propiedad no proporciona un tamaño de página separado para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas normales tienen dimensiones independientes. Utilice la configuración de tamaño de diapositiva normal cuando desee cambiar el tamaño de las propias diapositivas.

**¿Por qué mi resultado guardado o impreso tiene un tamaño diferente?**

Primero vuelva a abrir la presentación guardada y compare sus dimensiones de notas. Si estas cambiaron, verifique si guardar o convertir el archivo en otra aplicación modificó la configuración de la página. Si no lo hizo, revise el diseño de exportación, la escala de la imagen, los ajustes del visor y la selección de papel de la impresora.