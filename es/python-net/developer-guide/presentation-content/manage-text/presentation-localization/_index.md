---
title: Automatizar la localización de presentaciones con Python
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/python-net/presentation-localization/
keywords:
- cambiar idioma
- comprobación ortográfica
- suprimir comprobación ortográfica
- idioma de corrección
- identificador de idioma
- texto multilingüe
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Establezca idiomas de corrección para el texto de presentaciones PowerPoint y OpenDocument en Python con Aspose.Slides, incluidos valores predeterminados y párrafos multilingües."
---
## **Visión general**

Aspose.Slides for Python via .NET le permite configurar metadatos de corrección para porciones de texto individuales. Utilice [BasePortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/language_id/) para identificar el idioma de corrección, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/spell_check/) para permitir o suprimir las comprobaciones ortográficas, y [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/proof_disabled/) para controlar el estado más amplio de “no corregir”. Debido a que estos ajustes se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de corrección.

Este artículo explica cómo asignar un idioma a texto específico, establecer el idioma predeterminado para texto nuevo con [LoadOptions.default_text_language](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/default_text_language/), crear párrafos multilingües, elegir entre `spell_check` y `proof_disabled`, y conservar la configuración prevista al usar [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Estas propiedades almacenan metadatos para aplicaciones de presentación; no traducen texto, no realizan comprobaciones ortográficas basadas en diccionarios, ni devuelven palabras mal escritas.

## **Establecer el idioma de corrección para el texto**

Crear o cargar una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/), acceder a la porción de texto requerida mediante [Portion.portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/portion_format/), y asignar su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de corrección y guarda el resultado con [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el idioma predeterminado para texto nuevo**

Utilice [LoadOptions.default_text_language](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/default_text_language/) para especificar el idioma de corrección que Aspose.Slides asigna al texto recién creado. Esta configuración es útil cuando la mayor parte o todo el texto nuevo en una presentación utiliza el mismo idioma. No modifica los metadatos de idioma del texto que ya tiene un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo utiliza reglas de corrección alemanas:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar varios idiomas en un mismo párrafo**

Un [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) separada para cada idioma y establezca su `language_id` de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Habilitar o suprimir la comprobación ortográfica para porciones individuales**

[PortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/) hereda las propiedades de texto comunes definidas por [BasePortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/). Acceda al formato de una porción mediante [Portion.portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/portion_format/) y establezca [BasePortionFormat.spell_check](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/spell_check/) para controlar si una aplicación de presentación puede verificar la ortografía de esa porción. El valor predeterminado es `False`: `True` permite la comprobación ortográfica, mientras que `False` la suprime.

La configuración se aplica a porciones de texto individuales. Por lo tanto, diferentes porciones en el mismo párrafo pueden usar valores distintos. [BasePortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/language_id/) y `spell_check` cumplen propósitos complementarios: `language_id` identifica el idioma de corrección, mientras que `spell_check` determina si se permiten las comprobaciones ortográficas para la porción.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/proof_disabled/) también controla la corrección, pero representa el estado más amplio de “no corregir” como un [NullableBool](https://reference.aspose.com/slides/es/python-net/aspose.slides/nullablebool/). Utilice `spell_check` cuando necesite un conmutador Booleano directo específicamente para comprobaciones ortográficas. Utilice `proof_disabled` cuando necesite conservar o controlar explícitamente los metadatos de no corrección de la presentación, incluido su estado `NOT_DEFINED`. Si establece ambas propiedades, mantenga sus valores coherentes; no combine `spell_check = True` con `proof_disabled = slides.NullableBool.TRUE`.

Estas propiedades configuran los metadatos de corrección utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los emplea para ejecutar comprobaciones ortográficas basadas en diccionario ni para devolver una lista de palabras mal escritas.

El siguiente ejemplo completo crea una presentación de entrada, la carga, asigna distintas configuraciones de comprobación ortográfica e idiomas de corrección a dos porciones en el mismo párrafo, guarda el resultado, lo vuelve a abrir y verifica los valores almacenados:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) combina porciones adyacentes que tienen el mismo formato. Una diferencia únicamente en `spell_check` no mantiene dichas porciones separadas; después de unirlas, la porción resultante conserva el valor `spell_check` de la primera porción. Si las porciones necesitan distintas configuraciones de comprobación ortográfica, llame a `join_portions_with_same_formatting` antes de asignar esas configuraciones, o inspeccione los límites de la porción resultante y vuelva a aplicar las configuraciones posteriormente. Las porciones con valores diferentes de `language_id` permanecen separadas porque su formato de idioma de corrección difiere.

## **Preguntas frecuentes**

**¿El ID de idioma traduce el texto?**

No. [BasePortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/language_id/) almacena metadatos de corrección para ortografía y gramática; no modifica el contenido del texto. Traduzca el texto por separado y luego establezca el identificador de idioma apropiado para cada porción traducida.

**¿El idioma de corrección controla fuentes, guionización o ajuste de línea?**

No. El identificador de idioma es para la corrección. La renderización y el diseño del texto dependen principalmente de las [fonts](/slides/es/python-net/powerpoint-fonts/), del sistema de escritura y de la configuración del marco de texto. Para una renderización fiable, proporcione las fuentes necesarias, configure la [font substitution](/slides/es/python-net/font-substitution/) o [embed fonts](/slides/es/python-net/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de corrección?**

Sí. Asigne cada idioma a una porción separada, como se muestra en el ejemplo del párrafo multilingüe.

**¿Debo usar `default_text_language` o `language_id`?**

Utilice [LoadOptions.default_text_language](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/default_text_language/) cuando desee un valor predeterminado para el texto recién creado. Utilice [BasePortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/language_id/) cuando una porción específica necesite un idioma de corrección explícito o cuando un párrafo contenga varios idiomas.