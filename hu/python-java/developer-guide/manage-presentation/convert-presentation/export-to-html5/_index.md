---
title: Prezentációk konvertálása HTML5-re Pythonon keresztül Java-val
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

Ez a cikk elmagyarázza, hogyan lehet a PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides segítségével. Lefedi az alap HTML5 exportot további webkiterjesztések nélkül, valamint a formaanimációk és diaátmenetek vezérlésének beállításait. A cikk bemutatja a szabványos PowerPoint‑HTML export folyamatát, elmagyarázza, hogyan állítható elő HTML5 kimenet dianézet módban, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni az exportált dokumentumhoz a layout konfigurálásával.

A példák az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet használatát igénylik. Helyezze a `pres.pptx` (vagy a megjegyzések példához a `sample.pptx`) fájlt az aktuális munkakönyvtárba. Minden példa csak akkor indítja el a JVM‑et, ha az még nem fut.

## **PowerPoint exportálása HTML5‑re**

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) funkciót a [SaveFormat.Html5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Html5) opcióval, hogy kiegészítő webkiterjesztések nélkül exportáljon egy prezentációt:

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
A HTML5 exportáló HTML tartalmat hoz létre, amely böngészőben megtekinthető. 
{{% /alert %}}

Használja a [Html5Options](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/) osztályt az export konfigurálásához. Hívja a [setAnimateShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateShapes) és a [setAnimateTransitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateTransitions) metódusokat `False` értékkel az alakzatanimációk és diaátmenetek letiltásához:

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

Használja a [SaveFormat.Html](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Html) opciót a szabványos HTML exporthoz. További beállításokért tekintse meg a [PowerPoint konvertálása HTML‑re](/slides/hu/python-java/convert-powerpoint-to-html/) oldalt:

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

Ebben az esetben a prezentáció tartalma SVG‑n keresztül jelenik meg, a következő módon:

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
A szabványos HTML export a dia tartalmát SVG‑n keresztül jeleníti meg, és nem biztosítja a HTML5 alakzatanimáció és diaátmenet lehetőségeket. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia nézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertáljon, amelyben a diák dia‑nézet módban jelennek meg. Ebben az esetben, ha a létrejött HTML5 fájlt böngészőben nyitja meg, a prezentációt a weboldalon dia‑nézet módban láthatja.

Ez a Python kód bemutatja a PowerPoint‑HTML5 dia‑nézet export folyamatát:

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

## **Prezentációk konvertálása HTML5 dokumentumokká megjegyzésekkel**

Megjegyzések a PowerPoint‑ban egy eszköz, amely lehetővé teszi a felhasználók számára, hogy megjegyzéseket vagy visszajelzést hagyjanak a prezentáció diáin. Különösen hasznosak együttműködő projektekben, ahol több személy adhat hozzá javaslatokat vagy megjegyzéseket a diák adott elemeihez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés megjeleníti a szerző nevét, ami megkönnyíti annak nyomon követését, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentáció a "sample.pptx" fájlban van tárolva.

![Két megjegyzés a prezentáció diáján](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertál, könnyen megadhatja, hogy a prezentáció megjegyzései belekerüljenek-e a kimeneti dokumentumba. Ehhez adja át a megjegyzések megjelenítési paramétereit a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) metódusnak a [Html5Options](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/) osztályon keresztül.

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) és a [setCommentsPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) metódusokat a [CommentsPositions.Right](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentspositions/#Right) értékkel. A következő kódrészlet egy prezentációt HTML5 dokumentummá konvertál, ahol a megjegyzések a diák jobb oldalán jelennek meg.

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

Az "output.html" dokumentum az alábbi képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **FAQ**

**Korlátozhatom, hogy az objektumanimációk és diaátmenetek lejátszódjanak-e HTML5‑ben?**

Igen, a HTML5 különálló beállításokat biztosít a [shape animations](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateShapes) és a [slide transitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateTransitions) engedélyezéséhez vagy letiltásához.

**Támogatott‑e a megjegyzések kimenete, és hol helyezhetők el a diához képest?**

Igen, a megjegyzéseket hozzáadhatja HTML5‑ben, és elhelyezheti (például a dia jobb oldalán) a [layout settings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) (elrendezési beállítások) segítségével.

**Átugorhatom‑e azokat a hivatkozásokat, amelyek JavaScriptet hívnak meg biztonsági vagy CSP okokból?**

Igen, van egy [setting](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) amely lehetővé teszi, hogy a mentés során kihagyja a JavaScript‑hívásokat tartalmazó hiperhivatkozásokat. Ez eltávolítja az ilyen hivatkozásokat; azonban önmagában nem garantálja, hogy az összes generált HTML5 szkript megfelel a webhely Content Security Policy‑jének.