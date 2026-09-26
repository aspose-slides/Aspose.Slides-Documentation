---
title: Převod prezentací PowerPoint do PDF s poznámkami v Pythonu
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- převést PowerPoint
- převést prezentaci
- převést PPT
- převést PPTX
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- PPTX do PDF
- uložit prezentaci jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- poznámky řečníka
- PDF s poznámkami
- Python
- Java
- Aspose.Slides
description: "Převést prezentace PPT a PPTX do PDF s poznámkami řečníka pomocí Aspose.Slides pro Python přes Java. Nakonfigurujte umístění poznámek a zachovejte dlouhé poznámky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do PDF s poznámkami řečníka pomocí Aspose.Slides pro Python přes Java. Můžete zahrnout poznámky pod každým snímkem a umožnit dlouhým poznámkám pokračovat na dalších stránkách. Pro další nastavení exportu PDF viz [Convert PowerPoint to PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).

Pro nastavení rozměrů a orientace stránky s poznámkami před exportem viz [Notes Page Size](/slides/cs/python-java/notes-size/).

## **Převést PowerPoint do PDF s poznámkami**

Použijte metodu [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) k exportu prezentace PPT nebo PPTX do PDF. Pro zahrnutí poznámek řečníka vytvořte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) a nakonfigurujte umístění poznámky pomocí jeho metody [setNotesPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Tento rozvrh přiřaďte ke [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) pomocí [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Následující příklad načte `sample.pptx` a exportuje jej do `output.pdf` s poznámkami řečníka pod snímky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Nakonfigurujte možnosti PDF pro vykreslení poznámek řečníka.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Uložte prezentaci do PDF s poznámkami řečníka.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Můžete také vyzkoušet [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zabránit oříznutí dlouhých poznámek řečníka?**

Použijte [NotesPositions.BottomFull](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomFull), jak je uvedeno v příkladu výše. Toto nastavení zobrazuje celé poznámky a v případě potřeby použije další stránky.

**Mohu mít každý snímek a jeho poznámky na jedné stránce?**

Použijte [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomTruncated). Toto nastavení omezuje poznámky na jednu stránku, takže poznámky, které se nevejdou, mohou být oříznuty.

**Jak exportovat snímky bez poznámek řečníka?**

Vynechte konfiguraci rozvrhu poznámek a použijte standardní export PDF popsaný v [Convert PowerPoint to PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).