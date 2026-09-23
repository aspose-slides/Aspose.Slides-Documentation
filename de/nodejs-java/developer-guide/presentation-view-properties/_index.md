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
- Vertikalen Trennbalken einrasten
- Einzelansicht
- Balkenstatus
- Dimensionsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Node.js via Java, um PPT-, PPTX- und ODP‑Folien anzupassen—Layouts, Zoom‑Stufen und Anzeigeeinstellungen ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist, wie sie zuletzt gespeichert wurde.

Die Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen. 

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewRestoredProperties) und ihre abgeleiteten Klassen sowie das Aufzählungstyp [SplitterBarStateType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType) wurden hinzugefügt.

## **Über NormalViewProperties**

Stellt Normalansichtseigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus angezeigt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trennbalken in einen minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) geben an, ob der Benutzer es vorzieht, einen einteiligen Vollfensterbereich anstelle der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist dies aktiviert, kann die Anwendung entscheiden, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SplitterBarStateType#Restored) für [getVerticalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) angewendet wird.

## **Über das Wiederherstellen von NormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn er ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) ist, Höhe, wenn er ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) ist) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn er ein Kind von restoredTop ist, Höhe, wenn er ein Kind von restoredLeft ist).

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung neu skaliert wird.

Ein untenstehendes Beispiel zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.

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

Aspose.Slides für Node.js via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, so dass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Setzen der [ViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties) einer Präsentation erfolgen. [getSlideViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation) in Aspose.Slides gesetzt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei. In dem unten gezeigten Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht gesetzt.

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

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getViewProperties--) , um auf die ansichtsweiten Einstellungen der Präsentation zuzugreifen. Die Methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) und [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgendende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertelzoll und speichert das Ergebnis.

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

Das Raster unterscheidet sich von [Zeichnungsrichtlinien](/slides/de/nodejs-java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungsrichtlinien einzeln positionierte horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichnungsrichtlinien ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungsrichtlinien sind Hilfsmittel beim Bearbeiten. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: Die Sichtbarkeit hängt auch von den Einstellungen des Betrachters oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getViewProperties--) , um auf die ansichtsweiten Einstellungen der Präsentation zuzugreifen. Mit [ViewProperties.getShowComments](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#getShowComments--) und [ViewProperties.setShowComments](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) können Sie die gespeicherte Präferenz auslesen bzw. ändern, ob Kommentare beim Öffnen der Präsentation in PowerPoint oder einem anderen kompatiblen Editor angezeigt werden sollen.

Diese Einstellung steuert lediglich die gespeicherte Ansichtspräferenz. Sie fügt keine Kommentare hinzu, entfernt sie nicht, bearbeitet sie nicht und löst sie nicht auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/nodejs-java/presentation-comments/) für Vorgänge, die die Kommentare selbst ändern.

Das folgende Beispiel erfordert eine vorhandene `comments.pptx` mit Kommentaren. Es gibt die aktuelle Sichtbarkeitseinstellung aus, fordert das Ausblenden der Kommentare an und speichert ein neues PPTX, ohne Kommentare zu entfernen. Es verwendet zudem [ViewProperties.setLastView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) zusammen mit [ViewType.SlideView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewtype/#SlideView), um die anfängliche Bearbeitungsansicht zusammen mit der Kommentar‑Sichtbarkeit zu konfigurieren.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild-, Notiz‑ oder Handout‑Exporten enthalten sind. Konfigurieren Sie die entsprechenden export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Überprüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichenrichtlinien den Rasterabstand?**

Nein. Zeichenrichtlinien und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Richtlinien lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des Dokuments für das gesamte Dokument gilt.

**Kann ich unterschiedliche Ansichtszustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzereinstellungen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, damit neue Präsentationen gleich öffnen?**

Ja. Da [Ansichtseigenschaften](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.