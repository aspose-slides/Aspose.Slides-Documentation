---
title: PPTX konvertálása PPT-re Pythonban
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/python-java/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPTX konvertálása
- PPTX PPT-re
- PPTX mentése PPT-ként
- PPTX exportálása PPT-be
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "PPTX konvertálása a régi PPT formátumba Pythonban az Aspose.Slides for Python via Java segítségével. Tartalmaz kódrészletet és megjegyzéseket a kompatibilitásról és a védett fájlokról."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy egy PPTX prezentációt konvertáljon a PowerPoint 97–2003 által használt régi PPT formátumba anélkül, hogy a Microsoft PowerPoint telepítve lenne. Töltse be a PPTX fájlt, és mentse PPT kimeneti formátummal, ahogy az alább látható.

## **PPTX konvertálása PPT-re**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a kimeneti úttal és a [SaveFormat.Ppt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Ppt) paraméterrel.

Az alábbi példa elindítja a Java virtuális gépet, ha szükséges, és a `template.pptx` fájlt `output.ppt`-re konvertálja az alapértelmezett beállításokkal. Cserélje ki az elérési útvonalakat a saját fájlneveire. A `finally` blokk felszabadítja a prezentáció erőforrásait még akkor is, ha a mentés sikertelen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Tölti be a PPTX prezentációt.
presentation = Presentation("template.pptx")
try:
    # Mentse a prezentációt PPT formátumban.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

A [SaveFormat.Ppt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Ppt) argumentum válassza ki a kimeneti formátumot; csak a fájl kiterjesztésének módosítása nem konvertálja a prezentációt. Tartsa meg az eredeti PPTX fájlt, hogy visszatérhessen hozzá, ha egy újabb funkciónak nincs megfelelője a PPT-ben.

## **PPTX konvertálása más formátumokra**

Az Aspose.Slides további kimeneti formátumokat is támogat. Tekintse meg a megfelelő cikkeket a formátum-specifikus beállítások és példák tekintetében:

- [PowerPoint konvertálása PDF-be Pythonban](/slides/hu/python-java/convert-powerpoint-to-pdf/)
- [PowerPoint konvertálása XPS-re Pythonban](/slides/hu/python-java/convert-powerpoint-to-xps/)
- [PowerPoint konvertálása HTML-re Pythonban](/slides/hu/python-java/convert-powerpoint-to-html/)
- [Prezentációk mentése ODP-ként Pythonban](/slides/hu/python-java/save-presentation/)
- [PowerPoint konvertálása PNG-re Pythonban](/slides/hu/python-java/convert-powerpoint-to-png/)

## **GYIK**

**Minden PPTX hatás és funkció megmarad a PPT-re történő konvertálás során?**

Nem mindig. A régi PPT formátum nem támogat minden, a PPTX-ben elérhető funkciót. Egyes hatások, objektumok vagy viselkedések egyszerűsödhetnek vagy másként jelenhetnek meg. Ellenőrizze a konvertált prezentációt a célzott megjelenítőben, különösen akkor, ha újabb PowerPoint funkciókat tartalmaz.

**Csak a kiválasztott diák konvertálhatók PPT-re?**

A PPT mentése az egész prezentációt írja ki. Kiválasztott diák konvertálásához hozzon létre egy új prezentációt, távolítsa el annak kezdeti üres diáját, klónozza a szükséges diákot bele, majd mentse PPT-ként. Lásd a [Diák klónozása Pythonban](/slides/hu/python-java/clone-slides/).

**Jelszóval védett PPTX fájlt konvertálhatok?**

Igen, ha a forrás prezentáció betöltésekor megadja a megfelelő jelszót. A kimeneti fájl védelmét is konfigurálhatja. Lásd a [Jelszóval védett prezentációk](/slides/hu/python-java/password-protected-presentation/) cikket.