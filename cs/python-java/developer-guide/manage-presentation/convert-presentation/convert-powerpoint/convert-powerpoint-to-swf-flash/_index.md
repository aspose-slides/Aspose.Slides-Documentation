---
title: Převod prezentací PowerPoint do SWF Flash v Pythonu pomocí Java
linktitle: PowerPoint na SWF
type: docs
weight: 80
url: /cs/python-java/convert-powerpoint-to-swf-flash/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na SWF
- prezentace na SWF
- snímek na SWF
- PPT na SWF
- PPTX na SWF
- PowerPoint na Flash
- prezentace na Flash
- snímek na Flash
- PPT na Flash
- PPTX na Flash
- uložit PPT jako SWF
- uložit PPTX jako SWF
- exportovat PPT do SWF
- exportovat PPTX do SWF
- Python
- Java
- Aspose.Slides
description: "Převod prezentací PowerPoint do SWF Flash v Pythonu pomocí Java s Aspose.Slides. Nakonfigurujte prohlížeč, poznámky, skryté snímky, kompresi a písma."
---
## **Přehled**

Aspose.Slides for Python via Java umožňuje převádět prezentace PowerPoint do SWF bez Microsoft PowerPoint. Použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) pro export prezentace a [SwfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/) pro nastavení prohlížeče, kvality obrázku a rozložení poznámek nebo komentářů.

## **Převést prezentace do formátu Flash**

Načtěte zdrojový soubor pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), nakonfigurujte [SwfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/) a uložte jej pomocí [SaveFormat.Swf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Swf).

Následující příklad exportuje `presentation.pptx` do `presentation.swf`. Zakáže vložený prohlížeč pomocí [setViewerIncluded](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/#setViewerIncluded) a přidá poznámky řečníka pod snímky pomocí [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Před spuštěním příkladu [install Aspose.Slides for Python via Java](/slides/cs/python-java/installation/) a umístěte `presentation.pptx` do pracovního adresáře. JVM se spustí jednou na každý proces Pythonu.

Příklad používá [NotesPositions.BottomFull](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomFull) prostřednictvím [setNotesPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) a předává rozložení do [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Pro zahrnutí komentářů také nakonfigurujte [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) před exportem.

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do souboru SWF?**

Ano. Zavolejte [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) s hodnotou `True`. Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu ovládat kompresi a konečnou velikost souboru SWF?**

Použijte [SwfOptions.setCompressed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/#setCompressed) pro zapnutí nebo vypnutí komprese a [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/#setJpegQuality) pro úpravu kvality JPEG obrázků. Nižší kvalita JPEG může snížit velikost souboru na úkor věrnosti obrazu.

**K čemu slouží vložený prohlížeč a kdy jej mám vypnout?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/#setViewerIncluded) určuje, zda vygenerovaný SWF obsahuje prohlížeč. Použijte `False`, když potřebujete exportované snímky bez vloženého prohlížeče, jak je ukázáno v předchozím příkladu.

**Co se stane, pokud na exportním počítači chybí zdrojové písmo?**

Můžete zadat výchozí běžné písmo pomocí [setDefaultRegularFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), které je zděděno třídou [SwfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/swfoptions/). Vyberte písmo dostupné v exportním procesu; náhrada písma může změnit vzhled textu a rozložení.