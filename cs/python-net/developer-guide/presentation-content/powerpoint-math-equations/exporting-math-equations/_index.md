---
title: Exportovat matematické rovnice z prezentací v Pythonu
linktitle: Exportovat rovnice
type: docs
weight: 30
url: /cs/python-net/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Exportovat matematické rovnice z prezentací PowerPoint do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro Python přes .NET."
---
## **Úvod**

Aspose.Slides pro Python přes .NET umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat rovnice z konkrétních snímků a znovu je použít v jiném programu nebo platformě.

{{% alert color="primary" %}}
Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.
{{% /alert %}}

## **Exportovat matematické rovnice do LaTeXu**

Aspose.Slides může převést matematickou rovnici PowerPointu přímo do LaTeXu; není vyžadován mezilehlý soubor MathML ani externí konvertor. Matematická rovnice je uložena v textovém rámečku jako [MathPortion](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathportion/). Použijte [MathPortion.math_paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) k získání [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/), a poté zavolejte [MathParagraph.to_latex](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). Metoda vrátí řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámeček na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného souboru `.tex`:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) vrací všechny textové rámečky nalezené na snímku. Kontrola typu [MathPortion](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíčky ani Unicode znaky. Otestujte vrácený řetězec s LaTeXovým enginem, který vaše aplikace používá. Pokud symbol nebo prvek Office Math nemá v tomto prostředí vhodnou reprezentaci, nahraďte jej v vráceném řetězci projektním příkazem nebo rovnici přeskočte a zaznamenejte problém k revizi.

## **Uložit matematické rovnice jako MathML**

Ačkoliv lidé mohou snadno psát LaTeX, MathML je obvykle generováno aplikacemi automaticky. Protože MathML je založeno na XML, programy jej mohou spolehlivě číst a parsovat, takže je běžně používáno jako výstupní a tiskový formát v mnoha oblastech.

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

**Co přesně se exportuje do MathML—odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak zjistím, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzor se nachází v [MathPortion](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci—je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML—prezentační podmnožinu standardu—která je široce používána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; neprovádí změny v souboru prezentace.