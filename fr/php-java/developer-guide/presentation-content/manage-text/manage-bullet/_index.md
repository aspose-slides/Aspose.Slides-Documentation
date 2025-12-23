---
title: Gérer les listes à puces et numérotées dans les présentations avec PHP
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/php-java/manage-bullet/
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
- PHP
- Aspose.Slides
description: "Apprenez à gérer les listes à puces et numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java. Guide étape par étape."
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même façon que dans Word et les autres éditeurs de texte. **Aspose.Slides for PHP via Java** vous permet également d'utiliser des puces et des numéros dans les diapositives de vos présentations.

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et présenter l'information rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l'attention de vos lecteurs ou spectateurs sur des informations importantes
- permet à vos lecteurs ou spectateurs de parcourir facilement les points clés
- communique et transmet les détails importants efficacement.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et présenter l'information. Idéalement, vous devez utiliser des chiffres (à la place des puces) lorsque l'ordre des éléments (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu'un élément doit être référencé (par exemple, *voir l'étape 3*).

**Exemple de liste numérotée**

Ceci est un résumé des étapes (étape 1 à étape 15) dans la procédure **Creating Bullets** ci‑dessous :

1. Créez une instance de la classe de présentation. 
2. Effectuez plusieurs tâches (étape 3 à étape 14).
3. Enregistrez la présentation. 

## **Créer des puces**
Ce sujet fait également partie de la série sur la gestion des paragraphes de texte. Cette page illustre comment gérer les puces de paragraphe. Les puces sont utiles lorsqu'un contenu doit être décrit étape par étape. De plus, le texte apparaît mieux organisé grâce à l'utilisation de puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent exploiter cette petite mais puissante fonctionnalité d’Aspose.Slides for PHP via Java. Veuillez suivre les étapes ci‑dessous pour gérer les puces de paragraphe à l’aide d’Aspose.Slides for PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le TextFrame.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph).
7. Définissez le type de puce du paragraphe.
8. Définissez le type de puce à [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) et spécifiez le caractère de la puce.
9. Définissez le texte du paragraphe.
10. Définissez le retrait du paragraphe pour positionner la puce.
11. Définissez la couleur de la puce.
12. Définissez la hauteur des puces.
13. Ajoutez le paragraphe créé dans la collection de paragraphes du TextFrame.
14. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes **7 à 13**.
15. Enregistrez la présentation.

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter et accéder à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre texte de l'AutoShape créé
    $txtFrm = $aShp->getTextFrame();
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->removeAt(0);
    # Créer un paragraphe
    $para = new Paragraph();
    # Définir le style de puce du paragraphe et le symbole
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Définir le texte du paragraphe
    $para->setText("Welcome to Aspose.Slides");
    # Définir le retrait de la puce
    $para->getParagraphFormat()->setIndent(25);
    # Définir la couleur de la puce
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir IsBulletHardColor à true pour utiliser votre propre couleur de puce
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Définir la hauteur de la puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajouter le paragraphe au cadre texte
    $txtFrm->getParagraphs()->add($para);
    # Enregistrer la présentation en tant que fichier PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Créer des puces d'image**

Aspose.Slides for PHP via Java vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer encore plus l'attention sur les éléments d'une liste, vous pouvez utiliser votre propre image comme puce.

{{% alert color="primary" %}} 

Idéalement, si vous envisagez de remplacer le symbole de puce standard par une image, vous pouvez choisir une image graphique simple avec un fond transparent. Ces images fonctionnent le mieux comme symboles de puce personnalisés. 

