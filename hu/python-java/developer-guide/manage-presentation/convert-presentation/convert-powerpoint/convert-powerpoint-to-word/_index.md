---
title: PowerPoint előadásokat Word dokumentumokká konvertálás Pythonon keresztül Java használatával
linktitle: PowerPoint Word-be
type: docs
weight: 110
url: /hu/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertálása
- előadás konvertálása
- PowerPoint Word-be
- előadás Word-be
- PPT Word-be
- PPTX Word-be
- ODP Word-be
- PowerPoint DOCX-be
- PPT DOCX-be
- PPTX DOCX-be
- PowerPoint DOC-ba
- PPT mentése DOCX-ként
- PPTX mentése DOCX-ként
- PPT exportálása DOCX-be
- PPTX exportálása DOCX-be
- Python
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument előadásokat konvertál Word-dokumentummá Pythonon keresztül Java-val, az Aspose.Slides és Aspose.Words használatával, a diaképeket szerkeszthető szöveggel kombinálva."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint és OpenDocument előadásokat Word dokumentumokká konvertálni az Aspose.Slides for Python via Java és az Aspose.Words for Java használatával. Az Aspose.Slides minden diát renderel, és beolvassa a szövegét, míg az Aspose.Words a JPype segítségével hozza létre a Word dokumentumot. A Microsoft Office nem szükséges.

Az eredményül kapott dokumentum egy dia képet tartalmaz, amelyet a dia felső szintű automatikus alakzataiból kinyert szerkeszthető szöveg követ. A kép megőrzi a dia vizuális megjelenését; az egyedi alakzatok, diagramok és táblázatok nem konvertálódnak szerkeszthető Word objektumokká. A kinyert szöveg nem őrzi meg az eredeti szövegformázást vagy pozicionálást.

## **PowerPoint konvertálása Word-be**

1. Telepítse az [Aspose.Slides for Python via Java](/slides/hu/python-java/installation/) és egy kompatibilis Java futtatókörnyezetet.
2. Töltse le az [Aspose.Words for Java](https://releases.aspose.com/words/java/). Helyezze a fő JAR fájlt egy `lib` könyvtárba a szkriptje mellé, és nevezze át `aspose-words.jar`-ra, vagy módosítsa az útvonalat a példában a letöltött fájl nevéhez.
3. Tegye a bemeneti előadást, a `sample.pptx`-t a munkakönyvtárba. A `lib/aspose-words.jar` útvonal is relatív ehhez a könyvtárhoz.
4. Futtassa az alábbi Python kódot a `output.docx` létrehozásához.

A példa a forrást a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) segítségével tölti be, és a diák rendereléséhez a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódust használja. Az Aspose.Words [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) osztályát használja a képek és a szöveg beillesztéséhez a Word dokumentumba.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Igazítsa a diaképet a szövegterület szélességéhez, megőrizve az arányát.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Szúrja be a felső szintű automatikus alakzatokból származó egyszerű szöveget, beleértve a szövegdobozokat.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Minden dia új oldalon kezdődik. A hosszú kinyert szöveg vagy a szokatlanul magas dia képek további oldalakat igényelhetnek. A kód csak a diák között szúr be oldaltöréseket, és a `finally` blokkokban felszabadítja az előadást és a renderelt képeket. A JVM továbbra is elérhető a további konverziókhoz ugyanabban a Python folyamatban.

## **GYIK**

**Milyen könyvtárak szükségesek?**

Használja az Aspose.Slides for Python via Java, a JPype, egy kompatibilis Java futtatókörnyezet, valamint az Aspose.Words for Java könyvtárakat. Mindkét Aspose könyvtár ugyanabban a JVM-ben fut. Az Aspose.Slides kezeli az előadást; az Aspose.Words írja a Word dokumentumot.

**Konvertálhatok PPT és ODP fájlokat is, valamint PPTX-et?**

Igen. Cserélje le a `sample.pptx`-t egy PPT vagy ODP fájlra. Lásd a [Supported File Formats](/slides/hu/python-java/supported-file-formats/) oldalt az előadás bemeneti formátumaiért.

**Minden dia tartalom szerkeszthető a Word-ben?**

Nem. Minden dia statikus képként kerül beillesztésre, a felső szintű automatikus alakzatokból származó egyszerű szöveggel alatta. A csoportok, táblázatok, SmartArt és diagramok belső szövege, valamint a jegyzetek nem kerülnek kinyerésre ebben a példában. Az animációk és átmenetek nem jelennek meg a Word dokumentumban.

**Menthetek DOC formátumban a DOCX helyett?**

Igen. Módosítsa a kimeneti fájlnevet `output.doc`-ra. Az Aspose.Words a fájlnevek kiterjesztéséből választja ki a kimeneti formátumot, amikor ezt a mentési túlterhelést használja.