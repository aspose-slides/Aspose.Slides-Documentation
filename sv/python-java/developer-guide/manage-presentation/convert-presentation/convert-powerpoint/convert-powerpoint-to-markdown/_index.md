---
title: Konvertera PowerPoint-presentationer till Markdown i Python via Java
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/python-java/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till MD
- presentation till MD
- bild till MD
- PPT till MD
- PPTX till MD
- spara PowerPoint som Markdown
- spara presentation som Markdown
- spara bild som Markdown
- spara PPT som MD
- spara PPTX som MD
- exportera PPT till MD
- exportera PPTX till MD
- Markdown bildexport
- CDN bildlänkar
- PowerPoint
- presentation
- Markdown
- Python
- Java
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i Python via Java och kontrollera var exporterade bitmap-, metafil- och SVG-bilder sparas och refereras."
---
## **Översikt**

Aspose.Slides for Python via Java kan konvertera PPT‑ och PPTX‑presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigrering och versionskontrollarbetsflöden. Du kan välja en Markdown‑variant, kontrollera hur bildinnehåll renderas och bestämma var exporterade bilder sparas samt hur den genererade Markdown‑referenserna hänvisar till dem.

Som standard använder Markdown‑export endast textutdata. För att exportera visuellt innehåll, sätt exporttypen med metoden [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setExportType) till `Sequential` eller `Visual`‑värdet från enumerationen [MarkdownExportType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownexporttype/). `Sequential` renderar bildobjekt separat och i ordning, medan `Visual` behåller grupperade objekt tillsammans för att bevara deras visuella relation. `TextOnly`‑värdet genererar inga bildresurser, så bild‑sparnings‑callback‑funktionerna anropas inte i det läget.

## **Konvertera en presentation till Markdown**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och anropa sedan metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med värdet `Md` från enumerationen [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Varje exempel läser `presentation.pptx` från den aktuella arbetskatalogen. Installera Aspose.Slides for Python via Java och en kompatibel Java‑runtime innan du kör exemplen. Starta JVM en gång per Python‑process.

## **Välj en Markdown‑variant**

Metoden [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setFlavor) styr vilken Markdown‑specifikation som används för utdata. Enumerationen [Flavor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödda varianter.

Följande exempel exporterar en presentation som CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Exportera bilder med standardbeteendet för lokalt sparande**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/) erbjuder två metoder för att konfigurera lokalt sparade bilder:

- [setBasePath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setBasePath) anger baskatalogen för Markdown‑dokumentet och dess resurser.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) anger bildundermappen. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Detta beteende fungerar även som reserv när en anpassad bild‑sparnings‑handler returnerar `False`.

## **Anpassa bildsparning och Markdown‑länkar**

Använd metoden [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/) för att registrera en callback för icke‑SVG‑bitmap‑ och metafilresurser som genereras under Markdown‑export. Dess `MarkdownImageSavingHandler`‑callback tar emot bildobjektet, dess [ImageFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/)‑värde och den genererade Markdown‑länken som ett endimensionellt `String[]`‑parameter. Spara eller ladda upp bilden med det angivna formatet och ersätt `link[0]` med den referens som ska visas i Markdown‑utdata.

