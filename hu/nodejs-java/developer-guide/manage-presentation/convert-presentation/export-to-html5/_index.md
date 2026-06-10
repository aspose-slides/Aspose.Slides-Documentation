---
title: Prezentációk konvertálása HTML5-re JavaScriptben
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for Node.js segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk leírja, hogyan lehet a PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides segítségével. Kitér az alapvető HTML5‑exportálásra webes kiterjesztések vagy további függőségek nélkül, valamint a formaanimációk és diaváltások vezérlésének beállítási lehetőségeire. A cikk bemutatja a szabványos PowerPoint‑HTML exportálási folyamatot, ismerteti, hogyan lehet HTML5‑kimenetet generálni dianézet módban, és megmutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba az elrendezésük konfigurálásával.

## **PowerPoint exportálása HTML5‑re**

Ez a JavaScript‑kód bemutatja, hogyan exportálhat egy prezentációt HTML5‑re webes kiterjesztések és függőségek nélkül:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Ebben az esetben tiszta HTML-et kap. 
{{% /alert %}}

Lehet, hogy így szeretné megadni a formaanimációk és diaváltások beállításait:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint exportálása HTML‑re**

Ez a JavaScript bemutatja a szabványos PowerPoint‑HTML folyamatot:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
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

{{% alert title="Note" color="warning" %}} 
Ha ezt a módszert használja a PowerPoint HTML‑re exportálásához, az SVG‑renderelés miatt nem tud stílusokat alkalmazni vagy specifikus elemeket animálni. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetben**

Az **Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertáljon, amelyben a diák dianézet módban jelennek meg. Ebben az esetben, amikor a keletkezett HTML5 fájlt egy böngészőben megnyitja, a prezentációt dianézetben láthatja egy weboldalon. 

Ez a JavaScript‑kód bemutatja a PowerPoint‑HTML5 dianézet exportálási folyamatát:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A PowerPoint megjegyzései olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyjanak a prezentáció diáin. Különösen hasznosak együttműködési projektekben, ahol több személy adhat hozzá javaslatokat vagy megjegyzéseket a diákat érintő elemekhez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés mutatja a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentáció a "sample.pptx" fájlban van mentve.

![Két megjegyzés a prezentáció diáján](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertál, egyszerűen megadhatja, hogy a prezentáció megjegyzései szerepeljenek-e a kimeneti dokumentumban. Ehhez meg kell adnia a megjegyzések megjelenítési paramétereit a `notes_comments_layouting` tulajdonságban a [Html5Options](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/) osztályban.

Az alábbi kódrészlet egy prezentációt HTML5 dokumentummá konvertál, a megjegyzéseket a diák jobb oldalán megjelenítve:

```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Az "output.html" dokumentum a lenti képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

**Kontrolálhatom, hogy az objektumanimációk és diaváltások lejátszódjanak-e HTML5‑ben?**

Igen, a HTML5 különálló beállításokat biztosít a [formaanimációk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/setanimateshapes/) és a [diaváltások](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/setanimatetransitions/) engedélyezésére vagy letiltására.

**Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a diához képest?**

Igen, a megjegyzéseket hozzáadhatja HTML5‑ben, és a [elrendezési beállítások](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) segítségével (például a dia jobb oldalán) elhelyezheti a jegyzetek és megjegyzések számára.

**Kihagyhatok linkeket, amelyek JavaScript‑et hívnak meg biztonsági vagy CSP‑okból adódó okok miatt?**

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), amely lehetővé teszi a JavaScript‑hívásokat tartalmazó hiperlinkek kihagyását mentés közben. Ez segít a szigorú biztonsági irányelvek betartásában.