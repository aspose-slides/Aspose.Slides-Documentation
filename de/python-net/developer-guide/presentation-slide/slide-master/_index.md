---
title: PowerPoint-Folienmaster in Python verwalten
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
- Python
- Aspose.Slides
description: "Automatisieren Sie PowerPoint- und OpenDocument-Folienmaster mit Aspose.Slides für Python über .NET, um die Entwicklungseffizienz zu maximieren. Ein vollständiger Leitfaden für Einsteiger und Fortgeschrittene."
---

## **Übersicht**

Ein **Slide Master** ist eine Folienvorlage, die Layout, Stile, Design, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Slide Master verwenden.

Ein Slide Master ist nützlich, weil er es ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Slide‑Master‑Mechanismus von PowerPoint.

VBA ermöglicht ebenfalls, den Slide Master zu manipulieren und dieselben in PowerPoint unterstützten Vorgänge auszuführen: Hintergründe ändern, Formen hinzufügen, Layouts anpassen und mehr. Aspose.Slides bietet flexible APIs, mit denen Sie mit Slide Mastern arbeiten und gängige Aufgaben erledigen können.

Dies sind grundlegende Slide Master‑Operationen:

- Einen Slide Master erstellen.
- Den Slide Master auf Präsentationsfolien anwenden.
- Den Hintergrund des Slide Masters ändern.
- Ein Bild, Platzhalter, SmartArt usw. zum Slide Master hinzufügen.

Dies sind weiterführende Vorgänge, die den Slide Master betreffen:

- Slide Master vergleichen.
- Slide Master zusammenführen.
- Mehrere Slide Master anwenden.
- Eine Folie zusammen mit ihrem Slide Master in eine andere Präsentation kopieren.
- Doppelte Slide Master in Präsentationen identifizieren.
- Den Slide Master als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}}
Vielleicht möchten Sie sich den Aspose [Online PowerPoint Viewer](https://products.aspose.app/slides/viewer) ansehen, da er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse bietet.
{{% /alert %}}

## **Wie der Slide Master angewendet wird**

Bevor Sie mit einem Slide Master arbeiten, sollten Sie verstehen, wie Slide Master in Präsentationen verwendet und auf Folien angewendet werden.

- Jede Präsentation besitzt standardmäßig mindestens einen Slide Master.
- Eine Präsentation kann mehrere Slide Master enthalten. Sie können mehrere Slide Master hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten.

In Aspose.Slides wird ein Slide Master durch den Typ [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) repräsentiert.

Das Aspose.Slides‑Objekt [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) enthält die Sammlung [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) vom Typ [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), die alle in einer Präsentation definierten Master‑Folien hält.

Über CRUD‑Operationen hinaus bietet die Klasse [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) nützliche Methoden wie [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) und [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/). Diese erweitern die grundlegende Folien‑Klon‑Funktionalität und ermöglichen es Ihnen, bei der Arbeit mit Slide Mastern komplexere Setups zu implementieren.

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Slide Master darauf angewendet. Standardmäßig wird der Slide Master der vorherigen Folie ausgewählt.

**Hinweis:** Präsentationsfolien werden in der Sammlung [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) gespeichert, und jede neue Folie wird standardmäßig am Ende dieser Sammlung eingefügt. Enthält eine Präsentation nur einen Slide Master, wird dieser Slide Master für alle neuen Folien ausgewählt. Aus diesem Grund müssen Sie den Slide Master nicht für jede neu erstellte Folie angeben.

Das gleiche Prinzip gilt in PowerPoint und Aspose.Slides. Beispielsweise können Sie in PowerPoint beim Hinzufügen einer neuen Folie auf den Bereich unterhalb der letzten Folie klicken, und es wird eine neue Folie (unter Verwendung des Slide Masters der vorherigen Folie) erstellt.

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie dieselbe Aufgabe mithilfe der Methode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) ausführen.

## **Slide Master in der Folienhierarchie**

Die Verwendung von **Slide Layouts** zusammen mit dem **Slide Master** bietet maximale Flexibilität. Ein Slide Layout kann dieselben Stilarten wie der Slide Master definieren (Hintergrund, Schriftarten, Formen usw.). Wenn mehrere Slide Layouts unter einem Slide Master definiert werden, bilden sie gemeinsam ein zusammenhängendes Stilsystem. Durch das Anwenden eines Slide Layouts auf eine einzelne Folie können Sie dessen Stil im Verhältnis zum Slide Master anpassen.

