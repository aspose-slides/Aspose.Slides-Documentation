---
title: "Erweiterte Textextraktion aus PowerPoint-Präsentationen in Python"
linktitle: "Text extrahieren"
type: docs
weight: 90
url: /de/python-net/extract-text-from-presentation/
keywords:
- "Text extrahieren"
- "Text aus Folie extrahieren"
- "Text aus Präsentation extrahieren"
- "Text aus PowerPoint extrahieren"
- "Text aus OpenDocument extrahieren"
- "Text aus PPT extrahieren"
- "Text aus PPTX extrahieren"
- "Text aus ODP extrahieren"
- "Text abrufen"
- "Text aus Folie abrufen"
- "Text aus Präsentation abrufen"
- "Text aus PowerPoint abrufen"
- "Text aus OpenDocument abrufen"
- "Text aus PPT abrufen"
- "Text aus PPTX abrufen"
- "Text aus ODP abrufen"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Text schnell und einfach aus PowerPoint-Präsentationen mit Aspose.Slides für Python über .NET extrahieren können. Befolgen Sie unsere einfache, schrittweise Anleitung, um Zeit zu sparen und effizient auf Folieninhalte in Ihren Anwendungen zuzugreifen."
---

## **Übersicht**

Das Extrahieren von Text aus Präsentationen ist eine gängige, aber dennoch wesentliche Aufgabe für Entwickler, die mit Folieninhalten arbeiten. Egal, ob Sie Microsoft PowerPoint‑Dateien im PPT‑ oder PPTX‑Format oder OpenDocument‑Präsentationen (ODP) verarbeiten, das Zugreifen auf und das Abrufen von Textdaten kann für Analysen, Automatisierung, Indexierung oder die Migration von Inhalten entscheidend sein.

Dieser Artikel bietet eine umfassende Anleitung, wie man mithilfe von Aspose.Slides for Python effizient Text aus verschiedenen Präsentationsformaten, einschließlich PPT, PPTX und ODP, extrahiert. Sie erfahren, wie Sie systematisch durch Präsentationselemente iterieren, um den benötigten Textinhalt genau zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides for Python stellt den [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/)‑Namensraum bereit, der die Klasse [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die Methode [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Diese Methode akzeptiert ein Objekt vom Typ [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) als Parameter. Beim Aufruf durchsucht die Methode die gesamte Folie nach Text und gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zurück, wobei die Textformatierung erhalten bleibt.

Der folgende Codeausschnitt extrahiert den gesamten Text aus der ersten Folie der Präsentation:
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Holen Sie ein Array von TextFrame-Objekten aus allen Folien der PPTX-Datei.
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # Durchlaufen Sie das Array der TextFrames.
    for text_frame in text_frames:
        # Durchlaufen Sie die Absätze im aktuellen TextFrame.
        for paragraph in text_frame.paragraphs:
            # Durchlaufen Sie die Textanteile im aktuellen Absatz.
            for portion in paragraph.portions:
                # Anzeigen des Textes im aktuellen Teil.
                print(portion.text)
                # Anzeigen der Schriftgröße des Textes.
                print(portion.portion_format.font_height)
                # Anzeigen des Schriftartnamens des Textes.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Text aus einer Präsentation extrahieren**

Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) der Klasse [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Sie akzeptiert zwei Parameter:

1. Ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt, das eine PowerPoint‑ oder OpenDocument‑Präsentation darstellt, aus der Text extrahiert werden soll.  
2. Einen `Boolean`‑Wert, der angibt, ob die Master‑Folien beim Scannen des Textes aus der Präsentation einbezogen werden sollen.

Die Methode gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zurück, einschließlich Informationen zur Textformatierung. Der nachfolgende Code scannt Text‑ und Formatinformationen aus einer Präsentation, einschließlich der Master‑Folien.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation("pres.pptx") as presentation:
    # Holen Sie ein Array von TextFrame-Objekten aus allen Folien der PPTX-Datei.
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # Durchlaufen Sie das Array der TextFrames.
    for text_frame in text_frames:
        # Durchlaufen Sie die Absätze im aktuellen TextFrame.
        for paragraph in text_frame.paragraphs:
            # Durchlaufen Sie die Textabschnitte im aktuellen Absatz.
            for portion in paragraph.portions:
                # Zeigen Sie den Text im aktuellen Teil an.
                print(portion.text)
                # Zeigen Sie die Schriftgröße des Textes an.
                print(portion.portion_format.font_height)
                # Zeigen Sie den Schriftartnamen des Textes an.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Kategorisierte und schnelle Textextraktion**

Die Klasse [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) bietet ebenfalls statische Methoden zum Extrahieren des gesamten Textes aus Präsentationen:
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


Das Aufzählungsargument [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) gibt den Modus zur Anordnung des Textextraktionsergebnisses an und kann auf die folgenden Werte gesetzt werden:
- `UNARRANGED` – Der Rohtext, ohne Rücksicht auf seine Position auf der Folie.  
- `ARRANGED` – Der Text wird in derselben Reihenfolge angeordnet, wie er auf der Folie erscheint.

Der Modus `UNARRANGED` kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Modus `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) repräsentiert den aus der Präsentation extrahierten Rohtext. Es enthält die Eigenschaft `slides_text`, die ein Array von Objekten des Typs [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) zurückgibt. Jedes Objekt stellt den Text der entsprechenden Folie dar. Das Objekt vom Typ [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) verfügt über die folgenden Eigenschaften:

- `text` – Der Text innerhalb der Formen der Folie.  
- `master_text` – Der Text innerhalb der Formen der Master‑Folien, die dieser Folie zugeordnet sind.  
- `layout_text` – Der Text innerhalb der Formen der Layout‑Folien, die dieser Folie zugeordnet sind.  
- `notes_text` – Der Text innerhalb der Formen der Notiz‑Folien, die dieser Folie zugeordnet sind.  
- `comments_text` – Der Text innerhalb von Kommentaren, die dieser Folie zugeordnet sind.  
```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst [große Präsentationen](/slides/de/python-net/open-presentation/) effizient, sodass es für Echtzeit‑ oder Batch‑Szenarien geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie sämtlichen Textinhalt problemlos zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, jedoch enthält diese [bestimmte Einschränkungen](/slides/de/python-net/licensing/), beispielsweise die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und die Verarbeitung größerer Präsentationen wird der Erwerb einer Voll‑Lizenz empfohlen.