---
title: Ukládání prezentací v .NET
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/net/save-presentation/
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
- postup ukládání
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v .NET pomocí Aspose.Slides—exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations in C#](/slides/cs/net/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvořit a uložit prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete již existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro .NET můžete uložit do **souboru** nebo **proudu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru voláním metody `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Předávejte názvy souboru a formát uložení metodě. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Proveďte zde nějakou práci...
    
    // Uložte prezentaci do souboru.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Ukládání prezentací do proudů**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů proudů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Uložte prezentaci do proudu.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Aspose.Slides vám umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, prostřednictvím třídy [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/). Nastavte vlastnost [LastView](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/lastview/) na hodnotu z výčtu [ViewType](https://reference.aspose.com/slides/cs/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Ukládání prezentací ve formátu Strict Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/) a nastavte její vlastnost Conformance při ukládání. Pokud nastavíte `Conformance.Iso29500_2008_Strict`, výstupní soubor bude uložen ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Uložte prezentaci ve formátu Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Ukládání prezentací v Office Open XML formátu v režimu Zip64**

Soubor Office Open XML je ZIP archiv, který omezuje nekomprimovanou velikost jakéhokoli souboru, komprimovanou velikost jakéhokoli souboru i celkovou velikost archivu na 4 GB (2^32 bytů) a také omezuje počet souborů v archivu na 65 535 (2^16‑1). Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Vlastnost [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/zip64mode/) vám umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tato vlastnost poskytuje následující režimy:

- `IfNecessary` používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `Never` nikdy nepoužívá rozšíření ZIP64.
- `Always` vždy používá rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Když uložíte s `Zip64Mode.Never`, je vyhozena výjimka [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací v Office Open XML formátu s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese, abyste vybalancovali velikost souboru a dobu zpracování. V závislosti na vašich požadavcích můžete preferovat rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje vlastnost [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/compressionlevel/), která vám umožňuje určit úroveň komprese používanou při ukládání prezentace v Office Open XML formátu.

Dostupné úrovně komprese jsou:

- **None**: Žádná komprese. Soubory jsou uloženy v původní podobě.
- **Level1**: Nejrychlejší komprese s nejnižším poměrem komprese.
- **Level2**: Rychlejší komprese s mírně lepším poměrem než **Level1**.
- **Level3**: Poskytuje lepší kompresi než **Level2** s mírným dopadem na dobu zpracování.
- **Level4**: Poskytuje lepší kompresi než **Level3**.
- **Level5**: Zlepšená komprese oproti **Level4** s dalším časem zpracování.
- **Level6**: Standardní komprese, která nabízí dobrý poměr rychlosti zpracování a velikosti souboru. Toto je *výchozí úroveň komprese*.
- **Level7**: Lepší komprese než **Level6** s pomalejším zpracováním.
- **Level8**: Lepší komprese než **Level7**.
- **Level9**: Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelší doby zpracování.

Následující příklad ukazuje, jak uložit prezentaci jako soubor PPTX *bez komprese*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Tento příklad ukazuje, jak uložit prezentaci jako soubor PPTX s *maximální kompresí*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Ukládání prezentací bez aktualizace miniatury**

Vlastnost [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura se při uložení aktualizuje. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, zachová se aktuální miniatura. Pokud prezentace nemá miniaturu, žádná se nevygeneruje.

V níže uvedeném kódu je prezentace uložena do PPTX bez aktualizace miniatury.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Tato možnost pomáhá zkrátit dobu potřebnou k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládání aktualizací postupu v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) se používá přes vlastnost `ProgressCallback` vystavenou rozhraním [ISaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isaveoptions/) a abstraktní třídou [SaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/). Přiřaďte implementaci [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) k `ProgressCallback`, abyste získali aktualizace postupu ukládání v procentech.

Níže uvedené úryvky kódu ukazují, jak použít `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Zde použijte hodnotu procenta postupu.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo **bezplatnou** aplikaci [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající vlastní API. Aplikace vám umožní rozdělit prezentaci do více souborů tím, že vybrané snímky uloží jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), aby se zapisovaly jen změny?**

Ne. Ukládání při každém volání vytvoří kompletní cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) **není thread‑safe** (/slides/cs/net/multithreading/); ukládejte ji z jediného vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) se automaticky nekopírují – zajistěte, aby odkazy zůstaly přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/net/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.