---
title: Exportovat matematické rovnice z prezentací v Java
linktitle: Exportovat rovnice
type: docs
weight: 30
url: /cs/java/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Exportujte matematické rovnice z prezentací PowerPoint do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro Java."
---
## **Úvod**

Aspose.Slides umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 

Rovnice můžete exportovat přímo do LaTeXu nebo do MathML, což je populární standard pro matematický obsah používaný na webu i v mnoha aplikacích.

{{% /alert %}}

## **Exportovat matematické rovnice do LaTeXu**

Aspose.Slides dokáže převést matematickou rovnici PowerPointu přímo do LaTeXu; není potřeba mezilehlý soubor MathML ani externí převodník. Matematická rovnice je uložena v textovém rámci jako [IMathPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imathportion/). Použijte [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imathportion/#getMathParagraph--) k získání [IMathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imathparagraph/), a poté zavolejte [IMathParagraph.toLatex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imathparagraph/#toLatex--). Metoda vrátí řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámec na každém snímku, najde všechny matematické úseky a zapíše každou rovnici do samostatného souboru `.tex`:

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
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) vrací všechny textové rámce nalezené na snímku. Kontrola typu [IMathPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové motory a šablony dokumentů nepodporují všechny příkazy, balíčky ani Unicode znaky. Otestujte vrácený řetězec s LaTeXovým motorem, který používá vaše aplikace. Pokud symbol nebo prvek Office Math nemá vhodnou reprezentaci v tomto prostředí, nahraďte jej v řetězci projektem specifickým příkazem nebo rovnice přeskočte a zaznamenejte problém k revizi.

## **Uložit matematické rovnice jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají obtíže s kódem pro MathML, protože ten je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže MathML se běžně používá jako výstupní a tiskový formát v mnoha oborech.

Tento ukázkový kód ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

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

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec, nikoli běžný text nebo obrázek?**

Vzorec žije v [MathPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/). Obrázky a běžné textové úseky bez [MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/) nejsou exportovatelnými vzorci.

**Odkud v prezentaci pochází MathML – je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu určenou pro prezentace, která je široce používána napříč aplikacemi a webem.

**Podporuje se export vzorců uvnitř tabulek, SmartArtu, skupin atd.?**

Ano, pokud tyto objekty obsahují textové úseky s [MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/) (tedy skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; neprovádí žádnou úpravu souboru prezentace.