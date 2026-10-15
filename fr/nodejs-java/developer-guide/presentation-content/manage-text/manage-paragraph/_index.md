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
- importer HTML
- texte en HTML
- paragraphe en HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java représente le texte comme une hiérarchie de cadres de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) représente le conteneur de texte dans une forme et fournit l'accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l'accès à ses portions et à la mise en forme au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) représente un fragment de texte au sein d'un paragraphe. Chaque portion peut avoir son propre texte et une mise en forme au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres mises en forme en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

Créez des paragraphes dans le cadre de texte d’une forme et utilisez des portions pour formater des fragments de texte individuels. Cette section montre comment combiner plusieurs portions au sein de chaque paragraphe et appliquer différentes couleurs, tailles de police et styles.

### **Créer des paragraphes avec plusieurs portions**

L’exemple JavaScript suivant crée trois paragraphes, chacun contenant trois fragments de texte dans la collection retournée par [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/). Il réutilise le paragraphe par défaut et sa portion vide, puis ajoute les paragraphes et les portions restants. La mise en forme est appliquée via [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) : la première portion de chaque paragraphe est rouge, en gras et de 15 points ; la deuxième est bleue, en italique et de 18 points. La troisième portion conserve sa mise en forme par défaut :

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

Organisez le texte des paragraphes en listes avec des symboles, des chiffres ou des images personnalisées. Les exemples de cette section couvrent la mise en forme des puces, les listes à plusieurs niveaux et les numéros de départ personnalisés.

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments associés. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

Cet exemple JavaScript ajoute une puce symbole et un élément numéroté au même cadre de texte. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) sélectionne le type de puce, tandis que [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) fournit le symbole et [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) choisit le style de numérotation. Les deux éléments utilisent des puces noires avec une hauteur de 100 % et un retrait de paragraphe de 25 points :

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

Les puces image vous permettent d’utiliser une image personnalisée à la place d’un symbole ou d’un chiffre.

Cet exemple JavaScript charge `image.png` depuis le répertoire de travail de l’application, ajoute l’image à la collection d’images de la présentation comme un [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) et l’utilise comme puce de paragraphe. Il appelle [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) pour utiliser une puce image et assigne l’image via [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/). [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) est fixé à 100 % pour dimensionner la puce par rapport au texte du paragraphe :

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

Définissez [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

Cet exemple JavaScript affecte des valeurs de [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) de 0 à 3 à quatre paragraphes, créant une hiérarchie au sein d’un même cadre de texte. Chaque paragraphe utilise une puce symbole, avec [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) alternant entre une puce ronde et un tiret pour distinguer les niveaux adjacents :

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

### **Définir des valeurs de départ personnalisées pour les listes numérotées**

Utilisez [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) pour définir le numéro initial affiché pour un paragraphe numéroté.

Cet exemple JavaScript définit [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) pour utiliser la numérotation pour trois paragraphes et attribue des valeurs de [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) de 2, 3 et 7. La valeur de départ est configurée séparément pour chaque paragraphe, ce qui permet aux numéros affichés de sauter des valeurs :

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

## **Contrôler la disposition du paragraphe et les propriétés de fin**

Ajustez les marges et les retraits des paragraphes pour contrôler la position de la première ligne et des lignes renvoyées. Vous pouvez également formater le marqueur de fin du paragraphe séparément du texte visible.

### **Définir un retrait de première ligne**

Utilisez la méthode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) pour contrôler le retrait de première ligne d’un paragraphe. Ce paramètre ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées sur le corps du paragraphe.

Utilisez [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) lorsque vous ne devez déplacer que la première ligne.

L’exemple suivant donne à trois paragraphes la même [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) de 20 points et des valeurs de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) de 0, 20 et 40 points. Les premières lignes commencent à des décalages progressivement plus grands, tandis que les lignes renvoyées conservent la même marge gauche :

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

Le résultat :

