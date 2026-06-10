---
title: Matematikai egyenletek exportálása prezentációkból .NET-ben
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/net/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- MathML
- LaTeX
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Zökkenőmentes exportálás a PowerPointból MathML-be az Aspose.Slides for .NET segítségével – megőrizze a formázást és növelje a kompatibilitást."
---
## **Bevezetés**

Aspose.Slides for .NET lehetővé teszi, hogy matematikai egyenleteket exportáljon prezentációkból. Például előfordulhat, hogy a diákon (egy adott prezentációból) lévő matematikai egyenleteket ki kell nyernie, és egy másik programban vagy platformon szeretné használni. 

{{% alert color="primary" %}} 
Az egyenleteket exportálhatja MathML-be, egy népszerű formátumba vagy szabványba, amelyet a weben és számos alkalmazásban látható matematikai egyenletek és hasonló tartalmak számára használnak. 
{{% /alert %}}

## **Matematikai egyenletek mentése MathML-be**

Miközben az emberek könnyen megírják a kódot bizonyos egyenletformátumokhoz, mint a LaTeX, nehezebben tudnak MathML kódot írni, mivel az utóbbit általában alkalmazások generálják automatikusan. A programok könnyen olvassák és értelmezik a MathML-t, mert a kódja XML-ben van, így a MathML széles körben használatos kimeneti és nyomtatási formátumként sok területen. 

Ez a mintakód megmutatja, hogyan exportáljon egy matematikai egyenletet egy prezentációból MathML-be:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **GYIK**

**Mi pontosan kerül exportálásra MathML-be – egy bekezdés vagy egy egyedi formula blokk?**

Exportálhatja akár egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)), akár egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathblock/)) MathML-be. Mindkét típus biztosít egy metódust a MathML írásához.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai formula-e a szokásos szöveg vagy kép helyett?**

Egy formula egy [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/) részeként létezik, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)-al. Képek és szokásos szövegrészek, amelyek nem tartalmaznak [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)-t, nem exportálható formulák.

**Honnan származik a MathML egy prezentációban – PowerPoint‑specifikus vagy szabványos?**

Az export szabványos MathML‑t (XML) célozza. Az Aspose a Presentation MathML‑t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott-e a formulák exportálása táblázatokban, SmartArt‑ban, csoportokban stb.?**

Igen, ha azok az objektumok szövegrészeket tartalmaznak [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)-al (azaz valódi PowerPoint formulákról van szó), akkor exportálódnak. Ha a formula képként van beágyazva, akkor nem.

**Módosítja-e a MathML‑be exportálás az eredeti prezentációt?**

Nem. A MathML írása a formula tartalmának sorosítása, nem módosítja a prezentáció fájlt.