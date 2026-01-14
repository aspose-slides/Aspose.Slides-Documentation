---
title: Gérer les paragraphes de texte PowerPoint en PHP
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/php-java/manage-paragraph/
keywords:
- ajouter texte
- ajouter paragraphe
- gérer texte
- gérer paragraphe
- gérer puce
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
- exporter paragraphe
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Maîtrisez la mise en forme des paragraphes avec Aspose.Slides pour PHP via Java — optimisez l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP."
---

Aspose.Slides fournit toutes les classes dont vous avez besoin pour travailler avec les textes, les paragraphes et les portions PowerPoint.

* Aspose.Slides fournit la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) permettant d’ajouter des objets représentant un paragraphe. Un objet `TextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) permettant d’ajouter des objets représentant des portions. Un objet `Paragraph` peut contenir une ou plusieurs portions (collection d’objets de portion).
* Aspose.Slides fournit la classe [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) permettant d’ajouter des objets représentant des textes et leurs propriétés de mise en forme.

Un objet `Paragraph` peut gérer des textes avec différentes propriétés de mise en forme grâce à ses objets sous-jacents `Portion`.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape] rectangulaire https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/ à la diapositive.
4. Obtenez le ITextFrame associé à la [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Créez deux objets [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) et ajoutez-les à la collection de paragraphes du [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Créez trois objets [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) pour chaque nouveau `Paragraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `Portion` à la collection de portions de chaque `Paragraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez vos fonctions de mise en forme préférées à chaque portion en utilisant les propriétés de mise en forme exposées par l’objet `Portion`.
9. Enregistrez la présentation modifiée.

Ce code PHP est une implémentation des étapes pour ajouter des paragraphes contenant des portions :
```php
# Instancier une classe Presentation qui représente un fichier PPTX
$pres = new Presentation();
try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter un AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Accéder au TextFrame de l'AutoShape
    $tf = $ashp->getTextFrame();
    # Créer des Paragraphs et Portions avec différents formats de texte
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Enregistrer le PPTX sur le disque
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Définissez le type de puce `Type` du paragraphe sur `Symbol` et définissez le caractère de puce.
8. Définissez le texte du paragraphe.
9. Définissez l’indentation `Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code PHP montre comment ajouter une puce de paragraphe :
```php
# Instancie une classe Presentation qui représente un fichier PPTX
$pres = new Presentation();
try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute et accède à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre de texte de l'AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Supprime le paragraphe par défaut
    $txtFrm->getParagraphs()->removeAt(0);
    # Crée un paragraphe
    $para = new Paragraph();
    # Définit le style de puce du paragraphe et le symbole
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Définit le texte du paragraphe
    $para->setText("Welcome to Aspose.Slides");
    # Définit le retrait de la puce
    $para->getParagraphFormat()->setIndent(25);
    # Définit la couleur de la puce
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// définir IsBulletHardColor à true pour utiliser sa propre couleur de puce

    # Définit la hauteur de la puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para);
    # Crée le deuxième paragraphe
    $para2 = new Paragraph();
    # Définit le type et le style de puce du paragraphe
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Ajoute le texte du paragraphe
    $para2->setText("This is numbered bullet");
    # Définit le retrait de la puce
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// définir IsBulletHardColor à true pour utiliser sa propre couleur de puce

    # Définit la hauteur de la puce
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para2);
    # Enregistre la présentation modifiée
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Gérer les puces d’image**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes avec image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Chargez l’image dans [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) et définissez l’image.
9. Définissez le texte du paragraphe.
10. Définissez l’indentation `Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code PHP montre comment ajouter et gérer les puces d’image :
```php
# Instancie une classe Presentation qui représente un fichier PPTX
$presentation = new Presentation();
try {
    # Accède à la première diapositive
    $slide = $presentation->getSlides()->get_Item(0);
    # Instancie l'image pour les puces
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Ajoute et accède à l'AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au TextFrame de l'AutoShape
    $textFrame = $autoShape->getTextFrame();
    # Supprime le paragraphe par défaut
    $textFrame->getParagraphs()->removeAt(0);
    # Crée un nouveau paragraphe
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Définit le style de puce du paragraphe et l'image
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Définit la hauteur de la puce
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au TextFrame
    $textFrame->getParagraphs()->add($paragraph);
    # Enregistre la présentation en fichier PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Enregistre la présentation en fichier PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **Gérer les puces à plusieurs niveaux**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code PHP montre comment ajouter et gérer les puces à plusieurs niveaux :
```php
# Instancie une classe Presentation qui représente un fichier PPTX
$pres = new Presentation();
try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute et accède à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre de texte de l'AutoShape créé
    $text = $aShp->addTextFrame("");
    # Vide le paragraphe par défaut
    $text->getParagraphs()->clear();
    # Ajoute le premier paragraphe
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para1->getParagraphFormat()->setDepth(0);
    # Ajoute le deuxième paragraphe
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para2->getParagraphFormat()->setDepth(1);
    # Ajoute le troisième paragraphe
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para3->getParagraphFormat()->setDepth(2);
    # Ajoute le quatrième paragraphe
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para4->getParagraphFormat()->setDepth(3);
    # Ajoute les paragraphes à la collection
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Enregistre la présentation sous forme de fichier PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Gérer un paragraphe avec une liste numérotée personnalisée**

La classe [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) fournit la méthode [setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) et d’autres qui permettent de gérer les paragraphes avec une numérotation ou une mise en forme personnalisée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code PHP montre comment ajouter et gérer des paragraphes avec une numérotation ou une mise en forme personnalisée :
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre de texte de l'AutoShape créée
    $textFrame = $shape->getTextFrame();
    # Supprime le paragraphe existant par défaut
    $textFrame->getParagraphs()->removeAt(0);
    # Première liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **Définir l’indent du paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Accédez à la référence de la diapositive concernée via son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) avec trois paragraphes à l’autoshape rectangulaire.
1. Masquez les lignes du rectangle.
1. Définissez l’indent pour chaque [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) via leur propriété BulletOffset.
1. Enregistrez la présentation modifiée au format PPT.

Ce code PHP montre comment définir un indent de paragraphe :
```php
# Instancie la classe Presentation
$pres = new Presentation();
try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une forme Rectangle
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Ajoute un TextFrame au rectangle
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # Définit le texte pour qu'il s'adapte à la forme
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Masque les lignes du rectangle
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Récupère le premier paragraphe du TextFrame et définit son retrait
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Définit le style de puce du paragraphe et le symbole
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Récupère le deuxième paragraphe du TextFrame et définit son retrait
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Récupère le troisième paragraphe du TextFrame et définit son retrait
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Enregistre la présentation sur le disque
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Définir un retrait suspendu pour un paragraphe**

Ce code PHP montre comment définir le retrait suspendu pour un paragraphe :
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Gérer les propriétés de fin de paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) avec deux paragraphes au rectangle.
1. Définissez la hauteur de police et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code PHP montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint :
```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Importer du texte HTML dans des paragraphes**

Aspose.Slides fournit un support amélioré pour l’importation de texte HTML dans les paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez et accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de l’AutoShape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code PHP est une implémentation des étapes pour importer des textes HTML dans des paragraphes :
```php
# Créer une instance de présentation vide
$pres = new Presentation();
try {
    # Accéder à la première diapositive par défaut de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter l'AutoShape pour accueillir le contenu HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Ajouter un cadre de texte à la forme
    $ashape->addTextFrame("");
    # Effacer tous les paragraphes du cadre de texte ajouté
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Charger le fichier HTML à l'aide d'un lecteur de flux
    $tr = new StreamReader("file.html");
    # Ajouter le texte du lecteur de flux HTML dans le cadre de texte
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Enregistrer la présentation
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Exporter le texte d’un paragraphe vers HTML**

Aspose.Slides fournit un support amélioré pour l’exportation de textes (contenus dans les paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée via son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un indice de départ à StreamWriter et exportez vos paragraphes préférés.

Ce code PHP montre comment exporter les textes de paragraphes PowerPoint vers HTML :
```php
# Charger le fichier de présentation
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Accéder à la première diapositive par défaut de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Index souhaité
    $index = 0;
    # Accéder à la forme ajoutée
    $ashape = $slide->getShapes()->get_Item($index);
    # Créer le fichier HTML de sortie
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraire le premier paragraphe en HTML
    # Écrire les données des paragraphes en HTML en indiquant l'index de départ du paragraphe et le nombre total de paragraphes à copier
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Enregistrer un paragraphe en tant qu’image**

Dans cette section, nous explorerons deux exemples qui montrent comment enregistrer un paragraphe de texte, représenté par la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/), sous forme d’image. Les deux exemples comprennent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `getImage` de la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), le calcul des limites du paragraphe au sein de la forme, puis l’exportation sous forme d’image bitmap. Ces approches permettent d’extraire des parties spécifiques du texte d’une présentation PowerPoint et de les enregistrer comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous disposions d’un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis nous calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique en tant qu’image distincte tout en conservant les dimensions et la mise en forme exactes du texte.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Enregistrer la forme en mémoire sous forme de bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Créer un bitmap de forme à partir de la mémoire.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calculer les limites du deuxième paragraphe.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recadrer le bitmap de forme pour obtenir uniquement le bitmap du paragraphe.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


Le résultat :

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée sous forme d’image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à plus haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des supports imprimés de haute qualité.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Enregistrer la forme en mémoire sous forme de bitmap avec mise à l'échelle.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Créer un bitmap de forme à partir de la mémoire.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calculer les limites du deuxième paragraphe.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recadrer le bitmap de forme pour obtenir uniquement le bitmap du paragraphe.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne à l’intérieur d’un cadre de texte ?**

Oui. Utilisez le paramètre de retour à la ligne du cadre de texte ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une portion unique) pour connaître sa position et sa taille précises sur la diapositive.

**Où la mise en forme d’alignement du paragraphe (gauche/droite/centré/justifié) est‑elle contrôlée ?**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); il s’applique à tout le paragraphe quel que soit le format individuel des portions.

**Puis‑je définir une langue de vérification orthographique pour seulement une partie du paragraphe (par ex., un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)), de sorte que plusieurs langues peuvent coexister dans un même paragraphe.