---
title: Abrufen und Aktualisieren von Präsentationsansichts‑Eigenschaften in C++
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/cpp/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensiongröße
- automatische Anpassung
- Standard‑Zoom
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für C++, um PPT-, PPTX- und ODP‑Folienformate anzupassen – Layouts, Zoom‑Stufen und Anzeige‑Einstellungen zu ändern."
---
## **Einführung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu erhalten. 

[INormalViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/inormalviewrestoredproperties/) Schnittstellen und deren Nachfolger, das Enum [SplitterBarStateType](https://reference.aspose.com/slides/de/cpp/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt die Normalansichts‑Eigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungs‑Inhalte in einem der Inhaltsbereiche der Normalansicht angezeigt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trenner in einen minimierten Zustand „einrasten“ soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer lieber einen Vollfenster‑Einzel‑Inhaltsbereich statt der Standard‑Normalansicht mit drei Inhaltsbereichen sehen möchte. Wenn aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung neu dimensioniert wird.

Ein folgendes Beispiel zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Wiederherstellen der Ansichtseigenschaften der Präsentation
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Standard‑Zoomwert festlegen**

Aspose.Slides für C++ unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch das Setzen der [ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/) einer Präsentation erfolgen. Folien‑Ansichts‑Eigenschaften sowie [get_NotesViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/get_notesviewproperties/) können programmgesteuert gesetzt werden. In diesem Abschnitt zeigen wir mit einem Beispiel, wie die View‑Eigenschaften einer Präsentation in Aspose.Slides festgelegt werden.

Um die Ansichtseigenschaften zu setzen, folgen Sie bitte den unten stehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse
1. Setzen Sie die View[Properties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/) der Präsentation
1. Schreiben Sie die Präsentation als PPTX‑Datei

Im nachstehenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht gesetzt.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Festlegen der Ansichtseigenschaften der Präsentation
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomwert in Prozent für die Folienansicht
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomwert in Prozent für die Notizansicht 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation::get_ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/), um die ansichtsweiten Einstellungen der gesamten Präsentation abzurufen. Die Methoden [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/get_gridspacing/) und [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/set_gridspacing/) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet ein vorhandenes `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertel Zoll und speichert das Ergebnis.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Das Raster unterscheidet sich von den [drawing guides](/slides/de/cpp/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungs‑Hilfslinien einzeln positionierte horizontale oder vertikale Ausrichtungs­linien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichnungs‑Hilfslinien ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungs‑Hilfslinien dienen als Bearbeitungs­hilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Bildschirmpräsentation gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: Seine Sichtbarkeit hängt ebenfalls von den Einstellungen des Viewers oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation ein‑ oder ausblenden**

Verwenden Sie [Presentation::get_ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/), um die ansichtsweiten Einstellungen der Präsentation abzurufen. Mit [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/get_showcomments/) und [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/set_showcomments/) können Sie eine Präferenz speichern, ob Kommentare beim Öffnen der Präsentation in PowerPoint oder einem anderen kompatiblen Editor angezeigt werden sollen.

Diese Einstellung beeinflusst nur die gespeicherte Ansichtspräferenz. Sie fügt keine Kommentare hinzu, entfernt sie nicht, bearbeitet sie nicht und löst sie nicht auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/cpp/presentation-comments/) für Vorgänge, die die Kommentare selbst ändern.

Das nachstehende Beispiel erfordert ein vorhandenes `comments.pptx` mit Kommentaren. Es gibt die aktuelle Sichtbarkeits‑Einstellung aus, fordert das Ausblenden der Kommentare an und speichert ein neues PPTX, ohne Kommentare zu entfernen. Zusätzlich wird [IViewProperties::set_LastView](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/set_lastview/) zusammen mit [ViewType::SlideView](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewtype/) verwendet, um die anfängliche Bearbeitungsansicht neben der Kommentar‑Sichtbarkeit zu konfigurieren.

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
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild‑, Notiz‑ oder Handout‑Exporten enthalten sind. Konfigurieren Sie die jeweiligen export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeits‑Einstellungen des Editors.

**Ändert das Entfernen von Zeichnungs‑Hilfslinien den Rasterabstand?**

Nein. Zeichnungs‑Hilfslinien und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfslinien lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/) werden auf Ebene der Präsentation definiert ([Normal View](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument beim Öffnen gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind für alle Benutzer gleich. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View‑Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.