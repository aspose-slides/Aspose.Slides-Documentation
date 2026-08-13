---
title: Eksport równań matematycznych z prezentacji w Java
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeX
- PowerPoint do LaTeX
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Eksport równań matematycznych z prezentacji PowerPoint do LaTeX lub MathML bezpośrednio przy użyciu Aspose.Slides dla Java."
---
## **Wprowadzenie**

Aspose.Slides umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z określonej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="info" %}} 

Możesz eksportować równania bezpośrednio do LaTeX lub do MathML, popularnego standardu zawartości matematycznej używanego w sieci i w wielu aplikacjach.

{{% /alert %}}

## **Eksportowanie równań matematycznych do LaTeX**

Aspose.Slides może konwertować równanie matematyczne PowerPoint bezpośrednio do LaTeX; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [IMathPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imathportion/). Użyj [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imathportion/#getMathParagraph--) aby uzyskać [IMathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imathparagraph/), a następnie wywołaj [IMathParagraph.toLatex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imathparagraph/#toLatex--). Metoda zwraca łańcuch znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalej przetworzyć.

Poniższy przykład przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie fragmenty matematyczne i zapisuje każde równanie do osobnego pliku `.tex`:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Sprawdzenie typu [IMathPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imathportion/) oddziela prawdziwe edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie obsługują wszystkich tych samych poleceń, pakietów ani znaków Unicode. Przetestuj zwrócony łańcuch przy użyciu silnika LaTeX używanego w Twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zastąp go w zwróconym łańcuchu poleceniem specyficznym dla projektu lub pomiń równanie i zanotuj problem do przeglądu.

## **Zapis równań matematycznych jako MathML**

Chociaż ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy odczytują i analizują MathML łatwo, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **FAQ**

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**

Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/)) jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPoint, czy jest standardem?**

Eksport skierowany jest do standardowego MathML (XML). Aspose używa Presentation MathML — podzestawu prezentacji standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksportowanie formuł wewnątrz tabel, SmartArt, grup itp. jest obsługiwane?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/), (czyli prawdziwe formuły PowerPoint), są one eksportowane. Jeśli formuła jest osadzona jako obraz, nie jest.

**Czy eksportowanie do MathML modyfikuje pierwotną prezentację?**

Nie. Zapis MathML jest serializacją zawartości formuły; nie modyfikuje pliku prezentacji.