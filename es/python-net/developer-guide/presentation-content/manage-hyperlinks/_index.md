---
title: Gestionar hipervínculos de presentación en Python
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/python-net/manage-hyperlinks/
keywords:
- añadir URL
- añadir hipervínculo
- crear hipervínculo
- formatear hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- hipervínculo de texto
- hipervínculo de diapositiva
- hipervínculo de forma
- hipervínculo de imagen
- hipervínculo de vídeo
- hipervínculo modificable
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Añadir, formatear, actualizar y eliminar hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET, usando ejemplos en Python."
---
## **Introducción**

Un hipervínculo conecta el contenido de la presentación con un sitio web o una ubicación dentro de la presentación. En PowerPoint, los hipervínculos suelen cumplir dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco multimedia.  
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenidos.  

Aspose.Slides for Python via .NET le permite añadir estos enlaces, controlar su apariencia y sonido, actualizar sus propiedades y eliminarlos. Los ejemplos a continuación muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a los hipervínculos a nivel de presentación, diapositiva o cuadro de texto.

{{% alert color="info" title="Note" %}}
También puede editar presentaciones con el [editor gratuito de PowerPoint en línea de Aspose](https://products.aspose.app/slides/es/editor).
{{% /alert %}}

## **Añadir hipervínculos URL**

Puede asignar una URL de sitio web a texto, una forma o un marco multimedia. El elemento al que asigna el hipervínculo determina el área clicable: una porción de texto enlaza el texto seleccionado, mientras que una forma o un marco enlaza el objeto de la diapositiva.

### **Añadir hipervínculos URL al texto**

Para enlazar texto a un sitio web, asigne un [Hyperlink](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/) a la propiedad [hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/hyperlink_click/) de la porción de texto, como se muestra a continuación. Sólo esa porción de texto se vuelve clicable.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Añadir hipervínculos URL a formas y marcos multimedia**

Para que una forma o marco sea clicable, establezca su propiedad [hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/hyperlink_click/). El hipervínculo pertenece al propio objeto y no a una porción de texto dentro de él.

El mismo enfoque se aplica a los marcos de imagen, audio y vídeo: asigne el hipervínculo al marco y establezca el [tooltip](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/tooltip/) del enlace si es necesario.

El siguiente ejemplo hace que un rectángulo sea clicable:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar hipervínculos para crear una tabla de contenidos**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenidos a una diapositiva específica. El siguiente ejemplo usa [set_internal_hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) para enlazar el texto “Page 2” en la primera diapositiva a la segunda diapositiva.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formato de hipervínculos**

### **Color**

La propiedad [color_source](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/color_source/) de [Hyperlink](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/) determina si un hipervínculo utiliza el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, seleccione [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkcolorsource/) y establezca el color de relleno de la porción. Esta característica se introdujo en PowerPoint 2019; las versiones anteriores no aplican esta configuración.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero usa un relleno de texto rojo, mientras que el segundo mantiene el color de hipervínculo predeterminado.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Utilice las siguientes propiedades para configurar estos comportamientos:

- [Hyperlink.sound](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/sound/) especifica el audio asociado al hipervínculo.  
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/stop_sound_on_click/) controla si al activar el hipervínculo se detiene el sonido anterior.  

#### **Añadir un sonido al hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al hacer clic en el botón se reproduce el sonido y se navega a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al hacer clic, sin realizar una acción de navegación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Extraer el sonido de un hipervínculo**

El siguiente ejemplo abre la presentación creada anteriormente y lee el audio del hipervínculo de la primera forma en memoria mediante [sound](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/sound/) y [binary_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Configuración de tooltip e interacción**

Puede actualizar las siguientes propiedades de [Hyperlink](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/) después de asignar un hipervínculo a texto o a una forma:

- [tooltip](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/tooltip/) establece el texto que un espectador puede mostrar como pista para el enlace.  
- [target_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/target_frame/) especifica el marco de destino dentro de un frameset HTML padre, cuando corresponda.  
- [history](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/history/) controla si al activar el enlace se añade su destino a la lista de hipervínculos vistos.  
- [highlight_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/highlight_click/) controla si el hipervínculo se resalta al hacer clic.  

## **Eliminar hipervínculos de presentaciones**

Utilice [get_any_hyperlinks](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) para recopilar contenedores de hipervínculos, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar sólo un tipo, llame únicamente a [remove_hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) o a [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); eliminar una acción de clic no elimina su contraparte de pasar el ratón.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Para una eliminación incondicional, [remove_all_hyperlinks](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) elimina ambos tipos de activación en el alcance seleccionado en una sola llamada. Para una limpieza selectiva y cobertura de maestros, diseños y notas, vea [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, haga un inventario de sus acciones interactivas y de sus enlaces web. [get_any_hyperlinks](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) devuelve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/es/python-net/aspose.slides/ihyperlinkcontainer/), no una lista plana de cadenas URL. Revise tanto [hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) como [hyperlink_mouse_over](https://reference.aspose.com/slides/es/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear sólo los hipervínculos a nivel de forma puede pasar por alto enlaces adjuntos a porciones de texto. Consulte el alcance apropiado en su lugar y conserve los contenedores devueltos para poder actualizar o eliminar sus acciones más adelante.

### **Consultar alcances de presentación, diapositiva y cuadro de texto**

La clase [HyperlinkQueries](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/) está disponible a través de [Presentation.hyperlink_queries](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/hyperlink_queries/) y [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/hyperlink_queries/). Cada alcance admite las mismas consultas:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) devuelve contenedores con una acción de clic.  
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) devuelve contenedores con una acción de pasar el ratón.  
- [get_any_hyperlinks](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) devuelve contenedores con una o ambas acciones.  

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace externo de clic, un enlace de pasar el ratón a un archivo, una navegación interna de diapositiva, un enlace de pasar el ratón en texto y una acción de macro. No ejecuta ninguna de estas acciones. Las mismas tres consultas funcionan en cada alcance; los contadores describen contenedores, no totales de acciones. El alcance de cuadro de texto excluye los enlaces propios de la forma contenedora.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Para este ejemplo, las consultas de presentación y de diapositiva informan tres contenedores de clic, dos contenedores de pasar el ratón y tres contenedores con cualquiera de las acciones. La consulta de cuadro de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Utilice [Hyperlink.action_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/action_type/) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkactiontype/) abarcan más que la navegación web:

