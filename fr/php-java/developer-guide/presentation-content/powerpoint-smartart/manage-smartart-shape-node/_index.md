---
title: Gérer les nœuds de forme SmartArt dans les présentations avec PHP
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/php-java/manage-smartart-shape-node/
keywords:
- nœud SmartArt
- nœud enfant
- ajouter un nœud
- position du nœud
- accéder au nœud
- supprimer le nœud
- position personnalisée
- nœud assistant
- format de remplissage
- rendre le nœud
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans les fichiers PPT et PPTX avec Aspose.Slides pour PHP via Java. Obtenez des exemples de code clairs et des astuces pour optimiser vos présentations."
---

## **Ajouter un nœud SmartArt**
Aspose.Slides pour PHP via Java a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant vous aidera à ajouter un nœud et un nœud enfant à l'intérieur d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et charger la présentation contenant la forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) si c'est du SmartArt.
5. [Ajouter un nouveau nœud](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) dans la collection **NodeCollection** de la forme SmartArt et définir le texte dans le TextFrame.
6. Maintenant, [Ajouter](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) un **nœud enfant** dans le nœud SmartArt récemment ajouté et définir le texte dans le TextFrame.
7. Enregistrer la présentation.
```php
  # Charger la présentation souhaitée
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Parcourir chaque forme de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArt
        $smart = $shape;
        # Ajouter un nouveau nœud SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Ajouter du texte
        $TemNode->getTextFrame()->setText("Test");
        # Ajouter un nouveau nœud enfant au nœud parent. Il sera ajouté à la fin de la collection
        $newNode = $TemNode->getChildNodes()->addNode();
        # Ajouter du texte
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Enregistrer la présentation
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt à une position particulière.

1. Créer une instance de la classe Presentation.
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Ajouter une forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) de type [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) dans la diapositive accessible.
4. Accéder au premier nœud de la forme SmartArt ajoutée.
5. Maintenant, ajouter le **nœud enfant** pour le **nœud** sélectionné à la position 2 et définir son texte.
6. Enregistrer la présentation.
```php
  # Créer une instance de présentation
  $pres = new Presentation();
  try {
    # Accéder à la diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter un Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accéder au nœud SmartArt à l'index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Ajouter du texte
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Enregistrer la présentation
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Accéder à un nœud SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds à l'intérieur d'une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lors de l'ajout de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et charger la présentation contenant la forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) si c'est du SmartArt.
5. Parcourir tous les **nœuds** à l'intérieur de la forme SmartArt.
6. Accéder et afficher des informations telles que la position du nœud SmartArt, le niveau et le texte.
```php
  # Instancier la classe Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourir chaque forme de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArt
        $smart = $shape;
        # Parcourir tous les nœuds à l'intérieur du SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accéder au nœud SmartArt à l'index i
          $node = $smart->getAllNodes()->get_Item($i);
          # Afficher les paramètres du nœud SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Accéder à un nœud enfant SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et charger la présentation contenant la forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) si c'est du SmartArt.
5. Parcourir tous les **nœuds** à l'intérieur de la forme SmartArt.
6. Pour chaque **nœud** de forme SmartArt sélectionné, parcourir tous les **nœuds enfants** à l'intérieur du nœud particulier.
7. Accéder et afficher des informations telles que la position du **nœud enfant**, le niveau et le texte.
```php
  # Instancier la classe Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourir chaque forme de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArt
        $smart = $shape;
        # Parcourir tous les nœuds à l'intérieur du SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accéder au nœud SmartArt à l'index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Parcourir les nœuds enfants du nœud SmartArt à l'index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Accéder au nœud enfant dans le nœud SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Afficher les paramètres du nœud enfant SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Accéder à un nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Ajouter une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
4. Accéder à la forme SmartArt ajoutée.
5. Accéder au nœud d'index 0 de la forme SmartArt.
6. Maintenant, accéder au **nœud enfant** à la position 1 du nœud SmartArt en utilisant la méthode **get_Item()**.
7. Accéder et afficher des informations telles que la position du **nœud enfant**, le niveau et le texte.
```php
  # Instancier la présentation
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter la forme SmartArt dans la première diapositive
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accéder au nœud SmartArt à l'index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Accéder au nœud enfant à la position 1 dans le nœud parent
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Afficher les paramètres du nœud enfant SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l'intérieur d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et charger la présentation contenant la forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) si c'est du SmartArt.
5. Vérifier si le SmartArt possède plus de 0 nœud.
6. Sélectionner le nœud SmartArt à supprimer.
7. Maintenant, supprimer le nœud sélectionné à l'aide de la méthode [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. Enregistrer la présentation.
```php
  # Charger la présentation souhaitée
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Parcourir chaque forme de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accéder au nœud SmartArt à l'index 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Supprimer le nœud sélectionné
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Enregistrer la présentation
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Supprimer un nœud SmartArt d'une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l'intérieur d'une forme SmartArt à une position particulière.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et charger la présentation contenant la forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son indice.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) si c'est du SmartArt.
5. Sélectionner le nœud de forme SmartArt à l'indice 0.
6. Vérifier si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
7. Supprimer le nœud à la **position 1** à l'aide de la méthode [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. Enregistrer la présentation.
```php
  # Charger la présentation souhaitée
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Parcourir chaque forme de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accéder au nœud SmartArt à l'index 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Supprimer le nœud enfant à la position 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Enregistrer la présentation
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir une position personnalisée pour un nœud enfant dans un objet SmartArt**
Aspose.Slides pour PHP via Java prend en charge la définition des propriétés [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setX) et [Y](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setY). Le fragment de code ci‑dessous montre comment définir la position, la taille et la rotation personnalisées d’une SmartArtShape ; notez également que l’ajout de nouveaux nœuds provoque un recalcul des positions et des tailles de tous les nœuds. Avec les paramètres de position personnalisés, l’utilisateur peut placer les nœuds selon les exigences.
```php
  # Instancier la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Déplacer la forme SmartArt à une nouvelle position
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Modifier la largeur de la forme SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Modifier la hauteur de la forme SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Modifier la rotation de la forme SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Vérifier un nœud Assistant**
{{% alert color="primary" %}} 

Dans cet article, nous approfondirons les fonctionnalités des formes SmartArt ajoutées aux diapositives de présentation de façon programmatique à l’aide d’Aspose.Slides pour PHP via Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour nos investigations dans les différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt source dans la diapositive**|

Dans le code d'exemple suivant, nous étudierons comment identifier les **nœuds Assistant** dans la collection de nœuds SmartArt et les modifier.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et charger la présentation contenant la forme SmartArt.
2. Obtenir la référence de la deuxième diapositive en utilisant son indice.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) si c'est du SmartArt.
5. Parcourir tous les nœuds de la forme SmartArt et vérifier s’ils sont des [**nœuds Assistant**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
6. Modifier le statut du nœud Assistant en nœud normal.
7. Enregistrer la présentation.
```php
  # Créer une instance de présentation
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Parcourir chaque forme de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArt
        $smart = $shape;
        # Parcourir tous les nœuds de la forme SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Vérifier si le nœud est un nœud Assistant
          if ($node->isAssistant()) {
            # Définir le nœud Assistant sur false et le transformer en nœud normal
            $node->isAssistant();
          }
        }
      }
    }
    # Enregistrer la présentation
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : Nœuds Assistant modifiés dans la forme SmartArt de la diapositive**|

## **Définir le format de remplissage d’un nœud**
Aspose.Slides pour PHP via Java permet d’ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides pour PHP via Java.

Veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Obtenir la référence d’une diapositive en utilisant son indice.
3. Ajouter une forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) en définissant son [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Définir le [**Fill Format**](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFillFormat) pour les nœuds de la forme SmartArt.
5. Enregistrer la présentation modifiée au format PPTX.
```php
  # Instancier la présentation
  $pres = new Presentation();
  try {
    # Accéder à la diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter la forme SmartArt et les nœuds
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Définir la couleur de remplissage du nœud
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Enregistrer la présentation
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Générer une vignette d’un nœud enfant SmartArt**
Les développeurs peuvent générer une vignette du nœud enfant d’un SmartArt en suivant les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. [Ajouter SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode).
3. Obtenir la référence d’un nœud en utilisant son indice.
4. Extraire l’image miniature.
5. Enregistrer l’image miniature dans le format d’image souhaité.
```php
  # Instancier la classe Presentation qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Ajouter SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Obtenir la référence d'un nœud en utilisant son indice
    $node = $smart->getNodes()->get_Item(1);
    # Obtenir la miniature
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Enregistrer la miniature
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**L’animation SmartArt est‑elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/php-java/shape-animation/) (entrée, sortie, mise en relief, trajectoires) et ajuster le timing. Vous pouvez également animer les formes à l’intérieur des nœuds SmartArt si besoin.

**Comment localiser de manière fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). Définir un AltText distinctif sur le SmartArt permet de le trouver programmatiquement sans dépendre des identifiants internes.

**L’apparence du SmartArt sera‑t‑elle préservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une haute fidélité visuelle lors de l’[export PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), préservant la disposition, les couleurs et les effets.

**Puis‑je extraire une image de l’ensemble du SmartArt (pour des aperçus ou des rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt en [formats raster](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ou en [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) pour une sortie vectorielle évolutive, ce qui la rend adaptée aux vignettes, rapports ou utilisations Web.