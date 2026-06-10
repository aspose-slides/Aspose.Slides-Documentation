---
title: Prezentációk konvertálása HTML5-re Pythonban
linktitle: Exportálás HTML5-re
type: docs
weight: 40
url: /hu/python-net/export-to-html5/
keywords:
- PowerPoint HTML5-re
- OpenDocument HTML5-re
- prezentáció HTML5-re
- dia HTML5-re
- PPT HTML5-re
- PPTX HTML5-re
- ODP HTML5-re
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
- dia konvertálása
- HTML5 export
- prezentáció exportálása
- dia exportálása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for Python via .NET segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint előadásokat HTML5 formátumba konvertálni az Aspose.Slides használatával. Kitér az egyszerű HTML5 exportálásra webes kiegészítők vagy további függőségek nélkül, valamint a formák animációinak és diaátmenetek vezérlésére szolgáló beállításokra. A cikk továbbá bemutatja a szokásos PowerPoint‑HTML exportfolyamatot, elmagyarázza, hogyan generálható HTML5 kimenet dia‑nézet módban, és megmutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba az elrendezés beállításával.

## **PowerPoint exportálása HTML5-re**

Ez a Python kód bemutatja, hogyan exportálhatunk egy előadást HTML5 formátumba webes kiegészítők és függőségek nélkül:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}}Ebben az esetben tiszta HTML-et kapunk.{{% /alert %}}

Az alábbi módon adhatja meg a formák animációi és a diaátmenetek beállításait:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **PowerPoint exportálása HTML-re**

Ez a Python kód bemutatja a szokásos PowerPoint‑HTML exportfolyamatot:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

Ebben az esetben az előadás tartalma SVG‑ként kerül renderelésre a következő módon:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Megjegyzés" color="warning" %}}Ha ezzel a módszerrel exportálja a PowerPointot HTML-re, az SVG renderelés miatt nem lesz lehetőség stílusok alkalmazására vagy egyes elemek animálására.{{% /alert %}}

## **PowerPoint exportálása HTML5 dia‑nézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint előadást HTML5 dokumentummá konvertáljon, ahol a diák dia‑nézet módban jelennek meg. Ebben az esetben, ha a kapott HTML5 fájlt egy böngészőben nyitja meg, a prezentációt dia‑nézetben láthatja a weboldalon.

Ez a Python kód bemutatja a PowerPoint‑HTML5 dia‑nézet exportfolyamatát:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportáljon egy prezentációt, amely diák átmeneteket, animációkat és alakzat animációkat tartalmaz HTML5-be
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Prezentáció mentése
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A PowerPoint megjegyzések olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyanak a prezentáció diáin. Különösen együttműködési projektekben hasznosak, ahol több ember is hozzáadhatja javaslatait vagy megjegyzéseit a diákat érintő elemekhez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés megjeleníti a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint prezentáció a "sample.pptx" fájlban van elmentve.

![Két megjegyzés a prezentáció dián](two_comments_pptx.png)

Amikor egy PowerPoint előadást HTML5 dokumentummá konvertál, egyszerűen megadhatja, hogy a megjegyzéseket felvegye-e a kimeneti dokumentumba. Ehhez a `notes_comments_layouting` tulajdonságban kell megadni a megjegyzések megjelenítési paramétereit a [Html5Options](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/) osztályban.

A következő kódrészlet egy prezentációt HTML5 dokumentummá konvertál, ahol a megjegyzések a diák jobb oldalán jelennek meg.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Az "output.html" dokumentum az alábbi képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **FAQ**

**Ellenőrizhetem, hogy az objektumanimációk és diaátmenetek lejátszódnak-e HTML5-ben?**

Igen, a HTML5 külön beállításokat biztosít a [forma animációk](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_shapes/) és a [diaátmenetek](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_transitions/) engedélyezésére vagy letiltására.

**Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a diahoz képest?**

Igen, a megjegyzések hozzáadhatók HTML5-ben, és elhelyezhetők (például a dia jobb oldalán) a [elrendezési beállítások](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/notes_comments_layouting/) segítségével a jegyzetek és megjegyzések számára.

**Kihagyhatom-e azokat a hivatkozásokat, amelyek JavaScript‑et hívnak meg biztonsági vagy CSP okokból?**

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/skip_java_script_links/), amely lehetővé teszi, hogy a mentés során kihagyja a JavaScript‑hívással rendelkező hiperhivatkozásokat. Ez segít a szigorú biztonsági szabályok betartásában.