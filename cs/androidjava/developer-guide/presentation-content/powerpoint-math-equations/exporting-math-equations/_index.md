---
title: Exportovat matematické rovnice z prezentací na Androidu
linktitle: Exportovat rovnice
type: docs
weight: 30
url: /cs/androidjava/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Exportovat matematické rovnice z PowerPoint prezentací do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro Android v Javě."
---
## **Úvod**

Aspose.Slides pro Android pomocí Java vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice ze snímků (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 
Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.
{{% /alert %}}

## **Export rovnic do LaTeXu**

Aspose.Slides může převést matematickou rovnici PowerPointu přímo do LaTeXu; není potřeba žádný mezilehlý soubor MathML ani externí převaděč. Matematická rovnice je uložena v textovém rámci jako [IMathPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathportion/). Použijte [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) k získání [IMathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathparagraph/), a poté zavolejte [IMathParagraph.toLatex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathparagraph/#toLatex--). Metoda vrací řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámec na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného souboru `.tex`:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) vrací všechny textové rámečky nalezené na snímku. Kontrola typu [IMathPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíčky ani znaky Unicode. Otestujte vrácený řetězec s LaTeXovým enginem, který používá vaše aplikace. Pokud symbol nebo prvek Office Math nemá v tomto prostředí vhodnou reprezentaci, nahraďte jej ve vráceném řetězci příkazem specifickým pro projekt nebo rovnice vynechte a zaznamenejte problém k revizi.

## **Uložení matematických rovnic jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, s kódem pro MathML mají problémy, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oblastech.

Příklad kódu vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Co přesně se exportuje do MathML – odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak zjistím, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci – je specifické pro PowerPoint nebo jde o standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu určenou pro prezentace, která je široce používána napříč aplikacemi a webem.

**Je podporováno exportování vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; nemění soubor prezentace.