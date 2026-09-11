---
title: Export matematických rovnic z prezentací v Pythonu
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/python-java/exporting-math-equations/
keywords:
- export matematických rovnic
- export rovnic do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Exportujte matematické rovnice z prezentací PowerPoint do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro Python přes Java."
---
## **Úvod**

Aspose.Slides vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě. 

{{% alert color="info" title="Note" %}} 

Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.

{{% /alert %}}

## **Export matematických rovnic do LaTeXu**

Aspose.Slides dokáže převést matematickou rovnici z PowerPointu přímo do LaTeXu; není potřeba mezilehlý soubor MathML ani externí konvertor. Matematická rovnice je uložena v textovém rámci jako [MathPortion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathportion/). Použijte [MathPortion.getMathParagraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathportion/#getMathParagraph), abyste získali [MathParagraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathparagraph/), a poté zavolejte [MathParagraph.toLatex](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathparagraph/#toLatex). Metoda vrací řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámec na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného `.tex` souboru:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/#getAllTextBoxes) vrací všechny textové rámce nalezené na snímku. Kontrola typu [MathPortion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíčky ani znaky Unicode. Otestujte vrácený řetězec s LaTeXovým enginem, který používá vaše aplikace. Pokud symbol nebo prvek Office Math nemá v tomto prostředí vhodnou reprezentaci, nahraďte jej v vráceném řetězci projektem specifickým příkazem nebo rovnice přeskočte a zaznamenejte problém k revizi.

## **Uložení matematických rovnic jako MathML**

Zatímco lidé mohou snadno psát kód pro některé formáty rovnic, například LaTeX, MathML je obtížnější psát ručně, protože je navrženo k automatickému generování aplikacemi. Programy mohou snadno číst a parsovat MathML, protože je založeno na XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oblastech. 

Ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **Časté dotazy**

**Co přesně je exportováno do MathML – odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak mohu zjistit, že objekt na snímku je matematický vzorec, nikoli běžný text nebo obrázek?**

Vzorec je uložen v [MathPortion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci – je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu určenou pro prezentace, která je široce používána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mathparagraph/) (t.j. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializací obsahu vzorce; nemění soubor prezentace.