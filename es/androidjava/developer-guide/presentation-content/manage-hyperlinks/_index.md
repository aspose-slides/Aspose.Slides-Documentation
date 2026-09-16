---
title: Gestionar hipervínculos de presentación en Android
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/androidjava/manage-hyperlinks/
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
- Android
- Java
- Aspose.Slides
description: "Añadir, formatear, actualizar y eliminar hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java, utilizando ejemplos en Java."
---
## **Introducción**

Un hipervínculo conecta el contenido de la presentación a un sitio web o a una ubicación dentro de la presentación. En PowerPoint, los hipervínculos normalmente cumplen dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco multimedia.
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenido.

Aspose.Slides for Android via Java permite añadir estos enlaces, controlar su apariencia y sonido, actualizar sus propiedades y eliminarlos. Los ejemplos a continuación muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a los hipervínculos a nivel de presentación, diapositiva o marco de texto.

{{% alert color="info" title="Note" %}}
También puedes editar presentaciones con el [editor gratuito en línea de Aspose PowerPoint](https://products.aspose.app/slides/es/editor).
{{% /alert %}} 

## **Agregar hipervínculos URL**

Puedes asignar una URL de sitio web a texto, una forma o un marco multimedia. El elemento al que asignas el hipervínculo determina el área clicable: una porción de texto enlaza el texto seleccionado, mientras que una forma o marco enlaza el objeto de la diapositiva.

### **Agregar hipervínculos URL a texto**

Para enlazar texto a un sitio web, pasa un [Hyperlink](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/hyperlink/) al método [setHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) de la porción de texto, como se muestra a continuación. Sólo esa porción de texto se vuelve clicable.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Agregar hipervínculos URL a formas y marcos multimedia**

Para hacer que una forma o marco sea clicable, llama a su método [setHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). El hipervínculo pertenece al propio objeto, no a una porción de texto dentro de él.

El mismo enfoque se aplica a marcos de imágenes, audio y vídeo: asigna el hipervínculo al marco y llama a [setTooltip](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) si es necesario.

El siguiente ejemplo hace que un rectángulo sea clicable:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usar hipervínculos para crear una tabla de contenido**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenido a una diapositiva específica. El siguiente ejemplo usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) para enlazar el texto “Page 2” de la primera diapositiva a la segunda diapositiva.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formato de hipervínculos**

### **Color**

El método [setColorSource](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) de [IHyperlink](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/) determina si un hipervínculo usa el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, selecciona [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/hyperlinkcolorsource/) y establece el color de relleno de la porción. Esta característica se introdujo en PowerPoint 2019; las versiones anteriores no aplican este ajuste.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero usa un relleno de texto rojo, mientras que el segundo mantiene el color de hipervínculo predeterminado.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Usa los siguientes métodos para configurar estos comportamientos:

- [IHyperlink.setSound](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) especifica el audio asociado al hipervínculo.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) controla si al activar el hipervínculo se detiene el sonido previo.

#### **Agregar un sonido al hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al pulsar el botón se reproduce el sonido y se avanza a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al pulsarse, sin realizar una acción de navegación.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Extraer un sonido de hipervínculo**

