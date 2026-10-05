---
title: Prezentációk konvertálása HTML5-re .NET-ben
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Exportálja PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for .NET segítségével. Megőrizze a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet PowerPoint-prezentációkat HTML5-re konvertálni az Aspose.Slides for .NET használatával. Tárgyalja az alapvető exportálást, az alakzatanimációk és diaátmenetek vezérlését, valamint a megjegyzéselrendezést. Emellett összehasonlítja a HTML5 kimenetet a szabványos HTML export SVG-alapú kimenetével.

## **PowerPoint exportálása HTML5-re**

A következő példában egy prezentációt tölt be a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa azt mutatja be, hogyan lehet kifejezetten vezérelni az animáció lejátszását. Cserélje le a bemeneti útvonalat a prezentációja elérési útjára.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
A HTML dokumentum mellett az export a diák stílusához, animációihoz, effektjeihez és navigációjához szükséges CSS- és JavaScript-fájlokat is ír. Ezeket a fájlokat a HTML dokumentummal együtt tartsa, amikor áthelyezi vagy közzéteszi a kimenetet. A generált oldal a jQuery-t és az Anime.js-t is betölti a nyilvános CDN-ekről; ezek nélkül a diák navigációja és animációi nem működnek.
{{% /alert %}}

Az alakzatanimációk vagy diaátmenetek lejátszása nélkül történő exportáláshoz állítsa a [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) és a [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) értékét `false`-ra a [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)-ben. Ezek a beállítások függetlenek, így az egyiket engedélyezheti, míg a másikat letiltja. A példa a prezentációt úgy exportálja, hogy mindkét animációt letiltja a generált oldalon.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **PowerPoint exportálása HTML-re**

A szabványos HTML exportálás másik megjelenítési megközelítést használ: a dia tartalma SVG-ként jelenik meg egy HTML-oldalon. A következő példa egy prezentációt konvertál HTML-dokumentummá ezzel a megközelítéssel.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Az alábbi egyszerűsített jelölőnyelv bemutatja a generált oldal felépítését. Az SVG elem a megjelenített dia tartalmát tartalmazza; a helykitöltő szöveg ezt a tartalmat jelöli, és nem a tényleges exportkimenet.

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
Az SVG-alapú exportálás nem teszi elérhetővé a PowerPoint alakzatokat egyedi HTML elemekként. Használja a HTML5 exportálást, ha a cikkben bemutatott alakzat-animációs és diaátmeneti beállításokra van szüksége.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetként**

A HTML5 export egy olyan oldalt hoz létre, amely a böngészőben a prezentáció diáinak megtekintését és navigálását teszi lehetővé. Ez a példa engedélyezi mind a [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) és a [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) beállításokat, hogy az exportált dianézet le tudja játszani a forrásprezentáció hatásait.

Használjon olyan prezentációt, amely már tartalmaz alakzatanimációkat és diaátmeneteket, hogy lássa ezen beállítások hatását. Ezek engedélyezése nem ad hozzá új hatásokat azokhoz a diákhoz, amelyeknél nincsenek. Export után nyissa meg a generált HTML5 dokumentumot egy böngészőben, a támogatást nyújtó fájlok elérhetőségével.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A meglévő diaszövegeket beillesztheti a HTML5 kimenetbe, így az olvasók a dia tartalma mellett láthatják a visszajelzéseket. Az ebben a szakaszban szereplő példa azt várja, hogy a forrásprezentáció tartalmazzon megjegyzéseket, ahogyan az alább illusztrálva van. Ezeket a megjegyzéseket exportálja; újakat nem hoz létre.

![Két megjegyzés a prezentáció diáján](two_comments_pptx.png)

Rendeljen egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) objektumot a [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) tulajdonságához a [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)-ben. Állítsa a [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) értékét `Right`-ra a [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) felsorolásból, hogy a megjegyzéseket minden dia jobb oldalára helyezze.

A következő példa a prezentációt HTML5 formátumban exportálja ezzel a megjegyzéselrendezéssel. A megjegyzések nélküli prezentáció nem tartalmaz megjeleníthető megjegyzésszöveget.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **JavaScript hiperhivatkozások kizárása exportálás közben**

Tegyük fel, hogy a `hyperlinks.pptx` olyan hivatkozott szöveget tartalmaz, amelynek célja egy `javascript:alert('Hello')` és egy általános `https://example.com/` hivatkozás. A JavaScript hiperhivatkozás kizárásához exportáláskor állítsa a [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) értékét `true`-ra. Az alapértelmezett érték `false`, ezért ezek a hivatkozások csak akkor szűrődnek ki, ha engedélyezi a beállítást.

A következő példa a prezentációt a munkakönyvtárból tölti be, és a [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) használatával exportálja:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Az exportált fájl kihagyja a JavaScript hiperhivatkozást, miközben megtartja a szöveget és a szokásos HTTPS hivatkozást. A forrásprezentáció változatlan marad.

Ez a beállítás csak a JavaScript hiperhivatkozásokat szűri; nem távolít el minden szkriptet vagy egyéb aktív tartalmat, és nem garantálja a CSP-megfelelőséget. Például a HTML5 kimenet továbbra is tartalmaz szkripteket a dia navigációhoz és animációkhoz.

## **GYIK**

**Kontrollálhatom, hogy az objektumanimációk és diaátmenetek le fognak-e játszódni HTML5-ben?**  
Igen, a HTML5 exportálás különálló beállításokat biztosít a [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) és a [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) engedélyezésére vagy letiltására.

**Támogatottak a megjegyzések, és hol helyezhetők el a diához képest?**  
Igen, a meglévő megjegyzések belefoglalhatók a HTML5 kimenetbe, és elhelyezhetők (például a dia jobb oldalán) a [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) segítségével a jegyzetekhez és megjegyzésekhez.

**Kihagyhatok JavaScript-et meghívó hivatkozásokat biztonsági vagy CSP okokból?**  
Igen, a [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) beállítás lehetővé teszi, hogy a mentés során kihagyja a JavaScript hívásokat tartalmazó hiperhivatkozásokat. Alapértelmezés szerint `false`. Lásd a [Exclude JavaScript Hyperlinks During Export](/slides/hu/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) részt egy egyszerű HTML, HTML5 és PDF exportálási példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 megjelenítő által a navigációhoz és animációkhoz használt JavaScriptet.