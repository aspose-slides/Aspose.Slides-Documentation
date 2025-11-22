---
title: Formen in Präsentationen mit Python verwalten
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/python-net/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentations-Form
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Alternativtext für Form
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für Python über .NET erstellen, bearbeiten und optimieren und hochperformante PowerPoint- und OpenDocument-Präsentationen bereitstellen."
---

## **Übersicht**

Dieses Handbuch führt in die Formmanipulation in Aspose.Slides für Python über .NET ein. Erfahren Sie praktische Muster zum Finden von Formen (auch über Alternative Text), Duplizieren, Löschen oder Ausblenden, Neuanordnen, Ausrichten und Drehen, Auslesen von IDs und layoutgesteuerter Formatierung sowie zum Exportieren einzelner Formen als SVG mithilfe der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) APIs.

## **Formen auf Folien finden**

PowerPoint identifiziert Formen nur über interne IDs. Weisen Sie der Ziel­form in PowerPoint einen eindeutigen Alt‑Text zu, öffnen Sie dann die Präsentation mit Aspose.Slides für Python, durchlaufen Sie die Formen der Folie und wählen Sie die aus, deren Alt‑Text übereinstimmt. Die Methode `find_shape` implementiert diesen Ansatz und gibt die passende Form zurück.
```py
import aspose.slides as slides

# Findet eine Form auf einer Folie anhand ihres Alternativtextes.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instanziiert die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Findet die Form mit Alt Text "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **Formen klonen**

Um Formen von einer Quellfolie zu einer neuen Folie in Aspose.Slides zu klonen, gehen Sie wie folgt vor:

1. Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aus der Quelldatei.  
2. Holen Sie die Quellfolie per Index und deren Formen‑Sammlung.  
3. Rufen Sie ein leeres Layout von der Master‑Folie ab.  
4. Fügen Sie mit diesem Layout eine leere Folie hinzu und erhalten Sie deren Formen.  
5. Klonen Sie die Formen in die Ziel‑Folie.  
6. Speichern Sie die Präsentation als PPTX.

Das folgende Code‑Beispiel klont Formen von einer Folie zur anderen.
```py
import aspose.slides as slides

# Instanziiert die Presentation-Klasse.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Speichert die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Formen entfernen**

Aspose.Slides ermöglicht das Entfernen beliebiger Formen von einer Folie. Beispiel: Um eine Form von der ersten Folie über ihren Alternative‑Text zu löschen, gehen Sie wie folgt vor:

1. Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt und laden Sie die Datei.  
2. Greifen Sie auf die erste Folie der Folien‑Sammlung zu.  
3. Finden Sie die Form über den Alternative‑Text‑Wert.  
4. Entfernen Sie die Form aus der Formen‑Sammlung der Folie.  
5. Speichern Sie die Präsentation im PPTX‑Format auf der Festplatte.
```py
import aspose.slides as slides

# Findet eine Form auf einer Folie anhand ihres Alternativtexts.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instanziiert die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Findet die Form mit Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Entfernt die Form.
    slide.shapes.remove(shape)
    # Speichert die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Formen ausblenden**

Aspose.Slides ermöglicht das Ausblenden beliebiger Formen auf einer Folie. Beispiel: Um eine Form auf der ersten Folie über ihren Alternative‑Text auszublenden, gehen Sie wie folgt vor:

1. Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt und laden Sie die Datei.  
2. Greifen Sie auf die erste Folie der Folien‑Sammlung zu.  
3. Finden Sie die Form über den Alternative‑Text‑Wert.  
4. Blenden Sie die Form aus.  
5. Speichern Sie die Präsentation im PPTX‑Format auf der Festplatte.
```py
# Findet eine Form auf einer Folie anhand ihres Alternativtexts.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instanziiert die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Findet die Form mit Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Blendet die Form aus.
    shape.hidden = True
    # Speichert die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Reihenfolge der Formen ändern**

Aspose.Slides erlaubt das Neuanordnen von Formen (Ändern ihrer Z‑Reihenfolge). Das Neuanordnen bestimmt, welche Form im Vordergrund bzw. im Hintergrund erscheint. Beispiel: Um zwei Formen auf der ersten Folie neu zu ordnen, gehen Sie wie folgt vor:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie die erste Form hinzu (z. B. ein Rechteck).  
4. Fügen Sie die zweite Form hinzu (z. B. ein Dreieck).  
5. Ordnen Sie die Formen neu, indem Sie die zweite Form an die erste Position in der Sammlung verschieben.  
6. Speichern Sie die Präsentation auf der Festplatte.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Füge zwei Formen zur Folie hinzu.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Verschiebe die zweite Form an die erste Position.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Interop‑Form‑ID abrufen**