El siguiente ejemplo abre la presentación creada arriba y lee el audio del hipervínculo de la primera forma en memoria mediante [getSound](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#getSound--) y [getBinaryData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Configuración de información sobre herramientas e interacción**

Puedes llamar a los siguientes métodos de [IHyperlink](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/) después de asignar un hipervínculo a texto o a una forma:

- [setTooltip](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) establece el texto que un visor puede mostrar como pista para el enlace.
- [setTargetFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) especifica el marco de destino dentro de un frameset HTML padre, cuando corresponda.
- [setHistory](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) controla si al activar el enlace se añade su destino a la lista de hipervínculos vistos.
- [setHighlightClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) controla si el hipervínculo se resalta al hacer clic.

## **Eliminar hipervínculos de presentaciones**

Utiliza [getAnyHyperlinks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) para recopilar los contenedores de hipervínculos, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar sólo un tipo, llama únicamente a [removeHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) o a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); eliminar una acción de clic no elimina su contraparte de pasar el ratón.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Para una eliminación incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) elimina ambos tipos de activación en el ámbito seleccionado con una sola llamada. Para una limpieza selectiva y cobertura de maestros, diseños y notas, consulta [Informe, saneado y verificación de hipervínculos](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, inventaría sus acciones interactivas y sus enlaces web. [getAnyHyperlinks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) devuelve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkcontainer/), no una lista plana de cadenas URL. Inspecciona tanto [getHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) como [getHyperlinkMouseOver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear sólo los hipervínculos a nivel de forma puede pasar por alto enlaces adjuntos a porciones de texto. Consulta el ámbito apropiado en su lugar y conserva los contenedores devueltos para poder actualizarlos o eliminarlos más tarde.

### **Consultar los ámbitos de presentación, diapositiva y marco de texto**

La interfaz [IHyperlinkQueries](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/) está disponible a través de [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) y [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Cada ámbito admite las mismas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) devuelve contenedores con una acción de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) devuelve contenedores con una acción de pasar el ratón.
- [getAnyHyperlinks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) devuelve contenedores con cualquiera de las dos acciones o ambas.

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace de clic externo, un enlace de pasar el ratón a un archivo, navegación interna de diapositiva, un enlace de pasar el ratón en texto y una acción de macro. No ejecuta ninguna de estas acciones. Las mismas tres consultas funcionan en cada ámbito; los recuentos describen contenedores, no totales de acciones. El ámbito de marco de texto excluye los enlaces propios de la forma contenedora.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para este ejemplo, las consultas de presentación y diapositiva informan tres contenedores de clic, dos de pasar el ratón y tres contenedores con cualquiera de las acciones. La consulta de marco de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Utiliza [IHyperlink.getActionType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#getActionType--) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/hyperlinkactiontype/) abarcan más que la navegación web:

| Valores | Significado para una auditoría |
| --- | --- |
| `Hyperlink` | Hipervínculo externo; inspeccionar la URL y su esquema. |
| `JumpSpecificSlide` | Navegación interna a una diapositiva concreta. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegación interna de la presentación incorporada, resuelta en el contexto de la presentación. |
| `JumpEndShow`, `StartCustomSlideShow` | Finaliza la presentación actual o inicia una presentación personalizada. |
| `StartMacro` | Ejecutar una macro. |
| `StartProgram` | Iniciar un programa. |
| `OpenFile`, `OpenPresentation` | Abrir un archivo u otra presentación; revisarlo por separado de las URL web. |
| `StartStopMedia` | Iniciar o detener la reproducción de medios. |
| `NoAction`, `Unknown` | Sin acción de navegación, o una acción no reconocida que requiere revisión. |

Lee destinos externos con [getExternalUrl](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) y destinos internos específicos con [getTargetSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor carezca de acción. Conserva el valor devuelto por [getExternalUrlOriginal](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) cuando difiere de la URL normalizada, e incluye la información sobre herramientas devuelta por [getTooltip](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) cuando esté disponible.

### **Informe, saneado y verificación de hipervínculos**

El siguiente ejemplo Java lee una presentación existente (usa el archivo creado arriba), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar nuevamente ambos tipos de activación. Recopila contenedores antes de modificarlos y usa igualdad de referencia para evitar procesar el mismo contenedor dos veces. Las consultas de presentación cubren diapositivas ordinarias; para un inventario a nivel de paquete, también consulta explícitamente maestros, diseños, notas y los maestros de notas y folletos cuando están presentes.

El informe registra un índice de diapositiva basado en uno y [getSlideId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) cuando está disponible. [ISlideComponent.getSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecomponent/#getSlide--) proporciona la diapositiva propietaria para los contenedores compatibles. Los maestros, diseños y notas no tienen un índice de diapositiva ordinario y se identifican por su ámbito. Los contenedores de forma y los de formato de porción de texto se etiquetan por separado; otros tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local de informe para que sus dos acciones puedan correlacionarse. El informe almacena los tipos de acción como las constantes enteras definidas por la enumeración Java.

Esta política de aplicación deliberadamente restrictiva permite sólo URL HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas de URL. Estos rechazos son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS por sí solo no establece confianza: agrega listas de permitidos de host y otras comprobaciones para tu aplicación. Se verifican tanto las URL externas originales como las normalizadas. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [getHyperlinkManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) del contenedor admite [setExternalHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) y [removeHyperlinkMouseOver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Aquí, los enlaces de clic externos prohibidos se reemplazan por una página de destino HTTPS fija; los demás clics y acciones de pasar el ratón prohibidos se eliminan de forma independiente. Establece `replaceExternalClicks` a `false` para eliminar todas las violaciones de política. Elige una página de reemplazo gestionada por la aplicación antes del despliegue.

La bandera de exportación del informe usa una política conservadora de revisión de PDF: marca acciones de pasar el ratón y cualquier cosa que no sea un enlace externo o un salto a diapositiva específica como potencialmente no soportada. Es una pista de revisión, no una prueba de capacidad ni una garantía de que los enlaces no marcados sobrevivirán a la exportación. Las exportaciones compatibles de [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/) y [HTML](/slides/es/androidjava/convert-powerpoint-to-html/) pueden conservar hipervínculos, según la acción, las opciones de exportación y el visor. Las imágenes rasterizadas [images](/slides/es/androidjava/convert-powerpoint-to-png/) y [video](/slides/es/androidjava/convert-powerpoint-to-video/) no pueden preservar hipervínculos interactivos; marca cada acción al auditar esos resultados.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serializa las filas planas de este informe sin una dependencia JSON adicional.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Con la entrada creada arriba, el informe contiene cinco filas de acción. El enlace de pasar el ratón a archivo y el clic de macro se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositiva permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL de clic externo prohibida también activa la rama de reemplazo. Un contenedor con un clic permitido y un pasar el ratón prohibido conserva su acción de clic.

Esta limpieza selectiva difiere de [removeAllHyperlinks](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), que elimina ambos tipos de activación en todo el ámbito seleccionado sin considerar la política. La verificación aquí solo revisa acciones de hipervínculo; no elimina proyectos VBA incrustados, objetos OLE u otro contenido activo, y no valida un archivo PDF o HTML exportado.

## **Preguntas frecuentes**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear una navegación a una sección, enlaza a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en las diapositivas que usan la maestra o el diseño correspondiente.

**¿Se conservan los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?**

Las exportaciones de PDF y HTML compatibles pueden conservar hipervínculos; las imágenes raster y el vídeo no pueden. Consulta las consideraciones de exportación en [Informe, saneado y verificación de hipervínculos](#report-sanitize-and-verify-hyperlinks).