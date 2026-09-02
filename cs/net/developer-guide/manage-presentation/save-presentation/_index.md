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
- Strict Office Open XML Formát
- režim Zip64
- obnovení miniatury
- ukládání průběhu
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v .NET pomocí Aspose.Slides—export do PowerPointu nebo OpenDocumentu při zachování rozvržení, fontů a efektů."
---
## **Přehled**

[Otevřít prezentace v C#](/slides/cs/net/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro .NET můžete uložit do **souboru** nebo **proudu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru voláním metody `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Do metody předáte název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Proveďte zde nějakou práci...

    // Uložte prezentaci do souboru.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Ukládání prezentací do proudu**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů proudu. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides vám umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/). Nastavte vlastnost [LastView](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/lastview/) na hodnotu z výčtu [ViewType](https://reference.aspose.com/slides/cs/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Ukládání prezentací ve formátu Strict Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/) a nastavte její vlastnost conformance při ukládání. Pokud nastavíte `Conformance.Iso29500_2008_Strict`, výstupní soubor bude uložen ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Ukládání prezentací v Office Open XML ve formátu Zip64**

Soubor Office Open XML je ZIP archiv, který omezuje nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu na 4 GB (2^32 bajtů) a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 zvyšují tato omezení na 2^64.

Vlastnost [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/zip64mode/) vám umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tato vlastnost poskytuje následující režimy:

- `IfNecessary` používá rozšíření ZIP64 pouze, pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `Never` nikdy nepoužívá rozšíření ZIP64.
- `Always` vždy používá rozšíření ZIP64.

Následující kód demonstruje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="POZNÁMKA" color="warning" %}}
Při uložení s `Zip64Mode.Never` je vyvolána výjimka [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/), pokud není možné prezentaci uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací v Office Open XML s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese, aby byl vyvážený poměr mezi velikostí souboru a časem zpracování. V závislosti na vašich požadavcích můžete upřednostňovat rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje vlastnost [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/compressionlevel/), která umožňuje určit úroveň komprese použitou při ukládání prezentace ve formátu Office Open XML.

Dostupné úrovně komprese jsou:

- **None**: Žádná komprese. Soubory jsou uloženy tak, jak jsou.
- **Level1**: Nejrychlejší komprese s nejnižším poměrem komprese.
- **Level2**: Rychlejší komprese s mírně lepším poměrem než **Level1**.
- **Level3**: Lepší komprese než **Level2** s mírně vyšším dopadem na čas zpracování.
- **Level4**: Lepší komprese než **Level3**.
- **Level5**: Vylepšená komprese oproti **Level4** s dalším časem zpracování.
- **Level6**: Standardní komprese, která nabízí dobrý poměr mezi rychlostí zpracování a velikostí souboru. Toto je *výchozí úroveň komprese*.
- **Level7**: Lepší komprese než **Level6** s pomalejším zpracováním.
- **Level8**: Lepší komprese než **Level7**.
- **Level9**: Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelšího času zpracování.

Následující příklad ukazuje, jak uložit prezentaci jako soubor PPTX *bez komprese*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Ukládání prezentací bez obnovení miniatury**

Vlastnost [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura je během ukládání obnovena. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální miniatura je zachována. Pokud prezentace nemá miniaturu, žádná není vytvořena.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení miniatury.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Informace" color="info" %}}
Tato volba pomáhá snížit dobu potřebnou k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládání průběhu v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) se používá prostřednictvím vlastnosti `ProgressCallback`, kterou vystavuje rozhraní [ISaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isaveoptions/) a abstraktní třída [SaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/). Přiřaďte implementaci [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) k `ProgressCallback`, abyste získali aktualizace průběhu ukládání v procentech.

Následující ukázky kódu ukazují, jak použít `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Zde použijte hodnotu procentuálního pokroku.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Informace" color="info" %}}
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající své vlastní API. Aplikace vám umožní rozdělit prezentaci do několika souborů tím, že vybrané snímky uloží jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), takže se zapisují jen změny?**

Ne. Ukládání vždy vytvoří kompletní cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) **není thread‑safe** (/slides/cs/net/multithreading/); ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) se automaticky nekopírují — ujistěte se, že odkazy zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Firma, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/net/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.