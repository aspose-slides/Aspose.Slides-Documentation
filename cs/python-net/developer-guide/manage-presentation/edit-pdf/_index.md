---
title: Upravit PDF dokumenty v Pythonu
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/python-net/edit-pdf/
keywords:
- upravit PDF
- nahradit text PDF
- PDF na PPTX
- PPTX na PDF
- Python
- Aspose.Slides
description: "Upravte PDF dokumenty v Pythonu importováním do Aspose.Slides, nahrazením textu a uložením upravené prezentace zpět do PDF."
---
## **Přehled**

Aspose.Slides pro Python přes .NET vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímky, úpravou prezentace a exportem zpět do PDF. Tento článek ukazuje jednoduchou náhradu textu. Prezentace zůstává v paměti, takže uložení mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [add_from_pdf](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_from_pdf/) k importu stránek, [replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_text/) k aktualizaci textu a [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) k exportu výsledku.

Následující příklad očekává, že `input.pdf` po importu obsahuje slovo „Draft“ jako editovatelný text. Nahradí toto slovo slovem „Final“ a zapíše `edited.pdf`. Vymazání úvodního snímku před importem zabraňuje extra prázdné stránce ve výstupu. Vyhledávání odpovídá celým slovům se stejným rozlišením velkých a malých písmen; `None` znamená, že není potřeba žádná zpětná volání výsledku.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Pro více možností viz [Vyhledávání a nahrazování textu](/slides/cs/python-net/search-and-replace-text/) a [Převod PowerPointu do PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Nahrazení textu funguje na importovaném textu, ne na textu uvnitř skenovaných obrázků. Konverze může ovlivnit rozložení a formátování, takže výstup zkontrolujte, zejména pokud je náhradní text delší než původní.
{{% /alert %}}

## **Často kladené otázky**

**Musím uložit soubor PPTX před exportem do PDF?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Uložte kopii PPTX jen pokud chcete nadále upravovat v PowerPointu; viz [Ukládání prezentací](/slides/cs/python-net/save-presentation/).

**Proč může některý text zůstat nezměněn?**

Příklad odpovídá celému slovu „Draft“ s přesným rozlišením velikosti písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí nutně odpovídat vyhledávání. Zkontrolujte importovaný obsah a upravte vyhledávání pro váš dokument.