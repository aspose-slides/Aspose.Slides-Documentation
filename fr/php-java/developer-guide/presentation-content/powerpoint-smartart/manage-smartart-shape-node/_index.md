---
title: Créer ou Gérer un Nœud de Forme SmartArt PowerPoint
linktitle: Gérer le Nœud de Forme SmartArt
type: docs
weight: 30
url: /fr/php-java/manage-smartart-shape-node/
keywords: smartart powerpoint, nœuds smartart, position smartart, supprimer smartart, ajouter nœuds smartart, présentation powerpoint, powerpoint java, api java powerpoint
description: Gérer le nœud smartart et le nœud enfant dans les présentations PowerPoint
---

## **Ajouter un Nœud SmartArt dans une Présentation PowerPoint en utilisant PHP**
Aspose.Slides pour PHP via Java a fourni la plus simple API pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant aidera à ajouter un nœud et un nœud enfant à l'intérieur de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) et cast l’objet sélectionné à [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si c'est du SmartArt.
1. [Ajoutez un nouveau Nœud](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) dans la forme SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) et définissez le texte dans le TextFrame.
1. Maintenant, [Ajoutez](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) un [**Nœud Enfant**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) dans le Nœud [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) nouvellement ajouté et définissez le texte dans le TextFrame.
1. Enregistrez la présentation.

