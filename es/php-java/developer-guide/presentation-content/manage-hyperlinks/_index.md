---
title: Gestionar hipervínculos de presentación en PHP
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/php-java/manage-hyperlinks/
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
- PHP
- Aspose.Slides
description: "Añadir, formatear, actualizar y eliminar hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java, utilizando ejemplos en PHP."
---
## **Introducción**

Un hipervínculo conecta el contenido de la presentación con un sitio web o con una ubicación dentro de la presentación. En PowerPoint, los hipervínculos normalmente cumplen dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco multimedia.  
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenido.

Aspose.Slides for PHP via Java le permite agregar estos enlaces, controlar su apariencia y sonido, actualizar sus propiedades y eliminarlos. Los ejemplos siguientes muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a los hipervínculos a nivel de presentación, diapositiva o marco de texto. Se asume que PHP/Java Bridge y el contenedor de Aspose.Slides para PHP están inicializados. Los miembros de la API que no tienen una página de referencia de PHP enlazan a la API subyacente de Java.

{{% alert color="info" title="Nota" %}}
También puede editar presentaciones con el [editor gratuito en línea de Aspose PowerPoint](https://products.aspose.app/slides/es/editor).
{{% /alert %}} 

## **Agregar hipervínculos URL**

Puede asignar una URL de sitio web a texto, una forma o un marco multimedia. El elemento al que asigne el hipervínculo determina el área clicable: una porción de texto enlaza el texto seleccionado, mientras que una forma o marco enlaza el objeto de la diapositiva.

### **Agregar hipervínculos URL a texto**

Para enlazar texto a un sitio web, pase un [Hyperlink](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/) al método [setHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/sethyperlinkclick/) de la porción de texto, como se muestra a continuación. Solo esa porción de texto se vuelve clicable.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Agregar hipervínculos URL a formas y marcos multimedia**

Para que una forma o marco sea clicable, llame a su método [setHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/sethyperlinkclick/). El hipervínculo pertenece al propio objeto y no a una porción de texto dentro de él.

El mismo enfoque se aplica a marcos de imagen, audio y video: asigne el hipervínculo al marco y llame a [setTooltip](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/settooltip/) si es necesario.

El siguiente ejemplo hace que un rectángulo sea clicable:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usar hipervínculos para crear una tabla de contenido**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenido a una diapositiva específica. El siguiente ejemplo usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) para enlazar el texto “Page 2” en la primera diapositiva a la segunda diapositiva.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Formato de los hipervínculos**

### **Color**

El método [setColorSource](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/setcolorsource/) de [Hyperlink](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/) determina si un hipervínculo usa el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, seleccione [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkcolorsource/) y establezca el color de relleno de la porción. Esta característica se introdujo en PowerPoint 2019; las versiones anteriores no aplican esta configuración.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero usa un relleno de texto rojo, mientras que el segundo conserva el color de hipervínculo predeterminado.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Utilice los siguientes métodos para configurar estos comportamientos:

- [Hyperlink::setSound](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/setsound/) especifica el audio asociado al hipervínculo.  
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/setstopsoundonclick/) controla si la activación del hipervínculo detiene el sonido anterior.

#### **Agregar un sonido a un hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al hacer clic en el botón se reproduce el sonido y se avanza a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al hacer clic, sin realizar ninguna acción de navegación.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Extraer el sonido de un hipervínculo**

El siguiente ejemplo abre la presentación creada arriba y lee el audio del hipervínculo de la primera forma en memoria mediante [getSound](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/getsound/) y [getBinaryData](https://reference.aspose.com/slides/es/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Información sobre herramienta y configuraciones de interacción**

Puede llamar a los siguientes métodos de [Hyperlink](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/) después de asignar un hipervínculo a texto o a una forma:

- [setTooltip](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/settooltip/) establece el texto que el espectador puede ver como pista para el enlace.  
- [setTargetFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/settargetframe/) especifica el marco de destino dentro de un conjunto de marcos HTML padre, cuando sea aplicable.  
- [setHistory](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/sethistory/) controla si la activación del enlace añade su destino a la lista de hipervínculos vistos.  
- [setHighlightClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/sethighlightclick/) controla si el hipervínculo se resalta al hacer clic.

## **Eliminar hipervínculos de presentaciones**

Utilice [getAnyHyperlinks](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) para recopilar contenedores de hipervínculos, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar solo un tipo, invoque únicamente [removeHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); eliminar la acción de clic no elimina su contrapartida de paso del ratón.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Para una eliminación incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) elimina ambos tipos de activación en el alcance seleccionado con una sola llamada. Para una depuración selectiva que cubra maestros, diseños y notas, vea [Informar, sanear y verificar hipervínculos](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, inventaríe sus acciones interactivas así como sus enlaces web. [getAnyHyperlinks](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) devuelve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihyperlinkcontainer/), no una lista plana de cadenas URL. Examine tanto [getHyperlinkClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) como [getHyperlinkMouseOver](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear solo los hipervínculos a nivel de forma puede pasar por alto enlaces adjuntos a porciones de texto. Consulte el alcance adecuado y retenga los contenedores devueltos para poder actualizarlos o eliminarlos posteriormente.

### **Consultar alcances de presentación, diapositiva y marco de texto**

La clase [HyperlinkQueries](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/) está disponible a través de [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) y [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/gethyperlinkqueries/). Cada alcance admite las mismas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) devuelve contenedores con una acción de clic.  
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) devuelve contenedores con una acción de paso del ratón.  
- [getAnyHyperlinks](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) devuelve contenedores con cualquiera de las dos acciones.

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace externo de clic, un enlace de paso del ratón a archivo, navegación interna entre diapositivas, un enlace de paso del ratón en texto y una acción de macro. No ejecuta ninguna de estas acciones. Las tres consultas funcionan en cada alcance; los recuentos describen contenedores, no totales de acciones. El alcance de marco de texto excluye los enlaces propios de la forma contenedora.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En este ejemplo, las consultas de presentación y de diapositiva informan tres contenedores de clic, dos de paso del ratón y tres contenedores con cualquiera de las acciones. La consulta de marco de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Utilice [Hyperlink::getActionType](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/getactiontype/) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkactiontype/) cubren más que la navegación web:

