---
title: Gestionar guías de dibujo en presentaciones en PHP
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/php-java/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- maestro de notas
- maestro de folletos
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Añadir, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint usando Aspose.Slides para PHP via Java."
---
## **Resumen**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma coherente mientras editan una presentación en PowerPoint. Resultan especialmente útiles cuando una aplicación genera una presentación que luego será refinada manualmente: la aplicación puede guardar las mismas ayudas de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación de diapositivas ni en la salida renderizada. Aspose.Slides for PHP via Java las expone a través de la clase [DrawingGuidesCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguidescollection/). Una guía está representada por [DrawingGuide](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o la diapositiva maestra correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Añadir guías a la vista de diapositiva**

Utilice [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/es/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) para gestionar las guías mostradas al editar diapositivas normales. Llame a [DrawingGuidesCollection::add](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguidescollection/#add) con un valor de [Orientation](https://reference.aspose.com/slides/es/php-java/aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo añade una guía vertical a la derecha del centro de la diapositiva y una guía horizontal por debajo de ella:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acceder a las guías de dibujo**

Los métodos [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguidescollection/#getCount) y [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguidescollection/#get_Item) proporcionan acceso a las guías existentes. Los métodos [DrawingGuide::getOrientation](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguide/#getPosition) y [DrawingGuide::getColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguide/#getColor) devuelven valores que también pueden modificarse mediante los métodos setter correspondientes.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada arriba:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Añadir guías a diapositivas maestras y de diseño**

Una diapositiva maestra y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/#getDrawingGuides) para una diapositiva maestra y [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getDrawingGuides) para una diapositiva de diseño.

El siguiente ejemplo añade una guía vertical a la primera diapositiva maestra y una guía horizontal a la primera diapositiva de diseño:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Añadir guías a maestros de notas y de folletos**

Los maestros de notas y los maestros de folletos también admiten guías de dibujo. Utilice [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslide/#getDrawingGuides) y [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) para acceder a sus colecciones. Si una presentación no contiene uno de estos maestros, obtenga el administrador apropiado con [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) o [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), y luego cree el maestro predeterminado con `setDefaultMasterNotesSlide` o `setDefaultMasterHandoutSlide`.

El siguiente ejemplo añade una guía horizontal a un maestro de notas y una guía vertical a un maestro de folletos:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eliminar guías de dibujo**

Llame a [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguidescollection/#clear) para eliminar todas las guías de una colección determinada. Limpiar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo elimina las guías de la vista de diapositiva y todas las guías de las diapositivas maestras, diapositivas de diseño, el maestro de notas y el maestro de folletos sin crear maestros faltantes:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Aparecen las guías de dibujo en una presentación de diapositivas o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de la vista de diapositiva de la presentación. Existen colecciones de guías separadas para los maestros de diapositivas, las diapositivas de diseño, los maestros de notas y los maestros de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo, y las posiciones horizontales se miden desde el borde superior.

**¿Eliminar las guías de dibujo elimina formas o modifica el contenido de la diapositiva?**

No. El método [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/drawingguidescollection/#clear) elimina únicamente las guías de la colección seleccionada. Las formas y demás contenido de la diapositiva permanecen sin cambios.