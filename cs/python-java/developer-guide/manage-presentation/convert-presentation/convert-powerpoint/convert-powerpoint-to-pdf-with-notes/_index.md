---
title: Převod prezentací PowerPoint do PDF s poznámkami v Pythonu
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- převod PowerPoint
- převod prezentace
- převod PPT
- převod PPTX
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- PPTX do PDF
- uložit prezentaci jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- poznámky přednášejícího
- PDF s poznámkami
- Python
- Java
- Aspose.Slides
description: "Převést prezentace PPT a PPTX do PDF s poznámkami přednášejícího pomocí Aspose.Slides pro Python prostřednictvím Javy. Nakonfigurujte umístění poznámek a zachovejte dlouhé poznámky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do PDF s poznámkami přednášejícího pomocí Aspose.Slides pro Python prostřednictvím Javy. Můžete zahrnout poznámky pod každým snímkem a umožnit dlouhým poznámkám pokračovat na dalších stránkách. Další nastavení exportu do PDF najdete v [Convert PowerPoint to PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).

## **Převod PowerPointu do PDF s poznámkami**

Použijte metodu [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), abyste exportovali prezentaci PPT nebo PPTX do PDF. Pro zahrnutí poznámek přednášejícího vytvořte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) a nakonfigurujte jeho metodu [setNotesPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Tento rozvrh přiřaďte k [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) pomocí [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Následující příklad načte `sample.pptx` a exportuje jej do `output.pdf` s poznámkami přednášejícího pod snímky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Nakonfigurujte možnosti PDF pro vykreslení poznámek přednášejícího.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Uložte prezentaci do PDF s poznámkami přednášejícího.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Můžete také vyzkoušet [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zabránit oříznutí dlouhých poznámek přednášejícího?**

Použijte [NotesPositions.BottomFull](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomFull), jak je uvedeno v příkladu výše. Toto nastavení zobrazí celé poznámky a v případě potřeby použije další stránky.

**Mohu mít každý snímek a jeho poznámky na jedné stránce?**

Použijte [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomTruncated). Toto nastavení omezuje poznámky na jednu stránku, takže poznámky, které se nevejdou, mohou být oříznuty.

**Jak exportovat snímky bez poznámek přednášejícího?**

Vynechte konfiguraci rozvržení poznámek a použijte standardní export do PDF popsaný v [Convert PowerPoint to PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).