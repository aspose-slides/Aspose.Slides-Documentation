---
title: Matematikai egyenletek exportálása prezentációkból Androidon
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/androidjava/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- MathML
- LaTeX
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Egyszerűen exportáljon matematikai egyenleteket PowerPointból MathML-be az Aspose.Slides for Android via Java segítségével – őrizze meg a formázást és növelje a kompatibilitást."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java lehetővé teszi a matematikai egyenletek exportálását a prezentációkból. Például előfordulhat, hogy ki kell nyernie a diákon (egy adott prezentációból) található matematikai egyenleteket, és egy másik programban vagy platformon felhasználni őket.

{{% alert color="primary" %}} 
Az egyenleteket exportálhatja MathML‑be, egy népszerű formátumba vagy szabványba a matematikai egyenletek és hasonló tartalmak számára, amelyek a weben és számos alkalmazásban megjelennek. 
{{% /alert %}}

## **Matematikai egyenletek exportálása prezentációkból**

Miközben az emberek könnyedén megírják a kódot néhány egyenletformátumhoz, például a LaTeX‑hez, nehezen tudnak MathML kódot írni, mivel az utóbbit alkalmazásoknak automatikusan kell előállítaniuk. A programok könnyen olvassák és elemzik a MathML‑t, mivel a kódja XML‑ben van, ezért a MathML gyakran használt kimeneti és nyomtatási formátum sok területen. 

Ez a példakód megmutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML‑be:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mi kerül pontosan exportálásra MathML‑be – egy bekezdés vagy egy egyedi formulablokk?**

Exportálhatja vagy egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathblock/)) MathML‑be. Mindkét típus rendelkezik olyan módszerrel, amely MathML‑be írásra használható.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet, és nem egyszerű szöveg vagy kép?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathportion/) belsejében él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/) elemmel. Képek és egyszerű szövegrészek, amelyek nem tartalmaznak [MathParagraph]-t, nem exportálható képletek.

**Honnan származik a MathML egy prezentációban – PowerPoint‑specifikus vagy szabvány?**

Az export a szabványos MathML‑t (XML) célozza. Az Aspose a Presentation MathML‑t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazásokban és a weben.

**Támogatott‑e a képletek exportálása táblázatokban, SmartArt‑ban, csoportokban stb.?**

Igen, ha ezek az objektumok olyan szövegrészeket tartalmaznak, amelyek rendelkeznek [MathParagraph]-ral (azaz valódi PowerPoint képletek), akkor exportálva lesznek. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja‑e a MathML‑be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentáció fájlt.