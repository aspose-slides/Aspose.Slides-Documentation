---
title: Prezentációk konvertálása HTML5-re Pythonban Java használatával
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/python-java/export-to-html5/
keywords:
- PowerPoint HTML5-re
- OpenDocument HTML5-re
- prezentáció HTML5-re
- dia HTML5-re
- PPT HTML5-re
- PPTX HTML5-re
- ODP HTML5-re
- PPT mentése HTML5-ként
- PPTX mentése HTML5-ként
- ODP mentése HTML5-ként
- PPT exportálása HTML5-re
- PPTX exportálása HTML5-re
- ODP exportálása HTML5-re
- Python
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for Python via Java segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint-prezentációkat HTML5-re konvertálni az Aspose.Slides segítségével. Kitér a webes kiterjesztések nélküli alapvető HTML5 exportálásra, valamint a formaanimációk és diaátmenetek vezérlésének lehetőségeire. A cikk a szabványos PowerPoint‑HTML exportfolyamatot is bemutatja, ismerteti, hogyan állítható elő HTML5 kimenet dia nézet módban, és megmutatja, hogyan vehetők fel a megjegyzések az exportált dokumentumba a elrendezés konfigurálásával.

A példákhoz szükség van az Aspose.Slides for Python via Java csomagra és egy kompatibilis Java futtatókörnyezetre. Helyezd a `pres.pptx` (vagy a megjegyzéses példához a `sample.pptx`) fájlt az aktuális munkakönyvtárba. Minden példa csak akkor indítja el a JVM‑et, ha az még nincs futásban.

## **PowerPoint exportálása HTML5‑re**

Használd a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Html5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Html5) formátummal, hogy a prezentációt webes kiterjesztések nélkül exportáld:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}} 
Az HTML5 exportáló HTML‑tartalmat hoz létre a böngészőben történő megjelenítéshez. 
{{% /alert %}}

A [Html5Options](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/) használatával konfigurálható az export. A [setAnimateShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateShapes) és a [setAnimateTransitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateTransitions) meghívásával `False` értékkel letilthatók a formaanimációk és a diaátmenetek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint exportálása HTML‑re**

Használd a [SaveFormat.Html](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Html) formátumot a szabványos HTML exporthoz. További lehetőségekért lásd a [Convert PowerPoint to HTML](/slides/hu/python-java/convert-powerpoint-to-html/) oldalt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Ebben az esetben a prezentáció tartalma SVG‑vel kerül renderelésre a következő módon:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Figyelmeztetés" color="warning" %}} 
A szabványos HTML export SVG‑n keresztül jeleníti meg a dia tartalmát, és nem biztosítja a HTML5‑os forma‑animációk és dia‑átmenetek beállításait. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia nézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertálj, amelyben a diák dia nézet módban jelennek meg. Ebben az esetben, amikor a létrehozott HTML5 fájlt böngészőben nyitod meg, a prezentációt a weboldalon dia nézetben láthatod.

Ez a Python‑kód bemutatja a PowerPoint‑HTML5 dia‑nézet export folyamatát:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Prezentációk konvertálása HTML5 dokumentummá megjegyzésekkel**

A PowerPoint‑megjegyzések olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy megjegyzéseket vagy visszajelzéseket hagyjanak a prezentáció diáiban. Különösen hasznosak együttműködési projektekben, ahol több ember adhat hozzá saját javaslatait vagy észrevételeit a diák egyes elemeihez anélkül, hogy a fő tartalmat módosítanák. Minden megjegyzés megjeleníti a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a „sample.pptx” fájlban a következő PowerPoint‑prezentáció található.

![Két megjegyzés a prezentáció diáján](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertálsz, egyszerűen megadhatod, hogy a bemeneti prezentáció megjegyzései szerepeljenek-e a kimeneti dokumentumban. Ehhez add át a megjegyzések megjelenítési paramétereit a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) metódusnak a [Html5Options](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/) osztályból.

Használd a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) és a [setCommentsPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) metódust a [CommentsPositions.Right](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentspositions/#Right) értékkel. Az alábbi kódrészlet egy prezentációt konvertál HTML5 dokumentummá, amelyben a megjegyzések a diák jobb oldalán jelennek meg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Az „output.html” dokumentum az alábbi képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

**Le tudom-e szabályozni, hogy az objektumanimációk és diaátmenetek lejátszódjanak‑e HTML5‑ben?**

Igen, a HTML5 külön lehetőséget biztosít a [shape animations](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateShapes) és a [slide transitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateTransitions) engedélyezésére vagy letiltására.

**Exportálhatók a megjegyzések, és hol helyezhetők el a diahoz képest?**

Igen, a megjegyzések hozzáadhatók HTML5‑ben, és például a dia jobb oldalára pozicionálhatók a [layout settings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) segítségével a jegyzetek és megjegyzések beállításánál.

**Kihagyhatok‑e olyan hivatkozásokat, amelyek JavaScript‑et hívnak a biztonság vagy CSP okokból?**

Igen, létezik egy [setting](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), amely lehetővé teszi, hogy mentéskor kihagyjuk a JavaScript‑hívásokat tartalmazó hiperhivatkozásokat. Ez eltávolítja ezeket a hivatkozásokat; azonban önmagában nem garantálja, hogy minden generált HTML5‑szkript megfelel a webhely Content Security Policy‑jának.