---
title: PowerPoint prezentációk konvertálása XML-re Pythonban
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/python-net/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-re
- prezentáció konvertálása XML-re
- PPT XML-re
- PPTX XML-re
- ODP XML-re
- PowerPoint XML prezentáció
- SaveFormat.XML
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML adatfolyam
- Python
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy adatfolyamokká Pythonban az Aspose.Slides használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET képes a PowerPoint‑prezentációkat a PowerPoint XML Presentation formátumba konvertálni. Az XML‑kimenet akkor hasznos, ha szöveges ábrázolásra van szükség a prezentáció felépítésének vizsgálatához, a generált dokumentumok hibakereséséhez, a kimenet összehasonlításához automatizált tesztekben, vagy egy olyan munkafolyamattal való integrációhoz, amely XML‑t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) felsorolás `XML` értékével. Az eredményt közvetlenül fájlba vagy streambe írhatja.

{{% alert color="info" title="Megjegyzés" %}}

`SaveFormat.XML` PowerPoint XML Presentation‑t hoz létre. Nem bontja ki a PPTX csomagban tárolt egyedi Office Open XML részeket. Ha a pontos PPTX csomagrészekre van szükség, például a `ppt/presentation.xml` fájlra vagy az egyes diák XML‑fájljaira, vizsgálja meg közvetlenül a PPTX csomagot.

{{% /alert %}}

## **Prezentáció konvertálása XML fájlba**

Töltsön be egy forrás‑prezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztállyal, majd adja át a kimeneti útvonalat és a `SaveFormat.XML` értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódusnak. A forrás lehet bármely, betöltésre támogatott prezentációformátum, például PPT, PPTX vagy ODP.

Az alábbi példában egy PPTX prezentációt konvertálunk XML fájlba:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Az XML kimenet írása streambe**

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) stream‑túlterhelését, amikor az XML‑nek memóriában kell maradnia vagy egy másik komponensnek (például webszolgáltatásnak, tárolási szolgáltatónak vagy XML‑feldolgozó csővezetéknek) kell átadni. Az alábbi példában az eredményt egy [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) streambe írjuk, majd visszaállítjuk a pozíciót a későbbi olvasáshoz:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Az xml_stream-et átadja a munkafolyamat következő komponensének.
```

## **XML összehasonlítása a prezentációval és az exportformátumokkal**

Válassza ki a kimeneti formátumot az eredmény felhasználási módja szerint:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | A struktúra ellenőrzése, hibakeresés, a generált kimenet összehasonlítása és XML‑alapú integráció |
| PPT (`.ppt`) | Örökölt bináris prezentációfájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részt tartalmazva | Szokásos PowerPoint szerkesztés és prezentációcserére |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Az egyes dia renderelt ábrázolása | Miniatűrök, előnézetek és képeszközök |
| HTML vagy HTML5 | Web‑orientált prezentációkimenet | Böngészőben való megtekintés és webes közzététel |

A PPT‑ és PPTX‑formátumoktól eltérően az XML‑kimenet elsősorban ellenőrzésre és adat‑központú munkafolyamatokra szolgál. A PDF‑, TIFF‑, HTML‑ és dia‑képfájlformátumoktól különbözik, mivel a prezentáció adatát ábrázolja, nem pedig a diákat oldalakon vagy vizuális eszközökön keresztül rendereli. A [supported file formats](/slides/hu/python-net/supported-file-formats/) táblázat a PowerPoint XML Presentation‑t csak mentésre alkalmas formátumként sorolja fel, ezért ne használja, ha a munkafolyamatnak vissza kell töltenie az exportált fájlt az Aspose.Slides‑be a további szerkesztéshez.

## **GYIK**

**Ugyanaz-e a `SaveFormat.XML`, mint egy PPTX fájl mentése?**

Nem. A PPTX több Office Open XML részt tartalmazó csomag, míg a `SaveFormat.XML` egy PowerPoint XML Presentation fájlt hoz létre.

**Menthetem az XML‑kimenetet anélkül, hogy fájlt hoznék létre lemezen?**

Igen. Adjon át egy írható streamet a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódusnak. Például használjon egy [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) streamet a memóriában történő feldolgozáshoz.

**Tudja-e az Aspose.Slides betölteni az exportált XML‑fájlt újra?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre támogatott, betöltésre nem. Használjon PPTX‑et vagy más, támogatott prezentációformátumot, ha körkörös szerkesztésre van szükség.

**Az XML‑konverzió minden diákat oldalra vagy képre renderel?**

Nem. Az XML‑konverzió strukturált prezentációadatot ír. Használjon PDF‑et vagy TIFF‑et oldalorientált kimenethez, illetve PNG‑t, JPEG‑t és SVG‑t az egyes diák képeihez.