![L'indentation de la première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une disposition de paragraphe dans laquelle la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la méthode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Fixez le retrait à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) définit la position gauche du corps du paragraphe, et [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une marge gauche positive et un retrait négatif.

Cette mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

L’exemple JavaScript suivant associe des valeurs de [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) de 40 et 60 points à des valeurs de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) de -20 et -30 points. Dans chaque paragraphe, la première ligne commence à gauche des lignes renvoyées ; le deuxième paragraphe possède un retrait suspendu plus prononcé :

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

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin du paragraphe**

La méthode [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) contrôle la mise en forme du marqueur de fin du paragraphe. L’exemple suivant crée un [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) dont [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) est fixé à 48 points et [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) à Times New Roman. Il affecte ce format au marqueur de fin du deuxième paragraphe, laissant les portions de texte visibles inchangées :

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

## **Compter les lignes rendues**

Pour les règles de paragraphe qui affectent le renvoi automatique à la ligne et la ponctuation en fin de ligne, voir [Control Line Breaking](/slides/fr/nodejs-java/text-formatting/#control-line-breaking) et [Control Hanging Punctuation](/slides/fr/nodejs-java/text-formatting/#control-hanging-punctuation).

Utilisez [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) pour compter les lignes occupées par un paragraphe après la mise en page du texte, y compris le renvoi automatique. Cela est utile lors de la vérification de la longueur du texte et de la mise en page dans les modèles de présentation.

Un paragraphe est un élément de [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/), et il peut occuper plusieurs lignes rendues. Un saut de ligne explicite au sein d’un paragraphe force une nouvelle ligne sans créer un autre paragraphe. Le renvoi automatique crée des lignes en fonction de la largeur disponible sans insérer de sauts de ligne explicites dans le texte. Ainsi, compter les paragraphes ou les caractères de saut de ligne ne donne pas le nombre réel de lignes rendues.

L’exemple suivant crée une forme de texte, compte ses lignes, rétrécit la forme, puis remplace le texte par une chaîne plus courte. L’exemple active le renvoi avec [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) et désactive l’ajustement automatique avec [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) afin que la largeur de la forme contrôle le renvoi sans réduire automatiquement le texte ni redimensionner la forme. Chaque mesure utilise [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount). Les dimensions de la forme sont exprimées en points. Enfin, l’exemple ajoute un autre paragraphe et additionne les comptes de lignes à travers le cadre de texte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Avec ce texte et ces dimensions, rétrécir la forme augmente le nombre de lignes, tandis que remplacer le texte par la chaîne courte le réduit. Les comptes exacts peuvent varier en fonction de la disponibilité des polices et des substitutions, de la taille de la police, des marges, des retraits, du renvoi et des paramètres d’ajustement automatique. Utilisez les polices et les paramètres de mise en page prévus pour l’environnement cible lors de la vérification d’un modèle.

Le simple nombre de lignes ne détermine pas si le texte dépasse son conteneur. La hauteur disponible, les hauteurs de ligne, les espacements de paragraphe et de ligne, et le comportement d’ajustement automatique sont également importants ; même une seule ligne peut excéder la largeur disponible lorsque le renvoi est désactivé.

## **Importer et exporter le contenu des paragraphes**

Utilisez HTML pour importer du texte dans une présentation ou exporter des paragraphes existants afin de les réutiliser ailleurs. Cette section montre également comment rendre des paragraphes individuels en images, y compris les paragraphes dans les cellules de tableau.

### **Importer du texte HTML dans des paragraphes**

Utilisez [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

Cet exemple JavaScript lit le fichier HTML `file.html` depuis le répertoire de travail de l’application et transmet le balisage à [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/). Il vide le paragraphe par défaut du cadre de texte afin que le cadre ne contienne que le contenu importé. La forme rectangulaire laisse une marge de 10 points de chaque côté de la diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Exporter le texte d’un paragraphe en HTML**

Utilisez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) pour exporter une plage sélectionnée de paragraphes au format HTML. Lors de la réutilisation du texte d’une présentation sur un site Web, vous pouvez souhaiter conserver les mises en emphase locales sans transférer les styles de police, de taille ou de zone de texte de la présentation. Réglez [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) pour contrôler jusqu’où l’exportateur suit l’héritage de mise en forme.

Téléchargez [la présentation d’exemple](text-inheritance.pptx) et placez‑la dans le répertoire de travail de l’application. Sa première diapositive contient une forme de texte avec le texte « Inherited text; explicit red 18pt ». L’entrée utilise délibérément plusieurs niveaux de mise en forme :

- Le style de texte par défaut de la présentation fournit Calibri et une taille de 28 pt.
- Le style de texte de premier niveau du cadre de texte fournit du texte bleu et italique.
- Le paragraphe définit explicitement le texte en gras.
- La deuxième portion, « explicit red 18pt », définit explicitement le texte rouge et une taille de 18 pt.

L’exemple complet suivant exporte les mêmes paragraphes trois fois. Il transmet un [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) à la méthode d’export et écrit chaque résultat dans un fichier HTML UTF‑8 distinct :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
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

Le HTML généré contient le CSS suivant pour la première portion, « Inherited text; ». Le tableau répertorie les déclarations pertinentes ; les autres propriétés générées sont omises pour plus de clarté.

| Sortie | CSS pertinent pour la première portion | Apparence |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique à 28 pt en Calibri, si cette police est disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique ; la page ou le navigateur fournit la famille de police et la taille. |
| `ParagraphOnly.html` | `font-weight:bold` | Texte gras ; la page ou le navigateur fournit la famille de police, la taille, la couleur et le style italique. |

La deuxième portion conserve `color:#ff0000`, `font-size:18pt` et `font-weight:bold` dans les trois sorties. Elle conserve également l’italique dans `All` et `TextBox`, mais pas dans `ParagraphOnly`. Restreindre l’héritage ne supprime donc pas la mise en forme assignée explicitement à un paragraphe ou à une portion.

Ouvrez les fichiers dans le même navigateur pour les comparer. Dans les deux modes restreints, les propriétés CSS omises sont résolues par les styles de la page cible ou les valeurs par défaut du navigateur, de sorte que l’apparence finale dépend de l’endroit où le HTML est utilisé.

### **Rendre un paragraphe en image**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Vous n’avez pas besoin de rendre la forme contenant le paragraphe ni de recadrer manuellement un bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) peut renvoyer `null` si le paragraphe n’est pas trouvé dans sa collection parente, n’a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

L’exemple crée une présentation contenant une diapositive dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte contenant trois paragraphes](paragraph_to_image_input.png)

