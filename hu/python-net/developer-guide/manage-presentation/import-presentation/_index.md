---
title: "Prezentációk importálása Pythonban"
linktitle: "Prezentáció importálása"
type: docs
weight: 60
url: /hu/python-net/import-presentation/
keywords:
- "PowerPoint importálása"
- "prezentáció importálása"
- "dia importálása"
- "PDF prezentációba"
- "PDF PPT‑vé"
- "PDF PPTX‑vé"
- "PDF ODP‑vé"
- "HTML prezentációba"
- "HTML PPT‑vé"
- "HTML PPTX‑vé"
- "HTML ODP‑vé"
- Python
- Aspose.Slides
description: "PDF és HTML dokumentumok könnyed importálása PowerPoint és OpenDocument prezentációkba Pythonban az Aspose.Slides segítségével a zökkenőmentes, nagy teljesítményű dia feldolgozáshoz."
---
## **Bevezetés**

Az [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/hu/python-net/) segítségével tartalmakat importálhat prezentációba más fájlformátumokból. A [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) osztály metódusokat biztosít a diák PDF‑ből, HTML‑ből és egyéb forrásokból való importálásához.

## **PDF átalakítása prezentációvá**

Ez a rész azt mutatja be, hogyan lehet egy PDF‑et prezentációvá alakítani az Aspose.Slides segítségével. Lépésről lépésre vezeti az importáláson, a PDF oldalak diákra bontásán és az eredmény PPTX fájlként való mentésén.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hívja meg az [add_from_pdf](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_from_pdf/) metódust, és adja át a PDF fájlt.  
3. Használja a [save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a prezentáció PowerPoint formátumban való mentéséhez.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Érdemes kipróbálni az **Aspose ingyenes** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást – ez a leírt folyamat élő megvalósítása.
{{% /alert %}}

## **HTML átalakítása prezentációvá**

Ez a rész azt mutatja be, hogyan lehet HTML‑t tartalmat importálni egy prezentációba az Aspose.Slides segítségével. Lefedi a HTML betöltését, átalakítását diákra a szöveg, képek és alapformázás megőrzésével, valamint az eredmény PPTX fájlként való mentését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hívja meg az [add_from_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_from_html/) metódust, és adja át a HTML fájlt.  
3. Használja a [save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a prezentáció PowerPoint formátumban való mentéséhez.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**A PDF importálásakor megmaradnak-e a táblázatok, és javítható-e azok felismerése?**

A táblázatok importálás során felderíthetők; a [PdfImportOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.importing/pdfimportoptions/) tartalmaz egy [detect_tables](https://reference.aspose.com/slides/hu/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) paramétert, amely lehetővé teszi a táblázatok felismerését. A hatékonyság a PDF szerkezetétől függ.

{{% alert title="Note" color="info" %}}
Az Aspose.Slides segítségével HTML‑t is átalakíthat más népszerű fájlformátumokká:

* [HTML képformátumba](https://products.aspose.com/slides/hu/python-net/conversion/html-to-image/)
* [HTML JPG‑be](https://products.aspose.com/slides/hu/python-net/conversion/html-to-jpg/)
* [HTML XML‑be](https://products.aspose.com/slides/hu/python-net/conversion/html-to-xml/)
* [HTML TIFF‑be](https://products.aspose.com/slides/hu/python-net/conversion/html-to-tiff/)
{{% /alert %}}