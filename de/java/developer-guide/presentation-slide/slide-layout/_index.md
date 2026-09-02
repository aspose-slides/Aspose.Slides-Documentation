---
title: Slide-Layouts in Java anwenden oder ändern
linktitle: Slide-Layout
type: docs
weight: 60
url: /de/java/slide-layout/
keywords:
- Slide-Layout
- Inhalts-Layout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- ungenutztes Layout
- Fußzeilen‑Sichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Slide-Layouts in Aspose.Slides für Java anwenden, erstellen und ändern, Platzhalter hinzufügen, ungenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und Formatierungen von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die am häufigsten verwendeten Layouts sind:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeinen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layout‑Vererbung**

Eine Präsentation hat drei zusammenhängende Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) definiert das Design, geteilte Formatierungen, Hintergründe und gemeinsame Objekte.
2. Eine [Layoutfolie](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
3. Eine [Normalfolie](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Normalfolie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Normalfolie gesetzter Wert überschreibt den vererbten Wert auf dieser Ebene. Beim Erstellen einer Normalfolie werden ihre Platzhalter‑Formen aus dem ausgewählten Layout generiert, während der in die Platzhalter eingegebene Inhalt zur Normalfolie gehört.

Fügen Sie erforderliche Platzhalter zu einem Layout hinzu, bevor Sie daraus Folien erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch eine entsprechende Platzhalter‑Form zu bereits bestehenden Normalfolien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern von geerbten Formatierungen oder vorhandener Platzhalter‑Geometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Prüfen Sie vor dem Bearbeiten eines bereits genutzten Layouts dessen abhängige Folien und überprüfen Sie die resultierende Präsentation.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Weisen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folien‑Master](/slides/de/java/slide-master/).

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint‑Layout‑Definitionen folgt. Layoutnamen sind vom Benutzer editierbar und können lokalisiert werden, sodass eine namensbasierte Auswahl weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** ausgewichen. Die zweite Null‑Prüfung ist nötig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [ISlide.setLayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)‑Methode auf die erste Normalfolie angewendet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ändern des Layouts einer Folie entfernt nicht die direkt auf der Folie hinzugefügten normalen Formen. Platzhalterpositionen, geerbte Formatierungen und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können jedoch ändern, weshalb Sie die Ausgabe prüfen sollten, wenn Sie zwischen wesentlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind getrennte Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt kein neues. Um ein Layout zu erstellen, rufen Sie die [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-)‑Methode auf der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt danach eine Normalfolie, die darauf basiert. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Fügen Sie ein Layout nur dann hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein geeignetes Layout, wählen Sie dieses aus und nutzen Sie es, anstatt ein Duplikat zu erstellen.

## **Hinzufügen von Platzhaltern zu einer Layoutfolie**

Die [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)‑Methode liefert einen [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalter‑Formen zu einem Layout.

| PowerPoint‑Platzhalter            | `ILayoutPlaceholderManager` Methode |
| --------------------------------- | ----------------------------------- |
| ![Inhalt](content.png)            | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Inhalt (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertikal)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Bild](picture.png)              | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagramm](chart.png)            | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabelle](table.png)             | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Medien](media.png)              | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online‑Bild](onlineImage.png)   | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine Normalfolie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden vor der Erstellung der Normalfolie hinzugefügt, sodass Aspose.Slides die entsprechenden Platzhalter‑Formen auf dieser Folie erzeugen kann.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Das Ändern geerbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bestehenden Normalfolien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.

{{% /alert %}}

## **Entfernen ungenutzter Layoutfolien**

Verwenden Sie die [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)‑Methode, um Layouts zu entfernen, auf die keine Normalfolie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um ein bestimmtes Layout zu entfernen, prüfen Sie zunächst dessen [hasDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--)‑ oder [getDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getDependingSlides--)‑Methode. Weisen Sie abhängige Folien neu zu, bevor Sie [ILayoutSlide.remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#remove--) aufrufen. Der Versuch, ein benutztes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummern‑ und Datum‑Uhrzeit‑Platzhalter. Verwenden Sie die [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--)‑Methode, um diese Platzhalter für ein Layout zu steuern. Dies ist nützlich, wenn zum Beispiel Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilenelemente sichtbar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und seinen Kind‑Layouts**

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--)‑Methode. Die Propagations‑Methoden von [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie auf dessen abhängige Layout‑ und Normalfolien; sie zielen nicht nur auf eine einzelne Normalfolie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Design und die geteilten Formatierungen einer Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normalfolien nutzen diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)‑Methode eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriften, Designs, Bilder und andere vom Quell‑Layout genutzte Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits genutztes Layout ändere?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschreiben. Platzhalter‑Geometrie und vererbte Stile können daher auf vielen Folien gleichzeitig ändern. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getDependingSlides--), um vor der Bearbeitung des Layouts die betroffenen Folien zu ermitteln.

**Was passiert, wenn ich ein noch genutztes Layout entferne?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxeditexception/). Weisen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), um nur nicht referenzierte Layouts zu entfernen.