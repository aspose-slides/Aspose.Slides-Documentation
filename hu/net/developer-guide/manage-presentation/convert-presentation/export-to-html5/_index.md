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
- PPT exportálása HTML5-be
- PPTX exportálása HTML5-be
- ODP exportálása HTML5-be
- .NET
- C#
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása responsív HTML5-re az Aspose.Slides for .NET használatával. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides segítségével. Kitér az alapvető HTML5‑exportálásra, valamint a formaanimációk és diákátmenetek szabályozásának lehetőségeire. A cikk meg is mutatja a szabványos PowerPoint‑HTML export folyamatát, elmagyarázza, hogyan lehet HTML5 kimenetet előállítani dianézet módban, és bemutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba a elrendezésük konfigurálásával.

## **PowerPoint exportálása HTML5‑re**

Ez a C# kód bemutatja, hogyan lehet egy prezentációt HTML5‑re exportálni:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
A HTML dokumentum mellett az exportálás létrehozza a hivatkozott segédfájlokat is: `pres.css`, `master.css`, `animation.js`, `effects.js` és `navigation.js`. A generált oldal továbbá betölti a jQuery‑t és az Anime.js‑t a nyilvános CDN‑ekről; ezek nélkül a diák navigációja és animációi nem működnek.
{{% /alert %}}

Az alábbi módon adhatsz meg beállításokat a formaanimációk és diákátmenetek számára:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **PowerPoint exportálása HTML‑re**

A következő C# bemutatja a szabványos PowerPoint‑HTML folyamát:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Ebben az esetben a prezentáció tartalma SVG‑ként kerül renderelésre, a következő formában:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Ha ezzel a módszerrel exportálsz PowerPoint‑t HTML‑re, az SVG renderelés miatt nem lesz lehetőség stílusok alkalmazására vagy egyes elemek animálására.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertálj, amelyben a diák dianézet módban jelennek meg. Ebben az esetben, ha a kapott HTML5 fájlt egy böngészőben nyitod meg, a prezentációt a weboldalon diaképként láthatod.

Az alábbi C# kód demonstrálja a PowerPoint‑HTML5 dianézet export folyamatát:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

Megjegyzések a PowerPointban olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyjanak a prezentációs diákon. Különösen együttműködő projektekben hasznosak, ahol több személy is hozzáadhatja javaslatait vagy megjegyzéseit a konkrét diáelemekhez a fő tartalom módosítása nélkül. Minden megjegyzés tartalmazza a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentáció el van mentve a "sample.pptx" fájlban.

![Két megjegyzés a prezentációs dián](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertálsz, egyszerűen megadhatod, hogy a prezentációból származó megjegyzéseket bele szeretnéd-e foglalni a kimeneti dokumentumba. Ehhez a megjegyzések megjelenítési paramétereit kell megadni a `NotesCommentsLayouting` tulajdonságban a [Html5Options](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/) osztályban.

A következő kódrészlet egy prezentációt HTML5 dokumentummá konvertál, a megjegyzésekkel a diák jobb oldalán.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Az "output.html" dokumentum az alábbi képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

### Szabályozhatom-e, hogy az objektumanimációk és diákátmenetek lejátszódjanak HTML5‑ben?

Igen, a HTML5 különálló beállításokat kínál a [formaanimációk](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animateshapes/) és a [diákátmenetek](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animatetransitions/) engedélyezésére vagy letiltására.

### Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a diához képest?

Igen, a megjegyzések hozzáadhatók HTML5-ben, és elhelyezhetők (például a dia jobb oldalán) a [elrendezési beállítások](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/notescommentslayouting/) segítségével.

### Kihagyhatom-e a JavaScript‑hívásokat tartalmazó hivatkozásokat biztonsági vagy CSP okokból?

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), amely lehetővé teszi, hogy a mentés során kihagyjuk a JavaScript‑hívásokat tartalmazó hiperhivatkozásokat. Ez segít a szigorú biztonsági politikák betartásában.