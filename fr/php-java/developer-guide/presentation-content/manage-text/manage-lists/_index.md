---
title: Gérer les listes à puces et numérotées dans les présentations avec PHP
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/php-java/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer puce
- ajouter puce
- ajouter liste
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et formater des listes à puces, à puces image, à plusieurs niveaux et numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java."
---
## **Aperçu**

Aspose.Slides for PHP via Java vous permet de créer et de formater des listes à puces et numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la méthode [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#getParagraphFormat--) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d'entrée principal est [ParagraphFormat.getBullet](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getBullet--) qui renvoie un objet [BulletFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l'image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- inspecter et modifier le formatage des listes dans une présentation existante

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) à un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) et définissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setType-int-) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/#Symbol). Vous pouvez ensuite définir [BulletFormat.setChar](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#getColor--) et [BulletFormat.setHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setHeight-float-) pour contrôler l'apparence de la puce.

Le code PHP suivant montre comment créer une liste à puces dans une diapositive :
```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :
![Les puces symboliques](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez les listes numérotées lorsque l'ordre des éléments est important. Définissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setType-int-) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/#Numbered). Vous pouvez également choisir un format de numérotation avec [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) ou définir [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) lorsque la liste doit commencer à une valeur autre que 1.

Le code PHP suivant montre comment créer une liste numérotée dans une diapositive :
```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :
![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce classique par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="primary" %}}
Idéalement, si vous envisagez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphique simple avec un arrière-plan transparent. Ce type d'images fonctionne bien comme symboles de puce personnalisés.

Gardez à l'esprit que l'image sera réduite à une taille très petite. Pour cette raison, nous vous recommandons vivement de choisir une image qui reste claire et visuellement efficace lorsqu'elle est utilisée comme puce dans une liste.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation.getImages](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getImages--) et assignez l'objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) retourné à [BulletFormat.getPicture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#getPicture--). Définissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setType-int-) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/#Picture) avant d'assigner l'image.

Disons que nous disposons d'un "image.png" :

![Une image pour les puces](picture_for_bullets.png)

Le code PHP suivant montre comment créer des puces image dans une diapositive :
```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :
![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setDepth-short-) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, et ainsi de suite.

Le code PHP suivant montre comment créer une liste à puces à plusieurs niveaux :
```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :
![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le formatage d'une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres [ParagraphFormat.getBullet](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getBullet--). Les mêmes propriétés utilisées pour créer des listes peuvent être employées pour inspecter ou modifier des listes chargées à partir d'un fichier PPT, PPTX ou ODP.

Le code PHP suivant modifie le premier paragraphe d'un cadre de texte pour qu'il utilise un style de liste numérotée :
```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Les listes à puces et numérotées peuvent-elles être exportées vers PDF ou images ?**

Oui. Aspose.Slides conserve le formatage des listes lorsque le format cible prend en charge la mise en page du texte et les fonctionnalités de puces correspondantes.

**Puis-je modifier les listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe cible, inspectez ou mettez à jour ses paramètres [ParagraphFormat.getBullet](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getBullet--), puis enregistrez la présentation.

**Les listes peuvent-elles contenir du texte non latin ?**

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, vous pouvez donc créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères dont vous avez besoin.