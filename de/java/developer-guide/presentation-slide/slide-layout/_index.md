---
title: Anwenden oder Ändern von Folienlayouts in Java
linktitle: Folienlayout
type: docs
weight: 60
url: /de/java/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
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
description: "Folienlayouts in Aspose.Slides für Java anwenden, erstellen und ändern, Platzhalter hinzufügen, ungenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und Formatierungen von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die gebräuchlichsten Layouts umfassen:

- **Title Slide**: Enthält Platzhalter für Titel und Untertitel.
- **Title and Content**: Enthält einen Titelplatzhalter und einen allgemeinen Inhaltsplatzhalter.
- **Blank**: Enthält keine Inhaltsplatzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Layout‑Vererbung verstehen**

Eine Präsentation hat drei verwandte Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) definiert das Design, die geteilte Formatierung, Hintergründe und gemeinsame Objekte.  
2. Eine [Layoutfolie](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.  
3. Eine [normale Folie](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine normale Folie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer normalen Folie festgelegter Wert überschreibt den geerbten Wert auf dieser Ebene. Beim Erzeugen einer normalen Folie werden die Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur normalen Folie gehört.

Fügen Sie erforderliche Platzhalter einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalterform zu bereits bestehenden normalen Folien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern geerbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann jede davon abhängige Folie aktualisieren. Prüfen Sie vor dem Bearbeiten eines bereits genutzten Layouts dessen abhängige Folien und überprüfen Sie die resultierende Präsentation.  
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie zunächst seine abhängigen Folien einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/java/slide-master/).

Um geerbte Logos oder dekorative Master‑Formen auf einer Folie oder über ein gemeinsames Layout auszublenden, siehe [Control the Visibility of Master Graphics](/slides/de/java/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardisierten PowerPoint‑Layout‑Definitionen folgt. Layout‑Namen sind vom Benutzer editierbar und können lokalisiert werden, sodass eine namensbasierte Auswahl weniger zuverlässig ist, sofern Sie die Quellvorlage kontrollieren.

Das folgende Beispiel sucht nach **Title and Content** im ersten Master. Ist dieses Layout nicht verfügbar, fällt es bewusst auf **Blank** zurück. Der zweite Null‑Check ist nötig, weil eine Präsentation ausschließlich benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [ISlide.setLayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)‑Methode auf die erste normale Folie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die direkt hinzugefügten normalen Formen. Platzhalterpositionen, geerbte Formatierungen und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können sich jedoch ändern, weshalb das Ergebnis beim Wechsel zwischen stark unterschiedlichen Layouts geprüft werden sollte.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-)‑Methode in der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Title and Content**‑Layout mit dem Namen `Report Title and Content` hinzu und erzeugt anschließend eine normale Folie, die darauf basiert. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

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

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert ein passendes Layout bereits, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)‑Methode liefert einen [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint Platzhalter | `ILayoutPlaceholderManager` Methode |
| ---------------------- | ----------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Das folgende Beispiel überprüft, ob das **Blank**‑Layout vorhanden ist, fügt ihm vier Platzhalter hinzu und erzeugt dann eine normale Folie, die das geänderte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die normale Folie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie generieren kann.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Das Ändern geerbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht nachträglich in vorhandene normale Folien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen ungenutzter Layoutfolien**

Verwenden Sie die [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)‑Methode, um Layouts zu entfernen, auf die keine normale Folie verweist. Layouts, die noch verwendet werden, bleiben unverändert erhalten.

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

Um ein bestimmtes Layout zu entfernen, nutzen Sie zunächst dessen [hasDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--)‑ oder [getDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getDependingSlides--)‑Methode. Ordnen Sie abhängige Folien neu zu, bevor Sie [ILayoutSlide.remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#remove--) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑nummer‑ und Datum‑Uhrzeit‑Platzhalter. Verwenden Sie die [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--)‑Methode, um diese Platzhalter für ein Layout zu steuern. Dies ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titelfolien jedoch nicht.

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

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und dessen untergeordneten Layouts**

Um einheitliche Fußzeilen‑Einstellungen über eine Master‑Hierarchie hinweg anzuwenden, nutzen Sie die [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--)‑Methode. Die Verbreitungsmethoden des [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie richten sich nicht nur an eine einzelne normale Folie.

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

Eine Masterfolie definiert das Design und die geteilte Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und legt eine wiederverwendbare Anordnung von Platzhaltern fest. Normale Folien verwenden diese Layouts und speichern den folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie eine Kopie zur Ziel‑Sammlung mit der [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)‑Methode hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und andere vom Quell‑Layout genutzte Ressourcen prüfen.

**Was passiert, wenn ich ein Layout ändere, das bereits verwendet wird?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschrieben haben. Die Geometrie von Platzhaltern und geerbte Stile können daher gleichzeitig auf vielen Folien geändert werden. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getDependingSlides--), um die betroffenen Folien vor der Bearbeitung des Layouts zu ermitteln.

**Was passiert, wenn ich ein Layout entferne, das noch verwendet wird?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxeditexception/). Ordnen Sie zunächst die abhängigen Folien neu zu oder nutzen Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), um nur nicht referenzierte Layouts zu entfernen.