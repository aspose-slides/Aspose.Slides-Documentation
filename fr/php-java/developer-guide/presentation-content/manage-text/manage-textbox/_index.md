---
title: Gérer TextBox
type: docs
weight: 20
url: /fr/php-java/manage-textbox/
description: Créer une zone de texte sur des diapositives PowerPoint en utilisant PHP. Ajouter une colonne dans une zone de texte ou un cadre de texte dans des diapositives PowerPoint en utilisant PHP. Ajouter une zone de texte avec un lien hypertexte dans des diapositives PowerPoint en utilisant PHP.
---


Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter un texte à une diapositive, vous devez ajouter une zone de texte et ensuite mettre du texte à l'intérieur de cette zone de texte. Aspose.Slides for PHP via Java fournit l'interface [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) qui vous permet d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Mais les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) peuvent contenir du texte.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous traitez une forme à laquelle vous souhaitez ajouter du texte, vous voudrez peut-être vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'à ce moment-là que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), qui est une propriété sous `IAutoShape`. Consultez la section [Mettre à jour le texte](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) sur cette page.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence pour la première diapositive dans la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) avec `ShapeType` défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence pour l'objet `IAutoShape` nouvellement ajouté.
4. Ajoutez une propriété `TextFrame` à l'objet `IAutoShape` qui contiendra un texte. Dans l'exemple ci-dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code PHP—une implémentation des étapes ci-dessus—vous montre comment ajouter du texte à une diapositive :

```php
  # Instancie la présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive dans la présentation
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
    # Sauvegarde la présentation sur le disque
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vérifier la forme de la zone de texte**

Aspose.Slides fournit la propriété [isTextBox()](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) (de la classe [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)) pour vous permettre d'examiner les formes et de trouver des zones de texte.

![Zone de texte et forme](istextbox.png)

Ce code PHP vous montre comment vérifier si une forme a été créée en tant que zone de texte :

```php
class ShapeCallback {
    function invoke($shape, $slide, $index){
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape")))
        $autoShape = $shape;
        echo(java_is_true($autoShape->isTextBox()) ? "la forme est une zone de texte" : "la forme est un texte, pas une zone");
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($pres, $forEachShapeCallback);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter une colonne dans la zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) et [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) qui vous permettent d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l'espacement entre les colonnes en points.

Ce code démontre l'opération décrite :

```php
  $pres = new Presentation();
  try {
    # Obtient la première diapositive dans la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape avec le type défini comme Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ajoute un TextFrame au Rectangle
    $aShape->addTextFrame("Toutes ces colonnes sont limitées à rester dans un seul conteneur de texte -- " . "vous pouvez ajouter ou supprimer du texte et le texte nouveau ou restant s'ajuste automatiquement " . "pour s'écouler dans le conteneur. Vous ne pouvez pas faire couler du texte d'un conteneur " . "à un autre cependant -- nous vous avons dit que les options de colonnes de PowerPoint pour le texte sont limitées !");
    # Obtient le format du texte du TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Spécifie le nombre de colonnes dans le TextFrame
    $format->setColumnCount(3);
    # Spécifie l'espacement entre les colonnes
    $format->setColumnSpacing(10);
    # Sauvegarde la présentation
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter une colonne dans le cadre de texte**
Aspose.Slides for PHP via Java fournit la propriété [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)) qui vous permet d'ajouter des colonnes dans les cadres de texte. Grâce à cette propriété, vous pouvez spécifier votre nombre préféré de colonnes dans un cadre de texte.

Ce code PHP vous montre comment ajouter une colonne à l'intérieur d'un cadre de texte :

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("Toutes ces colonnes sont forcées de rester dans un seul conteneur de texte -- " . "vous pouvez ajouter ou supprimer du texte - et le nouveau texte ou le texte restant s'ajuste automatiquement " . "pour rester dans le conteneur. Vous ne pouvez pas faire déborder le texte d'un conteneur " . "à un autre, cependant -- car les options de colonnes de PowerPoint pour le texte sont limitées !");
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

Aspose.Slides vous permet de changer ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes contenus dans une présentation. 

Ce code PHP démontre une opération où tous les textes d'une présentation sont mis à jour ou changés :

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Vérifie si la forme prend en charge le cadre de texte (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itère à travers les paragraphes dans le cadre de texte
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Itère à travers chaque portion dans le paragraphe
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Change le texte

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Change le format

            }
          }
        }
      }
    }
    # Sauvegarde la présentation modifiée
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter une zone de texte avec un lien hypertexte** 

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés pour ouvrir le lien. 

 Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence pour la première diapositive dans la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Assignez l'objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) associée à votre portion préférée du `TextFrame`.
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code PHP—une implémentation des étapes ci-dessus—vous montre comment ajouter une zone de texte avec un lien hypertexte à une diapositive :

```php
  # Instancie une classe Presentation qui représente un PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive dans la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute un objet AutoShape avec le type défini comme Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Cast la forme en AutoShape
    $pptxAutoShape = $shape;
    # Accède à la propriété ITextFrame associée à l'AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Ajoute du texte au cadre
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Définit le lien hypertexte pour le texte de la portion
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Sauvegarde la présentation PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```