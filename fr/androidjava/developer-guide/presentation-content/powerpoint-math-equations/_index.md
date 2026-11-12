---
title: Ajouter des équations mathématiques aux présentations PowerPoint sur Android
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/androidjava/powerpoint-math-equations/
keywords:
- équation mathématique
- symbole mathématique
- formule mathématique
- texte mathématique
- ajouter une équation mathématique
- ajouter un symbole mathématique
- ajouter une formule mathématique
- ajouter un texte mathématique
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans les fichiers PowerPoint PPT et PPTX avec Aspose.Slides pour Android, en prenant en charge OMML, les contrôles de formatage et des exemples de code Java clairs."
---
## **Vue d'ensemble**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides for Android via Java, vous pouvez créer le même type de contenu mathématique de manière programmatique : fractions, radicaux, fonctions, limites, opérateurs n‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations depuis **Insertion > Équation** :

![Onglet Insertion de PowerPoint avec la commande Équation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique modifiable sur la diapositive :

![Une diapositive PowerPoint contenant une équation mathématique modifiable](powerpoint-math-equations_2.png)

Aspose.Slides crée ce texte mathématique à l’aide de trois objets principaux :

- Une forme mathématique, créée avec [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/), est la forme qui contient l’équation.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) stocke le contenu mathématique à l’intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

La plupart des exemples ci‑dessous utilisent [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) et les méthodes fluides de [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) pour garder le code court et lisible.

Pour les scénarios d’exportation MathML, voir [Exporter des équations mathématiques depuis des présentations sur Android](/slides/fr/androidjava/exporting-math-equations/).

## **Créer une équation**

Cet exemple utilise [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) pour créer une forme mathématique et ajoute le théorème de Pythagore :

![L’équation c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), appelez [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), et ajoutez des blocs mathématiques ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/).

![Une fraction mathématique biaisée montrant un divisé par x](powerpoint-math-equations_4.png)

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

Pour une fraction empilée, utilisez [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar) :

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Ajouter des radicaux**

Utilisez [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) pour créer une racine carrée, une racine cubique ou toute autre racine. L’élément courant devient la base, et l’argument devient le degré.

![Une expression radicée de n‑ième racine avec x sous le signe radical](powerpoint-math-equations_5.png)

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

## **Ajouter des fonctions et des limites**

Utilisez [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) ou [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) pour des fonctions telles que `sin(x)`, `log(x)` ou des noms de fonction personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) ou utilisez [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![La limite de x lorsque x tend vers l’infini](powerpoint-math-equations_8.png)

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

Pour un nom de fonction personnalisé, faites du nom de fonction l’élément courant et appelez [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) avec son argument :

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Ajouter des opérateurs n‑aires et des intégrales**

Utilisez [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) pour les sommes, les unions, les intersections et d’autres grands opérateurs. Utilisez [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) pour les intégrales. Les deux méthodes vous permettent de définir les limites inférieure et supérieure.

![Une sommation avec limites inférieure et supérieure](powerpoint-math-equations_7.png)

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

Les opérateurs n‑aires sont destinés aux grands opérateurs avec limites optionnelles. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés en tant que [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) et joints à l’expression.

Pour une intégrale, utilisez [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) :

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) pour les lignes et les colonnes. Les matrices n’incluent pas de crochets par défaut, donc encadrez la matrice lorsque vous avez besoin de parenthèses, de crochets ou d’accolades.

![Une matrice mathématique à deux lignes avec une cellule vide](powerpoint-math-equations_10.png)

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

## **Ajouter des tableaux d’équations**

Utilisez [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) lorsque vous avez besoin d’équations alignées ou d’une pile verticale d’expressions.

![Un tableau mathématique vertical avec x au-dessus de y](powerpoint-math-equations_11.png)

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

## **Ajouter des fonctions trigonométriques**

Utilisez [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) lorsque l’argument est l’élément courant et que le nom de la fonction est connu.

![La fonction trigonométrique cos appliquée à 2x](powerpoint-math-equations_6.png)

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

## **Ajouter des indices et des exposants**

Utilisez les assistants d’indice et d’exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Un Y majuscule avec indice gauche 1 et exposant n](powerpoint-math-equations_9.png)

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

## **Ajouter des délimiteurs**

Utilisez [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) pour placer une expression entre délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

![Une expression délimitée contenant x, y et z séparés par des barres verticales](powerpoint-math-equations_13.png)

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

### **Taille et alignement des délimiteurs**

Passez `true` à [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) pour laisser les parenthèses s’agrandir autour d’un opérande haut, ou passez `false` pour les garder à leur taille normale. Utilisez [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) avec l’une des deux valeurs [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/). `Centered` centre les parenthèses sur l’axe mathématique, qui traverse le milieu du signe égal. `Match` les aligne avec le contenu enfermé. Les deux réglages n’affectent que les délimiteurs. L’expression à l’intérieur reste la même.

