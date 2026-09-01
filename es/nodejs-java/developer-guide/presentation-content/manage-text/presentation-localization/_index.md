---
title: Automatizar la localización de presentaciones en JavaScript
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/nodejs-java/presentation-localization/
keywords:
- cambiar idioma
- corrección ortográfica
- suprimir corrección ortográfica
- idioma de corrección
- identificador de idioma
- texto multilingüe
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Establezca los idiomas de corrección para el texto de presentaciones PowerPoint y OpenDocument en JavaScript con Aspose.Slides, incluyendo valores predeterminados y párrafos multilingües."
---
## **Visión general**

Aspose.Slides for Node.js via Java le permite configurar los metadatos de corrección para porciones de texto individuales. Utilice [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) para identificar el idioma de corrección, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) para permitir o suprimir la comprobación ortográfica, y [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) para controlar el estado más amplio de no corrección. Dado que estos ajustes se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de corrección.

Este artículo explica cómo asignar un idioma a un texto específico, establecer el idioma predeterminado para texto nuevo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), crear párrafos multilingües, elegir entre `SpellCheck` y `ProofDisabled`, y conservar los ajustes previstos al utilizar [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Estas propiedades almacenan metadatos para aplicaciones de presentación; no traducen texto, no realizan comprobación ortográfica basada en diccionarios ni devuelven palabras mal escritas.

## **Establecer el idioma de corrección para el texto**

Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/), acceda a la porción de texto requerida mediante [Portion.getPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#getPortionFormat-- ) y asigne su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de corrección y guarda el resultado con [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el idioma predeterminado para texto nuevo**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para especificar el idioma de corrección que Aspose.Slides asigna al texto creado recientemente. Esta configuración es útil cuando la mayor parte o todo el texto nuevo en una presentación utiliza el mismo idioma. No cambia los metadatos de idioma del texto que ya tiene un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo utiliza reglas de corrección alemanas:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utilizar varios idiomas en un mismo párrafo**

Un [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) separada para cada idioma y establezca su `LanguageId` de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Habilitar o suprimir la comprobación ortográfica para porciones individuales**

[PortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/) hereda las propiedades de texto comunes definidas por [BasePortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/). Acceda al formato de una porción mediante [Portion.getPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#getPortionFormat--) y utilice [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) para controlar si una aplicación de presentación puede comprobar la ortografía de esa porción. El valor predeterminado es `false`: `true` permite la comprobación ortográfica, mientras que `false` la suprime.

La configuración se aplica a porciones de texto individuales. Por lo tanto, diferentes porciones en el mismo párrafo pueden usar valores distintos. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) y `setSpellCheck` cumplen propósitos complementarios: `setLanguageId` identifica el idioma de corrección, mientras que `setSpellCheck` determina si se permiten las comprobaciones ortográficas para la porción.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) también controla la corrección, pero representa el estado más amplio de "no corregir" como un [NullableBool](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/nullablebool/). Utilice `setSpellCheck` cuando necesite un interruptor booleano directo específicamente para las comprobaciones ortográficas. Utilice `setProofDisabled` cuando necesite preservar o controlar explícitamente los metadatos de no corrección de la presentación, incluido su estado `NotDefined`. Si establece ambas propiedades, mantenga sus valores coherentes; no combine `setSpellCheck(true)` con `setProofDisabled(NullableBool.True)`.

Estas propiedades configuran los metadatos de corrección utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los utiliza para ejecutar una comprobación ortográfica basada en diccionarios ni para devolver una lista de palabras mal escritas.

El siguiente ejemplo completo crea una presentación de entrada, la carga, asigna diferentes configuraciones de comprobación ortográfica e idiomas de corrección a dos porciones en el mismo párrafo, guarda el resultado, lo vuelve a abrir y verifica los valores almacenados:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina porciones adyacentes que tienen el mismo formato. Una diferencia solo en `SpellCheck` no mantiene esas porciones separadas; después de combinarlas, la porción resultante conserva el valor `SpellCheck` de la primera porción. Si las porciones necesitan diferentes configuraciones de comprobación ortográfica, llame a `joinPortionsWithSameFormatting` antes de asignar esas configuraciones, o inspeccione los límites de la porción resultante y vuelva a aplicar los ajustes posteriormente. Las porciones con valores de `LanguageId` diferentes permanecen separadas porque su formato de idioma de corrección difiere.

## **FAQ**

**¿Un ID de idioma traduce el texto?**

No. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) almacena metadatos de corrección para ortografía y gramática; no altera el contenido del texto. Traduzca el texto por separado y luego establezca el identificador de idioma adecuado para cada porción traducida.

**¿El idioma de corrección controla fuentes, guiones o ajuste de línea?**

No. El identificador de idioma es para corrección. La representación y el diseño del texto dependen principalmente de las [fuentes](/slides/es/nodejs-java/powerpoint-fonts/) disponibles, del sistema de escritura y de la configuración del marco de texto. Para una representación fiable, proporcione las fuentes requeridas, configure la [sustitución de fuentes](/slides/es/nodejs-java/font-substitution/) o [incorpore fuentes](/slides/es/nodejs-java/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de corrección?**

Sí. Asigne cada idioma a una porción separada, como se muestra en el ejemplo de párrafo multilingüe.

**¿Debería usar `setDefaultTextLanguage` o `setLanguageId`?**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) cuando desee un valor predeterminado para el texto recién creado. Utilice [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) cuando una porción específica necesita un idioma de corrección explícito o cuando un párrafo contiene varios idiomas.