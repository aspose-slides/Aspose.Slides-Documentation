---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in Java hinzufügen
linktitle: PowerPoint Mathematische Gleichungen
type: docs
weight: 80
url: /de/java/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- mathematischer Text
- Mathematische Gleichung hinzufügen
- Mathematisches Symbol hinzufügen
- Mathematische Formel hinzufügen
- Mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Java einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare Java‑Beispielcodes."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Java können Sie dieselben mathematischen Inhalte programmatisch erstellen: Brüche, Wurzeln, Funktionen, Grenzwerte, N‑stellige Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint‑Registerkarte Einfügen mit ausgewählter Gleichungs‑Schaltfläche](powerpoint-math-equations_1.png)

Das Ergebnis ist bearbeitbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie, die eine bearbeitbare mathematische Gleichung enthält](powerpoint-math-equations_2.png)

Aspose.Slides erzeugt diesen mathematischen Text über drei Hauptobjekte:

- Eine mathematische Form, erstellt mit [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), ist die Form, die die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) speichert mathematischen Inhalt im Textfeld der Form.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Export Math Equations from Presentations in Java](/slides/de/java/exporting-math-equations/).

## **Eine Gleichung erstellen**

Dieses Beispiel verwendet [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) zum Erstellen einer mathematischen Form und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) erstellt eine Form, die bereits einen Mathematik‑Absatz enthält. Greifen Sie auf den ersten [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) zu, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph-- ) auf und fügen Sie dem Absatz mathematische Blöcke oder Elemente hinzu.
{{% /alert %}}

### **Mathematik‑Blöcke kombinieren**

Wenn Teile einer Gleichung unabhängig als [IMathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/)‑Objekte gebaut werden, verwenden Sie [joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-), um sie zu kombinieren. Das Beispiel erstellt `c² =` im linken Block und `a² + b²` im rechten Block. [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-java.lang.String-) erzeugt bearbeitbare mathematische Hochstellungen für alle drei Potenzen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathParagraph mathParagraph = mathPortion.getMathParagraph();

    MathBlock leftBlock = new MathBlock();
    leftBlock.add(new MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new MathematicalText("="));

    MathBlock rightBlock = new MathBlock();
    rightBlock.add(new MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new MathematicalText("+"));
    rightBlock.add(new MathematicalText("b").setSuperscript("2"));

    IMathBlock combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) gibt `leftBlock` selbst zurück, das nun beide Teile in Reihenfolge enthält, und lässt `rightBlock` leer. Fügen Sie den kombinierten Block nur einmal zum [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) hinzu. Nach dem erneuten Öffnen von `equation.pptx` enthält der Absatz einen Block, der `c² = a² + b²` darstellt, wobei alle drei Potenzen als mathematische Hochstellungen erhalten bleiben.

