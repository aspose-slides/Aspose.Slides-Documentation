---
title: Prezentációk konvertálása HTML5-re Pythonon keresztül Java használatával
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
- PPT exportálása HTML5-be
- PPTX exportálása HTML5-be
- ODP exportálása HTML5-be
- Python
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-be az Aspose.Slides for Python via Java segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk azt mutatja be, hogyan lehet a PowerPoint‑prezentációkat HTML5 formátumba konvertálni az Aspose.Slides for Python via Java használatával. Leírja az alap exportálást, az alakzatanimációk és diaátmenetek vezérlését, valamint a megjegyzéselrendezést. Emellett összehasonlítja a HTML5 kimenetet a szabványos HTML export SVG‑alapú kimenetével.

A példákhoz szükséges az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet. Helyezze a bemeneti prezentációkat az aktuális munkakönyvtárba. Minden példa csak akkor indítja el a JVM‑et, ha az még nem fut.

## **PowerPoint exportálása HTML5‑be**

A következő példa betölti a prezentációt a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa bemutatja, hogyan lehet kifejezetten vezérelni az animáció lejátszását. Cserélje le a bemeneti útvonalat a saját prezentációjának útvonalára.

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

{{% alert color="info" title="Note" %}}
Az HTML‑dokumentum mellett az exportálás CSS és JavaScript fájlokat is létrehozza a dia stílusozásához, animációkhoz, hatásokhoz és navigációhoz. Ezeket a fájlokat a HTML‑dokumentummal együtt kell tartani, amikor a kimenetet áthelyezi vagy közzéteszi. A generált oldal továbbá a publikus CDN‑ről tölti be a jQuery‑t és az Anime.js‑t; ezek hiányában a dia navigáció és az animációk nem működnek.
{{% /alert %}}

Az alakzatanimációk vagy diaátmenetek lejátszása nélküli exportáláshoz adja át a `False` értéket a [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) és a [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) metódusoknak a [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) példányban. Ezek a beállítások függetlenek, így az egyiket engedélyezheti, míg a másikat letiltja. A példa a prezentációt a generált oldalon mindkét animációtípus letiltásával exportálja.

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint exportálása HTML‑be**

A szabványos HTML export más renderelési megközelítést használ: a dia tartalma SVG‑ként jelenik meg egy HTML‑oldalon belül. A következő példa egy prezentációt HTML‑dokumentummá konvertál ezzel a renderelési módszerrel.

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

Az alábbi egyszerűsített jelölés bemutatja a generált oldal felépítését. Az SVG elem a renderelt dia tartalmát tartalmazza; a helyőrző szöveg ezt a tartalmat jelöli, és nem a tényleges exportkimenetet.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Az SVG‑alapú export nem teszi elérhetővé a PowerPoint alakzatokat egyedi HTML elemekként. Használjon HTML5 exportot, ha az ebben a cikkben bemutatott alakzat‑animációs és dia‑átmeneti beállításokra van szükség.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia nézetbe**

A HTML5 export egy olyan oldalt hoz létre, amely a böngészőben a prezentáció diái megtekintésére és navigálására szolgál. Ez a példa engedélyezi a [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) és a [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) beállításokat, hogy az exportált dia nézet le tudja játszani a forrásprezentációban található hatásokat.

Használjon olyan prezentációt, amely már tartalmaz alakzatanimációkat és diaátmeneteket, hogy lássa ezen beállítások hatását. Ezek bekapcsolása nem ad hozzá új hatásokat a diákhoz, amelyeknek egyáltalán nincs animációja. Exportálás után nyissa meg a generált HTML5 dokumentumot egy böngészőben, a támogatásra szolgáló fájlok elérhetőségével.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A HTML5 kimenetbe beilleszthetők a meglévő dia‑megjegyzések, így az olvasók a dia tartalmával együtt láthatják a visszajelzéseket. A szekcióban szereplő példa feltételezi, hogy a forráspresentáció megjegyzéseket tartalmaz, ahogyan az alább is szemléltetve van. A megjegyzéseket exportálja; újakat nem hoz létre.

![Two comments on the presentation slide](two_comments_pptx.png)

Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) metódusnak a [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) példányban. Használja a [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) metódust, hogy a [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) felsorolásból a `Right` értéket válassza, így a megjegyzések a dia jobb oldalán jelennek meg.

A következő példa a prezentációt HTML5 formátumban exportálja ezzel a megjegyzéselrendezéssel. A megjegyzéseket nem tartalmazó prezentáción nem jelenik meg megjegyzésszöveg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Az alábbi kép mutatja a exportált HTML5 dokumentumot, ahol a megjegyzések a dia mellett jelennek meg.

![The comments in the output HTML5 document](two_comments_html5.png)

## **JavaScript hiperhivatkozások kizárása exportálás közben**

Tegyük fel, hogy a `hyperlinks.pptx` olyan szöveggel rendelkezik, amelynek célja egy `javascript:alert('Hello')` hivatkozás, valamint egy szokásos `https://example.com/` link. A JavaScript hivatkozás kizárásához exportáláskor adja át a `True` értéket a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) metódusnak. Alapértelmezés szerint `False`, ezért ezek a linkek nem lesznek szűrve, hacsak nem kapcsolja be a beállítást.

A következő példa betölti a prezentációt a munkakönyvtárból, és a [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) használatával exportálja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Az exportált fájl kihagyja a JavaScript hivatkozást, miközben megtartja a szövegét és a szokásos HTTPS linket. A forrásprezentáció változatlan marad.

Ez a beállítás szűri a JavaScript hivatkozásokat; nem távolít el minden scriptet vagy egyéb aktív tartalmat, és nem garantálja a CSP megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz scripteket a dia navigációhoz és animációkhoz.

## **GYIK**

**Kezelhetem, hogy az objektumanimációk és a diaátmenetek lejátszódjanak‑e a HTML5‑ben?**

Igen, a HTML5 export különálló beállításokkal rendelkezik a [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) és a [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) engedélyezésére vagy letiltására.

**Támogatottak a megjegyzések, és hol helyezhetők el a dia viszonyítva?**

Igen, a meglévő megjegyzések belefoglalhatók a HTML5 kimenetbe, és a [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) segítségével (például a dia jobb oldalán) elhelyezhetők.

**Kihagyhatom‑e azokat a linkeket, amelyek JavaScript‑et hívnak meg biztonsági vagy CSP‑ok miatt?**

Igen, a [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) beállítás lehetővé teszi, hogy a mentés során kihagyja a JavaScript‑hívásokat tartalmazó hiperhivatkozásokat. Alapértelmezés szerint `False`. Lásd a [JavaScript hiperhivatkozások kizárása exportálás közben](/slides/hu/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) példát a HTML5 exporthoz és a szűrő hatóköréhez. Ez a beállítás nem távolítja el a HTML5 megjelenítőben a navigációhoz és animációkhoz használt JavaScript‑et.