L’exemple place une fraction dans l’exposant de `x` de sorte que l’expression s’étende davantage au‑dessus de la ligne de base qu’en dessous. Les quatre équations utilisent les mêmes parenthèses et paramètres de police.

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

Dans PowerPoint, comparez les lignes pour voir l’effet de l’agrandissement. Dans la ligne supérieure, les parenthèses s’agrandissent pour englober l’exposant et sont identiques pour les deux formes. Dans la ligne inférieure, l’agrandissement est désactivé. Les petites parenthèses à gauche (`Centered`) sont alignées avec le signe égal, tandis que celles à droite (`Match`) sont placées plus haut autour de l’expression.

![Quatre équations dans PowerPoint avec croissance des délimiteurs activée en haut et désactivée en bas, et Centered à gauche et Match à droite](delimiter-sizing.png)

## **Ajouter une boîte de bordure**

Appelez [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) sur une fraction pour encadrer l’expression entière. Le [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) retourné affiche les quatre côtés par défaut. Utilisez [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), et [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) pour supprimer des côtés individuels.

L’exemple place six copies de la même fraction sur une diapositive. Pour montrer une annulation, masquez les quatre côtés et passez `true` à [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) pour une diagonale ascendante (↗) ou à [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) pour une diagonale descendante (↘). Vous pouvez également utiliser [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) ou [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) avec n’importe quelle combinaison de côtés visibles.

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

![Six fractions éditables dans PowerPoint. Ligne supérieure : bordure complète, côtés inférieur et gauche, diagonale ascendante. Ligne inférieure : diagonale descendante, barre horizontale, barre verticale avec bordure complète](border-box-fractions.png)

Sur cette fraction, la barre horizontale chevauche la barre de fraction. La barre verticale traverse à la fois le numérateur et le dénominateur tandis que la bordure entourante reste visible. Ces lignes décorent l’ensemble de l’expression. Le barré de texte ordinaire s’applique aux caractères d’une séquence de texte. Après avoir rouvert la présentation dans PowerPoint, vous pouvez encore modifier le numérateur et le dénominateur séparément.

## **Grouper les termes**

Utilisez [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) pour placer un caractère de regroupement au-dessus ou en dessous d’une expression. Ajoutez une limite pour étiqueter les termes regroupés.

![L’expression x + y groupée avec l’étiquette n’importe quel texte en dessous](powerpoint-math-equations_15.png)

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

## **Formater les éléments mathématiques**

Utilisez les helpers de formatage uniquement lorsqu’ils clarifient la formule. Par exemple, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) place une barre au‑dessus d’un élément mathématique.

![Une expression mathématique ABC avec une barre au‑dessus](powerpoint-math-equations_14.png)

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

### **Formater le texte dans une équation existante**

Pour formater le texte dans une équation existante, parcourez l’arbre d’éléments de chaque bloc mathématique. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) renvoie uniquement les enfants immédiats, il faut donc l’appeler récursivement pour atteindre le texte à l’intérieur des fractions, exposants, radicaux et autres structures imbriquées. Vérifiez l’élément courant ainsi que ses enfants afin d’inclure l’élément de départ lorsqu’il s’agit de [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/).

Cet exemple suppose que `input.pptx` contient une équation telle que `z = xᵢ / ∛y`, avec une fraction contenant un indice dans son numérateur et un radical dans son dénominateur. Ne traiter que les éléments de niveau supérieur du bloc manquerait le texte à l’intérieur de la fraction. L’exemple trouve les portions mathématiques dans les cadres de texte des diapositives, accède à leurs blocs via [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), et utilise [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour définir la taille de police à 28 points via la méthode [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) de chaque élément de texte.

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

La présentation enregistrée contient le formatage du texte mis à jour à chaque niveau de chaque équation traitée, tout en préservant son contenu texte et sa structure mathématique.

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| Combiner des éléments | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Créer des fractions | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter un exposant ou un indice | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des fonctions | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des radicaux | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des limites | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des indices à gauche | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des sommes et des intégrales | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| Ajouter des tableaux d’équations | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des délimiteurs | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ajouter des barres et des bordures | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Regrouper les termes | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **FAQ**

**Puis-je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), appelez [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), et mettez à jour les blocs mathématiques dans ce paragraphe.

**Les équations sont‑elles enregistrées comme mathématiques PowerPoint modifiables ?**

Oui. Lorsque vous enregistrez au format PPTX, Aspose.Slides écrit l’équation sous forme de contenu Office mathématique modifiable.

**Puis‑je exporter des équations vers LaTeX ?**

Oui. Obtenez le [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) de son [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/), et appelez [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) pour l’exporter directement. Pour un exemple complet, voir [Exporter des équations mathématiques depuis des présentations sous Android via Java](/slides/fr/androidjava/exporting-math-equations/#export-math-equations-to-latex).