| Values | Significado para una auditoría |
| --- | --- |
| `HYPERLINK` | Hipervínculo externo; inspeccione la URL y su esquema. |
| `JUMP_SPECIFIC_SLIDE` | Navegación interna a una diapositiva concreta. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Navegación incorporada de la presentación, resuelta en contexto de presentación. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Finalizar la presentación actual o iniciar una presentación personalizada. |
| `START_MACRO` | Ejecutar una macro. |
| `START_PROGRAM` | Lanzar un programa. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Abrir un archivo o otra presentación; revise por separado de las URL web. |
| `START_STOP_MEDIA` | Iniciar o detener la reproducción de medios. |
| `NO_ACTION`, `UNKNOWN` | No hay acción de navegación, o una acción no reconocida que requiere revisión. |

Lea destinos externos desde [external_url](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/external_url/) y destinos internos específicos desde [target_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/target_slide/). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor carezca de acción. Preserve [external_url_original](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/external_url_original/) cuando difiera de la URL normalizada e incluya el [tooltip](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlink/tooltip/) cuando esté disponible.

### **Informar, sanear y verificar hipervínculos**

El siguiente ejemplo en Python lee una presentación existente (utilice el archivo creado arriba), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar nuevamente ambos tipos de activación. Recopila contenedores antes de modificarlos y consulta cada alcance de diapositiva una sola vez para evitar procesado duplicado. Las consultas de presentación cubren diapositivas ordinarias; para un inventario a nivel de paquete, el ejemplo consulta diapositivas ordinarias, maestros, diseños, notas y los maestros de notas y folletos cuando están presentes.

El informe registra un índice de diapositiva basado en 1 y [slide_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/slide_id/) donde esté disponible. El recopilador mantiene la diapositiva propietaria y el alcance junto a cada contenedor devuelto. Los maestros, diseños y notas no tienen índice de diapositiva ordinario y se identifican por su alcance. Los contenedores de forma y los de formato de porción de texto se etiquetan por separado; los demás tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local de informe para que sus dos acciones puedan correlacionarse.

Esta política de aplicación deliberadamente restrictiva permite sólo URLs HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas de URL. Estas rechazadas son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS por sí solo no establece confianza: añada listas blancas de hosts y otras comprobaciones para su aplicación. Tanto las URL externas originales como las normalizadas se comprueban. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [hyperlink_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) del contenedor admite [set_external_hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) y [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Aquí, los enlaces externos de clic prohibidos se sustituyen por una página de destino HTTPS fija; los demás clics y acciones de pasar el ratón prohibidos se eliminan de forma independiente. Establezca `replace_external_clicks` a `False` para eliminar todas las violaciones de política en su lugar. Escoja una página de sustitución propia de la aplicación antes del despliegue.

La bandera de exportación del informe usa una política conservadora de revisión PDF: marca acciones de pasar el ratón y cualquier cosa distinta de un enlace externo o salto a diapositiva específica como potencialmente no soportada. Es una pista de revisión, no una prueba de capacidad ni una garantía de que los enlaces no marcados sobrevivirán a la exportación. Las exportaciones soportadas de [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) y [HTML](/slides/es/python-net/convert-powerpoint-to-html/) pueden preservar hipervínculos, según la acción, opciones de exportación y visor. Las [imágenes](/slides/es/python-net/convert-powerpoint-to-png/) raster y los [videos](/slides/es/python-net/convert-powerpoint-to-video/) no pueden preservar hipervínculos interactivos; marque cada acción al auditar esos resultados.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Consultar cada alcance de diapositiva una vez, reteniendo su propietario con cada contenedor.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Con la entrada creada arriba, el informe contiene cinco filas de acción. El enlace de pasar el ratón del archivo y el clic de macro se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositiva permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL de clic externa prohibida también ejerce la rama de sustitución. Un contenedor con un clic permitido y un pasar el ratón prohibido conserva su acción de clic.

Esta limpieza selectiva difiere de [remove_all_hyperlinks](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), que elimina ambos tipos de activación en todo el alcance seleccionado sin tener en cuenta la política. La verificación aquí solo comprueba acciones de hipervínculo; no elimina proyectos VBA incrustados, objetos OLE u otro contenido activo, y no valida un archivo PDF o HTML exportado.

## **FAQ**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear navegación a una sección, enlace a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en las diapositivas que usan la maestra o el diseño correspondiente.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o video?**

Las exportaciones soportadas de PDF y HTML pueden conservar hipervínculos; las imágenes raster y el video no pueden. Vea las consideraciones de exportación en [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).