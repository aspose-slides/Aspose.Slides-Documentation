---
title: Gérer les Paragraphes PowerPoint
type: docs
weight: 40
url: /php-java/manage-paragraph/
keywords: "Ajouter un paragraphe PowerPoint, Gérer les paragraphes, Retrait de paragraphe, Propriétés de paragraphe, Texte HTML, Exporter le texte du paragraphe, Présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Créer et gérer des Paragraphes, du texte, des retraits et des propriétés dans des présentations PowerPoint"
---

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec les textes, paragraphes et portions PowerPoint.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) pour vous permettre d'ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut avoir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) pour vous permettre d'ajouter des objets représentant des portions. Un objet `IParagraph` peut avoir une ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) pour vous permettre d'ajouter des objets représentant des textes et leurs propriétés de formatage.

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage à travers ses objets `IPortion` sous-jacents.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une forme rectangle [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé à l'[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le Paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection de IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez vos caractéristiques de formatage préférées à chaque portion en utilisant les propriétés de formatage exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code PHP est une implémentation des étapes pour ajouter des paragraphes contenant des portions :

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une forme AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Accéder au TextFrame de l'AutoShape
    $tf = $ashp->getTextFrame();
    # Créer des Paragraphes et des Portions avec différents formats de texte
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
    # Écrire le PPTX sur le disque
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gérer les Puces de Paragraphe**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Définissez le `Type` de puce pour le paragraphe sur `Symbol` et définissez le caractère de puce.
8. Définissez le `Texte` du paragraphe.
9. Définissez le `Retrait` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus donné dans les étapes 7 à 13.
14. Enregistrez la présentation.

Ce code PHP vous montre comment ajouter une puce de paragraphe :

```php
  # Instancie une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute et accède à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre de texte de l'autoshape
    $txtFrm = $aShp->getTextFrame();
    # Supprime le paragraphe par défaut
    $txtFrm->getParagraphs()->removeAt(0);
    # Crée un paragraphe
    $para = new Paragraph();
    # Définit un style et un symbole de puce pour le paragraphe
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Définit un texte de paragraphe
    $para->setText("Bienvenue dans Aspose.Slides");
    # Définit le retrait de la puce
    $para->getParagraphFormat()->setIndent(25);
    # Définit la couleur de la puce
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// définir IsBulletHardColor sur true pour utiliser la couleur de puce personnalisée

    # Définit la Hauteur de la Puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le Paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para);
    # Crée le deuxième paragraphe
    $para2 = new Paragraph();
    # Définit le type et le style de puce du paragraphe
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Ajoute le texte du paragraphe
    $para2->setText("Ceci est une puce numérotée");
    # Définit le retrait de la puce
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// définir IsBulletHardColor sur true pour utiliser la couleur de puce personnalisée

    # Définit la Hauteur de la Puce
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le Paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para2);
    # Sauvegarde la présentation modifiée
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gérer les Puces d'Image**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les paragraphes à image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) et définissez l'image.
9. Définissez le `Texte` du paragraphe.
10. Définissez le `Retrait` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter et gérer des puces d'image :

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
    # Accède au textframe de l'autoshape
    $textFrame = $autoShape->getTextFrame();
    # Supprime le paragraphe par défaut
    $textFrame->getParagraphs()->removeAt(0);
    # Crée un nouveau paragraphe
    $paragraph = new Paragraph();
    $paragraph->setText("Bienvenue dans Aspose.Slides");
    # Définit le style et l'image de la puce du paragraphe
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Définit la Hauteur de la Puce
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au cadre de texte
    $textFrame->getParagraphs()->add($paragraph);
    # Écrit la présentation sous forme de fichier PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Écrit la présentation sous forme de fichier PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Gérer les Puces Multiniveaux**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe à l'aide de la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe à l'aide de la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe à l'aide de la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter et gérer des puces multiniveaux :

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
    # Efface le paragraphe par défaut
    $text->getParagraphs()->clear();
    # Ajoute le premier paragraphe
    $para1 = new Paragraph();
    $para1->setText("Contenu");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para1->getParagraphFormat()->setDepth(0);
    # Ajoute le deuxième paragraphe
    $para2 = new Paragraph();
    $para2->setText("Deuxième Niveau");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para2->getParagraphFormat()->setDepth(1);
    # Ajoute le troisième paragraphe
    $para3 = new Paragraph();
    $para3->setText("Troisième Niveau");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para3->getParagraphFormat()->setDepth(2);
    # Ajoute le quatrième paragraphe
    $para4 = new Paragraph();
    $para4->setText("Quatrième Niveau");
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
    # Écrit la présentation sous forme de fichier PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gérer les Paragraphes avec une Liste Numérotée Personnalisée**

L'interface [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) et d'autres qui vous permettent de gérer les paragraphes avec une numérotation ou un formatage personnalisés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) sur 2.
7. Créez la deuxième instance de paragraphe à l'aide de la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 3.
8. Créez la troisième instance de paragraphe à l'aide de la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisés :

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre de texte de l'AutoShape créé
    $textFrame = $shape->getTextFrame();
    # Supprime le paragraphe existant par défaut
    $textFrame->getParagraphs()->removeAt(0);
    # Première liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("puce 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("puce 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("puce 7");
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


## **Définir le Retrait de Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Accédez à la référence de la diapositive pertinente via son index.
1. Ajoutez une forme rectangle [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) avec trois paragraphes à la forme rectangle.
1. Masquez les lignes du rectangle.
1. Définissez le retrait pour chaque [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) via leur propriété BulletOffset.
1. Écrivez la présentation modifiée sous forme de fichier PPT.

Ce code PHP vous montre comment définir un retrait de paragraphe :

```php
  # Instancier la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une forme Rectangle
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Ajouter un TextFrame au Rectangle
    $tf = $rect->addTextFrame("Ceci est la première ligne \rCeci est la deuxième ligne \rCeci est la troisième ligne");
    # Configurez le texte pour qu'il s'adapte à la forme
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Masquez les lignes du Rectangle
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Obtenir le premier paragraphe dans le TextFrame et définir son Retrait
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Définir le style de la puce du paragraphe et le symbole
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Obtenir le deuxième paragraphe dans le TextFrame et définir son Retrait
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Obtenir le troisième paragraphe dans le TextFrame et définir son Retrait
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Écrire la présentation sur le disque
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir un Retrait Suspendu pour le Paragraphe**

Ce code PHP vous montre comment définir le retrait suspendu pour un paragraphe :

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Exemple");
    $para2 = new Paragraph();
    $para2->setText("Définir le Retrait Suspendu pour le Paragraphe");
    $para3 = new Paragraph();
    $para3->setText("Ce code C# vous montre comment définir le retrait suspendu pour un paragraphe : ");
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

## **Gérer les Propriétés de Fin de Paragraphes pour le Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence pour la diapositive contenant le paragraphe via sa position.
1. Ajoutez une [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) rectangle à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) avec deux paragraphes dans le rectangle.
1. Définissez la `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de Fin pour les paragraphes.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code PHP vous montre comment définir les propriétés de Fin pour les paragraphes dans PowerPoint :

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Texte d'exemple"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Texte d'exemple 2"));
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


## **Importer du Texte HTML dans les Paragraphes**

Aspose.Slides fournit un support amélioré pour importer du texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à l'autoshape [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
5. Supprimez le paragraphe par défaut dans l'[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML dans le TextReader lu à la [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) du TextFrame.
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
    # Effacer tous les paragraphes dans le cadre de texte ajouté
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Charger le fichier HTML à l'aide du lecteur de flux
    $tr = new StreamReader("file.html");
    # Ajouter le texte du lecteur de flux HTML dans le cadre de texte
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Enregistrer la Présentation
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exporter le Texte des Paragraphes en HTML**

Aspose.Slides fournit un support amélioré pour exporter des textes (contenus dans les paragraphes) en HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive pertinente via son index.
3. Accédez à la forme contenant le texte qui sera exporté en HTML.
4. Accédez à la [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ au StreamWriter et exportez vos paragraphes préférés.

Ce code PHP vous montre comment exporter les textes des paragraphes PowerPoint en HTML :

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
    # Création du fichier HTML de sortie
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraire le premier paragraphe en tant que HTML
    # Écrire les données des Paragraphes en HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```