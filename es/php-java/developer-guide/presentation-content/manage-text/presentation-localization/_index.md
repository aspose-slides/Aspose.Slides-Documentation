---
title: Automatizar la localización de presentaciones en PHP
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/php-java/presentation-localization/
keywords:
- cambiar idioma
- corrección ortográfica
- suprimir corrección ortográfica
- idioma de revisión
- identificador de idioma
- texto multilingüe
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Establecer idiomas de revisión para el texto de presentaciones PowerPoint y OpenDocument en PHP con Aspose.Slides, incluidos los valores predeterminados y párrafos multilingües."
---
## **Visión general**

Aspose.Slides for PHP via Java le permite configurar metadatos de revisión para porciones de texto individuales. Utilice [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId) para identificar el idioma de revisión, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setSpellCheck) para permitir o suprimir la corrección ortográfica, y [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setProofDisabled) para controlar el estado más amplio de “no revisar”. Como estas configuraciones se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de revisión.

Este artículo explica cómo asignar un idioma a texto específico, establecer el idioma predeterminado para texto nuevo con [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), crear párrafos multilingües, elegir entre `SpellCheck` y `ProofDisabled`, y conservar la configuración prevista al usar [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Estas propiedades almacenan metadatos para aplicaciones de presentación; no traducen texto, realizan comprobaciones ortográficas basadas en diccionario ni devuelven palabras mal escritas.

## **Establecer el idioma de revisión para el texto**

Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/), acceda a la porción de texto requerida mediante [Portion::getPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getPortionFormat) y asigne su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de revisión y guarda el resultado con [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el idioma predeterminado para texto nuevo**

Utilice [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para especificar el idioma de revisión que Aspose.Slides asigna al texto creado recientemente. Esta configuración es útil cuando la mayor parte o todo el texto nuevo de una presentación utiliza el mismo idioma. No modifica los metadatos de idioma del texto que ya tiene un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo utiliza las reglas de revisión del alemán:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utilizar varios idiomas en un párrafo**

Un [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/) distinta para cada idioma y establezca su `LanguageId` de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Habilitar o suprimir la corrección ortográfica para porciones individuales**

[PortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/) hereda las propiedades de texto comunes definidas por [BasePortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/). Acceda al formato de una porción mediante [Portion::getPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getPortionFormat) y utilice [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setSpellCheck) para controlar si una aplicación de presentación puede comprobar la ortografía de esa porción. El valor predeterminado es `false`: `true` permite la corrección ortográfica, mientras que `false` la suprime.

La configuración se aplica a porciones de texto individuales. Por lo tanto, distintas porciones dentro del mismo párrafo pueden usar valores diferentes. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId) y `setSpellCheck` cumplen propósitos complementarios: `setLanguageId` identifica el idioma de revisión, mientras que `setSpellCheck` determina si se permiten comprobaciones ortográficas para la porción.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setProofDisabled) también controla la revisión, pero representa el estado más amplio de “no revisar” como un [NullableBool](https://reference.aspose.com/slides/es/php-java/aspose.slides/nullablebool/). Utilice `setSpellCheck` cuando necesite un interruptor booleano directo específicamente para la corrección ortográfica. Utilice `setProofDisabled` cuando necesite conservar o controlar explícitamente los metadatos de “no revisar” de la presentación, incluido su estado `NotDefined`. Si establece ambas propiedades, mantenga sus valores consistentes; no combine `setSpellCheck(true)` con `setProofDisabled(NullableBool::True)`.

Estas propiedades configuran los metadatos de revisión utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los usa para ejecutar correcciones ortográficas basadas en diccionario ni para devolver una lista de palabras mal escritas.

El siguiente ejemplo completo crea una presentación de entrada, la carga, asigna diferentes configuraciones de corrección ortográfica e idiomas de revisión a dos porciones del mismo párrafo, guarda el resultado, lo vuelve a abrir y verifica los valores almacenados:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combina porciones adyacentes que tienen el mismo formato. Una diferencia únicamente en `SpellCheck` no mantiene esas porciones separadas; después de unirlas, la porción resultante conserva el valor `SpellCheck` de la primera porción. Si las porciones necesitan configuraciones de corrección ortográfica diferentes, llame a `joinPortionsWithSameFormatting` antes de asignar esas configuraciones, o inspeccione los límites de la porción resultante y vuelva a aplicar las configuraciones después. Las porciones con valores diferentes de `LanguageId` permanecen separadas porque su formato de idioma de revisión difiere.

## **Preguntas frecuentes**

**¿Un identificador de idioma traduce el texto?**

No. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId) almacena metadatos de revisión para ortografía y gramática; no altera el contenido del texto. Traduzca el texto por separado y luego establezca el identificador de idioma apropiado para cada porción traducida.

**¿El idioma de revisión controla fuentes, guiones o ajuste de línea?**

No. El identificador de idioma es solo para la revisión. El renderizado y la disposición del texto dependen principalmente de las [fuentes](/slides/es/php-java/powerpoint-fonts/) disponibles, del sistema de escritura y de la configuración del marco de texto. Para un renderizado fiable, proporcione las fuentes necesarias, configure la [sustitución de fuentes](/slides/es/php-java/font-substitution/) o [incorpore fuentes](/slides/es/php-java/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de revisión?**

Sí. Asigne cada idioma a una porción distinta, como se muestra en el ejemplo del párrafo multilingüe.

**¿Debo usar `setDefaultTextLanguage` o `setLanguageId`?**

Use [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) cuando desee un valor predeterminado para el texto creado recientemente. Use [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId) cuando una porción específica necesite un idioma de revisión explícito o cuando un párrafo contenga varios idiomas.