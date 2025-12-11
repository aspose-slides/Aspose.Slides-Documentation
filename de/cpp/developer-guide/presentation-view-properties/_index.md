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
- vertikalen Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für C++, um PPT-, PPTX- und ODP‑Folien anzupassen – Layouts, Zoom‑Stufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Information ermöglicht es der Anwendung, den Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu ermöglichen.  

[INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) Schnittstellen und deren Nachfolger, [SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) Aufzählung wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungs‑Inhalte in einem der Inhaltsbereiche des Normalansichtsmodus angezeigt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trenner in einen minimierten Zustand einrasten soll, wenn der Seitenbereich hinreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, einen einzelnen Inhaltsbereich im Vollfenster gegenüber der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist sie aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennerleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored.**

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung neu dimensioniert wird.

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.
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


## **Standard‑Zoom‑Wert festlegen**

Aspose.Slides für C++ unterstützt jetzt das Festlegen des Standard‑Zoom‑Werts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits gesetzt ist. Dies kann durch das Festlegen der [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) einer Präsentation erfolgen. Folien‑Ansichts‑Eigenschaften sowie [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) können programmgesteuert gesetzt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die Ansatz‑Eigenschaften einer Präsentation in Aspose.Slides festgelegt werden.

Um die Ansatz‑Eigenschaften zu setzen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)
2. Setzen Sie die View‑[Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) der Präsentation
3. Schreiben Sie die Präsentation als PPTX‑Datei

Im nachfolgenden Beispiel haben wir den Zoom‑Wert für die Folienansicht sowie die Notizansicht festgelegt.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Festlegen der Ansichtseigenschaften der Präsentation
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomwert in Prozent für die Folienansicht
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomwert in Prozent für die Notizansicht

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich verschiedene Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) sind auf Ebene der Präsentation definiert ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen auf das gesamte Dokument angewendet wird.

**Kann ich unterschiedliche Ansichts‑Zustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Anzeige‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) auf Ebene der Präsentation gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.