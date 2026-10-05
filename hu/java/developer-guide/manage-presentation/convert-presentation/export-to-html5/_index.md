---
title: Prezentációk konvertálása HTML5-re Java
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat választható HTML5-re az Aspose.Slides for Java segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint-prezentációkat HTML5-re konvertálni az Aspose.Slides for Java használatával. Lefedi az alapvető exportálást, az alakzatanimációk és diaváltások vezérlését, valamint a megjegyzések elrendezését. Emellett összehasonlítja a HTML5 kimenetet a szabványos HTML export SVG-alapú kimenetével.

## **PowerPoint exportálása HTML5-be**

A következő példa egy prezentációt tölt be a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa bemutatja, hogyan lehet explicit módon vezérelni az animáció lejátszását. Cserélje le a bemeneti útvonalat a saját prezentációja útvonalára.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A HTML dokumentum mellett az export létrehozza a diák stílusához, animációihoz, effektjeihez és navigációjához szükséges CSS és JavaScript fájlokat is. Ezeket a fájlokat a HTML dokumentummal együtt tartsa, amikor áthelyezi vagy közzéteszi a kimenetet. A generált oldal továbbá a jQuery-t és az Anime.js-t nyilvános CDN-eken keresztül tölti be; ezek nélkül a diák navigációja és animációi nem működnek.
{{% /alert %}}

Az exportáláshoz, hogy az alakzatanimációk vagy diaváltások ne játsszanak le, adja át a `false` értéket a [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) metódusoknak a [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) objektumban. Ezek a beállítások függetlenek, így az egyiket engedélyezheti, míg a másikat letilthatja. A példa a prezentációt exportálja úgy, hogy mindkét animációs típus le van tiltva a generált oldalon.

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

## **PowerPoint exportálása HTML-re**

A szabványos HTML export egy másik renderelési megközelítést alkalmaz: a diatartalom SVG-ként jelenik meg egy HTML oldalon belül. A következő példa egy prezentációt konvertál HTML dokumentummá ezen a renderelési megközelítésen keresztül.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Az alábbi egyszerűsített jelölőnyelv bemutatja a generált oldal felépítését. Az SVG elem tartalmazza a renderelt diatartalmat; a helyőrző szöveg ezt a tartalmat képviseli, és nem a tényleges exportkimenet.

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
Az SVG-alapú export nem teszi elérhetővé a PowerPoint-alkalmazásokat egyedi HTML elemekként. Használja a HTML5 exportot, ha a cikkben bemutatott alakzat-animációs és diaváltási beállításokra van szüksége.
{{% /alert %}}

## **PowerPoint exportálása HTML5 diáknézetre**

A HTML5 export egy oldalt hoz létre a prezentációs diák megtekintéséhez és navigálásához a böngészőben. Ez a példa engedélyezi mind a [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) beállítást, hogy az exportált diáknézet le tudja játszani a forrás prezentáció effektjeit.

Használjon egy olyan prezentációt, amely már tartalmaz alakzatanimációkat és diaváltásokat, hogy lássa ezen beállítások hatását. Ezek engedélyezése nem ad hozzá új effektusokat azokhoz a diákhoz, amelyeknek egyáltalán nincs animációja. Export után nyissa meg a generált HTML5 dokumentumot egy böngészőben, ahol a támogató fájlok elérhetők.

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

A HTML5 kimenetben szerepeltethetők a meglévő diákkönyvzetek, így az olvasók a visszajelzéseket a diatartalom mellett láthatják. Az ebben a szakaszban bemutatott példa azt feltételezi, hogy a forrás prezentáció tartalmaz megjegyzéseket, ahogyan az alább látható. Ezeket a megjegyzéseket exportálja; újat nem hoz létre.

![Két megjegyzés a prezentáció diáján](two_comments_pptx.png)

Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) objektumot a [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódusnak a [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) objektumban. Használja a [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) metódust a `Right` érték kiválasztásához a [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) felsorolásból, hogy a megjegyzéseket minden dia jobb oldalára helyezze.

A következő példa a prezentációt HTML5 formátumban exportálja ezzel a megjegyzéselrendezéssel. Egy megjegyzés nélküli prezentáció nem fog megjeleníteni semmilyen megjegyzésszöveget.

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

Az alábbi kép mutatja a exportált HTML5 dokumentumot, ahol a megjegyzések a dia mellett jelennek meg.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **JavaScript hivatkozások kizárása exportálás közben**

Tegyük fel, hogy a `hyperlinks.pptx` egy `javascript:alert('Hello')` célt és egy szokásos `https://example.com/` hivatkozást tartalmazó szöveget linkel. A JavaScript hivatkozás kizárásához exportálás során adja át a `true` értéket a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) metódusnak. Alapértelmezésben a megfelelő érték `false`, ezért ezek a hivatkozások nincsenek szűrve, hacsak nem engedélyezi a beállítást.

A következő példa a prezentációt a munkakönyvtárból tölti be, és a [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) használatával exportálja:

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

Az exportált fájl kihagyja a JavaScript hivatkozást, miközben megtartja annak szövegét és a szokásos HTTPS linket. A forrás prezentáció változatlan marad.

Ez a beállítás csak a JavaScript hivatkozásokat szűri; nem távolít el minden scriptet vagy egyéb aktív tartalmat, és nem garantálja a CSP megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz szkripteket a diák navigációjához és animációihoz.

## **GYIK**

**Kontrollálhatom, hogy az objektumanimációk és diaváltások lejátszódjanak-e HTML5-ben?**  
Igen, a HTML5 export külön lehetőséget biztosít a [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezésére vagy letiltására.

**Támogatottak a megjegyzések, és hol helyezhetők el a dia viszonylatában?**  
Igen, a meglévő megjegyzések belefoglalhatók a HTML5 kimenetbe, és elhelyezhetők (például a dia jobb oldalára) a jegyzetek és megjegyzések [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) segítségével.

**Kihagyhatok olyan hivatkozásokat, amelyek JavaScript-et hívnak meg biztonsági vagy CSP okokból?**  
Igen, a [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) beállítás lehetővé teszi a JavaScript hívást tartalmazó hivatkozások kihagyását mentéskor. Alapértelmezésben `false`. Lásd a [Exclude JavaScript Hyperlinks During Export](/slides/hu/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) részt egy HTML5 export példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 megjelenítő navigációhoz és animációkhoz használt JavaScriptet.