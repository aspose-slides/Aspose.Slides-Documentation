---
title: Agregar ecuaciones matemáticas a presentaciones de PowerPoint en Java
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/java/powerpoint-math-equations/
keywords:
- ecuación matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- agregar ecuación matemática
- agregar símbolo matemático
- agregar fórmula matemática
- agregar texto matemático
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para Java, compatible con OMML, controles de formato y ejemplos de código Java claros."
---
## **Visión general**

PowerPoint almacena ecuaciones como Office Math Markup Language (OMML). Con Aspose.Slides for Java, puedes crear el mismo tipo de contenido matemático de forma programada: fracciones, radicales, funciones, límites, operadores N-arios, matrices, arreglos y bloques de matemáticas con formato.

En PowerPoint, los usuarios normalmente añaden ecuaciones desde **Insert > Equation**:

![Pestaña Insertar de PowerPoint con el comando Ecuación seleccionado](powerpoint-math-equations_1.png)

El resultado es texto matemático editable en la diapositiva:

![Una diapositiva de PowerPoint que contiene una ecuación matemática editable](powerpoint-math-equations_2.png)

Aspose.Slides construye ese texto matemático mediante tres objetos principales:

- Una forma matemática, creada con [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), es la forma que contiene la ecuación.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) almacena el contenido matemático dentro del marco de texto de la forma.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) contiene uno o más objetos [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/).

La mayoría de los ejemplos a continuación usan [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) y los métodos fluidos de [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) para mantener el código breve y legible.

Para escenarios de exportación MathML, consulta [Exportar ecuaciones matemáticas desde presentaciones en Java](/slides/es/java/exporting-math-equations/).

## **Crear una ecuación**

Este ejemplo usa [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) para crear una forma matemática y agrega el teorema de Pitágoras:

![La ecuación c al cuadrado es igual a a al cuadrado más b al cuadrado](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) crea una forma que ya contiene un párrafo matemático. Accede al primer [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), llama a [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), y agrega bloques matemáticos o elementos matemáticos a él.
{{% /alert %}}

## **Agregar fracciones**

Utiliza [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) para crear una fracción. Puedes elegir un estilo de fracción con [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/).

![Una fracción matemática inclinada que muestra uno dividido por x](powerpoint-math-equations_4.png)

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

