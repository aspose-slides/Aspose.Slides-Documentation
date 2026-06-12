---
title: PowerPoint-presentaties naar Word-documenten converteren in Java
linktitle: PowerPoint naar Word
type: docs
weight: 110
url: /nl/java/convert-powerpoint-to-word/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar Word
- presentatie naar Word
- dia naar Word
- PPT naar Word
- PPTX naar Word
- PowerPoint naar DOCX
- presentatie naar DOCX
- dia naar DOCX
- PPT naar DOCX
- PPTX naar DOCX
- PowerPoint naar DOC
- presentatie naar DOC
- dia naar DOC
- PPT naar DOC
- PPTX naar DOC
- PPT opslaan als DOCX
- PPTX opslaan als DOCX
- PPT exporteren naar DOCX
- PPTX exporteren naar DOCX
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT- en PPTX-dia's naar bewerkbare Word-documenten in Java met Aspose.Slides, waarbij de exacte lay-out, afbeeldingen en opmaak behouden blijven."
---
## **Overzicht**

Dit artikel biedt een oplossing voor ontwikkelaars om PowerPoint- en OpenDocument‑presentaties naar Word‑documenten te converteren met Aspose.Slides en Aspose.Words. De stapsgewijze handleiding leidt u door elke fase van het conversieproces.

## **PowerPoint naar Word converteren**

Volg de onderstaande instructies om een PowerPoint‑ of OpenDocument‑presentatie naar een Word‑document te converteren:

1. Download de bibliotheken [Aspose.Slides for Java](https://downloads.aspose.com/slides/nl/java) en [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Voeg *aspose-slides-x.x-jdk16.jar* en *aspose-words-x.x-jdk16.jar* toe aan uw CLASSPATH.
3. Gebruik dit codefragment om de PowerPoint naar Word te converteren:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // genereert een dia afbeelding als een byte array stream
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // voegt de teksten van de dia toe
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

**Welke componenten moeten geïnstalleerd worden om PowerPoint- en OpenDocument‑presentaties naar Word‑documenten te converteren?**

U hoeft alleen het betreffende pakket voor [Aspose.Slides for Java](https://releases.aspose.com/slides/nl/java/) en [Aspose.Words for Java](https://releases.aspose.com/words/java/) aan uw project toe te voegen. Beide bibliotheken functioneren als zelfstandige API’s en er is geen vereiste om Microsoft Office te installeren.

**Worden alle PowerPoint- en OpenDocument‑presentatieformaten ondersteund?**

Aspose.Slides [ondersteunt alle presentatieformaten](/slides/nl/java/supported-file-formats/), waaronder PPT, PPTX, ODP en andere gangbare bestandstypen. Hierdoor kunt u werken met presentaties die zijn gemaakt in verschillende versies van Microsoft PowerPoint.