---
title: Převod prezentací PowerPoint do Markdownu v PHP
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/php-java/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do MD
- prezentace do MD
- snímek do MD
- PPT do MD
- PPTX do MD
- uložit PowerPoint jako Markdown
- uložit prezentaci jako Markdown
- uložit snímek jako Markdown
- uložit PPT jako MD
- uložit PPTX jako MD
- exportovat PPT do MD
- exportovat PPTX do MD
- PowerPoint
- prezentace
- Markdown
- PHP
- Aspose.Slides
description: "Převod snímků PowerPoint — PPT, PPTX — do čistého Markdownu pomocí Aspose.Slides pro PHP přes Java, automatizujte dokumentaci a zachovejte formátování."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu Markdown, což může být užitečné pro pracovní postupy dokumentace, generování statických webů, migraci obsahu a publikování textu pod verzovacím řízením. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak ovládat způsob, jakým je obsah snímků vygenerován v dokumentu Markdown.

Můžete exportovat prezentace jako prostý Markdown, vybírat z několika variant Markdownu, jako je CommonMark a GitHub Flavored Markdown, a nastavit, jak jsou během exportu zpracovávány obrázky. Pro prezentace, které obsahují vizuální obsah, vám Aspose.Slides také umožní uložit obrázky do samostatné složky a odkazovat na ně z vygenerovaného souboru Markdown.

{{% alert color="warning" %}}
Export z PowerPointu do Markdownu je ve výchozím nastavení **bez obrázků**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte nastavit `ExportType = MarkdownExportType::Visual` a zadat `BasePath`, kam budou uloženy obrázky odkazované v dokumentu Markdown.
{{% /alert %}}

## **Převod prezentace do Markdownu**

Tato sekce vysvětluje, jak Aspose.Slides převádí prezentace PowerPoint a OpenDocument (PPT, PPTX, ODP) do čistého Markdownu, přičemž zachovává původní strukturu snímků, text a základní formátování, takže můžete obsah znovu použít v dokumentaci nebo ve workflow pod verzovacím řízením bez další manuální práce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) představující prezentaci.
2. Použijte metodu [save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) k exportu jako souboru Markdown.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Převod prezentace do varianty Markdownu**

Aspose.Slides vám umožní převést prezentace PowerPoint do Markdownu se základní syntaxí, stejně jako do CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab a dalších sedmnácti variant Markdownu.

Následující PHP kód ukazuje, jak převést prezentaci PowerPoint do CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

23 podporovaných variant Markdownu je uvedeno v [enumeraci Flavor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/flavor/).

## **Převod prezentace obsahující obrázky do Markdownu**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) poskytuje vlastnosti a enumerace, které vám umožní konfigurovat výsledný soubor Markdown. Například enumerace [MarkdownExportType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownexporttype/) určuje, jak jsou obrázky zpracovávány: `Sequential`, `TextOnly` nebo `Visual`.

{{% alert color="warning" %}}
Ve výchozím nastavení export z PowerPointu do Markdownu **neobsahuje obrázky**. Pro vložení obrázků zavolejte `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` a nastavte `BasePath`, který určuje, kam budou uloženy obrázky odkazované v souboru Markdown.
{{% /alert %}}

### **Převod obrázků sekvenčně**

Pokud chcete, aby se obrázky ve výsledném Markdownu objevily jednotlivě, jeden po druhém, musíte zvolit možnost `Sequential`. Následující PHP kód ukazuje, jak převést prezentaci obsahující obrázky do Markdownu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Převod obrázků vizuálně**

Pokud chcete, aby se obrázky ve výsledném Markdownu objevily společně, musíte zvolit možnost `Visual`. V tomto případě jsou obrázky uloženy do aktuálního adresáře aplikace (a v dokumentu Markdown je pro ně vygenerována relativní cesta), nebo můžete zadat svůj preferovaný adresář a název složky.

Následující PHP kód demonstruje operaci:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Zůstávají hypertextové odkazy při exportu do Markdownu zachovány?**

Ano. Textové [hyperlinky](/slides/cs/php-java/manage-hyperlinks/) jsou zachovány jako standardní odkazy v Markdownu. [Přechody](/slides/cs/php-java/slide-transition/) a [animace](/slides/cs/php-java/powerpoint-animation/) snímků nejsou převedeny.

**Mohu urychlit konverzi spuštěním ve více vláknech?**

Můžete paralelizovat na úrovni souborů, ale [nesdílejte](/slides/cs/php-java/multithreading/) stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) napříč vlákny. Používejte samostatné instance/procesy pro každý soubor, abyste se vyhnuli konfliktům.

**Co se stane s obrázky – kde jsou uloženy a jsou cesty relativní?**

[Obrázky](/slides/cs/php-java/image/) jsou exportovány do samostatné složky a soubor Markdown je standardně odkazuje relativními cestami. Můžete nastavit základní výstupní cestu a název složky pro aktiva, aby struktura repozitáře byla předvídatelná.