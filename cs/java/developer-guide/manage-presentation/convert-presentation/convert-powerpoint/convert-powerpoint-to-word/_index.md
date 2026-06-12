---
title: Převod prezentací PowerPoint do dokumentů Word v Javě
linktitle: PowerPoint do Wordu
type: docs
weight: 110
url: /cs/java/convert-powerpoint-to-word/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do Wordu
- prezentace do Wordu
- snímek do Wordu
- PPT do Wordu
- PPTX do Wordu
- PowerPoint do DOCX
- prezentace do DOCX
- snímek do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- prezentace do DOC
- snímek do DOC
- PPT do DOC
- PPTX do DOC
- uložit PPT jako DOCX
- uložit PPTX jako DOCX
- exportovat PPT do DOCX
- exportovat PPTX do DOCX
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint PPT a PPTX do editovatelných dokumentů Word v Javě pomocí Aspose.Slides se zachováním přesného rozvržení, obrázků a formátování."
---
## **Přehled**

Tento článek poskytuje vývojářům řešení pro převod prezentací PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides a Aspose.Words. Průvodce krok za krokem vás provede každou fází procesu konverze.

## **Převod PowerPointu do Wordu**

Postupujte podle níže uvedených instrukcí pro převod prezentace PowerPoint nebo OpenDocument do dokumentu Word:

1. Stáhněte knihovny [Aspose.Slides for Java](https://downloads.aspose.com/slides/cs/java) a [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Přidejte *aspose-slides-x.x-jdk16.jar* a *aspose-words-x.x-jdk16.jar* do svého CLASSPATH.
3. Použijte následující úryvek kódu pro převod PowerPointu do Wordu:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // vytvoří obrázek snímku jako proud bajtů
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // vloží texty snímku
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

## **Často kladené otázky**

**Jaké komponenty je třeba nainstalovat pro převod prezentací PowerPoint a OpenDocument do dokumentů Word?**

Stačí přidat odpovídající balíček pro [Aspose.Slides for Java](https://releases.aspose.com/slides/cs/java/) a [Aspose.Words for Java](https://releases.aspose.com/words/java/) do vašeho projektu. Obě knihovny fungují jako samostatná API a není nutné mít nainstalovaný Microsoft Office.

**Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?**

Aspose.Slides [podporuje všechny formáty prezentací](/slides/cs/java/supported-file-formats/), včetně PPT, PPTX, ODP a dalších běžných typů souborů. To zajišťuje, že můžete pracovat s prezentacemi vytvořenými v různých verzích Microsoft PowerPoint.