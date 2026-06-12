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
- prezentace do proudu
- předdefinovaný typ zobrazení
- striktní formát Office Open XML
- režim Zip64
- obnovení náhledu
- ukládání postupu
- PHP
- Aspose.Slides
description: "Objevte, jak ukládat prezentace pomocí Aspose.Slides pro PHP prostřednictvím Java — export do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations in PHP](/slides/cs/php-java/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít uložit po dokončení. S Aspose.Slides pro PHP můžete uložit do **souboru** nebo **proudu**. Tento článek popisuje různé způsoby ukládání prezentace.

## **Uložit prezentace do souborů**

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

## **Uložit prezentace do proudů**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů proudů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Uložte prezentaci do proudu.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

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

## **Uložit prezentace ve striktním formátu Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve striktním formátu Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/) a při ukládání nastavte její vlastnost conformance. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), výstupní soubor bude uložen ve striktním formátu Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve striktním formátu Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Uložte prezentaci ve striktním formátu Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Uložit prezentace ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost jakéhokoli souboru, komprimovanou velikost a celkovou velikost archivu na 4 GB (2^32 bajtů) a také omezuje počet souborů v archivu na 65 535 (2^16‑1). Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setZip64Mode) vám umožňuje zvolit, kdy použít rozšíření formátu ZIP64 při ukládání souboru Office Open XML.

Tuto metodu lze použít s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#IfNecessary) používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Never) nikdy nepoužívá rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Always) vždy používá rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako PPTX s povolenými rozšířeními formátu ZIP64:

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
Když ukládáte s [Zip64Mode.Never](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Never), je vyvolána výjimka [PptxException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložit prezentace bez obnovování náhledu**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí generování náhledu při ukládání prezentace do PPTX:
- Pokud je nastavena na `true`, náhled se během ukládání obnoví. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální náhled se zachová. Pokud prezentace nemá náhled, žádný se nevygeneruje.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení jejího náhledu.

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
Tato volba pomáhá snížit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládat aktualizace postupu v procentech**

Zprávy o průběhu ukládání jsou nakonfigurovány pomocí metody [setProgressCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setProgressCallback) na třídě [SaveOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/) a jejích podtřídách. Poskytněte Java proxy, která implementuje rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/); během exportu volaná metoda periodicky získává aktualizace v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Použijte zde hodnotu procenta postupu.
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
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) pomocí vlastního API. Aplikace vám umožní rozdělit prezentaci do více souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), takže se zapisují pouze změny?**

Ne. Ukládání vytváří při každém zápisu celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné (thread‑safe) ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) [není thread‑safe](/slides/cs/php-java/multithreading/); uložte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hyperlinky](/slides/cs/php-java/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) se automaticky nekopírují — ujistěte se, že odkazy na cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/php-java/presentation-properties/) jsou podporovány a při uložení budou zapsány do souboru.