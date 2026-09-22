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
- Vertikalen Trenner einrasten lassen
- Einzelansicht
- Leistenstatus
- Abmessungsgröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Java, um PPT-, PPTX- und ODP‑Folien anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---
## **Einführung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften bezüglich der Positionierung der verschiedenen Inhaltsbereiche. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu bieten.

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties) sowie deren Ableitungen, die Aufzählung [SplitterBarStateType](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType) wurden hinzugefügt.

## **Über INormalViewProperties**

Repräsentiert Normalansichts‑Eigenschaften.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalte in einem der Inhaltsbereiche des Normalansichts‑Modus dargestellt werden.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand „einrasten“ soll, wenn der seitliche Bereich ausreichend klein ist.

Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer es bevorzugt, einen einzigen Vollfenster‑Inhaltsbereich anstelle der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist diese Option aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben an, in welchem Zustand die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Restored) angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Methode [getDimensionSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung neu dimensioniert wird.

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Stelle die Ansichtseigenschaften der Präsentation wieder her
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standard‑Zoomwert festlegen**

{{% alert color="info" %}} 

Aspose.Slides for Java unterstützt jetzt das Festlegen eines Standard‑Zoomwerts für Präsentationen, sodass beim Öffnen die Zoomstufe bereits eingestellt ist. Dies kann durch das Setzen der [ViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) einer Präsentation erfolgen. Sowohl [getSlideViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) als auch [getNotesViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation) in Aspose.Slides gesetzt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften zu setzen, gehen Sie bitte wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.  
   Im nachfolgenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizansicht 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) um auf die view‑weiten Einstellungen einer Präsentation zuzugreifen. Die Methoden [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#getGridSpacing--) und [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, legt ein Intervall von einem Viertelzoll fest und speichert das Ergebnis.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Raster unterscheidet sich von den [Zeichnungshilfen](/slides/de/java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen individuell positionierte horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Bearbeitungshilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Bildschirmpräsentation gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt ebenfalls von den Einstellungen des Viewers oder Editors ab.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nicht pro Abschnitt. Daher gilt ein einziger Parametersatz für das gesamte Dokument beim Öffnen.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.