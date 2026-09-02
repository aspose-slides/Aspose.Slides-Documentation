---
title: Exportovat matematické rovnice z prezentací v .NET
linktitle: Exportovat rovnice
type: docs
weight: 30
url: /cs/net/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Exportujte matematické rovnice z PowerPoint prezentací do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro .NET."
---
## **Úvod**

Aspose.Slides pro .NET vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice ze snímků (z konkrétní prezentace) a použít je v jiném programu nebo platformě. 

{{% alert color="primary" %}} 

Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.

{{% /alert %}}

## **Export matematických rovnic do LaTeX**

Aspose.Slides může převést matematickou rovnici PowerPointu přímo do LaTeXu; není potřeba mezilehlý soubor MathML ani externí převaděč. Matematická rovnice je uložena v textovém rámečku jako [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/). Použijte [MathPortion.MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/mathparagraph/) k získání [IMathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/imathparagraph/), a poté zavolejte [IMathParagraph.ToLatex](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/imathparagraph/tolatex/). Metoda vrátí řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámeček na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného souboru `.tex`:

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextboxes/) vrací všechny textové rámečky nalezené na snímku. Kontrola typu [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíčky ani znakové sady Unicode. Otestujte vrácený řetězec pomocí LaTeXového enginu používaného ve vaší aplikaci. Pokud symbol nebo prvek Office Math nemá v tomto prostředí vhodnou reprezentaci, nahraďte jej ve vráceném řetězci projektovým příkazem nebo rovnici přeskočte a zaznamenejte problém k revizi.

## **Uložení matematických rovnic jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají potíže psát kód pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML často používá jako výstupní a tiskový formát v mnoha oblastech. 

Tento ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

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

## **Často kladené otázky**

**Co přesně se exportuje do MathML - odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak zjistím, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci - je specifické pro PowerPoint nebo jde o standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML - prezentační podmnožinu standardu, která je široce používána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializací obsahu vzorce; nemění soubor prezentace.