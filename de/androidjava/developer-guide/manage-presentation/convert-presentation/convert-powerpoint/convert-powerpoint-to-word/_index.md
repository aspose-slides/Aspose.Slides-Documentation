---
title: PowerPoint-Präsentationen auf Android in Word-Dokumente konvertieren
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/androidjava/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Word
- Präsentation zu Word
- Folie zu Word
- PPT zu Word
- PPTX zu Word
- PowerPoint zu DOCX
- Präsentation zu DOCX
- Folie zu DOCX
- PPT zu DOCX
- PPTX zu DOCX
- PowerPoint zu DOC
- Präsentation zu DOC
- Folie zu DOC
- PPT zu DOC
- PPTX zu DOC
- PPT als DOCX speichern
- PPTX als DOCX speichern
- PPT nach DOCX exportieren
- PPTX nach DOCX exportieren
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT- und PPTX-Folien in bearbeitbare Word-Dokumente in Java konvertieren, wobei Aspose.Slides für Android verwendet wird und das exakte Layout, Bilder und Formatierungen erhalten bleiben."
---

Wenn Sie planen, Textinhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu nutzen, können Sie davon profitieren, die Präsentation in Word (DOC oder DOCX) zu konvertieren. 

* Im Vergleich zu Microsoft PowerPoint bietet die Microsoft Word‑App mehr Werkzeuge oder Funktionen für Inhalte. 
* Zusätzlich zu den Bearbeitungsfunktionen in Word können Sie von erweiterten Kollaborations-, Druck‑ und Freigabefunktionen profitieren. 

{{% alert color="primary" %}} 

Vielleicht möchten Sie unseren [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, welchen Nutzen Sie daraus ziehen können, mit Textinhalten aus Folien zu arbeiten. 

{{% /alert %}} 

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint‑Datei (PPTX oder PPT) in Word (DOCX oder DOC) zu konvertieren, benötigen Sie sowohl [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) als auch [Aspose.Words for Android via Java](https://products.aspose.com/words/androidjava/).

Als eigenständige API stellt [Aspose.Slides](https://products.aspose.app/slides) für Java Funktionen bereit, mit denen Sie Texte aus Präsentationen extrahieren können. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) ist eine fortschrittliche Dokumenten‑Verarbeitungs‑API, die Anwendungen ermöglicht, Dateien zu erstellen, zu ändern, zu konvertieren, zu rendern, zu drucken und weitere Aufgaben mit Dokumenten durchzuführen, ohne Microsoft Word zu verwenden.

## **PowerPoint in Word konvertieren**

1. Laden Sie die Bibliotheken [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) und [Aspose.Words for Java](https://downloads.aspose.com/words/java) herunter. 
2. Fügen Sie *aspose-slides-x.x-jdk16.jar* und *aspose-words-x.x-jdk16.jar* zu Ihrem CLASSPATH hinzu. 
3. Verwenden Sie dieses Code‑Snippet, um die PowerPoint‑Datei in Word zu konvertieren: 
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


## **FAQ**

**Welche Komponenten müssen installiert werden, um PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente zu konvertieren?**

Sie müssen lediglich das jeweilige Paket für [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) und [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) zu Ihrem Projekt hinzufügen. Beide Bibliotheken funktionieren als eigenständige APIs, und es ist nicht erforderlich, Microsoft Office zu installieren.

**Werden alle PowerPoint‑ und OpenDocument‑Präsentationsformate unterstützt?**

Aspose.Slides [unterstützt alle Präsentationsformate](/slides/de/androidjava/supported-file-formats/), einschließlich PPT, PPTX, ODP und anderer gängiger Dateitypen. Das stellt sicher, dass Sie mit Präsentationen arbeiten können, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.