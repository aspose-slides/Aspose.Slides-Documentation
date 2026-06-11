---
title: Eksport równań matematycznych z prezentacji w PHP
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/php-java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Umożliw bezproblemowy eksport równań matematycznych z PowerPointa do MathML przy użyciu Aspose.Slides dla PHP via Java — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java umożliwia eksport równań matematycznych z prezentacji. Na przykład może być konieczne wyodrębnienie równań matematycznych ze slajdów (z konkretnej prezentacji) i użycie ich w innym programie lub platformie.

{{% alert color="primary" %}} 
Możesz eksportować równania do MathML, popularnego formatu lub standardu dla równań matematycznych i podobnych treści widocznych w sieci i w wielu aplikacjach. 
{{% /alert %}}

## **Zapisz równania matematyczne jako MathML**

Chociaż ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach. 

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

Możesz wyeksportować cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/)) lub pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathportion/) i ma [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/). Obrazy i zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — jest to specyficzne dla PowerPointa czy standard?**

Eksport skierowany jest do standardowego MathML (XML). Aspose używa Presentation MathML — podzbioru standardu przeznaczonego do prezentacji, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy wspierany jest eksport formuł znajdujących się w tabelach, SmartArt, grupach itp.?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są one eksportowane. Jeśli formuła jest osadzona jako obraz, nie jest.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML jestSerializacją zawartości formuły; nie modyfikuje pliku prezentacji.