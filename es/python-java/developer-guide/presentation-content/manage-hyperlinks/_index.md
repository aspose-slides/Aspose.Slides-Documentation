---
title: Gestionar hipervínculos de presentación en Python vía Java
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/python-java/manage-hyperlinks/
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
- hipervínculo mutable
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Añadir, formatear, actualizar y eliminar hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python vía Java, utilizando ejemplos en Python."
---
## **Introducción**

Un hipervínculo conecta el contenido de la presentación con un sitio web o una ubicación dentro de la presentación. En PowerPoint, los hipervínculos suelen cumplir dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco de medios.
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenido.

Aspose.Slides for Python via Java le permite añadir estos enlaces, controlar su apariencia y sonido, actualizar sus propiedades y eliminarlos. Los ejemplos a continuación muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a los hipervínculos a nivel de presentación, diapositiva o cuadro de texto.

{{% alert color="info" title="Nota" %}}
También puede editar presentaciones con el [editor gratuito en línea de Aspose PowerPoint](https://products.aspose.app/slides/es/editor).
{{% /alert %}} 

## **Añadir hipervínculos URL**

Puede asignar una URL de sitio web a texto, una forma o un marco de medios. El elemento al que asigna el hipervínculo determina el área clicable: una porción de texto enlaza el texto seleccionado, mientras que una forma o marco enlaza al objeto de la diapositiva.

### **Añadir hipervínculos URL a texto**

Para enlazar texto a un sitio web, pase un [Hyperlink](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/) al método [setHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#setHyperlinkClick) de la porción de texto, como se muestra a continuación. Sólo esa porción de texto se vuelve clicable.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Añadir hipervínculos URL a formas y marcos de medios**

Para que una forma o marco sea clicable, llame a su método [setHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setHyperlinkClick). El hipervínculo pertenece al propio objeto y no a una porción de texto dentro de él.

El mismo enfoque se aplica a los marcos de imagen, audio y vídeo: asigne el hipervínculo al marco y llame a [setTooltip](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setTooltip) si es necesario.

El siguiente ejemplo hace que un rectángulo sea clicable:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utilizar hipervínculos para crear una tabla de contenido**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenido a una diapositiva específica. El siguiente ejemplo usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) para enlazar el texto “Page 2” en la primera diapositiva a la segunda diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formato de hipervínculos**

### **Color**

El método [setColorSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setColorSource) de [Hyperlink](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/) determina si un hipervínculo utiliza el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, seleccione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkcolorsource/) y establezca el color de relleno de la porción. Esta característica se introdujo en PowerPoint 2019; las versiones anteriores no aplican este ajuste.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero utiliza un relleno de texto rojo, mientras que el segundo mantiene el color de hipervínculo predeterminado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Utilice los siguientes métodos para configurar estos comportamientos:

- [Hyperlink.setSound](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setSound) especifica el audio asociado al hipervínculo.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) controla si al activar el hipervínculo se detiene el sonido anterior.

#### **Añadir un sonido a un hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al hacer clic en el botón se reproduce el sonido y se navega a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al hacer clic, sin realizar una acción de navegación.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Extraer un sonido de hipervínculo**