Die Rangfolge ist: **Slide Master** → **Slide Layout** → **Slide**.

![todo:image_alt_text](slide-master_2.jpg)

Jedes [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)‑Objekt besitzt die Eigenschaft [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/), die die Liste der Slide Layouts enthält. Eine [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) hat die Eigenschaft [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/), die das angewendete Slide Layout referenziert. Die Interaktion zwischen einer Folie und dem Slide Master erfolgt über ihr Slide Layout.

{{% alert color="info" title="Hinweis" %}}
- In Aspose.Slides sind alle Folienkonstrukte (Slide Master, Slide Layout und die Folie selbst) Folienobjekte, die die Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) erweitern.
- Da Slide Master und Slide Layout viele der gleichen Eigenschaften bereitstellen, müssen Sie wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)‑Objekt angewendet werden. Der Slide Master wird zuerst angewendet, anschließend das Slide Layout. Beispiel: Wenn sowohl Slide Master als auch Slide Layout einen Hintergrund definieren, verwendet die Folie den Hintergrund des Slide Layouts.
{{% /alert %}}

## **Woraus ein Slide Master besteht**

Um zu verstehen, wie ein Slide Master geändert werden kann, müssen Sie seine Komponenten kennen. Dies sind die Kern‑Eigenschaften von [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/):

- `background` — ruft den Folienhintergrund ab bzw. legt ihn fest.
- `body_style` — ruft die Textstile für den Folienkörper ab bzw. legt sie fest.
- `shapes` — ruft alle Formen auf dem Slide Master ab bzw. legt sie fest (Platzhalter, Bildrahmen usw.).
- `controls` — ruft ActiveX‑Steuerelemente ab bzw. legt sie fest.
- `theme_manager` — ruft den Theme‑Manager ab.
- `header_footer_manager` — ruft den Header‑ und Footer‑Manager ab.

Methoden des Slide Masters:

- `get_depending_slides()` — ruft alle Folien ab, die vom Slide Master abhängen.
- `apply_external_theme_to_depending_slides(fname)` — erstellt einen neuen Slide Master basierend auf dem aktuellen und einem externen Theme und wendet den neuen Slide Master anschließend auf alle abhängigen Folien an.

## **Slide Master abrufen**

In PowerPoint können Sie den Slide Master über **Ansicht** → **Slide Master** aufrufen:

![todo:image_alt_text](slide-master_3.jpg)

Using Aspose.Slides, you can access a Slide Master as follows:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Die erste Masterfolie in der Präsentation abrufen.
    master_slide = presentation.masters[0]
```


Die Klasse [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) repräsentiert einen Slide Master. Die Eigenschaft [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) (eine [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) enthält alle in der Präsentation definierten Slide Master.

## **Ein Bild zum Slide Master hinzufügen**

Wenn Sie ein Bild zu einem Slide Master hinzufügen, wird dieses Bild auf allen Folien angezeigt, die von diesem Master abhängen.

Beispielsweise können Sie das Firmenlogo oder andere Bilder auf dem Slide Master platzieren und anschließend zur Normalansicht zurückkehren. Das Bild wird dann auf jeder abhängigen Folie angezeigt.

![todo:image_alt_text](slide-master_4.png)

You can add images to a Slide Master with Aspose.Slides:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="Siehe auch" %}}
Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Add Picture Frames to Presentations with Python](/slides/de/python-net/picture-frame/).
{{% /alert %}}

## **Einen Platzhalter zum Slide Master hinzufügen**

Diese Textfelder sind die Standard‑Platzhalter auf einem Slide Master:

- Klicken zum Bearbeiten des Master‑Titelstils
- Master‑Textstile bearbeiten
- Zweite Ebene
- Dritte Ebene

Diese Platzhalter erscheinen auch auf Folien, die auf dem Slide Master basieren. Sie können diese Platzhalter auf dem Slide Master bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet.

In PowerPoint können Sie einen Platzhalter über **Slide Master** → **Insert Placeholder** hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Betrachten wir ein komplexeres Beispiel für Platzhalter in Aspose.Slides. Nehmen Sie eine Folie mit Platzhaltern, die vom Slide Master geerbt wurden:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Slide Master wie folgt aktualisieren:

![todo:image_alt_text](slide-master_7.png)

Zuerst holen Sie den Titel‑Platzhalter vom Slide Master ab und verwenden anschließend die Eigenschaft `PlaceHolder.fill_format`:

```python
# Referenz auf den Titel-Platzhalter der Masterfolie erhalten.
title_placeholder = master_slide.shapes[0]

