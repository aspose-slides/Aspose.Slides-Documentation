---
title: Gérer SmartArt
type: docs
weight: 10
url: /php-java/manage-smartart/
---

## **Obtenir du texte à partir de SmartArt**
Maintenant, la méthode TextFrame a été ajoutée à l'interface [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) s'il ne contient pas uniquement du texte des nœuds. Le code exemple suivant vous aidera à obtenir du texte à partir d'un nœud SmartArt.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer le type de mise en page de SmartArt**
Pour changer le type de mise en page de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Changez [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) en BasicProcess.
- Enregistrez la présentation sous forme de fichier PPTX.
  Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # Changer LayoutType en BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Enregistrement de la présentation
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vérifier la propriété cachée de SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) retourne vrai si ce nœud est un nœud caché dans le modèle de données. Pour vérifier la propriété cachée de n'importe quel nœud de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Ajoutez [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajoutez un nœud sur SmartArt.
- Vérifiez la propriété [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--).
- Enregistrez la présentation sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Ajouter un nœud sur SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Vérifier la propriété isHidden
    $hidden = $node->isHidden();// Retourne vrai

    if ($hidden) {
      # Effectuer certaines actions ou notifications
    }
    # Enregistrement de la présentation
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir ou définir le type de graphique organisationnel**
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d'obtenir ou de définir le type de graphique organisationnel associé au nœud actuel. Pour obtenir ou définir le type de graphique organisationnel, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Ajoutez [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenez ou [définissez le type de graphique organisationnel](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Enregistrez la présentation sous forme de fichier PPTX.
  Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Obtenir ou définir le type de graphique organisationnel
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Enregistrement de la présentation
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Créer un graphique organisationnel avec images**
Aspose.Slides pour PHP via Java fournit une API simple pour créer des graphiques et des graphiques d'organisation d'images de manière simple. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type désiré (ChartType::PictureOrganizationChart).
4. Écrivez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique.

```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir ou définir l'état de SmartArt**
Pour changer le type de mise en page de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Ajoutez [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
3. [Obtenez](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) ou [définissez](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) l'état du diagramme SmartArt.
4. Enregistrez la présentation sous forme de fichier PPTX.

Le code suivant est utilisé pour créer un graphique.

```php
  # Instancier la classe Presentation représentant le fichier PPTX
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Obtenir ou définir l'état du diagramme SmartArt
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # Enregistrement de la présentation
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```