---
title: Eksport równań matematycznych z prezentacji w Javie
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Umożliw bezproblemowy eksport równań matematycznych z PowerPointa do MathML przy użyciu Aspose.Slides dla Javy — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wstęp**

Aspose.Slides umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład, możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z konkretnej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="primary" %}} 

Możesz eksportować równania do MathML, popularnego formatu lub standardu dla równań matematycznych i podobnych treści widocznych w Internecie i w wielu aplikacjach. 

{{% /alert %}}

## **Zapisz równania matematyczne jako MathML**

Podczas gdy ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i do drukowania w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

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

## **FAQ**

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**

Możesz wyeksportować cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/)) lub pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy jest standardem?**

Eksport jest skierowany do standardowego MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacji standardu — który jest szeroko stosowany w aplikacjach i w Internecie.

**Czy eksportowanie formuł wewnątrz tabel, SmartArt, grup itp. jest obsługiwane?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są eksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapisywanie MathML to serializacja zawartości formuły; nie modyfikuje pliku prezentacji.