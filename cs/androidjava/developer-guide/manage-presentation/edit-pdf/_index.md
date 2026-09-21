---
title: Úprava PDF dokumentů na Androidu
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/androidjava/edit-pdf/
keywords:
- upravit PDF
- nahradit text PDF
- PDF na PPTX
- PPTX na PDF
- Android
- Java
- Aspose.Slides
description: "Upravte PDF dokumenty na Androidu pomocí Javy tím, že je importujete do Aspose.Slides, nahradíte text a uložíte upravenou prezentaci zpět do PDF."
---
## **Přehled**

Aspose.Slides pro Android přes Java vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a exportem zpět do PDF. Tento článek ukazuje jednoduchou náhradu textu. Prezentace zůstává v paměti, takže ukládání mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [addFromPdf](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) k importu stránek, [replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) k aktualizaci textu a [save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) k exportu výsledku.

Cílový příklad předpokládá, že `input.pdf` obsahuje slovo "Draft" jako editovatelný text po importu. Nahrazuje toto slovo slovem "Final" a zapisuje do `edited.pdf`. Vymazání úvodního snímku před importem zabraňuje vzniku extra prázdné stránky ve výstupu. Vyhledávání odpovídá celým slovům se stejným rozlišením velikosti písmen; `null` znamená, že není potřeba žádná zpětná volání výsledku.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Další možnosti najdete v [Vyhledávání a nahrazení textu](/slides/cs/androidjava/search-and-replace-text/) a [Převod PowerPointu do PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Poznámka" %}}
Nahrazení textu funguje na importovaném textu, nikoli na textu ve skenovaných obrázcích. Konverze může ovlivnit rozložení a formátování, proto zkontrolujte výstup, zejména pokud je nahrazovaný text delší než původní.
{{% /alert %}}

## **Často kladené otázky**

**Potřebuji uložit soubor PPTX před exportem do PDF?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Uložte kopii PPTX jen v případě, že ji chcete také dál upravovat v PowerPointu; viz [Uložit prezentace](/slides/cs/androidjava/save-presentation/).

**Proč může některý text zůstat nezměněn?**

Příklad odpovídá celému slovu "Draft" s přesným rozlišením velikosti písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí nutně odpovídat vyhledávání. Zkontrolujte importovaný obsah a upravte vyhledávání podle vašeho dokumentu.