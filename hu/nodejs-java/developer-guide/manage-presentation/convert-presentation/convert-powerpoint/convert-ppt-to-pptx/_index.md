---
title: PPT konvertálása PPTX‑be JavaScript‑ben
linktitle: PPT PPTX‑be
type: docs
weight: 20
url: /hu/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- előadás konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX‑be
- PPT mentése PPTX‑ként
- PPT exportálása PPTX‑be
- PowerPoint
- előadás
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a régi PPT előadásokat modern PPTX formátumba gyorsan az Aspose.Slides for Node.js segítségével — áttekinthető bemutató, ingyenes kódminták, Microsoft Office függőség nélkül."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint előadást PPT formátumból PPTX formátumba konvertálni JavaScript használatával és online PPT‑t‑PPTX konverziós alkalmazással. A következő téma kerül bemutatásra.

- PPT konvertálása PPTX‑be JavaScript‑ben

## **Java Convert PPT to PPTX**

A PPT‑t PPTX‑be konvertáló JavaScript minta kódért lásd az alábbi szekciót: [PPT konvertálása PPTX‑be](#convert-ppt-to-pptx). A minta csak betölti a PPT fájlt és PPTX formátumban menti el. Különböző mentési formátumok megadásával a PPT fájlt más formátumokba is elmentheted, például PDF, XPS, ODP, HTML stb., amint ezekben a cikkekben tárgyaltuk.

- [PPT konvertálása PDF‑be JavaScript‑ben](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/)
- [PPT konvertálása XPS‑be JavaScript‑ben](/slides/hu/nodejs-java/convert-powerpoint-to-xps/)
- [PPT konvertálása HTML‑be JavaScript‑ben](/slides/hu/nodejs-java/convert-powerpoint-to-html/)
- [PPT konvertálása ODP‑be JavaScript‑ben](/slides/hu/nodejs-java/save-presentation/)
- [PPT konvertálása PNG‑be JavaScript‑ben](/slides/hu/nodejs-java/convert-powerpoint-to-png/)

## **A PPT‑t PPTX‑be konvertálásról**
Régi PPT formátum konvertálása PPTX‑be az Aspose.Slides API‑val. Ha több ezer PPT előadást kell PPTX formátumba konvertálni, a legjobb megoldás programozottan elvégezni. Az Aspose.Slides API‑val ez csak néhány kódsorral megvalósítható. Az API teljes kompatibilitást biztosít a PPT előadás PPTX‑be konvertálásához, és lehetővé teszi:

- Bonyolult master, elrendezés és dia struktúrák konvertálását.
- Diagramokat tartalmazó előadások konvertálását.
- Csoportos alakzatok, automata alakzatok (például téglalapok és ellipszisek), egyedi geometriai alakzatok konvertálását.
- Textúrákat és képekkel kitöltött automata alakzatok konvertálását.
- Helyfoglalókat, szövegdobozokat és szövegmezőket tartalmazó előadások konvertálását.

{{% alert color="primary" %}} 

Nézze meg az **Aspose.Slides PPT‑t‑PPTX konverzió** alkalmazást:

[](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx)

Ez az alkalmazás a **Aspose.Slides API** alapján készült, így élő példát láthat az alapvető PPT‑t‑PPTX konverziós képességekre. Az Aspose.Slides Conversion egy webes alkalmazás, amely lehetővé teszi PPT formátumú előadások feltöltését és PPTX‑be konvertálva letöltését.

Találjon más élő **Aspose.Slides Conversion** példákat.
{{% /alert %}} 

## **PPT konvertálása PPTX‑be**
Az Aspose.Slides for Node.js via Java most lehetővé teszi a fejlesztők számára, hogy a PPT‑t a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztálypéldányon keresztül elérjék, és azt a megfelelő [PPTX](https://docs.fileformat.com/presentation/pptx/) formátumba konvertálják. Jelenleg részleges konverziót támogat a [PPT](https://docs.fileformat.com/presentation/ppt/) PPTX‑be.

Az Aspose.Slides for Node.js via Java a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályt kínálja, amely egy **PPTX** előadás fájlt képvisel. A Presentation osztály most már a **PPT**‑t is elérheti, ha a példányt a PPT‑vel hozza létre. Az alábbi példa bemutatja, hogyan konvertáljunk egy PPT előadást PPTX Presentation‑be.

```javascript
// PPTX fájlt reprezentáló Presentation objektum példányosítása
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // A PPTX előadás mentése PPTX formátumba
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Ábra: Eredeti PPT előadás**|

A fenti kódrészlet a konverzió után a következő PPTX előadást hozza létre

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Ábra: Generált PPTX előadás a konverzió után**|

## **GYIK**

**Mi a különbség a PPT és PPTX formátumok között?**

A PPT a Microsoft PowerPoint régebbi bináris fájlformátuma, míg a PPTX a Microsoft Office 2007‑től bevezetett XML‑alapú új formátum. A PPTX fájlok jobb teljesítményt, kisebb méretet és fejlettebb adat-helyreállítást biztosítanak.

**Támogatja az Aspose.Slides a több PPT fájl egyidejű PPTX‑be konvertálását?**

Igen, az Aspose.Slides segítségével ciklusban programozottan konvertálhat több PPT fájlt PPTX‑be, ami alkalmas kötegelt konverzióra.

**Megmaradnak-e a tartalom és a formázás a konverzió után?**

Az Aspose.Slides nagy hitelességgel konvertálja az előadásokat. Diaelrendezések, animációk, alakzatok, diagramok és egyéb tervezési elemek megmaradnak a PPT‑t‑PPTX konverzió során.

**Konvertálhatok-e más formátumokra, például PDF vagy HTML, PPT fájlokból?**

Igen, az Aspose.Slides támogatja a PPT fájlok több formátumba történő konvertálását, beleértve a PDF‑et, XPS‑t, HTML‑t, ODP‑t és a képek közül a PNG‑t és JPEG‑t is.

**Lehetséges PPT‑t PPTX‑be konvertálni Microsoft PowerPoint telepítése nélkül?**

Igen, az Aspose.Slides egy önálló API, amely nem igényel Microsoft PowerPoint‑ot vagy harmadik féltől származó szoftvert a konverzió elvégzéséhez.

**Elérhető‑e online eszköz PPT‑t PPTX‑be konvertáláshoz?**

Igen, a ingyenes [Aspose.Slides PPT‑t‑PPTX Converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) webalkalmazással közvetlenül a böngészőben végezheti a konverziót kód írása nélkül.