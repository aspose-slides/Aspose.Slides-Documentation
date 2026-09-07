---
title: PowerPoint-Präsentationen in Word-Dokumente in Python über Java konvertieren
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu Word
- Präsentation zu Word
- PPT zu Word
- PPTX zu Word
- ODP zu Word
- PowerPoint zu DOCX
- PPT zu DOCX
- PPTX zu DOCX
- PowerPoint zu DOC
- PPT als DOCX speichern
- PPTX als DOCX speichern
- PPT nach DOCX exportieren
- PPTX nach DOCX exportieren
- Python
- Java
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in Word in Python über Java mit Aspose.Slides und Aspose.Words konvertieren, wobei Folienbilder mit bearbeitbarem Text kombiniert werden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über Java zusammen mit Aspose.Words für Java in Word-Dokumente konvertiert. Aspose.Slides rendert jede Folie und liest deren Text, während Aspose.Words das Word-Dokument über JPype erstellt. Microsoft Office ist nicht erforderlich.

Das resultierende Dokument enthält ein Folienbild, gefolgt von bearbeitbarem Text, der aus den Auto‑Shapes der obersten Ebene der Folie extrahiert wurde. Das Bild bewahrt das visuelle Aussehen der Folie; einzelne Formen, Diagramme und Tabellen werden nicht in bearbeitbare Word‑Objekte konvertiert. Der extrahierte Text behält die ursprüngliche Textformatierung oder Positionierung nicht bei.

## **PowerPoint in Word konvertieren**

1. Installieren Sie Aspose.Slides für Python über Java und eine kompatible Java‑Runtime.  
2. Laden Sie Aspose.Words für Java herunter. Platzieren Sie die Haupt‑JAR‑Datei in einem Verzeichnis `lib` neben Ihrem Skript und benennen Sie sie in `aspose-words.jar` um, oder passen Sie den Pfad im Beispiel an die heruntergeladene Datei an.  
3. Legen Sie die Eingabepräsentation `sample.pptx` im Arbeitsverzeichnis ab. Der Pfad `lib/aspose-words.jar` ist ebenfalls relativ zu diesem Verzeichnis.  
4. Führen Sie den folgenden Python‑Code aus, um `output.docx` zu erstellen.

Das Beispiel lädt die Quelle mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und rendert Folien mit [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage). Es verwendet [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) von Aspose.Words, um die Bilder und den Text in das Word‑Dokument einzufügen.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Passe das Folienbild an die Breite des Textbereichs an und bewahre das Seitenverhältnis.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Füge einfachen Text von AutoShapes der obersten Ebene hinzu, einschließlich Textfeldern.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Jede Folie beginnt auf einer neuen Seite. Langer extrahierter Text oder ungewöhnlich hohe Folienbilder können zusätzliche Seiten erfordern. Der Code fügt Seitenumbrüche nur zwischen den Folien ein und gibt die Präsentation sowie die gerenderten Bilder in `finally`‑Blöcken frei. Die JVM bleibt für nachfolgende Konvertierungen im selben Python‑Prozess verfügbar.

## **FAQ**

**Welche Bibliotheken werden benötigt?**

Verwenden Sie Aspose.Slides für Python über Java, JPype, eine kompatible Java‑Runtime und Aspose.Words für Java. Beide Aspose‑Bibliotheken laufen in derselben JVM. Aspose.Slides verarbeitet die Präsentation; Aspose.Words schreibt das Word‑Dokument.

**Kann ich PPT- und ODP-Dateien sowie PPTX konvertieren?**

Ja. Ersetzen Sie `sample.pptx` durch eine PPT‑ oder ODP‑Datei. Siehe [Supported File Formats](/slides/de/python-java/supported-file-formats/) für die unterstützten Eingabeformate der Präsentation.

**Ist der gesamte Folieninhalt in Word bearbeitbar?**

Nein. Jede Folie wird als statisches Bild eingefügt, wobei einfacher Text aus den Auto‑Shapes der obersten Ebene darunter hinzugefügt wird. Text innerhalb von Gruppen, Tabellen, SmartArt und Diagrammen sowie Sprecher‑Notizen wird von diesem Beispiel nicht extrahiert. Animationen und Übergänge werden im Word‑Dokument nicht wiedergegeben.

**Kann ich als DOC statt DOCX speichern?**

Ja. Ändern Sie den Ausgabedateinamen zu `output.doc`. Aspose.Words wählt das Ausgabeformat anhand der Dateierweiterung, wenn diese Speicher‑Überladung verwendet wird.