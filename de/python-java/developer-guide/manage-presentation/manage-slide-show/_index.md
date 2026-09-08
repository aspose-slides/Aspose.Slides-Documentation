---
title: Verwalten von Folienvorführungen in Python via Java
linktitle: Folienvorführung
type: docs
weight: 90
url: /de/python-java/manage-slide-show/
keywords:
- Showtyp
- Vom Sprecher präsentiert
- Einzelperson durchgesehen
- Im Kiosk angezeigt
- Show-Optionen
- Kontinuierlich schleifen
- Vorführung ohne Erzählung
- Vorführung ohne Animation
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Vorführung
- Folien vorwärts schalten
- Manuell
- Mit Zeitsteuerung
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienvorführungen in Aspose.Slides für Python via Java verwalten. Steuern Sie Folienübergänge, Zeitabläufe und mehr für PPT-, PPTX- und ODP-Formate mühelos."
---
## **Einleitung**

Microsoft PowerPoint's **Set Up Show**-Optionen ermöglichen es Ihnen, den Showtyp auszuwählen, das Schleifen zu aktivieren, Folien auszuwählen und zu steuern, wie Folien voranschreiten. Mit Aspose.Slides für Python via Java können Sie diese Optionen programmgesteuert konfigurieren und in einer Präsentationsdatei speichern.

Die [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideShowSettings) Methode gibt ein [SlideShowSettings](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/) Objekt zurück, das diese Optionen steuert. Die Beispiele unten erfordern Aspose.Slides für Python via Java und eine kompatible Java‑Laufzeit. Jedes Beispiel startet die JVM bei Bedarf und gibt die Präsentation nach Abschluss frei.

## **Showtyp auswählen**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definiert den Typ der Vorführung, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/de/python-java/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/de/python-java/aspose.slides/browsedatkiosk/). Mit dieser Methode können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Vorführungen.

Der Beispielcode unten erstellt eine neue Präsentation und setzt den Showtyp auf „Browsed by an individual“ ohne Anzeige der Bildlaufleiste.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Showoptionen aktivieren**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setLoop) bestimmt, ob die Vorführung in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen sollen. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setShowNarration) legt fest, ob während der Vorführung Sprachkommentare abgespielt werden sollen. Das ist hilfreich für automatisierte Präsentationen, die Sprachführung für das Publikum enthalten. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setShowAnimation) bestimmt, ob Animationen, die Folienobjekten hinzugefügt wurden, abgespielt werden sollen. Dies ist nützlich, um den vollen visuellen Effekt der Präsentation zu zeigen.

Der folgende Code erstellt eine neue Präsentation und lässt die Vorführung schleifen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Folien für die Show auswählen**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setSlides) Methode ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation gezeigt werden sollen. Das ist praktisch, wenn Sie nur einen Teil der Präsentation und nicht alle Folien anzeigen möchten. Der folgende Beispielcode erstellt eine Präsentation mit neun Folien und wählt die Folien 2 bis 9 aus. Der Bereich verwendet einsbasierte Foliennummern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Erstelle neun Folien, damit der ausgewählte Bereich existiert.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Folienfortschritt steuern**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setUseTimings) Methode erlaubt es Ihnen, die Verwendung vordefinierter Zeiten für jede Folie zu aktivieren oder zu deaktivieren. Das ist nützlich, um Folien automatisch mit festgelegten Anzeigedauern zu zeigen. Der untenstehende Beispielcode erstellt eine neue Präsentation und deaktiviert die Verwendung von Zeiten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mediensteuerungen anzeigen**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) Methode bestimmt, ob Mediensteuerungen (wie Abspielen, Pause und Stop) während der Vorführung angezeigt werden sollen, wenn multimediale Inhalte (z. B. Video oder Audio) abgespielt werden. Das ist hilfreich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Der folgende Beispielcode erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Vorführungsmodus öffnet?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten direkt im Vorführungsmodus, wenn sie in PowerPoint geöffnet werden. In Aspose.Slides wählen Sie das entsprechende Speicherformat [während des Exports](/slides/de/python-java/save-presentation/).

**Kann ich einzelne Folien aus der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [versteckt](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setHidden). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Vorführung nicht angezeigt.

**Kann Aspose.Slides eine Vorführung abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.