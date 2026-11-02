---
title: Gestionar hipervínculos de presentación en C++
linktitle: Gestionar hipervínculos
type: docs
weight: 20
url: /es/cpp/manage-hyperlinks/
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
- C++
- Aspose.Slides
description: "Añadir, formatear, actualizar y eliminar hipervínculos en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para C++, utilizando ejemplos en C++."
---
## **Introducción**

Un hipervínculo conecta el contenido de la presentación con un sitio web o una ubicación dentro de la presentación. En PowerPoint, los hipervínculos suelen servir a dos propósitos:

* Abrir un sitio web desde texto, una forma o un marco multimedia.
* Navegar a otra diapositiva, por ejemplo, desde una tabla de contenido.

Aspose.Slides for C++ le permite agregar estos enlaces, controlar su apariencia y sonido, actualizar sus configuraciones y eliminarlos. Los ejemplos a continuación muestran cómo trabajar con hipervínculos en elementos individuales y cómo acceder a los hipervínculos a nivel de presentación, diapositiva o marco de texto.

{{% alert color="info" title="Note" %}}
También puede editar presentaciones con el [editor de PowerPoint de Aspose en línea gratuito](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Agregar hipervínculos URL**

Puede asignar una URL de sitio web a texto, una forma o un marco multimedia. El elemento al que asigna el hipervínculo determina el área clicable: una porción de texto vincula el texto seleccionado, mientras que una forma o un marco vincula el objeto de la diapositiva.

Para presentaciones que contengan hipervínculos relativos, consulte [Gestionar la base de hipervínculos](/slides/es/cpp/presentation-properties/#manage-the-hyperlink-base) para leer, cambiar o borrar la base a nivel de documento.

### **Agregar hipervínculos URL a texto**

Para enlazar texto a un sitio web, cree un [Hipervínculo](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) y asígnele mediante el método [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) de la porción de texto, como se muestra a continuación. Sólo esa porción de texto se vuelve clicable.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Agregar hipervínculos URL a formas y marcos multimedia**

Para hacer que una forma o un marco sea clicable, use su método [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/). El hipervínculo pertenece al propio objeto y no a una porción de texto dentro de él.

El mismo enfoque se aplica a marcos de imagen, audio y vídeo: asigne el hipervínculo al marco y use [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) para añadir una sugerencia si es necesario.

El siguiente ejemplo hace que un rectángulo sea clicable:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Usar hipervínculos para crear una tabla de contenido**

Los hipervínculos internos permiten a los lectores saltar de una tabla de contenido a una diapositiva específica. El siguiente ejemplo usa [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) para enlazar el texto “Page 2” en la primera diapositiva a la segunda diapositiva.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Formato de hipervínculos**

### **Color**

El método [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) de [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) determina si un hipervínculo utiliza el color de hipervínculo de la presentación o el formato de la porción de texto. Para aplicar un color de texto personalizado, seleccione [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) y establezca el color de relleno de la porción. Esta función se introdujo en PowerPoint 2019; las versiones anteriores no aplican esta configuración.

El siguiente ejemplo añade dos hipervínculos de texto a la misma diapositiva. El primero usa un relleno de texto rojo, mientras que el segundo mantiene el color de hipervínculo predeterminado.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **Sonido**

Un hipervínculo puede reproducir un sonido al activarse o detener un sonido que ya se está reproduciendo. Utilice los siguientes métodos para configurar estos comportamientos:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) especifica el audio asociado al hipervínculo.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) controla si al activar el hipervínculo se detiene el sonido anterior.

#### **Agregar un sonido al hipervínculo**

El siguiente ejemplo carga `sampleaudio.wav` y lo asocia a un botón en la primera diapositiva. Al hacer clic en el botón se reproduce el sonido y se navega a la siguiente diapositiva. Una segunda forma en esa diapositiva detiene el sonido anterior al hacer clic, sin realizar una acción de navegación.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Extraer un sonido de hipervínculo**

El siguiente ejemplo abre la presentación creada arriba y lee el audio de hipervínculo de la primera forma en memoria mediante [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) y [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Información sobre herramienta y configuraciones de interacción**

Puede actualizar las siguientes configuraciones de [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) mediante estos métodos después de asignar un hipervínculo a texto o a una forma:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) establece el texto que un visor puede mostrar como pista para el enlace.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) especifica el marco de destino dentro de un conjunto de marcos HTML padre, cuando sea aplicable.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) controla si al activar el enlace se añade su destino a la lista de hipervínculos vistos.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) controla si el hipervínculo se resalta al hacer clic.

