---
title: Matematikai egyenletek exportálása előadásokból .NET-ben
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/net/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- egyenletek exportálása LaTeX-be
- PowerPoint LaTeX-be
- MathML
- LaTeX
- PowerPoint
- előadás
- .NET
- C#
- Aspose.Slides
description: "Matematikai egyenletek exportálása PowerPoint előadásokból közvetlenül LaTeX vagy MathML formátumba az Aspose.Slides for .NET segítségével."
---
## **Bevezetés**

Az Aspose.Slides for .NET lehetővé teszi, hogy matematikai egyenleteket exportáljon a bemutatókból. Például szükség lehet a diákon (egy adott bemutatóból) található matematikai egyenletek kinyerésére, és azok egy másik programban vagy platformon történő felhasználására. 

{{% alert color="primary" %}} 
Az egyenleteket közvetlenül exportálhatja LaTeX-be vagy MathML-be, amely egy népszerű szabvány a weben és számos alkalmazásban használt matematikai tartalom számára.
{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX-be**

Az Aspose.Slides közvetlenül képes egy PowerPoint matematikai egyenletet LaTeX-be konvertálni; köztes MathML fájlra vagy külső konvertorra nincs szükség. A matematikai egyenlet szövegkeretben tárolódik, mint egy [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/). Használja a [MathPortion.MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/mathparagraph/) metódust egy [IMathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathparagraph/) lekérdezéséhez, majd hívja meg a [IMathParagraph.ToLatex](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathparagraph/tolatex/). A metódus egy karakterláncot ad vissza, amelyet menthet, megjeleníthet, elküldhet egy másik alkalmazásnak, vagy tovább feldolgozhat.

A következő példa minden szövegkeretet ellenőriz minden dián, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextboxes/) visszaadja az adott dián található összes szövegkeretet. A [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/) típusellenőrzés elválasztja a valódi szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszaadott karakterláncot a saját alkalmazásában használt LaTeX motorral. Ha egy szimbólum vagy Office Math elem nem rendelkezik megfelelő ábrázolással az adott környezetben, cserélje ki a visszaadott karakterláncban egy projektre specifikus parancsra, vagy hagyja ki az egyenletet, és rögzítse a problémát későbbi felülvizsgálatra.

## **Matematikai egyenletek mentése MathML formátumba**

Miközben az emberek könnyen megírják a kódot bizonyos egyenletformátumokhoz, például a LaTeX-hez, a MathML kód megírása számukra nehéz, mivel azt általában alkalmazások generálják automatikusan. A programok könnyen olvassák és elemzik a MathML-t, mert a kódja XML-ben van, így a MathML gyakran használt kimeneti és nyomtatási formátum sok területen. 

Ez a minta kód szemlélteti, hogyan exportáljon egy matematikai egyenletet egy bemutatóból MathML-be:

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

**Mi pontosan kerül exportálásra MathML-be – egy bekezdés vagy egy egyedi képletblokk?**  
Exportálhat egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathblock/)) MathML-be. Mindkét típus rendelkezik egy metódussal a MathML írásához.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e, és nem egyszerű szöveg vagy kép?**  
A képlet egy [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/) részeként létezik, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)-al. Képek és szabályos szövegrészek, amelyeknek nincs [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/) eleme, nem exportálhatóak képletekként.

**Honnan származik a MathML egy bemutatóban – PowerPoint-specifikus vagy egy szabvány?**  
Az export célja a szabványos MathML (XML). Az Aspose a Presentation MathML-t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt alkalmazásokban és a weben.

**Támogatott-e a képletek exportálása táblázatokból, SmartArt-ból, csoportokból stb.?**  
Igen, ha ezek az objektumok szövegrészeket tartalmaznak, amelyeknek van [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/) eleme (azaz valódi PowerPoint képletek), akkor exportálásra kerülnek. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja az export MathML-be a forrás bemutatót?**  
Nem. A MathML írása a képlet tartalmának sorosítása, nem módosítja a bemutató fájlt.