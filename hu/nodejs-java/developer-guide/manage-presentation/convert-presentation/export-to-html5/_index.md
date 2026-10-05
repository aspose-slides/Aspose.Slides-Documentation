---
title: Convert Presentations to HTML5 in JavaScript
linktitle: Presentation to HTML5
type: docs
weight: 40
url: /hu/nodejs-java/export-to-html5/
keywords:
- PowerPoint to HTML5
- OpenDocument to HTML5
- presentation to HTML5
- slide to HTML5
- PPT to HTML5
- PPTX to HTML5
- ODP to HTML5
- save PPT as HTML5
- save PPTX as HTML5
- save ODP as HTML5
- export PPT to HTML5
- export PPTX to HTML5
- export ODP to HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "Export PowerPoint & OpenDocument presentations to responsive HTML5 with Aspose.Slides for Node.js. Preserve formatting, animations, and interactivity."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides for Node.js for Java segítségével. Tárgyalja az alapvető exportálást, az alakzatanimációk és diaváltások vezérlését, valamint a megjegyzések elrendezését. Emellett összehasonlítja a HTML5 kimenetet a standard HTML export SVG‑alapú kimenetével.

## **PowerPoint exportálása HTML5-re**

Az alábbi példa betölt egy prezentációt a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa azt mutatja be, hogyan lehet kifejezetten vezérelni az animáció lejátszását. Cserélje le a bemeneti útvonalat a saját prezentációja útvonalára.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A HTML dokumentum mellett az export a diák megjelenítéséhez, animációkhoz, effektusokhoz és navigációhoz szükséges CSS és JavaScript fájlokat is ír. Tartsa meg ezeket a fájlokat a HTML dokumentummal együtt, amikor áthelyezi vagy közzéteszi a kimenetet. A generált oldal a jQuery‑t és az Anime.js‑t is betölti nyilvános CDN‑ről; ezek nélkül a diánakavigáció és az animációk nem futnak.
{{% /alert %}}

Az alakzatanimációk vagy diaváltások lejátszása nélküli exportáláshoz adjon át `false` értéket a [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-)‑nek és a [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-)‑nek a [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/)-ban. Ezek a beállítások függetlenek, így engedélyezhet egyet, miközben a másikat letiltja. A példa a prezentációt úgy exportálja, hogy mindkét animációtípust letiltja a generált oldalon.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint exportálása HTML-re**

A szabványos HTML exportálás eltérő megjelenítési megközelítést alkalmaz: a diák tartalma SVG‑ként jelenik meg egy HTML‑oldalon. Az alábbi példa egy prezentációt HTML‑dokumentummá konvertál ezzel a megjelenítési megközelítéssel.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Az alább látható egyszerűsített leírás a generált oldal szerkezetét szemlélteti. Az SVG elem a renderelt diatartalmat tartalmazza; a helykitöltő szöveg ezt a tartalmat ábrázolja, és nem a tényleges exportkimenetet.

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
Az SVG‑alapú exportálás nem teszi elérhetővé a PowerPoint alakzatokat egyedi HTML elemeként. Használjon HTML5 exportot, ha a cikkben bemutatott alakzat‑animációs és dia‑váltási beállításokra van szüksége.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetre**

A HTML5 export egy oldalt hoz létre a prezentáció diáinak böngészőben történő megtekintéséhez és navigálásához. Ez a példa engedélyezi mind a [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-), mind a [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-), hogy az exportált dianézet a forrásprezentáció effektjeit le tudja játszani.

Használjon olyan prezentációt, amely már tartalmaz alakzatanimációkat és diaváltásokat, hogy lássa ezen beállítások hatását. Ezek engedélyezése nem ad hozzá új effektusokat a diákhoz, amelyek már nem tartalmaznak ilyeneket. Export után nyissa meg a generált HTML5 dokumentumot egy böngészőben, a támogatásához szükséges fájlok rendelkezésre állásával.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A meglévő diamegjegyzéseket be lehet ágyazni a HTML5 kimenetbe, hogy az olvasók a diatartalom mellett láthassák a visszajelzéseket. Ennek a szakasznak a példája feltételezi, hogy a forrásprezentáció tartalmaz megjegyzéseket, ahogyan az alább látható. Ezeket a megjegyzéseket exportálja; újakat nem hoz létre.

![Két megjegyzés a prezentáció dián](two_comments_pptx.png)

Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/)-objektumot a [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-)-metódusnak a [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/)-ban. Használja a [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-)‑t a [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/)-enumerációból a `Right` érték kiválasztásához, hogy a megjegyzéseket minden dia jobb oldalára helyezze.

Az alábbi példa a prezentációt HTML5-re exportálja ezzel a megjegyzéselrendezéssel. A megjegyzésekkel nem rendelkező prezentáció nem jelenít meg megjegyzésszöveget.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Az alábbi kép az exportált HTML5 dokumentumot mutatja, ahol a megjegyzések a dia mellett jelennek meg.

![A megjegyzések az eredmény HTML5 dokumentumban](two_comments_html5.png)

## **JavaScript hivatkozások kizárása exportálás során**

Tegyük fel, hogy a `hyperlinks.pptx` egy `javascript:alert('Hello')` célt és egy szokásos `https://example.com/` hivatkozást tartalmaz. A JavaScript hivatkozás kizárásához exportáláskor adjon át `true` értéket a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)-nek. Az alapértelmezett érték `false`, ezért ezek a hivatkozások nincsenek szűrve, hacsak nem engedélyezi a beállítást.

Az alábbi példa betölti a prezentációt a munkakönyvtárból, és azt [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/)-al exportálja:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Az exportált fájl kihagyja a JavaScript hivatkozást, miközben megtartja a szövegét és a szokásos HTTPS hivatkozást. A forrásprezentáció változatlan marad.

Ez a beállítás szűri a JavaScript hivatkozásokat; nem távolít el minden szkriptet vagy egyéb aktív tartalmat, és nem garantálja a CSP megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz szkripteket a diák navigációjához és animációihoz.

## **GYIK**

**Vezérelhetem-e, hogy az objektumanimációk és diaváltások lejátszódjanak HTML5-ben?**

Igen, a HTML5 export különálló lehetőségeket kínál a [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) és a [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezésére vagy letiltására.

**Támogatottak-e a megjegyzések, és hol helyezhetők el a diákhoz képest?**

Igen, a meglévő megjegyzések belefoglalhatók a HTML5 kimenetbe, és elhelyezhetők (például a dia jobb oldalára) a [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) segítségével.

**Kihagyhatok-e olyan hivatkozásokat, amelyek JavaScript‑et hívnak elő biztonsági vagy CSP‑okból adódó okokból?**

Igen, a [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) beállítás lehetővé teszi, hogy a mentés során kihagyja a JavaScript‑hívásokat tartalmazó hivatkozásokat. Az alapértelmezett érték `false`. Lásd a [JavaScript hivatkozások kizárása exportálás során](/slides/hu/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) szakaszt egy HTML5 export példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 néző által a navigációhoz és animációkhoz használt JavaScriptet.