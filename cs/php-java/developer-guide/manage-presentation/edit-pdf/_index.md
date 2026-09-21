---
title: Upravit PDF dokumenty v PHP
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/php-java/edit-pdf/
keywords:
- upravit PDF
- nahradit text PDF
- PDF do PPTX
- PPTX do PDF
- PHP
- Aspose.Slides
description: "Upravte PDF dokumenty v PHP jejich importem do Aspose.Slides, nahrazením textu a uložením upravené prezentace zpět do PDF."
---
## **Přehled**

Aspose.Slides for PHP via Java vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a následným exportem zpět do PDF. Tento článek ukazuje jednoduchou náhradu textu. Prezentace zůstává v paměti, takže ukládání dočasného souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [SlideCollection::addFromPdf](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/#addFromPdf) k importu stránek, [Presentation::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceText) k aktualizaci textu a [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) k exportu výsledku.

Následující příklad předpokládá, že `input.pdf` obsahuje slovo „Draft“ jako editovatelný text po importu. Nahradí toto slovo slovem „Final“ a zapíše soubor `edited.pdf`. Vymazání úvodního snímku před importem zabraňuje vzniku další prázdné stránky ve výstupu. Vyhledávání odpovídá celým slovům se stejným rozlišením velikosti písmen; `null` znamená, že není potřeba žádná zpětná volání pro výsledek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Další možnosti najdete v [Search and Replace Text](/slides/cs/php-java/search-and-replace-text/) a [Convert PowerPoint to PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Poznámka" %}}
Nahrazení textu funguje na importovaném textu, nikoli na textu ve skenovaných obrázcích. Konverze může ovlivnit rozvržení a formátování, takže výstup pečlivě zkontrolujte, zejména pokud je náhradní text delší než původní.
{{% /alert %}}

## **Často kladené otázky**

**Musím uložit soubor PPTX před exportem do PDF?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Uložte kopii PPTX pouze v případě, že ji také chcete nadále upravovat v PowerPointu; viz [Save Presentations](/slides/cs/php-java/save-presentation/).

**Proč může některý text zůstat nezměněn?**

Příklad odpovídá celému slovu „Draft“ s přesným rozlišením velikosti písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámečků nemusí nutně odpovídat vyhledávání. Zkontrolujte importovaný obsah a upravte vyhledávání pro svůj dokument.