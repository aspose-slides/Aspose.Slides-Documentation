---
title: Export matematických rovnic z prezentací v .NET
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/net/exporting-math-equations/
keywords:
- export matematických rovnic
- MathML
- LaTeX
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Umožněte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí Aspose.Slides pro .NET—zachovejte formátování a zvýšte kompatibilitu."
---
## **Úvod**

Aspose.Slides pro .NET umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě. 

{{% alert color="primary" %}} 
Můžete exportovat rovnice do MathML, populárního formátu nebo standardu pro matematické rovnice a podobný obsah, který se používá na webu i v mnoha aplikacích. 
{{% /alert %}}

## **Uložení matematických rovnic jako MathML**

Zatímco lidé snadno zapisují kód pro některé formáty rovnic, jako je LaTeX, mají obtíže se zápisem kódu pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a analyzují MathML, protože jeho kód je v XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oborech. 

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

**Co přesně se exportuje do MathML — odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud v prezentaci pochází MathML — je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML — prezentační podmnožinu standardu, která je široce používána napříč aplikacemi a webem.

**Je podporován export vzorců ve tabulkách, SmartArt, skupinách apod.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není exportován.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializací obsahu vzorce; nemění soubor prezentace.