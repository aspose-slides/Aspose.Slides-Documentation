---
title: Export prezentací do XAML v .NET
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/net/export-to-xaml/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- PowerPoint do XAML
- OpenDocument do XAML
- prezentace do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- uložit PPT jako XAML
- uložit PPTX jako XAML
- uložit ODP jako XAML
- exportovat PPT do XAML
- exportovat PPTX do XAML
- exportovat ODP do XAML
- .NET
- C#
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v .NET pomocí Aspose.Slides—rychlé řešení bez Office, které zachová rozvržení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručné představení XAML, ukazuje, jak uložit prezentaci do XAML s výchozím nastavením, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek souvisejících s rezervními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je značkovací jazyk založený na XML, který se používá k popisu uživatelských rozhraní v rámcích jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S XAML soubory můžete pracovat ve vizuálním designéru nebo psát a upravovat značky přímo.

## **Export prezentací do XAML s výchozími možnostmi**

Následující příklad v C# ukazuje, jak exportovat prezentaci do XAML s výchozím nastavením:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Ve výchozím nastavení jsou exportované snímky uloženy do podsložky `pres` v aktuálním pracovním adresáři procesu, jak vrací [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Složka je vytvořena automaticky a všechny potřebné obrázky jsou také uloženy tam.

Název výstupní složky je odvozen od názvu zdrojového souboru bez jeho přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dále. I když zadáte absolutní cestu ke vstupní prezentaci, výstupní složka je vytvořena relativně k aktuálnímu pracovnímu adresáři, nikoli vedle vstupního souboru.

## **Export prezentací do XAML s vlastními možnostmi**

Pro řízení toho, jak Aspose.Slides exportuje prezentaci do XAML, použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/ixamloptions/).

Chcete-li uložit výstup na vlastní místo, implementujte [IXamlOutputSaver](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/ixamloutputsaver/) a přiřaďte instanci vaší implementace k vlastnosti [OutputSaver](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/outputsaver/) objektu [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/).

Pro zahrnutí skrytých snímků do výstupu XAML nastavte vlastnost [ExportHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) na `true`, jak ukazuje následující příklad v C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Zachycení všech vygenerovaných XAML artefaktů**

Export XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Přiřaďte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/ixamloutputsaver/) k [XamlOptions.OutputSaver](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/outputsaver/), abyste tyto artefakty získali místo výchozího ukládání do souborového systému. Spusťte export pomocí XAML‑specifické přetížené metody [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/), která přijímá XAML možnosti.

### **Pochopení životního cyklu zpětných volání**

Exportér volá [IXamlOutputSaver.Save](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/ixamloutputsaver/save/) samostatně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní složky. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Ukladač je zodpovědný za zachování nebo trvalé uložení dat před návratem. Příklady kopírují každý pole bajtů do paměti vlastněné aplikací.
- Export považujte za úspěšný jen tehdy, když operace uložení prezentace skončí a každé zpětné volání bylo úspěšně dokončeno. Nezahazujte chyby úložiště ani nespouštějte nepozorované zápisy na pozadí. Pokud se perzistence provede později, hlaste celkový úspěch až po úspěšném dokončení i tohoto kroku.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) se také vztahuje na vlastní ukladač. Jeho výchozí hodnota `false` vylučuje XAML dokumenty skrytých snímků. Nastavením na `true` je zahrne spolu se všemi zdroji potřebnými pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jedno zpětné volání na snímek ani pevně dané pořadí zpětných volání.

### **Export do paměti a kontrola artefaktů**

Tento kompletní příklad načte `pres.pptx`, shromáždí každý artefakt v [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) a vytiskne jeho název, typ a počet bajtů. Přesně zachovává poskytnuté názvy. Duplicitní názvy způsobí selhání kolekce místo tichého přepsání artefaktu.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Dekódujte pouze XAML a pouze když je potřeba textová inspekce.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Spusťte `InMemoryXamlExample.Run` z vaší aplikace. Kontrola rozšíření je užitečná při inspekci; uchovejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu ponechte bajty beze změny. Používejte [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) pouze pro XAML, který vyžaduje textové zpracování.

