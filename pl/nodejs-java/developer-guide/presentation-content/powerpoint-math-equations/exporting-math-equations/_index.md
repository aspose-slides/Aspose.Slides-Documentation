---
title: Eksport równań matematycznych z prezentacji w JavaScript
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/nodejs-java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Umożliw bezproblemowy eksport równań matematycznych z PowerPoint do MathML przy użyciu JavaScript i Aspose.Slides dla Node.js — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wprowadzenie**

Aspose.Slides umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z konkretnej prezentacji) i użyć ich w innym programie lub platformie.

{{% alert color="primary" %}} 
Możesz eksportować równania do MathML, popularnego formatu lub standardu dla równań matematycznych i podobnych treści widocznych w sieci i w wielu aplikacjach. 
{{% /alert %}}

## **Zapisz równania matematyczne jako MathML**

Podczas gdy ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach.

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

Możesz wyeksportować zarówno cały paragraf matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/)) jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy jest standardem?**

Eksport dotyczy standardowego MathML (XML). Aspose używa Presentation MathML — podzestawu prezentacji tego standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy obsługiwany jest eksport formuł znajdujących się w tabelach, SmartArt, grupach itp.?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są one eksportowane. Jeśli formuła jest osadzona jako obraz, nie jest.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML to serializacja zawartości formuły; nie modyfikuje pliku prezentacji.