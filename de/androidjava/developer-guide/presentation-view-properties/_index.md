---
title: Abrufen und Aktualisieren von Präsentations‑Ansichtseigenschaften auf Android
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/androidjava/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Schnappvertikaler Trenner
- Einzelansicht
- Leistenstatus
- Dimensiongröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Android via Java, um PPT-, PPTX- und ODP‑Folien anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties) sowie deren Ableitungen und das Aufzählungs‑Element [SplitterBarStateType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansichtseigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean--) geben an, ob der vertikale Trenner in den minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) gibt an, ob der Benutzer lieber einen einzelnen Inhaltsbereich im Vollfenster sehen möchte statt der Standard‑Normalansicht mit drei Inhaltsbereichen. Ist sie aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster darzustellen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) legen fest, in welchem Zustand die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Restored) für [getVerticalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) jeweils angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung verkleinert oder vergrößert wird.

Ein nachfolgendes Beispiel zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.

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
## **Standard-Zoomwert festlegen**

{{% alert color="info" %}} 

Aspose.Slides für Android via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für Präsentationen, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Setzen der [ViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) einer Präsentation erfolgen. [getSlideViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmatisch festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) in Aspose.Slides gesetzt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
2. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
3. Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei. Im nachstehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht festgelegt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizenansicht

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Rasterabstand festlegen**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) , um auf die für die gesamte Präsentation geltenden Ansichtseinstellungen zuzugreifen. Die Methoden [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) und [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation und nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene Datei `demo.pptx`, gibt den aktuellen Rasterabstand aus, legt ein Intervall von einem Viertelzoll fest und speichert das Ergebnis.

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

Das Raster unterscheidet sich von den [drawing guides](/slides/de/androidjava/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichenhilfen einzelne, horizontal oder vertikal positionierte Ausrichtungs‑Linien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichenhilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichenhilfen dienen als Bearbeitungshilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt ebenfalls von den Einstellungen des Betrachters oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation ein- oder ausblenden**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) , um auf die für die gesamte Präsentation geltenden Ansichtseinstellungen zuzugreifen. Mit [IViewProperties.getShowComments](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) und [IViewProperties.setShowComments](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) können Sie die gespeicherte Präferenz auslesen bzw. ändern, ob Kommentare angezeigt werden sollen, wenn die Präsentation in PowerPoint oder einem anderen kompatiblen Editor geöffnet wird.

Diese Einstellung steuert nur die gespeicherte Ansichtspräferenz. Sie fügt keine Kommentare hinzu, entfernt, bearbeitet oder löst sie nicht. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/androidjava/presentation-comments/) für Vorgänge, die die Kommentare selbst ändern.

Das folgende Beispiel erfordert eine vorhandene Datei `comments.pptx` mit Kommentaren. Es gibt die aktuelle Sichtbarkeitseinstellung aus, bittet darum, Kommentare zu verbergen, und speichert ein neues PPTX, ohne Kommentare zu entfernen. Außerdem wird [IViewProperties.setLastView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) zusammen mit [ViewType.SlideView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewtype/#SlideView) verwendet, um die anfängliche Bearbeitungsansicht zusammen mit der Kommentar‑Sichtbarkeit zu konfigurieren.

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

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild-, Notiz- oder Handout‑Exporten enthalten sind. Konfigurieren Sie die jeweiligen export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtungseinstellungen des Editors.

**Ändert das Entfernen von Zeichenhilfen den Rasterabstand?**

Nein. Zeichenhilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) werden auf Präsentationsebene (Normal View/Slide View) definiert, nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des gesamten Dokuments gilt.

**Kann ich für verschiedene Benutzer unterschiedliche Ansichts­zustände vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, damit neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.