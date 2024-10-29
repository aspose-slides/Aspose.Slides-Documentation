---
title: Gérer les Puces
type: docs
weight: 60
url: /fr/php-java/manage-bullet/
keywords: "Puces, Listes à puces, Nombres, Listes numérotées, Puces d'image, puces multilevel, Présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Créer des listes à puces et des listes numérotées dans une présentation PowerPoint"
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et des listes numérotées de la même manière que dans Word et d'autres éditeurs de texte. **Aspose.Slides pour PHP via Java** vous permet également d'utiliser des puces et des numéros dans les diapositives de vos présentations.

## Pourquoi utiliser des listes à puces ?

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement.

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l'attention de vos lecteurs ou spectateurs sur des informations importantes
- permet à vos lecteurs ou spectateurs de rechercher facilement des points clés
- communique et transmet efficacement des détails importants.

## Pourquoi utiliser des listes numérotées ?

Les listes numérotées aident également à organiser et à présenter des informations. Idéalement, vous devriez utiliser des numéros (à la place des puces) lorsque l'ordre des entrées (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu'une entrée doit être référencée (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Création de Puces** ci-dessous :

1. Créez une instance de la classe de présentation.
2. Effectuez plusieurs tâches (étape 3 à étape 14).
3. Enregistrez la présentation.

## Création de Puces
Ce sujet fait également partie de la série de sujets sur la gestion des paragraphes de texte. Cette page illustrera comment nous pouvons gérer les puces de paragraphes. Les puces sont plus utiles lorsque quelque chose doit être décrit en étapes. De plus, le texte a un aspect bien organisé grâce à l'utilisation de puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent utiliser cette petite mais puissante fonctionnalité d'Aspose.Slides pour PHP via Java. Veuillez suivre les étapes ci-dessous pour gérer les puces de paragraphe à l'aide d'Aspose.Slides pour PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) dans la diapositive sélectionnée.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) de la forme ajoutée.
1. Supprimez le paragraphe par défaut dans le TextFrame.
1. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph).
1. Définissez le type de puce du paragraphe.
1. Définissez le type de puce sur [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) et définissez le caractère de la puce.
1. Définissez le texte du paragraphe.
1. Définissez l'indentation du paragraphe pour définir la puce.
1. Définissez la couleur de la puce.
1. Définissez la hauteur des puces.
1. Ajoutez le paragraphe créé dans la collection de paragraphes TextFrame.
1. Ajoutez le deuxième paragraphe et répétez le processus donné aux étapes **7 à 13**.
1. Enregistrez la présentation.

Ce code d'exemple — une mise en œuvre des étapes ci-dessus — vous montre comment créer une liste à puces dans une diapositive :

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter et accéder à Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre de texte de l'autoshape créé
    $txtFrm = $aShp->getTextFrame();
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->removeAt(0);
    # Créer un paragraphe
    $para = new Paragraph();
    # Définir le style de puce et le symbole du paragraphe
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Définir le texte du paragraphe
    $para->setText("Bienvenue dans Aspose.Slides");
    # Définir l'indentation de la puce
    $para->getParagraphFormat()->setIndent(25);
    # Définir la couleur de la puce
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir IsBulletHardColor sur true pour utiliser la couleur de puce propre
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Définir la hauteur de la puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajouter le paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para);
    # enregistrer la présentation en tant que fichier PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## Création de Puces d'Image

Aspose.Slides pour PHP via Java vous permet de changer les puces dans les listes à puces. Vous pouvez remplacer les puces par des symboles personnalisés ou des images. Si vous souhaitez ajouter de l'intérêt visuel à une liste ou attirer encore plus l'attention sur les éléments d'une liste, vous pouvez utiliser votre propre image comme puce.

{{% alert color="primary" %}} 

Idéalement, si vous envisagez de remplacer le symbole de puce régulier par une image, vous voudrez peut-être sélectionner une image graphique simple avec un fond transparent. De telles images fonctionnent mieux comme symboles de puce personnalisés.

