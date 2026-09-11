---
title: Verwalten von Präsentationsformen in Python via Java
linktitle: Formbearbeitung
type: docs
weight: 40
url: /de/python-java/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- alternativer Text der Form
- Form-Anpassungspunkt
- vorgegebene Formanpassung
- Formgeometrie
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für Python via Java identifizieren, anpassen, duplizieren, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for Python via Java stellt die Formen auf einer Folie als geordnete [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Er erklärt zunächst, wie man eine Form zuverlässig identifiziert und voreingestellte Formanpassungspunkte ändert, zeigt dann, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑Ebene‑Formatierung, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuanordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner entsprechend der Erstellung und Pflege der Präsentation:

- [Name](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getName) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich im Auswahl‑Bereich von PowerPoint leicht inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention festlegen, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getAlternativeText) ist nützlich, wenn eine Barrierefreiheitsbeschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Sie ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie bedeutungsvollen Barrierefreiheitstext nicht stillschweigend als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getOfficeInteropShapeId) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Form‑ID entspricht. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form eine eindeutige Referenz benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [getUniqueId](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getUniqueId)-Methode gibt einen Bezeichner mit Präsentationsumfang zurück, aber dieser Bezeichner ist für Add‑Ins vorgesehen und kann neu zugewiesen werden. Er sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn langfristige Identität entscheidend ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach Namen mit einem exakten Vergleich und gibt die folienbezogene Interop‑ID aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt weiterzumachen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie den Typ, bevor Sie typspezifische Member verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Voreingestellte Formanpassungen identifizieren und ändern**

