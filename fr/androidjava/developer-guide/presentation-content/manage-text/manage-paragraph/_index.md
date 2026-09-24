---
title: "Gérer les paragraphes de texte PowerPoint sur Android"
linktitle: "Gérer le paragraphe"
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
- gérer les puces
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte en HTML
- paragraphe en HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour Android via Java."
---
## **Aperçu**

Aspose.Slides pour Android via Java représente le texte sous forme d’une hiérarchie de cadres de texte, de paragraphes et de portions :

* [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) représente le conteneur de texte d’une forme et fournit l’accès à sa collection de paragraphes.
* [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/) représente un paragraphe dans un cadre de texte et fournit l’accès à ses portions et à la mise en forme au niveau du paragraphe.
* [IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) représente un texte continu dans un paragraphe. Chaque portion peut avoir son propre texte et une mise en forme au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres mises en forme en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme.
5. Utilisez le paragraphe par défaut et ajoutez deux objets [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/) supplémentaires au cadre de texte.
6. Ajoutez suffisamment d’objets [IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définissez le texte de chaque portion.
8. Appliquez une mise en forme au niveau des caractères via [IPortion.getPortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Enregistrez la présentation modifiée.

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

Les puces et la numérotation facilitent la lecture des éléments liés. Dans Aspose.Slides, les paramètres de listes sont définis via [IBulletFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme.
5. Supprimez le paragraphe par défaut du cadre de texte.
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/) pour une puce symbole.
7. Définissez [IBulletFormat.setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setType-int-) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/bullettype/) et spécifiez le caractère de la puce.
8. Définissez le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Créez un second paragraphe et définissez [IBulletFormat.setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setType-int-) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/bullettype/).
11. Configurez le style de puce numérotée et ajoutez le paragraphe au cadre de texte.
12. Enregistrez la présentation.

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

### **Utiliser des puces image**