# Füllformat auf Verlauf setzen.
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


Der Titelstil und die Formatierung ändern sich auf allen Folien, die auf dem Slide Master basieren:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}}
* [Platzhalter in Präsentationen mit Python verwalten](/slides/de/python-net/manage-placeholder/)
* [PowerPoint‑Text in Python formatieren](/slides/de/python-net/text-formatting/)
{{% /alert %}}

## **Slide Master‑Hintergrund ändern**

Wenn Sie die Hintergrundfarbe eines Slide Masters ändern, übernehmen alle regulären Folien in der Präsentation die neue Farbe. Der folgende Python‑Code demonstriert dies:
```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="Siehe auch" %}}
- [Präsentationshintergründe in Python verwalten](/slides/de/python-net/presentation-background/)
- [PowerPoint‑Präsentationsthemen in Python verwalten](/slides/de/python-net/presentation-theme/)
{{% /alert %}}

## **Mehrere Slide Master zu einer Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Slide Master und Slide Layouts zu einer beliebigen Präsentation. Damit können Sie Stile, Layouts und Formatierungsoptionen für Folien auf vielfältige Weise konfigurieren.

In PowerPoint können Sie neue Slide Master und Slide Layouts über das Menü **Slide Master** wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Slide Master hinzufügen, indem Sie die Methode `add_clone` aufrufen:
```python
# Neue Masterfolie hinzufügen.
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **Slide Master vergleichen**

Ein Slide Master erweitert die Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), die die Methode `equals(slide)` zum Vergleich von Folien enthält. Diese Methode gibt true zurück, wenn Slide Master in Struktur und statischem Inhalt identisch sind.

Zwei Slide Master gelten als gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen identisch sind. Der Vergleich ignoriert eindeutige Kennzeichnerwerte (z. B. `slide_id`) und dynamische Inhalte (z. B. das aktuelle Datum in einem Datums‑Platzhalter).

## **Slide Master als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht das Festlegen eines Slide Masters als Standardansicht der Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie die Präsentation öffnen. Das folgende Python‑Beispiel zeigt, wie ein Slide Master als Standardansicht der Präsentation festgelegt wird:
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as presentation:
    # Legen Sie die Standardansicht als Folienmaster-Ansicht fest.
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Präsentation speichern.
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Unbenutzte Master‑Folien entfernen**

Aspose.Slides stellt die Methode `remove_unused_master_slides` (in der Klasse [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) bereit, um unerwünschte, unbenutzte Master‑Folien zu löschen. Der folgende Python‑Code zeigt, wie unbenutzte Master‑Folien aus einer PowerPoint‑Präsentation entfernt werden:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Was ist ein Slide Master in PowerPoint?**

Ein Slide Master ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht es, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern.

**Wie stehen Slide Master zu Slide Layouts?**

Slide Layouts arbeiten zusammen mit Slide Mastern, um Flexibilität beim Foliendesign zu bieten. Während ein Slide Master übergeordnete Stile und Designs definiert, ermöglichen [Slide Layouts](/slides/de/python-net/slide-layout/) Variationen in der Anordnung von Inhalten. Die Hierarchie ist wie folgt:

- **Slide Master** → Definiert globale Stile.
- **Slide Layout** → Bietet unterschiedliche Inhaltsanordnungen.
- **Slide** → Erbt das Design von ihrem Slide Layout.

**Kann ich mehrere Slide Master in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Slide Master enthalten. Das ermöglicht es, verschiedene Abschnitte einer Präsentation auf unterschiedliche Weise zu gestalten und bietet Flexibilität im Design.

**Wie kann ich mit Aspose.Slides auf einen Slide Master zugreifen und ihn ändern?**

In Aspose.Slides wird ein Slide Master durch die Klasse [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) repräsentiert. Sie können einen Slide Master über die Eigenschaft [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts abrufen.