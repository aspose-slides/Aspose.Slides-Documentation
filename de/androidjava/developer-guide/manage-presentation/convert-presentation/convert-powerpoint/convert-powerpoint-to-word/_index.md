---
title: PowerPoint in Word umwandeln
type: docs
weight: 110
url: /androidjava/convert-powerpoint-to-word/
keywords: "PowerPoint umwandeln, PPT, PPTX, Präsentation, Word, DOCX, DOC, PPTX in DOCX, PPT in DOC, PPTX in DOC, PPT in DOCX, Java, java, Aspose.Slides"
description: "PowerPoint-Präsentation in Word in Java umwandeln"
---

Wenn Sie planen, textuelle Inhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu verwenden, könnte es vorteilhaft sein, die Präsentation in Word (DOC oder DOCX) umzuwandeln.

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word-App besser mit Werkzeugen oder Funktionen für Inhalte ausgestattet.
* Neben den Bearbeitungsfunktionen in Word profitieren Sie möglicherweise auch von verbesserten Funktionen zur Zusammenarbeit, zum Drucken und Teilen.

{{% alert color="primary" %}} 

Sie möchten vielleicht unseren [**Online-Konverter für Präsentationen zu Word**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, was Sie durch die Arbeit mit textuellen Inhalten aus Folien gewinnen können.

{{% /alert %}} 

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOCX) umzuwandeln, benötigen Sie sowohl [Aspose.Slides für Android über Java](https://products.aspose.com/slides/androidjava/) als auch [Aspose.Words für Java](https://products.aspose.com/words/java/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für Java Funktionen, die es Ihnen ermöglichen, Texte aus Präsentationen zu extrahieren.

[Aspose.Words](https://docs.aspose.com/words/java/) ist eine fortschrittliche API zur Dokumentenverarbeitung, die es Anwendungen ermöglicht, Dateien zu generieren, zu modifizieren, zu konvertieren, zu rendern, zu drucken und andere Aufgaben mit Dokumenten auszuführen, ohne Microsoft Word zu verwenden.

## **PowerPoint in Word umwandeln**

1. Laden Sie die Bibliotheken [Aspose.Slides für Android über Java](https://downloads.aspose.com/slides/java) und [Aspose.Words für Java](https://downloads.aspose.com/words/java) herunter.
2. Fügen Sie *aspose-slides-x.x-jdk16.jar* und *aspose-words-x.x-jdk16.jar* zu Ihrem CLASSPATH hinzu.
3. Verwenden Sie diesen Code-Snippet, um PowerPoint in Word umzuwandeln:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // erzeugt ein Folienbild als Byte-Array-Stream
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