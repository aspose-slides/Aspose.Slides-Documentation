---
title: Retrieve and Update Presentation View Properties in C++
linktitle: View Properties
type: docs
weight: 80
url: /de/cpp/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikaler Trenner einrasten
- Einzelansicht
- Balkenzustand
- Dimensiongröße
- automatische Anpassung
- Standard‑Zoom
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für C++, um das Layout der Normalansicht, den Zoom von Folien und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint‑Präsentationen zu konfigurieren."
---
## **Einführung**

In der normalen Ansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturansichten oder einer Gliederung und einem Notizenbereich unten angezeigt. Aspose.Slides für C++ stellt die beim Speichern der Präsentation festgelegten Bearbeitungseinstellungen über [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) bereit. Diese umfassen das Layout der Bereiche, Zoomstufen, Rasterabstand und Sichtbarkeit von Kommentaren.

## **Über INormalViewProperties**

Verwenden Sie [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/), um auf die Schnittstelle [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) zuzugreifen. [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) lässt den Seitenbereich in den minimierten Zustand springen, wenn der Benutzer ihn verkleinert. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) gibt eine Vorliebe für die Anzeige eines einzigen Bereichs im gesamten Fenster an.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) steuert den Trenner zwischen dem Seitenbereich und der Folie. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) steuert den Trenner über dem Notizenbereich. Beide akzeptieren einen Wert vom Typ [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) – `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von INormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) die gespeicherte Größe des Seitenbereichs und [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) die gespeicherte Größe des oberen Folienbereichs. Beide geben [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) frei. Seine Methode [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) akzeptiert einen Prozentsatz von 0 bis 100, und [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) steuert, ob der Editor die Größe beim Ändern der Fenstergröße anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, setzt die Größe des oberen Folienbereichs, der von [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) bereitgestellt wird, auf 80 % mit aktivierter automatischer Anpassung und maximiert den vertikalen Trenner. Außerdem werden Gliederungs‑Symbole mit [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) für die Gliederungsansicht aktiviert.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Standard‑Zoomwert festlegen**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) und [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) speichern unabhängige Zoom‑Einstellungen für den Editor. Diese Einstellungen beeinflussen nicht die Folienabmessungen, die Präsentations‑Wiedergabe oder die Auflösung beim Export von Bildern.

Dieses Beispiel öffnet eine vorhandene Präsentation und aktiviert die automatische Skalierung mit [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/), um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizenseite deaktiviert es die automatische Skalierung und verwendet [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/), um einen festen Zoom von 80 % festzulegen.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Rasterabstand festlegen**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) legt den Abstand zwischen den Bearbeitungsrastern in der gesamten Präsentation fest. Der Wert ist positiv und wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein Raster von einem Viertel Zoll, indem das Intervall auf 18 Punkte gesetzt wird.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Das Raster wiederholt sich in festen Intervallen. [Drawing guides](/slides/de/cpp/drawing-guides/) kennzeichnen einzelne horizontale oder vertikale Positionen. Beide sind Hilfsmittel zum Bearbeiten und erscheinen nur in Editoren, die sie anzeigen. Präsentationen und Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation ein- oder ausblenden**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Außerdem wird [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) mit [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) aufgerufen, sodass die Kopie in der Folienansicht geöffnet wird.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Presentation Comments](/slides/de/cpp/presentation-comments/). Export‑Einstellungen steuern, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln erscheinen.

## **FAQ**

**Warum ist das Raster ausgeblendet, wenn ich die Präsentation erneut öffne?**

Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Raster‑Sichtbarkeit im Editor.

**Ändert das Löschen von Zeichenhilfen den Rasterabstand?**

Nein. Hinzufügen, Verschieben oder Löschen einer Hilfestellung lässt das Rasterintervall unverändert.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**

Nein. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**

Die Datei speichert einen Satz von Ansichtseigenschaften für alle. Ein Editor kann zusätzlich die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**

Ja. Präsentationen, die aus der Vorlage erstellt werden, übernehmen deren gespeicherte Ansichtseinstellungen.