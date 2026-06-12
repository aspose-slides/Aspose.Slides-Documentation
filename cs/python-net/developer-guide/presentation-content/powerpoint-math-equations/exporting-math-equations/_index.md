---
title: Export matematických rovnic z prezentací v Pythonu
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/python-net/exporting-math-equations/
keywords:
- export matematických rovnic
- MathML
- LaTeX
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Umožněte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí Aspose.Slides pro Python via .NET — zachovejte formátování a zvyšte kompatibilitu."
---
## **Úvod**

Aspose.Slides for Python via .NET vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat rovnice ze specifických snímků a znovu je použít v jiném programu nebo platformě.

{{% alert color="primary" %}}
Můžete exportovat rovnice do MathML, široce používaného standardu pro reprezentaci matematického obsahu na webu a v mnoha aplikacích.
{{% /alert %}}

## **Uložit matematické rovnice jako MathML**

Ačkoli lidé mohou snadno psát LaTeX, MathML se obvykle generuje automaticky aplikacemi. Protože je MathML založen na XML, programy jej dokážou spolehlivě číst a parsovat, a proto se často používá jako výstupní a tiskový formát v mnoha oborech.

Následující ukázkový kód ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **Často kladené otázky**

**Co přesně se exportuje do MathML – odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud v prezentaci pochází MathML – je specifické pro PowerPoint nebo je to standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – prezentační podmnožinu standardu, která je široce používána v aplikacích i na webu.

**Je podporováno exportování vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není exportovatelný.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializací obsahu vzorce; nemění soubor prezentace.