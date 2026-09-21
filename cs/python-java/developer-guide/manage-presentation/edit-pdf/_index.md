---
title: Upravit PDF dokumenty v Pythonu pomocí Javy
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/python-java/edit-pdf/
keywords:
- upravit PDF
- nahradit text v PDF
- PDF na PPTX
- PPTX na PDF
- Python
- Java
- Aspose.Slides
description: "Upravte PDF dokumenty v Pythonu přes Java importováním do Aspose.Slides, nahrazením textu a uložení upravené prezentace zpět do PDF."
---
## **Přehled**

Aspose.Slides for Python via Java vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a exportem zpět do PDF. Tento článek ukazuje jednoduché nahrazení textu. Prezentace zůstává v paměti, takže uložení mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) k importu stránek, [replaceText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#replaceText) k aktualizaci textu a [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) k exportu výsledku.

Následující příklad očekává, že `input.pdf` obsahuje slovo "Draft" jako upravitelný text po importu. Nahradí toto slovo slovem "Final" a zapíše `edited.pdf`. Vymazání počátečního snímku před importem zabraňuje vytvoření extra prázdné stránky ve výstupu. Vyhledávání odpovídá celým slovům se stejným velikostí písmen; `None` znamená, že není potřeba žádná zpětná volba výsledku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Další možnosti najdete v [Search and Replace Text](/slides/cs/python-java/search-and-replace-text/) a [Convert PowerPoint to PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Poznámka" %}}
Nahrazení textu funguje na importovaném textu, ne na textu uvnitř naskenovaných obrázků. Konverze může ovlivnit rozložení a formátování, proto výstup pečlivě zkontrolujte, zejména pokud je náhradní text delší než původní.
{{% /alert %}}

## **Často kladené otázky**

**Musím před exportem do PDF uložit soubor PPTX?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Uložte kopii PPTX jen pokud ji chcete také nadále upravovat v PowerPointu; viz [Save Presentations](/slides/cs/python-java/save-presentation/).

**Proč může některý text zůstat nezměněn?**

Příklad odpovídá celému slovu "Draft" s přesnou velikostí písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí odpovídat hledání. Zkontrolujte importovaný obsah a upravte hledání pro váš dokument.