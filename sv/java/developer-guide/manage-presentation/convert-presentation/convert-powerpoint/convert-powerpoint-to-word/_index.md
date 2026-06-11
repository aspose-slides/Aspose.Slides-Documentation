---
title: Konvertera PowerPoint-presentationer till Word-dokument i Java
linktitle: PowerPoint till Word
type: docs
weight: 110
url: /sv/java/convert-powerpoint-to-word/
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
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT- och PPTX-bilder till redigerbara Word-dokument i Java med Aspose.Slides med exakt layout, bilder och formatering bevarade."
---
## **Översikt**

Denna artikel ger en lösning för utvecklare för att konvertera PowerPoint- och OpenDocument-presentationer till Word-dokument med hjälp av Aspose.Slides och Aspose.Words. Den steg‑för‑steg‑guiden går igenom varje steg i konverteringsprocessen.

## **Konvertera PowerPoint till Word**

Följ instruktionerna nedan för att konvertera en PowerPoint- eller OpenDocument-presentation till ett Word-dokument:

1. Ladda ner [Aspose.Slides for Java](https://downloads.aspose.com/slides/sv/java) och [Aspose.Words for Java](https://downloads.aspose.com/words/java) biblioteken.
2. Lägg till *aspose-slides-x.x-jdk16.jar* och *aspose-words-x.x-jdk16.jar* i din CLASSPATH.
3. Använd detta kodexempel för att konvertera PowerPoint till Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
        // genererar en bild av bilden som en byte-arrayström
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

## **Vanliga frågor**

**Vilka komponenter behöver installeras för att konvertera PowerPoint- och OpenDocument-presentationer till Word-dokument?**

Du behöver bara lägga till det respektive paketet för [Aspose.Slides for Java](https://releases.aspose.com/slides/sv/java/) och [Aspose.Words for Java](https://releases.aspose.com/words/java/) i ditt projekt. Båda biblioteken fungerar som fristående API:er, och det finns inget krav på att Microsoft Office måste vara installerat.

**Stöds alla PowerPoint- och OpenDocument-presentationformat?**

Aspose.Slides [stödjer alla presentationsformat](/slides/sv/java/supported-file-formats/), inklusive PPT, PPTX, ODP och andra vanliga filtyper. Detta säkerställer att du kan arbeta med presentationer som skapats i olika versioner av Microsoft PowerPoint.