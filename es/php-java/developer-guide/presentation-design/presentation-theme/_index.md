---
title: Gestionar temas de presentación en PHP
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/php-java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Tema externo
- THMX
- Color del tema
- Paleta adicional
- Fuente del tema
- Estilo del tema
- Efecto del tema
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Temas maestros de presentación en Aspose.Slides para PHP vía Java para crear, personalizar y convertir archivos PowerPoint con una marca coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos conscientes del tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un master puede anular el tema de la presentación mediante [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), mientras que un diseño o una diapositiva individual pueden anular su tema heredado mediante [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo para una diapositiva se resuelve mediante esta cadena de herencia: tema de presentación, anulación del master, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las siguientes secciones muestran los flujos de trabajo de tema más comunes: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y efectos, y leer valores efectivos después de que la herencia y las anulaciones se hayan resuelto.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) expone el esquema de colores, el esquema de fuentes y el esquema de formato del tema a través de [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) y [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();

    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Si un archivo utiliza varios masters, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el master asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones de diseño o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos conscientes del tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), todos los objetos que aún hacen referencia a ese color del tema se resuelven con el nuevo valor. Los objetos que utilizan un color RGB directo no se modifican con una actualización de color del tema.

El siguiente ejemplo integral crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir e imprime el color de relleno efectivo:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);

    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Porque el rectángulo sigue vinculado a `Accent4`, su color visible se vuelve rojo tras el cambio del tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones a través de la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.

**2** - Variantes más claras y más oscuras generadas a partir de los colores principales del tema.

El siguiente ejemplo crea seis rectángulos basados en `Accent4`, aplica transformaciones de luminancia a cinco de ellos y guarda el resultado:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Estas variantes siguen basándose en el color del tema. Si `Accent4` cambia posteriormente, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear valores de `SchemeColor` a ranuras de `ColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que el [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. El mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se convierten dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para encabezados y un conjunto de fuentes secundario para el cuerpo del texto. Los métodos [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) y [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Fuente Latin menor)
* `+mj-lt` - Fuente del encabezado Latin (Fuente Latin mayor)
* `+mn-ea` - Fuente del cuerpo East Asian (Fuente East Asian menor)
* `+mj-ea` - Fuente del encabezado East Asian (Fuente East Asian mayor)
* `+mn-cs` - Fuente del cuerpo Complex Script (Fuente Complex Script menor)
* `+mj-cs` - Fuente del encabezado Complex Script (Fuente Complex Script mayor)

El siguiente ejemplo crea un encabezado que usa la fuente Latin mayor del tema y una línea de cuerpo que usa la fuente Latin menor del tema. Luego cambia las fuentes del tema y guarda el resultado:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. Un texto que tenga un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

Las colecciones de fuentes mayores y menores también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, sustituir o eliminar estas asignaciones, consulte [Fuentes de tema específicas de script](/slides/es/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para más información sobre fuentes de presentación, consulte [Fuentes de PowerPoint](/slides/es/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Resolver referencias de fuentes del tema**

Al inspeccionar texto, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) puede devolver una referencia de tema como `+mn-lt` en lugar de un nombre de familia tipográfica. Llame a [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) con los datos efectivos del tema apropiados para resolver esa referencia. Los prefijos `+mj` y `+mn` seleccionan los conjuntos de fuentes mayor y menor; los sufijos `-lt`, `-ea` y `-cs` seleccionan sus fuentes Latin, East Asian y Complex Script, respectivamente.

Obtenga el tema efectivo mediante [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) sobre el objeto cuyo tema se aplica al texto inspeccionado. Para texto ordinario en una diapositiva, llame a este método sobre la diapositiva para que el contexto incluya el tema heredado de esa diapositiva y sus anulaciones locales. Al inspeccionar un diseño o un master, utilice su propio tema efectivo. No asuma que el tema del primer master se aplica a todas las diapositivas.

El siguiente ejemplo crea una porción de texto que hace referencia explícita a la fuente Latin menor. Inicializa un esquema de fuentes de diapositiva mediante [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) y establece las familias Latin mayor y menor en `Arial` y `Calibri`, lo que hace que el resultado sea reproducible sin un archivo de entrada.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

La salida es `+mn-lt -> Calibri` seguida de `Verdana -> Verdana`. La referencia almacenada permanece sin cambios, mientras que un nombre de familia explícito se devuelve tal cual. Si la porción usara `+mj-lt`, se resolvería a `Arial` en este tema.

Resolver una referencia de tema identifica la familia tipográfica especificada por el tema. No verifica la disponibilidad de la fuente ni determina el archivo de fuente que finalmente se usa tras la sustitución o la sustitución de glifos durante la renderización. Consulte [Secuencia de selección de fuentes](/slides/es/php-java/font-selection-sequence/) y [Sustitución de fuentes](/slides/es/php-java/font-substitution/) para esos pasos independientes.

## **Copiar o aplicar un tema**

Los flujos de trabajo siguientes resuelven diferentes problemas relacionados con los temas.

### **Aplicar un tema externo a las diapositivas dependientes de un master**

Utilice [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) cuando tenga un archivo de tema de PowerPoint (`.thmx`) y desee rediseñar cada diapositiva que dependa de un master concreto. Seleccione el master de la colección [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), representada por [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea una nueva diapositiva maestra basada en el master seleccionado.
1. Aplica el tema externo a la nueva maestra.
1. Asigna la nueva maestra a todas las diapositivas que previamente dependían del master seleccionado.
1. Devuelve la [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) recién creada.

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer master y guarda la presentación:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;

    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Un tema inválido, corrupto o no compatible puede provocar una [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Valide las rutas proporcionadas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado correctamente.

Solo se reasignan las diapositivas que dependían del master seleccionado. Las diapositivas asociadas a otros masters conservan sus masters y temas existentes. Los colores, fuentes, rellenos, líneas, fondos y efectos conscientes del tema se resuelven con el tema externo. Los colores, fuentes, rellenos y demás formato asignado directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y de diapositiva también pueden tener prioridad sobre los valores heredados del nuevo master.

El tema puede referenciar fuentes que no estén disponibles en el entorno de ejecución. Para una renderización y exportación coherentes, instale las fuentes necesarias, proporciónelas mediante [fuentes personalizadas](/slides/es/php-java/custom-font/), o configure la [sustitución de fuentes](/slides/es/php-java/font-substitution/).

Este es un flujo de trabajo directo a nivel de master: el método acepta una ruta de archivo a un `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o de diseño.

