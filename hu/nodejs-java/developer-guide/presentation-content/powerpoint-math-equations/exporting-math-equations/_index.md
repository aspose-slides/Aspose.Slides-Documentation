---
title: Matematikai egyenletek exportálása prezentációkból JavaScriptben
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/nodejs-java/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- MathML
- LaTeX
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Engedélyezze a zökkenőmentes matematikai egyenletek exportálását a PowerPointból MathML-be JavaScript és a Node.js-hez készült Aspose.Slides használatával—őrizze a formázást és növelje a kompatibilitást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a matematikai egyenletek exportálását a prezentációkból. Például előfordulhat, hogy a diákon (egy adott prezentációból) lévő matematikai egyenleteket kell kinyerned, és egy másik programban vagy platformon használni.

{{% alert color="primary" %}} 
Az egyenleteket exportálhatod MathML-be, egy népszerű formátumba vagy szabványba a matematikai egyenletek és hasonló tartalmak számára, amelyet a weben és számos alkalmazásban láthatunk. 
{{% /alert %}}

## **Matematikai egyenletek mentése MathML-be**

Míg az emberek könnyen megírják a kódot bizonyos egyenletformátumokhoz, például a LaTeX-hez, nehezebben tudnak MathML kódot írni, mivel ezt utóbbit általában alkalmazások generálják automatikusan. A programok könnyen olvassák és elemzik a MathML-t, mert a kódja XML-ben van, így a MathML-t gyakran használják kimeneti és nyomtatási formátumként számos területen.

Ez a példa kód megmutatja, hogyan exportálhatsz egy matematikai egyenletet egy prezentációból MathML-be:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mi pontosan kerül exportálásra MathML-be — egy bekezdés vagy egy egyedi képletblokk?**

Exportálhatsz egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathblock/)) MathML-be. Mindkét típus rendelkezik egy módszerrel a MathML-be íráshoz.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e, és nem sima szöveg vagy kép?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathportion/) részeként él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/)-val. A képek és a sima szövegrétegek, amelyeknek nincs [MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/), nem exportálható képletek.

**Honnan származik a MathML egy prezentációban — PowerPoint-specifikus vagy szabványos?**

Az exportálás a szabványos MathML-t (XML) célozza. Az Aspose a Presentation MathML-t használja — a szabvány prezentációs alcsomópontját, amely széles körben elterjedt az alkalmazásokban és a weben.

**Támogatott-e képletek exportálása táblázatok, SmartArt, csoportok stb. belsejéből?**

Igen, ha ezek az objektumok szövegrétegeket tartalmaznak [MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/) segítségével (azaz valódi PowerPoint képleteket), akkor exportálásra kerülnek. Ha a képlet képként van beágyazva, akkor nem.

**Módosítja-e egy MathML-be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentációfájlt.