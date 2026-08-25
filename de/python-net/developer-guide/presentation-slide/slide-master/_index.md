---
title: Verwalten von Folienmastern in Präsentationen mit Python
linktitle: Folienmaster
type: docs
weight: 80
url: /de/python-net/slide-master/
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
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Python via .NET: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Theme‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides for Python via .NET unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Master‑Folien enthalten, und jede Master‑Folie kann mehrere Layout‑Folien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Master‑Folie. Stattdessen verwendet eine normale Folie eine Layout‑Folie, und diese Layout‑Folie gehört zu einer Master‑Folie.

Die Hierarchie ist:

1. **Folienmaster** – definiert das gemeinsame Design und Theme.  
1. **Layout‑Folie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.  

![Die Hierarchie von Master‑Folien, Layout‑Folien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die Klasse [MasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) repräsentiert. Alle Master‑Folien einer Präsentation sind über die Sammlung `Presentation.masters` verfügbar.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Zum Beispiel, wenn sowohl ein Folienmaster als auch eine Layout‑Folie einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layout‑Folien finden Sie unter [Anwenden oder Ändern von Folienlayouts](/slides/de/python-net/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `masters`, um auf Master‑Folien zuzugreifen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Sie können die von einer normalen Folie verwendete Master‑Folie auch über ihr Layout abrufen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Was ein Folienmaster enthält**

Eine Master‑Folie ist ein folienähnliches Objekt. Sie erbt das allgemeine Folienverhalten von der Klasse [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/) und stellt daher viele der gleichen Folieneigenschaften zur Verfügung, die von normalen und Layout‑Folien verwendet werden. Master‑spezifische Member sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Master‑Folie‑Member umfassen:

| Member | Zweck |
| --- | --- |
| `background` | Legt den Master‑Folienhintergrund fest. |
| `shapes` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `layout_slides` | Speichert die Layout‑Folien, die zum Master gehören. |
| `theme_manager` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `header_footer_manager` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Foliennummern für den Master und seine untergeordneten Layouts. |
| `get_depending_slides` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einer Master‑Folie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende visuelle Elemente.

Das folgende Beispiel fügt dem ersten Master‑Folie ein Logo hinzu:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Weitere Informationen zu Bildrahmen finden Sie unter [Bildrahmen](/slides/de/python-net/picture-frame/).

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Der Master‑Folie liefert den gemeinsamen Stil und das Theme, das diese Layouts erben, während jedes Layout bestimmt, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint stehen Platzhalterbefehle in der Folienmaster‑Ansicht zur Verfügung.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layout‑Folie, die zum Master gehört:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Sie können auch Platzhalterformen, die bereits auf einer Master‑Folie existieren, formatieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatierter Titel‑Platzhalter, vererbt von normalen Folien](slide-master_8.png)

Weitere Optionen für Platzhalter und Textformatierung finden Sie unter [Eingabetext im Platzhalter festlegen](/slides/de/python-net/manage-placeholder/) und [Textformatierung](/slides/de/python-net/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien übernommen, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einheitliche Hintergrundfarbe für die erste Master‑Folie:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Verwandte Themen finden Sie unter [Präsentationshintergrund](/slides/de/python-net/presentation-background/) und [Präsentationstheme](/slides/de/python-net/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie die Methode `add_clone` der Klasse [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/), um eine Master‑Folie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Folien klonen](/slides/de/python-net/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Master‑Folien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Master‑Folien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, ruft ein leeres Layout unter diesem geklonten Master ab und fügt eine neue Folie basierend auf diesem Layout hinzu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Folienmaster vergleichen**

Master‑Folien können mit der Methode `equals`, die von der Klasse [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/) geerbt wird, verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Bezeichner wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Weitere Informationen finden Sie unter [Präsentationsfolien vergleichen](/slides/de/python-net/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Eigenschaft `last_view` der Präsentations‑[ViewProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Weitere Ansichtseinstellungen finden Sie unter [Präsentation speichern](/slides/de/python-net/save-presentation/).

## **Unbenutzte Master‑Folien entfernen**

Präsentationen enthalten manchmal Master‑Folien, die von keiner normalen Folie mehr verwendet werden. Das Entfernen ungenutzter Master‑Folien kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `remove_unused`, um ungenutzte Master‑Folien aus der Sammlung `masters` zu entfernen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Sie können auch die Low‑Code‑Methode `remove_unused_master_slides` der Klasse [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) verwenden:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Was ist der Unterschied zwischen einem Folienmaster und einer Layout‑Folie?

Ein Folienmaster definiert gemeinsam genutzte Designeinstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layout‑Folie und erbt somit sowohl vom Layout als auch vom Master.

### Kann eine Präsentation mehrere Folienmaster enthalten?

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenauftritte benötigen.

### Sollte ich Platzhalter zu einem Folienmaster oder zu einer Layout‑Folie hinzufügen?

In den meisten Fällen sollten Sie Platzhalter zu Layout‑Folien hinzufügen. Platzieren Sie gemeinsam genutzte visuelle Elemente und Formatierungen auf dem Folienmaster und fügen Sie Inhalts‑Platzhalter zu den Layouts hinzu, die von normalen Folien verwendet werden.

### Kann ich einen Folienmaster löschen, der noch verwendet wird?

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master, oder verwenden Sie eine Aufräummethode für ungenutzte Master, die nur nicht verwendete Master entfernt.