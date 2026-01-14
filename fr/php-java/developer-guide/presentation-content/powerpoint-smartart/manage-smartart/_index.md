---
title: Gérer SmartArt dans les présentations PowerPoint avec PHP
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/php-java/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme image
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour PHP via Java en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte d'un objet SmartArt**
Maintenant la méthode TextFrame a été ajoutée à la classe [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) même s'il ne contient pas uniquement le texte des nœuds. Le code d'exemple suivant vous aidera à récupérer le texte d'un nœud SmartArt.
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


## **Modifier le type de disposition d'un objet SmartArt**
Afin de modifier le type de disposition de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) BasicBlockList.
- Modifiez le [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) en BasicProcess.
- Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # Modifier LayoutType en BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Enregistrement de la présentation
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Vérifier la propriété Hidden d'un objet SmartArt**
Veuillez noter : la méthode [SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) renvoie `true` si ce nœud est masqué dans le modèle de données. Afin de vérifier la propriété hidden de n’importe quel nœud de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) RadialCycle.
- Ajoutez un nœud sur le SmartArt.
- Vérifiez la propriété [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/).
- Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Ajouter un nœud sur SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Vérifier la propriété isHidden
    $hidden = $node->isHidden();// Renvoie true

    if ($hidden) {
      # Effectuer des actions ou des notifications
    }
    # Enregistrement de la présentation
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir ou définir le type de diagramme d’organisation**
Les méthodes [SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) et [SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) permettent d’obtenir ou de définir le type de diagramme d’organisation associé au nœud actuel. Afin d’obtenir ou de définir le type de diagramme d’organisation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) sur la diapositive.
- Obtenez ou [définissez le type de diagramme d’organisation](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/).
- Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Obtenir ou définir le type d'organigramme
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Enregistrement de la présentation
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Créer un diagramme PictureOrganization**
Aspose.Slides for PHP via Java fournit une API simple pour créer des diagrammes PictureOrganization facilement. Pour créer un diagramme sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive par son index.
3. Ajoutez un diagramme avec les données par défaut ainsi que le type souhaité (ChartType::PictureOrganizationChart).
4. Enregistrez la présentation modifiée au format PPTX

Le code suivant est utilisé pour créer un diagramme.
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


## **Obtenir ou définir l’état du SmartArt**
Afin de modifier le type de disposition de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) sur la diapositive.
3. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/) ou [Set](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) l’état du diagramme SmartArt.
4. Enregistrez la présentation au format PPTX.

Le code suivant est utilisé pour créer un diagramme.
```php
  # Instancier la classe Presentation qui représente le fichier PPTX
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


## **FAQ**

**Le SmartArt prend‑il en charge le miroir/l’inversion pour les langues RTL ?**

Oui. La méthode [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) bascule la direction du diagramme (LTR/RTL) si le type SmartArt sélectionné prend en charge l’inversion.

**Comment puis‑je copier le SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/php-java/shape-manipulations/) via la collection de formes ([ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) ou [cloner la diapositive entière](/slides/fr/php-java/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation web ?**

[Rendez la diapositive](/slides/fr/php-java/convert-powerpoint-to-png/) (ou l’ensemble de la présentation) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images — le SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner programmatiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) ou un [nom](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) et à rechercher la forme par cet attribut dans les [formes de la diapositive](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), puis à vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). La documentation décrit les techniques typiques pour trouver et manipuler les formes.