Les puces image vous permettent d’utiliser une image personnalisée à la place d’un symbole ou d’un chiffre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive concernée par son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et accédez à son [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/).
4. Supprimez le paragraphe par défaut du cadre de texte.
5. Chargez l’image de la puce et ajoutez‑la à la collection d’images de la présentation en tant que [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/).
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/) et définissez son texte.
7. Définissez [IBulletFormat.setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setType-int-) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/bullettype/).
8. Assignez l’image via [IBulletFormat.getPicture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#getPicture--) et définissez la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Enregistrez la présentation modifiée.

Cet exemple Android via Java crée une puce image :

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

Définissez [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et supprimez le paragraphe par défaut de son cadre de texte.
3. Créez quatre paragraphes et configurez leurs symboles de puce.
4. Définissez leurs valeurs [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) à `0`, `1`, `2` et `3`.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

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

### **Démarrer les éléments de liste numérotée avec des valeurs personnalisées**

Utilisez [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à une diapositive.
2. Supprimez le paragraphe par défaut du cadre de texte de la forme.
3. Créez trois paragraphes numérotés.
4. Définissez [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

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

## **Contrôler la mise en forme du paragraphe et les propriétés de fin**

### **Définir un retrait de première ligne**

Utilisez [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour contrôler le retrait de la première ligne d’un paragraphe. Cette méthode déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées au corps du paragraphe.

Utilisez [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) lorsque vous devez déplacer tout le paragraphe. Utilisez [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) lorsque vous devez déplacer uniquement la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour démontrer comment le retrait de première ligne affecte la mise en forme du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour ceux‑ci.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait de paragraphe :

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

Un retrait suspendu est une mise en forme de paragraphe dans laquelle la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Passez une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) définit la position gauche du corps du paragraphe, et [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, passez une valeur positive à `setMarginLeft` et une valeur négative à `setIndent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes enroulées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et passez une valeur positive à [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pour chaque paragraphe.
6. Passez une valeur négative à [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour créer l’effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait suspendu pour un paragraphe :

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

### **Définir les propriétés de fin de paragraphe**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) contrôle le formatage du marqueur de fin du paragraphe. L’exemple suivant attribue une taille de police et une police latine au marqueur de fin du second paragraphe :

1. Chargez une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et supprimez son paragraphe par défaut.
3. Créez deux paragraphes et ajoutez des portions de texte.
4. Créez un [PortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/portionformat/) pour le marqueur de fin du second paragraphe.
5. Définissez [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) et [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Assignez le format avec [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) et enregistrez la présentation.

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

Utilisez [IParagraph.getLinesCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) pour compter les lignes occupées par un paragraphe après la mise en page du texte, y compris le retour à la ligne automatique. Cela est utile lors de la vérification de la longueur du texte et de la mise en page dans des modèles de présentation.

Un paragraphe est un élément de [ITextFrame.getParagraphs](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParagraphs--), et il peut occuper plusieurs lignes rendues. Un retour à la ligne explicite à l’intérieur d’un paragraphe force une nouvelle ligne sans créer un nouveau paragraphe. Le retour à la ligne automatique crée des lignes en fonction de la largeur disponible sans insérer de caractères de retour à la ligne explicites dans le texte. Compter les paragraphes ou les caractères de retour à la ligne ne donne donc pas le nombre de lignes rendues.

L’exemple suivant crée une forme de texte, compte ses lignes, rétrécit la forme, puis remplace le texte par une chaîne plus courte. Le retour à la ligne est activé et le redimensionnement automatique désactivé afin que la largeur de la forme contrôle le retour à la ligne sans réduire automatiquement le texte ni redimensionner la forme. Les dimensions de la forme sont exprimées en points. Enfin, l’exemple ajoute un autre paragraphe et somme les décomptes de lignes dans le cadre de texte.

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

Avec ce texte et ces dimensions, rétrécir la forme augmente le nombre de lignes, tandis que remplacer le texte par la chaîne courte le réduit. Les décomptes exacts peuvent varier selon la disponibilité et le remplacement des polices, la taille de la police, les marges, les retraits, le retour à la ligne et les paramètres de redimensionnement automatique. Utilisez les polices et les paramètres de mise en page prévus pour l’environnement cible lors de la vérification d’un modèle.

Le nombre de lignes seul ne détermine pas si le texte dépasse son conteneur. La hauteur disponible, les hauteurs de ligne, les interlignes de paragraphe et de ligne, ainsi que le comportement du redimensionnement automatique sont également importants ; même une seule ligne peut dépasser la largeur disponible lorsque le retour à la ligne est désactivé.

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans les paragraphes**

Utilisez [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à une diapositive et ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/).
3. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de la forme et supprimez son paragraphe par défaut.
4. Lisez le fichier HTML source.
5. Passez la chaîne HTML à [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Enregistrez la présentation modifiée.

Cet exemple Android via Java importe du HTML dans un cadre de texte :

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

Utilisez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pour exporter une plage sélectionnée de paragraphes au format HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la diapositive et trouvez la [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) contenant le texte.
3. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/).
4. Appelez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) avec l’indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrivez la chaîne HTML retournée dans un fichier.

Cet exemple Android via Java exporte tous les paragraphes du premier cadre de texte :

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

### **Rendre un paragraphe en image**

[IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage--) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Vous n’avez pas besoin de rendre la forme contenant le texte ni de recadrer manuellement un bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage--) peut retourner `null` si le paragraphe est introuvable dans sa collection parent, n’a pas de limites de rendu valides ou ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

Supposons que nous ayons un fichier de présentation nommé sample.pptx contenant une diapositive, dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L’exemple suivant rend le second paragraphe d’une forme de texte ordinaire à l’échelle par défaut et enregistre l’image retournée au format PNG. Le bloc `finally` garantit que l’image est correctement libérée.

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

![L’image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) qui accepte les paramètres `float scaleX` et `float scaleY` pour définir les facteurs d’échelle horizontaux et verticaux. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, puis enregistre le résultat au format PNG.

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

Un facteur d’échelle de `1` conserve cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement le double des dimensions par défaut, ce qui donne quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent également la consommation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le rapport d’aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [IShape.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getImage--) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou tout autre contexte visuel de la forme. Pour une image ne contenant que le paragraphe, utilisez [IParagraph.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne dans un cadre de texte ?**

Oui. Définissez [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites précises d’un paragraphe spécifique sur la diapositive ?**

Utilisez [IParagraph.getRect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/#getRect--) pour récupérer le rectangle englobant du paragraphe. [IPortion.getRect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/#getRect--) fournit les limites d’une portion individuelle.

**Où le alignement du paragraphe (gauche, droite, centré ou justifié) est‑il contrôlé ?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) est un paramètre au niveau du paragraphe et s’applique à l’ensemble du paragraphe indépendamment du formatage des portions individuelles.

**Puis‑je définir la langue de vérification orthographique pour une partie d’un paragraphe ?**

Oui. Définissez [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pour les portions individuelles, de sorte qu’un même paragraphe puisse contenir du texte en plusieurs langues.