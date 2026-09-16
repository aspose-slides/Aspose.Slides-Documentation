---
title: Presentaties exporteren naar XAML in .NET
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/net/export-to-xaml/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- PPT opslaan als XAML
- PPTX opslaan als XAML
- ODP opslaan als XAML
- PPT exporteren naar XAML
- PPTX exporteren naar XAML
- ODP exporteren naar XAML
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia’s naar XAML in .NET met Aspose.Slides — snelle, Office‑vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, toont hoe u een presentatie opslaat als XAML met de standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook enkele veelvoorkomende vragen over fallback‑lettertypen, XAML‑stack‑compatibiliteit en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een op XML gebaseerde opmaaktetaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visuele ontwerper of de markup rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende C#‑voorbeeld laat zien hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Standaard worden de geëxporteerde dia's opgeslagen in een submap `pres` van de huidige werkmap van het proces, zoals geretourneerd door [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). De map wordt automatisch aangemaakt en eventuele benodigde afbeeldingen worden daar ook opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bestandsnaam van de bron zonder extensie. Voor `pres.pptx` krijgen de uitvoerbestanden de namen `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs als u een absoluut pad opgeeft voor de invoerpresentatie, wordt de uitvoermap aangemaakt relatief ten opzichte van de huidige werkmap, niet naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de [IXamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/ixamloptions/)‑interface om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de uitvoer op een aangepaste locatie op te slaan, implementeert u [IXamlOutputSaver](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/ixamloutputsaver/) en kent u een instantie van uw implementatie toe aan de [OutputSaver](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/outputsaver/)‑eigenschap van [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/).

Om verborgen dia's op te nemen in de XAML‑uitvoer, stelt u de [ExportHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/)‑eigenschap in op `true`, zoals getoond in het volgende C#‑voorbeeld:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Alle gegenereerde XAML‑artifacts vastleggen**

Een XAML‑export kan een XAML‑document produceren voor elke geëxporteerde dia plus afzonderlijke afbeeldingen en ondersteunende bronnen. Ken een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/ixamloutputsaver/) toe aan [XamlOptions.OutputSaver](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/outputsaver/) om deze artifacts te ontvangen in plaats van de standaard bestands­systeem‑saver. Start de export met de XAML‑specifieke overload van [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) die XAML‑opties accepteert.

### **De levenscyclus van de callback begrijpen**

De exporter roept [IXamlOutputSaver.Save](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/ixamloutputsaver/save/) afzonderlijk aan voor elk gegenereerd artifact:

- `path` identificeert het artifact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML middelen kan refereren via relatieve paden.
- `data` bevat de bytes van het artifact. Afbeeldingen en andere binaire bronnen mogen niet als tekst worden gedecodeerd.
- De saver is verantwoordelijk voor het behouden of persistent maken van de data vóór terugkeer. De voorbeelden kopiëren elke byte‑array naar geheugen dat eigendom is van de applicatie.
- Beschouw de export als geslaagd alleen wanneer de presentatiesave‑operatie retourneert en elke callback met succes is afgerond. Slik geen opslag‑fouten in en start geen onwaargenomen achtergrondschrijvingen. Als persistatie later gebeurt, rapporteer dan pas succes nadat die stap ook geslaagd is.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) is ook van toepassing op een aangepaste saver. De standaardwaarde, `false`, sluit XAML‑documenten voor verborgen dia's uit. Door deze op `true` te zetten, worden ze en alle voor hun export benodigde bronnen opgenomen. Het aantal bronnen hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artifacts inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, verzamelt elk artifact in een [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) en geeft de naam, het type en het byte‑aantal weer. Het behoudt de opgegeven namen precies. Dubbele namen veroorzaken een fout bij de verzameling in plaats van stilzwijgend een artifact te overschrijven.

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

            // Decodeer alleen XAML, en alleen wanneer tekstuele inspectie nodig is.
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

Roep `InMemoryXamlExample.Run` aan vanuit uw applicatie. Extensietests zijn nuttig voor inspectie; bewaar alle artifacts, inclusief onbekende bron‑typen. Laat de bytes ongewijzigd wanneer u ze opslaat of verzendt. Gebruik [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) alleen voor XAML die tekstueel verwerkt moet worden.

