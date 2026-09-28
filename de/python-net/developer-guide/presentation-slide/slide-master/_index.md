---
title: Verwalten von Präsentations-Slide-Mastern in Python
linktitle: Slide-Master
type: docs
weight: 80
url: /de/python-net/slide-master/
keywords:
- Slide-Master
- Master-Folie
- PPT-Master-Folie
- Mehrere Master-Folien
- Master-Folien vergleichen
- Hintergrund
- Platzhalter
- Master-Folie klonen
- Master-Folie kopieren
- Master-Folie duplizieren
- Unbenutzte Master-Folie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Slide-Master in Aspose.Slides für Python via .NET: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Master-Folien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Slide-Master** definiert gemeinsame Design‑Einstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Design‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Slide‑Masters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides for Python via .NET unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Master‑Folien enthalten, und jede Master‑Folie kann mehrere Layout‑Folien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Master‑Folie. Stattdessen verwendet eine normale Folie eine Layout‑Folie, und diese Layout‑Folie gehört zu einer Master‑Folie.

Die Hierarchie ist:

1. **Slide-Master** – definiert das gemeinsame Design und das Theme.  
1. **Layout‑Folie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.

![Die Hierarchie von Master‑Folien, Layout‑Folien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Slide‑Master durch die [MasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/)‑Klasse dargestellt. Alle Master‑Folien einer Präsentation sind über die Sammlung `Presentation.masters` zugänglich.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn ein Master‑Slide und ein Layout‑Slide beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layout‑Folien finden Sie unter [Apply or Change Slide Layouts](/slides/de/python-net/slide-layout/).
{{% /alert %}}

## **Zugriff auf Slide-Master**

In PowerPoint können Sie die Slide‑Master‑Ansicht über **Ansicht** > **Slide Master** öffnen.

![Der Slide‑Master‑Befehl auf der PowerPoint‑Ansicht‑Registerkarte](slide-master_3.jpg)

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

Sie können auch die Master‑Folie erhalten, die von einer normalen Folie über ihr Layout verwendet wird:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Was ein Slide-Master enthält**

Ein Master‑Slide ist ein folienähnliches Objekt. Es erbt das gemeinsame Folienverhalten von der [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/)‑Klasse, sodass es viele der gleichen Folieneigenschaften bereitstellt, die von normalen und Layout‑Folien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Master‑Slide‑Mitglieder umfassen:

| Mitglied | Zweck |
| --- | --- |
| `background` | Legt den Folienhintergrund auf Master‑Ebene fest. |
| `shapes` | Speichert Formen, die auf dem Master platziert sind, z. B. Logos, Bildrahmen und gemeinsam genutzten Text. |
| `layout_slides` | Speichert die Layout‑Folien, die zum Master gehören. |
| `theme_manager` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `header_footer_manager` | Steuert Kopf‑ und Fußzeilen, Datum und Foliennummern für den Master und dessen untergeordnete Layouts. |
| `get_depending_slides` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Slide-Master hinzufügen**

Wenn Sie ein Bild zu einem Master‑Slide hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende visuelle Elemente.

Das folgende Beispiel fügt dem ersten Master‑Slide ein Logo hinzu:

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

Weitere Informationen zu Bildrahmen finden Sie unter [Picture Frame](/slides/de/python-net/picture-frame/).

## **Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/show_master_shapes/), um geerbte Master‑Grafiken wie Logos oder dekorative Formen auszublenden, ohne sie aus dem Master zu löschen. Setzen Sie [Slide.show_master_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/show_master_shapes/) auf `False` bei der Folie, die diese Grafiken weglassen soll, und lassen Sie es bei Folien, die sie anzeigen sollen, auf `True`.

Das folgende, eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabepräsentation oder Bilddatei ist erforderlich.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Das Beispiel verwendet das mit einer neuen Präsentation gelieferte **Blank**‑Layout und entfernt die ursprünglichen Platzhalter der ersten Folie.

### **Wählen Sie den Geltungsbereich der Einstellung**

Eine normale Folie verwendet ihren Master über [Slide.layout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/layout_slide/) und [LayoutSlide.master_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/master_slide/). Das Setzen der Eigenschaft auf einer einzelnen Folie beeinflusst nur diese Folie. Das Setzen von [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/show_master_shapes/) auf `False` blendet Master‑Grafiken für alle Folien aus, die dieses gemeinsame Layout verwenden, selbst wenn ihre eigene Einstellung `True` ist. Um Grafiken nur auf einer Folie zu verbergen, ändern Sie die Folien‑Eigenschaft und lassen das gemeinsame Layout unverändert.

Die Einstellung wird nicht als Sichtbarkeitssteuerung auf dem Master‑Slide selbst unterstützt. Auf einem Master gibt sie immer `False` zurück, und das Zuweisen von `True` löst eine Ausnahme aus. Wenden Sie sie stattdessen auf eine normale Folie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Vorgang | Auswirkung |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu ändern. |
| Folienhintergrundfüllung ändern | Ändert die Hintergrundfarbe, den Farbverlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Presentation Background](/slides/de/python-net/presentation-background/). |
| Form vom Master löschen | Entfernt die gemeinsam genutzte Quellform, sodass sie für keine Folie mehr verfügbar ist, die diesen Master verwendet. |

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Der Master‑Slide liefert den gemeinsamen Stil und das Theme, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Slide‑Master‑Ansicht verfügbar.

