---
title: PDF-dokumentumok szerkesztése Pythonban
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/python-net/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF PPTX-re
- PPTX PDF-re
- Python
- Aspose.Slides
description: "PDF-dokumentumok szerkesztése Pythonban az Aspose.Slides-be történő importálással, a szöveg cseréjével, majd a módosított bemutató vissza mentésével PDF-be."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi a PDF tartalom szerkesztését az oldalak diáként történő importálásával, a bemutató módosításával, majd visszaexportálásával PDF formátumba. Ez a cikk egy egyszerű szövegcserét mutat be. A bemutató a memóriában marad, így egy köztes PPTX fájl mentése opcionális.

## **Szöveg cseréje PDF-ben**

Használja a [add_from_pdf](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_from_pdf/) az oldalak importálásához, a [replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_text/) a szöveg frissítéséhez, és a [save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) az eredmény exportálásához.

A következő példa azt várja, hogy az `input.pdf` az importálás után szerkeszthető szövegként tartalmazza a "Draft" szót. A program ezt a szót "Final"-ra cseréli, és a `edited.pdf` fájlt írja ki. Az elején lévő dia törlése az importálás előtt megakadályoz egy extra üres oldalt a kimenetben. A keresés teljes szavakat egyező kis- és nagybetűkkel talál; a `None` azt jelenti, hogy nem szükséges eredmény‑visszahívás.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

További lehetőségekért lásd a [Keresés és szövegcsere](/slides/hu/python-net/search-and-replace-text/) és a [PowerPoint konvertálása PDF-be](/slides/hu/python-net/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Megjegyzés" %}}
A szövegcseré csak az importált szövegen működik, nem a beolvasott képekben lévő szövegen. Az átalakítás befolyásolhatja az elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen ha a cserélt szöveg hosszabb az eredetinél.
{{% /alert %}}

## **GYIK**

**Szükséges-e PPTX fájlt menteni a PDF exportálása előtt?**

Nem. A bemutatót a memóriában szerkesztheti és exportálhatja. PPTX másolatot csak akkor kell menteni, ha tovább szeretné szerkeszteni PowerPointban; lásd a [Prezentációk mentése](/slides/hu/python-net/save-presentation/).

**Miért maradhat néhány szöveg változatlanul?**

A példa a teljes "Draft" szót egyező kis- és nagybetűkkel keresi. A képként importált vagy különálló szövegdobozokra osztott szöveg nem feltétlenül felel meg a keresésnek. Ellenőrizze az importált tartalmat, és állítsa be a keresést a dokumentumához.