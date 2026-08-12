---
title: Buscar y reemplazar texto en presentaciones PowerPoint en Python
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/python-net/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- cuadro de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones PowerPoint con Aspose.Slides para Python a través de .NET."
---
## **Descripción general**

Aspose.Slides para Python a través de .NET puede buscar, resaltar y reemplazar texto en un cuadro de texto individual o en toda una presentación. Estas capacidades son útiles para la revisión, la redacción, la verificación de terminología, la limpieza de plantillas y otros flujos de trabajo automatizados de procesamiento de documentos.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Elegir el ámbito de búsqueda**

Utilice los métodos de [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) para limitar una operación a un cuadro de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un cuadro de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [TextFrame.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_text/) |
| Resaltar coincidencias de expresiones regulares | [TextFrame.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_regex/) |
| Reemplazar texto literal | [TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_text/) |
| Reemplazar coincidencias de expresiones regulares | [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_regex/) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/whole_words_only/) limita las coincidencias a palabras completas.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/case_sensitive/) controla si la mayúscula/minúscula de los caracteres debe coincidir.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/include_notes/) incluye las notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan una cadena de patrón, por lo que las reglas de coincidencia, como la sensibilidad a mayúsculas y los límites de palabra, se definen mediante la expresión.

## **Resaltar texto**

Utilice el método [TextFrame.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_text/) para resaltar coincidencias de texto literal en un cuadro de texto. Pase [TextSearchOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/) para controlar la búsqueda.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Resaltar cada aparición de "try" en el cuadro de texto.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Resaltar solo la palabra completa "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [TextFrame.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_regex/) resalta las coincidencias de texto encontradas mediante una expresión regular en un cuadro de texto.

El siguiente código resalta todas las palabras que contienen siete o más caracteres:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

El resultado:

![El texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda la presentación**

Utilice [Presentation.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_text/) y [Presentation.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_regex/) para buscar en todos los cuadros de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Reemplazar texto en un cuadro de texto**

Utilice [TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) para texto literal y [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del cuadro de texto existente, manteniendo el formato de la porción circundante en lugar de reconstruir el cuadro de texto a partir de una cadena simple.

El siguiente ejemplo normaliza una variante ortográfica y luego reemplaza las etiquetas de versión:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Si una coincidencia abarca porciones con formatos diferentes, revise la salida para confirmar qué formato debe aplicarse al texto de reemplazo.

## **Reemplazar texto en toda la presentación**

Utilice [Presentation.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_text/) y [Presentation.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_regex/) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y la redacción.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Preguntas frecuentes**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el marco de texto de la forma y llame a [TextFrame.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) o [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) en ese marco de texto. Los métodos a nivel de presentación procesan todos los cuadros de texto aplicables en su lugar.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/whole_words_only/) y [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/case_sensitive/) en `True`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la sensibilidad a mayúsculas en el propio patrón.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de la diapositiva?**

Sí. Establezca [TextSearchOptions.include_notes](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/include_notes/) en `True` al usar una operación de texto literal a nivel de presentación.

**¿Mantiene el reemplazo de texto su formato?**

[TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) y [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) modifican el texto coincidente dentro del cuadro de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca porciones con formatos diferentes, inspeccione el resultado para garantizar que el reemplazo utilice el estilo deseado.