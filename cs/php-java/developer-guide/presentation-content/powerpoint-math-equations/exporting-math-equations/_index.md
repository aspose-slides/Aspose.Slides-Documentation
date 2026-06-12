---
title: Export matematických rovnic z prezentací v PHP
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/php-java/exporting-math-equations/
keywords:
- export matematických rovnic
- MathML
- LaTeX
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Umožněte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí Aspose.Slides pro PHP přes Java — zachovejte formátování a zvýšte kompatibilitu."
---
## **Úvod**

Aspose.Slides pro PHP přes Java vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 
Můžete exportovat rovnice do MathML, populárního formátu nebo standardu pro matematické rovnice a podobný obsah, který se objevuje na webu i v mnoha aplikacích. 
{{% /alert %}}

## **Uložit matematické rovnice jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají potíže s psaním kódu pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže se MathML běžně používá jako výstupní a tiskový formát v mnoha oblastech. 

Tento ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené dotazy**

**Co přesně se exportuje do MathML – odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci – je specifické pro PowerPoint nebo jde o standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu zaměřenou na prezentace, která je široce používána v aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializace obsahu vzorce; nemění soubor prezentace.