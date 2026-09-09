---
title: Automatizar la localización de presentaciones en Python mediante Java
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/python-java/presentation-localization/
keywords:
- cambiar idioma
- revisión ortográfica
- suprimir revisión ortográfica
- idioma de revisión
- identificador de idioma
- texto multilingüe
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Establezca idiomas de revisión para el texto de presentaciones PowerPoint y OpenDocument en Python mediante Java con Aspose.Slides, incluidos los valores predeterminados y los párrafos multilingües."
---
## **Visión general**

Aspose.Slides for Python via Java le permite configurar los metadatos de revisión para porciones de texto individuales. Utilice [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) para identificar el idioma de revisión, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) para permitir o suprimir la comprobación ortográfica y [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setProofDisabled) para controlar el estado más amplio de «no revisar». Como estos ajustes se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de revisión.

Este artículo explica cómo asignar un idioma a un texto específico, establecer el idioma predeterminado para texto nuevo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), crear párrafos multilingües, elegir entre [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) y [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setProofDisabled), y conservar los ajustes deseados al usar [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Estas propiedades almacenan metadatos para aplicaciones de presentación; no traducen el texto, no realizan una comprobación ortográfica basada en diccionario ni devuelven palabras mal escritas.

## **Establecer el idioma de revisión para el texto**

Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), acceda a la porción de texto requerida mediante [Portion.getPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getPortionFormat) y asigne su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de revisión y guarda el resultado con [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el idioma predeterminado para texto nuevo**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para especificar el idioma de revisión que Aspose.Slides asigna al texto recién creado. Esta configuración es útil cuando la mayor parte o todo el texto nuevo en una presentación utiliza el mismo idioma. No modifica los metadatos de idioma del texto que ya tiene un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo usa normas de revisión alemanas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utilizar varios idiomas en un mismo párrafo**

Un [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) distinta para cada idioma y establezca su [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Activar o suprimir la comprobación ortográfica para porciones individuales**

[PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/) hereda las propiedades comunes de texto definidas por [BasePortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/). Acceda al formato de una porción mediante [Portion.getPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getPortionFormat) y use [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) para controlar si una aplicación de presentación puede comprobar la ortografía de esa porción. El valor predeterminado es `False`: `True` permite la comprobación ortográfica, mientras que `False` la suprime.

El ajuste se aplica a porciones de texto individuales. Por lo tanto, distintas porciones en el mismo párrafo pueden usar valores diferentes. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) y [setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) cumplen propósitos complementarios: [setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) identifica el idioma de revisión, mientras que [setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) determina si se permiten comprobaciones ortográficas para la porción.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setProofDisabled) también controla la revisión, pero representa el estado más amplio de «no revisar» como un [NullableBool](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/). Use [setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) cuando necesite un interruptor booleano directo específicamente para la comprobación ortográfica. Use [setProofDisabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setProofDisabled) cuando necesite preservar o controlar explícitamente los metadatos de «no revisar» de la presentación, incluido su estado [NullableBool.NotDefined](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/#NotDefined). Si establece ambas propiedades, mantenga sus valores coherentes; no combine [setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) configurado en `True` con [setProofDisabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setProofDisabled) configurado en el estado [NullableBool.True](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/#True).

Estas propiedades configuran metadatos de revisión utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los emplea para ejecutar una comprobación ortográfica basada en diccionario ni para devolver una lista de palabras mal escritas.

El siguiente ejemplo completo crea una presentación de entrada, la carga, asigna diferentes ajustes de comprobación ortográfica e idiomas de revisión a dos porciones del mismo párrafo, guarda el resultado, lo vuelve a abrir y verifica los valores almacenados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combina porciones adyacentes que tengan el mismo formato. Una diferencia únicamente en [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) no mantiene esas porciones separadas; después de unirlas, la porción resultante conserva el valor de [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setSpellCheck) de la primera porción. Si las porciones necesitan ajustes de comprobación ortográfica diferentes, llame a [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) antes de asignar esos ajustes, o inspeccione los límites de la porción resultante y vuelva a aplicar los ajustes posteriormente. Las porciones con valores diferentes de [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) permanecen separadas porque su formato de idioma de revisión difiere.

## **FAQ**

**¿Un ID de idioma traduce el texto?**

No. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) almacena metadatos de revisión para ortografía y gramática; no altera el contenido del texto. Traduzca el texto por separado y, a continuación, establezca el identificador de idioma adecuado para cada porción traducida.

**¿El idioma de revisión controla fuentes, guiones o ajuste de línea?**

No. El identificador de idioma es solo para la revisión. La representación y el diseño del texto dependen principalmente de las [fuentes](/slides/es/python-java/powerpoint-fonts/) disponibles, del sistema de escritura y de la configuración del marco de texto. Para un renderizado fiable, proporcione las fuentes requeridas, configure la [sustitución de fuentes](/slides/es/python-java/font-substitution/) o [incorpore fuentes](/slides/es/python-java/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de revisión?**

Sí. Asigne cada idioma a una porción distinta, como se muestra en el ejemplo del párrafo multilingüe.

**¿Debo usar [setDefaultTextLanguage](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) o [setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) cuando desee un valor predeterminado para el texto recién creado. Utilice [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) cuando una porción específica necesite un idioma de revisión explícito o cuando un párrafo contenga varios idiomas.