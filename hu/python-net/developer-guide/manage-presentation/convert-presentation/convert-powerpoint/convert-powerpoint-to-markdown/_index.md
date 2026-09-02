---
title: PowerPoint prezentációk konvertálása Markdown-re Pythonban
linktitle: PowerPoint Markdown-re
type: docs
weight: 140
url: /hu/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD-re
- prezentáció MD-re
- dia MD-re
- PPT MD-re
- PPTX MD-re
- PowerPoint mentése Markdown formátumban
- prezentáció mentése Markdown formátumban
- dia mentése Markdown formátumban
- PPT mentése MD formátumba
- PPTX mentése MD formátumba
- PPT exportálása MD-be
- PPTX exportálása MD-be
- Markdown képexport
- CDN képhivatkozások
- PowerPoint
- prezentáció
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "PPT és PPTX prezentációk konvertálása Markdown-re Pythonban, valamint az exportált képek mentési helyének és a generált Markdown képhivatkozásainak vezérlése."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET képes PPT és PPTX prezentációkat Markdown formátumba konvertálni dokumentációs, statikus weboldali, tartalom-migrációs és verziókezelési munkafolyamatokhoz. Kiválaszthatja a Markdown változatot, szabályozhatja, hogyan jelenjen meg a diák tartalma, valamint eldöntheti, hol legyenek tárolva az exportált képek és hogyan hivatkozzon rájuk a generált Markdown.

Alapértelmezés szerint a Markdown export csak szöveges kimenetet használ. A vizuális tartalom exportálásához állítsa be a [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/export_type/) tulajdonságot a [MarkdownExportType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownexporttype/) felsoroló `SEQUENTIAL` vagy `VISUAL` értékére. A `SEQUENTIAL` külön-külön és sorrendben jeleníti meg a diák elemeit, míg a `VISUAL` csoportosítja őket a vizuális kapcsolat megőrzése érdekében. A `TEXT_ONLY` érték nem generál képernyőforrásokat.

## **Prezentáció konvertálása Markdown-be**

Töltsük be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztállyal, majd hívjuk meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipresentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) felsoroló `MD` értékével.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Markdown változat kiválasztása**

A [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/flavor/) tulajdonság határozza meg, hogy melyik Markdown specifikációt használja a kimenet. A [Flavor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/flavor/) felsoroló tartalmazza a CommonMark-ot, a GitHub Flavored Markdown-ot és más támogatott változatokat.

Az alábbi példa közös marként exportál egy prezentációt:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/) osztály két tulajdonságot biztosít a helyileg mentett képekhez:

- [base_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/base_path/) adja meg a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [images_save_folder_name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) adja meg a képek alkönyvtárát. Alapértelmezett értéke `Images`.

Az alábbi példa megjeleníti a vizuális tartalmat, a `output/assets` könyvtárba írja a képeket, és relatív képhivatkozásokat hoz létre a Markdown dokumentumban:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Az Aspose.Slides a képek alkönyvtárát automatikusan létrehozza, ha az export képernyőforrásokat generál, de a `base_path` könyvtárat a felhasználónak kell létrehozni a Markdown fájl mentése előtt.

## **Markdown és képek előkészítése közzétételhez**

Az Aspose.Slides for Python via .NET nem teszi elérhetővé a .NET képmentés visszahívásait az egyes generált képhivatkozások cseréjéhez az export során. Ehelyett exportálja a Markdown dokumentumot és a képek mappáját egy közzétételi könyvtárba, majd közzéteszi azt anélkül, hogy megváltoztatná a relatív struktúrát.

Az alábbi példa a `cdn-origin/presentations/quarterly-report` könyvtárat állítja elő, mint csatolt vagy szinkronizált közzétételi helyet. A minta maga nem hajt végre hálózati feltöltést: a generált hivatkozások csak a könyvtár a céloldalon vagy CDN‑en való közzétételét követően válnak érvényessé.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Tegye közzé a `presentation.md` fájlt az `assets` könyvtárral együtt. A Markdown dokumentum relatív képhivatkozásokat használ, így mindkét elemnek meg kell őriznie azonos viszonyát a célhelyen. Ha a közzétételi rendszer abszolút külső URL‑eket igényel, írja át a generált hivatkozásokat egy külön utófeldolgozási lépésben, miután az összes képfájl közzétételre került.

## **GYIK**

**Testreszabhatók-e a Python visszahívások az egyes képfájlok és hivatkozások során a Markdown exportálásakor?**

Nem. Az Aspose.Slides for Python via .NET nem teszi elérhetővé a .NET `ImageSaving` és `SvgImageSaving` visszahívásait. Állítsa be a helyi kimenetet a [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/base_path/) és a [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) használatával, majd közzéteszi vagy utófeldolgozza a generált erőforrásokat.

**Hol kerülnek mentésre az exportált képek?**

A képek helyét a [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/base_path/) és a [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) szabályozza. A Markdown dokumentum relatív útvonalakkal hivatkozik ezekre a képekre.

**Milyen útvonal-elválasztót kell használni a képhivatkozásoknál?**

Használjon előre lövő perjeleket (`/`) a Markdown hivatkozásokban és URL‑ekben. A fájlrendszer‑útvonalakhoz csak a `os.path.join`‑t alkalmazza, és a post‑processing során külön normalizálja a létrehozott hivatkozásokat.

**Megmaradnak-e a hiperhivatkozások a Markdown exportálásakor?**

Igen. A szöveges [hyperlinks](/slides/hu/python-net/manage-hyperlinks/) megmaradnak szabványos Markdown hivatkozásként. A diák [transitions](/slides/hu/python-net/slide-transition/) és [animations](/slides/hu/python-net/powerpoint-animation/) nem kerülnek konvertálásra.

**Párhuzamosan konvertálhatók-e a prezentációk Markdown‑be?**

Különböző prezentációs fájlok párhuzamos feldolgozása lehetséges, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a szálak között. Kövesse a [multithreading guidelines](/slides/hu/python-net/multithreading/) irányelveket, és minden fájlhoz használjon külön példányt.