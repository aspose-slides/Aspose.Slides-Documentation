---
title: Gérer les paragraphes de texte PowerPoint en Java
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer les puces
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphe avec Aspose.Slides for Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java représente le texte sous la forme d’une hiérarchie de cadres de texte, de paragraphes et de portions :

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) représente le conteneur de texte dans une forme et fournit l’accès à sa collection de paragraphes.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) représente un paragraphe dans un cadre de texte et fournit l’accès à ses portions ainsi qu’au formatage au niveau du paragraphe.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) représente un fragment de texte au sein d’un paragraphe. Chaque portion peut avoir son propre texte et son formatage au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formats en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

Créez des paragraphes dans le cadre de texte d’une forme et utilisez les portions pour formater les fragments de texte individuels. Cette section montre comment combiner plusieurs portions au sein de chaque paragraphe et appliquer différentes couleurs, tailles de police et styles.

### **Créer des paragraphes avec plusieurs portions**

L’exemple Java suivant crée trois paragraphes, chacun contenant trois fragments de texte dans la collection renvoyée par la méthode [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) . Il réutilise le paragraphe par défaut et sa portion vide, puis ajoute les paragraphes et portions restants. Le formatage est appliqué via [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) : la première portion de chaque paragraphe est rouge, en gras et de 15 points ; la deuxième est bleue, en italique et de 18 points. La troisième portion conserve son formatage par défaut :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer des listes à puces et numérotées**

Organisez le texte des paragraphes sous forme de listes à puces, à numéros ou avec des images personnalisées. Les exemples de cette section couvrent le formatage des puces, les listes à plusieurs niveaux et les numéros de départ personnalisés.

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/).

Cet exemple Java ajoute une puce symbole et un élément numéroté au même cadre de texte. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) sélectionne le type de puce, tandis que [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) fournit le symbole et [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) sélectionne le style de numérotation. Les deux éléments utilisent des puces noires avec une hauteur de 100 % et un retrait de paragraphe de 25 points :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Utiliser des puces image**

Les puces image vous permettent d’utiliser une image personnalisée à la place d’un symbole ou d’un numéro.

Cet exemple Java ajoute une image à la collection d’images de la présentation en tant qu’[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) et l’utilise comme puce de paragraphe. Il appelle [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) pour sélectionner une puce image et affecte l’image via [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) est fixé à 100 % pour dimensionner la puce relativement au texte du paragraphe :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Créer une liste multiniveau**

