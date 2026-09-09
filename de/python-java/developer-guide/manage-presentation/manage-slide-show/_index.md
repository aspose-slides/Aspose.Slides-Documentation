---
title: Verwalten von Diashows in Python über Java
linktitle: Diashow
type: docs
weight: 90
url: /de/python-java/manage-slide-show/
keywords:
- Show-Typ
- Vom Sprecher präsentiert
- Einzelne Ansicht
- Im Kiosk angezeigt
- Anzeigeoptionen
- Kontinuierlich wiederholen
- Anzeige ohne Erzählung
- Anzeige ohne Animation
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Show
- Folien weiterführen
- Manuell
- Mit Zeitangaben
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diashows in Aspose.Slides für Python über Java verwalten. Steuern Sie Folienübergänge, Zeitangaben und mehr in PPT-, PPTX- und ODP‑Formaten mühelos."
---
## **Einführung**

Microsoft PowerPoints **Set Up Show**-Optionen ermöglichen es Ihnen, den Show‑Typ auszuwählen, das Schleifen zu aktivieren, Folien zu wählen und zu steuern, wie Folien weitergehen. Mit Aspose.Slides für Python über Java können Sie diese Optionen programmgesteuert konfigurieren und in einer Präsentationsdatei speichern.

Die [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideShowSettings) Methode gibt ein [SlideShowSettings](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/) Objekt zurück, das diese Optionen steuert. Die untenstehenden Beispiele erfordern Aspose.Slides für Python über Java und eine kompatible Java‑Laufzeit. Jedes Beispiel startet die JVM bei Bedarf und gibt die Präsentation nach Abschluss frei.

## **Show‑Typ auswählen**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definiert den Typ der Diashow, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/de/python-java/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/de/python-java/aspose.slides/browsedatkiosk/). Die Verwendung dieser Methode ermöglicht es Ihnen, die Präsentation an verschiedene Nutzungsszenarien anzupassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das untenstehende Code‑Beispiel erstellt eine neue Präsentation und setzt den Show‑Typ auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.

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

## **Show‑Optionen aktivieren**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setLoop) bestimmt, ob die Diashow in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setShowNarration) bestimmt, ob Sprach‑Narrationen während der Diashow abgespielt werden sollen. Dies ist nützlich für automatisierte Präsentationen, die eine gesprochene Anleitung für das Publikum enthalten. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setShowAnimation) bestimmt, ob zu Folienobjekten hinzugefügte Animationen abgespielt werden sollen. Dies ist nützlich, um den vollen visuellen Effekt der Präsentation zu erzielen.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und wiederholt die Diashow.

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

## **Folien zur Anzeige auswählen**

Die [SlideShowSettings.setSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setSlides) Methode ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation statt aller Folien zeigen möchten. Das folgende Code‑Beispiel erstellt eine Präsentation mit neun Folien und wählt die Folien 2 bis 9 aus. Der Bereich verwendet einsbasierte Foliennummern.

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

Die [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setUseTimings) Methode ermöglicht es Ihnen, die Verwendung voreingestellter Zeitvorgaben für jede Folie zu aktivieren oder zu deaktivieren. Dies ist nützlich, um Folien automatisch mit vordefinierten Anzeigedauern zu zeigen. Das untenstehende Code‑Beispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Zeitvorgaben.

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

## **Medien­steuerelemente anzeigen**

Die [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) Methode bestimmt, ob Mediensteuerelemente (wie Abspielen, Pause und Stopp) während der Diashow angezeigt werden sollen, wenn multimediale Inhalte (z. B. Video oder Audio) abgespielt werden. Dies ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerelementen.

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

**Kann ich eine Präsentation speichern, damit sie direkt im Diashow‑Modus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten beim Öffnen in PowerPoint direkt im Diashow‑Modus. In Aspose.Slides wählen Sie das entsprechende Speicherformat [während des Exports](/slides/de/python-java/save-presentation/).

**Kann ich einzelne Folien von der Diashow ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setHidden). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Diashow nicht angezeigt.

**Kann Aspose.Slides eine Diashow abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Anzeigesoftware wie PowerPoint übernommen.