L’exemple suivant sélectionne le deuxième paragraphe à l’index 1 et appelle [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) sans paramètres d’échelle. Il vérifie que la forme contient le paragraphe requis et que le rendu renvoie une image avant d’appeler [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) pour l’enregistrer au format PNG. Le bloc `finally` libère l’image après utilisation.

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

Le résultat :

![L’image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) qui accepte les paramètres `scaleX` et `scaleY` pour définir les facteurs d’échelle horizontaux et verticaux. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat sous forme d’image PNG.

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

Un facteur d’échelle de `1` conserve cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement le double des dimensions par défaut, ce qui donne quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou les rendus haute résolution, mais augmentent également la consommation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le rapport d’aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) reste utile lorsque la sortie doit inclure le remplissage, le contour ou tout autre contexte visuel de la forme. Pour une image ne contenant que le paragraphe, utilisez [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Puis‑je désactiver complètement le renvoi à la ligne dans un cadre de texte ?**

Oui. Réglez [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) pour désactiver le renvoi afin que les lignes ne se cassent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Utilisez [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) pour récupérer le rectangle englobant du paragraphe. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) fournit les limites d’une portion individuelle.

**Où la justification du paragraphe (gauche, droite, centre ou justifiée) est‑elle contrôlée ?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) est un paramètre au niveau du paragraphe et s’applique à l’ensemble du paragraphe, quel que soit le formatage des portions individuelles.

Pour aligner verticalement des portions de tailles de police différentes au sein de chaque ligne, voir [Align Fonts Within a Line](/slides/fr/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Puis‑je définir la langue de vérification orthographique pour une partie d’un paragraphe ?**

Oui. Réglez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) pour les portions individuelles, de sorte qu’un paragraphe puisse contenir du texte dans plusieurs langues.