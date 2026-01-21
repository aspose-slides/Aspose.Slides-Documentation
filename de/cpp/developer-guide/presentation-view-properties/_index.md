---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in C++
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/cpp/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trennbalken einrasten lassen
- Einzelansicht
- Balkenstatus
- Dimensiongröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für C++, um PPT-, PPTX- und ODP-Folienformate anzupassen - Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist, in dem die Präsentation zuletzt gespeichert wurde.

Die Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.

[INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) Schnittstellen und deren Nachfolger, [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) Aufzählung wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties**

Stellt die Eigenschaften der Normalansicht dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalte in einem der Inhaltsbereiche des Normalansichtsmodus angezeigt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trennbalken in einen minimierten Zustand einrasten soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, einen vollflächigen Einzel‑Inhaltsbereich anstelle der standardmäßigen Normalansicht mit drei Inhaltsbereichen zu sehen. Wenn aktiviert, kann die Anwendung entscheiden, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored.**

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** und **HorizontalBarState** jeweils der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs bei einer Größenänderung des Anwendungsfensters, das die Ansicht enthält, kompensiert werden soll.

Ein nachstehendes Beispiel zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.
``` cpp
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

Aspose.Slides für C++ unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Setzen der [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) einer Präsentation erreicht werden. Folienansichtseigenschaften sowie [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/) können programmgesteuert festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die View Properties einer Präsentation in Aspose.Slides gesetzt werden.

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Setzen Sie die View [Properties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) der Präsentation.
1. Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht festgelegt.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Festlegen der Ansichtseigenschaften der Präsentation
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomwert in Prozent für die Folienansicht
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomwert in Prozent für die Notizansicht 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument beim Öffnen gilt.

**Kann ich unterschiedliche Ansichtszustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält einen einzigen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, damit neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.