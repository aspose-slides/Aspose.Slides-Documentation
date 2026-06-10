---
title: PowerPoint prezentációk konvertálása Word dokumentumokká Java-ban
linktitle: PowerPoint Word-re
type: docs
weight: 110
url: /hu/java/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint Word-re
- prezentáció Word-re
- dia Word-re
- PPT Word-re
- PPTX Word-re
- PowerPoint DOCX-re
- prezentáció DOCX-re
- dia DOCX-re
- PPT DOCX-re
- PPTX DOCX-re
- PowerPoint DOC-ra
- prezentáció DOC-ra
- dia DOC-ra
- PPT DOC-ra
- PPTX DOC-ra
- PPT mentése DOCX-ként
- PPTX mentése DOCX-ként
- PPT exportálása DOCX-be
- PPTX exportálása DOCX-be
- Java
- Aspose.Slides
description: "PowerPoint PPT és PPTX diák konvertálása szerkeszthető Word dokumentumokká Java-ban az Aspose.Slides segítségével, megőrizve a pontos elrendezést, a képeket és a formázást."
---
## **Áttekintés**

Ez a cikk megoldást nyújt a fejlesztőknek a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásához az Aspose.Slides és Aspose.Words használatával. A lépésről-lépésre útmutató minden állomáson végigvezet a konverziós folyamaton.

## **PowerPoint konvertálása Word-re**

Kövesse az alábbi utasításokat a PowerPoint vagy OpenDocument prezentáció Word dokumentummá konvertálásához:

1. Töltse le az [Aspose.Slides for Java](https://downloads.aspose.com/slides/hu/java) és az [Aspose.Words for Java](https://downloads.aspose.com/words/java) könyvtárakat.
2. Adja hozzá a *aspose-slides-x.x-jdk16.jar* és a *aspose-words-x.x-jdk16.jar* fájlokat a CLASSPATH-hoz.
3. Használja az alábbi kódrészletet a PowerPoint Word-re konvertálásához:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    //     létrehozza a diaképet bájt tömb adatfolyamként
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    //     beszúrja a dia szövegeit
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **GYIK**

**Milyen komponenseket kell telepíteni a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásához?**

Csak hozzá kell adnia a megfelelő csomagot az [Aspose.Slides for Java](https://releases.aspose.com/slides/hu/java/) és az [Aspose.Words for Java](https://releases.aspose.com/words/java/) számára a projektjéhez. Mindkét könyvtár önálló API-ként működik, és nincs szükség a Microsoft Office telepítésére.

**Támogatott-e az összes PowerPoint és OpenDocument prezentációformátum?**

Az Aspose.Slides [támogatja az összes prezentációformátumot](/slides/hu/java/supported-file-formats/), beleértve a PPT, PPTX, ODP és egyéb gyakori fájltípusokat. Ez biztosítja, hogy különböző Microsoft PowerPoint verziókban létrehozott prezentációkkal is dolgozhasson.