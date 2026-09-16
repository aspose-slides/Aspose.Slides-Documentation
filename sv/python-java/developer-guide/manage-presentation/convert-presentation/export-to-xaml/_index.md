---
title: Exportera presentationer till XAML i Python via Java
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till XAML med Aspose.Slides för Python via Java. Använd standardalternativ eller inkludera dolda bilder."
---
## **Översikt**

Den här artikeln förklarar hur man exporterar PowerPoint-presentationer till XAML med Aspose.Slides för Python via Java. Den innehåller en kort introduktion till XAML, visar hur man sparar en presentation till XAML med standardinställningar och demonstrerar hur man anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservtypsnitt, XAML‑stack‑kompatibilitet och beteende för export av dolda bilder.

Exemplen kräver Aspose.Slides för Python via Java och en kompatibel Java‑runtime. Placera `pres.pptx` i den aktuella arbetskatalogen. Varje exempel startar JVM endast om den inte redan körs.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk som WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande Python‑exempel visar hur man exporterar en presentation till XAML med standardinställningar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Som standard sparas de exporterade bilderna i en `pres`‑undermapp i processens aktuella arbetskatalog. Mappen skapas automatiskt och alla nödvändiga bilder sparas där också.

Utdata‑mappnamnet tas från källfilens namn utan filändelse. För `pres.pptx` får utdatafilerna namn `pres/Slide_1.xaml`, `pres/Slide_2.xaml` och så vidare. Även om du anger en absolut sökväg till inmatningspresentationen skapas utdata‑mappen relativt till den aktuella arbetskatalogen, snarare än bredvid inmatningsfilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd klassen [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata till en anpassad plats, implementera `IXamlOutputSaver` och skicka en instans av din implementation till metoden [setOutputSaver](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setOutputSaver) i [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/).

För att inkludera dolda bilder i XAML‑utdata, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) med `True`, som visas i följande Python‑exempel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Fånga alla genererade XAML‑artefakter**

En XAML‑export kan producera ett XAML‑dokument för varje exporterad bild samt separata bilder och stödjande resurser. Tilldela en anpassad `IXamlOutputSaver` till [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setOutputSaver) för att ta emot dessa artefakter i stället för standard‑fil‑system‑spararen. Starta exporten med den XAML‑specifika [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) som accepterar XAML‑alternativ.

I Python, använd `jpype.JProxy` för att implementera Java‑gränssnittet `IXamlOutputSaver`. Konvertera återuppringnings‑sökvägen till `str` och kopiera Java‑byte‑arrayen till Python‑`bytes` innan du returnerar, som demonstrerat nedan.

### **Förstå återuppringnings‑livscykeln**

Exportören anropar `IXamlOutputSaver.save` separat för varje genererad artefakt:

- `path` identifierar artefakten och kan innehålla relativa kataloger. Behåll denna information eftersom XAML kan referera till resurser med relativa sökvägar.
- `data` innehåller artefaktens bytes. Bilder och andra binära resurser får inte avkodas som text.
- Spararen ansvarar för att behålla eller persistera data innan den returneras. Exemplen kopierar varje byte‑array till applikationsägd minne.
- Betrakta exporten som lyckad först när presentationens sparoperation returnerar och varje återuppringning har slutförts utan fel. Svälj inte lagringsfel eller påbörja osedda bakgrundsskrivningar. Om persisteringen sker efteråt, rapportera total framgång först när även detta steg lyckas.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) gäller också för en anpassad sparare. Standardvärdet, `False`, exkluderar XAML‑dokument för dolda bilder. Att skicka `True` inkluderar dem och alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en återuppringning per bild eller en fast återuppringningsordning.

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel laddar `pres.pptx`, samlar varje artefakt i en Python‑dictionary med namn och oföränderliga `bytes`‑värden, och skriver ut dess namn, typ och byte‑antal. Det behåller de angivna namnen exakt. Dubbla namn markerar samlingen som ogiltig i stället för att tyst skriva över en artefakt. Exemplet kontrollerar detta innan resultaten används.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Avkoda bara XAML, och endast när textuell inspektion behövs.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Filändelsekontroller är användbara för inspektion; behåll alla artefakter, inklusive okända resurstyp. Lämna bytes oförändrade vid lagring eller överföring. Använd `bytes.decode` med UTF-8 endast för XAML som behöver textuell behandling.

### **Paketera samlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytesen till ett ZIP‑arkiv. Ett unikt arkivnamn separerar samtidiga exportjobb. ZIP‑poster använder framåtsnedstreck och behåller relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Stänger och färdigställer ZIP-katalogen innan framgång rapporteras.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Exemplet använder Pythons `zipfile.ZipFile` för att skriva ett lokalt arkiv; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring, ersätt steg för att skriva arkivet med uppladdning av de insamlade byte‑arrayerna. Använd en export‑jobb‑identifierare plus det fullständiga relativa artefaktnamnet som ett blob‑nyckel, eller lagra jobb‑identifieraren, relativt namn och binärdata i en databasrad. Publicera jobbet först när alla uppladdningar är klara eller databastransaktionen har committats. Rensa partiell output om persisteringen misslyckas.

För stora presentationer kan en anpassad sparare persistera varje artefakt direkt till applikationslagring för att undvika att hålla en extra kopia av hela exporten i applikationsminnet. Behåll varje återuppringning synkron från exportörens perspektiv: returnera först när destinationen har accepterat bytesen, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsseparatorer när destinationen kräver det, men bevara relativa kataloger. Använd inte bara `pathlib.Path.name` såvida inte varje genererat namn är känt att vara unikt och resursreferenser förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. När du skriver lösa filer, avvisa rotade sökvägar och träskelettssegment, lös destinationen med `pathlib.Path.resolve` och verifiera att den förblir under den avsedda exportkatalogen, inklusive katalogseparatorn i innehållskontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje exportjobb. Upptäck kollisioner efter separator‑normalisering och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, analysera varje XAML‑dokument som XML och inspektera dess filbaserade resursreferenser, såsom bild‑`Source` eller `ImageSource`‑attribut. Lös varje relativ URI mot den innehållande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande nyckel i mappen, ZIP‑post eller lagrat objekt finns. Behandla externa URI:er och XAML‑markup‑uttryck separat från relativa filnamn.

Till exempel, om `pres/Slide_1.xaml` refererar till `images/image1.png`, måste den lagrade resursen vara tillgänglig som `pres/images/image1.png`. Att bara behålla `image1.png` skulle bryta den relationen. För objektlagring, bevara samma layout under jobb‑prefixet och göra dessa resurs‑URL:er tillgängliga för XAML‑konsumenten. Återöppna det färdiga ZIP‑et för att verifiera postnamn och resurs‑bytes, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löser korrekt.

## **Vanliga frågor**

**Hur kan jag säkerställa förutsägbara typsnitt om det ursprungliga typsnittet inte är tillgängligt på datorn?**

Anropa [setDefaultRegularFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/) — den används som reservtypsnitt under export när originalet saknas. Detta garanterar inte att den genererade XAML:en refererar till reservtypsnittet eller att typsnittet är tillgängligt på målmaskinen. Säkerställ att de typsnitt som XAML refererar till finns i den miljö där den visas.

**Är den exporterade XAML:en avsedd endast för WPF, eller kan den användas i andra XAML‑stackar också?**

Aspose.Slides exporterar WPF‑XAML via sitt offentliga API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) i [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.