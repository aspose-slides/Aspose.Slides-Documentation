---
title: Export prezentací do HTML s externě odkazovanými obrázky
type: docs
weight: 100
url: /cs/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- exportovat snímek
- exportovat PPT
- exportovat PPTX
- exportovat ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- odkazovaný obrázek
- externě odkazovaný obrázek
- odkazovaný zdroj
- externí zdroj
- Python
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v Pythonu pomocí Aspose.Slides s obrázky a dalšími zdroji uloženými jako externí odkazované soubory."
---
## **Přehled**

Ve výchozím nastavení exportuje Aspose.Slides prezentaci do samostatného HTML souboru. Obrázky a další zdroje jsou zapisovány přímo do HTML, obvykle jako data Base64. To je pohodlné, když potřebujete jeden přenosný soubor, ale není to vždy nejlepší formát pro webové stránky, CMS nebo serverovou konverzní pipeline.

Použijte externě odkazované zdroje, pokud chcete:
- zmenšit velikost HTML dokumentu;
- cachovat obrázky, fonty, audio nebo video samostatně v prohlížeči nebo CDN;
- prozkoumat, nahradit, komprimovat nebo následně zpracovat vygenerované zdroje po exportu;
- udržet strukturu výstupu blíže tomu, co očekává webová aplikace.

Pro obecný průběh konverze HTML viz [Convert PowerPoint Presentations to HTML](/slides/cs/python-java/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu týkající se propojování zdrojů.

## **Jak funguje export s odkazovanými zdroji**

`ILinkEmbedController` umožňuje vaší aplikaci rozhodnout, zdroj po zdroji, zda exportér vloží data do HTML nebo je uloží externě a zapíše odkaz.

Rozhraní má tři metody:
- `ILinkEmbedController.getObjectStoringLocation` rozhoduje, zda by měl být zdroj odkazován nebo vložen.
- `ILinkEmbedController.getUrl` vrací URL, která bude zapsána do vygenerovaného HTML nebo do jiného odkazovaného zdroje.
- `ILinkEmbedController.saveExternal` zapisuje data odkazovaného zdroje na disk nebo do jiného úložného cíle.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený příklad zapisuje soubory zdrojů do `html-output/assets` na disku, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč tato URL řeší relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na SVG soubor používá `assets/resource-1.svg`, zatímco odkaz z toho SVG souboru na obrázek uložený ve stejném adresáři `assets` používá `resource-4.jpg`.

## **Export HTML s odkazovanými zdroji**

Následující příklad v Pythonu vytvoří výstupní adresář, uloží tam HTML soubor a uloží odkazované zdroje do podadresáře `assets`. Řadič propojává běžné obrázky, fonty, audio, video a CSS zdroje, pokud Aspose.Slides poskytuje nebo dokáže odvodit bezpečnou příponu souboru. Zdroje, které nejsou rozpoznány, zůstávají vložené.

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

Po exportu má výstupní složka tuto strukturu:

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

Přesné soubory závisí na obsahu prezentace a nastaveních exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný obrazový kodek než ten použitý ve zdrojové prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Výběr URL pro nasazení**

Ukázka používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřen z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden odkazovaný zdroj odkazuje na jiný odkazovaný zdroj, ukázka používá parametr `referrer` v `ILinkEmbedController.getUrl` a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba ve složce `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, ne na `assets/resource-4.jpg`.

Použijte jinou předponu URL, pokud jsou soubory nasazeny jinde:
- Použijte `assets/`, když je adresář s prostředky vedle HTML souboru.
- Použijte `../assets/`, když je adresář s prostředky o úroveň výš než HTML soubor.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, když jsou soubory nahrány na CDN nebo na statický souborový server.

URL vrácená metodou `ILinkEmbedController.getUrl` musí odpovídat konečné nasazené lokaci souboru zapsaného metodou `ILinkEmbedController.saveExternal`. V serverových aplikacích použijte jedinečný výstupní adresář nebo předponu objektového úložiště pro každou konverzní úlohu, aby nedošlo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když výstup musí být jediný soubor, například e‑mailová příloha, offline náhled nebo dokument, který bude přesunut bez přidružené složky s prostředky. Odkazované zdroje jsou vhodnější, když bude HTML podávána webovou aplikací, uložena v CMS, optimalizována build pipeline nebo cachována prohlížeči nezávisle na HTML.

## **Často kladené otázky**

**Mohu externalizovat jen obrázky a nechat ostatní zdroje vložené?**

Ano. V metodě `ILinkEmbedController.getObjectStoringLocation` vraťte [LinkEmbedDecision.Link](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linkembeddecision/#Link) pouze pro typy obsahu, které chcete uložit jako samostatné soubory, a pro ostatní vraťte [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linkembeddecision/#Embed).

**Proč se přípona exportovaného obrázku liší od původní prezentace?**

Aspose.Slides může během HTML exportu překódovat rastrové obrázky, aby zlepšil velikost nebo kompatibilitu s prohlížeči. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG v závislosti na výsledném vykreslení.

**Fungují relativní URL po přesunu HTML souboru?**

Relativní URL fungují pouze při zachování stejné relativní struktury složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle HTML souboru, pokud nevytvoříte jinou předponu URL.

**Měly by serverové aplikace znovu používat stejný výstupní adresář?**

Ne. Použijte jedinečný výstupní adresář nebo předponu úložiště pro každou konverzní úlohu. To zabraňuje kolizím názvů souborů a přepisování zdrojů jedním exportem jiným exportem.