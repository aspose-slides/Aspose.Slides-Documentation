---
title: Erweiterte Textextraktion aus Präsentationen in Python
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/python-net/extract-text-from-presentation/
keywords:
- Text extrahieren
- Text aus Folie extrahieren
- Text aus Präsentation extrahieren
- Text aus PowerPoint extrahieren
- Text aus OpenDocument extrahieren
- Text aus PPT extrahieren
- Text aus PPTX extrahieren
- Text aus ODP extrahieren
- Text abrufen
- Text aus Folie abrufen
- Text aus Präsentation abrufen
- Text aus PowerPoint abrufen
- Text aus OpenDocument abrufen
- Text aus PPT abrufen
- Text aus PPTX abrufen
- Text aus ODP abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Schnelles Extrahieren von Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides for Python via .NET. Folgen Sie unserer einfachen, schrittweisen Anleitung, um Zeit zu sparen."
---
## **Übersicht**

Das Extrahieren von Text aus Präsentationen ist eine gängige, aber dennoch wesentliche Aufgabe für Entwickler, die mit Folieninhalt arbeiten. Ob Sie Microsoft PowerPoint‑Dateien im PPT‑ oder PPTX‑Format oder OpenDocument‑Präsentationen (ODP) bearbeiten, das Zugreifen auf und das Abrufen von Textdaten kann für Analyse, Automatisierung, Indizierung oder Inhaltsmigration entscheidend sein.

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Text aus verschiedenen Präsentationsformaten – PPT, PPTX und ODP – effizient extrahieren können, indem Sie Aspose.Slides for Python via .NET verwenden. Sie lernen, wie Sie systematisch durch Präsentationselemente iterieren, um den gewünschten Textinhalt exakt zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides for Python via .NET stellt den [aspose.slides.util](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/)‑Namensraum bereit, der die Klasse [SlideUtil](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/) enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren sämtlichen Textes aus einer Präsentation oder Folie. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die Methode [get_all_text_boxes](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Diese Methode akzeptiert ein Objekt des Typs [BaseSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/) als Parameter. Beim Aufruf durchsucht die Methode die gesamte Folie nach Text und gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) zurück, wobei alle Textformatierungen erhalten bleiben.

Der folgende Codeausschnitt extrahiert den gesamten Text aus der ersten Folie der Präsentation:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Text aus einer Präsentation extrahieren**

Um den Text aus der gesamten Präsentation zu durchsuchen, verwenden Sie die statische Methode [get_all_text_frames](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/get_all_text_frames/) der Klasse [SlideUtil](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/). Sie akzeptiert zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-