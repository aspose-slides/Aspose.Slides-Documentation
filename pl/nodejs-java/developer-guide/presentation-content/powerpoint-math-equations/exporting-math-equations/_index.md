---
title: Eksport równań matematycznych z prezentacji w JavaScript
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/nodejs-java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeX
- PowerPoint do LaTeX
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Eksport równań matematycznych z prezentacji PowerPoint do LaTeX lub MathML bezpośrednio przy użyciu Aspose.Slides dla Node.js w Javie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład, możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z konkretnej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="primary" %}} 
Możesz eksportować równania bezpośrednio do LaTeX lub do MathML, popularnego standardu zawartości matematycznej używanego w sieci i w wielu aplikacjach.
{{% /alert %}}

## **Eksportowanie równań matematycznych do LaTeX**

Aspose.Slides może bezpośrednio konwertować równanie matematyczne PowerPointa na LaTeX; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [MathPortion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathportion/). Użyj [MathPortion.getMathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) aby uzyskać [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/), a następnie wywołaj [MathParagraph.toLatex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Metoda zwraca łańcuch znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalej przetworzyć.

Poniższy przykład przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie części matematyczne i zapisuje każde równanie do osobnego `.tex` pliku:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Kontrola typu [MathPortion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathportion/) oddziela prawdziwe edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie wszystkie obsługują te same polecenia, pakiety ani znaki Unicode. Przetestuj zwrócony łańcuch znaków za pomocą silnika LaTeX używanego w Twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zastąp go w zwróconym łańcuchu poleceniem specyficznym dla projektu lub pomiń równanie i zanotuj problem do przeglądu.

## **Zapis równań matematycznych jako MathML**

Choć ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, dlatego MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

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

## **FAQ**

**Co dokładnie jest eksportowane do MathML — paragraf czy pojedynczy blok formuły?**  
Możesz wyeksportować zarówno cały paragraf matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/)), jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**  
Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy jest standardem?**  
Eksport celuje w standardowy MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacji standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksport formuł znajdujących się w tabelach, SmartArt, grupach itp. jest obsługiwany?**  
Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są one eksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**  
Nie. Zapis MathML to serializacja zawartości formuły; nie modyfikuje pliku prezentacji.