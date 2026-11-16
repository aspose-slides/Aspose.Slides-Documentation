---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften unter Android
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/androidjava/presentation-view-properties/
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
- Android
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Android über Java, um das Layout der Normalansicht, den Zoom von Folien und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint-Präsentationen zu konfigurieren."
---
## **Einführung**

In der Normalansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturansichten oder einer Gliederung und einem Notizbereich darunter angezeigt. Aspose.Slides für Android über Java stellt die gespeicherten Bearbeitungspräferenzen der Präsentation über [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) bereit. Diese umfassen das Layout der Bereiche, Zoomstufen, Rasterabstand und Sichtbarkeit von Kommentaren.

## **Über INormalViewProperties**

Verwenden Sie [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) , um auf das Interface [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) zuzugreifen. [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) lässt den Seitenbereich beim Verengen durch den Benutzer in den minimierten Zustand einrasten. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) gibt eine Vorliebe dafür an, einen einzigen Bereich im Vollbildfenster anzuzeigen.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) steuert den Trenner zwischen dem Seitenbereich und der Folie. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) steuert den Trenner über dem Notizbereich. Beide akzeptieren einen [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) Wert von `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von INormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) die gespeicherte Größe des Seitenbereichs und [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) die gespeicherte Größe des oberen Folienbereichs. Beide geben [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/) frei. Die Methode [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) akzeptiert einen Prozentsatz von 0 bis 100, und [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) steuert, ob der Editor die Größe beim Ändern der Fenstergröße anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, setzt die von [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) zurückgegebene Größe auf 80% mit aktiviertem automatischem Anpassen und maximiert den vertikalen Trenner. Es ruft außerdem [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) auf, um Symbole in der Gliederungsansicht anzuzeigen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standard-Zoomwert festlegen**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) und [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) speichern unabhängige Zoom‑Einstellungen für den Editor. Diese Einstellungen beeinflussen nicht die Folienabmessungen, die Wiedergabe der Diashow oder die Auflösung beim Export von Bildern.

Dieses Beispiel öffnet eine vorhandene Präsentation und ruft [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) auf, um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizseite deaktiviert es die automatische Skalierung und ruft [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) auf, um einen festen Zoom von 80% festzulegen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterabstand festlegen**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) legt den Abstand zwischen den Bearbeitungsrasterlinien in der gesamten Präsentation fest. Es akzeptiert einen positiven Wert in Punkten, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein Viertel‑Zoll‑Raster, indem es das Intervall auf 18 Punkte setzt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Raster wiederholt sich in einem festen Intervall. [Zeichnungshilfen](/slides/de/androidjava/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide sind Bearbeitungs‑Hilfsmittel und erscheinen nur in Editoren, die sie anzeigen. Diashows und Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Es ruft außerdem [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) mit [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) auf, sodass die Kopie in der Folienansicht geöffnet wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Präsentationskommentare](/slides/de/androidjava/presentation-comments/). Export‑Einstellungen steuern, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln erscheinen.

## **FAQ**

**Warum ist das Raster ausgeblendet, wenn ich die Präsentation wieder öffne?**  
Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Rasteranzeige im Editor.

**Ändert das Entfernen von Zeichnungshilfen den Rasterabstand?**  
Nein. Das Hinzufügen, Verschieben oder Entfernen einer Hilfslinie ändert das Rasterintervall nicht.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**  
Nein. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**  
Die Datei speichert ein Satz von Ansichtseigenschaften für alle. Ein Editor kann zudem die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**  
Ja. Präsentationen, die aus der Vorlage erstellt werden, übernehmen deren gespeicherte Ansichtseinstellungen.