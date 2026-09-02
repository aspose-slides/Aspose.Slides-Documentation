---
title: Gérer les paragraphes texte PowerPoint sur Android
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer la puce
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
- Android
- Java
- Aspose.Slides
description: Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour Android via Java.
---
## **Vue d'ensemble**

Aspose.Slides pour Android via Java représente le texte comme une hiérarchie de cadres de texte, de paragraphes et de portions :

* [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) représente le conteneur de texte dans une forme et fournit l'accès à sa collection de paragraphes.
* [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/) représente un paragraphe dans un cadre de texte et fournit l'accès à ses portions ainsi qu'au formatage au niveau du paragraphe.
* [IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) représente un segment de texte au sein d'un paragraphe. Chaque portion peut avoir son propre texte et un formatage au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formats en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte contenant trois paragraphes, chacun contenant trois portions :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accéder à la diapositive concernée par son indice.
3. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accéder au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme.
5. Utiliser le paragraphe par défaut et ajouter deux autres objets [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/) au cadre de texte.
6. Ajouter suffisamment d'objets [IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définir le texte de chaque portion.
8. Appliquer le formatage au niveau des caractères via [IPortion.getPortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Enregistrer la présentation modifiée.

Cet exemple Android via Java implémente les étapes :

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments connexes. Dans Aspose.Slides, les paramètres de liste sont définis via [IBulletFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accéder à la diapositive concernée par son indice.
3. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accéder au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme.
5. Supprimer le paragraphe par défaut du cadre de texte.
6. Créer un [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/) pour une puce de type symbole.
7. Définir [IBulletFormat.setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setType-int-) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/bullettype/) et spécifier le caractère de puce.
8. Définir le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Créer un deuxième paragraphe et définir [IBulletFormat.setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setType-int-) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/bullettype/).
11. Configurer le style de puce numérotée et ajouter le paragraphe au cadre de texte.
12. Enregistrer la présentation.

Cet exemple Android via Java crée une puce symbole et une puce numérotée :

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Utiliser des puces d'image**

Les puces d'image vous permettent d'utiliser une image personnalisée au lieu d'un symbole ou d'un chiffre.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accéder à la diapositive concernée par son indice.
3. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et accéder à son [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/).
4. Supprimer le paragraphe par défaut du cadre de texte.
5. Charger l'image de la puce et l'ajouter à la collection d'images de la présentation en tant qu'[IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/).
6. Créer un [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/) et définir son texte.
7. Définir [IBulletFormat.setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setType-int-) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/bullettype/).
8. Attribuer l'image via [IBulletFormat.getPicture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#getPicture--) et définir la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Enregistrer la présentation modifiée.

Cet exemple Android via Java crée une puce d'image :

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

### **Créer une liste à plusieurs niveaux**

Définir [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) pour placer les paragraphes à différents niveaux d'une liste. Le niveau supérieur a une profondeur de `0`.

1. Créer une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et accéder à une diapositive.
2. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et effacer le paragraphe par défaut de son cadre de texte.
3. Créer quatre paragraphes et configurer leurs symboles de puce.
4. Définir leurs valeurs [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) à `0`, `1`, `2` et `3`.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple Android via Java crée une liste à puces à quatre niveaux :

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Démarrer les éléments numérotés de la liste à des valeurs personnalisées**

