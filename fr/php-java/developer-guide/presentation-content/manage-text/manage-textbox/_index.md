---
title: Gérer les zones de texte dans les présentations avec PHP
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/php-java/manage-textbox/
keywords:
  - zone de texte
  - cadre de texte
  - ajouter du texte
  - mettre à jour le texte
  - créer une zone de texte
  - vérifier la zone de texte
  - ajouter une colonne de texte
  - ajouter un hyperlien
  - PowerPoint
  - présentation
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP facilite la création, la modification et le clonage de zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l’automatisation de vos présentations."
---
## **Introduction**

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Ainsi, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis y placer du texte. Aspose.Slides for PHP via Java fournit la classe [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) qui vous permet d’ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également la classe [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) qui vous permet d’ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via la classe `Shape` ne peuvent pas contenir du texte. En revanche, les formes ajoutées via la classe [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) peuvent contenir du texte.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous traitez une forme à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu’elle a été convertie via la classe `AutoShape`. Ce n’est qu’alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/), qui est une propriété de `AutoShape`. Voir la section [Update Text](/slides/fr/php-java/manage-textbox/#update-text) sur cette page.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte sur une diapositive, suivez les étapes suivantes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Obtenir une référence à la première diapositive de la présentation récemment créée. 
3. Ajouter un objet [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) dont le type de forme est défini sur [Rectangle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapetype/#Rectangle) à une position spécifiée sur la diapositive et obtenir la référence de l’objet `AutoShape` ajouté.
4. Ajouter un `TextFrame` à l’objet `AutoShape` qui contiendra du texte. Dans l’exemple ci‑dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrire le fichier PPTX via l’objet `Presentation`. 

Ce code PHP — une implémentation des étapes ci‑dessus — montre comment ajouter du texte à une diapositive :

```php
  # Instancie la présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive de la présentation
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape avec le type défini comme Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Ajoute un TextFrame au rectangle
    $ashp->addTextFrame(" ");
    # Accède au cadre de texte
    $txtFrame = $ashp->getTextFrame();
    # Crée l'objet Paragraph pour le cadre de texte
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crée un objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    # Définit le texte
    $portion->setText("Aspose TextBox");
    # Enregistre la présentation sur le disque
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vérifier la présence d’une forme de zone de texte**

Aspose.Slides propose la méthode [isTextBox](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/istextbox/) de la classe [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) qui vous permet d’examiner les formes et d’identifier les zones de texte.

![Text box and shape](istextbox.png)

Ce code PHP montre comment vérifier si une forme a été créée comme une zone de texte :

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Notez que si vous ajoutez simplement une autoshape à l’aide de la méthode `addAutoShape` de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/), la méthode `isTextBox` de l’autoshape renverra `false`. En revanche, après avoir ajouté du texte à l’autoshape à l’aide de la méthode `addTextFrame` ou de la méthode `setText`, la propriété `isTextBox` renvoie `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() renvoie false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() renvoie true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() renvoie false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() renvoie true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() renvoie false
$shape3->addTextFrame("");
// shape3->isTextBox() renvoie false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() renvoie false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() renvoie false
```

## **Trouver la forme qui possède un TextFrame**

Dans un code de traitement de texte générique, vous pouvez recevoir un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) sans savoir quel objet de la présentation le contient. Utilisez la méthode [TextFrame::getParentShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentShape) pour revenir à la [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) propriétaire.

Pour un texte‑frame appartenant à une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) ou à une autre forme contenant du texte, [TextFrame::getParentShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentShape) renvoie le propriétaire et [TextFrame::getParentCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentCell) renvoie `null`. Les deux méthodes offrent une navigation en lecture seule, ainsi les appeler ne modifie pas la propriété. Vérifiez toujours la valeur renvoyée avec `java_is_null` avant d’accéder à la forme.

Pour un exemple complet qui identifie les propriétaires de formes et de cellules de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/php-java/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

Aspose.Slides propose les méthodes [setColumnCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/setcolumncount/) et [setColumnSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/setcolumnspacing/) de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/) qui permettent d’ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l’espacement, en points, entre les colonnes.

Ce code montre l’opération décrite :

```php
  $pres = new Presentation();
  try {
    # Obtient la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape avec le type défini comme Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ajoute un TextFrame au rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Obtient le format du texte du TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Spécifie le nombre de colonnes dans le TextFrame
    $format->setColumnCount(3);
    # Spécifie l'espacement entre les colonnes
    $format->setColumnSpacing(10);
    # Enregistre la présentation
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter des colonnes à un TextFrame**

Aspose.Slides for PHP via Java propose la méthode [setColumnCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/setcolumncount/) de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/) qui permet d’ajouter des colonnes dans les TextFrames. Grâce à cette propriété, vous pouvez spécifier le nombre de colonnes souhaité dans un TextFrame.

Ce code PHP montre comment ajouter une colonne à l’intérieur d’un TextFrame :

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes d’une présentation. 

Ce code PHP montre une opération où tous les textes d’une présentation sont mis à jour ou modifiés :

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Vérifie si la forme prend en charge le cadre de texte (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itère à travers les paragraphes du cadre de texte
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Itère à travers chaque portion du paragraphe
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Modifie le texte

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Modifie le formatage

            }
          }
        }
      }
    }
    # Enregistre la présentation modifiée
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter une zone de texte avec un hyperlien**

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créer une instance de la classe `Presentation`. 
2. Obtenir une référence à la première diapositive de la présentation récemment créée. 
3. Ajouter un objet `AutoShape` dont le `ShapeType` est `Rectangle` à une position spécifiée sur la diapositive et obtenir la référence de l’objet AutoShape ajouté.
4. Ajouter un `TextFrame` à l’objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instancier la classe `HyperlinkManager`. 
6. Attribuer un hyperlien en utilisant la méthode [setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) associée à la partie souhaitée du `TextFrame`.
7. Enfin, écrire le fichier PPTX via l’objet `Presentation`. 

Ce code PHP — une implémentation des étapes ci‑dessus — montre comment ajouter une zone de texte avec un hyperlien à une diapositive :

```php
  # Instancie une classe Presentation qui représente un PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute un objet AutoShape avec le type défini comme Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Convertit la forme en AutoShape
    $pptxAutoShape = $shape;
    # Accède à la propriété ITextFrame associée à l'AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Ajoute du texte au cadre
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Définit l'hyperlien pour le texte de la portion
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Enregistre la présentation PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lors de l’utilisation des diapositives maîtres ?**

Un [placeholder](/slides/fr/php-java/manage-placeholder/) hérite du style/position du [master](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/), tandis qu’une zone de texte ordinaire est un objet indépendant sur une diapositive spécifique et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement massif de texte dans toute la présentation sans toucher au texte à l’intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux auto‑shapes qui possèdent des TextFrames et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/fr/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartart/)) en parcourant leurs collections séparément ou en sautant ces types d’objets.