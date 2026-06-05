---
title: Verwalten von Präsentationsfolienmaster in Python
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
- ungenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Python via .NET: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Design‑Einstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Designthemen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für Python via .NET unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layout‑Folien enthalten. Normale Folien verweisen in der Regel nicht direkt auf einen Folienmaster. Stattdessen verwendet eine normale Folie eine Layout‑Folie, und diese Layout‑Folie gehört zu einem Folienmaster.

Die Hierarchie ist:

1. **Folienmaster** – definiert das gemeinsame Design und Theme.
1. **Layout‑Folie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die [MasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/)‑Klasse repräsentiert. Alle Folienmaster in einer Präsentation sind über die `Presentation.masters`‑Sammlung verfügbar.

{{% alert color="info" title="Vererbung" %}}
Wenn dieselbe Eigenschaft auf mehreren Ebenen definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn ein Folienmaster und eine Layout‑Folie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layout‑Folien finden Sie unter [Apply or Change Slide Layouts](/python-net/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die `masters`‑Sammlung, um auf Folienmaster zuzugreifen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Sie können den von einer normalen Folie verwendeten Folienmaster auch über ihr Layout erhalten:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Inhalt eines Folienmasters**

Ein Folienmaster ist ein folienähnliches Objekt. Er erbt das allgemeine Folienverhalten von der [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/)‑Klasse und stellt daher viele der gleichen Folieneigenschaften bereit, die von normalen und Layout‑Folien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Master‑Mitglieder umfassen:

| Mitglied | Zweck |
| --- | --- |
| `background` | Legt den master‑ Ebene Folienhintergrund fest. |
| `shapes` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsam genutzten Text. |
| `layout_slides` | Speichert die Layout‑Folien, die zum Master gehören. |
| `theme_manager` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `header_footer_manager` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Foliennummern für den Master und seine untergeordneten Layouts. |
| `get_depending_slides` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende visuelle Elemente.

Das folgende Beispiel fügt einem ersten Folienmaster ein Logo hinzu:

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

Weitere Informationen zu Bildrahmen finden Sie unter [Picture Frame](/python-net/picture-frame/).

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Der Folienmaster stellt den gemeinsamen Stil und das Theme bereit, das diese Layouts erben, während jedes Layout bestimmt, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Folienmaster‑Ansicht verfügbar.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

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

Sie können auch Platzhalterformen formatieren, die bereits auf einem Folienmaster vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) und [Text Formatting](/python-net/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien, die ihn nicht überschreiben, geerbt. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für den ersten Folienmaster:

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

Verwandte Themen finden Sie unter [Presentation Background](/python-net/presentation-background/) und [Presentation Theme](/python-net/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie die `add_clone`‑Methode der [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/)‑Klasse, um einen Folienmaster in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Clone Slides](/python-net/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Marken, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Das folgende Beispiel klont den Standardsmaster, gibt dem Klon einen anderen Hintergrund, holt ein leeres Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

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

Folienmaster können mit der aus der [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/)‑Klasse geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

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

Weitere Informationen finden Sie unter [Compare Presentation Slides](/python-net/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die `last_view`‑Eigenschaft der Präsentations‑[ViewProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Weitere Ansichtseinstellungen finden Sie unter [Save Presentation](/python-net/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner normalen Folie mehr verwendet werden. Das Entfernen ungenutzter Master kann die Dateigröße reduzieren und die Vorlagenwartung vereinfachen.

Verwenden Sie `remove_unused`, um unbenutzte Master aus der `masters`‑Sammlung zu entfernen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Sie können auch die Low‑Code‑Methode `remove_unused_master_slides` der [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/)‑Klasse verwenden:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layout‑Folie?**

Ein Folienmaster definiert gemeinsam genutzte Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layout‑Folie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Marken benötigen.

**Sollte ich Platzhalter zu einem Folienmaster oder zu einer Layout‑Folie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layout‑Folien hinzu. Gemeinsame visuelle Elemente und Formatierungen kommen auf den Folienmaster, während Inhalts‑Platzhalter auf den Layouts platziert werden, die von normalen Folien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie diese Folien zunächst zu Layouts unter einem anderen Master oder verwenden Sie eine Aufräummethode für unbenutzte Master, die nur Master entfernt, die nicht verwendet werden.