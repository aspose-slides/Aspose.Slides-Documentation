---
title: Úprava PDF dokumentů v JavaScriptu
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/nodejs-java/edit-pdf/
keywords:
- upravit PDF
- nahradit text v PDF
- PDF do PPTX
- PPTX do PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Upravujte PDF dokumenty v JavaScriptu tím, že je importujete do Aspose.Slides, nahradíte text a uložíte upravenou prezentaci zpět do PDF."
---
## **Přehled**

Aspose.Slides for Node.js via Java vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a exportem zpět do PDF. Tento článek ukazuje jednoduché nahrazení textu. Prezentace zůstává v paměti, takže ukládání mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte addFromPdf k importu stránek, replaceText k aktualizaci textu a save k exportu výsledku.

Následující příklad očekává, že soubor `input.pdf` obsahuje slovo „Draft“ jako editovatelný text po importu. Nahrazuje toto slovo slovem „Final“ a zapíše `edited.pdf`. Vymazání úvodního snímku před importem zabraňuje vzniku extra prázdné stránky ve výstupu. Vyhledávání odpovídá celým slovům se stejným rozlišením velkých a malých písmen; `null` znamená, že není potřeba žádná zpětná výzva výsledku.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Pro více možností viz [Vyhledávání a nahrazení textu](/slides/cs/nodejs-java/search-and-replace-text/) a [Převod PowerPointu do PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Nahrazení textu funguje na importovaném textu, nikoli na textu uvnitř skenovaných obrázků. Konverze může ovlivnit rozvržení a formátování, proto výstup zkontrolujte, zejména pokud je náhradní text delší než originál.
{{% /alert %}}

## **Často kladené otázky**

**Potřebuji před exportem PDF uložit soubor PPTX?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Kopii PPTX uložte jen v případě, že ji chcete dále upravovat v PowerPointu; viz [Ukládání prezentací](/slides/cs/nodejs-java/save-presentation/).

**Proč může část textu zůstat nezměněna?**

Příklad odpovídá celému slovu „Draft“ s přesným rozlišením velkých a malých písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí vyhledávání odpovídat. Zkontrolujte importovaný obsah a upravte vyhledávání podle svého dokumentu.