Définissez [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

Cet exemple Java affecte des valeurs de [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) de 0 à 3 à quatre paragraphes, créant une hiérarchie au sein d’un même cadre de texte. Chaque paragraphe utilise une puce symbole, avec [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) alternant entre une puce ronde et un tiret pour distinguer les niveaux adjacents :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Commencer les éléments de liste numérotée à des valeurs personnalisées**

Utilisez [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) pour définir le numéro initial affiché pour un paragraphe numéroté.

Cet exemple Java définit [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) pour la numérotation de trois paragraphes et affecte les valeurs 2, 3 et 7 via [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-). La valeur de départ est configurée séparément pour chaque paragraphe, ce qui permet aux numéros affichés d’ignorer certaines valeurs :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler la disposition des paragraphes et les propriétés de fin**

Ajustez les marges et retraits des paragraphes pour contrôler la position de la première ligne et des lignes renvoyées. Vous pouvez également formater le signe de fin de paragraphe séparément du texte visible.

### **Définir un retrait de première ligne**

Utilisez la méthode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pour contrôler le retrait de première ligne d’un paragraphe. Ce réglage ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utilisez [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) lorsque vous devez déplacer tout le paragraphe. Utilisez [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) lorsque vous ne devez déplacer que la première ligne.

L’exemple suivant attribue à trois paragraphes la même [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de 20 points et des valeurs de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) de 0, 20 et 40 points. Les premières lignes commencent à des décalages progressivement plus grands, tandis que les lignes renvoyées conservent la même marge gauche :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une disposition où la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la propriété [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Affectez `Indent` à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) définit la position gauche du corps du paragraphe, et [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, attribuez une valeur positive à `MarginLeft` et une valeur négative à `Indent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

L’exemple Java suivant associe des valeurs de [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de 40 et 60 points avec des valeurs de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) de -20 et -30 points. Dans chaque paragraphe, la première ligne débute à gauche des lignes renvoyées ; le deuxième paragraphe possède un retrait suspendu plus important :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin du paragraphe**

La méthode [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) contrôle le formatage du signe de fin de paragraphe. L’exemple suivant crée un [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) avec [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) réglé à 48 points et [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) défini sur Times New Roman. Il affecte ce format au signe de fin du deuxième paragraphe, laissant les portions de texte visibles inchangées :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compter les lignes rendues**

Pour les règles de paragraphe qui affectent le renvoi automatique et la ponctuation en fin de ligne, consultez [Control Line Breaking](/slides/fr/java/text-formatting/#control-line-breaking) et [Control Hanging Punctuation](/slides/fr/java/text-formatting/#control-hanging-punctuation).

Utilisez [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) pour compter les lignes occupées par un paragraphe après la mise en page du texte, y compris le renvoi automatique. Cela est utile pour vérifier la longueur du texte et la mise en page dans les modèles de présentation.

Un paragraphe est un élément de [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) et peut occuper plusieurs lignes rendues. Un saut de ligne explicite à l’intérieur d’un paragraphe force une nouvelle ligne sans créer un autre paragraphe. Le renvoi automatique crée des lignes en fonction de la largeur disponible sans insérer de sauts de ligne explicites dans le texte. Compter les paragraphes ou les caractères de saut de ligne ne donne donc pas le nombre de lignes réellement rendues.

L’exemple suivant crée une forme de texte, compte ses lignes, réduit la forme, puis remplace le texte par une chaîne plus courte. L’exemple active le renvoi avec [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) et désactive l’ajustement automatique avec [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) afin que la largeur de la forme contrôle le renvoi sans réduire automatiquement le texte ni redimensionner la forme. Chaque mesure utilise [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--). Les dimensions de la forme sont exprimées en points. Enfin, l’exemple ajoute un autre paragraphe et additionne les comptes de lignes à travers le cadre de texte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Avec ce texte et ces dimensions, réduire la forme augmente le nombre de lignes, tandis que remplacer le texte par la chaîne courte le diminue. Les comptes exacts peuvent varier selon la disponibilité et la substitution des polices, la taille de la police, les marges, les retraits, le renvoi et les réglages d’ajustement. Utilisez les polices et les paramètres de mise en page prévus pour l’environnement cible lors de la vérification d’un modèle.

Le nombre de lignes seul ne détermine pas si le texte dépasse son conteneur. La hauteur disponible, la hauteur des lignes, l’espacement des paragraphes et des lignes, ainsi que le comportement d’ajustement, sont également importants ; même une seule ligne peut excéder la largeur disponible si le renvoi est désactivé.

## **Importer et exporter le contenu du paragraphe**

Utilisez HTML pour insérer du texte dans une présentation ou exporter des paragraphes existants afin de les utiliser en dehors. Cette section montre également comment rendre des paragraphes individuels en images, y compris les paragraphes dans les cellules de tableau.

### **Importer du texte HTML dans les paragraphes**

Utilisez [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pour convertir du balisage HTML en paragraphes et portions dans un cadre de texte.

Cet exemple Java lit du HTML depuis un fichier et transmet le balisage à [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Il vide le paragraphe par défaut du cadre de texte afin que le cadre ne contienne que le contenu importé. La forme rectangulaire laisse une marge de 10 points de chaque côté de la diapositive :

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Exporter le texte du paragraphe au format HTML**

Utilisez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pour exporter une plage sélectionnée de paragraphes au format HTML. Lors de la réutilisation du texte d’une présentation sur un site web, vous pouvez vouloir préserver l’accentuation locale sans transporter la police, la taille ou les styles de zone de texte de la présentation. Réglez [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) pour contrôler jusqu’où l’exportateur suit l’héritage du formatage.

Téléchargez [la présentation d’exemple](text-inheritance.pptx) et placez‑la dans le répertoire de travail de l’application. Sa première diapositive contient une forme de texte avec le texte « Inherited text; explicit red 18pt ». L’entrée utilise délibérément plusieurs niveaux de formatage :

- Le style de texte par défaut de la présentation fournit Calibri et une taille de 28 pt.
- Le style de texte de premier niveau du cadre de texte fournit du texte bleu et de l’italique.
- Le paragraphe définit explicitement le texte en gras.
- La deuxième portion, « explicit red 18pt », définit explicitement le texte rouge et une taille de 18 pt.

L’exemple complet suivant exporte les mêmes paragraphes trois fois. Il transmet [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) à la méthode d’exportation et écrit chaque résultat dans un fichier HTML UTF‑8 séparé :

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Le HTML généré contient le CSS suivant pour la première portion, « Inherited text; ». Le tableau répertorie les déclarations pertinentes ; les autres propriétés générées sont omises pour plus de clarté.

| Sortie | CSS pertinent pour la première portion | Apparence |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique à 28 pt en Calibri, si cette police est disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique ; la page ou le navigateur fournit la famille de police et la taille. |
| `ParagraphOnly.html` | `font-weight:bold` | Texte gras ; la page ou le navigateur fournit la famille de police, la taille, la couleur et le style italique. |

La deuxième portion conserve `color:#ff0000`, `font-size:18pt` et `font-weight:bold` dans les trois sorties. Elle conserve également l’italique avec `All` et `TextBox`, mais pas avec `ParagraphOnly`. Restreindre l’héritage ne supprime donc pas le formatage explicitement assigné à un paragraphe ou à une portion.

Ouvrez les fichiers dans le même navigateur pour les comparer. Dans les deux modes restreints, les propriétés CSS omises sont résolues par les styles de la page de destination ou les valeurs par défaut du navigateur, de sorte que l’apparence finale dépend de l’endroit où le HTML est utilisé.

### **Rendre un paragraphe en image**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Vous n’avez pas besoin de rendre la forme contenant le paragraphe ni de recadrer un bitmap manuellement.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) peut renvoyer `null` si le paragraphe n’est pas trouvé dans sa collection parente, s’il n’a pas de limites de rendu valides, ou s’il ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

L’exemple utilise une présentation comportant une diapositive dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L’exemple suivant sélectionne le deuxième paragraphe d’indice 1 et appelle [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) sans paramètres d’échelle. Il vérifie que la forme contient le paragraphe requis et que le rendu renvoie une image avant d’appeler [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) pour l’enregistrer au format PNG. Le bloc `finally` libère l’image après usage.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Le résultat :

![L'image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) qui accepte les paramètres `float scaleX` et `float scaleY` pour définir les facteurs d’échelle horizontaux et verticaux. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, puis enregistre le résultat au format PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Un facteur d’échelle de `1` conserve cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement deux fois les dimensions d’origine, soit quatre fois plus de pixels. Des facteurs plus élevés produisent généralement un texte plus net pour le zoom ou la sortie haute résolution, mais augmentent aussi la consommation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le ratio d’aspect du paragraphe ; des facteurs différents entre l’horizontale et la verticale étirent la sortie indépendamment.

Rendre toute une forme avec [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou d’autres contextes visuels de la forme. Pour une image contenant uniquement le paragraphe, utilisez [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Réglez [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) pour désactiver le renvoi afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Utilisez [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) pour récupérer le rectangle englobant du paragraphe. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) fournit les limites d’une portion individuelle.

**Où le réglage d’alignement du paragraphe (gauche, droite, centre ou justifié) est‑il contrôlé ?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) est un paramètre au niveau du paragraphe et s’applique à l’ensemble du paragraphe quel que soit le formatage des portions individuelles.

Pour aligner verticalement des portions de tailles de police différentes dans chaque ligne, consultez [Align Fonts Within a Line](/slides/fr/java/text-formatting/#align-fonts-within-a-line).

**Puis‑je définir la langue de vérification orthographique pour une partie d’un paragraphe ?**

Oui. Réglez [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pour les portions individuelles, de sorte qu’un paragraphe puisse contenir du texte dans plusieurs langues.