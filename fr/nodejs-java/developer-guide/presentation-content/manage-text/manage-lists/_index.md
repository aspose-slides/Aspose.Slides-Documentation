---
title: Gérer les listes à puces et numérotées dans les présentations avec JavaScript
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/nodejs-java/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter puce
- ajouter liste
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à créer et à mettre en forme des listes à puces, image, à plusieurs niveaux et numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Node.js via Java."
---
## **Aperçu**

Aspose.Slides for Node.js via Java vous permet de créer et de formater des listes à puces et numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d’entrée principal est `Paragraph.getParagraphFormat().getBullet()`, qui renvoie un objet [BulletFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l’image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- inspecter et modifier le format d’une liste dans une présentation existante

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) à un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) et définissez `BulletFormat.setType` sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bullettype/). Vous pouvez ensuite régler `BulletFormat.setChar`, `BulletFormat.getColor` et `BulletFormat.setHeight` pour contrôler l’apparence de la puce.

Le code JavaScript suivant montre comment créer une liste à puces dans une diapositive :

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces symboles](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez des listes numérotées lorsque l’ordre des éléments est important. Définissez `BulletFormat.setType` sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bullettype/). Vous pouvez également choisir un format de numérotation avec `BulletFormat.setNumberedBulletStyle` ou définir `BulletFormat.setNumberedBulletStartWith` lorsque la liste doit commencer à une valeur différente de 1.

Le code JavaScript suivant montre comment créer une liste numérotée dans une diapositive :

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce standard par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="primary" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, choisissez un graphique simple avec un arrière‑plan transparent. Ce type d’image fonctionne bien comme symbole de puce personnalisé.

Gardez à l’esprit que l’image sera réduite à une taille très petite. Pour cette raison, nous vous recommandons fortement de sélectionner une image qui reste claire et visuellement efficace lorsqu’elle est utilisée comme puce dans une liste.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) avec `Presentation.getImages().addImage` et affectez l’objet [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) retourné à `BulletFormat.getPicture().setImage`. Définissez `BulletFormat.setType` sur [BulletType.Picture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bullettype/) avant d’assigner l’image.

Imaginons que nous ayons une « image.png » :

![Une image pour les puces](picture_for_bullets.png)

Le code JavaScript suivant montre comment créer des puces image dans une diapositive :

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Le résultat :

![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez `ParagraphFormat.setDepth` pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, etc.

Le code JavaScript suivant montre comment créer une liste à puces à plusieurs niveaux :

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le format d’une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres `ParagraphFormat.getBullet`. Les mêmes propriétés utilisées pour créer des listes peuvent être utilisées pour inspecter ou modifier des listes chargées depuis un fichier PPT, PPTX ou ODP.

Le code JavaScript suivant modifie le premier paragraphe d’un cadre de texte pour qu’il utilise un style de liste numérotée :

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Les listes à puces et numérotées peuvent‑elles être exportées vers PDF ou images ?**

Oui. Aspose.Slides conserve le formatage des listes lorsque le format cible prend en charge la mise en page du texte et les fonctionnalités de puces correspondantes.

**Puis‑je modifier les listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe cible, inspectez ou mettez à jour ses paramètres `ParagraphFormat.getBullet`, puis enregistrez la présentation.

**Les listes peuvent‑elles contenir du texte non latin ?**

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, vous permettant de créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères dont vous avez besoin.