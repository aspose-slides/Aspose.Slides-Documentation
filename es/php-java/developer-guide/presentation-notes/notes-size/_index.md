---
title: Cambiar el tamaño y la orientación de la página de notas en PHP
linktitle: Tamaño de la página de notas
type: docs
weight: 10
url: /es/php-java/notes-size/
keywords:
- tamaño de página de notas
- orientación de notas
- notas en horizontal
- notas en vertical
- tamaño del folleto
- PowerPoint
- presentación
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lea y cambie las dimensiones de la página de notas en Aspose.Slides para PHP mediante Java, cambie la orientación, verifique los tamaños guardados y exporte notas o folletos a PDF e imágenes."
---
## **Descripción general**

Utilice [Presentation::getNotesSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getnotessize/) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [NotesSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/notessize/) cuyo método [setSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/notessize/setsize/) establece las dimensiones de la página. Aunque el objeto de configuración no puede ser reemplazado, puede asignar nuevas dimensiones mediante este método.

El ancho y la altura se especifican en **points**, con 72 points por pulgada. Por ejemplo, 900 × 600 points equivalen a 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, y no a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getnotessize/) | Controla las dimensiones de la página de notas y las dimensiones de página usadas para la exportación de folletos. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getslidesize/) | Controla las dimensiones de las diapositivas normales de la presentación mediante [SlideSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/). |

Cambiar cualquiera de los ajustes no modifica automáticamente el otro. Cambiar la orientación de la página de notas tampoco rota las diapositivas normales. Consulte [Slide Size](/slides/es/php-java/slide-size/) para redimensionar las diapositivas normales.

Los ejemplos siguientes utilizan un `sample.pptx` existente. Para los ejemplos de exportación, use una presentación que contenga al menos una diapositiva con notas del orador. Cada ejemplo puede ejecutarse de forma independiente después de cargar el PHP/Java Bridge y el contenedor PHP de Aspose.Slides. Los valores numéricos devueltos por Java se convierten a valores PHP con `java_values` antes de la comparación o el cálculo.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una página más alta es vertical, y dimensiones iguales describen una página cuadrada. Este ejemplo imprime las dimensiones reales en points, sin asumir un tamaño de papel estándar.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Cambiar a horizontal sin modificar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto preserva las longitudes de ambos lados, incluidas las de un tamaño de papel personalizado. La condición a continuación impide que una página ya en horizontal se cambie a vertical y deja una página cuadrada sin alterar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para orientación vertical, use la misma asignación cuando `java_values($size->getWidth()) > java_values($size->getHeight())`. No sustituya las dimensiones de A4 o Carta a menos que también desee cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones juntas, luego use [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/save/) para escribir la presentación. Este ejemplo establece una página horizontal de 900 × 600 points, la guarda como PPTX y abre el archivo guardado nuevamente para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 points para valores de coma flotante; no es una garantía de precisión para cada formato de archivo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

El resultado esperado es `900 x 600 points` y `Size preserved: true`. Comprobar una presentación recién abierta verifica el archivo guardado, en lugar de solo los ajustes en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para los diseños de notas o folletos. No habilitan esos diseños por sí mismas: también hay que configurar las opciones de exportación. La exportación de diapositivas normales sigue usando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getImage) y [RenderingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/php-java/aspose.slides/notespositions/) mantiene las notas en una sola página; las notas que no quepan pueden truncarse. El PDF utiliza páginas de 900 × 600 points. Con la escala de imagen de 1 × 1 usada a continuación, el PNG es de 900 × 600 píxeles. Los points describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Para la exportación a PDF con notas largas, [BottomFull](https://reference.aspose.com/slides/es/php-java/aspose.slides/notespositions/) permite páginas adicionales según sea necesario. No use ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo admite. Después de cambiar el tamaño, inspeccione la salida para notas recortadas y la ubicación de los objetos notes-master existentes; cambiar solo las dimensiones de la página no debe considerarse una garantía de que todo el contenido cabrá. Consulte [Convert PowerPoint to PDF with Notes](/slides/es/php-java/convert-powerpoint-to-pdf-with-notes/) para obtener más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/handoutlayoutingoptions/) para varias miniaturas de diapositivas en una página. El siguiente ejemplo establece una página de 900 × 600 points y usa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/es/php-java/aspose.slides/handouttype/) para organizar hasta cuatro diapositivas por página. El preajuste horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula del folleto sin cambiar las dimensiones de las diapositivas originales. Para imágenes de folleto, use [Presentation::getImages](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getimages/) con el diseño de folleto, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, la renderización de folletos a nivel de presentación utiliza las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folleto. Consulte [Handout Mode](/slides/es/php-java/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

Mantenga el tamaño de la presentación almacenado, el tamaño de página exportado y el tamaño de papel impreso separados:

- **Visores de presentaciones:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, vuelva a abrirlo y compruebe las dimensiones nuevamente; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster usan dimensiones de píxeles enteras y una escala de renderizado, por lo que los valores de points fraccionarios pueden redondearse en la salida de la imagen. Exportar diapositivas normales no aplica el tamaño de página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y los ajustes de ajuste al página pueden cambiar la salida física sin modificar las dimensiones almacenadas en la presentación o el PDF. Para un tamaño de papel específico, coincida los ajustes de la impresora e inspeccione la vista previa de impresión.

## **Preguntas frecuentes**

**¿Puedo establecer el tamaño de las notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden tener contenido de notas diferente, pero esta propiedad no ofrece un tamaño de página separado para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas normales tienen dimensiones independientes. Utilice la configuración del tamaño de diapositiva regular cuando desee redimensionar las propias diapositivas.

**¿Por qué mi resultado guardado o impreso tiene un tamaño diferente?**

Primero vuelva a abrir la presentación guardada y compare sus dimensiones de notas. Si estas cambiaron, verifique si al guardar o convertir el archivo en otra aplicación se modificaron los ajustes de página. Si no, revise el diseño de exportación, la escala de la imagen, los ajustes del visor y la selección de papel de la impresora.