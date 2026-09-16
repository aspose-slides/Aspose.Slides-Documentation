---
title: Gestionar hipervínculos de presentación en .NET
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/net/manage-hyperlinks/
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
- .NET
- C#
- Aspose.Slides
description: "Añada, formatee, actualice y elimine hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET, usando ejemplos en C#."
---
## **Introducción**

Un hipervínculo conecta el contenido de la presentación con un sitio web o una ubicación dentro de la presentación. En PowerPoint, los hipervínculos suelen servir dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco multimedia.
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenidos.

Aspose.Slides para .NET le permite añadir estos enlaces, controlar su apariencia y sonido, actualizar sus propiedades y eliminarlos. Los ejemplos a continuación muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a hipervínculos a nivel de presentación, diapositiva o marco de texto.

{{% alert color="info" title="Nota" %}}
También puede editar presentaciones con el [editor gratuito en línea de Aspose PowerPoint](https://products.aspose.app/slides/es/editor).
{{% /alert %}} 

## **Añadir hipervínculos URL**

Puede asignar una URL de sitio web a texto, una forma o un marco multimedia. El elemento al que asigna el hipervínculo determina el área clicable: una porción de texto enlaza el texto seleccionado, mientras que una forma o un marco enlaza el objeto de la diapositiva.

### **Añadir hipervínculos URL a texto**

Para enlazar texto a un sitio web, asigne un [Hyperlink](https://reference.aspose.com/slides/es/net/aspose.slides/hyperlink/) a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/portionformat/hyperlinkclick/) de la porción de texto, como se muestra a continuación. Sólo esa porción de texto se vuelve clicable.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Añadir hipervínculos URL a formas y marcos multimedia**

Para que una forma o un marco sea clicable, establezca su propiedad [HyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/shape/hyperlinkclick/). El hipervínculo pertenece al propio objeto y no a una porción de texto dentro de él.

El mismo enfoque se aplica a marcos de imagen, audio y video: asigne el hipervínculo al marco y, si es necesario, establezca el [Tooltip](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/tooltip/) del enlace.

El siguiente ejemplo hace que un rectángulo sea clicable:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Usar hipervínculos para crear una tabla de contenidos**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenidos a una diapositiva específica. El siguiente ejemplo utiliza [SetInternalHyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) para enlazar el texto “Página 2” de la primera diapositiva a la segunda diapositiva.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Formato de hipervínculos**

### **Color**

La propiedad [ColorSource](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/colorsource/) de [IHyperlink](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/) determina si un hipervínculo usa el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, seleccione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/hyperlinkcolorsource/) y establezca el color de relleno de la porción. Esta función se introdujo en PowerPoint 2019; versiones anteriores no aplican esta configuración.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero usa un relleno de texto rojo, mientras que el segundo mantiene el color de hipervínculo predeterminado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Utilice las siguientes propiedades para configurar estos comportamientos:

- [IHyperlink.Sound](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/sound/) especifica el audio asociado al hipervínculo.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/stopsoundonclick/) controla si al activar el hipervínculo se detiene el sonido anterior.

#### **Añadir un sonido a un hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al pulsar el botón se reproduce el sonido y se navega a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al pulsarse, sin realizar ninguna acción de navegación.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Extraer un sonido de hipervínculo**

El siguiente ejemplo abre la presentación creada arriba y lee el audio del hipervínculo de la primera forma en memoria mediante [Sound](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/sound/) y [BinaryData](https://reference.aspose.com/slides/es/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip y ajustes de interacción**

Puede actualizar las siguientes propiedades de [IHyperlink](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/) después de asignar un hipervínculo a texto o a una forma:

- [Tooltip](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/tooltip/) define el texto que el visor puede mostrar como pista para el enlace.
- [TargetFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/targetframe/) especifica el marco de destino dentro de un conjunto de marcos HTML padre, cuando sea aplicable.
- [History](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/history/) controla si al activar el enlace se añade su destino a la lista de hipervínculos vistos.
- [HighlightClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/highlightclick/) controla si el hipervínculo se resalta al pulsarse.

## **Eliminar hipervínculos de presentaciones**

Utilice [GetAnyHyperlinks](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) para recopilar contenedores de hipervínculo, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar sólo un tipo, invoque únicamente [RemoveHyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) o [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); eliminar una acción de clic no elimina su contraparte de paso del ratón.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Para una eliminación incondicional, [RemoveAllHyperlinks](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) elimina ambos tipos de activación en el ámbito seleccionado en una sola llamada. Para una depuración selectiva y cobertura de maestros, diseños y notas, consulte [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, inventarie sus acciones interactivas así como sus enlaces web. [GetAnyHyperlinks](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) devuelve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkcontainer/), no una lista plana de cadenas URL. Inspeccione tanto [HyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) como [HyperlinkMouseOver](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear sólo hipervínculos a nivel de forma puede pasar por alto enlaces adjuntos a porciones de texto. Consulte el ámbito apropiado y conserve los contenedores devueltos para poder actualizarlos o eliminarlos después.

### **Consultar ámbitos de presentación, diapositiva y marco de texto**

La interfaz [IHyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/) está disponible a través de [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/hyperlinkqueries/) y [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/hyperlinkqueries/). Cada ámbito soporta las mismas consultas:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) devuelve contenedores con una acción de clic.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) devuelve contenedores con una acción de paso del ratón.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) devuelve contenedores con cualquiera de las dos acciones o con ambas.

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace de clic externo, un enlace de paso del ratón a archivo, navegación interna de diapositiva, un enlace de paso del ratón en texto y una acción de macro. No ejecuta ninguna de estas acciones. Las tres consultas funcionan en cada ámbito; los recuentos describen contenedores, no totales de acciones. El ámbito del marco de texto excluye los enlaces propios de la forma que lo contiene.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Para este ejemplo, las consultas de presentación y de diapositiva informan tres contenedores de clic, dos de paso del ratón y tres contenedores con cualquiera de las dos acciones. La consulta de marco de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Use [IHyperlink.ActionType](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/actiontype/) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/es/net/aspose.slides/hyperlinkactiontype/) cubren más que la navegación web:

