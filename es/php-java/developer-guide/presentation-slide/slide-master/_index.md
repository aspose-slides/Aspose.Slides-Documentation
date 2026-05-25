---
title: Gestionar masters de diapositivas de presentación en PHP
linktitle: Master de diapositiva
type: docs
weight: 70
url: /es/php-java/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra sin usar
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestiona los masters de diapositivas en Aspose.Slides para PHP a través de Java: accede, edita, clona, compara y elimina diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Una **slide master** define los ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y ajustes de pie de página. En PowerPoint, editar una slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for PHP via Java soporta el mismo modelo. Una presentación puede contener una o más master slides, y cada master slide puede contener varias layout slides. Normalmente, las diapositivas normales no hacen referencia directa a una master slide. En su lugar, una diapositiva normal utiliza una layout slide, y esa layout slide pertenece a una master slide.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de layout.
1. **Normal slide** - contiene el contenido real de la presentación y utiliza una layout slide.

![La jerarquía de master slides, layout slides y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, una slide master está representada por la clase [MasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/). Todas las master slides de una presentación están disponibles a través del método [Presentation.getMasters](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getMasters), que devuelve un objeto [MasterSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, el nivel más específico prevalece. Por ejemplo, si una master slide y una layout slide ambas definen un fondo, las diapositivas basadas en esa layout usan el fondo de la layout. Para obtener más información sobre layout slides, consulte [Apply or Change Slide Layouts](/slides/es/php-java/slide-layout/).
{{% /alert %}}

## **Acceder a las slide masters**

En PowerPoint, puede abrir la vista Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use el método `getMasters` para acceder a las master slides:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

También puede obtener la master slide utilizada por una diapositiva normal a través de su layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Qué contiene una slide master**

Una master slide es un objeto similar a una diapositiva. Extiende [BaseSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y layout slides. Los miembros específicos de la master slide se enumeran en la página de API de [MasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/).

Los miembros de master slide más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground` | Establece el fondo de la diapositiva a nivel de master. |
| `getShapes` | Almacena las formas colocadas en el master, como logotipos, marcos de imágenes y texto compartido. |
| `getLayoutSlides` | Almacena las layout slides que pertenecen al master. |
| `getThemeManager` | Proporciona acceso a las API del tema del master. |
| `getHeaderFooterManager` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus layouts hijos. |
| `getDependingSlides` | Devuelve las diapositivas normales que dependen del master a través de sus layouts. |

## **Añadir una imagen a una slide master**

Cuando agrega una imagen a una master slide, aparece en las diapositivas que usan layouts de ese master. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo a la primera master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para más información sobre marcos de imágenes, consulte [Picture Frame](/slides/es/php-java/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en layout slides. La master slide proporciona el estilo y tema compartidos que esos layouts heredan, mientras que cada layout decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insert Placeholder en la vista Slide Master de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la layout slide que pertenece al master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

También puede formatear las formas de marcador de posición que ya existen en una master slide. El siguiente ejemplo busca el marcador de posición de título y le aplica un relleno de degradado lineal:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para más opciones de formato de marcadores de posición y texto, consulte [Set Prompt Text in Placeholder](/slides/es/php-java/manage-placeholder/) y [Text Formatting](/slides/es/php-java/text-formatting/).

## **Cambiar el fondo de una slide master**

Un fondo de master se hereda por layouts y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para temas relacionados, vea [Presentation Background](/slides/es/php-java/presentation-background/) y [Presentation Theme](/slides/es/php-java/presentation-theme/).

## **Clonar una slide master a otra presentación**

Use `addClone` de [MasterSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/) para copiar una master slide a otra presentación. El master copiado puede entonces ser usado por layouts y diapositivas en la presentación de destino.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Si necesita clonar diapositivas normales junto con su master, consulte [Clone Slides](/slides/es/php-java/clone-slides/).

## **Agregar varias slide masters**

Una presentación puede contener varias master slides. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar master slides](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, le asigna un fondo diferente, crea una layout bajo ese master clonado y añade una nueva diapositiva basada en esa layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comparar slide masters**

Las master slides pueden compararse con el método `equals` heredado de [BaseSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como IDs de diapositivas, ni valores dinámicos de marcadores de posición, como la fecha actual.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Para más información, vea [Compare Presentation Slides](/slides/es/php-java/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Use el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para más configuraciones de vista, vea [Save Presentation](/slides/es/php-java/save-presentation/).

## **Eliminar slide masters sin usar**

A veces las presentaciones contienen master slides que ya no son usadas por ninguna diapositiva normal. Eliminar los masters no usados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use `removeUnused` de [MasterSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/) para eliminar los masters no usados de la colección `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

También puede usar el método de bajo código `removeUnusedMasterSlides` de la clase [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**¿Cuál es la diferencia entre una slide master y una layout slide?**

Una slide master define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una layout slide pertenece a una slide master y define una disposición específica de marcadores de posición. Una diapositiva normal usa una layout slide, por lo que hereda tanto de la layout como del master.

**¿Puede una presentación contener varias slide masters?**

Sí. Una presentación puede contener varias slide masters. Use múltiples masters cuando diferentes secciones necesiten diferentes sistemas visuales o marcas.

**¿Debo añadir marcadores de posición a una slide master o a una layout slide?**

En la mayoría de los casos, añada marcadores de posición a las layout slides. Coloque los elementos visuales compartidos y el formato compartido en la slide master, y los marcadores de posición de contenido en las layouts que usarán las diapositivas normales.

**¿Puedo eliminar una slide master que todavía se está usando?**

No. Una slide master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a layouts bajo otro master, o utilice un método de limpieza de masters no usados que elimine solo los masters que no están en uso.