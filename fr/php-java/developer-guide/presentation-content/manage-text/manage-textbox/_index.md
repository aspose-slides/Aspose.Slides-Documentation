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
description: "Aspose.Slides for PHP facilite la création, la modification et la duplication des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l'automatisation de vos présentations."
---

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis placer du texte à l'intérieur de la zone de texte. Aspose.Slides for PHP via Java fournit l'interface [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}
Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) qui vous permet d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir du texte. En revanche, les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) peuvent contenir du texte.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Par conséquent, lorsque vous travaillez avec une forme à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), qui est une propriété de `IAutoShape`. Consultez la section [Update Text](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) sur cette page.
{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte sur une diapositive, suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) avec [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet `IAutoShape` nouvellement ajouté.
4. Ajoutez la propriété `TextFrame` à l'objet `IAutoShape` qui contiendra du texte. Dans l'exemple ci‑dessus, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code PHP — une implémentation des étapes ci‑dessus — vous montre comment ajouter du texte à une diapositive :
```php
  # Instancie la présentation
  $pres = new Presentation();
  try {
    # Récupère la première diapositive de la présentation
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape avec le type défini comme Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Ajoute un TextFrame au Rectangle
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


## **Vérifier une forme de zone de texte**

Aspose.Slides fournit la méthode [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) de la classe [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), vous permettant d'examiner les formes et d'identifier les zones de texte.

![Text box and shape](istextbox.png)

Ce code PHP vous montre comment vérifier si une forme a été créée en tant que zone de texte :
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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```


Notez que si vous ajoutez simplement une autoshape en utilisant la méthode `addAutoShape` de la classe [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/), la méthode `isTextBox` de l'autoshape renverra `false`. Cependant, après avoir ajouté du texte à l'autoshape avec la méthode `addTextFrame` ou la méthode `setText`, la propriété `isTextBox` renvoie `true`.
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


## **Ajouter des colonnes à une zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) et [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (issues de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) qui vous permettent d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l'espacement en points entre les colonnes.

Ce code démontre l'opération décrite :
```php
  $pres = new Presentation();
  try {
    # Obtient la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape avec le type défini comme Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ajoute un TextFrame au rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Obtient le format de texte du TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Définit le nombre de colonnes dans le TextFrame
    $format->setColumnCount(3);
    # Définit l'espacement entre les colonnes
    $format->setColumnSpacing(10);
    # Enregistre la présentation
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter des colonnes à un cadre de texte**
Aspose.Slides for PHP via Java fournit la propriété [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)) qui vous permet d'ajouter des colonnes dans les cadres de texte. Grâce à cette propriété, vous pouvez spécifier le nombre de colonnes souhaité dans un cadre de texte.

Ce code PHP vous montre comment ajouter une colonne à l'intérieur d'un cadre de texte :
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

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes d'une présentation. 

Ce code PHP montre une opération où tous les textes d'une présentation sont mis à jour ou modifiés :
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Vérifie si la forme prend en charge le cadre de texte (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Parcourt les paragraphes du cadre de texte
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Parcourt chaque portion du paragraphe
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

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` contenant *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Assignez l'objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) associée à la portion souhaitée de votre `TextFrame`.
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code PHP — une implémentation des étapes ci‑dessus — vous montre comment ajouter une zone de texte avec un hyperlien à une diapositive :
```php
  # Instancie une classe Presentation qui représente un PPTX
  # Obtient la première diapositive de la présentation
  # Ajoute un objet AutoShape avec le type défini comme Rectangle
  # Convertit la forme en AutoShape
  # Accède à la propriété ITextFrame associée à l'AutoShape
  # Ajoute du texte au cadre
  # Définit le lien hypertexte pour le texte de la portion
  # Enregistre la présentation PPTX
  $pres = new Presentation();
  try {
    # Gets the first slide in the presentation
    $slide = $pres->getSlides()->get_Item(0);
    # Adds an AutoShape object with type set as Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Casts the shape to AutoShape
    $pptxAutoShape = $shape;
    # Accesses the ITextFrame property associated with the AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Adds some text to the frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Sets the Hyperlink for the portion text
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Saves the PPTX Presentation
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lorsqu’on travaille avec les diapositives maîtres ?**

Un [placeholder](/slides/fr/php-java/manage-placeholder/) hérite du style/position du [master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), tandis qu'une zone de texte ordinaire est un objet indépendant sur une diapositive spécifique et ne change pas lorsque vous changez de layout.

**Comment effectuer un remplacement de texte en masse dans la présentation sans toucher le texte à l'intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux auto‑shapes qui possèdent des cadres de texte et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d'objets.