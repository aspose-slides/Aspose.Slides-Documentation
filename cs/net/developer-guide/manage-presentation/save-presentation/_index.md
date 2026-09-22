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
- prezentace do streamu
- předdefinovaný typ zobrazení
- striktní formát Office Open XML
- režim Zip64
- obnova náhledu
- průběh ukládání
- .NET
- C#
- Aspose.Slides
description: "Uložte prezentace PowerPoint a OpenDocument do souborů nebo streamů v C# s Aspose.Slides pro .NET a nakonfigurujte výstup PPTX a hlášení postupu."
---
## **Přehled**

Po vytvoření prezentace nebo [otevřít existující](/slides/cs/net/open-presentation/), použijte metodu [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) k zápisu výsledku. Aspose.Slides pro .NET může uložit prezentaci do souboru nebo streamu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce popisují standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Uložit prezentace do souborů**

Chcete‑li uložit prezentaci do souboru, předávejte cestu k výstupu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/) metodě [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytvoří prezentaci a uloží ji jako soubor PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Uložit prezentace v jejich původním formátu**

Pro příklady detekce souboru a streamu, chování nově vytvořených prezentací a rozdíl mezi zdrojovým a výstupním formátem viz [Určete původní formát prezentace](/slides/cs/net/detect-presentation-source-format/).

V aplikaci provádějící dávkové zpracování může být vstupní formát neznámý. Po načtení souboru přečtěte jeho původní formát z vlastnosti [IPresentation.SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/sourceformat/). Výslednou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/sourceformat/) předávejte metodě [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/tosaveformat/) pro získání odpovídající hodnoty [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/), a poté použijte [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) k zápisu upravené prezentace.

Následující kompletní příklad zpracuje každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, ve kterém byl načten:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/tosaveformat/) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty ukládání prezentací. Mapuje pouze zdrojové formáty prezentací; není určeno k výběru exportních formátů, jako jsou PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/sourceformat/) má za následek výjimku [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Legacy soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena ze streamu bez přípony souboru, může být soubor PPS nebo POT identifikován jako PPT. Pokud je nutné zachovat tyto starší podtypy, uchovejte původní název souboru nebo metadata formátu samostatně a použijte je při výběru výstupního názvu souboru a formátu.

## **Uložit prezentace do streamů**

Chcete‑li zapsat prezentaci bez použití konečné cesty k souboru, předávejte zapisovatelný [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/) metodě [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Tento přístup je užitečný, když musí být výstup vrácen z webové služby, uložen do databáze nebo zpracován v paměti.

Následující příklad uloží novou prezentaci do souborového streamu:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

Můžete určit zobrazení, ve kterém PowerPoint při otevření uložené prezentace nejprve zobrazí. Před uložením nastavte vlastnost [ViewProperties.LastView](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/lastview/) na hodnotu [ViewType](https://reference.aspose.com/slides/cs/net/aspose.slides/viewtype/).

Následující příklad nastaví zobrazení Slide Master jako počáteční:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Uložit prezentace ve striktním formátu Office Open XML**

Chcete‑li vytvořit soubor PPTX, který odpovídá strict profilu Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/) a nastavte její vlastnost [Conformance](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/conformance/) na `Conformance.Iso29500_2008_Strict`. Poté předejte možnosti metodě [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Uložit prezentace v Office Open XML formátu v režimu Zip64**

Standardní ZIP archiv omezuje komprimovanou i nekomprimovanou velikost každého záznamu, celkovou velikost archivu a počet záznamů. Protože soubor PPTX je ZIP archiv, může velmi velká prezentace tato omezení překročit. Rozšíření ZIP64 zvyšují příslušná omezení velikosti a počtu záznamů.

Pro ovládání, zda Aspose.Slides zapisuje rozšíření ZIP64, použijte vlastnost [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/zip64mode/):

- `IfNecessary` používá ZIP64 jen tehdy, když prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- `Never` zakazuje rozšíření ZIP64.
- `Always` vždy zapisuje rozšíření ZIP64.

Následující příklad vždy zapne rozšíření ZIP64 pro výstupní prezentaci:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Pokud je `Zip64Mode` nastaven na `Never` a prezentace se nevejde do standardních limitů ZIP, operace ukládání vyvolá výjimku [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Uložit prezentace v Office Open XML formátu s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání a velikost souboru nastavením vlastnosti [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/compressionlevel/). Výčtová hodnota [CompressionLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.export/compressionlevel/) poskytuje následující možnosti:

- `None` ukládá data bez komprese.
- `Level1` poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- `Level2` až `Level5` postupně upřednostňují menší výstup před rychlostí ukládání.
- `Level6` vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- `Level7` a `Level8` dále upřednostňují menší výstup před rychlostí ukládání.
- `Level9` poskytuje nejsilnější kompresi a vyžaduje nejvíce výpočetního času.

Následující příklad uloží prezentaci bez komprese:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Následující příklad použije maximální úroveň komprese:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Uložit prezentace bez obnovy náhledu**

Při uložení prezentace jako PPTX řídí vlastnost [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pptxoptions/refreshthumbnail/) její náhledový obrázek:

- `true` znovu generuje náhled během operace ukládání. Toto je výchozí hodnota.
- `false` zachovává existující náhled. Pokud prezentace nemá náhled, Aspose.Slides jej nevytvoří.

Následující příklad uloží prezentaci bez obnovení náhledu:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Vypnutí obnovy náhledu může snížit čas potřebný k uložení souboru PPTX.
{{% /alert %}}

## **Ukládat průběh v procentech**

Chcete‑li sledovat operaci ukládání, implementujte rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/) a přiřaďte implementaci vlastnosti [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides pak během exportu volá metodu [IProgressCallback.Reporting](https://reference.aspose.com/slides/cs/net/aspose.slides/iprogresscallback/reporting/) s hodnotami postupu.

Následující příklad hlásí postup exportu PDF do konzole:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose poskytuje bezplatný [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na Aspose.Slides API. Umožňuje uložit vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides inkrementální nebo „rychlé“ ukládání?**

Ne. Každá operace ukládání zapíše kompletní výstupní soubor místo aktualizace pouze změněných částí.

**Mohou více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) [není thread‑safe](/slides/cs/net/multithreading/). Přístup a ukládání každé instance provádějte z jediné vlákna najednou.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při uložení prezentace?**

[Hypertextové odkazy](/slides/cs/net/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě odkazované soubory, takže uložená prezentace musí i nadále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako je autor, název, společnost a datum vytvoření?**

Ano. Před uložením nastavte příslušné [vlastnosti dokumentu](/slides/cs/net/presentation-properties/) a Aspose.Slides je zapíše do výstupního souboru.