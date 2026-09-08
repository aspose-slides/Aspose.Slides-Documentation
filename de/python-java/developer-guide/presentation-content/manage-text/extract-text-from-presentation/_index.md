---
title: Erweiterte Textextraktion aus Präsentationen in Python via Java
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/python-java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java. Folgen Sie unserer einfachen, schrittweisen Anleitung, um Zeit zu sparen."
---
## **Übersicht**

Das Extrahieren von Text aus Präsentationen ist eine häufige, aber wesentliche Aufgabe für Entwickler, die mit Folieninhalten arbeiten. Egal, ob Sie Microsoft PowerPoint-Dateien im PPT- oder PPTX-Format oder OpenDocument‑Präsentationen (ODP) bearbeiten, der Zugriff auf und das Abrufen von Textdaten kann für Analyse, Automatisierung, Indizierung oder Inhaltsmigration entscheidend sein.

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Text effizient aus verschiedenen Präsentationsformaten, einschließlich PPT, PPTX und ODP, mit Aspose.Slides für Python via Java extrahieren können. Sie erfahren, wie Sie systematisch durch Präsentationselemente iterieren, um den benötigten Textinhalt genau zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides für Python via Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/) bereit. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren von Text aus einer Präsentation oder Folie. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die Methode [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#getAllTextBoxes). Diese Methode akzeptiert ein Objekt vom Typ [BaseSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/) als Parameter. Bei Ausführung durchsucht die Methode die gesamte Folie nach Text und gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) zurück, wobei sämtliche Textformatierungen beibehalten werden.

Der folgende Codeausschnitt extrahiert den gesamten Text aus der ersten Folie der Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Text aus einer Präsentation extrahieren**

Um Text aus der gesamten Präsentation zu durchsuchen, verwenden Sie die statische Methode [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#getAllTextFrames), die von der Klasse [SlideUtil](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/) bereitgestellt wird. Sie akzeptiert zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Objekt, das eine PowerPoint- oder OpenDocument‑Präsentation darstellt, aus der Text extrahiert werden soll.
1. Als zweites ein `bool`‑Wert, der angibt, ob die Master‑Folien beim Durchsuchen des Textes aus der Präsentation einbezogen werden sollen.

Die Methode gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) zurück, das Textformatierungsinformationen enthält. Der untenstehende Code durchsucht den Text und die Formatierungsdetails einer Präsentation, einschließlich der Master‑Folien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Kategorisierte und schnelle Textextraktion**

Die Klasse [PresentationFactory](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/) bietet ebenfalls Methoden zum Extrahieren des gesamten Textes aus Präsentationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Text aus einer Datei extrahieren.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Text aus einem Stream extrahieren.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Text aus einem Stream mithilfe von Ladeoptionen extrahieren.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Das Enum‑Argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/textextractionarrangingmode/) gibt den Modus zur Anordnung des Textextraktionsergebnisses an und kann auf die folgenden Werte gesetzt werden:

- [Unarranged](https://reference.aspose.com/slides/de/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) – Der Rohtext ohne Rücksicht auf seine Position auf der Folie.
- [Arranged](https://reference.aspose.com/slides/de/python-java/aspose.slides/textextractionarrangingmode/#Arranged) – Der Text wird in derselben Reihenfolge wie auf der Folie angeordnet.

Der Unarranged‑Modus kann verwendet werden, wenn Geschwindigkeit kritisch ist; er ist schneller als der Arranged‑Modus.

[PresentationText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationtext/) stellt den rohen Text dar, der aus der Präsentation extrahiert wurde. Die Methode [getSlidesText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationtext/#getSlidesText) gibt ein Array von Objekten des Typs `SlideText` zurück. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das Objekt vom Typ `SlideText` verfügt über die folgenden Methoden:

- `getText` – Der Text innerhalb der Formen der Folie.
- `getMasterText` – Der Text innerhalb der Formen der Master‑Folie, die dieser Folie zugeordnet sind.
- `getLayoutText` – Der Text innerhalb der Formen der Layout‑Folie, die dieser Folie zugeordnet sind.
- `getNotesText` – Der Text innerhalb der Formen der Notizfolie, die dieser Folie zugeordnet sind.
- `getCommentsText` – Der Text innerhalb von Kommentaren, die dieser Folie zugeordnet sind.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und kann selbst [große Präsentationen](/slides/de/python-java/open-presentation/) verarbeiten, wodurch es für Echtzeit‑ oder Massenvorgänge geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja. Aspose.Slides kann Text aus vielen Folienelementen extrahieren, einschließlich Tabellen und diagrammbezogener Objekte, sodass Sie auf Textinhalte in gängigen Präsentationsstrukturen zugreifen und diese analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings hat sie [bestimmte Einschränkungen](/slides/de/python-java/licensing/), z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Kauf einer Voll‑Lizenz empfohlen.