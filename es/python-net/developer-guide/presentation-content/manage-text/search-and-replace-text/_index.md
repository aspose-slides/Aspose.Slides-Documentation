---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en Python
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/python-net/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- marco de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Aspose.Slides for Python via .NET puede buscar, resaltar y reemplazar texto en un marco de texto individual o en toda la presentación. Estas capacidades son útiles para revisiones, redactado, comprobaciones de terminología, limpieza de plantillas y otros flujos de trabajo automatizados de procesamiento de documentos.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Elegir el ámbito de búsqueda**

Utilice los métodos de [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) para limitar una operación a un marco de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un marco de texto | Toda la presentación |
|---|---|---|
| Resaltar texto literal | [TextFrame.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_text/) |
| Resaltar coincidencias de expresiones regulares | [TextFrame.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_regex/) |
| Reemplazar texto literal | [TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_text/) |
| Reemplazar coincidencias de expresiones regulares | [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_regex/) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/whole_words_only/) limita las coincidencias a palabras completas.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/case_sensitive/) controla si la mayúscula/minúscula debe coincidir.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/include_notes/) incluye las notas de la diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones basadas en expresiones regulares utilizan una cadena de patrón, por lo que reglas como la sensibilidad a mayúsculas y los límites de palabra se definen en la propia expresión.

## **Identificar el propietario de un marco de texto**

Los flujos de trabajo genéricos de procesamiento de texto a menudo reciben un [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) mientras buscan, reemplazan, validan o exportan texto. Utilice [TextFrame.parent_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_shape/) y [TextFrame.parent_cell](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_cell/) para determinar qué objeto de presentación es el propietario del marco de texto.

Los valores esperados dependen del propietario:

| Propietario del marco de texto | `parent_shape` | `parent_cell` |
|---|---|---|
| Una AutoShape u otra forma que contenga texto | El [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) propietario | `None` |
| Una celda de tabla | `None` | La [Cell](https://reference.aspose.com/slides/es/python-net/aspose.slides/cell/) propietaria |

Ambas propiedades son de solo lectura. Consultarlas no desplaza el marco de texto ni cambia su propietario. El código genérico debe comprobar ambos valores para `None` y gestionar la posibilidad de que ninguno de los propietarios esté disponible.

El siguiente ejemplo utiliza [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/get_all_text_frames/) para iterar a través de los marcos de texto de una presentación. Para las formas, muestra el nombre de la forma, el tipo de tiempo de ejecución de Python y la diapositiva contenedora. Para las celdas de tabla, muestra las coordenadas de columna y fila basadas en cero y la diapositiva contenedora.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Para el contenido de SmartArt, itere a través de las formas en [SmartArtNode.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartnode/shapes/) y acceda a cada [ISmartArtShape.text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/ismartartshape/text_frame/). El marco de texto puede rastrearse a su forma asociada mediante [TextFrame.parent_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_shape/), mientras que [TextFrame.parent_cell](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_cell/) es `None`. Por lo tanto, la rama de forma en el ejemplo también gestiona texto de nodos SmartArt.

## **Resaltar texto**

Utilice el método [TextFrame.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_text/) para resaltar coincidencias de texto literal en un marco de texto. Pase un [TextSearchOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/) para controlar la búsqueda.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Resaltar cada aparición de "try" en el marco de texto.
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

El método [TextFrame.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_regex/) resalta las coincidencias de texto encontradas mediante una expresión regular en un marco de texto.

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

Utilice [Presentation.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_text/) y [Presentation.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/highlight_regex/) para buscar en todos los marcos de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico:

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

## **Reemplazar texto en un marco de texto**

Utilice [TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) para texto literal y [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del marco de texto existente, conservando el formato de las porciones circundantes en lugar de reconstruir el marco de texto a partir de una cadena simple.

El siguiente ejemplo normaliza una variante ortográfica y luego reemplaza etiquetas de versión:

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

Si una coincidencia abarca porciones con formato diferente, revise la salida para confirmar qué formato debe aplicarse al texto de reemplazo.

## **Reemplazar texto en toda la presentación**

Utilice [Presentation.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_text/) y [Presentation.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_regex/) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redactado.

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

Obtenga el marco de texto de la forma y llame a [TextFrame.highlight_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) o [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) en ese marco de texto. Los métodos a nivel de presentación procesan todos los marcos de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/whole_words_only/) y [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/case_sensitive/) en `True`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la sensibilidad a mayúsculas en la propia expresión.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de la diapositiva?**

Sí. Establezca [TextSearchOptions.include_notes](https://reference.aspose.com/slides/es/python-net/aspose.slides/textsearchoptions/include_notes/) en `True` al usar una operación de texto literal a nivel de presentación.

**¿El reemplazo de texto conserva su formato?**

[TextFrame.replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_text/) y [TextFrame.replace_regex](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/replace_regex/) modifican el texto coincidente dentro del marco de texto existente y conservan el formato de las porciones circundantes. Si una coincidencia abarca porciones con formato diferente, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.