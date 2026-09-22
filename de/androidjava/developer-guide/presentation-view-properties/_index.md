---
title: Abrufen und Aktualisieren von Präsentations-Ansichtseigenschaften unter Android
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/androidjava/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- vertikaler Splitter einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- automatische Anpassung
- Standard-Zoom
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Android via Java, um PPT-, PPTX- und ODP-Folienformate anzupassen – Layouts, Zoom-Stufen und Anzeigeeinstellungen zu verändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in einer Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu ermöglichen.  

[INormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties) Schnittstellen und deren Ableitungen, das [SplitterBarStateType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType)‑Enum wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn im Normalansichts‑Modus Gliederungsinhalte in einem der Inhaltsbereiche angezeigt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Splitter auf einen minimierten Zustand einrasten soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer bevorzugt, ein einzelnes Inhaltsfeld über das gesamte Fenster zu sehen, anstatt der Standard‑Normalansicht mit drei Inhaltsbereichen. Ist sie aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Restored) angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) ist, Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ist) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).  

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).  

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe kompensieren soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung resized wird.  

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Wiederherstellen der Ansichtseigenschaften der Präsentation
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

Aspose.Slides für Android via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits gesetzt ist. Dies kann durch das Setzen der [ViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) einer Präsentation geschehen. [getSlideViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Abschnitt zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) in Aspose.Slides festgelegt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den unten stehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).  
2. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).  
3. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im nachfolgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht gesetzt.

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

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) um auf die präsentationsweiten Ansichtseinstellungen zuzugreifen. Die Methoden [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) und [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht nur für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertel Zoll und speichert das Ergebnis.

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

Das Raster unterscheidet sich von [Zeichnungshilfen](/slides/de/androidjava/drawing-guides/). Der Rasterabstand definiert ein regelmäßiges Intervall, während Zeichnungshilfen einzelne, horizontal oder vertikal positionierte Ausrichtungslinien sind. Das Hinzufügen, Bewegen oder Löschen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Bearbeitungs­hilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Bildschirmpräsentation gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt ebenfalls von den Präferenzen des Betrachters oder Editors ab.

## **FAQ**

**Warum ist das Raster nach erneutem Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Löschen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Löschen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des Dokuments gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.