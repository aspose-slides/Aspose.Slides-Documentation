---
title: PDF dokumentumok szerkesztése Pythonon keresztül Java segítségével
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/python-java/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF PPTX-re
- PPTX PDF-re
- Python
- Java
- Aspose.Slides
description: "PDF dokumentumok szerkesztése Pythonon keresztül Java segítségével, azokat az Aspose.Slides-ba importálva, a szöveg cseréjével, és a módosított bemutató vissza PDF-be mentésével."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi a PDF tartalom szerkesztését az oldalak diaként történő importálásával, a bemutató módosításával és a visszaexportálással PDF-be. Ez a cikk egy egyszerű szövegcsere példáját mutatja be. A bemutató a memóriában marad, így a köztes PPTX fájl mentése opcionális.

## **Szöveg cseréje PDF-ben**

Használja az [addFromPdf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromPdf) metódust az oldalak importálásához, a [replaceText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#replaceText) metódust a szöveg frissítéséhez, és a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust az eredmény exportálásához.

A következő példa azt feltételezi, hogy az `input.pdf` a "Draft" szót szerkeszthető szövegként tartalmazza az importálás után. A "Draft" szót "Final"-re cseréli, és az `edited.pdf` fájlt írja ki. Az első dia törlése az importálás előtt megakadályozza, hogy a kimenetben egy extra üres oldal jelenjen meg. A keresés teljes szavakat egyezik meg ugyanazzal a kis- és nagybetűkkel; a `None` azt jelenti, hogy nincs szükség eredmény‑visszahívásra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

További beállításokért lásd a [Keresés és csere szöveg](/slides/hu/python-java/search-and-replace-text/) és a [PowerPoint konvertálása PDF-be](/slides/hu/python-java/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere importált szövegen működik, nem a beolvasott képek szövegén. A konverzió befolyásolhatja az elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen ha a helyettesítő szöveg hosszabb az eredetinél.
{{% /alert %}}

## **GYIK**

**Mentsek PPTX fájlt a PDF exportálása előtt?**

Nem. A bemutatót közvetlenül a memóriában szerkesztheti és exportálhatja. PPTX másolatot csak akkor mentse, ha továbbra is PowerPointban szeretné szerkeszteni; lásd a [Prezentációk mentése](/slides/hu/python-java/save-presentation/) oldalt.

**Miért maradhat néhány szöveg változatlan?**

A példa a "Draft" teljes szót pontos kis- és nagybetűkkel egyezteti. Az image‑ként importált vagy különálló szövegdobozokba szétrágolt szöveg nem feltétlenül egyezik a kereséssel. Ellenőrizze az importált tartalmat, és módosítsa a keresést a dokumentumához.