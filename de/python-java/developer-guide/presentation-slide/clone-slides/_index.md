---
title: Präsentationsfolien klonen in Python
linktitle: Folien klonen
type: docs
weight: 35
url: /de/python-java/clone-slides/
keywords:
- Folie klonen
- Folie kopieren
- Folie speichern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Duplizieren Sie PowerPoint‑Folien schnell mit Aspose.Slides for Python via Java. Folgen Sie unseren klaren Code‑Beispielen, um die PPT‑Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu eliminieren."
---
## **Einführung**

Cloning ist der Vorgang, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides for Python via Java ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle Präsentation oder jede andere offene Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Wege, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon zusammen mit seiner Masterfolie in eine andere Präsentation.

In Aspose.Slides for Python via Java stellt die Folienkollektion (eine Sammlung von [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/)‑Objekten), die vom [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) und [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen.

## **Klon einer Folie am Ende einer Präsentation**

Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone)‑Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Holen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) indem Sie die von dem Objekt [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) bereitgestellte Slides‑Sammlung referenzieren.
1. Rufen Sie die von dem Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) auf und übergeben Sie die zu klonende Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone).
1. Schreiben Sie die geänderte Präsentationsdatei.

Im Beispiel unten haben wir eine Folie (die an erster Position – Index 0 – der Präsentation liegt) bis zum Ende der Präsentation geklont.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziiere die Presentation‑Klasse, die eine Präsentationsdatei darstellt
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Schreibe die geänderte Präsentation auf die Festplatte
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klon einer Folie an eine andere Position innerhalb einer Präsentation**

Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, verwenden Sie die [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone)‑Methode:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf die Folienkollektion, die von [getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) des Objekts [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) zurückgegeben wird.
1. Rufen Sie die von dem Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) bereitgestellte Methode [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone) auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone).
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im Beispiel unten haben wir eine Folie (die an Index 1 – Position 2 – der Präsentation liegt) zu Index 2 – Position 3 – der Präsentation geklont.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziiere die Presentation‑Klasse, die eine Präsentationsdatei darstellt
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Rufe die Sammlung der Folien in der Präsentation ab
    slides = presentation.getSlides()

    # Klone die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Schreibe die geänderte Präsentation auf die Festplatte
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klon einer Folie am Ende einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) die die Präsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Holen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) indem Sie die von dem Objekt [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) der Zielpräsentation zurückgegebene Folienkollektion referenzieren.
1. Rufen Sie die von dem Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone).
1. Schreiben Sie die geänderte Zieldatei der Präsentation.

Im Beispiel unten haben wir eine Folie (aus Index 0 der Quellpräsentation) bis zum Ende der Zielpräsentation geklont.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziiere die Presentation‑Klasse, um die Quellpräsentationsdatei zu laden
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanziiere die Presentation‑Klasse für die Ziel‑PPTX (wo die Folie geklont werden soll)
    destination_presentation = Presentation()
    try:
        # Klone die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Schreibe die Zielpräsentation auf die Festplatte
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klon einer Folie an eine andere Position in einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Holen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) indem Sie die von dem Objekt [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) der Zielpräsentation bereitgestellte Slides‑Sammlung referenzieren.
1. Rufen Sie die von dem Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) bereitgestellte Methode [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone) auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone).
1. Schreiben Sie die geänderte Zieldatei der Präsentation.

Im Beispiel unten haben wir eine Folie (aus Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziiere die Presentation‑Klasse, um die Quellpräsentationsdatei zu laden
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanziiere die Presentation‑Klasse für die Ziel‑PPTX (wo die Folie geklont werden soll)
    destination_presentation = Presentation()
    try:
        # Klone die gewünschte Folie aus der Quellpräsentation an den angegebenen Index in der Zielpräsentation
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Schreibe die Zielpräsentation auf die Festplatte
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klon einer Folie mit ihrer Masterfolie in eine andere Präsentation**

Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, klonen Sie zuerst die gewünschte Masterfolie von der Quell‑ in die Zielpräsentation. Anschließend verwenden Sie die geklonte Masterfolie beim Klonen der Folie. Die [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone)‑Methode erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Befolgen Sie dazu die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Holen Sie das Objekt [MasterSlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/) indem Sie die von dem Objekt [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) der Zielpräsentation bereitgestellte Masters‑Sammlung referenzieren.
1. Rufen Sie die von dem Objekt [MasterSlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/#addClone) auf und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/#addClone).
1. Holen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) indem Sie die von dem Objekt [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) der Zielpräsentation bereitgestellte Slides‑Sammlung referenzieren.
1. Rufen Sie die von dem Objekt [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) auf und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone).
1. Schreiben Sie die geänderte Zieldatei der Präsentation.

Im Beispiel unten haben wir eine Folie mit einer Masterfolie (die am Index 0 der Quellpräsentation liegt) bis zum Ende der Zielpräsentation geklont, wobei die Masterfolie der Quellfolie verwendet wurde.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instanziiere die Presentation-Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    destination_presentation = Presentation()
    try:
        # Instanziiere die Folie aus der Sammlung von Folien in der Quellpräsentation zusammen mit
        # Master-Folie
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Kopiere die gewünschte Master-Folie aus der Quellpräsentation in die Sammlung von Master-Folien in der
        # Zielpräsentation
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Kopiere die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        # Sammlung von Folien in der Zielpräsentation
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Speichere die Zielpräsentation auf die Festplatte
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klon einer Folie am Ende eines angegebenen Abschnitts**

Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone)‑Methode, die von der Klasse [**SlideCollection**](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) bereitgestellt wird. Aspose.Slides for Python via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das anschließende Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Der folgende Code‑Auszug zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Speichere die Zielpräsentation auf die Festplatte
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Übereinstimmende Foliengröße sicherstellen**

Beim Klonen von Folien in eine andere Präsentation stellen Sie sicher, dass die Zielpräsentation dieselbe Foliengröße wie die Quellpräsentation hat. Wenn die Foliengrößen unterschiedlich sind, skaliert Aspose.Slides die geklonten Formen nicht automatisch – deren ursprüngliche Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte falsch ausgerichtet sind oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie an die Quelle anpassen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Tun Sie dies, bevor Sie den Master und die Folie klonen.

## **FAQ**

**Werden Sprecherreferenzen und Prüferkommentare geklont?**

Ja. Die Notizenseite und Prüfkommentare werden in den Klon übernommen. Wenn Sie sie nicht benötigen, [entfernen Sie sie](/slides/de/python-java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und ihre Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/python-java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/python-java/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben Sie anschließend die Folie dorthin.