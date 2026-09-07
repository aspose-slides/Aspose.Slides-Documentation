---
title: Převod prezentací PowerPoint do dokumentů Word v Pythonu přes Java
linktitle: PowerPoint do Wordu
type: docs
weight: 110
url: /cs/python-java/convert-powerpoint-to-word/
keywords:
- převést PowerPoint
- převést prezentaci
- PowerPoint do Wordu
- prezentace do Wordu
- PPT do Wordu
- PPTX do Wordu
- ODP do Wordu
- PowerPoint do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- uložit PPT jako DOCX
- uložit PPTX jako DOCX
- exportovat PPT do DOCX
- exportovat PPTX do DOCX
- Python
- Java
- Aspose.Slides
description: "Převod prezentací PowerPoint a OpenDocument do Wordu v Pythonu přes Java s Aspose.Slides a Aspose.Words, kombinující obrázky snímků s editovatelným textem."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides pro Python přes Java spolu s Aspose.Words pro Java. Aspose.Slides vykresluje každý snímek a čte jeho text, zatímco Aspose.Words vytváří dokument Word pomocí JPype. Microsoft Office není vyžadován.

Výsledný dokument obsahuje obrázek snímku následovaný editovatelným textem extrahovaným z horních automatických tvarů snímku. Obrázek zachovává vizuální vzhled snímku; jednotlivé tvary, grafy a tabulky nejsou převedeny na editovatelné objekty Wordu. Extrahovaný text si neuchovává původní formátování textu ani umístění.

## **Převod PowerPointu do Wordu**

1. Nainstalujte [Aspose.Slides for Python via Java](/slides/cs/python-java/installation/) a kompatibilní Java runtime.
2. Stáhněte [Aspose.Words for Java](https://releases.aspose.com/words/java/). Umístěte jeho hlavní JAR soubor do adresáře `lib` vedle vašeho skriptu a přejmenujte jej na `aspose-words.jar`, nebo upravte cestu v příkladu tak, aby odpovídala staženému souboru.
3. Umístěte vstupní prezentaci `sample.pptx` do pracovního adresáře. Cesta `lib/aspose-words.jar` je také relativní k tomuto adresáři.
4. Spusťte následující Python kód pro vytvoření `output.docx`.

Příklad načítá zdroj pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a vykresluje snímky pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage). Používá [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) z Aspose.Words k vložení obrázků a textu do dokumentu Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Přizpůsobte obrázek snímku šířce textové oblasti při zachování poměru stran.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Přidejte prostý text z hlavních automatických tvarů, včetně textových polí.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Každý snímek začíná na nové stránce. Dlouhý extrahovaný text nebo neobvykle vysoké obrázky snímků mohou vyžadovat další stránky. Kód přidává zalomení stránky pouze mezi snímky a uvolňuje prezentaci a vykreslené obrázky v blocích `finally`. JVM zůstává dostupný pro následné převody ve stejném Python procesu.

## **Často kladené otázky**

**Které knihovny jsou vyžadovány?**

Použijte Aspose.Slides pro Python přes Java, JPype, kompatibilní Java runtime a Aspose.Words pro Java. Obě knihovny Aspose běží ve stejném JVM. Aspose.Slides zpracovává prezentaci; Aspose.Words zapisuje dokument Word.

**Mohu převádět soubory PPT a ODP stejně jako PPTX?**

Ano. Nahraďte `sample.pptx` souborem PPT nebo ODP. Viz [Supported File Formats](/slides/cs/python-java/supported-file-formats/) pro vstupní formáty prezentací.

**Je celý obsah snímku editovatelný ve Wordu?**

Ne. Každý snímek je vložen jako statický obrázek, pod ním je přidán prostý text z horních automatických tvarů. Text uvnitř skupin, tabulek, SmartArt a grafů, stejně jako poznámky k řečníkovi, není tímto příkladem extrahován. Animace a přechody nejsou v dokumentu Word reprodukovány.

**Mohu uložit jako DOC místo DOCX?**

Ano. Změňte název výstupního souboru na `output.doc`. Aspose.Words vybírá výstupní formát podle přípony souboru při použití tohoto přetížení metody ukládání.