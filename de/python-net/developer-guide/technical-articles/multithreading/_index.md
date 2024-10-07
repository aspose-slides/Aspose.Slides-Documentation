---
title: Multithreading in Aspose.Slides
type: docs
weight: 200
url: /python-net/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- paralleles Arbeiten
- Folien konvertieren
- Folien zu Bildern
- Python
- Aspose.Slides für Python
---

## **Einführung**

Während paralleles Arbeiten mit Präsentationen möglich ist (neben dem Parsen/Laden/Klonen) und alles gut läuft (meistens), besteht eine geringe Chance, dass Sie falsche Ergebnisse erhalten, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen dringend, dass Sie **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Instanz in einer Multithreading-Umgebung verwenden, da dies zu unvorhersehbaren Fehlern oder Problemen führen kann, die nicht leicht erkannt werden. 

Es ist **nicht** sicher, eine Instanz einer [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Operationen werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Operationen unter Verwendung mehrerer einzelner Prozesse mit einem Thread parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden. 

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien aus einer PowerPoint-Präsentation parallel in PNG-Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem separaten Thread verwendet wird. Das folgende Codebeispiel zeigt, wie man dies macht.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Folie i in eine separate Präsentation extrahieren.
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