Utiliser [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créer une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à une diapositive.
2. Effacer le paragraphe par défaut du cadre de texte de la forme.
3. Créer trois paragraphes numérotés.
4. Définir [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple Android via Java attribue un numéro de départ personnalisé à chaque paragraphe :

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

## **Contrôler la disposition et les propriétés de fin des paragraphes**

### **Définir un retrait de première ligne**

Utiliser [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour contrôler le retrait de la première ligne d'un paragraphe. Cette méthode déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utiliser [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) lorsque vous devez déplacer tout le paragraphe. Utiliser [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) lorsque vous devez déplacer uniquement la première ligne.

L'exemple ci-dessous crée plusieurs paragraphes et applique différentes valeurs [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour illustrer comment le retrait de première ligne affecte la disposition du paragraphe.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accéder à la diapositive cible.
3. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accéder au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme et supprimer le paragraphe par défaut.
5. Créer plusieurs paragraphes et définir différentes valeurs [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour chacun.
6. Ajouter les paragraphes au cadre de texte.
7. Enregistrer la présentation modifiée.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Un retrait suspendu est une disposition de paragraphe dans laquelle la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Fournissez une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) définit la position gauche du corps du paragraphe, et [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, donnez une valeur positive à `setMarginLeft` et une valeur négative à `setIndent`.

Ce formatage est utile pour les bibliographies, les références, les entrées de glossaire et d'autres paragraphes où les lignes renvoyées doivent être alignées sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accéder à la diapositive cible.
3. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accéder au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme et supprimer le paragraphe par défaut.
5. Créer des paragraphes et appliquer une valeur positive à [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pour chaque paragraphe.
6. Appliquer une valeur négative à [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour créer l'effet de retrait suspendu.
7. Ajouter les paragraphes au cadre de texte.
8. Enregistrer la présentation modifiée.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Définir les propriétés d'exécution de fin de paragraphe**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) contrôle le formatage du marqueur de fin de paragraphe. L'exemple suivant attribue une taille de police et une police latine au marqueur de fin du deuxième paragraphe :

1. Charger une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et accéder à une diapositive.
2. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et effacer son paragraphe par défaut.
3. Créer deux paragraphes et y ajouter des portions de texte.
4. Créer un [PortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/portionformat/) pour le marqueur de fin du deuxième paragraphe.
5. Définir [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) et [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Attribuer le format avec [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) et enregistrer la présentation.

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

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans les paragraphes**

Utiliser [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accéder à une diapositive et ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/).
3. Accéder au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme et effacer le paragraphe par défaut.
4. Lire le fichier HTML source.
5. Passer la chaîne HTML à [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Enregistrer la présentation modifiée.

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

### **Exporter le texte du paragraphe en HTML**

Utiliser [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pour exporter une plage sélectionnée de paragraphes en HTML.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et charger la présentation souhaitée.
2. Accéder à la diapositive et trouver la [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) qui contient le texte.
3. Accéder au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme.
4. Appeler [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) avec l'indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrire la chaîne HTML retournée dans un fichier.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
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

### **Rendre un paragraphe sous forme d'image**

[IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage--) rend directement un paragraphe individuel et retourne un [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Vous n'avez pas besoin de rendre la forme contenant ou de recadrer manuellement un bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage--) peut retourner `null` si le paragraphe est introuvable dans sa collection parente, n'a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l'enregistrer et libérez l'image retournée après usage.

#### **Rendre un paragraphe à l'échelle par défaut**

Supposons que nous possédions un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple suivant rend le deuxième paragraphe dans une forme de texte ordinaire à l'échelle par défaut et enregistre l'image retournée au format PNG. Le bloc `finally` garantit que l'image est correctement libérée.

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

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l'échelle**

Utilisez la surcharge [IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) qui accepte les paramètres `float scaleX` et `float scaleY` pour définir les facteurs d'échelle horizontale et verticale. L'exemple suivant crée un tableau, rend le paragraphe dans sa première cellule avec une largeur et une hauteur deux fois supérieures à la valeur par défaut, et enregistre le résultat sous forme d'image PNG.

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

Un facteur d'échelle de `1` conserve cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont environ deux fois les dimensions par défaut, ce qui donne quatre fois plus de pixels. Des facteurs plus élevés produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent également l'utilisation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le ratio d'aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [IShape.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getImage--) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou tout autre contexte visuel de la forme. Pour une image contenant uniquement le paragraphe, utilisez [IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Définissez [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Utilisez [IParagraph.getRect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getRect--) pour récupérer le rectangle englobant du paragraphe. [IPortion.getRect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/#getRect--) fournit les limites d'une portion individuelle.

**Où le alignement du paragraphe (gauche, droite, centre ou justifié) est‑il contrôlé ?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) est un paramètre au niveau du paragraphe et s'applique à l'ensemble du paragraphe, quel que soit le formatage des portions individuelles.

**Puis‑je définir la langue de vérification orthographique pour une partie d'un paragraphe ?**

Oui. Définissez [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pour les portions individuelles, de sorte qu'un paragraphe puisse contenir du texte en plusieurs langues.