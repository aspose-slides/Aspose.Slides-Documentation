---
title: PowerPoint prezentációk Word dokumentumokká konvertálása Pythonban
linktitle: PowerPoint Word-re
type: docs
weight: 110
url: /hu/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint DOCX-re
- OpenDocument DOCX-re
- prezentáció DOCX-re
- dia DOCX-re
- PPT DOCX-re
- PPTX DOCX-re
- ODP DOCX-re
- PowerPoint DOC-ra
- OpenDocument DOC-ra
- prezentáció DOC-ra
- dia DOC-ra
- PPT DOC-ra
- PPTX DOC-ra
- ODP DOC-ra
- PowerPoint Word-re
- OpenDocument Word-re
- prezentáció Word-re
- dia Word-re
- PPT Word-re
- PPTX Word-re
- ODP Word-re
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- ODP konvertálása
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet könnyedén konvertálni a PowerPoint és OpenDocument prezentációkat Word dokumentumokká az Aspose.Slides for Python via .NET segítségével. Lépésről‑lépésre útmutatónk, amely tartalmaz minta Python kódot, megoldást kínál a fejlesztők számára, akik egyszerűsíteni szeretnék dokumentumfolyamataikat."
---
## **Áttekintés**

Ez a cikk megoldást nyújt a fejlesztőknek a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásához az Aspose.Slides for Python via .NET és az Aspose.Words for Python via .NET segítségével. A lépésről‑lépésre útmutató minden szakaszon végigvezeti Önt a konvertálási folyamat során.

## **Prezentáció konvertálása Word dokumentummá**

Kövesse az alábbi lépéseket egy PowerPoint vagy OpenDocument prezentáció Word dokumentummá konvertálásához:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály példányát, és töltse be a prezentációfájlt.
2. Hozza létre a [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) és a [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) osztályok példányait a Word dokumentum előállításához.
3. Állítsa be a Word dokumentum oldalméretét a prezentációéhoz hasonlóan a [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) tulajdonság segítségével.
4. Állítsa be a Word dokumentum margóit a [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) tulajdonság segítségével.
5. Iteráljon végig a prezentáció összes dián a [Presentation.slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) tulajdonság használatával.
   - Generáljon diaképet a [Slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) osztály `get_image` metódusával, és mentse memóriaáramra.
   - Adja hozzá a diaképet a Word dokumentumhoz a [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) osztály `insert_image` metódusával.
6. Mentse a Word dokumentumot egy fájlba.

Tegyük fel, hogy van egy „sample.pptx” prezentációnk, amely így néz ki:

![PowerPoint prezentáció](PowerPoint.png)

Az alábbi Python kódrészlet bemutatja, hogyan konvertálható a PowerPoint prezentáció Word dokumentummá:

```py
import aspose.slides as slides
import aspose.words as words

# Töltsön be egy prezentációfájlt.
with slides.Presentation("sample.pptx") as presentation:

    # Hozzon létre Document és DocumentBuilder objektumokat.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Állítsa be az oldal méretét a Word dokumentumban.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Állítsa be a margókat a Word dokumentumban.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Iteráljon végig a prezentáció összes diáján.
    for slide in presentation.slides:

        # Generáljon egy diaképet, és mentse memóriaáramra.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Adja hozzá a diaképet a Word dokumentumhoz.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Mentse a Word dokumentumot egy fájlba.
    document.save("output.docx")
```

Az eredmény:

![Word dokumentum](Word.png)

{{% alert color="primary" %}} 

Próbálja ki az **Online PPT to Word Converter**[https://products.aspose.app/slides/hu/conversion/ppt-to-word] linket, hogy lássa, milyen előnyöket nyújt a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálása. 

{{% /alert %}}

## **GYIK**

**Milyen komponenseket kell telepíteni a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásához?**

Csak a [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) és a [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) megfelelő csomagjait kell hozzáadnia a Python projektjéhez. Mindkét csomag önálló API‑ként működik, és nem szükséges a Microsoft Office telepítése.

**Támogatottak-e minden PowerPoint és OpenDocument prezentációformátum?**

Az Aspose.Slides for Python .NET [minden prezentációformátumot támogat](/slides/hu/python-net/supported-file-formats/), beleértve a PPT, PPTX, ODP és más gyakori fájltípusokat. Ez biztosítja, hogy különböző Microsoft PowerPoint verziókban készült prezentációkkal is dolgozhasson.