Resurser som genereras i SVG-format hanteras separat. Registrera en callback med metoden [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/). Dess `MarkdownSvgImageSavingHandler`‑callback tar emot ett [SvgImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/)‑objekt och det endimensionella `String[] link`‑parametern. En SVG har inget `ImageFormat`‑argument; skriv eller ladda upp dess XML‑data via metoden [SvgImage.getSvgData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/#getSvgData) istället. Beroende på exportläget och visuell gruppering kan en SVG i källpresentationen rasteriseras eller kombineras med annat innehåll; den resulterande icke‑SVG‑resursen skickas sedan till bild‑sparnings‑callbacken. Registrera båda callbacks när varje exporterad visuell resurs kräver anpassad bearbetning.

Callback‑värdet bestämmer vem som bearbetar bilden:

- Returnera `True` efter att callbacken har sparat, laddat upp, transformerat eller på annat sätt bearbetat bilden och tilldelat ett giltigt värde till `link[0]`. Aspose.Slides skriver det värdet till Markdown‑dokumentet och utför inte den standardmässiga lokala sparningen.
- Returnera `False` för att låta Aspose.Slides spara bilden lokalt och generera dess länk enligt de värden som satts med [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setBasePath) och [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}
En handler som returnerar `True` tar ansvar för bilden. Om den returnerar `True` utan att tilldela en giltig, icke‑tom länk, misslyckas exporten med ett `InvalidOperationException`.
{{% /alert %}}

I Python registreras dessa callbacks med `jpype.JProxy` genom att implementera Java‑callback‑gränssnittet via dess `invoke`‑metod. `link`‑argumentet är en muterbar Java‑strängarray: konvertera `link[0]` till en Python‑sträng innan du bearbetar den, och tilldela sedan den ersättande URL‑en tillbaka till `link[0]`.

### **Spara bilder till en CDN‑ursprungs‑katalog och använd externa URL‑er**

Följande exempel behandlar `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad CDN‑ursprungs‑katalog. Varje handler extraherar det genererade filnamnet, sparar bilden i den anpassade katalogen och ersätter den genererade lokala referensen med en offentlig CDN‑URL. Exemplet utför ingen nätverksuppladdning: URL‑en blir giltig först när katalogen är monterad som CDN‑ursprung eller dess filer har publicerats till CDN. För objektlagring, ersätt fil‑system‑skrivningen med lagrings‑SDK:ns uppladdnings‑operation och tilldela `link[0]` först efter att uppladdningen lyckats.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Bitmap‑handlaren returnerar medvetet `False` för bilder mindre än 128 × 128 pixlar, så Aspose.Slides sparar dessa bilder till `output/fallback-images` med standardbeteendet. Större bitmap‑ och metafilresurser, liksom SVG‑resurser, hanteras av den anpassade koden. Till exempel blir en genererad lokal referens som `fallback-images/image1.png` till `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlarna använder operativsystemets sökvägar endast när filer skrivs; länkar som skrivs till Markdown använder snedstreck och URL‑kodade filnamn. Applicera samma regel när du bygger relativa länkar: använd `/`, inte plattforms‑specifika katalogseparatorn.

## **Vanliga frågor**

**Kan en handler bearbeta både rasterbilder och SVG‑bilder?**

Nej. Använd [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/) för emitterade bitmap‑ och metafilresurser och [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/) för resurser som emitteras som SVG. Den förra tillhandahåller ett bildobjekt och ett [ImageFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/)‑värde; den senare tillhandahåller ett [SvgImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/)‑objekt vars SVG‑data kan läsas med [SvgImage.getSvgData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/#getSvgData). En käll‑SVG som rasteriseras under export bearbetas av bild‑sparnings‑callbacken istället.

**Vad händer när en bild‑sparnings‑handler returnerar `False`?**

Aspose.Slides använder sitt standard‑lokala sparbeteende. Bildens plats och den genererade referensen styrs av de värden som satts med [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setBasePath) och [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Kan en handler tillhandahålla en URL utan att spara bilden lokalt?**

Ja. Handlaren kan ladda upp bilden till objektlagring eller vidarebefordra den till en annan tjänst, tilldela den resulterande URL‑en till `link[0]` och returnera `True`. Handlaren måste slutföra bearbetningen själv; att returnera `True` förhindrar den standardmässiga lokala sparningen.

**Varför kastar Markdown‑export ett `InvalidOperationException` från en handler?**

Detta undantag uppstår när handlern returnerar `True` men inte tillhandahåller en giltig länk. Tilldela den relativa sökvägen eller externa URL‑en som ska skrivas till Markdown innan du returnerar `True`.

**Vilken sökvägsseparator bör bild‑länkar använda?**

Använd snedstreck (`/`) i Markdown‑länkar och URL‑er. Använd `pathlib.Path` endast för fil‑system‑sökvägar och bygg eller normalisera sedan Markdown‑referensen separat.

**Behålls hyperlänkar under Markdown‑export?**

Ja. Text‑[hyperlinks](/slides/sv/python-java/manage-hyperlinks/) bevaras som standard Markdown‑länkar. Bild‑[transitions](/slides/sv/python-java/slide-transition/) och [animations](/slides/sv/python-java/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**

Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑instans mellan trådar. Följ [multithreading guidelines](/slides/sv/python-java/multithreading/) och använd en separat instans för varje fil.