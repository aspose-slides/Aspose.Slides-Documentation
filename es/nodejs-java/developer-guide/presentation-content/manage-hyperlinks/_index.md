---
title: Gestionar hipervínculos de presentación en JavaScript
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/nodejs-java/manage-hyperlinks/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Añadir, formatear, actualizar y eliminar hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Node.js a través de Java, usando ejemplos en JavaScript."
---
## **Introducción**

Un hipervínculo conecta el contenido de una presentación con un sitio web o una ubicación dentro de la presentación. En PowerPoint, los hipervínculos suelen cumplir dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco multimedia.
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenido.

Aspose.Slides for Node.js a través de Java le permite añadir estos enlaces, controlar su apariencia y sonido, actualizar sus propiedades y eliminarlos. Los ejemplos a continuación muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a los hipervínculos a nivel de presentación, diapositiva o marco de texto.

{{% alert color="info" title="Note" %}}
También puede editar presentaciones con el [editor en línea gratuito de Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Agregar hipervínculos URL**

Puede asignar una URL de sitio web a texto, una forma o un marco multimedia. El elemento al que asigna el hipervínculo determina el área clicable: una porción de texto enlaza el texto seleccionado, mientras que una forma o un marco enlaza el objeto de la diapositiva.

Para presentaciones que contienen hipervínculos relativos, consulte [Administrar la base de hipervínculo](/slides/es/nodejs-java/presentation-properties/#manage-the-hyperlink-base) para leer, cambiar o borrar la base a nivel de documento.

### **Agregar hipervínculos URL a texto**

Para enlazar texto a un sitio web, pase un [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) al método [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) de la porción de texto, como se muestra a continuación. Solo esa porción de texto se vuelve clicable.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Agregar hipervínculos URL a formas y marcos multimedia**

Para hacer que una forma o un marco sea clicable, llame a su método [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick). El hipervínculo pertenece al propio objeto en lugar de a una porción de texto dentro de él.

El mismo enfoque se aplica a marcos de imagen, audio y vídeo: asigne el hipervínculo al marco y llame a [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) si es necesario.

El siguiente ejemplo hace que un rectángulo sea clicable:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utilizar hipervínculos para crear una tabla de contenido**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenido a una diapositiva específica. El siguiente ejemplo usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) para enlazar el texto “Page 2” en la primera diapositiva a la segunda diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formato de hipervínculos**

### **Color**

El método [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) de [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) determina si un hipervínculo utiliza el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, seleccione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) y establezca el color de relleno de la porción. Esta función se introdujo en PowerPoint 2019; las versiones anteriores no aplican esta configuración.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero usa un relleno de texto rojo, mientras que el segundo mantiene el color de hipervínculo predeterminado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Utilice los siguientes métodos para configurar estos comportamientos:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) especifica el audio asociado al hipervínculo.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) controla si al activar el hipervínculo se detiene el sonido anterior.

#### **Añadir un sonido al hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al hacer clic en el botón se reproduce el sonido y se navega a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al hacer clic, sin realizar una acción de navegación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extraer el sonido de un hipervínculo**

El siguiente ejemplo abre la presentación creada arriba y lee el audio del hipervínculo de la primera forma en memoria mediante [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) y [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Configuración de información sobre herramientas y de interacción**

Puede llamar a los siguientes métodos de [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) después de asignar un hipervínculo a texto o a una forma:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) establece el texto que el espectador puede mostrar como pista para el enlace.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) especifica el marco de destino dentro de un frameset HTML padre, cuando corresponda.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) controla si al activar el enlace se añade su destino a la lista de hipervínculos vistos.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) controla si el hipervínculo se resalta al hacer clic.

## **Eliminar hipervínculos de presentaciones**

Utilice [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) para recopilar contenedores de hipervínculos, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar solo un tipo, invoque únicamente [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); eliminar una acción de clic no elimina su contraparte de pasar el ratón.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Para una eliminación incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) quita ambos tipos de activación en el alcance seleccionado en una única llamada. Para una limpieza selectiva que incluya maestros, diseños y notas, consulte [Informar, sanear y verificar hipervínculos](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, inventarié sus acciones interactivas así como sus enlaces web. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) devuelve contenedores de hipervínculos, no una lista plana de cadenas URL. Inspeccione tanto [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) como [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear solo los hipervínculos a nivel de forma puede pasar por alto enlaces adjuntos a porciones de texto. Consulte el alcance apropiado en su lugar y conserve los contenedores devueltos para que luego pueda actualizar o eliminar sus acciones.

### **Consultar alcances de presentación, diapositiva y marco de texto**

La clase [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) está disponible mediante [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) y [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Cada alcance admite las mismas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) devuelve contenedores con una acción de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) devuelve contenedores con una acción de pasar el ratón.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) devuelve contenedores con cualquiera de las acciones o ambas.

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace externo de clic, un enlace de archivo al pasar el ratón, navegación interna de diapositiva, un enlace de texto al pasar el ratón y una acción de macro. No ejecuta ninguna de estas acciones. Las mismas tres consultas funcionan en cada alcance; los recuentos describen contenedores, no totales de acciones. El alcance de marco de texto excluye los enlaces propios de la forma contenedora.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para este ejemplo, las consultas de presentación y de diapositiva informan tres contenedores de clic, dos de pasar el ratón y tres contenedores con cualquiera de las acciones. La consulta de marco de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Utilice [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) cubren más que la navegación web:

