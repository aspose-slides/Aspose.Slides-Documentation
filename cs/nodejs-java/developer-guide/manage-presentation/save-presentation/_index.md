---
title: "Ukládání prezentací v JavaScriptu"
linktitle: "Uložit prezentaci"
type: docs
weight: 80
url: /cs/nodejs-java/save-presentation/
keywords:
- "uložit PowerPoint"
- "uložit OpenDocument"
- "uložit prezentaci"
- "uložit snímek"
- "uložit PPT"
- "uložit PPTX"
- "uložit ODP"
- "prezentace do souboru"
- "prezentace do proudu"
- "předdefinovaný typ zobrazení"
- "striktní formát Office Open XML"
- "režim Zip64"
- "obnovení miniatury"
- "ukládání postupu"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Objevte, jak ukládat prezentace pomocí Aspose.Slides pro Node.js prostřednictvím JavaScriptu — export do PowerPointu nebo OpenDocumentu při zachování rozložení, fontů a efektů."
---
## **Přehled**

[Otevření prezentací v JavaScriptu](/slides/cs/nodejs-java/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít uložit po dokončení. S Aspose.Slides pro Node.js můžete ukládat do **souboru** nebo **proudu**. Tento článek vysvětluje různé způsoby ukládání prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru zavoláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Jako argumenty metody předáte název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Proveďte zde nějakou práci...

    // Uložte prezentaci do souboru.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací do proudu**

Prezentaci můžete uložit do proudu předáním výstupního proudu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů proudu. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Uložte prezentaci do proudu.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Aspose.Slides vám umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/). Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#setLastView) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve striktním formátu Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve striktním formátu Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/) a nastavte při ukládání její vlastnost *conformance*. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), výstupní soubor bude uložen ve striktním formátu Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve striktním formátu Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Uložte prezentaci ve striktním formátu Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu na 4 GB (2^32 bajtů) a počet souborů na 65 535 (2^16‑1). Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) vám umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tato metoda může být použita s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#IfNecessary) používá rozšíření ZIP64 pouze v případě, že velikost prezentace překročí výše uvedená omezení. Jedná se o výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Never) nikdy nevyužívá rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Always) vždy používá rozšíření ZIP64.

Následující kód demonstruje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Při ukládání s [Zip64Mode.Never](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Never) je vyhozena výjimka [PptxException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací ve formátu Office Open XML se stupni komprese**

Při práci s velkými prezentacemi můžete nastavit úroveň komprese, aby byl vyvážený poměr mezi velikostí souboru a časem zpracování. V závislosti na požadavcích můžete upřednostňovat rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje metodu [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), která umožňuje určit úroveň komprese při ukládání prezentace ve formátu Office Open XML.

Následující úrovně komprese jsou k dispozici:

- [**None**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#None): Žádná komprese není použita. Soubory jsou uloženy beze změny.
- [**Level1**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level1): Nejrychlejší komprese s nejnižším poměrem komprese.
- [**Level2**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level2): Rychlejší komprese s mírně lepším poměrem než **Level1**.
- [**Level3**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level3): Poskytuje lepší kompresi než **Level2** s mírně vyšším dopadem na čas zpracování.
- [**Level4**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level4): Poskytuje lepší kompresi než **Level3**.
- [**Level5**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level5): Poskytuje vylepšenou kompresi oproti **Level4** s dodatkovým časem zpracování.
- [**Level6**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level6): Standardní komprese, která nabízí dobrý kompromis mezi rychlostí zpracování a velikostí souboru. Jedná se o *výchozí úroveň komprese*.
- [**Level7**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level7): Poskytuje lepší kompresi než **Level6** s pomalejším zpracováním.
- [**Level8**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level8): Poskytuje lepší kompresi než **Level7**.
- [**Level9**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level9): Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelšího času zpracování.

Následující příklad ukazuje, jak uložit prezentaci jako soubor PPTX *bez komprese*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Tento příklad ukazuje, jak uložit prezentaci jako soubor PPTX s *maximální kompresí*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací bez obnovení miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí generování miniatury při ukládání prezentace do formátu PPTX:

- Pokud je nastavena na `true`, miniatura je během ukládání obnovena. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální miniatura je zachována. Pokud prezentace nemá miniaturu, žádná není vytvořena.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení miniatury.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Tato volba pomáhá zkrátit dobu potřebnou k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládání průběhových informací v procentech**

Zprávy o postupu ukládání jsou konfigurovány pomocí metody [setProgressCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) na třídě [SaveOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/) a jejích podtřídách. Poskytněte Java proxy, která implementuje rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/); během exportu bude callback přijímat periodické aktualizace v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Použijte zde hodnotu procentuálního postupu.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo bezplatnou aplikaci [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající vlastní API. Aplikace umožňuje rozdělit prezentaci do více souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), aby se zapisovaly jen změny?**

Ne. Ukládání při každém volání vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je ukládání stejné instance Presentation z více vláken bezpečné?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) není thread‑safe; ukládejte ji z jedné vlákna.

**Co se stane s hyperlinky a externě propojenými soubory při ukládání?**

[Hyperlinky](/slides/cs/nodejs-java/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány — zajistěte, aby odkazy zůstaly přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Firma, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/nodejs-java/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.