---
title: Prezentációk konvertálása HTML5-re Pythonban
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/python-net/export-to-html5/
keywords:
- PowerPoint HTML5-re
- OpenDocument HTML5-re
- előadás HTML5-re
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
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument előadásokat reszponzív HTML5 formátumba az Aspose.Slides for Python via .NET segítségével. Megőrizze a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint előadásokat HTML5 formátumba konvertálni az Aspose.Slides for Python via .NET használatával. Lefedi az alapvető exportálást, az alakzatanimációk és diáátmenetek vezérlését, valamint a megjegyzések elrendezését. Emellett összehasonlítja a HTML5 kimenetet a szabványos HTML export SVG-alapú kimenetével.

## **PowerPoint exportálása HTML5-be**

A következő példa betölt egy előadást a munkakönyvtárból, és HTML5 formátumban menti el. Alapértelmezett exportbeállításokat használ; a következő példa azt mutatja be, hogyan lehet kifejezetten vezérelni az animáció lejátszását. Cserélje le a bemeneti útvonalat a saját előadásának útvonalára.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Megjegyzés" %}}
A HTML-dokumentum mellett az exportálás támogatási CSS és JavaScript fájlokat is ír a diák stílusához, animációkhoz, hatásokhoz és navigációhoz. Tartsa meg ezeket a fájlokat a HTML-dokumentummal együtt a kimenet áthelyezésekor vagy közzétételekor. A generált oldal a jQuery és az Anime.js könyvtárakat is betölti nyilvános CDN-kről; ezek nélkül a dia-navigáció és az animációk nem fognak működni.
{{% /alert %}}

Az alakzatanimációk vagy a diáátmenetek lejátszása nélküli exportáláshoz állítsa a [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) és a [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) értékét `False`-ra a [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/)-ban. Ezek a beállítások függetlenek, így egyet engedélyezhet, miközben a másikat letiltja. A példa az előadást exportálja úgy, hogy mindkét animációtípust letiltja a generált oldalon.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **PowerPoint exportálása HTML-be**

A szabványos HTML-exportálás más megjelenítési megközelítést alkalmaz: a dia tartalmát SVG-ként jeleníti meg egy HTML-oldalon. A következő példa egy előadást HTML-dokumentummá konvertál ennek a megjelenítési módnak a használatával.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Az alábbi egyszerűsített jelölőnyelv a generált oldal szerkezetét mutatja be. Az SVG elem tartalmazza a renderelt dia tartalmát; a helyőrző szöveg ezt a tartalmat ábrázolja, és nem a tényleges exportkimenet.

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
Az SVG-alapú exportálás nem teszi elérhetővé a PowerPoint alakzatokat különálló HTML elemekként. Használja a HTML5 exportálást, ha a cikkben bemutatott alakzat-animációs és dia-átmeneti beállításokra van szükség.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia nézetben**

A HTML5 export egy oldalt hoz létre a bemutató diáinak böngészőben történő megtekintéséhez és navigálásához. Ez a példa engedélyezi mind a [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) és a [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) opciókat, hogy az exportált dia nézet lejátszhassa a forrás előadás hatásait.

Használjon olyan előadást, amely már tartalmaz alakzatanimációkat és diáátmeneteket, hogy lássa ezen beállítások hatását. Ezek engedélyezése nem ad hozzá új hatásokat a diákhoz, amelyeknek korábban nem voltak. Exportálás után nyissa meg a generált HTML5 dokumentumot egy böngészőben, a szükséges támogatási fájlok rendelkezésre állásával.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Az előadás konvertálása HTML5 dokumentummá megjegyzésekkel**

A meglévő dia megjegyzéseket beillesztheti a HTML5 kimenetbe, így az olvasók a visszajelzéseket a dia tartalma mellett láthatják. Ennek a szakasznak a példája azt feltételezi, hogy a forrás előadás megjegyzéseket tartalmaz, ahogy az alább látható. Ezeket a megjegyzéseket exportálja; újakat nem hoz létre.

![Két megjegyzés a bemutató dián](two_comments_pptx.png)

Rendeljen egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) objektumot a [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) tulajdonsághoz a [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/)- esetén. Állítsa a [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) értékét `RIGHT`-re a [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) felsorolásból, hogy a megjegyzéseket az egyes diák jobb oldalára helyezze.

A következő példa exportálja az előadást HTML5-be ezzel a megjegyzéselrendezéssel. A megjegyzésekkel nem rendelkező előadásnak nem lesz megjeleníthető megjegyzés szövege.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

Az alábbi kép az exportált HTML5 dokumentumot mutatja, ahol a megjegyzések a dia mellett jelennek meg.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **JavaScript hivatkozások kizárása exportálás közben**

Tegyük fel, hogy a `hyperlinks.pptx` egy `javascript:alert('Hello')` célú hivatkozott szöveget és egy egyszerű `https://example.com/` hivatkozást tartalmaz. A JavaScript hivatkozás kizárásához exportáláskor állítsa a [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) értékét `True`-ra. Alapértelmezés szerint `False`, így ezek a linkek nem szűrődnek le, hacsak nem engedélyezi a beállítást.

A következő példa betölti az előadást a munkakönyvtárból, és [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) használatával exportálja:

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Az exportált fájl kihagyja a JavaScript hivatkozást, miközben megtartja annak szövegét és a hagyományos HTTPS hivatkozást. A forrás előadás változatlan marad.

Ez a beállítás a JavaScript hivatkozásokat szűri; nem távolít el minden scriptet vagy más aktív tartalmat, és nem garantálja a CSP megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz scriptet a dia-navigációhoz és az animációkhoz.

## **GYIK**

**Le tudom-e szabályozni, hogy az objektumanimációk és a diáátmenetek lejátszódjanak-e HTML5-ben?**

Igen, a HTML5 export különálló lehetőségeket kínál a [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) és a [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) engedélyezésére vagy letiltására.

**Támogatottak a megjegyzések, és hol lehet őket elhelyezni a diahoz képest?**

Igen, a meglévő megjegyzések beilleszthetők a HTML5 kimenetbe, és elhelyezhetők (például a dia jobb oldalán) a [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) használatával a jegyzetek és megjegyzések számára.

**Kihagyhatom-e a JavaScript-et meghívó hivatkozásokat biztonsági vagy CSP okokból?**

Igen, a [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) beállítás lehetővé teszi, hogy a mentés során kihagyja a JavaScript hívásokat tartalmazó hivatkozásokat. Alapértelmezés szerint `False`. Lásd a [JavaScript hivatkozások kizárása exportálás közben](/slides/hu/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) szakaszt egy HTML5 exportálási példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 megjelenítő által a navigációhoz és animációkhoz használt JavaScriptet.