![Der Befehl „Platzhalter einfügen“ in der PowerPoint‑Slide‑Master‑Ansicht](slide-master_5.png)

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

Sie können auch Platzhalterformen formatieren, die bereits auf einem Master‑Slide vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

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

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen zur Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/slides/de/python-net/manage-placeholder/) und [Text Formatting](/slides/de/python-net/text-formatting/).

## **Den Hintergrund eines Slide-Masters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einheitliche Hintergrundfarbe für den ersten Master‑Slide:

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

Für verwandte Themen siehe [Presentation Background](/slides/de/python-net/presentation-background/) und [Presentation Theme](/slides/de/python-net/presentation-theme/).

## **Einen Slide-Master in eine andere Präsentation klonen**

Verwenden Sie die Methode `add_clone` der Klasse [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/), um einen Master‑Slide in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, lesen Sie [Clone Slides](/slides/de/python-net/clone-slides/).

## **Mehrere Slide-Master hinzufügen**

Eine Präsentation kann mehrere Master‑Folien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Marken, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Master‑Folien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erhält ein leeres Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

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

## **Slide-Master vergleichen**

Master‑Slides können mit der von [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/) geerbten Methode `equals` verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

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

Weitere Informationen finden Sie unter [Compare Presentation Slides](/slides/de/python-net/compare-slides/).

## **Slide-Master‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Eigenschaft `last_view` auf den Präsentations‑[ViewProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Slide‑Master‑Ansicht:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Weitere Ansichtseinstellungen finden Sie unter [Save Presentation](/slides/de/python-net/save-presentation/).

## **Unbenutzte Master‑Folien entfernen**

Präsentationen enthalten manchmal Master‑Folien, die von keinen normalen Folien mehr verwendet werden. Das Entfernen unbenutzter Master‑Folien kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `remove_unused`, um unbenutzte Master‑Folien aus der Sammlung `masters` zu entfernen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Sie können zudem die Low‑Code‑Methode `remove_unused_master_slides` der Klasse [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) verwenden:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einem Slide-Master und einer Layout‑Folie?**

Ein Slide‑Master definiert gemeinsam genutzte Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Master‑Slide und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layout‑Folie und erbt dadurch sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Slide-Master enthalten?**

Ja. Eine Präsentation kann mehrere Slide‑Master enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Marken benötigen.

**Sollte ich Platzhalter zu einem Master‑Slide oder zu einer Layout‑Folie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layout‑Folien hinzu. Gemeinsame visuelle Elemente und Formatierungen kommen auf den Master‑Slide, während Inhalts‑Platzhalter auf den Layout‑Folien platziert werden, die von normalen Folien verwendet werden.

**Kann ich einen Master‑Slide löschen, der noch verwendet wird?**

Nein. Ein Master‑Slide, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master, oder verwenden Sie eine Aufräummethode, die nur unbenutzte Master‑Slides entfernt.