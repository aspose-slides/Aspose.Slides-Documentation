---
title: PowerPoint prezentációk konvertálása XML-be Pythonon keresztül Java segítségével
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/python-java/convert-powerpoint-to-xml/
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
- Python
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy adatfolyamokká Pythonon keresztül Java-val, az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java képes a PowerPoint‑prezentációkat a PowerPoint XML Presentation formátumba konvertálni. Az XML kimenet akkor hasznos, ha szövegalapú ábrázolásra van szükség a prezentációs struktúra vizsgálatához, a generált dokumentumok hibakereséséhez, a kimenet automata tesztekben történő összehasonlításához, vagy egy olyan munkafolyamathoz való integrálásához, amely XML‑t fogyaszt a prezentációcsomag helyett.

Használd a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) osztályból származó [Xml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Xml) értékkel. Az eredményt közvetlenül fájlba vagy streambe is írhatod.

{{% alert color="info" title="Megjegyzés" %}}

A [SaveFormat.Xml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Xml) PowerPoint XML Presentation fájlt hoz létre. Nem bontja ki a PPTX csomagban tárolt egyes Office Open XML részeket. Ha a pontos PPTX csomagrészekre van szükséged, például a `ppt/presentation.xml`‑ra vagy az egyes dia XML fájlokra, vizsgáld meg a PPTX csomagot.

{{% /alert %}}

## **Prezentáció konvertálása XML fájlba**

Tölts be egy forrásprezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal, majd add át a kimeneti útvonalat és a [SaveFormat.Xml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Xml) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. A forrás lehet bármely, betöltésre támogatott prezentációformátum, például PPT, PPTX vagy ODP.

A következő példa egy PPTX prezentációt konvertál XML fájlba:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **XML kimenet írása streambe**

Használd a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) stream túlterhelését, ha az XML‑nek memóriában kell maradnia, vagy egy másik komponensnek kell továbbadni, például egy webszolgáltatásnak, tároló szolgáltatónak vagy XML‑feldolgozó csővezetéknek. A következő példa az eredményt egy [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)‑ba írja, és a kapott XML‑t Python bytes objektumként adja vissza:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Az xml_data-t átadja a munkafolyamat következő komponensének.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **XML összehasonlítása a prezentációs és export formátumokkal**

Válaszd ki a kimeneti formátumot attól függően, hogyan lesz felhasználva az eredmény:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | Struktúra vizsgálata, hibakeresés, a generált kimenet összehasonlítása, és XML‑alapú integráció |
| PPT (`.ppt`) | Örökölt bináris prezentációfájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Több részt tartalmazó Office Open XML csomag | Rendszeres PowerPoint szerkesztés és prezentációcserélés |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Egyedi dia renderelt ábrázolása | Bélyegképek, előnézetek és kép eszközök |
| HTML vagy HTML5 | Web‑orientált prezentációkimenet | Böngészőben való megtekintés és webes publikálás |

A PPT és PPTX formátumokkal ellentétben az XML kimenet elsősorban ellenőrzésre és adatközpontú munkafolyamatokra szolgál. A PDF, TIFF, HTML és diakép formátumokkal ellentétben a prezentáció adatait ábrázolja, nem a diákat oldalként vagy vizuális eszközként jeleníti meg. A [supported file formats](/slides/hu/python-java/supported-file-formats/) táblázat a PowerPoint XML Presentation formátumot csak mentésre használható formátumként sorolja fel, ezért ne használd, ha a munkafolyamatnak vissza kell töltenie az exportált fájlt az Aspose.Slides-be a további szerkesztéshez.

## **GYIK**

**Ugyanaz-e az XML export, mint egy PPTX fájl mentése?**

Nem. A PPTX egy több Office Open XML részt tartalmazó csomag, míg a [SaveFormat.Xml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Xml) egy PowerPoint XML Presentation fájlt hoz létre.

**Menthetem az XML kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**

Igen. Adj át egy írható Java kimeneti streamet a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. Például használj egy [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) objektumot a memória alapú feldolgozáshoz.

**Tudja-e az Aspose.Slides újra betölteni a exportált XML fájlt?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre támogatott, betöltésre nem. Használj PPTX‑et vagy más támogatott prezentációs formátumot, ha körkörös szerkesztésre van szükség.

**Az XML konverzió minden diát oldal vagy kép formájában jelenít meg?**

Nem. Az XML konverzió strukturált prezentációs adatokat ír ki. Használj PDF‑et vagy TIFF‑et az oldal‑orientált kimenethez, vagy PNG‑t, JPEG‑t és SVG‑t az egyes diaképekhez.