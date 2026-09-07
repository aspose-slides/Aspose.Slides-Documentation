---
title: PowerPoint prezentációk konvertálása XPS-re Pythonban
linktitle: PowerPoint XPS-re
type: docs
weight: 70
url: /hu/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint XPS-re
- prezentáció XPS-re
- PPT XPS-re
- PPTX XPS-re
- PPT mentése XPS-ként
- PPTX mentése XPS-ként
- PPT exportálása XPS-be
- PPTX exportálása XPS-be
- Python
- Java
- Aspose.Slides
description: "PowerPoint PPT és PPTX prezentációk konvertálása XPS-re Pythonban az Aspose.Slides for Python via Java használatával, alapértelmezett vagy egyéni export beállításokkal."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy PowerPoint prezentációkat XPS-be konvertáljon, egy PPT vagy PPTX fájlt XPS formátumban elmentve. Ez a cikk elmagyarázza, mikor lehet hasznos az XPS, és bemutatja, hogyan exportáljon egy prezentációt alapértelmezett vagy egyéni [XpsOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xpsoptions/) beállításokkal.

## **Az XPS-ről**

Az XPS (XML Paper Specification) egy Microsoft által kifejlesztett XML-alapú dokumentumformátum. Rögzített oldalakat ír le, megőrizve a szöveg és a grafika elrendezését a megjelenítéshez és nyomtatáshoz kompatibilis szoftverekkel.

## **Mikor használjuk a Microsoft XPS formátumot**

Használja az XPS-t, amikor egy dokumentumfolyamat rögzített elrendezésű fájlokat igényel a megosztáshoz vagy nyomtatáshoz XPS‑kompatibilis eszközökön keresztül. A címzetteknek olyan szoftverre van szükségük, amely támogatja az XPS-t. Ha a munkafolyamat inkább PDF-et igényel, lásd a [Convert PowerPoint to PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Megjegyzés" %}}
A PPT vagy PPTX prezentáció XPS-re konvertálásának kipróbálásához használja az [ingyenes online konvertert](https://products.aspose.app/slides/hu/conversion).
{{% /alert %}}

| Bemeneti PowerPoint prezentáció | Kimeneti XPS dokumentum |
| --- | --- |
| ![Eredeti PowerPoint prezentáció](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Prezentáció XPS-re konvertálva](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **XPS konvertálás az Aspose.Slides segítségével**

Használja a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályon a [SaveFormat.Xps](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Xps) értékkel a prezentáció exportálásához. Használhatja az alapértelmezett exportbeállításokat, vagy megadhatja a [XpsOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xpsoptions/) objektumot a kimenet testreszabásához.

Minden alábbi példa szükség esetén elindítja a Java virtuális gépet, és a használat után felszabadítja a prezentációt. Cserélje le a bemeneti fájlnevet a saját PPT vagy PPTX fájlja elérési útjára.

### **Prezentációk konvertálása XPS-re alapértelmezett beállításokkal**

Az alábbi Python kód konvertál egy prezentációt XPS-re alapértelmezett beállításokkal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Mentse a prezentációt XPS dokumentumként.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Prezentációk konvertálása XPS-re egyéni beállításokkal**

Az alábbi példa a [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) metódust használja, hogy a metafájlok PNG képek legyenek a létrehozott XPS dokumentumban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Mentse a prezentációt az egyéni XPS beállításokkal.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **GYIK**

**Menthetek XPS-t adatfolyamba fájl helyett?**

Igen. A [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak vannak olyan túlterhelései, amelyek Java kimeneti áramlattal dolgoznak. Python via Java esetén használjon kompatibilis Java áramlatot a JPype-en keresztül, például egy Java byte‑array output streamet, hogy a exportált adat memória‑beli maradjon.

**A rejtett diák szerepelnek az XPS kimenetben?**

A rejtett diák alapértelmezés szerint kizárásra kerülnek. Ha szeretné őket belefoglalni, állítsa be a [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) értékét `True` mentés előtt.

**Megőrződnek-e az animációk és diaátmenetek az XPS-ben?**

Nem. Az XPS rögzített oldalakat tartalmaz, így az exportált diák nem játszanak le animációkat vagy átmeneti effektusokat.