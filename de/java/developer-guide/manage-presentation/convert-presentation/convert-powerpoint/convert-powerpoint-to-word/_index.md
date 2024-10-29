---
title: PowerPoint in Word konvertieren
type: docs
weight: 110
url: /de/java/convert-powerpoint-to-word/
keywords: "PowerPoint konvertieren, PPT, PPTX, Präsentation, Word, DOCX, DOC, PPTX in DOCX, PPT in DOC, PPTX in DOC, PPT in DOCX, Java, java, Aspose.Slides"
description: "PowerPoint Präsentation in Word in Java konvertieren"
---

Wenn Sie planen, tekstuelle Inhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu verwenden, können Sie davon profitieren, die Präsentation in Word (DOC oder DOCX) zu konvertieren.

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word-App besser mit Tools oder Funktionen für Inhalte ausgestattet.
* Neben den Bearbeitungsfunktionen in Word können Sie auch von erweiterten Kollaborations-, Druck- und Freigabefunktionen profitieren.

{{% alert color="primary" %}}

Sie möchten vielleicht unseren [**Präsentation in Word Online-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, was Sie durch die Arbeit mit in Folien enthaltenen Textinhalten gewinnen können.

{{% /alert %}}

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOC) zu konvertieren, benötigen Sie sowohl [Aspose.Slides für Java](https://products.aspose.com/slides/java/) als auch [Aspose.Words für Java](https://products.aspose.com/words/java/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für Java Funktionen, die es Ihnen ermöglichen, Texte aus Präsentationen zu extrahieren.

[Aspose.Words](https://docs.aspose.com/words/java/) ist eine fortschrittliche Dokumentenverarbeitungs-API, die es Anwendungen ermöglicht, Dateien zu generieren, zu ändern, zu konvertieren, darzustellen, zu drucken und andere Aufgaben mit Dokumenten auszuführen, ohne Microsoft Word zu nutzen.

## **PowerPoint in Word konvertieren**

1. Laden Sie die Bibliotheken [Aspose.Slides für Java](https://downloads.aspose.com/slides/java) und [Aspose.Words für Java](https://downloads.aspose.com/words/java) herunter.
2. Fügen Sie *aspose-slides-x.x-jdk16.jar* und *aspose-words-x.x-jdk16.jar* zu Ihrem CLASSPATH hinzu.
3. Verwenden Sie diesen Code-Snippet, um die PowerPoint in Word zu konvertieren:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // generiert ein Folienbild als Byte-Array-Stream
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // fügt die Texte der Folie ein
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```