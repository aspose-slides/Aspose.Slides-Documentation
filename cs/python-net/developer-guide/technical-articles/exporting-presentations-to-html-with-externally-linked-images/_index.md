---
title: "Exportovat prezentace do HTML s externě odkazovanými obrázky v Pythonu"
linktitle: "Export prezentací do HTML s externě odkazovanými obrázky"
type: docs
weight: 100
url: /cs/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
- export prezentace
- export snímku
- export PPT
- export PPTX
- export ODP
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
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v Pythonu pomocí Aspose.Slides s obrázky uloženými jako externě odkazované soubory."
---
## **Přehled**

Ve výchozím nastavení exportuje Aspose.Slides prezentaci do samostatného souboru HTML. Obrázky a další zdroje jsou zapisovány přímo do HTML, obvykle jako data Base64. To je výhodné, když potřebujete jeden přenosný soubor, ale není to vždy nejlepší formát pro webové stránky, CMS nebo serverový konverzní pipeline.

Používejte externě odkazované obrázky, když chcete:

- zmenšit velikost dokumentu HTML;
- cachovat obrázky samostatně v prohlížeči nebo CDN;
- prohlížet, nahrazovat, komprimovat nebo následně zpracovávat vygenerované obrázky po exportu;
- udržet strukturu výstupu blíže tomu, co očekává webová aplikace.

Pro obecný workflow konverze HTML viz [Převést prezentace PowerPoint do HTML](/slides/cs/python-net/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu související s prolinkováním obrázků.

## **Jak funguje export odkazovaných obrázků**

V .NET a Java představuje [ILinkEmbedController](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/ilinkembedcontroller/) rozhraní zpětného volání, které exportér používá k rozhodnutí, zda by měl být prostředek vložen nebo odkazován. V Pythonu přes .NET není zatím možné, aby třídy Pythonu přímo implementovaly toto .NET rozhraní zpětného volání, takže praktický workflow je:

1. Exportujte prezentaci do HTML pomocí [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/).
2. Použijte [SlideImageFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/slideimageformat/) s [SVGOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/), aby byly snímky v HTML reprezentovány jako SVG.
3. Přesuňte data obrázků Base64 z HTML `data:` URL do samostatných souborů.
4. Nahraďte původní `data:` URL relativními odkazy, např. `assets/resource-1.jpg`.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený příklad zapisuje soubory obrázků do `html-output/assets` na disku, zatímco HTML obsahuje relativní URL, jako je `assets/resource-1.jpg`. Prohlížeč tyto URL řeší relativně k souboru HTML, který odkaz obsahuje.

## **Export HTML s odkazovanými obrázky**

Následující příklad v Pythonu vytvoří výstupní adresář, uloží tam soubor HTML, uloží extrahované obrázky do podadresáře `assets` a přepíše URL obrázků Base64 na relativní odkazy. Příklad extrahuje běžné formáty obrázků Base64, pokud Aspose.Slides poskytuje bezpečnou příponu souboru. Data URL, které nejsou rozpoznány, zůstávají vložená.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Po exportu může mít výstupní složka tuto strukturu:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Přesné soubory závisí na obsahu prezentace a nastavení exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný kodek obrázku než ten použitý ve zdrojové prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Výběr URL pro nasazení**

Ukázka používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřen z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.jpg`.

Použijte jiný název asset adresáře nebo přepište vygenerované odkazy, pokud jsou soubory nasazeny jinde:

- Použijte `assets/`, když je asset adresář vedle souboru HTML.
- Použijte `../assets/`, když je asset adresář o jednu úroveň výše než soubor HTML.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, když jsou soubory nahrány na CDN nebo statický souborový server.

V serverových aplikacích použijte unikátní výstupní adresář nebo předponu v objektovém úložišti pro každou konverzní úlohu, aby nedocházelo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když výstup musí být jeden soubor, např. e‑mailová příloha, offline náhled nebo dokument, který bude přesunut bez doprovodné složky s assety. Odkazované obrázky jsou vhodnější, když bude HTML podáváno webovou aplikací, uloženo v CMS, optimalizováno build pipeline nebo cachováno prohlížeči nezávisle na HTML.

## **Často kladené otázky**

**Mohu externalizovat jen obrázky a nechat ostatní zdroje vložené?**

Ano. Ukázka extrahuje pouze `image/*` Base64 data URL, jejichž typy obsahu jsou uvedeny v `EXTENSIONS_BY_CONTENT_TYPE`. Ostatní data URL zůstávají vložená.

**Proč se přípona exportovaného obrázku liší od zdrojové prezentace?**

Aspose.Slides může při exportu HTML překódovat rastrové obrázky, aby zlepšil velikost nebo kompatibilitu s prohlížečem. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG v závislosti na výsledku renderování.

**Fungují relativní URL po přesunutí souboru HTML?**

Relativní URL fungují jen tehdy, když je zachována stejná relativní struktura složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle souboru HTML, pokud nevytvoříte jinou předponu URL.

**Měly by serverové aplikace znovu používat stejnou výstupní složku?**

Ne. Použijte unikátní výstupní adresář nebo předponu úložiště pro každou konverzní úlohu. Tím se předejde kolizím názvů souborů a zabrání se přepsání zdrojů jedním exportem jiným exportem.