```php
  # Charger la présentation souhaitée
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Parcourir chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifiez si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast la forme à SmartArt
        $smart = $shape;
        # Ajout d'un nouveau Nœud SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Ajout de texte
        $TemNode->getTextFrame()->setText("Test");
        # Ajouter un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
        $newNode = $TemNode->getChildNodes()->addNode();
        # Ajout de texte
        $newNode->getTextFrame()->setText("Nouveau Nœud Ajouté");
      }
    }
    # Enregistrer la Présentation
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter un Nœud SmartArt à une Position Spécifique**
Dans le code d'exemple suivant, nous avons expliqué comment ajouter les nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt à une position particulière.

1. Créez une instance de la classe Presentation.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Ajoutez une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) dans la diapositive accédée.
1. Accédez au premier nœud dans la forme SmartArt ajoutée.
1. Maintenant, ajoutez le [**Nœud Enfant**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) pour le [**Nœud**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) sélectionné à la position 2 et définissez son texte.
1. Enregistrez la Présentation.

```php
  # Création d'une instance de présentation
  $pres = new Presentation();
  try {
    # Accéder à la diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une forme Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accéder au nœud SmartArt à l'index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Ajouter du texte
    $chNode->getTextFrame()->setText("Texte d'Échantillon Ajouté");
    # Enregistrer la Présentation
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accéder au Nœud SmartArt dans une Présentation PowerPoint en utilisant PHP**
Le code d'exemple suivant vous aidera à accéder aux nœuds à l'intérieur de la forme SmartArt. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et n'est défini que lorsque la forme SmartArt est ajoutée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) et cast l’objet sélectionné à [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si c'est du SmartArt.
1. Parcourez tous les [**Nœuds**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Accédez et affichez des informations telles que la position du Nœud SmartArt, le niveau et le texte.

```php
  # Instancier la classe Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Obtenez la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourez chaque forme à l'intérieur de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifiez si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast la forme à SmartArt
        $smart = $shape;
        # Parcourez tous les nœuds à l'intérieur du SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accéder au nœud SmartArt à l'index i
          $node = $smart->getAllNodes()->get_Item($i);
          # Imprimer les paramètres du nœud SmartArt
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

## **Accéder au Nœud Enfant SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) et cast l’objet sélectionné à [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si c'est du SmartArt.
1. Parcourez tous les [**Nœuds**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Pour chaque forme SmartArt sélectionnée [**Nœud**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode), parcourez tous les [**Nœuds Enfants**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) à l'intérieur du nœud particulier.
1. Accédez et affichez des informations telles que la position, le niveau et le texte du [**Nœud Enfant**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--).

```php
  # Instancier la classe Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourez chaque forme à l'intérieur de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifiez si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast la forme à SmartArt
        $smart = $shape;
        # Parcourez tous les nœuds à l'intérieur du SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accéder au nœud SmartArt à l'index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Parcourir les nœuds enfants dans le nœud SmartArt à l'index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Accéder au nœud enfant dans le nœud SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Imprimer les paramètres du nœud enfant SmartArt
            System->out->print("j = " . $j . ", Texte = " . $node->getTextFrame()->getText() . ",  Niveau = " . $node->getLevel() . ", Position = " . $node->getPosition());
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

## **Accéder au Nœud Enfant SmartArt à une Position Spécifique**
Dans cet exemple, nous allons apprendre à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Ajoutez une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Accédez à la forme SmartArt ajoutée.
1. Accédez au nœud à l'index 0 pour la forme SmartArt accédée.
1. Maintenant, accédez au [**Nœud Enfant**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) à la position 1 pour le nœud SmartArt accédé en utilisant la méthode **get_Item()**.
1. Accédez et affichez des informations telles que la position, le niveau et le texte du [**Nœud Enfant**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--).

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
    # Imprimer les paramètres du nœud enfant SmartArt
    System->out->print("Texte = " . $chNode->getTextFrame()->getText() . ",  Niveau = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer un Nœud SmartArt dans une Présentation PowerPoint en utilisant PHP**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) et cast l’objet sélectionné à [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si c'est du SmartArt.
1. Vérifiez si le [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) a plus de 0 nœuds.
1. Sélectionnez le nœud SmartArt à supprimer.
1. Maintenant, supprimez le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Enregistrez la présentation.

```php
  # Charger la présentation souhaitée
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Parcourez chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifiez si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast la forme à SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accéder au nœud SmartArt à l'index 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Supprimer le nœud sélectionné
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Enregistrer la Présentation
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer un Nœud SmartArt à une Position Spécifique**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt à une position particulière.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) et cast l’objet sélectionné à [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si c'est du SmartArt.
1. Sélectionnez le nœud de forme SmartArt à l'index 0.
1. Maintenant, vérifiez si le nœud SmartArt sélectionné a plus de 2 nœuds enfants.
1. Maintenant, supprimez le nœud à **la Position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Enregistrez la présentation.

```php
  # Charger la présentation souhaitée
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Parcourez chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifiez si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast la forme à SmartArt
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
    # Enregistrer la Présentation
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir une Position Personnalisée pour le Nœud Enfant dans SmartArt**
Aspose.Slides pour PHP via Java prend maintenant en charge la définition des propriétés [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) et [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-) de [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape). Le fragment de code ci-dessous montre comment définir la position, la taille et la rotation d'un SmartArtShape personnalisé. Veuillez également noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds. Avec les paramètres de position personnalisés, l'utilisateur peut également disposer les nœuds selon les exigences.

```php
  # Instancier la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Déplacer la forme SmartArt vers une nouvelle position
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Changer la largeur des formes SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() + $shape->getWidth() * 2);
    # Changer la hauteur des formes SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() + $shape->getHeight() * 2);
    # Changer la rotation des formes SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Vérifier le Nœud Assistant**
{{% alert color="primary" %}} 

Dans cet article, nous allons explorer davantage les fonctionnalités des formes SmartArt ajoutées dans les diapos de présentation par programme en utilisant Aspose.Slides pour PHP via Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour notre étude dans différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt Source dans la diapositive**|

Dans le code d'exemple suivant, nous allons examiner comment identifier les **Nœuds Assistants** dans la collection de nœuds SmartArt et les modifier.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la deuxième diapositive en utilisant son index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) et cast l’objet sélectionné à [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si c'est du SmartArt.
1. Parcourez tous les nœuds à l'intérieur de la forme SmartArt et vérifiez s'ils sont des [**Nœuds Assistants**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
1. Changez le statut du Nœud Assistant en nœud normal.
1. Enregistrez la présentation.

```php
  # Création d'une instance de présentation
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Parcourez chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifiez si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast la forme à SmartArt
        $smart = $shape;
        # Parcourir tous les nœuds de la forme SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Vérifiez si le nœud est un nœud Assistant
          if ($node->isAssistant()) {
            # Définir le nœud Assistant sur false et le rendre nœud normal
            $node->isAssistant(false);
          }
        }
      }
    }
    # Enregistrer la Présentation
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : Nœuds Assistants Changés dans la forme SmartArt à l'intérieur de la diapositive**|

## **Définir le Format de Remplissage du Nœud**
Aspose.Slides pour PHP via Java permet d'ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage en utilisant Aspose.Slides pour PHP via Java.

Veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) en définissant son [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Définissez le [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) pour les nœuds de la forme SmartArt.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

```php
  # Instancier la présentation
  $pres = new Presentation();
  try {
    # Accéder à la diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter la forme SmartArt et les nœuds
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Du texte ici");
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

## **Générer une Miniature du Nœud Enfant SmartArt**
Les développeurs peuvent générer une miniature du nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. [Ajoutez SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtenez la référence d'un nœud en utilisant son index.
1. Obtenez l'image miniature.
1. Enregistrez l'image miniature dans le format d'image souhaité.

```php
  # Instancier la classe Presentation qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Ajouter SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Obtenir la référence d'un nœud en utilisant son index
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