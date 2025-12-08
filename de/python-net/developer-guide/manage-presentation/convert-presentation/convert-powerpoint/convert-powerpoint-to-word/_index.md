---
title: PowerPoint-Präsentationen in Word-Dokumente mit Python konvertieren
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint zu DOCX
- OpenDocument zu DOCX
- Präsentation zu DOCX
- Folie zu DOCX
- PPT zu DOCX
- PPTX zu DOCX
- ODP zu DOCX
- PowerPoint zu DOC
- OpenDocument zu DOC
- Präsentation zu DOC
- Folie zu DOC
- PPT zu DOC
- PPTX zu DOC
- ODP zu DOC
- PowerPoint zu Word
- OpenDocument zu Word
- Präsentation zu Word
- Folie zu Word
- PPT zu Word
- PPTX zu Word
- ODP zu Word
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- ODP konvertieren
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mühelos in Word-Dokumente mit Aspose.Slides für Python via .NET konvertieren können. Unser schritt‑für‑schritt Leitfaden mit Beispiel‑Python‑Code bietet die Lösung für Entwickler, die ihre Dokumenten‑Workflows optimieren möchten."
---

## **Übersicht**

Dieser Artikel bietet Entwicklern eine Lösung zum Konvertieren von PowerPoint- und OpenDocument-Präsentationen in Word-Dokumente mithilfe von Aspose.Slides für Python via .NET und Aspose.Words für Python via .NET. Die Schritt-für-Schritt-Anleitung führt Sie durch jede Phase des Konvertierungsprozesses.

## **Eine Präsentation in ein Word‑Dokument konvertieren**

Folgen Sie den nachstehenden Anweisungen, um eine PowerPoint‑ oder OpenDocument‑Präsentation in ein Word‑Dokument zu konvertieren:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie eine Präsentationsdatei.
2. Instanziieren Sie die Klassen [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) und [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/), um ein Word‑Dokument zu erzeugen.
3. Legen Sie die Seitengröße für das Word‑Dokument fest, damit sie der der Präsentation entspricht, indem Sie die Eigenschaft [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) verwenden.
4. Setzen Sie die Ränder im Word‑Dokument mithilfe der Eigenschaft [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Durchlaufen Sie alle Folien der Präsentation mit der Eigenschaft [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/):
    - Erzeugen Sie ein Folienbild mithilfe der Methode `get_image` der Klasse [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) und speichern Sie es in einen Speicher‑Stream.
    - Fügen Sie das Folienbild dem Word‑Dokument mit der Methode `insert_image` der Klasse [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) hinzu.
6. Speichern Sie das Word‑Dokument in einer Datei.

Angenommen, wir haben eine Präsentation "sample.pptx", die folgendermaßen aussieht:

![PowerPoint-Präsentation](PowerPoint.png)

Das folgende Python‑Codebeispiel zeigt, wie man die PowerPoint‑Präsentation in ein Word‑Dokument konvertiert:
```py
import aspose.slides as slides
import aspose.words as words

# Präsentationsdatei laden.
with slides.Presentation("sample.pptx") as presentation:

    # Document- und DocumentBuilder-Objekte erstellen.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Seitengröße im Word-Dokument festlegen.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Ränder im Word-Dokument festlegen.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Durch alle Folien der Präsentation iterieren.
    for slide in presentation.slides:

        # Folienbild erzeugen und in einen Speicher-Stream speichern.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Folienbild zum Word-Dokument hinzufügen.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Word-Dokument in einer Datei speichern.
    document.save("output.docx")
```


Das Ergebnis:

![Word‑Dokument](Word.png)

{{% alert color="primary" %}} 
Probieren Sie unseren [**Online PPT‑zu‑Word‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) aus, um zu sehen, welchen Nutzen Sie aus der Konvertierung von PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente ziehen können. 
{{% /alert %}}

## **FAQ**

**Welche Komponenten müssen installiert werden, um PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente zu konvertieren?**

Sie müssen lediglich die jeweiligen Pakete für [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) und [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) zu Ihrem Python‑Projekt hinzufügen. Beide Pakete funktionieren als eigenständige APIs, und es ist keine Installation von Microsoft Office erforderlich.

**Werden alle PowerPoint‑ und OpenDocument‑Präsentationsformate unterstützt?**

Aspose.Slides für Python .NET [unterstützt alle Präsentationsformate](/slides/de/python-net/supported-file-formats/), einschließlich PPT, PPTX, ODP und anderer gängiger Dateitypen. Dadurch können Sie mit Präsentationen arbeiten, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.