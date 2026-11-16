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
- vertikaler Trenner einrasten
- Einzelansicht
- Leistenzustand
- Abmessungsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Node.js über Java, um das Layout der Normalansicht, den Zoom von Folien und Notizen, den Rasterabstand und die Kommentarsichtbarkeit in PowerPoint‑Präsentationen zu konfigurieren."
---
## **Einleitung**

In der Normalansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturansichten oder einer Gliederung und einem Notizbereich unten angezeigt. Aspose.Slides für Node.js über Java stellt die gespeicherten Bearbeitungseinstellungen der Präsentation über [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) bereit. Diese umfassen das Layout der Bereiche, Zoomstufen, Rasterabstand und die Sichtbarkeit von Kommentaren.

## **Über NormalViewProperties**

Verwenden Sie [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties), um auf die Klasse [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) zuzugreifen. [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ermöglicht es dem Seitenbereich, beim Verengen durch den Benutzer in den minimierten Zustand zu springen. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) gibt eine Präferenz an, ein einzelnes Feld im Vollfenster anzuzeigen.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) steuert den Trenner zwischen dem Seitenbereich und der Folie. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) steuert den Trenner über dem Notizbereich. Beide akzeptieren einen Wert des Typs [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) entweder `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von NormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) die gespeicherte Größe des Seitenbereichs und [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) die gespeicherte Größe des oberen Folienbereichs. Beide geben [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/) frei. Die Methode [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) akzeptiert einen Prozentsatz von 0 bis 100, und [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) steuert, ob der Editor die Größe bei Änderung der Fenstergröße anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, setzt die von [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) zurückgegebene Größe auf 80 % mit aktiviertem automatischem Anpassen und maximiert den vertikalen Trenner. Es ruft außerdem [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) auf, um Symbole in der Gliederungsansicht anzuzeigen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standard‑Zoomwert festlegen**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) und [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) speichern unabhängige Zoom‑Einstellungen für den Editor. Diese Einstellungen beeinflussen nicht die Folienabmessungen, die Wiedergabe der Bildschirmpräsentation oder die Auflösung beim Bildexport.

Dieses Beispiel öffnet eine vorhandene Präsentation und ruft [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) auf, um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizseite deaktiviert es die automatische Skalierung und ruft [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) auf, um einen festen Zoom von 80 % festzulegen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterabstand festlegen**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) legt den Abstand zwischen den Bearbeitungsrastern in der gesamten Präsentation fest. Es nimmt einen positiven Wert in Punkten, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein viertel‑Zoll‑Raster, indem es das Intervall auf 18 Punkte setzt.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Raster wiederholt sich in festen Intervallen. [Zeichnungshilfen](/slides/de/nodejs-java/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide dienen als Bearbeitungshilfen und erscheinen nur in Editoren, die sie anzeigen. Bildschirmpräsentationen sowie Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Es ruft außerdem [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) mit [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) auf, sodass die Kopie in der Folienansicht geöffnet wird.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Präsentationskommentare](/slides/de/nodejs-java/presentation-comments/). Exporteinstellungen steuern, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln erscheinen.

## **FAQ**

**Warum wird das Raster beim erneuten Öffnen der Präsentation ausgeblendet?**

Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Rasteranzeige im Editor.

**Ändert das Löschen von Zeichenhilfen den Rasterabstand?**

Nein. Das Hinzufügen, Verschieben oder Löschen einer Hilfslinie lässt das Rasterintervall unverändert.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**

Nein. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**

Die Datei speichert ein Satz von Ansichtseigenschaften für alle. Ein Editor kann zudem die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**

Ja. Präsentationen, die aus der Vorlage erstellt werden, erben deren gespeicherte Ansichtseinstellungen.