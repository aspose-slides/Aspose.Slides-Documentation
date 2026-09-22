---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in JavaScript
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/nodejs-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten lassen
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js via Java-Ansichtseigenschaften, um PPT-, PPTX- und ODP-Folien anzupassen - Layouts, Zoom-Stufen und Anzeigeeinstellungen zu ändern."
---
## **Einführung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem Seiten-Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, den Ansichtszustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansicht‑Eigenschaften einer Präsentation zu ermöglichen.

[NormalViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewRestoredProperties) Klassen und deren Ableitungen, [SplitterBarStateType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType) Enum wurden hinzugefügt.

## **Über NormalViewProperties**

Repräsentiert NormalView‑Eigenschaften.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalt in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt wird.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) geben an, ob der Benutzer es bevorzugt, ein einzelnes Inhaltsfeld über das gesamte Fenster zu sehen, anstatt der Standard‑Normalansicht mit drei Inhaltsbereichen. Ist dies aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennerleiste trennt die Folie vom Seiten-Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) geben die Größe des oberen oder seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Restored) verwendet wird.

## **Über das Wiederherstellen von NormalViewProperties** 

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Methode [getDimensionSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des Seiten-Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung neu skaliert wird.

Ein nachstehendes Beispiel zeigt, wie Sie auf die [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)‑Eigenschaften einer Präsentation zugreifen können.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Wiederherstellen der Ansichtseigenschaften der Präsentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standard‑Zoomwert festlegen**

{{% alert color="info" %}} 

Aspose.Slides für Node.js via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits gesetzt ist. Dies kann geschehen, indem die [ViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties) einer Präsentation eingestellt werden. [getSlideViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation) in Aspose.Slides festgelegt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im nachstehenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht gesetzt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizansicht
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getViewProperties--) , um die präsentationsweiten Ansichtseinstellungen zu erhalten. Die Methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) und [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Viertel‑Zoll‑Intervall und speichert das Ergebnis.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Raster unterscheidet sich von [Zeichnungshilfen](/slides/de/nodejs-java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen individuell positionierte horizontale oder vertikale Ausrichtungs‑Linien sind. Das Hinzufügen, Verschieben oder Löschen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Hilfsmittel für die Bearbeitung. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Bildschirmpräsentation gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: seine Sichtbarkeit hängt auch von den Einstellungen des Viewers oder Editors ab.

## **FAQ**

**Warum ist das Raster nach erneutem Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Löschen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Löschen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene ([Normal View](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)) definiert, nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des Dokuments gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzereinstellungen berücksichtigen, aber die Datei enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [View Properties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.