---  
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in Java  
linktitle: Ansichtseigenschaften  
type: docs  
weight: 80  
url: /de/java/presentation-view-properties/  
keywords:  
- Ansichtseigenschaften  
- Normalansicht  
- Gliederungsinhalt  
- Gliederungssymbole  
- Vertikalen Trennbalken einrasten  
- Einzelansicht  
- Balkenzustand  
- Dimensionsgröße  
- automatische Anpassung  
- Standardzoom  
- PowerPoint  
- OpenDocument  
- Präsentation  
- Java  
- Aspose.Slides  
description: "Verwenden Sie Aspose.Slides für Java, um das Layout der Normalansicht, das Zoom von Folien und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint-Präsentationen zu konfigurieren."  
---
## **Einleitung**

In der Normalansicht von PowerPoint wird die Folie zwischen einem Seitenfenster für Miniaturansichten oder einer Gliederung und einem Notizbereich darunter angezeigt. Aspose.Slides für Java stellt die gespeicherten Bearbeitungspräferenzen der Präsentation über [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) bereit. Dazu gehören das Fensterlayout, Zoomstufen, Rasterabstand und die Sichtbarkeit von Kommentaren.

## **Über INormalViewProperties**

Verwenden Sie [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) , um auf das Interface [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) zuzugreifen. [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) sorgt dafür, dass das Seitenfenster in den minimierten Zustand einrastet, wenn der Benutzer es verkleinert. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) gibt eine Präferenz an, ein einzelnes Fenster im Vollbild anzuzeigen.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) steuert den Trenner zwischen dem Seitenfenster und der Folie. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) steuert den Trenner über dem Notizbereich. Beide akzeptieren einen [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) Wert von `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von INormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) die gespeicherte Größe des Seitenfensters und [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) die gespeicherte Größe des oberen Folienbereichs. Beide stellen [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/) bereit. Die Methode [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) akzeptiert einen Prozentsatz von 0 bis 100, und [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) steuert, ob der Editor die Größe bei einer Fenstergrößenänderung anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, setzt die von [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) zurückgegebene Größe auf 80% bei aktiviertem automatischem Anpassen und maximiert den vertikalen Trenner. Es ruft außerdem [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) auf, um Symbole in der Gliederungsansicht anzuzeigen.

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

## **Standard‑Zoomwert festlegen**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) und [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) speichern unabhängige Zoom‑Einstellungen für den Editor. Diese Einstellungen beeinflussen nicht die Folienabmessungen, die Wiedergabe der Bildschirmpräsentation oder die Auflösung beim Export von Bildern.

Dieses Beispiel öffnet eine vorhandene Präsentation und ruft [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) auf, um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizseite wird die automatische Skalierung deaktiviert und [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) aufgerufen, um einen festen Zoom von 80% festzulegen.

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

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) legt den Abstand zwischen den Bearbeitungsrasterlinien in der gesamten Präsentation fest. Es akzeptiert einen positiven Wert in Punkten, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein Viertel‑Zoll‑Raster, indem das Intervall auf 18 Punkte gesetzt wird.

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

Das Raster wiederholt sich in einem festen Intervall. [Zeichnungshilfen](/slides/de/java/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide dienen als Bearbeitungshilfen und werden nur in Editoren angezeigt, die sie unterstützen. Bildschirmpräsentationen und Exporte zu PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Es ruft außerdem [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) mit [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) auf, sodass die Kopie in der Folienansicht geöffnet wird.

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

Das Ausblenden von Kommentaren bewahrt deren Text, Autor*innen, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Präsentationskommentare](/slides/de/java/presentation-comments/). Export‑Einstellungen bestimmen, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handouts erscheinen.

## **FAQ**

**Warum wird das Raster beim erneuten Öffnen der Präsentation ausgeblendet?**  
Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Raster‑Sichtbarkeit im Editor.

**Ändert das Löschen von Zeichnungshilfen den Rasterabstand?**  
Nein. Das Hinzufügen, Verschieben oder Löschen einer Hilfslinie lässt das Rasterintervall unverändert.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**  
Nein. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**  
Die Datei speichert ein Set von Ansichtseigenschaften für alle. Ein Editor kann jedoch zusätzlich die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**  
Ja. Präsentationen, die aus der Vorlage erstellt werden, übernehmen deren gespeicherte Ansichtseinstellungen.