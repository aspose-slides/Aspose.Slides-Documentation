---
title: Verwalten von Folienmastern in Präsentationen mit Python via Java
linktitle: Folienmaster
type: docs
weight: 70
url: /de/python-java/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Python via Java: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert geteilte Design‑Einstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Thema‑Einstellungen und Fußzeilen‑Einstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters die übliche Methode, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für Python via Java unterstützt dasselbe Modell. Eine Präsentation kann ein oder mehrere Masterfolien enthalten, und jede Masterfolie kann mehrere Layoutfolien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Masterfolie. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einer Masterfolie.

Die Hierarchie ist:

1. **Folienmaster** – definiert das geteilte Design und das Thema.  
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und layoutbezogener Formatierung.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Masterfolien, Layoutfolien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die Klasse [MasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) dargestellt. Alle Masterfolien in einer Präsentation sind über die Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasters) verfügbar, die durch [MasterSlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/) repräsentiert wird.

{{% alert color="info" title="Vererbung" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Zum Beispiel, wenn sowohl eine Masterfolie als auch eine Layoutfolie einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Hintergrund des Layouts. Weitere Informationen zu Layoutfolien finden Sie unter [Anwenden oder Ändern von Folienlayouts](/slides/de/python-java/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasters) um auf Masterfolien zuzugreifen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Sie können die von einer normalen Folie verwendete Masterfolie auch über ihr Layout erhalten:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Was ein Folienmaster enthält**

Eine Masterfolie ist ein folienähnliches Objekt. Sie erbt von [BaseSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/), sodass sie viele der selben Folieneigenschaften bereitstellt, die von normalen und Layoutfolien verwendet werden. Master‑spezifische Member sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Masterfolien‑Member umfassen:

| Member | Zweck |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getBackground) | Setzt den Master‑Folienhintergrund. |
| [getShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getShapes) | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| [getLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getLayoutSlides) | Speichert die Layoutfolien, die zum Master gehören. |
| [getThemeManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getThemeManager) | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Steuert Kopf‑ und Fußzeilen, Datum und Folienzahlen für den Master und seine untergeordneten Layouts. |
| [getDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getDependingSlides) | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einer Masterfolie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Dies ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende visuelle Elemente.

Das folgende Beispiel fügt der ersten Masterfolie ein Logo hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Weitere Informationen zu Bildrahmen finden Sie unter [Bildrahmen](/slides/de/python-java/picture-frame/).

## **Die Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#setShowMasterShapes), um geerbte Master‑Grafiken, wie Logos oder dekorative Formen, auszublenden, ohne sie vom Master zu löschen. Übergeben Sie `False` an [Slide.setShowMasterShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setShowMasterShapes) auf der Folie, die diese Grafiken weglassen soll, und lassen Sie es `True` auf Folien, die sie anzeigen sollen.

Das folgende eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabepräsentation oder Bild ist erforderlich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Beispiel verwendet das mit einer neuen Präsentation gelieferte Layout **Blank** und entfernt die eigenen Platzhalter der Anfangsfolie.

### **Den Geltungsbereich der Einstellung wählen**

Eine normale Folie verwendet ihren Master über [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getLayoutSlide) und [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getMasterSlide). Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf diese Folie. Das Übergeben von `False` an [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#setShowMasterShapes) blendet Master‑Grafiken für Folien aus, die dieses gemeinsame Layout verwenden, selbst wenn deren eigene Einstellung `True` ist. Um Grafiken nur auf einer Folie auszublenden, ändern Sie die Folieneigenschaft und lassen das gemeinsame Layout unverändert.

Die Einstellung wird nicht als Sichtbarkeitssteuerung auf der Masterfolie selbst unterstützt. Auf einem Master gibt [getShowMasterShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getShowMasterShapes) stets `False` zurück, und das Übergeben von `True` an [setShowMasterShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#setShowMasterShapes) löst eine Ausnahme aus. Wenden Sie sie stattdessen auf eine normale Folie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Operation | Effekt |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu ändern. |
| Folienhintergrundfüllung ändern | Ändert die Hintergrundfarbe, den Verlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Präsentationshintergrund](/slides/de/python-java/presentation-background/). |
| Eine Form vom Master löschen | Entfernt die gemeinsame Quellform, sodass sie für keine Folie mehr verfügbar ist, die diesen Master verwendet. |

## **Mit Platzhaltern arbeiten**

Platzhalter werden normalerweise auf Layoutfolien definiert. Die Masterfolie liefert den gemeinsamen Stil und das Theme, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint stehen Platzhalterbefehle in der Folienmaster‑Ansicht zur Verfügung.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sie können auch Platzhalterformen, die bereits auf einer Masterfolie existieren, formatieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Prompt‑Text im Platzhalter festlegen](/slides/de/python-java/manage-placeholder/) und [Textformatierung](/slides/de/python-java/text-formatting/).

## **Den Hintergrund einer Folienmaster ändern**

Ein Master‑Hintergrund wird von Layouts und Folien, die ihn nicht überschreiben, geerbt. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für die erste Masterfolie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für verwandte Themen siehe [Präsentationshintergrund](/slides/de/python-java/presentation-background/) und [Präsentationsthema](/slides/de/python-java/presentation-theme/).

## **Eine Folienmaster in eine andere Präsentation klonen**

Verwenden Sie [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/#addClone), um eine Masterfolie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Folien klonen](/slides/de/python-java/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Masterfolien enthalten. Dies ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenbildung, Seitenstruktur oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Masterfolien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie hinzu, die auf diesem Layout basiert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Masterfolien vergleichen**

Masterfolien können mit der von [BaseSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/) geerbten Methode [equals](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#equals) verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen, wie Folien‑IDs, oder dynamische Platzhalterwerte, wie das aktuelle Datum.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Für weitere Informationen siehe [Präsentationsfolien vergleichen](/slides/de/python-java/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Methode [setLastView](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setLastView) auf [ViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für weitere Ansichtseinstellungen siehe [Präsentation speichern](/slides/de/python-java/save-presentation/).

## **Ungenutzte Masterfolien entfernen**

Präsentationen enthalten manchmal Masterfolien, die von keiner normalen Folie mehr verwendet werden. Das Entfernen ungenutzter Master kann die Dateigröße reduzieren und die Vorlagenwartung vereinfachen.

Verwenden Sie [removeUnused](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/#removeUnused), um ungenutzte Master aus der Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasters) zu entfernen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sie können zudem die Low‑Code‑Methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedMasterSlides) verwenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layoutfolie?**

Ein Folienmaster definiert gemeinsame Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einer Masterfolie und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie, sodass sie sowohl vom Layout als auch vom Master erbt.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Marken benötigen.

**Sollte ich Platzhalter zu einer Masterfolie oder einer Layoutfolie hinzufügen?**

In den meisten Fällen sollten Sie Platzhalter zu Layoutfolien hinzufügen. Gemeinsame visuelle Elemente und gemeinsame Formatierung auf die Masterfolie setzen, dann Inhalts‑Platzhalter auf die Layouts, die von normalen Folien verwendet werden.

**Kann ich eine Masterfolie löschen, die noch verwendet wird?**

Nein. Eine Masterfolie, die abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master, oder verwenden Sie eine Bereinigungs‑Methode für ungenutzte Master, die nur Master entfernt, die nicht verwendet werden.