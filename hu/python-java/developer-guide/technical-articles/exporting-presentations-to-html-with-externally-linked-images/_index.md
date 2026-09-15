---
title: "Prezentációk exportálása HTML-re külsőleg hivatkozott képekkel"
type: docs
weight: 100
url: /hu/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- "PowerPoint exportálása"
- "OpenDocument exportálása"
- "prezentáció exportálása"
- "dia exportálása"
- "PPT exportálása"
- "PPTX exportálása"
- "ODP exportálása"
- "PowerPoint HTML-re"
- "OpenDocument HTML-re"
- "prezentáció HTML-re"
- "dia HTML-re"
- "PPT HTML-re"
- "PPTX HTML-re"
- "ODP HTML-re"
- "hivatkozott kép"
- "külsőleg hivatkozott kép"
- "hivatkozott erőforrás"
- "külső erőforrás"
- "Python"
- "Java"
- "Aspose.Slides"
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-re Pythonban az Aspose.Slides használatával, a képek és egyéb erőforrások külső hivatkozott fájlokként mentve."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML‑fájlba exportál. A képeket és egyéb erőforrásokat közvetlenül a HTML‑be írja, általában Base64 adatként. Ez kényelmes, ha egy hordozható fájlra van szükség, de nem mindig a legjobb formátum egy weboldal, CMS vagy szerveroldali konverziós csővezeték számára.

Külsőleg hivatkozott erőforrásokat használjon, ha:

- csökkenteni szeretné a HTML‑dokumentum méretét;
- a böngészőben vagy CDN‑ben külön szeretné gyorsítótárazni a képeket, betűkészleteket, hang- vagy videofájlokat;
- az export után vizsgálni, cserélni, tömöríteni vagy utófeldolgozni kívánja a generált erőforrásokat;
- a kimeneti szerkezetet közelebb szeretné hozni ahhoz, amit egy webalkalmazás elvár.

Az általános HTML‑konverziós munkafolyamatért lásd a [PowerPoint prezentációk konvertálása HTML-re](/slides/hu/python-java/convert-powerpoint-to-html/). Ez a cikk az export erőforrás‑hivatkozási részére fókuszál.

## **Hogyan működik a hivatkozott erőforrás exportálása**

`ILinkEmbedController` lehetővé teszi az alkalmazás számára, hogy erőforrásonként eldöntse, a exportáló beágyazza‑e az adatot a HTML‑be, vagy külsőleg elmenti és hivatkozást ír.

Az interfész három metódussal rendelkezik:

- `ILinkEmbedController.getObjectStoringLocation` dönti el, hogy egy erőforrás hivatkozott vagy beágyazott legyen.
- `ILinkEmbedController.getUrl` adja vissza a generált HTML‑be vagy egy másik hivatkozott erőforrásba írandó URL‑t.
- `ILinkEmbedController.saveExternal` írja a hivatkozott erőforrás adatait lemezre vagy egy másik tárolási célba.

A fájlrendszer‑útvonal és a böngésző‑URL külön kérdés. Például az alábbi minta az erőforrás‑fájlokat a `html-output/assets` könyvtárba írja lemezre, míg a HTML relatív URL‑kat tartalmaz, mint `assets/resource-1.svg`. A böngésző ezeket az URL‑kat a hivatkozást tartalmazó fájlhoz viszonyítva oldja fel. Ennek következtében a `presentation.html`‑ról egy SVG fájlra mutató hivatkozás `assets/resource-1.svg`, míg az SVG fájlból ugyanabba a `assets` mappába mentett képre mutató hivatkozás `resource-4.jpg`.

## **HTML exportálása hivatkozott erőforrásokkal**

Az alábbi Python‑példa létrehoz egy kimeneti könyvtárat, ott elmenti a HTML‑fájlt, és az `assets` almappában tárolja a hivatkozott erőforrásokat. A vezérlő a gyakori kép‑, betűkészlet‑, hang‑, video‑ és CSS‑erőforrásokra hivatkozik, ha az Aspose.Slides biztosít vagy képes következtetni egy biztonságos fájlkiterjesztésre. A nem felismert erőforrások továbbra is beágyazottak maradnak.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Az export után a kimeneti mappának a következő struktúrája lesz:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

