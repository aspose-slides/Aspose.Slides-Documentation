---
title: Prezentációk konvertálása HTML5-re PHP-ben
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Export PowerPoint és OpenDocument prezentációkat reszponzív HTML5-be az Aspose.Slides for PHP via Java használatával. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk leírja, hogyan konvertálhatók a PowerPoint‑prezentációk HTML5‑re az Aspose.Slides for PHP via Java segítségével. Bemutatja az alapvető exportálást, az alakzatanimációk és diaváltások vezérlését, valamint a megjegyzéselrendezést. Emellett összehasonlítja a HTML5 kimenetet a szabványos HTML‑export SVG‑alapú kimenetével.

## **PowerPoint exportálása HTML5‑be**

A következő példa betölti egy prezentációt a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa megmutatja, hogyan vezérelhető kifejezetten az animáció lejátszása. Cserélje ki a bemeneti útvonalat a saját prezentációjának útvonalára.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Megjegyzés" %}}
A HTML-dokumentum mellett az exportálás létrehozza a diák stilizálásához, animációihoz, effektusaihoz és navigációjához szükséges CSS és JavaScript fájlokat. Ezeket a fájlokat a HTML-dokumentummal együtt tartsa, amikor áthelyezi vagy közzéteszi a kimenetet. A generált oldal a jQuery‑t és az Anime.js‑t is betölti nyilvános CDN‑kről; ezek nélkül a diák navigációja és animációi nem fognak működni.
{{% /alert %}}

Az alakzatanimációk vagy diaváltások lejátszása nélkül történő exportáláshoz adja át a `false` értéket a [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) és a [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) metódusnak a [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) objektumban. Ezek a beállítások függetlenek, így az egyiket engedélyezheti, miközben a másikat letiltja. A példa a prezentációt úgy exportálja, hogy mindkét animációtípust letiltotta a generált oldalon.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint exportálása HTML‑be**

A szabványos HTML‑export másik megjelenítési megközelítést alkalmaz: a diák tartalma SVG‑ként jelenik meg egy HTML‑oldalon. A következő példa egy prezentációt HTML‑dokumentummá alakít ezzel a megjelenítési megközelítéssel.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Az alább látható egyszerűsített jelölőnyelv a generált oldal szerkezetét mutatja. Az SVG‑elem tartalmazza a renderelt diatartalmat; a helykitöltő szöveg ezt a tartalmat szemlélteti, és nem a tényleges exportált kimenet.

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
Az SVG‑alapú exportálás nem teszi elérhetővé a PowerPoint‑alakzatokat különálló HTML‑elemekként. Használjon HTML5‑exportot, ha a cikkben bemutatott alakzat‑animációs és dia‑átmeneti beállításokra van szükség.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetbe**

Az HTML5 export egy olyan oldalt hoz létre, amely a böngészőben a prezentáció diáinak megtekintésére és navigálására szolgál. Ez a példa engedélyezi mind a [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) és a [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) beállításokat, hogy az exportált dianézet lejátszhassa a forrásprezentáció effektjeit.

Használjon olyan prezentációt, amely már tartalmaz alakzat‑animációkat és diaváltásokat, hogy lássa e beállítások hatását. Ezek engedélyezése nem ad hozzá új effektusokat azokhoz a diákhoz, amelyeknek egyáltalán nincsenek animációi. Exportálás után nyissa meg a generált HTML5 dokumentumot egy böngészőben, a támogatást nyújtó fájlok elérhetőségével.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Prezentáció konvertálása HTML5 dokumentummá kommentárokkal**

Az HTML5 kimenetben felveheti a meglévő diakommentárokat, hogy az olvasók a diatartalom mellett láthassák a visszajelzéseket. Az ebben a szakaszban bemutatott példa azt feltételezi, hogy a forrásprezentáció kommentárokat tartalmaz, ahogyan azt alább szemléltetjük. Ezeket a kommentárokat exportálja; újakat nem hoz létre.

![Két kommentár a prezentáció diáján](two_comments_pptx.png)

Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) metódusnak a [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) objektumban. Használja a [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) metódust, hogy a [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) felsorolt típusból a `Right` értéket válassza, ezzel a kommentárokat minden dia jobb oldalára helyezi.

A következő példa a prezentációt HTML5 formátumba exportálja ezzel a kommentárelrendezéssel. A kommentárokat nem tartalmazó prezentáció esetén nem jelenik meg kommentárszöveg.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Az alábbi kép a exportált HTML5 dokumentumot mutatja, ahol a kommentárok a dia mellett jelennek meg.

![A kommentárok a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **JavaScript hivatkozások kizárása exportálás közben**

Tegyük fel, hogy a `hyperlinks.pptx` olyan szöveghivatkozást tartalmaz, amelynek célja egy `javascript:alert('Hello')`, valamint egy szokásos `https://example.com/` link. A JavaScript hivatkozás kizárásához exportálás közben adja át a `true` értéket a [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) metódusnak. Az alapértelmezett érték `false`, így ezek a linkek nincsenek szűrve, hacsak nem aktiválja a beállítást.

A következő példa betölti a prezentációt a munkakönyvtárból, és [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) segítségével exportálja:

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Az exportált fájl kihagyja a JavaScript hivatkozást, miközben megtartja annak szövegét és a szokásos HTTPS linket. A forrásprezentáció változatlan marad.

Ez a beállítás csak a JavaScript hivatkozásokat szűri; nem távolítja el az összes szkriptet vagy egyéb aktív tartalmat, és nem garantálja a CSP megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz szkripteket a diák navigációjához és animációihoz.

## **GYIK**

**Le tudom-e szabályozni, hogy az objektumanimációk és diaváltások lejátszódjanak-e HTML5‑ben?**

Igen, a HTML5 export különálló beállításokat kínál a [alakzati animációk](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) és a [diaátmenetek](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) engedélyezésére vagy letiltására.

**Támogatottak-e a kommentárok, és hol lehet őket elhelyezni a dia viszonylatában?**

Igen, a meglévő kommentárok belefoglalhatók a HTML5 kimenetbe, és (például a dia jobb oldalára) elhelyezhetők a jegyzetek és kommentárok [elrendezési beállításainak](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) keresztül.

**Kihagyhatok-e JavaScriptet meghívó hivatkozásokat biztonsági vagy CSP okok miatt?**

Igen, a [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) beállítás lehetővé teszi a JavaScript‑hívásokat tartalmazó hivatkozások kihagyását a mentés során. Az alapértelmezett érték `false`. Lásd a [JavaScript hivatkozások kizárása exportálás közben](/slides/hu/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) részt egy HTML5 export példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 néző által a navigációhoz és animációkhoz használt JavaScriptet.