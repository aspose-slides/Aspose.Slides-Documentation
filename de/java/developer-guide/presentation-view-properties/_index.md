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
- vertikalen Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- automatische Anpassung
- Standard-Zoom
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Java, um PPT-, PPTX- und ODP-Folien anzupassen – Layouts, Zoom-Stufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist, in dem die Präsentation zuletzt gespeichert wurde.

Methode[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansicht‑Eigenschaften einer Präsentation zu bieten.

[INormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties) Interfaces und ihre Nachfolger, [SplitterBarStateType](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType) Enum wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansicht‑Eigenschaften dar.

Methoden[getShowOutlineIcons](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und[setShowOutlineIcons](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungs‑Inhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Methoden[getSnapVerticalSplitter](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und[setSnapVerticalSplitter](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand „einrasten“ soll, wenn der seitliche Bereich ausreichend klein ist.

Eigenschaft[getPreferSingleView](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und[setPreferSingleView](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geben an, ob der Benutzer es vorzieht, einen einzigen Vollfenster‑Inhaltsbereich anstelle der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist dies aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Methoden[getVerticalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und[getHorizontalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunterliegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Restored).

Methoden[getRestoredLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und[getRestoredTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für[getVerticalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und[getHorizontalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) jeweils der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Restored) angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von[getRestoredTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) ist, Höhe, wenn ein Kind von[getRestoredLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ist) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Methode[getDimensionSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite bei restoredTop, Höhe bei restoredLeft).

Methode[getAutoAdjust](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs sich an die neue Größe anpassen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung geändert wird.

Ein Beispiel unten zeigt, wie Sie auf [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) Eigenschaften einer Präsentation zugreifen können.

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

Aspose.Slides für Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann geschehen, indem die [ViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) einer Präsentation gesetzt werden. [getSlideViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) von [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation) in Aspose.Slides festzulegen sind.

{{% /alert %}} 

Um die Ansichtseigenschaften zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)‑Klasse.
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im nachfolgenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht gesetzt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoom-Wert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoom-Wert in Prozent für die Notizansicht 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) um die präsentationsweiten Ansichtseinstellungen abzurufen. Die [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#getGridSpacing--) und [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) Methoden lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet ein vorhandenes `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertel Zoll und speichert das Ergebnis.

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

Das Raster unterscheidet sich von [drawing guides](/slides/de/java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichen­hilfen einzelne horizontal‑ oder vertikal ausgerichtete Linien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichen­hilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichen­hilfen sind Hilfsmittel zur Bearbeitung. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: seine Sichtbarkeit hängt ebenfalls von den Einstellungen des Betrachters bzw. Editors ab.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) um die präsentationsweiten Ansichtseinstellungen abzurufen. Verwenden Sie [IViewProperties.getShowComments](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#getShowComments--) und [IViewProperties.setShowComments](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) um die gespeicherte Präferenz zu lesen bzw. zu ändern, ob Kommentare angezeigt werden sollen, wenn die Präsentation in PowerPoint oder einem anderen kompatiblen Editor geöffnet wird.

Diese Einstellung steuert nur die gespeicherte Ansichtspräferenz. Sie fügt keine Kommentare hinzu, entfernt sie, bearbeitet sie oder löst sie auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/java/presentation-comments/) für Vorgänge, die die Kommentare selbst ändern.

Das nachfolgende Beispiel benötigt ein vorhandenes `comments.pptx` mit Kommentaren. Es gibt die aktuelle Sichtbarkeit aus, fordert an, Kommentare auszublenden, und speichert ein neues PPTX, ohne Kommentare zu entfernen. Außerdem wird [IViewProperties.setLastView](https://reference.aspose.com/slides/de/java/com.aspose.slides/iviewproperties/#setLastView-int-) mit [ViewType.SlideView](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewtype/#SlideView) verwendet, um die initiale Bearbeitungsansicht zusammen mit der Kommentar‑Sichtbarkeit zu konfigurieren.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild‑, Notiz‑ oder Handzettel‑Exporten enthalten sind. Konfigurieren Sie die jeweiligen export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Löschen von Zeichen­hilfen den Rasterabstand?**

Nein. Zeichen­hilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) werden auf Präsentations‑Ebene definiert ([Normal View](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument gilt, wenn es geöffnet wird.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, damit neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getViewProperties--) auf Präsentations‑Ebene gespeichert werden, können Sie sie in eine Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.