A pontos fájlok a prezentáció tartalmától és az exportálási beállításoktól függenek. Például a raszteres képeket gyakran JPEG‑ként vagy PNG‑ként exportálja. Az Aspose.Slides egy másik képkódolót választhat, mint a forrás‑prezentációban használt, ha ez kisebb vagy alkalmasabb fájlt eredményez. Az átlátszóságot tartalmazó képeket PNG‑ként exportálja.

## **URL‑k kiválasztása a telepítéshez**

A minta relatív URL‑előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html`‑ből van megnyitva, a böngésző a `html-output/assets/resource-1.svg`‑t tölti be.

Amikor egy hivatkozott erőforrás egy másik hivatkozott erőforrásra hivatkozik, a minta a `referrer` paramétert használja az `ILinkEmbedController.getUrl`‑ban, és csak a fájlnevet adja vissza. Például ha a `resource-1.svg` és a `resource-4.jpg` is az `assets` mappában van, az SVG‑fájlnak `resource-4.jpg`‑re kell hivatkoznia, nem `assets/resource-4.jpg`‑re.

Használjon más URL‑előtagot, ha a fájlok máshol vannak telepítve:

- Használja az `assets/`‑t, ha az eszközkönyvtár a HTML‑fájl mellett helyezkedik el.
- Használja a `../assets/`‑t, ha az eszközkönyvtár egy szinttel feljebb van a HTML‑fájlnál.
- Használja a `https://cdn.example.com/presentations/job-123/assets/`‑t, ha a fájlok CDN‑re vagy statikus fájlszerverre vannak feltöltve.

Az `ILinkEmbedController.getUrl` által visszaadott URL‑nek meg kell egyeznie az `ILinkEmbedController.saveExternal` által írt fájl végleges telepítési helyével. Szerveralkalmazásokban használjon egyedi kimeneti könyvtárat vagy objektumtároló‑előtagot minden konverziós feladathoz, hogy elkerülje más exportok fájljainak felülírását.

## **Mikor érdemes beágyazni helyette**

A beágyazott Base64 HTML továbbra is hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail‑csatolmányként, offline‑előnézetként vagy olyan dokumentumként, amelyet egy támogató eszközkönyvtár nélkül fognak mozgatni. A hivatkozott erőforrások jobban illeszkednek, ha a HTML‑t egy webalkalmazás szolgálja ki, CMS‑ben tárolják, build‑csővezeték optimalizálja, vagy a böngészők függetlenül gyorsítótárazzák a HTML‑től.

## **GYIK**

**Kizárólag képeket kívánok externalizálni, a többi erőforrást pedig beágyazottan tartani?**

Igen. Az `ILinkEmbedController.getObjectStoringLocation`‑ban adja vissza a [LinkEmbedDecision.Link](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linkembeddecision/#Link) döntést csak azokhoz a tartalomtípusokhoz, amelyeket külön fájlokként szeretne menteni, a többit pedig a [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linkembeddecision/#Embed) döntéssel kezelje.

**Miért tér el az exportált kép kiterjesztése a forrás‑prezentációétól?**

Az Aspose.Slides a HTML exportálása során újrakódolhatja a raszteres képeket a méret vagy a böngésző‑kompatibilitás javítása érdekében. Például egy forrásfájlból származó kép JPEG‑ként vagy PNG‑ként íródhat, a megjelenített eredménytől függően.

**Működnek a relatív URL‑k, ha áthelyezem a HTML‑fájlt?**

A relatív URL‑k csak akkor működnek, ha a relatív mappaszerkezet megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` mappának a HTML‑fájl mellett kell maradnia, hacsak nem generál más URL‑előtagot.

**A szerveralkalmazások újra felhasználhatják ugyanazt a kimeneti mappát?**

Nem. Minden konverziós feladathoz használjon egyedi kimeneti könyvtárat vagy tárolási előtagot. Ez megakadályozza a fájlnév‑ütközéseket és azt, hogy egy export felülírja egy másik export által generált erőforrásokat.