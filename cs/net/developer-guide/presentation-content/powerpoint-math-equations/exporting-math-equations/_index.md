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

{{% alert color="info" %}} 
Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.
{{% /alert %}}

## **Export rovnic do LaTeX**

Aspose.Slides může převést matematickou rovnici z PowerPointu přímo do LaTeXu; není vyžadován mezilehlý soubor MathML ani externí konvertor. Matematická rovnice je uložena v textovém rámci jako [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/). Použijte [MathPortion.MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/mathparagraph/) k získání [IMathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/imathparagraph/), a poté zavolejte [IMathParagraph.ToLatex](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/imathparagraph/tolatex/). Metoda vrací řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámec na každém snímku, najde všechny matematické úseky a zapíše každou rovnici do samostatného souboru `.tex`:

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextboxes/) vrací všechny textové rámy nalezené na snímku. Kontrola typu [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíčky ani Unicode znaky. Otestujte vrácený řetězec s LaTeXovým enginem, který používá vaše aplikace. Pokud symbol nebo prvek Office Math nemá ve stejném prostředí vhodné zastoupení, nahraďte jej v vráceném řetězci projektem specifickým příkazem nebo rovnici přeskočte a zaznamenejte problém k revizi.

## **Uložení rovnic jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají potíže psát kód pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy čtou a parsují MathML snadno, protože jeho kód je v XML, takže MathML je běžně používán jako výstupní a tiskový formát v mnoha oblastech. 

Ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

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

## **Často kladené otázky**

**Co přesně se exportuje do MathML—odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak mohu poznat, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové úseky bez [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud v prezentaci pochází MathML—je specifické pro PowerPoint nebo je to standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML—prezentační podmnožinu standardu, která je široce využívána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové úseky s [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPoint vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; nemění soubor prezentace.