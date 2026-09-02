---
title: Export matematických rovnic z prezentací v JavaScriptu
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/nodejs-java/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportujte matematické rovnice z PowerPoint prezentací do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro Node.js přes Java."
---
## **Úvod**

Aspose.Slides vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice ze snímků (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 

Rovnice můžete exportovat přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu i v mnoha aplikacích.

{{% /alert %}}

## **Export matematických rovnic do LaTeXu**

Aspose.Slides dokáže převést rovnici PowerPointu přímo do LaTeXu; není potřeba mezilehlý soubor MathML ani externí převodník. Rovnice je uložena v textovém rámečku jako [MathPortion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathportion/). Použijte [MathPortion.getMathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) k získání [MathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/), a poté zavolejte [MathParagraph.toLatex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Metoda vrátí řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámec na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného souboru `.tex`:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) vrací všechny textové rámce nalezené na snímku. Kontrola typu [MathPortion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathportion/) odděluje skutečné editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny příkazy, balíčky ani Unicode znaky. Otestujte vrácený řetězec s LaTeXovým enginem, který používá vaše aplikace. Pokud symbol nebo prvek Office Math nemá v daném prostředí vhodnou reprezentaci, nahraďte jej ve vráceném řetězci projektem specifickým příkazem nebo rovnici přeskočte a zaznamenejte problém k revizi.

## **Uložit matematické rovnice jako MathML**

Lidé snadno zapisují kód pro některé formáty rovnic, jako je LaTeX, ale mají potíže se zápisem kódu pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oblastech.

Tento ukázkový kód vám ukazuje, jak exportovat rovnici z prezentace do MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Co přesně se exportuje do MathML – odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak mohu poznat, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci – je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu určenou pro prezentace –, která je široce používána napříč aplikacemi a webem.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zapisování MathML je serializací obsahu vzorce; nemění soubor prezentace.