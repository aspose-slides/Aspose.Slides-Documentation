---
title: "Anwenden oder Ändern von Folienlayouts in Python via Java"
linktitle: "Folienlayout"
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
- Python
- Java
- Aspose.Slides
description: "Anwenden, Erstellen und Ändern von Folienlayouts in Aspose.Slides für Python via Java, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Fußzeilen‑Sichtbarkeit steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und Formatierungen von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die gebräuchlichsten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen universellen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layoutvererbung**

Eine Präsentation hat drei zusammengehörige Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) definiert das Design, die gemeinsame Formatierung, Hintergründe und gemeinsame Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [Normalfolie](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Normalfolie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Normalfolie gesetzter Wert überschreibt den vererbten Wert auf dieser Ebene. Beim Erstellen einer Normalfolie werden ihre Platzhalter‑Formen aus dem ausgewählten Layout erzeugt, während der in diese Platzhalter eingegebene Inhalt zur Normalfolie gehört.

Fügen Sie erforderliche Platzhalter zu einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalter‑Form zu bereits bestehenden Normalfolien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern von geerbter Formatierung oder vorhandener Platzhalter‑Geometrie eines Layouts kann jede abhängige Folie aktualisieren. Bevor Sie ein bereits verwendetes Layout bearbeiten, prüfen Sie dessen abhängige Folien und überprüfen Sie die resultierende Präsentation.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie zunächst seine abhängigen Folien einem anderen Layout zu oder entfernen Sie nur nicht verwendete Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/python-java/slide-master/).

## **Auswählen und Anwenden eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den Standard‑PowerPoint‑Layout‑Definitionen folgt. Layout‑Namen sind vom Benutzer editierbar und können lokalisiert werden, sodass die Auswahl nach Namen weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Im folgenden Beispiel wird auf dem ersten Master nach **Titel und Inhalt** gesucht. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** zurückgegriffen. Die zweite Prüfung auf `None` ist notwendig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das gefundene Layout wird dann mittels der [Slide.setLayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setLayoutSlide)‑Methode auf die erste Normalfolie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Platzhalter‑Positionen, geerbte Formatierung und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können sich jedoch ändern, sodass Sie die Ausgabe prüfen sollten, wenn Sie zwischen wesentlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterlayoutslidecollection/#add)‑Methode auf der Layout‑Sammlung des Ziel‑Masters auf.

Im folgenden Beispiel wird stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzugefügt und anschließend eine Normalfolie darauf basierend erstellt. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

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

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein passendes Layout, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getPlaceholderManager)‑Methode liefert einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/) zum Hinzufügen von Platzhalter‑Formen zu einem Layout.

| PowerPoint Platzhalter | [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/) Methode |
| ---------------------- | ----------------------------------- |
| ![Inhalt](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhalt (Vertikal)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertikal)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagramm](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabelle](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medien](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online-Bild](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Im folgenden Beispiel wird überprüft, ob das **Leer**‑Layout existiert, vier Platzhalter hinzugefügt und anschließend eine Normalfolie erstellt, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Normalfolie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalter‑Formen auf dieser Folie erzeugen kann.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Das Ändern von geerbter Formatierung oder der Geometrie bestehender Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht in bereits vorhandene Normalfolien nachgetragen. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Nicht verwendete Layoutfolien entfernen**

Verwenden Sie die [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑Methode, um Layouts zu entfernen, auf die keine Normalfolie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

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

Um ein bestimmtes Layout zu entfernen, nutzen Sie zuerst dessen [hasDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#hasDependingSlides)‑ oder [getDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getDependingSlides)‑Methode. Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#remove) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummer‑ und Datum‑Uhr‑Platzhalter. Verwenden Sie die [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑Methode, um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn z. B. Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

Im folgenden Beispiel wird ein Layout sicher ausgewählt und dessen Fußzeilen‑Elemente sichtbar gemacht:

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

Um konsistente Fußzeilen‑Einstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getHeaderFooterManager)‑Methode. Die Verbreitungsmethoden des [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie auf dessen abhängige Layout‑ und Normalfolien; sie richten sich nicht nur an eine einzelne Normalfolie.

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

Eine Masterfolie definiert das Design und die gemeinsame Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und definiert ein wiederverwendbares Arrangement von Platzhaltern. Normalfolien nutzen diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie eine Kopie zur Ziel‑Sammlung mit der [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/globallayoutslidecollection/#addClone)‑Methode hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und andere vom Quell‑Layout genutzte Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffene Formatierung oder Objekte nicht lokal überschrieben haben. Platzhalter‑Geometrie und vererbte Stile können dadurch auf vielen Folien gleichzeitig geändert werden. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getDependingSlides), um die betroffenen Folien vor der Bearbeitung des Layouts zu identifizieren.

**Was passiert, wenn ich ein Layout entferne, das noch verwendet wird?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/). Ordnen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedLayoutSlides), um nur unreferenzierte Layouts zu entfernen.