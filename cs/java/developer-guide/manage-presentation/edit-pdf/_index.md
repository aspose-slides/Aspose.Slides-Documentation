---
title: Upravit PDF dokumenty v Java
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/java/edit-pdf/
keywords:
- upravit PDF
- nahradit text v PDF
- PDF do PPTX
- PPTX do PDF
- Java
- Aspose.Slides
description: "Upravujte PDF dokumenty v Java pomocí importu do Aspose.Slides, nahrazení textu a uložení upravené prezentace zpět do PDF."
---
## **Přehled**

Aspose.Slides for Java vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a následným exportem zpět do PDF. Tento článek ukazuje jednoduchou náhradu textu. Prezentace zůstává v paměti, takže uložení mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [addFromPdf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) k importu stránek, [replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) k aktualizaci textu a [save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) k exportu výsledku.

Následující příklad předpokládá, že `input.pdf` obsahuje slovo „Draft“ jako editovatelný text po importu. Nahrazuje toto slovo slovem „Final“ a zapisuje do `edited.pdf`. Vymazání úvodního snímku před importem zabraňuje vytvoření další prázdné stránky ve výstupu. Vyhledávání odpovídá celým slovům se stejnou velikostí písmen; `null` znamená, že není potřeba zpětné volání výsledku.

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

Další možnosti najdete v [Search and Replace Text](/slides/cs/java/search-and-replace-text/) a [Convert PowerPoint to PDF](/slides/cs/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Poznámka" %}}

Nahrazení textu funguje na importovaném textu, nikoli na textu uvnitř skenovaných obrázků. Převod může ovlivnit rozložení a formátování, proto výstup přezkoumejte, zejména pokud je nahrazovaný text delší než původní.

{{% /alert %}}

## **Často kladené otázky**

**Musím uložit soubor PPTX před exportem do PDF?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Kopii PPTX uložte pouze tehdy, pokud ji chcete dále upravovat v PowerPointu; viz [Save Presentations](/slides/cs/java/save-presentation/).

**Proč některý text zůstane nezměněn?**

Příklad odpovídá celému slovu „Draft“ s přesnou velikostí písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí odpovídat vyhledávání. Zkontrolujte importovaný obsah a upravte vyhledávání podle svého dokumentu.