Aspose.Slides ermöglicht das Abrufen einer eindeutigen Identifikationsnummer einer Form im Folien‑Geltungsbereich, im Gegensatz zur Eigenschaft `unique_id`, die über die gesamte Präsentation eindeutig ist. Die Eigenschaft `office_interop_shape_id` ist in der Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) verfügbar. Ihr Wert entspricht der `Id` des Objekts `Microsoft.Office.Interop.PowerPoint.Shape`. Ein Beispielcode‑Snippet ist unten dargestellt.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Erhalte die eindeutige Kennung der Form innerhalb der Folie.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **Alternative Text für Formen festlegen**

Aspose.Slides erlaubt das Festlegen von alternativem Text für beliebige Formen. Sie können den alternativen Text nutzen, um Formen in einer Präsentation zu identifizieren und zu finden. Die Alternative‑Text‑Eigenschaft kann sowohl über Aspose.Slides als auch über Microsoft PowerPoint gelesen und geschrieben werden. Durch das Taggen von Formen mit dieser Eigenschaft können Sie sie später entfernen, ausblenden oder neu anordnen.

Um den alternativen Text einer Form festzulegen, gehen Sie wie folgt vor:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie eine Form hinzu.  
4. Setzen Sie den alternativen Text.  
5. Speichern Sie die Präsentation auf der Festplatte.
```py
import aspose.slides as slides

# Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Fügt eine Form hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Setzt den Alternativtext für die Form.
    shape.alternative_text = "User Defined"
    # Speichert die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Layout‑Formate für Formen zugreifen**

Aspose.Slides stellt eine einfache API zum Zugriff auf Layout‑Formate für Formen bereit. Dieser Abschnitt demonstriert, wie Layout‑Formate abgerufen werden können.
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **Formen als SVG rendern**

Aspose.Slides unterstützt das Rendern von Formen als SVG. Die Methode `write_as_svg` (und ihre Überladungen) in der Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ermöglicht das Speichern des Inhalts einer Form als SVG‑Bild. Das untenstehende Code‑Snippet zeigt, wie eine Form in eine SVG‑Datei exportiert wird.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Hole die erste Form auf der ersten Folie.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **Form ausrichten**

Mit der Methode `align_shape` in der Klasse [SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) können Sie:

* Formen relativ zu den Folienrändern ausrichten (siehe Beispiel 1).  
* Formen relativ zueinander ausrichten (siehe Beispiel 2).

Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) definiert die verfügbaren Ausrichtungsoptionen.

**Beispiel 1**

Dieses Python‑Code‑Beispiel zeigt, wie die Formen mit den Indizes 1, 2 und 4 an der oberen Kante der Folie ausgerichtet werden:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**Beispiel 2**

Dieses Python‑Beispiel zeigt, wie alle Formen in einer Sammlung relativ zu der am weitesten unten liegenden Form dieser Sammlung ausgerichtet werden:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **Spiegelungs‑Eigenschaften**

In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) die Kontrolle über horizontales und vertikales Spiegeln von Formen über die Eigenschaften `flip_h` und `flip_v`. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) und erlauben Werte `TRUE` für eine Spiegelung, `FALSE` für keine Spiegelung oder `NOT_DEFINED`, um das Standardverhalten zu verwenden. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) einer Form zugänglich.

Um die Spiegelungs‑Einstellungen zu ändern, wird eine neue Instanz von [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flip_h` und `flip_v` sowie dem Rotationswinkel erstellt. Durch Zuordnen dieser Instanz zum [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) der Form und dem anschließenden Speichern der Präsentation werden die Spiegel‑Transformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzige Form mit den standardmäßigen Spiegelungs‑Einstellungen enthält, wie unten dargestellt.

![Die zu spiegelnde Form](shape_to_be_flipped.png)

Das folgende Code‑Beispiel ruft die aktuellen Spiegelungs‑Eigenschaften der Form ab und spiegelt sie horizontal und vertikal.
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Lese die horizontale Flip-Eigenschaft der Form.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Lese die vertikale Flip-Eigenschaft der Form.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Flip horizontal und vertikal.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die gespiegelte Form](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Schnitt/Menge‑Differenz) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für Boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst konstruieren – z. B. die resultierende Geometrie (über [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)) berechnen und eine neue Form mit diesem Umriss erstellen, optional die Originale entfernen.

**Wie kann ich die Stapel‑Reihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie die Z‑Reihenfolge nach allen anderen Folien‑Modifikationen finalisieren.

**Kann ich eine Form „sperren“, um zu verhindern, dass Nutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie [Form‑Schutz‑Flags](/slides/de/python-net/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf spiegeln Sie die Beschränkungen auf dem Master / Layout. Beachten Sie, dass dies nur UI‑Schutz ist, kein Sicherheitsmerkmal; für stärkeren Schutz kombinieren Sie ihn mit Dateischutz‑Optionen wie [Empfehlungen für schreibgeschützte Dateien oder Passwörter](/slides/de/python-net/password-protected-presentation/).