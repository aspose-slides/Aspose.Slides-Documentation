---
title: Folienlayouts in Python über Java anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/python-java/slide-layout/
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
- Python
- Java
- Aspose.Slides
description: "Folienlayouts in Aspose.Slides für Python über Java anwenden, erstellen und ändern, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und die Formatierung von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, ermöglicht jedoch, dass jede Folie ihren eigenen Inhalt enthält.

Die gebräuchlichsten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel-Platzhalter und einen allgemeinen Inhalts-Platzhalter.
- **Leer**: Enthält keine Inhalts-Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layout-Vererbung**

Eine Präsentation hat drei verwandte Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) definiert das Design, die gemeinsame Formatierung, Hintergründe und gemeinsame Objekte.
2. Eine [Layoutfolie](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
3. Eine [Normale Folie](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine normale Folie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom Master. Ein direkt auf einer normalen Folie festgelegter Wert überschreibt den vererbten Wert auf dieser Ebene. Wenn eine normale Folie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur normalen Folie gehört.

Fügen Sie die erforderlichen Platzhalter einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout führt nicht automatisch zur Erstellung einer entsprechenden Platzhalterform in bereits bestehenden normalen Folien.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern der vererbten Formatierung oder der vorhandenen Platzhalter-Geometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts sollten Sie dessen abhängige Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie zunächst seine abhängigen Folien einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/python-java/slide-master/).

Um geerbte Logos oder dekorative Master‑Formen auf einer Folie bzw. über ein gemeinsam genutztes Layout auszublenden, siehe [Steuern der Sichtbarkeit von Mastergrafiken](/slides/de/python-java/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswählen und Anwenden eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint‑Layoutdefinitionen folgt. Layoutnamen sind vom Benutzer editierbar und können lokalisiert werden, sodass eine namensbasierte Auswahl weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** zurückgegriffen. Die zweite Prüfung auf `None` ist nötig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird anschließend über die [Slide.setLayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setLayoutSlide)‑Methode auf die erste normale Folie angewendet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ändern des Layouts einer Folie entfernt nicht die regulären Formen, die direkt zur Folie hinzugefügt wurden. Platzhalterpositionen, vererbte Formatierungen und die Zuordnung zwischen bestehenden Platzhaltern und dem neuen Layout können sich jedoch ändern, daher sollten Sie die Ausgabe prüfen, wenn Sie zwischen erheblich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterlayoutslidecollection/#add)‑Methode in der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine normale Folie, die darauf basiert. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage wirklich eine weitere wiederverwendbare Struktur benötigt. Wenn bereits ein passendes Layout existiert, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erzeugen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getPlaceholderManager)‑Methode liefert einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint-Platzhalter | [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/) Methode |
| ---------------------- | ---------------------------------- |
| ![Inhalt](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhalt (vertikal)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (vertikal)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagramm](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabelle](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medien](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online-Bild](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine normale Folie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die normale Folie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie erzeugen kann.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

{{% alert color="warning" title="Warnung" %}}
Das Ändern der vererbten Formatierung oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bestehende normale Folien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Nicht verwendete Layoutfolien entfernen**

Verwenden Sie die [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑Methode, um Layouts zu entfernen, auf die keine normale Folie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um ein bestimmtes Layout zu entfernen, nutzen Sie zuerst dessen [hasDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#hasDependingSlides)‑ oder [getDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getDependingSlides)‑Methode. Ordnen Sie abhängige Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#remove) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummer‑ und Datum‑Uhr‑Platzhalter. Verwenden Sie die [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑Methode, um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilenelemente sichtbar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und seinen untergeordneten Layouts**

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, nutzen Sie die [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getHeaderFooterManager)‑Methode. Die Propagations‑Methoden von [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie zielen nicht nur auf eine einzelne Normalfolie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Design und die gemeinsame Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normale Folien verwenden diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/globallayoutslidecollection/#addClone)‑Methode eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und andere vom Quell‑Layout genutzte Ressourcen prüfen.

**Was passiert, wenn ich ein Layout ändere, das bereits verwendet wird?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschreiben. Die Geometrie von Platzhaltern und vererbte Stile können dadurch gleichzeitig auf vielen Folien geändert werden. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getDependingSlides), um die betroffenen Folien vor dem Bearbeiten des Layouts zu ermitteln.

**Was passiert, wenn ich ein Layout entferne, das noch verwendet wird?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/). Ordnen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedLayoutSlides), um nur nicht referenzierte Layouts zu entfernen.