El siguiente ejemplo abre la presentación creada anteriormente y lee el audio del hipervínculo de la primera forma en memoria mediante [getSound](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#getSound) y [getBinaryData](https://reference.aspose.com/slides/es/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Información sobre herramientas y ajustes de interacción**

Puede llamar a los siguientes métodos de [Hyperlink](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/) después de asignar un hipervínculo a texto o a una forma:

- [setTooltip](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setTooltip) establece el texto que un visualizador puede mostrar como pista para el enlace.
- [setTargetFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setTargetFrame) especifica el marco de destino dentro de un frameset HTML padre, cuando corresponda.
- [setHistory](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setHistory) controla si al activar el enlace se añade su destino a la lista de hipervínculos vistos.
- [setHighlightClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setHighlightClick) controla si el hipervínculo se resalta al hacer clic.

## **Eliminar hipervínculos de presentaciones**

Utilice [getAnyHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) para recopilar contenedores de hipervínculo, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar sólo un tipo, llame sólo a [removeHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) o a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); eliminar una acción de clic no elimina su contraparte de paso del ratón.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Para una eliminación incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) elimina ambos tipos de activación en el ámbito seleccionado en una única llamada. Para una limpieza selectiva y cobertura de maestros, diseños y notas, vea [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, haga un inventario de sus acciones interactivas así como de sus enlaces web. [getAnyHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) devuelve contenedores de hipervínculo, como objetos [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) y [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/), no una lista plana de cadenas URL. Examine tanto [getHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getHyperlinkClick) como [getHyperlinkMouseOver](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getHyperlinkMouseOver) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear sólo los hipervínculos a nivel de forma puede pasar por alto enlaces adjuntos a porciones de texto. En su lugar, consulte el ámbito apropiado y conserve los contenedores devueltos para que pueda actualizarlos o eliminarlos posteriormente.

### **Consultar ámbitos de presentación, diapositiva y cuadro de texto**

La clase [HyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/) está disponible a través de [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getHyperlinkQueries) y [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getHyperlinkQueries). Cada ámbito admite las mismas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) devuelve contenedores con una acción de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) devuelve contenedores con una acción de paso del ratón.
- [getAnyHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) devuelve contenedores con cualquiera o ambas acciones.

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace de clic externo, un enlace de paso del ratón a archivo, navegación interna de diapositiva, un enlace de paso del ratón en texto y una acción de macro. No ejecuta ninguna de estas acciones. Las mismas tres consultas funcionan en cada ámbito; los recuentos describen contenedores, no totales de acciones. El ámbito de cuadro de texto excluye los enlaces propios de la forma contenedora.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para este ejemplo, las consultas de presentación y de diapositiva informan cada una tres contenedores de clic, dos contenedores de paso del ratón y tres contenedores con cualquiera de las acciones. La consulta de cuadro de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Utilice [Hyperlink.getActionType](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#getActionType) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkactiontype/) cubren más que la navegación web:

| Valores | Significado para una auditoría |
| --- | --- |
| `Hyperlink` | Hipervínculo externo; inspeccione la URL y su esquema. |
| `JumpSpecificSlide` | Navegación interna a una diapositiva concreta. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegación incorporada de la presentación, resuelta en el contexto de la presentación. |
| `JumpEndShow`, `StartCustomSlideShow` | Finaliza la presentación actual o inicia una presentación personalizada. |
| `StartMacro` | Ejecutar una macro. |
| `StartProgram` | Iniciar un programa. |
| `OpenFile`, `OpenPresentation` | Abrir un archivo u otra presentación; revíselo por separado de las URLs web. |
| `StartStopMedia` | Iniciar o detener la reproducción de medios. |
| `NoAction`, `Unknown` | Sin acción de navegación, o una acción no reconocida que requiere revisión. |

Lea los destinos externos mediante [getExternalUrl](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#getExternalUrl) y los destinos internos específicos mediante [getTargetSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#getTargetSlide). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor no tenga acción. Conserve el valor devuelto por [getExternalUrlOriginal](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) cuando difiera de la URL normalizada, e incluya la información emergente devuelta por [getTooltip](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#getTooltip) cuando esté disponible.

### **Informar, sanear y verificar hipervínculos**

El siguiente ejemplo en Python lee una presentación existente (use el archivo creado anteriormente), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar nuevamente ambos tipos de activación. Recopila los contenedores antes de modificarlos y usa igualdad de referencia para evitar procesar el mismo contenedor dos veces. Las consultas de presentación cubren diapositivas ordinarias; para un inventario de todo el paquete, también consulta explícitamente maestros, diseños, notas y los maestros de notas y folletos cuando están presentes.

El informe registra un índice de diapositiva basado en 1 y [getSlideId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getSlideId) cuando está disponible. [getSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getSlide) proporciona la diapositiva propietaria para los contenedores compatibles. Los maestros, diseños y notas no tienen un índice de diapositiva ordinario y se identifican por su ámbito. Los contenedores de forma y los contenedores de formato de porción de texto se etiquetan por separado; los demás tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local al informe para que sus dos acciones puedan correlacionarse. El informe almacena los tipos de acción como las constantes enteras definidas por la enumeración Java.

Esta política de aplicación deliberadamente restrictiva permite sólo URLs HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas de URL. Estos rechazos son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS por sí solo no establece confianza: añada listas de hosts permitidos y otras comprobaciones para su aplicación. Se verifican tanto las URLs externas originales como las normalizadas. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [getHyperlinkManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getHyperlinkManager) del contenedor admite [setExternalHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) y [removeHyperlinkMouseOver](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Aquí, los enlaces externos de clic prohibidos se reemplazan con una página de destino HTTPS fija; los demás clics prohibidos y las acciones de paso del ratón prohibidas se eliminan de forma independiente. Establezca `replace_external_clicks` a `False` para eliminar todas las violaciones de la política. Elija una página de sustitución propia de la aplicación antes del despliegue.

La bandera de exportación del informe utiliza una política conservadora de revisión de PDF: marca las acciones de paso del ratón y cualquier cosa que no sea un enlace externo o un salto a una diapositiva específica como potencialmente no soportada. Es una pista de revisión, no una prueba de capacidad ni una garantía de que los enlaces sin marcar sobrevivirán a la exportación. Las exportaciones compatibles de [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/) y [HTML](/slides/es/python-java/convert-powerpoint-to-html/) pueden preservar los hipervínculos, según la acción, las opciones de exportación y el visor. Las [imágenes](/slides/es/python-java/convert-powerpoint-to-png/) y [video](/slides/es/python-java/convert-powerpoint-to-video/) raster no pueden preservar hipervínculos interactivos; marque cada acción al auditar para esas salidas.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Con la entrada creada anteriormente, el informe contiene cinco filas de acciones. El enlace de paso del ratón a archivo y el clic de macro se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositivas permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL de clic externo prohibida también ejecuta la rama de reemplazo. Un contenedor con un clic permitido y un paso del ratón prohibido conserva su acción de clic.

Esta limpieza selectiva difiere de [removeAllHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), que elimina ambos tipos de activación en todo el ámbito seleccionado sin importar la política. La verificación aquí sólo revisa las acciones de los hipervínculos; no elimina proyectos VBA incrustados, objetos OLE u otro contenido activo, y no valida un archivo PDF o HTML exportado.

## **Preguntas frecuentes**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear navegación a una sección, enlace a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a los elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en las diapositivas que utilizan la maestra o el diseño correspondiente.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?**

Las exportaciones compatibles de PDF y HTML pueden conservar los hipervínculos; las imágenes raster y el vídeo no pueden. Consulte las consideraciones de exportación en [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).