Dans tous les cas, l'image que vous choisissez sera réduite à une taille très petite, nous vous recommandons donc fortement de sélectionner une image qui reste de bonne qualité (en tant que remplacement du symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce d'image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
3. Ajoutez une forme automatique (autoshape) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
6. Créez la première instance de paragraphe en utilisant la classe Paragraph.
7. Chargez l'image depuis le disque dans [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage).
8. Définissez le type de puce sur Image et définissez l'image.
9. Définissez le texte du paragraphe.
10. Définissez le retrait du paragraphe pour positionner la puce.
11. Définissez la couleur de la puce.
12. Définissez la hauteur des puces.
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
14. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes précédentes.
15. Enregistrez la présentation.

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
    # Ajouter et accéder à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre texte de l'AutoShape créé
    $txtFrm = $aShp->getTextFrame();
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->removeAt(0);
    # Créer un nouveau paragraphe
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # Définir le style de puce du paragraphe et l'image
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Définir la hauteur de la puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajouter le paragraphe au cadre texte
    $txtFrm->getParagraphs()->add($para);
    # Enregistrer la présentation en tant que fichier PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Créer des puces à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux — des listes supplémentaires sous la liste principale — suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
3. Ajoutez une forme automatique (autoshape) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
6. Créez la première instance de paragraphe en utilisant la classe Paragraph avec une profondeur de 0.
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph avec une profondeur de 1.
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph avec une profondeur de 2.
9. Créez la quatrième instance de paragraphe en utilisant la classe Paragraph avec une profondeur de 3.
10. Ajoutez les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
11. Enregistrez la présentation.

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter et accéder à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre texte de l'AutoShape créé
    $txtFrm = $aShp->addTextFrame("");
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->clear();
    # Créer le premier paragraphe
    $para1 = new Paragraph();
    # Définir le style de puce du paragraphe et le symbole
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de puce
    $para1->getParagraphFormat()->setDepth(0);
    # Créer le deuxième paragraphe
    $para2 = new Paragraph();
    # Définir le style de puce du paragraphe et le symbole
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de puce
    $para2->getParagraphFormat()->setDepth(1);
    # Créer le troisième paragraphe
    $para3 = new Paragraph();
    # Définir le style de puce du paragraphe et le symbole
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de puce
    $para3->getParagraphFormat()->setDepth(2);
    # Créer le quatrième paragraphe
    $para4 = new Paragraph();
    # Définir le style de puce du paragraphe et le symbole
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définir le niveau de puce
    $para4->getParagraphFormat()->setDepth(3);
    # Ajouter le paragraphe au cadre texte
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # Enregistrer la présentation en tant que fichier PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Créer des listes numérotées personnalisées**

Aspose.Slides for PHP via Java fournit une API simple pour gérer les paragraphes avec un formatage de numérotation personnalisé. Pour ajouter une liste numérotée personnalisée dans un paragraphe, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l'aide de l'objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
3. Ajoutez une forme automatique (autoshape) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
6. Créez la première instance de paragraphe en utilisant la classe Paragraph et définissez **NumberedBulletStartWith** à 2
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph et définissez **NumberedBulletStartWith** à 3
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph et définissez **NumberedBulletStartWith** à 7
9. Ajoutez les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
10. Enregistrez la présentation.

```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter et accéder à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accéder au cadre texte de l'AutoShape créé
    $txtFrm = $aShp->addTextFrame("");
    # Supprimer le paragraphe par défaut existant
    $txtFrm->getParagraphs()->clear();
    # Première liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Deuxième liste
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
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


## **FAQ**

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent-elles être exportées vers d'autres formats tels que PDF ou images ?**

Oui, Aspose.Slides préserve pleinement la mise en forme et la structure des listes à puces et numérotées lors de l'exportation des présentations vers des formats tels que PDF, images, et autres, garantissant des résultats cohérents.

**Est-il possible d'importer des listes à puces ou numérotées à partir de présentations existantes ?**

Oui, Aspose.Slides permet d'importer et de modifier des listes à puces ou numérotées à partir de présentations existantes tout en préservant leur mise en forme et apparence originales.

**Aspose.Slides prend-il en charge les listes à puces et numérotées dans des présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n'importe quelle langue, y compris l'utilisation de caractères spéciaux ou non latins.