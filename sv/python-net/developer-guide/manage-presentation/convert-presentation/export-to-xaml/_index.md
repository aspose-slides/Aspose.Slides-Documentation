---
title: Exportera presentationer till XAML med Python
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML med Python och Aspose.Slides — en snabb, Office-fri lösning som behåller din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint‑presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservfonter, XAML‑stack‑kompatibilitet och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk som WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markeringarna direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande Python‑exempel visar hur du exporterar en presentation till XAML med standardinställningar:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XtraOptions()
    presentation.save(xaml_options)
```

Som standard sparas de exporterade bilderna i en `pres`‑undermapp i processens aktuella arbetskatalog, som returneras av [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Mappen skapas automatiskt och eventuella nödvändiga bilder sparas där också.

Utdatamappens namn tas från källfilens namn utan filändelse. För `pres.pptx` får utdatafilnamnen `pres/Slide_1.xaml`, `pres/Slide_2.xaml` och så vidare. Även om du anger en absolut sökväg till inmatningspresentationen skapas utdatamappen relativt till den aktuella arbetskatalogen, inte bredvid indatafilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd klassen [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att inkludera dolda bilder i XAML‑utdata, sätt egenskapen [export_hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) till `True`, som visas i följande Python‑exempel:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Fånga alla genererade XAML‑artefakter**

En XAML‑export kan producera ett XAML‑dokument för varje exporterad bild samt separata bilder och stödresurser. Behåll alla dessa filer när du lagrar eller överför en export.

Exemplen nedan använder den standardfil‑system‑spararen i en temporär katalog och samlar sedan de genererade filerna.

### **Förstå exportlivscykeln**

- Starta exporten med den XAML‑specifika [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/)‑överladdningen som accepterar XAML‑alternativ. Läs de genererade filerna först när den har returnerat utan fel.
- Bevara varje artefakts relativa sökväg eftersom XAML kan referera resurser med relativa vägar.
- Läs artefakter som byte‑sekvenser. Bilder och andra binära resurser får inte avkodas som text.
- Rapportera totalt resultat först när insamling och eventuell efterföljande lagringsoperation är klar. Låt lagringsfel nå anroparen och rensa partiell utdata om beståndigheten misslyckas.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) är `False` som standard, vilket utesluter XAML‑dokument för dolda bilder. Om du sätter den till `True` inkluderas de samt alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en fil per bild.

{{% alert color="warning" title="Warning" %}}
Exemplen ändrar tillfälligt processens aktuella arbetskatalog, vilket påverkar alla trådar. Kör varje export i en dedikerad arbetsprocess, eller säkerställ att inget annat arbete i processen är beroende av den aktuella katalogen under exporten. En unik temporär katalog ensam gör inte parallella exporter i samma process säkra.
{{% /alert %}}

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel läser in `pres.pptx`, exporterar den till en temporär katalog, samlar varje artefakt i en ordbok med relativa namn och byte‑sekvenser, och skriver ut namn, typ samt byte‑antal. Det bevarar den genererade katalogstrukturen och tar bort de temporära filerna efter insamling. Indatasökvägen löses innan arbetskatalogen ändras.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Dekoda endast XAML, och endast när textuell inspektion behövs.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Filändelsekontroller är användbara för inspektion; behåll alla artefakter, även okända resurs­typer. Lämna byte‑sekvenserna oförändrade när du lagrar eller överför dem. Avkoda bara XAML som kräver textuell behandling. Detta tillvägagångssätt använder både temporärt diskutrymme och minne för den insamlade exporten.

### **Paketera insamlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar dess namn och skriver de ursprungliga byte‑sekvenserna till ett ZIP‑arkiv. Ett unikt arkivnamn skiljer exportjobb åt. ZIP‑poster använder framåtsnedstreck och behåller relativa mappar. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ZIP-katalogen har slutförts innan framgång rapporteras.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Exemplet använder [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) för att skriva ett lokalt arkiv efter att den temporära exporten samlats. För fjärrlagring ersätter du steget för att skriva arkivet med uppladdning av de insamlade byte‑sekvenserna. Använd ett export‑job‑identifierare plus det fullständiga relativa artefaktnamnet som objekt‑nyckel, eller lagra job‑identifieraren, relativa namn och binärdata i en databasrad. Publicera jobbet först när alla uppladdningar är klara eller databastransaktionen har begåtts. Rensa partiell utdata om beståndigheten misslyckas.

För stora presentationer, bearbeta de temporära filerna en åt gången efter exporten istället för att samla alla deras byte‑sekvenser i en ordbok. Detta undviker en extra kopia av hela exporten i minnet, men eliminerar inte exportörens egna minnesbehov.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa mappar. Behåll inte bara filnamnet om inte varje genererat namn är garanterat unikt och resurssreferenserna förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. När du skriver lösa filer, avvisa absoluta sökvägar och traversalsegment, lös destinationen och verifiera att den förblir under den avsedda exportkatalogen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd ett separat lagrings‑namnutrymme för varje exportjobb. Detektera kollisioner efter separator‑normalisering och enligt destinationens känslighet för skiftläge.
- Innan publicering, pars varje XAML‑dokument som XML och inspektera dess filbaserade ressursreferenser, såsom bild‑`Source` eller `ImageSource`‑attribut. Lös varje relativ URI mot den omgivande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande nyckel i ordboken, ZIP‑post eller lagrat objekt finns. Behandla externa URI:er och XAML‑uttryck separat från relativa filnamn.

Till exempel, om `pres/Slide_1.xaml` refererar `images/image1.png` måste den lagrade resursen finnas som `pres/images/image1.png`. Att bara behålla `image1.png` skulle bryta den relationen. För objektslagring, bevara samma layout under jobb‑prefixet och gör dessa resurs‑URL:er åtkomliga för XAML‑konsumenten. Återöppna det färdiga ZIP‑arkivet för att verifiera postnamn och resurs‑byte‑sekvenser, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löser korrekt.

## **FAQ**

**Hur kan jag säkerställa förutsägbara teckensnitt om det ursprungliga teckensnittet inte finns på maskinen?**

Ställ in [default_regular_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) i [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/) — det används som reservteckensnitt under exporten när originalet saknas. Detta garanterar inte att den genererade XAML‑referensen använder reservteckensnittet eller att teckensnittet finns på målmaskinen. Säkerställ att de teckensnitt som XAML refererar till finns i den miljö där den visas.

**Är den exporterade XAML‑en avsedd endast för WPF, eller kan den även användas i andra XAML‑stackar?**

Aspose.Slides exporterar WPF‑XAML via sitt offentliga API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markeringen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [export_hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) i [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.