Ein Aufruf von [add](https://reference.aspose.com/slides/java/com.aspose.slides/imathelementcollection/#add-com.aspose.slides.IMathElement-) als `leftBlock.add(rightBlock)` versucht stattdessen, einen Block direkt in einen anderen zu verschachteln, und wirft `InvalidOperationException`.

## **Brüche hinzufügen**

Verwenden Sie [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) auswählen.

![Ein schräger mathematischer Bruch, der eins durch x teilt](powerpoint-math-equations_4.png)

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

Für einen gestapelten Bruch verwenden Sie [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Wurzeln hinzufügen**

Verwenden Sie [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erzeugen. Das aktuelle Element wird zur Basis, das Argument zum Grad.

![Ein n‑te‑Wurzel‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

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

### **Den Grad einer Quadratwurzel anzeigen oder verbergen**

Eine Quadratwurzel kann die explizite 2 anzeigen oder die konventionelle √x‑Notation verwenden. Die Methode [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) von [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) steuert, welche Form erscheint. Beide Formen behalten den Grad 2 und das Radikand x in der bearbeitbaren Gleichung.

![Die gleiche Quadratwurzel, links mit sichtbarem Grad, rechts mit verstecktem Grad](square-root-degree.png)

Das Beispiel speichert dieselbe Quadratwurzel zweimal. In `visible-degree.pptx` ist die 2 sichtbar. In `hidden-degree.pptx` ist sie versteckt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IMathRadical radical = new MathematicalText("x").radical("2");

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Funktionen und Grenzwerte hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) oder [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzwerte setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) oder verwenden Sie [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![Der Grenzwert von x, wenn x gegen unendlich strebt](powerpoint-math-equations_8.png)

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

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element und rufen [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) mit seinem Argument auf:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N‑stellige Operatoren und Integrale hinzufügen**

Verwenden Sie [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) für Summen, Vereinigungen, Schnitte und andere große Operatoren. Verwenden Sie [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) für Integrale. Beide Methoden erlauben das Festlegen von Unter‑ und Obergrenzen.

![Eine Summation mit Unter‑ und Obergrenzen](powerpoint-math-equations_7.png)

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

N‑stellige Operatoren dienen großen Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden meist als [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) hinzugefügt und in den Ausdruck eingefügt.

Für ein Integral verwenden Sie [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, deshalb sollten Sie die Matrix bei Bedarf in Klammern, eckige Klammern oder geschweifte Klammern einbetten.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

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

### **Eine vorhandene Matrix bearbeiten**

Angenommen, eine lineare‑Algebra‑Stunde beginnt mit der Koeffizientenmatrix in `matrix.pptx`, die im vorangegangenen Beispiel gespeichert wurde. Für die nächste Übung behalten Sie die erste Gleichung, ersetzen die zweite durch zwei neue Gleichungen und überarbeiten die Menge der Variablen. Öffnen Sie die vorhandene Matrix über [IMathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/), um die noch gültigen Koeffizienten zu erhalten.

![Ursprüngliche zweizeilige Koeffizientenmatrix mit den Einträgen 1, x und einer leeren Zelle in der ersten Zeile sowie x, 2 und y in der zweiten Zeile](matrix-before-edit.png)

Zeilen‑ und Spalten‑Indizes beginnen bei 0 und beziehen sich auf den aktuellen Zustand der Matrix. Das Einfügen einer Zeile vor Index 1 verschiebt die ursprüngliche zweite Zeile zu Index 2. Das Einfügen nach Index 2 fügt dann eine Zeile am Ende an. Das Löschen von Zeile 2 entfernt die ursprüngliche zweite Gleichung und verschiebt die angefügte Zeile nach oben. Spalten verschieben sich analog.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("matrix.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathMatrix matrix = (IMathMatrix) portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Neue Zellen sind zunächst null. Setzen Sie zuerst die von Null verschiedenen Koeffizienten.
    matrix.set_Item(1, 0, new MathematicalText("12"));
    matrix.set_Item(1, 1, new MathematicalText("1"));
    matrix.set_Item(2, 2, new MathematicalText("10"));
    matrix.set_Item(2, 3, new MathematicalText("1"));
    for (int row = 0; row < matrix.getRowCount(); row++) {
        for (int column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) richtet die erste Spalte linksbündig aus. [setColumnsAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) richtet drei aufeinander folgende Spalten rechtsbündig aus, beginnend bei Index 1. In `updated-matrix.pptx` hat die Matrix drei Gleichungen und vier Variablen. Die ursprünglichen Koeffizienten der ersten Zeile `1` und `x` erscheinen jetzt in der ersten bzw. dritten Spalte.

![Aktualisierte dreizeilige Matrix mit den Zeilen 1, 0, x, 0; 12, 1, 0, 0; und 0, 0, 10, 1](matrix-after-edit.png)

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

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

### **Ein Array mit umliegenden Elementen ausrichten**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) steuert die vertikale Ausrichtung eines Arrays relativ zu den mathematischen Elementen daneben. Das nachfolgende Beispiel vergleicht die Ausrichtung mit der ersten Zeile, der Mitte des Arrays und der letzten Zeile.

Das folgende Beispiel erzeugt drei identische Arrays, jeweils mit drei Zeilen und den Nachbarelementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24 pt. Nur die Array‑Ausrichtung ändert sich.

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

Der folgende Vergleich zeigt die gespeicherte Präsentation in PowerPoint. Beachten Sie die Position von `A=` und `=B` neben jedem Array.

![Gleichungs‑Arrays in PowerPoint mit oben‑, mittel‑ und unten‑Ausrichtung und identischen Nachbarelementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) wählt die Abstand‑Regel für Zeilen innerhalb des Arrays. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) liefert einen numerischen Wert für eine explizite Abstand‑Regel und wird von den Voreinstellungen ignoriert.

Für exakten Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird er in Halblinien gemessen: Der Wert `3` im Beispiel steht für 1,5 Linien. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das Ändern des numerischen Werts allein wählt keine Abstand‑Regel aus.

Das nachfolgende Beispiel speichert fünf Präsentationen mit denselben Gleichungen, derselben Ausrichtung und denselben Schrifteinstellungen. Die ersten drei verwenden Voreinstellungen; die letzten beiden zeigen explizite Werte.

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

Der Zeilenabstand eines Arrays ist unabhängig vom Absatz‑Abstand. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) und [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) fügen Abstand rund um den enthaltenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtung des Arrays.

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

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

## **Tief- und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief‑ und Hochstellungen bei Indizes und Potenzen. Wenn die Indizes links vom Basiselement erscheinen sollen, verwenden Sie [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Ein großes Y mit linken Tiefstellung 1 und Hochstellung n](powerpoint-math-equations_9.png)

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

## **Klammern hinzufügen**

Verwenden Sie [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-), um einen Ausdruck in Klammern zu setzen. Sie können auch ein Trennzeichen‑Zeichen festlegen für Klammer‑Ausdrücke, die mehrere Elemente enthalten.

![Ein Klammer‑Ausdruck, der x, y und z durch senkrechte Striche trennt](powerpoint-math-equations_13.png)

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

### **Größe und Ausrichtung von Klammern**

Geben Sie `true` an [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) weiter, damit die Klammern um einen hohen Operand herum wachsen, oder `false`, um ihre normale Größe beizubehalten. Verwenden Sie [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) mit einem der beiden Werte von [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/). `Centered` zentriert die Klammern auf der mathematischen Achse, die durch das Gleichheitszeichen verläuft. `Match` richtet sie an dem eingeschlossenen Inhalt aus. Beide Einstellungen betreffen nur die Klammern; der Ausdruck bleibt unverändert.

Das Beispiel setzt einen Bruch als Exponenten von `x`, sodass der Ausdruck über der Grundlinie weiter reicht als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schrifteinstellungen.

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

In PowerPoint vergleichen Sie die Zeilen, um den Effekt des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen bei beiden Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`Centered`) richten sich nach dem Gleichheitszeichen, während die rechten (`Match`) höher um den Ausdruck herumliegen.

![Vier Gleichungen in PowerPoint mit aktivierter Klammer‑Vergrößerung oben und deaktivierter unten, sowie `Centered` links und `Match` rechts](delimiter-sizing.png)

## **Eine Rand‑Box hinzufügen**

Rufen Sie [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) bei einem Bruch auf, um den gesamten Ausdruck zu umrahmen. Das zurückgegebene [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-) und [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um eine Durchstreichung zu zeigen, verbergen Sie alle vier Seiten und setzen Sie `true` bei [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) für eine steigende Diagonale (↗) oder bei [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) für eine fallende Diagonale (↘). Sie können auch [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) oder [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) mit beliebiger Kombination sichtbarer Seiten verwenden.

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

![Sechs bearbeitbare Brüche in PowerPoint. Obere Zeile: voller Rand, untere und linke Seiten, steigende Diagonale. Untere Zeile: fallende Diagonale, horizontaler Strich, vertikaler Strich mit vollem Rand](border-box-fractions.png)

Bei diesem Bruch überschneidet der horizontale Strich den Bruchstrich. Der vertikale Strich durchschneidet sowohl Zähler als auch Nenner, während der umgebende Rand sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Ein normaler Text‑Durchstrich gilt für Zeichen in einem Textlauf. Nach dem erneuten Öffnen der Präsentation in PowerPoint können Sie Zähler und Nenner weiterhin unabhängig bearbeiten.

## **Sichtbarkeit und Layout mit Phantom‑Elementen steuern**

Betten Sie einen Ausdruck in [MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) ein, um seine Sichtbarkeit und den von ihm beanspruchten Platz in einer Gleichung unabhängig zu steuern. Die Methoden von [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) regeln Folgendes:

| Methode | Wirkung |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` verbergen den Ausdruck. Seine Abmessungen tragen weiterhin zum Layout bei, sofern die nachfolgenden Methoden nicht `true` erhalten. |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | Die horizontale Breite des Ausdrucks wird als Null behandelt, sodass Nachbarelemente näher zusammenrücken können. |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | Der Aufstieg (Höhe über der Grundlinie) wird als Null behandelt, wodurch der darüber liegende Abstand reduziert wird. |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | Der Abstieg (Tiefe unter der Grundlinie) wird als Null behandelt, wodurch ein Bruchstrich oder anderer Inhalt unter dem Ausdruck näher an benachbarte Elemente rückt. |

Die Grundlinie ist die Referenzlinie, auf der gewöhnliche mathematische Buchstaben sitzen. Das Verbergen von Inhalten entfernt nicht deren Abmessungen, und das Ersetzen einer Abmessung durch Null löscht den Ausdruck nicht. Der zugrundliegende Ausdruck bleibt über [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--) zugänglich. Setzen Sie `true` bei [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-), um ihn wieder anzuzeigen; die Dimensionseinstellungen bleiben unverändert.

Das nachfolgende Beispiel erstellt fünf nebeneinander stehende Varianten: einen sichtbaren Bruch, einen verborgenen Bruch, der Platz reserviert, und drei verborgene Brüche, bei denen jeweils eine Dimension als Null behandelt wird. Jede Variante verwendet denselben umgebenden Ausdruck und Cambria Math in 24 pt. Alle Gleichungs‑Formen haben dieselbe obere Position, markiert durch die graue Hilfslinie. Das Platzieren des Phantoms im Zähler eines äußeren Bruchs erleichtert das Erkennen vertikaler Layout‑Änderungen.

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
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY);

    for (int i = 0; i < labels.length; i++) {
        int left = 10 + i * 200;

        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(labels[i]);

        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        MathematicalText fractionNumerator = factory.createText("a+b");
        MathematicalText fractionDenominator = factory.createText("c+d");
        MathFraction fraction = new MathFraction(fractionNumerator, fractionDenominator);
        MathPhantom phantom = new MathPhantom(fraction);
        phantom.setShow(i == 0);
        phantom.setZeroWidth(i == 2);
        phantom.setZeroAsc(i == 3);
        phantom.setZeroDesc(i == 4);

        MathematicalText leftText = factory.createText("x+");
        MathematicalText rightText = factory.createText("+y");
        IMathBlock numerator = new MathBlock(leftText).join(phantom).join(rightText);
        MathematicalText denominator = factory.createText("z");
        MathFraction equation = new MathFraction(numerator, denominator);

        IAutoShape shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);

        IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IMathParagraph mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Fünf Gleichungen in PowerPoint, die einen sichtbaren Bruch, einen verborgenen Bruch, der Raum reserviert, und verborgene Brüche mit aktivierten ZeroWidth, ZeroAsc bzw. ZeroDesc vergleichen](math-phantom.png)

## **Terme gruppieren**

Verwenden Sie [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y, gruppiert mit der Beschriftung beliebiger Text darunter](powerpoint-math-equations_15.png)

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

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungshilfen nur dort, wo sie die Formel klarer machen. Zum Beispiel legt [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) einen Balken über ein mathematisches Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

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

### **Text in einer bestehenden Gleichung formatieren**

Um Text in einer bestehenden Gleichung zu formatieren, durchlaufen Sie den Element‑Baum jedes Mathematik‑Blocks. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) gibt nur die unmittelbaren Kinder zurück, daher muss es rekursiv aufgerufen werden, um Text in Brüchen, Exponenten, Wurzeln und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie seine Kinder, um das Ausgangselement einzubeziehen, wenn es sich um [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) handelt.

Dieses Beispiel geht davon aus, dass `input.pptx` eine Gleichung wie `z = xᵢ / ∛y` enthält, wobei der Bruch im Zähler einen Tiefstellen‑Index und im Nenner eine Wurzel hat. Das bloße Durchsuchen der obersten Block‑Elemente würde den Text im Bruch übersehen. Das Beispiel findet mathematische Portionen in Folientext‑Frames, greift über [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) auf deren Blöcke zu und verwendet [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-), um die Schriftgröße über jedes Textelement‑[getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) auf 28 pt zu setzen.

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

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, wobei Inhalt und mathematische Struktur erhalten bleiben.

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathematischen Text erstellen | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Brüche erstellen | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Hoch‑ oder Tiefstellung hinzufügen | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Wurzeln hinzufügen | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Grenzwerte hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| Klammern hinzufügen | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Balken und Ränder hinzufügen | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie die Form, die einen [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) enthält, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) auf und aktualisieren Sie die mathematischen Blöcke in diesem Absatz.

**Werden Gleichungen als bearbeitbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als bearbeitbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie sich das [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) einer [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/), und rufen Sie [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) auf, um sie direkt zu exportieren. Für ein vollständiges Beispiel siehe [Export Math Equations from Presentations in Java](/slides/de/java/exporting-math-equations/#export-math-equations-to-latex).