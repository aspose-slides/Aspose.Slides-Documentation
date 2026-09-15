---
title: Multithreading in Aspose.Slides für Python über Java
linktitle: Multithreading
type: docs
weight: 310
url: /de/python-java/multithreading/
keywords:
- Multithreading
- mehrere Threads
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides für Python über Java Multithreading steigert die Verarbeitung von PowerPoint- und OpenDocument-Dateien. Entdecken Sie bewährte Methoden für effiziente Präsentations-Workflows."
---
## **Einführung**

Obwohl parallele Arbeit mit Präsentationen möglich ist (außer beim Parsen, Laden und Klonen) und in der Regel gut funktioniert, besteht eine geringe Chance auf falsche Ergebnisse, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen dringend, dass Sie in einer multithreaded Umgebung **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz in mehreren Threads zu laden, zu speichern und/oder zu klonen. Derartige Vorgänge werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Vorgänge mithilfe mehrerer einthreadiger Prozesse parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da es unsicher ist, eine einzelne [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, indem wir jede Präsentation in einem eigenen Thread verwenden. Das folgende Codebeispiel zeigt, wie das geht.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extrahiere die Folie in eine separate Präsentation.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Konvertiere die Folie in ein Bild in einem separaten Task.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Warte, bis alle Tasks abgeschlossen sind.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht, sie einmal pro Prozess vor dem Start der Threads auszuführen. Wenn [license setup](/slides/de/python-java/licensing/) möglicherweise gleichzeitig aufgerufen wird (z. B. während der Lazy‑Initialisierung), synchronisieren Sie diesen Aufruf, da die Lizenzsetup‑Methode selbst nicht thread‑sicher ist.

**Kann ich [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) oder [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) Objekte zwischen Threads übergeben?**

Das Übergeben von „lebenden“ Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erstellen Sie im Voraus separate Präsentationen bzw. Foliencontainer für jeden Thread. Dieser Ansatz folgt der allgemeinen Empfehlung, eine einzelne Präsentationsinstanz nicht über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, wenn jeder Thread seine eigene [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz hat?**

Ja. Mit unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Streams.

**Was soll ich mit globalen Schriftarteinstellungen (Ordner, Ersetzungen) beim Multithreading tun?**

Initialisieren Sie alle globalen [font settings](/slides/de/python-java/powerpoint-fonts/) vor dem Start der Threads und ändern Sie sie während der parallelen Arbeit nicht. Dadurch entfallen Rennbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen.