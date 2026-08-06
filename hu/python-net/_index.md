---
title: "Aspose.Slides Pythonhoz .NET-en keresztül"
second_title: "Aspose.Slides Pythonhoz"
type: docs
weight: 35
url: /hu/python-net/
is_root: true
keywords:
- "Aspose.Slides Pythonhoz"
- "PowerPoint automatizálás Pythonban"
- "Python PPT könyvtár"
- "PowerPoint PDF-be exportálása Pythonban"
- "PowerPoint SVG-be exportálása Pythonban"
- "PowerPoint szerkesztése Pythonban"
- "Python PowerPoint Microsoft Office nélkül"
- "PPTX kezelése Pythonnal"
- "diák előnézete Pythonban"
- "Python hang hozzáadása diákhoz"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Az Aspose.Slides for Python via .NET átfogó funkciókészletet kínál, többek között szöveg, alakzat, táblázat és animáció kezelését, hang és videó hozzáadását a diákhoz, a diák előnézetét, valamint exportálást SVG, PDF és egyéb formátumokba."
---
{{% alert color="primary" %}}

**Üdvözli az Aspose.Slides for Python via .NET-et**

![Aspose.Slides for Python via .NET terméklógó](aspose_slides-for-python.png)

Az Aspose.Slides for Python via .NET egy robusztus osztálykönyvtár, amely lehetővé teszi alkalmazásai számára, hogy Microsoft PowerPoint® szükségessége nélkül olvassanak és írjanak PowerPoint® prezentációkat.

Ez az első és egyetlen összetevő, amely teljes körű PowerPoint® dokumentumkezelést biztosít Python fejlesztők számára.

Az Aspose.Slides for Python via .NET számos funkciót tartalmaz, például szöveggel, alakzatokkal, táblázatokkal és animációkkal való munkát; hang és videó hozzáadását; diák előnézetét; valamint diák exportálását SVG, PDF és egyéb formátumokba.

{{% /alert %}}

## Az Aspose.Slides for Python via .NET telepítése

```bash
pip install aspose.slides
```

A csomag tartalmazza a szükséges .NET futtatókörnyezetet, így nincs más telepítendő, és a Microsoft PowerPoint sem szükséges. Python 3.7 vagy újabb Windows, Linux vagy macOS rendszereken.

## PowerPoint prezentáció létrehozása Pythonban

Ez a példa egy prezentációt hoz létre, szöveges alakzatot ad az első diára, és az eredményt PPTX‑ként és PDF‑ként is elmenti.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

A futtatás `presentation.pptx` (kb. 34 KB) és `presentation.pdf` (kb. 36 KB) fájlokat ír a munkakönyvtárba.

Licenc nélkül a könyvtár értékelő módban működik, amely vízjelet ad hozzá és korlátozza a diák számát. Lásd a [Licencelés](/slides/hu/python-net/licensing/) részt a licenc alkalmazásához.

## Aspose.Slides for Python via .NET erőforrások

Fedezze fel ezeket a hasznos forrásokat:

- [Aspose.Slides for Python via .NET online dokumentáció](/slides/hu/python-net/)
- [Aspose.Slides for Python via .NET funkciók](/slides/hu/python-net/features-overview/)
- [Aspose.Slides for Python via .NET kiadási megjegyzések](https://releases.aspose.com/slides/hu/python-net/release-notes/)
- [Aspose.Slides for Python via .NET termékoldal](https://products.aspose.com/slides/hu/python-net/)
- [Aspose.Slides for Python via .NET letöltése](https://releases.aspose.com/slides/hu/python-net/)
- [Aspose.Slides for Python via .NET PyPi csomag telepítése](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API referencia útmutató](https://reference.aspose.com/slides/hu/python-net/)
- [Aspose.Slides for Python via .NET ingyenes támogatási fórum](https://forum.aspose.com/c/slides/hu/11)
- [Aspose.Slides for Python via .NET fizetett támogatási helpdesk](https://helpdesk.aspose.com/)

## GyIK

### Mi az Aspose.Slides for Python via .NET?

Az Aspose.Slides for Python via .NET egy hatékony Python könyvtár, amely lehetővé teszi PowerPoint prezentációk (PPT, PPTX, ODP) programozott létrehozását, szerkesztését és konvertálását a Microsoft PowerPoint telepítése nélkül.

### Milyen prezentációs funkciókat támogat az Aspose.Slides?

A könyvtár támogatja a szöveg, alakzatok, táblázatok, diagramok, animációk, mesterdiák, hang, videó és egyéb elemek kezelését. Emellett lehetővé teszi a diák előnézetét, renderelését, nyomtatását és exportálását PDF, SVG, HTML és képek formátumaiba.

### Konvertálhatok prezentációkat más formátumokba az Aspose.Slides segítségével?

Igen. Az Aspose.Slides lehetővé teszi a PowerPoint fájlok konvertálását PDF, SVG, HTML, JPG, PNG, TIFF és más formátumokba magas pontossággal és teljesítménnyel.

### Szükséges a Microsoft PowerPoint az Aspose.Slides használatához?

Nem. Az Aspose.Slides egy önálló API, és nem igényel Microsoft Office‑t vagy más külső szoftvert.

### Milyen platformokat támogat az Aspose.Slides for Python via .NET?

Keresztplatformos, és működik Windows, Linux és macOS környezetekben.

### Hogyan kezdjek hozzá az Aspose.Slides for Python használatához?

Telepítheti a PyPi‑n keresztül, és felfedezheti a [Fejlesztői útmutatót](/slides/hu/python-net/developer-guide/) a példákkal, API hivatkozásokkal és oktatóanyagokkal.