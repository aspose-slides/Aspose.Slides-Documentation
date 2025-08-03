---
title: PowerPoint‑Präsentationen in Word‑Dokumente mit Python umwandeln
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint in DOCX
- OpenDocument in DOCX
- Präsentation in DOCX
- Folie in DOCX
- PPT in DOCX
- PPTX in DOCX
- ODP in DOCX
- PowerPoint in DOC
- OpenDocument in DOC
- Präsentation in DOC
- Folie in DOC
- PPT in DOC
- PPTX in DOC
- ODP in DOC
- PowerPoint in Word
- OpenDocument in Word
- Präsentation in Word
- Folie in Word
- PPT in Word
- PPTX in Word
- ODP in Word
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- ODP konvertieren
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑ und OpenDocument‑Präsentationen mithilfe von Aspose.Slides for Python via .NET mühelos in Word‑Dokumente umwandeln. Unsere Schritt‑für‑Schritt‑Anleitung mit Beispiel‑Python‑Code bietet Entwicklern eine Lösung, um ihre Dokument‑Workflows zu optimieren."
---

Wenn Sie planen, textuelle Inhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu verwenden, können Sie davon profitieren, die Präsentation in Word (DOC oder DOCX) umzuwandeln.

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word-App besser mit Tools oder Funktionalitäten für Inhalte ausgestattet.
* Abgesehen von den Bearbeitungsfunktionen in Word können Sie auch von verbesserten Funktionen für Zusammenarbeit, Drucken und Teilen profitieren.

{{% alert color="primary" %}}

Sie möchten vielleicht unseren [**Online-Converter für Präsentationen in Word**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, was Sie aus der Bearbeitung textueller Inhalte von Folien gewinnen können.

{{% /alert %}}

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOCX) umzuwandeln, benötigen Sie sowohl [Aspose.Slides für Python über .NET](https://products.aspose.com/slides/python-net/) als auch [Aspose.Words für Python über .NET](https://products.aspose.com/words/python-net/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.com/slides/python-net/) für Python über .NET Funktionen, mit denen Sie Texte aus Präsentationen extrahieren können.

[Aspose.Words](https://products.aspose.com/words/python-net/) ist eine fortschrittliche API zur Dokumentenverarbeitung, die es Anwendungen ermöglicht, Dateien zu generieren, zu modifizieren, zu konvertieren, zu rendern, zu drucken und andere Aufgaben mit Dokumenten ohne die Nutzung von Microsoft Word durchzuführen.

## **PowerPoint in Word in Python umwandeln**

1. Fügen Sie diese Namensräume zu Ihrer program.py-Datei hinzu:

```py
import aspose.slides as slides
import aspose.words as words
```

2. Verwenden Sie diesen Codeausschnitt, um die PowerPoint in Word umzuwandeln:

```py
with slides.Presentation("sample.pptx") as presentation:
    doc = words.Document()
    builder = words.DocumentBuilder(doc)

    for index in range(presentation.slides.length):
        slide = presentation.slides[index]

        file_name = "slide_{i}.png".format(i=index)

        # generiert ein Folienbild
        with slide.get_image(1, 1) as image:
            image.save(file_name, slides.ImageFormat.PNG)

        builder.insert_image(file_name)

        for shape in slide.shapes:
            # fügt die Texte der Folie ein
            if type(shape) is slides.AutoShape:
                builder.writeln(shape.text_frame.text)

        builder.insert_break(words.BreakType.PAGE_BREAK)
    doc.save("output.docx")
```