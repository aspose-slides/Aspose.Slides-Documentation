---
title: Ukládání prezentací v Java
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/java/save-presentation/
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
- přísný formát Office Open XML
- režim Zip64
- obnovení miniatury
- ukládání postupu
- Java
- Aspose.Slides
description: "Objevte, jak v Java pomocí Aspose.Slides — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations in Java](/slides/cs/java/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro Java můžete ukládat do **souboru** nebo **proudu**. Tento článek popisuje různé způsoby ukládání prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru voláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Metodě předáte název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Proveďte zde nějakou práci...

    // Uložte prezentaci do souboru.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací do proudů**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Prezentaci lze zapsat do různých typů proudů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Uložte prezentaci do proudu.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Aspose.Slides umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/). Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#setLastView-int-) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve formátu Strict Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/) a při ukládání nastavte její vlastnost `conformance`. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), výstupní soubor bude uložen ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Uložte prezentaci ve formátu Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu na 4 GB (2^32 bajtů) a také limituje počet souborů v archivu na 65 535 (2^16‑1). Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tuto metodu můžete použít s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#IfNecessary) používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Never) nikdy nepoužije rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Always) vždy použije rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako PPTX s povolenými rozšířeními ZIP64:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Při ukládání s [Zip64Mode.Never](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Never) se vyhodí výjimka [PptxException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací bez obnovení miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura se při ukládání obnoví. Jedná se o výchozí nastavení.
- Pokud je nastavena na `false`, aktuální miniatura se zachová. Pokud prezentace nemá miniaturu, žádná se nevygeneruje.

V níže uvedeném kódu se prezentace uloží do PPTX bez obnovení miniatury.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Tato možnost pomáhá zkrátit dobu potřebnou k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládání průběhu v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) se používá prostřednictvím metody `setProgressCallback` vystavené rozhraním [ISaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isaveoptions/) a abstraktní třídou [SaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/). Implementaci [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) přiřaďte pomocí `setProgressCallback`, abyste získali aktualizace průběhu ukládání v procentech.

Níže jsou ukázky kódu, jak použít `IProgressCallback`.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Použijte zde hodnotu postupu v procentech.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo bezplatnou aplikaci [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající vlastní API. Aplikace vám umožní rozdělit prezentaci do několika souborů tím, že vybrané snímky uloží jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), aby se zapisovaly jen změny?**

Ne. Ukládání vždy vytvoří úplný cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné z více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) **není** bezpečná pro více vláken; ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hypertextové odkazy](/slides/cs/java/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) se automaticky nekopírují — ujistěte se, že odkazy na cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/java/presentation-properties/) jsou podporovány a při ukládání se zapíší do souboru.