---
title: Exportovat matematické rovnice z prezentací v JavaScriptu
linktitle: Exportovat rovnice
type: docs
weight: 30
url: /cs/nodejs-java/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- MathML
- LaTeX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Umožněte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí JavaScriptu a Aspose.Slides pro Node.js – zachovejte formátování a zvyšte kompatibilitu."
---
## **Úvod**

Aspose.Slides vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice ze snímků (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 
Můžete exportovat rovnice do formátu MathML, populárního formátu nebo standardu pro matematické rovnice a podobný obsah, který se objevuje na webu i v mnoha aplikacích. 
{{% /alert %}}

## **Uložit matematické rovnice jako MathML**

Zatímco lidé snadno zapisují kód pro některé formáty rovnic, jako je LaTeX, obtížně zapisují kód pro MathML, protože tento formát má být generován automaticky aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML často používá jako výstupní a tiskový formát v mnoha oblastech.

Tento ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:
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

**Odkud v prezentaci pochází MathML – je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu prezentace standardu, která je široce používána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; nemění soubor prezentace.