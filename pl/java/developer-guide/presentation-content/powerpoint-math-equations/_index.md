---
title: Dodaj równania matematyczne do prezentacji PowerPoint w Javie
linktitle: Równania matematyczne w PowerPoint
type: docs
weight: 80
url: /pl/java/powerpoint-math-equations/
keywords:
- równanie matematyczne
- symbol matematyczny
- formuła matematyczna
- tekst matematyczny
- dodaj równanie matematyczne
- dodaj symbol matematyczny
- dodaj formułę matematyczną
- dodaj tekst matematyczny
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Wstawiaj i edytuj równania matematyczne w PowerPoint PPT i PPTX przy użyciu Aspose.Slides for Java, obsługując OMML, kontrolę formatowania oraz przejrzyste przykłady kodu Java."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Dzięki Aspose.Slides for Java możesz programowo tworzyć taki sam rodzaj treści matematycznej: ułamki, pierwiastki, funkcje, granice, operatory N-ary, macierze, tablice oraz sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj dodają równania z **Insert > Equation**:

![Karta Insert w PowerPoint z wybraną komendą Equation](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalne równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides tworzy ten tekst matematyczny przy użyciu trzech głównych obiektów:

- Kształt matematyczny, tworzony za pomocą [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), jest kształtem, który zawiera równanie.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) przechowuje treść matematyczną wewnątrz ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) oraz metod fluent z [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) aby kod był krótki i czytelny.

