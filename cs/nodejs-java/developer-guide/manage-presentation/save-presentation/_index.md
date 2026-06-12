---
title: Ukládání prezentací v JavaScriptu
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/nodejs-java/save-presentation/
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
- Striktní formát Office Open XML
- režim Zip64
- obnovení miniatury
- ukládání postupu
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte, jak ukládat prezentace pomocí Aspose.Slides pro Node.js prostřednictvím Java—export do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations in JavaScript](/slides/cs/nodejs-java/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít uložit, když skončíte. S Aspose.Slides pro Node.js můžete uložit do **souboru** nebo **streamu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru zavoláním metody `save` třídy Presentation. Předáte názvu souboru a formátu uložení metodě. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```js
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

## **Ukládání prezentací do streamů**

Můžete uložit prezentaci do streamu předáním výstupního streamu metodě `save` třídy Presentation. Prezentaci lze zapsat do mnoha typů streamů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Uložte prezentaci do streamu.
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
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve Formátu Strict Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/) a nastavte její vlastnost conformance při ukládání. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), výstupní soubor je uložen ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Uložte prezentaci ve formátu Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost jakéhokoli souboru, komprimovanou velikost jakéhokoli souboru i celkovou velikost archivu na 4 GB (2^32 bytů) a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) vám umožňuje zvolit, kdy použít rozšíření formátu ZIP64 při ukládání souboru Office Open XML.

Tato metoda může být použita s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#IfNecessary) používá rozšíření formátu ZIP64 pouze v případě, že prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Never) nikdy nepoužije rozšíření formátu ZIP64.
- [Always](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Always) vždy použije rozšíření formátu ZIP64.

Následující kód demonstruje, jak uložit prezentaci jako PPTX s povolenými rozšířeními ZIP64:

```js
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
Když ukládáte s Zip64Mode.Never, je vyvolána výjimka [PptxException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxexception/), pokud není možné prezentaci uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací bez obnovení miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura je během uložení obnovena. Toto je výchozí hodnota.
- Pokud je nastavena na `false`, aktuální miniatura je zachována. Pokud prezentace nemá miniaturu, žádná není vytvořena.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení její miniatury.

```js
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

## **Ukládání aktualizací postupu v procentech**

Zpráva o postupu ukládání je konfigurována pomocí metody [setProgressCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) na třídě [SaveOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/) a jejích podtřídách. Poskytněte Java proxy, která implementuje rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/); během exportu callback přijímá periodické aktualizace v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Použijte zde hodnotu procenta postupu.
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
Aspose vyvinulo bezplatnou aplikaci PowerPoint Splitter pomocí svého API. Aplikace vám umožní rozdělit prezentaci do více souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **FAQ**

**Je podporováno „rychlé uložení“ (inkrementální ukládání), takže se zapisují jen změny?**

Ne. Ukládání vždy vytvoří celý cílový soubor; inkrementální „rychlé uložení“ není podporováno.

**Je bezpečné ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) není **thread‑safe**; ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hyperlinky](/slides/cs/nodejs-java/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) se automaticky nekopírují – ujistěte se, že odkazy na cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/nodejs-java/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.