Dans tous les cas, l'image que vous choisissez sera réduite à une très petite taille, il est donc fortement recommandé de choisir une image qui a fière allure (comme remplacement pour le symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce d'image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Ajoutez une autoshape dans la diapositive sélectionnée.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forme ajoutée.
1. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Créez la première instance de paragraphe à l'aide de la classe Paragraph.
1. Chargez l'image depuis le disque dans [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage).
1. Définissez le type de puce sur Picture et définissez l'image.
1. Définissez le texte du paragraphe.
1. Définissez l'indentation du paragraphe pour définir la puce.
1. Définissez la couleur de la puce.
1. Définissez la hauteur des puces.
1. Ajoutez le paragraphe créé dans la collection de paragraphes [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Ajoutez le deuxième paragraphe et répétez le processus indiqué dans les étapes précédentes.
1. Enregistrez la présentation.

Ce code PHP vous montre comment créer une puce d'image dans une diapositive :

```php
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Instancier l'image pour les puces
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajouter et accéder à Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre de texte de l'autoshape créé
    $txtFrm = $aShp->getTextFrame();
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->removeAt(0);
    # Créer un nouveau paragraphe
    $para = new Paragraph();
    $para->setText("Bienvenue dans Aspose.Slides");
    # Définir le style de puce et l'image du paragraphe
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Définir la hauteur de la puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajouter le paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para);
    # Écrire la présentation en tant que fichier PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Création de Puces Multilevel

Pour créer une liste à puces qui contient des éléments à différents niveaux — des listes supplémentaires sous la liste principale à puces — suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Ajoutez une autoshape dans la diapositive sélectionnée.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forme ajoutée.
1. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Créez la première instance de paragraphe à l'aide de la classe Paragraph et avec une profondeur définie à 0.
1. Créez la deuxième instance de paragraphe à l'aide de la classe Paragraph et avec une profondeur définie à 1.
1. Créez la troisième instance de paragraphe à l'aide de la classe Paragraph et avec une profondeur définie à 2.
1. Créez la quatrième instance de paragraphe à l'aide de la classe Paragraph et avec une profondeur définie à 3.
1. Ajoutez les paragraphes créés dans la collection de paragraphes [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Enregistrez la présentation.

Ce code, qui est une implémentation des étapes ci-dessus, vous montre comment créer une liste à puces multilevel :

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter et accéder à Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre de texte de l'autoshape créé
    $txtFrm = $aShp->addTextFrame("");
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->clear();
    # Créer le premier paragraphe
    $para1 = new Paragraph();
    # Définir le style de puce et le symbole du paragraphe
    $para1->setText("Contenu");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de la puce
    $para1->getParagraphFormat()->setDepth(0);
    # Créer le deuxième paragraphe
    $para2 = new Paragraph();
    # Définir le style de puce et le symbole du paragraphe
    $para2->setText("Deuxième niveau");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de la puce
    $para2->getParagraphFormat()->setDepth(1);
    # Créer le troisième paragraphe
    $para3 = new Paragraph();
    # Définir le style de puce et le symbole du paragraphe
    $para3->setText("Troisième niveau");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de la puce
    $para3->getParagraphFormat()->setDepth(2);
    # Créer le quatrième paragraphe
    $para4 = new Paragraph();
    # Définir le style de puce et le symbole du paragraphe
    $para4->setText("Quatrième niveau");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de la puce
    $para4->getParagraphFormat()->setDepth(3);
    # Ajouter le paragraphe au cadre de texte
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # enregistrer la présentation en tant que fichier PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Créer une Liste Numérotée Personnalisée
Aspose.Slides pour PHP via Java fournit une API simple pour gérer les paragraphes avec un formatage de numéros personnalisés. Pour ajouter une liste numérotée personnalisée dans un paragraphe, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Ajoutez une autoshape dans la diapositive sélectionnée.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forme ajoutée.
1. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Créez la première instance de paragraphe à l'aide de la classe Paragraph et définissez **NumberedBulletStartWith** sur 2.
1. Créez la deuxième instance de paragraphe à l'aide de la classe Paragraph et définissez **NumberedBulletStartWith** sur 3.
1. Créez la troisième instance de paragraphe à l'aide de la classe Paragraph et définissez **NumberedBulletStartWith** sur 7.
1. Ajoutez les paragraphes créés dans la collection de paragraphes [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Enregistrez la présentation.

Ce code PHP vous montre comment créer une liste numérotée dans une diapositive :

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter et accéder à Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre de texte de l'autoshape créé
    $txtFrm = $aShp->addTextFrame("");
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->clear();
    # Première liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("puce 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("puce 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Deuxième liste
    $paragraph5 = new Paragraph();
    $paragraph5->setText("puce 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```