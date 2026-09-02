---
title: PowerPoint prezentációk XML-re konvertálása JavaScript-ben
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/nodejs-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-re
- prezentáció konvertálása XML-re
- PPT XML-re
- PPTX XML-re
- ODP XML-re
- PowerPoint XML prezentáció
- SaveFormat.Xml
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML adatfolyam
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy adatfolyamokká JavaScript-ben az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes PowerPoint prezentációkat PowerPoint XML Presentation formátumba konvertálni. Az XML kimenet hasznos, ha szövegalapú ábrázolásra van szükség a prezentáció struktúrájának vizsgálatához, a generált dokumentumok hibakereséséhez, a kimenet automatizált tesztekben történő összehasonlításához, vagy olyan munkafolyamathoz való integráláshoz, amely XML-t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) felsorolt `Xml` értékével. Az eredményt közvetlenül fájlba vagy adatfolyamba írhatja.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` creates a PowerPoint XML Presentation. It does not extract the individual Office Open XML parts stored inside a PPTX package. If you need the exact PPTX package parts, such as `ppt/presentation.xml` or individual slide XML files, inspect the PPTX package itself.

{{% /alert %}}

## **Prezentáció konvertálása XML fájlba**

Töltsön be egy forrásprezentációt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal, majd adja át a kimeneti útvonalat és a `SaveFormat.Xml` értéket a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódusnak. A forrás lehet bármely, betöltésre támogatott prezentációformátum, például PPT, PPTX vagy ODP.

A következő példa egy PPTX prezentációt konvertál XML fájlba:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML kimenet írása adatfolyamba**

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) adatfolyam túlterhelését, amikor az XML-nek a memóriában kell maradnia vagy tovább kell adni egy másik komponensnek, például egy webszolgáltatásnak, tároló szolgáltatónak vagy XML feldolgozási csővezetéknek. A következő példa az eredményt egy Java `ByteArrayOutputStream`-ba írja, és a generált adatot egy Node.js `Buffer`-be másolja:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Adja át az xmlBuffer-t a munkafolyamat következő komponensének.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML összehasonlítása prezentációval és exportformátumokkal**

Válassza ki a kimeneti formátumot a végeredmény felhasználási módja szerint:

| Formátum | Kimenet | Tipikus felhasználás |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Struktúra vizsgálata, hibakeresés, generált kimenet összehasonlítása, és XML-alapú integráció |
| PPT (`.ppt`) | Egy régi bináris prezentációs fájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Egy Office Open XML csomag, amely több részt tartalmaz | Rendszeres PowerPoint szerkesztés és prezentációcsere |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Egy egyéni dia leképezett ábrázolása | Bélyegképek, előnézetek és képeszközök |
| HTML vagy HTML5 | Weborientált prezentációkimenet | Böngészőben való megtekintés és webes közzététel |

A PPT és PPTX formátumokkal ellentétben az XML kimenet elsősorban ellenőrzésre és adatközpontú munkafolyamatokra szolgál. A PDF, TIFF, HTML és diákkép formátumokkal ellentétben ez nem a diákat oldalként vagy vizuális eszközként rendereli, hanem a prezentáció adatát reprezentálja. A [támogatott fájlformátumok](/slides/hu/nodejs-java/supported-file-formats/) táblázat a PowerPoint XML Presentation-t csak mentésre használható formátumként sorolja fel, ezért ne használja, ha a munkafolyamatnak vissza kell töltenie az exportált fájlt az Aspose.Slides-be a további szerkesztéshez.

## **GYIK**

**Ugyanaz e a `SaveFormat.Xml`, mint egy PPTX fájl mentése?**

Nem. A PPTX egy olyan csomag, amely több Office Open XML részt tartalmaz, míg a `SaveFormat.Xml` egy PowerPoint XML Presentation fájlt hoz létre.

**Menthetem az XML kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**

Igen. Adjon át egy írható adatfolyamot a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódusnak. Például használjon egy Java `ByteArrayOutputStream`-ot, és másolja annak adatait egy Node.js `Buffer`-be a memóriaalapú feldolgozáshoz.

**Tudja-e az Aspose.Slides újra betölteni az exportált XML fájlt?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre, nem betöltésre támogatott. Használjon PPTX-et vagy más támogatott prezentációformátumot, ha körkörös szerkesztés szükséges.

**Az XML konvertálás minden diákat oldalra vagy képre renderel?**

Nem. Az XML konvertálás strukturált prezentációs adatokat ír. Használjon PDF-et vagy TIFF-et oldalorientált kimenethez, vagy PNG-t, JPEG-et és SVG-t egyedi dia képekhez.