---
title: Matematikai egyenletek exportálása prezentációkból .NET‑ben
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
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Matematikai egyenletek exportálása PowerPoint prezentációkból közvetlenül LaTeX vagy MathML formátumba az Aspose.Slides for .NET segítségével."
---
## **Bevezetés**

Az Aspose.Slides for .NET lehetővé teszi a matematikai egyenletek exportálását a prezentációkból. Például szükség lehet a diákon (egy adott prezentációból) lévő matematikai egyenletek kinyerésére, és azok egy másik programban vagy platformon való felhasználására. 

{{% alert color="info" %}} 

Az egyenleteket közvetlenül exportálhatja LaTeX-be vagy MathML-be, egy népszerű szabvány a weben és számos alkalmazásban használt matematikai tartalomra.

{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX‑be**

Az Aspose.Slides közvetlenül képes PowerPoint matematikai egyenletet LaTeX‑be konvertálni; köztes MathML‑fájlra és külső konverterre nincs szükség. A matematikai egyenlet szövegdobozban [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/)‑ként tárolódik. Használja a [MathPortion.MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/mathparagraph/)‑t egy [IMathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathparagraph/) lekéréséhez, majd hívja a [IMathParagraph.ToLatex](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathparagraph/tolatex/). A metódus egy karakterláncot ad vissza, amelyet menthet, megjeleníthet, elküldhet egy másik alkalmazásnak, vagy tovább feldolgozhat.

Az alábbi példa minden dián minden szövegdobozt átnéz, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextboxes/) visszaadja az egy dián megtalált összes szövegdobozt. A [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/) típusellenőrzés elkülöníti a valódi szerkeszthető egyenleteket a rendes szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszaadott karakterláncot az alkalmazásában használt LaTeX motorral. Ha egy szimbólum vagy Office Math elem nem rendelkezik megfelelő ábrázolással abban a környezetben, cserélje ki a visszaadott karakterláncban egy projektre szabott parancsra, vagy hagyja ki az egyenletet, és rögzítse a problémát felülvizsgálatra.

## **Matematikai egyenletek mentése MathML‑ként**

Míg az emberek könnyen írják a kódot olyan egyenletformátumokhoz, mint a LaTeX, nehezen tudják kézzel megírni a MathML kódját, mivel ezt utóbbit alkalmazásoknak kell automatikusan generálniuk. A programok könnyen olvassák és dolgozzák fel a MathML‑t, mivel kódja XML‑ben van, ezért a MathML gyakran használatos kimeneti és nyomtatási formátumként számos területen. 

Ez a mintakód bemutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML‑be:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

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

**Mi kerül pontosan exportálásra MathML-be – egy bekezdés vagy egy egyedi képletblokk?**

Exportálhatja vagy egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)), vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathblock/)) MathML‑be. Mindkét típus rendelkezik egy metódussal a MathML‑be íráshoz.

**Hogyan deríthetem ki, hogy egy dián lévő objektum matematikai képlet-e a szokásos szöveg vagy kép helyett?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/)‑ban él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/)-nal. A képek és a szokásos szövegrészek, amelyeknek nincs [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/), nem exportálható képletek.

**Honnan származik a MathML egy prezentációban – PowerPoint‑specifikus vagy szabványos?**

Az export a szabványos MathML-re (XML) irányul. Az Aspose a Presentation MathML-t használja – a szabvány bemutató alhalmazát –, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott a képletek exportálása táblázatokban, SmartArt‑ban, csoportokban stb.?**

Igen, ha ezek az objektumok olyan szövegrészeket tartalmaznak, amelyeknek van [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/) (azaz valódi PowerPoint képletek), akkor exportálva lesznek. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja a MathML‑be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentáció fájlt.