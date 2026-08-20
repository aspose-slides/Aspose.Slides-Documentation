---
title: Verwalten von Präsentationsformen in Python
linktitle: Formenmanipulation
type: docs
weight: 40
url: /de/python-net/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form klonen
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Alternativtext der Form
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via .NET Präsentationsformen identifizieren, klonen, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for Python via .NET stellt die Formen auf einer Folie als geordnete [ShapeCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Zuerst wird erklärt, wie man eine Form zuverlässig identifiziert, dann wird gezeigt, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die letzten Abschnitte behandeln Layout‑Formatierung, SVG‑Export, Ausrichtung und Spiegel‑Einstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow benötigt.

## **Identifizieren und Finden von Formen**

Sammlungsindizes sind praktisch beim Verarbeiten einer bekannten Datei, aber sie sind keine stabilen Kennungen. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie eine Kennung nach dem Vorgehen, wie die Präsentation erstellt und gepflegt wird:

- [Shape.name](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/name/) ist nützlich für entwicklerkontrollierte Vorlagen und lässt sich leicht im Auswahlbereich von PowerPoint prüfen. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention etablieren, wenn Code von ihnen abhängt.
- [Shape.alternative_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/alternative_text/) ist hilfreich, wenn eine Barrierefreiheits‑Beschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Sie ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie bedeutungsvollen Barrierefrei‑Text nicht stillschweigend als Datenbank‑Schlüssel.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/office_interop_shape_id/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Form‑ID entspricht. Nutzen Sie ihn bei der Integration mit PowerPoint oder wenn Sie während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [Shape.unique_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/unique_id/)‑Eigenschaft hat Geltungsbereich der Präsentation, ist jedoch für Add‑Ins vorgesehen und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn langfristige Identität entscheidend ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach `name` mit einem exakten Vergleich und gibt die folienbezogene Interop‑ID aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie den Typ, bevor Sie typ‑spezifische Member verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) ist.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Formensammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge der Formen ändert, dürfen Sie nicht weiterhin auf vor dem Vorgang erfasste Indizes vertrauen.

### **Eine Form klonen**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_clone/) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Collection‑Ende an. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/insert_clone/) erzeugt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten entgegennehmen, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erzeugt eine Ziel‑Folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone verändern nicht die Quellform.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Das Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und Alternativtexts. Weisen Sie dem Klon neue logische Kennungen zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Collection‑Element mit einer neuen Form‑Identität.

### **Formen entfernen**

[ShapeCollection.remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Wenn beim indizierten Durchlaufen mehrere Treffer entfernt werden, iterieren Sie von hinten, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest `slide.shapes[index]`, nicht ein festes Collection‑Element, und wirft die Form nicht unnötig.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes nachfolgender Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die sich auf das entfernte Objekt beziehen können; das Entfernen einer sichtbaren Form kann mehr als nur das Aussehen der Folie verändern.

### **Eine Form ausblenden**

Das Setzen von [Shape.hidden](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/hidden/) auf `True` behält die Form in der Sammlung, verhindert jedoch ihr Auftreten in der normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für den Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Ausblenden ist kein Löschen oder eine Sicherheitsmaßnahme. Das Objekt kann weiterhin gefunden und von einem Benutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z-Order ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gezeichnet. [ShapeCollection.reorder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/reorder/) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist hinten; `len(slide.shapes) - 1` ist vorne.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Order, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Collection‑Elemente anhängen oder einfügen und die beabsichtigte Stapelung ändern können.

## **Formen auf Layout‑Folien prüfen**

Normale Folien, Layout‑Folien und Master‑Folien besitzen getrennte Formensammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Prüfen Sie Layout‑Formen, wenn Sie Formatierungen verstehen oder ändern möchten, die von einem Layout bereitgestellt werden.

Das folgende Beispiel liest für jede Layout‑Form das [Shape.fill_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/fill_format/) und das [Shape.line_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/line_format/), ohne anzunehmen, dass jede Form eine `AutoShape` ist.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

[Shape.write_as_svg](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/write_as_svg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Halten Sie die Präsentation beim Rendern offen. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen.

## **Formen ausrichten**

Die [SlideUtil.align_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/align_shapes/)‑Überladungen richten entweder alle Formen oder ausgewählte Collection‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder den Verteilungsmodus an. Setzen Sie `align_to_slide` auf `True`, um die Folienkanten zu verwenden; setzen Sie es auf `False`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Ihre aktuellen Indizes werden unmittelbar vor der Ausrichtung ermittelt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Ausrichtung ändert Positionen, nicht die Z‑Order. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen zur Bestimmung des Abstands benötigt. Berechnen Sie die Indizes neu, wenn Sie die Sammlung vor dem Methodenaufruf modifizieren.

## **Eine Form spiegeln**

Die [ShapeFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapeframe/)‑Klasse speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Rotation. Ihre `flip_h`‑ und `flip_v`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/python-net/aspose.slides/nullablebool/): `TRUE` aktiviert die Spiegelung, `FALSE` deaktiviert sie und `NOT_DEFINED` bewahrt den nicht‑definierten oder Standardzustand.

Die Eingabe‑Präsentation unten enthält eine nicht gespiegelt‑Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel übernimmt alle anderen Frame‑Werte und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Shape.frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/frame/) den gesamten Frame ersetzt.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, während Position, Größe und Rotation erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungsindex als Form‑Kennung verwenden?**

Nur für kurzlebige Verarbeitung, bei der die Sammlung vor der Nutzung des Index nicht geändert wird. Bevorzugen Sie eine validierte `name`‑ oder `alternative_text`‑Konvention für authorisierte Vorlagen oder `office_interop_shape_id` für interop‑bezogene Arbeiten innerhalb einer Folie.

**Entfernt das Ausblenden einer Form sie aus dem Z‑Order?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu geordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`add_clone` fügt den Klon an das Ende der Sammlung an, das ist die Vorderseite des Z‑Orders. Verwenden Sie `insert_clone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.