| Valores | Significado para una auditoría |
| --- | --- |
| `Hyperlink` | Hipervínculo externo; inspeccione la URL y su esquema. |
| `JumpSpecificSlide` | Navegación interna a una diapositiva concreta. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegación de presentación incorporada, resuelta en contexto de presentación. |
| `JumpEndShow`, `StartCustomSlideShow` | Finalizar la presentación actual o iniciar una presentación personalizada. |
| `StartMacro` | Ejecutar una macro. |
| `StartProgram` | Iniciar un programa. |
| `OpenFile`, `OpenPresentation` | Abrir un archivo o otra presentación; revise por separado de las URL web. |
| `StartStopMedia` | Iniciar o detener reproducción de medios. |
| `NoAction`, `Unknown` | Sin acción de navegación, o acción no reconocida que requiere revisión. |

Lea destinos externos mediante [getExternalUrl](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/getexternalurl/) y destinos internos concretos mediante [getTargetSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/gettargetslide/). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor carezca de acción. Preserve el valor devuelto por [getExternalUrlOriginal](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) cuando difiera de la URL normalizada, e incluya la información sobre herramienta devuelta por [getTooltip](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlink/gettooltip/) cuando esté disponible.

### **Informar, sanear y verificar hipervínculos**

El siguiente ejemplo PHP lee una presentación existente (utilice el archivo creado arriba), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar ambos tipos de activación nuevamente. Recopila contenedores antes de modificarlos y usa igualdad de referencia para evitar procesar el mismo contenedor dos veces. Las consultas de presentación cubren diapositivas ordinarias; para un inventario a nivel de paquete, también consulta explícitamente maestros, diseños, notas y los maestros de notas y folletos cuando estén presentes.

El informe registra un índice de diapositiva basado en 1 y [getSlideId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/#getSlideId--) cuando está disponible. [ISlideComponent::getSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecomponent/#getSlide--) proporciona la diapositiva propietaria para los contenedores compatibles. Los maestros, diseños y notas no tienen un índice de diapositiva ordinario y se identifican por su alcance. Los contenedores de forma y de formato de porción de texto se etiquetan por separado; los demás tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local de informe para que sus dos acciones puedan correlacionarse. El informe almacena los tipos de acción como los valores enteros definidos por la enumeración PHP.

Esta política de aplicación deliberadamente restrictiva permite solo URL HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas de URL. Estos rechazos son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS por sí solo no establece confianza: añada listas blancas de hosts y otras comprobaciones para su aplicación. Ambas URL externas, original y normalizada, son verificadas. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [getHyperlinkManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) del contenedor soporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) y [removeHyperlinkMouseOver](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Aquí, los enlaces externos de clic prohibidos se sustituyen por una página de aterrizaje HTTPS fija; los demás clics prohibidos y acciones de paso del ratón prohibidas se eliminan de forma independiente. Establezca `$replaceExternalClicks` a `false` para eliminar todas las violaciones de política. Elija una página de reemplazo propia de la aplicación antes del despliegue.

La bandera de exportación del informe usa una política conservadora de revisión de PDF: marca acciones de paso del ratón y cualquier cosa que no sea un enlace externo o un salto específico de diapositiva como potencialmente no admitida. Es una pista de revisión, no una prueba de capacidad ni una garantía de que los enlaces no marcados sobrevivirán a la exportación. Las exportaciones admitidas a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/) y [HTML](/slides/es/php-java/convert-powerpoint-to-html/) pueden preservar hipervínculos, según la acción, las opciones de exportación y el visor. Las [imágenes](/slides/es/php-java/convert-powerpoint-to-png/) y los [videos](/slides/es/php-java/convert-powerpoint-to-video/) raster no pueden preservar hipervínculos interactivos; marque cada acción al auditar para esas salidas.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Con la entrada creada arriba, el informe contiene cinco filas de acción. El enlace de paso del ratón a archivo y la macro de clic se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositiva permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL externa de clic prohibida también ejecuta la rama de sustitución. Un contenedor con un clic permitido y un paso del ratón prohibido mantiene su acción de clic.

Esta limpieza selectiva difiere de [removeAllHyperlinks](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), que elimina ambos tipos de activación en todo el alcance seleccionado sin considerar la política. La verificación aquí solo comprueba acciones de hipervínculo; no elimina proyectos VBA incrustados, objetos OLE ni otro contenido activo, y no valida un archivo PDF o HTML exportado.

## **Preguntas frecuentes**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear una navegación a una sección, enlace a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en las diapositivas que usan la maestra o el diseño correspondiente.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?**

Las exportaciones admitidas a PDF y HTML pueden conservar hipervínculos; las imágenes raster y los vídeos no pueden. Consulte las consideraciones de exportación en [Informar, sanear y verificar hipervínculos](#report-sanitize-and-verify-hyperlinks).