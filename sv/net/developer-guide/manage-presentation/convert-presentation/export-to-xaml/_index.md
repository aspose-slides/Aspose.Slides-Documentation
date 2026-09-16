---
title: Exportera presentationer till XAML i .NET
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/net/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i .NET med Aspose.Slides—snabb, Office-fri lösning som bevarar din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint‑presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via XamlOptions, inklusive export av dolda bilder. Artikeln besvarar också några vanliga frågor relaterade till reservteckensnitt, XAML‑stack‑kompatibilitet och beteendet för export av dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk såsom WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande C#‑exempel visar hur du exporterar en presentation till XAML med standardinställningar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Som standard sparas de exporterade bilderna i en `pres`‑undermapp i processens nuvarande arbetskatalog, som returneras av Directory.GetCurrentDirectory. Mappen skapas automatiskt och eventuella erforderliga bilder sparas där också.

Utdata‑mappens namn tas från källa‑filens namn utan filändelse. För `pres.pptx` får utdatafilerna namnen `pres/Slide_1.xaml`, `pres/Slide_2.xaml` osv. Även om du anger en absolut sökväg till inmatnings‑presentationen skapas utdata‑mappen relativt till den aktuella arbetskatalogen, snarare än bredvid inmatningsfilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd IXamlOptions‑gränssnittet för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata till en anpassad plats, implementera IXamlOutputSaver och tilldela en instans av din implementation till OutputSaver‑egenskapen i XamlOptions.

För att inkludera dolda bilder i XAML‑utdata, sätt ExportHiddenSlides‑egenskapen till `true`, som visas i följande C#‑exempel:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Fånga alla genererade XAML‑artefakter**

En XAML‑export kan skapa ett XAML‑dokument för varje exporterad bild samt separata bilder och stödresurser. Tilldela en anpassad IXamlOutputSaver till XamlOptions.OutputSaver för att ta emot dessa artefakter istället för standard‑filsystem‑spararen. Starta exporten med den XAML‑specifika Presentation.Save‑overloaden som accepterar XAML‑alternativ.

### **Förstå callback‑livscykeln**

Exportören anropar IXamlOutputSaver.Save separat för varje genererad artefakt:

- `path` identifierar artefakten och kan innehålla relativa kataloger. Behåll denna information eftersom XAML kan referera resurser med relativa sökvägar.
- `data` innehåller artefaktens bytes. Bilder och andra binära resurser får inte avkodas som text.
- Spararen är ansvarig för att behålla eller persistera datan innan den returneras. Exemp​len kopierar varje byte‑array till applikationsägd minne.
- Betänk exporten som lyckad endast när Presentation‑sparningsoperationen returnerar och varje callback har slutförts framgångsrikt. Undvik att undertrycka lagringsfel eller påbörja osynliga bakgrundsskrivningar. Om persisteringen sker efteråt, rapportera total framgång först när även det steget lyckas.

XamlOptions.ExportHiddenSlides gäller också för en anpassad sparare. Dess standardvärde, false, utesluter XAML‑dokument för dolda bilder. Att sätta det till true inkluderar dem samt alla resurser som krävs för deras export. Antalet resurser beror på presentationen; anta inte en callback per bild eller en fast callback‑ordning.

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel laddar `pres.pptx`, samlar varje artefakt i ett Dictionary<string, byte[]> och skriver ut dess namn, typ och byte‑antal. Det bevarar de angivna namnen exakt. Dubblettnamn får insamlingen att misslyckas istället för att tyst skriva över en artefakt.

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

            // Avkoda endast XAML, och endast när textuell inspektion behövs.
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

Anropa InMemoryXamlExample.Run från din applikation. Filändelsekontroller är användbara för inspektion; behåll alla artefakter, inklusive okända resurstyp­er. Lämna bytes oförändrade vid lagring eller överföring. Använd Encoding.UTF8.GetString endast för XAML som kräver textbearbetning.

### **Paketera insamlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytena till ett ZIP‑arkiv. Ett unikt arkivnamn separerar samtidiga exportjobb. ZIP‑poster använder snedstreck framåt och behåller relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

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

        // ZIP-katalogen har slutförts genom disposal innan framgång rapporteras.
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

Anropa ZipXamlExample.Run från din applikation. Exemplet använder ZipArchive för att skriva ett lokalt arkiv; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring, ersätt steget för arkivskrivning med uppladdning av de insamlade byte‑arrayerna. Använd ett export‑jobb‑identifierare plus hela relativa artefaktnamnet som en blob‑nyckel, eller lagra jobb‑identifieraren, relativa namnet och binärdata i en databastrad. Publicera jobbet först när alla uppladdningar är klara eller databas‑transaktionen har committats. Rensa partiell utdata om persisteringen misslyckas.

För stora presentationer kan en anpassad sparare persistera varje artefakt direkt till applikationslagring för att undvika att hålla en extra kopia av hela exporten i minnet. Exportören samlar fortfarande alla genererade artefakter i minnet innan spararen anropas. Håll varje callback synkron från exportörens perspektiv: returnera först när destinationen har accepterat bytena, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa kataloger. Använd inte bara Path.GetFileName såvida inte varje genererat namn är känt att vara unikt och resurshänvisningarna förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. Vid skrivning av lösa filer, avvisa rotade sökvägar och traverseringssegment, lös destinationen med Path.GetFullPath och verifiera att den förblir under den avsedda exportkatalogen, inklusive katalogavgränsaren i innehållskontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje exportjobb. Upptäck kollisioner efter separator‑normalisering och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, pars varje XAML‑dokument som XML och inspektera dess filbaserade resursreferenser, såsom bild‑Source‑ eller ImageSource‑attribut. Lös varje relativ URI mot den omgivande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande dictionary‑nyckel, ZIP‑post eller lagrat objekt finns. Behandla externa URI:er och XAML‑markup‑uttryck separat från relativa filnamn.

Till exempel, om `pres/Slide_1.xaml` refererar till `images/image1.png`, måste den lagrade resursen finnas som `pres/images/image1.png`. Att endast behålla `image1.png` skulle bryta den relationen. För objektslagring, bevara samma struktur under jobb‑prefixet och gör dessa resurs‑URL:er tillgängliga för XAML‑konsumenten. Öppna det färdiga ZIP‑arkivet igen för att verifiera postnamn och resurs‑bytes, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löses korrekt.

## **FAQ**

**Hur kan jag säkerställa förutsägbara teckensnitt om originalteckensnittet inte finns på maskinen?**

Ange [DefaultRegularFont](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/defaultregularfont/) i [XamlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/) — det används som ett reservteckensnitt under export när originalet saknas. Detta garanterar inte att den genererade XAML‑referensen använder reservteckensnittet eller att teckensnittet finns på målmaskinen. Se till att de teckensnitt som XAML refererar till finns i den miljö där den visas.

**Är den exporterade XAML endast avsedd för WPF, eller kan den även användas i andra XAML‑stackar?**

Aspose.Slides exporterar WPF‑XAML via sitt publika API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [ExportHiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) i [XamlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.