## **Eliminar hipervínculos de presentaciones**

Utilice [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) para recopilar contenedores de hipervínculos, incluidos los enlaces de porciones de texto, antes de modificarlos. El siguiente ejemplo elimina ambos tipos de activación de la primera diapositiva. Para eliminar sólo un tipo, llame únicamente a [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) o a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); eliminar una acción de clic no elimina su contraparte de pasar el ratón.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Para una eliminación incondicional, [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) elimina ambos tipos de activación en el ámbito seleccionado en una sola llamada. Para una limpieza selectiva y cobertura de maestros, diseños y notas, consulte [Informar, sanear y verificar hipervínculos](#report-sanitize-and-verify-hyperlinks).

## **Crear un inventario completo de hipervínculos**

Antes de distribuir una presentación, inventarié sus acciones interactivas así como sus enlaces web. [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) devuelve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/), no una lista plana de cadenas URL. Inspeccione tanto [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) como [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) en cada contenedor. Son independientes: el mismo contenedor puede exponer ambas acciones, por lo que un informe completo necesita hasta dos filas por contenedor.

Escanear sólo los hipervínculos a nivel de forma puede perder enlaces adjuntos a porciones de texto. Consulte el ámbito apropiado en su lugar y conserve los contenedores devueltos para que luego pueda actualizar o eliminar sus acciones.

### **Consultar ámbitos de presentación, diapositiva y marco de texto**

La interfaz [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) está disponible a través de [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) y [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Cada ámbito soporta las mismas consultas:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) devuelve contenedores con una acción de clic.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) devuelve contenedores con una acción de pasar el ratón.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) devuelve contenedores con una o ambas acciones.

El siguiente ejemplo crea `hyperlink-audit-input.pptx` con un enlace de clic externo, un enlace de pasar el ratón a un archivo, navegación interna de diapositivas, un enlace de pasar el ratón en texto y una acción de macro. No ejecuta ninguna de estas acciones. Las mismas tres consultas funcionan en todos los ámbitos; los recuentos describen contenedores, no totales de acciones. El ámbito de marco de texto excluye los propios enlaces de la forma que lo contiene.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Para este ejemplo, las consultas de presentación y diapositiva informan cada una tres contenedores de clic, dos contenedores de pasar el ratón y tres contenedores con cualquiera de las acciones. La consulta de marco de texto informa un contenedor en cada categoría.

### **Clasificar acciones y destinos**

Utilice [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) para interpretar una acción antes de interpretar su destino. Los valores de [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) abarcan más que la navegación web:

| Valores | Significado para una auditoría |
| --- | --- |
| `Hyperlink` | Hipervínculo externo; inspeccione la URL y su esquema. |
| `JumpSpecificSlide` | Navegación interna a una diapositiva concreta. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegación incorporada de la presentación, resuelta en contexto de presentación. |
| `JumpEndShow`, `StartCustomSlideShow` | Finaliza la presentación actual o inicia una presentación personalizada. |
| `StartMacro` | Ejecuta una macro. |
| `StartProgram` | Inicia un programa. |
| `OpenFile`, `OpenPresentation` | Abre un archivo u otra presentación; revíselo por separado de URLs web. |
| `StartStopMedia` | Inicia o detiene la reproducción de medios. |
| `NoAction`, `Unknown` | No hay acción de navegación, o una acción no reconocida que requiera revisión. |

Lea destinos externos mediante [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) y destinos internos específicos mediante [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). Las acciones internas y los comandos incorporados pueden no tener URL externa; una URL vacía no significa que el contenedor no tenga acción. Preserve [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) cuando difiera de la URL normalizada, e incluya la información sobre herramienta devuelta por [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) cuando esté disponible.

### **Informar, sanear y verificar hipervínculos**

