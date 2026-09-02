---
title: Automatizar la localización de presentaciones en .NET
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/net/presentation-localization/
keywords:
- cambiar idioma
- corrección ortográfica
- suprimir corrección ortográfica
- idioma de corrección
- identificador de idioma
- texto multilingüe
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Establezca los idiomas de corrección para el texto de presentaciones PowerPoint y OpenDocument en .NET con Aspose.Slides, incluidos los valores predeterminados y los párrafos multilingües."
---
## **Visión general**

Aspose.Slides para .NET le permite configurar los metadatos de corrección para porciones de texto individuales. Utilice [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/languageid/) para identificar el idioma de corrección, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/spellcheck/) para permitir o suprimir la comprobación ortográfica, y [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/proofdisabled/) para controlar el estado más amplio de “no corregir”. Como estos ajustes se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de corrección.

Este artículo explica cómo asignar un idioma a un texto específico, establecer el idioma predeterminado para texto nuevo con [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaulttextlanguage/), crear párrafos multilingües, elegir entre `SpellCheck` y `ProofDisabled`, y preservar la configuración deseada al usar [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/joinportionswithsameformatting/). Estas propiedades almacenan metadatos para las aplicaciones de presentación; no traducen el texto, no realizan comprobación ortográfica basada en diccionarios, ni devuelven palabras mal escritas.

## **Establecer el idioma de corrección para el texto**

Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/), acceda a la porción de texto requerida a través de [IPortion.PortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/portionformat/), y asigne su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de corrección y guarda el resultado con [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Establecer el idioma predeterminado para texto nuevo**

Utilice [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaulttextlanguage/) para especificar el idioma de corrección que Aspose.Slides asigna al texto creado recientemente. Esta configuración es útil cuando la mayor parte o todo el texto nuevo en una presentación utiliza el mismo idioma. No modifica los metadatos de idioma del texto que ya tiene un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo utiliza las reglas de corrección alemanas:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Utilizar varios idiomas en un mismo párrafo**

Un [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/net/aspose.slides/portion/) separada para cada idioma y establezca su `LanguageId` de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Habilitar o suprimir la comprobación ortográfica para porciones individuales**

[IPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/) hereda las propiedades comunes de texto definidas por [IBasePortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/). Acceda al formato de una porción a través de [IPortion.PortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/portionformat/) y establezca [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/spellcheck/) para controlar si una aplicación de presentación puede comprobar la ortografía de esa porción. El valor predeterminado es `false`: `true` permite la comprobación ortográfica, mientras que `false` la suprime.

Este ajuste se aplica a porciones de texto individuales. Por lo tanto, diferentes porciones en el mismo párrafo pueden usar valores distintos. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/languageid/) y `SpellCheck` cumplen propósitos complementarios: `LanguageId` identifica el idioma de corrección, mientras que `SpellCheck` determina si se permiten las comprobaciones ortográficas para la porción.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/proofdisabled/) también controla la corrección, pero representa el estado más amplio de “no corregir” como un [NullableBool](https://reference.aspose.com/slides/es/net/aspose.slides/nullablebool/). Utilice `SpellCheck` cuando necesite un conmutador booleano directo específicamente para las comprobaciones ortográficas. Utilice `ProofDisabled` cuando necesite preservar o controlar explícitamente los metadatos de “no corregir” de la presentación, incluido su estado `NotDefined`. Si establece ambas propiedades, mantenga sus valores coherentes; no combine `SpellCheck = true` con `ProofDisabled = NullableBool.True`.

Estas propiedades configuran los metadatos de corrección utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los usa para ejecutar comprobaciones ortográficas basadas en diccionarios ni para devolver una lista de palabras mal escritas.

El siguiente ejemplo completo crea una presentación de entrada, la carga, asigna diferentes configuraciones de comprobación ortográfica e idiomas de corrección a dos porciones del mismo párrafo, guarda el resultado, lo vuelve a abrir y verifica los valores almacenados:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/joinportionswithsameformatting/) combina porciones adyacentes que tengan el mismo formato. Una diferencia únicamente en `SpellCheck` no mantiene esas porciones separadas; después de combinarlas, la porción resultante conserva el valor `SpellCheck` de la primera porción. Si las porciones necesitan configuraciones de comprobación ortográfica diferentes, llame a `JoinPortionsWithSameFormatting` antes de asignar esas configuraciones, o inspeccione los límites de las porciones resultantes y vuelva a aplicar las configuraciones posteriormente. Las porciones con valores diferentes de `LanguageId` permanecen separadas porque el formato del idioma de corrección difiere.

## **Preguntas frecuentes**

**¿El identificador de idioma traduce el texto?**

No. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/languageid/) almacena metadatos de corrección para la ortografía y la gramática; no altera el contenido del texto. Traduce el texto por separado y, a continuación, establezca el identificador de idioma apropiado para cada porción traducida.

**¿El idioma de corrección controla fuentes, guiones o ajuste de línea?**

No. El identificador de idioma es para la corrección. La representación y el diseño del texto dependen principalmente de las [fuentes](/slides/es/net/powerpoint-fonts/), el sistema de escritura y la configuración del marco de texto. Para una representación fiable, proporcione las fuentes necesarias, configure la [sustitución de fuentes](/slides/es/net/font-substitution/) o [incorpore fuentes](/slides/es/net/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de corrección?**

Sí. Asigne cada idioma a una porción separada, como se muestra en el ejemplo del párrafo multilingüe.

**¿Debo usar `DefaultTextLanguage` o `LanguageId`?**

Utilice [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaulttextlanguage/) cuando desee un valor predeterminado para el texto recién creado. Utilice [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/languageid/) cuando una porción específica necesite un idioma de corrección explícito o cuando un párrafo contenga varios idiomas.