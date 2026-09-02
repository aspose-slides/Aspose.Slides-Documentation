---
title: Export matematických rovnic z prezentací v PHP
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/php-java/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Exportujte matematické rovnice z PowerPoint prezentací do LaTeXu nebo MathML přímo pomocí Aspose.Slides pro PHP prostřednictvím Javy."
---
## **Úvod**

Aspose.Slides pro PHP prostřednictvím Javy vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě.

{{% alert color="primary" %}} 
Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.
{{% /alert %}}

## **Export rovnic do LaTeXu**

Aspose.Slides může převést matematickou rovnici PowerPointu přímo do LaTeXu; není potřeba mezilehlý soubor MathML ani externí převodník. Matematická rovnice je uložena v textovém rámci jako [MathPortion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathportion/). Použijte [MathPortion::getMathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathportion/#getMathParagraph) pro získání [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/), a poté zavolejte [MathParagraph::toLatex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/#toLatex). Metoda vrátí řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prozkoumá každý textový rámec na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného souboru `.tex`:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/#getAllTextBoxes) vrací všechny textové rámce nalezené na snímku. Kontrola typu [MathPortion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathportion/) odděluje skutečné editovatelné rovnice od obyčejného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíky ani Unicode znaky. Otestujte vrácený řetězec s LaTeXovým enginem, který vaše aplikace používá. Pokud symbol nebo prvek Office Math nemá v tomto prostředí vhodné vyjádření, nahraďte jej ve vráceném řetězci příkazem specifickým pro projekt nebo rovnice přeskočte a zaznamenejte problém k revizi.

## **Uložení rovnic do MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají obtíže psát kód pro MathML, protože tento formát je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže MathML je běžně používáno jako výstupní a tiskový formát v mnoha oblastech.

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

## **Často kladené otázky**

**Co přesně se exportuje do MathML — odstavec nebo samostatný blok vzorce?**  
Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/)) nebo samostatný blok ([MathBlock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec, a ne obyčejný text nebo obrázek?**  
Vzor se nachází v [MathPortion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud pochází MathML v prezentaci — je to specifické pro PowerPoint nebo standard?**  
Export cílí na standardní MathML (XML). Aspose používá Presentation MathML — prezentační podmnožinu standardu, která je široce využívána napříč aplikacemi a webem.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**  
Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**  
Ne. Zapsání MathML je serializace obsahu vzorce; nemění soubor prezentace.