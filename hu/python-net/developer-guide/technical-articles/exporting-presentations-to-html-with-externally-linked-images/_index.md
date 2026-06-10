---
title: Prezentációk exportálása HTML-be külsőleg hivatkozott képekkel Pythonban
linktitle: Prezentációk exportálása HTML-be külsőleg hivatkozott képekkel
type: docs
weight: 100
url: /hu/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- dia exportálása
- PPT exportálása
- PPTX exportálása
- ODP exportálása
- PowerPoint HTML-re
- OpenDocument HTML-re
- prezentáció HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- ODP HTML-re
- hivatkozott kép
- külsőleg hivatkozott kép
- hivatkozott erőforrás
- külső erőforrás
- Python
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-be Pythonban az Aspose.Slides használatával, a képek külsőleg hivatkozott fájlokként mentve."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy előadást önálló HTML-fájlba exportál. A képek és egyéb erőforrások közvetlenül a HTML-be kerülnek, általában Base64 adatként. Ez akkor kényelmes, ha egy hordozható fájlra van szükség, de nem mindig a legjobb formátum egy weboldal, egy CMS vagy egy szerveroldali konverziós folyamat számára.

Külső hivatkozású képeket használjon, ha a következőkre van szükség:

- a HTML-dokumentum méretének csökkentése;
- a képek külön tárolása a böngészőben vagy CDN‑en;
- a generált képek ellenőrzése, cseréje, tömörítése vagy utófeldolgozása export után;
- a kimeneti struktúra közelebb hozása ahhoz, amit egy webalkalmazás elvár.

Az általános HTML‑konverziós munkafolyamat leírását lásd a [PowerPoint előadáskonvertálás HTML-re](/slides/hu/python-net/convert-powerpoint-to-html/). Ez a cikk az export kép‑hivatkozási részére fókuszál.

## **A linkelt kép exportálásának működése**

.NET‑ben és Javaban az [ILinkEmbedController](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/ilinkembedcontroller/) képviseli azt a visszahívási felületet, amelyet az exportáló használ annak eldöntésére, hogy egy erőforrást be kell-e ágyazni vagy hivatkozni kell rá. Python‑ban .NET‑en keresztül a Python‑osztályok jelenleg nem tudják közvetlenül megvalósítani ezt a .NET visszahívási felületet, így a gyakorlati munkafolyamat a következő:

1. Exportálja az előadást HTML‑be a [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) használatával.
2. Használja a [SlideImageFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/slideimageformat/)‑t a [SVGOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/)‑szel, hogy a diák SVG‑ként legyenek ábrázolva a HTML‑ben.
3. Mozgassa át a Base64 képadatokat a HTML `data:` URL‑ekből külön fájlokba.
4. Cserélje le az eredeti `data:` URL‑eket relatív hivatkozásokra, például `assets/resource-1.jpg`.

A fájlrendszer‑útvonal és a böngésző‑URL külön kérdés. Például az alábbi minta képfájlokat a `html-output/assets` könyvtárba írja a lemezen, míg a HTML relatív URL‑eket tartalmaz, például `assets/resource-1.jpg`. A böngésző ezeket az URL‑eket a linket tartalmazó HTML‑fájlhoz relatívan oldja fel.

## **HTML exportálása linkelt képekkel**

Az alábbi Python‑példa létrehoz egy kimeneti könyvtárat, elmenti a HTML‑fájlt oda, a kinyert képeket egy `assets` alkönyvtárba helyezi, és a Base64 kép‑URL‑eket relatív hivatkozásokra cseréli. A példa a gyakori Base64 képformátumokat extrahálja, ha az Aspose.Slides biztonságos fájlkiterjesztést tud biztosítani. Az ismeretlen adat‑URL‑ek továbbra is beágyazottak maradnak.

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

Az exportálás után a kimeneti mappának a következő szerkezete lehet:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

A pontos fájlok a bemutató tartalmától és az exportálási beállításoktól függenek. Például a raszteres képeket általában JPEG‑ként vagy PNG‑ként exportálják. Az Aspose.Slides egy másik kép‑kodeket is választhat, ha az kisebb vagy megfelelőbb fájlt eredményez, mint a forrás‑prezentációban szereplő. Az átlátszóságot igénylő képeket PNG‑ként exportálja.

## **URL‑k kiválasztása a telepítéshez**

A minta relatív URL‑előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html`‑ből van megnyitva, a böngésző a `html-output/assets/resource-1.jpg`‑t tölti be.

Használjon másik eszközkönyvtár‑nevet vagy írja át a generált hivatkozásokat, ha a fájlok máshol kerülnek telepítésre:

- Használja a `assets/`‑t, ha az eszközkönyvtár a HTML‑fájl mellett helyezkedik el.
- Használja a `../assets/`‑t, ha az eszközkönyvtár egy szinttel a HTML‑fájl fölött található.
- Használja a `https://cdn.example.com/presentations/job-123/assets/`‑t, ha a fájlok CDN‑re vagy statikus fájlszerverre lettek feltöltve.

Szerveralkalmazásokban használjon egyedi kimeneti könyvtárat vagy objektumtároló‑előtagot minden konverziós feladathoz, hogy elkerülje más exportálás által létrehozott fájlok felülírását.

## **Mikor érdemes beágyazni helyette**

A beágyazott Base64 HTML továbbra is hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail‑melléklet, offline előnézet vagy egy olyan dokumentum esetén, amelyet egy támogató eszközkönyvtár nélkül mozgatnak. A linkelt képek jobb megoldást jelentenek, ha a HTML‑t webalkalmazás szolgálja ki, CMS‑ben tárolják, egy build‑csővezeték optimalizálja, vagy a böngészők a HTML‑től függetlenül gyorsítótárazzák.

## **GYIK**

**Kizárólag a képeket kívánom külsővé tenni, a többi erőforrást beágyazva hagyni?**

Igen. A minta csak a `image/*` Base64 adat‑URL‑eket extrahálja, amelyek tartalomtípusai szerepelnek az `EXTENSIONS_BY_CONTENT_TYPE`‑ben. A többi adat‑URL továbbra is beágyazott marad.

**Miért tér el az exportált kép kiterjesztése a forrás‑prezentációétól?**

Az Aspose.Slides a HTML exportálás során újrakódolhatja a raszteres képeket a méret vagy a böngésző‑kompatibilitás javítása érdekében. Például egy forrás‑fájlban található kép JPEG‑ként vagy PNG‑ként íródhat, a megjelenített eredménytől függően.

**Működnek a relatív URL‑ek, ha áthelyezem a HTML‑fájlt?**

A relatív URL‑ek csak akkor működnek, ha a ugyanaz a relatív mappastruktúra megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` könyvtárnak a HTML‑fájl mellett kell maradnia, hacsak nem generál másik URL‑előtagot.

**A szerveralkalmazások újrahasználhatják ugyanazt a kimeneti mappát?**

Nem. Használjon egyedi kimeneti könyvtárat vagy tároló‑előtagot minden konverziós feladathoz. Ez megakadályozza a fájlnév‑ütközéseket és azt, hogy egy export felülírja egy másik export által generált erőforrásokat.