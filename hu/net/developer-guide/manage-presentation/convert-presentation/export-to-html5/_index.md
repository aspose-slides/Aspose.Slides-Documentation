---
title: Prezentációk konvertálása HTML5 formátumba .NET-ben
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
description: "PowerPoint és OpenDocument prezentációk exportálása reszponzív HTML5-be az Aspose.Slides for .NET segítségével. Megőrzik a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhatók a PowerPoint bemutatók HTML5 formátumba az Aspose.Slides segítségével. Lefedi az egyszerű HTML5 exportot webes kiterjesztések vagy további függőségek nélkül, valamint a formaanimációk és diavetítések vezérlésének beállításait. A cikk bemutatja a szabványos PowerPoint‑to‑HTML exportfolyamatot, elmagyarázza, hogyan generálhatók HTML5 kimenetek dianézet módban, és megmutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba a elrendezésük konfigurálásával.

## **PowerPoint exportálása HTML5‑be**

Ez a C# kód bemutatja, hogyan exportálhat egy bemutatót HTML5‑be webes kiterjesztések és függőségek nélkül:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}}  
Ebben az esetben tiszta HTML-et kap.  
{{% /alert %}}

Ilyen módon megadhatja a formaanimációk és diavetítések beállításait:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **PowerPoint exportálása HTML‑be**

Ez a C# bemutatja a szabványos PowerPoint‑to‑HTML folyamatot:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Ebben az esetben a bemutató tartalma SVG‑vel kerül renderelésre, a következő formában:

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
Ha ezt a módszert használja a PowerPoint HTML‑be exportálásához, az SVG renderelés miatt nem fog tudni stílusokat alkalmazni vagy egyes elemeket animálni.  
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint bemutatót HTML5 dokumentummá konvertáljon, amelyben a diák dianézet módban jelennek meg. Ebben az esetben, ha a keletkezett HTML5 fájlt egy böngészőben nyitja meg, a bemutatót dianézetben láthatja a weboldalon.

Ez a C# kód bemutatja a PowerPoint‑to‑HTML5 dianézet export folyamatát:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Bemutató konvertálása HTML5 dokumentummá megjegyzésekkel**

A PowerPoint megjegyzései olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyjanak a bemutató diáin. Különösen hasznosak együttműködési projektekben, ahol több személy adhat hozzá javaslatokat vagy megjegyzéseket a diák bizonyos elemeihez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés a szerző nevét mutatja, így könnyű nyomon követni, ki hagyta.

Tegyük fel, hogy a következő PowerPoint bemutató a "sample.pptx" fájlban van elmentve.

![Két megjegyzés a bemutató dián](two_comments_pptx.png)

Amikor egy PowerPoint bemutatót HTML5 dokumentummá konvertál, könnyen megadhatja, hogy a kimeneti dokumentumban szerepeljenek‑e a bemutató megjegyzései. Ehhez meg kell adnia a megjegyzések megjelenítési paramétereit a `NotesCommentsLayouting` tulajdonságban a [Html5Options](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/) osztályban.

A következő kódrészlet egy bemutatót HTML5 dokumentummá konvertál, a megjegyzésekkel a diák jobb oldalán:

```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Az "output.html" dokumentum az alábbi képen látható.

![A megjegyzések az eredmény HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

**Megal tudom határozni, hogy az objektumanimációk és diavetítések lejátszódjanak‑e HTML5‑ben?**  
Igen, a HTML5 különálló beállításokat biztosít a [shape animations](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animateshapes/) és a [slide transitions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animatetransitions/) engedélyezésére vagy letiltására.

**Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a diára vonatkozóan?**  
Igen, a megjegyzések hozzáadhatók HTML5‑ben, és a [layout settings](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/notescommentslayouting/) segítségével (például a dia jobb oldalára) helyezhetők el a jegyzetek és megjegyzések számára.

**Kihagyhatom‑e azokat a hivatkozásokat, amelyek JavaScript‑et hívnak meg biztonsági vagy CSP‑okból adódó okok miatt?**  
Igen, van egy [setting](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) amely lehetővé teszi, hogy a mentés során kihagyja a JavaScript hívásokat tartalmazó hiperhivatkozásokat. Ez segít a szigorú biztonsági szabályzatok betartásában.