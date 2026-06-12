---
title: Export matematických rovnic z prezentací v Javě
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/java/exporting-math-equations/
keywords:
- export matematických rovnic
- MathML
- LaTeX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Umožněte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí Aspose.Slides pro Java—zachovejte formátování a zvyšte kompatibilitu."
---
## **Úvod**

Aspose.Slides umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě. 

{{% alert color="primary" %}} 

Můžete exportovat rovnice do MathML, populárního formátu nebo standardu pro matematické rovnice a podobný obsah, který se objevuje na webu a v mnoha aplikacích. 

{{% /alert %}}

## **Uložit matematické rovnice jako MathML**

Zatímco lidé snadno zapisují kód pro některé formáty rovnic, jako je LaTeX, mají problémy s psaním kódu pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oblastech. 

Tento ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

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

**Co přesně se exportuje do MathML—odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud v prezentaci pochází MathML – je to specifické pro PowerPoint nebo standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu určenou pro prezentace, která je široce používána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializací obsahu vzorce; nezasahuje do souboru prezentace.