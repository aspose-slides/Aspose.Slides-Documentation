---
title: Administrar Zoom de Presentación en PHP
linktitle: Administrar Zoom
type: docs
weight: 60
url: /es/php-java/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- añadir zoom
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides for PHP a través de Java — saltar entre secciones, añadir miniaturas y transiciones en presentaciones de PowerPoint."
---
## **Introducción**

Los zooms de PowerPoint le permiten navegar entre diapositivas y secciones específicas durante una presentación. Con Aspose.Slides for PHP a través de Java, puede crear zooms de diapositiva, de sección y de resumen y personalizar sus vistas previas, bordes y transiciones.

![Vista general del zoom de PowerPoint](overview.png)

* Para resumir toda la presentación en una sola diapositiva, use un [Resumen Zoom](#summary-zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de Diapositiva](#slide-zoom).
* Para mostrar solo una sección, use un [Zoom de Sección](#section-zoom).

## **Zoom de Diapositiva**

Un zoom de diapositiva puede hacer su presentación más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zooms de diapositiva son ideales para presentaciones cortas sin muchas secciones, pero también pueden usarse en diferentes escenarios de presentación.

Los zooms de diapositiva le permiten explorar información relacionada desde una única diapositiva de vista general.

![Seleccionar diapositivas para un zoom de diapositiva](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/), la clase [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/), y los métodos de la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Crear marcos de zoom**

Utilice [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) para colocar enlaces a diapositivas individuales en una diapositiva de vista general. Este ejemplo crea dos diapositivas de destino con fondos y etiquetas diferentes, luego añade una vista previa de cada una a la primera diapositiva y guarda la presentación como PPTX. Las posiciones y dimensiones del marco se especifican en puntos.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Crear marcos de zoom con imágenes personalizadas**

Pase una imagen personalizada a [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) para reemplazar la vista previa predeterminada de la diapositiva de destino. Este ejemplo requiere una imagen local, la carga con [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile), y la añade a la presentación usando [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). El marco resultante muestra esa imagen mientras sigue enlazando a la segunda diapositiva.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Formato de marcos de zoom**

Este ejemplo personaliza dos marcos de zoom de diapositiva. Asigna una imagen local al primer marco mediante [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), y da al segundo marco un borde rosado de cinco puntos, de guión‑punto, a través de [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat). Pasar `false` a [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) oculta el fondo del segundo marco. Se requiere una imagen local para la vista previa personalizada; ambos marcos conservan sus destinos de diapositiva en el PPTX guardado.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $firstZoomFrame = $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $secondZoomFrame = $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $firstZoomFrame->setZoomImage($previewImage);

    $secondZoomFrame->getLineFormat()->setWidth(5);
    $secondZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 105, 180);
    $secondZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);

    $secondZoomFrame->setShowBackground(false);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zoom de Sección**

Un zoom de sección enlaza a una sección de su presentación. Úselo para volver a un tema o mostrar cómo se conectan las diferentes partes de la presentación.