W scenariuszach eksportu MathML zobacz [Export Math Equations from Presentations in Java](/slides/pl/java/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład używa [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) do utworzenia kształtu matematycznego i dodaje twierdzenie Pitagorasa:

![Równanie c kwadrat równa się a kwadrat plus b kwadrat](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), i dodaj bloki matematyczne lub elementy matematyczne do niego.

{{% /alert %}}

## **Dodaj ułamki**

Użyj [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/).

![Ułamek matematyczny nachylony pokazujący jeden podzielony przez x](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby uzyskać ułamek stosowany, użyj [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Dodaj pierwiastki**

Użyj [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Bieżący element staje się podstawą, a argument określa stopień.

![Wyrażenie pierwiastka n-tego z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj funkcje i granice**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) lub [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) dla funkcji takich jak `sin(x)`, `log(x)` lub własnych nazw funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) lub użyj [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![Granica x gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby użyć własnej nazwy funkcji, ustaw nazwę funkcji jako bieżący element i wywołaj [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) z jej argumentem:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Dodaj operatory N-ary i całki**

Użyj [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) dla sum, unii, przecięć i innych dużych operatorów. Użyj [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) dla całek. Obie metody pozwalają ustawić dolne i górne granice.

![Suma z dolną i górną granicą](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operatory N-ary służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` są zazwyczaj dodawane jako [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) i łączone w wyrażenie.

Dla całki użyj [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) dla wierszy i kolumn. Macierze domyślnie nie zawierają nawiasów, więc otaczaj macierz nawiasami, klamrami lub nawiasami kwadratowymi, gdy są potrzebne.

![Macierz matematyczna z dwoma wierszami i jedną pustą komórką](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj tablice równań**

Użyj [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x powyżej y](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wyrównaj tablicę z otaczającymi elementami**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) kontroluje pionowe wyrównanie tablicy względem elementów matematycznych obok niej. Poniższy przykład porównuje wyrównanie pierwszego wiersza, środka tablicy i ostatniego wiersza.

Poniższy przykład tworzy trzy identyczne tablice, każda z trzema wierszami i sąsiadującymi elementami `A=` i `=B`. Wszystki tekst matematyczny używa czcionki Cambria Math w rozmiarze 24 punkty. Zmienia się jedynie wyrównanie tablicy.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);
    
    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie pokazuje zapisane prezentacje w PowerPoint. Zauważ pozycję `A=` i `=B` obok każdej tablicy.

![Tablice równań w PowerPoint z wyrównaniem góra, środek i dół oraz identycznymi elementami sąsiednimi](equation-array-alignment.png)

### **Skonfiguruj odstępy wierszy**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) wybiera regułę odstępu dla wierszy w tablicy. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) podaje wartość numeryczną dla explicite określonej reguły odstępu i jest ignorowane przy użyciu reguł wstępnych.

Dla dokładnego odstępu wartość jest podawana w punktach. Dla odstępu proporcjonalnego jest podawana w półlinijkach: wartość `3` w przykładzie oznacza 1,5 linii. Ustaw oba właściwości, gdy podajesz wartość explicite; zmiana samej wartości numerycznej nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z tymi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają presetów; ostatnie dwa pokazują wartości explicite.

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Odstępy wierszy tablicy są oddzielne od odstępów akapitu. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) i [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) dodają przestrzeń wokół zawierającego akapitu, nie między wierszami tablicy. Podobnie, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) pozycjonuje cały akapit matematyczny poziomo; nie zastępuje ustawienia pionowego wyrównania tablicy.

## **Dodaj funkcje trygonometryczne**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) gdy argument jest bieżącym elementem i nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj indeksy dolne i górne**

Użyj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy mają pojawić się po lewej stronie podstawy, użyj [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Wielka litera Y z lewostronnym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj delimitery**

Użyj [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) aby umieścić wyrażenie wewnątrz delimiterów. Możesz także ustawić znak separatora dla wyrażeń delimiterów zawierających kilka elementów.

![Wyrażenie delimitera zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rozmiar i wyrównanie delimiterów**

Przekaż `true` do [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) aby nawiasy rozrosły się wokół wysokiego operandu, lub `false` aby zachować ich normalny rozmiar. Użyj [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) z jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/). `Centered` centrowa nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `Match` wyrównuje je do zawartości. Oba ustawienia wpływają tylko na delimitery. Wyrażenie wewnątrz pozostaje niezmienione.

Przykład umieszcza ułamek w wykładniku `x`, więc wyrażenie rozciąga się wyżej nad linią bazową niż poniżej. Wszystkie cztery równania używają tych samych nawiasów i ustawień czcionki.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W PowerPoint porównaj wiersze, aby zobaczyć efekt rozrostu. W górnym wierszu nawiasy rosną, aby objąć wykładnik i wyglądają tak samo dla obu kształtów. W dolnym wierszu rozrost jest wyłączony. Mniejsze nawiasy po lewej (`Centered`) są wyrównane do znaku równości, natomiast po prawej (`Match`) znajdują się wyżej wokół wyrażenia.

![Cztery równania w PowerPoint z włączonym rozrostem delimiterów powyżej i wyłączonym poniżej, oraz Centered po lewej i Match po prawej](delimiter-sizing.png)

## **Dodaj ramkę obramowania**

Wywołaj [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) na ułamku, aby obramować całe wyrażenie. Zwrócony [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) domyślnie pokazuje wszystkie cztery strony. Użyj [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), i [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) aby usunąć poszczególne strony.

Przykład umieszcza sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać anulowanie, ukryj wszystkie cztery strony i przekaż `true` do [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) dla rosnącej przekątnej (↗) lub [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) dla opadającej przekątnej (↘). Możesz także użyć [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) lub [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) z dowolną kombinacją widocznych stron.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sześć edytowalnych ułamków w PowerPoint. Górny wiersz: pełne obramowanie, dolna i lewa strona, rosnąca przekątna. Dolny wiersz: opadająca przekątna, poziome przekreślenie, pionowe przekreślenie z pełnym obramowaniem](border-box-fractions.png)

Na tym ułamku poziome przekreślenie zachodzi na pasek ułamka. Pionowe przekreślenie przecina zarówno licznik, jak i mianownik, podczas gdy otaczające obramowanie pozostaje widoczne. Linie te dekorują całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w urzędzie tekstowym. Po ponownym otwarciu prezentacji w PowerPoint nadal możesz edytować licznik i mianownik niezależnie.

## **Grupowanie terminów**

Użyj [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj limit, aby oznaczyć grupowane terminy.

![Wyrażenie x plus y grupowane z etykietą dowolny tekst poniżej](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatowanie elementów matematycznych**

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z nadkreślonym paskiem](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Formatuj tekst w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź przez drzewo elementów każdego bloku matematycznego. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) zwraca tylko bezpośrednie dzieci, więc wywołaj go rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, indeksów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź bieżący element oraz jego dzieci, aby uwzględnić element początkowy, gdy jest to [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/).

Ten przykład zakłada, że `input.pptx` zawiera równanie takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku oraz pierwiastek w mianowniku. Przetwarzanie tylko elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje matematyczne fragmenty w ramkach tekstowych slajdów, uzyskuje dostęp do ich bloków poprzez [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), i używa [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) aby ustawić rozmiar czcionki na 28 punktów poprzez metodę [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) każdego elementu tekstowego.

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana prezentacja zawiera zaktualizowane formatowanie tekstu na każdym poziomie każdego przetworzonego równania, zachowując jego treść i strukturę matematyczną.

## **Szybka ściąga**

| Zadanie | Główne API |
| --- | --- |
| Tworzenie tekstu matematycznego | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| Łączenie elementów | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Tworzenie ułamków | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Dodawanie indeksu górnego lub dolnego | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Dodawanie funkcji | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Dodawanie pierwiastków | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Dodawanie granic | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Dodawanie indeksów po lewej stronie | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Dodawanie sum i całek | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Dodawanie macierzy | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| Dodawanie tablic równań | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| Dodawanie delimiterów | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Dodawanie pasków i ramek | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Grupowanie terminów | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**Czy mogę edytować istniejące równanie w PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Podczas zapisu do PPTX Aspose.Slides zapisuje równanie jako edytowalną treść matematyczną Office.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) równania z jego [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/), i wywołaj [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) aby bezpośrednio wyeksportować. Pełny przykład znajdziesz w [Export Math Equations from Presentations in Java](/slides/pl/java/exporting-math-equations/#export-math-equations-to-latex).