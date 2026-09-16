---
title: Verwalten von Präsentations-Hyperlinks in C++
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/cpp/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Hinzufügen, Formatieren, Aktualisieren und Entfernen von Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ anhand von C++-Beispielen."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnen einer Website über Text, eine Form oder einen Medienrahmen.
* Navigieren zu einer anderen Folie, beispielsweise von einem Inhaltsverzeichnis.

Aspose.Slides for C++ ermöglicht das Hinzufügen dieser Links, das Steuern von Aussehen und Klang, das Aktualisieren ihrer Einstellungen und das Entfernen. Die nachstehenden Beispiele zeigen, wie man mit Hyperlinks auf einzelnen Elementen arbeitet und wie man Hyperlinks auf Ebene der Präsentation, Folie oder des Text‑Frames abruft.

{{% alert color="info" title="Hinweis" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online‑Aspose‑PowerPoint‑Editor](https://products.aspose.app/slides/de/editor) bearbeiten.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

Sie können einer Webseite eine URL zuweisen, die an Text, einer Form oder einem Medienrahmen angehängt wird. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verknüpfen, erstellen Sie einen [Hyperlink](https://reference.aspose.com/slides/de/cpp/aspose.slides/hyperlink/) und weisen ihn über die Methode [set_HyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/portionformat/set_hyperlinkclick/) des Textabschnitts zu, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

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

### **URL‑Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, verwenden Sie deren Methode [set_HyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/set_hyperlinkclick/). Der Hyperlink gehört zum Objekt selbst und nicht zu einem Textabschnitt darin.

Der gleiche Ansatz gilt für Bild‑, Audio‑ und Video‑Rahmen: Vergeben Sie den Hyperlink dem Rahmen und verwenden Sie [set_Tooltip](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_tooltip/), um bei Bedarf einen Hinweis hinzuzufügen.

Das folgende Beispiel macht ein Rechteck anklickbar:

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

## **Hyperlinks zur Erstellung eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es Lesern, vom Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [SetInternalHyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

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

## **Hyperlinks formatieren**

### **Farbe**

Die Methode [set_ColorSource](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_colorsource/) von [IHyperlink](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen unterstützen diese Einstellung nicht.

Das folgende Beispiel fügt zwei Text‑Hyperlinks zur selben Folie hinzu. Der erste verwendet eine rote Textfüllung, der zweite behält die Standard‑Hyperlink‑Farbe bei.

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
### **Klang**

Ein Hyperlink kann beim Aktivieren einen Klang abspielen oder einen bereits spielenden Klang stoppen. Verwenden Sie die folgenden Methoden, um dieses Verhalten zu konfigurieren:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_sound/) legt die dem Hyperlink zugeordnete Audiodatei fest.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) bestimmt, ob das Aktivieren des Hyperlinks den vorherigen Klang stoppt.

#### **Hyperlink‑Klang hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft sie mit einem Button auf der ersten Folie. Ein Klick auf den Button spielt den Klang ab und navigiert zur nächsten Folie. Eine zweite Form auf derselben Folie stoppt den vorherigen Klang, ohne eine Navigation auszuführen.

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

#### **Hyperlink‑Klang extrahieren**

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest den Hyperlink‑Audio‑Stream der ersten Form über [get_Sound](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/get_sound/) und [get_BinaryData](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudio/get_binarydata/) in den Speicher ein.

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

### **Tooltip‑ und Interaktionseinstellungen**

Sie können die folgenden [IHyperlink](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/)‑Einstellungen nach dem Zuweisen eines Hyperlinks zu Text oder einer Form über die jeweiligen Methoden aktualisieren:

- [set_Tooltip](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_tooltip/) legt den Hinweistext fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [set_TargetFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_targetframe/) gibt bei Bedarf den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an.
- [set_History](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_history/) steuert, ob das Aktivieren des Links sein Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [set_HighlightClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/set_highlightclick/) legt fest, ob der Hyperlink beim Klick hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [GetAnyHyperlinks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/), um Hyperlink‑Container, einschließlich Text‑Abschnitts‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [RemoveHyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) oder [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) auf; das Entfernen einer Klick‑Aktion entfernt nicht deren Mouse‑Over‑Gegenstück.

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

Für uneingeschränktes Entfernen entfernt [RemoveAllHyperlinks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) beide Aktivierungstypen im ausgewählten Geltungsbereich in einem Aufruf. Für selektive Aufräum‑ und Abdeckungsarbeiten von Master‑, Layout‑ und Notiz‑Folien siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie deren interaktive Aktionen sowie deren Web‑Links. [GetAnyHyperlinks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) liefert Objekte vom Typ [IHyperlinkContainer](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkcontainer/), nicht eine flache Liste von URL‑Strings. Prüfen Sie sowohl [get_HyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) als auch [get_HyperlinkMouseOver](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) jedes Containers. Sie sind unabhängig: derselbe Container kann beide Aktionen bereitstellen, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das reine Abfragen von Shape‑Level‑Hyperlinks kann Links übersehen, die an Text‑Abschnitten hängen. Fragen Sie stattdessen den entsprechenden Geltungsbereich ab und behalten Sie die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Präsentations‑, Folien‑ und Text‑Frame‑Bereiche abfragen**

Das Interface [IHyperlinkQueries](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/) ist über [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) und [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) verfügbar. Jeder Geltungsbereich unterstützt dieselben Abfragen:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) liefert Container mit einer Klick‑Aktion.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) liefert Container mit einer Mouse‑Over‑Aktion.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) liefert Container mit einer oder beiden Aktionen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Mouse‑Over‑Link, einer internen Folien‑Navigation, einem Text‑Mouse‑Over‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Geltungsbereich; die Zählungen beziehen sich auf Container, nicht auf Gesamtaktionen. Der Text‑Frame‑Geltungsbereich schließt die eigenen Links des umgebenden Shapes aus.

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