### **Aplicar diferentes temas externos en una presentación con varios masters**

Cuando el master relevante no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) y [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Guarde las referencias originales de los masters antes de aplicar cualquier tema porque cada llamada crea otro master en la presentación.

El siguiente ejemplo usa diapositivas de dos secciones para localizar sus masters y aplica un tema externo diferente a cada grupo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;

            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

La primera llamada afecta solo a las diapositivas que dependían de `$firstGroupMaster`, y la segunda llamada afecta solo a las diapositivas que dependían de `$secondGroupMaster`. Las diapositivas pertenecientes a cualquier otro master no se vuelven a diseñar.

### **Preservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el master de origen en la presentación de destino con [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), luego clone la diapositiva con [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) y el master clonado. Esto lleva consigo el master, sus diseños y el tema asociado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);

        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);

        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);

        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse igual en el destino. Simplemente clonar el contenido sobre un master de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su master y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) y [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) copian los tres componentes principales del tema en la anulación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);

        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Esto cambia el tema utilizado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través del [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Utilice un tema a nivel de master o de presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo diferente, y una anulación de diapositiva solo para excepciones reales. Las anulaciones excesivas a nivel de diapositiva dificultan la predicción de cambios globales de tema posteriores.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint puede presentar más opciones de fondo en su interfaz que el número de definiciones de relleno almacenadas físicamente en esta colección, porque la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el índice actual de estilo mediante [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Un índice de estilo `0` indica que no hay relleno temático; los valores positivos son referencias de estilo de fondo temático. Esto difiere del indexado directo de la colección PHP, donde `get_Item(0)` corresponde al primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el recuento de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer master y guarda la presentación:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);

    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado visible depende de la entrada del tema referenciada por el master y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del master puede no afectar a esa diapositiva. Utilice [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) cuando necesite conocer el fondo final después de aplicar la herencia.

{{% alert color="warning" title="Warning" %}}
No trate el índice de estilo como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y suponer que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formateo directo de fondo y herencia de fondo, consulte [Fondo de presentación](/slides/es/php-java/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de estilos de relleno, línea y efecto expuestas mediante [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), y [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Los temas típicos de Office a menudo contienen tres entradas principales que corresponden visualmente a formato sutil, moderado e intenso, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutiles, moderados e intensos aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en PHP, el índice de la colección comienza en cero: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto mediante [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Modificar un estilo del tema afecta a las formas que hacen referencia a ese estilo; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existan las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra externa en el tercer estilo de efecto y guarda el resultado:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);

    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para las formas que referencian estas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido, y el tercer estilo de efecto adquiere una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y si el formato directo sobrescribe al tema.

![Estilos de efecto de tema después de cambiar la línea, el relleno y la sombra](presentation-design_11.png)

## **Seleccionar estilos de relleno y línea de tema para una forma**

Una forma puede seleccionar su relleno y contorno de forma independiente mediante [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) y [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Para cualquiera de los métodos, el índice `1` selecciona la primera entrada de la colección temática correspondiente (`get_Item(0)`), y el índice `2` selecciona la segunda (`get_Item(1)`).

El siguiente ejemplo configura dos estilos de relleno (oro y azul cielo) y dos estilos de línea (azul oscuro a 6 pt y rojo oscuro a 12 pt) en el tema predeterminado de una nueva presentación. Guarda la diapositiva en tres etapas para que pueda comparar los resultados en PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Estilos iniciales | Cambiar el contorno derecho | Editar el primer relleno del tema |
|:---:|:---:|:---:|
| ![Rectángulos dorados y azul cielo con contornos delgados azul oscuro a juego](theme-style-initial.png) | ![El rectángulo azul cielo ahora tiene un contorno grueso rojo oscuro](theme-style-line-changed.png) | ![El rectángulo izquierdo ahora es verde y ambos contornos están sin cambios](theme-style-fill-changed.png) |

Seleccionar un estilo de línea diferente solo cambia el contorno del rectángulo derecho. Editar el primer relleno del tema actualiza cada forma que lo usa. En este caso, solo el rectángulo izquierdo se vuelve verde.

En una forma existente, un color de relleno local, un color de línea o un ancho de línea pueden anular esa parte del estilo del tema. Si cambiar un índice de estilo no produce efecto visible, compruebe el [formato directo](/slides/es/php-java/shape-formatting/) de la forma.

## **Determinar si un relleno sólido efectivo usa un color de tema**

Un relleno puede almacenarse directamente en un objeto o heredarse de un párrafo, diseño, master, estilo de tema u otro nivel de formato. Llame a [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para resolver esa jerarquía en datos de relleno efectivo inmutables. Primero verifique el resultado de `getFillType`. Solo cuando sea `FillType::Solid` debería leer las propiedades del relleno sólido.

Para un relleno sólido, `getSolidFillColor` devuelve el valor RGB final renderizado después de aplicar la herencia, la búsqueda en el tema y las transformaciones de color. El método `getSolidFillSchemeColor` devuelve la ranura lógica de [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) correspondiente, como `Text1` o `Accent6`. Un valor de `SchemeColor::NotDefined` indica que el relleno sólido efectivo no se basa en un color de esquema. En un flujo de trabajo donde los rellenos son colores de tema o colores RGB directos, este valor identifica un relleno RGB directo.

No utilice solo el valor local de [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) para clasificar un relleno. Por ejemplo, una porción de texto puede no tener un color de esquema definido localmente, por lo que su valor local es `NotDefined`, mientras que su relleno efectivo hereda un color de tema y se resuelve a `Text1` o `Accent6`. Por el contrario, `getSolidFillSchemeColor` indica qué ranura lógica del tema produjo el color efectivo, pero no indica si esa ranura proviene del objeto, párrafo, diseño, master u otro nivel de la jerarquía de formato.

El siguiente ejemplo carga una presentación, audita los rellenos de forma y los rellenos de porción de texto, imprime cada valor RGB final y el color de esquema asociado, y marca los rellenos sólidos que no seguirán los cambios de color del tema:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

La rama `NotDefined` proporciona una lista de auditoría de rellenos sólidos que no responderán a los cambios en las ranuras de color del tema. Revise esos objetos cuando una presentación deba seguir una nueva paleta de marca. El valor RGB informado muestra aún la apariencia actual, mientras que el valor del esquema explica si esa apariencia está conectada al tema.

Los objetos de formato efectivo son instantáneas. Después de cambiar el tema de la presentación, una anulación de tema o cualquier formato heredado, llame a `getEffective` nuevamente y lea los nuevos datos de relleno efectivos antes de comparar o informar colores.

## **Leer valores de tema efectivos**

Los objetos de tema sin procesar indican qué está definido en un nivel determinado. Los valores efectivos indican qué usa realmente una diapositiva o forma después de que se resuelven la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Para un fondo, use [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), y para un relleno, use [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

El siguiente ejemplo lee el tema efectivo, el fondo y el primer relleno de forma de una diapositiva:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();

    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;

    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), puede pasar por alto una anulación de master, diseño, diapositiva o forma que cambie la apariencia final.

## **Preguntas frecuentes**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) reasigna solo las diapositivas que dependen del master seleccionado. Las diapositivas que usan otros masters conservan sus temas existentes.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el master?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y preservar su apariencia original, clone el master de origen en el destino y clone la diapositiva con ese master mediante [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) y [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Esto mantiene juntos el master, los diseños y el tema.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) para una diapositiva o tema de diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) y [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Estas API devuelven los valores resueltos tras aplicar la herencia y las anulaciones.