---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz Androidon
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/androidjava/powerpoint-math-equations/
keywords:
- matematika egyenlet
- matematika szimbólum
- matematika képlet
- matematika szöveg
- matematika egyenlet hozzáadása
- matematika szimbólum hozzáadása
- matematika képlet hozzáadása
- matematika szöveg hozzáadása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Android segítségével, OMML támogatással, formázási vezérléssel és tiszta Java kódpéldákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket Office Math Markup Language (OMML) formátumban tárol. Az Aspose.Slides for Android via Java segítségével programozottan hozhat létre ugyanilyen matematikai tartalmakat: törtek, gyökök, függvények, határértékek, N-árnyú operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában a **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Insert fül, ahol a Equation parancs ki van választva](powerpoint-math-equations_1.png)

A végeredmény szerkeszthető matematikai szöveg a dián:

![PowerPoint diavetítés, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) hoz létre, az az alakzat, amely tartalmazza az egyenletet.
- A [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretén belül.
- A [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) tartalmaz egy vagy több [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) objektumot.

Az alábbi példák többsége a [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) folyékony metódusait használja, hogy a kód rövid és olvasható legyen.

MathML export esetén lásd a [Matematikai egyenletek exportálása bemutatókból Androidon](/slides/hu/androidjava/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz-tételt:

![Az egyenlet: c négyzet egyenlő a négyzet plusz b négyzet](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) létrehoz egy alakzatot, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), meghívja a [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), és hozzáadja a matematikai blokkokat vagy elemeket.
{{% /alert %}}

### **Matematikai blokkok kombinálása**

Ha egy egyenlet részei önállóan [IMathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathblock/) objektumokként épülnek, használja a [joinBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) metódust a kombinálásukhoz. A példa a `c² =` bal blokkban és az `a² + b²` jobb blokkban építi fel. A [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSuperscript-java.lang.String-) szerkeszthető matematikai felső indexeket hoz létre mindhárom hatványhoz.

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

[joinBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) visszaadja a `leftBlock`-ot magát, amely most már sorrendben tartalmazza mindkét részt, és a `rightBlock`-ot üresen hagyja. Adja hozzá a kombinált blokkot csak egyszer a [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/)‑hez. A `equation.pptx` újranyitása után a bekezdés egy blokkot tartalmaz, amely a `c² = a² + b²` kifejezést képviseli, és mindhárom hatvány matematikai felső indexként megmarad.

A [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelementcollection/#add-com.aspose.slides.IMathElement-) meghívása `leftBlock.add(rightBlock)` helyett megpróbálja a blokkot közvetlenül egy másik blokkba ágyazni, és `InvalidOperationException` kivételt dob.

## **Törtek hozzáadása**

Használja a [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) metódust egy tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Egy ferdén elhelyezett matematikai tört, ahol egy osztva x-szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar)-t:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

Használja a [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) metódust négyzetgyök, köbgyök vagy más gyök létrehozásához. Az aktuális elem lesz az alap, az argumentum pedig a fokszám.

![Egy n-edik gyököt ábrázoló kifejezés, ahol az x a gyökjel alatt áll](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokszámának megjelenítése vagy elrejtése**

A négyzetgyök explicit 2‑t jeleníthet meg, vagy a hagyományos √x jelölést használhatja. A [setHideDegree](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/#setHideDegree-boolean-) metódus a [IMathRadical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/)‑ban határozza meg, hogy melyik forma jelenik meg. Mindkét forma megőrzi a 2‑es fokszámot és az x radikandust a szerkeszthető egyenletben.

![Ugyanaz a négyzetgyök, bal oldalon a fokszám látható, jobb oldalon rejtett](square-root-degree.png)

A példa két alkalommal menti ugyanazt a négyzetgyököt. A `visible-degree.pptx`‑ben a 2 látható. A `hidden-degree.pptx`‑ben rejtett.

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

## **Függvények és határértékek hozzáadása**

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) vagy a [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határértékekhez helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/)‑ba, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-)‑t.

![x határértéke, amikor x a végtelenhez tart](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy egyedi függvénynévhez tegye a függvénynevet az aktuális elemmé, majd hívja a [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-)‑t a argumentummal:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-árnyú operátorok és integrálok hozzáadása**

Használja a [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) metódust összegzések, uniók, metszetek és egyéb nagy operátorok kezelésére. Az integrálokhoz használja a [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)‑t. Mindkét módszer lehetővé teszi alsó és felső határ megadását.

![Összegzés alsó és felső korlátokkal](powerpoint-math-equations_7.png)

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

Az N-árnyú operátorok nagy operátorok, opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-` és `=`, általában [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/)‑ként kerülnek hozzáadásra, majd egyesítve a kifejezésben.

Integrál esetén használja a [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)‑t:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/)‑t sorok és oszlopok kezelésére. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért szükség esetén tekerje őket zárójelek, szögletes vagy kapcsos zárójelek közé.

![Két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

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

### **Meglévő mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra óra a `matrix.pptx`‑ben lévő koefficiensmátrixszal indul, amelyet az előző példa mentett. A következő feladatnál tartsa meg az első egyenletet, cserélje le a másodikat két új egyenletre, és módosítsa a változók halmazát. Nyissa meg a meglévő mátrixot az [IMathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/) segítségével, hogy megtartsa a még érvényes koefficienseket.

![Eredeti kétsoros koefficiensmátrix, amelynek első sorában 1, x, és egy üres cella, a második sorban x, 2 és y szerepel](matrix-before-edit.png)

A sor- és oszlopindexek nulláról indulnak, és az aktuális hívásnál létező mátrixra vonatkoznak. Sor beszúrása az 1. index előtt áthelyezi az eredeti második sort a 2. indexre. Beszúrás 2. index után egy új sor hozzáadását eredményezi. A 2. sor törlése eltávolítja az eredeti második egyenletet, és a hozzáadott sort egy hellyel feljebb viszi. Az oszlopok ugyanígy eltolódnak.

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

    // Az új cellák eleinte null értékűek. Először állítsa be a nem nulla együtthatókat.
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

[setColumnAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) balra igazítja az első oszlopot. A [setColumnsAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) három egymást követő oszlopot jobbra igazít a 1-es indextől kezdve. Az `updated-matrix.pptx`‑ben a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor koefficiensei `1` és `x` most az első és a harmadik oszlopban jelennek meg.

![Frissített három soros mátrix, amely a következő sorokat mutatja: 1, 0, x, 0; 12, 1, 0, 0; és 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) metódust, ha igazított egyenletekre vagy függőleges kifejezéshalmazra van szüksége.

![Függőleges matematikai tömb, ahol x van y felett](powerpoint-math-equations_11.png)

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

### **Tömb igazítása a környező elemekkel**

A [setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) vezérli a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa összehasonlítja az első sor, a tömb középpontja és az utolsó sor igazítását.

A következő példa három azonos tömböt hoz létre, mindegyik három sorral és a szomszédos elemekkel `A=` és `=B`. Minden matematikai szöveg Cambria Math betűtípussal, 24 pont mérettel jelenik meg. Csak a tömb igazítása változik.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

A következő összehasonlítás a PowerPointban mentett bemutatót mutatja. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök a PowerPointban felső, középső és alsó igazítással és azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sor távolság beállítása**

A [setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) választja ki a sorok közötti távolság szabályát a tömbön belül. A [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) numerikus értékkel explicit szabályt ad meg, és a preset szabályok figyelmen kívül hagyják.

Az exact spacing esetén az értéket pontban mérik. A proportional spacing esetén fél sorban: a `3` érték például 1,5 sort jelent. Mindkét tulajdonságot állítsa be explicit érték megadásakor; csak a numerikus érték módosítása nem választ szabályt.

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

A sorok távolsága különbözik a bekezdés távolságától. A [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és a [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) a körülvevő bekezdés körül ad távolságot, nem a tömb sorai között. Hasonlóképpen az [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) a teljes matematikai bekezdést igazítja vízszintesen; nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) metódust, ha az argumentum az aktuális elem, és a függvény neve ismert.

![A trigonometrikus cos függvény alkalmazva a 2x-re](powerpoint-math-equations_6.png)

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó- és felső index segédfüggvényeket indexek és hatványok létrehozásához. Ha az indexnek a bázis bal oldalán kell megjelenni, használja a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)‑t.

![Egy nagy Y balra elhelyezett alsóindexe 1 és felsőindexe n](powerpoint-math-equations_9.png)

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

## **Elválasztók hozzáadása**

Használja az [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) metódust egy kifejezés elválasztók közé helyezéséhez. A több elemet tartalmazó elválasztó kifejezésekhez beállíthat egy elválasztó karaktert is.

![Egy elválasztó kifejezés, amely x, y és z‑t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Az elválasztók mérete és igazítása**

Adja át a `true` értéket a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-)‑nek, hogy a zárójelek a magas operandus körül növekedjenek, vagy `false`‑t adjon meg, hogy normál méretben maradjanak. Használja a [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-)‑t a [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) két értékének egyikével. A `Centered` a zárójeleket a matematikai tengelyen középre helyezi, amely az egyenlőségjel közepén halad. A `Match` a zárójeleket a körülvett tartalomhoz igazítja. Mindkét beállítás csak az elválasztókat érinti; a kifejezés belseje változatlan marad.

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

A PowerPointban hasonlítsa össze a sorokat a növekedés hatásának láthatóságához. A felső sorban a zárójelek a kitevő körül növekednek, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldalon lévő kisebb zárójelek (`Centered`) a egyenlőségjelhez igazodnak, míg a jobb oldalon lévő (`Match`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet a PowerPointban, ahol a bal oldalon a zárójelek növekedése engedélyezett, jobb oldalon letiltott, és a bal oldalon a Centered, jobb oldalon a Match beállítás](delimiter-sizing.png)

## **Keretes doboz hozzáadása**

Hívja meg a [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) metódust egy törtön, hogy a teljes kifejezést keretezze. A visszakapott [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) alapértelmezés szerint mind a négy oldalt megjeleníti. A [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), és a [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) segítenek egyes oldalak eltávolításában.

Az alábbi példa ugyanazt a törtet helyezi hat példányban egy diára. A törlés megjelenítéséhez rejtsük el a négy oldalt, és a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-)‑t állítsuk `true`‑ra egy emelkedő átló (↗) létrehozásához, vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-)‑t egy leereszkedő átló (↘) esetén. A [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) kombinálható tetszőleges látható oldalakkal.

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

![Hat szerkeszthető tört a PowerPointban. Felső sor: teljes keret, alsó és bal oldal, emelkedő átló. Alsó sor: leereszkedő átló, vízszintes vonal, függőleges vonal teljes kerettel.](border-box-fractions.png)

Ezen törtön a vízszintes vonal átfedi a törtvonalat. A függőleges vonal mind a számlálót, mind a nevezőt átlövi, míg a körülvevő keret látható marad. Ezek a vonalak a teljes kifejezést díszítik. A szokásos szöveg áthúzása csak a szövegtöredék karakterein alkalmazható. A bemutató PowerPointban való újranyitása után továbbra is szerkeszthető marad a számláló és a nevező külön-külön.

## **Láthatóság és elrendezés szabályozása fantom elemekkel**

Csomagolja be a kifejezést egy [MathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathphantom/)‑ba, hogy önállóan szabályozza a láthatóságát és az egyenlethez hozzáadott helyet. Az [IMathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/) módszerek a következőket szabályozzák:

| Módszer | Hatás |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` értékkel rejti el a kifejezést. Méretei továbbra is hozzájárulnak az elrendezéshez, hacsak a lenti módszerek nem kapnak `true` értéket. |
| [setZeroWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | A kifejezés vízszintes szélességét nullaként kezeli, lehetővé téve a szomszédos elemek közelebb kerülését. |
| [setZeroAsc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | A kifejezés emelkedését (a vonal feletti magasságot) nullaként kezeli. |
| [setZeroDesc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | A kifejezés leereszkedését (a vonal alatti mélységet) nullaként kezeli. |

A baseline az a referencia vonal, amelyen az általános matematikai betűk állnak. A tartalom elrejtése nem távolítja el a méreteket, és egy dimenzió nullaként kezelése sem törli a kifejezést. A kifejezés a [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#getBase--)‑on keresztül továbbra is elérhető. Hívja meg a [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-)‑t `true`‑ra a megjelenítéshez; a dimenzióbeállítások változatlanok maradnak.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LTGRAY);

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

![Öt egyenlet a PowerPointban, amely összehasonlítja a látható törtet, egy helyet fenntartó rejtett törtet, valamint a ZeroWidth, ZeroAsc vagy ZeroDesc engedélyezett rejtett törteket](math-phantom.png)

## **Tagok csoportosítása**

Használja a [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-)‑t, hogy egy csoportosító karaktert helyezzen fel vagy alá egy kifejezéshez. Adjunk hozzá egy határértéket a csoportosított tagok felcímkézéséhez.

![Az x + y kifejezés csoportosítva, alul címkével: valamennyi szöveg](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Használjon formázó segédfüggvényeket csak ott, ahol azok tisztázzák a képletet. Például a [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) egy vonalat helyez egy matematikai elem fölé.

![Matematikai kifejezés ABC, fölötte vonallal](powerpoint-math-equations_14.png)

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

### **Szöveg formázása meglévő egyenletben**

A szöveg formázásához egy meglévő egyenletben járja be minden matematikai blokk elemfáját. Az [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a szöveget a törtekben, szkriptekben, gyökökben és más beágyazott struktúrákban. Ellenőrizze az aktuális elemet és annak gyermekeit is, hogy a [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) kezdőelemet is belefoglalja.

Ez a példa feltételezi, hogy az `input.pptx` egy olyan egyenletet tartalmaz, mint a `z = xᵢ / ∛y`, ahol a tört alsó indexet tartalmaz a számlálóban, a gyök pedig a nevezőben. A blokkok csak felső szintű elemeinek feldolgozása kihagyná a törtekben lévő szöveget. A példa megtalálja a matematikai részeket a dia szövegkereteiben, hozzáfér azok blokkjaihoz a [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)‑on keresztül, és a [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)‑t használja, hogy a betűmagasságot 28 pontra állítsa minden szövegelem [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) metódusával.

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

A mentett bemutató frissített szövegformázást tartalmaz minden feldolgozott egyenlet minden szintjén, miközben megőrzi a szövegtartalmat és a matematikai szerkezetet.

## **Gyorsreferencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Felső- vagy alsóindex hozzáadása | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Gyökök hozzáadása | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Határértékek hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Baloldali indexek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Összegzések és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Elválasztók hozzáadása | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Vonalak és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a bemutatót, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/)‑t tartalmaz, hívja meg a [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)‑t, és frissítse a matematika blokkokat abban a bekezdésben.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentve az Aspose.Slides az egyenletet szerkeszthető Office math tartalomként írja.

**Exportálhatok-e egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/)‑ját a [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/)‑ról, és hívja meg a [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--)‑t a közvetlen exportáláshoz. Teljes példa a [Matematikai egyenletek exportálása bemutatókból Androidon Java‑val](/slides/hu/androidjava/exporting-math-equations/#export-math-equations-to-latex) oldalon található.