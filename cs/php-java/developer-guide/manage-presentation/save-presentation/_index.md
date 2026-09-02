---
title: Ukládání prezentací v PHP
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/php-java/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do streamu
- předdefinovaný typ zobrazení
- Strict Office Open XML formát
- režim Zip64
- obnovení náhledu
- ukládání průběhu
- PHP
- Aspose.Slides
description: "Objevte, jak ukládat prezentace pomocí Aspose.Slides pro PHP prostřednictvím Javy — export do PowerPointu nebo OpenDocumentu při zachování rozložení, fontů a efektů."
---
## **Přehled**

[Open Presentations in PHP](/slides/cs/php-java/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od začátku nebo upravujete existující, po dokončení ji budete chtít uložit. S Aspose.Slides pro PHP můžete ukládat do **souboru** nebo **streamu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru voláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Předávejte metodě název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Proveďte zde nějakou práci...

    // Uložte prezentaci do souboru.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací do streamů**

Prezentaci můžete uložit do streamu předáním výstupního streamu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů streamů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Uložte prezentaci do streamu.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Aspose.Slides umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/). Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/#setLastView) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací ve Strict Office Open XML formátu**

Aspose.Slides umožňuje uložit prezentaci ve Strict Office Open XML formátu. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/) a při ukládání nastavte její vlastnost `conformance`. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), výstupní soubor bude uložen ve Strict Office Open XML formátu.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve Strict Office Open XML formátu.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Uložte prezentaci ve Strict Office Open XML formátu.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací v Office Open XML formátu v režimu Zip64**

Soubor Office Open XML je ZIP archiv, který omezuje nekomprimovanou velikost jakéhokoli souboru, komprimovanou velikost a celkovou velikost archivu na 4 GB (2^32 bajtů) a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tyto limity zvyšují na 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setZip64Mode) vám umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tato metoda může být použita s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#IfNecessary) používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Never) nikdy nepoužívá rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Always) vždy používá rozšíření ZIP64.

Následující kód demonstruje, jak uložit prezentaci jako PPTX soubor s povolenými rozšířeními ZIP64:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Při uložení s [Zip64Mode.Never](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Never) je vyhozena výjimka [PptxException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací v Office Open XML formátu s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese tak, aby vyvážila velikost souboru a dobu zpracování. Podle vašich požadavků můžete upřednostnit rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje metodu [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setCompressionLevel), která umožňuje specifikovat úroveň komprese používanou při ukládání prezentace v Office Open XML formátu.

K dispozici jsou následující úrovně komprese:

- [**None**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#None): Žádná komprese není použita. Soubory jsou uloženy tak, jak jsou.
- [**Level1**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level1): Nejrychlejší komprese s nejnižším kompresním poměrem.
- [**Level2**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level2): Rychlejší komprese s mírně lepším poměrem než **Level1**.
- [**Level3**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level3): Lepší komprese než **Level2** s mírným dopadem na dobu zpracování.
- [**Level4**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level4): Lepší komprese než **Level3**.
- [**Level5**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level5): Vylepšená komprese oproti **Level4** s dalším časem zpracování.
- [**Level6**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level6): Standardní komprese, která nabízí dobrý poměr mezi rychlostí zpracování a velikostí souboru. Toto je *výchozí úroveň komprese*.
- [**Level7**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level7): Lepší komprese než **Level6** s pomalejším zpracováním.
- [**Level8**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level8): Lepší komprese než **Level7**.
- [**Level9**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level9): Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelší doby zpracování.

Následující příklad ukazuje, jak uložit prezentaci jako PPTX soubor *bez komprese*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Tento příklad ukazuje, jak uložit prezentaci jako PPTX soubor s *maximální kompresí*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací bez obnovení náhledu**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí generování náhledu při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, náhled je během ukládání obnoven. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální náhled je zachován. Pokud prezentace nemá náhled, není žádný vygenerován.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení náhledu.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Tato volba pomáhá zkrátit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládání průběhu v procentech**

Zprávy o průběhu ukládání se konfigurovají pomocí metody [setProgressCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setProgressCallback) na třídě [SaveOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/) a jejích podtřídách. Poskytněte Java proxy, která implementuje rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/); během exportu callback přijímá periodické aktualizace v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Použijte zde hodnotu procentuálního postupu.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající jejich vlastní API. Aplikace vám umožní rozdělit prezentaci do více souborů uložením vybraných snímků jako nové PPTX nebo PPT soubory.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální uložení), aby se zapisovaly jen změny?**

Ne. Ukládání vždy vytvoří kompletní cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) [není thread‑safe](/slides/cs/php-java/multithreading/); ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hypertextové odkazy](/slides/cs/php-java/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány – ujistěte se, že odkazy zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Firma, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/php-java/presentation-properties/) jsou podporovány a budou při uložení zapsány do souboru.