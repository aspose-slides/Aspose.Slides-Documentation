---
title: PowerPoint-presentaties omzetten naar Word-documenten op Android
linktitle: PowerPoint naar Word
type: docs
weight: 110
url: /nl/androidjava/convert-powerpoint-to-word/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint‑PPT‑en‑PPTX‑dia's omzetten naar bewerkbare Word‑documenten in Java met Aspose.Slides voor Android, met behoud van exacte lay-out, afbeeldingen en opmaak."
---
## **Overzicht**

Dit artikel biedt een oplossing voor ontwikkelaars om PowerPoint‑ en OpenDocument‑presentaties om te zetten naar Word‑documenten met behulp van Aspose.Slides en Aspose.Words. De stapsgewijze handleiding leidt je door elke fase van het conversieproces.

## **Aspose.Slides en Aspose.Words**

Om een PowerPoint‑bestand (PPTX of PPT) naar Word (DOCX of DOC) te converteren, heb je zowel [Aspose.Slides for Android via Java](https://products.aspose.com/slides/nl/androidjava/) als [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/) nodig.

Als zelfstandige API biedt [Aspose.Slides](https://products.aspose.app/slides) voor java functies die je in staat stellen teksten uit presentaties te extraheren. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) is een geavanceerde documentverwerkings‑API die applicaties in staat stelt bestanden te genereren, wijzigen, converteren, renderen, afdrukken en andere taken uit te voeren met documenten zonder Microsoft Word te gebruiken.

## **PowerPoint naar Word converteren**

1. Download de bibliotheken [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/nl/java) en [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Voeg *aspose-slides-x.x-jdk16.jar* en *aspose-words-x.x-jdk16.jar* toe aan je CLASSPATH.
3. Gebruik dit code‑fragment om de PowerPoint naar Word te converteren:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // genereert een diaafbeelding als een byte‑arraystroom
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

**Welke componenten moeten geïnstalleerd worden om PowerPoint‑ en OpenDocument‑presentaties naar Word‑documenten te converteren?**

Je hoeft alleen het bijbehorende pakket voor [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/nl/androidjava/) en [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) toe te voegen aan je project. Beide bibliotheken functioneren als zelfstandige API’s, en er is geen vereiste om Microsoft Office te installeren.

**Worden alle PowerPoint‑ en OpenDocument‑presentatieformaten ondersteund?**

Aspose.Slides [ondersteunt alle presentatieformaten](/slides/nl/androidjava/supported-file-formats/), inclusief PPT, PPTX, ODP en andere gangbare bestandssoorten. Dit zorgt ervoor dat je met presentaties kunt werken die in verschillende versies van Microsoft PowerPoint zijn gemaakt.