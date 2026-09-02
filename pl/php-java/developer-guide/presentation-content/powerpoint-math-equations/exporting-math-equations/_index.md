---
title: Eksport równań matematycznych z prezentacji w PHP
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/php-java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeX
- PowerPoint do LaTeX
- MathML
- LaTeX
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Eksportuj równania matematyczne z prezentacji PowerPoint do LaTeX lub MathML bezpośrednio przy użyciu Aspose.Slides for PHP via Java."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne na slajdach (z określonej prezentacji) i użyć ich w innym programie lub platformie.

{{% alert color="primary" %}} 
Możesz eksportować równania bezpośrednio do LaTeX lub do MathML, popularnego standardu treści matematycznych używanego w sieci i w wielu aplikacjach.
{{% /alert %}}

## **Eksport równań matematycznych do LaTeX**

Aspose.Slides może konwertować równanie matematyczne PowerPoint bezpośrednio do LaTeX; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [MathPortion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathportion/). Użyj [MathPortion::getMathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathportion/#getMathParagraph), aby uzyskać [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/), a następnie wywołaj [MathParagraph::toLatex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/#toLatex). Metoda zwraca ciąg znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalej przetworzyć.

Poniższy przykład przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie fragmenty matematyczne i zapisuje każde równanie do osobnego pliku `.tex`:

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

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/#getAllTextBoxes) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Sprawdzenie typu [MathPortion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathportion/) oddziela prawdziwe edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie zawsze obsługują te same polecenia, pakiety ani znaki Unicode. Przetestuj zwrócony ciąg znaków przy użyciu silnika LaTeX używanego w Twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zastąp go w zwróconym ciągu poleceniem specyficznym dla projektu lub pomiń równanie i zarejestruj problem do przeglądu.

## **Zapis równań matematycznych jako MathML**

Choć ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukujący w wielu dziedzinach.

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

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

## **FAQ**

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**  
Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/)) jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**  
Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathportion/) i ma [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/). Obrazy i zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzne dla PowerPoint, czy jest standardem?**  
Eksport skierowany jest do standardowego MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacyjnego standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksport formuł wewnątrz tabel, SmartArt, grup itp. jest obsługiwany?**  
Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są eksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**  
Nie. Zapis MathML to serializacja zawartości formuły; nie modyfikuje pliku prezentacji.