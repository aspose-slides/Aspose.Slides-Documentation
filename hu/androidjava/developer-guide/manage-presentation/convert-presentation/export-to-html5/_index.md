---
title: Prezentációk konvertálása HTML5-re Androidon
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Export PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for Android Java segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides for Android for Java‑vel. Tárgyalja az alapvető exportálást, az alakzat‑animációk és dia‑átmenetek vezérlését, valamint a megjegyzések elrendezését. Összeveti a HTML5 kimenetet a szokásos HTML‑export SVG‑alapú kimenetével.

## **PowerPoint exportálása HTML5‑re**

Az alábbi példa betölti a prezentációt a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa bemutatja, hogyan lehet kifejezetten vezérelni az animáció lejátszását. Cserélje le a bemeneti útvonalat a saját prezentációja útvonalára.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Megjegyzés" %}}
A HTML‑dokumentum mellett az exportálás CSS és JavaScript fájlokat is ír a dia‑stílusok, animációk, hatások és navigáció támogatásához. Ezeket a fájlokat a HTML‑dokumentummal együtt tartsa, ha a kimenetet áthelyezi vagy közzéteszi. A generált oldal betölti a jQuery‑t és az Anime.js‑t nyilvános CDN‑ről; ezek nélkül a dia‑navigáció és az animációk nem fognak futni.
{{% /alert %}}

Az alakzat‑animációk vagy dia‑átmenetek lejátszása nélkül történő exportáláshoz adja át a `false` értéket a [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) metódusoknak a [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) osztályban. Ezek a beállítások függetlenek, így engedélyezhet egyet, miközben a másikat letiltja. Az alábbi példa a prezentációt mindkét animációtípus letiltásával exportálja a generált oldalon.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint exportálása HTML‑re**

A szabványos HTML‑exportálás más megjelenítési megközelítést használ: a dia tartalma SVG‑ként jelenik meg egy HTML‑oldalon belül. Az alábbi példa ezen a megközelítésen keresztül konvertálja a prezentációt HTML‑dokumentummá.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Az alább látható egyszerűsített jelölőnyelv bemutatja a generált oldal szerkezetét. Az SVG‑elem a renderelt dia‑tartalmat tartalmazza; a helykitöltő szöveg ezt a tartalmat jelöli, de nem a tényleges exportkimenet.

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
Az SVG‑alapú exportálás nem teszi elérhetővé a PowerPoint‑alakzatokat különálló HTML elemekként. Használja a HTML5‑exportálást, ha a cikkben bemutatott alakzat‑animációs és dia‑átmeneti lehetőségekre van szüksége.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia‑nézetként**

A HTML5 exportálás egy böngészőben megtekinthető és navigálható diavetítést hoz létre. Ez a példa engedélyezi mind a [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) beállításokat, hogy az exportált dia‑nézet lejátszhassa a forrás prezentáció hatásait.

Használjon olyan prezentációt, amely már tartalmaz alakzat‑animációkat és dia‑átmeneteket, hogy lássa ezen beállítások hatását. A bekapcsolásuk nem ad új hatásokat azokhoz a diákhoz, amelyeknek egyáltalán nincsenek animációi. Export után nyissa meg a generált HTML5 dokumentumot egy böngészőben, ahol a támogatott fájlok elérhetők.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A HTML5 kimenet tartalmazhat meglévő dia‑megjegyzéseket, így az olvasók visszajelzéseket láthatnak a dia‑tartalom mellett. Az alábbi szakaszban szereplő példa feltételezi, hogy a forrás prezentáció már tartalmaz megjegyzéseket, ahogy az alább is látható. Ezeket a megjegyzéseket exportálja; újakat nem hoz létre.

![Two comments on the presentation slide](two_comments_pptx.png)

Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) objektumot a [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódusnak a [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) osztályban. A [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) segítségével válassza a `Right`‑et a [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) felsorolásból, hogy a megjegyzéseket minden dia jobb oldalán helyezze el.

Az alábbi példa a prezentációt HTML5‑re exportálja ezzel a megjegyzés‑elrendezéssel. Egy megjegyzés nélküli prezentáció esetén nem lesz megjelenítendő szöveg.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Az alábbi kép a megjegyzésekkel megjelenített exportált HTML5 dokumentumot mutatja a dia mellett.

![The comments in the output HTML5 document](two_comments_html5.png)

## **JavaScript hivatkozások kizárása exportáláskor**

Tegyük fel, hogy a `hyperlinks.pptx` tartalmaz egy `javascript:alert('Hello')` célú hivatkozott szöveget és egy hagyományos `https://example.com/` linket. A JavaScript hivatkozás kizárásához exportáláskor adja át a `true` értéket a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) beállításnak. Alapértelmezés szerint `false`, ezért ezek a linkek nincsenek szűrve, hacsak nem engedélyezi a beállítást.

Az alábbi példa betölti a prezentációt a munkakönyvtárból, és a [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) használatával exportálja:

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Az exportált fájl kihagyja a JavaScript hivatkozást, miközben megőrzi annak szövegét és a szokásos HTTPS linket. A forrás prezentáció változatlan marad.

Ez a beállítás a JavaScript hivatkozásokat szűri; nem távolítja el az összes szkriptet vagy egyéb aktív tartalmat, és nem garantálja a CSP megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz szkripteket a dia‑navigációhoz és animációkhoz.

## **GYIK**

**Képes vagyok vezérelni, hogy az objektum‑animációk és dia‑átmenetek lejátszódjanak-e HTML5‑ben?**

Igen, a HTML5 exportálás külön beállításokat kínál a [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezésére vagy letiltására.

**Támogatottak a megjegyzések, és hol helyezhetők el a diához képest?**

Igen, a meglévő megjegyzések belefoglalhatók a HTML5 kimenetbe, és elhelyezhetők (például a dia jobb oldalán) a [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) segítségével a jegyzetek és megjegyzések számára.

**Kihagyhatom a JavaScript‑hívásokat tartalmazó hivatkozásokat biztonsági vagy CSP okokból?**

Igen, a [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) beállítás lehetővé teszi, hogy a mentés során a JavaScript‑hívásokat tartalmazó hivatkozásokat kihagyja. Alapértelmezés szerint `false`. Lásd a [Exclude JavaScript Hyperlinks During Export](/slides/hu/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) szakaszt egy HTML5 exportálási példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 nézőben a navigációhoz és animációkhoz használt JavaScript‑et.