---
title: PowerPoint prezentációk konvertálása Word dokumentumokká Androidon
linktitle: PowerPoint Word-re
type: docs
weight: 110
url: /hu/androidjava/convert-powerpoint-to-word/
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
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT és PPTX diákat szerkeszthető Word dokumentumokká Java-ban az Aspose.Slides for Android segítségével, a pontos elrendezés, képek és formázás megőrzésével."
---
## **Áttekintés**

Ez a cikk megoldást nyújt a fejlesztők számára a PowerPoint és OpenDocument prezentációk Word dokumentumokká konvertálásához az Aspose.Slides és Aspose.Words használatával. Az lépésről‑lépésre útmutató végigvezeti Önt a konvertálási folyamat minden szakaszán.

## **Aspose.Slides és Aspose.Words**

PowerPoint fájl (PPTX vagy PPT) Word dokumentummá (DOCX vagy DOCX) konvertálásához szükséges mind a [Aspose.Slides for Android via Java](https://products.aspose.com/slides/hu/androidjava/) és az [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/).

Az önálló API, a [Aspose.Slides](https://products.aspose.app/slides) Java számára olyan funkciókat biztosít, amelyek lehetővé teszik a prezentációkból szövegek kinyerését.  

Az [Aspose.Words](https://docs.aspose.com/words/androidjava/) egy fejlett dokumentumfeldolgozó API, amely lehetővé teszi az alkalmazások számára, hogy dokumentumokat generáljanak, módosítsanak, konvertáljanak, megjelenítsenek, nyomtatjanak, és egyéb feladatokat végezzenek dokumentumokkal anélkül, hogy a Microsoft Word‑öt használnák.

## **PowerPoint konvertálása Word‑re**

1. Töltse le az [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/hu/java) és az [Aspose.Words for Java](https://downloads.aspose.com/words/java) könyvtárakat.  
2. Adja hozzá a *aspose-slides-x.x-jdk16.jar* és a *aspose-words-x.x-jdk16.jar* fájlokat a CLASSPATH‑hoz.  
3. Használja ezt a kódrészletet a PowerPoint Word‑re történő konvertálásához:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // generálja a dia képét bájt tömbként áramként
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // beszúrja a dia szövegeit
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

**Mit kell telepíteni a PowerPoint és OpenDocument prezentációk Word dokumentumokká konvertálásához?**

Csak a megfelelő csomagot kell hozzáadnia a projektjéhez a [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/hu/androidjava/) és az [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) esetében. Mindkét könyvtár önálló API‑ként működik, és nincs szükség a Microsoft Office telepítésére.

**Támogatottak‑e minden PowerPoint és OpenDocument prezentációformátum?**

Az Aspose.Slides [támogat minden prezentációformátumot](/slides/hu/androidjava/supported-file-formats/), beleértve a PPT, PPTX, ODP és egyéb gyakori fájltípusokat. Ez biztosítja, hogy különböző Microsoft PowerPoint verziókkal készült prezentációkkal is dolgozhasson.