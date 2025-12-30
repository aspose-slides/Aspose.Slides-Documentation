---
title: Gérer SmartArt dans les présentations PowerPoint avec PHP
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/php-java/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour PHP via Java en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte d'un objet SmartArt**
La méthode **TextFrame** a été ajoutée à l’interface [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape). Cette propriété vous permet d’obtenir tout le texte du [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) lorsqu’il ne contient pas seulement le texte des nœuds. Le code d’exemple suivant vous aidera à récupérer le texte d’un nœud SmartArt.
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


## **Modifier le type de mise en page d'un objet SmartArt**
Pour changer le type de mise en page d’un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) **BasicBlockList**.
- Changez le [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) en **BasicProcess**.
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


## **Vérifier la propriété « Hidden » d’un objet SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) renvoie **true** si ce nœud est masqué dans le modèle de données. Pour vérifier la propriété masquée d’un nœud de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) **RadialCycle**.
- Ajoutez un nœud au SmartArt.
- Vérifiez la propriété [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) .
- Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessus, nous avons ajouté un connecteur entre deux formes.
```php
  $pres = new Presentation();
  try {
    # Ajouter SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Ajouter un nœud sur SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Vérifier la propriété isHidden
    $hidden = $node->isHidden();// Retourne true

    if ($hidden) {
      # Faire certaines actions ou notifications
    }
    # Enregistrement de la présentation
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir ou définir le type d’organigramme**
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d’obtenir ou de définir le type d’organigramme associé au nœud actuel. Pour obtenir ou définir ce type, suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenez ou [définissez le type d’organigramme](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Enregistrez la présentation au format PPTX.  
Dans l’exemple ci‑dessus, nous avons ajouté un connecteur entre deux formes.
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


## **Créer un organigramme de type « Picture »**
Aspose.Slides for PHP via Java propose une API simple pour créer facilement des graphiques **PictureOrganization**. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive par son index.
3. Ajoutez un graphique avec les données par défaut en spécifiant le type souhaité (**ChartType::PictureOrganizationChart**).
4. Enregistrez la présentation modifiée au format PPTX.

Le code suivant est utilisé pour créer le graphique.
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


## **Obtenir ou définir l’état d’un SmartArt**
Pour changer le type de mise en page d’un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Ajoutez un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
3. [Obtenez](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) ou [définissez](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) l’état du diagramme SmartArt.
4. Enregistrez la présentation au format PPTX.

Le code suivant est utilisé pour créer le graphique.
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

Oui. La méthode [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) inverse la direction du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/php-java/shape-manipulations/) via la collection de formes ([ShapeCollection.addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) ou [cloner la diapositive entière](/slides/fr/php-java/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre un SmartArt sous forme d’image raster pour un aperçu ou une exportation web ?**

[Renderisez la diapositive](/slides/fr/php-java/convert-powerpoint-to-png/) (ou la présentation entière) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images ; le SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner programmatiquement un SmartArt spécifique sur une diapositive lorsqu’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le **texte alternatif** ([shape.getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)) ou le **nom** ([shape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/)) et à rechercher la forme par cet attribut dans les [formes de la diapositive](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), puis à vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). La documentation décrit les techniques typiques pour retrouver et manipuler les formes.