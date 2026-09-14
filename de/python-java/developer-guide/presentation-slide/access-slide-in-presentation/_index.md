---
title: Zugriff auf Präsentationsfolien in Python
linktitle: Zugriff auf Folie
type: docs
weight: 20
url: /de/python-java/access-slide-in-presentation/
keywords:
- Folienzugriff
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python über Java Folien in PowerPoint- und OpenDocument-Präsentationen abrufen und verwalten. Steigern Sie die Produktivität mit Codebeispielen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Aspose.Slides Folien in einer Präsentation abruft und verwaltet. Er zeigt, wie man Folien über ihren nullbasierten Index aus der Folien‑Sammlung abruft und wie man über die eindeutige ID einer Folie mit der [getSlideById](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideById)‑Methode darauf zugreift.

Sie lernen außerdem, wie man die Position einer Folie mit der [setSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setSlideNumber)‑Methode ändert und wie man die Start‑Foliennummer einer Präsentation mit der [setFirstSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#setFirstSlideNumber)‑Methode festlegt. Die Beispiele zeigen das Laden einer Präsentation, das Abrufen von Folienreferenzen, das Aktualisieren von Folienreihenfolge oder -nummerierung und das Speichern der modifizierten Präsentation.

## **Zugriff auf eine Folie nach Index**

Alle Folien in einer Präsentation sind numerisch nach ihrer Position angeordnet, beginnend bei 0. Die erste Folie ist über Index 0 erreichbar; die zweite Folie über Index 1; usw.

Die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse, die eine Präsentationsdatei repräsentiert, stellt alle Folien als [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/)‑Sammlung (Sammlung von [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/)‑Objekten) bereit. Dieser Python‑Code zeigt, wie man über den Index auf eine Folie zugreift:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Erzeugen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("demo.pptx")
try:
    # Greifen Sie auf eine Folie über ihren Index zu.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Zugriff auf eine Folie nach ID**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die [getSlideById](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideById)‑Methode (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse) verwenden, um diese ID anzusprechen. Dieser Python‑Code zeigt, wie man eine gültige Folien‑ID übergibt und die Folie mit der [getSlideById](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideById)‑Methode abruft:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Erzeugen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("demo.pptx")
try:
    # Ermitteln Sie die Folien-ID.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Greifen Sie über die ID auf die Folie zu.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Folienposition ändern**

Aspose.Slides ermöglicht es, die Position einer Folie zu ändern. Beispielsweise können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index ab.
1. Legen Sie eine neue Position für die Folie mit der [setSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setSlideNumber)‑Methode fest.
1. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code demonstriert einen Vorgang, bei dem die Folie an Position 1 zu Position 2 verschoben wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Erzeugen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("Presentation.pptx")
try:
    # Holen Sie die Folie, deren Position geändert wird.
    slide = presentation.getSlides().get_Item(0)

    # Legen Sie die neue Position für die Folie fest.
    slide.setSlideNumber(2)

    # Speichern Sie die modifizierte Präsentation.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Beim Ändern der Folienposition werden andere Folien automatisch angepasst.

## **Foliennummer festlegen**

Mit der [setFirstSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#setFirstSlideNumber)‑Methode (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang führt dazu, dass andere Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie die Foliennummer ab.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code demonstriert einen Vorgang, bei dem die erste Foliennummer auf 10 gesetzt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Erzeugen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("HelloWorld.pptx")
try:
    # Ermitteln Sie die Foliennummer.
    first_slide_number = presentation.getFirstSlideNumber()

    # Setzen Sie die Foliennummer.
    presentation.setFirstSlideNumber(10)

    # Speichern Sie die modifizierte Präsentation.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) wie folgt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # Setzen Sie die Nummer für die erste Folie der Präsentation.
    presentation.setFirstSlideNumber(0)

    # Zeigen Sie Foliennummern für alle Folien an.
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # Verstecken Sie die Foliennummer der ersten Folie.
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # Speichern Sie die modifizierte Präsentation.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Stimmt die von einem Benutzer gesehenen Foliennummer mit dem nullbasierten Index der Sammlung überein?**

Die auf einer Folie angezeigte Nummer kann bei einem beliebigen Wert (z. B. 10) beginnen und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung der Präsentation’s [first slide number](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#setFirstSlideNumber) gesteuert.

**Beeinflussen ausgeblendete Folien die Indizierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indizierung gezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfügen, Löschen und Verschieben neu berechnet.