| Valores | Significado para una auditoría |
| --- | --- |
| `Hyperlink` | Hipervínculo externo; inspeccione la URL y su esquema. |
| `JumpSpecificSlide` | Navegación interna a una diapositiva concreta. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegación incorporada de presentación, resuelta en el contexto de la presentación. |
| `JumpEndShow`, `StartCustomSlideShow` | Finaliza la presentación actual o inicia una presentación personalizada. |
| `StartMacro` | Ejecuta una macro. |
| `StartProgram` | Inicia un programa. |
| `OpenFile`, `OpenPresentation` | Abre un archivo o otra presentación; revíselo por separado de las URLs web. |
| `StartStopMedia` | Inicia o detiene la reproducción de medios. |
| `NoAction`, `Unknown` | Sin acción de navegación, o una acción no reconocida que requiere revisión. |

Lea destinos externos mediante [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) y destinos internos específicos mediante [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor no tenga acción. Preserve el valor devuelto por [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) cuando difiera de la URL normalizada, e incluya la información sobre herramientas devuelta por [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) cuando esté disponible.

### **Informar, sanear y verificar hipervínculos**

El siguiente ejemplo de JavaScript lee una presentación existente (utilice el archivo creado arriba), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar nuevamente ambos tipos de activación. Recopila contenedores antes de modificarlos y utiliza igualdad de referencia para evitar procesar el mismo contenedor dos veces. Las consultas de presentación cubren diapositivas ordinarias; para un inventario de todo el paquete, también consulta explícitamente maestros, diseños, notas y los maestros de notas y folletos cuando están presentes.

El informe registra un índice de diapositiva basado en uno y [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) cuando está disponible. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) proporciona la diapositiva propietaria para los contenedores compatibles. Los maestros, diseños y notas no tienen un índice de diapositiva ordinario y se identifican por su alcance. Los contenedores de forma y los contenedores de formato de porción de texto se etiquetan por separado; otros tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local del informe para que sus dos acciones puedan correlacionarse. El informe almacena los tipos de acción como las constantes enteras definidas por la enumeración HyperlinkActionType.

Esta política de aplicación deliberadamente restrictiva permite solo URL HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas URL. Estos rechazos son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS por sí solo no establece confianza: añada listas de permitidos de hosts y otras verificaciones para su aplicación. Se comprueban tanto las URL externas originales como las normalizadas. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) del contenedor admite [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) y [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Aquí, los enlaces de clic externos prohibidos se sustituyen por una página de destino HTTPS fija; los demás clics prohibidos y las acciones de pasar el ratón prohibidas se eliminan de forma independiente. Establezca `replaceExternalClicks` a `false` para eliminar todas las violaciones de política en su lugar. Elija una página de reemplazo controlada por la aplicación antes del despliegue.

La bandera de exportación del informe utiliza una política conservadora de revisión de PDF: marca las acciones de pasar el ratón y cualquier cosa que no sea un enlace externo o un salto a una diapositiva específica como potencialmente no compatible. Es una indicación de revisión, no una prueba de capacidad ni una garantía de que los enlaces no marcados sobrevivirán a la exportación. Las exportaciones compatibles de [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/) y [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/) pueden conservar los hipervínculos, según la acción, las opciones de exportación y el visor. Las imágenes rasterizadas [images](/slides/es/nodejs-java/convert-powerpoint-to-png/) y los [video](/slides/es/nodejs-java/convert-powerpoint-to-video/) no pueden conservar hipervínculos interactivos; marque cada acción al auditar para esas salidas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Con la entrada creada arriba, el informe contiene cinco filas de acción. El enlace de pasar el ratón de archivo y el clic de macro se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositiva permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL de clic externo prohibida también ejecuta la rama de sustitución. Un contenedor con un clic permitido y un pasar el ratón prohibido conserva su acción de clic.

Esta limpieza selectiva difiere de [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), que elimina ambos tipos de activación en todo el alcance seleccionado sin importar la política. La verificación aquí solo revisa acciones de hipervínculo; no elimina proyectos VBA incrustados, objetos OLE u otro contenido activo, y no valida un PDF o archivo HTML exportado.

## **Preguntas frecuentes**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear navegación a una sección, enlace a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a los elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en las diapositivas que usan la maestra o el diseño correspondiente.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o video?**

Las exportaciones compatibles de PDF y HTML pueden conservar los hipervínculos; las imágenes rasterizadas y el video no pueden. Consulte las consideraciones de exportación en [Informar, sanear y verificar hipervínculos](#report-sanitize-and-verify-hyperlinks).