Para una fracción apilada, usa [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Agregar radicales**

Utiliza [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) para crear una raíz cuadrada, raíz cúbica u otra raíz. El elemento actual se convierte en la base y el argumento en el grado.

![Una expresión radical de n-ésima raíz con x bajo el signo radical](powerpoint-math-equations_5.png)

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

## **Agregar funciones y límites**

Utiliza [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) o [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) para funciones como `sin(x)`, `log(x)` o nombres de funciones personalizados. Para límites, coloca `lim` en un [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) o usa [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![El límite de x cuando x tiende a infinito](powerpoint-math-equations_8.png)

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

Para un nombre de función personalizado, haz que el nombre de la función sea el elemento actual y llama a [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) con su argumento:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Agregar operadores N-arios e integrales**

Utiliza [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) para sumas, uniones, intersecciones y otros operadores grandes. Utiliza [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) para integrales. Ambos métodos permiten establecer límites inferior y superior.

![Una sumatoria con límites inferior y superior](powerpoint-math-equations_7.png)

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

Los operadores N-arios son para operadores grandes con límites opcionales. Los operadores simples como `+`, `-` y `=` suelen añadirse como [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) y unirse a la expresión.

Para una integral, usa [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Agregar matrices**

Utiliza [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) para filas y columnas. Las matrices no incluyen corchetes por defecto, así que encierra la matriz cuando necesites paréntesis, corchetes o llaves.

![Una matriz matemática de dos filas con una celda vacía](powerpoint-math-equations_10.png)

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

## **Agregar arreglos de ecuaciones**

Utiliza [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) cuando necesites ecuaciones alineadas o una pila vertical de expresiones.

![Un arreglo matemático vertical con x sobre y](powerpoint-math-equations_11.png)

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

### **Alinear un arreglo con los elementos circundantes**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) controla la alineación vertical de un arreglo respecto a los elementos matemáticos a su lado. El ejemplo siguiente compara la alineación con la primera fila, el centro del arreglo y la última fila.

El siguiente ejemplo crea tres arreglos idénticos, cada uno con tres filas y los elementos vecinos `A=` y `=B`. Todo el texto matemático usa Cambria Math a 24 puntos. Sólo cambia la alineación del arreglo.

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

La siguiente comparación muestra la presentación guardada en PowerPoint. Observa la posición de `A=` y `=B` junto a cada arreglo.

![Arreglos de ecuaciones en PowerPoint con alineación Superior, Centro e Inferior y elementos vecinos idénticos](equation-array-alignment.png)

### **Configurar el espaciado de filas**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) selecciona la regla de espaciado para las filas dentro del arreglo. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) proporciona un valor numérico para una regla de espaciado explícita y es ignorado por las reglas preestablecidas.

Para espaciado exacto, el valor se mide en puntos. Para espaciado proporcional, se mide en medias líneas: el valor `3` en el ejemplo especifica 1,5 líneas. Establece ambas propiedades al especificar un valor explícito; cambiar solo el valor numérico no selecciona una regla de espaciado.

El ejemplo siguiente guarda cinco presentaciones con las mismas ecuaciones, alineación y configuración de fuente. Las tres primeras usan preajustes; las dos últimas muestran valores explícitos.

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

El espaciado de filas del arreglo es independiente del espaciado de párrafo. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) y [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) añaden espacio alrededor del párrafo contenedor, no entre filas del arreglo. Del mismo modo, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) posiciona horizontalmente todo el párrafo matemático; no reemplaza la configuración de alineación vertical del arreglo.

## **Agregar funciones trigonométricas**

Utiliza [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) cuando el argumento es el elemento actual y el nombre de la función es conocido.

![La función trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

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

## **Agregar subíndices y superíndices**

Utiliza los asistentes de subíndices y superíndices para índices y potencias. Cuando los índices deben aparecer en el lado izquierdo de la base, usa [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Una Y mayúscula con subíndice izquierdo 1 y superíndice n](powerpoint-math-equations_9.png)

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

## **Agregar delimitadores**

Utiliza [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) para colocar una expresión dentro de delimitadores. También puedes establecer un carácter separador para expresiones delimitadoras que contengan varios elementos.

![Una expresión delimitadora que contiene x, y y z separados por barras verticales](powerpoint-math-equations_13.png)

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

### **Tamaño y alineación de delimitadores**

Pasa `true` a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) para que los paréntesis crezcan alrededor de un operando alto, o pasa `false` para mantener su tamaño normal. Usa [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) con uno de los dos valores de [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/). `Centered` centra los paréntesis en el eje matemático, que atraviesa el medio del signo igual. `Match` los alinea con el contenido encerrado. Ambas configuraciones afectan solo a los delimitadores. La expresión interior permanece igual.

El ejemplo coloca una fracción en el exponente de `x` de modo que la expresión se extienda más arriba de la línea base que abajo. Las cuatro ecuaciones usan los mismos paréntesis y configuraciones de fuente.

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

En PowerPoint, compara las filas para ver el efecto del crecimiento. En la fila superior, los paréntesis crecen para encerrar el exponente y se ven iguales para ambas formas. En la fila inferior, el crecimiento está desactivado. Los paréntesis más pequeños a la izquierda (`Centered`) se alinean con el signo igual, mientras que los de la derecha (`Match`) se sitúan más arriba alrededor de la expresión.

![Cuatro ecuaciones en PowerPoint con el crecimiento de delimitadores activado arriba y desactivado abajo, y Centered a la izquierda y Match a la derecha](delimiter-sizing.png)

## **Agregar un recuadro**

Llama a [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) sobre una fracción para encuadrar toda la expresión. El [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) devuelto muestra los cuatro lados por defecto. Utiliza [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), y [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) para eliminar lados individuales.

El ejemplo coloca seis copias de la misma fracción en una diapositiva. Para mostrar cancelación, oculta los cuatro lados y pasa `true` a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) para una diagonal ascendente (↗) o [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) para una diagonal descendente (↘). También puedes usar [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) o [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) con cualquier combinación de lados visibles.

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