Für dieses Beispiel melden die Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Mouse‑Over‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet jeweils einen Container pro Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [IHyperlink::get_ActionType](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/get_actiontype/), um eine Aktion zu interpretieren, bevor Sie ihr Ziel auswerten. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/cpp/aspose.slides/hyperlinkactiontype/) decken mehr als nur Web‑Navigation ab:

| Werte | Bedeutung für das Audit |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; prüfen Sie die URL und ihr Schema. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Folien‑Navigation, im Präsentations‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Aktuelle Show beenden bzw. benutzerdefinierte Show starten. |
| `StartMacro` | Makro ausführen. |
| `StartProgram` | Programm starten. |
| `OpenFile`, `OpenPresentation` | Datei oder andere Präsentation öffnen; gesondert von Web‑URLs prüfen. |
| `StartStopMedia` | Medienwiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion bzw. unbekannte Aktion, die überprüft werden muss. |

Lesen Sie externe Ziele über [get_ExternalUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/get_externalurl/) und spezifische interne Ziele über [get_TargetSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/get_targetslide/). Interne Aktionen und eingebaute Befehle besitzen möglicherweise keine externe URL; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie [get_ExternalUrlOriginal](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) auf, wenn sie von der normalisierten URL abweicht, und fügen Sie den Tooltip aus [get_Tooltip](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlink/get_tooltip/) hinzu, sofern verfügbar.

### **Hyperlinks melden, bereinigen und prüfen**

Das folgende C++‑Beispiel liest eine bestehende Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen erneut zu prüfen. Es sammelt Container, bevor Änderungen vorgenommen werden, und nutzt die Zeigeridentität, um dieselbe Container‑Instanz nicht doppelt zu verarbeiten. Präsentations‑Abfragen decken gewöhnliche Folien ab; für ein paketweites Inventar werden zudem explizit Master‑, Layout‑, Notiz‑ und Handout‑Master‑Folien abgefragt, sofern vorhanden.

Der Bericht enthält einen eins‑basierten Folien‑Index sowie [get_SlideId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_slideid/), falls verfügbar. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecomponent/get_slide/) liefert die zugehörige Folie für unterstützte Container. Master‑, Layout‑ und Notiz‑Folien besitzen keinen normalen Folien‑Index und werden über ihren Geltungsbereich identifiziert. Shape‑Container und Text‑Abschnitt‑Formatierungs‑Container werden separat bezeichnet; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt ausschließlich absolute HTTPS‑URLs und gültige interne Folien‑Ziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Folien‑Aktionen, unbekannte Aktionen sowie andere URL‑Schemen. Diese Ablehnungen sind Richtlinien‑Entscheidungen, nicht ein Sicherheitsurteil von Aspose.Slides. HTTPS allein begründet kein Vertrauen: Ergänzen Sie Host‑Allowlists und weitere Prüfungen für Ihre Anwendung. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Korrektur unterstützt das [get_HyperlinkManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) des Containers [SetExternalHyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) und [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klicks und Mouse‑Over‑Aktionen werden unabhängig entfernt. Setzen Sie `replaceExternalClicks` auf `false`, um alle Richtlinien‑Verstöße zu entfernen. Bestimmen Sie eine von Ihrer Anwendung bereitgestellte Ersatz‑Seite vor dem Deployment.

Das Export‑Flag des Berichts verwendet eine konservative PDF‑Überprüfung‑Richtlinie: Mouse‑Over‑Aktionen und alles außer einem externen Link oder einem spezifischen Folien‑Sprung werden als potenziell nicht unterstützt markiert. Das ist ein Hinweis für die Überprüfung, kein Funktions‑Test oder eine Garantie, dass nicht markierte Links beim Export erhalten bleiben. Unterstützte [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/cpp/convert-powerpoint-to-html/)‑Exporte können Hyperlinks je nach Aktion, Export‑Optionen und Viewer erhalten; Raster‑[Bilder](/slides/de/cpp/convert-powerpoint-to-png/) und -[Video](/slides/de/cpp/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; beim Auditen für diese Ausgaben sollten Sie jede Aktion markieren.

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

Mit dem oben erstellten Eingabedokument enthält der Bericht fünf Aktions‑Zeilen. Der Datei‑Mouse‑Over‑Link und das Makro‑Klick‑Element werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifikation gibt null verbotene Aktionen aus. Ein Eingabedokument mit einer verbotenen externen Klick‑URL demonstriert zudem den Ersetzungs‑Pfad. Ein Container mit einem zulässigen Klick und einem verbotenen Mouse‑Over behält seine Klick‑Aktion bei.

Diese selektive Bereinigung unterscheidet sich von [RemoveAllHyperlinks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), das beide Aktivierungstypen im ausgewählten Geltungsbereich unabhängig von Richtlinien entfernt. Die Verifikation prüft hier ausschließlich Hyperlink‑Aktionen; sie entfernt keine eingebetteten VBA‑Projekte, OLE‑Objekte oder andere aktive Inhalte und validiert nicht ein exportiertes PDF‑ oder HTML‑Dokument.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder dessen erster Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einen Hyperlink an Elemente der Master‑Folien anhängen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layout‑Folien unterstützen Hyperlinks. Diese Links sind während der Vorführung auf allen Folien verfügbar, die den entsprechenden Master oder das Layout nutzen.

**Werden Hyperlinks beim Export nach PDF, HTML, Bild‑ oder Videoformat beibehalten?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Video können keine interaktiven Hyperlinks beibehalten. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).