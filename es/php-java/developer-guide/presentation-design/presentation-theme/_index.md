---
title: Gestionar temas de presentación en PHP
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/php-java/presentation-theme/
keywords:
- Tema de PowerPoint
- tema de presentación
- tema de diapositiva
- establecer tema
- cambiar tema
- gestionar tema
- color del tema
- paleta adicional
- fuente del tema
- estilo del tema
- efecto del tema
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para PHP vía Java para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos conscientes del tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, por lo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un maestro puede anular el tema de la presentación mediante [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterthememanager/), mientras que un diseño o una diapositiva individual pueden anular su tema heredado mediante [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de la presentación, anulación del maestro, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y de efecto, y leer valores efectivos después de que se haya resuelto la herencia y las anulaciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/mastertheme/) expone el esquema de colores, el esquema de fuentes y el esquema de formato del tema mediante [MasterTheme.getColorScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/mastertheme/) y [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

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

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones de diseño o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos conscientes del tema pueden referirse a un color lógico del enumerado [SchemeColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [ColorScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/colorscheme/), todos los objetos que siguen referenciando ese color del tema se resuelven contra el nuevo valor. Los objetos que usan un color RGB directo no se cambian con una actualización de color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

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

Dado que el rectángulo sigue vinculado a `Accent4`, su color visible se vuelve rojo después de cambiar el tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones a través del enumerado [ColorTransformOperation](https://reference.aspose.com/slides/es/php-java/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y más oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.  
**2** - Variantes más claras y más oscuras producidas a partir de los colores principales del tema.

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

Estas variantes siguen basadas en el color del tema. Si `Accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear valores de `SchemeColor` a ranuras de `ColorScheme`**

El enumerado [SchemeColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que el [ColorScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/colorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. El mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para los encabezados y un conjunto secundario para el cuerpo del texto. Los métodos [FontScheme.getMajor](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontscheme/) y [FontScheme.getMinor](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontscheme/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (fuente latina menor)
* `+mj-lt` - Fuente del encabezado Latin (fuente latina mayor)
* `+mn-ea` - Fuente del cuerpo East Asian (fuente asiática oriental menor)
* `+mj-ea` - Fuente del encabezado East Asian (fuente asiática oriental mayor)

El siguiente ejemplo crea un encabezado que usa la fuente latina mayor del tema y una línea de cuerpo que usa la fuente latina menor del tema. Luego cambia las fuentes del tema y guarda el resultado:

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

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

{{% alert color="info" title="Tip" %}}
Para obtener más información sobre fuentes en presentaciones, consulte [PowerPoint Fonts](/slides/es/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Copiar o aplicar un tema**

Existen dos flujos de trabajo comunes, y resuelven problemas diferentes.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro de origen en la presentación de destino con [MasterSlideCollection.addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/), y luego clone la diapositiva con [SlideCollection.addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/) y el maestro clonado. Esto lleva el maestro, sus diseños y el tema asociado juntos.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse igual en el destino. Clonar simplemente el contenido sobre un maestro de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar valores del tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su maestro y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/overridetheme/) y [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/overridetheme/) copian los tres componentes principales del tema en la anulación.

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

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/overridetheme/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través de [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslidethememanager/):

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

Utilice un tema a nivel de maestro o presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo diferente, y una anulación de diapositiva solo para excepciones reales. Un exceso de anulaciones a nivel de diapositiva dificulta predecir los cambios globales posteriores del tema.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/es/php-java/aspose.slides/formatscheme/). PowerPoint puede presentar más opciones de fondo en su interfaz de usuario que el número de definiciones de relleno físicamente almacenadas en esta colección, porque la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.getStyleIndex](https://reference.aspose.com/slides/es/php-java/aspose.slides/background/) actual. Un índice de estilo `0` significa que no hay relleno con tema; los valores positivos son referencias a estilos de fondo del tema. Esto difiere de indexar directamente la colección PHP, donde `get_Item(0)` representa el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa del número de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer maestro y guarda la presentación:

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

El resultado visible depende de la entrada del tema a la que hace referencia el maestro y de cualquier anulación de fondo en el diseño o la diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Use [Background.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/background/) cuando necesite conocer el fondo final después de aplicar la herencia.

{{% alert color="warning" title="Warning" %}}
No trate el índice de estilo como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y asumir que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formateo directo de fondos e herencia de fondos, consulte [Presentation Background](/slides/es/php-java/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones independientes de estilos de relleno, línea y efecto expuestas mediante [FormatScheme.getFillStyles](https://reference.aspose.com/slides/es/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/es/php-java/aspose.slides/formatscheme/) y [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/es/php-java/aspose.slides/formatscheme/). Los temas típicos de Office suelen contener tres entradas de estilo principales que corresponden visualmente a formatos sutil, moderado e intenso, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutiles, moderados e intensos aplicados a la misma forma](presentation-design_10.png)

Cuando accede a estas colecciones en PHP, el índice de la colección empieza en cero: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [ShapeStyle](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapestyle/). Modificar un estilo del tema afecta a las formas que referencian ese estilo; las formas con formato directo pueden permanecer sin cambios.

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

Para las formas que referencian estas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido y el tercer estilo de efecto adquiere una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y si el formato directo anula el tema.

![Estilos de efecto del tema después de cambiar los ajustes de línea, relleno y sombra](presentation-design_11.png)

## **Leer valores efectivos del tema**

Los objetos de tema en bruto le indican lo que está definido en un nivel concreto. Los valores efectivos le indican lo que una diapositiva o forma utiliza realmente después de que se haya resuelto la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseoverridethememanager/). Para un fondo, use [Background.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/background/), y para un relleno, use [FillFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/fillformat/).

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

Utilice datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/), puede pasar por alto una anulación de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **FAQ**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de transportar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia original, clone el maestro de origen en el destino y clone la diapositiva con ese maestro usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslidecollection/) y [SlideCollection.addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/). Así se mantiene el maestro, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseoverridethememanager/) para un tema de diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato como [Background.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/background/) y [FillFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/fillformat/). Estas API devuelven los valores resueltos después de aplicar la herencia y las anulaciones.