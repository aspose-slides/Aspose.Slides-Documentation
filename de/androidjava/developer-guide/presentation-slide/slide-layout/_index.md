---
title: Anwenden oder Ändern von Folienlayouts auf Android
linktitle: Folienlayout
type: docs
weight: 60
url: /de/androidjava/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- unbenutztes Layout
- Fußzeilen-Sichtbarkeit
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
- Android
- Java
- Aspose.Slides
description: "Anwenden, Erstellen und Ändern von Folienlayouts in Aspose.Slides für Android mittels Java, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und das Format von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine einheitliche Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die gebräuchlichsten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemein nutzbaren Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhaltsplatzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layout‑Vererbung**

Eine Präsentation hat drei verwandte Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) definiert das Design, die gemeinsame Formatierung, Hintergründe und gemeinsame Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [Standardfolie](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Standardfolie erbt das Design und die Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Standardfolie festgelegter Wert überschreibt den geerbten Wert auf dieser Ebene. Wenn eine Standardfolie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur Standardfolie gehört.

Fügen Sie einem Layout die erforderlichen Platzhalter hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalterform zu bereits vorhandenen Standardfolien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern von geerbter Formatierung oder vorhandener Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Bevor Sie ein bereits verwendetes Layout bearbeiten, prüfen Sie dessen abhängige Folien und überprüfen Sie die resultierende Präsentation.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zunächst einem anderen Layout zu oder entfernen Sie nur nicht genutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Slide Master](/slides/de/androidjava/slide-master/).

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den Standard‑PowerPoint‑Layoutdefinitionen folgt. Layoutnamen können vom Benutzer bearbeitet und lokalisiert werden, sodass eine nach Namen basierende Auswahl weniger zuverlässig ist, es sei denn, Sie steuern die Quellvorlage.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Wenn dieses Layout nicht verfügbar ist, greift es bewusst auf **Leer** zurück. Die zweite Null‑Prüfung ist erforderlich, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die Methode [ISlide.setLayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) auf die erste Standardfolie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Platzhalterpositionen, geerbte Formatierung und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können jedoch geändert werden, daher sollten Sie die Ausgabe überprüfen, wenn Sie zwischen deutlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die Methode [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) in der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine Standardfolie, die darauf basiert. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

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

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein passendes Layout, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die Methode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) liefert einen [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint‑Platzhalter | `ILayoutPlaceholderManager`‑Methode |
| ---------------------- | ----------------------------------- |
| ![Inhalt](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Inhalt (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertikal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Bild](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagramm](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabelle](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online‑Bild](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout vorhanden ist, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine Standardfolie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Standardfolie erstellt wird, damit Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie erzeugen kann.

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
Das Ändern von geerbter Formatierung oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht in vorhandene Standardfolien nachgetragen. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Nicht verwendete Layoutfolien entfernen**

Verwenden Sie die Methode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) , um Layouts zu entfernen, auf die keine Standardfolie verweist. Die Methode lässt weiterhin verwendete Layouts unverändert.

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

Um ein bestimmtes Layout zu entfernen, verwenden Sie zunächst dessen Methode [hasDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) oder [getDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) . Ordnen Sie abhängige Folien neu zu, bevor Sie [ILayoutSlide.remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#remove--) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout hat eigene Fußzeilen‑, Folien‑Nummern‑ und Datum‑Uhrzeit‑Platzhalter. Verwenden Sie die Methode [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) , um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titelfolien jedoch nicht.

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

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und seinen untergeordneten Layouts**

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die Methode [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . Die Verbreitungsmethoden von [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie seine abhängigen Layout‑ und Standardfolien; sie zielen nicht nur auf eine einzelne Standardfolie.

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

Eine Masterfolie definiert das Design bzw. das Thema der Präsentation und die gemeinsame Formatierung. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Standardfolien verwenden diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen überprüfen Sie zudem Schriften, Designs, Bilder und andere von der Quell‑Layout genutzte Ressourcen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffene Formatierung oder Objekte nicht lokal überschreiben. Die Platzhaltergeometrie und die vererbte Formatierung können daher gleichzeitig auf vielen Folien geändert werden. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) , um die betroffenen Folien vor der Bearbeitung des Layouts zu ermitteln.

**Was passiert, wenn ich ein noch verwendetes Layout entferne?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxeditexception/). Ordnen Sie zunächst die abhängigen Folien neu zu, oder verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) , um nur nicht referenzierte Layouts zu entfernen.