### **Zabalení shromážděných artefaktů do ZIP archivu**

Tento samostatný příklad shromažďuje export, ověřuje jeho názvy a zapisuje původní bajty do ZIP archivu. Jedinečný název archivu odděluje souběžné exportní úlohy. ZIP položky používají dopředná lomítka a zachovávají relativní složky. Neplatné názvy nebo názvy, které po normalizaci kolidují, odhodí celý balík před jeho zápisem.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ZIP adresář byl dokončen při uvolnění před oznámením úspěchu.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Spusťte `ZipXamlExample.Run` z vaší aplikace. Příklad používá [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) k zápisu jednoho lokálního archivu; samotný exportér nezapisuje volné XAML nebo obrázkové soubory. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráváním shromážděných polí bajtů. Použijte identifikátor export‑úlohy plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data v řádku databáze. Publikujte úlohu až po dokončení všech nahrávek nebo po potvrzení transakce databáze. Vyčistěte částečný výstup, pokud perzistence selže.

U velkých prezentací může vlastní ukladač perzistentně ukládat každý artefakt přímo do úložiště aplikace, aby se předešlo udržování další kopie celého exportu v paměti aplikace. Exportér stále sbírá všechny vygenerované artefakty v paměti před voláním ukladače. Udržujte každé zpětné volání synchronní z pohledu exportéru: vraťte se až poté, co cíl přijal bajty, a nechte selhání dosáhnout volajícího.

### **Zachování názvů zdrojů a ověření odkazů**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní složky. Nepoužívejte pouze [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename), pokud nevíte, že každý vygenerovaný název je unikátní a odkazy na zdroje zůstávají platné.
- Použijte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítejte kořenové cesty a segmenty traversalu, vyřešte cíl pomocí [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) a ověřte, že zůstává pod zamýšleným exportním adresářem, včetně oddělovače adresáře v kontrole obsahu. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Používejte oddělený ukladač a jmenný prostor úložiště pro každou exportní úlohu. Detekujte kolize po normalizaci oddělovačů a podle pravidel citlivosti na velikost písmen cíle.
- Před publikací analyzujte každý XAML dokument jako XML a prozkoumejte jeho reference na soubory, např. atributy `Source` nebo `ImageSource`. Rozřešte každý relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte výsledný název úložiště a potvrďte, že odpovídající klíč slovníku, položka ZIP nebo uložený objekt existuje. Zpracovávejte externí URI a XAML syntaktické výrazy odděleně od relativních názvů souborů.

Například pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, uložený zdroj musí být dostupný jako `pres/images/image1.png`. Pouze `image1.png` by přerušilo tento vztah. Pro objektové úložiště zachovejte stejnou strukturu pod prefixem úlohy a zpřístupněte tyto URL zdrojům XAML spotřebitele. Znovu otevřete dokončený ZIP, ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, abyste potvrdili správné rozlišení obrázků.

## **Časté dotazy**

**Jak zajistit předvídatelné fonty, pokud není původní font na počítači k dispozici?**

Nastavte [DefaultRegularFont](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/defaultregularfont/) v [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/) — používá se jako náhradní font během exportu, když původní chybí. To nezaručuje, že generované XAML odkazuje na náhradní font nebo že font bude k dispozici na cílovém počítači. Ujistěte se, že fonty odkazované v XAML jsou dostupné v prostředí, kde je zobrazováno.

**Je exportované XAML určeno jen pro WPF, nebo jej lze použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím veřejného API. Kompatibilita s dalšími XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte generované značky ve vašem cílovém prostředí.

**Jsou skryté snímky podporovány a jak je zabránit jejich exportu ve výchozím nastavení?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [ExportHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) v [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/) — nechte tuto možnost vypnutou, pokud je nepotřebujete exportovat.