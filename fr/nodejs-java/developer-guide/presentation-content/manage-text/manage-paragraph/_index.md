---
title: Gérer les paragraphes de texte PowerPoint en JavaScript
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
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
  - importer du HTML
  - texte vers HTML
  - paragraphe vers HTML
  - paragraphe vers image
  - texte vers image
  - exporter le paragraphe
  - PowerPoint
  - présentation
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, portions, puces, listes numérotées, retraits, contenu HTML et images de paragraphes avec Aspose.Slides for Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java représente le texte comme une hiérarchie de cadres de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) représente le conteneur de texte d'une forme et fournit l'accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l'accès à ses portions ainsi qu'au formatage au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) représente un segment de texte à l'intérieur d'un paragraphe. Chaque portion peut avoir son propre texte et son formatage au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formats en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme.
5. Utilisez le paragraphe par défaut et ajoutez deux autres objets [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) au cadre de texte.
6. Ajoutez suffisamment d'objets [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définissez le texte de chaque portion.
8. Appliquez le formatage au niveau des caractères via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/getportionformat/).
9. Enregistrez la présentation modifiée.

This JavaScript example implements the steps:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer des listes à puces et numérotées**

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture d'éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme.
5. Supprimez le paragraphe par défaut du cadre de texte.
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) pour une puce de type symbole.
7. Définissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/settype/) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bullettype/) et spécifiez le caractère de la puce.
8. Définissez le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Créez un second paragraphe et définissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/settype/) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bullettype/).
11. Configurez le style de puce numérotée et ajoutez le paragraphe au cadre de texte.
12. Enregistrez la présentation.

This JavaScript example creates a symbol bullet and a numbered bullet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Utiliser des puces image**

Les puces image vous permettent d'utiliser une image personnalisée au lieu d'un symbole ou d'un numéro.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) et accédez à son [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/).
4. Supprimez le paragraphe par défaut du cadre de texte.
5. Chargez l'image de la puce et ajoutez‑la à la collection d'images de la présentation sous forme de [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/).
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) et définissez son texte.
7. Définissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/settype/) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bullettype/).
8. Assignez l'image via [BulletFormat.getPicture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/getpicture/) et définissez la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Enregistrez la présentation modifiée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Créer une liste à plusieurs niveaux**

Définissez [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setdepth/) pour placer les paragraphes à différents niveaux d'une liste. Le niveau supérieur a une profondeur de `0`.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) et effacez le paragraphe par défaut de son cadre de texte.
3. Créez quatre paragraphes et configurez leurs symboles de puce.
4. Définissez leurs valeurs [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setdepth/) à `0`, `1`, `2` et `3`.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Démarrer les éléments de liste numérotée à des valeurs personnalisées**

Utilisez [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à une diapositive.
2. Effacez le paragraphe par défaut du cadre de texte de la forme.
3. Créez trois paragraphes numérotés.
4. Définissez [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler la mise en forme des paragraphes et les propriétés de fin**

### **Définir un retrait de première ligne**

Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) pour contrôler le retrait de la première ligne d'un paragraphe. Cette méthode déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utilisez [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) lorsque vous ne devez déplacer que la première ligne.

L'exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) pour démontrer comment le retrait de première ligne affecte la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) pour chacun.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Le retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une mise en forme de paragraphe dans laquelle la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/). Passez une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) définit la position gauche du corps du paragraphe, et [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, passez une valeur positive à `setMarginLeft` et une valeur négative à `setIndent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent être alignées sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et passez une valeur positive à [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) pour chaque paragraphe.
6. Passez une valeur négative à [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) pour créer l'effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin de paragraphe**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) contrôle le formatage du caractère de fin de paragraphe. L'exemple suivant attribue une taille de police et une police latine au caractère de fin du deuxième paragraphe :

1. Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) et effacez son paragraphe par défaut.
3. Créez deux paragraphes et ajoutez des portions de texte à ceux‑ci.
4. Créez un [PortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/) pour le caractère de fin du deuxième paragraphe.
5. Définissez [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) et [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Appliquez le format avec [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) et enregistrez la présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans les paragraphes**

Utilisez [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à une diapositive et ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/).
3. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme et effacez le paragraphe par défaut.
4. Définissez ou lisez la chaîne HTML source.
5. Transférez la chaîne HTML à [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Enregistrez la présentation modifiée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Exporter le texte du paragraphe vers HTML**

Utilisez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) pour exporter une plage sélectionnée de paragraphes en HTML.

1. Créez ou chargez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive et trouvez la [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) qui contient le texte.
3. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme.
4. Appelez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) avec l'indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrivez la chaîne HTML renvoyée dans un fichier.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Rendre un paragraphe sous forme d'image**

[Paragraph.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/#getImage) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/). Enregistrez le résultat dans un fichier avec [IImage.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/#save). Vous n'avez pas besoin de rendre la forme contenant ou de recadrer manuellement un bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/#getImage) peut renvoyer `null` si le paragraphe est introuvable dans sa collection parente, n'a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l'enregistrer et libérez l'image renvoyée après utilisation.

#### **Rendre un paragraphe à l'échelle par défaut**

La zone de texte suivante contient trois paragraphes :

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple suivant rend le deuxième paragraphe dans une forme de texte ordinaire à l'échelle par défaut et enregistre l'image renvoyée au format PNG. Le bloc `finally` garantit que l'image est correctement libérée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

![L'image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l'échelle**

Utilisez la surcharge de [Paragraph.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/#getImage) qui accepte les paramètres `scaleX` et `scaleY` pour définir les facteurs d'échelle horizontaux et verticaux. L'exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat sous forme d'image PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Un facteur d'échelle de `1` maintient cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement deux fois les dimensions par défaut, ce qui donne quatre fois plus de pixels. Des facteurs plus élevés produisent généralement un texte plus net pour le zoom ou la sortie haute résolution, mais ils augmentent également l'utilisation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour conserver le rapport d'aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [Shape.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getImage) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou autre contexte visuel de la forme. Pour une image ne contenant que le paragraphe, utilisez [Paragraph.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Définissez [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/setwraptext/) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/getrect/) pour récupérer le rectangle englobant du paragraphe. [Portion.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#getRect) fournit les limites d'une portion individuelle.

**Où le alignement du paragraphe (gauche, droite, centre ou justifié) est‑il contrôlé ?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setalignment/) est un réglage au niveau du paragraphe et s'applique à tout le paragraphe, quel que soit le formatage des portions individuelles.

**Puis‑je définir la langue de vérification orthographique pour une partie d'un paragraphe ?**

Oui. Définissez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) pour des portions individuelles, de sorte qu'un paragraphe puisse contenir du texte dans plusieurs langues.