---
title: PowerPoint prezentációk konvertálása Markdown-ba Pythonban
linktitle: PowerPoint Markdown-ba
type: docs
weight: 140
url: /hu/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása Markdown-ba
- OpenDocument konvertálása Markdown-ba
- prezentáció konvertálása Markdown-ba
- dia konvertálása Markdown-ba
- PPT konvertálása Markdown-ba
- PPTX konvertálása Markdown-ba
- ODP konvertálása Markdown-ba
- PowerPoint konvertálása MD-be
- OpenDocument konvertálása MD-be
- prezentáció konvertálása MD-be
- dia konvertálása MD-be
- PPT konvertálása MD-be
- PPTX konvertálása MD-be
- ODP konvertálása MD-be
- PowerPoint
- OpenDocument
- prezentáció
- Markdown
- Python
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument diákat—PPT, PPTX, ODP—tiszta Markdown formátumba az Aspose.Slides for Python via .NET segítségével, automatizálja a dokumentációt és megőrizze a formázást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk Markdown‑formátumba történő konvertálását, ami hasznos lehet dokumentációs munkafolyamatokban, statikus webhelyek generálásában, tartalom migrációban és verziókövetett szöveges kiadványok közzétételében. Az API közvetlen exportot támogat PPT és PPTX prezentációkból MD fájlokba, és további lehetőségeket biztosít a diák tartalmának a létrehozott Markdown‑dokumentumban való ábrázolásának szabályozására.

Exportálhat prezentációkat egyszerű Markdown‑ként, választhat több Markdown‑változat közül, például a CommonMark és a GitHub Flavored Markdown, valamint beállíthatja, hogyan kezelje a képeket az export során. Olyan prezentációk esetén, amelyek vizuális tartalmat tartalmaznak, az Aspose.Slides lehetővé teszi a képek külön mappába mentését, és azok hivatkozását a generált Markdown‑fájlban.

{{% alert color="warning" %}}

A PowerPoint‑Markdown export alapértelmezés szerint **képek nélkül** történik. Ha olyan PowerPoint‑dokumentumot szeretne exportálni, amely képeket tartalmaz, be kell állítania az `export_type = MarkdownExportType.VISUAL` értéket, és meg kell adnia a `base_path`‑t, ahova a Markdown‑dokumentumban hivatkozott képek mentésre kerülnek.

{{% /alert %}}

## **Prezentációk konvertálása Markdown‑ba**

Az alábbi példa a legegyszerűbb módját mutatja be egy PowerPoint‑prezentáció Markdown‑ba konvertálásának az Aspose.Slides for Python via .NET használatával, alapértelmezett beállításokkal.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot a prezentáció betöltéséhez.
1. Hívja meg a `save` metódust a Markdown‑fájlba történő exportáláshoz.

Használja az alábbi Python kódrészletet a konverzió elvégzéséhez:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Prezentációk konvertálása különböző Markdown‑változatokba**

Az Aspose.Slides lehetővé teszi a prezentációk konvertálását különböző Markdown‑formátumokba, beleértve az alap Markdown‑t, a CommonMark‑ot, a GitHub‑flavored Markdown‑ot, a Trello‑t, az XWiki‑t, a GitLab‑ot és további 17 Markdown‑változatot.

Az alábbi Python példa bemutatja, hogyan konvertálhat egy PowerPoint‑prezentációt CommonMark‑ra:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

A támogatott 23 Markdown‑változat a [Flavor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) felsorolásban található a [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) osztályban.

## **Képeket tartalmazó prezentációk konvertálása Markdown‑ba**

Az [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) osztály tulajdonságokat és felsorolásokat biztosít, amelyekkel beállítható a létrehozott Markdown‑fájl. Például a [MarkdownExportType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enumeráció határozza meg a képek kezelésének módját: `SEQUENTIAL`, `TEXT_ONLY` vagy `VISUAL`.

### **Képek szekvenciális konvertálása**

Ha azt szeretné, hogy a képek egymás után, egyenként jelenjenek meg a generált Markdown‑ban, válassza a `SEQUENTIAL` opciót. Az alábbi Python példa bemutatja, hogyan konvertálhat egy képeket tartalmazó prezentációt Markdown‑ba.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Képek vizuális konvertálása**

Ha azt szeretné, hogy a képek együtt jelenjenek meg a létrehozott Markdown‑ban, válassza a `VISUAL` opciót. Ebben a módban a képek az alkalmazás aktuális könyvtárába (és a Markdown‑dokumentum relatív útvonalakat használ), vagy megadhat egy egyéni kimeneti útvonalat és mappanevet.

Az alábbi Python példa mutatja be ezt a műveletet:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **GYIK**

**Megmaradnak a hiperhivatkozások az exportálás után?**

Igen. A szöveg [hyperlinks](/slides/hu/python-net/manage-hyperlinks/) megmarad szabványos Markdown‑hivatkozásként. A diák [transitions](/slides/hu/python-net/slide-transition/) és [animations](/slides/hu/python-net/powerpoint-animation/) nem kerülnek konvertálásra.

**Gyorsítható a konvertálás több szál használatával?**

Fájlok között párhuzamosítható, de [don’t share](/slides/hu/python-net/multithreading/) ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt szálak között. Használjon különálló példányokat vagy folyamatokat fájlonként a versengés elkerülése érdekében.

**Mi történik a képekkel – hová kerülnek mentésre, és relatívak‑e az útvonalak?**

A [Images](/slides/hu/python-net/image/) külön mappába exportálódik, és a Markdown‑fájl alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. A kimeneti alapú útvonal és az asset mappa nevét konfigurálhatja, hogy előre megjósolható tárolóstruktúrát kapjon.