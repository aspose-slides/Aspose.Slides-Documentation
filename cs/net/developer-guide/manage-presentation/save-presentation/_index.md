---
title: "Ukládání prezentací v .NET"
linktitle: "Uložit prezentaci"
type: docs
weight: 80
url: /cs/net/save-presentation/
keywords:
- "uložit PowerPoint"
- "uložit OpenDocument"
- "uložit prezentaci"
- "uložit snímek"
- "uložit PPT"
- "uložit PPTX"
- "uložit ODP"
- "prezentace do souboru"
- "prezentace do streamu"
- "předdefinovaný typ zobrazení"
- "striktní formát Office Open XML"
- "režim Zip64"
- "obnovení miniatury"
- "průběh ukládání"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Objevte, jak ukládat prezentace v .NET pomocí Aspose.Slides — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, fontů a efektů."
---
## **Přehled**

[Open Presentations in C#](/slides/cs/net/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro .NET můžete uložit do **souboru** nebo **streamu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Uložit prezentace do souborů**

Uložit prezentaci do souboru zavoláním metody `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Předáte metodě název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Proveďte zde nějakou práci...

    // Uložte prezentaci do souboru.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Uložit prezentace do streamů**

Můžete uložit prezentaci do streamu předáním výstupního streamu metodě `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů streamů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Uložte prezentaci do streamu.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

Aspose.Slides vám umožní nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, prostřednictvím třídy [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/). Nastavte vlastnost [LastView](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/lastview/) na hodnotu z výčtu [ViewType](https://reference.aspose.com/slides/cs/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Uložit prezentace ve striktním formátu Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve striktním formátu Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/) a nastavte její vlastnost conformance při ukládání. Pokud nastavíte `Conformance.Iso29500_2008_Strict`, výstupní soubor bude uložen ve striktním formátu Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve striktním formátu Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Uložte prezentaci ve striktním formátu Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Uložit prezentace v formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost souboru na 4 GB (2^32 bajtů), komprimovanou velikost na 4 GB a celkovou velikost archivu také na 4 GB a také omezuje počet souborů v archivu na 65 535 (2^16‑1). Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Vlastnost [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/zip64mode/) vám umožňuje zvolit, kdy při ukládání souboru Office Open XML použít rozšíření ZIP64.

Tato vlastnost poskytuje následující režimy:

- `IfNecessary` používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `Never` nikdy nepoužije rozšíření ZIP64.
- `Always` vždy používá rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako PPTX s povolenými rozšířeními ZIP64:

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
Když ukládáte s `Zip64Mode.Never`, je vyvolána [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/)..., pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložit prezentace bez obnovení miniatury**

Vlastnost [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) řídí generování miniatur při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura se při ukládání obnoví. Toto je výchozí hodnota.
- Pokud je nastavena na `false`, aktuální miniatura se zachová. Pokud prezentace nemá miniaturu, žádná se nevytvoří.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení miniatury.

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
Tato možnost pomáhá snížit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládat průběh ukládání v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) se používá přes vlastnost `ProgressCallback`, kterou vystavuje rozhraní [ISaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isaveoptions/) a abstraktní třída [SaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/). Přiřaďte implementaci [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) k `ProgressCallback`, abyste získali aktualizace průběhu ukládání v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

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
        // Použijte zde hodnotu procentuálního postupu.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinula [free PowerPoint Splitter app](https://products.aspose.app/slides/cs/splitter) pomocí svého vlastního API. Aplikace vám umožní rozdělit prezentaci do více souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), takže jsou zapisovány jen změny?**

Ne. Ukládání pokaždé vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) není [isn’t thread-safe](/slides/cs/net/multithreading/); ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány – ujistěte se, že odkazované cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [document properties](/slides/cs/net/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.