### **Verzamelde artifacts in een ZIP‑archief verpakken**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen, en schrijft de oorspronkelijke bytes naar een ZIP‑archief. Een unieke archiefnaam scheidt gelijktijdige exporttaken. ZIP‑entries gebruiken schuine strepen en behouden relatieve mappen. Ongeldige namen of namen die na normalisatie conflicteren, worden afgewezen voordat het archief wordt geschreven.

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

        // De ZIP-directory is voltooid door de disposering voordat succes wordt gerapporteerd.
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

Roep `ZipXamlExample.Run` aan vanuit uw applicatie. Het voorbeeld gebruikt [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor opslag op afstand vervangt u de fase van archiefschrijven door uploads van de verzamelde byte‑arrays. Gebruik een export‑taak‑identifier plus de volledige relatieve artifact‑naam als blob‑sleutel, of bewaar de taak‑identifier, relatieve naam en binaire data in een database‑rij. Publiceer de taak pas nadat alle uploads voltooid zijn of de databasetransactie is gecommitteerd. Maak gedeeltelijke uitvoer schoon als persistatie mislukt.

Voor grote presentaties kan een aangepaste saver elk artifact direct naar de applicatieopslag schrijven om te voorkomen dat er een extra kopie van de volledige export in het geheugen van de applicatie wordt gehouden. De exporter blijft alle gegenereerde artifacts in het geheugen verzamelen voordat de saver wordt aangeroepen. Houd elke callback synchroon vanuit het perspectief van de exporter: retourneer pas nadat de bestemming de bytes heeft geaccepteerd, en laat fouten naar de aanroeper doordringen.

### **Bron‑namen behouden en referenties verifiëren**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dit vereist, maar behoud relatieve mappen. Gebruik niet alleen [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) tenzij elke gegenereerde naam gegarandeerd uniek is en bron‑referenties geldig blijven.
- Pas bestemming‑specifieke naambewaking toe. Bij het schrijven van losse bestanden, weiger absolute paden en traversalsegmenten, los de bestemming op met [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) en controleer dat deze zich onder de beoogde exportmap bevindt, inclusief het map‑scheidingsteken in de containment‑check. Gebruik een door de applicatie gecontroleerde map zonder symbolische koppelingen die schrijfacties kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace voor elke exporttaak. Detecteer conflicten na normalisatie van scheidingstekens en volgens de hoofdlettergevoeligheidsregels van de bestemming.
- Voordat u publiceert, parse elk XAML‑document als XML en inspecteer de bestands‑gebaseerde bron‑referenties, zoals `Source`‑ of `ImageSource`‑attributen van afbeeldingen. Los elk relatief URI‑adres op tegen de map van het betreffende XAML‑artifact, normaliseer de resulterende opslagnaam, en bevestig dat de corresponderende dictionary‑sleutel, ZIP‑entry of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` refereert aan `images/image1.png`, moet de opgeslagen bron beschikbaar zijn als `pres/images/image1.png`. Alleen `image1.png` bewaren zou die relatie verbreken. Bij objectopslag behoudt u dezelfde hiërarchie onder de taak‑prefix en maakt u die bron‑URL’s toegankelijk voor de XAML‑consument. Open het voltooide ZIP‑archief opnieuw om de entry‑namen en bron‑bytes te verifiëren, en laad representatieve dia’s in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgelost.

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen wanneer het oorspronkelijke lettertype niet beschikbaar is op de machine?**

Stel [DefaultRegularFont](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/defaultregularfont/) in bij [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het origineel ontbreekt. Dit garandeert niet dat de gegenereerde XAML het fallback‑lettertype referereert of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de door de XAML gerefereerde lettertypen aanwezig zijn in de omgeving waarin ze worden weergegeven.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

Aspose.Slides exporteert WPF‑XAML via zijn openbare API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, wordt niet gegarandeerd. Test de gegenereerde markup in uw doelformaat.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [ExportHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/) — houd het uitgeschakeld als u ze niet wilt exporteren.