---
title: Eksportowanie równań matematycznych z prezentacji na Androidzie
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/androidjava/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odblokuj płynny eksport równań matematycznych z PowerPoint do MathML przy użyciu Aspose.Slides for Android via Java — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java pozwala na eksportowanie równań matematycznych z prezentacji. Na przykład, możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z określonej prezentacji) i użyć ich w innym programie lub platformie.

{{% alert color="primary" %}} 
Możesz wyeksportować równania do formatu MathML, popularnego formatu lub standardu dla równań matematycznych i podobnych treści widocznych w sieci i w wielu aplikacjach. 
{{% /alert %}}

## **Eksportowanie równań matematycznych z prezentacji**

Choć ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten format ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach. 

Poniższy przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

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

**Co dokładnie jest eksportowane do MathML — paragraf czy pojedynczy blok formuły?**  

Możesz wyeksportować cały paragraf matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mathparagraph/)) lub pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest równaniem matematycznym, a nie zwykłym tekstem lub obrazem?**  

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — jest specyficzny dla PowerPointa czy jest standardem?**  

Eksport skierowany jest do standardowego MathML (XML). Aspose używa Presentation MathML — podzestawu prezentacji tego standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksportowanie formuł wewnątrz tabel, SmartArt, grup itp. jest obsługiwane?**  

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są eksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksportowanie do MathML modyfikuje oryginalną prezentację?**  

Nie. Zapis MathML to serializacja treści formuły; nie modyfikuje pliku prezentacji.