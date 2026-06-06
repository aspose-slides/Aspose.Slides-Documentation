---
title: Gérer les listes à puces et numérotées dans les présentations en Java
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/java/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter une puce
- ajouter une liste
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et mettre en forme des listes à puces, à images, à plusieurs niveaux et numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java vous permet de créer et de mettre en forme des listes à puces et numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la méthode [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/#getParagraphFormat--) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d’entrée principal est [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getBullet--), qui renvoie un objet [IBulletFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l’image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- inspecter et modifier le formatage de liste dans une présentation existante

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) à un [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) et définissez [IBulletFormat.setType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setType-byte-) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/java/com.aspose.slides/bullettype/#Symbol). Vous pouvez ensuite définir [IBulletFormat.setChar](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#getColor--) et [IBulletFormat.setHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setHeight-float-) pour contrôler l’apparence de la puce.

Le code Java suivant montre comment créer une liste à puces dans une diapositive :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces symboliques](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez les listes numérotées lorsque l’ordre des éléments est important. Définissez [IBulletFormat.setType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setType-byte-) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/java/com.aspose.slides/bullettype/#Numbered). Vous pouvez également choisir un format de numérotation avec [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ou définir [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) lorsque la liste doit commencer à une valeur autre que 1.

Le code Java suivant montre comment créer une liste numérotée dans une diapositive :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce classique par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="primary" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphique simple avec un fond transparent. Ce type d’image convient bien comme symbole de puce personnalisé.

Gardez à l’esprit que l’image sera réduite à une taille très petite. Pour cette raison, nous vous recommandons fortement de choisir une image qui reste nette et visuellement efficace lorsqu’elle est utilisée comme puce dans une liste.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation.getImages](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getImages--) et affectez l’objet image retourné à [IBulletFormat.getPicture](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#getPicture--). Définissez [IBulletFormat.setType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setType-byte-) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/java/com.aspose.slides/bullettype/#Picture) avant d’affecter l’image.

Supposons que nous ayons une "image.png" :

![Une image pour les puces](picture_for_bullets.png)

Le code Java suivant montre comment créer des puces image dans une diapositive :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setDepth-short-) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, etc.

Le code Java suivant montre comment créer une liste à puces à plusieurs niveaux :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le formatage d’une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getBullet--). Les mêmes propriétés utilisées pour créer des listes peuvent être utilisées pour inspecter ou modifier des listes chargées depuis un fichier PPT, PPTX ou ODP.

Le code Java suivant modifie le premier paragraphe d’un cadre de texte pour utiliser un style de liste numérotée :

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Les listes à puces et numérotées peuvent-elles être exportées vers PDF ou images ?**

Oui. Aspose.Slides conserve le formatage des listes lorsque le format cible prend en charge la mise en page du texte et les fonctionnalités de puces correspondantes.

**Puis-je modifier les listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe cible, inspectez ou mettez à jour ses paramètres [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getBullet--), puis enregistrez la présentation.

**Les listes peuvent-elles contenir du texte non latin ?**

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, vous permettant de créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères nécessaires.