Vorgefertigte Geometrieformen können Anpassungspunkte besitzen, die Eigenschaften wie Eckgröße, Pfeilproportionen oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte [GeometryShape.getAdjustments](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#getAdjustments)-Sammlung darauf zu. Die Sammlung selbst wird von der Form bereitgestellt, aber jedes [AdjustValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/) enthält einen Wert, der geändert werden kann.

Verlassen Sie sich nicht ausschließlich auf einen festen Sammlungsindex. Durchlaufen Sie die Anpassungen und prüfen Sie die schreibgeschützte [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType)-Methode, deren [ShapeAdjustmentType](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/)-Wert beschreibt, was die Anpassung kontrolliert. Die schreibgeschützte [getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName)-Methode liefert zusätzliche Identifikationsinformationen und ist besonders nützlich, wenn ein Voreinstellung mehr als eine Anpassung desselben semantischen Typs enthält.

Verwenden Sie die Werthandhabung, die zur Bedeutung der Anpassung passt:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Größe abgerundeter Ecken | [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Dicke eines Pfeilschafts | [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Länge einer Pfeilspitze | [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Breite einer Pfeilspitze | [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Startwinkel eines Kreisabschnitts oder Bogens | [setAngleValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Endwinkel eines Kreisabschnitts oder Bogens | [setAngleValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType) und [getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName) liefern schreibgeschützte Informationen. [getRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getRawValue) und [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue) arbeiten mit einem Integer in den nativen Geometrie‑Einheiten der Voreinstellung, während [getAngleValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getAngleValue) und [setAngleValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setAngleValue) mit einem Winkel in Grad arbeiten. Anzahl, Reihenfolge, Bedeutung und gültiger Bereich der Anpassungen hängen vom [ShapeType](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#getShapeType) der Voreinstellung ab. Ein für eine Voreinstellung gültiger Wert kann für eine andere ungültig sein oder eine andere Wirkung haben.

Wenn [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType) [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#Custom) zurückgibt, erkennt die API keine standardmäßige semantische Bedeutung. Untersuchen Sie [getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName), den Voreinstellungs­typ und den vorhandenen Wert und lassen Sie die Anpassung unverändert, wenn die erwartete Bedeutung und der Bereich nicht bekannt sind. Selbst bei anerkannten Typen prüfen Sie, ob derselbe Typ mehrmals vorkommt, bevor Sie einen Wert auswählen. Der Artikel [Connector](/slides/de/python-java/connector/) zeigt diese Situation bei Bieganpassungen von Connectors.

Das folgende vollständige Beispiel erzeugt Standard‑ und modifizierte Versionen von drei Voreinstellungsformen. Es durchläuft jede Anpassung, gibt deren Namen und Typ aus, ändert größenbezogene Werte über [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue), ändert Winkel über [setAngleValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setAngleValue) und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie bei; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den vier‑weg‑Pfeil und das Kuchen‑Diagramm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Fügt Überschriften für die Standard- und angepassten Formspalten hinzu.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Prüfen des semantischen Typs vor einer Wertänderung macht den Code eindeutig in seiner Absicht und verhindert Annahmen, dass ein bestimmter Sammlungsindex dieselbe Bedeutung über verschiedene Voreinstellungsformen hinweg hat.

## **Die Formsammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge von Formen ändert, verlassen Sie sich nicht weiter auf vor dem Vorgang erfasste Indizes.

### **Eine Form klonen**

[addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addClone) erzeugt eine unabhängige Kopie und fügt sie der Ziel‑Sammlung hinzu. [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#insertClone) erzeugt ebenfalls eine Kopie, legt sie jedoch an einem angegebenen Z‑Order‑Index ab. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erzeugt eine Ziel‑Folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone beeinflussen nicht die Ausgangsform.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und Alternativtexts. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Sammlungs‑Element mit neuer Form‑Identität.

### **Formen entfernen**

[remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#remove) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Wenn Sie mehrere Treffer während einer indizierten Iteration entfernen, traversieren Sie von hinten, sodass jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem bestimmten Namen. Es liest die Form am aktuellen Index, nicht ein festes Sammlungs‑Element, und wirft die Form nicht unnötig.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nach dem Entfernen ändern sich die Formanzahl und die Indizes späterer Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Connectors, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen können; das Entfernen einer sichtbaren Form kann mehr als das Aussehen der Folie verändern.

### **Eine Form ausblenden**

Setzen von [Hidden](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setHidden) auf `True` behält die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Diashow. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für Code zugänglich, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ausblenden ist kein Löschen oder eine Sicherheitsmaßnahme. Das Objekt kann weiterhin von einem Benutzer oder Code entdeckt und wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Order ändern**

Überlappende Formen werden in Sammlungsreihenfolge gezeichnet. [reorder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#reorder) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist der hintere; die [size](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#size) minus eins ist der vordere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter dem Ellipsen‑Objekt. Das Verschieben zum letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Order, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Sammlungs‑Elemente anhängen oder einfügen und die beabsichtigte Stapelreihenfolge ändern können.

## **Formen in Layout‑Folien inspizieren**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Inspizieren Sie Layout‑Formen, wenn Sie die von einem Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getFillFormat) und das [LineFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getLineFormat), ohne anzunehmen, dass jede Form eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Das Bearbeiten eines Layouts kann mehrere Folien betreffen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

Die `writeAsSvg`‑Methode von [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält die Form, nicht den gesamten Folien‑Hintergrund oder benachbarte Formen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Halten Sie die Präsentation während des Renderns geöffnet. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriftarten und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen.

## **Formen ausrichten**

Die [SlideUtil.alignShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#alignShapes)-Überladungen richten entweder alle Formen oder ausgewählte Sammlungsindizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder den Verteilungsmodus an. Setzen Sie `align_to_slide` auf `True`, um die Folienkanten zu verwenden; setzen Sie es auf `False`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ausrichtung ändert Positionen, nicht die Z‑Order. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung ausreichend Formen für die Abstanddefinition benötigt. Berechnen Sie Indizes neu, wenn Sie die Sammlung vor dem Aufruf der Methode ändern.

## **Eine Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegelungs‑Einstellungen sowie Rotation. Ihre [getFlipH](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeframe/#getFlipH)- und [getFlipV](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeframe/#getFlipV)-Werte nutzen [NullableBool](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht definierten/Standard‑Zustand.

Die Eingabe‑Präsentation unten enthält eine nicht gespiegelte Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel bewahrt alle anderen Frame‑Werte und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Setzen eines neuen [Frame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setFrame) den gesamten Frame ersetzt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, während Position, Größe und Rotation erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungs‑Index als Form‑Bezeichner verwenden?**

Nur für kurzlebige Vorgänge, bei denen die Sammlung vor der Nutzung des Index nicht geändert wird. Bevorzugen Sie ein validiertes [Name](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getName)- oder [AlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getAlternativeText)-Konzept für erstellte Vorlagen oder [OfficeInteropShapeId](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getOfficeInteropShapeId) für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Order?**

Nein. Eine ausgeblendete Form bleibt an ihrem Index in der Sammlung. Sie kann gefunden, neu geordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

[addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addClone) fügt den Klon am Ende der Sammlung ein, was dem Vordergrund der Z‑Order entspricht. Verwenden Sie [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#insertClone), um den Anfangs‑Index zu wählen, oder [reorder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#reorder) nach dem Hinzufügen aller Formen.

**Kann ich einen festen Index verwenden, um eine voreingestellte Formanpassung zu identifizieren?**

Nur nach Validierung der genauen Voreinstellung und Sammlungs‑Layout. Bevorzugen Sie das Durchlaufen von [GeometryShape.getAdjustments](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#getAdjustments) und das Prüfen von [AdjustValue.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType); verwenden Sie [AdjustValue.getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName) als zusätzliche Information, wenn derselbe semantische Typ mehrmals vorkommt.