| Valores | Significado para una auditoría |
| --- | --- |
| `Hyperlink` | Hipervínculo externo; inspeccione la URL y su esquema. |
| `JumpSpecificSlide` | Navegación interna a una diapositiva concreta. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegación incorporada de la presentación, resuelta en contexto de presentación. |
| `JumpEndShow`, `StartCustomSlideShow` | Finaliza la presentación actual o inicia una presentación personalizada. |
| `StartMacro` | Ejecuta una macro. |
| `StartProgram` | Inicia un programa. |
| `OpenFile`, `OpenPresentation` | Abre un archivo u otra presentación; revíselo por separado de las URLs web. |
| `StartStopMedia` | Inicia o detiene la reproducción de medios. |
| `NoAction`, `Unknown` | No hay acción de navegación, o una acción no reconocida que requiere revisión. |

Lea destinos externos desde [ExternalUrl](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/externalurl/) y destinos internos específicos desde [TargetSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/targetslide/). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor carezca de acción. Preserve [ExternalUrlOriginal](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/externalurloriginal/) cuando difiera de la URL normalizada e incluya el [Tooltip](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/tooltip/) cuando esté disponible.

### **Informar, sanitizar y verificar hipervínculos**

El siguiente ejemplo .NET 6+ lee una presentación existente (utilice el archivo creado arriba), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar nuevamente ambos tipos de activación. Recopila contenedores antes de modificarlos y usa igualdad de referencia para evitar procesar el mismo contenedor dos veces. Las consultas de presentación cubren diapositivas ordinarias; para un inventario a nivel de paquete también consulta explícitamente maestros, diseños, notas y los maestros de notas y folletos cuando estén presentes.

El informe registra un índice de diapositiva basado en 1 y [SlideId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/slideid/) cuando está disponible. [ISlideComponent.Slide](https://reference.aspose.com/slides/es/net/aspose.slides/islidecomponent/slide/) proporciona la diapositiva propietaria para los contenedores compatibles. Los maestros, diseños y notas no tienen índice de diapositiva ordinario y se identifican por su ámbito. Los contenedores de forma y los de formato de porción de texto se etiquetan por separado; otros tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local al informe para que sus dos acciones puedan correlacionarse.

Esta política de aplicación deliberadamente restrictiva permite sólo URLs HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas de URL. Estos rechazos son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS solo no establece confianza: añada listas blancas de hosts y otras comprobaciones para su aplicación. Tanto las URLs externas originales como las normalizadas se comprueban. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [HyperlinkManager](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) del contenedor soporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) y [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Aquí, los enlaces de clic externos prohibidos se sustituyen por una página de destino HTTPS fija; los demás clics y acciones de paso del ratón prohibidos se eliminan de forma independiente. Establezca `replaceExternalClicks` a `false` para eliminar todas las violaciones de política. Elija una página de sustitución propia de la aplicación antes del despliegue.

La bandera de exportación del informe usa una política conservadora de revisión PDF: marca acciones de paso del ratón y cualquier cosa que no sea un enlace externo o un salto a diapositiva específica como potencialmente no soportada. Es una pista de revisión, no una prueba de capacidad o una garantía de que los enlaces no marcados sobrevivirán a la exportación. Las exportaciones compatibles a [PDF](/slides/es/net/convert-powerpoint-to-pdf/) y [HTML](/slides/es/net/convert-powerpoint-to-html/) pueden preservar hipervínculos, según la acción, las opciones de exportación y el visor. Las [imágenes](/slides/es/net/convert-powerpoint-to-png/) y los [videos](/slides/es/net/convert-powerpoint-to-video/) rasterizados no pueden preservar hipervínculos interactivos; marque cada acción al auditar para esas salidas.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Con la entrada creada arriba, el informe contiene cinco filas de acción. El enlace de paso del ratón a archivo y la macro de clic se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositiva permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL de clic externo prohibida también ejerce la rama de sustitución. Un contenedor con un clic permitido y un paso del ratón prohibido conserva su acción de clic.

Esta limpieza selectiva difiere de [RemoveAllHyperlinks](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), que elimina ambos tipos de activación en todo el ámbito seleccionado sin importar la política. La verificación aquí solo revisa acciones de hipervínculo; no elimina proyectos VBA incrustados, objetos OLE u otro contenido activo, y no valida un archivo PDF o HTML exportado.

## **FAQ**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear navegación a una sección, enlace a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en las diapositivas que usan la maestra o el diseño correspondiente.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?**

Las exportaciones soportadas a PDF y HTML pueden conservar hipervínculos; las imágenes raster y el vídeo no pueden. Consulte las consideraciones de exportación en [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).