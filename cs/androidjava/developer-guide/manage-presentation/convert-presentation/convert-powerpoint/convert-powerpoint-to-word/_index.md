---
title: Převod prezentací PowerPoint do dokumentů Word na Androidu
linktitle: PowerPoint do Wordu
type: docs
weight: 110
url: /cs/androidjava/convert-powerpoint-to-word/
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
- Android
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint PPT a PPTX do editovatelných dokumentů Word v jazyce Java pomocí Aspose.Slides pro Android s přesným zachováním rozložení, obrázků a formátování."
---
## **Přehled**

Tento článek poskytuje vývojářům řešení pro převod prezentací PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides a Aspose.Words. Průvodce krok za krokem vás provede každou fází převodního procesu.

## **Aspose.Slides a Aspose.Words**

Chcete‑li převést soubor PowerPoint (PPTX nebo PPT) do Wordu (DOCX nebo DOCX), potřebujete jak [Aspose.Slides for Android via Java](https://products.aspose.com/slides/cs/androidjava/), tak [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/).

Jako samostatné API poskytuje [Aspose.Slides](https://products.aspose.app/slides) pro java funkce, které umožňují extrahovat texty z prezentací.  

[Aspose.Words](https://docs.aspose.com/words/androidjava/) je pokročilé API pro zpracování dokumentů, které umožňuje aplikacím generovat, upravovat, převádět, vykreslovat, tisknout soubory a provádět další úkony s dokumenty bez použití Microsoft Word.

## **Převod PowerPoint do Wordu**

1. Stáhněte knihovny [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/cs/java) a [Aspose.Words for Java](https://downloads.aspose.com/words/java).  
2. Přidejte *aspose-slides-x.x-jdk16.jar* a *aspose-words-x.x-jdk16.jar* do vašeho CLASSPATH.  
3. Použijte tento útržek kódu k převodu PowerPointu do Wordu:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // vytvoří obrázek snímku jako proud bajtového pole
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // vkládá texty snímku
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

Stačí přidat příslušný balíček pro [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/cs/androidjava/) a [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) do vašeho projektu. Obě knihovny fungují jako samostatná API a není vyžadováno, aby byl nainstalován Microsoft Office.

**Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?**

Aspose.Slides [podporuje všechny formáty prezentací](/slides/cs/androidjava/supported-file-formats/), včetně PPT, PPTX, ODP a dalších běžných typů souborů. To zajišťuje, že můžete pracovat s prezentacemi vytvořenými v různých verzích Microsoft PowerPoint.