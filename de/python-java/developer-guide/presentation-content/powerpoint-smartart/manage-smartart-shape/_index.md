---
title: SmartArt-Grafiken in Präsentationen mit Python verwalten
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/python-java/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt zugreifen
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint SmartArt in Python mit Aspose.Slides, inklusive kompakter Codebeispiele und leistungsorientierter Anleitungen."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, SmartArt‑Grafiken in PowerPoint‑Präsentationen programmgesteuert zu erstellen und zu verwalten. Dieser Artikel erklärt, wie Sie einer Folie ein SmartArt‑Objekt hinzufügen, vorhandene SmartArt‑Objekte zugreifen, SmartArt anhand eines bestimmten Layouttyps finden und deren visuelles Erscheinungsbild aktualisieren, indem Sie den SmartArt‑Stil oder den Farb‑Stil ändern.

Die Beispiele zeigen, wie man mit SmartArt‑Objekten über die Formsammlung der Präsentationsfolie arbeitet, prüft, ob eine Form SmartArt ist, und dann deren Eigenschaften ändert oder inspiziert.

## **SmartArt‑Objekt erstellen**
Aspose.Slides für Python via Java stellt eine API zum Erstellen von SmartArt‑Objekten bereit. Um ein SmartArt‑Objekt in einer Folie zu erstellen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
2. Rufen Sie eine Folie anhand ihres Index ab.
3. [SmartArt‑Objekt hinzufügen](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addSmartArt) durch Angabe eines [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/).
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Die erste Folie abrufen.
    slide = presentation.getSlides().get_Item(0)

    # SmartArt-Form hinzufügen.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Präsentation speichern.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt‑Objekt zur Folie hinzugefügt**|

## **Zugriff auf ein SmartArt‑Objekt auf einer Folie**
Das folgende Beispiel greift auf SmartArt‑Objekte einer Präsentationsfolie zu. Es iteriert über jede Form auf der Folie und prüft, ob die Form eine [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Instanz ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Durchlaufen Sie alle Formen auf der ersten Folie.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Zugriff auf ein SmartArt‑Objekt mit einem bestimmten Layouttyp**
Das folgende Beispiel greift auf ein [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Objekt mit einem bestimmten Layouttyp zu, das über [SmartArt.getLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#getLayout) zurückgegeben wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die ein SmartArt‑Objekt enthält.
2. Holen Sie die erste Folie über ihren Index.
3. Iterieren Sie über jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form eine [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Instanz ist.
5. Prüfen Sie, ob das SmartArt‑Objekt den angegebenen Layouttyp hat, und führen Sie die erforderliche Operation aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Alle Formen auf der ersten Folie durchlaufen.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Das SmartArt-Layout überprüfen.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **SmartArt‑Objektstil ändern**
Dieses Beispiel zeigt, wie man den Schnellstil eines SmartArt‑Objekts ändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die ein SmartArt‑Objekt enthält.
2. Holen Sie die erste Folie über ihren Index.
3. Iterieren Sie über jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form eine [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Instanz ist.
5. Finden Sie das SmartArt‑Objekt mit dem angegebenen Stil.
6. Setzen Sie den neuen Stil für das SmartArt‑Objekt.
7. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Alle Formen auf der ersten Folie durchlaufen.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt-Stil prüfen und ändern.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt‑Objekt mit geändertem Stil**|

## **SmartArt‑Objektfarbstil ändern**
Dieses Beispiel greift auf ein SmartArt‑Objekt mit einem bestimmten Farbstil zu und ändert diesen Stil.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die ein SmartArt‑Objekt enthält.
2. Holen Sie die erste Folie über ihren Index.
3. Iterieren Sie über jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form eine [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Instanz ist.
5. Finden Sie das SmartArt‑Objekt mit dem angegebenen Farbstil.
6. Setzen Sie den neuen Farbstil für das SmartArt‑Objekt.
7. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Alle Formen auf der ersten Folie durchlaufen.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt-Stil prüfen und ändern.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Abbildung: SmartArt‑Objekt mit geändertem Farbstil**|

## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/python-java/powerpoint-animation/) (Eingang, Ausgang, Hervorhebung, Bewegungswege) wie bei anderen Formen anwenden können.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie finden, wenn ich seine interne ID nicht kenne?**

Setzen Sie den [alternativen Text](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setAlternativeText) und suchen Sie die Form nach diesem Wert – dies ist ein empfohlener Weg, um die Ziel‑Form zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und anschließend die Gruppe [bearbeiten](/slides/de/python-java/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Miniaturbild/Bild der Form; die Bibliothek kann einzelne Formen [rendern](/slides/de/python-java/create-shape-thumbnails/) zu Rasterdateien (PNG/JPG/TIFF).

**Wird das SmartArt‑Erscheinungsbild beim Konvertieren der gesamten Präsentation in PDF beibehalten?**

Ja. Die Rendering‑Engine zielt bei [PDF‑Export](/slides/de/python-java/convert-powerpoint-to-pdf/) auf hohe Treue, mit einer Reihe von Qualitäts‑ und Kompatibilitätsoptionen.