![Seis fracciones editables en PowerPoint. Fila superior: borde completo, lados inferior e izquierdo, diagonal ascendente. Fila inferior: diagonal descendente, línea horizontal, línea vertical con borde completo](border-box-fractions.png)

En esta fracción, la línea horizontal se superpone a la barra de la fracción. La línea vertical cruza tanto el numerador como el denominador mientras el borde circundante permanece visible. Estas líneas decoran toda la expresión. El tachado de texto ordinario se aplica a los caracteres en una ejecución de texto. Después de volver a abrir la presentación en PowerPoint, aún puedes editar el numerador y el denominador de forma independiente.

## **Agrupar términos**

Utiliza [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) para colocar un carácter de agrupación encima o debajo de una expresión. Añade un límite para etiquetar los términos agrupados.

![La expresión x más y agrupada con la etiqueta cualquier texto debajo](powerpoint-math-equations_15.png)

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

## **Formatear elementos matemáticos**

Utiliza los asistentes de formato solo donde aclaren la fórmula. Por ejemplo, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) coloca una barra sobre un elemento matemático.

![Una expresión matemática ABC con una barra superior](powerpoint-math-equations_14.png)

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

### **Formatear texto en una ecuación existente**

Para formatear texto en toda una ecuación existente, recorre el árbol de elementos de cada bloque matemático. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) devuelve solo los hijos inmediatos, por lo que debes llamarlo recursivamente para alcanzar el texto dentro de fracciones, superíndices/subíndices, radicales y otras estructuras anidadas. Verifica el elemento actual así como sus hijos para incluir el elemento inicial cuando sea [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/).

Este ejemplo asume que `input.pptx` contiene una ecuación como `z = xᵢ / ∛y`, con una fracción que contiene un subíndice en su numerador y un radical en su denominador. Procesar solo los elementos de nivel superior del bloque perdería el texto dentro de la fracción. El ejemplo encuentra porciones matemáticas en marcos de texto de diapositivas, accede a sus bloques mediante [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), y usa [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para establecer el tamaño de fuente a 28 puntos a través del método [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) de cada elemento de texto.

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

La presentación guardada contiene el formato de texto actualizado en cada nivel de cada ecuación procesada, mientras conserva su contenido textual y su estructura matemática.

## **Referencia rápida**

| Tarea | API principal |
| --- | --- |
| Crear texto matemático | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| Combinar elementos | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Crear fracciones | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Agregar superíndice o subíndice | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Agregar funciones | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Agregar radicales | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Agregar límites | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Agregar scripts del lado izquierdo | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Agregar sumas e integrales | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Agregar matrices | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| Agregar arreglos de ecuaciones | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| Agregar delimitadores | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Agregar barras y bordes | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Agrupar términos | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **Preguntas frecuentes**

**¿Puedo editar una ecuación existente de PowerPoint?**

Sí. Abre la presentación, busca la forma que contiene un [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), llama a [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), y actualiza los bloques matemáticos en ese párrafo.

**¿Se guardan las ecuaciones como matemáticas editables de PowerPoint?**

Sí. Al guardar en PPTX, Aspose.Slides escribe la ecuación como contenido matemático de Office editable.

**¿Puedo exportar ecuaciones a LaTeX?**

Sí. Obtén el [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) de la ecuación a partir de su [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/), y llama a [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) para exportarlo directamente. Para un ejemplo completo, consulta [Exportar ecuaciones matemáticas desde presentaciones en Java](/slides/es/java/exporting-math-equations/#export-math-equations-to-latex).