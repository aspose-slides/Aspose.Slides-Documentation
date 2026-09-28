---
title: Gestionar maestros de diapositivas de presentación en PHP
linktitle: Maestro de diapositiva
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
description: "Gestionar los maestros de diapositivas en Aspose.Slides para PHP a través de Java: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Un maestro de diapositiva define ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y de pie de página. En PowerPoint, editar un maestro de diapositiva es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para PHP a través de Java admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no hacen referencia directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Maestro de diapositiva** – define el diseño y tema compartidos.  
1. **Diapositiva de diseño** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** – contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![Jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un maestro de diapositiva está representado por la clase [MasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) . Todas las diapositivas maestras de una presentación están disponibles a través del método [Presentation.getMasters](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getMasters) , que devuelve un objeto [MasterSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño definen ambas un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/php-java/slide-layout/).
{{% /alert %}}

## **Acceder a los maestros de diapositiva**

En PowerPoint, puedes abrir la vista Maestro de diapositiva desde **Vista** > **Maestro de diapositiva**.

![El comando Maestro de diapositiva en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, usa el método `getMasters` para acceder a las diapositivas maestras:

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

También puedes obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

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

## **Qué contiene un maestro de diapositiva**

Un maestro de diapositiva es un objeto parecido a una diapositiva. Extiende [BaseSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/), por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y de diseño. Los miembros específicos del maestro se enumeran en la página de API de [MasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) .

Los miembros de maestro de diapositiva más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `getBackground` | Establece el fondo de la diapositiva a nivel de maestro. |
| `getShapes` | Almacena las formas colocadas en el maestro, como logotipos, marcos de imagen y texto compartido. |
| `getLayoutSlides` | Almacena las diapositivas de diseño que pertenecen al maestro. |
| `getThemeManager` | Proporciona acceso a las API del tema del maestro. |
| `getHeaderFooterManager` | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños hijos. |
| `getDependingSlides` | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Añadir una imagen a un maestro de diapositiva**

Cuando añades una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva maestra:

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

Para obtener más información sobre marcos de imagen, consulte [Marco de imagen](/slides/es/php-java/picture-frame/).

## **Controlar la visibilidad de los gráficos del maestro**

Utiliza [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#setShowMasterShapes) para ocultar los gráficos heredados del maestro, como logotipos o formas decorativas, sin eliminarlos del maestro. Pasa `false` a [Slide::setShowMasterShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#setShowMasterShapes) en la diapositiva que debe omitir esos gráficos y mantenlo `true` en las diapositivas que deben mostrarlos.

El siguiente ejemplo independiente crea una banda decorativa azul en un maestro y dos diapositivas que usan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se necesita una presentación o imagen de entrada.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El ejemplo utiliza el diseño **Blank** proporcionado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance de la configuración**

Una diapositiva normal usa su maestro a través de [Slide::getLayoutSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getLayoutSlide) y [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getMasterSlide). Establecer la propiedad en una diapositiva individual afecta solo a esa diapositiva. Pasar `false` a [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#setShowMasterShapes) oculta los gráficos del maestro para las diapositivas que usan ese diseño compartido, aunque su propia configuración sea `true`. Para ocultar gráficos en una sola diapositiva, cambia la propiedad de la diapositiva y deja el diseño compartido sin modificar.

La configuración no se admite como control de visibilidad en la propia diapositiva maestra. En un maestro, [getShowMasterShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/#getShowMasterShapes) siempre devuelve `false`, y pasar `true` a [setShowMasterShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/#setShowMasterShapes) genera una excepción. Aplícala a una diapositiva normal o a un diseño en su lugar.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar los gráficos del maestro | Controla la visibilidad de las formas heredadas del maestro sin eliminarlas ni cambiar las formas propias de la diapositiva. |
| Cambiar el relleno de fondo de la diapositiva | Cambia el color, degradado o imagen de fondo. Los gráficos del maestro son formas separadas y pueden permanecer visibles sobre ese fondo. Ver [Fondo de la presentación](/slides/es/php-java/presentation-background/). |
| Eliminar una forma del maestro | Elimina la forma de origen compartida, por lo que ya no está disponible para ninguna diapositiva que use ese maestro. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Maestro de diapositiva.

![El comando Insertar marcador de posición en la vista Maestro de diapositiva de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaja con la diapositiva de diseño que pertenece al maestro:

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

También puedes formatear formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición de título y aplica un relleno de degradado lineal:

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

Para obtener más opciones de marcadores de posición y formato de texto, consulte [Establecer texto de indicación en marcador de posición](/slides/es/php-java/manage-placeholder/) y [Formato de texto](/slides/es/php-java/text-formatting/).

## **Cambiar el fondo de un maestro de diapositiva**

Un fondo de maestro se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

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

Para temas relacionados, vea [Fondo de la presentación](/slides/es/php-java/presentation-background/) y [Tema de la presentación](/slides/es/php-java/presentation-theme/).

## **Clonar un maestro de diapositiva a otra presentación**

Use `addClone` de [MasterSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/) para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

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

Si necesita clonar diapositivas normales junto con su maestro, consulte [Clonar diapositivas](/slides/es/php-java/clone-slides/).

## **Añadir varios maestros de diapositiva**

Una presentación puede contener varios maestros de diapositiva. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar maestros de diapositiva](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, le da al clon un fondo diferente, crea un diseño bajo ese maestro clonado y añade una nueva diapositiva basada en ese diseño:

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

## **Comparar maestros de diapositiva**

Los maestros de diapositiva pueden compararse con el método `equals` heredado de [BaseSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de la diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

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

Para obtener más información, consulte [Comparar diapositivas de presentación](/slides/es/php-java/compare-slides/).

## **Establecer la vista Maestro de diapositiva como vista predeterminada**

Use el método `setLastView` en [ViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Maestro de diapositiva:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para más configuraciones de vista, vea [Guardar presentación](/slides/es/php-java/save-presentation/).

## **Eliminar maestros de diapositiva no usados**

Las presentaciones a veces contienen maestros de diapositiva que ya no son usados por ninguna diapositiva normal. Eliminar maestros no usados puede reducir el tamaño del archivo y simplificar el mantenimiento de plantillas.

Use `removeUnused` de [MasterSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/) para eliminar los maestros no usados de la colección `getMasters` :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

También puede usar el método de bajo código `removeUnusedMasterSlides` de la clase [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) :

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un maestro de diapositiva y una diapositiva de diseño?**

Un maestro de diapositiva define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un maestro de diapositiva y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios maestros de diapositiva?**

Sí. Una presentación puede contener varios maestros de diapositiva. Use varios maestros cuando diferentes secciones necesiten sistemas visuales o marcas distintas.

**¿Debo añadir marcadores de posición a una diapositiva maestra o a una diapositiva de diseño?**

En la mayoría de los casos, añada marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato compartido en la diapositiva maestra y, a continuación, coloque los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva maestra que todavía se está usando?**

No. Una diapositiva maestra que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro maestro, o use un método de limpieza de maestros no usados que elimine solo los maestros que no están en uso.