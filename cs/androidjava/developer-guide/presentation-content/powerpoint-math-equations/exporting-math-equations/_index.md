---
title: Export matematických rovnic z prezentací na Androidu
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/androidjava/exporting-math-equations/
keywords:
- export matematických rovnic
- MathML
- LaTeX
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Odhalte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí Aspose.Slides pro Android via Java — zachovejte formátování a zvyšte kompatibilitu."
---
## **Úvod**

Aspose.Slides pro Android via Java vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 
Můžete exportovat rovnice do MathML, populárního formátu nebo standardu pro matematické rovnice a podobný obsah, který se zobrazuje na webu a v mnoha aplikacích. 
{{% /alert %}}

## **Export matematických rovnic z prezentací**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají potíže s psaním kódu pro MathML, protože poslední je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oblastech. 

Tento ukázkový kód vám ukáže, jak exportovat matematickou rovnici z prezentace do MathML:

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

**Jak mohu rozpoznat, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci – je specifické pro PowerPoint, nebo je to standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu pro prezentace, která je široce používána v aplikacích a na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; neovlivňuje soubor prezentace.