El siguiente ejemplo en C++ lee una presentación existente (use el archivo creado arriba), escribe `hyperlink-audit.json`, aplica una política, guarda `hyperlink-sanitized.pptx` y la vuelve a abrir para comprobar nuevamente ambos tipos de activación. Recopila contenedores antes de modificarlos y usa la identidad de punteros para evitar procesar el mismo contenedor dos veces. Las consultas de presentación cubren diapositivas ordinarias; para un inventario a nivel de paquete, también consulta explícitamente maestros, diseños, notas y los maestros de notas y folletos cuando están presentes.

El informe registra un índice de diapositiva basado en uno y [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) cuando está disponible. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) proporciona la diapositiva propietaria para los contenedores admitidos. Los maestros, diseños y notas no tienen un índice de diapositiva ordinario y se identifican por su ámbito. Los contenedores de forma y los contenedores de formato de porción de texto se etiquetan por separado; otros tipos de contenedor conservan su nombre de tipo en tiempo de ejecución. Cada contenedor recibe un ID local del informe para que sus dos acciones puedan correlacionarse.

Esta política de aplicación deliberadamente restrictiva permite sólo URLs HTTPS absolutas y destinos internos de diapositiva válidos. Rechaza macros, programas, acciones de archivo, otras acciones de presentación, acciones desconocidas y otros esquemas de URL. Estos rechazos son decisiones de política, no un veredicto de seguridad de Aspose.Slides. HTTPS solo no establece confianza: añada listas de hosts permitidos y otras comprobaciones para su aplicación. Tanto las URLs externas originales como las normalizadas se verifican. El ejemplo audita metadatos sin seguir enlaces ni ejecutar acciones.

Para la remediación, el [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) del contenedor soporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) y [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Aquí, los enlaces de clic externos prohibidos se sustituyen por una página de destino HTTPS fija; otros clics prohibidos y acciones de pasar el ratón prohibidas se eliminan de forma independiente. Establezca `replaceExternalClicks` a `false` para eliminar todas las violaciones de política en su lugar. Elija una página de reemplazo propietaria de la aplicación antes del despliegue.

La bandera de exportación del informe utiliza una política conservadora de revisión de PDF: marca acciones de pasar el ratón y cualquier cosa que no sea un enlace externo o un salto a una diapositiva específica como potencialmente no soportada. Es una pista de revisión, no una prueba de capacidad o garantía de que los enlaces no marcados sobrevivirán a la exportación. Las exportaciones compatibles de [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/) y [HTML](/slides/es/cpp/convert-powerpoint-to-html/) pueden conservar los hipervínculos, según la acción, las opciones de exportación y el visor. Las [imágenes](/slides/es/cpp/convert-powerpoint-to-png/) y [vídeo](/slides/es/cpp/convert-powerpoint-to-video/) raster no pueden preservar hipervínculos interactivos; marque cada acción al auditar para esas salidas.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Con la entrada creada arriba, el informe contiene cinco filas de acción. El enlace de pasar el ratón a archivo y el clic de macro se eliminan, mientras que los enlaces HTTPS y la navegación interna de diapositivas permanecen. La verificación muestra cero acciones prohibidas. Una entrada que contiene una URL de clic externo prohibida también ejecuta la rama de sustitución. Un contenedor con un clic permitido y un pasar el ratón prohibido conserva su acción de clic.

Esta limpieza selectiva difiere de [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), que elimina ambos tipos de activación en todo el ámbito seleccionado sin importar la política. La verificación aquí comprueba sólo las acciones de hipervínculo; no elimina proyectos VBA incrustados, objetos OLE u otro contenido activo, y no valida un archivo PDF o HTML exportado.

## **Preguntas frecuentes**

**¿Cómo puedo enlazar a una sección o a su primera diapositiva?**

Las secciones en PowerPoint agrupan diapositivas, pero un hipervínculo interno apunta a una diapositiva individual. Para crear una navegación a una sección, enlaza a la primera diapositiva de esa sección.

**¿Puedo adjuntar un hipervínculo a elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de diapositiva maestra y de diseño soportan hipervínculos. Los enlaces en estos elementos están disponibles durante la presentación en diapositivas que usan la maestra o el diseño correspondiente.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?**

Las exportaciones compatibles a PDF y HTML pueden conservar los hipervínculos; las imágenes raster y el vídeo no pueden. Consulte las consideraciones de exportación en [Informar, sanear y verificar hipervínculos](#report-sanitize-and-verify-hyperlinks).