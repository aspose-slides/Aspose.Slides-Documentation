---
title: Multithreading in Aspose.Slides für Python
linktitle: Multithreading
type: docs
weight: 200
url: /de/python-net/multithreading/
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
- Aspose.Slides
description: "Aspose.Slides für Python über .NET-Multithreading steigert die Verarbeitung von PowerPoint und OpenDocument. Entdecken Sie bewährte Methoden für effiziente Präsentationsabläufe."
---

## **Einleitung**

Während paralleles Arbeiten mit Präsentationen möglich ist (außer beim Parsen/Laden/Klonen) und meistens alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass Sie falsche Ergebnisse erhalten, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen dringend, **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz in einer Multi‑Thread‑Umgebung zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Derartige Vorgänge werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, sollten Sie die Operationen mit mehreren single‑threaded Prozessen parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden. 

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation`‑Instanz in mehreren Threads zu verwenden, teilen wir die Folien in separate Präsentationen auf und konvertieren die Folien parallel, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Codebeispiel zeigt, wie das geht.
```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extrahiere Folie i in eine separate Präsentation.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Konvertiere die Folie in ein Bild.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Warte, bis alle Aufgaben abgeschlossen sind.
for task in conversion_tasks:
    task.result()

del presentation
```


## **FAQ**

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht, sie einmal pro Prozess/App‑Domain aufzurufen, bevor die Threads starten. Wenn [license setup](/slides/de/python-net/licensing/) gleichzeitig aufgerufen werden könnte (z. B. bei lazy initialization), synchronisieren Sie diesen Aufruf, da die Lizenzkonfigurations‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „lebenden“ Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erzeugen Sie getrennte Präsentationen/Slide‑Container für jeden Thread im Voraus. Dieser Ansatz folgt der allgemeinen Empfehlung, eine einzelne Präsentationsinstanz nicht über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, sofern jeder Thread seine eigene `Presentation`‑Instanz hat?**

Ja. Mit unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Streams.

**Wie soll ich mit globalen Schriftarteinstellungen (Ordner, Ersetzungen) in einer Multi‑Thread‑Umgebung umgehen?**

Initialisieren Sie alle globalen Schriftarteinstellungen, bevor Sie die Threads starten, und ändern Sie sie während der parallelen Arbeit nicht mehr. Dadurch werden Rennbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen vermieden.