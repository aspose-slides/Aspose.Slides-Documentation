---
title: Eksportowanie równań matematycznych z prezentacji w .NET
linktitle: Eksportuj równania
type: docs
weight: 30
url: /pl/net/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Umożliw płynny eksport równań matematycznych z PowerPoint do MathML przy użyciu Aspose.Slides for .NET — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wprowadzenie**

Aspose.Slides for .NET umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z określonej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="primary" %}} 
Możesz eksportować równania do MathML, popularnego formatu lub standardu dla równań matematycznych i podobnych treści widocznych w sieci i w wielu aplikacjach. 
{{% /alert %}}

## **Zapisz równania matematyczne jako MathML**

Choć ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i parsują MathML, ponieważ jego kod jest w XML, dlatego MathML jest powszechnie używany jako format wyjściowy i do drukowania w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

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

## **FAQ**

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**

Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/)) jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy to standard?**

Eksport dotyczy standardowego MathML (XML). Aspose używa Presentation MathML — podzestawu prezentacji standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksport formuł znajdujących się w tabelach, SmartArt, grupach itp. jest obsługiwany?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/) (czyli prawdziwe formuły PowerPoint), zostaną wyeksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML jest serializacją zawartości formuły; nie modyfikuje pliku prezentacji.