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
- alternativer Text der Form
- Form-Anpassungspunkt
- voreingestellte Formanpassung
- Formgeometrie
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für Python via .NET identifizieren, anpassen, klonen, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for Python via .NET stellt die Formen auf einer Folie als geordnete [ShapeCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die am weitesten hinten liegende Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Er erklärt zunächst, wie man eine Form zuverlässig identifiziert und voreingestellte Anpassungspunkte einer Form ändert, und zeigt anschließend, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑ebene Formatierungen, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner je nach Art und Pflege der Präsentation:

- [Shape.name](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/name/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlfenster von PowerPoint inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention festlegen, wenn Code von ihnen abhängt.
- [Shape.alternative_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/alternative_text/) ist sinnvoll, wenn eine Barrierefreiheit‑Beschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Sie ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie keinen bedeutungsvollen Barrierefreiheitstext stillschweigend als Datenbankschlüssel.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/office_interop_shape_id/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der Shape‑ID entspricht, die von PowerPoint‑Interop verwendet wird. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige Eigenschaft [Shape.unique_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/unique_id/) hat Geltungsbereich für die gesamte Präsentation, ist jedoch für Add‑Ins vorgesehen und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn langfristige Identität wichtig ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach `name` mit einem exakten Vergleich und gibt die interop‑ID im Folienbereich aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

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

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie den Typ, bevor Sie typ‑spezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) ist.

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

## **Voreingestellte Formanpassungen identifizieren und ändern**

Voreingestellte Geometrieformen können Anpassungspunkte bereitstellen, die Eigenschaften wie Eckgröße, Pfeil‑Proportionen oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte Sammlung [GeometryShape.adjustments](https://reference.aspose.com/slides/de/python-net/aspose.slides/geometryshape/adjustments/) darauf zu. Die Sammlung selbst wird von der Form bereitgestellt, aber jedes [AdjustValue](https://reference.aspose.com/slides/de/python-net/aspose.slides/adjustvalue/) enthält einen Wert, der geändert werden kann.

Verlassen Sie sich nicht ausschließlich auf einen festen Sammlungsindex. Durchlaufen Sie die Anpassungen und prüfen Sie die schreibgeschützte Eigenschaft [AdjustValue.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/adjustvalue/type/), deren Wert vom Typ [ShapeAdjustmentType](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapeadjustmenttype/) beschreibt, was die Anpassung steuert. Die schreibgeschützte Eigenschaft [AdjustValue.name](https://reference.aspose.com/slides/de/python-net/aspose.slides/adjustvalue/name/) liefert zusätzliche Identifikationsinformationen und ist besonders nützlich, wenn ein Preset mehr als eine Anpassung desselben semantischen Typs enthält.

Verwenden Sie die Werteigenschaft, die der Bedeutung der Anpassung entspricht:

| Anpassungstyp | Zweck | Zu ändernder Wert |
|---|---|---|
| `CORNER_SIZE` | Größe abgerundeter Ecken | [raw_value](https://reference.aspose.com/slides/de/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Dicke des Pfeilschafts | `raw_value` |
| `ARROWHEAD_LENGTH` | Länge der Pfeilspitze | `raw_value` |
| `ARROWHEAD_WIDTH` | Breite der Pfeilspitze | `raw_value` |
| `START_ANGLE` | Startwinkel eines Torten- oder Bogenabschnitts | [angle_value](https://reference.aspose.com/slides/de/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Endwinkel eines Torten- oder Bogenabschnitts | `angle_value` |

`type` und `name` können nicht zugewiesen werden. `raw_value` ist ein Lese‑/Schreib‑Integer in den nativen Geometriemaßeinheiten des Presets, während `angle_value` ein Lese‑/Schreib‑Winkel in Grad ist. Anzahl, Reihenfolge, Bedeutung und gültiger Wertebereich der Anpassungen hängen vom Preset‑Typ [GeometryShape.shape_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/geometryshape/shape_type/) ab. Ein Wert, der für ein Preset gültig ist, kann für ein anderes ungültig sein oder eine andere Wirkung haben.

Wenn `type` `ShapeAdjustmentType.CUSTOM` ist, erkennt die API keine standardisierte semantische Bedeutung. Prüfen Sie `name`, den Preset‑Typ und den bestehenden Wert und lassen Sie die Anpassung unverändert, es sei denn, die erwartete Bedeutung und der Wertebereich sind bekannt. Auch bei erkannten Typen sollten Sie prüfen, ob derselbe Typ mehrmals vorkommt, bevor Sie einen Wert auswählen. Der Artikel [Connector](/slides/de/python-net/connector/) zeigt diese Situation bei Biegungsanpassungen von Verbindern.

Das folgende vollständige Beispiel erstellt Standard‑ und modifizierte Versionen von drei voreingestellten Formen. Es durchläuft jede Anpassung, gibt deren `name` und `type` aus, ändert größenbezogene Werte über `raw_value`, ändert Winkel über `angle_value` und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den vierfachen Pfeil und das Tortenstück.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Überschriften für die Standard- und angepassten Formspalten hinzufügen.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Das Prüfen des semantischen Typs vor der Werteänderung macht den Code explizit hinsichtlich seiner Absicht und verhindert Annahmen, dass ein bestimmter Sammlungsindex dieselbe Bedeutung bei unterschiedlichen Preset‑Formen hat.

## **Die Formensammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Ändert ein Vorgang die Anzahl oder Reihenfolge der Formen, dürfen Sie nicht weiterhin auf zuvor erfasste Indizes vertrauen.

### **Eine Form klonen**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_clone/) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Collection‑Ende an. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/insert_clone/) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn zudem skalieren.

Das Beispiel erstellt eine Ziel‑Folien, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon nach hinten ein. Änderungen an einem der Klone beeinflussen nicht die Quellform.

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

Das Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und Alternativtexts. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Collection‑Element mit einer neuen Form‑Identität.

### **Formen entfernen**

[ShapeCollection.remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration sollten Sie von hinten nach vorne durchlaufen, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest `slide.shapes[index]`, nicht ein fixes Collection‑Element, und castet die Form nicht unnötig.

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

Nach dem Entfernen ändern sich die Formanzahl und die Indizes nachfolgender Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie zudem Verbinder, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen können; das Entfernen einer sichtbaren Form kann mehr als nur das Aussehen der Folie ändern.

### **Eine Form ausblenden**

Das Setzen von [Shape.hidden](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/hidden/) auf `True` lässt die Form in der Sammlung, verhindert aber ihr Auftreten in der normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

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

Ausblenden bedeutet nicht Löschen oder Sicherheit. Das Objekt kann weiterhin gefunden und von einem Benutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Die Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gemalt. [ShapeCollection.reorder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/reorder/) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist der hinterste; `len(slide.shapes) - 1` ist der vorderste.

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

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum finalen Index bringt es nach vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Collection‑Elemente anhängen oder einfügen und die beabsichtigte Stapelung verändern können.

## **Formen auf Layout‑Folien inspizieren**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Formensammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Inspizieren Sie Layout‑Formen, wenn Sie die durch ein Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form [Shape.fill_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/fill_format/) und [Shape.line_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/line_format/) aus, ohne anzunehmen, dass jede Form ein `AutoShape` ist.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Das Bearbeiten eines Layouts kann mehrere Folien betreffen, die es verwenden. Bevor Sie eine Layout‑Form ändern, prüfen Sie, ob eine normale Folie das Objekt erbt oder lokal überschreibt, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

[Shape.write_as_svg](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/write_as_svg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

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

Halten Sie die Präsentation während des Renderns offen. Die Ausgabe hängt von der Formatierung der Form und von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie anstelle einer einzelnen Form. Der Aufrufer besitzt den Stream und muss diesen schließen.

## **Formen ausrichten**

Die Überladungen von [SlideUtil.align_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/align_shapes/) richten entweder alle Formen oder ausgewählte Collection‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder Verteilungsart an. Setzen Sie `align_to_slide` auf `True`, um die Folienränder zu verwenden; setzen Sie es auf `False`, um die ausgewählten Formen relativ zueinander auszurichten.

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

Ausrichtung ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung ausreichend Formen braucht, um Abstände zu definieren. Berechnen Sie Indizes neu, wenn Sie die Sammlung vor dem Aufruf der Methode ändern.

## **Eine Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Rotation. Ihre Werte `flip_h` und `flip_v` verwenden [NullableBool](https://reference.aspose.com/slides/de/python-net/aspose.slides/nullablebool/): `TRUE` aktiviert die Spiegelung, `FALSE` deaktiviert sie und `NOT_DEFINED` bewahrt den nicht festgelegten oder Standardzustand.

Die Eingabepäsentation unten enthält eine nicht gespiegelt Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Shape.frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/frame/) den gesamten Frame ersetzt.

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

Die gespeicherte Form ist horizontal und vertical gespiegelt, wobei Position, Größe und Rotation erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungs‑Index als Form‑Identifikator verwenden?**

Nur für kurzlebige Verarbeitung, bei der die Sammlung vor der Nutzung des Index nicht verändert wird. Bevorzugen Sie ein validiertes `name`‑ oder `alternative_text`‑Konzept für erstellte Vorlagen oder `office_interop_shape_id` für interop‑Arbeiten im Folien‑Bereich.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`add_clone` fügt den Klon am Ende der Sammlung hinzu, was dem vordersten Teil der Z‑Reihenfolge entspricht. Verwenden Sie `insert_clone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.

**Kann ich einen festen Index verwenden, um eine voreingestellte Form‑Anpassung zu identifizieren?**

Nur nach einer Validierung des genauen Presets und der Sammlungsstruktur. Durchlaufen Sie lieber `GeometryShape.adjustments` und prüfen Sie `AdjustValue.type`; verwenden Sie `AdjustValue.name` als zusätzliche Information, wenn derselbe semantische Typ mehrmals vorkommt.