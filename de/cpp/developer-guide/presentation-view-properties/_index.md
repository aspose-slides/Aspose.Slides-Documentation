---
title: Abrufen und Aktualisieren von Ansichtseigenschaften einer Präsentation in C++
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
- Balkenzustand
- Abmessungsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für C++, um PPT-, PPTX- und ODP-Folien anzupassen – Layouts, Zoom-Stufen und Anzeigeeinstellungen zu bearbeiten."
---
## **Einführung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtszustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist, in dem die Präsentation zuletzt gespeichert wurde.

Die Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu bieten.  

[INormalViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/inormalviewrestoredproperties/) Schnittstellen und deren Nachfolger, [SplitterBarStateType](https://reference.aspose.com/slides/de/cpp/aspose.slides/splitterbarstatetype/) Aufzählung wurden hinzugefügt.

## **Über INormalViewProperties**

Repräsentiert Normalansichtseigenschaften.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalt in einem der Inhaltsbereiche der Normalansicht angezeigt wird.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trenner in den minimierten Zustand springen soll, wenn der Seitenbereich hinreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es vorzieht, einen einzigen Vollfenster‑Inhaltsbereich anstelle der standardmäßigen Normalansicht mit drei Inhaltsbereichen zu sehen. Ist sie aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster darstellen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunterliegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn Kind von RestoredTop, Höhe, wenn Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn Kind von RestoredTop, Höhe, wenn Kind von RestoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe kompensieren soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung geändert wird.

Ein unten stehendes Beispiel zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

``` cpp
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

Aspose.Slides für C++ unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Festlegen der [ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/) einer Präsentation erfolgen. Folien‑Ansichtseigenschaften sowie [get_NotesViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/get_notesviewproperties/) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die Ansichtseigenschaften einer Präsentation in Aspose.Slides gesetzt werden.

Um die Ansichtseigenschaften zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Setzen Sie die Ansicht [Properties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/) der Präsentation.
1. Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.

``` cpp
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

Verwenden Sie [Presentation::get_ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/), um die anwendungsweiten Ansichtseinstellungen einer Präsentation zu erhalten. Die Methoden [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/get_gridspacing/) und [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/de/cpp/aspose.slides/iviewproperties/set_gridspacing/) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene Datei `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertel Zoll und speichert das Ergebnis.

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

Das Raster unterscheidet sich von den [Zeichnungshilfen](/slides/de/cpp/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen einzeln positionierte horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Löschen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Bearbeitungs­hilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: Seine Sichtbarkeit hängt auch von den Präferenzen des Viewers oder Editors ab.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Überprüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Löschen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Löschen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich verschiedene Ansichtseinstellungen für unterschiedliche Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/) werden auf Presentation‑Ebene definiert ([Normal View](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen auf das gesamte Dokument angewendet wird.

**Kann ich unterschiedliche Ansichts‑Zustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, damit neue Präsentationen gleich geöffnet werden?**

Ja. Da [Ansichtseigenschaften](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_viewproperties/) auf Presentation‑Ebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.