![Seleccionar una sección para un zoom de sección](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la clase [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/), y los métodos de la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Crear marcos de zoom de sección**

Cree una sección con [SectionCollection::addSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection), luego pase la sección devuelta a [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame). Este ejemplo coloca un zoom de sección en la primera diapositiva y lo enlaza a una sección que comienza con una diapositiva coloreada. La posición y dimensiones del marco se especifican en puntos, y la presentación se guarda como PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Crear marcos de zoom de sección con imágenes personalizadas**

La sobrecarga de imagen de [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) le permite mostrar una vista previa personalizada sin cambiar la sección de destino. Este ejemplo requiere una imagen local, que se carga con [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) y se añade mediante [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). La presentación guardada contiene un zoom de sección en la primera diapositiva enlazado a la sección recién creada.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Cambiar la sección de destino de un zoom de sección**

Utilice [SectionZoomFrame::setTargetSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/#setTargetSection) para redirigir un zoom de sección existente sin recrearlo. Elija una sección poblada de la colección [Presentation::getSections](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSections) de la misma presentación. Asignar una sección vacía deja el destino actual sin cambios, por lo que debe comprobar [Section::getSlidesListOfSection](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSlidesListOfSection) antes de asignarla. Consulte [Manage Slide Sections](/slides/es/php-java/slide-section/) para obtener más información sobre las secciones.

El siguiente ejemplo carga un archivo de presentación, que debe contener varias secciones pobladas, un zoom de sección existente llamado `Section navigation` y una sección con el nombre único `Results`. Busca el zoom en todas las diapositivas y encuentra el destino por nombre en lugar de por un índice de colección que puede cambiar cuando se reordenan las secciones. Si los nombres no son únicos, use [Section::getSectionId](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSectionId) para identificar el destino.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("section-zoom.pptx");
try {
    $zoom = null;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($i = 0; $i < $slideCount; $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($j = 0; $j < $shapeCount; $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISectionZoomFrame")) && java_values($shape->getName()) === "Section navigation") {
                $zoom = $shape;
                break;
            }
        }
        if ($zoom != null) {
            break;
        }
    }

    $targetSection = null;
    $sectionCount = java_values($presentation->getSections()->size());
    for ($i = 0; $i < $sectionCount; $i++) {
        $section = $presentation->getSections()->get_Item($i);
        if (java_values($section->getName()) === "Results") {
            $targetSection = $section;
            break;
        }
    }

    if ($zoom == null || $targetSection == null) {
        echo "The section zoom or destination section was not found.", PHP_EOL;
    } else if (java_values($targetSection->getSlidesListOfSection()->size()) == 0) {
        echo "The destination section is empty.", PHP_EOL;
    } else {
        $currentSection = $zoom->getTargetSection();
        echo "Current section: " . (java_is_null($currentSection) ? "" : java_values($currentSection->getName())), PHP_EOL;
        $zoom->setTargetSection($targetSection);
        $presentation->save("section-zoom-updated.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

### **Formato de marcos de zoom de sección**

Este ejemplo mueve y redimensiona un zoom de sección a 100 por 75 puntos, asigna una imagen local mediante [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), y aplica un borde marrón de 2,5 puntos, guión‑punto. Habilita [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) para volver a la diapositiva de origen después de la sección, deshabilita [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground), y establece [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) a 1,5 segundos. Se requiere una imagen local para la vista previa personalizada.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);

    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $sectionZoomFrame->setZoomImage($previewImage);

    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);

    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);

    $sectionZoomFrame->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zoom de Resumen**

Un zoom de resumen ofrece una visión general de las secciones de la presentación. Durante una presentación, puede usarlo para saltar a una sección, avanzar o volver a un tema sin seguir el orden de las diapositivas.

![Seleccionar secciones para un zoom de resumen](sumzoomsel.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las clases [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/), y [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/), y los métodos de la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Crear un zoom de resumen**

Utilice [ShapeCollection::addSummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSummaryZoomFrame) para crear una visión general de las secciones de la presentación. Este ejemplo crea cuatro secciones con fondos de diapositiva diferentes y añade un zoom de resumen a la primera diapositiva. La posición y dimensiones del marco se especifican en puntos, y la visión general resultante se guarda en una presentación PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 3", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 100, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 4", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Añadir y eliminar una sección de zoom de resumen**

Un zoom de resumen almacena sus objetos [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) en [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Este ejemplo crea una visión general de dos secciones, añade una tercera sección mediante [SummaryZoomSectionCollection::addSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection), y elimina la entrada de la primera sección usando [SummaryZoomSectionCollection::removeSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Eliminar la entrada deja la sección de la presentación y sus diapositivas intactas.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $firstSection = $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $thirdSection = $presentation->getSections()->addSection("Section 3", $slide);

    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($thirdSection);

    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($firstSection);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Formato de secciones de zoom de resumen**

Este ejemplo da formato a la primera entrada en [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), usando el índice basado en cero `0`. Necesita una imagen local para [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), aplica un borde negro de 1,5 puntos, guión‑punto, y establece [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) a 1,5 segundos. Pasar `false` a [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) desactiva el retorno automático a la diapositiva de resumen para esta entrada.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $summarySection->setZoomImage($previewImage);
    $summarySection->setReturnToParent(false);

    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);

    $summarySection->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo controlar el regreso a la diapositiva 'principal' después de mostrar el objetivo?**

Sí. Llame a [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) con `true` para volver a la diapositiva de origen después de que se muestre el contenido del objetivo.

**¿Puedo ajustar la 'velocidad' o duración de la transición del Zoom?**

Sí. Use [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) para controlar la duración de la transición en segundos.

**¿Existen límites sobre cuántos objetos Zoom puede contener una presentación?**

No hay un límite estricto de API documentado. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede añadir muchos marcos de Zoom, pero tenga en cuenta el tamaño del archivo y el tiempo de renderizado.