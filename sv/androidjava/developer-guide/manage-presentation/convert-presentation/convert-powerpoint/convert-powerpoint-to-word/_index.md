---
title: Konvertera PowerPoint-presentationer till Word-dokument på Android
linktitle: PowerPoint till Word
type: docs
weight: 110
url: /sv/androidjava/convert-powerpoint-to-word/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till Word
- presentation till Word
- bild till Word
- PPT till Word
- PPTX till Word
- PowerPoint till DOCX
- presentation till DOCX
- bild till DOCX
- PPT till DOCX
- PPTX till DOCX
- PowerPoint till DOC
- presentation till DOC
- bild till DOC
- PPT till DOC
- PPTX till DOC
- spara PPT som DOCX
- spara PPTX som DOCX
- exportera PPT till DOCX
- exportera PPTX till DOCX
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT- och PPTX-bilder till redigerbara Word-dokument i Java med Aspose.Slides för Android med exakt layout, bilder och formatering bevarade."
---
## **Översikt**

Den här artikeln ger en lösning för utvecklare för att konvertera PowerPoint‑ och OpenDocument‑presentationer till Word‑dokument med Aspose.Slides och Aspose.Words. Den steg‑för‑steg‑guiden leder dig genom alla steg i konverteringsprocessen.

## **Aspose.Slides och Aspose.Words**

För att konvertera en PowerPoint‑fil (PPTX eller PPT) till Word (DOCX eller DOCX) behöver du både [Aspose.Slides for Android via Java](https://products.aspose.com/slides/sv/androidjava/) och [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/).

Som ett fristående API ger [Aspose.Slides](https://products.aspose.app/slides) för java funktioner som låter dig extrahera text från presentationer. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) är ett avancerat dokumentbehandlings‑API som låter applikationer skapa, ändra, konvertera, rendera, skriva ut filer och utföra andra uppgifter med dokument utan att använda Microsoft Word.

## **Konvertera PowerPoint till Word**

1. Ladda ner biblioteken [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/sv/java) och [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Lägg till *aspose-slides-x.x-jdk16.jar* och *aspose-words-x.x-jdk16.jar* i din CLASSPATH.
3. Använd detta kodexempel för att konvertera PowerPoint‑filen till Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // genererar en bild av bilden som en bytearrayström
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // infogar bildens texter
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

**Vilka komponenter måste installeras för att konvertera PowerPoint- och OpenDocument-presentationer till Word-dokument?**

Du behöver bara lägga till det respektive paketet för [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/sv/androidjava/) och [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) i ditt projekt. Båda biblioteken fungerar som fristående API:er, och det finns inget krav på att Microsoft Office måste vara installerat.

**Stöds alla PowerPoint- och OpenDocument-presentationformat?**

Aspose.Slides [stöder alla presentationsformat](/slides/sv/androidjava/supported-file-formats/), inklusive PPT, PPTX, ODP och andra vanliga filtyper. Detta säkerställer att du kan arbeta med presentationer som skapats i olika versioner av Microsoft PowerPoint.