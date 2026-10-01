---
title: Cambiar el tamaño y la orientación de la página de notas en Android
linktitle: Tamaño de página de notas
type: docs
weight: 10
url: /es/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "Leer y cambiar las dimensiones de la página de notas en Aspose.Slides para Android mediante Java, cambiar la orientación, verificar los tamaños guardados y exportar notas o folletos a PDF e imágenes."
---
## **Visión general**

Use [Presentation.getNotesSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getNotesSize--) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [INotesSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/inotessize/) cuyo método [setSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) establece las dimensiones de la página. Aunque el propio objeto de configuración no puede ser sustituido, puede asignar nuevas dimensiones mediante este método.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos son 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, no a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Controla las dimensiones de la página de notas y las dimensiones de página usadas para la exportación de folletos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Controla las dimensiones de las diapositivas normales mediante [ISlideSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidesize/). |

Cambiar cualquiera de las configuraciones no modifica automáticamente la otra. Cambiar la orientación de la página de notas tampoco rota las diapositivas normales. Consulte [Slide Size](/slides/es/androidjava/slide-size/) para cambiar el tamaño de las diapositivas normales.

Los ejemplos a continuación utilizan un `sample.pptx` existente. Para los ejemplos de exportación, use una presentación con al menos una diapositiva que contenga notas del presentador. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una página más alta es vertical, y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin suponer un tamaño de papel estándar.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

Para cambiar solo la orientación, intercambie el ancho y la altura actuales. Esto conserva la longitud de ambos lados, incluidas las de un tamaño de papel personalizado. La condición a continuación evita que una página ya horizontal se vuelva a cambiar a vertical y deja una página cuadrada sin cambios.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para orientación vertical, use la misma asignación cuando `size.getWidth() > size.getHeight()`. No sustituya las dimensiones de A4 o Letter a menos que también quiera cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones a la vez, luego use [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para escribir la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y abre el archivo guardado nuevamente para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de coma flotante; no es una garantía de precisión para cada formato de archivo.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

El resultado esperado es `900.0 x 600.0 points` y `Size preserved: true`. Comprobar una presentación recién abierta verifica el archivo guardado, en lugar de solo la configuración en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para los diseños de notas o folletos. No habilitan esos diseños por sí mismas: también configure las opciones de exportación. La exportación de diapositivas normales continúa usando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) y [RenderingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notespositions/) mantiene las notas en una sola página; las notas que no quepan pueden truncarse. El PDF usa páginas de 900 × 600 puntos. Con la escala de imagen de 1 × 1 usada a continuación, el PNG es de 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Para la exportación a PDF con notas largas, [BottomFull](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notespositions/) permite páginas adicionales según sea necesario. No use ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo admite. Después de cambiar el tamaño, inspeccione la salida en busca de notas recortadas y la ubicación de los objetos existentes del maestro de notas; cambiar solo las dimensiones de la página no debe considerarse una garantía de que todo el contenido quepa. Consulte [Convert PowerPoint to PDF with Notes](/slides/es/androidjava/convert-powerpoint-to-pdf-with-notes/) para más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/handoutlayoutingoptions/) para varias miniaturas de diapositivas en una página. El siguiente ejemplo establece una página de 900 × 600 puntos y usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/handouttype/) para organizar hasta cuatro diapositivas por página. El ajuste horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula del folleto sin cambiar las dimensiones de las diapositivas de origen. Para imágenes de folletos, use [Presentation.getImages](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) con el diseño de folleto, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, la representación de folletos a nivel de presentación utiliza las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folleto. Consulte [Handoff Mode](/slides/es/androidjava/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

Mantenga separados el tamaño almacenado de la presentación, el tamaño de página exportado y el tamaño de papel impreso:

- **Visores de presentaciones:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, ábralo de nuevo y verifique las dimensiones; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores utilizan las dimensiones de página configuradas. Las imágenes raster usan dimensiones de píxel enteras y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de imagen. Exportar diapositivas normales no aplica el tamaño de página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y la configuración de ajuste a página pueden cambiar la salida física sin alterar las dimensiones almacenadas en la presentación o el PDF. Para un tamaño de papel específico, ajuste la configuración de la impresora e inspeccione la vista previa de impresión.

## **Preguntas frecuentes**

**¿Puedo establecer el tamaño de notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden tener contenido de notas diferente, pero esta propiedad no proporciona un tamaño de página separado para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas normales tienen dimensiones independientes. Use la configuración de tamaño de diapositiva normal cuando desee cambiar el tamaño de las diapositivas en sí.

**¿Por qué mi resultado guardado o impreso tiene un tamaño diferente?**

Primero abra de nuevo la presentación guardada y compare sus dimensiones de notas. Si esas cambiaron, compruebe si al guardar o convertir el archivo en otra aplicación se modificaron los ajustes de página. Si no, revise el diseño de exportación, la escala de imagen, la configuración del visor y la selección de papel de la impresora.